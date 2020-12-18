using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace UoT {
  [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
  public partial class BankSetup : Form {

    // Form overrides dispose to clean up the component list.
    [DebuggerNonUserCode()]
    protected override void Dispose(bool disposing) {
      try {
        if (disposing && components is object) {
          components.Dispose();
        }
      } finally {
        base.Dispose(disposing);
      }
    }

    // Required by the Windows Form Designer
    private System.ComponentModel.IContainer components;

    // NOTE: The following procedure is required by the Windows Form Designer
    // It can be modified using the Windows Form Designer.  
    // Do not modify it using the code editor.
    [DebuggerStepThrough()]
    private void InitializeComponent() {
      var TreeNode1 = new TreeNode(@"ROM\Gameplay_Keep.zdata");
      var TreeNode2 = new TreeNode("0x04", new TreeNode[] { TreeNode1 });
      var TreeNode3 = new TreeNode(@"ROM\Gameplay_Field_Keep");
      var TreeNode4 = new TreeNode(@"ROM\Gameplay_Dangeon_Keep.zdata");
      var TreeNode5 = new TreeNode("0x05", new TreeNode[] { TreeNode3, TreeNode4 });
      var TreeNode6 = new TreeNode(@"ROM\ObjectFile");
      var TreeNode7 = new TreeNode(@"ROM\object_oE_anime.zobj");
      var TreeNode8 = new TreeNode(@"ROM\object_o_anime.zobj");
      var TreeNode9 = new TreeNode("Animation", new TreeNode[] { TreeNode6, TreeNode7, TreeNode8 });
      var TreeNode10 = new TreeNode("Banks", new TreeNode[] { TreeNode2, TreeNode5, TreeNode9 });
      TreeView1 = new TreeView();
      SuspendLayout();
      // 
      // TreeView1
      // 
      TreeView1.Location = new Point(12, 12);
      TreeView1.Name = "TreeView1";
      TreeNode1.Name = "Node4";
      TreeNode1.Text = @"ROM\Gameplay_Keep.zdata";
      TreeNode2.Name = "Node1";
      TreeNode2.Text = "0x04";
      TreeNode3.Name = "Node5";
      TreeNode3.Text = @"ROM\Gameplay_Field_Keep";
      TreeNode4.Name = "Node7";
      TreeNode4.Text = @"ROM\Gameplay_Dangeon_Keep.zdata";
      TreeNode5.Name = "Node2";
      TreeNode5.Text = "0x05";
      TreeNode6.Name = "Node8";
      TreeNode6.Text = @"ROM\ObjectFile";
      TreeNode7.Name = "Node9";
      TreeNode7.Text = @"ROM\object_oE_anime.zobj";
      TreeNode8.Name = "Node10";
      TreeNode8.Text = @"ROM\object_o_anime.zobj";
      TreeNode9.Name = "Node3";
      TreeNode9.Text = "Animation";
      TreeNode10.Name = "Node0";
      TreeNode10.Text = "Banks";
      TreeView1.Nodes.AddRange(new TreeNode[] { TreeNode10 });
      TreeView1.Size = new Size(202, 332);
      TreeView1.TabIndex = 0;
      // 
      // ObjectExchange
      // 
      AutoScaleDimensions = new SizeF(6.0f, 13.0f);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(225, 423);
      Controls.Add(TreeView1);
      Name = "ObjectExchange";
      Text = "Bank setup";
      ResumeLayout(false);
    }

    public TreeView TreeView1;
  }
}