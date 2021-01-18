Imports System.Numerics
Imports UoT.animation.playback

Public Class ZAnimation
  ''' <summary>
  '''   Parses a limb hierarchy according to the following spec:
  '''   https://wiki.cloudmodding.com/oot/Animation_Format#Hierarchy
  ''' </summary>
  Public Function GetHierarchies(Data As IBank, isLink As Boolean, dlManager As DlManager, model As StaticDlModel) As Limb()
    Dim limbIndexAddress As UInteger
    Dim limbIndexBank As UInteger
    Dim limbIndexOffset As UInteger

    model.Reset()

    Dim j As Integer = 0
    For i As Integer = 0 To Data.Count - 8 Step 4
      limbIndexAddress = IoUtil.ReadUInt32(Data, i)
      IoUtil.SplitAddress(limbIndexAddress, limbIndexBank, limbIndexOffset)

      Dim limbCount As UInteger = Data(i + 4)

      Dim limbAddress As UInteger
      Dim limbBank As UInteger
      Dim limbOffset As UInteger
      Dim limbBankBuffer As IBank

      ' Link has an extra set of values for each limb that define LOD model
      ' display lists.
      Dim limbSize As UInteger
      If isLink Then
        limbSize = 16
      Else
        limbSize = 12
      End If

      If RamBanks.IsValidBank(limbIndexBank) And limbCount > 0 Then
        Dim limbIndexBankBuffer As IBank = RamBanks.GetBankByIndex(limbIndexBank)

        If limbIndexOffset + 4 * limbCount < limbIndexBankBuffer.Count Then
          Dim firstChild As Byte
          Dim nextSibling As Byte

          Dim isValid As Boolean = True
          Dim somethingVisible As Boolean = False

          For j = 0 To limbCount - 1
            limbAddress = IoUtil.ReadUInt32(limbIndexBankBuffer, limbIndexOffset + j * 4)
            IoUtil.SplitAddress(limbAddress, limbBank, limbOffset)

            If Not RamBanks.IsValidBank(limbBank) Then
              isValid = False
              GoTo badLimbIndexOffset
            End If

            limbBankBuffer = RamBanks.GetBankByIndex(limbBank)

            If limbOffset + limbSize >= limbBankBuffer.Count Then
              isValid = False
              GoTo badLimbIndexOffset
            End If

            firstChild = limbBankBuffer(limbOffset + 6)
            nextSibling = limbBankBuffer(limbOffset + 7)

            If firstChild = j Or nextSibling = j Then
              isValid = False
              GoTo badLimbIndexOffset
            End If

            Dim displayListAddress As UInteger = IoUtil.ReadUInt32(limbBankBuffer, limbOffset + 8)
            Dim displayListBank As UInteger
            Dim displayListOffset As UInteger
            IoUtil.SplitAddress(displayListAddress, displayListBank, displayListOffset)

            If displayListBank <> 0 Then
              somethingVisible = True
            End If

            If displayListBank <> 0 And Not RamBanks.IsValidBank(displayListBank) Then
              isValid = False
              GoTo badLimbIndexOffset
            End If
          Next

