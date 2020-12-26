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


    // TODO: Support these fields.
    public Vec3s[] Positions;
    public Vec3s GetPosition(int i) => this.Positions[i];

    public int TrackCount => this.Tracks.Length;
    public IAnimationTrack GetTrack(int i) => this.Tracks[i];
  }

  public struct LinkAnimetionTrack : IAnimationTrack {
    public int Type { get; set; } // 0 = constant, 1 = keyframe
    public ushort[] Frames { get; set; }
  }

  // TODO: Use below structs instead.
  /*public struct LinkAnimetionFace {
    public byte Mouth;
    public byte Eyes;
  }

  public struct LinkAnimetionFrame {
    public Vec3s RootTranslation;
    public Vec3s[] LimbRotations; // Should have length of 21.
    public LinkAnimetionFace FacialExpression;
  }*/
}
