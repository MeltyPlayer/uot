namespace UoT {
  public struct Texture {
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
    public int PalBank;
    public int Offset;
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
  }
}
