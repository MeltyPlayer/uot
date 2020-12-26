namespace UoT {
  public static class RamBanks {
    public static byte[] ZFileBuffer { get; set; }
    public static byte[] ZSceneBuffer { get; set; }

    public static int CurrentBank { get; set; }
    public static BankSwitch CommonBankUse { get; set; }

    public static ObjectExchange CommonBanks { get; set; }

    public static byte[] GetBankByIndex(uint bankIndex) {
      if (bankIndex == RamBanks.CurrentBank) {
        return RamBanks.ZFileBuffer;
      }

      switch (bankIndex) {
        case 2:
          return RamBanks.ZSceneBuffer;
        case 4:
          return RamBanks.CommonBanks.Bank4.Banks[RamBanks.CommonBankUse.Bank04]
                         .Data;
        case 5:
          return RamBanks.CommonBanks.Bank5.Banks[RamBanks.CommonBankUse.Bank05]
                         .Data;

        default:
          // TODO: Should throw an error for unsupported banks.
          return null;
      }
    }
  }
}