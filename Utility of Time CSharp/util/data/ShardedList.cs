using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace UoT.util.data {
  public interface IShardedListAddress {
    int Offset { get; }
  }

  public interface IShardedList<T> : IEnumerable<T> {
    IShardedList<T>? Parent { get; }
    IShardedListAddress GlobalOffset { get; }
    int Length { get; }

    T this[int localOffset] { get; set; }

    IShardedList<T> Shard(int localOffset, int length);

    // TODO: Resizing
  }

  public class ShardedList<T> : IShardedList<T> {
    private readonly IList<IShardedList<T>> regions_ =
        new List<IShardedList<T>>();

    private ShardedList(
        ShardedList<T>? parent,
        T[] ts
    ) {
      this.regions_.Add(new RawShardedList<T>(this, ts));

      this.Parent = parent;

      if (parent != null) {
        this.GlobalOffset = new ShardedListAddress(
            () => parent.LocateRegion_(this));
      } else {
        this.GlobalOffset = new NullShardedListAddress();
      }
    }

    public static ShardedList<T> From(params T[] ts)
      => new ShardedList<T>(null, ts);

    public IShardedList<T>? Parent { get; }
    public IShardedListAddress GlobalOffset { get; }

    // TODO: Can this be cached?
    public int Length => this.regions_.Sum(region => region.Length);

    public T this[int localOffset] {
      get {
        this.GetRegionAtLocalOffset_(localOffset,
                                     out var region,
                                     out var regionOffset,
                                     out _);
        return region[localOffset - regionOffset];
      }
      set {
        this.GetRegionAtLocalOffset_(localOffset,
                                     out var region,
                                     out var regionOffset,
                                     out _);
        region[localOffset - regionOffset] = value;
      }
    }

    private void GetRegionAtLocalOffset_(
        int localOffset,
        out IShardedList<T> region,
        out int regionOffset,
        out int regionIndex) {
      Asserts.Assert(localOffset >= 0, "Tried to access a negative offset!");
      Asserts.Assert(localOffset < this.Length,
                     "Tried to access beyond the end of the region!");

      var currentRegionOffset = 0;
      for (var i = 0; i < this.regions_.Count; ++i) {
        var currentRegion = this.regions_[i];
        var nextRegionOffset = currentRegionOffset + currentRegion.Length;
        if (localOffset >= currentRegionOffset &&
            localOffset < nextRegionOffset) {
          region = currentRegion;
          regionOffset = currentRegionOffset;
          regionIndex = i;
          return;
        }
        currentRegionOffset = nextRegionOffset;
      }

      region = this;
      regionOffset = -1;
      regionIndex = -1;
      Asserts.Fail("Failed to find a matching region, this should not happen.");
    }

    public IShardedList<T> Shard(int localOffset, int length) {
      Asserts.Assert(length > 0, "Tried to shard a region of size 0!");
      Asserts.Assert(localOffset + length <= this.Length,
                     "Tried to shard a region that extends beyond the size of this shard!");

      if (localOffset == 0 && length == this.Length) {
        return this;
      }

      this.GetRegionAtLocalOffset_(localOffset,
                                   out var region,
                                   out var regionOffset,
                                   out var regionIndex);

      var rawRegion = region as RawShardedList<T>;
      Asserts.Assert(rawRegion != null,
                     "Tried to shard a previously sharded region.");

      var regionLocalOffset = localOffset - regionOffset;
      Asserts.Assert(regionLocalOffset + length <= region.Length,
                     "New shard spans multiple regions.");

      var beforeLength = regionLocalOffset;
      var newRegionLength = length;
      var afterLength = region.Length - (beforeLength + newRegionLength);

      this.regions_.RemoveAt(regionIndex);

      var regionImpl = rawRegion!.Impl;

      if (afterLength > 0) {
        var afterImpl = new T[afterLength];
        for (var i = 0; i < afterLength; ++i) {
          afterImpl[i] = regionImpl[beforeLength + newRegionLength + i];
        }
        this.regions_.Insert(regionIndex,
                             new RawShardedList<T>(this, afterImpl));
      }

      var newRegionImpl = new T[newRegionLength];
      for (var i = 0; i < newRegionLength; ++i) {
        newRegionImpl[i] = regionImpl[beforeLength + i];
      }
      var newRegion = new ShardedList<T>(this, newRegionImpl);
      this.regions_.Insert(regionIndex, newRegion);

      if (beforeLength > 0) {
        var beforeImpl = new T[beforeLength];
        for (var i = 0; i < beforeLength; ++i) {
          beforeImpl[i] = regionImpl[i];
        }
        this.regions_.Insert(regionIndex,
                             new RawShardedList<T>(this, beforeImpl));
      }

      this.MergeNeighboringRawRegions_();

      return newRegion;
    }

    private void MergeNeighboringRawRegions_() {
      var didMerge = false;

      var previousRegion = this.regions_[0];
      for (var i = 1; i < this.regions_.Count; ++i) {
        var currentRegion = this.regions_[i];

        if (previousRegion is RawShardedList<T> rawPreviousRegion &&
            currentRegion is RawShardedList<T> rawCurrentRegion) {
          didMerge = true;

          var mergedImpl = new T[previousRegion.Length + currentRegion.Length];

          rawPreviousRegion.Impl.CopyTo(mergedImpl, 0);
          rawCurrentRegion.Impl.CopyTo(mergedImpl, previousRegion.Length);

          var mergedRegion = new RawShardedList<T>(this, mergedImpl);

          this.regions_.RemoveAt(i);
          this.regions_.RemoveAt(i - 1);

          this.regions_.Insert(i - 1, mergedRegion);

          break;
        }

        previousRegion = currentRegion;
      }

      if (didMerge) {
        this.MergeNeighboringRawRegions_();
      }
    }

    private class NullShardedListAddress : IShardedListAddress {
      public int Offset => 0;
    }

    private int LocateRegion_(IShardedList<T> region) {
      var index = this.regions_.IndexOf(region);
      if (index >= 0) {
        return index;
      }
      throw new NotSupportedException("Failed to find the region!");
    }

    public IEnumerator<T> GetEnumerator()
      => new ShardedListEnumerator(this.regions_);

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

    private class ShardedListEnumerator : IEnumerator<T> {
      private IEnumerator<IShardedList<T>> topEnumerator_;
      private IEnumerator<T>? currentEnumerator_;

      public ShardedListEnumerator(IList<IShardedList<T>> regions) {
        this.topEnumerator_ = regions.GetEnumerator();
      }

      public T Current => this.currentEnumerator_!.Current;
      object IEnumerator.Current => this.Current!;

      public void Dispose() {
        this.topEnumerator_.Dispose();
        this.currentEnumerator_?.Dispose();
      }

      public bool MoveNext() {
        if (this.currentEnumerator_?.MoveNext() ?? false) {
          return true;
        }

        if (this.topEnumerator_.MoveNext()) {
          this.currentEnumerator_ = this.topEnumerator_.Current.GetEnumerator();
          this.currentEnumerator_.MoveNext();
          return true;
        }

        this.currentEnumerator_ = null;
        return false;
      }

      public void Reset() {
        this.topEnumerator_.Reset();
        this.currentEnumerator_ = null;
      }
    }

    private class ShardedListAddress : IShardedListAddress {
      private readonly Func<int> getOffsetHandler_;

      public ShardedListAddress(Func<int> getOffsetHandler) {
        this.getOffsetHandler_ = getOffsetHandler;
      }

      // TODO: Can this be cached?
      public int Offset => this.getOffsetHandler_();
    }

    private class RawShardedList<T> : IShardedList<T> {
      public RawShardedList(ShardedList<T> parent, IList<T> impl) {
        this.Impl = impl;

        this.Parent = parent;
        this.GlobalOffset =
            new ShardedListAddress(() => parent.LocateRegion_(this));
      }

      public IList<T> Impl { get; }

      public IShardedList<T>? Parent { get; }

      public IShardedListAddress GlobalOffset { get; }

      public int Length => this.Impl.Count;

      public T this[int localOffset] {
        get => this.Impl[localOffset];
        set => this.Impl[localOffset] = value;
      }

      public IShardedList<T> Shard(int localOffset, int length)
        => throw new NotSupportedException("Attempted to shard raw region.");

      public IEnumerator<T> GetEnumerator() => this.Impl.GetEnumerator();
      IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
  }
}