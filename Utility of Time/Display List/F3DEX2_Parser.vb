Imports System.Math
Imports Tao.OpenGl

Public Class F3DEX2_Parser

#Region "VARIABLES"

  Public Enum Parse
    GEOMETRY = 1
    EVERYTHING = 0
  End Enum

  Public ParseMode As Integer = - 1

#Region "SHADERS & TEXTURE RELATED"

  Private Palette16() As Byte
  Private N64GeometryMode As UInt32
  Private MultiTexture As Boolean
  Private CurrentTex As Integer
  Private MultiTexCoord As Boolean = False
  Private TextureCache As TextureCache = New TextureCache()
  Private TileDescriptors(1) As TileDescriptor
  Private FragShaderCache(-1) As ShaderCache
  Private PrimColor() As Single = {1.0, 1.0, 1.0, 0.5}
  Private PrimColorLOD As Single = 0
  Private PrimColorM As Single = 0
  Private EnvironmentColor() As Single = {1.0, 1.0, 1.0, 0.5}
  Private BlendColor() As Single = {1.0, 1.0, 1.0, 0.5}
  Private FogColor() As Single = {1.0, 1.0, 1.0, 0.5}
  Private CombArg As New UnpackedCombiner
  Private PrecompiledCombiner As Boolean = False
  Private EnableCombiner As Boolean = False

#End Region

#Region "GEOMETRY RELATED"

  Private VertBufferOff As Integer = 0
  Private Polygons(5) As UInteger
  Private v0 As Byte = 0
  Private n0 As Byte = 0
  Private EnableLighting As Boolean = True
  Private VertexCache As N64Vertex
  Private CycleMode As Integer = 0
  Private FullAlphaCombiner As Boolean = False
  Private ModColorWithAlpha As Boolean = False

  Structure RSPMatrix
    Dim N64Mat() As Byte
    Dim OGLMat(,) As Single
  End Structure

#End Region

#Region "COMMON Z64 DATA"

#End Region

#End Region

#Region "F3DEX2 TO OPENGL DISPLAY LIST"

  Public Sub ParseDL(ByVal DL As N64DisplayList)
    For i As Integer = 0 To DL.Commands.Length - 1
      With DL.Commands(i)
        If ParseMode = Parse.EVERYTHING Then
          Select Case .CMDParams(0)
            Case F3DZEX.POPMTX
popmatrix:

            Case RDP.G_SETENVCOLOR
setenvironmentcolor:
              ENVCOLOR(.CMDParams)

            Case RDP.G_SETPRIMCOLOR
setprimitivecolor:
              SETPRIMCOLOR(.CMDParams)

            Case RDP.G_SETTIMG
settextureimg:
              Dim pal As Boolean = (DL.Commands(i + 1).CMDParams(0) = RDP.G_RDPTILESYNC)

              If DL.Commands(i - 1).CMDParams(0) = RDP.G_SETTILESIZE Then
                CurrentTex = 1
                If GLExtensions.GLMultiTexture And GLExtensions.GLFragProg Then
                  MultiTexCoord = True
                Else
                  MultiTexCoord = False
                End If
                MultiTexture = True
              Else
                MultiTexture = False
                MultiTexCoord = False
                CurrentTex = 0
              End If

              SETTIMG(.CMDHigh, pal)

            Case RDP.G_LOADTLUT
loadtexturelut:
              LOADTLUT(.CMDHigh)

            Case RDP.G_LOADBLOCK
loadtexblock:
              LOADBLOCK()

            Case RDP.G_LOADTILE
              LOADTILE()

            Case RDP.G_SETTILESIZE
settilesize:
              SETTILESIZE(.CMDLow, .CMDHigh)

            Case RDP.G_SETTILE
settile:
              If .CMDParams(1) > 0 Then SETTILE(.CMDLow, .CMDHigh)

            Case RDP.G_SETCOMBINE
setcombiner:
              SETCOMBINE(.CMDLow, .CMDHigh)

            Case F3DZEX.TEXTURE
texture:
              TEXTURE(.CMDHigh)

            Case F3DZEX.GEOMETRYMODE
geometrymode:
              GEOMETRYMODE(.CMDLow, .CMDHigh)

            Case F3DZEX.SETOTHERMODE_H
setothermodehigh:
              SETOTHERMODE_H(.CMDLow, .CMDHigh)

            Case F3DZEX.SETOTHERMODE_L
seothtermodelow:
              SETOTHERMODE_L(.CMDLow, .CMDHigh)

            Case F3DZEX.MTX
matrix:
              MTX(.CMDLow, .CMDHigh)

            Case F3DZEX.VTX
vertex:
              If DL.Commands(i + 1).CMDParams(0) <> F3DZEX.CULLDL And DL.Commands(i + 1).CMDParams(0) <> F3DZEX.MTX Then
                VTX(.CMDLow, .CMDHigh)
              End If

            Case F3DZEX.MODIFYVTX
modifyvertex:
              MODIFYVTX(VertexCache, .CMDParams)

            Case F3DZEX.TRI1
onetriangle:
              TRI1(.CMDParams)

            Case F3DZEX.TRI2
twotriangles:
              TRI2(.CMDParams)

            Case F3DZEX.ENDDL
enddisplaylist:
              Reset()
              Exit Sub
          End Select
        ElseIf ParseMode = Parse.GEOMETRY Then
          Select Case .CMDParams(0)
            Case F3DZEX.VTX

              GoTo vertex

            Case F3DZEX.GEOMETRYMODE

              GoTo geometrymode

            Case F3DZEX.MODIFYVTX

              GoTo modifyvertex

            Case F3DZEX.TRI1

              GoTo onetriangle

            Case F3DZEX.TRI2

              GoTo twotriangles

            Case F3DZEX.ENDDL

              GoTo enddisplaylist

          End Select
        End If
      End With
    Next
  End Sub

  Public Function IdentifyCommand(ByVal CommandCode As Byte) As String
    Select Case CommandCode
      Case RDP.G_RDPPIPESYNC
        Return "G_RDPPIPESYNC (unemulated)"
      Case RDP.G_RDPLOADSYNC
        Return "G_RDPLOADSYNC (unemulated)"
      Case RDP.G_SETENVCOLOR
        Return "G_SETENVCOLOR"
      Case RDP.G_SETPRIMCOLOR
        Return "G_SETPRIMCOLOR"
      Case RDP.G_SETTIMG
        Return "G_SETTIMG"
      Case RDP.G_LOADTLUT
        Return "G_LOADTLUT"
      Case RDP.G_LOADBLOCK
        Return "G_LOADBLOCK"
      Case RDP.G_SETTILESIZE
        Return "G_SETTILESIZE"
      Case RDP.G_SETTILE
        Return "G_SETTILE"
      Case RDP.G_SETCOMBINE
        Return "G_SETCOMBINE"
      Case F3DZEX.TEXTURE
        Return "F3DEX2_TEXTURE"
      Case F3DZEX.GEOMETRYMODE
        Return "F3DEX2_GEOMETRYMODE"
      Case F3DZEX.SETOTHERMODE_H
        Return "F3DEX2_SETOTHERMODE_H (partial)"
      Case F3DZEX.SETOTHERMODE_L
        Return "F3DEX2_SETOTHERMODE_L"
      Case F3DZEX.MTX
        Return "F3DEX2_MTX (unemulated)"
      Case F3DZEX.VTX
        Return "F3DEX2_VTX"
      Case F3DZEX.MODIFYVTX
        Return "F3DEX2_MODIFYVTX"
      Case F3DZEX.TRI1
        Return "F3DEX2_TRI1"
      Case F3DZEX.TRI2
        Return "F3DEX2_TRI2"
      Case F3DZEX.CULLDL
        Return "F3DEX2_CULLDL (unemulated)"
      Case F3DZEX.DL
        Return "F3DEX2_DL (unemulated)"
      Case F3DZEX.ENDDL
        Return "F3DEX2_ENDDL"
      Case Else
        Return "Unrecognized (0x" & CommandCode.ToString("X2") & ")"
    End Select
  End Function

