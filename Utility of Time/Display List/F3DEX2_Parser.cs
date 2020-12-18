using System;
using System.Runtime.InteropServices;

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

using Tao.OpenGl;

namespace UoT {
  public class F3DEX2_Parser {
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public enum Parse {
      GEOMETRY = 1,
      EVERYTHING = 0
    }

    public int ParseMode = -1;

    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    private int PalBank = 0;
    private int PalOff = 0;
    private byte[] Palette16;
    private bool NewTexture = false;
    private uint N64GeometryMode;
    private bool MultiTexture;
    private int CurrentTex;
    private bool MultiTexCoord = false;
    private Structs.TCache[] TextureCache = new Structs.TCache[0];
    private int TexCachePos;
    private Structs.Texture[] Textures = new Structs.Texture[2];
    private int TexCount = 0;
    private Structs.ShaderCache[] FragShaderCache = new Structs.ShaderCache[0];
    private float[] PrimColor = new float[] {1.0f, 1.0f, 1.0f, 0.5f};
    private float PrimColorLOD = 0f;
    private float PrimColorM = 0f;
    private float[] EnvironmentColor = new float[] {1.0f, 1.0f, 1.0f, 0.5f};
    private float[] BlendColor = new float[] {1.0f, 1.0f, 1.0f, 0.5f};
    private float[] FogColor = new float[] {1.0f, 1.0f, 1.0f, 0.5f};
    private Structs.UnpackedCombiner CombArg = new Structs.UnpackedCombiner();
    private bool PrecompiledCombiner = false;

    private bool EnableCombiner = false;

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    private int VertBufferOff = 0;
    private uint[] Polygons = new uint[6];
    private byte v0 = 0;
    private byte n0 = 0;
    private bool EnableLighting = true;
    private Structs.N64Vertex VertexCache;
    private int CycleMode = 0;
    private bool FullAlphaCombiner = false;
    private bool ModColorWithAlpha = false;

    public struct RSPMatrix {
      public byte[] N64Mat;
      public float[,] OGLMat;
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public void ParseDL(Structs.N64DisplayList DL) {
      for (int i = 0, loopTo = DL.Commands.Length - 1; i <= loopTo; i++) {
        {
          var withBlock = DL.Commands[i];
          if (ParseMode == (int) Parse.EVERYTHING) {
            switch (withBlock.CMDParams[0]) {
              case (byte) F3DEX2_Defs.F3DZEX.POPMTX: {
                popmatrix: ;
                break;
              }

              case (byte) RDP_Defs.RDP.G_SETENVCOLOR: {
                setenvironmentcolor: ;
                ENVCOLOR(withBlock.CMDParams);
                break;
              }

              case (byte) RDP_Defs.RDP.G_SETPRIMCOLOR: {
                setprimitivecolor: ;
                SETPRIMCOLOR(withBlock.CMDParams);
                break;
              }

              case (byte) RDP_Defs.RDP.G_SETTIMG: {
                settextureimg: ;
                bool pal = DL.Commands[i + 1].CMDParams[0] ==
                           (int) RDP_Defs.RDP.G_RDPTILESYNC;
                if (DL.Commands[i - 1].CMDParams[0] ==
                    (int) RDP_Defs.RDP.G_SETTILESIZE) {
                  CurrentTex = 1;
                  if (GlobalVars.GLExtensions.GLMultiTexture &
                      GlobalVars.GLExtensions.GLFragProg) {
                    MultiTexCoord = true;
                  } else {
                    MultiTexCoord = false;
                  }

                  MultiTexture = true;
                } else {
                  MultiTexture = false;
                  MultiTexCoord = false;
                  CurrentTex = 0;
                }

                SETTIMG(withBlock.CMDHigh, pal);
                break;
              }

              case (byte) RDP_Defs.RDP.G_LOADTLUT: {
                loadtexturelut: ;
                LOADTLUT(withBlock.CMDHigh);
                break;
              }

              case (byte) RDP_Defs.RDP.G_LOADBLOCK: {
                loadtexblock: ;
                break;
              }

              case (byte) RDP_Defs.RDP.G_SETTILESIZE: {
                settilesize: ;
                SETTILESIZE(withBlock.CMDLow, withBlock.CMDHigh);
                break;
              }

              case (byte) RDP_Defs.RDP.G_SETTILE: {
                settile: ;
                if (withBlock.CMDParams[1] > 0)
                  SETTILE(withBlock.CMDLow, withBlock.CMDHigh);
                break;
              }

              case (byte) RDP_Defs.RDP.G_SETCOMBINE: {
                setcombiner: ;
                SETCOMBINE(withBlock.CMDLow, withBlock.CMDHigh);
                break;
              }

              case (byte) F3DEX2_Defs.F3DZEX.TEXTURE: {
                texture: ;
                TEXTURE(withBlock.CMDHigh);
                break;
              }

              case (byte) F3DEX2_Defs.F3DZEX.GEOMETRYMODE: {
                GEOMETRYMODE(withBlock.CMDLow, withBlock.CMDHigh);
                break;
              }

              case (byte) F3DEX2_Defs.F3DZEX.SETOTHERMODE_H: {
                setothermodehigh: ;
                SETOTHERMODE_H(withBlock.CMDLow, withBlock.CMDHigh);
                break;
              }

              case (byte) F3DEX2_Defs.F3DZEX.SETOTHERMODE_L: {
                seothtermodelow: ;
                SETOTHERMODE_L(withBlock.CMDLow, withBlock.CMDHigh);
                break;
              }

              case (byte) F3DEX2_Defs.F3DZEX.MTX: {
                matrix: ;
                MTX(withBlock.CMDLow, withBlock.CMDHigh);
                break;
              }

              case (byte) F3DEX2_Defs.F3DZEX.VTX: {
                if (DL.Commands[i + 1].CMDParams[0] !=
                    (int) F3DEX2_Defs.F3DZEX.CULLDL &
                    DL.Commands[i + 1].CMDParams[0] !=
                    (int) F3DEX2_Defs.F3DZEX.MTX) {
                  VTX(withBlock.CMDLow, withBlock.CMDHigh);
                }

                break;
              }

              case (byte) F3DEX2_Defs.F3DZEX.MODIFYVTX: {
                MODIFYVTX(ref VertexCache, withBlock.CMDParams);
                break;
              }

              case (byte) F3DEX2_Defs.F3DZEX.TRI1: {
                TRI1(withBlock.CMDParams);
                break;
              }

              case (byte) F3DEX2_Defs.F3DZEX.TRI2: {
                TRI2(withBlock.CMDParams);
                break;
              }

              case (byte) F3DEX2_Defs.F3DZEX.ENDDL: {
                Reset();
                return;
              }
            }
          } else if (ParseMode == (int) Parse.GEOMETRY) {
            switch (withBlock.CMDParams[0]) {
              case (byte) F3DEX2_Defs.F3DZEX.VTX: {
                if (DL.Commands[i + 1].CMDParams[0] !=
                    (int) F3DEX2_Defs.F3DZEX.CULLDL &
                    DL.Commands[i + 1].CMDParams[0] !=
                    (int) F3DEX2_Defs.F3DZEX.MTX) {
                  VTX(withBlock.CMDLow, withBlock.CMDHigh);
                }
                break;
              }

              case (byte) F3DEX2_Defs.F3DZEX.GEOMETRYMODE: {
                GEOMETRYMODE(withBlock.CMDLow, withBlock.CMDHigh);
                break;
              }

              case (byte) F3DEX2_Defs.F3DZEX.MODIFYVTX: {
                MODIFYVTX(ref VertexCache, withBlock.CMDParams);
                break;
              }

              case (byte) F3DEX2_Defs.F3DZEX.TRI1: {
                TRI1(withBlock.CMDParams);
                break;
              }

              case (byte) F3DEX2_Defs.F3DZEX.TRI2: {
                TRI2(withBlock.CMDParams);
                break;
              }

              case (byte) F3DEX2_Defs.F3DZEX.ENDDL: {
                Reset();
                break;
              }
            }
          }
        }
      }
    }

