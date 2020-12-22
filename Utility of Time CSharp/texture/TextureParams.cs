namespace UoT {
  /// <summary>
  ///   Params needed to generate a texture.
  ///
  ///   This *must* be a struct for now, as the parser expects for data to be
  ///   copied by value instead of by reference.
  /// </summary>
  public struct TextureParams {
    // TODO: Get rid of this field.
    public int ID;
    public int DXT;
    public int Height;
    public int Width;
    public int RealWidth;
    public int RealHeight;
    public double TextureHRatio;
    public double TextureWRatio;
    public uint TexBytes;
    public int ImageBank;
    // TODO: Are PAL-specific fields needed?
    public int PalBank;
    public int Offset;
    // TODO: Are PAL-specific fields needed?
    public int PalOff;
    public int TexFormat;
    public int TexelSize;
    public int CMS;
    public int CMT;
    public double S_Scale;
    public double T_Scale;
    public double ShiftS;
    public double ShiftT;
    public double TShiftS;
    public double TShiftT;
    public int MaskS;
    public int MaskT;
    public int LineSize;
    public int ULS;
    public int ULT;
    public int LRS;
    public int LRT;
    public uint OGLTexObj;
    public Color4UByte[] Palette32;

    public long Uuid {
      get {
        long offset = this.Offset;
        long imageBank = this.ImageBank;

        return offset << 32 | imageBank;
      }
    }
  }
}
