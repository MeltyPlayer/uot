using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace UoT {
  [DesignerGenerated()]
  public partial class ActorPresets : Form {

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
      Button1 = new Button();
      Button2 = new Button();
      Button3 = new Button();
      _ActorSelection = new TreeView();
      _ActorSelection.AfterSelect += new TreeViewEventHandler(ActorSelection_AfterSelect);
      SuspendLayout();
      // 
      // Button1
      // 
      Button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      Button1.DialogResult = DialogResult.Cancel;
      Button1.Location = new Point(195, 447);
      Button1.Name = "Button1";
      Button1.Size = new Size(75, 23);
      Button1.TabIndex = 0;
      Button1.Text = "&Close";
      Button1.UseVisualStyleBackColor = true;
      // 
      // Button2
      // 
      Button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      Button2.Location = new Point(33, 447);
      Button2.Name = "Button2";
      Button2.Size = new Size(75, 23);
      Button2.TabIndex = 1;
      Button2.Text = "&Apply";
      Button2.UseVisualStyleBackColor = true;
      // 
      // Button3
      // 
      Button3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      Button3.Location = new Point(114, 447);
      Button3.Name = "Button3";
      Button3.Size = new Size(75, 23);
      Button3.TabIndex = 7;
      Button3.Text = "&Refresh";
      Button3.UseVisualStyleBackColor = true;
      // 
      // ActorSelection
      // 
      _ActorSelection.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

      _ActorSelection.Location = new Point(12, 12);
      _ActorSelection.Name = "_ActorSelection";
      _ActorSelection.Size = new Size(284, 423);
      _ActorSelection.TabIndex = 8;
      // 
      // ActorPresets
      // 
      AutoScaleDimensions = new SizeF(6.0f, 13.0f);
      AutoScaleMode = AutoScaleMode.Font;
      CancelButton = Button1;
      ClientSize = new Size(308, 482);
      Controls.Add(_ActorSelection);
      Controls.Add(Button3);
      Controls.Add(Button2);
      Controls.Add(Button1);
      FormBorderStyle = FormBorderStyle.SizableToolWindow;
      MaximizeBox = false;
      MinimizeBox = false;
      Name = "ActorPresets";
      ShowInTaskbar = false;
      StartPosition = FormStartPosition.CenterParent;
      Text = "Actor Presets";
      Load += new EventHandler(ActorPresets_Load);
      ResumeLayout(false);
    }

    internal Button Button1;
    internal Button Button2;
    internal Button Button3;
    private TreeView _ActorSelection;

    internal TreeView ActorSelection {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _ActorSelection;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_ActorSelection != null) {
          _ActorSelection.AfterSelect -= ActorSelection_AfterSelect;
        }

        _ActorSelection = value;
        if (_ActorSelection != null) {
          _ActorSelection.AfterSelect += ActorSelection_AfterSelect;
        }
      }
    }
  }
}