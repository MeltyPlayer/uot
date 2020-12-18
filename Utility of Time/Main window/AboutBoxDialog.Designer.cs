using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace UoT {
  [DesignerGenerated()]
  public partial class AboutBoxDialog : Form {

    // Form overrides dispose to clean up the component list.
    [DebuggerNonUserCode()]
    protected override void Dispose(bool disposing) {
      if (disposing && components is object) {
        components.Dispose();
      }

      base.Dispose(disposing);
    }


    // Required by the Windows Form Designer
    private System.ComponentModel.IContainer components;

    // NOTE: The following procedure is required by the Windows Form Designer
    // It can be modified using the Windows Form Designer.  
    // Do not modify it using the code editor.
    [DebuggerStepThrough()]
    private void InitializeComponent() {
      var resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutBoxDialog));
      Button1 = new Button();
      Label3 = new Label();
      _LinkLabel1 = new LinkLabel();
      _LinkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(LinkLabel1_LinkClicked_1);
      GroupBox1 = new GroupBox();
      _LinkLabel3 = new LinkLabel();
      _LinkLabel3.LinkClicked += new LinkLabelLinkClickedEventHandler(LinkLabel3_LinkClicked);
      _LinkLabel2 = new LinkLabel();
      _LinkLabel2.LinkClicked += new LinkLabelLinkClickedEventHandler(LinkLabel2_LinkClicked);
      Label1 = new Label();
      GroupBox1.SuspendLayout();
      SuspendLayout();
      // 
      // Button1
      // 
      Button1.Location = new Point(14, 74);
      Button1.Name = "Button1";
      Button1.Size = new Size(75, 23);
      Button1.TabIndex = 6;
      Button1.Text = "&OK";
      Button1.UseVisualStyleBackColor = true;
      // 
      // Label3
      // 
      Label3.AutoSize = true;
      Label3.Font = new Font("Arial", 9.0f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
      Label3.Location = new Point(11, 15);
      Label3.Name = "Label3";
      Label3.Size = new Size(107, 15);
      Label3.TabIndex = 8;
      Label3.Text = "Version 0.95 BETA";
      // 
      // LinkLabel1
      // 
      _LinkLabel1.AutoSize = true;
      _LinkLabel1.Location = new Point(12, 45);
      _LinkLabel1.Name = "_LinkLabel1";
      _LinkLabel1.Size = new Size(79, 13);
      _LinkLabel1.TabIndex = 10;
      _LinkLabel1.TabStop = true;
      _LinkLabel1.Text = "cooliscool.NET";
      // 
      // GroupBox1
      // 
      GroupBox1.Controls.Add(_LinkLabel3);
      GroupBox1.Controls.Add(_LinkLabel2);
      GroupBox1.Location = new Point(141, 9);
      GroupBox1.Name = "GroupBox1";
      GroupBox1.Size = new Size(106, 88);
      GroupBox1.TabIndex = 11;
      GroupBox1.TabStop = false;
      GroupBox1.Text = "Useful links";
      // 
      // LinkLabel3
      // 
      _LinkLabel3.AutoSize = true;
      _LinkLabel3.Location = new Point(12, 59);
      _LinkLabel3.Name = "_LinkLabel3";
      _LinkLabel3.Size = new Size(20, 13);
      _LinkLabel3.TabIndex = 1;
      _LinkLabel3.TabStop = true;
      _LinkLabel3.Text = "Jul";
      // 
      // LinkLabel2
      // 
      _LinkLabel2.AutoSize = true;
      _LinkLabel2.Location = new Point(12, 25);
      _LinkLabel2.Name = "_LinkLabel2";
      _LinkLabel2.Size = new Size(79, 13);
      _LinkLabel2.TabIndex = 0;
      _LinkLabel2.TabStop = true;
      _LinkLabel2.Text = "Spinout's forum";
      // 
      // Label1
      // 
      Label1.AutoSize = true;
      Label1.Location = new Point(95, 390);
      Label1.Name = "Label1";
      Label1.Size = new Size(0, 13);
      Label1.TabIndex = 12;
      // 
      // AboutBoxDialog
      // 
      AcceptButton = Button1;
      AutoScaleDimensions = new SizeF(6.0f, 13.0f);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(262, 105);
      Controls.Add(Label1);
      Controls.Add(GroupBox1);
      Controls.Add(_LinkLabel1);
      Controls.Add(Label3);
      Controls.Add(Button1);
      FormBorderStyle = FormBorderStyle.FixedDialog;
      Icon = (Icon)resources.GetObject("$this.Icon");
      MaximizeBox = false;
      MinimizeBox = false;
      Name = "AboutBoxDialog";
      Padding = new Padding(9);
      ShowInTaskbar = false;
      StartPosition = FormStartPosition.CenterParent;
      Text = "Utility of Time";
      GroupBox1.ResumeLayout(false);
      GroupBox1.PerformLayout();
      ResumeLayout(false);
      PerformLayout();
    }

    internal Button Button1;
    internal Label Label3;
    private LinkLabel _LinkLabel1;

    internal LinkLabel LinkLabel1 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _LinkLabel1;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_LinkLabel1 != null) {
          _LinkLabel1.LinkClicked -= LinkLabel1_LinkClicked_1;
        }

        _LinkLabel1 = value;
        if (_LinkLabel1 != null) {
          _LinkLabel1.LinkClicked += LinkLabel1_LinkClicked_1;
        }
      }
    }

    internal GroupBox GroupBox1;
    private LinkLabel _LinkLabel2;

    internal LinkLabel LinkLabel2 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _LinkLabel2;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_LinkLabel2 != null) {
          _LinkLabel2.LinkClicked -= LinkLabel2_LinkClicked;
        }

        _LinkLabel2 = value;
        if (_LinkLabel2 != null) {
          _LinkLabel2.LinkClicked += LinkLabel2_LinkClicked;
        }
      }
    }

    private LinkLabel _LinkLabel3;

    internal LinkLabel LinkLabel3 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _LinkLabel3;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_LinkLabel3 != null) {
          _LinkLabel3.LinkClicked -= LinkLabel3_LinkClicked;
        }

        _LinkLabel3 = value;
        if (_LinkLabel3 != null) {
          _LinkLabel3.LinkClicked += LinkLabel3_LinkClicked;
        }
      }
    }

    internal Label Label1;
  }
}