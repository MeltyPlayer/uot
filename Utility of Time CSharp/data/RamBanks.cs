using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace UoT {
  public interface IRamBank : IList<byte> {}

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

  public class SimpleRamBank : BList, IRamBank {
    private byte[] impl_ = new byte[0];

    public void Resize(int size) => Array.Resize(ref this.impl_, size);

    public override int Count => this.impl_.Length;
    public override byte this[int offset] {
      get => this.impl_[offset];
      set => this.impl_[offset] = value;
    }

    public void PopulateFromFile(string filename)
      => this.impl_ = File.ReadAllBytes(filename);

    public void PopulateFromStream(FileStream fs, int fsOffset, int count) {
      this.Resize(count);
      fs.Position = fsOffset;
      fs.Read(this.impl_, 0, count);
    }

    public void WriteToFile(string filename)
      => File.WriteAllBytes(filename, this.impl_);

    public void WriteToStream(FileStream fs, int fsOffset) {
      fs.Position = fsOffset;
      fs.Write(this.impl_, 0, this.Count);
    }
  }

  public class RdRamBank : BList, IRamBank {
    private const int RDRAM_SIZE = 0x7A1200;
    private readonly SimpleRamBank impl_;

    public RdRamBank() {
      this.impl_ = new SimpleRamBank();
      this.impl_.Resize(RDRAM_SIZE);
    }

    public override int Count => this.impl_.Count;

    public override byte this[int offset] {
      get {
        return this.impl_[offset];
      } 
      set => this.impl_[offset] = value;
    }
  }

  public static class RamBanks {
    static RamBanks() {
      // TODO: Initialize RDRAM.
    }

    public static RdRamBank Rdram { get; } = new RdRamBank();

    public static SimpleRamBank ZFileBuffer { get; } = new SimpleRamBank();

    /// <summary>
    ///   Bank 2, Current Scene.
    /// </summary>
    public static SimpleRamBank ZSceneBuffer { get; } = new SimpleRamBank();

    // TODO: Figure out why textures are not parsed correctly from 8 and 9.
    /// <summary>
    ///   Bank 8, "icon_item_static". Contains animated textures, such as eyes,
    ///   mouths, etc.
    /// </summary>
    public static SimpleRamBank IconItemStatic { get; } = new SimpleRamBank();

    /// <summary>
    ///   Bank 9, "icon_item_24_static". Contains animated textures.
    /// </summary>
    public static SimpleRamBank IconItem24Static { get; } = new SimpleRamBank();


    public static int CurrentBank { get; set; }
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

    public static IRamBank GetBankByIndex(uint bankIndex) {
      if (bankIndex == RamBanks.CurrentBank) {
        return RamBanks.ZFileBuffer;
      }

      switch (bankIndex) {
        // TODO: Support case 0, direct reference!
        // TODO: Support case 3, "Current Room". (?)
        case 2:
          return RamBanks.ZSceneBuffer;
        case 4:
          return RamBanks.CommonBanks.Bank4.Banks[RamBanks.CommonBankUse.Bank04]
                         .Data;
        case 5:
          return RamBanks.CommonBanks.Bank5.Banks[RamBanks.CommonBankUse.Bank05]
                         .Data;

        default:
          // TODO: Should throw an error for unsupported banks.
          return null;
      }
    }
  }
}