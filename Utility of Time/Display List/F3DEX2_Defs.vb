Module F3DEX2_Defs
  Public Function ReadInDL(Data As IRamBank, ByRef DisplayList() As N64DisplayList, ByVal Offset As Integer,
                           ByVal Index As Integer) As Integer
    Try
      If Offset < Data.Count Then
        If Data(Offset) = &HDE Then
          Do Until Data(Offset) <> &HDE
            Offset = IoUtil.ReadUInt24(Data, Offset + 5)
          Loop
        End If

        ReDim Preserve DisplayList(Index)
        DisplayList(Index) = New N64DisplayList

        Dim EPLoc As Integer = Offset

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
            ReDim Preserve .CommandsCopy(.CommandCount)
            ReDim .Commands(.CommandCount).CMDParams(7)

            .Commands(.CommandCount).Name = DLParser.IdentifyCommand(Data(EPLoc))

            For i As Integer = 0 To 7
              .Commands(.CommandCount).CMDParams(i) = Data(EPLoc + i)
            Next

            .Commands(.CommandCount).CMDLow = IoUtil.ReadUInt24(Data, EPLoc + 1)

            .Commands(.CommandCount).CMDHigh = IoUtil.ReadUInt32(Data, EPLoc + 4)

            .Commands(.CommandCount).DLPos = .CommandCount

            If Data(EPLoc) = F3DZEX.ENDDL Or EPLoc >= Data.Count Then
              EPLoc += 8
              Exit Do
            End If

            EPLoc += 8
            .CommandCount += 1
          Loop
          .CommandsCopy = .Commands
        End With

        Return EPLoc
      End If
    Catch ex As Exception
      MsgBox("Error reading in display list: " & ex.Message, MsgBoxStyle.Critical, "Exception")
      Exit Function
    End Try
  End Function
End Module
