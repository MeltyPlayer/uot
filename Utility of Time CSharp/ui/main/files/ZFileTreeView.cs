using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

using UoT.common.fuzzy;
using UoT.memory.files;

namespace UoT.ui.main.files {
  public partial class ZFileTreeView : UserControl {
    // TODO: Add tests.
    // TODO: Move the fuzzy logic to a separate reusable component.
    // TODO: Add support for different sorting systems.
    // TODO: Add support for different hierarchies.
    // TODO: Clean up the logic here.

    private ZFiles data_;
    private LinkedList<ZFileNode> zFileNodes_ = new LinkedList<ZFileNode>();
    private readonly FuzzyTreeComparer comparer_;

    private readonly IFuzzySearchDictionary<ZFileNode> filterImpl_ =
        new SymSpellFuzzySearchDictionary<ZFileNode>();

    public delegate void FileSelectedHandler(IZFile file);

    public event FileSelectedHandler FileSelected = delegate {};

    // TODO: Clean this up.
    private class ZFileNode {
      public string Text;
      public ZFileNode Parent;
      public TreeNode TreeNode;
      public IZFile ZFile;
      public ISet<string> Keywords;
      public double MatchPercentage;
      public IList<ZFileNode> AllChildZFileNodes = new List<ZFileNode>();
    }

    public ZFileTreeView() {
      this.InitializeComponent();

      this.filterTextBox_.TextChanged += (sender, args) => { this.Filter_(); };

      this.fileTreeView_.AfterSelect += (sender, args) => {
        var selectedFile = this.GetSelectedFile_();

        if (selectedFile != null) {
          this.FileSelected.Invoke(selectedFile);
        }
      };

      this.fileTreeView_.TreeViewNodeSorter =
          this.comparer_ = new FuzzyTreeComparer();
    }

    public void Populate(ZFiles zFiles) {
      this.fileTreeView_.BeginUpdate();
      this.comparer_.Enabled = false;

      var nodes = this.fileTreeView_.Nodes;

      var modelsNode = nodes.Add("Actor models");
      this.AddZFileNodeFor(null, modelsNode);
      foreach (var model in zFiles.Objects) {
        var modelNode = modelsNode.Nodes.Add(model.BetterFileName);
        this.AddZFileNodeFor(model, modelNode);
      }

      var actorCodeNode = nodes.Add("Actor code");
      this.AddZFileNodeFor(null, actorCodeNode);
      foreach (var code in zFiles.ActorCode) {
        var codeNode = actorCodeNode.Nodes.Add(code.BetterFileName);
        this.AddZFileNodeFor(code, codeNode);
      }

      var scenesNode = nodes.Add("Scenes");
      this.AddZFileNodeFor(null, scenesNode);
      foreach (var scene in zFiles.Scenes) {
        var sceneNode = scenesNode.Nodes.Add(scene.BetterFileName);
        this.AddZFileNodeFor(scene, sceneNode);

        foreach (var map in scene.Maps) {
          var mapNode = sceneNode.Nodes.Add(map.BetterFileName);
          this.AddZFileNodeFor(map, mapNode);
        }
      }

      var othersNode = nodes.Add("Others");
      this.AddZFileNodeFor(null, othersNode);
      foreach (var other in zFiles.Others) {
        var otherNode = othersNode.Nodes.Add(other.BetterFileName);
        this.AddZFileNodeFor(other, otherNode);
      }

      this.InitializeAutocomplete_();

      this.fileTreeView_.EndUpdate();
      this.comparer_.Enabled = true;
    }

    private void AddZFileNodeFor(IZFile zFile, TreeNode treeNode) {
      var parentZFileNode = (ZFileNode) treeNode.Parent?.Tag;

      var zFileNode = new ZFileNode {
          Parent = parentZFileNode,
          Text = treeNode.Text,
          TreeNode = treeNode,
          ZFile = zFile,
      };

      this.zFileNodes_.AddLast(zFileNode);
      parentZFileNode?.AllChildZFileNodes?.Add(zFileNode);

      // Gathers keywords.
      var keywords = zFileNode.Keywords = new HashSet<string>();

      if (zFile != null) {
        var fileName = zFile.FileName;
        keywords.Add(fileName);

        var betterFileName = zFile.BetterFileName;
        if (!string.IsNullOrEmpty(betterFileName)) {
          keywords.Add(betterFileName);
        }

        foreach (var keyword in keywords) {
          this.filterImpl_.Add(keyword, zFileNode);
        }
      }

      // TODO: Is there a better option that doesn't use boxing?
      // Adds as tag.
      treeNode.Tag = zFileNode;
    }

