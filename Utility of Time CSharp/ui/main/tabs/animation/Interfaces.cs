﻿namespace UoT {
  /// <summary>
  ///   Helper interface for managing the dirty details of playing back an
  ///   animation for a model.
  /// </summary>
  public interface IAnimationPlaybackManager {
    /// <summary>
    ///   Current frame of playback, including the fractional progress towards
    ///   the next frame.
    /// </summary>
    double Frame { get; set; }

    int TotalFrames { get; set; }
    int FrameRate { get; set; }

    // TODO: Is it better to make this a method?
    bool IsPlaying { get; set; }
    bool ShouldLoop { get; set; }

    void Tick();
    void Reset();
  }
}
