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
    public F3DZEX Opcode { get; }

    public byte[] CMDParams { get; set; }

    public uint High {get; set; }
    public uint Low { get; set; }

    public string Name { get; set; }
    public int DLPos { get; set; }

    public IDisplayListInstruction FirstChild { get; set; }
    public IDisplayListInstruction NextSibling { get; set; }
  }
}
