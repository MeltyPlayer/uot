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
            RGBA5551 = IoUtil.ReadUInt16(SourceImg, (uint)SourceTexPos);
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

    // TODO: Where is YUV??

    public class CI {
      private byte[] PaletteIndex = new byte[2];

      public object CI8(uint Width, uint Height, uint LineSize, byte[] SourceImg, ref byte[] DestImg, Color4UByte[] Palette) {
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

      public object CI4(uint Width, uint Height, uint LineSize, byte[] SourceImg, ref byte[] DestImg, Color4UByte[] Palette) {
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
      private const byte FACTOR = 17;

      public object I4(uint Width, uint Height, uint LineSize, byte[] SourceImg, ref byte[] DestImg) {
        DestImg = new byte[(int)(Width * Height * 8L + 1)];
        for (int i = 0, loopTo = (int)(Height - 1L); i <= loopTo; i++) {
          for (int j = 0, loopTo1 = (int)(Width / 2L - 1L); j <= loopTo1; j++) {
            BitMath.Split(SourceImg[SourceTexPos], out var upper4, out var lower4);

            var upperIntensity = (byte) (upper4 * FACTOR);
            DestImg[DestTexPos] = upperIntensity;
            DestImg[DestTexPos + 1] = upperIntensity;
            DestImg[DestTexPos + 2] = upperIntensity;
            DestImg[DestTexPos + 3] = 255;

            var lowerIntensity = (byte)(lower4 * FACTOR);
            DestImg[DestTexPos + 4] = lowerIntensity;
            DestImg[DestTexPos + 5] = lowerIntensity;
            DestImg[DestTexPos + 6] = lowerIntensity;
            DestImg[DestTexPos + 7] = 255;

            ++SourceTexPos;
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
            var intensity = SourceImg[SourceTexPos];
            DestImg[DestTexPos] = intensity;
            DestImg[DestTexPos + 1] = intensity;
            DestImg[DestTexPos + 2] = intensity;
            DestImg[DestTexPos + 3] = 255;

            ++SourceTexPos;
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
      private const byte FACTOR = 17;

      public object IA4(uint Width, uint Height, uint LineSize, byte[] SourceImg, ref byte[] DestImg) {
        DestImg = new byte[(int)(Width * Height * 8L + 1)];
        for (int i = 0, loopTo = (int)(Height - 1L); i <= loopTo; i++) {
          for (int j = 0, loopTo1 = (int)(Width / 2L - 1L); j <= loopTo1; j++) {
            BitMath.Split(SourceImg[SourceTexPos], out var upper4, out var lower4);

            var IAIntensity = (byte)((SourceImg[SourceTexPos] & 0xF0) >> 4);
            byte IAAlpha;
            if (Conversions.ToBoolean(upper4 & 1))
              IAAlpha = 255;
            else
              IAAlpha = 0;
            var upperIntensity = (byte)(upper4 * FACTOR);
            DestImg[DestTexPos] = upperIntensity;
            DestImg[DestTexPos + 1] = upperIntensity;
            DestImg[DestTexPos + 2] = upperIntensity;
            DestImg[DestTexPos + 3] = IAAlpha;

            var lowerIntensity = (byte)(lower4 * FACTOR);
            if (Conversions.ToBoolean(lower4 & 1))
              IAAlpha = 255;
            else
              IAAlpha = 0;
            DestImg[DestTexPos + 4] = lowerIntensity;
            DestImg[DestTexPos + 5] = lowerIntensity;
            DestImg[DestTexPos + 6] = lowerIntensity;
            DestImg[DestTexPos + 7] = IAAlpha;

            ++SourceTexPos;
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
            BitMath.Split(SourceImg[SourceTexPos], out var upper4, out var lower4);
            var intensity = (byte)(upper4 * FACTOR);
            var alpha = (byte)(lower4 * FACTOR);

            DestImg[DestTexPos] = intensity;
            DestImg[DestTexPos + 1] = intensity;
            DestImg[DestTexPos + 2] = intensity;
            DestImg[DestTexPos + 3] = alpha;
            
            ++SourceTexPos;
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

  // TODO: Move somewhere else.
  public static class BitMath {
    public static void Split(byte value, out byte upper4, out byte lower4) {
      upper4 = (byte) (value >> 4);
      lower4 = (byte) ((byte)(value << 4) >> 4);
    }
  }
}