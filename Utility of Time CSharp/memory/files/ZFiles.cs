using System.Collections.Generic;
using System.IO;

namespace UoT.memory.files {
  public class ZFiles {
    public ZObj[] Objects;
    public ZCodeFiles[] ActorCode;
    public ZSc[] Levels;
    public ZOtherData[] Others;

    public static ZFiles FromRom(string filename) {
      var romBytes = ZFiles.LoadRomBytes(filename);

      //var segments = ZFiles.GetSegments_(romBytes);

      return null;
    }

    // TODO: Make private.
    public static byte[] LoadRomBytes(string filename) 
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
    public static IList<Segment> GetSegments(byte[] romBytes, uint segmentOffset) {
      var segments = new List<Segment>();

      bool bothZero;
      do {
        var startAddress = IoUtil.ReadUInt32(romBytes, segmentOffset);
        var endAddress = IoUtil.ReadUInt32(romBytes, segmentOffset + 4);
        
        bothZero = startAddress == 0 && endAddress == 0;
        if (!bothZero) {
          segments.Add(new Segment {
              StartAddress = startAddress,
              EndAddress = endAddress
          });

          segmentOffset += 16;
        }
      } while (!bothZero);

      return segments;
    }
  }
}
