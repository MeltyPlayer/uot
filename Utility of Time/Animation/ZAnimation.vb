Public Class ZAnimation
  Public Function GetHierarchies(ByVal Data() As Byte, ByVal Bank As Byte) As Limb()
    Try
      Dim tOffset As Integer = 0
      Dim tBank As Byte = 0
      Dim tCnt As Integer = 0
      Dim j As Integer = 0
      For i As Integer = 0 To Data.Length - 8 Step 4
        If (Data(i) = Bank) And Data(i + 4) > 0 Then
          tBank = Data(i)
          tCnt = Data(i + 4)
          tOffset = IoUtil.ReadUInt24(Data, i + 1)
          If tOffset < Data.Length - 16 Then
            For j = tOffset To (tOffset + (tCnt * 4) - 1) Step 4
              If Data(j) <> tBank Then
                Exit For
              End If
            Next
            If i = j Then
              Dim tmpHierarchy(tCnt - 1) As Limb
              Dim tmpLimbOff As Integer = 0
              For k As Integer = 0 To tCnt - 1
                tmpHierarchy(k) = New Limb
                tmpLimbOff = IoUtil.ReadUInt24(Data, tOffset + 1)
                With tmpHierarchy(k)
                  .x = IoUtil.ReadUInt16(Data, tmpLimbOff + 0)
                  .y = IoUtil.ReadUInt16(Data, tmpLimbOff + 2)
                  .z = IoUtil.ReadUInt16(Data, tmpLimbOff + 4)
                  .firstChild = CSByte(Data(tmpLimbOff + 6))
                  .nextSibling = CSByte(Data(tmpLimbOff + 7))

                  If Data(tmpLimbOff + 8) = Bank Then
                    .DisplayList = IoUtil.ReadUInt24(Data, tmpLimbOff + 9)
                    ReDim Preserve GlobalVarsCs.N64DList(GlobalVarsCs.N64DList.Length)
                    ReadInDL(Data, GlobalVarsCs.N64DList, .DisplayList, GlobalVarsCs.N64DList.Length - 1)
                  Else
                    .DisplayList = Nothing
                  End If
                  'If Data(tmpLimbOff + 12) = Bank Then
                  '    .DisplayListLow = ReadUInt24(Data, tmpLimbOff + 13)
                  '    ReDim Preserve N64DList(N64DList.Length)
                  '    ReadInDL(Data, N64DList, .DisplayListLow, N64DList.Length - 1)
                  'Else
                  .DisplayListLow = Nothing
                  'End If
                  .r = Rand.NextDouble
                  .g = Rand.NextDouble
                  .b = Rand.NextDouble
                End With
                tOffset += 4
              Next
              Return tmpHierarchy
            End If
          End If
        End If
      Next
      Return Nothing
    Catch err As Exception
      Return Nothing
    End Try
  End Function

  ''' <summary>
  '''   Parses a set of animations according to the spec at:
  '''   https://wiki.cloudmodding.com/oot/Animation_Format#Normal_Animations
  ''' </summary>
  Public Function GetCommonAnimations(ByVal Data() As Byte, ByVal LimbCount As Integer, ByVal Bank As Byte) As CommonAnimation()
    Try
      Dim animCnt As Integer = -1
      Dim tAnimation(-1) As CommonAnimation
      MainWin.AnimationList.Items.Clear()

      ' Guesstimating the index by looking for an spot where the header's angle
      ' address and track address have the same bank as the param at the top.
      ' TODO: Is this robust enough?
      For i As Integer = 16 To Data.Length - 8 Step 4
        Dim attemptOffset = i - 4

        Dim frameCount As UShort = IoUtil.ReadUInt16(Data, attemptOffset)
        Dim rotationValuesAddress As UInt32 = IoUtil.ReadUInt32(Data, attemptOffset + 4)
        Dim rotationIndicesAddress As UInt32 = IoUtil.ReadUInt32(Data, attemptOffset + 8)

        Dim rotationValuesBank As Byte
        Dim rotationValuesOffset As UInt32
        IoUtil.SplitAddress(rotationValuesAddress, rotationValuesBank, rotationValuesOffset)

        Dim rotationIndicesBank As Byte
        Dim rotationIndicesOffset As UInt32
        IoUtil.SplitAddress(rotationIndicesAddress, rotationIndicesBank, rotationIndicesOffset)

        Dim sameRotationValuesBank As Boolean = rotationValuesBank = Bank
        Dim sameRotationIndicesBank As Boolean = rotationIndicesBank = Bank
        Dim validAttemptOffset As Boolean = sameRotationValuesBank And sameRotationIndicesBank

        Dim validRotationValuesOffset As Boolean = rotationValuesOffset < Data.Length
        Dim validRotationIndicesOffset As Boolean = rotationIndicesOffset < Data.Length
        Dim validRotationOffsets As Boolean = validRotationValuesOffset And validRotationIndicesOffset

        Dim angleCount As UInteger = (rotationIndicesOffset - rotationValuesOffset) \ 2
        Dim validAngleCount As Boolean = rotationIndicesOffset > rotationValuesOffset And angleCount > 0

        If validAttemptOffset And validRotationOffsets And validAngleCount Then
          Dim limit As UShort = IoUtil.ReadUInt16(Data, attemptOffset + 12)

          Dim hasZeroes As Boolean = IoUtil.ReadUInt16(Data, attemptOffset + 2) = 0 And IoUtil.ReadUInt16(Data, attemptOffset + 14) = 0
          ' TODO: Assumes 0 is one of the angles, is this valid?
          'Dim validAngles As Boolean = IoUtil.ReadUInt16(Data, rotationValuesOffset) = 0 And IoUtil.ReadUInt16(Data, rotationValuesOffset + 2) > 0

          If hasZeroes Then
            animCnt += 1
            ReDim Preserve tAnimation(animCnt)
            With tAnimation(animCnt)
              .FrameCount = frameCount
              .TrackOffset = rotationIndicesOffset
              .ConstTrackCount = limit

              .TrackCount = (LimbCount * 3)
              .AngleCount = angleCount

              If .FrameCount > 0 Then
                ReDim .Angles(.AngleCount - 1)
                ReDim .Tracks(.TrackCount - 1)

                MainWin.AnimationList.Items.Add("0x" & Hex(i))

                For i1 As Integer = 0 To .AngleCount - 1
                  .Angles(i1) = IoUtil.ReadUInt16(Data, rotationValuesOffset)
                  rotationValuesOffset += 2
                Next

                .XTrans = IoUtil.ReadUInt16(Data, .TrackOffset + 0)
                .YTrans = IoUtil.ReadUInt16(Data, .TrackOffset + 2)
                .ZTrans = IoUtil.ReadUInt16(Data, .TrackOffset + 4)

                Dim tTrackOffset As Integer = .TrackOffset + 6

                Dim tTrack As UInteger = 0
                For i1 As Integer = 0 To .TrackCount - 1
                  tTrack = IoUtil.ReadUInt16(Data, tTrackOffset)

                  If tTrack < .ConstTrackCount Then
                    ' Constant (single value)
                    .Tracks(i1).Type = 0
                    ReDim .Tracks(i1).Frames(0)
                    .Tracks(i1).Frames(0) = .Angles(tTrack)
                  Else
                    ' Keyframes
                    .Tracks(i1).Type = 1
                    ReDim .Tracks(i1).Frames(.FrameCount - 1)
                    For i2 As Integer = 0 To .FrameCount - 1
                      .Tracks(i1).Frames(i2) = .Angles(tTrack + i2)
                    Next
                  End If

                  tTrackOffset += 2
                Next
              Else
                ReDim Preserve tAnimation(animCnt - 1)
              End If
            End With
          End If
        End If
      Next
      If tAnimation.Length > 0 Then
        Return tAnimation
      End If
      Return Nothing
    Catch err As Exception
      Return Nothing
    End Try
  End Function

  Public Function GetTrackRot(ByVal Animation As CommonAnimation, ByVal Counter As FrameAdvancer, ByVal axis As Integer,
                              ByVal Track As Integer) As Single
    'thanks to euler for some of this logic
    Dim tTrack As Integer = Track * 3 + axis

    If tTrack > Animation.Tracks.Length - 1 Then
      tTrack = 0
    End If

    Dim Frame As Integer = Counter.CurrFrame
    Dim NextFrame As Integer = Counter.CurrFrame + 1

    Dim tFrame0 As Double = 0.0F
    Dim tFrame1 As Double = 0.0F

    With Animation.Tracks(tTrack)
      If .Type = 1 Then
        tFrame0 = .Frames(Frame)
        If NextFrame >= .Frames.Length Then
          NextFrame = 0
        End If
        tFrame1 = .Frames(NextFrame)
      ElseIf .Type = 0 Then
        tFrame0 = .Frames(0)
        tFrame1 = .Frames(0)
      End If
    End With

    tFrame0 = AngleToRad(tFrame0)
    tFrame1 = AngleToRad(tFrame1)

    Return Interpolation.Degrees(tFrame0, tFrame1, Counter.FrameDelta)
  End Function

  Public Function Animate(ByVal Animation As IAnimation, ByVal LoopAnimation As Boolean,
                          ByRef CurrentFrame As TrackBar)
    CountFrames(AnimationStopWatch, ZAnimationCounter)
    If ZAnimationCounter.FrameNo < Animation.FrameCount - 1 Then
      ZAnimationCounter.CurrFrame = ZAnimationCounter.FrameNo
      CurrentFrame.Value = ZAnimationCounter.CurrFrame + 1
    ElseIf ZAnimationCounter.FrameNo = Animation.FrameCount - 1 And Not LoopAnimation Then
      ResetAnimation(AnimationStopWatch, ZAnimationCounter)
      StopAnimation(AnimationStopWatch, ZAnimationCounter)
      CurrentFrame.Value = 1
    Else
      ResetAnimation(AnimationStopWatch, ZAnimationCounter)
      StopAnimation(AnimationStopWatch, ZAnimationCounter)
      StartAnimation(AnimationStopWatch, ZAnimationCounter)
      CurrentFrame.Value = 1
    End If
  End Function

  Public Function CountFrames(ByRef AnimationStopWatch As Stopwatch, ByRef Counter As FrameAdvancer)
    With Counter
      .ElapsedSeconds = AnimationStopWatch.Elapsed.TotalSeconds
      .ElapsedMilliseconds = AnimationStopWatch.Elapsed.Milliseconds
      .DeltaTime = .ElapsedSeconds - .LastUpdateTime

      ' TODO: Delete unneeded fields.
      .FramesAdvanced = .FrameDelta + .DeltaTime * .FPS
      .FramesAdvancedInt = Math.Floor(.FramesAdvanced)

      .FrameNo += .FramesAdvancedInt
      .FrameDelta = .FramesAdvanced - .FramesAdvancedInt

      .LastUpdateTime = AnimationStopWatch.Elapsed.TotalSeconds
    End With
  End Function

  Public Function ResetAnimation(ByRef AnimationStopWatch As Stopwatch, ByRef Counter As FrameAdvancer)
    With Counter
      .CurrFrame = 0
      .FrameNo = 0
      .FrameDelta = 0
      .FramesAdvanced = 0
      .FramesAdvancedInt = 0
      .ElapsedMilliseconds = 0
      .ElapsedSeconds = 0
      .LastUpdateTime = 0
      .DeltaTime = 0
    End With
    AnimationStopWatch.Reset()
  End Function

  Public Function StartAnimation(ByRef AnimationStopWatch As Stopwatch, ByRef Counter As FrameAdvancer)
    Counter.Advancing = True
    AnimationStopWatch.Start()
  End Function

  Public Function StopAnimation(ByRef AnimationStopWatch As Stopwatch, ByRef Counter As FrameAdvancer)
    Counter.Advancing = False
    AnimationStopWatch.Stop()
  End Function
End Class
