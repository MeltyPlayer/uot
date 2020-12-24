using System;

namespace UoT {
  // TODO: Delete statics, use this within DlManager.
  /// <summary>
  ///   TMEM (texture memory) implementation. TMEM seems to be a middleman for
  ///   N64 texture loading: textures are loaded from RAM into TMEM, and tile
  ///   descriptors point into TMEM at a specific offset.
  /// </summary>
  public class Tmem {
    private readonly TextureCache cache_;
    private readonly ulong[] impl_ = new ulong[512];

    public Tmem(TextureCache cache) {
      this.cache_ = cache;
    }

    /// <summary>
    ///   Shamelessly copied from GLideN64's source.
    /// </summary>
    public void LoadTile(ref TileDescriptor tileDescriptor,
        ushort uls,
        ushort ult,
        ushort lrs,
        ushort lrt,
        TimgArgs timgArgs) {
      // TODO: Implement this method.
      // TODO: To verify behavior, load contents into a new texture and save to
      // file.

      tileDescriptor.ULS = uls;
      tileDescriptor.ULT = ult;
      tileDescriptor.LRS = lrs;
      tileDescriptor.LRT = lrt;

      var fUls = IoUtil.Fixed2Float(uls, 2);
      var fUlt = IoUtil.Fixed2Float(ult, 2);
      var fLrs = IoUtil.Fixed2Float(lrs, 2);
      var fLrt = IoUtil.Fixed2Float(lrt, 2);

      var timgImageAddress = timgArgs.Address;
      var timgBitSize = timgArgs.BitSize;
      var timgWidth = timgArgs.Width;
      var timgBpl = timgWidth << (int) timgBitSize >> 1; 

      var line = tileDescriptor.LineSize;
      var maskS = tileDescriptor.MaskS;
      var maskT = tileDescriptor.MaskT;

      uint imageBank;
      uint offset;
      IoUtil.SplitAddress(timgImageAddress, out imageBank, out offset);
      tileDescriptor.ImageBank = (int) imageBank;
      tileDescriptor.Offset = (int) offset;

      var texture = this.cache_[tileDescriptor];
      if (texture != null) {
        return;
      }

      if (lrs < uls || lrt < ult) {
        return;
      }

      var width = (lrs - uls + 1) & 0x03FF;
      var height = (lrt - ult + 1) & 0x03FF;
      var bpl = line << 3;

      var alignedWidth = width;
      var wmask = 0;

      switch (timgBitSize) {
        case BitSize.S_8B:
          wmask = 7;
          break;
        case BitSize.S_16B:
          wmask = 3;
          break;
        case BitSize.S_32B:
          wmask = 1;
          break;
        default:
          throw new NotSupportedException();
      }

      if ((width & wmask) != 0) {
        alignedWidth = (width & (~wmask)) + wmask + 1;
      }
      var bpr = alignedWidth << (int) timgBitSize >> 1;

      // Start doing the loading.
      var infoTexAddress = timgImageAddress;
      var infoWidth = (ushort) (maskS != 0
                                             ? Math.Min(width, 1U << maskS)
                                             : width);
      var infoHeight = (ushort) (maskT != 0
                                              ? Math.Min(height,
                                                    1U << maskT)
                                              : height);
      var infoTexWidth = timgWidth;
      var infoSize = timgBitSize;
      var infoBytes = bpl * height;

      if (timgBitSize == BitSize.S_32B) {
        // 32 bit texture loaded into lower and upper half of TMEM, thus actual bytes doubled.
        infoBytes *= 2;
      }

      if (line == 0) {
        return;
      }

      if (maskS == 0) {
        tileDescriptor.RealWidth =
            Math.Max(tileDescriptor.RealWidth, infoWidth);
      }
      if (maskT == 0) {
        /*if (gDP.otherMode.cycleType != G_CYC_2CYCLE &&
            gDP.loadTile->tmem % gDP.loadTile->line == 0) {
          u16 theight =
              static_cast<u16>(info.height +
                               gDP.loadTile->tmem / gDP.loadTile->line);
          gDP.loadTile->loadHeight = max(gDP.loadTile->loadHeight, theight);
        } else
          gDP.loadTile->loadHeight = max(gDP.loadTile->loadHeight, info.height);*/
      }

      var address = timgImageAddress +
                    ult * timgBpl +
                    (uls << (int) timgBitSize >> 1);

      /*
      u32 bpl2 = bpl;
      if (gDP.loadTile->lrs > timgWidth)
        bpl2 = (gDP.textureImage.width - gDP.loadTile->uls);
      var height2 = height;

      if (gDP.loadTile->lrt > gDP.scissor.lry)
        height2 = static_cast<u32>(gDP.scissor.lry) - gDP.loadTile->ult;

      if (CheckForFrameBufferTexture(address, info.width, bpl2 * height2))
        return;*/

      if (timgBitSize == BitSize.S_32B) {
        this.LoadTile32b_(ref tileDescriptor, timgArgs);
      } else {
        /*u32 tmemAddr = gDP.loadTile->tmem;
        const u32 line = gDP.loadTile->line;
        const u32 qwpr = bpr >> 3;
        for (u32 y = 0; y < height; ++y) {
          if (address + bpl > RDRAMSize)
            UnswapCopyWrap(RDRAM,
                           address,
                           reinterpret_cast<u8*>(TMEM),
                           tmemAddr << 3,
                           0xFFF,
                           RDRAMSize - address);
          else
            UnswapCopyWrap(RDRAM,
                           address,
                           reinterpret_cast<u8*>(TMEM),
                           tmemAddr << 3,
                           0xFFF,
                           bpr);
          if (y & 1)
            DWordInterleaveWrap(reinterpret_cast<u32*>(TMEM),
                                tmemAddr << 1,
                                0x3FF,
                                qwpr);

          address += gDP.textureImage.bpl;
          if (address >= RDRAMSize)
            break;
          tmemAddr += line;
        }*/
      }
    }

