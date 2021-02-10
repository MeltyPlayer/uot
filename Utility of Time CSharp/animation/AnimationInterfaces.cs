using System.Collections.Generic;
using System.ComponentModel;

namespace UoT {
  public interface IAnimation {
    ushort FrameCount { get; }

    Vec3s GetPosition(int i);
    FacialState GetFacialState(int i);

    int TrackCount { get; }
    IAnimationTrack GetTrack(int i);
  }

  public interface IAnimationTrack {
    // TODO: Convert this to an enum.
    int Type { get; }
    IList<ushort> Frames { get; }
  }

  public class Vec3s {
    public short X { get; set; }
    public short Y { get; set; }
    public short Z { get; set; }
  }

  public class FacialState {
    public static FacialState DEFAULT = new FacialState(default, default);

    public FacialState(EyeState eyeState, MouthState mouthState) {
      this.EyeState = eyeState;
      this.MouthState = mouthState;
    }

    public EyeState EyeState { get; }
    public MouthState MouthState { get; }
  }
}