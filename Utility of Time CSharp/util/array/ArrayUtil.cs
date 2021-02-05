using System;

namespace UoT.util.array {
  public static class ArrayUtil {
    public static void ExtractTo<T>(
        T[] src,
        int srcOffset,
        out T[] dst,
        int dstOffset,
        int count) {
      dst = new T[count];
      ArrayUtil.CopyTo(src, srcOffset, dst, dstOffset, count);
    }

    public static void CopyTo<T>(
        T[] src,
        int srcOffset,
        T[] dst,
        int dstOffset,
        int count) {
      Asserts.Assert(srcOffset >= 0,
                     "Attempted to access a negative offset in src!");
      Asserts.Assert(dstOffset >= 0,
                     "Attempted to access a negative offset in src!");

      Asserts.Assert(count >= 0,
                     "Attempted to copy a negatively-sized region!");

      Asserts.Assert(srcOffset + count <= src.Length,
                     "Attempted to pull from block past length of dst!");
      Asserts.Assert(dstOffset + count <= dst.Length,
                     "Attempted to copy block past length of dst!");

      Array.ConstrainedCopy(src, srcOffset, dst, dstOffset, count);
    }
  }
}