    /// <summary>
    ///   Shamelessly copied from GLideN64's source.
    /// </summary>
    private void LoadTile32b_(ref TileDescriptor tileDescriptor, TimgArgs timgArgs) {
      var uls = tileDescriptor.ULS;
      var ult = tileDescriptor.ULT;
      var lrs = tileDescriptor.LRS;
      var lrt = tileDescriptor.LRT;

      var width = lrs - uls + 1;
      var height = lrt - ult + 1;

      var line = tileDescriptor.LineSize << 2;
      var tbase = tileDescriptor.TmemOffset << 2;
      var addr = timgArgs.Address >> 2;

      /*const u32* src = reinterpret_cast <const u32*> (RDRAM);
      u16* tmem16 = reinterpret_cast<u16*>(TMEM);
      u32 c, ptr, tline, s, xorval;

      for (u32 j = 0; j < height; ++j) {
        tline = tbase + line * j;
        s = ((j + ult) * gDP.textureImage.width) + uls;
        xorval = (j & 1) ? 3 : 1;
        for (u32 i = 0; i < width; ++i) {
          c = src[addr + s + i];
          ptr = ((tline + i) ^ xorval) & 0x3ff;
          tmem16[ptr] = c >> 16;
          tmem16[ptr | 0x400] = c & 0xffff;
        }
      }*/
    }

