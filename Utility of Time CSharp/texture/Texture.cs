using Tao.OpenGl;

namespace UoT {
  /// <summary>
  ///   Instance of a valid texture.
  /// </summary>
  public class Texture {
    private TextureParams TextureParams { get; }

    public Texture(TextureParams textureParams) {
      this.TextureParams = textureParams;
    }

    // OpenGL-specific logic.
    private int GlId => this.TextureParams.ID;

    public void Bind() => Gl.glBindTexture(Gl.GL_TEXTURE_2D, this.GlId);

    public void Destroy() {
      var id = this.GlId;
      Gl.glDeleteTextures(1, ref id);
    }

    // TODO: Add method for destroying.
    // TODO: Add method for saving to a file.
  }
}
