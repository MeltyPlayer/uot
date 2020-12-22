using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace UoT {
  public static class BetterFilenames {
    private static readonly IDictionary<string, string> impl_ =
        new Dictionary<string, string>();

    // TODO: Add ability to sort into categories too?
    static BetterFilenames() => BetterFilenames.Add(
        ("object_Bb", "Bubble"),
        ("object_bdan_objects", "Misc. Inside Jabu-Jabu's Belly"),
        ("object_blkobj", "Dark Link's Room"),
        ("object_bombf", "Bomb Flower"),
        ("object_bw", "Torch Slug"),
        ("object_bwall", "Bombable Wall"),
        ("object_cow", "Cow"),
        ("object_d_hsblock", "Hookshot Pillar"),
        ("object_ddan_objects", "Misc. Dodongo's Cavern"),
        ("object_dekunuts", "Deku Scrub"),
        ("object_dekubaba", "Deku Baba"),
        ("object_dh", "Dead Hand (arm)"),
        ("object_dodojr", "Dodongo (Baby)"),
        ("object_dodongo", "Dodongo"),
        ("object_dog", "Dog"),
        ("object_du", "Darunia"),
        ("object_dy_obj", "Great Fairy"),
        ("object_ei", "Stinger"),
        ("object_firefly", "Keese (Fire)"),
        ("object_ganon2", "Ganon"),
        ("object_gol", "Ghoma Larva"),
        ("object_goma", "Ghoma"),
        ("object_gt", "Ganon's Castle (Exterior)"),
        ("object_hakach_objects", "Misc. Bottom of the Well"),
        ("object_hidan_objects", "Misc. Fire Temple"),
        ("object_ice_objects", "Misc. Ice Cavern"),
        ("object_im", "Impa"),
        ("object_jj", "Jabu-Jabu"),
        ("object_kibako2", "Box"),
        ("object_kz", "King Zora"),
        ("object_link_boy", "Link (adult)"),
        ("object_link_child", "Link (child)"),
        ("object_ma2", "Malon (adult)"),
        ("object_mamenoki", "Magic Bean Leaf"),
        ("object_md", "Mido"),
        ("object_mizu_objects", "Misc. Water Temple"),
        ("object_mm", "Running Man"),
        ("object_mori_hineri1", "Twisting Hallway"),
        ("object_niw", "Cucco"),
        ("object_oB1", "Hyrule Castle Town Shopkeeper (w/ Legs"),
        ("object_okuta", "Octorok"),
        ("object_os", "Happy Mask Salesman"),
        ("object_ossan", "Hyrule Castle Town Shopkeeper (w/o Legs)"),
        ("object_peehat", "Peahat"),
        ("object_po_field", "Poe (Hyrule Field)"),
        ("object_poh", "Poe"),
        ("object_ps", "Poe Collector"),
        ("object_relay_objects", "Misc. Windmill"),
        ("object_rd", "Gibdo"),
        ("object_rl", "Rauru"),
        ("object_rr", "Like Like"),
        ("object_ru1", "Ruto (child)"),
        ("object_sk2", "Stalfos"),
        ("object_skb", "Stalchild"),
        ("object_skj", "Skull Kid"),
        ("object_spot00_objects", "Misc. Hyrule Field"),
        ("object_sst", "Bongo-Bongo (hand)"),
        ("object_st", "Skulltula"),
        ("object_ta", "Talon"),
        ("object_tk", "Dampé"),
        ("object_toki_objects", "Misc. Temple of Time"),
        ("object_torch2", "Dark Link"),
        ("object_vase", "Pot"),
        ("object_vm", "Beamos"),
        ("object_wallmaster", "Wallmaster"),
        ("object_wf", "Wolfos"),
        ("object_xc", "Sheik"),
        ("object_ydan_objects", "Misc. Inside the Deku Tree"),
        ("object_zf", "Lizalfos"),
        ("object_zo", "Zora")
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