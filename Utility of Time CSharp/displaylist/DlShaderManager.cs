using System;

using Tao.OpenGl;

namespace UoT {
  /// <summary>
  ///   Helper class for managing shader-specific fields and passing them into
  ///   OpenGL.
  /// </summary>
  public class DlShaderManager {
    private ShaderCache[] FragShaderCache = new ShaderCache[0];
    public float[] PrimColor = new float[4];
    public float PrimColorLOD = 0f;
    public float PrimColorM = 0f;
    public float[] EnvironmentColor = new float[4];
    public float[] BlendColor = new float[4];
    public float[] FogColor = new float[4];
    private UnpackedCombiner CombArg = new UnpackedCombiner();
    private bool PrecompiledCombiner = false;

    public bool MultiTexture = false;
    public bool EnableCombiner = false;
    public bool EnableLighting = false;

    private void ResetColor_(float[] color)
      => this.SetColor_(color, 1, 1, 1, .5f);

    public void SetCombine(uint w0, uint w1) {
      if (GLExtensions.GLFragProg) {
        var ShaderCachePos = -1;
        this.EnableCombiner = true;

        foreach (var cachedFragShader in this.FragShaderCache) {
          if (w0 == cachedFragShader.MUXS0 && w1 == cachedFragShader.MUXS1) {
            Gl.glBindProgramARB(Gl.GL_FRAGMENT_PROGRAM_ARB,
                                cachedFragShader.FragShader);
            return;
          }
        }

        this.DecodeMUX_(w0,
                        w1,
                        ref this.FragShaderCache,
                        this.FragShaderCache.Length);
      } else {
        this.EnableCombiner = false;
      }
    }

    private void SetColor_(float[] color, float r, float g, float b, float a) {
      color[0] = r;
      color[1] = g;
      color[2] = b;
      color[3] = a;
    }

    public void SetPrimaryColor(
        float primColorM,
        float primColorLOD,
        float r,
        float g,
        float b,
        float a) {
      this.PrimColorM = primColorM;
      this.PrimColorLOD = primColorLOD;
      this.SetColor_(this.PrimColor, r, g, b, a);
    }

    public void SetEnvironmentColor(
        float r,
        float g,
        float b,
        float a)
      => this.SetColor_(this.EnvironmentColor, r, g, b, a);

    public void SetBlendColor(
        float r,
        float g,
        float b,
        float a)
      => this.SetColor_(this.BlendColor, r, g, b, a);

    public void SetFogColor(
        float r,
        float g,
        float b,
        float a)
      => this.SetColor_(this.FogColor, r, g, b, a);

    public void Reset() {
      this.ResetColor_(this.PrimColor);
      this.ResetColor_(this.EnvironmentColor);
      this.ResetColor_(this.BlendColor);
      this.ResetColor_(this.FogColor);

      Gl.glDisable(Gl.GL_FRAGMENT_PROGRAM_ARB);
      Gl.glDisable(Gl.GL_CULL_FACE);
      Gl.glDisable(Gl.GL_TEXTURE_2D);
      Gl.glDisable(Gl.GL_BLEND);
      Gl.glDisable(Gl.GL_ALPHA_TEST);
      Gl.glBlendFunc(Gl.GL_ONE, Gl.GL_ZERO);
      Gl.glAlphaFunc(Gl.GL_GREATER, 0f);

      Gl.glDisable(Gl.GL_LIGHTING);
      Gl.glDisable(Gl.GL_NORMALIZE);

      this.EnableCombiner = false;
      this.EnableLighting = true;

      if (!this.PrecompiledCombiner) {
        this.PrecompileMUXS_(RDP_Defs.G_COMBINERMUX0, RDP_Defs.G_COMBINERMUX1);
      }
    }

    public void PrecompileMUXS_(uint[] MUXLIST1, uint[] MUXLIST2) {
      if (MUXLIST1.Length == MUXLIST2.Length) {
        for (int i = 0, loopTo = MUXLIST1.Length - 1; i <= loopTo; i++) {
          this.DecodeMUX_(MUXLIST1[i],
                          MUXLIST2[i],
                          ref this.FragShaderCache,
                          i);
        }
      }

      this.PrecompiledCombiner = true;
    }

    private void DecodeMUX_(
        uint MUXS0,
        uint MUXS1,
        ref ShaderCache[] Cache,
        int CacheEntry) {
      this.UnpackMUX(MUXS0, MUXS1, ref this.CombArg);
      Array.Resize(ref Cache, CacheEntry + 1);
      Cache[CacheEntry].MUXS0 = MUXS0;
      Cache[CacheEntry].MUXS1 = MUXS1;
      this.CreateShader_(2, ref Cache, CacheEntry);
    }

