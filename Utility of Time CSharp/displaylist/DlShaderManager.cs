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
      var ShaderLines =
          @"!!ARBfp1.0
            TEMP Texel0;
            TEMP Texel1;
            TEMP CCRegister_0;
            TEMP CCRegister_1;
            TEMP ACRegister_0;
            TEMP ACRegister_1;
            TEMP CCReg;
            TEMP ACReg;
            PARAM EnvColor = program.env[0];
            PARAM PrimColor = program.env[1];
            PARAM PrimColorL = program.env[2];
            ATTRIB Shade = fragment.color.primary;
            OUTPUT FinalColor = result.color;
            TEX Texel0, fragment.texcoord[0], texture[0], 2D;
            TEX Texel1, fragment.texcoord[1], texture[1], 2D;";

      for (var i = 0; i < Cycles; ++i) {
        // Final color = (ColorA [base] - ColorB) * ColorC + ColorD
        ShaderLines +=
            DlShaderManager.MovC_('a', "CCRegister_0.rgb", this.CombArg.cA[i]);
        ShaderLines +=
            DlShaderManager.MovC_('b', "CCRegister_1.rgb", this.CombArg.cB[i]);
        ShaderLines += "SUB CCRegister_0, CCRegister_0, CCRegister_1;" +
                       Environment.NewLine;

        ShaderLines +=
            DlShaderManager.MovC_('c', "CCRegister_1.rgb", this.CombArg.cC[i]);
        ShaderLines += "MUL CCRegister_0, CCRegister_0, CCRegister_1;" +
                       Environment.NewLine;

        ShaderLines +=
            DlShaderManager.MovC_('d', "CCRegister_1.rgb", this.CombArg.cD[i]);
        ShaderLines += "ADD CCRegister_0, CCRegister_0, CCRegister_1;" +
                       Environment.NewLine +
                       Environment.NewLine;


        ShaderLines +=
            DlShaderManager.MovA_('a', "ACRegister_0.a", this.CombArg.aA[i]);
        ShaderLines +=
            DlShaderManager.MovA_('b', "ACRegister_1.a", this.CombArg.aB[i]);
        ShaderLines += "SUB ACRegister_0.a, ACRegister_0.a, ACRegister_1.a;" +
                       Environment.NewLine;

        ShaderLines +=
            DlShaderManager.MovA_('c', "ACRegister_1.a", this.CombArg.aC[i]);
        ShaderLines += "MUL ACRegister_0.a, ACRegister_0.a, ACRegister_1.a;" +
                       Environment.NewLine;

        ShaderLines +=
            DlShaderManager.MovA_('d', "ACRegister_1.a", this.CombArg.aD[i]);
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

    private static string MovC_(char letter, string target, uint value) {
      return $"MOV {target}, {DlShaderManager.CToValue_(letter, value)};" +
             Environment.NewLine;
    }

    private static string CToValue_(char letter, uint value) {
      switch (value) {
        case (uint) RDP.G_CCMUX_COMBINED:
          return "CCReg";

        case (uint) RDP.G_CCMUX_TEXEL0:
          return "Texel0";

        case (uint) RDP.G_CCMUX_TEXEL1:
          return "Texel1";

        case (uint) RDP.G_CCMUX_PRIMITIVE:
          return "PrimColor";

        case (uint) RDP.G_CCMUX_SHADE:
          return "Shade";

        case (uint) RDP.G_CCMUX_ENVIRONMENT:
          return "EnvColor";
      }

      switch (letter) {
        case 'a':
          // TODO: Support noise mux (white noise)?
          switch (value) {
            case (uint) RDP.G_CCMUX_1:
            case (uint) RDP.G_CCMUX_NOISE:
              return "{1.0,1.0,1.0,1.0}";
          }
          break;

        case 'b':
          switch (value) {
            case (uint) RDP.G_CCMUX_CENTER:
            case (uint) RDP.G_CCMUX_K4:
              return "{1.0,1.0,1.0,1.0}";
          }
          break;

        case 'c':
          switch (value) {
            case (uint) RDP.G_CCMUX_COMBINED_ALPHA:
              return "CCReg.a";

            case (uint) RDP.G_CCMUX_TEXEL0_ALPHA:
              return "Texel0.a";

            case (uint) RDP.G_CCMUX_TEXEL1_ALPHA:
              return "Texel1.a";

            case (uint) RDP.G_CCMUX_PRIMITIVE_ALPHA:
              return "PrimColor.a";

            case (uint) RDP.G_CCMUX_SHADE_ALPHA:
              return "Shade.a";

            case (uint) RDP.G_CCMUX_ENV_ALPHA:
              return "EnvColor.a";

            case (uint) RDP.G_CCMUX_PRIM_LOD_FRAC:
              return "PrimColorL";

            case (uint) RDP.G_CCMUX_SCALE:
            case (uint) RDP.G_CCMUX_K5:
              return "{1.0,1.0,1.0,1.0}";
          }
          break;

        case 'd':
          switch (value) {
            case (uint) RDP.G_CCMUX_1:
              return "{1.0,1.0,1.0,1.0}";
          }
          break;
      }

      return "{0.0,0.0,0.0,0.0}";
    }

    private static string MovA_(char letter, string target, uint value) {
      return $"MOV {target}, {DlShaderManager.AToValue_(letter, value)};" +
             Environment.NewLine;
    }

    private static string AToValue_(char letter, uint value) {
      switch (value) {
        case (uint) RDP.G_ACMUX_TEXEL0:
          return "Texel0.a";

        case (uint) RDP.G_ACMUX_TEXEL1:
          return "Texel1.a";

        case (uint) RDP.G_ACMUX_PRIMITIVE:
          return "PrimColor.a";

        case (uint) RDP.G_ACMUX_SHADE:
          return "Shade.a";

        case (uint) RDP.G_ACMUX_ENVIRONMENT:
          return "EnvColor.a";
      }

      if (letter == 'a' || letter == 'b' || letter == 'd') {
        switch (value) {
          case (uint) RDP.G_ACMUX_COMBINED:
            return "ACReg";

          case (uint) RDP.G_ACMUX_1:
            return "{1.0,1.0,1.0,1.0}";
        }
      } else {
        switch (value) {
          case (uint)RDP.G_ACMUX_PRIM_LOD_FRAC:
            return "PrimColorL.a";

          case (uint)RDP.G_ACMUX_LOD_FRACTION:
            return "{1.0,1.0,1.0,1.0}";
        }
      }

      return "{0.0,0.0,0.0,0.0}";
    }
  }
}