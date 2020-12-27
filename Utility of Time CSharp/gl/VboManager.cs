using System;
using System.Collections.Generic;

using Tao.OpenGl;

namespace UoT {
  public class VboManager {
    // TODO: Prune unused values.
    // TODO: Split out vertices into separately indexed position/uv/color arrays.

    // TODO: How to separate limbs?
    // TODO: How to apply matrix to specific limb's vertices?
    // TODO: How to 

    public bool IsComplete { get; set; }

    private int activeLimb_;
    private int[] activeVertices_ = new int[32];
    private int[] activeTextures_ = new int[2];

    private IList<LimbParams> allLimbs_ = new List<LimbParams>();
    private IList<VertexParams> allVertices_ = new List<VertexParams>();

    public IList<TextureWrapper> allTextures_ = new List<TextureWrapper>();

    public void Reset() {
      this.activeLimb_ = -1;
      for (var i = 0; i < this.activeVertices_.Length; ++i) {
        this.activeVertices_[i] = -1;
      }
      for (var i = 0; i < this.activeTextures_.Length; ++i) {
        this.activeTextures_[i] = -1;
      }

      // TODO: Clear vertices and textures.

      foreach (var limb in this.allLimbs_) {
        limb.Triangles.Clear();
        limb.OwnedVertices.Clear();
      }

      this.allLimbs_.Clear();
      this.allVertices_.Clear();
      this.allTextures_.Clear();
    }

    public void DrawWithAnimation(IAnimation animation, double frame) {
      // TODO: Project vertices first.
      // TODO: Then draw w/ projected vertices.

      foreach (var limb in this.allLimbs_) {
        foreach (var triangle in limb.Triangles) {
          Gl.glBegin(Gl.GL_TRIANGLES);
          Gl.glEnd();
        }
      }
    }

    public void AddLimb(double x, double y, double z, int firstChild, int nextSibling) {
      this.allLimbs_.Add(new LimbParams {
          Triangles = new List<TriangleParams>(),
          OwnedVertices = new List<int>()
      });
    }

    public void SetCurrentLimb(int limb) => this.activeLimb_ = limb;

    public void AddTriangle(int vertex1, int vertex2, int vertex3) {
      var triangle = new TriangleParams();

      triangle.Textures = new int[2];
      for (var t = 0; t < 2; ++t) {
        triangle.Textures[t] = this.allTextures_[this.activeTextures_[t]].Uuid;
      }

      triangle.Vertices = new int[3];
      triangle.Vertices[0] =
          this.allVertices_[this.activeVertices_[vertex1]].Uuid;
      triangle.Vertices[1] =
          this.allVertices_[this.activeVertices_[vertex2]].Uuid;
      triangle.Vertices[2] =
          this.allVertices_[this.activeVertices_[vertex3]].Uuid;

      this.allLimbs_[this.activeLimb_].Triangles.Add(triangle);
    }

    public void UpdateVertex(
        int index,
        Func<VertexParams, VertexParams> modifier) {
      VertexParams vertex;
      var oldUuid = this.activeVertices_[index];
      if (oldUuid == -1) {
        vertex = new VertexParams();
      } else {
        vertex = this.allVertices_[oldUuid];
      }

      vertex = modifier(vertex);
      vertex.Uuid = this.allVertices_.Count;

      this.allLimbs_[this.activeLimb_].OwnedVertices.Add(vertex.Uuid);
      this.activeVertices_[index] = vertex.Uuid;
      this.allVertices_.Add(vertex);
    }

    public void UpdateTexture(int index, Texture texture) {
      var textureWrapper = new TextureWrapper {
          Uuid = this.allTextures_.Count,
          Texture = texture
      };

      this.activeTextures_[index] = textureWrapper.Uuid;
      this.allTextures_.Add(textureWrapper);
    }
  }

  public struct LimbParams {
    public IList<TriangleParams> Triangles;
    public IList<int> OwnedVertices;

    public double X;
    public double Y;
    public double Z;

    public int FirstChild;
    public int NextSibling;
  }

  public struct TriangleParams {
    public int[] Textures;
    public int[] Vertices;
  }

  public struct VertexParams {
    public int Uuid;

    public double X;
    public double Y;
    public double Z;

    public double U;
    public double V;

    public double R;
    public double G;
    public double B;
    public double A;
  }

  public struct TextureWrapper {
    public int Uuid;
    public Texture Texture;
  }
}