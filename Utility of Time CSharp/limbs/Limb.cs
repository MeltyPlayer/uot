namespace UoT.limbs {
  public struct Limb {
    /// <summary>
    ///   Limb hierarchies include invisible entries, but matrices are indexed
    ///   by *visible* index.
    /// </summary>
    public int VisibleIndex;

    public double r;
    public double g;
    public double b;
    public short x;
    public short y;
    public short z;
    public sbyte firstChild;
    public sbyte nextSibling;
    public uint DisplayListAddress;
    public uint DisplayListLow;
  }
}