    /// <summary>
    ///   Shamelessly copied from GLideN64's source.
    /// </summary>
    private void CalcTileSize(ref TileDescriptor tileDescriptor) { //, TileSizes &_sizes, gDPTile* _pLoadTile) {
      /*gDPTile* pTile = _t < 2 ? gSP.textureTile[_t] : &gDP.tiles[_t];
      pTile->masks = pTile->originalMaskS;
      pTile->maskt = pTile->originalMaskT;

      u32 tileWidth = ((pTile->lrs - pTile->uls) & 0x03FF) + 1;
      u32 tileHeight = ((pTile->lrt - pTile->ult) & 0x03FF) + 1;

      const u32 tMemMask = gDP.otherMode.textureLUT == G_TT_NONE ? 0x1FF : 0xFF;
      gDPLoadTileInfo & info = gDP.loadInfo[pTile->tmem & tMemMask];
      if (pTile->tmem == gDP.loadTile->tmem) {
        if (gDP.loadTile->loadWidth != 0 && gDP.loadTile->masks == 0)
          info.width = gDP.loadTile->loadWidth;
        if (gDP.loadTile->loadHeight != 0 && gDP.loadTile->maskt == 0) {
          info.height = gDP.loadTile->loadHeight;
          info.bytes = info.height * (gDP.loadTile->line << 3);
          if (gDP.loadTile->size == G_IM_SIZ_32b)
            // 32 bit texture loaded into lower and upper half of TMEM, thus actual bytes doubled.
            info.bytes *= 2;
        }
        gDP.loadTile->loadWidth = gDP.loadTile->loadHeight = 0;
      }
      _sizes.bytes = info.bytes;

      if (tileWidth == 1 && tileHeight == 1 &&
        gDP.otherMode.cycleType == G_CYC_COPY &&
        _pLoadTile != nullptr) {
        const u32 ulx = _SHIFTR(RDP.w1, 14, 10);
        const u32 uly = _SHIFTR(RDP.w1, 2, 10);
        const u32 lrx = _SHIFTR(RDP.w0, 14, 10);
        const u32 lry = _SHIFTR(RDP.w0, 2, 10);
        tileWidth = lrx - ulx + 1;
        tileHeight = lry - uly + 1;
      }

      u32 width = 0, height = 0;
      if (info.loadType == LOADTYPE_TILE) {
        width = min(info.width, info.texWidth);
        if (width == 0)
          width = tileWidth;
        if (info.size > pTile->size)
          width <<= info.size - pTile->size;

        height = info.height;
        if (height == 0)
          height = tileHeight;
        if ((config.generalEmulation.hacks & hack_MK64) != 0 && (height % 2) != 0)
          height--;
      } else {
        const TextureLoadParameters &loadParams =
          ImageFormat::get().tlp[gDP.otherMode.textureLUT][pTile->size][pTile->format];

        int tile_width = pTile->lrs - pTile->uls + 1;
        int tile_height = pTile->lrt - pTile->ult + 1;

        int mask_width = (pTile->masks == 0) ? (tile_width) : (1 << pTile->masks);
        int mask_height = (pTile->maskt == 0) ? (tile_height) : (1 << pTile->maskt);

        if (pTile->clamps)
          width = min(mask_width, tile_width);
        else if ((u32)(mask_width * mask_height) <= loadParams.maxTexels)
          width = mask_width;
        else
          width = tileWidth;

        if (pTile->clampt)
          height = min(mask_height, tile_height);
        else if ((u32)(mask_width * mask_height) <= loadParams.maxTexels)
          height = mask_height;
        else
          height = tileHeight;
      }

      _sizes.clampWidth = (pTile->clamps && gDP.otherMode.cycleType != G_CYC_COPY) ? tileWidth : width;
      _sizes.clampHeight = (pTile->clampt && gDP.otherMode.cycleType != G_CYC_COPY) ? tileHeight : height;

      _sizes.width = (info.loadType == LOADTYPE_TILE &&
              pTile->clamps != 0 &&
              pTile->masks == 0) ?
              _sizes.clampWidth :
              width;
      _sizes.height = (info.loadType == LOADTYPE_TILE &&
              pTile->clampt != 0 &&
              pTile->maskt == 0) ?
              _sizes.clampHeight :
              height;
    }*/
    }
  }
}