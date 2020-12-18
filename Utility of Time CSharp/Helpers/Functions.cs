namespace UoT {
  public static class Functions {
    public static uint ReadUInt24(byte[] Buffer, uint Offset) {
      uint ReadUInt24Ret = default;
      ReadUInt24Ret = (uint)(Buffer[(int)Offset] * 0x10000 + Buffer[(int)(Offset + 1L)] * 0x100 + Buffer[(int)(Offset + 2L)]);

      return ReadUInt24Ret;
    }
  }
}