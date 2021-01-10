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

    public uint MapTextureAddress(uint originalAddress) {
      var blueOffset = 0x1300;
      var redOffset = 0x1B00;

      var topOffset = blueOffset;
      var eyeOffset = topOffset + (0x1F20 - 0x1B00);
      var bottomOffset = topOffset + (0x2100 - 0x1B00);

      // Top
      if (originalAddress == 0x08000000) {
        return 0x06000000 + (uint) topOffset;
      }

      // Eye
      if (originalAddress == 0x09000000) {
        return 0x06000000 + (uint) eyeOffset;
      }

      // Bottom
      if (originalAddress == 0x0A000000) {
        return 0x06000000 + (uint) bottomOffset;
      }

      return originalAddress;
    }
  }
}