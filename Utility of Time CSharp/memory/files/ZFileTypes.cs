
namespace UoT.memory.files {
  public enum ZFileType {
    OBJECT,
    CODE,
    SCENE,
    MAP,
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


  public class ZOtherData : IZFile {
    public ZFileType Type => ZFileType.OTHER;
    public string FileName { get; set; }
    public string BetterFileName { get; set; }
    public int StartOffset { get; set; }
    public int EndOffset { get; set; }
  }
}
