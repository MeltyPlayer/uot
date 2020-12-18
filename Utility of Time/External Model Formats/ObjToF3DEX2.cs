using System;

namespace UoT {
  static class ObjToF3DEX2 {
    private static Structs.N64DisplayList[] tempDL = new Structs.N64DisplayList[1];
    private static Structs.N64Vertex[] tempVerts;
    private static Random rand = new Random();

    public static Structs.N64Vertex[] SplitVertices(ref OBJData.OBJModel OBJ) {
      Structs.N64Vertex[] verts;
      verts = new Structs.N64Vertex[1];
      int CurGroup = 0;
      int tracker = 31;
      {
        var withBlock = verts[0];
        withBlock.x = new short[32];
        withBlock.y = new short[32];
        withBlock.z = new short[32];
        withBlock.u = new short[32];
        withBlock.v = new short[32];
        withBlock.r = new byte[32];
        withBlock.g = new byte[32];
        withBlock.b = new byte[32];
        withBlock.a = new byte[32];
      }

      for (int i = 0, loopTo = OBJ.Parts.Length - 1; i <= loopTo; i++) {
        for (int i1 = 0, loopTo1 = OBJ.Parts[i].Faces.Length; i1 <= loopTo1; i1++) {
          {
            var withBlock1 = OBJ.Parts[i].Faces[i1];
            for (int i2 = 0; i2 <= 2; i2++) {
              switch (i2) {
                case 0: {
                    verts[CurGroup].x[tracker] = OBJ.Vertices[withBlock1.V1].x;
                    verts[CurGroup].y[tracker] = OBJ.Vertices[withBlock1.V1].y;
                    verts[CurGroup].z[tracker] = OBJ.Vertices[withBlock1.V1].z;
                    withBlock1.V1 = tracker * 2;
                    break;
                  }

                case 1: {
                    verts[CurGroup].x[tracker] = OBJ.Vertices[withBlock1.V2].x;
                    verts[CurGroup].y[tracker] = OBJ.Vertices[withBlock1.V2].y;
                    verts[CurGroup].z[tracker] = OBJ.Vertices[withBlock1.V2].z;
                    withBlock1.V2 = tracker * 2;
                    break;
                  }

                case 2: {
                    verts[CurGroup].x[tracker] = OBJ.Vertices[withBlock1.V3].x;
                    verts[CurGroup].y[tracker] = OBJ.Vertices[withBlock1.V3].y;
                    verts[CurGroup].z[tracker] = OBJ.Vertices[withBlock1.V3].z;
                    withBlock1.V3 = tracker * 2;
                    break;
                  }
              }

              verts[CurGroup].u[tracker] = unchecked((short)0xFFFF);
              verts[CurGroup].v[tracker] = unchecked((short)0xFFFF);
              verts[CurGroup].r[tracker] = (byte)rand.Next(0, 255);
              verts[CurGroup].g[tracker] = (byte)rand.Next(0, 255);
              verts[CurGroup].b[tracker] = (byte)rand.Next(0, 255);
              verts[CurGroup].a[tracker] = (byte)rand.Next(0, 255);
              tracker += 1;
            }
          }
        }

        if (tracker == 31) {
          tracker = 0;
          CurGroup += 1;
          Array.Resize(ref verts, CurGroup + 1);
          {
            var withBlock2 = verts[CurGroup];
            withBlock2.x = new short[32];
            withBlock2.y = new short[32];
            withBlock2.z = new short[32];
            withBlock2.u = new short[32];
            withBlock2.v = new short[32];
            withBlock2.r = new byte[32];
            withBlock2.g = new byte[32];
            withBlock2.b = new byte[32];
            withBlock2.a = new byte[32];
          }
        } else {
          tracker += 1;
        }
      }

      return verts;
    }

    public static Structs.N64DisplayList ConvertToF3DEX2(OBJData.OBJModel OBJ) {
      tempVerts = SplitVertices(ref OBJ);
      for (int i = 0, loopTo = OBJ.Parts.Length; i <= loopTo; i++) {
      }

      return default;
    }
  }
}