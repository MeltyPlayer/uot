﻿namespace UoT.memory.mapper {
  // TODO: Figure out how to make pointers to memory source work?
  // TODO: Byte array
  // TODO: Shardable memory
  // TODO: Memory labels
  // TODO: Saving back to a file
  // TODO: Texture memory
  // TODO: DL memory

  public interface IMemorySource {
    byte this[uint offset] { get; set; }
    uint Length { get; }
  }
}
