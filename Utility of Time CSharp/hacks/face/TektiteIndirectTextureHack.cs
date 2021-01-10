namespace UoT {
  /// <summary>
  ///   Indirect textures for Tektites. This is needed for this object because
  ///   it chooses between two sets of textures depending on the color.
  ///
  ///   These addresses were found by searching the ROM for specific color
  ///   values.
  /// </summary>
  public class TektiteIndirectTextureHack : IIndirectTextureHack {
    // TODO: Support switching between the sets in the editor.
    // TODO: Where is blue?

    public uint MapTextureAddress(uint originalAddress) {
      // Top
      if (originalAddress == 0x08000000) {
        return 0x06000000 + 0x1B00;
      }

      // Eye
      if (originalAddress == 0x09000000) {
        return 0x06000000 + 0x1F20;
      }

      // Bottom
      if (originalAddress == 0x0A000000) {
        return 0x06000000 + 0x2100;
      }

      return originalAddress;
    }
  }
}
