Imports Tao.FreeGlut
Imports Tao.OpenGl
Imports System.Math
Imports System.Runtime.InteropServices
Module Functions
    Public Declare Function ShellExecute Lib "shell32.dll" Alias "ShellExecuteA" _
    (ByVal hWnd As Long, ByVal lpOperation As String, ByVal lpFile As String, ByVal _
    lpParameters As String, ByVal lpDirectory As String, ByVal nShowCmd As Long) As Long
    Public Declare Function GetTickCount Lib "kernel32" () As Long
    Public Sub SetOGLDefaultParams()
        Gl.glDisable(Gl.GL_TEXTURE_2D)
        Gl.glDisable(Gl.GL_FRAGMENT_PROGRAM_ARB)
        Gl.glDisable(Gl.GL_LIGHTING)
        Gl.glDisable(Gl.GL_NORMALIZE)
        Gl.glDisable(Gl.GL_BLEND)
        Gl.glDisable(Gl.GL_POLYGON_OFFSET_FILL)
        Gl.glDisable(Gl.GL_CULL_FACE)
    End Sub
    Public Function RGBA8ColorToColorObject(ByVal Color As Color4UByte) As Color
        Return System.Drawing.Color.FromArgb(Color.a, Color.r, _
                                             Color.g, Color.b)
    End Function
    Public Function PushOGLAttribs(ByVal attribs() As Integer)
        For i As Integer = 0 To attribs.Length - 1
            Gl.glPushAttrib(attribs(i))
        Next
    End Function
    Public Function PopOGLAttribls()
        Gl.glPopAttrib()
    End Function
    Public Function AngleToRad(ByVal angle As Short) As Double
        Return angle * 180.0F / 32768.0F
    End Function
    Public Function SearchDLCache(ByVal N64DList() As N64DisplayList, ByVal Offset As UInteger) As Integer
        For i As Integer = 0 To N64DList.Length - 1
            If N64DList(i).StartPos.Offset = Offset Then
                Return i
            End If
        Next
        Return -1
    End Function
    Public Function ToggleBoolean(ByRef bool As Boolean, ByRef MenuItem As ToolStripMenuItem)
        If bool Then bool = False Else bool = True
        If MenuItem IsNot Nothing Then
            MenuItem.Checked = bool
        End If
    End Function
    Public Sub InitNewCommand(ByRef Command As DLCommand, ByVal CommandCode As Byte)
        Command = New DLCommand
        With Command
            ReDim .CMDParams(7)
            .CMDHigh = 0
            .CMDLow = 0
            .CMDParams(0) = CommandCode
            For i As Integer = 1 To 7
                .CMDParams(i) = 0
            Next
        End With
    End Sub
    Public Function Flip32(ByVal Flip As ULong) As ULong
        Return ((Flip And &HFF000000) >> 24) Or ((Flip And &HFF0000) >> 8) Or _
        ((Flip And &HFF00) << 8) Or ((Flip And &HFF) << 24)
    End Function


    Public Function ReadUInt32(ByVal Buffer() As Byte, ByVal Offset As UInteger) As UInteger
        ReadUInt32 = Buffer(Offset) * &H1000000 _
                                    + Buffer(Offset + 1) * &H10000 _
                                    + Buffer(Offset + 2) * &H100 _
                                    + Buffer(Offset + 3)

    End Function
    Public Function ReadUInt24(ByVal Buffer() As Byte, ByVal Offset As UInteger) As UInteger
        ReadUInt24 = Buffer(Offset) * &H10000 _
                            + Buffer(Offset + 1) * &H100 _
                            + Buffer(Offset + 2)
    End Function
    Public Function ReadInt16(ByVal Buffer() As Byte, ByVal Offset As UInteger) As Integer
        If Offset > Buffer.Length - 1 Then
            ReadInt16 = 0
            Exit Function
        End If
        ReadInt16 = Buffer(Offset) * &H100 + Buffer(Offset + 1)
    End Function
    Public Function WriteInt16(ByRef Buffer() As Byte, ByRef Offset As Short, ByVal Data As Short)
        If Offset >= (Buffer.Length - 1) Then
            ReDim Preserve Buffer(Offset + 2)
        End If
        Buffer(Offset + 0) = (Data >> 8) And &HFF
        Buffer(Offset + 1) = (Data >> 0) And &HFF
        Offset += 2
    End Function
    Public Function WriteInt32(ByRef Buffer() As Byte, ByVal Data As UInteger, ByRef Offset As Integer)
        If Offset >= (Buffer.Length - 1) Then
            ReDim Preserve Buffer(Offset + 4)
        End If
        Buffer(Offset + 0) = (Data >> 24) And &HFF
        Buffer(Offset + 1) = (Data >> 16) And &HFF
        Buffer(Offset + 2) = (Data >> 8) And &HFF
        Buffer(Offset + 3) = (Data >> 0) And &HFF
        Offset += 4
    End Function
    Public Function WriteInt24(ByRef Buffer() As Byte, ByVal Data As UInteger, ByRef Offset As Integer)
        If Offset >= (Buffer.Length - 1) Then
            ReDim Preserve Buffer(Offset + 3)
        End If
        Buffer(Offset + 0) = (Data >> 16) And &HFF
        Buffer(Offset + 1) = (Data >> 8) And &HFF
        Buffer(Offset + 2) = (Data >> 0) And &HFF
        Offset += 3
    End Function
    Public Function NoExt(ByVal FullPath _
            As String) As String
        Return System.IO.Path.GetFileNameWithoutExtension(FullPath)
    End Function
    Public Function Fixed2Float(ByVal v As Double, ByVal b As Integer) As Double
        Return v * FIXED2FLOATRECIP(b - 1)
    End Function
    Public Function Pow2(ByVal val As ULong) As ULong
        Dim i As Long = 1
        While i < val
            i <<= 1
        End While
        Return i
    End Function
    Public Function HexOnly(ByVal str As String) As Boolean
        If "0123456789ABCDEF".IndexOf(str) = -1 Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function PowOf(ByVal val As ULong) As ULong
        Dim num As Long = 1
        Dim i As Long = 0
        While num < val
            num <<= 1
            i += 1
        End While
        Return i
    End Function
    Public Function GetDir(ByVal fn As String) As String
        For i As Integer = fn.Length - 1 To 0 Step -1
            If fn(i) = "\" Or fn(i) = "/" Then
                Return Mid(fn, 1, i)
            End If
        Next
        Return ""
    End Function
    Public Function ConvertHexToSingle(ByVal hexValue As String) As Single
        Try
            Dim iInputIndex As Integer = 0
            Dim iOutputIndex As Integer = 0
            Dim bArray(3) As Byte
            For iInputIndex = 0 To hexValue.Length - 1 Step 2
                bArray(iOutputIndex) = Byte.Parse(hexValue.Chars(iInputIndex) & hexValue.Chars(iInputIndex + 1), Globalization.NumberStyles.HexNumber)
                iOutputIndex += 1
            Next
            Array.Reverse(bArray)
            Return BitConverter.ToSingle(bArray, 0)
        Catch ex As Exception
            Throw New FormatException("The supplied hex value is either empty or in an incorrect format. Use the following format: 00000000", ex)
        End Try
    End Function
    Public Function CheckAllChildNodes(ByVal treeNode1 As TreeNode, ByVal nodeChecked As Boolean) As Object
        Dim node As TreeNode
        For Each node In treeNode1.Nodes
            node.Checked = nodeChecked
            If node.Nodes.Count > 0 Then
                CheckAllChildNodes(node, nodeChecked)
            End If
        Next
    End Function
    'macros for processing n64 dl commands
    Public Function ShiftR(ByVal v As UInt32, ByVal s As UInt32, ByVal w As UInt32) As UInt32
        Return (v >> s) And ((1 << w) - 1)
    End Function
    Public Function ShiftL(ByVal v As UInt32, ByVal s As UInt32, ByVal w As UInt32) As UInt32
        Return (v And ((1 << w) - 1) << s)
    End Function
    Public Function Hex2(ByVal sHex As String) As Byte()
        Dim n As Long
        Dim nCount As Long
        Dim bArr() As Byte
        nCount = Len(sHex)
        If (nCount And 1) = 1 Then
            sHex = "0" & sHex
            nCount += 1
        End If
        ReDim bArr((nCount \ 2) - 1)
        For n = 1 To nCount Step 2
            bArr((n - 1) \ 2) = CByte("&H" & Mid$(sHex, n, 2))
        Next
        Hex2 = bArr
    End Function
    Public Function GetFileName(ByVal flname As String, ByVal getdir As Boolean) As String
        Dim posn As Integer, i As Integer
        Dim fName As String
        Dim fLen As Integer = flname.Length - 1
        If Not getdir Then
            For i = 0 To fLen
                If flname(i) = "\" Or flname(i) = "/" Then posn = i
            Next
        Else
            For i = fLen To 0 Step -1
                If flname(i) = "\" Or flname(i) = "/" Then
                    posn = i
                    Exit For
                End If
            Next
        End If
        If getdir Then fName = Mid(flname, 1, posn) Else fName = Right(flname, fLen - posn)
        Return fName
    End Function

    Public Function SearchListbox(ByRef listbx As ListBox, ByVal searchbox As TextBox, ByVal startind As Integer, ByVal nxt As Boolean) As Boolean
        If searchbox.Text <> "" Then
            If Not nxt Then
                For i As Integer = 0 To listbx.Items.Count - 1
                    If listbx.Items.Item(i).tolower.contains(searchbox.Text.ToLower) Then
                        listbx.SelectedIndex = i
                        Return True
                    End If
                Next
            Else
                For i As Integer = startind + 1 To listbx.Items.Count - 1
                    If listbx.Items.Item(i).tolower.contains(searchbox.Text.ToLower) Then
                        listbx.SelectedIndex = i
                        Return True
                    End If
                Next
            End If
            listbx.SelectedIndex = -1
            Return False
        End If
    End Function
    Public Function GLPrint2D(ByVal Text As String, ByVal XPos As Integer, ByVal YPos As Integer, ByVal Shadow As Boolean)
        Gl.glMatrixMode(Gl.GL_PROJECTION)
        Gl.glPushMatrix()
        Gl.glLoadIdentity()
        Gl.glOrtho(0, winw, 0, winh, 0, 1)

        Gl.glMatrixMode(Gl.GL_MODELVIEW)
        Gl.glPushMatrix()
        Gl.glLoadIdentity()

        If Shadow Then
            'shadow (black - 0r, 0g, 0b)
            Gl.glColor3f(0, 0, 0)
            Gl.glRasterPos2f(XPos + 1, winh - YPos - 1)
            For a As Integer = 0 To Text.Length - 1
                Glut.glutBitmapCharacter(Glut.GLUT_BITMAP_HELVETICA_18, Asc(Text(a)))
            Next
        End If

        'main text (white - 1r, 1g, 1b)
        Gl.glColor3f(1, 1, 1)
        Gl.glRasterPos2f(XPos, winh - YPos)
        For a As Integer = 0 To Text.Length - 1
            Glut.glutBitmapCharacter(Glut.GLUT_BITMAP_HELVETICA_18, Asc(Text(a)))
        Next

        Gl.glMatrixMode(Gl.GL_PROJECTION)
        Gl.glPopMatrix()

        Gl.glMatrixMode(Gl.GL_MODELVIEW)
        Gl.glPopMatrix()
    End Function
    Public Sub UpdateCommand(ByRef DL As N64DisplayList, ByVal CmdPos As UInteger, ByVal newCmd As Byte, ByVal newHW As UInteger, ByVal newLW As UInteger)
        With DL.Commands(CmdPos)
            .CMDHigh = newHW
            .CMDLow = newLW
            .CMDParams(0) = newCmd
            .DLPos = CmdPos
            WriteInt24(.CMDParams, newLW, 1)
            WriteInt32(.CMDParams, newHW, 4)
        End With
    End Sub
End Module
