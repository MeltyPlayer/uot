
namespace UoT.memory.files {
  public enum ZFileType {
    OBJECT,
    CODE,
    SCENE,
    MAP,

    /// <summary>
    ///   A set of objects in a given map. These seem to be used to switch
    ///   between different versions of rooms.
    /// </summary>
    OBJECT_SET,
    OTHER,
  }

  public interface IZFile {
    ZFileType Type { get; }

    string FileName { get; set; }
    string BetterFileName { get; set; }

    int StartOffset { get; set; }
    int EndOffset { get; set; }
  }


  public class ZObj : IZFile {
    public ZFileType Type => ZFileType.OBJECT;
    public string FileName { get; set; }
    public string BetterFileName { get; set; }
    public int StartOffset { get; set; }
    public int EndOffset { get; set; }
  }


  public class ZCodeFiles : IZFile {
    public ZFileType Type => ZFileType.CODE;
    public string FileName { get; set; }
    public string BetterFileName { get; set; }
    public int StartOffset { get; set; }
    public int EndOffset { get; set; }
  }


  public class ZSc : IZFile {
    public ZFileType Type => ZFileType.SCENE;
    public string FileName { get; set; }
    public string BetterFileName { get; set; }
    public int StartOffset { get; set; }
    public int EndOffset { get; set; }

    public ZMap[] Maps;
  }

  public class ZMap : IZFile {
    public ZFileType Type => ZFileType.MAP;
    public string FileName { get; set; }
    public string BetterFileName { get; set; }
    public int StartOffset { get; set; }
    public int EndOffset { get; set; }

    public ZSc Scene;
  }

  public class ZObjectSet : IZFile {
    public ZFileType Type => ZFileType.OBJECT_SET;
    public string FileName { get; set; }
    public string BetterFileName { get; set; }
    public int StartOffset { get; set; }
    public int EndOffset { get; set; }
  }


  public class ZOtherData : IZFile {
    public ZFileType Type => ZFileType.OTHER;
    public string FileName { get; set; }
    public string BetterFileName { get; set; }
    public int StartOffset { get; set; }
    public int EndOffset { get; set; }
  }
}
