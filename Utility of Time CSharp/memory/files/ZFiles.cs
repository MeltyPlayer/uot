using System.Collections.Generic;
using System.IO;

namespace UoT.memory.files {
  public class ZFiles {
    public ZObj[] Objects;
    public ZCodeFiles[] ActorCode;
    public ZSc[] Levels;
    public ZOtherData[] Others;

    public static ZFiles FromRom(string filename) {
      var romBytes = ZFiles.GetRomBytes(filename);

      //var segments = ZFiles.GetSegments_(romBytes);

      return null;
    }

    // TODO: Make private.
    public static byte[] GetRomBytes(string filename) 
      => File.ReadAllBytes(filename);

    public class Header {
    }

    // TODO: Make private.
    public static Header GetHeader() {
      return null;
    }

    public class Segment {
      public uint StartAddress;
      public uint EndAddress;
    }

    // TODO: Make private.
    public static Segment[] GetSegments(byte[] romBytes) {
      return null;
    }
  }
}
