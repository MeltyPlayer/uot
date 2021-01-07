using System;
using System.Text;

using Tao.OpenGl;

namespace UoT {
  public class DlShaderGenerator {
    public int CreateShaderProgram(int cycles, UnpackedCombiner combArg) {
      var vertexShader = this.CreateVertexShader_();
      var fragmentShader = this.CreateFragmentShader_(cycles, combArg);

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

      return program;
    }

    private int CreateVertexShader_() {
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

      return ShaderCompiler.Compile(Gl.GL_VERTEX_SHADER, vertexShaderLines);
    }

    private int CreateFragmentShader_(
        int cycles,
        UnpackedCombiner combArg) {
      var newLine = '\n';

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

      for (var i = 0; i < cycles; ++i) {
        // Final color = (ColorA [base] - ColorB) * ColorC + ColorD
        fragmentMainLines +=
            DlShaderGenerator.MovC_('a',
                                    "CCRegister_0.rgb",
                                    combArg.cA[i]);
        fragmentMainLines +=
            DlShaderGenerator.MovC_('b',
                                    "CCRegister_1.rgb",
                                    combArg.cB[i]);
        fragmentMainLines += "CCRegister_0 = CCRegister_0 - CCRegister_1;" +
                             newLine +
                             newLine;

        fragmentMainLines +=
            DlShaderGenerator.MovC_('c',
                                    "CCRegister_1.rgb",
                                    combArg.cC[i]);
        fragmentMainLines += "CCRegister_0 = CCRegister_0 * CCRegister_1;" +
                             newLine;

        fragmentMainLines +=
            DlShaderGenerator.MovC_('d',
                                    "CCRegister_1.rgb",
                                    combArg.cD[i]);
        fragmentMainLines += "CCRegister_0 = CCRegister_0 + CCRegister_1;" +
                             newLine +
                             newLine;


        fragmentMainLines +=
            DlShaderGenerator.MovA_('a', "ACRegister_0.a", combArg.aA[i]) +
            newLine;
        fragmentMainLines +=
            DlShaderGenerator.MovA_('b', "ACRegister_1.a", combArg.aB[i]) +
            newLine;
        fragmentMainLines +=
            "ACRegister_0.a = ACRegister_0.a - ACRegister_1.a;" +
            newLine;

        fragmentMainLines +=
            DlShaderGenerator.MovA_('c', "ACRegister_1.a", combArg.aC[i]) +
            newLine;
        fragmentMainLines +=
            "ACRegister_0.a = ACRegister_0.a * ACRegister_1.a;" +
            newLine;

        fragmentMainLines +=
            DlShaderGenerator.MovA_('d', "ACRegister_1.a", combArg.aD[i]) +
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

      return ShaderCompiler.Compile(Gl.GL_FRAGMENT_SHADER, fragmentShaderLines);
    }

    private static string MovC_(
        char letter,
        string target,
        uint value) {
      return $"{target} = {DlShaderGenerator.CToValue_(letter, value)};" +
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
      return $"{target} = {DlShaderGenerator.AToValue_(letter, value)};" +
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