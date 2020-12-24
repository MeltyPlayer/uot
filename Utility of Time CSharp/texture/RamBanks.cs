namespace UoT {
  public static class RamBanks {
    public static byte[] ZFileBuffer { get; set; }
    public static byte[] ZSceneBuffer { get; set; }

    public static int CurrentBank { get; set; } = 0;
    public static ObjectExchange CommonBanks { get; set; }
  }
}
