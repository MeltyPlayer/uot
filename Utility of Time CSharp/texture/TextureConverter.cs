using Microsoft.VisualBasic.CompilerServices;

namespace UoT {
  public class TextureUpscaler {
    private static int SourceTexPos = 0;
    private static int DestTexPos = 0;

    public class RGBA {
      public object RGBA16(uint Width, uint Height, uint LineSize, byte[] SourceImg, ref byte[] DestImg) {
        ushort RGBA5551 = 0;
        DestImg = new byte[(int)(Width * Height * 8L + 1)];
        for (int i = 0, loopTo = (int)(Height - 1L); i <= loopTo; i++) {
          for (int j = 0, loopTo1 = (int)(Width - 1L); j <= loopTo1; j++) {
            RGBA5551 = FunctionsCs.ReadUInt16(SourceImg, (uint)SourceTexPos);
            DestImg[DestTexPos] = (byte)((RGBA5551 & 0xF800) >> 8);
            DestImg[DestTexPos + 1] = (byte)((RGBA5551 & 0x7C0) << 5 >> 8);
            DestImg[DestTexPos + 2] = (byte)((RGBA5551 & 0x3E) << 18 >> 16);
            if (Conversions.ToBoolean(RGBA5551 & 1))
              DestImg[DestTexPos + 3] = 255;
            else
              DestImg[DestTexPos + 3] = 0;
            SourceTexPos += 2;
            DestTexPos += 4;
          }

          SourceTexPos = (int)(SourceTexPos + (LineSize * 4L - Width));
        }

        SourceTexPos = 0;
        DestTexPos = 0;
        return default;
      }
    }

    public class CI {
      private byte[] PaletteIndex = new byte[2];

      public object CI4(uint Width, uint Height, uint LineSize, byte[] SourceImg, ref byte[] DestImg, Color4UByte[] Palette) {
        DestImg = new byte[(int)(Width * Height * 8L + 1)];
        for (int i = 0, loopTo = (int)(Height - 1L); i <= loopTo; i++) {
          for (int j = 0, loopTo1 = (int)(Width - 1L); j <= loopTo1; j++) {
            PaletteIndex[0] = SourceImg[SourceTexPos];
            DestImg[DestTexPos] = Palette[PaletteIndex[0]].r;
            DestImg[DestTexPos + 1] = Palette[PaletteIndex[0]].g;
            DestImg[DestTexPos + 2] = Palette[PaletteIndex[0]].b;
            DestImg[DestTexPos + 3] = Palette[PaletteIndex[0]].a;
            SourceTexPos += 1;
            DestTexPos += 4;
          }

          SourceTexPos = (int)(SourceTexPos + (LineSize * 8L - Width));
        }

        SourceTexPos = 0;
        DestTexPos = 0;
        return default;
      }

      public object CI8(uint Width, uint Height, uint LineSize, byte[] SourceImg, ref byte[] DestImg, Color4UByte[] Palette) {
        DestImg = new byte[(int)(Width * Height * 8L + 1)];
        for (int i = 0, loopTo = (int)(Height - 1L); i <= loopTo; i++) {
          for (int j = 0, loopTo1 = (int)(Width / 2L - 1L); j <= loopTo1; j++) {
            PaletteIndex[0] = (byte)((SourceImg[SourceTexPos] & 0xF0) >> 4);
            PaletteIndex[1] = (byte)(SourceImg[SourceTexPos] & 0xF);
            DestImg[DestTexPos] = Palette[PaletteIndex[0]].r;
            DestImg[DestTexPos + 1] = Palette[PaletteIndex[0]].g;
            DestImg[DestTexPos + 2] = Palette[PaletteIndex[0]].b;
            DestImg[DestTexPos + 3] = Palette[PaletteIndex[0]].a;
            DestImg[DestTexPos + 4] = Palette[PaletteIndex[1]].r;
            DestImg[DestTexPos + 5] = Palette[PaletteIndex[1]].g;
            DestImg[DestTexPos + 6] = Palette[PaletteIndex[1]].b;
            DestImg[DestTexPos + 7] = Palette[PaletteIndex[1]].a;
            SourceTexPos += 1;
            DestTexPos += 8;
          }

          SourceTexPos = (int)(SourceTexPos + (LineSize * 8L - Width / 2L));
        }

        SourceTexPos = 0;
        DestTexPos = 0;
        return default;
      }
    }

    public class I {
      public object I4(uint Width, uint Height, uint LineSize, byte[] SourceImg, ref byte[] DestImg) {
        DestImg = new byte[(int)(Width * Height * 8L + 1)];
        for (int i = 0, loopTo = (int)(Height - 1L); i <= loopTo; i++) {
          for (int j = 0, loopTo1 = (int)(Width / 2L - 1L); j <= loopTo1; j++) {
            var IIntensity = SourceImg[SourceTexPos] >> 4;
            DestImg[DestTexPos] = (byte)(IIntensity * 17);
            DestImg[DestTexPos + 1] = (byte)(IIntensity * 17);
            DestImg[DestTexPos + 2] = (byte)(IIntensity * 17);
            DestImg[DestTexPos + 3] = 255;
            IIntensity = SourceImg[SourceTexPos] << 4 >> 4;
            DestImg[DestTexPos + 4] = (byte)(IIntensity * 17);
            DestImg[DestTexPos + 5] = (byte)(IIntensity * 17);
            DestImg[DestTexPos + 6] = (byte)(IIntensity * 17);
            DestImg[DestTexPos + 7] = 255;
            SourceTexPos += 1;
            DestTexPos += 8;
          }

          SourceTexPos = (int)(SourceTexPos + (LineSize * 8L - Width / 2L));
        }

