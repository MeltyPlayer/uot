using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace UoT {
  static class Functions {
    [DllImport("shell32.dll", EntryPoint = "ShellExecuteA")]
    public static extern long ShellExecute(long hWnd, string lpOperation, string lpFile, string lpParameters, string lpDirectory, long nShowCmd);
    [DllImport("kernel32")]
    public static extern long GetTickCount();

    public static void SetOGLDefaultParams() {
      Gl.glDisable(Gl.GL_TEXTURE_2D);
      Gl.glDisable(Gl.GL_FRAGMENT_PROGRAM_ARB);
      Gl.glDisable(Gl.GL_LIGHTING);
      Gl.glDisable(Gl.GL_NORMALIZE);
      Gl.glDisable(Gl.GL_BLEND);
      Gl.glDisable(Gl.GL_POLYGON_OFFSET_FILL);
      Gl.glDisable(Gl.GL_CULL_FACE);
    }

    public static Color RGBA8ColorToColorObject(Structs.Color4UByte Color) {
      return System.Drawing.Color.FromArgb(Color.a, Color.r, Color.g, Color.b);
    }

    public static object PushOGLAttribs(int[] attribs) {
      for (int i = 0, loopTo = attribs.Length - 1; i <= loopTo; i++)
        Gl.glPushAttrib(attribs[i]);
      return default;
    }

    public static object PopOGLAttribls() {
      Gl.glPopAttrib();
      return default;
    }

    public static double AngleToRad(short angle) {
      return angle * 180.0f / 32768.0f;
    }

    public static int SearchDLCache(Structs.N64DisplayList[] N64DList, uint Offset) {
      for (int i = 0, loopTo = N64DList.Length - 1; i <= loopTo; i++) {
        if (N64DList[i].StartPos.Offset == Offset) {
          return i;
        }
      }

      return -1;
    }

    public static object ToggleBoolean(ref bool @bool, ref ToolStripMenuItem MenuItem) {
      if (@bool)
        @bool = false;
      else
        @bool = true;
      if (MenuItem is object) {
        MenuItem.Checked = @bool;
      }

      return default;
    }

    public static void InitNewCommand(ref Structs.DLCommand Command, byte CommandCode) {
      Command = new Structs.DLCommand();
      Command.CMDParams = new byte[8];
      Command.CMDHigh = 0U;
      Command.CMDLow = 0U;
      Command.CMDParams[0] = CommandCode;
      for (int i = 1; i <= 7; i++)
        Command.CMDParams[i] = 0;
    }

    public static ulong Flip32(ulong Flip) {
      return (ulong)(((long)Flip & 0xFF000000L) >> 24 | ((long)Flip & 0xFF0000L) >> 8 | ((long)Flip & 0xFF00L) << 8 | ((long)Flip & 0xFFL) << 24);
    }

    public static uint ReadUInt32(byte[] Buffer, uint Offset) {
      uint ReadUInt32Ret = default;
      ReadUInt32Ret = (uint)(Buffer[(int)Offset] * 0x1000000 + Buffer[(int)(Offset + 1L)] * 0x10000 + Buffer[(int)(Offset + 2L)] * 0x100 + Buffer[(int)(Offset + 3L)]);


      return ReadUInt32Ret;
    }

    public static uint ReadUInt24(byte[] Buffer, uint Offset) {
      uint ReadUInt24Ret = default;
      ReadUInt24Ret = (uint)(Buffer[(int)Offset] * 0x10000 + Buffer[(int)(Offset + 1L)] * 0x100 + Buffer[(int)(Offset + 2L)]);

      return ReadUInt24Ret;
    }

    public static int ReadInt16(byte[] Buffer, uint Offset) {
      int ReadInt16Ret = default;
      if (Offset >= Buffer.Length - 1) {
        ReadInt16Ret = 0;
        return ReadInt16Ret;
      }

      ReadInt16Ret = Buffer[(int)Offset] * 0x100 + Buffer[(int)(Offset + 1L)];
      return ReadInt16Ret;
    }

    public static object WriteInt16(ref byte[] Buffer, ref short Offset, short Data) {
      if (Offset >= Buffer.Length - 1) {
        Array.Resize(ref Buffer, Offset + 2 + 1);
      }

      Buffer[Offset + 0] = (byte)(Data >> 8 & 0xFF);
      Buffer[Offset + 1] = (byte)(Data >> 0 & 0xFF);
      Offset = (short)(Offset + 2);
      return default;
    }

    public static object WriteInt32(ref byte[] Buffer, uint Data, ref int Offset) {
      if (Offset >= Buffer.Length - 1) {
        Array.Resize(ref Buffer, Offset + 4 + 1);
      }

      Buffer[Offset + 0] = (byte)(Data >> 24 & 0xFFL);
      Buffer[Offset + 1] = (byte)(Data >> 16 & 0xFFL);
      Buffer[Offset + 2] = (byte)(Data >> 8 & 0xFFL);
      Buffer[Offset + 3] = (byte)(Data >> 0 & 0xFFL);
      Offset += 4;
      return default;
    }

    public static object WriteInt24(ref byte[] Buffer, uint Data, ref int Offset) {
      if (Offset >= Buffer.Length - 1) {
        Array.Resize(ref Buffer, Offset + 3 + 1);
      }

      Buffer[Offset + 0] = (byte)(Data >> 16 & 0xFFL);
      Buffer[Offset + 1] = (byte)(Data >> 8 & 0xFFL);
      Buffer[Offset + 2] = (byte)(Data >> 0 & 0xFFL);
      Offset += 3;
      return default;
    }

    public static string NoExt(string FullPath) {
      return System.IO.Path.GetFileNameWithoutExtension(FullPath);
    }

    public static double Fixed2Float(double v, int b) {
      return v * RDP_Defs.FIXED2FLOATRECIP[b - 1];
    }

    public static ulong Pow2(ulong val) {
      long i = 1L;
      while (i < (decimal)val)
        i = i << 1;
      return (ulong)i;
    }

    public static bool HexOnly(string str) {
      if ("0123456789ABCDEF".IndexOf(str) == -1) {
        return true;
      } else {
        return false;
      }
    }

    public static ulong PowOf(ulong val) {
      long num = 1L;
      long i = 0L;
      while (num < (decimal)val) {
        num = num << 1;
        i += 1L;
      }

      return (ulong)i;
    }

    public static string GetDir(string fn) {
      for (int i = fn.Length - 1; i >= 0; i -= 1) {
        if (Conversions.ToString(fn[i]) == @"\" | Conversions.ToString(fn[i]) == "/") {
          return Strings.Mid(fn, 1, i);
        }
      }

      return "";
    }

    public static float ConvertHexToSingle(string hexValue) {
      try {
        int iInputIndex = 0;
        int iOutputIndex = 0;
        var bArray = new byte[4];
        var loopTo = hexValue.Length - 1;
        for (iInputIndex = 0; iInputIndex <= loopTo; iInputIndex += 2) {
          bArray[iOutputIndex] = byte.Parse(Conversions.ToString(hexValue[iInputIndex]) + hexValue[iInputIndex + 1], System.Globalization.NumberStyles.HexNumber);
          iOutputIndex += 1;
        }

        Array.Reverse(bArray);
        return BitConverter.ToSingle(bArray, 0);
      } catch (Exception ex) {
        throw new FormatException("The supplied hex value is either empty or in an incorrect format. Use the following format: 00000000", ex);
      }
    }

    public static object CheckAllChildNodes(TreeNode treeNode1, bool nodeChecked) {
      foreach (TreeNode node in treeNode1.Nodes) {
        node.Checked = nodeChecked;
        if (node.Nodes.Count > 0) {
          CheckAllChildNodes(node, nodeChecked);
        }
      }

      return default;
    }
    // macros for processing n64 dl commands
    public static uint ShiftR(uint v, uint s, uint w) {
      return (uint)(v >> (int)s & (1 << (int)w) - 1);
    }

    public static uint ShiftL(uint v, uint s, uint w) {
      return (uint)(v & (1 << (int)w) - 1 << (int)s);
    }

    public static byte[] Hex2(string sHex) {
      byte[] Hex2Ret = default;
      long n;
      long nCount;
      byte[] bArr;
      nCount = Strings.Len(sHex);
      if ((nCount & 1L) == 1L) {
        sHex = "0" + sHex;
        nCount += 1L;
      }

      bArr = new byte[(int)(nCount / 2L - 1L + 1)];
      var loopTo = nCount;
      for (n = 1L; n <= loopTo; n += 2L)
        bArr[(int)((n - 1L) / 2L)] = Conversions.ToByte("&H" + Strings.Mid(sHex, (int)n, 2));
      Hex2Ret = bArr;
      return Hex2Ret;
    }

    public static string GetFileName(string flname, bool getdir) {
      var posn = default(int);
      int i;
      string fName;
      int fLen = flname.Length - 1;
      if (!getdir) {
        var loopTo = fLen;
        for (i = 0; i <= loopTo; i++) {
          if (Conversions.ToString(flname[i]) == @"\" | Conversions.ToString(flname[i]) == "/")
            posn = i;
        }
      } else {
        for (i = fLen; i >= 0; i -= 1) {
          if (Conversions.ToString(flname[i]) == @"\" | Conversions.ToString(flname[i]) == "/") {
            posn = i;
            break;
          }
        }
      }

      if (getdir)
        fName = Strings.Mid(flname, 1, posn);
      else
        fName = Strings.Right(flname, fLen - posn);
      return fName;
    }

    public static bool SearchListbox(ref ListBox listbx, TextBox searchbox, int startind, bool nxt) {
      if (!string.IsNullOrEmpty(searchbox.Text)) {
        if (!nxt) {
          for (int i = 0, loopTo = listbx.Items.Count - 1; i <= loopTo; i++) {
            if (Conversions.ToBoolean(listbx.Items[i].ToString().ToLower().Contains(searchbox.Text.ToLower()))) {
              listbx.SelectedIndex = i;
              return true;
            }
          }
        } else {
          for (int i = startind + 1, loopTo1 = listbx.Items.Count - 1; i <= loopTo1; i++) {
            if (Conversions.ToBoolean(listbx.Items[i].ToString().ToLower().Contains(searchbox.Text.ToLower()))) {
              listbx.SelectedIndex = i;
              return true;
            }
          }
        }

        listbx.SelectedIndex = -1;
        return false;
      }

      return default;
    }

    public static object GLPrint2D(string Text, Point Position, Color TextColor, IntPtr GLUTFONT, int XOffset, int YOffset, bool Shadow) {
      Gl.glMatrixMode(Gl.GL_PROJECTION);
      Gl.glPushMatrix();
      Gl.glLoadIdentity();
      Gl.glOrtho(0d, GlobalVars.winw, 0d, GlobalVars.winh, 0d, 1d);
      Gl.glMatrixMode(Gl.GL_MODELVIEW);
      Gl.glPushMatrix();
      Gl.glLoadIdentity();
      int XPos = Position.X;
      int YPos = Position.Y;
      if (Shadow) {
        // shadow (black - 0r, 0g, 0b)
        Gl.glColor3f(0f, 0f, 0f);
        Gl.glRasterPos2f(XPos + XOffset + 1, GlobalVars.winh - YPos + YOffset - 1);
        for (int a = 0, loopTo = Text.Length - 1; a <= loopTo; a++)
          Glut.glutBitmapCharacter(GLUTFONT, Strings.Asc(Text[a]));
      }

      // main text (white - 1r, 1g, 1b)
      Gl.glColor3ub(TextColor.R, TextColor.G, TextColor.B);
      Gl.glRasterPos2f(XPos + XOffset, GlobalVars.winh - YPos + YOffset);
      for (int a = 0, loopTo1 = Text.Length - 1; a <= loopTo1; a++)
        Glut.glutBitmapCharacter(GLUTFONT, Strings.Asc(Text[a]));
      Gl.glMatrixMode(Gl.GL_PROJECTION);
      Gl.glPopMatrix();
      Gl.glMatrixMode(Gl.GL_MODELVIEW);
      Gl.glPopMatrix();
      return default;
    }

    public static void UpdateCommand(ref Structs.N64DisplayList DL, uint CmdPos, byte newCmd, uint newHW, uint newLW) {
      {
        var withBlock = DL.Commands[(int)CmdPos];
        withBlock.CMDHigh = newHW;
        withBlock.CMDLow = newLW;
        withBlock.CMDParams[0] = newCmd;
        withBlock.DLPos = (int)CmdPos;
        int argOffset = 1;
        WriteInt24(ref withBlock.CMDParams, newLW, ref argOffset);
        int argOffset1 = 4;
        WriteInt32(ref withBlock.CMDParams, newHW, ref argOffset1);
      }
    }
  }
}