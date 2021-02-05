using System;
using System.IO;

using UoT.memory.map;
using UoT.util.array;

namespace UoT {
  public interface IBank : IIndexable<byte> {
    byte Segment { get; }
  }

  public class RomBank : BIndexable, IBank {
    public byte Segment { get; set; }
    public void Resize(int size) => this.Region!.Resize(size);

    public IShardedMemory? Region { get; set; }
    public override int Count => this.Region?.Count ?? 0;

    public override byte this[int offset] {
      get => this.Region![offset];
      set => this.Region![offset] = value;
    }

    public void PopulateFromFile(string filename) {
      throw new NotSupportedException();
      //this.impl_ = File.ReadAllBytes(filename);
      //this.StartOffset = 0;
    }

    public void WriteToFile(string filename)
      => throw new NotSupportedException();
      // => File.WriteAllBytes(filename, this.impl_);

    public void WriteToStream(FileStream fs, int fsOffset) {
      throw new NotSupportedException();
      //fs.Position = fsOffset;
      //fs.Write(this.impl_, 0, this.Count);
    }
  }

  /*public class RdRamBank : BList, IBank {
    private const int RDRAM_SIZE = 0x7A1200;
    private readonly RomBank impl_;



    public RdRamBank() {
      this.impl_ = new RomBank();
      this.impl_.Resize(RDRAM_SIZE);
    }

    public override int Count => this.impl_.Count;

    public override byte this[int offset] {
      get {
        return this.impl_[offset];
      } 
      set => this.impl_[offset] = value;
    }
  }*/

  public static class RamBanks {
    static RamBanks() {
      // TODO: Initialize RDRAM.
    }


    public static RomBank ZFileBuffer { get; } = new RomBank();

    /// <summary>
    ///   Bank 2, Current Scene.
    /// </summary>
    public static RomBank ZSceneBuffer { get; } = new RomBank {Segment = 2};

    // TODO: Figure out why textures are not parsed correctly from 8 and 9.
    /// <summary>
    ///   Bank 8, "icon_item_static". Contains animated textures, such as eyes,
    ///   mouths, etc.
    /// </summary>
    public static RomBank IconItemStatic { get; } = new RomBank {Segment = 8};

    /// <summary>
    ///   Bank 9, "icon_item_24_static". Contains animated textures.
    /// </summary>
    public static RomBank IconItem24Static { get; } = new RomBank {Segment = 9};


    public static int CurrentBank => RamBanks.ZFileBuffer.Segment;
    public static BankSwitch CommonBankUse { get; set; }

    public static ObjectExchange CommonBanks { get; set; }

    public static bool IsValidBank(byte bankIndex) {
      if (bankIndex == RamBanks.CurrentBank) {
        return true;
      }

      switch (bankIndex) {
        case 2:
          return RamBanks.ZSceneBuffer.Count > 0;
        case 4:
          return true;
        case 5:
          return true;

        default:
          return false;
      }
    }

    public static IBank? GetBankByIndex(uint bankIndex) {
      if (bankIndex == RamBanks.CurrentBank) {
        return RamBanks.ZFileBuffer;
      }

      switch (bankIndex) {
        // TODO: Support case 0, direct reference!
        // TODO: Support case 3, "Current Room". (?)
        case 2:
          return RamBanks.ZSceneBuffer;
        case 4:
          return RamBanks.CommonBanks.Bank4.Banks
              [RamBanks.CommonBankUse.Bank04];
        case 5:
          return RamBanks.CommonBanks.Bank5.Banks
              [RamBanks.CommonBankUse.Bank05];

        default:
          // TODO: Should throw an error for unsupported banks.
          return null;
      }
    }
  }
}