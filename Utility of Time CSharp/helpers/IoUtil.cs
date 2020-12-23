namespace UoT {
  public static class IoUtil {
    public static void SplitAddress(uint address, out uint bank, out uint offset) {
      bank = address >> 24;
      offset = address << 8 >> 8;
    }


    // TODO: Rename params.
    /// <summary>
    ///   Gets multiple bits from the right-hand side of a value.
    /// </summary>
    public static uint ShiftR(uint v, int s, int w)
      => (uint)((v >> s) & ((1 << w) - 1));

    // TODO: What is this doing?
    // TODO: Rename params.
    public static uint ShiftL(uint v, int s, int w)
      => (uint)(v & ((1 << w) - 1) << s);

    // TODO: What is this doing?
    // TODO: Rename params.
    public static double Fixed2Float(double v, int b)
      => v * RDP_Defs.FIXED2FLOATRECIP[b - 1];


    public static ushort ReadUInt16(byte[] buffer, uint offset)
      => (ushort)IoUtil.ReadUInt(buffer, offset, 2);

    public static uint ReadUInt24(byte[] buffer, uint offset)
      => IoUtil.ReadUInt(buffer, offset, 3);

    public static uint ReadUInt32(byte[] buffer, uint offset)
      => IoUtil.ReadUInt(buffer, offset, 4);

    private static uint ReadUInt(byte[] buffer, uint offset, int byteNum) {
      uint total = 0;
      for (var i = 0; i < byteNum; ++i) {
        var hexIndex = 2 * (byteNum - 1 - i);
        var bitIndex = 4 * hexIndex;
        var byteFactor = (uint)(1 << bitIndex);
        total += buffer[offset + i] * byteFactor;
      }
      return total;
    }
  }
}
