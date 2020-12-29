using System;

namespace UoT {
  public static class Time {
    public static double CurrentFrac { get; private set; }

    public static void UpdateCurrent() {
      TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
      Time.CurrentFrac = t.TotalSeconds % 1;
    }
  }
}
