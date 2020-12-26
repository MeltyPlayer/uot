namespace UoT {
  // Structs that store animations from the "link_animetion" file.
  //
  // Based on the structs at:
  // https://wiki.cloudmodding.com/oot/Animation_Format#C_code

  public struct LinkAnimetion : IAnimation {
    public LinkAnimetionHeader Header;

    public ushort FrameCount => this.Header.FrameCount;
    public IAnimationTrack GetTrack(int i) => null;
  }

  public struct LinkAnimetionHeader {
    public ushort FrameCount;
    public uint Address;
  }

  public struct Vec3s {
    public short X;
    public short Y;
    public short Z;
  }

  public struct LinkAnimetionFace {
    public byte Mouth;
    public byte Eyes;
  }

  public struct LinkAnimetionFrame {
    public Vec3s RootTranslation;
    public Vec3s[] LimbRotations; // Should have length of 21.
    public LinkAnimetionFace FacialExpression;
  }
}
