using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace UoT {
  public interface IBank : IList<byte> {
    byte Segment { get; }
  }

  public abstract class BList : IList<byte> {
    public abstract int Count { get; }
    public abstract byte this[int index] { get; set; }


    // TODO: Get rid of all this crap.
    public IEnumerator<byte> GetEnumerator()
      => throw new NotImplementedException();

    IEnumerator IEnumerable.GetEnumerator()
      => throw new NotImplementedException();

    public void Add(byte item) => throw new NotImplementedException();

    public void Clear() {
      throw new NotImplementedException();
    }

    public bool Contains(byte item) {
      throw new NotImplementedException();
    }

    public void CopyTo(byte[] array, int arrayIndex) {
      throw new NotImplementedException();
    }

    public bool Remove(byte item) {
      throw new NotImplementedException();
    }

    public bool IsReadOnly => false;

    public int IndexOf(byte item) {
      throw new NotImplementedException();
    }

    public void Insert(int index, byte item) {
      throw new NotImplementedException();
    }

    public void RemoveAt(int index) {
      throw new NotImplementedException();
    }
  }

  public class RomBank : BList, IBank {
    private byte[] impl_ = new byte[0];

    public byte Segment { get; set; }
    public void Resize(int size) => Array.Resize(ref this.impl_, size);

    public int StartOffset { get; private set; }
    public int EndOffset => this.StartOffset + this.Count;
    public override int Count => this.impl_.Length;

    public override byte this[int offset] {
      get => this.impl_[offset];
      set => this.impl_[offset] = value;
    }

    public void PopulateFromFile(string filename) {
      this.impl_ = File.ReadAllBytes(filename);
      this.StartOffset = 0;
    }

    public void PopulateFromBytes(byte[] src, int srcOffset, int count) {
      this.Resize(count);
      Buffer.BlockCopy(src, srcOffset, this.impl_, 0, count);

      this.StartOffset = srcOffset;
    }

    public void PopulateFromStream(FileStream src, int srcOffset, int count) {
      this.Resize(count);
      src.Position = srcOffset;
      src.Read(this.impl_, 0, count);

      this.StartOffset = srcOffset;
    }

    public void WriteToFile(string filename)
      => File.WriteAllBytes(filename, this.impl_);

    public void WriteToStream(FileStream fs, int fsOffset) {
      fs.Position = fsOffset;
      fs.Write(this.impl_, 0, this.Count);
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