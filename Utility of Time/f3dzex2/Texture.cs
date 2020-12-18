using System;

namespace UoT {
  public static partial class Structs {
    public class Texture {
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

      // TODO: Make this method private.
      public void CalculateSize() {
        uint MaxTexel = 0U;
        uint Line_Shift = 0U;
        switch (this.TexFormat) {
          case 0:
          case 0x40: {
              MaxTexel = 4096U;
              Line_Shift = 4U;
              break;
            }

          case 0x60:
          case 0x80: {
              MaxTexel = 8192U;
              Line_Shift = 4U;
              break;
            }

          case 0x8:
          case 0x48: {
              MaxTexel = 2048U;
              Line_Shift = 3U;
              break;
            }

          case 0x68:
          case 0x88: {
              MaxTexel = 4096U;
              Line_Shift = 3U;
              break;
            }

          case 0x10:
          case 0x70: {
              MaxTexel = 2048U;
              Line_Shift = 2U;
              break;
            }

          case 0x50:
          case 0x90: {
              MaxTexel = 2048U;
              Line_Shift = 0U;
              break;
            }

          case 0x18: {
              MaxTexel = 1024U;
              Line_Shift = 2U;
              break;
            }
        }

        uint Line_Width = (uint)(this.LineSize << (int)Line_Shift);
        uint Tile_Width = (uint)(this.LRS - this.ULS + 1);
        uint Tile_Height = (uint)(this.LRT - this.ULT + 1);
        uint Mask_Width = (uint)(1 << this.MaskS);
        uint Mask_Height = (uint)(1 << this.MaskT);
        uint Line_Height = 0U;
        if (Line_Width > 0L) {
          Line_Height =
              (uint)Math.Min(MaxTexel / (double)Line_Width, Tile_Height);
        }

        if (this.MaskS > 0 & Mask_Width * Mask_Height <= MaxTexel) {
          this.Width = (int)Mask_Width;
        } else if (Tile_Width * Tile_Height <= MaxTexel) {
          this.Width = (int)Tile_Width;
        } else {
          this.Width = (int)Line_Width;
        }

        if (this.MaskT > 0 & Mask_Width * Mask_Height <= MaxTexel) {
          this.Height = (int)Mask_Height;
        } else if (Tile_Width * Tile_Height <= MaxTexel) {
          this.Height = (int)Tile_Height;
        } else {
          this.Height = (int)Line_Height;
        }

        uint Clamp_Width = 0U;
        uint Clamp_Height = 0U;
        if (this.CMS == 1) {
          Clamp_Width = Tile_Width;
        } else {
          Clamp_Width = (uint)this.Width;
        }

        if (this.CMT == 1) {
          Clamp_Height = Tile_Height;
        } else {
          Clamp_Height = (uint)this.Height;
        }

        if (Mask_Width > this.Width) {
          this.MaskS = (int)Functions.PowOf((ulong)this.Width);
          Mask_Width = (uint)(1 << this.MaskS);
        }

        if (Mask_Height > this.Height) {
          this.MaskT = (int)Functions.PowOf((ulong)this.Height);
          Mask_Height = (uint)(1 << this.MaskT);
        }

        if (this.CMS == 2 | this.CMS == 3) {
          this.RealWidth = (int)Functions.Pow2(Clamp_Width);
        } else if (this.CMS == 1) {
          this.RealWidth = (int)Functions.Pow2(Mask_Width);
        } else {
          this.RealWidth =
              (int)Functions.Pow2((ulong)this.Width);
        }

        if (this.CMT == 2 | this.CMT == 3) {
          this.RealHeight = (int)Functions.Pow2(Clamp_Height);
        } else if (this.CMT == 1) {
          this.RealHeight = (int)Functions.Pow2(Mask_Height);
        } else {
          this.RealHeight =
              (int)Functions.Pow2((ulong)this.Height);
        }

        this.ShiftS = 1.0d;
        this.ShiftT = 1.0d;
        if (this.TShiftS > 10d) {
          this.ShiftS = 1 << (int)(16d - this.TShiftS);
        } else if (this.TShiftS > 0d) {
          this.ShiftS /= 1 << (int)this.TShiftS;
        }

        if (this.TShiftT > 10d) {
          this.ShiftT = 1 << (int)(16d - this.TShiftT);
        } else if (this.TShiftT > 0d) {
          this.ShiftT /= 1 << (int)this.TShiftT;
        }

        this.TextureHRatio = this.T_Scale *
                                     this.ShiftT /
                                     32d /
                                     this.RealHeight;
        this.TextureWRatio = this.S_Scale *
                                     this.ShiftS /
                                     32d /
                                     this.RealWidth;
      }
    }
  }
}