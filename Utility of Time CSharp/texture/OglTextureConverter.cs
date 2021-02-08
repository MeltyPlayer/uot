﻿using System;
using System.Collections.Generic;

using Tao.OpenGl;

using UoT.util;

namespace UoT {
  // TODO: Come up w/ better name.
  public class OglTextureConverter {
    public void GenerateAndAddToCache(
        IList<byte> data,
        int offset,
        ref TileDescriptor tileDescriptor,
        Color4UByte[] palette32,
        TextureCache cache,
        bool save = false) {
      var loadedRgba = new byte[] {0, 0xFF, 0, 0};

      var width = tileDescriptor.LoadWidth;
      var height = tileDescriptor.LoadHeight;

      // Clamp defines whether to clamp each uv component. Unlike standard
      // OpenGL, this can be combined with wrapping/mirroring so the texture
      // wraps a few times before actually clamping.
      var clampS = (tileDescriptor.CMS & (int) RDP.G_TX_CLAMP) != 0;
      var clampT = (tileDescriptor.CMT & (int) RDP.G_TX_CLAMP) != 0;

      // Mirror defines whether to mirror each uv component when wrapping. That
      // is, values will range between [0, 1], then values beyond will go from
      // [1, 0], then back to [0, 1], and so on. If this is false, values will
      // always wrap between [0, 1].
      var mirrorS = (tileDescriptor.CMS & (int) RDP.G_TX_MIRROR) != 0;
      var mirrorT = (tileDescriptor.CMT & (int) RDP.G_TX_MIRROR) != 0;

      // These following values represent the true bounds of accessible uv
      // space for clamping. In standard OpenGL, uvs will always be clamped
      // between [0, 1], but in the N64 hardware these bounds can be altered.
      var sSize =
          clampS ? (tileDescriptor.LRS - tileDescriptor.ULS + 1) : width;
      var tSize =
          clampT ? (tileDescriptor.LRT - tileDescriptor.ULT + 1) : height;

      var converter =
          TextureConverter.GetConverter(tileDescriptor.ColorFormat,
                                        tileDescriptor.BitSize);
      converter.Convert((uint) width,
                        (uint) height,
                        (uint) tileDescriptor.LineSize,
                        data,
                        offset,
                        ref loadedRgba,
                        palette32);

      // Some textures are repeated and THEN clamped, so we must resize the
      // image accordingly.

      // Generates texture.
      Gl.glGenTextures(1, out tileDescriptor.ID);
      Gl.glBindTexture(Gl.GL_TEXTURE_2D, tileDescriptor.ID);

      // Puts pixels into texture.
      Gl.glTexImage2D(Gl.GL_TEXTURE_2D,
                      0,
                      Gl.GL_RGBA,
                      tileDescriptor.LoadWidth,
                      tileDescriptor.LoadHeight,
                      0,
                      Gl.GL_RGBA,
                      Gl.GL_UNSIGNED_BYTE,
                      loadedRgba);
      Glu.gluBuild2DMipmaps(Gl.GL_TEXTURE_2D,
                            Gl.GL_RGBA,
                            tileDescriptor.LoadWidth,
                            tileDescriptor.LoadHeight,
                            Gl.GL_RGBA,
                            Gl.GL_UNSIGNED_BYTE,
                            loadedRgba);

      var texture = Asserts.Assert(cache.Add(tileDescriptor, loadedRgba, save));

      /**
       * Lets OpenGL manage wrapping instead of calculating it within the
       * shader. This is necessary to fix seams.
       */
      var differentS = sSize != width;
      if (clampS) {
        texture.GlClampedS = true;
      }

      if (mirrorS) {
        Gl.glTexParameteri(Gl.GL_TEXTURE_2D,
                           Gl.GL_TEXTURE_WRAP_S,
                           Gl.GL_MIRRORED_REPEAT);
        texture.GlMirroredS = true;
      } else if (!clampS) {
        Gl.glTexParameteri(Gl.GL_TEXTURE_2D,
                           Gl.GL_TEXTURE_WRAP_S,
                           Gl.GL_REPEAT);
      } else if (differentS) {
        Gl.glTexParameteri(Gl.GL_TEXTURE_2D,
                           Gl.GL_TEXTURE_WRAP_S,
                           Gl.GL_REPEAT);
      } else {
        Gl.glTexParameteri(Gl.GL_TEXTURE_2D,
                           Gl.GL_TEXTURE_WRAP_S,
                           Gl.GL_CLAMP_TO_EDGE);
      }

      var differentT = tSize != height;
      if (clampT) {
        texture.GlClampedT = true;
      }

      if (mirrorT) {
        Gl.glTexParameteri(Gl.GL_TEXTURE_2D,
                           Gl.GL_TEXTURE_WRAP_T,
                           Gl.GL_MIRRORED_REPEAT);
        texture.GlMirroredT = true;
      } else if (!clampT) {
        Gl.glTexParameteri(Gl.GL_TEXTURE_2D,
                           Gl.GL_TEXTURE_WRAP_T,
                           Gl.GL_REPEAT);
      } else if (differentT) {
        Gl.glTexParameteri(Gl.GL_TEXTURE_2D,
                           Gl.GL_TEXTURE_WRAP_T,
                           Gl.GL_REPEAT);
      } else {
        Gl.glTexParameteri(Gl.GL_TEXTURE_2D,
                           Gl.GL_TEXTURE_WRAP_T,
                           Gl.GL_CLAMP_TO_EDGE);
      }

      //if (UoT.GlobalVars.RenderToggles.Anisotropic) {
      Gl.glTexParameterf(Gl.GL_TEXTURE_2D,
                         Gl.GL_TEXTURE_MAX_ANISOTROPY_EXT,
                         GLExtensions.AnisotropicSamples);
      /*} else {
        Gl.glTexParameterf(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAX_ANISOTROPY_EXT, 1.0f);
      }*/

      Gl.glTexParameteri(Gl.GL_TEXTURE_2D,
                         Gl.GL_TEXTURE_MIN_FILTER,
                         Gl.GL_LINEAR_MIPMAP_LINEAR);
      Gl.glTexParameteri(Gl.GL_TEXTURE_2D,
                         Gl.GL_TEXTURE_MAG_FILTER,
                         Gl.GL_LINEAR_MIPMAP_LINEAR);
    }
  }
}