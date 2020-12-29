using System.Collections.Generic;

using Tao.OpenGl;

namespace UoT {
  // TODO: Come up w/ better name.
  public class OglTextureConverter {
    public void GenerateAndAddToCache(IList<byte> data, int offset, ref TileDescriptor tileDescriptor, Color4UByte[] palette32, TextureCache cache, bool save = false) {
      var loadedRgba = new byte[] { 0, 0xFF, 0, 0 };

      var width = tileDescriptor.LoadWidth;
      var height = tileDescriptor.LoadHeight;

      var converter = TextureConverter.GetConverter(tileDescriptor.ColorFormat, tileDescriptor.BitSize);
      converter.Convert((uint)width, (uint) height, (uint)tileDescriptor.LineSize, data, offset, ref loadedRgba, palette32);

      // Some textures are repeated and THEN clamped, so we must resize the
      // image accordingly.

      var sSize = tileDescriptor.CMS == (int)RDP.G_TX_CLAMP ? (tileDescriptor.LRS - tileDescriptor.ULS) + 1 : width;
      var tSize = tileDescriptor.CMT == (int)RDP.G_TX_CLAMP ? (tileDescriptor.LRT - tileDescriptor.ULT) + 1 : height;

      // TODO: ULS/ULT might be negative, we should track if we need to offset
      // UVs.
      // TODO: Can we specify a max/min UV or UV scaling system?
      byte[] resizedRgba;
      if (sSize != width || tSize != height) {
        resizedRgba = new byte[4 * sSize * tSize];
        for (var s = 0; s < sSize; ++s) {
          for (var t = 0; t < tSize; ++t) {
            var x = s % width;
            var y = t % height;

            for (var i = 0; i < 4; ++i) {
              resizedRgba[4* (t * sSize + s) + i] = loadedRgba[4*(y * width + x) + i];
            }
          }
        }

        tileDescriptor.LoadWidth = sSize;
        tileDescriptor.LoadHeight = tSize;
        tileDescriptor.UScaling = (1.0 * width) / sSize;
        tileDescriptor.VScaling = (1.0 * height) / tSize;
      } else {
        resizedRgba = loadedRgba;

        tileDescriptor.UScaling = 1;
        tileDescriptor.VScaling = 1;
      }

      // Generates texture.
      Gl.glGenTextures(1, out tileDescriptor.ID);
      Gl.glBindTexture(Gl.GL_TEXTURE_2D, tileDescriptor.ID);

      // Puts pixels into texture.
      Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGBA, tileDescriptor.LoadWidth, tileDescriptor.LoadHeight, 0, Gl.GL_RGBA, Gl.GL_UNSIGNED_BYTE, resizedRgba);
      Glu.gluBuild2DMipmaps(Gl.GL_TEXTURE_2D, Gl.GL_RGBA, tileDescriptor.LoadWidth, tileDescriptor.LoadHeight, Gl.GL_RGBA, Gl.GL_UNSIGNED_BYTE, resizedRgba);

      // Sets texture parameters.
      switch (tileDescriptor.CMS) {
        case (int)RDP.G_TX_CLAMP:
        case 3: {
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_S, Gl.GL_CLAMP_TO_EDGE);
            break;
          }

        case (int)RDP.G_TX_MIRROR: {
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_S, Gl.GL_MIRRORED_REPEAT);
            break;
          }

        case (int)RDP.G_TX_WRAP: {
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_S, Gl.GL_REPEAT);
            break;
          }

        default: {
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_S, Gl.GL_REPEAT);
            break;
          }
      }

      switch (tileDescriptor.CMT) {
        case (int)RDP.G_TX_CLAMP:
        case 3: {
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_T, Gl.GL_CLAMP_TO_EDGE);
            break;
          }

        case (int)RDP.G_TX_MIRROR: {
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_T, Gl.GL_MIRRORED_REPEAT);
            break;
          }

        case (int)RDP.G_TX_WRAP: {
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_T, Gl.GL_REPEAT);
            break;
          }

        default: {
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_T, Gl.GL_REPEAT);
            break;
          }
      }

      //if (UoT.GlobalVars.RenderToggles.Anisotropic) {
        Gl.glTexParameterf(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAX_ANISOTROPY_EXT, GLExtensions.AnisotropicSamples[GLExtensions.AnisotropicSamples.Length - 1]);
      /*} else {
        Gl.glTexParameterf(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAX_ANISOTROPY_EXT, 1.0f);
      }*/

      Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR_MIPMAP_LINEAR);
      Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR_MIPMAP_LINEAR);

      cache.Add(tileDescriptor, resizedRgba, save);
    }
  }
}
