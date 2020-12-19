namespace UoT {
  public static class FunctionsCs {
    public static uint ReadUInt32(byte[] buffer, uint offset) =>
        (uint)(buffer[offset] * 0x1000000 + 
               buffer[offset + 1] * 0x10000 +
               buffer[offset + 2] * 0x100 +
               buffer[offset + 3]);

    public static uint ReadUInt24(byte[] buffer, uint offset) =>
      (uint)(buffer[offset] * 0x10000 +
             buffer[offset + 1] * 0x100 + 
             buffer[offset + 2]);
  }
}