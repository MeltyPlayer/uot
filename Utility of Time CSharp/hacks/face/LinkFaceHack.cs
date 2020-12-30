namespace UoT {
  public class LinkFaceHack : IFaceHack {
    // TODO: Support different eyes/mouths depending on animation frame.

    public uint MapTextureAddress(uint originalAddress) {
      // Eyes
      if (originalAddress == 0x08000000) {
        // Returns start of current file (Link's model).
        return 0x06000000;
      }

      // Mouth
      if (originalAddress == 0x09000000) {
        // Returns current file (Link's model) + 0x4000.
        return 0x06004000;
      }

      return originalAddress;
    }
  }
}
