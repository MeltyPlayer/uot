using System.Drawing;
using System.IO;

using Tao.OpenGl;

namespace UoT {
  /// <summary>
  ///   Instance of a valid texture.
  /// </summary>
  public class Texture {
    private TextureParams TextureParams { get; }
    private readonly byte[] rgba_;

    public Texture(TextureParams textureParams, byte[] rgba) {
      this.TextureParams = textureParams;
      this.rgba_ = rgba;

      var format = textureParams.TexFormat;
      var uuid = textureParams.Uuid;
      var filename = "R:/Noesis/Output/" + format + "_" + uuid + ".bmp";
      this.SaveToFile(filename);
    }

    // OpenGL-specific logic.
    private int GlId => this.TextureParams.ID;

    public void Bind() => Gl.glBindTexture(Gl.GL_TEXTURE_2D, this.GlId);

    public void Destroy() {
      var id = this.GlId;
      Gl.glDeleteTextures(1, ref id);
    }

    public void SaveToFile(string filename) {
      if (File.Exists(filename)) {
        return;
      }

      var width = this.TextureParams.RealWidth;
      var height = this.TextureParams.RealHeight;

      var rgba = this.rgba_;

      var bmp = new Bitmap(width, height);
      for (var y = 0; y < height; y++) {
        for (var x = 0; x < width; x++) {
          var i = 4 * ((y * width) + x);

          var r = rgba[i];
          var g = rgba[i + 1];
          var b = rgba[i + 2];
          var a = rgba[i + 3];

          var color = Color.FromArgb(a, r, g, b);
          bmp.SetPixel(x, y, color);
        }
      }

      bmp.Save(filename);
    }

    // TODO: Add method for destroying.
    // TODO: Add method for saving to a file.
  }
}
