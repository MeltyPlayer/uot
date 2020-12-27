using System;
using System.Collections.Generic;

using MathNet.Numerics.LinearAlgebra;

using Tao.OpenGl;

namespace UoT {
  public interface IModelViewMatrixTransformer {
    IModelViewMatrixTransformer Push();
    IModelViewMatrixTransformer Pop();

    IModelViewMatrixTransformer Identity();

    IModelViewMatrixTransformer Translate(double x, double y, double z);

    IModelViewMatrixTransformer Rotate(
        double angle,
        double x,
        double y,
        double z);

    IModelViewMatrixTransformer MultMatrix(Matrix<double> m);
  }

  public static class ModelViewMatrixTransformer {
    private static IModelViewMatrixTransformer INSTANCE =
        new SoftwareModelViewMatrixTransformer();

    public static IModelViewMatrixTransformer Push()
      => ModelViewMatrixTransformer.INSTANCE.Push();

    public static IModelViewMatrixTransformer Pop()
      => ModelViewMatrixTransformer.INSTANCE.Pop();

    public static IModelViewMatrixTransformer Identity()
      => ModelViewMatrixTransformer.INSTANCE.Identity();

    public static IModelViewMatrixTransformer Translate(
        double x,
        double y,
        double z) => ModelViewMatrixTransformer.INSTANCE.Translate(x, y, z);

    public static IModelViewMatrixTransformer Rotate(
        double angle,
        double x,
        double y,
        double z) => ModelViewMatrixTransformer.INSTANCE.Rotate(angle, x, y, z);

    public static IModelViewMatrixTransformer MultMatrix(Matrix<double> m)
      => ModelViewMatrixTransformer.INSTANCE.MultMatrix(m);
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

    public IModelViewMatrixTransformer Identity() {
      Gl.glLoadIdentity();
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

    public IModelViewMatrixTransformer MultMatrix(Matrix<double> m)
      => throw new NotImplementedException();
  }

  public class
      SoftwareModelViewMatrixTransformer : IModelViewMatrixTransformer {
    private Matrix<double> current_;
    private Stack<Matrix<double>> stack_ = new Stack<Matrix<double>>();

    public SoftwareModelViewMatrixTransformer() {
      this.Push();
    }

    public IModelViewMatrixTransformer Push() {
      Matrix<double> newMatrix;
      if (this.current_ == null) {
        newMatrix = Matrix<double>.Build.DenseIdentity(4, 4);
      } else {
        newMatrix = this.current_.Clone();
      }

      this.stack_.Push(newMatrix);
      this.UpdateCurrent_();
      this.UpdateGl_();

      return this;
    }

    public IModelViewMatrixTransformer Pop() {
      if (this.stack_.Count <= 1) {
        throw new Exception("Popped too far.");
      }

      this.stack_.Pop();
      this.UpdateCurrent_();
      this.UpdateGl_();

      return this;
    }

    private void UpdateCurrent_() => this.current_ = this.stack_.Peek();

    private readonly Matrix<double> rhsBuffer_ =
        Matrix<double>.Build.DenseIdentity(4, 4);

    private readonly Matrix<double> resultBuffer_ =
        Matrix<double>.Build.DenseIdentity(4, 4);

    public IModelViewMatrixTransformer Identity() {
      this.current_.Clear();
      for (var i = 0; i < 4; ++i) {
        this.current_[i, i] = 1;
      }

      this.UpdateGl_();

      return this;
    }


    public IModelViewMatrixTransformer Translate(double x, double y, double z) {
      this.rhsBuffer_.Clear();
      for (var i = 0; i < 4; ++i) {
        this.rhsBuffer_[i, i] = 1;
      }
      this.rhsBuffer_[0, 3] = x;
      this.rhsBuffer_[1, 3] = y;
      this.rhsBuffer_[2, 3] = z;

      this.current_.Multiply(this.rhsBuffer_, this.resultBuffer_);

      this.resultBuffer_.CopyTo(this.current_);
      this.UpdateGl_();

      return this;
    }

    public IModelViewMatrixTransformer Rotate(
        double angle,
        double x,
        double y,
        double z) {
      // From https://www.csee.umbc.edu/portal/help/C++/opengl/man_pages/html/gl/rotate.html
      var len = Math.Sqrt(x * x + y * y + z * z);
      x /= len;
      y /= len;
      z /= len;

      var rads = angle / 180 * Math.PI;
      var c = Math.Cos(rads);
      var s = Math.Sin(rads);

      this.rhsBuffer_.Clear();
      this.rhsBuffer_[0, 0] = x * x * (1 - c) + c;
      this.rhsBuffer_[0, 1] = x * y * (1 - c) - z * s;
      this.rhsBuffer_[0, 2] = x * z * (1 - c) + y * s;

      this.rhsBuffer_[1, 0] = y * x * (1 - c) + z * s;
      this.rhsBuffer_[1, 1] = y * y * (1 - c) + c;
      this.rhsBuffer_[1, 2] = y * z * (1 - c) - x * s;

      this.rhsBuffer_[2, 0] = x * z * (1 - c) - y * s;
      this.rhsBuffer_[2, 1] = y * z * (1 - c) + x * s;
      this.rhsBuffer_[2, 2] = z * z * (1 - c) + c;

      this.rhsBuffer_[3, 3] = 1;


      this.current_.Multiply(this.rhsBuffer_, this.resultBuffer_);

      this.resultBuffer_.CopyTo(this.current_);
      this.UpdateGl_();

      return this;
    }

    public IModelViewMatrixTransformer MultMatrix(Matrix<double> m) {
      this.current_.Multiply(m, this.resultBuffer_);

      this.resultBuffer_.CopyTo(this.current_);
      this.UpdateGl_();

      return this;
    }


    private readonly double[] glBuffer_ = new double[16];

    private void UpdateGl_() {
      for (var r = 0; r < 4; ++r) {
        for (var c = 0; c < 4; ++c) {
          this.glBuffer_[4 * c + r] = this.current_[r, c];
        }
      }
      Gl.glLoadMatrixd(this.glBuffer_);
    }
  }
}