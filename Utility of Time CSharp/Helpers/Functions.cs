namespace UoT {
  public static class FunctionsCs {
    public static uint ReadUInt24(byte[] buffer, uint offset)
      => FunctionsCs.ReadUInt(buffer, offset, 3);

    public static uint ReadUInt32(byte[] buffer, uint offset)
      => FunctionsCs.ReadUInt(buffer, offset, 4);

    private static uint ReadUInt(byte[] buffer, uint offset, int byteNum) {
      uint total = 0;
      for (var i = 0; i < byteNum; ++i) {
        var hexIndex = 2 * (byteNum - 1 - i);
        var bitIndex = 4 * hexIndex;
        var byteFactor = (uint) (1 << bitIndex);
        total += buffer[offset + i] * byteFactor;
      }
      return total;
    }
  }
}