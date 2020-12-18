using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace UoT {
  [DesignerGenerated()]
  public partial class SetupDialog : Form {

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
      _OK_Button = new Button();
      _OK_Button.Click += new EventHandler(OK_Button_Click);
      _Cancel_Button = new Button();
      _Cancel_Button.Click += new EventHandler(Cancel_Button_Click);
      GroupBox1 = new GroupBox();
      _Button2 = new Button();
      _Button2.Click += new EventHandler(Button2_Click);
      TextBox2 = new TextBox();
      Label3 = new Label();
      FolderBrowserDialog1 = new FolderBrowserDialog();
      _OpenFileDialog1 = new OpenFileDialog();
      _OpenFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(OpenFileDialog1_FileOk);
      OpenFileDialog2 = new OpenFileDialog();
      GroupBox1.SuspendLayout();
      SuspendLayout();
      // 
      // OK_Button
      // 
      _OK_Button.Anchor = AnchorStyles.None;
      _OK_Button.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
      _OK_Button.Location = new Point(78, 110);
      _OK_Button.Name = "_OK_Button";
      _OK_Button.Size = new Size(67, 23);
      _OK_Button.TabIndex = 14;
      _OK_Button.Text = "&OK";
      // 
      // Cancel_Button
      // 
      _Cancel_Button.Anchor = AnchorStyles.None;
      _Cancel_Button.DialogResult = DialogResult.Cancel;
      _Cancel_Button.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
      _Cancel_Button.Location = new Point(151, 110);
      _Cancel_Button.Name = "_Cancel_Button";
      _Cancel_Button.Size = new Size(67, 23);
      _Cancel_Button.TabIndex = 15;
      _Cancel_Button.Text = "&Cancel";
      // 
      // GroupBox1
      // 
      GroupBox1.Controls.Add(_Button2);
      GroupBox1.Controls.Add(TextBox2);
      GroupBox1.Controls.Add(Label3);
      GroupBox1.Location = new Point(7, 12);
      GroupBox1.Name = "GroupBox1";
      GroupBox1.Size = new Size(279, 87);
      GroupBox1.TabIndex = 2;
      GroupBox1.TabStop = false;
      GroupBox1.Text = "Options";
      // 
      // Button2
      // 
      _Button2.Location = new Point(237, 41);
      _Button2.Name = "_Button2";
      _Button2.Size = new Size(28, 23);
      _Button2.TabIndex = 7;
      _Button2.Text = "...";
      _Button2.UseVisualStyleBackColor = true;
      // 
      // TextBox2
      // 
      TextBox2.Location = new Point(9, 43);
      TextBox2.Name = "TextBox2";
      TextBox2.Size = new Size(222, 20);
      TextBox2.TabIndex = 6;
      // 
      // Label3
      // 
      Label3.AutoSize = true;
      Label3.Location = new Point(6, 27);
      Label3.Name = "Label3";
      Label3.Size = new Size(104, 13);
      Label3.TabIndex = 7;
      Label3.Text = "Default Debug ROM";
      // 
      // OpenFileDialog1
      // 
      _OpenFileDialog1.Filter = "N64 ROMs (*.n64 *.v64 *.z64 *.bin)|*.n64;*.v64;*.z64;*.bin|All Files (*.*)|*.*";
      // 
      // OpenFileDialog2
      // 
      OpenFileDialog2.FileName = "Project64.exe";
      OpenFileDialog2.Filter = "Windows Executables (*.exe)|*.exe";
      // 
      // SetupDialog
      // 
      AcceptButton = _OK_Button;
      AutoScaleDimensions = new SizeF(6.0f, 13.0f);
      AutoScaleMode = AutoScaleMode.Font;
      CancelButton = _Cancel_Button;
      ClientSize = new Size(294, 143);
      Controls.Add(GroupBox1);
      Controls.Add(_OK_Button);
      Controls.Add(_Cancel_Button);
      FormBorderStyle = FormBorderStyle.FixedDialog;
      MaximizeBox = false;
      MinimizeBox = false;
      Name = "SetupDialog";
      ShowInTaskbar = false;
      StartPosition = FormStartPosition.CenterParent;
      Text = "Utility of Time Setup";
      GroupBox1.ResumeLayout(false);
      GroupBox1.PerformLayout();
      Load += new EventHandler(Dialog3_Load);
      ResumeLayout(false);
    }

    private Button _OK_Button;

    internal Button OK_Button {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _OK_Button;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_OK_Button != null) {
          _OK_Button.Click -= OK_Button_Click;
        }

        _OK_Button = value;
        if (_OK_Button != null) {
          _OK_Button.Click += OK_Button_Click;
        }
      }
    }

    private Button _Cancel_Button;

    internal Button Cancel_Button {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _Cancel_Button;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_Cancel_Button != null) {
          _Cancel_Button.Click -= Cancel_Button_Click;
        }

        _Cancel_Button = value;
        if (_Cancel_Button != null) {
          _Cancel_Button.Click += Cancel_Button_Click;
        }
      }
    }

    internal GroupBox GroupBox1;
    internal FolderBrowserDialog FolderBrowserDialog1;
    internal TextBox TextBox2;
    internal Label Label3;
    private Button _Button2;

    internal Button Button2 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _Button2;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_Button2 != null) {
          _Button2.Click -= Button2_Click;
        }

        _Button2 = value;
        if (_Button2 != null) {
          _Button2.Click += Button2_Click;
        }
      }
    }

    private OpenFileDialog _OpenFileDialog1;

    internal OpenFileDialog OpenFileDialog1 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _OpenFileDialog1;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_OpenFileDialog1 != null) {
          _OpenFileDialog1.FileOk -= OpenFileDialog1_FileOk;
        }

        _OpenFileDialog1 = value;
        if (_OpenFileDialog1 != null) {
          _OpenFileDialog1.FileOk += OpenFileDialog1_FileOk;
        }
      }
    }

    internal OpenFileDialog OpenFileDialog2;
  }
}