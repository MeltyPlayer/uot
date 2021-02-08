using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

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
              var withBlock = tAnimation[animCnt];
              withBlock.FrameCount = frameCount;
              withBlock.TrackOffset = rotationIndicesOffset;
              withBlock.AngleCount = angleCount;
              if (withBlock.FrameCount > 0) {
                withBlock.Angles =
                    new ushort[(int) (withBlock.AngleCount - 1L + 1)];
                withBlock.Tracks =
                    new NormalAnimationTrack[(int) (trackCount - 1L + 1)];
                animationList.Items.Add("0x" + Conversion.Hex(i));
                for (int i1 = 0, loopTo2 = (int) (withBlock.AngleCount - 1L);
                     i1 <= loopTo2;
                     i1++) {
                  withBlock.Angles[i1] =
                      IoUtil.ReadUInt16(rotationValuesBuffer,
                                        rotationValuesOffset);
                  rotationValuesOffset = (uint) (rotationValuesOffset + 2L);
                }

                withBlock.Position.X = IoUtil.ReadInt16(
                    rotationIndicesBuffer,
                    withBlock.TrackOffset);
                withBlock.Position.Y = IoUtil.ReadInt16(
                    rotationIndicesBuffer,
                    withBlock.TrackOffset + 2);
                withBlock.Position.Z = IoUtil.ReadInt16(
                    rotationIndicesBuffer,
                    withBlock.TrackOffset + 4);

                int tTrackOffset = (int) (withBlock.TrackOffset + 6L);
                for (int i1 = 0, loopTo3 = (int) (trackCount - 1L);
                     i1 <= loopTo3;
                     i1++) {
                  var tTrack =
                      IoUtil.ReadUInt16(rotationIndicesBuffer,
                                        (uint) tTrackOffset);
                  if (tTrack < limit) {
                    // Constant (single value)
                    withBlock.Tracks[i1].Type = 0;
                    withBlock.Tracks[i1].Frames = new ushort[1];
                    withBlock.Tracks[i1].Frames[0] = withBlock.Angles[tTrack];
                  } else {
                    // Keyframes
                    withBlock.Tracks[i1].Type = 1;
                    withBlock.Tracks[i1].Frames =
                        new ushort[withBlock.FrameCount];
                    for (int i2 = 0, loopTo4 = withBlock.FrameCount - 1;
                         i2 <= loopTo4;
                         i2++) {
                      try {
                        withBlock.Tracks[i1].Frames[i2] =
                            withBlock.Angles[tTrack + i2];
                      } catch {
                        return null;
                      }
                    }
                  }

                  tTrackOffset += 2;
                }

                tAnimation[animCnt] = withBlock;
              } else {
                Array.Resize(ref tAnimation, animCnt);
              }
            }
          }
        }
      }

      if (tAnimation.Length > 0) {
        var outList = new List<IAnimation>();
        foreach (NormalAnimation animation in tAnimation)
          outList.Add(animation);
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
      int animCnt = -1;
      var animations = new LinkAnimetion[0];
      animationList.Items.Clear();

      var trackCount = (uint) (LimbCount * 3);
      var frameSize = 2 * (3 + trackCount) + 2;
      for (int i = 0x2310; i <= 0x34F8; i += 4) {
        var frameCount = IoUtil.ReadUInt16(HeaderData, (uint) i);
        var animationAddress = IoUtil.ReadUInt32(HeaderData, (uint) (i + 4));
        IoUtil.SplitAddress(animationAddress,
                            out var animationBank,
                            out var animationOffset);
        bool validAnimationBank =
            animationBank == 7; // Corresponds to link_animetions.
        var hasZeroes = IoUtil.ReadUInt16(HeaderData, (uint) (i + 2)) == 0;

        // TODO: Is this really needed?
        var validOffset = animationOffset + frameSize * frameCount <
                          animationData.Count;
        if (validAnimationBank & hasZeroes & validOffset) {
          animCnt += 1;
          Array.Resize(ref animations, animCnt + 1);
          {
            var withBlock = animations[animCnt];

            withBlock.FrameCount = frameCount;
            if (frameCount > 0) {
              withBlock.Positions = new Vec3s[frameCount];
              withBlock.Tracks =
                  new LinkAnimetionTrack[(int) (trackCount - 1L + 1)];
              for (int t = 0, loopTo = (int) (trackCount - 1L);
                   t <= loopTo;
                   t++) {
                withBlock.Tracks[t].Type = 1;
                withBlock.Tracks[t].Frames = new ushort[frameCount];
              }

              withBlock.FacialStates = new FacialState[frameCount];
              for (int f = 0, loopTo1 = frameCount - 1; f <= loopTo1; f++) {
                var frameOffset = (uint) (animationOffset + f * frameSize);

                // TODO: This should be ReadInt16() instead.
                withBlock.Positions[f].X =
                    (short) IoUtil.ReadUInt16(animationData,
                                              frameOffset);
                withBlock.Positions[f].Y =
                    (short) IoUtil.ReadUInt16(animationData,
                                              frameOffset + 2);
                withBlock.Positions[f].Z =
                    (short) IoUtil.ReadUInt16(animationData,
                                              frameOffset + 4);
                for (int t = 0, loopTo2 = (int) (trackCount - 1L);
                     t <= loopTo2;
                     t++) {
                  var trackOffset = (uint) (frameOffset + 2 * (3 + t));
                  withBlock.Tracks[t].Frames[f] =
                      IoUtil.ReadUInt16(animationData, trackOffset);
                }

                var facialStateOffset = (int) (frameOffset + 2 * (3 + trackCount));
                var facialState = animationData[facialStateOffset + 1];
                var mouthState = IoUtil.ShiftR(facialState, 4, 4);
                var eyeState = IoUtil.ShiftR(facialState, 0, 4);
                withBlock.FacialStates[f].EyeState = (EyeState) eyeState;
                withBlock.FacialStates[f].MouthState = (MouthState) mouthState;
              }

              animationList.Items.Add("0x" + Conversion.Hex(i));
            } else {
              Array.Resize(ref animations, animCnt);
            }

            animations[animCnt] = withBlock;
          }
        }
      }

      if (animations.Length > 0) {
        var outList = new List<IAnimation>();
        foreach (LinkAnimetion animation in animations) {
          outList.Add(animation);
        }
        return outList;
      }

      return null;
    }
  }
}