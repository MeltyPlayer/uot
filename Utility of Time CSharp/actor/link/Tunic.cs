namespace UoT {
  public class Tunic {
    /**
     * Selected tunic id @ 15E6D0
     * - 17: kokiri
     * - 18: goron
     * - 19: zora
     *
     * Doesn't impact color until unpause.
     */

    public const int TUNIC_TYPE_RDRAM_OFFSET = 0x2246FC;

    public enum TunicType {
      KOKIRI = 0,
      GORON = 1,
      ZORA = 2,
    }
  }
}
