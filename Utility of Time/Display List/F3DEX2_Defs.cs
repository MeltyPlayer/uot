using System;
using Microsoft.VisualBasic;

namespace UoT {
  static class F3DEX2_Defs {

    // ALL UCODES - BASIC

    // F3DZEX (F3DEX v2.0)
    public enum F3DZEX {
      // GEOMETRY DRAWING
      VTX = 1,
      MODIFYVTX = 2,
      CULLDL = 3,
      BRANCH_Z = 4,
      TRI1 = 5,
      TRI2 = 6,
      QUAD = 7,

      // MATRIX MANIPULATION
      MTX_MODELVIEW = 0,
      MTX_PROJECTION = 4,
      MTX_MUL = 3,
      MTX_LOAD = 2,
      MTX_NOPUSH = 0,
      MTX_PUSH = 1,

      // GENERAL
      RDPHALF_2 = 0xF1,
      SETOTHERMODE_H = 0xE3,
      SETOTHERMODE_L = 0xE2,
      RDPHALF_1 = 0xE1,
      SPNOOP = 0xE0,
      ENDDL = 0xDF,
      DL = 0xDE,
      LOAD_UCODE = 0xDD,
      MOVEMEM = 0xDC,
      MOVEWORD = 0xDB,
      MTX = 0xDA,
      GEOMETRYMODE = 0xD9,
      POPMTX = 0xD8,
      TEXTURE = 0xD7,
      DMA_IO = 0xD6,
      SPECIAL_1 = 0xD5,
      SPECIAL_2 = 0xD4,
      SPECIAL_3 = 0xD3
    }

    public static int ReadInDL(byte[] Data, ref Structs.N64DisplayList[] DisplayList, int Offset, int Index) {
      try {
        if (Offset < Data.Length) {
          if (Data[Offset] == 0xDE) {
            while (Data[Offset] == 0xDE)
              Offset = (int)Functions.ReadUInt24(Data, (uint)(Offset + 5));
          }

          Array.Resize(ref DisplayList, Index + 1);
          DisplayList[Index] = new Structs.N64DisplayList();
          int EPLoc = Offset;
          My.MyProject.Forms.MainWin.DListSelection.Items.Add((Index + 1).ToString() + ". " + Conversion.Hex(Offset));
          {
            var withBlock = DisplayList[Index] = new Structs.N64DisplayList();
            withBlock.StartPos = new Structs.ZSegment();
            withBlock.StartPos.Offset = (uint)Offset;
            withBlock.StartPos.Bank = (byte)GlobalVars.CurrentBank;
            withBlock.Skip = false;
            withBlock.PickCol = new Structs.Color3UByte {
                r = (byte)GlobalVars.Rand.Next(0, 255),
                g = (byte)GlobalVars.Rand.Next(0, 255),
                b = (byte)GlobalVars.Rand.Next(0, 255),
            };
            do {
              Array.Resize(ref withBlock.Commands, withBlock.CommandCount + 1);
              Array.Resize(ref withBlock.CommandsCopy, withBlock.CommandCount + 1);

              var newCommand = new Structs.DLCommand();
              withBlock.Commands[withBlock.CommandCount] = newCommand;

              newCommand.CMDParams = new byte[8];
              newCommand.Name = GlobalVars.DLParser.IdentifyCommand(Data[EPLoc]);
              for (int i = 0; i <= 7; i++)
                newCommand.CMDParams[i] = Data[EPLoc + i];
              newCommand.CMDLow = Functions.ReadUInt24(Data, (uint)(EPLoc + 1));
              newCommand.CMDHigh = Functions.ReadUInt32(Data, (uint)(EPLoc + 4));
              newCommand.DLPos = withBlock.CommandCount;
              if (Data[EPLoc] == (int)F3DZEX.ENDDL | EPLoc >= Data.Length) {
                EPLoc += 8;
                break;
              }

              EPLoc += 8;
              withBlock.CommandCount += 1;
            }
            while (true);
            
            // TODO: Why is this here??
            withBlock.Commands.CopyTo(withBlock.CommandsCopy, 0);
          }

          return EPLoc;
        }
      } catch (Exception ex) {
        Interaction.MsgBox("Error reading in display list: " + ex.Message, MsgBoxStyle.Critical, "Exception");
        return default;
      }

      return default;
    }
  }
}