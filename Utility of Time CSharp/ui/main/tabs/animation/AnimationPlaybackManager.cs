namespace UoT {
  /// <summary>
  ///   Helper interface for managing the dirty details of playing back an
  ///   animation for a model.
  /// </summary>
  public interface IAnimationPlaybackManager {

    double CurrentFrame { get; }
    int TotalFrames { get; }
    int FrameRate { get; }

    bool IsPlaying { get; }
    bool ShouldLoop { get; }
    void Play();
    void Pause();
  }

  // TODO: Move all animation logic and data from UI components into this
  // class.
  public class AnimationPlaybackManager {
  }
}