#Region "GEOMETRY HANDLING"

  Private Sub MTX(ByVal w0 As UInt32, ByVal w1 As UInt32)
    Dim MtxSegment As Byte = (w1 >> 24)
    Dim Address As UInteger = (w1 << 8 >> 8)
    Dim Param As Byte = (w1 And &HFF) Xor F3DZEX.MTX_PUSH

    Dim TempRSPMatrix As New RSPMatrix

    With TempRSPMatrix
      ReDim .N64Mat(&H3F)
      ReDim .OGLMat(3, 3)
    End With

    Dim MatValue(1) As Short
    Dim MtxPos As UInteger

    Select Case MtxSegment
      Case CurrentBank
        For i As Integer = 0 To &H3F
          TempRSPMatrix.N64Mat(i) = ZFileBuffer(Address + i)
        Next
      Case 2
        For i As Integer = 0 To &H3F
          TempRSPMatrix.N64Mat(i) = ZSceneBuffer(Address + i)
        Next
      Case &H80
        Gl.glPopMatrix()
        Exit Sub
      Case Else
        Exit Sub
    End Select


    For i As Integer = 0 To 3
      For j As Integer = 0 To 3
        MatValue(0) = FunctionsCs.ReadUInt16(TempRSPMatrix.N64Mat, MtxPos + 0)
        MatValue(1) = FunctionsCs.ReadUInt16(TempRSPMatrix.N64Mat, MtxPos + 32)
        TempRSPMatrix.OGLMat(i, j) = ((MatValue(0) << 16) Or MatValue(1)) * 1.0F / 65536.0F
        MtxPos += 2
      Next
    Next

    Dim gch As Runtime.InteropServices.GCHandle = Runtime.InteropServices.GCHandle.Alloc(TempRSPMatrix.OGLMat,
                                                                                         Runtime.InteropServices.
                                                                                          GCHandleType.Pinned)
    Dim mtxPtr As IntPtr = gch.AddrOfPinnedObject()

    'If Param And F3DZEX.MTX_PROJECTION > 0 Then
    '    Gl.glMatrixMode(Gl.GL_PROJECTION)
    'Else
    '    Gl.glMatrixMode(Gl.GL_MODELVIEW)
    '    If Param And F3DZEX.MTX_PUSH > 0 Then
    '        Gl.glPushMatrix()
    '    End If
    'End If
    Gl.glPushMatrix()

    'If Param And F3DZEX.MTX_LOAD > 0 Then
    '    Gl.glLoadMatrixf(mtxPtr)
    'Else
    Gl.glMultMatrixf(mtxPtr)
    'End If

    gch.Free()
  End Sub

  Private Sub MODIFYVTX(ByRef VertCache As N64Vertex, ByVal CMDParams() As Byte)
    Dim Vertex As Integer = (FunctionsCs.ReadUInt16(CMDParams, 2) And &HFFF) / 2
    Dim Target As Integer = CMDParams(1)
    Select Case Target
      Case &H10
        VertCache.r(Vertex) = CMDParams(4)
        VertCache.g(Vertex) = CMDParams(5)
        VertCache.b(Vertex) = CMDParams(6)
        VertCache.a(Vertex) = CMDParams(7)
      Case &H14
        VertCache.u(Vertex) = CShort(FunctionsCs.ReadUInt16(CMDParams, 4))
        VertCache.v(Vertex) = CShort(FunctionsCs.ReadUInt16(CMDParams, 6))
    End Select
  End Sub

  Private Function GEOMETRYMODE(ByVal w0 As UInt32, ByVal w1 As UInt32)
    Dim MCLEAR As UInt32 = w0
    Dim MSET As UInt32 = w1 And &HFFFFFF

    N64GeometryMode = N64GeometryMode And MCLEAR
    N64GeometryMode = N64GeometryMode Or MSET

    If N64GeometryMode And RDP.G_CULL_BOTH Then
      Gl.glEnable(Gl.GL_CULL_FACE)
      If N64GeometryMode And RDP.G_CULL_BACK Then
        Gl.glCullFace(Gl.GL_BACK)
      Else
        Gl.glDisable(Gl.GL_CULL_FACE)
      End If
    Else
      Gl.glDisable(Gl.GL_CULL_FACE)
    End If
    If ParseMode = Parse.EVERYTHING Then
      If N64GeometryMode And RDP.G_LIGHTING Then
        EnableLighting = True
        Gl.glEnable(Gl.GL_NORMALIZE)
        Gl.glEnable(Gl.GL_LIGHTING)
      Else
        EnableLighting = False
        Gl.glDisable(Gl.GL_NORMALIZE)
        Gl.glDisable(Gl.GL_LIGHTING)
      End If
    End If
  End Function

  Private Sub SETOTHERMODE_H(ByVal w0 As UInt32, ByVal w1 As UInt32)
    Dim MDSFT As Byte = (32 - (w0 << 4 >> 4) - 1)
    Select Case MDSFT
      Case RDP.G_MDSFT_CYCLETYPE
        CycleMode = w1 >> RDP.G_MDSFT_CYCLETYPE
      Case Else
    End Select
  End Sub

  Private Function SETOTHERMODE_L(ByVal w0 As UInt32, ByVal w1 As UInt32)
    Dim AA_EN As Boolean = (w1 And &H8) > 0
    Dim Z_CMP As Boolean = (w1 And &H10) > 0
    Dim Z_UPD As Boolean = (w1 And &H20) > 0
    Dim IM_RD As Boolean = (w1 And &H40) > 0
    Dim CLR_ON_CVG As Boolean = (w1 And &H80) > 0
    Dim CVG_DST_WRAP As Boolean = (w1 And &H100) > 0
    Dim CVG_DST_FULL As Boolean = (w1 And &H200) > 0
    Dim CVG_DST_SAVE As Boolean = (w1 And &H300) > 0
    Dim ZMODE_INTER As Boolean = (w1 And &H400) > 0
    Dim ZMODE_XLU As Boolean = (w1 And &H800) > 0
    Dim ZMODE_DEC As Boolean = (w1 And &HC00) > 0
    Dim CVG_X_ALPHA As Boolean = (w1 And &H1000) > 0
    Dim ALPHA_CVG_SEL As Boolean = (w1 And &H2000) > 0
    Dim FORCE_BL As Boolean = (w1 And &H4000) > 0

    Dim MDSFT As Byte = (32 - (w0 << 4 >> 4) - 1)

    Select Case MDSFT
      Case 3 'rendermode
        If ZMODE_DEC Then
          Gl.glEnable(Gl.GL_POLYGON_OFFSET_FILL)
          Gl.glPolygonOffset(-7, -7)
        Else
          Gl.glDisable(Gl.GL_POLYGON_OFFSET_FILL)
        End If
        If CVG_X_ALPHA Or ALPHA_CVG_SEL Then
          Gl.glAlphaFunc(Gl.GL_GEQUAL, 0.2F)
          Gl.glEnable(Gl.GL_ALPHA_TEST)
          Gl.glDisable(Gl.GL_BLEND)
        ElseIf FORCE_BL Then
          ForceBlending(w0, w1)
        End If
        If Z_CMP Then
          Gl.glEnable(Gl.GL_DEPTH_TEST)
        Else
          Gl.glDisable(Gl.GL_DEPTH_TEST)
        End If
      Case Else
        MsgBox("Unhandled SETOTHERMODE_L MDSFT: 0x" & MDSFT.ToString & "?")
    End Select
  End Function

  Private Function FillVertexCache(ByVal Data() As Byte, ByRef Cache As N64Vertex, ByVal DataSource As Byte,
                                   ByVal Offset As Integer, ByVal n0 As Integer, ByVal v0 As Integer)
    Try
      Select Case DataSource
        Case CurrentBank
          Dim x As Short
          Dim y As Short
          Dim z As Short
          Dim u As Short
          Dim v As Short
          Dim r As Byte
          Dim g As Byte
          Dim b As Byte
          Dim a As Byte
          For i2 As Integer = v0 To (n0 + v0) - 1
            x = CShort(FunctionsCs.ReadUInt16(Data, Offset))
            y = CShort(FunctionsCs.ReadUInt16(Data, Offset + 2))
            z = CShort(FunctionsCs.ReadUInt16(Data, Offset + 4))
            u = CShort(FunctionsCs.ReadUInt16(Data, Offset + 8))
            v = CShort(FunctionsCs.ReadUInt16(Data, Offset + 10))
            r = Data(Offset + 12)
            g = Data(Offset + 13)
            b = Data(Offset + 14)
            a = Data(Offset + 15)
            With Cache
              'Vertex x(l)-y(w)-z(d) coordinates
              .x(i2) = x
              .y(i2) = y
              .z(i2) = z

              'Texture coordinates
              .u(i2) = u
              .v(i2) = v

              'Vertex colors
              .r(i2) = r
              .g(i2) = g
              .b(i2) = b
              .a(i2) = a
            End With
            Offset += 16
          Next
        Case Else
          MsgBox("Trying to load vertices from bank 0x" & Hex(DataSource) & "?")
      End Select
    Catch err As Exception
    End Try
  End Function

  Private Function SearchTexCache(ByVal tileDescriptor As TileDescriptor) As Texture
    Return TextureCache(tileDescriptor)
  End Function

  Private Sub VTX(ByVal w0 As UInt32, ByVal w1 As UInt32)
    Dim n0 As UInteger = (w0 And &HFFF) >> 1
    Dim v0 As UInteger = n0 - ((w0 And &HFFF000) >> 12)
    Dim VertBufferOff As UInteger = w1 << 8 >> 8
    Dim VertexSeg As UInteger = w1 >> 24

    Select Case VertexSeg
      Case CurrentBank
        FillVertexCache(ZFileBuffer, VertexCache, VertexSeg, VertBufferOff, n0, v0)

      Case 2
        FillVertexCache(ZSceneBuffer, VertexCache, VertexSeg, VertBufferOff, n0, v0)
      Case 4

      Case 5

    End Select

    If ParseMode = Parse.EVERYTHING Then
      If EnableCombiner Then
        Gl.glEnable(Gl.GL_FRAGMENT_PROGRAM_ARB)
        Gl.glProgramEnvParameter4fvARB(Gl.GL_FRAGMENT_PROGRAM_ARB, 0, EnvironmentColor)
        Gl.glProgramEnvParameter4fvARB(Gl.GL_FRAGMENT_PROGRAM_ARB, 1, PrimColor)
        Gl.glProgramEnvParameter4fvARB(Gl.GL_FRAGMENT_PROGRAM_ARB, 3, BlendColor)
        Gl.glProgramEnvParameter4fARB(Gl.GL_FRAGMENT_PROGRAM_ARB, 2, PrimColorLOD, PrimColorLOD, PrimColorLOD,
                                      PrimColorLOD)
      Else
        Gl.glDisable(Gl.GL_FRAGMENT_PROGRAM_ARB)
        Gl.glEnable(Gl.GL_LIGHTING)
        Gl.glEnable(Gl.GL_NORMALIZE)
        MultiTexture = False
        EnableLighting = True
      End If

      Gl.glEnable(Gl.GL_TEXTURE_2D)

      Gl.glActiveTextureARB(Gl.GL_TEXTURE0_ARB)
      Dim texture As Texture = SearchTexCache(TileDescriptors(0))

      If texture Is Nothing Then
        Select Case TileDescriptors(0).ImageBank
          Case CurrentBank
            LoadTex(ZFileBuffer, 0)
          Case 2
            LoadTex(ZSceneBuffer, 0)
          Case 4
            LoadTex(CommonBanks.Bank4.Banks(CommonBankUse.Bank04).Data, 0)
          Case 5
            LoadTex(CommonBanks.Bank5.Banks(CommonBankUse.Bank05).Data, 0)
          Case Else
            ' TODO: Should throw an error for unsupported banks.
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, 2)
        End Select
      Else
        texture.Bind()
      End If

      If MultiTexture Then
        Gl.glActiveTextureARB(Gl.GL_TEXTURE1_ARB)
        texture = SearchTexCache(TileDescriptors(1))

        If texture Is Nothing Then
          Select Case TileDescriptors(1).ImageBank
            Case CurrentBank
              LoadTex(ZFileBuffer, 1)
            Case 2
              LoadTex(ZSceneBuffer, 1)
            Case 4
              LoadTex(CommonBanks.Bank4.Banks(CommonBankUse.Bank04).Data, 0)
            Case 5
              LoadTex(CommonBanks.Bank5.Banks(CommonBankUse.Bank05).Data, 0)
            Case Else
              ' TODO: Should throw an error for unsupported banks.
              Gl.glBindTexture(Gl.GL_TEXTURE_2D, 2)
          End Select
        Else
          texture.Bind()
        End If
        Gl.glDisable(Gl.GL_TEXTURE_2D)
        Gl.glActiveTextureARB(Gl.GL_TEXTURE0_ARB)
      End If
    End If
  End Sub


  ''' <summary>
  '''   Loads a subset of a texture into memory. This *seems* to be specified
  '''   as a region starting at an upper-left coordinate and going on for n
  '''   "texels".
  '''
  '''   A rate param dxt can also be provided; this specifies the speed at
  '''   which a counter is increased per 64 bits read. Every time this counter
  '''   turns over to a new integer, the scanline increments.
  ''' </summary>
  Private Sub LOADBLOCK()
  End Sub

  ''' <summary>
  '''   Loads a subset of a texture into memory, specified as a region between
  '''   an upper-left coordinate and lower-right coordinate.
  ''' </summary>
  Private Sub LOADTILE()
  End Sub


  Private Sub TRI1(ByVal CMDParams() As Byte)
    Try
      Polygons(0) = CMDParams(1) >> 1
      Polygons(1) = CMDParams(2) >> 1
      Polygons(2) = CMDParams(3) >> 1

      If ParseMode = Parse.EVERYTHING Then
        Gl.glBegin(Gl.GL_TRIANGLES)
        For i As Integer = 0 To 2
          If MultiTexCoord Then
            Gl.glMultiTexCoord2f(Gl.GL_TEXTURE0_ARB, VertexCache.u(Polygons(i)) * TileDescriptors(0).TextureWRatio,
                                 VertexCache.v(Polygons(i)) * TileDescriptors(0).TextureHRatio)
            Gl.glMultiTexCoord2f(Gl.GL_TEXTURE1_ARB, VertexCache.u(Polygons(i)) * TileDescriptors(1).TextureWRatio,
                                 VertexCache.v(Polygons(i)) * TileDescriptors(1).TextureHRatio)
          Else
            Gl.glTexCoord2f(VertexCache.u(Polygons(i)) * TileDescriptors(0).TextureWRatio,
                            VertexCache.v(Polygons(i)) * TileDescriptors(0).TextureHRatio)
          End If
          If EnableLighting Then
            If (Not EnableCombiner) Then Gl.glColor4fv(PrimColor) Else Gl.glColor3f(1, 1, 1)
            Gl.glNormal3b(CByte(VertexCache.r(Polygons(i))), CByte(VertexCache.g(Polygons(i))),
                          CByte(VertexCache.b(Polygons(i))))
          Else
            Gl.glColor4ub(VertexCache.r(Polygons(i)), VertexCache.g(Polygons(i)), VertexCache.b(Polygons(i)),
                          VertexCache.a(Polygons(i)))
          End If
          Gl.glVertex3f(VertexCache.x(Polygons(i)), VertexCache.y(Polygons(i)), VertexCache.z(Polygons(i)))
        Next
        Gl.glEnd()
      Else
        Gl.glBegin(Gl.GL_TRIANGLES)
        For i As Integer = 0 To 2
          Gl.glVertex3f(VertexCache.x(Polygons(i)), VertexCache.y(Polygons(i)), VertexCache.z(Polygons(i)))
        Next
        Gl.glEnd()
      End If
    Catch ex As Exception
      MsgBox("Error TRI1 - out of bounds!" & Environment.NewLine & Environment.NewLine & ex.Message,
             MsgBoxStyle.Critical, "Error")
    End Try
  End Sub

  Private Sub TRI2(ByVal CMDParams() As Byte)
    Try
      Polygons(0) = CMDParams(1) >> 1
      Polygons(1) = CMDParams(2) >> 1
      Polygons(2) = CMDParams(3) >> 1
      Polygons(3) = CMDParams(5) >> 1
      Polygons(4) = CMDParams(6) >> 1
      Polygons(5) = CMDParams(7) >> 1

      If ParseMode = Parse.EVERYTHING Then
        Gl.glBegin(Gl.GL_TRIANGLES)
        For i As Integer = 0 To 5
          If MultiTexCoord Then
            Gl.glMultiTexCoord2f(Gl.GL_TEXTURE0_ARB, VertexCache.u(Polygons(i)) * TileDescriptors(0).TextureWRatio,
                                 VertexCache.v(Polygons(i)) * TileDescriptors(0).TextureHRatio)
            Gl.glMultiTexCoord2f(Gl.GL_TEXTURE1_ARB, VertexCache.u(Polygons(i)) * TileDescriptors(1).TextureWRatio,
                                 VertexCache.v(Polygons(i)) * TileDescriptors(1).TextureHRatio)
          Else
            Gl.glTexCoord2f(VertexCache.u(Polygons(i)) * TileDescriptors(0).TextureWRatio,
                            VertexCache.v(Polygons(i)) * TileDescriptors(0).TextureHRatio)
          End If
          If EnableLighting Then
            If (Not EnableCombiner) Then Gl.glColor4fv(PrimColor) Else Gl.glColor3f(1, 1, 1)
            Gl.glNormal3b(CByte(VertexCache.r(Polygons(i))), CByte(VertexCache.g(Polygons(i))),
                          CByte(VertexCache.b(Polygons(i))))
          Else
            Gl.glColor4ub(VertexCache.r(Polygons(i)), VertexCache.g(Polygons(i)), VertexCache.b(Polygons(i)),
                          VertexCache.a(Polygons(i)))
          End If
          Gl.glVertex3f(VertexCache.x(Polygons(i)), VertexCache.y(Polygons(i)), VertexCache.z(Polygons(i)))
        Next
        Gl.glEnd()
      Else
        Gl.glBegin(Gl.GL_TRIANGLES)
        For i As Integer = 0 To 5
          Gl.glVertex3f(VertexCache.x(Polygons(i)), VertexCache.y(Polygons(i)), VertexCache.z(Polygons(i)))
        Next
        Gl.glEnd()
      End If
    Catch ex As Exception
      MsgBox("Error TRI2 - out of bounds!" & Environment.NewLine & Environment.NewLine & ex.Message,
             MsgBoxStyle.Critical, "Error")
    End Try
  End Sub

#End Region

#Region "TEXTURE HANDLING"

  Private Sub SETTIMG(ByVal w1 As UInt32, ByVal palMode As Boolean)
    Dim address As UInt32 = w1
    Dim tmpBank As Integer = (address >> 24)
    Dim tmpOff As Integer = (address << 8 >> 8)

    If palMode Then
      TileDescriptors(0).PalOff = tmpOff
      TileDescriptors(0).PalBank = tmpBank
    Else
      TileDescriptors(CurrentTex).Offset = tmpOff
      TileDescriptors(CurrentTex).ImageBank = tmpBank
    End If
  End Sub

  Private Function SETTILE(ByVal w0 As UInt32, ByVal w1 As UInt32)
    ' TODO: Support setting palette.
    ' TODO: Support setting offset.

    Dim tileDescriptor As TileDescriptor = TileDescriptors(CurrentTex)
    With tileDescriptor
      ' TODO: Delete this.
      .JankFormat = w0 >> 16
      .ColorFormat = ColorFormatUtil.Parse(FunctionsCs.ShiftR(w0, 21, 3))
      .BitSize = BitSizeUtil.Parse(FunctionsCs.ShiftR(w0, 19, 2))
      .LineSize = FunctionsCs.ShiftR(w0, 9, 9)
      .CMT = FunctionsCs.ShiftR(w1, 18, 2)
      .CMS = FunctionsCs.ShiftR(w1, 8, 2)
      .MaskS = FunctionsCs.ShiftR(w1, 4, 4)
      .MaskT = FunctionsCs.ShiftR(w1, 14, 4)
      .TShiftS = FunctionsCs.ShiftR(w1, 0, 4)
      .TShiftT = FunctionsCs.ShiftR(w1, 10, 4)
    End With
    ' TODO: Remove this struct logic.
    TileDescriptors(CurrentTex) = tileDescriptor
  End Function

  ' TODO: Slow, should only need to run this once!
  Private Sub SETTILESIZE(ByVal w0 As UInt32, ByVal w1 As UInt32)
    Dim tileDescriptor As TileDescriptor = TileDescriptors(CurrentTex)
    With tileDescriptor
      .ULS = (w0 And &HFFF000) >> 14
      .ULT = (w0 And &HFFF) >> 2
      .LRS = (w1 And &HFFF000) >> 14
      .LRT = (w1 And &HFFF) >> 2
      .Width = ((.LRS - .ULS) + 1)
      .Height = ((.LRT - .ULT) + 1)
      .TexBytes = (.Width * .Height) * 2
      If .TexBytes >> 16 = &HFFFF Then
        .TexBytes = (.TexBytes << 16 >> 16) * 2
      End If
    End With

    ' TODO: Remove this struct logic.
    TileDescriptors(CurrentTex) = tileDescriptor

    CalculateTexSize(CurrentTex)
  End Sub

  Private Sub LOADTLUT(ByVal w1 As UInt32)
    Dim PalSize As Integer = ((w1 And &HFFF000) >> 14) * 2 + 1
    ReDim Palette16(PalSize + 2)
    Select Case TileDescriptors(0).PalBank
      Case CurrentBank
        For i2 As Integer = 0 To PalSize
          Palette16(i2) = ZFileBuffer(TileDescriptors(0).PalOff + i2)
        Next
      Case 2
        For i2 As Integer = 0 To PalSize
          Palette16(i2) = ZSceneBuffer(TileDescriptors(0).PalOff + i2)
        Next
    End Select

    ReDim TileDescriptors(0).Palette32(PalSize)
    Dim curInd As Integer = 0
    For iw As Integer = 0 To PalSize Step 2
      Dim RGBA5551 As UShort = 0
      RGBA5551 = FunctionsCs.ReadUInt16(Palette16, iw)
      With TileDescriptors(0)
        .Palette32(curInd).r = (RGBA5551 And &HF800) >> 8
        .Palette32(curInd).g = ((RGBA5551 And &H7C0) << 5) >> 8
        .Palette32(curInd).b = ((RGBA5551 And &H3E) << 18) >> 16
        If RGBA5551 And 1 Then .Palette32(curInd).a = 255 Else .Palette32(curInd).a = 0
      End With
      curInd += 1
    Next
  End Sub

  Private Sub CalculateTexSize(ByVal id As Integer)
    Dim tileDescriptor As TileDescriptor = TileDescriptors(id)
    With tileDescriptor
      Dim MaxTexel As UInteger = 0
      Dim Line_Shift As UInteger = 0
      Select Case .JankFormat
        Case 0, &H40
          MaxTexel = 4096
          Line_Shift = 4
        Case &H60, &H80
          MaxTexel = 8192
          Line_Shift = 4
        Case &H8, &H48
          MaxTexel = 2048
          Line_Shift = 3
        Case &H68, &H88
          MaxTexel = 4096
          Line_Shift = 3
        Case &H10, &H70
          MaxTexel = 2048
          Line_Shift = 2
        Case &H50, &H90
          MaxTexel = 2048
          Line_Shift = 0
        Case &H18
          MaxTexel = 1024
          Line_Shift = 2
      End Select

      Dim Line_Width As UInteger = .LineSize << Line_Shift

      Dim Tile_Width As UInteger = .LRS - .ULS + 1
      Dim Tile_Height As UInteger = .LRT - .ULT + 1

      Dim Mask_Width As UInteger = 1 << .MaskS
      Dim Mask_Height As UInteger = 1 << .MaskT

      Dim Line_Height As UInteger = 0
      If Line_Width > 0 Then Line_Height = Min(MaxTexel / Line_Width, Tile_Height)

      If .MaskS > 0 And ((Mask_Width * Mask_Height) <= MaxTexel) Then
        .Width = Mask_Width
      ElseIf ((Tile_Width * Tile_Height) <= MaxTexel) Then
        .Width = Tile_Width
      Else
        .Width = Line_Width
      End If
      If .MaskT > 0 And ((Mask_Width * Mask_Height) <= MaxTexel) Then
        .Height = Mask_Height
      ElseIf ((Tile_Width * Tile_Height) <= MaxTexel) Then
        .Height = Tile_Height
      Else
        .Height = Line_Height
      End If

      Dim Clamp_Width As UInteger = 0
      Dim Clamp_Height As UInteger = 0
      If .CMS = 1 Then
        Clamp_Width = Tile_Width
      Else
        Clamp_Width = .Width
      End If
      If .CMT = 1 Then
        Clamp_Height = Tile_Height
      Else
        Clamp_Height = .Height
      End If

      If Mask_Width > .Width Then
        .MaskS = FunctionsCs.PowOf(.Width)
        Mask_Width = 1 << .MaskS
      End If
      If Mask_Height > .Height Then
        .MaskT = FunctionsCs.PowOf(.Height)
        Mask_Height = 1 << .MaskT
      End If

      If .CMS = 2 Or .CMS = 3 Then
        .RealWidth = FunctionsCs.Pow2(Clamp_Width)
      ElseIf .CMS = 1 Then
        .RealWidth = FunctionsCs.Pow2(Mask_Width)
      Else
        .RealWidth = FunctionsCs.Pow2(.Width)
      End If

      If .CMT = 2 Or .CMT = 3 Then
        .RealHeight = FunctionsCs.Pow2(Clamp_Height)
      ElseIf .CMT = 1 Then
        .RealHeight = FunctionsCs.Pow2(Mask_Height)
      Else
        .RealHeight = FunctionsCs.Pow2(.Height)
      End If

      .ShiftS = 1.0F
      .ShiftT = 1.0F

      If (.TShiftS > 10) Then
        .ShiftS = (1 << (16 - .TShiftS))
      ElseIf (.TShiftS > 0) Then
        .ShiftS /= (1 << .TShiftS)
      End If

      If (.TShiftT > 10) Then
        .ShiftT = (1 << (16 - .TShiftT))
      ElseIf (.TShiftT > 0) Then
        .ShiftT /= (1 << .TShiftT)
      End If

      .TextureHRatio = ((.T_Scale * .ShiftT) / 32 / .RealHeight)
      .TextureWRatio = ((.S_Scale * .ShiftS) / 32 / .RealWidth)
    End With

    ' TODO: Remove this struct logic.
    TileDescriptors(id) = tileDescriptor
  End Sub

  Private Function LoadTex(ByVal Data() As Byte, ByVal ID As UInteger) As Integer
    Dim tileDescriptor As TileDescriptor = TileDescriptors(ID)
    With tileDescriptor
      Dim SourceBank As Integer = .ImageBank
      Dim Offset As UInteger = .Offset
      Dim Size As UInteger = .TexBytes

      Dim N64TexImg(Size) As Byte
      Dim OGLTexImg() As Byte = {0, &HFF, 0, 0}

      For i2 As Integer = 0 To (Size) - 1
        If Offset + i2 < Data.Length Then
          N64TexImg(i2) = Data(Offset + i2)
        Else
          Exit For
        End If
      Next

      Select Case .ColorFormat
        Case ColorFormat.RGBA
          Select Case .BitSize
            Case BitSize.S_32B
              OGLTexImg = N64TexImg
            Case BitSize.S_16B
              RGBA.RGBA16(.RealWidth,
                          .RealHeight,
                          .LineSize,
                          N64TexImg,
                          OGLTexImg)
            Case Else
              Throw New NotImplementedException()
          End Select

        Case ColorFormat.CI
          Select Case .BitSize
            Case BitSize.S_8B
              CI.CI8(.RealWidth,
                     .RealHeight,
                     .LineSize,
                     N64TexImg,
                     OGLTexImg,
                     TileDescriptors(0).Palette32)
            Case BitSize.S_4B
              CI.CI4(.RealWidth,
                     .RealHeight,
                     .LineSize,
                     N64TexImg,
                     OGLTexImg,
                     TileDescriptors(0).Palette32)
            Case Else
              Throw New NotImplementedException()
          End Select

        Case ColorFormat.IA
          Select Case .BitSize
            Case BitSize.S_16B
              IA.IA16(.RealWidth,
                      .RealHeight,
                      .LineSize,
                      N64TexImg,
                      OGLTexImg)
            Case BitSize.S_8B
              IA.IA8(.RealWidth,
                     .RealHeight,
                     .LineSize,
                     N64TexImg,
                     OGLTexImg)
            Case BitSize.S_4B
              IA.IA4(.RealWidth,
                     .RealHeight,
                     .LineSize,
                     N64TexImg,
                     OGLTexImg)
            Case Else
              Throw New NotImplementedException()
          End Select

        Case ColorFormat.I
          Select Case .BitSize
            Case BitSize.S_8B
              I.I8(.RealWidth,
                   .RealHeight,
                   .LineSize,
                   N64TexImg,
                   OGLTexImg)
            Case BitSize.S_4B
              I.I4(.RealWidth,
                   .RealHeight,
                   .LineSize,
                   N64TexImg,
                   OGLTexImg)
            Case Else
              Throw New NotImplementedException()
          End Select
        Case Else
          Throw New NotImplementedException()
      End Select

      ' Generates texture.
      Gl.glGenTextures(1, .ID)
      Gl.glBindTexture(Gl.GL_TEXTURE_2D, .ID)

      ' Puts pixels into texture.
      Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGBA, .RealWidth, .RealHeight, 0, Gl.GL_RGBA,
                      Gl.GL_UNSIGNED_BYTE, OGLTexImg)
      Glu.gluBuild2DMipmaps(Gl.GL_TEXTURE_2D, Gl.GL_RGBA, .RealWidth, .RealHeight, Gl.GL_RGBA,
                            Gl.GL_UNSIGNED_BYTE, OGLTexImg)

      ' Sets texture parameters.
      Select Case .CMS
        Case RDP.G_TX_CLAMP, 3
          Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_S, Gl.GL_CLAMP_TO_EDGE)
        Case RDP.G_TX_MIRROR
          Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_S, Gl.GL_MIRRORED_REPEAT)
        Case RDP.G_TX_WRAP
          Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_S, Gl.GL_REPEAT)
        Case Else
          Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_S, Gl.GL_REPEAT)
      End Select
      Select Case .CMT
        Case RDP.G_TX_CLAMP, 3
          Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_T, Gl.GL_CLAMP_TO_EDGE)
        Case RDP.G_TX_MIRROR
          Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_T, Gl.GL_MIRRORED_REPEAT)
        Case RDP.G_TX_WRAP
          Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_T, Gl.GL_REPEAT)
        Case Else
          Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_T, Gl.GL_REPEAT)
      End Select

      If RenderToggles.Anisotropic Then
        Gl.glTexParameterf(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAX_ANISOTROPY_EXT,
                           GLExtensions.AnisotropicSamples(GLExtensions.AnisotropicSamples.Length - 1))
      Else
        Gl.glTexParameterf(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAX_ANISOTROPY_EXT, 1.0)
      End If
      Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR_MIPMAP_LINEAR)
      Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR_MIPMAP_LINEAR)

      TextureCache.Add(tileDescriptor, OGLTexImg)
    End With
  End Function

  Private Sub TEXTURE(ByVal w1 As UInt32)
    ' TODO: Support setting max # of mipmap levels.
    ' TODO: Support enabling/disabling.

    For i As Integer = 0 To 1
      If FunctionsCs.ShiftR(w1, 16, 16) < &HFFFF Then _
        TileDescriptors(i).S_Scale = FunctionsCs.Fixed2Float(FunctionsCs.ShiftR(w1, 16, 16), 16) Else _
        TileDescriptors(i).S_Scale = 1.0F
      If FunctionsCs.ShiftR(w1, 0, 16) < &HFFFF Then _
        TileDescriptors(i).T_Scale = FunctionsCs.Fixed2Float(FunctionsCs.ShiftR(w1, 0, 16), 16) Else _
        TileDescriptors(i).T_Scale = 1.0F
    Next
  End Sub

#End Region

#Region "Color Combiner"

  Private Sub SETCOMBINE(ByVal w0 As UInt32, ByVal w1 As UInt32)
    If GLExtensions.GLFragProg Then
      Dim ShaderCachePos As Integer = -1
      EnableCombiner = True
      For i As Integer = 0 To FragShaderCache.Length - 1
        If (w0 = FragShaderCache(i).MUXS0) And (w1 = FragShaderCache(i).MUXS1) Then
          Gl.glBindProgramARB(Gl.GL_FRAGMENT_PROGRAM_ARB, FragShaderCache(i).FragShader)
          Exit Sub
        End If
      Next
      DecodeMUX(w0, w1, FragShaderCache, FragShaderCache.Length)
    Else
      EnableCombiner = False
    End If
  End Sub

  Private Sub ForceBlending(ByVal c1 As UInteger, ByVal c2 As UInteger)
    Gl.glEnable(Gl.GL_BLEND)
    Gl.glDisable(Gl.GL_ALPHA_TEST)

    Dim GLsrcFactor As Integer = Gl.GL_SRC_ALPHA
    Dim GLdstFactor As Integer = Gl.GL_ONE_MINUS_SRC_ALPHA

    Gl.glBlendFunc(GLsrcFactor, GLdstFactor)
    Gl.glAlphaFunc(Gl.GL_GREATER, 0.5F)
  End Sub

  Private Sub SETFOGCOLOR(ByVal CMDParams() As Byte)
    FogColor(0) = CMDParams(4) / 255
    FogColor(1) = CMDParams(5) / 255
    FogColor(2) = CMDParams(6) / 255
    FogColor(3) = CMDParams(7) / 255
  End Sub

  Private Sub ENVCOLOR(ByVal CMDParams() As Byte)
    EnvironmentColor(0) = CMDParams(4) / 255
    EnvironmentColor(1) = CMDParams(5) / 255
    EnvironmentColor(2) = CMDParams(6) / 255
    EnvironmentColor(3) = CMDParams(7) / 255
  End Sub

  Private Sub SETPRIMCOLOR(ByVal CMDParams() As Byte)
    PrimColorM = CMDParams(2) / 255
    PrimColorLOD = CMDParams(3) / 255
    PrimColor(0) = CMDParams(4) / 255
    PrimColor(1) = CMDParams(5) / 255
    PrimColor(2) = CMDParams(6) / 255
    PrimColor(3) = CMDParams(7) / 255
  End Sub

  Private Sub SETBLENDCOLOR(ByVal CMDParams() As Byte)
    BlendColor(0) = CMDParams(4) / 255
    BlendColor(1) = CMDParams(5) / 255
    BlendColor(2) = CMDParams(6) / 255
    BlendColor(3) = CMDParams(7) / 255
  End Sub

  Public Sub PrecompileMUXS(ByVal MUXLIST1() As UInteger, ByVal MUXLIST2() As UInteger)
    If MUXLIST1.Length = MUXLIST2.Length Then
      For i As Integer = 0 To MUXLIST1.Length - 1
        DecodeMUX(MUXLIST1(i), MUXLIST2(i), FragShaderCache, i)
      Next
    End If
    PrecompiledCombiner = True
  End Sub

  Public Function UnpackMUX(ByVal MUXS0 As UInteger, ByVal MUXS1 As UInteger, ByRef CC_Colors As UnpackedCombiner)
    CC_Colors = New UnpackedCombiner
    With CC_Colors
      ReDim .aA(1)
      ReDim .aB(1)
      ReDim .aC(1)
      ReDim .aD(1)
      ReDim .cA(1)
      ReDim .cB(1)
      ReDim .cC(1)
      ReDim .cD(1)
      .cA(0) = (MUXS0 >> 20) And &HF
      .cB(0) = (MUXS1 >> 28) And &HF
      .cC(0) = (MUXS0 >> 15) And &H1F
      .cD(0) = (MUXS1 >> 15) And &H7

      .aA(0) = (MUXS0 >> 12) And &H7
      .aB(0) = (MUXS1 >> 12) And &H7
      .aC(0) = (MUXS0 >> 9) And &H7
      .aD(0) = (MUXS1 >> 9) And &H7

      .cA(1) = (MUXS0 >> 5) And &HF
      .cB(1) = (MUXS1 >> 24) And &HF
      .cC(1) = (MUXS0 >> 0) And &H1F
      .cD(1) = (MUXS1 >> 6) And &H7

      .aA(1) = (MUXS1 >> 21) And &H7
      .aB(1) = (MUXS1 >> 3) And &H7
      .aC(1) = (MUXS1 >> 18) And &H7
      .aD(1) = (MUXS1 >> 0) And &H7
    End With
  End Function

  Public Sub DecodeMUX(ByVal MUXS0 As UInteger, ByVal MUXS1 As UInteger, ByRef Cache() As ShaderCache,
                       ByVal CacheEntry As Integer)
    UnpackMUX(MUXS0, MUXS1, CombArg)
    ReDim Preserve Cache(CacheEntry)
    Cache(CacheEntry).MUXS0 = MUXS0
    Cache(CacheEntry).MUXS1 = MUXS1
    CreateShader(2, Cache, CacheEntry)
  End Sub

  Private Sub CreateShaderGLSL(ByVal Cycles As Integer, ByVal Cache() As ShaderCache, ByVal CacheEntry As Integer)

    Dim ShaderCode() As String = {"uniform vec4 Color;", "uniform vec4 Alpha;",
                                  "void main(in float4 Color, in float4 Alpha)",
                                  "{",
                                  "gl_fragColor.rgb = ((Color.x + Color.y) * Color.z - Color.w)",
                                  "gl_fragColor.a = ((alpha.x + alpha.y) * alpha.z - alpha.w)",
                                  "}"}

    Cache(CacheEntry).FragShader = Gl.glCreateShaderObjectARB(Gl.GL_FRAGMENT_SHADER)
    Gl.glShaderSourceARB(Cache(CacheEntry).FragShader, ShaderCode.Length, ShaderCode, ShaderCode.Length)
  End Sub

  Private Sub CreateShader(ByVal Cycles As Integer, ByRef Cache() As ShaderCache, ByVal CacheEntry As Integer)
    Dim ShaderLines As String = "!!ARBfp1.0" &
                                "TEMP Texel0;" &
                                "TEMP Texel1;" &
                                "TEMP CCRegister_0;" &
                                "TEMP CCRegister_1;" &
                                "TEMP ACRegister_0;" &
                                "TEMP ACRegister_1;" &
                                "TEMP CCReg;" &
                                "TEMP ACReg;" &
                                "PARAM EnvColor = program.env[0];" &
                                "PARAM PrimColor = program.env[1];" &
                                "PARAM PrimColorL = program.env[2];" &
                                "ATTRIB Shade = fragment.color.primary;" &
                                "OUTPUT FinalColor = result.color;" &
                                "TEX Texel0, fragment.texcoord[0], texture[0], 2D;" &
                                "TEX Texel1, fragment.texcoord[1], texture[1], 2D;"
    For i As Integer = 0 To Cycles - 1
      'Final color = (ColorA [base] - ColorB) * ColorC + ColorD
      With CombArg
        Select Case .cA(i)
          Case RDP.G_CCMUX_COMBINED '0
            ShaderLines += "MOV CCRegister_0.rgb, CCReg;" & Environment.NewLine
          Case RDP.G_CCMUX_TEXEL0 '1
            ShaderLines += "MOV CCRegister_0.rgb, Texel0;" & Environment.NewLine
          Case RDP.G_CCMUX_TEXEL1 '2
            ShaderLines += "MOV CCRegister_0.rgb, Texel1;" & Environment.NewLine
          Case RDP.G_CCMUX_PRIMITIVE '3
            ShaderLines += "MOV CCRegister_0.rgb, PrimColor;" & Environment.NewLine
          Case RDP.G_CCMUX_SHADE '4
            ShaderLines += "MOV CCRegister_0.rgb, Shade;" & Environment.NewLine
          Case RDP.G_CCMUX_ENVIRONMENT '5
            ShaderLines += "MOV CCRegister_0.rgb, EnvColor;" & Environment.NewLine
          Case RDP.G_CCMUX_1 '6
            ShaderLines += "MOV CCRegister_0.rgb, {1.0,1.0,1.0,1.0};" & Environment.NewLine
          Case RDP.G_CCMUX_NOISE '7
            ShaderLines += "MOV CCRegister_0.rgb, {1.0,1.0,1.0,1.0};" & Environment.NewLine
          Case Else ' > 7
            ShaderLines += "MOV CCRegister_0.rgb, {0.0,0.0,0.0,0.0};" & Environment.NewLine
        End Select
        Select Case .cB(i)
          Case RDP.G_CCMUX_COMBINED '0
            ShaderLines += "MOV CCRegister_1.rgb, CCReg;" & Environment.NewLine
          Case RDP.G_CCMUX_TEXEL0 '1
            ShaderLines += "MOV CCRegister_1.rgb, Texel0;" & Environment.NewLine
          Case RDP.G_CCMUX_TEXEL1 '2
            ShaderLines += "MOV CCRegister_1.rgb, Texel1;" & Environment.NewLine
          Case RDP.G_CCMUX_PRIMITIVE '3
            ShaderLines += "MOV CCRegister_1.rgb, PrimColor;" & Environment.NewLine
          Case RDP.G_CCMUX_SHADE '4
            ShaderLines += "MOV CCRegister_1.rgb, Shade;" & Environment.NewLine
          Case RDP.G_CCMUX_ENVIRONMENT '5
            ShaderLines += "MOV CCRegister_1.rgb, EnvColor;" & Environment.NewLine
          Case RDP.G_CCMUX_CENTER '6
            ShaderLines += "MOV CCRegister_1.rgb, {1.0,1.0,1.0,1.0};" & Environment.NewLine
          Case RDP.G_CCMUX_K4 '7
            ShaderLines += "MOV CCRegister_1.rgb, {1.0,1.0,1.0,1.0};" & Environment.NewLine
          Case Else ' > 7
            ShaderLines += "MOV CCRegister_1.rgb, {0.0,0.0,0.0,0.0};" & Environment.NewLine
        End Select
        ShaderLines += "SUB CCRegister_0, CCRegister_0, CCRegister_1;" & Environment.NewLine
        Select Case .cC(i)
          Case RDP.G_CCMUX_COMBINED '0
            ShaderLines += "MOV CCRegister_1.rgb, CCReg;" & Environment.NewLine
          Case RDP.G_CCMUX_TEXEL0 '1
            ShaderLines += "MOV CCRegister_1.rgb, Texel0;" & Environment.NewLine
          Case RDP.G_CCMUX_TEXEL1 '2
            ShaderLines += "MOV CCRegister_1.rgb, Texel1;" & Environment.NewLine
          Case RDP.G_CCMUX_PRIMITIVE '3
            ShaderLines += "MOV CCRegister_1.rgb, PrimColor;" & Environment.NewLine
          Case RDP.G_CCMUX_SHADE '4
            ShaderLines += "MOV CCRegister_1.rgb, Shade;" & Environment.NewLine
          Case RDP.G_CCMUX_ENVIRONMENT '5
            ShaderLines += "MOV CCRegister_1.rgb, EnvColor;" & Environment.NewLine
          Case RDP.G_CCMUX_SCALE '6
            ShaderLines += "MOV CCRegister_1.rgb, {1.0,1.0,1.0,1.0};" & Environment.NewLine
          Case RDP.G_CCMUX_COMBINED_ALPHA '7
            ShaderLines += "MOV CCRegister_1.rgb, CCReg.a;" & Environment.NewLine
          Case RDP.G_CCMUX_TEXEL0_ALPHA '8
            ShaderLines += "MOV CCRegister_1.rgb, Texel0.a;" & Environment.NewLine
          Case RDP.G_CCMUX_TEXEL1_ALPHA '9
            ShaderLines += "MOV CCRegister_1.rgb, Texel1.a;" & Environment.NewLine
          Case RDP.G_CCMUX_PRIMITIVE_ALPHA '10
            ShaderLines += "MOV CCRegister_1.rgb, PrimColor.a;" & Environment.NewLine
          Case RDP.G_CCMUX_SHADE_ALPHA '11
            ShaderLines += "MOV CCRegister_1.rgb, Shade.a;" & Environment.NewLine
          Case RDP.G_CCMUX_ENV_ALPHA '12
            ShaderLines += "MOV CCRegister_1.rgb, EnvColor.a;" & Environment.NewLine
          Case RDP.G_CCMUX_PRIM_LOD_FRAC '14
            ShaderLines += "MOV CCRegister_1.rgb, PrimColorL;" & Environment.NewLine
          Case RDP.G_CCMUX_K5, RDP.G_CCMUX_SCALE ' 15, 6
            ShaderLines += "MOV CCRegister_1.rgb, {1.0,1.0,1.0,1.0};" & Environment.NewLine
          Case Else ' > 15 
            ShaderLines += "MOV CCRegister_1.rgb, {0.0,0.0,0.0,0.0};" & Environment.NewLine
        End Select
        ShaderLines += "MUL CCRegister_0, CCRegister_0, CCRegister_1;" & Environment.NewLine
        Select Case .cD(i)
          Case RDP.G_CCMUX_COMBINED '0
            ShaderLines += "MOV CCRegister_1.rgb, CCReg;" & Environment.NewLine
          Case RDP.G_CCMUX_TEXEL0 '1
            ShaderLines += "MOV CCRegister_1.rgb, Texel0;" & Environment.NewLine
          Case RDP.G_CCMUX_TEXEL1 '2
            ShaderLines += "MOV CCRegister_1.rgb, Texel1;" & Environment.NewLine
          Case RDP.G_CCMUX_PRIMITIVE '3
            ShaderLines += "MOV CCRegister_1.rgb, PrimColor;" & Environment.NewLine
          Case RDP.G_CCMUX_SHADE '4
            ShaderLines += "MOV CCRegister_1.rgb, Shade;" & Environment.NewLine
          Case RDP.G_CCMUX_ENVIRONMENT '5
            ShaderLines += "MOV CCRegister_1.rgb, EnvColor;" & Environment.NewLine
          Case RDP.G_CCMUX_1 '6
            ShaderLines += "MOV CCRegister_1.rgb, {1.0,1.0,1.0,1.0};" & Environment.NewLine
          Case Else ' > 6
            ShaderLines += "MOV CCRegister_1.rgb, {0.0,0.0,0.0,0.0};" & Environment.NewLine
        End Select
        ShaderLines += "ADD CCRegister_0, CCRegister_0, CCRegister_1;" & Environment.NewLine & Environment.NewLine

        Select Case .aA(i)
          Case RDP.G_ACMUX_COMBINED
            ShaderLines += "MOV ACRegister_0.a, ACReg;" & Environment.NewLine
          Case RDP.G_ACMUX_TEXEL0
            ShaderLines += "MOV ACRegister_0.a, Texel0.a;" & Environment.NewLine
          Case RDP.G_ACMUX_TEXEL1
            ShaderLines += "MOV ACRegister_0.a, Texel1.a;" & Environment.NewLine
          Case RDP.G_ACMUX_PRIMITIVE
            ShaderLines += "MOV ACRegister_0.a, PrimColor.a;" & Environment.NewLine
          Case RDP.G_ACMUX_SHADE
            ShaderLines += "MOV ACRegister_0.a, Shade.a;" & Environment.NewLine
          Case RDP.G_ACMUX_ENVIRONMENT
            ShaderLines += "MOV ACRegister_0.a, EnvColor.a;" & Environment.NewLine
          Case RDP.G_ACMUX_1
            ShaderLines += "MOV ACRegister_0.a, {1.0,1.0,1.0,1.0};" & Environment.NewLine
          Case Else
            ShaderLines += "MOV ACRegister_0.a, {0.0,0.0,0.0,0.0};" & Environment.NewLine
        End Select
        Select Case .aB(i)
          Case RDP.G_ACMUX_COMBINED
            ShaderLines += "MOV ACRegister_1.a, ACReg;" & Environment.NewLine
          Case RDP.G_ACMUX_TEXEL0
            ShaderLines += "MOV ACRegister_1.a, Texel0.a;" & Environment.NewLine
          Case RDP.G_ACMUX_TEXEL1
            ShaderLines += "MOV ACRegister_1.a, Texel1.a;" & Environment.NewLine
          Case RDP.G_ACMUX_PRIMITIVE
            ShaderLines += "MOV ACRegister_1.a, PrimColor.a;" & Environment.NewLine
          Case RDP.G_ACMUX_SHADE
            ShaderLines += "MOV ACRegister_1.a, Shade.a;" & Environment.NewLine
          Case RDP.G_ACMUX_ENVIRONMENT
            ShaderLines += "MOV ACRegister_1.a, EnvColor.a;" & Environment.NewLine
          Case RDP.G_ACMUX_1
            ShaderLines += "MOV ACRegister_1.a, {1.0,1.0,1.0,1.0};" & Environment.NewLine
          Case Else
            ShaderLines += "MOV ACRegister_1.a, {0.0,0.0,0.0,0.0};" & Environment.NewLine
        End Select
        ShaderLines += "SUB ACRegister_0.a, ACRegister_0.a, ACRegister_1.a;" & Environment.NewLine

        Select Case .aC(i)
          Case RDP.G_ACMUX_LOD_FRACTION
            ShaderLines += "MOV ACRegister_1.a, {1.0,1.0,1.0,1.0};" & Environment.NewLine
          Case RDP.G_ACMUX_TEXEL0
            ShaderLines += "MOV ACRegister_1.a, Texel0.a;" & Environment.NewLine
          Case RDP.G_ACMUX_TEXEL1
            ShaderLines += "MOV ACRegister_1.a, Texel1.a;" & Environment.NewLine
          Case RDP.G_ACMUX_PRIMITIVE
            ShaderLines += "MOV ACRegister_1.a, PrimColor.a;" & Environment.NewLine
          Case RDP.G_ACMUX_SHADE
            ShaderLines += "MOV ACRegister_1.a, Shade.a;" & Environment.NewLine
          Case RDP.G_ACMUX_ENVIRONMENT
            ShaderLines += "MOV ACRegister_1.a, EnvColor.a;" & Environment.NewLine
          Case RDP.G_ACMUX_PRIM_LOD_FRAC
            ShaderLines += "MOV ACRegister_1.a, PrimColorL.a;" & Environment.NewLine
          Case Else
            ShaderLines += "MOV ACRegister_1.a, {0.0,0.0,0.0,0.0};" & Environment.NewLine
        End Select
        ShaderLines += "MUL ACRegister_0.a, ACRegister_0.a, ACRegister_1.a;" & Environment.NewLine

        Select Case .aD(i)
          Case RDP.G_ACMUX_COMBINED
            ShaderLines += "MOV ACRegister_1.a, ACReg.a;" & Environment.NewLine
          Case RDP.G_ACMUX_TEXEL0
            ShaderLines += "MOV ACRegister_1.a, Texel0.a;" & Environment.NewLine
          Case RDP.G_ACMUX_TEXEL1
            ShaderLines += "MOV ACRegister_1.a, Texel1.a;" & Environment.NewLine
          Case RDP.G_ACMUX_PRIMITIVE
            ShaderLines += "MOV ACRegister_1.a, PrimColor.a;" & Environment.NewLine
          Case RDP.G_ACMUX_SHADE
            ShaderLines += "MOV ACRegister_1.a, Shade.a;" & Environment.NewLine
          Case RDP.G_ACMUX_ENVIRONMENT
            ShaderLines += "MOV ACRegister_1.a, EnvColor.a;" & Environment.NewLine
          Case RDP.G_ACMUX_1
            ShaderLines += "MOV ACRegister_1.a, {1.0,1.0,1.0,1.0};" & Environment.NewLine
          Case Else
            ShaderLines += "MOV ACRegister_1.a, {0.0,0.0,0.0,0.0};" & Environment.NewLine
        End Select
      End With
      ShaderLines += "ADD ACRegister_0, ACRegister_0, ACRegister_1;" & Environment.NewLine & Environment.NewLine

      ShaderLines += "MOV CCReg.rgb, CCRegister_0;" & Environment.NewLine
      ShaderLines += "MOV ACReg.a, ACRegister_0;" & Environment.NewLine
    Next

    ShaderLines += "MOV CCReg.a, ACReg.a;"
    ShaderLines += "MOV FinalColor, CCReg;" & Environment.NewLine
    ShaderLines += "END" & Environment.NewLine

    Gl.glGenProgramsARB(1, Cache(CacheEntry).FragShader)
    Gl.glBindProgramARB(Gl.GL_FRAGMENT_PROGRAM_ARB, Cache(CacheEntry).FragShader)
    Gl.glProgramStringARB(Gl.GL_FRAGMENT_PROGRAM_ARB, Gl.GL_PROGRAM_FORMAT_ASCII_ARB, ShaderLines.Length,
                          System.Text.Encoding.ASCII.GetBytes(ShaderLines))
  End Sub

#End Region

#Region "STATE CHANGES"

  Public Sub Initialize()
    Reset()
    KillTexCache()
  End Sub

  Public Sub KillTexCache()
    TextureCache.Clear()
  End Sub

  Public Sub Reset()

    Gl.glFinish()

    ReDim TileDescriptors(1)

    TileDescriptors(0).S_Scale = 1.0F
    TileDescriptors(0).T_Scale = 1.0F
    TileDescriptors(1).S_Scale = 1.0F
    TileDescriptors(1).T_Scale = 1.0F

    For i As Integer = 0 To 2
      PrimColor(i) = 1
      EnvironmentColor(i) = 1
    Next

    PrimColor(3) = 0.5
    EnvironmentColor(3) = 0.5


    Gl.glDisable(Gl.GL_FRAGMENT_PROGRAM_ARB)
    Gl.glDisable(Gl.GL_CULL_FACE)
    Gl.glDisable(Gl.GL_TEXTURE_2D)
    Gl.glDisable(Gl.GL_BLEND)
    Gl.glDisable(Gl.GL_ALPHA_TEST)
    Gl.glBlendFunc(Gl.GL_ONE, Gl.GL_ZERO)
    Gl.glAlphaFunc(Gl.GL_GREATER, 0.0)

    Gl.glDisable(Gl.GL_LIGHTING)
    Gl.glDisable(Gl.GL_NORMALIZE)

    EnableCombiner = False
    EnableLighting = True

    With VertexCache
      ReDim .x(63)
      ReDim .y(63)
      ReDim .z(63)
      ReDim .u(63)
      ReDim .v(63)
      ReDim .r(63)
      ReDim .g(63)
      ReDim .b(63)
      ReDim .a(63)
    End With

    If Not PrecompiledCombiner Then
      PrecompileMUXS(RDP_Defs.G_COMBINERMUX0, RDP_Defs.G_COMBINERMUX1)
    End If
  End Sub

#End Region

#End Region
End Class
