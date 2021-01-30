using System;

namespace UoT.util {
  public static class Asserts {
    public static void Fail(string? message = null) {
      if (message != null) {
        throw new AssertionException(message);
      } else {
        throw new AssertionException();
      }
    }

    public static T Assert<T>(T? value, string? message = null)
        where T : class {
      if (value == null) {
        Asserts.Fail(message);
      }
      return value!;
    }

    private class AssertionException : Exception {
      public AssertionException() : base() {}

      public AssertionException(string message) : base(message) {}

      public AssertionException(string message, Exception innerException) :
          base(message, innerException) {}
    }
  }
}