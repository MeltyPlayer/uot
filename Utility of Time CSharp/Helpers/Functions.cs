namespace UoT {
  public static class Functions {
    public static uint ReadUInt24(byte[] buffer, uint offset) =>
      (uint)(buffer[(int)offset] * 0x10000 +
             buffer[(int)(offset + 1L)] * 0x100 + 
             buffer[(int)(offset + 2L)]);
  }
}