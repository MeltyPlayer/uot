using System.Windows.Forms;

using UoT.memory.files;

namespace UoT.ui.main.files {
  public partial class ZFileTreeView : UserControl {
    public ZFileTreeView() => this.InitializeComponent();

    public void Populate(ZFiles zFiles) {
      var nodes = this.fileTreeView.Nodes;

      var modelsNode = nodes.Add("Actor models");
      foreach (var model in zFiles.Objects) {
        modelsNode.Nodes.Add(model.BetterFileName);
      }

      var actorCodeNode = nodes.Add("Actor code");
      foreach (var actorCode in zFiles.ActorCode) {
        actorCodeNode.Nodes.Add(actorCode.BetterFileName);
      }

      var scenesNode = nodes.Add("Scenes");
      foreach (var scene in zFiles.Scenes) {
        var sceneNode = scenesNode.Nodes.Add(scene.BetterFileName);

        foreach (var map in scene.Maps) {
          sceneNode.Nodes.Add(map.BetterFileName);
        }
      }

      var othersNode = nodes.Add("Others");
      foreach (var other in zFiles.Others) {
        othersNode.Nodes.Add(other.BetterFileName);
      }
    }

    public delegate void FileSelectedHandler(IZFile file);
    public event FileSelectedHandler FileSelected = delegate {};
  }
}