        SourceTexPos = 0;
        DestTexPos = 0;
        return default;
      }

      public object I8(uint Width, uint Height, uint LineSize, byte[] SourceImg, ref byte[] DestImg) {
        DestImg = new byte[(int)(Width * Height * 8L + 1)];
        for (int i = 0, loopTo = (int)(Height - 1L); i <= loopTo; i++) {
          for (int j = 0, loopTo1 = (int)(Width - 1L); j <= loopTo1; j++) {
            var IIntensity = (byte)(SourceImg[SourceTexPos] / 16);
            DestImg[DestTexPos] = (byte)(IIntensity * 17);
            DestImg[DestTexPos + 1] = (byte)(IIntensity * 17);
            DestImg[DestTexPos + 2] = (byte)(IIntensity * 17);
            DestImg[DestTexPos + 3] = 255;
            SourceTexPos += 1;
            DestTexPos += 4;
          }

          SourceTexPos = (int)(SourceTexPos + (LineSize * 8L - Width));
        }

        SourceTexPos = 0;
        DestTexPos = 0;
        return default;
      }
    }

    public class IA {
      public object IA4(uint Width, uint Height, uint LineSize, byte[] SourceImg, ref byte[] DestImg) {
        DestImg = new byte[(int)(Width * Height * 8L + 1)];
        for (int i = 0, loopTo = (int)(Height - 1L); i <= loopTo; i++) {
          for (int j = 0, loopTo1 = (int)(Width / 2L - 1L); j <= loopTo1; j++) {
            var IAIntensity = (byte)((SourceImg[SourceTexPos] & 0xF0) >> 4);
            byte IAAlpha;
            if (Conversions.ToBoolean(IAIntensity & 1))
              IAAlpha = 255;
            else
              IAAlpha = 0;
            DestImg[DestTexPos] = (byte)(IAIntensity * 17);
            DestImg[DestTexPos + 1] = (byte)(IAIntensity * 17);
            DestImg[DestTexPos + 2] = (byte)(IAIntensity * 17);
            DestImg[DestTexPos + 3] = IAAlpha;
            IAIntensity = (byte)(SourceImg[SourceTexPos] & 0xF);
            if (Conversions.ToBoolean(IAIntensity & 1))
              IAAlpha = 255;
            else
              IAAlpha = 0;
            DestImg[DestTexPos + 4] = (byte)(IAIntensity * 17);
            DestImg[DestTexPos + 5] = (byte)(IAIntensity * 17);
            DestImg[DestTexPos + 6] = (byte)(IAIntensity * 17);
            DestImg[DestTexPos + 7] = IAAlpha;
            SourceTexPos += 1;
            DestTexPos += 8;
          }

          SourceTexPos = (int)(SourceTexPos + (LineSize * 8L - Width / 2L));
        }

        SourceTexPos = 0;
        DestTexPos = 0;
        return default;
      }

      public object IA8(uint Width, uint Height, uint LineSize, byte[] SourceImg, ref byte[] DestImg) {
        DestImg = new byte[(int)(Width * Height * 8L + 1)];
        for (int i = 0, loopTo = (int)(Height - 1L); i <= loopTo; i++) {
          for (int j = 0, loopTo1 = (int)(Width - 1L); j <= loopTo1; j++) {
            var IAIntensity = SourceImg[SourceTexPos] >> 4;
            var IAAlpha = SourceImg[SourceTexPos] << 4 >> 4;
            DestImg[DestTexPos] = (byte)(IAIntensity * 17);
            DestImg[DestTexPos + 1] = (byte)(IAIntensity * 17);
            DestImg[DestTexPos + 2] = (byte)(IAIntensity * 17);
            DestImg[DestTexPos + 3] = (byte)(IAAlpha * 17);
            SourceTexPos += 1;
            DestTexPos += 4;
          }

          SourceTexPos = (int)(SourceTexPos + (LineSize * 8L - Width));
        }

        SourceTexPos = 0;
        DestTexPos = 0;
        return default;
      }

      public object IA16(uint Width, uint Height, uint LineSize, byte[] SourceImg, ref byte[] DestImg) {
        DestImg = new byte[(int)(Width * Height * 8L + 1)];
        for (int i = 0, loopTo = (int)(Height - 1L); i <= loopTo; i++) {
          for (int j = 0, loopTo1 = (int)(Width - 1L); j <= loopTo1; j++) {
            var IAIntensity = SourceImg[SourceTexPos];
            var IAAlpha = SourceImg[SourceTexPos + 1];
            DestImg[DestTexPos] = IAIntensity;
            DestImg[DestTexPos + 1] = IAIntensity;
            DestImg[DestTexPos + 2] = IAIntensity;
            DestImg[DestTexPos + 3] = IAAlpha;
            SourceTexPos += 2;
            DestTexPos += 4;
          }

          SourceTexPos = (int)(SourceTexPos + (LineSize * 4L - Width));
        }

        SourceTexPos = 0;
        DestTexPos = 0;
        return default;
      }
    }
  }
}