    public string IdentifyCommand(byte CommandCode) {
      switch (CommandCode) {
        case (byte) RDP_Defs.RDP.G_RDPPIPESYNC: {
          return "G_RDPPIPESYNC (unemulated)";
        }

        case (byte) RDP_Defs.RDP.G_RDPLOADSYNC: {
          return "G_RDPLOADSYNC (unemulated)";
        }

        case (byte) RDP_Defs.RDP.G_SETENVCOLOR: {
          return "G_SETENVCOLOR";
        }

        case (byte) RDP_Defs.RDP.G_SETPRIMCOLOR: {
          return "G_SETPRIMCOLOR";
        }

        case (byte) RDP_Defs.RDP.G_SETTIMG: {
          return "G_SETTIMG";
        }

        case (byte) RDP_Defs.RDP.G_LOADTLUT: {
          return "G_LOADTLUT";
        }

        case (byte) RDP_Defs.RDP.G_LOADBLOCK: {
          return "G_LOADBLOCK";
        }

        case (byte) RDP_Defs.RDP.G_SETTILESIZE: {
          return "G_SETTILESIZE";
        }

        case (byte) RDP_Defs.RDP.G_SETTILE: {
          return "G_SETTILE";
        }

        case (byte) RDP_Defs.RDP.G_SETCOMBINE: {
          return "G_SETCOMBINE";
        }

        case (byte) F3DEX2_Defs.F3DZEX.TEXTURE: {
          return "F3DEX2_TEXTURE";
        }

        case (byte) F3DEX2_Defs.F3DZEX.GEOMETRYMODE: {
          return "F3DEX2_GEOMETRYMODE";
        }

        case (byte) F3DEX2_Defs.F3DZEX.SETOTHERMODE_H: {
          return "F3DEX2_SETOTHERMODE_H (partial)";
        }

        case (byte) F3DEX2_Defs.F3DZEX.SETOTHERMODE_L: {
          return "F3DEX2_SETOTHERMODE_L";
        }

        case (byte) F3DEX2_Defs.F3DZEX.MTX: {
          return "F3DEX2_MTX (unemulated)";
        }

        case (byte) F3DEX2_Defs.F3DZEX.VTX: {
          return "F3DEX2_VTX";
        }

        case (byte) F3DEX2_Defs.F3DZEX.MODIFYVTX: {
          return "F3DEX2_MODIFYVTX";
        }

        case (byte) F3DEX2_Defs.F3DZEX.TRI1: {
          return "F3DEX2_TRI1";
        }

        case (byte) F3DEX2_Defs.F3DZEX.TRI2: {
          return "F3DEX2_TRI2";
        }

        case (byte) F3DEX2_Defs.F3DZEX.CULLDL: {
          return "F3DEX2_CULLDL (unemulated)";
        }

        case (byte) F3DEX2_Defs.F3DZEX.DL: {
          return "F3DEX2_DL (unemulated)";
        }

        case (byte) F3DEX2_Defs.F3DZEX.ENDDL: {
          return "F3DEX2_ENDDL";
        }

        default: {
          return "Unrecognized (0x" + CommandCode.ToString("X2") + ")";
        }
      }
    }

    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    private void MTX(uint w0, uint w1) {
      byte MtxSegment = (byte) (w1 >> 24);
      uint Address = w1 << 8 >> 8;
      byte Param = (byte) (w1 & 0xFFL ^ (long) F3DEX2_Defs.F3DZEX.MTX_PUSH);
      var TempRSPMatrix = new RSPMatrix();
      TempRSPMatrix.N64Mat = new byte[64];
      TempRSPMatrix.OGLMat = new float[4, 4];
      var MatValue = new short[2];
      var MtxPos = default(uint);
      switch (MtxSegment) {
        case var @case when @case == GlobalVars.CurrentBank: {
          for (int i = 0; i <= 0x3F; i++)
            TempRSPMatrix.N64Mat[i] =
                GlobalVars.ZFileBuffer[(int) (Address + i)];
          break;
        }

        case 2: {
          for (int i = 0; i <= 0x3F; i++)
            TempRSPMatrix.N64Mat[i] =
                GlobalVars.ZSceneBuffer[(int) (Address + i)];
          break;
        }

        case 0x80: {
          Gl.glPopMatrix();
          return;
        }

        default: {
          return;
        }
      }

      for (int i = 0; i <= 3; i++) {
        for (int j = 0; j <= 3; j++) {
          MatValue[0] =
              (short) Functions.ReadInt16(TempRSPMatrix.N64Mat,
                                          (uint) (MtxPos + 0L));
          MatValue[1] =
              (short) Functions.ReadInt16(TempRSPMatrix.N64Mat,
                                          (uint) (MtxPos + 32L));
          TempRSPMatrix.OGLMat[i, j] =
              (MatValue[0] << 16 | MatValue[1]) * 1.0f / 65536.0f;
          MtxPos = (uint) (MtxPos + 2L);
        }
      }

      var gch = GCHandle.Alloc(TempRSPMatrix.OGLMat, GCHandleType.Pinned);
      var mtxPtr = gch.AddrOfPinnedObject();

      // If Param And F3DZEX.MTX_PROJECTION > 0 Then
      // Gl.glMatrixMode(Gl.GL_PROJECTION)
      // Else
      // Gl.glMatrixMode(Gl.GL_MODELVIEW)
      // If Param And F3DZEX.MTX_PUSH > 0 Then
      // Gl.glPushMatrix()
      // End If
      // End If
      Gl.glPushMatrix();

      // If Param And F3DZEX.MTX_LOAD > 0 Then
      // Gl.glLoadMatrixf(mtxPtr)
      // Else
      Gl.glMultMatrixf(mtxPtr);
      // End If

      gch.Free();
    }

    private void MODIFYVTX(ref Structs.N64Vertex VertCache, byte[] CMDParams) {
      int Vertex = (int) ((Functions.ReadInt16(CMDParams, 2U) & 0xFFF) / 2d);
      int Target = CMDParams[1];
      switch (Target) {
        case 0x10: {
          VertCache.r[Vertex] = CMDParams[4];
          VertCache.g[Vertex] = CMDParams[5];
          VertCache.b[Vertex] = CMDParams[6];
          VertCache.a[Vertex] = CMDParams[7];
          break;
        }

        case 0x14: {
          VertCache.u[Vertex] = (short) Functions.ReadInt16(CMDParams, 4U);
          VertCache.v[Vertex] = (short) Functions.ReadInt16(CMDParams, 6U);
          break;
        }
      }
    }

    private object GEOMETRYMODE(uint w0, uint w1) {
      uint MCLEAR = w0;
      uint MSET = (uint) (w1 & 0xFFFFFFL);
      N64GeometryMode = N64GeometryMode & MCLEAR;
      N64GeometryMode = N64GeometryMode | MSET;
      if (Conversions.ToBoolean(N64GeometryMode &
                                (long) RDP_Defs.RDP.G_CULL_BOTH)) {
        Gl.glEnable(Gl.GL_CULL_FACE);
        if (Conversions.ToBoolean(N64GeometryMode &
                                  (long) RDP_Defs.RDP.G_CULL_BACK)) {
          Gl.glCullFace(Gl.GL_BACK);
        } else {
          Gl.glDisable(Gl.GL_CULL_FACE);
        }
      } else {
        Gl.glDisable(Gl.GL_CULL_FACE);
      }

      if (ParseMode == (int) Parse.EVERYTHING) {
        if (Conversions.ToBoolean(N64GeometryMode &
                                  (long) RDP_Defs.RDP.G_LIGHTING)) {
          EnableLighting = true;
          Gl.glEnable(Gl.GL_NORMALIZE);
          Gl.glEnable(Gl.GL_LIGHTING);
        } else {
          EnableLighting = false;
          Gl.glDisable(Gl.GL_NORMALIZE);
          Gl.glDisable(Gl.GL_LIGHTING);
        }
      }

      return default;
    }

    private void SETOTHERMODE_H(uint w0, uint w1) {
      byte MDSFT = (byte) (32L - (w0 << 4 >> 4) - 1L);
      switch (MDSFT) {
        case (byte) RDP_Defs.RDP.G_MDSFT_CYCLETYPE: {
          CycleMode = (int) (w1 >> (int) RDP_Defs.RDP.G_MDSFT_CYCLETYPE);
          break;
        }

        default: {
          break;
        }
      }
    }

    private object SETOTHERMODE_L(uint w0, uint w1) {
      bool AA_EN = (w1 & 0x8L) > 0L;
      bool Z_CMP = (w1 & 0x10L) > 0L;
      bool Z_UPD = (w1 & 0x20L) > 0L;
      bool IM_RD = (w1 & 0x40L) > 0L;
      bool CLR_ON_CVG = (w1 & 0x80L) > 0L;
      bool CVG_DST_WRAP = (w1 & 0x100L) > 0L;
      bool CVG_DST_FULL = (w1 & 0x200L) > 0L;
      bool CVG_DST_SAVE = (w1 & 0x300L) > 0L;
      bool ZMODE_INTER = (w1 & 0x400L) > 0L;
      bool ZMODE_XLU = (w1 & 0x800L) > 0L;
      bool ZMODE_DEC = (w1 & 0xC00L) > 0L;
      bool CVG_X_ALPHA = (w1 & 0x1000L) > 0L;
      bool ALPHA_CVG_SEL = (w1 & 0x2000L) > 0L;
      bool FORCE_BL = (w1 & 0x4000L) > 0L;
      byte MDSFT = (byte) (32L - (w0 << 4 >> 4) - 1L);
      switch (MDSFT) {
        case 3: {
          // rendermode
          if (ZMODE_DEC) {
            Gl.glEnable(Gl.GL_POLYGON_OFFSET_FILL);
            Gl.glPolygonOffset(-7, -7);
          } else {
            Gl.glDisable(Gl.GL_POLYGON_OFFSET_FILL);
          }

          if (CVG_X_ALPHA | ALPHA_CVG_SEL) {
            Gl.glAlphaFunc(Gl.GL_GEQUAL, 0.2f);
            Gl.glEnable(Gl.GL_ALPHA_TEST);
            Gl.glDisable(Gl.GL_BLEND);
          } else if (FORCE_BL) {
            ForceBlending(w0, w1);
          }

          if (Z_CMP) {
            Gl.glEnable(Gl.GL_DEPTH_TEST);
          } else {
            Gl.glDisable(Gl.GL_DEPTH_TEST);
          }

          break;
        }

        default: {
          Interaction.MsgBox("Unhandled SETOTHERMODE_L MDSFT: 0x" +
                             MDSFT.ToString() +
                             "?");
          break;
        }
      }

