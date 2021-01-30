using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace UoT.memory.files {
  public class ZFiles {
    public IReadOnlyList<ZObj> Objects;
    public IReadOnlyList<ZCodeFiles> ActorCode;
    public IReadOnlyList<ZSc> Scenes;
    public IReadOnlyList<ZOtherData> Others;

    private ZFiles(IList<ZObj> objects, IList<ZCodeFiles> actorCode, IList<ZSc> levels, IList<ZOtherData> others) {
      this.Objects = new ReadOnlyCollection<ZObj>(objects);
      this.ActorCode = new ReadOnlyCollection<ZCodeFiles>(actorCode);
      this.Scenes = new ReadOnlyCollection<ZSc>(levels);
      this.Others = new ReadOnlyCollection<ZOtherData>(others);
    }


    public static ZFiles? FromRom(string filename) {
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
    public static Header? GetHeader() => null;

    private class Segment {
      // Make nonnull via init, C#9
      public string FileName { get; set; }
      public uint StartOffset;
      public uint EndOffset;

      public Segment(string filename) {
        this.FileName = filename;
      }
    }

    private static IEnumerable<Segment> GetSegments_(byte[] romBytes, uint segmentOffset, uint nameOffset) {
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

          segments.Add(new Segment(fileName) {
              StartOffset = startAddress,
              EndOffset = endAddress
          });

          segmentOffset += 16;
        }
      } while (!bothZero);

      return segments;
    }

    public static ZFiles GetFiles(
        byte[] romBytes,
        uint segmentOffset,
        uint nameOffset) {
      var segments = ZFiles.GetSegments_(romBytes, segmentOffset, nameOffset);

      var objects = new List<ZObj>();
      var actorCode = new List<ZCodeFiles>();
      var scenes = new LinkedList<ZSc>();
      var others = new List<ZOtherData>();

      foreach(var segment in segments) {
        var fileName = segment.FileName;
        var betterFileName = BetterFileNames.Get(fileName);

        IZFile file;
        if (fileName.StartsWith("object_")) {
          var obj = new ZObj();
          file = obj;

          objects.Add(obj);
        }
        else if (fileName.StartsWith("ovl_")) {
          var ovl = new ZCodeFiles();
          file = ovl;

          actorCode.Add(ovl);
        }
        else if (fileName.EndsWith("_scene")) {
          var scene = new ZSc();
          file = scene;

          scenes.AddLast(scene);
        } else if (fileName.Contains("_room")) {
          var scene = scenes.Last.Value;

          var map = new ZMap { Scene = scene };
          file = map;

          var mapCount = scene.Maps?.Length ?? 0; 
          Array.Resize(ref scene.Maps, mapCount + 1);
          scene.Maps[mapCount] = map;
        }
        else {
          var other = new ZOtherData();
          file = other;

          others.Add(other);
        }

        file.FileName = fileName; 
        file.BetterFileName = betterFileName;
        file.StartOffset = (int) segment.StartOffset;
        file.EndOffset = (int)segment.EndOffset;
      }

      return new ZFiles(objects, actorCode, scenes.ToArray(), others);
    }
  }
}
