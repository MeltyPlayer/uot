using System;
using System.Collections.Generic;

namespace UoT {
  public class VboBuilder {
    // TODO: Prune unused values.
    // TODO: Split out vertices into separtely indexed position/uv/color arrays.

    public void Reset() {
      // TODO: Clear vertices and textures.

      this.allTriangles_.Clear();
      this.allVertices_.Clear();
      this.allTextures_.Clear();
    }

    private VertexParams[] activeVertices_ = new VertexParams[32];
    private TextureWrapper[] activeTextures_ = new TextureWrapper[2];

    private IList<TriangleParams> allTriangles_;
    private IList<VertexParams> allVertices_;

    public IList<TextureWrapper> allTextures_;

    public void AddTriangle(int vertex1, int vertex2, int vertex3) {
      var triangle = new TriangleParams();

      triangle.textures = new int[2];
      for (var t = 0; t < 2; ++t) {
        triangle.textures[t] = this.activeTextures_[t].uuid;
      }

      triangle.vertices = new int[3];
      triangle.vertices[0] = this.activeVertices_[vertex1].uuid;
      triangle.vertices[1] = this.activeVertices_[vertex2].uuid;
      triangle.vertices[2] = this.activeVertices_[vertex3].uuid;
    }

    public void UpdateVertex(
        int index,
        Func<VertexParams, VertexParams> modifier) {
      var vertex = this.activeVertices_[index];

      vertex = modifier(vertex);
      vertex.uuid = this.allVertices_.Count;

      this.activeVertices_[index] = vertex;
      this.allVertices_.Add(vertex);
    }

    public void UpdateTexture(int index, Texture texture) {
      var textureWrapper = this.activeTextures_[index];

      textureWrapper.texture = texture;
      textureWrapper.uuid = this.allTextures_.Count;

      this.activeTextures_[index] = textureWrapper;
      this.allTextures_.Add(textureWrapper);
    }
  }

  public struct TriangleParams {
    public int[] textures;
    public int[] vertices;
  }

  public struct VertexParams {
    public int uuid;

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
    public int uuid;
    public Texture texture;
  }
}