namespace UoT {
  public interface IDisplayList {
    F3DZEX Opcode { get; }

    uint High { get; }
    uint Low { get; }

    IDisplayListInstruction EntryPoint { get; }
  }

  public interface IDisplayListInstruction {
    byte Opcode { get; }

    uint Low { get; }
    uint High { get; }

    IDisplayListInstruction FirstChild { get; }
    IDisplayListInstruction NextSibling { get; }
  }
}
