using System;
using System.Globalization;
using System.IO;
using Microsoft.VisualBasic;

namespace UoT {
  public class PresetReader {
    public Structs.ActorDB[] ReadHumanActorDB(string fn) {
      var Reader = new StreamReader(fn, System.Text.Encoding.UTF8);
      var tDB = new Structs.ActorDB[0];
      int actorCnt = 0;
      int varCnt = 0;
      string tLine = "";
      string tNextLine = "";
      string tTest = "";
      var Tokens = new string[] { "" };
      var nextTokens = new string[] { "" };
      int intParse = 0;
      while (Reader.Peek() != -1) {
        tLine = Reader.ReadLine();
        tTest = Strings.Mid(tLine, 1, 1);
        Tokens = tLine.Split(' ');
        short argresult = (short)intParse;
        if (short.TryParse(tTest, out argresult)) {
          tNextLine = Reader.ReadLine();
          Array.Resize(ref tDB, actorCnt + 1);
          {
            var withBlock = tDB[actorCnt];
            withBlock.no = (uint)int.Parse(Tokens[0], NumberStyles.HexNumber);
            withBlock.grp = (uint)int.Parse(Tokens[1], NumberStyles.HexNumber);
            withBlock.desc = "?";
            if (Tokens.Length > 2) {
              for (int I = 2, loopTo = Tokens.Length - 1; I <= loopTo; I++)
                withBlock.desc += Tokens[2 + (I - 2)] + " ";
            }
          }

          nextTokens = tNextLine.Split(' ');
          if (nextTokens.Length > 2) {
            while (string.IsNullOrEmpty(nextTokens[0]) & CultureInfo.CurrentCulture.CompareInfo.Compare(nextTokens[1], "-", CompareOptions.IgnoreCase | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth) == 0 & int.TryParse(nextTokens[2], out intParse)) {
              Array.Resize(ref tDB[actorCnt].var, varCnt + 1);
              {
                var withBlock1 = tDB[actorCnt].var[varCnt];
                withBlock1.var = (uint)int.Parse(nextTokens[2], NumberStyles.HexNumber);
                if (nextTokens.Length > 3) {
                  for (int I = 4, loopTo1 = nextTokens.Length - 1; I <= loopTo1; I++)
                    withBlock1.desc += nextTokens[I] + " ";
                } else {
                  withBlock1.desc = "?";
                }
              }

              tNextLine = Reader.ReadLine();
              nextTokens = tNextLine.Split(' ');
              if (nextTokens.Length < 2) {
                break;
              }

              varCnt += 1;
            }
          }

          varCnt = 0;
          actorCnt += 1;
        }
      }

      Reader.Dispose();
      return tDB;
    }
  }
}