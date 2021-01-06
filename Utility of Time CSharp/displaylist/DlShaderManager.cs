using System;
using System.Text;

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
        // TODO: Fix this.
        /*Gl.glProgramEnvParameter4fvARB(Gl.GL_FRAGMENT_PROGRAM_ARB,
                                       0,
                                       this.EnvironmentColor);
        Gl.glProgramEnvParameter4fvARB(Gl.GL_FRAGMENT_PROGRAM_ARB,
                                       1,
                                       this.PrimColor);
        Gl.glProgramEnvParameter4fvARB(Gl.GL_FRAGMENT_PROGRAM_ARB,
                                       3,
                                       this.BlendColor);
        Gl.glProgramEnvParameter4fARB(Gl.GL_FRAGMENT_PROGRAM_ARB,
                                      2,
                                      this.PrimColorLOD,
                                      this.PrimColorLOD,
                                      this.PrimColorLOD,
                                      this.PrimColorLOD);*/

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

    private void CreateShader_(
        int Cycles,
        ref ShaderCache[] Cache,
        int CacheEntry) {
      var newLine = '\n';

      var vertexShaderLines =
          @"#version 130

            in vec3 in_position;
            in vec2 in_uv0;
            in vec2 in_uv1;
            in vec3 in_normal;
            in vec4 in_color;

            out vec3 position;
            out vec2 uv0;
            out vec2 uv1;
            out vec3 normal;
            out vec4 color;

            void main() {
              gl_Position = gl_ModelViewProjectionMatrix * vec4(in_position, 1f);

              position = in_position;
              uv0 = in_uv0;
              uv1 = in_uv1;
              normal = in_normal;
              color = in_color;
            }";

      var vertexShader =
          ShaderCompiler.Compile(Gl.GL_VERTEX_SHADER, vertexShaderLines);


      // TODO: Shade might need to be an "in" instead?
      var fragmentHeaderLines =
          @"#version 400

            uniform float time;
            uniform vec4 EnvColor;
            uniform vec4 PrimColor;
            uniform vec4 Shade;
            uniform float PrimColorL;

            uniform float lightingEnabled;

            uniform sampler2D texture0;
            uniform sampler2D texture1;

            in vec3 position;
            in vec2 uv0;
            in vec2 uv1;
            in vec3 normal;
            in vec4 color;

            out vec4 outColor;" +
          newLine;

      // TODO: Allow changing light position.
      var fragmentMainLines =
          @"vec4 applyColor(vec4 v_Color) {
              return v_Color * color;
            }

            vec4 applyLighting(vec4 v_Color) {
              vec3 u_Light_position = vec3(1);
              vec3 u_Ambient_color = vec3(1);
              vec3 u_Light_color = vec3(1);
              float u_Shininess = 0;

              vec3 v_Vertex = position;

              // Calculate the ambient color as a percentage of the surface color
              vec3 ambient_color = u_Ambient_color * vec3(v_Color);

              // Calculate a vector from the fragment location to the light source
              vec3 to_light = u_Light_position - v_Vertex;
              to_light = normalize( to_light );

              // The vertex's normal vector is being interpolated across the primitive
              // which can make it un-normalized. So normalize the vertex's normal vector.
              vec3 vertex_normal = normalize( normal );

              // Calculate the cosine of the angle between the vertex's normal vector
              // and the vector going to the light.
              float cos_angle = dot(vertex_normal, to_light);
              cos_angle = clamp(cos_angle, 0.0, 1.0);

              // Scale the color of this fragment based on its angle to the light.
              vec3 diffuse_color = vec3(v_Color) * cos_angle;

              // Calculate the reflection vector
              vec3 reflection = 2.0 * dot(vertex_normal,to_light) * vertex_normal - to_light;

              // Calculate a vector from the fragment location to the camera.
              // The camera is at the origin, so negating the vertex location gives the vector
              vec3 to_camera = -1.0 * v_Vertex;

              // Calculate the cosine of the angle between the reflection vector
              // and the vector going to the camera.
              reflection = normalize( reflection );
              to_camera = normalize( to_camera );
              cos_angle = dot(reflection, to_camera);
              cos_angle = clamp(cos_angle, 0.0, 1.0);
              cos_angle = pow(cos_angle, u_Shininess);

              // The specular color is from the light source, not the object
              vec3 specular_color;
              if (cos_angle > 0.0) {
                specular_color = u_Light_color * cos_angle;
                diffuse_color = diffuse_color * (1.0 - cos_angle);
              } else {
                specular_color = vec3(0.0, 0.0, 0.0);
              }

              vec3 color = ambient_color + diffuse_color + specular_color;

              //return vec4(color, v_Color.a);

              return v_Color;
            }

            void main(void) {
              vec4 CCRegister_0;
              vec4 CCRegister_1;
              vec4 ACRegister_0;
              vec4 ACRegister_1;
              vec4 CCReg;
              float ACReg;

              vec4 Texel0 = texture(texture0, uv0);
              vec4 Texel1 = texture(texture1, uv1);" +
          newLine;

      for (var i = 0; i < Cycles; ++i) {
        // Final color = (ColorA [base] - ColorB) * ColorC + ColorD
        fragmentMainLines +=
            DlShaderManager.MovC_('a',
                                  "CCRegister_0.rgb",
                                  this.CombArg.cA[i]);
        fragmentMainLines +=
            DlShaderManager.MovC_('b',
                                  "CCRegister_1.rgb",
                                  this.CombArg.cB[i]);
        fragmentMainLines += "CCRegister_0 = CCRegister_0 - CCRegister_1;" +
                             newLine +
                             newLine;

        fragmentMainLines +=
            DlShaderManager.MovC_('c',
                                  "CCRegister_1.rgb",
                                  this.CombArg.cC[i]);
        fragmentMainLines += "CCRegister_0 = CCRegister_0 * CCRegister_1;" +
                             newLine;

        fragmentMainLines +=
            DlShaderManager.MovC_('d',
                                  "CCRegister_1.rgb",
                                  this.CombArg.cD[i]);
        fragmentMainLines += "CCRegister_0 = CCRegister_0 + CCRegister_1;" +
                             newLine +
                             newLine;


        fragmentMainLines +=
            DlShaderManager.MovA_('a', "ACRegister_0.a", this.CombArg.aA[i]) +
            newLine;
        fragmentMainLines +=
            DlShaderManager.MovA_('b', "ACRegister_1.a", this.CombArg.aB[i]) +
            newLine;
        fragmentMainLines +=
            "ACRegister_0.a = ACRegister_0.a - ACRegister_1.a;" +
            newLine;

        fragmentMainLines +=
            DlShaderManager.MovA_('c', "ACRegister_1.a", this.CombArg.aC[i]) +
            newLine;
        fragmentMainLines +=
            "ACRegister_0.a = ACRegister_0.a * ACRegister_1.a;" +
            newLine;

        fragmentMainLines +=
            DlShaderManager.MovA_('d', "ACRegister_1.a", this.CombArg.aD[i]) +
            newLine;
        fragmentMainLines += "ACRegister_0 = ACRegister_0 + ACRegister_1;" +
                             newLine +
                             newLine;

        fragmentMainLines += @"CCReg.rgb = CCRegister_0.rgb;
                               ACReg = ACRegister_0.a;" +
                             newLine;
      }

      // TODO: Is this the right shadow calculation?
      fragmentMainLines +=
          @"CCReg.a = ACReg;
            outColor = mix(applyColor(CCReg), applyLighting(CCReg), lightingEnabled);
          }";

      var fragmentShaderLines = fragmentHeaderLines + fragmentMainLines;

      var fragmentShader =
          ShaderCompiler.Compile(Gl.GL_FRAGMENT_SHADER, fragmentShaderLines);

      var program = Gl.glCreateProgram();
      Gl.glAttachShader(program, vertexShader);
      Gl.glAttachShader(program, fragmentShader);
      Gl.glLinkProgram(program);

      Gl.glGetProgramiv(program, Gl.GL_LINK_STATUS, out var linked);
      if (linked == Gl.GL_FALSE) {
        Gl.glGetProgramiv(program, Gl.GL_INFO_LOG_LENGTH, out var logSize);

        var logBuilder = new StringBuilder(logSize);
        Gl.glGetProgramInfoLog(program, logSize, out _, logBuilder);

        throw new Exception(Environment.NewLine + logBuilder);
      }

      Cache[CacheEntry].FragShader = (uint) program;
    }

    private static string MovC_(
        char letter,
        string target,
        uint value) {
      return $"{target} = {DlShaderManager.CToValue_(letter, value)};" +
             Environment.NewLine;
    }

    private static string CToValue_(char letter, uint value) {
      switch (value) {
        case (uint) RDP.G_CCMUX_COMBINED:
          return "CCReg.rgb";

        case (uint) RDP.G_CCMUX_TEXEL0:
          return "Texel0.rgb";

        case (uint) RDP.G_CCMUX_TEXEL1:
          return "Texel1.rgb";

        case (uint) RDP.G_CCMUX_PRIMITIVE:
          return "PrimColor.rgb";

        case (uint) RDP.G_CCMUX_SHADE:
          return "Shade.rgb";

        case (uint) RDP.G_CCMUX_ENVIRONMENT:
          return "EnvColor.rgb";
      }

      switch (letter) {
        case 'a':
          // TODO: Support noise mux (white noise)?
          switch (value) {
            case (uint) RDP.G_CCMUX_1:
            case (uint) RDP.G_CCMUX_NOISE:
              return "vec3(1)";
          }
          break;

        case 'b':
          switch (value) {
            case (uint) RDP.G_CCMUX_CENTER:
            case (uint) RDP.G_CCMUX_K4:
              return "vec3(1)";
          }
          break;

        case 'c':
          switch (value) {
            case (uint) RDP.G_CCMUX_COMBINED_ALPHA:
              return "vec3(CCReg.a)";

            case (uint) RDP.G_CCMUX_TEXEL0_ALPHA:
              return "vec3(Texel0.a)";

            case (uint) RDP.G_CCMUX_TEXEL1_ALPHA:
              return "vec3(Texel1.a)";

            case (uint) RDP.G_CCMUX_PRIMITIVE_ALPHA:
              return "vec3(PrimColor.a)";

            case (uint) RDP.G_CCMUX_SHADE_ALPHA:
              return "vec3(Shade.a)";

            case (uint) RDP.G_CCMUX_ENV_ALPHA:
              return "vec3(EnvColor.a)";

            case (uint) RDP.G_CCMUX_PRIM_LOD_FRAC:
              return "vec3(PrimColorL)";

            case (uint) RDP.G_CCMUX_SCALE:
            case (uint) RDP.G_CCMUX_K5:
              return "vec3(1)";
          }
          break;

        case 'd':
          switch (value) {
            case (uint) RDP.G_CCMUX_1:
              return "vec3(1)";
          }
          break;
      }

      return "vec3(0)";
    }

    private static string MovA_(char letter, string target, uint value) {
      return $"{target} = {DlShaderManager.AToValue_(letter, value)};" +
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
            return "1";
        }
      } else {
        switch (value) {
          case (uint) RDP.G_ACMUX_PRIM_LOD_FRAC:
            return "PrimColorL";

          case (uint) RDP.G_ACMUX_LOD_FRACTION:
            return "1";
        }
      }

      return "0";
    }
  }
}