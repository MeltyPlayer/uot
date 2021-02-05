using UoT.memory.mapper;
using UoT.util.data;

namespace UoT.memory.map {
  public enum ShardedMemoryType {
    UNKNOWN,

    ROOT,

    // Files
    ACTOR,
    OVL,

    // Graphics
    LIMB_HIERARCHY,
    DISPLAY_LIST,
    TEXTURE,
    PALETTE,
  }

  /// <summary>
  ///   Helper interface for splitting up regions of ROM by type into
  ///   hierarchies. Especially useful for identifying regions of interest,
  ///   e.g. regions that have not yet been identified.
  /// </summary>
  public interface IShardedMemory : IMemorySource {
    IShardedListAddress GlobalOffset { get; }

    IShardedMemory Shard(
        ShardedMemoryType shardType,
        int localOffset,
        int length);

    void Resize(int newLength);
  }

  public class ShardedMemory : IShardedMemory {
    private readonly IShardedList<byte> impl_;

    private ShardedMemory(
        ShardedMemoryType shardType,
        IShardedList<byte> impl
    ) {
      this.ShardType = shardType;
      this.impl_ = impl;
    }

    public static ShardedMemory From(
        ShardedMemoryType shardType,
        params byte[] bytes)
      => new ShardedMemory(shardType, ShardedList<byte>.From(bytes));

    public ShardedMemoryType ShardType { get; }

    public int Length => this.impl_.Length;

    public byte this[int localOffset] {
      get => this.impl_[localOffset];
      set => this.impl_[localOffset] = value;
    }

    public IShardedListAddress GlobalOffset => this.impl_.GlobalOffset;

    public IShardedMemory Shard(
        ShardedMemoryType shardType,
        int localOffset,
        int length
    )
      => new ShardedMemory(shardType, this.impl_.Shard(localOffset, length));

    public void Resize(int newLength) => this.impl_.Resize(newLength);
  }
}