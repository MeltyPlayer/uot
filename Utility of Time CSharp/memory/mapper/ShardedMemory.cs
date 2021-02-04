using System;
using System.Collections;
using System.Collections.Generic;

using UoT.memory.mapper;
using UoT.util;

namespace UoT.memory.map {
  public enum ShardedMemoryType {
    UNKNOWN,

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
    uint Length { get; }

    IShardedMemory Shard(uint localOffset, uint length);
  }
}