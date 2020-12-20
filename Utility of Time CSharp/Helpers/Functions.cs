namespace UoT {
  public static class FunctionsCs {
    /// <summary>
    ///   Calculates the nearest power of 2 under a given value. This is useful
    ///   for textures widths/heights, which need to be exact powers of 2.
    /// </summary>
    public static ulong Pow2(ulong val) {
      ulong i = 1;
      while (i < val) {
        i <<= 1;
      }
      return i;
    }

    /// <summary>
    ///   Calculates which n results in 2^n closest under a given value. 
    /// </summary>
    public static ulong PowOf(ulong val) {
      ulong num = 1;
      ulong i = 0;
      while (num < val) {
        num <<= 1;
        i++;
      }
      return i;
    }


    public static ushort ReadUInt16(byte[] buffer, uint offset)
      => (ushort) FunctionsCs.ReadUInt(buffer, offset, 2);

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