      return default;
    }

    private object FillVertexCache(
        byte[] Data,
        ref Structs.N64Vertex Cache,
        byte DataSource,
        int Offset,
        int n0,
        int v0) {
      try {
        switch (DataSource) {
          case var @case when @case == GlobalVars.CurrentBank: {
            short x;
            short y;
            short z;
            short u;
            short v;
            byte r;
            byte g;
            byte b;
            byte a;
            for (int i2 = v0, loopTo = n0 + v0 - 1; i2 <= loopTo; i2++) {
              x = (short) Functions.ReadInt16(Data, (uint) Offset);
              y = (short) Functions.ReadInt16(Data, (uint) (Offset + 2));
              z = (short) Functions.ReadInt16(Data, (uint) (Offset + 4));
              u = (short) Functions.ReadInt16(Data, (uint) (Offset + 8));
              v = (short) Functions.ReadInt16(Data, (uint) (Offset + 10));
              r = Data[Offset + 12];
              g = Data[Offset + 13];
              b = Data[Offset + 14];
              a = Data[Offset + 15];
              // Vertex x(l)-y(w)-z(d) coordinates
              Cache.x[i2] = x;
              Cache.y[i2] = y;
              Cache.z[i2] = z;

              // Texture coordinates
              Cache.u[i2] = u;
              Cache.v[i2] = v;

              // Vertex colors
              Cache.r[i2] = r;
              Cache.g[i2] = g;
              Cache.b[i2] = b;
              Cache.a[i2] = a;
              Offset += 16;
            }

            break;
          }

          default: {
            Interaction.MsgBox("Trying to load vertices from bank 0x" +
                               Conversion.Hex(DataSource) +
                               "?");
            break;
          }
        }
      } catch (Exception err) {}

      return default;
    }

    private int SearchTexCache(Structs.Texture Texture) {
      for (int i = 0, loopTo = TextureCache.Length - 1; i <= loopTo; i++) {
        var cacheTexture = this.TextureCache[i]?.Texture;
        if (cacheTexture == null) {
          continue;
        }

        if (cacheTexture.Offset == Texture.Offset &&
            cacheTexture.ImageBank == Texture.ImageBank) {
          return i;
        }
      }

      return -1;
    }

    private void VTX(uint w0, uint w1) {
      uint n0 = (uint) ((w0 & 0xFFFL) >> 1);
      uint v0 = (uint) (n0 - ((w0 & 0xFFF000L) >> 12));
      uint VertBufferOff = w1 << 8 >> 8;
      uint VertexSeg = w1 >> 24;
      switch (VertexSeg) {
        case var @case when @case == GlobalVars.CurrentBank: {
          FillVertexCache(GlobalVars.ZFileBuffer,
                          ref VertexCache,
                          (byte) VertexSeg,
                          (int) VertBufferOff,
                          (int) n0,
                          (int) v0);
          break;
        }

        case 2U: {
          FillVertexCache(GlobalVars.ZSceneBuffer,
                          ref VertexCache,
                          (byte) VertexSeg,
                          (int) VertBufferOff,
                          (int) n0,
                          (int) v0);
          break;
        }

        case 4U: {
          break;
        }

        case 5U: {
          break;
        }
      }

      if (ParseMode == (int) Parse.EVERYTHING) {
        if (EnableCombiner) {
          Gl.glEnable(Gl.GL_FRAGMENT_PROGRAM_ARB);
          Gl.glProgramEnvParameter4fvARB(Gl.GL_FRAGMENT_PROGRAM_ARB,
                                         0,
                                         EnvironmentColor);
          Gl.glProgramEnvParameter4fvARB(Gl.GL_FRAGMENT_PROGRAM_ARB,
                                         1,
                                         PrimColor);
          Gl.glProgramEnvParameter4fvARB(Gl.GL_FRAGMENT_PROGRAM_ARB,
                                         3,
                                         BlendColor);
          Gl.glProgramEnvParameter4fARB(Gl.GL_FRAGMENT_PROGRAM_ARB,
                                        2,
                                        PrimColorLOD,
                                        PrimColorLOD,
                                        PrimColorLOD,
                                        PrimColorLOD);
        } else {
          Gl.glDisable(Gl.GL_FRAGMENT_PROGRAM_ARB);
          Gl.glEnable(Gl.GL_LIGHTING);
          Gl.glEnable(Gl.GL_NORMALIZE);
          MultiTexture = false;
          EnableLighting = true;
        }

        Gl.glEnable(Gl.GL_TEXTURE_2D);
        Gl.glActiveTextureARB(Gl.GL_TEXTURE0_ARB);
        TexCachePos = SearchTexCache(Textures[0]);
        if (TexCachePos == -1) {
          switch (Textures[0].ImageBank) {
            case var case1 when case1 == GlobalVars.CurrentBank: {
              LoadTex(GlobalVars.ZFileBuffer,
                      (byte) Textures[0].TexFormat,
                      Textures[0].ImageBank,
                      (uint) Textures[0].Offset,
                      Textures[0].TexBytes,
                      0U);
              break;
            }

            case 2: {
              LoadTex(GlobalVars.ZSceneBuffer,
                      (byte) Textures[0].TexFormat,
                      Textures[0].ImageBank,
                      (uint) Textures[0].Offset,
                      Textures[0].TexBytes,
                      0U);
              break;
            }

            case 4: {
              LoadTex(
                  GlobalVars.CommonBanks.Bank4
                            .Banks[GlobalVars.CommonBankUse.Bank04]
                            .Data,
                  (byte) Textures[0].TexFormat,
                  Textures[0].ImageBank,
                  (uint) Textures[0].Offset,
                  Textures[0].TexBytes,
                  0U);
              break;
            }

            case 5: {
              LoadTex(
                  GlobalVars.CommonBanks.Bank5
                            .Banks[GlobalVars.CommonBankUse.Bank05]
                            .Data,
                  (byte) Textures[0].TexFormat,
                  Textures[0].ImageBank,
                  (uint) Textures[0].Offset,
                  Textures[0].TexBytes,
                  0U);
              break;
            }

            default: {
              Gl.glBindTexture(Gl.GL_TEXTURE_2D, 2);
              break;
            }
          }
        } else {
          Gl.glBindTexture(Gl.GL_TEXTURE_2D,
                           TextureCache[TexCachePos].Texture.ID);
        }

        if (MultiTexture) {
          Gl.glActiveTextureARB(Gl.GL_TEXTURE1_ARB);
          TexCachePos = SearchTexCache(Textures[1]);
          if (TexCachePos == -1) {
            switch (Textures[1].ImageBank) {
              case var case2 when case2 == GlobalVars.CurrentBank: {
                LoadTex(GlobalVars.ZFileBuffer,
                        (byte) Textures[1].TexFormat,
                        Textures[1].ImageBank,
                        (uint) Textures[1].Offset,
                        Textures[1].TexBytes,
                        1U);
                break;
              }

              case 2: {
                LoadTex(GlobalVars.ZSceneBuffer,
                        (byte) Textures[1].TexFormat,
                        Textures[1].ImageBank,
                        (uint) Textures[1].Offset,
                        Textures[1].TexBytes,
                        1U);
                break;
              }

              case 4: {
                LoadTex(
                    GlobalVars.CommonBanks.Bank4
                              .Banks[GlobalVars.CommonBankUse.Bank04]
                              .Data,
                    (byte) Textures[0].TexFormat,
                    Textures[0].ImageBank,
                    (uint) Textures[0].Offset,
                    Textures[0].TexBytes,
                    0U);
                break;
              }

              case 5: {
                LoadTex(
                    GlobalVars.CommonBanks.Bank5
                              .Banks[GlobalVars.CommonBankUse.Bank05]
                              .Data,
                    (byte) Textures[0].TexFormat,
                    Textures[0].ImageBank,
                    (uint) Textures[0].Offset,
                    Textures[0].TexBytes,
                    0U);
                break;
              }

              default: {
                Gl.glBindTexture(Gl.GL_TEXTURE_2D, 2);
                break;
              }
            }
          } else {
            Gl.glBindTexture(Gl.GL_TEXTURE_2D,
                             TextureCache[TexCachePos].Texture.ID);
          }

          Gl.glDisable(Gl.GL_TEXTURE_2D);
          Gl.glActiveTextureARB(Gl.GL_TEXTURE0_ARB);
        }
      }
    }

