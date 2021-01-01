﻿namespace UoT {
  public class ZeldaChildFaceHack : IFaceHack {
    // TODO: Support different eyes/mouths depending on animation frame.
    // TODO: Where are the rest of the expressions?

    public enum Eye {
      NORMAL = 0x7208,
    }

    public uint MapTextureAddress(uint originalAddress) {
      // Left eye
      if (originalAddress == 0x09000000) {
        return 0x06000000 + (uint)Eye.NORMAL;
      }
      
      // Right eye
      if (originalAddress == 0x08000000) {
        return 0x06000000 + (uint) Eye.NORMAL;
      }

      // Mouth
      if (originalAddress == 0x0A000000) {
        return (uint)(0x06000000 + 0);
      }

      return originalAddress;
    }
  }
}