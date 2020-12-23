namespace UoT {
  // TODO: Delete statics, use this within DlManager.
  /// <summary>
  ///   TMEM (texture memory) implementation. TMEM seems to be a middleman for
  ///   N64 texture loading: textures are loaded from RAM into TMEM, and tile
  ///   descriptors point into TMEM at a specific offset.
  /// </summary>
  public class Tmem {
    public readonly ulong[] impl_ = new ulong[512];

    // TODO: Implement this class.
  }
}
