namespace UoT {
  public struct N64DisplayList {
    public bool Skip;
    public bool Highlight;
    public Color3UByte PickCol;
    public ZSegment StartPos;
    public ZSegment EndPos;
    public int CommandCount;
    public DLCommand[] Commands;
  }

  public struct DLCommand {
    public byte[] CMDParams;
    public uint CMDHigh;
    public uint CMDLow;
    public string Name;
    public int DLPos;
  }
}
