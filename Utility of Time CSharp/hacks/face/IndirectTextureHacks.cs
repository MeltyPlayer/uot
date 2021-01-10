using System.Collections.Generic;

namespace UoT {
  public interface IIndirectTextureHack {
    /// <summary>
    ///   Maps a given texture address to a new address. This is needed to map
    ///   an eye/mouth address from a random spot in RAM to where they're
    ///   actually defined in ROM (as this is basically what would happen
    ///   in-game.)
    /// </summary>
    uint MapTextureAddress(uint originalAddress);
  }

  public static class IndirectTextureHacks {
    private static IDictionary<string, IIndirectTextureHack> impl_ =
        new Dictionary<string, IIndirectTextureHack>();

    static IndirectTextureHacks() {
      var linkIndirectTextureHack = new LinkIndirectTextureHack();
      IndirectTextureHacks.Add_(
          ("object_link_boy", linkIndirectTextureHack),
          ("object_link_child", linkIndirectTextureHack),
          ("object_tite", new TektiteIndirectTextureHack()),
          ("object_zl1", new ZeldaChildIndirectTextureHack()),
          ("object_zl2", new ZeldaAdultIndirectTextureHack())
      );
    }

    public static IIndirectTextureHack Get(string filename) {
      IndirectTextureHacks.impl_.TryGetValue(filename, out var hack);
      return hack;
    }

    private static void Add_(params (string, IIndirectTextureHack)[] pairs) {
      foreach (var pair in pairs) {
        IndirectTextureHacks.impl_.Add(pair.Item1, pair.Item2);
      }
    }
  }
}