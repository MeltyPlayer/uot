using System.Collections.Generic;

using Tao.OpenGl;

namespace UoT {
  public class TextureCache {
    private readonly IList<TextureData> textures_ = new List<TextureData>();

    public void Clear() {
      // TODO: Move inside texture class.
      foreach (var texture in this.textures_) {
        var id = texture.ID;
        Gl.glDeleteTextures(1, ref id);
      }
      this.textures_.Clear();
    }

    public TextureData this[int index] => this.textures_[index];

    public void Add(TextureData texture) {
      this.textures_.Add(texture);
    }

    public int Find(TextureData searchTexture) {
      for (var i = 0; i < this.textures_.Count; ++i) {
        var texture = this.textures_[i];
        if (texture.Offset == searchTexture.Offset &&
            texture.ImageBank == searchTexture.ImageBank) {
          return i;
        }
      }
      return -1;
    }
  }
}
