namespace UoT {
  public interface IDisplayList {
    F3DZEX Opcode { get; }

    uint High { get; }
    uint Low { get; }

    IDisplayListInstruction EntryPoint { get; }
  }

  public interface IDisplayListInstruction {
    F3DZEX Opcode { get; }

    uint High { get; }
    uint Low { get; }

    IDisplayListInstruction FirstChild { get; }
    IDisplayListInstruction NextSibling { get; }
  }
}
