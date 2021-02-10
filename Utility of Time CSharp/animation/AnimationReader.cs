using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Microsoft.VisualBasic;

namespace UoT {
  public class AnimationReader {
    /// <summary>
    ///   Parses a set of animations according to the spec at:
    ///   https://wiki.cloudmodding.com/oot/Animation_Format#Normal_Animations
    /// </summary>
    public IList<IAnimation>? GetCommonAnimations(
        IBank Data,
        int LimbCount,
        ListBox animationList) {
      uint trackCount = (uint) (LimbCount * 3);
      int animCnt = -1;
      var tAnimation = new NormalAnimation[0];
      animationList.Items.Clear();

      // Guesstimating the index by looking for an spot where the header's angle
      // address and track address have the same bank as the param at the top.
      // TODO: Is this robust enough?
      for (int i = 4, loopTo = Data.Count - 12 - 1; i <= loopTo; i += 4) {
        var attemptOffset = (uint) (i - 4);
        var frameCount = IoUtil.ReadUInt16(Data, attemptOffset);
        if (frameCount == 0) {
          continue;
        }

        var rotationValuesAddress = IoUtil.ReadUInt32(
            Data,
            attemptOffset + 4);
        var rotationIndicesAddress = IoUtil.ReadUInt32(
            Data,
            attemptOffset + 8);
        IoUtil.SplitAddress(rotationValuesAddress,
                            out var rotationValuesBank,
                            out var rotationValuesOffset);
        IoUtil.SplitAddress(rotationIndicesAddress,
                            out var rotationIndicesBank,
                            out var rotationIndicesOffset);

        var limit = IoUtil.ReadUInt16(Data, attemptOffset + 12);
        bool validAttemptOffset = RamBanks.IsValidBank(rotationValuesBank) &
                                  RamBanks.IsValidBank(rotationIndicesBank);

        var rotationValuesBuffer = default(IBank);
        var rotationIndicesBuffer = default(IBank);

        bool validRotationOffsets = false;
        if (validAttemptOffset) {
          // 6 is "current file", which is whatever was passed into "Data".
          if (rotationValuesBank == 6) {
            rotationValuesBuffer = Data;
          } else {
            rotationValuesBuffer = RamBanks.GetBankByIndex(rotationValuesBank);
          }

          if (rotationIndicesBank == 6) {
            rotationIndicesBuffer = Data;
          } else {
            rotationIndicesBuffer =
                RamBanks.GetBankByIndex(rotationIndicesBank);
          }

          // Offsets should be within bounds of the bank.
          var validRotationValuesOffset =
              rotationValuesBuffer != null &&
              rotationValuesOffset < rotationValuesBuffer.Count;
          var validRotationIndicesOffset =
              rotationIndicesBuffer != null &&
              rotationIndicesOffset < rotationIndicesBuffer.Count;
          validRotationOffsets =
              validRotationValuesOffset && validRotationIndicesOffset;
        }

        // Angle count should be greater than 0.
        var angleCount =
            (uint) ((rotationIndicesOffset - rotationValuesOffset) / 2L);
        var validAngleCount = rotationIndicesOffset > rotationValuesOffset &&
                              angleCount > 0L;
        if (validAttemptOffset &&
            validRotationOffsets &&
            validAngleCount &&
            rotationValuesBuffer != null &&
            rotationIndicesBuffer != null) {
          // Should have zeroes present in two spots of the animation header. 
          var hasZeroes =
              IoUtil.ReadUInt16(Data, attemptOffset + 2) == 0 &&
              IoUtil.ReadUInt16(Data, attemptOffset + 14) == 0;

          // TODO: Assumes 0 is one of the angles, is this valid?
          // Dim validAngles As Boolean = IoUtil.ReadUInt16(Data, rotationValuesOffset) = 0 And IoUtil.ReadUInt16(Data, rotationValuesOffset + 2) > 0

          // All values of "tTrack" should be within the bounds of .Angles.
          bool validTTracks = true;
          for (int i1 = 0, loopTo1 = (int) (trackCount - 1L);
               i1 <= loopTo1;
               i1++) {
            var tTrack = IoUtil.ReadUInt16(
                rotationIndicesBuffer,
                (uint) (rotationIndicesOffset + 6L + 2 * i1));
            if (tTrack < limit) {
              if (tTrack >= angleCount) {
                validTTracks = false;
                goto badTTracks;
              }
            } else if ((uint) (tTrack + frameCount) > angleCount) {
              validTTracks = false;
              goto badTTracks;
            }
          }

          badTTracks: ;
          if (hasZeroes & validTTracks) {
            animCnt += 1;
            Array.Resize(ref tAnimation, animCnt + 1);
            {
              var animation = tAnimation[animCnt] = new NormalAnimation();
              animation.FrameCount = frameCount;
              animation.TrackOffset = rotationIndicesOffset;
              animation.AngleCount = angleCount;
              if (animation.FrameCount > 0) {
                animation.Angles =
                    new ushort[(int) (animation.AngleCount - 1L + 1)];
                animationList.Items.Add("0x" + Conversion.Hex(i));
                for (int i1 = 0, loopTo2 = (int) (animation.AngleCount - 1L);
                     i1 <= loopTo2;
                     i1++) {
                  animation.Angles[i1] =
                      IoUtil.ReadUInt16(rotationValuesBuffer,
                                        rotationValuesOffset);
                  rotationValuesOffset = (uint) (rotationValuesOffset + 2L);
                }

                var position = animation.Position = new Vec3s();
                position.X = IoUtil.ReadInt16(
                    rotationIndicesBuffer,
                    animation.TrackOffset);
                position.Y = IoUtil.ReadInt16(
                    rotationIndicesBuffer,
                    animation.TrackOffset + 2);
                position.Z = IoUtil.ReadInt16(
                    rotationIndicesBuffer,
                    animation.TrackOffset + 4);

                animation.Tracks =
                    new NormalAnimationTrack[(int) (trackCount - 1L + 1)];

                int tTrackOffset = (int) (animation.TrackOffset + 6L);
                for (int i1 = 0, loopTo3 = (int) (trackCount - 1L);
                     i1 <= loopTo3;
                     i1++) {
                  var track = animation.Tracks[i1] = new NormalAnimationTrack();

                  var tTrack =
                      IoUtil.ReadUInt16(rotationIndicesBuffer,
                                        (uint) tTrackOffset);
                  if (tTrack < limit) {
                    // Constant (single value)
                    track.Type = 0;
                    track.Frames = new ushort[1];
                    track.Frames[0] = animation.Angles[tTrack];
                  } else {
                    // Keyframes
                    track.Type = 1;
                    track.Frames = new ushort[animation.FrameCount];
                    for (int i2 = 0, loopTo4 = animation.FrameCount - 1;
                         i2 <= loopTo4;
                         i2++) {
                      try {
                        track.Frames[i2] = animation.Angles[tTrack + i2];
                      } catch {
                        return null;
                      }
                    }
                  }

                  tTrackOffset += 2;
                }
              } else {
                Array.Resize(ref tAnimation, animCnt);
              }
            }
          }
        }
      }

      if (tAnimation.Length > 0) {
        var outList = new List<IAnimation>();
        foreach (NormalAnimation animation in tAnimation) {
          outList.Add(animation);
        }
        return outList;
      }

      return null;
    }

