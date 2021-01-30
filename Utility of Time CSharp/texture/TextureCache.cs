﻿using System.Collections.Generic;

namespace UoT {
  /// <summary>
  ///   Helper class for caching textures generated by display lists.
  /// </summary>
  public class TextureCache {
    private readonly IDictionary<long, Texture> impl_ =
        new Dictionary<long, Texture>();

    public void Clear() {
      foreach (var texture in this.impl_.Values) {
        texture.Destroy();
      }
      this.impl_.Clear();
    }

    /// <summary>
    ///   O(log(n)) lookup.
    /// </summary>
    public Texture this[TileDescriptor tileDescriptor] {
      get {
        this.impl_.TryGetValue(tileDescriptor.Uuid, out var texture);
        return texture;
      }
    }

    public Texture? Add(TileDescriptor tileDescriptor, byte[] rgba, bool save = false) {
      var uuid = tileDescriptor.Uuid;
      if (!this.impl_.ContainsKey(uuid)) {
        var texture = new Texture(tileDescriptor, rgba, save);
        this.impl_.Add(uuid, texture);
        return texture;
      }

      return null;
    }
  }
}