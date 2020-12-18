
namespace UoT {
  static class MatrixManipulation {
    public static double[,] MultMatrix(double[,] res, double[,] mf, double[,] nf) {
      int i, j, k;
      var tmp = new double[4, 4];
      for (i = 0; i <= 3; i++) {
        for (j = 0; j <= 3; j++) {
          tmp[i, j] = 0.0d;
          for (k = 0; k <= 3; k++)
            tmp[i, j] = mf[i, k] * nf[k, j];
        }
      }

      return tmp;
    }

    public static object CopyMatrix(double[,] src, double[,] dst) {
      for (int i = 0; i <= 3; i++) {
        for (int j = 0; j <= 3; j++)
          dst[i, j] = src[i, j];
      }

      return default;
    }
  }
}