    public object UnpackMUX(
        uint MUXS0,
        uint MUXS1,
        ref UnpackedCombiner CC_Colors) {
      CC_Colors = new UnpackedCombiner();
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

    private void CreateShaderGLSL_(
        int Cycles,
        ShaderCache[] Cache,
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

      Array.Resize(ref ShaderCode, arglength);
    }

    private void CreateShader_(
        int Cycles,
        ref ShaderCache[] Cache,
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
          var withBlock = this.CombArg;
          switch (withBlock.cA[i]) {
            case (uint) RDP.G_CCMUX_COMBINED: {
              // 0
              ShaderLines +=
                  "MOV CCRegister_0.rgb, CCReg;" + Environment.NewLine;
              break;
            }

            case (uint) RDP.G_CCMUX_TEXEL0: {
              // 1
              ShaderLines +=
                  "MOV CCRegister_0.rgb, Texel0;" + Environment.NewLine;
              break;
            }

            case (uint) RDP.G_CCMUX_TEXEL1: {
              // 2
              ShaderLines +=
                  "MOV CCRegister_0.rgb, Texel1;" + Environment.NewLine;
              break;
            }

            case (uint) RDP.G_CCMUX_PRIMITIVE: {
              // 3
              ShaderLines += "MOV CCRegister_0.rgb, PrimColor;" +
                             Environment.NewLine;
              break;
            }

            case (uint) RDP.G_CCMUX_SHADE: {
              // 4
              ShaderLines +=
                  "MOV CCRegister_0.rgb, Shade;" + Environment.NewLine;
              break;
            }

            case (uint) RDP.G_CCMUX_ENVIRONMENT: {
              // 5
              ShaderLines += "MOV CCRegister_0.rgb, EnvColor;" +
                             Environment.NewLine;
              break;
            }

            case (uint) RDP.G_CCMUX_1: {
              // 6
              ShaderLines += "MOV CCRegister_0.rgb, {1.0,1.0,1.0,1.0};" +
                             Environment.NewLine;
              break;
            }

            case (uint) RDP.G_CCMUX_NOISE: {
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
            case (uint) RDP.G_CCMUX_COMBINED: {
              // 0
              ShaderLines +=
                  "MOV CCRegister_1.rgb, CCReg;" + Environment.NewLine;
              break;
            }

            case (uint) RDP.G_CCMUX_TEXEL0: {
              // 1
              ShaderLines +=
                  "MOV CCRegister_1.rgb, Texel0;" + Environment.NewLine;
              break;
            }

            case (uint) RDP.G_CCMUX_TEXEL1: {
              // 2
              ShaderLines +=
                  "MOV CCRegister_1.rgb, Texel1;" + Environment.NewLine;
              break;
            }

            case (uint) RDP.G_CCMUX_PRIMITIVE: {
              // 3
              ShaderLines += "MOV CCRegister_1.rgb, PrimColor;" +
                             Environment.NewLine;
              break;
            }

            case (uint) RDP.G_CCMUX_SHADE: {
              // 4
              ShaderLines +=
                  "MOV CCRegister_1.rgb, Shade;" + Environment.NewLine;
              break;
            }

            case (uint) RDP.G_CCMUX_ENVIRONMENT: {
              // 5
              ShaderLines += "MOV CCRegister_1.rgb, EnvColor;" +
                             Environment.NewLine;
              break;
            }

            case (uint) RDP.G_CCMUX_CENTER: {
              // 6
              ShaderLines += "MOV CCRegister_1.rgb, {1.0,1.0,1.0,1.0};" +
                             Environment.NewLine;
              break;
            }

            case (uint) RDP.G_CCMUX_K4: {
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
            case (uint) RDP.G_CCMUX_COMBINED: {
              // 0
              ShaderLines +=
                  "MOV CCRegister_1.rgb, CCReg;" + Environment.NewLine;
              break;
            }

            case (uint) RDP.G_CCMUX_TEXEL0: {
              // 1
              ShaderLines +=
                  "MOV CCRegister_1.rgb, Texel0;" + Environment.NewLine;
              break;
            }

            case (uint) RDP.G_CCMUX_TEXEL1: {
              // 2
              ShaderLines +=
                  "MOV CCRegister_1.rgb, Texel1;" + Environment.NewLine;
              break;
            }

            case (uint) RDP.G_CCMUX_PRIMITIVE: {
              // 3
              ShaderLines += "MOV CCRegister_1.rgb, PrimColor;" +
                             Environment.NewLine;
              break;
            }

            case (uint) RDP.G_CCMUX_SHADE: {
              // 4
              ShaderLines +=
                  "MOV CCRegister_1.rgb, Shade;" + Environment.NewLine;
              break;
            }

            case (uint) RDP.G_CCMUX_ENVIRONMENT: {
              // 5
              ShaderLines += "MOV CCRegister_1.rgb, EnvColor;" +
                             Environment.NewLine;
              break;
            }

            case (uint) RDP.G_CCMUX_SCALE: {
              // 6
              ShaderLines += "MOV CCRegister_1.rgb, {1.0,1.0,1.0,1.0};" +
                             Environment.NewLine;
              break;
            }

            case (uint) RDP.G_CCMUX_COMBINED_ALPHA: {
              // 7
              ShaderLines += "MOV CCRegister_1.rgb, CCReg.a;" +
                             Environment.NewLine;
              break;
            }

            case (uint) RDP.G_CCMUX_TEXEL0_ALPHA: {
              // 8
              ShaderLines += "MOV CCRegister_1.rgb, Texel0.a;" +
                             Environment.NewLine;
              break;
            }

            case (uint) RDP.G_CCMUX_TEXEL1_ALPHA: {
              // 9
              ShaderLines += "MOV CCRegister_1.rgb, Texel1.a;" +
                             Environment.NewLine;
              break;
            }

            case (uint) RDP.G_CCMUX_PRIMITIVE_ALPHA: {
              // 10
              ShaderLines += "MOV CCRegister_1.rgb, PrimColor.a;" +
                             Environment.NewLine;
              break;
            }

            case (uint) RDP.G_CCMUX_SHADE_ALPHA: {
              // 11
              ShaderLines += "MOV CCRegister_1.rgb, Shade.a;" +
                             Environment.NewLine;
              break;
            }

            case (uint) RDP.G_CCMUX_ENV_ALPHA: {
              // 12
              ShaderLines += "MOV CCRegister_1.rgb, EnvColor.a;" +
                             Environment.NewLine;
              break;
            }

            case (uint) RDP.G_CCMUX_PRIM_LOD_FRAC: {
              // 14
              ShaderLines += "MOV CCRegister_1.rgb, PrimColorL;" +
                             Environment.NewLine;
              break;
            }

            case (uint) RDP.G_CCMUX_K5:
            case var @case when @case == (uint) RDP.G_CCMUX_SCALE: {
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
            case (uint) RDP.G_CCMUX_COMBINED: {
              // 0
              ShaderLines +=
                  "MOV CCRegister_1.rgb, CCReg;" + Environment.NewLine;
              break;
            }

            case (uint) RDP.G_CCMUX_TEXEL0: {
              // 1
              ShaderLines +=
                  "MOV CCRegister_1.rgb, Texel0;" + Environment.NewLine;
              break;
            }

            case (uint) RDP.G_CCMUX_TEXEL1: {
              // 2
              ShaderLines +=
                  "MOV CCRegister_1.rgb, Texel1;" + Environment.NewLine;
              break;
            }

            case (uint) RDP.G_CCMUX_PRIMITIVE: {
              // 3
              ShaderLines += "MOV CCRegister_1.rgb, PrimColor;" +
                             Environment.NewLine;
              break;
            }

            case (uint) RDP.G_CCMUX_SHADE: {
              // 4
              ShaderLines +=
                  "MOV CCRegister_1.rgb, Shade;" + Environment.NewLine;
              break;
            }

            case (uint) RDP.G_CCMUX_ENVIRONMENT: {
              // 5
              ShaderLines += "MOV CCRegister_1.rgb, EnvColor;" +
                             Environment.NewLine;
              break;
            }

            case (uint) RDP.G_CCMUX_1: {
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
            case (uint) RDP.G_ACMUX_COMBINED: {
              ShaderLines += "MOV ACRegister_0.a, ACReg;" + Environment.NewLine;
              break;
            }

            case (uint) RDP.G_ACMUX_TEXEL0: {
              ShaderLines +=
                  "MOV ACRegister_0.a, Texel0.a;" + Environment.NewLine;
              break;
            }

            case (uint) RDP.G_ACMUX_TEXEL1: {
              ShaderLines +=
                  "MOV ACRegister_0.a, Texel1.a;" + Environment.NewLine;
              break;
            }

            case (uint) RDP.G_ACMUX_PRIMITIVE: {
              ShaderLines += "MOV ACRegister_0.a, PrimColor.a;" +
                             Environment.NewLine;
              break;
            }

            case (uint) RDP.G_ACMUX_SHADE: {
              ShaderLines +=
                  "MOV ACRegister_0.a, Shade.a;" + Environment.NewLine;
              break;
            }

            case (uint) RDP.G_ACMUX_ENVIRONMENT: {
              ShaderLines += "MOV ACRegister_0.a, EnvColor.a;" +
                             Environment.NewLine;
              break;
            }

            case (uint) RDP.G_ACMUX_1: {
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
            case (uint) RDP.G_ACMUX_COMBINED: {
              ShaderLines += "MOV ACRegister_1.a, ACReg;" + Environment.NewLine;
              break;
            }

            case (uint) RDP.G_ACMUX_TEXEL0: {
              ShaderLines +=
                  "MOV ACRegister_1.a, Texel0.a;" + Environment.NewLine;
              break;
            }

            case (uint) RDP.G_ACMUX_TEXEL1: {
              ShaderLines +=
                  "MOV ACRegister_1.a, Texel1.a;" + Environment.NewLine;
              break;
            }

            case (uint) RDP.G_ACMUX_PRIMITIVE: {
              ShaderLines += "MOV ACRegister_1.a, PrimColor.a;" +
                             Environment.NewLine;
              break;
            }

            case (uint) RDP.G_ACMUX_SHADE: {
              ShaderLines +=
                  "MOV ACRegister_1.a, Shade.a;" + Environment.NewLine;
              break;
            }

            case (uint) RDP.G_ACMUX_ENVIRONMENT: {
              ShaderLines += "MOV ACRegister_1.a, EnvColor.a;" +
                             Environment.NewLine;
              break;
            }

            case (uint) RDP.G_ACMUX_1: {
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
            case (uint) RDP.G_ACMUX_LOD_FRACTION: {
              ShaderLines += "MOV ACRegister_1.a, {1.0,1.0,1.0,1.0};" +
                             Environment.NewLine;
              break;
            }

            case (uint) RDP.G_ACMUX_TEXEL0: {
              ShaderLines +=
                  "MOV ACRegister_1.a, Texel0.a;" + Environment.NewLine;
              break;
            }

            case (uint) RDP.G_ACMUX_TEXEL1: {
              ShaderLines +=
                  "MOV ACRegister_1.a, Texel1.a;" + Environment.NewLine;
              break;
            }

            case (uint) RDP.G_ACMUX_PRIMITIVE: {
              ShaderLines += "MOV ACRegister_1.a, PrimColor.a;" +
                             Environment.NewLine;
              break;
            }

            case (uint) RDP.G_ACMUX_SHADE: {
              ShaderLines +=
                  "MOV ACRegister_1.a, Shade.a;" + Environment.NewLine;
              break;
            }

            case (uint) RDP.G_ACMUX_ENVIRONMENT: {
              ShaderLines += "MOV ACRegister_1.a, EnvColor.a;" +
                             Environment.NewLine;
              break;
            }

            case (uint) RDP.G_ACMUX_PRIM_LOD_FRAC: {
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
            case (uint) RDP.G_ACMUX_COMBINED: {
              ShaderLines +=
                  "MOV ACRegister_1.a, ACReg.a;" + Environment.NewLine;
              break;
            }

            case (uint) RDP.G_ACMUX_TEXEL0: {
              ShaderLines +=
                  "MOV ACRegister_1.a, Texel0.a;" + Environment.NewLine;
              break;
            }

            case (uint) RDP.G_ACMUX_TEXEL1: {
              ShaderLines +=
                  "MOV ACRegister_1.a, Texel1.a;" + Environment.NewLine;
              break;
            }

            case (uint) RDP.G_ACMUX_PRIMITIVE: {
              ShaderLines += "MOV ACRegister_1.a, PrimColor.a;" +
                             Environment.NewLine;
              break;
            }

            case (uint) RDP.G_ACMUX_SHADE: {
              ShaderLines +=
                  "MOV ACRegister_1.a, Shade.a;" + Environment.NewLine;
              break;
            }

            case (uint) RDP.G_ACMUX_ENVIRONMENT: {
              ShaderLines += "MOV ACRegister_1.a, EnvColor.a;" +
                             Environment.NewLine;
              break;
            }

            case (uint) RDP.G_ACMUX_1: {
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

          this.CombArg = withBlock;
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
  }
}