badLimbIndexOffset:

          If isValid Then
            Dim tmpHierarchy(limbCount - 1) As Limb
            For k As Integer = 0 To limbCount - 1
              limbAddress = IoUtil.ReadUInt32(limbIndexBankBuffer, limbIndexOffset + 4 * k)
              IoUtil.SplitAddress(limbAddress, limbBank, limbOffset)
              limbBankBuffer = RamBanks.GetBankByIndex(limbBank)

              tmpHierarchy(k) = New Limb
              With tmpHierarchy(k)
                .x = IoUtil.ReadUInt16(limbBankBuffer, limbOffset + 0)
                .y = IoUtil.ReadUInt16(limbBankBuffer, limbOffset + 2)
                .z = IoUtil.ReadUInt16(limbBankBuffer, limbOffset + 4)
                .firstChild = CSByte(limbBankBuffer(limbOffset + 6))
                .nextSibling = CSByte(limbBankBuffer(limbOffset + 7))

                DlModel.AddLimb(.x, .y, .z, .firstChild, .nextSibling)

                Dim displayListAddress As UInteger = IoUtil.ReadUInt32(limbBankBuffer, limbOffset + 8)
                Dim displayListBank As UInteger
                Dim displayListOffset As UInteger
                IoUtil.SplitAddress(displayListAddress, displayListBank, displayListOffset)

                If displayListBank <> 0 Then
                  Dim displayListBankBuffer As IBank = RamBanks.GetBankByIndex(displayListBank)
                  .DisplayListAddress = displayListAddress

                  ReadInDL(dlManager, displayListAddress)
                ElseIf Not somethingVisible Then
                  .DisplayListAddress = displayListAddress
                Else
                  .DisplayListAddress = displayListAddress
                End If

                ' Far model display list (i.e. LOD model). Only used for Link.
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
            Next

            If isValid And Not somethingVisible Then
              Throw New NotSupportedException("model format is not rendering a valid model!")
            End If

            Return tmpHierarchy
          End If
        End If
      End If
    Next
    Return Nothing
  End Function

  ''' <summary>
  '''   Parses a set of animations according to the spec at:
  '''   https://wiki.cloudmodding.com/oot/Animation_Format#Normal_Animations
  ''' </summary>
  Public Function GetCommonAnimations(Data As IBank, ByVal LimbCount As Integer) _
    As IList(Of IAnimation)
    Dim trackCount As UInteger = LimbCount * 3

    Dim animCnt As Integer = -1
    Dim tAnimation(-1) As NormalAnimation
    MainWin.AnimationList.Items.Clear()

    ' Guesstimating the index by looking for an spot where the header's angle
    ' address and track address have the same bank as the param at the top.
    ' TODO: Is this robust enough?
    For i As Integer = 4 To Data.Count - 12 - 1 Step 4
      Dim attemptOffset = i - 4

      Dim frameCount As UShort = IoUtil.ReadUInt16(Data, attemptOffset)

      If frameCount = 0 Then
        Continue For
      End If

      Dim rotationValuesAddress As UInt32 = IoUtil.ReadUInt32(Data, attemptOffset + 4)
      Dim rotationIndicesAddress As UInt32 = IoUtil.ReadUInt32(Data, attemptOffset + 8)

      Dim rotationValuesBank As Byte
      Dim rotationValuesOffset As UInt32
      IoUtil.SplitAddress(rotationValuesAddress, rotationValuesBank, rotationValuesOffset)

      Dim rotationIndicesBank As Byte
      Dim rotationIndicesOffset As UInt32
      IoUtil.SplitAddress(rotationIndicesAddress, rotationIndicesBank, rotationIndicesOffset)

      Dim limit As UShort = IoUtil.ReadUInt16(Data, attemptOffset + 12)

      Dim validAttemptOffset As Boolean = RamBanks.IsValidBank(rotationValuesBank) And RamBanks.IsValidBank(rotationIndicesBank)

      Dim rotationValuesBuffer As IBank
      Dim rotationIndicesBuffer As IBank
      Dim validRotationOffsets As Boolean = False
      If validAttemptOffset Then
        ' 6 is "current file", which is whatever was passed into "Data".
        If rotationValuesBank = 6 Then
          rotationValuesBuffer = Data
        Else
          rotationValuesBuffer = RamBanks.GetBankByIndex(rotationValuesBank)
        End If
        If rotationIndicesBank = 6 Then
          rotationIndicesBuffer = Data
        Else
          rotationIndicesBuffer = RamBanks.GetBankByIndex(rotationIndicesBank)
        End If

        ' Offsets should be within bounds of the bank.
        Dim validRotationValuesOffset As Boolean = rotationValuesOffset < rotationValuesBuffer.Count
        Dim validRotationIndicesOffset As Boolean = rotationIndicesOffset < rotationIndicesBuffer.Count
        validRotationOffsets = validRotationValuesOffset And validRotationIndicesOffset
      End If

      ' Angle count should be greater than 0.
      Dim angleCount As UInteger = (rotationIndicesOffset - rotationValuesOffset) \ 2
      Dim validAngleCount As Boolean = rotationIndicesOffset > rotationValuesOffset And angleCount > 0

      If validAttemptOffset And validRotationOffsets And validAngleCount Then
        ' Should have zeroes present in two spots of the animation header. 
        Dim hasZeroes As Boolean = IoUtil.ReadUInt16(Data, attemptOffset + 2) = 0 And
                                   IoUtil.ReadUInt16(Data, attemptOffset + 14) = 0

        ' TODO: Assumes 0 is one of the angles, is this valid?
        'Dim validAngles As Boolean = IoUtil.ReadUInt16(Data, rotationValuesOffset) = 0 And IoUtil.ReadUInt16(Data, rotationValuesOffset + 2) > 0

        ' All values of "tTrack" should be within the bounds of .Angles.
        Dim validTTracks As Boolean = True
        For i1 As Integer = 0 To trackCount - 1
          Dim tTrack As UShort = IoUtil.ReadUInt16(rotationIndicesBuffer, rotationIndicesOffset + 6 + 2 * i1)

          If tTrack < limit Then
            If tTrack >= angleCount Then
              validTTracks = False
              GoTo badTTracks
            End If
          ElseIf tTrack + frameCount > angleCount Then
            validTTracks = False
            GoTo badTTracks
          End If
        Next
