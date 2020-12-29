using System.Drawing;
using System.IO;

using Tao.OpenGl;

namespace UoT {
  /// <summary>
  ///   Instance of a valid texture.
  /// </summary>
  public class Texture {
    public TileDescriptor TileDescriptor { get; }
    private readonly byte[] rgba_;

    public Texture(TileDescriptor tileDescriptor, byte[] rgba, bool save = false) {
      this.TileDescriptor = tileDescriptor;
      this.rgba_ = rgba;

      if (save) {
        var format = tileDescriptor.ColorFormat;
        var size = tileDescriptor.BitSize;
        var uuid = tileDescriptor.Uuid;
        var filename = "R:/Noesis/Output/" +
                       format +
                       "_" +
                       size +
                       "_" +
                       uuid.ToString("X8") +
                       ".bmp";
        this.SaveToFile(filename);
      }
    }

    // OpenGL-specific logic.
    private int GlId => this.TileDescriptor.ID;

    public void Bind() => Gl.glBindTexture(Gl.GL_TEXTURE_2D, this.GlId);

    public void Destroy() {
      var id = this.GlId;
      Gl.glDeleteTextures(1, ref id);
    }

    public void SaveToFile(string filename) {
      if (File.Exists(filename)) {
        return;
      }

      var width = this.TileDescriptor.LoadWidth;
      var height = this.TileDescriptor.LoadHeight;

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
