using System;
using System.Collections.Generic;
using System.Numerics;

using MathNet.Numerics.LinearAlgebra.Double;

using UoT.animation.playback;

namespace UoT {
  /// <summary>
  ///   Helper class for managing a model's matrices for each limb.
  ///   Precalculates each matrix before rendering a frame.
  /// </summary>
  public class LimbMatrices {
    /// <summary> Each limb's matrix. </summary>
    private Matrix[] impl_ = {};

    /// <summary> Each visible limb's matrix. </summary>
    private Matrix[] visible_ = {};


    /// <summary>
    ///   Gets the matrix for limb with the given index. This DOES NOT take
    ///   visibility into account.
    /// </summary>
    public Matrix GetMatrixForLimb(uint limbIndex) => this.impl_[limbIndex];

    /// <summary>
    ///   Gets the matrix at the given address, as specified within a display
    ///   list. This DOES take visibility into account.
    /// </summary>
    private readonly Matrix identity_ = new DiagonalMatrix(4, 4, 1);
    public Matrix GetMatrixAtAddress(uint address) {
      IoUtil.SplitAddress(address, out var bank, out var offset);

      if (bank == 0x0d) {
        var visibleLimbIndex = offset / 0x40;
        return this.visible_[visibleLimbIndex];
      }

      // TODO: Zelda's hair is 0x0c?

      return this.identity_;
    }

    private uint ConvertAddressToVisibleLimbIndex_(uint address)
      => (address - 0x0d000000) / 0x40;


    /// <summary>
    ///   Retargets the lists of matrices to a new set of limbs. This MUST be
    ///   run whenever a new model is loaded.
    /// </summary>
    public void Retarget(Limb[] limbs) {
      var visibleCount = this.FindVisibleLimbs_(limbs);
      this.Resize_(limbs, visibleCount);
    }

    /// <summary>
    ///   Finds the visible limbs in the model and returns the total count.
    ///   Visibility is determined based on whether the display list's bank is
    ///   nonzero.
    /// </summary>
    private int FindVisibleLimbs_(Limb[] limbs) {
      var currentVisibleCount = 0;

      for (var i = 0; i < limbs.Length; ++i) {
        var limb = limbs[i];

        // TODO: Split this to check if bank is 0 instead?
        if (limb.DisplayListAddress > 0) {
          limb.VisibleIndex = currentVisibleCount++;
        } else {
          limb.VisibleIndex = -1;
        }

        limbs[i] = limb;
      }

      return currentVisibleCount;
    }

    private void Resize_(IReadOnlyList<Limb> limbs, int visibleCount) {
      this.impl_ = new Matrix[limbs.Count];
      this.visible_ = new Matrix[visibleCount];

      for (var i = 0; i < limbs.Count; ++i) {
        var limb = limbs[i];

        var m = new DenseMatrix(4, 4);
        this.impl_[i] = m;

        var visibleIndex = limb.VisibleIndex;
        if (visibleIndex > -1) {
          this.visible_[visibleIndex] = m;
        }
      }
    }


    public void UpdateLimbMatrices(
        Limb[] limbs,
        IAnimation animation,
        IAnimationPlaybackManager playbackManager) {
      this.UpdateLimbMatricesRecursively_(limbs, 0, animation, playbackManager);
    }

    private void UpdateLimbMatricesRecursively_(
        IReadOnlyList<Limb> limbs,
        int limbIndex,
        IAnimation? animation,
        IAnimationPlaybackManager playbackManager) {
      var limb = limbs[limbIndex];

      ModelViewMatrixTransformer.Push();
      {
        ModelViewMatrixTransformer.Translate(limb.x, limb.y, limb.z);

        if (animation != null) {
          this.PushRotation_(limbIndex, animation, playbackManager);
        }

        ModelViewMatrixTransformer.Get(this.tempMatrix_);
        this.tempMatrix_.CopyTo(this.impl_[limbIndex]);

        var firstChild = limb.firstChild;
        if (firstChild > -1) {
          this.UpdateLimbMatricesRecursively_(limbs,
                                              firstChild,
                                              animation,
                                              playbackManager);
        }
      }
      ModelViewMatrixTransformer.Pop();

      var nextSibling = limb.nextSibling;
      if (nextSibling > -1) {
        this.UpdateLimbMatricesRecursively_(limbs,
                                            nextSibling,
                                            animation,
                                            playbackManager);
      }
    }

    private void PushRotation_(
        int limbIndex,
        IAnimation animation,
        IAnimationPlaybackManager playbackManager) {
      var q = this.GetLimbRotation_(limbIndex, animation, playbackManager);
      this.ApplyQuaternion_(q);
    }


