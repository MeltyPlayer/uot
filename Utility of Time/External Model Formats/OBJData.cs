using System.IO;

namespace UoT {
  public static class OBJData {
    public struct OBJVert {
      public short x;
      public short y;
      public short z;
      public byte r;
      public byte g;
      public byte b;
      public byte a;
    }

    public struct OBJUV {
      public short s;
      public short t;
    }

    public struct OBJNormal {
      public short x;
      public short y;
      public short z;
    }

    public struct OBJFace {
      public int V1;
      public int V2;
      public int V3;
      public int uV1;
      public int uV2;
      public int uV3;
      public int nV1;
      public int nV2;
      public int nV3;
    }

    public struct SettileParams {
      public int CMS;
      public int CMT;
      public int ULS;
      public int ULT;
      public int LRS;
      public int LRT;
    }

    public struct MTLTexture {
      public byte[] Data;
      public int bpp;
      public int width;
      public int height;
    }

    public struct OBJMTL {
      public string mtlId;
      public string texFile;
      public MTLTexture[] Textures;
    }

    public struct OBJGroup {
      public string grpId;
      public OBJMTL[] Materials;
      public OBJFace[] Faces;
    }

    public struct OBJModel {
      public StreamReader mtlFile;
      public OBJVert[] Vertices;
      public OBJUV[] TexCoords;
      public OBJNormal[] Normals;
      public OBJGroup[] Parts;
    }
  }
}