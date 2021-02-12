using System;
using System.Collections.Generic;

using Tao.OpenGl;

using UoT.displaylist;
using UoT.limbs;
using UoT.util;

namespace UoT {
  public interface IDlModel {
    IList<IOldLimb> Limbs { get; }
  }

  public class Vec3d {
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }
  }


  public class StaticDlModel : IDlModel {
    // TODO: Prune unused values.
    // TODO: Split out vertices into separately indexed position/uv/color arrays.

    // TODO: How to separate limbs?
    // TODO: How to apply matrix to specific limb's vertices?
    // TODO: Keep track of texture params, combine modes, env colors, etc.
    // TODO: Support submeshes (e.g. held items).
    // TODO: Simplify some triangles to quads.
    // TODO: Separate common shader params as different materials.

    private bool isComplete_;

    public bool IsComplete {
      get => this.isComplete_;
      set {
        this.isComplete_ = value;

        this.projectedVertices_.Clear();
        if (value) {
          for (var i = 0; i < this.allVertices_.Count; ++i) {
            this.projectedVertices_.Add(new Vec3d());
          }
        }
      }
    }

    private LimbInstance? activeLimb_;
    private readonly int[] activeVertices_ = new int[32];
    private readonly int[] activeTextures_ = new int[2];

    // TODO: Needed for models w/o limbs.
    private LimbInstance? root_;

    private readonly IList<VertexParams>
        allVertices_ = new List<VertexParams>();

    private readonly IList<Vec3d>
        projectedVertices_ = new List<Vec3d>();

    private readonly IList<TextureWrapper> allTextures_ =
        new List<TextureWrapper>();

    private IList<LimbInstance> allLimbs_ = new List<LimbInstance>();
    public IList<IOldLimb> Limbs { get; } = new List<IOldLimb>();

    public void Reset() {
      this.IsComplete = false;

      for (var i = 0; i < this.activeVertices_.Length; ++i) {
        this.activeVertices_[i] = -1;
      }
      for (var i = 0; i < this.activeTextures_.Length; ++i) {
        this.activeTextures_[i] = -1;
      }

      this.root_ = new LimbInstance {
          firstChild = -1,
          nextSibling = -1
      };
      this.activeLimb_ = this.root_;

      // TODO: Clear vertices and textures.

      foreach (var limb in this.allLimbs_) {
        limb.Triangles.Clear();
        limb.OwnedVertices.Clear();
      }

      this.allLimbs_.Clear();
      this.Limbs.Clear();

      this.allVertices_.Clear();
      this.projectedVertices_.Clear();
      this.allTextures_.Clear();
    }

    public void DrawWithLimbMatrices(LimbMatrices limbMatrices) {
      // TODO: Then draw w/ projected vertices.
      // TODO: Add helper class for shader program.

      // TODO: Is the recursive stuff needed?

      ModelViewMatrixTransformer.Push();
      this.ForEachLimbRecursively_(
          0,
          limb => {
            if (limb.VisibleIndex == -1) {
              return;
            }

            var matrix =
                limbMatrices.GetMatrixForLimb((uint) limb.VisibleIndex);
            ModelViewMatrixTransformer.Set(matrix);

            foreach (var vertexIndex in limb.OwnedVertices) {
              var ownedVertex = this.allVertices_[vertexIndex];
              var projectedVertex = this.projectedVertices_[vertexIndex];

              var x = ownedVertex.X;
              var y = ownedVertex.Y;
              var z = ownedVertex.Z;

              ModelViewMatrixTransformer.ProjectVertex(ref x, ref y, ref z);

              projectedVertex.X = x;
              projectedVertex.Y = y;
              projectedVertex.Z = z;
            }
          });
      ModelViewMatrixTransformer.Pop();

      Gl.glDisable(Gl.GL_TEXTURE);

      this.ForEachLimbRecursively_(
          0,
          limb => {
            foreach (var triangle in limb.Triangles) {
              Gl.glColor3b(255, 255, 255);
              Gl.glBegin(Gl.GL_TRIANGLES);

              // TODO: Use texture.
              // TODO: Use color.
              // TODO: Use normal.
              // TODO: Use shader.

              // BindTextures(vertex)

              foreach (var vertexId in triangle.Vertices) {
                var vertex = this.projectedVertices_[vertexId];
                Gl.glVertex3d(vertex.X, vertex.Y, vertex.Z);

                /*If ShaderManager.EnableLighting Then
                If(Not ShaderManager.EnableCombiner) Then Gl.glColor4fv(ShaderManager.PrimColor) Else Gl.glColor3f(1, 1, 1)
                Gl.glVertexAttrib4f(ShaderManager.ColorLocation, 1, 1, 1, 1)
                Gl.glNormal3f(vertex.NormalX, vertex.NormalY, vertex.NormalZ)
                Gl.glVertexAttrib3f(ShaderManager.NormalLocation, vertex.NormalX, vertex.NormalY, vertex.NormalZ)
                Else
                Gl.glColor4ub(vertex.R, vertex.G, vertex.B, vertex.A)
                Gl.glVertexAttrib4f(ShaderManager.ColorLocation, vertex.R / 255.0F, vertex.G / 255.0F, vertex.B / 255.0F,
                                    vertex.A / 255.0F)
                ' Normal is invalid, but we have to pass a value in to prevent NaNs
                ' when normalizing in the shader.
                                          Gl.glVertexAttrib3f(ShaderManager.NormalLocation, 1, 1, 1)
                End If*/
              }

              Gl.glEnd();
            }
          });
    }

    private void ForEachLimbRecursively_(
        sbyte limbIndex,
        Action<LimbInstance> handler) {
      var limb = this.allLimbs_[limbIndex];

      handler(limb);

      var firstChildIndex = limb.firstChild;
      if (firstChildIndex > -1) {
        this.ForEachLimbRecursively_(firstChildIndex, handler);
      }

      var nextSiblingIndex = limb.nextSibling;
      if (nextSiblingIndex > -1) {
        this.ForEachLimbRecursively_(nextSiblingIndex, handler);
      }
    }

    public void AddLimb(
        bool visible,
        short x,
        short y,
        short z,
        sbyte firstChild,
        sbyte nextSibling) {
      if (this.IsComplete) {
        return;
      }

      var newLimb = new LimbInstance {
          Visible = visible,
          x = x,
          y = y,
          z = z,
          firstChild = firstChild,
          nextSibling = nextSibling
      };

      this.allLimbs_.Add(newLimb);
      this.Limbs.Add(newLimb);
    }

    public void CalculateVisibleLimbIndices() {
      var currentVisibleCount = 0;
      foreach (var limb in this.allLimbs_) {
        // TODO: Split this to check if bank is 0 instead?
        if (limb.Visible) {
          limb.VisibleIndex = currentVisibleCount++;
        } else {
          limb.VisibleIndex = -1;
        }
      }
    }

    public void SetCurrentVisibleLimbByMatrixAddress(uint matrixAddress)
      => this.SetCurrentVisibleLimbByIndex(
          LimbMatrices.ConvertAddressToVisibleLimbIndex(matrixAddress));

    public void SetCurrentVisibleLimbByIndex(uint visibleLimbIndex) {
      if (this.IsComplete) {
        return;
      }

      var limbIndex = -1;
      foreach (var limb in this.allLimbs_) {
        if (limb.VisibleIndex == visibleLimbIndex) {
          limbIndex = limb.VisibleIndex;
          break;
        }
      }
      Asserts.Assert(limbIndex > -1);

      this.activeLimb_ = this.allLimbs_[limbIndex];
    }

    public void AddTriangle(
        DlShaderParams shaderParams,
        int vertex1,
        int vertex2,
        int vertex3) {
      if (this.IsComplete) {
        return;
      }

      var textures = new int[2];
      for (var t = 0; t < 2; ++t) {
        textures[t] = this.activeTextures_[t];
      }

      var vertices = new int[3];
      vertices[0] = this.activeVertices_[vertex1];
      vertices[1] = this.activeVertices_[vertex2];
      vertices[2] = this.activeVertices_[vertex3];

      // TODO: Merge existing shader params.
      var triangle =
          new TriangleParams(shaderParams.Clone(), textures, vertices);
      Asserts.Assert(this.activeLimb_).Triangles.Add(triangle);
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

      Asserts.Assert(this.activeLimb_).OwnedVertices.Add(vertex.Uuid);
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

  public class LimbInstance : IOldLimb {
    public IList<TriangleParams> Triangles { get; } =
      new List<TriangleParams>();

    public IList<int> OwnedVertices { get; } = new List<int>();

    public bool Visible { get; set; }
    public int VisibleIndex { get; set; }

    public short x { get; set; }
    public short y { get; set; }
    public short z { get; set; }

    public sbyte firstChild { get; set; }
    public sbyte nextSibling { get; set; }
  }

  public class TriangleParams {
    public TriangleParams(
        DlShaderParams shaderParams,
        int[] textures,
        int[] vertices) {
      this.ShaderParams = shaderParams;
      this.Textures = textures;
      this.Vertices = vertices;
    }

    public DlShaderParams ShaderParams { get; }
    public int[] Textures { get; }
    public int[] Vertices { get; }
  }

  public struct VertexParams {
    public int Uuid { get; set; }

    public double X;
    public double Y;
    public double Z;

    public double U { get; set; }
    public double V { get; set; }

    public Normal? Normal { get; set; }
    public Rgba? Rgba { get; set; }
  }

  public struct TextureWrapper {
    public int Uuid;
    public Texture Texture;
  }

  public struct Normal {
    public double X { get; }
    public double Y { get; }
    public double Z { get; }
  }

  public struct Rgba {
    public double R { get; set; }
    public double G { get; set; }
    public double B { get; set; }
    public double A { get; set; }
  }
}