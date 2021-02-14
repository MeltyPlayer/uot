using System;
using System.Collections.Generic;
using System.Numerics;

using Tao.OpenGl;

using UoT.animation.playback;
using UoT.displaylist;
using UoT.limbs;
using UoT.util;

using SharpGLTF.Geometry;
using SharpGLTF.Geometry.VertexTypes;
using SharpGLTF.Materials;
using SharpGLTF.Schema2;
using SharpGLTF.Transforms;

using Buffer = SharpGLTF.Schema2.Buffer;

namespace UoT {
  using VERTEX =
      VertexBuilder<VertexPositionNormal, VertexColor1Texture2, VertexEmpty>;

  public interface IDlModel {
    IList<IOldLimb> Limbs { get; }
  }

  public class Vec3d : IVertex {
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }

    public short U { get; set; }
    public short V { get; set; }

    public float NormalX { get; set; }
    public float NormalY { get; set; }
    public float NormalZ { get; set; }

    public byte R { get; set; }
    public byte G { get; set; }
    public byte B { get; set; }
    public byte A { get; set; }
  }


  public class StaticDlModel : IDlModel {
    // TODO: Prune unused values.
    // TODO: Split out vertices into separately indexed position/uv/color arrays.

    // TODO: How to separate limbs?
    // TODO: Support submeshes (e.g. held items).
    // TODO: Simplify some triangles to quads.
    // TODO: Separate common shader params as different materials.

    // TODO: Add remainder of shader params for blend modes/etc.

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

    // TODO: Needed for models w/o limbs.
    private LimbInstance? root_;

    private readonly IList<VertexParams>
        allVertices_ = new List<VertexParams>();

    private readonly IList<Vec3d>
        projectedVertices_ = new List<Vec3d>();

    private readonly IList<Texture> allTextures_ = new List<Texture>();

    private readonly IList<LimbInstance> allLimbs_ = new List<LimbInstance>();
    public IList<IOldLimb> Limbs { get; } = new List<IOldLimb>();

    public void Reset() {
      this.IsComplete = false;

      for (var i = 0; i < this.activeVertices_.Length; ++i) {
        this.activeVertices_[i] = -1;
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
      }

      this.LimbMatrices.UpdateLimbMatrices(this.Limbs,
                                           animation,
                                           animationPlaybackManager);

      this.ForEachLimbRecursively_(
          0,
          (limb, limbIndex) => {
            if (false) {
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
            }

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

              projectedVertex.U = ownedVertex.U;
              projectedVertex.V = ownedVertex.V;

              double normalX = ownedVertex.NormalX;
              double normalY = ownedVertex.NormalY;
              double normalZ = ownedVertex.NormalZ;
              ModelViewMatrixTransformer.ProjectNormal(
                  ref normalX,
                  ref normalY,
                  ref normalZ);
              projectedVertex.NormalX = (float) normalX;
              projectedVertex.NormalY = (float) normalY;
              projectedVertex.NormalZ = (float) normalZ;

              projectedVertex.R = ownedVertex.R;
              projectedVertex.G = ownedVertex.G;
              projectedVertex.B = ownedVertex.B;
              projectedVertex.A = ownedVertex.A;
            }
          },
          (limb, _) => ModelViewMatrixTransformer.Pop());
      ModelViewMatrixTransformer.Pop();

      this.ForEachLimbRecursively_(
          0,
          (limb, _) => {
            foreach (var triangle in limb.Triangles) {
              this.shaderManager_.Params = triangle.ShaderParams;
              this.shaderManager_.PassValuesToShader();

              var textureIds = triangle.TextureIds;
              var texture0Id = textureIds[0];
              var texture1Id = textureIds[1];

              var texture0 = texture0Id > -1
                                 ? this.allTextures_[texture0Id]
                                 : null;
              var texture1 = texture1Id > -1
                                 ? this.allTextures_[texture1Id]
                                 : null;
              this.shaderManager_.BindTextures(texture0, texture1);

              Gl.glColor3b(255, 255, 255);
              Gl.glBegin(Gl.GL_TRIANGLES);

              var tileDescriptor0 = texture0?.TileDescriptor;
              var tileDescriptor1 = texture1?.TileDescriptor;

              foreach (var vertexId in triangle.Vertices) {
                var projectedVertex = this.projectedVertices_[vertexId];

                this.shaderManager_.BindTextureUvs(
                    projectedVertex,
                    tileDescriptor0,
                    tileDescriptor1);
                this.shaderManager_.PassInVertexAttribs(projectedVertex);
                Gl.glVertex3d(projectedVertex.X,
                              projectedVertex.Y,
                              projectedVertex.Z);
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

    public void SetCurrentLimbByMatrixAddress(uint matrixAddress)
      => this.SetCurrentLimbByVisibleLimbIndex(
          LimbMatrices.ConvertAddressToVisibleLimbIndex(matrixAddress));

    public void SetCurrentLimbByVisibleLimbIndex(uint visibleLimbIndex) {
      if (this.IsComplete) {
        return;
      }

      var limbIndex = -1;
      for (var i = 0; i < this.allLimbs_.Count; ++i) {
        var limb = this.allLimbs_[i];
        if (limb.VisibleIndex == visibleLimbIndex) {
          limbIndex = i;
          break;
        }
      }
      Asserts.Assert(limbIndex > -1);

      this.SetCurrentLimbByIndex(limbIndex);
    }

    public void SetCurrentLimbByIndex(int limbIndex) {
      if (this.IsComplete) {
        return;
      }
      this.activeLimb_ = this.allLimbs_[limbIndex];
    }

    public void AddTriangle(
        DlShaderParams shaderParams,
        int vertex1,
        int vertex2,
        int vertex3,
        Texture? texture0,
        Texture? texture1) {
      if (this.IsComplete) {
        return;
      }

      var textureIds = new[] {
          this.AddTexture_(texture0),
          this.AddTexture_(texture1),
      };
      var vertices = new int[3];
      vertices[0] = this.activeVertices_[vertex1];
      vertices[1] = this.activeVertices_[vertex2];
      vertices[2] = this.activeVertices_[vertex3];

// TODO: Merge existing shader params.
      var triangle =
          new TriangleParams(shaderParams.Clone(), textureIds, vertices);

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

    private int AddTexture_(Texture? texture) {
      if (this.IsComplete) {
        Asserts.Fail("Should not try to create a new texture when complete!");
      }

      if (texture == null) {
        return -1;
      }

      for (var i = 0; i < this.allTextures_.Count; ++i) {
        if (this.allTextures_[i].TileDescriptor.Uuid ==
            texture.TileDescriptor.Uuid) {
          return i;
        }
      }

      this.allTextures_.Add(texture);
      return this.allTextures_.Count - 1;
    }

    // TODO: Pull this out.
    public void SaveAsGlTf() {
      var path = "R:/Noesis/Model/test.gltf";

      var model = ModelRoot.CreateModel();

      var material = new MaterialBuilder("material1").WithUnlitShader();

      var skin = model.CreateSkin();

      var rootNode = model.CreateLogicalNode();

      var limbQueue = new Queue<(sbyte, Node)>();
      limbQueue.Enqueue((0, rootNode));

      // TODO: Use buffers for shader stuff?

      var scale = .01;
      while (limbQueue.Count > 0) {
        var (limbIndex, parentNode) = limbQueue.Dequeue();
        var limb = this.allLimbs_[limbIndex];

        var limbMeshBuilder = VERTEX.CreateCompatibleMesh();

        foreach (var triangle in limb.Triangles) {
          // TODO: Should be possible to merge these by texture/shader.

          var trianglePrimitive = limbMeshBuilder.UsePrimitive(material);

          var vtx1 = this.allVertices_[triangle.Vertices[0]];
          var vtx2 = this.allVertices_[triangle.Vertices[1]];
          var vtx3 = this.allVertices_[triangle.Vertices[2]];

          trianglePrimitive.AddTriangle(
              VERTEX.Create(new Vector3((float) (vtx1.X * scale),
                                        (float) (vtx1.Y * scale),
                                        (float) (vtx1.Z * scale))),
              VERTEX.Create(new Vector3((float) (vtx2.X * scale),
                                        (float) (vtx2.Y * scale),
                                        (float) (vtx2.Z * scale))),
              VERTEX.Create(new Vector3((float) (vtx3.X * scale),
                                        (float) (vtx3.Y * scale),
                                        (float) (vtx3.Z * scale))));
        }

        var limbMesh = model.CreateMesh(limbMeshBuilder);

        var node = parentNode.CreateNode()
                             .WithMesh(limbMesh)
                             .WithLocalTranslation(
                                 new Vector3((float) (limb.x * scale),
                                             (float) (limb.y * scale),
                                             (float) (limb.z * scale)));
        skin.BindJoints(node);

        // Enqueues children and siblings.
        var firstChildIndex = limb.firstChild;
        if (firstChildIndex > -1) {
          limbQueue.Enqueue((firstChildIndex, node));
        }

        var nextSiblingIndex = limb.nextSibling;
        if (nextSiblingIndex > -1) {
          limbQueue.Enqueue((nextSiblingIndex, parentNode));
        }
      }

      // TODO: Write animations.
      // TODO: Write textures.

      var writeSettings = new WriteSettings {
          JsonIndented = true,
          ImageWriting = ResourceWriteMode.Embedded
      };
      model.SaveGLTF(path, writeSettings);
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
        int[] textureIds,
        int[] vertices) {
      this.ShaderParams = shaderParams;

      this.TextureIds = textureIds;
      this.Vertices = vertices;
    }

    public DlShaderParams ShaderParams { get; }
    public int[] TextureIds { get; }
    public int[] Vertices { get; }
  }

  public struct VertexParams : IVertex {
    public int Uuid { get; set; }

    public double X;
    public double Y;
    public double Z;

    public short U { get; set; }
    public short V { get; set; }

    public float NormalX { get; set; }
    public float NormalY { get; set; }
    public float NormalZ { get; set; }

    public byte R { get; set; }
    public byte G { get; set; }
    public byte B { get; set; }
    public byte A { get; set; }
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