namespace UoT {
  // Based on the structs at:
  // https://wiki.cloudmodding.com/oot/Animation_Format#Normal_Animations

  public struct AnimTrackIndex {
    public uint XRot;
    public uint YRot;
    public uint ZRot;
  }

  public struct AnimTrack {
    public int Type; // 0 = constant, 1 = keyframe
    public ushort[] Frames;
  }

  public struct Animation {
    public ushort[] Angles;
    public AnimTrack[] Tracks;
    public uint XTrans;
    public uint YTrans;
    public uint ZTrans;
    public uint FrameOffset;
    public uint TrackOffset;
    public uint FrameCount;
    public uint AngleCount;
    public uint TrackCount;
    public int ConstTrackCount;
  }
}
