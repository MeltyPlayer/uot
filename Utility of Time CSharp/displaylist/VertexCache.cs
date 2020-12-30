using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace UoT {
  public struct Vertex {
    public bool Populated;

    public short X;
    public short Y;
    public short Z;

    public short U;
    public short V;

    public byte R;
    public byte G;
    public byte B;
    public byte A;
  } 

  public class VertexCache {
    private readonly Vertex[] impl_;

    public VertexCache() {
      this.impl_ = new Vertex[32];
    }

    public void Reset() {
      for (var i = 0; i < this.impl_.Length; ++i) {
        this.impl_[i] = default;
      }
    }

    public Vertex this[int index] {
      get => this.impl_[index];
      set => this.impl_[index] = value;
    }
  }
}
