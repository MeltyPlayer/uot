using System.Linq;
using UoT.util;

using NUnit.Framework;

namespace UoT.util.data {
  public class ShardedListTest {
    [Test]
    public void ShardingNegativeThrows() {
      var shardedList = ShardedList<int>.From(1, 2, 3, 4, 5, 6);
      Assert.Throws<AssertException>(() => shardedList.Shard(-1, 1));
    }

    [Test]
    public void ShardingZeroThrows() {
      var shardedList = ShardedList<int>.From(1, 2, 3, 4, 5, 6);
      Assert.Throws<AssertException>(() => shardedList.Shard(0, 0));
    }

    [Test]
    public void ShardingLargeThrows() {
      var shardedList = ShardedList<int>.From(1, 2, 3, 4, 5, 6);
      Assert.Throws<AssertException>(() => shardedList.Shard(0, 7));
    }

    [Test]
    public void ShardingFullListReturnsSelf() {
      var shardedList = ShardedList<int>.From(1, 2, 3, 4, 5, 6);
      var subShard = shardedList.Shard(0, 6);

      Assert.AreSame(shardedList, subShard);
    }


    [Test]
    public void DoubleShardingThrows() {
      var shardedList = ShardedList<int>.From(1, 2, 3, 4, 5, 6);
      shardedList.Shard(2, 4);

      Assert.Throws<AssertException>(() => shardedList.Shard(2, 4));
    }


    [Test]
    public void IteratingOverSingleShard() {
      var shardedList = ShardedList<int>.From(1, 2, 3, 4, 5, 6);
      Assert.AreEqual(new[] {1, 2, 3, 4, 5, 6}, shardedList.ToArray());
    }

    [Test]
    public void IteratingOverSubShard() {
      var shardedList = ShardedList<int>.From(1, 2, 3, 4, 5, 6);
      var subShard = shardedList.Shard(1, 4);

      Assert.AreEqual(new[] {1, 2, 3, 4, 5, 6}, shardedList.ToArray());
      Assert.AreEqual(new[] {2, 3, 4, 5}, subShard.ToArray());
    }

    [Test]
    public void IteratingOverSubSubShard() {
      var shardedList = ShardedList<int>.From(1, 2, 3, 4, 5, 6);
      var subShard = shardedList.Shard(1, 4);
      var subSubShard = subShard.Shard(1, 2);

      Assert.AreEqual(new[] {1, 2, 3, 4, 5, 6}, shardedList.ToArray());
      Assert.AreEqual(new[] {3, 4,}, subSubShard.ToArray());
    }


    [Test]
    public void IteratingOverNeighboringShards() {
      var shardedList = ShardedList<int>.From(1, 2, 3, 4, 5, 6);
      var subShard1 = shardedList.Shard(0, 2);
      var subShard2 = shardedList.Shard(2, 2);
      var subShard3 = shardedList.Shard(4, 2);

      Assert.AreEqual(new[] { 1, 2, 3, 4, 5, 6 }, shardedList.ToArray());
      Assert.AreEqual(new[] { 1, 2, }, subShard1.ToArray());
      Assert.AreEqual(new[] { 3, 4, }, subShard2.ToArray());
      Assert.AreEqual(new[] { 5, 6, }, subShard3.ToArray());
    }

    [Test]
    public void ShardingOverShardThrows() {
      var shardedList = ShardedList<int>.From(1, 2, 3, 4, 5, 6);
      shardedList.Shard(0, 2);
      shardedList.Shard(4, 2);

      Assert.Throws<AssertException>(() => shardedList.Shard(2, 3));
    }
  }
}