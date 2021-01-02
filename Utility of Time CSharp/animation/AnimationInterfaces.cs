using System.Collections.Generic;

namespace UoT {
  public interface IAnimation {
    ushort FrameCount { get; }

    Vec3s GetPosition(int i);

    int TrackCount { get; }
    IAnimationTrack GetTrack(int i);
  }

  public interface IAnimationTrack {
    // TODO: Convert this to an enum.
    int Type { get; }
    ushort[] Frames { get; }
  }

  public struct Vec3s {
    public short X;
    public short Y;
    public short Z;
  }
}