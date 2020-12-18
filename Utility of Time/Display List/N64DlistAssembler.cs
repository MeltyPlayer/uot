using System.Drawing;

namespace UoT {
  public class N64DlistAssembler {
    private RDPGlobal RDPCompiler = new RDPGlobal();
    private UCodeSpecific.F3DEX2 F3DEX2Compiler = new UCodeSpecific.F3DEX2();
    private UCodeSpecific.F3DEX F3DEXCompiler = new UCodeSpecific.F3DEX();

    public class RDPGlobal { // class handling RDP global commands (G_XXXX)
      public object TRI(Structs.UnpackedTriangle Triangles, ref Structs.DLCommand Output) {
        uint tCmdLo = 0U;
        uint tCmdHi = 0U;
        tCmdLo = (uint)(Triangles.VertA >> 16 & 0xFF | Triangles.VertB >> 8 & 0xFF | Triangles.VertC >> 0 & 0xFF);

        tCmdHi = 0U;
        if (Triangles.TRI2) {
          tCmdHi = (uint)(Triangles.VertA >> 24 & 0xFF | Triangles.VertB >> 16 & 0xFF | Triangles.VertC >> 8 & 0xFF);

        }

        Output.CMDHigh = tCmdHi;
        Output.CMDLow = tCmdLo;
        return default;
      }

      public object SETCONSTCOLOR(Color Color, ref Structs.DLCommand Output) {
        Output.CMDLow = 0U;
        Output.CMDHigh = (uint)(Color.R >> 24 & 0xFF | Color.G >> 16 & 0xFF | Color.B >> 8 & 0xFF | Color.A >> 0 & 0xFF);


        Output.CMDParams[4] = Color.R;
        Output.CMDParams[5] = Color.G;
        Output.CMDParams[6] = Color.B;
        Output.CMDParams[7] = Color.A;
        return default;
      }

      public object SETCOMBINE(Structs.UnpackedCombiner CombinerFlags, ref Structs.DLCommand Output) {
        Output.CMDLow = CombinerFlags.cA[0] << 20 | CombinerFlags.cC[0] << 15 | CombinerFlags.aA[0] << 12 | CombinerFlags.aC[0] << 9 | CombinerFlags.cA[1] << 5 | CombinerFlags.cC[1] << 0;




        Output.CMDHigh = CombinerFlags.cB[0] << 28 | CombinerFlags.cB[1] << 24 | CombinerFlags.aA[1] << 21 | CombinerFlags.aC[1] << 18 | CombinerFlags.cD[0] << 15 | CombinerFlags.aB[0] << 12 | CombinerFlags.aD[0] << 9 | CombinerFlags.cD[1] << 6 | CombinerFlags.aB[1] << 3 | CombinerFlags.aD[1] << 0;








        return default;
      }
    }

    public class UCodeSpecific { // class handling ucode specific commands (F3DEX2_XXXX)
      public class F3DEX2 { // F3DEX2
        public object GEOMETRYMODE(Structs.UnpackedGeometryMode GeoModes, ref Structs.DLCommand Output) {
          uint tCmd = 0x0U;
          if (GeoModes.ZBUFFER) {
            tCmd = (uint)(tCmd | (long)RDP_Defs.RDP.G_ZBUFFER);
          } else {
            tCmd = (uint)(tCmd | 0x0L);
          }

          if (GeoModes.CULLBACK) {
            tCmd = (uint)(tCmd | (long)RDP_Defs.RDP.G_CULL_BACK);
          }

          if (GeoModes.CULLFRONT) {
            tCmd = (uint)(tCmd | (long)RDP_Defs.RDP.G_CULL_FRONT);
          }

          if (GeoModes.FOG) {
            tCmd = (uint)(tCmd | (long)RDP_Defs.RDP.G_FOG);
          }

          if (GeoModes.LIGHTING) {
            tCmd = (uint)(tCmd | (long)RDP_Defs.RDP.G_LIGHTING);
          }

          if (GeoModes.TEXTUREGEN) {
            tCmd = (uint)(tCmd | (long)RDP_Defs.RDP.G_TEXTURE_GEN);
          }

          if (GeoModes.TEXTUREGENLINEAR) {
            tCmd = (uint)(tCmd | (long)RDP_Defs.RDP.G_TEXTURE_GEN_LINEAR);
          }

          if (GeoModes.SHADINGSMOOTH) {
            tCmd = (uint)(tCmd | (long)RDP_Defs.RDP.G_SHADING_SMOOTH);
          }

          return default;
        }

        public object VTX(Structs.UnpackedVtxLoad VtxSetup, ref Structs.DLCommand Output) {
          return default;
        }

        public object SETOTHERMODEL(Structs.UnpackedOtherModesL Modes, ref Structs.DLCommand Output) {
          return default;
        }
      }

      public class F3DEX {
      }
    }

    public Structs.DLCommand Compile(int UCode, uint CommandCode, object ParamData) {  // father function, calls required function to build commands, returns both lo/hiwords as DLCommand struct (see structs.vb)
      Structs.DLCommand CompileRet = default;
      CompileRet = default;
      Functions.InitNewCommand(ref CompileRet, (byte)CommandCode);
      switch (UCode) { // designed for expansion, no big plans to go beyond F3DEX2 (F3DZEX) currently, though
        case (int)Structs.UCodes.RDP: {
            switch (CommandCode) {
              case (uint)RDP_Defs.RDP.G_SETCOMBINE: { // set command struct with arg0 (24-bit) and arg1 (32-bit), compiled by specific functions
                  RDPCompiler.SETCOMBINE((Structs.UnpackedCombiner)ParamData, ref CompileRet);
                  break;
                }

              case (uint)RDP_Defs.RDP.G_SETENVCOLOR:
              case (uint)RDP_Defs.RDP.G_SETFOGCOLOR:
              case (uint)RDP_Defs.RDP.G_SETPRIMCOLOR: {
                  RDPCompiler.SETCONSTCOLOR((Color)ParamData, ref CompileRet);
                  break;
                }
            }

            break;
          }

        case (int)Structs.UCodes.F3DEX2: {
            switch (CommandCode) {
              case (uint)F3DEX2_Defs.F3DZEX.DL: {
                  break;
                }

              case (uint)F3DEX2_Defs.F3DZEX.GEOMETRYMODE: {
                  F3DEX2Compiler.GEOMETRYMODE((Structs.UnpackedGeometryMode)ParamData, ref CompileRet);
                  break;
                }

              case (uint)F3DEX2_Defs.F3DZEX.TRI1: {
                  break;
                }

              case (uint)F3DEX2_Defs.F3DZEX.TRI2: {
                  break;
                }

              case (uint)F3DEX2_Defs.F3DZEX.TEXTURE: {
                  break;
                }

              case (uint)F3DEX2_Defs.F3DZEX.SETOTHERMODE_L: {
                  break;
                }

              case (uint)F3DEX2_Defs.F3DZEX.SETOTHERMODE_H: {
                  break;
                }

              case (uint)F3DEX2_Defs.F3DZEX.ENDDL: {
                  break;
                }
            }

            break;
          }

        case (int)Structs.UCodes.F3DEX: {
            switch (CommandCode) {
              case (uint)F3DEX_Defs.F3DEX.TRI2: {
                  break;
                }
            }

            break;
          }
      }

      return CompileRet;
    }
  }
}