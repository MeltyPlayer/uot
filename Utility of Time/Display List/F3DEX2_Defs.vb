﻿Module F3DEX2_Defs
  Public Function ReadInDL(Data As IBank, ByRef DisplayList() As N64DisplayList, ByVal Offset As Integer,
                           ByVal Index As Integer) As Integer
    Try
      If Offset < Data.Count Then
        ' TODO: This jumps into the lowest level DL, but the 0xDE command (DL)
        ' actually allows returning back up and calling more DLs. So this seems
        ' like it will sometimes overlook any DLs that follow.
        ' This should just be deleted and replaced w/ emulating in
        ' F3DEX2_Parser.
        If Data(Offset) = &HDE Then
          Do Until Data(Offset) <> &HDE
            Offset = IoUtil.ReadUInt24(Data, Offset + 5)
          Loop
        End If

        ReDim Preserve DisplayList(Index)
        DisplayList(Index) = New N64DisplayList

        Dim EPLoc As UInteger = Offset

        MainWin.DListSelection.Items.Add((Index + 1).ToString & ". " & Hex(Offset))

        With DisplayList(Index)
          .StartPos = New ZSegment
          .StartPos.Offset = Offset
          .StartPos.Bank = RamBanks.CurrentBank
          .Skip = False

          .PickCol = New Color3UByte
          PickerUtil.NextRgb(.PickCol.r, .PickCol.g, .PickCol.b)

          Do
            ReDim Preserve .Commands(.CommandCount)
            .Commands(.CommandCount) = New DLCommand(Data, EPLoc)

            If Data(EPLoc) = F3DZEX.ENDDL Or EPLoc >= Data.Count Then
              EPLoc += 8
              Exit Do
            End If

            EPLoc += 8
            .CommandCount += 1
          Loop
        End With

        Return EPLoc
      End If
    Catch ex As Exception
      MsgBox("Error reading in display list: " & ex.Message, MsgBoxStyle.Critical, "Exception")
      Exit Function
    End Try
  End Function
End Module
