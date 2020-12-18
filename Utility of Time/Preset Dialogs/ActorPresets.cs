using System;
using System.Windows.Forms;

namespace UoT {
  public partial class ActorPresets {
    public ActorPresets() {
      InitializeComponent();
      _ActorSelection.Name = "ActorSelection";
    }

    private int ind = 0;
    private PresetReader ActorDBReader = new PresetReader();

    private void ActorPresets_Load(object sender, EventArgs e) {
      if (GlobalVars.ActorDataBase.Length > 0) {
        int curParent = 0;
        for (int i = 0, loopTo = GlobalVars.ActorDataBase.Length - 1; i <= loopTo; i++) {
          ActorSelection.Nodes.Add(GlobalVars.ActorDataBase[i].desc);
          if (GlobalVars.ActorDataBase[i].var is object) {
            for (int i1 = 0, loopTo1 = GlobalVars.ActorDataBase[i].var.Length - 1; i1 <= loopTo1; i1++)
              ActorSelection.Nodes[curParent].Nodes.Add(GlobalVars.ActorDataBase[i].var[i1].desc);
          }

          curParent += 1;
        }
      }
    }

    private void ActorSelection_AfterSelect(object sender, TreeViewEventArgs e) {
    }
  }
}