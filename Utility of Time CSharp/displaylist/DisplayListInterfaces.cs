namespace UoT {
  public interface IDisplayList {
    F3DZEX Opcode { get; }

    uint High { get; }
    uint Low { get; }

    IDisplayList FirstChild { get; }
    IDisplayList NextSibling { get; }
  }
}
