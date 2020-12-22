using System;
using System.Collections.Generic;

using MathNet.Numerics.LinearAlgebra;

using Tao.OpenGl;

namespace UoT {
  public interface IModelViewMatrixTransformer {
    IModelViewMatrixTransformer Push();
    IModelViewMatrixTransformer Pop();
    IModelViewMatrixTransformer Translate(double x, double y, double z);
    IModelViewMatrixTransformer Rotate(double angle, double x, double y, double z);
  }

  public static class ModelViewMatrixTransformer {
    private static IModelViewMatrixTransformer INSTANCE =
        new GlModelViewMatrixTransformer();

    public static IModelViewMatrixTransformer Push()
      => ModelViewMatrixTransformer.INSTANCE.Push();

    public static IModelViewMatrixTransformer Pop()
      => ModelViewMatrixTransformer.INSTANCE.Pop();

    public static IModelViewMatrixTransformer Translate(
        double x,
        double y,
        double z) => ModelViewMatrixTransformer.INSTANCE.Translate(x, y, z);

    public static IModelViewMatrixTransformer Rotate(
        double angle,
        double x,
        double y,
        double z) => ModelViewMatrixTransformer.INSTANCE.Rotate(angle, x, y, z);
  }


  public class GlModelViewMatrixTransformer : IModelViewMatrixTransformer {
    public IModelViewMatrixTransformer Push() {
      Gl.glPushMatrix();
      return this;
    }

    public IModelViewMatrixTransformer Pop() {
      Gl.glPopMatrix();
      return this;
    }

    public IModelViewMatrixTransformer Translate(double x, double y, double z) {
      Gl.glTranslated(x, y, z);
      return this;
    }

    public IModelViewMatrixTransformer Rotate(
        double angle,
        double x,
        double y,
        double z) {
      Gl.glRotated(angle, x, y, z);
      return this;
    }
  }

  public class SoftwareModelViewMatrixTransformer {
    private Matrix<double> current_;
    private Stack<Matrix<double>> stack_ = new Stack<Matrix<double>>();

    public SoftwareModelViewMatrixTransformer() {
      this.Push();
    }

    public void Push() {
      Matrix<double> newMatrix;
      if (this.current_ == null) {
        newMatrix = Matrix<double>.Build.DiagonalIdentity(4, 4);
      } else {
        newMatrix = this.current_.Clone();
      }

      this.stack_.Push(newMatrix);
      this.UpdateCurrent_();
    }

    public void Pop() {
      if (this.stack_.Count <= 1) {
        throw new Exception("Popped too far.");
      }

      this.stack_.Pop();
      this.UpdateCurrent_();
    }

    private void UpdateCurrent_() => this.current_ = this.stack_.Peek();
  }
}