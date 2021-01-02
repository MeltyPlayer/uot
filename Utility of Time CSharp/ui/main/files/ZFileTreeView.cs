using System.Collections.Generic;
using System.Windows.Forms;

using UoT.memory.files;

namespace UoT.ui.main.files {
  public partial class ZFileTreeView : UserControl {
    private readonly IDictionary<TreeNode, IZFile> nodeToZFile_ =
        new Dictionary<TreeNode, IZFile>();

    public delegate void FileSelectedHandler(IZFile file);

    public event FileSelectedHandler FileSelected = delegate {};

    public ZFileTreeView() {
      this.InitializeComponent();

      this.fileTreeView_.AfterSelect += (sender, args) => {
        var selectedFile = this.GetSelectedFile_();

        if (selectedFile != null) {
          this.FileSelected.Invoke(selectedFile);
        }
      };
    }

    public void Populate(ZFiles zFiles) {
      var nodes = this.fileTreeView_.Nodes;

      var modelsNode = nodes.Add("Actor models");
      foreach (var model in zFiles.Objects) {
        var modelNode = modelsNode.Nodes.Add(model.BetterFileName);
        this.nodeToZFile_.Add(modelNode, model);
      }

      var actorCodeNode = nodes.Add("Actor code");
      foreach (var code in zFiles.ActorCode) {
        var codeNode = actorCodeNode.Nodes.Add(code.BetterFileName);
        this.nodeToZFile_.Add(codeNode, code);
      }

      var scenesNode = nodes.Add("Scenes");
      foreach (var scene in zFiles.Scenes) {
        var sceneNode = scenesNode.Nodes.Add(scene.BetterFileName);
        this.nodeToZFile_.Add(sceneNode, scene);


        foreach (var map in scene.Maps) {
          var mapNode = sceneNode.Nodes.Add(map.BetterFileName);
          this.nodeToZFile_.Add(mapNode, map);
        }
      }

      var othersNode = nodes.Add("Others");
      foreach (var other in zFiles.Others) {
        var otherNode = othersNode.Nodes.Add(other.BetterFileName);
        this.nodeToZFile_.Add(otherNode, other);
      }
    }

    private IZFile GetSelectedFile_() {
      this.nodeToZFile_.TryGetValue(this.fileTreeView_.SelectedNode,
                                    out var zFile);
      return zFile;
    }
  }
}