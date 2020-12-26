using System.Collections.Generic;

namespace UoT {
  public interface IAnimation {
    ushort FrameCount { get; }

    int TrackCount { get; }
    IAnimationTrack GetTrack(int i);
  }

  public interface IAnimationTrack {
    // TODO: Convert this to an enum.
    int Type { get; }
    ushort[] Frames { get; }
  }
}