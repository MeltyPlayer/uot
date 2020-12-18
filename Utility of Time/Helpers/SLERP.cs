
namespace UoT {
  public class SLERP {
    public long startTick;
    public double startValue;
    public long endTick;
    public double endValue;

    public double getValue(long longTick) {
      double getValueRet = default;
      getValueRet = (longTick - startTick) / (double)(endTick - startTick);
      getValueRet = startValue + (endValue - startValue) * getValueRet;
      return getValueRet;
    }
  }
}