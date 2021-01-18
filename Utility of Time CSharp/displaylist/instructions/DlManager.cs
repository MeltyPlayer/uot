namespace UoT {
  /// <summary>
  ///   Class that manages a group of display lists. Parses models/animations,
  ///   creates textures, renders.
  /// </summary>
  public class DlManager : IDisplayListManager {
    public bool ShowBones { get; set; } = false;

    // TODO: Make this private.
    public bool HasLimbs { get; set; } = false;

    public void DoSomething() {
    }

    public IDisplayList GetDisplayListAtAddress(uint address) {
      throw new System.NotImplementedException();
    }
  }
}
