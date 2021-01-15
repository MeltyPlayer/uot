using System;
using System.Collections.Generic;

using Tao.OpenGl;

namespace UoT {
  public class StaticDlModel {
    // TODO: Prune unused values.
    // TODO: Split out vertices into separately indexed position/uv/color arrays.

    // TODO: How to separate limbs?
    // TODO: How to apply matrix to specific limb's vertices?
    // TODO: Keep track of texture params, combine modes, env colors, etc.
    // TODO: Support submeshes (e.g. held items).
    // TODO: Simplify some triangles to quads.
    // TODO: Separate common shader params as different materials.

    public bool IsComplete { get; set; }

    private LimbInstance activeLimb_;
    private int[] activeVertices_ = new int[32];
    private int[] activeTextures_ = new int[2];

    // TODO: Needed for models w/o limbs.
    private LimbInstance root_;

    private IList<LimbInstance> allLimbs_ = new List<LimbInstance>();
    private IList<VertexParams> allVertices_ = new List<VertexParams>();

    public IList<TextureWrapper> allTextures_ = new List<TextureWrapper>();

    public void Reset() {
      this.IsComplete = false;

      for (var i = 0; i < this.activeVertices_.Length; ++i) {
        this.activeVertices_[i] = -1;
      }
      for (var i = 0; i < this.activeTextures_.Length; ++i) {
        this.activeTextures_[i] = -1;
      }

      this.root_ = new LimbInstance {
          Triangles = new List<TriangleParams>(),
          OwnedVertices = new List<int>(),
          FirstChild = -1,
          NextSibling = -1
      };
      this.SetCurrentLimb(-1);

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
      // TODO: Include animations directly in this model.
      // TODO: Project vertices first.
      // TODO: Then draw w/ projected vertices.
      // TODO: Add helper class for shader program.

      foreach (var limb in this.allLimbs_) {
        foreach (var triangle in limb.Triangles) {
          Gl.glBegin(Gl.GL_TRIANGLES);

          // TODO: Draw.

          Gl.glEnd();
        }
      }
    }

    public void AddLimb(double x, double y, double z, int firstChild, int nextSibling) {
      if (this.IsComplete) {
        return;
      }

      this.allLimbs_.Add(new LimbInstance {
          Triangles = new List<TriangleParams>(),
          OwnedVertices = new List<int>(),
          X = x,
          Y = y,
          Z = z,
          FirstChild = firstChild,
          NextSibling = nextSibling
      });
    }

    public void SetCurrentLimb(int limb) {
      if (this.IsComplete) {
        return;
      }

      if (limb == -1) {
        this.activeLimb_ = this.root_;
      } else {
        this.activeLimb_ = this.allLimbs_[limb];
      }
    }

    public void AddTriangle(int vertex1, int vertex2, int vertex3) {
      if (this.IsComplete) {
        return;
      }

      var triangle = new TriangleParams();

      triangle.Textures = new int[2];
      for (var t = 0; t < 2; ++t) {
        triangle.Textures[t] = this.activeTextures_[t];
      }

      triangle.Vertices = new int[3];
      triangle.Vertices[0] = this.activeVertices_[vertex1];
      triangle.Vertices[1] = this.activeVertices_[vertex2];
      triangle.Vertices[2] = this.activeVertices_[vertex3];

      this.activeLimb_.Triangles.Add(triangle);
    }

    public void UpdateVertex(
        int index,
        Func<VertexParams, VertexParams> modifier) {
      if (this.IsComplete) {
        return;
      }

      VertexParams vertex;
      var oldUuid = this.activeVertices_[index];
      if (oldUuid == -1) {
        vertex = new VertexParams();
      } else {
        vertex = this.allVertices_[oldUuid];
      }

      vertex = modifier(vertex);
      vertex.Uuid = this.allVertices_.Count;

      this.activeLimb_.OwnedVertices.Add(vertex.Uuid);
      this.activeVertices_[index] = vertex.Uuid;
      this.allVertices_.Add(vertex);
    }

    public void UpdateTexture(int index, Texture texture) {
      if (this.IsComplete) {
        return;
      }

      if (texture == null) {
        this.activeTextures_[index] = -1;
        return;
      }

      var textureWrapper = new TextureWrapper {
          Uuid = this.allTextures_.Count,
          Texture = texture
      };

      this.activeTextures_[index] = textureWrapper.Uuid;
      this.allTextures_.Add(textureWrapper);
    }
  }

  public class LimbInstance {
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