    private Quaternion GetLimbRotation_(
        int limbIndex,
        IAnimation animation,
        IAnimationPlaybackManager playbackManager) {
      var trackIndex = limbIndex * 3;

      // TODO: This doesn't look like it should be needed.
      if (trackIndex > animation.TrackCount - 1) {
        trackIndex = 0;
      }

      var xTrack = animation.GetTrack(trackIndex);
      var yTrack = animation.GetTrack(trackIndex + 1);
      var zTrack = animation.GetTrack(trackIndex + 2);

      var xFrames = xTrack.Frames;
      var yFrames = yTrack.Frames;
      var zFrames = zTrack.Frames;

      var frame = (uint) Math.Floor(playbackManager.Frame);
      this.GetFrameAndNext_(xTrack, frame, out var xFrame, out var nextXFrame);
      this.GetFrameAndNext_(yTrack, frame, out var yFrame, out var nextYFrame);
      this.GetFrameAndNext_(zTrack, frame, out var zFrame, out var nextZFrame);

      var r2d = Math.PI / 180;
      var x1 = this.AngleToRad_(xFrames[xFrame]) * r2d;
      var y1 = this.AngleToRad_(yFrames[yFrame]) * r2d;
      var z1 = this.AngleToRad_(zFrames[zFrame]) * r2d;

      var q1 = this.GetQuaternion_(x1, y1, z1);

      var x2 = this.AngleToRad_(xFrames[nextXFrame]) * r2d;
      var y2 = this.AngleToRad_(yFrames[nextYFrame]) * r2d;
      var z2 = this.AngleToRad_(zFrames[nextZFrame]) * r2d;

      var q2 = this.GetQuaternion_(x2, y2, z2);

      if (Quaternion.Dot(q1, q2) < 0) {
        q2 = -q2;
      }

      var frameDelta = (float) (playbackManager.Frame % 1);
      var interp = Quaternion.Slerp(q1, q2, frameDelta);
      return Quaternion.Normalize(interp);
    }

    private double AngleToRad_(ushort angle) => (angle * 360.0) / 0xFFFF;

    private Quaternion GetQuaternion_(
        double xDegrees,
        double yDegrees,
        double zDegrees) {
      // The quaternion has to be multiplied in the same order the rotations
      // were applied in OpenGL: z, y, x!
      var qz = Quaternion.CreateFromYawPitchRoll(0, 0, (float) zDegrees);
      var qy = Quaternion.CreateFromYawPitchRoll((float) yDegrees, 0, 0);
      var qx = Quaternion.CreateFromYawPitchRoll(0, (float) xDegrees, 0);

      return Quaternion.Normalize(qz * qy * qx);
    }

    private void GetFrameAndNext_(
        IAnimationTrack track,
        uint frame,
        out uint trackFrame,
        out uint nextTrackFrame) {
      var frameCount = (uint) track.Frames.Length;

      if (track.Type == 1) {
        trackFrame = frame % frameCount;
        nextTrackFrame = (trackFrame + 1) % frameCount;
      } else {
        trackFrame = 0;
        nextTrackFrame = 0;
      }
    }


    // TODO: Move this to ModelViewMatrixTransformer.
    private readonly Matrix tempMatrix_ = new DenseMatrix(4, 4);

    private void ApplyQuaternion_(Quaternion q) {
      var qx = q.X;
      var qy = q.Y;
      var qz = q.Z;
      var qw = q.W;

      var m = this.tempMatrix_;
      m[0, 0] = 1.0 - 2.0 * qy * qy - 2.0 * qz * qz;
      m[0, 1] = 2.0 * qx * qy - 2.0 * qz * qw;
      m[0, 2] = 2.0 * qx * qz + 2.0 * qy * qw;
      m[0, 3] = 0.0;

      m[1, 0] = 2.0 * qx * qy + 2.0 * qz * qw;
      m[1, 1] = 1.0 - 2.0 * qx * qx - 2.0 * qz * qz;
      m[1, 2] = 2.0 * qy * qz - 2.0 * qx * qw;
      m[1, 3] = 0.0;

      m[2, 0] = 2.0 * qx * qz - 2.0 * qy * qw;
      m[2, 1] = 2.0 * qy * qz + 2.0 * qx * qw;
      m[2, 2] = 1.0 - 2.0 * qx * qx - 2.0 * qy * qy;
      m[2, 3] = 0.0;

      m[3, 0] = 0;
      m[3, 1] = 0;
      m[3, 2] = 0;
      m[3, 3] = 1;

      ModelViewMatrixTransformer.MultMatrix(m);
    }
  }
}