namespace UoT {
  // Based on the structs at:
  // https://wiki.cloudmodding.com/oot/Animation_Format#Normal_Animations

  public struct NormalAnimation : IAnimation {
    public ushort[] Angles;
    public NormalAnimationTrack[] Tracks;
    public uint XTrans;
    public uint YTrans;
    public uint ZTrans;
    public uint FrameOffset;
    public uint TrackOffset;
    public uint AngleCount;
    public uint TrackCount;
    public int ConstTrackCount;

    public ushort FrameCount { get; set; }
    public IAnimationTrack GetTrack(int i) => this.Tracks[i];
  }

  public struct NormalAnimationHeader {

  }

  public struct NormalAnimationTrack : IAnimationTrack {
    public int Type { get; set; } // 0 = constant, 1 = keyframe
    public ushort[] Frames { get; set; }
  }
}
