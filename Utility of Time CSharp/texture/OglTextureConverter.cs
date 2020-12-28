using System.Collections.Generic;

using Tao.OpenGl;

namespace UoT {
  // TODO: Come up w/ better name.
  public class OglTextureConverter {
    public void GenerateAndAddToCache(IList<byte> data, int offset, ref TileDescriptor tileDescriptor, Color4UByte[] palette32, TextureCache cache, bool save = false) {
      var OGLTexImg = new byte[] { 0, 0xFF, 0, 0 };

      var converter = TextureConverter.GetConverter(tileDescriptor.ColorFormat, tileDescriptor.BitSize);
      converter.Convert((uint)tileDescriptor.LoadWidth, (uint)tileDescriptor.LoadHeight, (uint)tileDescriptor.LineSize, data, offset, ref OGLTexImg, palette32);


      // Generates texture.
      Gl.glGenTextures(1, out tileDescriptor.ID);
      Gl.glBindTexture(Gl.GL_TEXTURE_2D, tileDescriptor.ID);

      // Puts pixels into texture.
      Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGBA, tileDescriptor.LoadWidth, tileDescriptor.LoadHeight, 0, Gl.GL_RGBA, Gl.GL_UNSIGNED_BYTE, OGLTexImg);
      Glu.gluBuild2DMipmaps(Gl.GL_TEXTURE_2D, Gl.GL_RGBA, tileDescriptor.LoadWidth, tileDescriptor.LoadHeight, Gl.GL_RGBA, Gl.GL_UNSIGNED_BYTE, OGLTexImg);

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

      cache.Add(tileDescriptor, OGLTexImg, save);
    }
  }
}