badTTracks:

        If hasZeroes And validTTracks Then
          animCnt += 1
          ReDim Preserve tAnimation(animCnt)
          With tAnimation(animCnt)
            .FrameCount = frameCount
            .TrackOffset = rotationIndicesOffset

            .AngleCount = angleCount

            If .FrameCount > 0 Then
              ReDim .Angles(.AngleCount - 1)
              ReDim .Tracks(trackCount - 1)

              MainWin.AnimationList.Items.Add("0x" & Hex(i))

              For i1 As Integer = 0 To .AngleCount - 1
                .Angles(i1) = IoUtil.ReadUInt16(rotationValuesBuffer, rotationValuesOffset)
                rotationValuesOffset += 2
              Next

              .Position.X = IoUtil.ReadInt16(rotationIndicesBuffer, .TrackOffset + 0)
              .Position.Y = IoUtil.ReadInt16(rotationIndicesBuffer, .TrackOffset + 2)
              .Position.Z = IoUtil.ReadInt16(rotationIndicesBuffer, .TrackOffset + 4)

              Dim tTrackOffset As Integer = .TrackOffset + 6

              For i1 As Integer = 0 To trackCount - 1
                Dim tTrack As UShort = IoUtil.ReadUInt16(rotationIndicesBuffer, tTrackOffset)

                If tTrack < limit Then
                  ' Constant (single value)
                  .Tracks(i1).Type = 0
                  ReDim .Tracks(i1).Frames(0)
                  .Tracks(i1).Frames(0) = .Angles(tTrack)
                Else
                  ' Keyframes
                  .Tracks(i1).Type = 1
                  ReDim .Tracks(i1).Frames(.FrameCount - 1)
                  For i2 As Integer = 0 To .FrameCount - 1
                    Try
                      .Tracks(i1).Frames(i2) = .Angles(tTrack + i2)
                    Catch
                      Return Nothing
                    End Try
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
      Dim outList As New List(Of IAnimation)
      For Each animation As NormalAnimation In tAnimation
        outList.Add(animation)
      Next
      Return outList
    End If
    Return Nothing
  End Function

  ''' <summary>
  '''   Parses a set of animations according to the spec at:
  '''   https://wiki.cloudmodding.com/oot/Animation_Format#C_code
  ''' </summary>
  Public Function GetLinkAnimations(HeaderData As IBank, ByVal LimbCount As Integer, animationData As IBank) _
    As IList(Of IAnimation)
    Dim animCnt As Integer = -1
    Dim animations(-1) As LinkAnimetion
    MainWin.AnimationList.Items.Clear()

    Dim trackCount As UInteger = LimbCount * 3
    Dim frameSize = 2 * (3 + trackCount) + 2

    For i As Integer = &H2310 To &H34F8 Step 4
      Dim frameCount As UShort = IoUtil.ReadUInt16(HeaderData, i)
      Dim animationAddress As UInt32 = IoUtil.ReadUInt32(HeaderData, i + 4)

      Dim animationBank As Byte
      Dim animationOffset As UInt32
      IoUtil.SplitAddress(animationAddress, animationBank, animationOffset)

      Dim validAnimationBank As Boolean = animationBank = 7 ' Corresponds to link_animetions.
      Dim hasZeroes As Boolean = IoUtil.ReadUInt16(HeaderData, i + 2) = 0

      ' TODO: Is this really needed?
      Dim validOffset As Boolean = animationOffset + frameSize * frameCount < animationData.Count

      If validAnimationBank And hasZeroes And validOffset Then
        animCnt += 1
        ReDim Preserve animations(animCnt)
        With animations(animCnt)
          .FrameCount = frameCount

          If frameCount > 0 Then
            ReDim .Positions(frameCount - 1)

            ReDim .Tracks(trackCount - 1)
            For t As Integer = 0 To trackCount - 1
              .Tracks(t).Type = 1
              ReDim .Tracks(t).Frames(frameCount - 1)
            Next

            For f As Integer = 0 To frameCount - 1
              Dim frameOffset As UInteger = animationOffset + f * frameSize

              ' TODO: This should be ReadInt16() instead.
              Dim position As Vec3s
              .Positions(f).X = IoUtil.ReadUInt16(animationData, frameOffset + 0)
              .Positions(f).Y = IoUtil.ReadUInt16(animationData, frameOffset + 2)
              .Positions(f).Z = IoUtil.ReadUInt16(animationData, frameOffset + 4)

              For t As Integer = 0 To trackCount - 1
                Dim trackOffset As UInteger = frameOffset + 2 * (3 + t)

                .Tracks(t).Frames(f) = IoUtil.ReadUInt16(animationData, trackOffset)
              Next
            Next

            MainWin.AnimationList.Items.Add("0x" & Hex(i))
          Else
            ReDim Preserve animations(animCnt - 1)
          End If
        End With
      End If
    Next
    If animations.Length > 0 Then
      Dim outList As New List(Of IAnimation)
      For Each animation As LinkAnimetion In animations
        outList.Add(animation)
      Next
      Return outList
    End If
    Return Nothing
  End Function
End Class