    private void TRI1(byte[] CMDParams) {
      try {
        Polygons[0] = (uint) (CMDParams[1] >> 1);
        Polygons[1] = (uint) (CMDParams[2] >> 1);
        Polygons[2] = (uint) (CMDParams[3] >> 1);
        if (ParseMode == (int) Parse.EVERYTHING) {
          Gl.glBegin(Gl.GL_TRIANGLES);
          for (int i = 0; i <= 2; i++) {
            if (MultiTexCoord) {
              Gl.glMultiTexCoord2f(Gl.GL_TEXTURE0_ARB,
                                   (float) (VertexCache.u[(int) Polygons[i]] *
                                            Textures[0].TextureWRatio),
                                   (float) (VertexCache.v[(int) Polygons[i]] *
                                            Textures[0].TextureHRatio));
              Gl.glMultiTexCoord2f(Gl.GL_TEXTURE1_ARB,
                                   (float) (VertexCache.u[(int) Polygons[i]] *
                                            Textures[1].TextureWRatio),
                                   (float) (VertexCache.v[(int) Polygons[i]] *
                                            Textures[1].TextureHRatio));
            } else {
              Gl.glTexCoord2f(
                  (float) (VertexCache.u[(int) Polygons[i]] *
                           Textures[0].TextureWRatio),
                  (float) (VertexCache.v[(int) Polygons[i]] *
                           Textures[0].TextureHRatio));
            }

            if (EnableLighting) {
              if (!EnableCombiner)
                Gl.glColor4fv(PrimColor);
              else
                Gl.glColor3f(1f, 1f, 1f);
              Gl.glNormal3b(VertexCache.r[(int) Polygons[i]],
                            VertexCache.g[(int) Polygons[i]],
                            VertexCache.b[(int) Polygons[i]]);
            } else {
              Gl.glColor4ub(VertexCache.r[(int) Polygons[i]],
                            VertexCache.g[(int) Polygons[i]],
                            VertexCache.b[(int) Polygons[i]],
                            VertexCache.a[(int) Polygons[i]]);
            }

            Gl.glVertex3f(VertexCache.x[(int) Polygons[i]],
                          VertexCache.y[(int) Polygons[i]],
                          VertexCache.z[(int) Polygons[i]]);
          }

          Gl.glEnd();
        } else {
          Gl.glBegin(Gl.GL_TRIANGLES);
          for (int i = 0; i <= 2; i++)
            Gl.glVertex3f(VertexCache.x[(int) Polygons[i]],
                          VertexCache.y[(int) Polygons[i]],
                          VertexCache.z[(int) Polygons[i]]);
          Gl.glEnd();
        }
      } catch (Exception ex) {
        Interaction.MsgBox(
            "Error TRI1 - out of bounds!" +
            Environment.NewLine +
            Environment.NewLine +
            ex.Message,
            MsgBoxStyle.Critical,
            "Error");
      }
    }