    /// <summary>
    ///   Parses a set of animations according to the spec at:
    ///   https://wiki.cloudmodding.com/oot/Animation_Format#C_code
    /// </summary>
    public IList<IAnimation>? GetLinkAnimations(
        IBank HeaderData,
        int LimbCount,
        IBank animationData,
        ListBox animationList) {
      animationList.Items.Clear();
      var animations = new List<IAnimation>();

      var trackCount = (uint) (LimbCount * 3);
      var frameSize = 2 * (3 + trackCount) + 2;
      for (uint i = 0x2310; i <= 0x34F8; i += 4) {
        var frameCount = IoUtil.ReadUInt16(HeaderData, i);
        if (frameCount == 0) {
          continue;
        }

        var animationAddress = IoUtil.ReadUInt32(HeaderData, i + 4);
        IoUtil.SplitAddress(animationAddress,
                            out var animationBank,
                            out var animationOffset);
        
        // Should use link_animetion bank.
        var validAnimationBank = animationBank == 7;
        if (!validAnimationBank) {
          continue;
        }

        // Should have zeroes in the expected bytes of the header.
        var hasZeroes = IoUtil.ReadUInt16(HeaderData, i + 2) == 0;
        if (!hasZeroes) {
          continue;
        }

        // Should be within the bounds of the bank.
        var validOffset = animationOffset + frameSize * frameCount <
                          animationData.Count;
        if (!validOffset) {
          continue;
        }

        var tracks = new LinkAnimetionTrack[(int) (trackCount - 1L + 1)];
        var positions = new Vec3s[frameCount];
        var facialStates = new FacialState[frameCount];

        for (int t = 0, loopTo = (int) (trackCount - 1L);
             t <= loopTo;
             t++) {
          tracks[t] = new LinkAnimetionTrack(1, new ushort[frameCount]);
        }

        for (int f = 0, loopTo1 = frameCount - 1; f <= loopTo1; f++) {
          var frameOffset = (uint) (animationOffset + f * frameSize);

          // TODO: This should be ReadInt16() instead.
          positions[f] = new Vec3s {
              X = (short) IoUtil.ReadUInt16(animationData, frameOffset),
              Y = (short) IoUtil.ReadUInt16(animationData, frameOffset + 2),
              Z = (short) IoUtil.ReadUInt16(animationData, frameOffset + 4),
          };
          for (int t = 0, loopTo2 = (int) (trackCount - 1L);
               t <= loopTo2;
               t++) {
            var trackOffset = (uint) (frameOffset + 2 * (3 + t));
            tracks[t].Frames[f] = IoUtil.ReadUInt16(animationData, trackOffset);
          }

          var facialStateOffset =
              (int) (frameOffset + 2 * (3 + trackCount));
          var facialState = animationData[facialStateOffset + 1];
          var mouthState = IoUtil.ShiftR(facialState, 4, 4);
          var eyeState = IoUtil.ShiftR(facialState, 0, 4);

          facialStates[f] = new FacialState((EyeState) eyeState,
                                            (MouthState) mouthState);
        }

        var animation =
            new LinkAnimetion(frameCount, tracks, positions, facialStates);
        animations.Add(animation);

        animationList.Items.Add("0x" + Conversion.Hex(i));
      }

      if (animations.Count > 0) {
        return animations;
      }

      return null;
    }
  }
}