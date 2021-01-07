using System;
using System.Text;

using Tao.OpenGl;

namespace UoT {
  /// <summary>
  ///   Helper class for managing shader-specific fields and passing them into
  ///   OpenGL.
  /// </summary>
  public class DlShaderManager {
    // TODO: Clean all this up.
    // TODO: Fix rendering collision boundaries.
    // TODO: Fix lighting.
    // TODO: Support uv bounds mapping in the shader (for repeating+clamped textures).
    // TODO: Add support for reflective surfaces.

    private readonly DlShaderGenerator generator_ = new DlShaderGenerator();
    private ShaderCache[] FragShaderCache = new ShaderCache[0];

    /**
     * Important key terms, as sourced from:
     * https://wiki.cloudmodding.com/oot/F3DZEX2#Parameter_Description
     *
     * COMBINED: The current added-up total color.
     * PRIMITIVE: A global color, not sure where this is mainly used.
     * SHADE: The color calculated from the vertex colors that make up a
     *   triangle.
     * ENVIRONMENT: A global color, typically used for coloring in alpha
     *   textures like Link's tunic.
     */
    public float[] PrimColor = new float[4];
    public float PrimColorLOD = 0f;
    public float PrimColorM = 0f;
    public float[] EnvironmentColor = new float[4];
    public float[] BlendColor = new float[4];
    public float[] FogColor = new float[4];
    private UnpackedCombiner combArg_ = new UnpackedCombiner();
    private bool PrecompiledCombiner = false;

    public bool MultiTexture = false;
    public bool EnableCombiner = false;
    public bool EnableLighting = false;

    private void ResetColor_(float[] color)
      => this.SetColor_(color, 1, 1, 1, .5f);

    private int activeProgram_ = -1;
    private int timeLocation_ = -1;
    private int envColorLocation_ = -1;
    private int primColorLocation_ = -1;
    private int shadeLocation_ = -1;
    private int primColorLodLocation_ = -1;
    private int texture0Location_ = -1;
    private int texture1Location_ = -1;

    private int lightingEnabledLocation_ = -1;

    public int Uv0Location { get; private set; } = -1;
    public int Uv1Location { get; private set; } = -1;
    public int NormalLocation { get; private set; } = -1;
    public int ColorLocation { get; private set; } = -1;

    public void SetCombine(uint w0, uint w1) {
      if (GLExtensions.GLFragProg) {
        var ShaderCachePos = -1;
        this.EnableCombiner = true;

        foreach (var cachedFragShader in this.FragShaderCache) {
          if (w0 == cachedFragShader.MUXS0 && w1 == cachedFragShader.MUXS1) {
            this.activeProgram_ = (int) cachedFragShader.FragShader;

            Gl.glUseProgram(this.activeProgram_);

            this.timeLocation_ =
                Gl.glGetUniformLocation(this.activeProgram_, "time");
            this.envColorLocation_ =
                Gl.glGetUniformLocation(this.activeProgram_, "EnvColor");
            this.primColorLocation_ =
                Gl.glGetUniformLocation(this.activeProgram_, "PrimColor");
            this.shadeLocation_ =
                Gl.glGetUniformLocation(this.activeProgram_, "Shade");
            this.primColorLodLocation_ =
                Gl.glGetUniformLocation(this.activeProgram_, "PrimColorL");
            this.texture0Location_ =
                Gl.glGetUniformLocation(this.activeProgram_, "texture0");
            this.texture1Location_ =
                Gl.glGetUniformLocation(this.activeProgram_, "texture1");
            this.lightingEnabledLocation_ =
                Gl.glGetUniformLocation(this.activeProgram_, "lightingEnabled");

            this.Uv0Location =
                Gl.glGetAttribLocation(this.activeProgram_, "in_uv0");
            this.Uv1Location =
                Gl.glGetAttribLocation(this.activeProgram_, "in_uv1");
            this.NormalLocation =
                Gl.glGetAttribLocation(this.activeProgram_, "in_normal");
            this.ColorLocation =
                Gl.glGetAttribLocation(this.activeProgram_, "in_color");

            return;
          }
        }

        this.DecodeMUX_(w0,
                        w1,
                        ref this.FragShaderCache,
                        this.FragShaderCache.Length);
      } else {
        Gl.glUseProgram(0);
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

    public void PassValuesToShader() {
      if (this.EnableCombiner) {
        Gl.glUniform1f(this.timeLocation_, (float) Time.Current);

        Gl.glUniform4fv(this.envColorLocation_, 1, this.EnvironmentColor);
        Gl.glUniform4fv(this.primColorLocation_, 1, this.PrimColor);
        Gl.glUniform4fv(this.shadeLocation_, 1, this.BlendColor);
        Gl.glUniform1f(this.primColorLodLocation_, this.PrimColorLOD);

        Gl.glUniform1i(this.texture0Location_, 0);
        Gl.glUniform1i(this.texture1Location_, 1);

        Gl.glUniform1f(this.lightingEnabledLocation_,
                       this.EnableLighting ? 1 : 0);
      } else {
        Gl.glDisable(Gl.GL_FRAGMENT_PROGRAM_ARB);
        Gl.glEnable(Gl.GL_LIGHTING);
        Gl.glEnable(Gl.GL_NORMALIZE);
        this.MultiTexture = false;
        this.EnableLighting = true;
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
      this.UnpackMUX(MUXS0, MUXS1, ref this.combArg_);
      Array.Resize(ref Cache, CacheEntry + 1);
      Cache[CacheEntry].MUXS0 = MUXS0;
      Cache[CacheEntry].MUXS1 = MUXS1;
      this.CreateShaderProgram_(2, ref Cache, CacheEntry);
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

    private void CreateShaderProgram_(
        int cycles,
        ref ShaderCache[] cache,
        int entry)
      => cache[entry].FragShader =
             (uint) this.generator_.CreateShaderProgram(cycles, this.combArg_);
  }
}