    private void TRI2(byte[] CMDParams) {
      try {
        Polygons[0] = (uint) (CMDParams[1] >> 1);
        Polygons[1] = (uint) (CMDParams[2] >> 1);
        Polygons[2] = (uint) (CMDParams[3] >> 1);
        Polygons[3] = (uint) (CMDParams[5] >> 1);
        Polygons[4] = (uint) (CMDParams[6] >> 1);
        Polygons[5] = (uint) (CMDParams[7] >> 1);
        if (ParseMode == (int) Parse.EVERYTHING) {
          Gl.glBegin(Gl.GL_TRIANGLES);
          for (int i = 0; i <= 5; i++) {
            if (MultiTexCoord) {
              Gl.glMultiTexCoord2f(Gl.GL_TEXTURE0_ARB,
                                   (float) (VertexCache.u[(int) Polygons[i]] *
                                            Textures[0].TextureWRatio),
                                   (float) (VertexCache.v[(int) Polygons[i]] *
                                            Textures[0].TextureHRatio));
              Gl.glMultiTexCoord2f(Gl.GL_TEXTURE1_ARB,
                                   (float) (VertexCache.u[(int) Polygons[i]] *
                                            Textures[1].TextureWRatio),
                                   (float) (VertexCache.v[(int) Polygons[i]] *
                                            Textures[1].TextureHRatio));
            } else {
              Gl.glTexCoord2f(
                  (float) (VertexCache.u[(int) Polygons[i]] *
                           Textures[0].TextureWRatio),
                  (float) (VertexCache.v[(int) Polygons[i]] *
                           Textures[0].TextureHRatio));
            }

            if (EnableLighting) {
              if (!EnableCombiner)
                Gl.glColor4fv(PrimColor);
              else
                Gl.glColor3f(1f, 1f, 1f);
              Gl.glNormal3b(VertexCache.r[(int) Polygons[i]],
                            VertexCache.g[(int) Polygons[i]],
                            VertexCache.b[(int) Polygons[i]]);
            } else {
              Gl.glColor4ub(VertexCache.r[(int) Polygons[i]],
                            VertexCache.g[(int) Polygons[i]],
                            VertexCache.b[(int) Polygons[i]],
                            VertexCache.a[(int) Polygons[i]]);
            }

            Gl.glVertex3f(VertexCache.x[(int) Polygons[i]],
                          VertexCache.y[(int) Polygons[i]],
                          VertexCache.z[(int) Polygons[i]]);
          }

          Gl.glEnd();
        } else {
          Gl.glBegin(Gl.GL_TRIANGLES);
          for (int i = 0; i <= 5; i++)
            Gl.glVertex3f(VertexCache.x[(int) Polygons[i]],
                          VertexCache.y[(int) Polygons[i]],
                          VertexCache.z[(int) Polygons[i]]);
          Gl.glEnd();
        }
      } catch (Exception ex) {
        Interaction.MsgBox(
            "Error TRI2 - out of bounds!" +
            Environment.NewLine +
            Environment.NewLine +
            ex.Message,
            MsgBoxStyle.Critical,
            "Error");
      }
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    private void SETTIMG(uint w1, bool palMode) {
      int tmpBank = (int) (w1 >> 24);
      int tmpOff = (int) (w1 << 8 >> 8);
      if (palMode) {
        Textures[0].PalOff = tmpOff;
        Textures[0].PalBank = tmpBank;
      } else {
        Textures[CurrentTex].Offset = tmpOff;
        Textures[CurrentTex].ImageBank = tmpBank;
      }
    }

    private object SETTILE(uint w0, uint w1) {
      Textures[CurrentTex].TexFormat = (int) (w0 >> 16);
      Textures[CurrentTex].TexelSize = (int) Functions.ShiftR(w0, 19U, 2U);
      Textures[CurrentTex].LineSize = (int) Functions.ShiftR(w0, 9U, 9U);
      Textures[CurrentTex].CMT = (int) Functions.ShiftR(w1, 18U, 2U);
      Textures[CurrentTex].CMS = (int) Functions.ShiftR(w1, 8U, 2U);
      Textures[CurrentTex].MaskS = (int) Functions.ShiftR(w1, 4U, 4U);
      Textures[CurrentTex].MaskT = (int) Functions.ShiftR(w1, 14U, 4U);
      Textures[CurrentTex].TShiftS = Functions.ShiftR(w1, 0U, 4U);
      Textures[CurrentTex].TShiftT = Functions.ShiftR(w1, 10U, 4U);
      return default;
    }

    private void SETTILESIZE(uint w0, uint w1) {
      Textures[CurrentTex].ULS = (int) ((w0 & 0xFFF000L) >> 14);
      Textures[CurrentTex].ULT = (int) ((w0 & 0xFFFL) >> 2);
      Textures[CurrentTex].LRS = (int) ((w1 & 0xFFF000L) >> 14);
      Textures[CurrentTex].LRT = (int) ((w1 & 0xFFFL) >> 2);
      Textures[CurrentTex].Width =
          Textures[CurrentTex].LRS - Textures[CurrentTex].ULS + 1;
      Textures[CurrentTex].Height =
          Textures[CurrentTex].LRT - Textures[CurrentTex].ULT + 1;
      Textures[CurrentTex].TexBytes =
          (uint) (Textures[CurrentTex].Width * Textures[CurrentTex].Height * 2);
      if (Textures[CurrentTex].TexBytes >> 16 == 0xFFFFL) {
        Textures[CurrentTex].TexBytes =
            (uint) ((Textures[CurrentTex].TexBytes << 16 >> 16) * 2L);
      }

      this.Textures[CurrentTex].CalculateSize();
    }

    private void LOADTLUT(uint w1) {
      int PalSize = (int) (((w1 & 0xFFF000L) >> 14) * 2L + 1L);
      Palette16 = new byte[PalSize + 2 + 1];
      switch (Textures[0].PalBank) {
        case var @case when @case == GlobalVars.CurrentBank: {
          for (int i2 = 0, loopTo = PalSize; i2 <= loopTo; i2++)
            Palette16[i2] = GlobalVars.ZFileBuffer[Textures[0].PalOff + i2];
          break;
        }

        case 2: {
          for (int i2 = 0, loopTo1 = PalSize; i2 <= loopTo1; i2++)
            Palette16[i2] = GlobalVars.ZSceneBuffer[Textures[0].PalOff + i2];
          break;
        }
      }

      Textures[0].Palette32 = new Structs.Color4UByte[PalSize + 1];
      int curInd = 0;
      for (int iw = 0, loopTo2 = PalSize; iw <= loopTo2; iw += 2) {
        ushort RGBA5551 = 0;
        RGBA5551 = (ushort) Functions.ReadInt16(Palette16, (uint) iw);
        {
          var newTexture = new Structs.Texture();
          newTexture.Palette32[curInd] = new Structs.Color4UByte {
              r = (byte) ((RGBA5551 & 0xF800) >> 8),
              g = (byte) ((RGBA5551 & 0x7C0) << 5 >> 8),
              b = (byte) ((RGBA5551 & 0x3E) << 18 >> 16),
              a = (byte) (Conversions.ToBoolean(RGBA5551 & 1) ? 255 : 0),
          };

          Textures[0] = newTexture;
        }

        curInd += 1;
      }
    }

    private int LoadTex(
        byte[] Data,
        byte Format,
        int SourceBank,
        uint Offset,
        uint Size,
        uint ID) {
      NewTexture = false;
      
      Array.Resize(ref TextureCache, TexCount + 1);
      this.TextureCache[this.TexCount] = new Structs.TCache {
          Texture = Textures[(int)ID],
      };

      var N64TexImg = new byte[(int) (Size + 1)];
      var OGLTexImg = new byte[] {0, 0xFF, 0, 0};
      for (int i2 = 0, loopTo = (int) (Size - 1L); i2 <= loopTo; i2++) {
        if (Offset + i2 < Data.Length) {
          N64TexImg[i2] = Data[(int) (Offset + i2)];
        } else {
          break;
        }
      }

      switch (Format) {
        case 0x18: {
          // 32bpp RGBA
          OGLTexImg = N64TexImg;
          break;
        }

        case 0x0:
        case 0x8:
        case 0x10: {
          // 5R, 5G, 5B, 1A (5551) RGBA 
          GlobalVars.RGBA.RGBA16((uint) Textures[(int) ID].RealWidth,
                                 (uint) Textures[(int) ID].RealHeight,
                                 (uint) Textures[(int) ID].LineSize,
                                 N64TexImg,
                                 ref OGLTexImg);


          break;
        }

        case 0x40:
        case 0x50: {
          // CI - 5551 RGBA palette with 8bpp array of indices
          GlobalVars.CI.CI8((uint) Textures[(int) ID].RealWidth,
                            (uint) Textures[(int) ID].RealHeight,
                            (uint) Textures[(int) ID].LineSize,
                            N64TexImg,
                            ref OGLTexImg,
                            Textures[0].Palette32);


          break;
        }

        case 0x48: {
          // CI - 5551 RGBA palette with 4bpp array of indices
          GlobalVars.CI.CI4((uint) Textures[(int) ID].RealWidth,
                            (uint) Textures[(int) ID].RealHeight,
                            (uint) Textures[(int) ID].LineSize,
                            N64TexImg,
                            ref OGLTexImg,
                            Textures[0].Palette32);


          break;
        }

        case 0x70: {
          // IA - 16 bit grayscale with alpha
          GlobalVars.IA.IA16((uint) Textures[(int) ID].RealWidth,
                             (uint) Textures[(int) ID].RealHeight,
                             (uint) Textures[(int) ID].LineSize,
                             N64TexImg,
                             ref OGLTexImg);


          break;
        }

        case 0x68: {
          // IA - 8 bit grayscale with alpha
          GlobalVars.IA.IA8((uint) Textures[(int) ID].RealWidth,
                            (uint) Textures[(int) ID].RealHeight,
                            (uint) Textures[(int) ID].LineSize,
                            N64TexImg,
                            ref OGLTexImg);


          break;
        }

        case 0x60: {
          // IA - 4 bit grayscale with alpha
          GlobalVars.IA.IA4((uint) Textures[(int) ID].RealWidth,
                            (uint) Textures[(int) ID].RealHeight,
                            (uint) Textures[(int) ID].LineSize,
                            N64TexImg,
                            ref OGLTexImg);


          break;
        }

        case 0x80:
        case 0x90: {
          // I - 4 bit grayscale with alpha
          GlobalVars.I.I4((uint) Textures[(int) ID].RealWidth,
                          (uint) Textures[(int) ID].RealHeight,
                          (uint) Textures[(int) ID].LineSize,
                          N64TexImg,
                          ref OGLTexImg);


          break;
        }

        case 0x88: {
          // I - 8 bit grayscale with alpha
          GlobalVars.I.I8((uint) Textures[(int) ID].RealWidth,
                          (uint) Textures[(int) ID].RealHeight,
                          (uint) Textures[(int) ID].LineSize,
                          N64TexImg,
                          ref OGLTexImg);


          break;
        }
      }

      {
        var withBlock = TextureCache[TexCount];
        Gl.glGenTextures(1, out withBlock.Texture.ID);
        Gl.glBindTexture(Gl.GL_TEXTURE_2D, withBlock.Texture.ID);
      }

      Gl.glTexImage2D(Gl.GL_TEXTURE_2D,
                      0,
                      Gl.GL_RGBA,
                      Textures[(int) ID].RealWidth,
                      Textures[(int) ID].RealHeight,
                      0,
                      Gl.GL_RGBA,
                      Gl.GL_UNSIGNED_BYTE,
                      OGLTexImg);
      Glu.gluBuild2DMipmaps(Gl.GL_TEXTURE_2D,
                            Gl.GL_RGBA,
                            Textures[(int) ID].RealWidth,
                            Textures[(int) ID].RealHeight,
                            Gl.GL_RGBA,
                            Gl.GL_UNSIGNED_BYTE,
                            OGLTexImg);
      switch (Textures[(int) ID].CMS) {
        case (int) RDP_Defs.RDP.G_TX_CLAMP:
        case 3: {
          Gl.glTexParameteri(Gl.GL_TEXTURE_2D,
                             Gl.GL_TEXTURE_WRAP_S,
                             Gl.GL_CLAMP_TO_EDGE);
          break;
        }

        case (int) RDP_Defs.RDP.G_TX_MIRROR: {
          Gl.glTexParameteri(Gl.GL_TEXTURE_2D,
                             Gl.GL_TEXTURE_WRAP_S,
                             Gl.GL_MIRRORED_REPEAT);
          break;
        }

        case (int) RDP_Defs.RDP.G_TX_WRAP: {
          Gl.glTexParameteri(Gl.GL_TEXTURE_2D,
                             Gl.GL_TEXTURE_WRAP_S,
                             Gl.GL_REPEAT);
          break;
        }

        default: {
          Gl.glTexParameteri(Gl.GL_TEXTURE_2D,
                             Gl.GL_TEXTURE_WRAP_S,
                             Gl.GL_REPEAT);
          break;
        }
      }

      switch (Textures[(int) ID].CMT) {
        case (int) RDP_Defs.RDP.G_TX_CLAMP:
        case 3: {
          Gl.glTexParameteri(Gl.GL_TEXTURE_2D,
                             Gl.GL_TEXTURE_WRAP_T,
                             Gl.GL_CLAMP_TO_EDGE);
          break;
        }

        case (int) RDP_Defs.RDP.G_TX_MIRROR: {
          Gl.glTexParameteri(Gl.GL_TEXTURE_2D,
                             Gl.GL_TEXTURE_WRAP_T,
                             Gl.GL_MIRRORED_REPEAT);
          break;
        }

        case (int) RDP_Defs.RDP.G_TX_WRAP: {
          Gl.glTexParameteri(Gl.GL_TEXTURE_2D,
                             Gl.GL_TEXTURE_WRAP_T,
                             Gl.GL_REPEAT);
          break;
        }

        default: {
          Gl.glTexParameteri(Gl.GL_TEXTURE_2D,
                             Gl.GL_TEXTURE_WRAP_T,
                             Gl.GL_REPEAT);
          break;
        }
      }

      if (GlobalVars.RenderToggles.Anisotropic) {
        Gl.glTexParameterf(Gl.GL_TEXTURE_2D,
                           Gl.GL_TEXTURE_MAX_ANISOTROPY_EXT,
                           GlobalVars.GLExtensions.AnisotropicSamples[
                               GlobalVars
                                   .GLExtensions.AnisotropicSamples
                                   .Length -
                               1]);
      } else {
        Gl.glTexParameterf(Gl.GL_TEXTURE_2D,
                           Gl.GL_TEXTURE_MAX_ANISOTROPY_EXT,
                           1.0f);
      }

      Gl.glTexParameteri(Gl.GL_TEXTURE_2D,
                         Gl.GL_TEXTURE_MIN_FILTER,
                         Gl.GL_LINEAR_MIPMAP_LINEAR);
      Gl.glTexParameteri(Gl.GL_TEXTURE_2D,
                         Gl.GL_TEXTURE_MAG_FILTER,
                         Gl.GL_LINEAR_MIPMAP_LINEAR);
      TexCount += 1;
      return default;
    }

    private void TEXTURE(uint w1) {
      for (int i = 0; i <= 1; i++) {
        if (Functions.ShiftR(w1, 16U, 16U) < 0xFFFFL)
          Textures[i].S_Scale =
              Functions.Fixed2Float(Functions.ShiftR(w1, 16U, 16U), 16);
        else
          Textures[i].S_Scale = 1.0d;
        if (Functions.ShiftR(w1, 0U, 16U) < 0xFFFFL)
          Textures[i].T_Scale =
              Functions.Fixed2Float(Functions.ShiftR(w1, 0U, 16U), 16);
        else
          Textures[i].T_Scale = 1.0d;
      }
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    private void SETCOMBINE(uint w0, uint w1) {
      if (GlobalVars.GLExtensions.GLFragProg) {
        int ShaderCachePos = -1;
        EnableCombiner = true;
        for (int i = 0, loopTo = FragShaderCache.Length - 1; i <= loopTo; i++) {
          if (w0 == FragShaderCache[i].MUXS0 & w1 == FragShaderCache[i].MUXS1) {
            Gl.glBindProgramARB(Gl.GL_FRAGMENT_PROGRAM_ARB,
                                FragShaderCache[i].FragShader);
            return;
          }
        }

        DecodeMUX(w0, w1, ref FragShaderCache, FragShaderCache.Length);
      } else {
        EnableCombiner = false;
      }
    }

    private void ForceBlending(uint c1, uint c2) {
      Gl.glEnable(Gl.GL_BLEND);
      Gl.glDisable(Gl.GL_ALPHA_TEST);
      int GLsrcFactor = Gl.GL_SRC_ALPHA;
      int GLdstFactor = Gl.GL_ONE_MINUS_SRC_ALPHA;
      Gl.glBlendFunc(GLsrcFactor, GLdstFactor);
      Gl.glAlphaFunc(Gl.GL_GREATER, 0.5f);
    }

    private void SETFOGCOLOR(byte[] CMDParams) {
      FogColor[0] = (float) (CMDParams[4] / 255d);
      FogColor[1] = (float) (CMDParams[5] / 255d);
      FogColor[2] = (float) (CMDParams[6] / 255d);
      FogColor[3] = (float) (CMDParams[7] / 255d);
    }

    private void ENVCOLOR(byte[] CMDParams) {
      EnvironmentColor[0] = (float) (CMDParams[4] / 255d);
      EnvironmentColor[1] = (float) (CMDParams[5] / 255d);
      EnvironmentColor[2] = (float) (CMDParams[6] / 255d);
      EnvironmentColor[3] = (float) (CMDParams[7] / 255d);
    }

    private void SETPRIMCOLOR(byte[] CMDParams) {
      PrimColorM = (float) (CMDParams[2] / 255d);
      PrimColorLOD = (float) (CMDParams[3] / 255d);
      PrimColor[0] = (float) (CMDParams[4] / 255d);
      PrimColor[1] = (float) (CMDParams[5] / 255d);
      PrimColor[2] = (float) (CMDParams[6] / 255d);
      PrimColor[3] = (float) (CMDParams[7] / 255d);
    }

    private void SETBLENDCOLOR(byte[] CMDParams) {
      BlendColor[0] = (float) (CMDParams[4] / 255d);
      BlendColor[1] = (float) (CMDParams[5] / 255d);
      BlendColor[2] = (float) (CMDParams[6] / 255d);
      BlendColor[3] = (float) (CMDParams[7] / 255d);
    }

    public void PrecompileMUXS(uint[] MUXLIST1, uint[] MUXLIST2) {
      if (MUXLIST1.Length == MUXLIST2.Length) {
        for (int i = 0, loopTo = MUXLIST1.Length - 1; i <= loopTo; i++)
          DecodeMUX(MUXLIST1[i], MUXLIST2[i], ref FragShaderCache, i);
      }

      PrecompiledCombiner = true;
    }

    public object UnpackMUX(
        uint MUXS0,
        uint MUXS1,
        ref Structs.UnpackedCombiner CC_Colors) {
      CC_Colors = new Structs.UnpackedCombiner();
      CC_Colors.aA = new uint[2];
      CC_Colors.aB = new uint[2];
      CC_Colors.aC = new uint[2];
      CC_Colors.aD = new uint[2];
      CC_Colors.cA = new uint[2];
      CC_Colors.cB = new uint[2];
      CC_Colors.cC = new uint[2];
      CC_Colors.cD = new uint[2];
      CC_Colors.cA[0] = (uint) (MUXS0 >> 20 & 0xFL);
      CC_Colors.cB[0] = (uint) (MUXS1 >> 28 & 0xFL);
      CC_Colors.cC[0] = (uint) (MUXS0 >> 15 & 0x1FL);
      CC_Colors.cD[0] = (uint) (MUXS1 >> 15 & 0x7L);
      CC_Colors.aA[0] = (uint) (MUXS0 >> 12 & 0x7L);
      CC_Colors.aB[0] = (uint) (MUXS1 >> 12 & 0x7L);
      CC_Colors.aC[0] = (uint) (MUXS0 >> 9 & 0x7L);
      CC_Colors.aD[0] = (uint) (MUXS1 >> 9 & 0x7L);
      CC_Colors.cA[1] = (uint) (MUXS0 >> 5 & 0xFL);
      CC_Colors.cB[1] = (uint) (MUXS1 >> 24 & 0xFL);
      CC_Colors.cC[1] = (uint) (MUXS0 >> 0 & 0x1FL);
      CC_Colors.cD[1] = (uint) (MUXS1 >> 6 & 0x7L);
      CC_Colors.aA[1] = (uint) (MUXS1 >> 21 & 0x7L);
      CC_Colors.aB[1] = (uint) (MUXS1 >> 3 & 0x7L);
      CC_Colors.aC[1] = (uint) (MUXS1 >> 18 & 0x7L);
      CC_Colors.aD[1] = (uint) (MUXS1 >> 0 & 0x7L);
      return default;
    }

    public void DecodeMUX(
        uint MUXS0,
        uint MUXS1,
        ref Structs.ShaderCache[] Cache,
        int CacheEntry) {
      UnpackMUX(MUXS0, MUXS1, ref CombArg);

      Array.Resize(ref Cache, CacheEntry + 1);
      Cache[CacheEntry] = new Structs.ShaderCache {
          MUXS0 = MUXS0,
          MUXS1 = MUXS1,
      };

      CreateShader(2, ref Cache, CacheEntry);
    }

    private void CreateShaderGLSL(
        int Cycles,
        Structs.ShaderCache[] Cache,
        int CacheEntry) {
      var ShaderCode = new string[] {
          "uniform vec4 Color;", "uniform vec4 Alpha;",
          "void main(in float4 Color, in float4 Alpha)", "{",
          "gl_fragColor.rgb = ((Color.x + Color.y) * Color.z - Color.w)",
          "gl_fragColor.a = ((alpha.x + alpha.y) * alpha.z - alpha.w)", "}"
      };

      Cache[CacheEntry].FragShader =
          (uint) Gl.glCreateShaderObjectARB(Gl.GL_FRAGMENT_SHADER);
      int arglength = ShaderCode.Length;
      Gl.glShaderSourceARB(Cache[CacheEntry].FragShader,
                           ShaderCode.Length,
                           ShaderCode,
                           ref arglength);
      //ShaderCode.Length = arglength;
    }

    private void CreateShader(
        int Cycles,
        ref Structs.ShaderCache[] Cache,
        int CacheEntry) {
      string ShaderLines = "!!ARBfp1.0" +
                           "TEMP Texel0;" +
                           "TEMP Texel1;" +
                           "TEMP CCRegister_0;" +
                           "TEMP CCRegister_1;" +
                           "TEMP ACRegister_0;" +
                           "TEMP ACRegister_1;" +
                           "TEMP CCReg;" +
                           "TEMP ACReg;" +
                           "PARAM EnvColor = program.env[0];" +
                           "PARAM PrimColor = program.env[1];" +
                           "PARAM PrimColorL = program.env[2];" +
                           "ATTRIB Shade = fragment.color.primary;" +
                           "OUTPUT FinalColor = result.color;" +
                           "TEX Texel0, fragment.texcoord[0], texture[0], 2D;" +
                           "TEX Texel1, fragment.texcoord[1], texture[1], 2D;";

      for (int i = 0, loopTo = Cycles - 1; i <= loopTo; i++) {
        // Final color = (ColorA [base] - ColorB) * ColorC + ColorD
        {
          var withBlock = CombArg;
          switch (withBlock.cA[i]) {
            case (uint) RDP_Defs.RDP.G_CCMUX_COMBINED: {
              // 0
              ShaderLines +=
                  "MOV CCRegister_0.rgb, CCReg;" + Environment.NewLine;
              break;
            }

            case (uint) RDP_Defs.RDP.G_CCMUX_TEXEL0: {
              // 1
              ShaderLines +=
                  "MOV CCRegister_0.rgb, Texel0;" + Environment.NewLine;
              break;
            }

            case (uint) RDP_Defs.RDP.G_CCMUX_TEXEL1: {
              // 2
              ShaderLines +=
                  "MOV CCRegister_0.rgb, Texel1;" + Environment.NewLine;
              break;
            }

            case (uint) RDP_Defs.RDP.G_CCMUX_PRIMITIVE: {
              // 3
              ShaderLines += "MOV CCRegister_0.rgb, PrimColor;" +
                             Environment.NewLine;
              break;
            }

            case (uint) RDP_Defs.RDP.G_CCMUX_SHADE: {
              // 4
              ShaderLines +=
                  "MOV CCRegister_0.rgb, Shade;" + Environment.NewLine;
              break;
            }

            case (uint) RDP_Defs.RDP.G_CCMUX_ENVIRONMENT: {
              // 5
              ShaderLines += "MOV CCRegister_0.rgb, EnvColor;" +
                             Environment.NewLine;
              break;
            }

            case (uint) RDP_Defs.RDP.G_CCMUX_1: {
              // 6
              ShaderLines += "MOV CCRegister_0.rgb, {1.0,1.0,1.0,1.0};" +
                             Environment.NewLine;
              break;
            }

            case (uint) RDP_Defs.RDP.G_CCMUX_NOISE: {
              // 7
              ShaderLines += "MOV CCRegister_0.rgb, {1.0,1.0,1.0,1.0};" +
                             Environment.NewLine; // > 7
              break;
            }

            default: {
              ShaderLines += "MOV CCRegister_0.rgb, {0.0,0.0,0.0,0.0};" +
                             Environment.NewLine;
              break;
            }
          }

          switch (withBlock.cB[i]) {
            case (uint) RDP_Defs.RDP.G_CCMUX_COMBINED: {
              // 0
              ShaderLines +=
                  "MOV CCRegister_1.rgb, CCReg;" + Environment.NewLine;
              break;
            }

            case (uint) RDP_Defs.RDP.G_CCMUX_TEXEL0: {
              // 1
              ShaderLines +=
                  "MOV CCRegister_1.rgb, Texel0;" + Environment.NewLine;
              break;
            }

            case (uint) RDP_Defs.RDP.G_CCMUX_TEXEL1: {
              // 2
              ShaderLines +=
                  "MOV CCRegister_1.rgb, Texel1;" + Environment.NewLine;
              break;
            }

            case (uint) RDP_Defs.RDP.G_CCMUX_PRIMITIVE: {
              // 3
              ShaderLines += "MOV CCRegister_1.rgb, PrimColor;" +
                             Environment.NewLine;
              break;
            }

            case (uint) RDP_Defs.RDP.G_CCMUX_SHADE: {
              // 4
              ShaderLines +=
                  "MOV CCRegister_1.rgb, Shade;" + Environment.NewLine;
              break;
            }

            case (uint) RDP_Defs.RDP.G_CCMUX_ENVIRONMENT: {
              // 5
              ShaderLines += "MOV CCRegister_1.rgb, EnvColor;" +
                             Environment.NewLine;
              break;
            }

            case (uint) RDP_Defs.RDP.G_CCMUX_CENTER: {
              // 6
              ShaderLines += "MOV CCRegister_1.rgb, {1.0,1.0,1.0,1.0};" +
                             Environment.NewLine;
              break;
            }

            case (uint) RDP_Defs.RDP.G_CCMUX_K4: {
              // 7
              ShaderLines += "MOV CCRegister_1.rgb, {1.0,1.0,1.0,1.0};" +
                             Environment.NewLine; // > 7
              break;
            }

            default: {
              ShaderLines += "MOV CCRegister_1.rgb, {0.0,0.0,0.0,0.0};" +
                             Environment.NewLine;
              break;
            }
          }

          ShaderLines += "SUB CCRegister_0, CCRegister_0, CCRegister_1;" +
                         Environment.NewLine;
          switch (withBlock.cC[i]) {
            case (uint) RDP_Defs.RDP.G_CCMUX_COMBINED: {
              // 0
              ShaderLines +=
                  "MOV CCRegister_1.rgb, CCReg;" + Environment.NewLine;
              break;
            }

            case (uint) RDP_Defs.RDP.G_CCMUX_TEXEL0: {
              // 1
              ShaderLines +=
                  "MOV CCRegister_1.rgb, Texel0;" + Environment.NewLine;
              break;
            }

            case (uint) RDP_Defs.RDP.G_CCMUX_TEXEL1: {
              // 2
              ShaderLines +=
                  "MOV CCRegister_1.rgb, Texel1;" + Environment.NewLine;
              break;
            }

            case (uint) RDP_Defs.RDP.G_CCMUX_PRIMITIVE: {
              // 3
              ShaderLines += "MOV CCRegister_1.rgb, PrimColor;" +
                             Environment.NewLine;
              break;
            }

            case (uint) RDP_Defs.RDP.G_CCMUX_SHADE: {
              // 4
              ShaderLines +=
                  "MOV CCRegister_1.rgb, Shade;" + Environment.NewLine;
              break;
            }

            case (uint) RDP_Defs.RDP.G_CCMUX_ENVIRONMENT: {
              // 5
              ShaderLines += "MOV CCRegister_1.rgb, EnvColor;" +
                             Environment.NewLine;
              break;
            }

            case (uint) RDP_Defs.RDP.G_CCMUX_SCALE: {
              // 6
              ShaderLines += "MOV CCRegister_1.rgb, {1.0,1.0,1.0,1.0};" +
                             Environment.NewLine;
              break;
            }

            case (uint) RDP_Defs.RDP.G_CCMUX_COMBINED_ALPHA: {
              // 7
              ShaderLines += "MOV CCRegister_1.rgb, CCReg.a;" +
                             Environment.NewLine;
              break;
            }

            case (uint) RDP_Defs.RDP.G_CCMUX_TEXEL0_ALPHA: {
              // 8
              ShaderLines += "MOV CCRegister_1.rgb, Texel0.a;" +
                             Environment.NewLine;
              break;
            }

            case (uint) RDP_Defs.RDP.G_CCMUX_TEXEL1_ALPHA: {
              // 9
              ShaderLines += "MOV CCRegister_1.rgb, Texel1.a;" +
                             Environment.NewLine;
              break;
            }

            case (uint) RDP_Defs.RDP.G_CCMUX_PRIMITIVE_ALPHA: {
              // 10
              ShaderLines += "MOV CCRegister_1.rgb, PrimColor.a;" +
                             Environment.NewLine;
              break;
            }

            case (uint) RDP_Defs.RDP.G_CCMUX_SHADE_ALPHA: {
              // 11
              ShaderLines += "MOV CCRegister_1.rgb, Shade.a;" +
                             Environment.NewLine;
              break;
            }

            case (uint) RDP_Defs.RDP.G_CCMUX_ENV_ALPHA: {
              // 12
              ShaderLines += "MOV CCRegister_1.rgb, EnvColor.a;" +
                             Environment.NewLine;
              break;
            }

            case (uint) RDP_Defs.RDP.G_CCMUX_PRIM_LOD_FRAC: {
              // 14
              ShaderLines += "MOV CCRegister_1.rgb, PrimColorL;" +
                             Environment.NewLine;
              break;
            }

            case (uint) RDP_Defs.RDP.G_CCMUX_K5:
            case var @case when @case == (uint) RDP_Defs.RDP.G_CCMUX_SCALE: {
              // 15, 6
              ShaderLines += "MOV CCRegister_1.rgb, {1.0,1.0,1.0,1.0};" +
                             Environment.NewLine; // > 15 
              break;
            }

            default: {
              ShaderLines += "MOV CCRegister_1.rgb, {0.0,0.0,0.0,0.0};" +
                             Environment.NewLine;
              break;
            }
          }

          ShaderLines += "MUL CCRegister_0, CCRegister_0, CCRegister_1;" +
                         Environment.NewLine;
          switch (withBlock.cD[i]) {
            case (uint) RDP_Defs.RDP.G_CCMUX_COMBINED: {
              // 0
              ShaderLines +=
                  "MOV CCRegister_1.rgb, CCReg;" + Environment.NewLine;
              break;
            }

            case (uint) RDP_Defs.RDP.G_CCMUX_TEXEL0: {
              // 1
              ShaderLines +=
                  "MOV CCRegister_1.rgb, Texel0;" + Environment.NewLine;
              break;
            }

            case (uint) RDP_Defs.RDP.G_CCMUX_TEXEL1: {
              // 2
              ShaderLines +=
                  "MOV CCRegister_1.rgb, Texel1;" + Environment.NewLine;
              break;
            }

            case (uint) RDP_Defs.RDP.G_CCMUX_PRIMITIVE: {
              // 3
              ShaderLines += "MOV CCRegister_1.rgb, PrimColor;" +
                             Environment.NewLine;
              break;
            }

            case (uint) RDP_Defs.RDP.G_CCMUX_SHADE: {
              // 4
              ShaderLines +=
                  "MOV CCRegister_1.rgb, Shade;" + Environment.NewLine;
              break;
            }

            case (uint) RDP_Defs.RDP.G_CCMUX_ENVIRONMENT: {
              // 5
              ShaderLines += "MOV CCRegister_1.rgb, EnvColor;" +
                             Environment.NewLine;
              break;
            }

            case (uint) RDP_Defs.RDP.G_CCMUX_1: {
              // 6
              ShaderLines += "MOV CCRegister_1.rgb, {1.0,1.0,1.0,1.0};" +
                             Environment.NewLine; // > 6
              break;
            }

            default: {
              ShaderLines += "MOV CCRegister_1.rgb, {0.0,0.0,0.0,0.0};" +
                             Environment.NewLine;
              break;
            }
          }

          ShaderLines += "ADD CCRegister_0, CCRegister_0, CCRegister_1;" +
                         Environment.NewLine +
                         Environment.NewLine;
          switch (withBlock.aA[i]) {
            case (uint) RDP_Defs.RDP.G_ACMUX_COMBINED: {
              ShaderLines += "MOV ACRegister_0.a, ACReg;" + Environment.NewLine;
              break;
            }

            case (uint) RDP_Defs.RDP.G_ACMUX_TEXEL0: {
              ShaderLines +=
                  "MOV ACRegister_0.a, Texel0.a;" + Environment.NewLine;
              break;
            }

            case (uint) RDP_Defs.RDP.G_ACMUX_TEXEL1: {
              ShaderLines +=
                  "MOV ACRegister_0.a, Texel1.a;" + Environment.NewLine;
              break;
            }

            case (uint) RDP_Defs.RDP.G_ACMUX_PRIMITIVE: {
              ShaderLines += "MOV ACRegister_0.a, PrimColor.a;" +
                             Environment.NewLine;
              break;
            }

            case (uint) RDP_Defs.RDP.G_ACMUX_SHADE: {
              ShaderLines +=
                  "MOV ACRegister_0.a, Shade.a;" + Environment.NewLine;
              break;
            }

            case (uint) RDP_Defs.RDP.G_ACMUX_ENVIRONMENT: {
              ShaderLines += "MOV ACRegister_0.a, EnvColor.a;" +
                             Environment.NewLine;
              break;
            }

            case (uint) RDP_Defs.RDP.G_ACMUX_1: {
              ShaderLines += "MOV ACRegister_0.a, {1.0,1.0,1.0,1.0};" +
                             Environment.NewLine;
              break;
            }

            default: {
              ShaderLines += "MOV ACRegister_0.a, {0.0,0.0,0.0,0.0};" +
                             Environment.NewLine;
              break;
            }
          }

          switch (withBlock.aB[i]) {
            case (uint) RDP_Defs.RDP.G_ACMUX_COMBINED: {
              ShaderLines += "MOV ACRegister_1.a, ACReg;" + Environment.NewLine;
              break;
            }

            case (uint) RDP_Defs.RDP.G_ACMUX_TEXEL0: {
              ShaderLines +=
                  "MOV ACRegister_1.a, Texel0.a;" + Environment.NewLine;
              break;
            }

            case (uint) RDP_Defs.RDP.G_ACMUX_TEXEL1: {
              ShaderLines +=
                  "MOV ACRegister_1.a, Texel1.a;" + Environment.NewLine;
              break;
            }

            case (uint) RDP_Defs.RDP.G_ACMUX_PRIMITIVE: {
              ShaderLines += "MOV ACRegister_1.a, PrimColor.a;" +
                             Environment.NewLine;
              break;
            }

            case (uint) RDP_Defs.RDP.G_ACMUX_SHADE: {
              ShaderLines +=
                  "MOV ACRegister_1.a, Shade.a;" + Environment.NewLine;
              break;
            }

            case (uint) RDP_Defs.RDP.G_ACMUX_ENVIRONMENT: {
              ShaderLines += "MOV ACRegister_1.a, EnvColor.a;" +
                             Environment.NewLine;
              break;
            }

            case (uint) RDP_Defs.RDP.G_ACMUX_1: {
              ShaderLines += "MOV ACRegister_1.a, {1.0,1.0,1.0,1.0};" +
                             Environment.NewLine;
              break;
            }

            default: {
              ShaderLines += "MOV ACRegister_1.a, {0.0,0.0,0.0,0.0};" +
                             Environment.NewLine;
              break;
            }
          }

          ShaderLines += "SUB ACRegister_0.a, ACRegister_0.a, ACRegister_1.a;" +
                         Environment.NewLine;
          switch (withBlock.aC[i]) {
            case (uint) RDP_Defs.RDP.G_ACMUX_LOD_FRACTION: {
              ShaderLines += "MOV ACRegister_1.a, {1.0,1.0,1.0,1.0};" +
                             Environment.NewLine;
              break;
            }

            case (uint) RDP_Defs.RDP.G_ACMUX_TEXEL0: {
              ShaderLines +=
                  "MOV ACRegister_1.a, Texel0.a;" + Environment.NewLine;
              break;
            }

            case (uint) RDP_Defs.RDP.G_ACMUX_TEXEL1: {
              ShaderLines +=
                  "MOV ACRegister_1.a, Texel1.a;" + Environment.NewLine;
              break;
            }

            case (uint) RDP_Defs.RDP.G_ACMUX_PRIMITIVE: {
              ShaderLines += "MOV ACRegister_1.a, PrimColor.a;" +
                             Environment.NewLine;
              break;
            }

            case (uint) RDP_Defs.RDP.G_ACMUX_SHADE: {
              ShaderLines +=
                  "MOV ACRegister_1.a, Shade.a;" + Environment.NewLine;
              break;
            }

            case (uint) RDP_Defs.RDP.G_ACMUX_ENVIRONMENT: {
              ShaderLines += "MOV ACRegister_1.a, EnvColor.a;" +
                             Environment.NewLine;
              break;
            }

            case (uint) RDP_Defs.RDP.G_ACMUX_PRIM_LOD_FRAC: {
              ShaderLines += "MOV ACRegister_1.a, PrimColorL.a;" +
                             Environment.NewLine;
              break;
            }

            default: {
              ShaderLines += "MOV ACRegister_1.a, {0.0,0.0,0.0,0.0};" +
                             Environment.NewLine;
              break;
            }
          }

          ShaderLines += "MUL ACRegister_0.a, ACRegister_0.a, ACRegister_1.a;" +
                         Environment.NewLine;
          switch (withBlock.aD[i]) {
            case (uint) RDP_Defs.RDP.G_ACMUX_COMBINED: {
              ShaderLines +=
                  "MOV ACRegister_1.a, ACReg.a;" + Environment.NewLine;
              break;
            }

            case (uint) RDP_Defs.RDP.G_ACMUX_TEXEL0: {
              ShaderLines +=
                  "MOV ACRegister_1.a, Texel0.a;" + Environment.NewLine;
              break;
            }

            case (uint) RDP_Defs.RDP.G_ACMUX_TEXEL1: {
              ShaderLines +=
                  "MOV ACRegister_1.a, Texel1.a;" + Environment.NewLine;
              break;
            }

            case (uint) RDP_Defs.RDP.G_ACMUX_PRIMITIVE: {
              ShaderLines += "MOV ACRegister_1.a, PrimColor.a;" +
                             Environment.NewLine;
              break;
            }

            case (uint) RDP_Defs.RDP.G_ACMUX_SHADE: {
              ShaderLines +=
                  "MOV ACRegister_1.a, Shade.a;" + Environment.NewLine;
              break;
            }

            case (uint) RDP_Defs.RDP.G_ACMUX_ENVIRONMENT: {
              ShaderLines += "MOV ACRegister_1.a, EnvColor.a;" +
                             Environment.NewLine;
              break;
            }

            case (uint) RDP_Defs.RDP.G_ACMUX_1: {
              ShaderLines += "MOV ACRegister_1.a, {1.0,1.0,1.0,1.0};" +
                             Environment.NewLine;
              break;
            }

            default: {
              ShaderLines += "MOV ACRegister_1.a, {0.0,0.0,0.0,0.0};" +
                             Environment.NewLine;
              break;
            }
          }
        }

        ShaderLines += "ADD ACRegister_0, ACRegister_0, ACRegister_1;" +
                       Environment.NewLine +
                       Environment.NewLine;
        ShaderLines += "MOV CCReg.rgb, CCRegister_0;" + Environment.NewLine;
        ShaderLines += "MOV ACReg.a, ACRegister_0;" + Environment.NewLine;
      }

      ShaderLines += "MOV CCReg.a, ACReg.a;";
      ShaderLines += "MOV FinalColor, CCReg;" + Environment.NewLine;
      ShaderLines += "END" + Environment.NewLine;
      Gl.glGenProgramsARB(1, out Cache[CacheEntry].FragShader);
      Gl.glBindProgramARB(Gl.GL_FRAGMENT_PROGRAM_ARB,
                          Cache[CacheEntry].FragShader);
      Gl.glProgramStringARB(Gl.GL_FRAGMENT_PROGRAM_ARB,
                            Gl.GL_PROGRAM_FORMAT_ASCII_ARB,
                            ShaderLines.Length,
                            System.Text.Encoding.ASCII.GetBytes(ShaderLines));
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public void Initialize() {
      Reset();
      KillTexCache();
    }

    public void KillTexCache() {
      foreach (var textureCache in this.TextureCache) {
        var cachedTexture = textureCache?.Texture;
        if (cachedTexture != null) {
          Gl.glDeleteTextures(1, ref cachedTexture.ID);
        }
      }
      TextureCache = new Structs.TCache[0];
    }

    public void Reset() {
      Gl.glFinish();
      Textures = new Structs.Texture[2];
      for (var i = 0; i < 2; i++) {
        this.Textures[i] = new Structs.Texture();
      }

      Textures[0].S_Scale = 1.0d;
      Textures[0].T_Scale = 1.0d;
      Textures[1].S_Scale = 1.0d;
      Textures[1].T_Scale = 1.0d;
      for (int i = 0; i <= 2; i++) {
        PrimColor[i] = 1f;
        EnvironmentColor[i] = 1f;
      }

      PrimColor[3] = 0.5f;
      EnvironmentColor[3] = 0.5f;
      Gl.glDisable(Gl.GL_FRAGMENT_PROGRAM_ARB);
      Gl.glDisable(Gl.GL_CULL_FACE);
      Gl.glDisable(Gl.GL_TEXTURE_2D);
      Gl.glDisable(Gl.GL_BLEND);
      Gl.glDisable(Gl.GL_ALPHA_TEST);
      Gl.glBlendFunc(Gl.GL_ONE, Gl.GL_ZERO);
      Gl.glAlphaFunc(Gl.GL_GREATER, 0.0f);
      Gl.glDisable(Gl.GL_LIGHTING);
      Gl.glDisable(Gl.GL_NORMALIZE);
      EnableCombiner = false;
      EnableLighting = true;
      this.VertexCache = new Structs.N64Vertex {
          x = new short[64],
          y = new short[64],
          z = new short[64],
          u = new short[64],
          v = new short[64],
          r = new byte[64],
          g = new byte[64],
          b = new byte[64],
          a = new byte[64],
      };

      if (!PrecompiledCombiner) {
        this.PrecompileMUXS(RDP_Defs.G_COMBINERMUX0, RDP_Defs.G_COMBINERMUX1);
      }
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
  }
}