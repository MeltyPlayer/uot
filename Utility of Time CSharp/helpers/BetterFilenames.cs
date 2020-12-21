using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace UoT {
  public static class BetterFilenames {
    private static readonly IDictionary<string, string> impl_ =
        new Dictionary<string, string>();

    static BetterFilenames() => BetterFilenames.Add(
        ("object_bdan_objects", "Misc. Inside Jabu-Jabu's Belly"),
        ("object_bombf", "Bomb Flower"),
        ("object_ddan_objects", "Misc. Dodongo's Cavern"),
        ("object_dekunuts", "Deku"),
        ("object_dekubaba", "Deku Baba"),
        ("object_dodongo", "Dodongo"),
        ("object_goma", "Ghoma"),
        ("object_hakach_objects", "Misc. Bottom of the Well"),
        ("object_hidan_objects", "Misc. Fire Temple"),
        ("object_ice_objects", "Misc. Ice Cavern"),
        ("object_jj", "Jabu-Jabu"),
        ("object_link_boy", "Link (adult)"),
        ("object_link_child", "Link (boy)"),
        ("object_mizu_objects", "Misc. Water Temple"),
        ("object_mori_hineri1", "Twisting hallway"),
        ("object_niw", "Cucco"),
        ("object_okuta", "Octorok"),
        ("object_peehat", "Peahat"),
        ("object_poh", "Poe"),
        ("object_relay_objects", "Misc. Windmill"),
        ("object_rd", "Gibdo"),
        ("object_sk2", "Stalfos"),
        ("object_spot00_objects", "Misc. Hyrule Field"),
        ("object_ta", "Talon"),
        ("object_tk", "Dampé"),
        ("object_toki_objects", "Misc. Temple of Time"),
        ("object_torch2", "Dark Link"),
        ("object_vase", "Pot"),
        ("object_st", "Skulltula"),
        ("object_vm", "Beamos"),
        ("object_wallmaster", "Wallmaster"),
        ("object_xc", "Sheik"),
        ("object_ydan_objects", "Misc. Inside the Deku Tree"),
        ("object_zf", "Lizalfos")
    );

    public static string Get(string filename) {
      BetterFilenames.impl_.TryGetValue(filename, out var betterFilename);
      return betterFilename ?? filename;
    }

    private static void Add(params (string, string)[] pairs) {
      foreach (var pair in pairs) {
        BetterFilenames.impl_.Add(pair.Item1, pair.Item2);
      }
    }
  }
}