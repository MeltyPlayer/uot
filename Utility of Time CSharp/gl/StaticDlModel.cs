using System;
using System.Collections.Generic;

using Tao.OpenGl;

using UoT.animation.playback;
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

    private readonly DlShaderManager shaderManager_;
    private bool isComplete_;

    public StaticDlModel(DlShaderManager shaderManager) {
      this.shaderManager_ = shaderManager;
    }


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

    private readonly IList<LimbInstance> allLimbs_ = new List<LimbInstance>();
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

    public LimbMatrices LimbMatrices { get; } = new LimbMatrices();

    public void Draw(
        IAnimation animation,
        IAnimationPlaybackManager animationPlaybackManager) {
      // TODO: Then draw w/ projected vertices.
      // TODO: Add helper class for shader program.

      // TODO: Is the recursive stuff needed?

      // TODO: Why aren't bones working?

      ModelViewMatrixTransformer.Push();

      if (animation != null) {
        var frame = animationPlaybackManager.Frame;
        var totalFrames = animationPlaybackManager.TotalFrames;

        var frameIndex = (int) Math.Floor(frame);
        var frameDelta = frame % 1;

        var startPos = animation.GetPosition(frameIndex);
        var endPos = animation.GetPosition((frameIndex + 1) % totalFrames);

        var f = frameDelta;

        var x = startPos.X * (1 - f) + endPos.X * f;
        var y = startPos.Y * (1 - f) + endPos.Y * f;
        var z = startPos.Z * (1 - f) + endPos.Z * f;

        ModelViewMatrixTransformer.Translate(x, y, z);

        /*If indirectTextureHack IsNot Nothing Then
            Dim face As FacialState = CurrAnimation.GetFacialState(frameIndex)
        indirectTextureHack.EyeState = face.EyeState
        indirectTextureHack.MouthState = face.MouthState
        End If*/

        this.LimbMatrices.UpdateLimbMatrices(this.Limbs,
                                             animation,
                                             animationPlaybackManager);
      }

      this.ForEachLimbRecursively_(
          0,
          (limb, limbIndex) => {
            var xI = 0.0;
            var yI = 0.0;
            var zI = 0.0;
            ModelViewMatrixTransformer.ProjectVertex(ref xI, ref yI, ref zI);

            double xF = limb.x;
            double yF = limb.y;
            double zF = limb.z;
            ModelViewMatrixTransformer.ProjectVertex(ref xF, ref yF, ref zF);

            Gl.glDepthRange(0, 0);
            Gl.glLineWidth(9);
            Gl.glBegin(Gl.GL_LINES);
            Gl.glColor3f(1, 1, 1);
            Gl.glVertex3d(xI, yI, zI);
            Gl.glVertex3d(xF, yF, zF);
            Gl.glEnd();
            Gl.glDepthRange(0, -0.5);
            Gl.glPointSize(11);
            Gl.glBegin(Gl.GL_POINTS);
            Gl.glColor3f(0, 0, 0);
            Gl.glVertex3d(xF, yF, zF);
            Gl.glEnd();
            /*Gl.glPointSize(8);
            Gl.glBegin(Gl.GL_POINTS);
            Gl.glColor3ub(BoneColorFactor.r,
                          BoneColorFactor.g,
                          BoneColorFactor.b);
            Gl.glVertex3f(xF, yF, zF);
            Gl.glEnd();*/
            Gl.glPointSize(1);
            Gl.glLineWidth(1);
            Gl.glDepthRange(0, 1);

            ModelViewMatrixTransformer.Push();

            var matrix = this.LimbMatrices.GetMatrixForLimb((uint) limbIndex);
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
          },
          (limb, _) => {
            ModelViewMatrixTransformer.Pop();
          });
      ModelViewMatrixTransformer.Pop();

      this.ForEachLimbRecursively_(
          0,
          (limb, _) => {
            foreach (var triangle in limb.Triangles) {
              this.shaderManager_.Params = triangle.ShaderParams;
              this.shaderManager_.PassValuesToShader();

              Gl.glColor3b(255, 255, 255);
              Gl.glBegin(Gl.GL_TRIANGLES);

              // TODO: Use texture.
              // TODO: Use color.
              // TODO: Use normal.
              // TODO: Use shader.

              var textures = triangle.Textures;
              var texture0 = textures[0] > -1
                                 ? this.allTextures_[textures[0]].Texture
                                 : null;
              var texture1 = textures[1] > -1
                                 ? this.allTextures_[textures[1]].Texture
                                 : null;
              this.shaderManager_.BindTextures(texture0, texture1);

              foreach (var vertexId in triangle.Vertices) {
                var vertex = this.projectedVertices_[vertexId];

                //this.shaderManager_.PassInVertexAttribs(vertex);
                Gl.glVertex3d(vertex.X, vertex.Y, vertex.Z);
              }

              Gl.glEnd();
            }
            Gl.glFinish();
          },
          null);
    }

    private void ForEachLimbRecursively_(
        sbyte limbIndex,
        Action<LimbInstance, sbyte>? beforeChildren,
        Action<LimbInstance, sbyte>? afterChildren) {
      var limb = this.allLimbs_[limbIndex];
      beforeChildren?.Invoke(limb, limbIndex);

      var firstChildIndex = limb.firstChild;
      if (firstChildIndex > -1) {
        this.ForEachLimbRecursively_(firstChildIndex,
                                     beforeChildren,
                                     afterChildren);
      }

      afterChildren?.Invoke(limb, limbIndex);

      var nextSiblingIndex = limb.nextSibling;
      if (nextSiblingIndex > -1) {
        this.ForEachLimbRecursively_(nextSiblingIndex,
                                     beforeChildren,
                                     afterChildren);
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