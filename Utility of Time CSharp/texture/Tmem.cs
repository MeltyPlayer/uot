namespace UoT {
  // TODO: Delete statics, use this within DlManager.
  /// <summary>
  ///   TMEM (texture memory) implementation. TMEM seems to be a middleman for
  ///   N64 texture loading: textures are loaded from RAM into TMEM, and tile
  ///   descriptors point into TMEM at a specific offset.
  /// </summary>
  public class Tmem {
    private readonly TextureCache cache_;
    private readonly ulong[] impl_ = new ulong[512];

    public Tmem(TextureCache cache) {
      this.cache_ = cache;
    }

    // TODO: Implement this class.

    // TODO: Will it work if we pass by ref?
    public TileDescriptor LoadTile(
        TileDescriptor tileDescriptor,
        ushort uls,
        ushort ult,
        ushort lrs,
        ushort lrt) {
      return tileDescriptor;
      // TODO: Implement this method.
      // TODO: To verify behavior, load contents into a new texture and save to
      // file.
    }
  }
}
