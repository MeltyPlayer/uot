namespace UoT {
  // Based on the structs at:
  // https://wiki.cloudmodding.com/oot/Animation_Format#Normal_Animations

  public struct NormalAnimation : IAnimation {
    public ushort[] Angles;
    public NormalAnimationTrack[] Tracks;
    public uint TrackOffset;
    public uint AngleCount;

    public ushort FrameCount { get; set; }

    public Vec3s Position;
    public Vec3s GetPosition(int _) => this.Position;
    public FacialState GetFacialState(int _) => default;

    public int TrackCount => this.Tracks.Length;
    public IAnimationTrack GetTrack(int i) => this.Tracks[i];
  }

  public struct NormalAnimationTrack : IAnimationTrack {
    public int Type { get; set; } // 0 = constant, 1 = keyframe
    public ushort[] Frames { get; set; }
  }
}
