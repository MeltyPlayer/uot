using NUnit.Framework;

namespace UoT.helpers {
  public class FunctionsTest {
    [Test]
    public void TestReadUInt24() {
      var buffer = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7 };
      Assert.AreEqual(66051, FunctionsCs.ReadUInt24(buffer, 1));
    }

    [Test]
    public void TestReadUInt32() {
      var buffer = new byte[] {0, 1, 2, 3, 4, 5, 6, 7};
      Assert.AreEqual(16909060, FunctionsCs.ReadUInt32(buffer, 1));
    }
  }
}