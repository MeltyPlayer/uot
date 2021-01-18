namespace UoT {
  public class LinkIndirectTextureHack : IIndirectTextureHack {
    public EyeState EyeState { get; set; }
    public MouthState MouthState { get; set; }

    public uint MapTextureAddress(uint originalAddress) {
      // Eyes
      if (originalAddress == 0x08000000) {
        var eyeIndex = (uint) this.EyeState > 0 ? this.EyeState - 1 : 0;
        return 0x06000000 + (uint)eyeIndex * 0x800;
      }

      // Mouth
      if (originalAddress == 0x09000000) {
        var mouthIndex = (uint) this.MouthState > 0 ? this.MouthState - 1 : 0;
        return 0x06004000 + (uint)mouthIndex * 0x400;
      }

      return originalAddress;
    }
  }
}