    private void InitializeAutocomplete_() {
      var allAutocompleteKeywords = new AutoCompleteStringCollection();

      foreach (var zFileNode in this.zFileNodes_) {
        foreach (var keyword in zFileNode.Keywords) {
          allAutocompleteKeywords.Add(keyword.ToLower());
        }
      }

      this.filterTextBox_.AutoCompleteCustomSource = allAutocompleteKeywords;
    }

    private IZFile GetSelectedFile_() {
      var zFileNode = (ZFileNode) this.fileTreeView_.SelectedNode?.Tag;
      return zFileNode?.ZFile;
    }

    // TODO: Debounce this method.
    private void Filter_() {
      var filterText = this.filterTextBox_.Text.ToLower();

      this.ResetMatchPercentages_();

      this.fileTreeView_.BeginUpdate();
      this.comparer_.Enabled = false;

      this.ClearTree_();

      if (string.IsNullOrEmpty(filterText)) {
        this.fileTreeView_.TreeViewNodeSorter = null;
        this.HideMatchesLessThan_(0);
      } else {
        const float matchPercentage = 20;

        var matches = this.filterImpl_.Search(filterText, matchPercentage);

        this.PropagateMatchPercentages_(matches);
        this.HideMatchesLessThan_(matchPercentage);
      }

      this.fileTreeView_.EndUpdate();
      this.comparer_.Enabled = true;
    }

    private void ResetMatchPercentages_() {
      foreach (var zFileNode in this.zFileNodes_) {
        zFileNode.MatchPercentage = 0;
      }
    }

    private void ClearTree_(TreeNode root = null) {
      var treeNodes = (root == null)
                          ? this.fileTreeView_.Nodes
                          : root.Nodes;

      foreach (var treeNode in treeNodes) {
        this.ClearTree_((TreeNode) treeNode);
      }

      treeNodes.Clear();
    }

    private void PropagateMatchPercentages_(
        IEnumerable<IFuzzySearchResult<ZFileNode>> matches) {
      foreach (var match in matches) {
        ZFileTreeView.SetMatchPercentage_(match.AssociatedData,
                                          match.MatchPercentage);
      }
    }

    private static void SetMatchPercentage_(
        ZFileNode zFileNode,
        double matchPercentage) {
      if (matchPercentage <= zFileNode.MatchPercentage) {
        return;
      }
      zFileNode.MatchPercentage = matchPercentage;

      var parentZFileNode = zFileNode.Parent;
      if (parentZFileNode == null) {
        return;
      }

      ZFileTreeView.SetMatchPercentage_(parentZFileNode, matchPercentage);
    }

    private void HideMatchesLessThan_(
        double minMatchPercentage,
        ZFileNode root = null) {
      // TODO: Merge these for loops.
      if (root == null) {
        foreach (var zFileNode in this.zFileNodes_) {
          if (zFileNode.Parent != null) {
            continue;
          }

          if (zFileNode.MatchPercentage < minMatchPercentage) {
            continue;
          }

          var treeNode = zFileNode.TreeNode;
          treeNode.Text = minMatchPercentage < .001f
                              ? zFileNode.Text
                              : $"{zFileNode.Text} ({zFileNode.MatchPercentage:0.0}%)";
          this.fileTreeView_.Nodes.Add(treeNode);

          this.HideMatchesLessThan_(minMatchPercentage, zFileNode);
        }
      } else {
        foreach (var zFileNode in root.AllChildZFileNodes) {
          if (zFileNode.MatchPercentage < minMatchPercentage) {
            continue;
          }

          var treeNode = zFileNode.TreeNode;
          treeNode.Text = minMatchPercentage < .001f
                              ? zFileNode.Text
                              : $"{zFileNode.Text} ({zFileNode.MatchPercentage:0.0}%)";
          root.TreeNode.Nodes.Add(treeNode);

          this.HideMatchesLessThan_(minMatchPercentage, zFileNode);
        }
      }
    }

    private class FuzzyTreeComparer : IComparer {
      public bool Enabled { get; set; }

      public int Compare(object lhs, object rhs) {
        if (!this.Enabled) {
          return 0;
        }

        // TODO: Can we eliminate unboxing (casting from object)?
        var lhsZFileNode = (ZFileNode) (((TreeNode) lhs).Tag);
        var rhsZFileNode = (ZFileNode) (((TreeNode) rhs).Tag);

        return -lhsZFileNode.MatchPercentage.CompareTo(
                   rhsZFileNode.MatchPercentage);
      }
    }
  }
}