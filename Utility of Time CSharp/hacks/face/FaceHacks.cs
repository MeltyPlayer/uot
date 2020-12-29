namespace UoT {
  public interface IFaceHack {
    /// <summary>
    ///   Maps a given texture address to a new address. This is needed to map
    ///   an eye/mouth address from a random spot in RAM to where they're
    ///   actually defined in ROM (as this is basically what would happen
    ///   in-game.)
    /// </summary>
    uint MapTextureAddress(uint originalAddress);
  }

  public static class FaceHacks {
    public static IFaceHack Get(string filename) {
      if (filename == "object_link_boy" || filename == "object_link_child") {
        return new LinkFaceHack();
      }

      return null;
    }
  }
}
