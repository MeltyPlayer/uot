namespace UoT {
  // Structs that store animations from the "link_animetion" (sic) file.
  //
  // Based on the structs at:
  // https://wiki.cloudmodding.com/oot/Animation_Format#C_code

  public struct LinkAnimetion : IAnimation {
    // TODO: Support animating translation.
    // TODO: Support animating face.

    public LinkAnimetionTrack[] Tracks;

    public ushort FrameCount { get; set; }

    public int TrackCount => this.Tracks.Length;
    public IAnimationTrack GetTrack(int i) => this.Tracks[i];

    // TODO: Support these fields.
    public short XTrans => 0;
    public short YTrans => 0;
    public short ZTrans => 0;
  }

  public struct LinkAnimetionTrack : IAnimationTrack {
    public int Type { get; set; } // 0 = constant, 1 = keyframe
    public ushort[] Frames { get; set; }
  }

  // TODO: Use below structs instead.

  /*public struct Vec3s {
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
  }*/
}
