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
      public string FileName;
      public uint StartOffset;
      public uint EndOffset;
    }

    // TODO: Make private.
    public static IList<Segment> GetSegments(byte[] romBytes, uint segmentOffset, uint nameOffset) {
      var segments = new List<Segment>();

      bool bothZero;
      do {
        var startAddress = IoUtil.ReadUInt32(romBytes, segmentOffset);
        var endAddress = IoUtil.ReadUInt32(romBytes, segmentOffset + 4);
        
        bothZero = startAddress == 0 && endAddress == 0;
        if (!bothZero) {
          var fileNameBytes = new List<byte>();
          while (romBytes[nameOffset] == 0) {
            nameOffset++;
          }
          while(romBytes[nameOffset] != 0) {
            fileNameBytes.Add(romBytes[nameOffset++]);
          }
          var fileName =
              System.Text.Encoding.UTF8.GetString(
                  fileNameBytes.ToArray(),
                  0,
                  fileNameBytes.Count);

          segments.Add(new Segment {
              FileName = fileName,
              StartOffset = startAddress,
              EndOffset = endAddress
          });

          segmentOffset += 16;
        }
      } while (!bothZero);

      return segments;
    }
  }
}
