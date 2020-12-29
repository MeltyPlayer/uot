namespace UoT {
  public static class AnimatedTextureHacks {
    public static double GetVOffsetForTexture(TileDescriptor tileDescriptor) {
      // TODO: Rewrite this to switch between different composed classes for
      // different handlers.
      var uuid = tileDescriptor.Uuid;

      if (uuid == 0x02008D58) {
        return -Time.CurrentFrac;
      }

      return 0;
    }
  }
}
