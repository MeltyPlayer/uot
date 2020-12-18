using System;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace UoT {
  public class ZAnimation {
    public Structs.Limb[] GetHierarchies(byte[] Data, byte Bank) {
      try {
        int tOffset = 0;
        byte tBank = 0;
        int tCnt = 0;
        int j = 0;
        for (int i = 0, loopTo = Data.Length - 8; i <= loopTo; i += 4) {
          if (Data[i] == Bank & Data[i + 4] > 0) {
            tBank = Data[i];
            tCnt = Data[i + 4];
            tOffset = (int)Functions.ReadUInt24(Data, (uint)(i + 1));
            if (tOffset < Data.Length - 16) {
              var loopTo1 = tOffset + tCnt * 4 - 1;
              for (j = tOffset; j <= loopTo1; j += 4) {
                if (Data[j] != tBank) {
                  break;
                }
              }

              if (i == j) {
                var tmpHierarchy = new Structs.Limb[tCnt];
                int tmpLimbOff = 0;
                for (int k = 0, loopTo2 = tCnt - 1; k <= loopTo2; k++) {
                  tmpHierarchy[k] = new Structs.Limb();
                  tmpLimbOff = (int)Functions.ReadUInt24(Data, (uint)(tOffset + 1));
                  {
                    var withBlock = tmpHierarchy[k];
                    withBlock.x = (short)Functions.ReadInt16(Data, (uint)(tmpLimbOff + 0));
                    withBlock.y = (short)Functions.ReadInt16(Data, (uint)(tmpLimbOff + 2));
                    withBlock.z = (short)Functions.ReadInt16(Data, (uint)(tmpLimbOff + 4));
                    withBlock.c0 = (sbyte)Data[tmpLimbOff + 6];
                    withBlock.c1 = (sbyte)Data[tmpLimbOff + 7];
                    if (Data[tmpLimbOff + 8] == Bank) {
                      withBlock.DisplayList = Functions.ReadUInt24(Data, (uint)(tmpLimbOff + 9));
                      Array.Resize(ref GlobalVars.N64DList, GlobalVars.N64DList.Length + 1);
                      F3DEX2_Defs.ReadInDL(Data, ref GlobalVars.N64DList, (int)withBlock.DisplayList, GlobalVars.N64DList.Length - 1);
                    } else {
                      withBlock.DisplayList = default;
                    }
                    // If Data(tmpLimbOff + 12) = Bank Then
                    // .DisplayListLow = ReadUInt24(Data, tmpLimbOff + 13)
                    // ReDim Preserve N64DList(N64DList.Length)
                    // ReadInDL(Data, N64DList, .DisplayListLow, N64DList.Length - 1)
                    // Else
                    withBlock.DisplayListLow = default;
                    // End If
                    withBlock.r = GlobalVars.Rand.NextDouble();
                    withBlock.g = GlobalVars.Rand.NextDouble();
                    withBlock.b = GlobalVars.Rand.NextDouble();
                  }

                  tOffset += 4;
                }

                return tmpHierarchy;
              }
            }
          }
        }

        return null;
      } catch (Exception err) {
        return null;
      }
    }

    public Structs.Animation[] GetAnimations(byte[] Data, int LimbCount, byte Bank) {
      try {
        int animCnt = -1;
        uint angleOffset = 0U;
        var tAnimation = new Structs.Animation[0];
        My.MyProject.Forms.MainWin.AnimationList.Items.Clear();
        for (int i = 16, loopTo = Data.Length - 8; i <= loopTo; i += 4) {
          if (Data[i] == Bank & Data[i + 4] == Bank & Data[i - 3] > 0 & Data[i - 4] == 0) {
            angleOffset = Functions.ReadUInt24(Data, (uint)(i + 1));
            if (angleOffset < Data.Length) {
              if (Data[(int)angleOffset] == 0 & Data[(int)(angleOffset + 1L)] == 0 & Functions.ReadInt16(Data, (uint)(angleOffset + 2L)) > 0) {
                animCnt += 1;
                Array.Resize(ref tAnimation, animCnt + 1);
                {
                  var withBlock = tAnimation[animCnt] = new Structs.Animation();
                  withBlock.TrackCount = (uint)(LimbCount * 3);
                  withBlock.ConstTrackCount = Functions.ReadInt16(Data, (uint)(i + 8));
                  withBlock.TrackOffset = Functions.ReadUInt24(Data, (uint)(i + 5));
                  withBlock.FrameCount = (uint)Functions.ReadInt16(Data, (uint)(i - 4));
                  withBlock.AngleCount = (uint)((withBlock.TrackOffset - angleOffset) / 2L);
                  if (withBlock.FrameCount > 0L) {
                    withBlock.Angles = new short[(int)(withBlock.AngleCount - 1L + 1)];
                    withBlock.Tracks = new Structs.AnimTrack[(int)(withBlock.TrackCount - 1L + 1)];
                    My.MyProject.Forms.MainWin.AnimationList.Items.Add("0x" + Conversion.Hex(i));
                    for (int i1 = 0, loopTo1 = (int)(withBlock.AngleCount - 1L); i1 <= loopTo1; i1++) {
                      withBlock.Angles[i1] = (short)Functions.ReadInt16(Data, angleOffset);
                      angleOffset = (uint)(angleOffset + 2L);
                    }

                    withBlock.XTrans = (uint)Functions.ReadInt16(Data, (uint)(withBlock.TrackOffset + 0L));
                    withBlock.YTrans = (uint)Functions.ReadInt16(Data, (uint)(withBlock.TrackOffset + 2L));
                    withBlock.ZTrans = (uint)Functions.ReadInt16(Data, (uint)(withBlock.TrackOffset + 4L));
                    int tTrackOffset = (int)(withBlock.TrackOffset + 6L);
                    uint tTrack = 0U;
                    for (int i1 = 0, loopTo2 = (int)(withBlock.TrackCount - 1L); i1 <= loopTo2; i1++) {
                      tTrack = (uint)Functions.ReadInt16(Data, (uint)tTrackOffset);

                      withBlock.Tracks[i1] = new Structs.AnimTrack();

                      if (tTrack < withBlock.ConstTrackCount) {
                        withBlock.Tracks[i1].Frames = new short[1];
                        withBlock.Tracks[i1].Frames[0] = withBlock.Angles[(int)tTrack];
                        withBlock.Tracks[i1].Type = 0;
                      } else {
                        withBlock.Tracks[i1].Frames = new short[(int)(withBlock.FrameCount - 1L + 1)];
                        for (int i2 = 0, loopTo3 = (int)(withBlock.FrameCount - 1L); i2 <= loopTo3; i2++)
                          withBlock.Tracks[i1].Frames[i2] = withBlock.Angles[(int)(tTrack + i2)];
                        withBlock.Tracks[i1].Type = 1;
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
        }

        if (tAnimation.Length > 0) {
          return tAnimation;
        }

        return null;
      } catch (Exception err) {
        return null;
      }
    }

    public float GetTrackRot(Structs.Animation Animation, Structs.FrameAdvancer Counter, int axis, int Track) {
      // thanks to euler for some of this logic
      try {
        int tTrack = Track * 3 + axis;
        if (tTrack > Animation.Tracks.Length - 1) {
          tTrack = 0;
        }

        int Frame = (int)Counter.CurrFrame;
        int NextFrame = (int)(Counter.CurrFrame + 1L);
        double tFrame0 = 0.0d;
        double tFrame1 = 0.0d;
        {
          var withBlock = Animation.Tracks[tTrack];
          if (withBlock.Type == 1) {
            tFrame0 = withBlock.Frames[Frame];
            if (NextFrame >= withBlock.Frames.Length) {
              NextFrame = 0;
            }

            tFrame1 = withBlock.Frames[NextFrame];
          } else if (withBlock.Type == 0) {
            tFrame0 = withBlock.Frames[0];
            tFrame1 = withBlock.Frames[0];
          }
        }

        tFrame0 = Functions.AngleToRad((short)tFrame0);
        tFrame1 = Functions.AngleToRad((short)tFrame1);
        if (tFrame1 > tFrame0 + 180.0d) {
          tFrame1 -= 360.0d;
        } else if (tFrame1 < tFrame0 - 180.0d) {
          tFrame1 += 360d;
        }

        return (float)(tFrame0 * (1f - Counter.FrameDelta) + tFrame1 * Counter.FrameDelta);
      } catch (Exception err) {
        return 0f;
      }
    }

    public object Animate(Structs.Animation[] AnimationEntries, int Index, bool LoopAnimation, ref TrackBar CurrentFrame) {
      GlobalVars.AnimParser.CountFrames(ref GlobalVars.AnimationStopWatch, ref GlobalVars.ZAnimationCounter);
      if (GlobalVars.ZAnimationCounter.FrameNo < AnimationEntries[Index].FrameCount - 1L) {
        GlobalVars.ZAnimationCounter.CurrFrame = GlobalVars.ZAnimationCounter.FrameNo;
        CurrentFrame.Value = (int)(GlobalVars.ZAnimationCounter.CurrFrame + 1L);
      } else if (GlobalVars.ZAnimationCounter.FrameNo == AnimationEntries[Index].FrameCount - 1L & !LoopAnimation) {
        GlobalVars.AnimParser.ResetAnimation(ref GlobalVars.AnimationStopWatch, ref GlobalVars.ZAnimationCounter);
        GlobalVars.AnimParser.StopAnimation(ref GlobalVars.AnimationStopWatch, ref GlobalVars.ZAnimationCounter);
        CurrentFrame.Value = 1;
      } else {
        GlobalVars.AnimParser.ResetAnimation(ref GlobalVars.AnimationStopWatch, ref GlobalVars.ZAnimationCounter);
        GlobalVars.AnimParser.StopAnimation(ref GlobalVars.AnimationStopWatch, ref GlobalVars.ZAnimationCounter);
        GlobalVars.AnimParser.StartAnimation(ref GlobalVars.AnimationStopWatch, ref GlobalVars.ZAnimationCounter);
        CurrentFrame.Value = 1;
      }

      return default;
    }

    public object CountFrames(ref Stopwatch AnimationStopWatch, ref Structs.FrameAdvancer Counter) {
      Counter.ElapsedSeconds = (float)AnimationStopWatch.Elapsed.TotalSeconds;
      Counter.ElapsedMilliseconds = AnimationStopWatch.Elapsed.Milliseconds;
      Counter.DeltaTime = Counter.ElapsedSeconds - Counter.LastUpdateTime;
      Counter.FramesAdvanced = Counter.FrameDelta + Counter.DeltaTime * Counter.FPS;
      Counter.FramesAdvancedInt = (int)Counter.FramesAdvanced;
      Counter.FrameNo = (uint)(Counter.FrameNo + Counter.FramesAdvanced);
      Counter.FrameDelta = (float)(Counter.FramesAdvanced - (double)Counter.FramesAdvancedInt);
      Counter.LastUpdateTime = (float)AnimationStopWatch.Elapsed.TotalSeconds;
      return default;
    }

    public object ResetAnimation(ref Stopwatch AnimationStopWatch, ref Structs.FrameAdvancer Counter) {
      Counter.CurrFrame = 0U;
      Counter.FrameNo = 0U;
      Counter.FrameDelta = 0f;
      Counter.FramesAdvanced = 0f;
      Counter.FramesAdvancedInt = 0;
      Counter.ElapsedMilliseconds = 0f;
      Counter.ElapsedSeconds = 0f;
      Counter.LastUpdateTime = 0f;
      Counter.DeltaTime = 0f;
      AnimationStopWatch.Reset();
      return default;
    }

    public object StartAnimation(ref Stopwatch AnimationStopWatch, ref Structs.FrameAdvancer Counter) {
      Counter.Advancing = true;
      AnimationStopWatch.Start();
      return default;
    }

    public object StopAnimation(ref Stopwatch AnimationStopWatch, ref Structs.FrameAdvancer Counter) {
      Counter.Advancing = false;
      AnimationStopWatch.Stop();
      return default;
    }
  }
}