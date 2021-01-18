using System.Collections.Generic;

namespace UoT {
  public class N64DisplayList {
    public bool Skip;
    public ZSegment StartPos;
    public ZSegment EndPos;
    public int CommandCount;
    public DLCommand[] Commands;

    // Picker
    public bool Highlight { get; set; }
    public Color3UByte PickCol { get; set; }
  }

  public class DLCommand : IDisplayListInstruction {
    private byte opcode_;

    public byte Opcode {
      get => this.opcode_;
      private set {
        this.opcode_ = value;
        this.Name = this.GetNameOfOpcode_(value);
      }
    }

    public string Name { get; private set; }


    public byte[] CMDParams { get; } = new byte[8];
    public uint Low { get; private set; }
    public uint High { get; private set; }

    public IDisplayListInstruction FirstChild { get; set; }
    public IDisplayListInstruction NextSibling { get; set; }

    public DLCommand() {}
    public DLCommand(byte opcode) => this.Update(opcode, 0, 0);
    public DLCommand(IList<byte> src, uint offset) => this.Update(src, offset);
    public DLCommand(byte opcode, uint low, uint high)
      => this.Update(opcode, low, high);
    public DLCommand(uint low, uint high) => this.Update(low, high);


    public void Update(IList<byte> src, uint offset)
      => this.Update(IoUtil.ReadUInt32(src, offset),
                     IoUtil.ReadUInt32(src, offset + 4));

    public void Update(byte opcode, uint low, uint high)
      => this.Update((uint) ((opcode << 24) | (low & 0x00ffffff)),
                     high);

    public void Update(uint low, uint high) {
      this.Low = low & 0x00ffffff;
      for (var i = 0; i < 4; ++i) {
        this.CMDParams[i] = (byte) IoUtil.ShiftR(low, (3 - i) * 8, 8);
      }

      this.High = high;
      for (var i = 0; i < 4; ++i) {
        this.CMDParams[4 + i] = (byte) IoUtil.ShiftR(high, (3 - i) * 8, 8);
      }

      this.Opcode = this.CMDParams[0];
    }

    private string GetNameOfOpcode_(byte opcode) {
      switch (opcode) {
        case (byte) RDP.G_RDPPIPESYNC:
          return "G_RDPPIPESYNC (unemulated)";
        case (byte) RDP.G_RDPLOADSYNC:
          return "G_RDPLOADSYNC (unemulated)";
        case (byte) RDP.G_SETENVCOLOR:
          return "G_SETENVCOLOR";
        case (byte) RDP.G_SETPRIMCOLOR:
          return "G_SETPRIMCOLOR";
        case (byte) RDP.G_SETTIMG:
          return "G_SETTIMG";
        case (byte) RDP.G_LOADTLUT:
          return "G_LOADTLUT";
        case (byte) RDP.G_LOADBLOCK:
          return "G_LOADBLOCK";
        case (byte) RDP.G_SETTILESIZE:
          return "G_SETTILESIZE";
        case (byte) RDP.G_SETTILE:
          return "G_SETTILE";
        case (byte) RDP.G_SETCOMBINE:
          return "G_SETCOMBINE";
        case (byte) F3DZEX.TEXTURE:
          return "F3DEX2_TEXTURE";
        case (byte) F3DZEX.GEOMETRYMODE:
          return "F3DEX2_GEOMETRYMODE";
        case (byte) F3DZEX.SETOTHERMODE_H:
          return "F3DEX2_SETOTHERMODE_H (partial)";
        case (byte) F3DZEX.SETOTHERMODE_L:
          return "F3DEX2_SETOTHERMODE_L";
        case (byte) F3DZEX.MTX:
          return "F3DEX2_MTX (unemulated)";
        case (byte) F3DZEX.VTX:
          return "F3DEX2_VTX";
        case (byte) F3DZEX.MODIFYVTX:
          return "F3DEX2_MODIFYVTX";
        case (byte) F3DZEX.TRI1:
          return "F3DEX2_TRI1";
        case (byte) F3DZEX.TRI2:
          return "F3DEX2_TRI2";
        case (byte) F3DZEX.CULLDL:
          return "F3DEX2_CULLDL (unemulated)";
        case (byte) F3DZEX.DL:
          return "F3DEX2_DL (unemulated)";
        case (byte) F3DZEX.ENDDL:
          return "F3DEX2_ENDDL";
        default:
          return "Unrecognized (0x" + opcode.ToString("X2") + ")";
      }
    }
  }
}