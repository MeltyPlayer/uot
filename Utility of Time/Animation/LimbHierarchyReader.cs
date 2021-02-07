using System;

namespace UoT {
  public static class LimbHierarchyReader {

    /// <summary>
    ///   Parses a limb hierarchy according to the following spec:
    ///   https://wiki.cloudmodding.com/oot/Animation_Format#Hierarchy
    /// </summary>
    public static Limb[] GetHierarchies(IBank Data, bool isLink, DlManager dlManager, StaticDlModel model) {
      uint limbIndexAddress;
      var limbIndexBank = default(uint);
      uint limbIndexOffset;
      model.Reset();
      int j = 0;
      for (int i = 0, loopTo = Data.Count - 8; i <= loopTo; i += 4) {
        limbIndexAddress = IoUtil.ReadUInt32(Data, (uint)i);
        byte argbank = (byte)limbIndexBank;
        IoUtil.SplitAddress(limbIndexAddress, out argbank, out limbIndexOffset);
        uint limbCount = Data[i + 4];
        uint limbAddress;
        var limbBank = default(uint);
        uint limbOffset;
        IBank limbBankBuffer;

        // Link has an extra set of values for each limb that define LOD model
        // display lists.
        uint limbSize;
        if (isLink) {
          limbSize = 16U;
        } else {
          limbSize = 12U;
        }

        if (RamBanks.IsValidBank((byte)limbIndexBank) & limbCount > 0L) {
          var limbIndexBankBuffer = RamBanks.GetBankByIndex(limbIndexBank);
          if (limbIndexOffset + 4L * limbCount < limbIndexBankBuffer.Count) {
            byte firstChild;
            byte nextSibling;
            bool isValid = true;
            bool somethingVisible = false;
            var loopTo1 = (int)(limbCount - 1L);
            for (j = 0; j <= loopTo1; j++) {
              limbAddress = IoUtil.ReadUInt32(limbIndexBankBuffer, (uint)(limbIndexOffset + j * 4));
              byte argbank1 = (byte)limbBank;
              IoUtil.SplitAddress(limbAddress, out argbank1, out limbOffset);
              if (!RamBanks.IsValidBank((byte)limbBank)) {
                isValid = false;
                goto badLimbIndexOffset;
              }

              limbBankBuffer = RamBanks.GetBankByIndex(limbBank);
              if (limbOffset + limbSize >= limbBankBuffer.Count) {
                isValid = false;
                goto badLimbIndexOffset;
              }

              firstChild = limbBankBuffer[(int)(limbOffset + 6L)];
              nextSibling = limbBankBuffer[(int)(limbOffset + 7L)];
              if (firstChild == j | nextSibling == j) {
                isValid = false;
                goto badLimbIndexOffset;
              }

              uint displayListAddress = IoUtil.ReadUInt32(limbBankBuffer, (uint)(limbOffset + 8L));
              var displayListBank = default(uint);
              uint displayListOffset;
              byte argbank2 = (byte)displayListBank;
              IoUtil.SplitAddress(displayListAddress, out argbank2, out displayListOffset);
              if (displayListBank != 0L) {
                somethingVisible = true;
              }

              if (displayListBank != 0L & !RamBanks.IsValidBank((byte)displayListBank)) {
                isValid = false;
                goto badLimbIndexOffset;
              }
            }

            badLimbIndexOffset:

            if (isValid) {
              var tmpHierarchy = new Limb[(int)(limbCount - 1L + 1)];
              for (int k = 0, loopTo2 = (int)(limbCount - 1L); k <= loopTo2; k++) {
                limbAddress = IoUtil.ReadUInt32(limbIndexBankBuffer, (uint)(limbIndexOffset + 4 * k));
                byte argbank3 = (byte)limbBank;
                IoUtil.SplitAddress(limbAddress, out argbank3, out limbOffset);
                limbBankBuffer = RamBanks.GetBankByIndex(limbBank);
                tmpHierarchy[k] = new Limb();
                {
                  var withBlock = tmpHierarchy[k];
                  withBlock.x = (short)IoUtil.ReadUInt16(limbBankBuffer, (uint)(limbOffset + 0L));
                  withBlock.y = (short)IoUtil.ReadUInt16(limbBankBuffer, (uint)(limbOffset + 2L));
                  withBlock.z = (short)IoUtil.ReadUInt16(limbBankBuffer, (uint)(limbOffset + 4L));
                  withBlock.firstChild = (sbyte)limbBankBuffer[(int)(limbOffset + 6L)];
                  withBlock.nextSibling = (sbyte)limbBankBuffer[(int)(limbOffset + 7L)];
                  model.AddLimb(withBlock.x, withBlock.y, withBlock.z, withBlock.firstChild, withBlock.nextSibling);
                  uint displayListAddress = IoUtil.ReadUInt32(limbBankBuffer, (uint)(limbOffset + 8L));
                  var displayListBank = default(uint);
                  uint displayListOffset;
                  byte argbank4 = (byte)displayListBank;
                  IoUtil.SplitAddress(displayListAddress, out argbank4, out displayListOffset);
                  if (displayListBank != 0L) {
                    var displayListBankBuffer = RamBanks.GetBankByIndex(displayListBank);
                    withBlock.DisplayListAddress = displayListAddress;
                    DisplayListReader.ReadInDL(dlManager, displayListAddress, UoT.My.MyProject.Forms.MainWin.DListSelection);
                  } else if (!somethingVisible) {
                    withBlock.DisplayListAddress = displayListAddress;
                  } else {
                    withBlock.DisplayListAddress = displayListAddress;
                  }

                  // Far model display list (i.e. LOD model). Only used for Link.
                  // If Data(tmpLimbOff + 12) = Bank Then
                  // .DisplayListLow = ReadUInt24(Data, tmpLimbOff + 13)
                  // ReDim Preserve N64DList(N64DList.Length)
                  // ReadInDL(Data, N64DList, .DisplayListLow, N64DList.Length - 1)
                  // Else
                  withBlock.DisplayListLow = default;

                  // End If
                  withBlock.r = UoT.GlobalVars.Rand.NextDouble();
                  withBlock.g = UoT.GlobalVars.Rand.NextDouble();
                  withBlock.b = UoT.GlobalVars.Rand.NextDouble();
                }
              }

              if (isValid & !somethingVisible) {
                throw new NotSupportedException("model format is not rendering a valid model!");
              }

              return tmpHierarchy;
            }
          }
        }
      }

      return null;
    }
  }
}