using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace UoT {
  [DesignerGenerated()]
  public partial class CombinerEditor : Form {

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
      Label1 = new Label();
      Label2 = new Label();
      Label3 = new Label();
      Label4 = new Label();
      _cA0 = new ComboBox();
      _cA0.SelectedIndexChanged += new EventHandler(cA0_SelectedIndexChanged);
      _cB0 = new ComboBox();
      _cB0.SelectedIndexChanged += new EventHandler(cB0_SelectedIndexChanged);
      _cC0 = new ComboBox();
      _cC0.SelectedIndexChanged += new EventHandler(cC0_SelectedIndexChanged);
      _cD0 = new ComboBox();
      _cD0.SelectedIndexChanged += new EventHandler(cD0_SelectedIndexChanged);
      Label5 = new Label();
      Label6 = new Label();
      Label7 = new Label();
      Label8 = new Label();
      Label9 = new Label();
      Label10 = new Label();
      _cD1 = new ComboBox();
      _cD1.SelectedIndexChanged += new EventHandler(cD1_SelectedIndexChanged);
      _cC1 = new ComboBox();
      _cC1.SelectedIndexChanged += new EventHandler(cC1_SelectedIndexChanged);
      _cB1 = new ComboBox();
      _cB1.SelectedIndexChanged += new EventHandler(cB1_SelectedIndexChanged);
      _cA1 = new ComboBox();
      _cA1.SelectedIndexChanged += new EventHandler(cA1_SelectedIndexChanged);
      Label11 = new Label();
      Label12 = new Label();
      Label13 = new Label();
      _aD0 = new ComboBox();
      _aD0.SelectedIndexChanged += new EventHandler(aD0_SelectedIndexChanged);
      _aC0 = new ComboBox();
      _aC0.SelectedIndexChanged += new EventHandler(aC0_SelectedIndexChanged);
      _aB0 = new ComboBox();
      _aB0.SelectedIndexChanged += new EventHandler(aB0_SelectedIndexChanged);
      _aA0 = new ComboBox();
      _aA0.SelectedIndexChanged += new EventHandler(aA0_SelectedIndexChanged);
      Label14 = new Label();
      Label15 = new Label();
      Label16 = new Label();
      _aD1 = new ComboBox();
      _aD1.SelectedIndexChanged += new EventHandler(aD1_SelectedIndexChanged);
      _aC1 = new ComboBox();
      _aC1.SelectedIndexChanged += new EventHandler(aC1_SelectedIndexChanged);
      _aB1 = new ComboBox();
      _aB1.SelectedIndexChanged += new EventHandler(aB1_SelectedIndexChanged);
      _aA1 = new ComboBox();
      _aA1.SelectedIndexChanged += new EventHandler(aA1_SelectedIndexChanged);
      _CompiledCmbCmd = new TextBox();
      _CompiledCmbCmd.TextChanged += new EventHandler(CompiledCmbCmd_TextChanged);
      Label17 = new Label();
      _PrimR = new Button();
      _PrimR.Click += new EventHandler(PrimR_Click);
      EnvR = new Button();
      ColorSelector = new ColorDialog();
      EnvA = new Button();
      PrimA = new Button();
      SuspendLayout();
      // 
      // Label1
      // 
      Label1.AutoSize = true;
      Label1.Location = new Point(9, 24);
      Label1.Name = "Label1";
      Label1.Size = new Size(40, 13);
      Label1.TabIndex = 0;
      Label1.Text = "Color 1";
      // 
      // Label2
      // 
      Label2.AutoSize = true;
      Label2.Location = new Point(9, 64);
      Label2.Name = "Label2";
      Label2.Size = new Size(40, 13);
      Label2.TabIndex = 1;
      Label2.Text = "Color 2";
      // 
      // Label3
      // 
      Label3.AutoSize = true;
      Label3.Location = new Point(9, 106);
      Label3.Name = "Label3";
      Label3.Size = new Size(43, 13);
      Label3.TabIndex = 2;
      Label3.Text = "Alpha 1";
      // 
      // Label4
      // 
      Label4.AutoSize = true;
      Label4.Location = new Point(9, 148);
      Label4.Name = "Label4";
      Label4.Size = new Size(43, 13);
      Label4.TabIndex = 3;
      Label4.Text = "Alpha 2";
      // 
      // cA0
      // 
      _cA0.DropDownStyle = ComboBoxStyle.DropDownList;
      _cA0.FormattingEnabled = true;
      _cA0.Location = new Point(12, 40);
      _cA0.Name = "_cA0";
      _cA0.Size = new Size(121, 21);
      _cA0.TabIndex = 4;
      // 
      // cB0
      // 
      _cB0.DropDownStyle = ComboBoxStyle.DropDownList;
      _cB0.FormattingEnabled = true;
      _cB0.Location = new Point(153, 40);
      _cB0.Name = "_cB0";
      _cB0.Size = new Size(121, 21);
      _cB0.TabIndex = 5;
      // 
      // cC0
      // 
      _cC0.DropDownStyle = ComboBoxStyle.DropDownList;
      _cC0.FormattingEnabled = true;
      _cC0.Location = new Point(301, 40);
      _cC0.Name = "_cC0";
      _cC0.Size = new Size(121, 21);
      _cC0.TabIndex = 6;
      // 
      // cD0
      // 
      _cD0.DropDownStyle = ComboBoxStyle.DropDownList;
      _cD0.FormattingEnabled = true;
      _cD0.Location = new Point(450, 40);
      _cD0.Name = "_cD0";
      _cD0.Size = new Size(121, 21);
      _cD0.TabIndex = 7;
      // 
      // Label5
      // 
      Label5.AutoSize = true;
      Label5.Font = new Font("Microsoft Sans Serif", 11.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
      Label5.Location = new Point(281, 42);
      Label5.Name = "Label5";
      Label5.Size = new Size(14, 18);
      Label5.TabIndex = 8;
      Label5.Text = "*";
      // 
      // Label6
      // 
      Label6.AutoSize = true;
      Label6.Font = new Font("Microsoft Sans Serif", 11.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
      Label6.Location = new Point(137, 39);
      Label6.Name = "Label6";
      Label6.Size = new Size(13, 18);
      Label6.TabIndex = 9;
      Label6.Text = "-";
      // 
      // Label7
      // 
      Label7.AutoSize = true;
      Label7.Font = new Font("Microsoft Sans Serif", 11.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
      Label7.Location = new Point(428, 41);
      Label7.Name = "Label7";
      Label7.Size = new Size(17, 18);
      Label7.TabIndex = 10;
      Label7.Text = "+";
      // 
      // Label8
      // 
      Label8.AutoSize = true;
      Label8.Font = new Font("Microsoft Sans Serif", 11.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
      Label8.Location = new Point(428, 83);
      Label8.Name = "Label8";
      Label8.Size = new Size(17, 18);
      Label8.TabIndex = 17;
      Label8.Text = "+";
      // 
      // Label9
      // 
      Label9.AutoSize = true;
      Label9.Font = new Font("Microsoft Sans Serif", 11.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
      Label9.Location = new Point(137, 81);
      Label9.Name = "Label9";
      Label9.Size = new Size(13, 18);
      Label9.TabIndex = 16;
      Label9.Text = "-";
      // 
      // Label10
      // 
      Label10.AutoSize = true;
      Label10.Font = new Font("Microsoft Sans Serif", 11.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
      Label10.Location = new Point(281, 84);
      Label10.Name = "Label10";
      Label10.Size = new Size(14, 18);
      Label10.TabIndex = 15;
      Label10.Text = "*";
      // 
      // cD1
      // 
      _cD1.DropDownStyle = ComboBoxStyle.DropDownList;
      _cD1.FormattingEnabled = true;
      _cD1.Location = new Point(450, 82);
      _cD1.Name = "_cD1";
      _cD1.Size = new Size(121, 21);
      _cD1.TabIndex = 14;
      // 
      // cC1
      // 
      _cC1.DropDownStyle = ComboBoxStyle.DropDownList;
      _cC1.FormattingEnabled = true;
      _cC1.Location = new Point(301, 82);
      _cC1.Name = "_cC1";
      _cC1.Size = new Size(121, 21);
      _cC1.TabIndex = 13;
      // 
      // cB1
      // 
      _cB1.DropDownStyle = ComboBoxStyle.DropDownList;
      _cB1.FormattingEnabled = true;
      _cB1.Location = new Point(153, 82);
      _cB1.Name = "_cB1";
      _cB1.Size = new Size(121, 21);
      _cB1.TabIndex = 12;
      // 
      // cA1
      // 
      _cA1.DropDownStyle = ComboBoxStyle.DropDownList;
      _cA1.FormattingEnabled = true;
      _cA1.Location = new Point(12, 82);
      _cA1.Name = "_cA1";
      _cA1.Size = new Size(121, 21);
      _cA1.TabIndex = 11;
      // 
      // Label11
      // 
      Label11.AutoSize = true;
      Label11.Font = new Font("Microsoft Sans Serif", 11.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
      Label11.Location = new Point(428, 125);
      Label11.Name = "Label11";
      Label11.Size = new Size(17, 18);
      Label11.TabIndex = 24;
      Label11.Text = "+";
      // 
      // Label12
      // 
      Label12.AutoSize = true;
      Label12.Font = new Font("Microsoft Sans Serif", 11.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
      Label12.Location = new Point(137, 123);
      Label12.Name = "Label12";
      Label12.Size = new Size(13, 18);
      Label12.TabIndex = 23;
      Label12.Text = "-";
      // 
      // Label13
      // 
      Label13.AutoSize = true;
      Label13.Font = new Font("Microsoft Sans Serif", 11.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
      Label13.Location = new Point(281, 126);
      Label13.Name = "Label13";
      Label13.Size = new Size(14, 18);
      Label13.TabIndex = 22;
      Label13.Text = "*";
      // 
      // aD0
      // 
      _aD0.DropDownStyle = ComboBoxStyle.DropDownList;
      _aD0.FormattingEnabled = true;
      _aD0.Location = new Point(450, 124);
      _aD0.Name = "_aD0";
      _aD0.Size = new Size(121, 21);
      _aD0.TabIndex = 21;
      // 
      // aC0
      // 
      _aC0.DropDownStyle = ComboBoxStyle.DropDownList;
      _aC0.FormattingEnabled = true;
      _aC0.Location = new Point(301, 124);
      _aC0.Name = "_aC0";
      _aC0.Size = new Size(121, 21);
      _aC0.TabIndex = 20;
      // 
      // aB0
      // 
      _aB0.DropDownStyle = ComboBoxStyle.DropDownList;
      _aB0.FormattingEnabled = true;
      _aB0.Location = new Point(153, 124);
      _aB0.Name = "_aB0";
      _aB0.Size = new Size(121, 21);
      _aB0.TabIndex = 19;
      // 
      // aA0
      // 
      _aA0.DropDownStyle = ComboBoxStyle.DropDownList;
      _aA0.FormattingEnabled = true;
      _aA0.Location = new Point(12, 124);
      _aA0.Name = "_aA0";
      _aA0.Size = new Size(121, 21);
      _aA0.TabIndex = 18;
      // 
      // Label14
      // 
      Label14.AutoSize = true;
      Label14.Font = new Font("Microsoft Sans Serif", 11.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
      Label14.Location = new Point(428, 165);
      Label14.Name = "Label14";
      Label14.Size = new Size(17, 18);
      Label14.TabIndex = 31;
      Label14.Text = "+";
      // 
      // Label15
      // 
      Label15.AutoSize = true;
      Label15.Font = new Font("Microsoft Sans Serif", 11.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
      Label15.Location = new Point(137, 163);
      Label15.Name = "Label15";
      Label15.Size = new Size(13, 18);
      Label15.TabIndex = 30;
      Label15.Text = "-";
      // 
      // Label16
      // 
      Label16.AutoSize = true;
      Label16.Font = new Font("Microsoft Sans Serif", 11.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
      Label16.Location = new Point(281, 166);
      Label16.Name = "Label16";
      Label16.Size = new Size(14, 18);
      Label16.TabIndex = 29;
      Label16.Text = "*";
      // 
      // aD1
      // 
      _aD1.DropDownStyle = ComboBoxStyle.DropDownList;
      _aD1.FormattingEnabled = true;
      _aD1.Location = new Point(450, 164);
      _aD1.Name = "_aD1";
      _aD1.Size = new Size(121, 21);
      _aD1.TabIndex = 28;
      // 
      // aC1
      // 
      _aC1.DropDownStyle = ComboBoxStyle.DropDownList;
      _aC1.FormattingEnabled = true;
      _aC1.Location = new Point(301, 164);
      _aC1.Name = "_aC1";
      _aC1.Size = new Size(121, 21);
      _aC1.TabIndex = 27;
      // 
      // aB1
      // 
      _aB1.DropDownStyle = ComboBoxStyle.DropDownList;
      _aB1.FormattingEnabled = true;
      _aB1.Location = new Point(153, 164);
      _aB1.Name = "_aB1";
      _aB1.Size = new Size(121, 21);
      _aB1.TabIndex = 26;
      // 
      // aA1
      // 
      _aA1.DropDownStyle = ComboBoxStyle.DropDownList;
      _aA1.FormattingEnabled = true;
      _aA1.Location = new Point(12, 164);
      _aA1.Name = "_aA1";
      _aA1.Size = new Size(121, 21);
      _aA1.TabIndex = 25;
      // 
      // CompiledCmbCmd
      // 
      _CompiledCmbCmd.CharacterCasing = CharacterCasing.Upper;
      _CompiledCmbCmd.Location = new Point(450, 259);
      _CompiledCmbCmd.MaxLength = 16;
      _CompiledCmbCmd.Name = "_CompiledCmbCmd";
      _CompiledCmbCmd.Size = new Size(122, 20);
      _CompiledCmbCmd.TabIndex = 32;
      // 
      // Label17
      // 
      Label17.AutoSize = true;
      Label17.Location = new Point(394, 263);
      Label17.Name = "Label17";
      Label17.Size = new Size(50, 13);
      Label17.TabIndex = 33;
      Label17.Text = "Compiled";
      // 
      // PrimR
      // 
      _PrimR.FlatStyle = FlatStyle.Flat;
      _PrimR.Location = new Point(156, 208);
      _PrimR.Name = "_PrimR";
      _PrimR.Size = new Size(118, 23);
      _PrimR.TabIndex = 37;
      _PrimR.Text = "[cPRIM]";
      _PrimR.UseVisualStyleBackColor = true;
      // 
      // EnvR
      // 
      EnvR.FlatStyle = FlatStyle.Flat;
      EnvR.Location = new Point(12, 208);
      EnvR.Name = "EnvR";
      EnvR.Size = new Size(121, 23);
      EnvR.TabIndex = 42;
      EnvR.Text = "[cENV]";
      EnvR.UseVisualStyleBackColor = true;
      // 
      // EnvA
      // 
      EnvA.FlatStyle = FlatStyle.Flat;
      EnvA.Location = new Point(301, 208);
      EnvA.Name = "EnvA";
      EnvA.Size = new Size(121, 23);
      EnvA.TabIndex = 44;
      EnvA.Text = "[aENV]";
      EnvA.UseVisualStyleBackColor = true;
      // 
      // PrimA
      // 
      PrimA.FlatStyle = FlatStyle.Flat;
      PrimA.Location = new Point(450, 208);
      PrimA.Name = "PrimA";
      PrimA.Size = new Size(122, 23);
      PrimA.TabIndex = 43;
      PrimA.Text = "[aPRIM]";
      PrimA.UseVisualStyleBackColor = true;
      // 
      // CombinerEditor
      // 
      AutoScaleDimensions = new SizeF(6.0f, 13.0f);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(581, 298);
      Controls.Add(EnvA);
      Controls.Add(PrimA);
      Controls.Add(EnvR);
      Controls.Add(_PrimR);
      Controls.Add(Label17);
      Controls.Add(_CompiledCmbCmd);
      Controls.Add(Label14);
      Controls.Add(Label15);
      Controls.Add(Label16);
      Controls.Add(_aD1);
      Controls.Add(_aC1);
      Controls.Add(_aB1);
      Controls.Add(_aA1);
      Controls.Add(Label11);
      Controls.Add(Label12);
      Controls.Add(Label13);
      Controls.Add(_aD0);
      Controls.Add(_aC0);
      Controls.Add(_aB0);
      Controls.Add(_aA0);
      Controls.Add(Label8);
      Controls.Add(Label9);
      Controls.Add(Label10);
      Controls.Add(_cD1);
      Controls.Add(_cC1);
      Controls.Add(_cB1);
      Controls.Add(_cA1);
      Controls.Add(Label7);
      Controls.Add(Label6);
      Controls.Add(Label5);
      Controls.Add(_cD0);
      Controls.Add(_cC0);
      Controls.Add(_cB0);
      Controls.Add(_cA0);
      Controls.Add(Label4);
      Controls.Add(Label3);
      Controls.Add(Label2);
      Controls.Add(Label1);
      FormBorderStyle = FormBorderStyle.FixedDialog;
      MaximizeBox = false;
      MinimizeBox = false;
      Name = "CombinerEditor";
      ShowInTaskbar = false;
      StartPosition = FormStartPosition.CenterParent;
      Text = "Combiner Editor";
      Load += new EventHandler(Dialog1_Load);
      ResumeLayout(false);
      PerformLayout();
    }

    internal Label Label1;
    internal Label Label2;
    internal Label Label3;
    internal Label Label4;
    private ComboBox _cA0;

    internal ComboBox cA0 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _cA0;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_cA0 != null) {
          _cA0.SelectedIndexChanged -= cA0_SelectedIndexChanged;
        }

        _cA0 = value;
        if (_cA0 != null) {
          _cA0.SelectedIndexChanged += cA0_SelectedIndexChanged;
        }
      }
    }

    private ComboBox _cB0;

    internal ComboBox cB0 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _cB0;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_cB0 != null) {
          _cB0.SelectedIndexChanged -= cB0_SelectedIndexChanged;
        }

        _cB0 = value;
        if (_cB0 != null) {
          _cB0.SelectedIndexChanged += cB0_SelectedIndexChanged;
        }
      }
    }

    private ComboBox _cC0;

    internal ComboBox cC0 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _cC0;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_cC0 != null) {
          _cC0.SelectedIndexChanged -= cC0_SelectedIndexChanged;
        }

        _cC0 = value;
        if (_cC0 != null) {
          _cC0.SelectedIndexChanged += cC0_SelectedIndexChanged;
        }
      }
    }

    private ComboBox _cD0;

    internal ComboBox cD0 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _cD0;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_cD0 != null) {
          _cD0.SelectedIndexChanged -= cD0_SelectedIndexChanged;
        }

        _cD0 = value;
        if (_cD0 != null) {
          _cD0.SelectedIndexChanged += cD0_SelectedIndexChanged;
        }
      }
    }

    internal Label Label5;
    internal Label Label6;
    internal Label Label7;
    internal Label Label8;
    internal Label Label9;
    internal Label Label10;
    private ComboBox _cD1;

    internal ComboBox cD1 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _cD1;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_cD1 != null) {
          _cD1.SelectedIndexChanged -= cD1_SelectedIndexChanged;
        }

        _cD1 = value;
        if (_cD1 != null) {
          _cD1.SelectedIndexChanged += cD1_SelectedIndexChanged;
        }
      }
    }

    private ComboBox _cC1;

    internal ComboBox cC1 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _cC1;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_cC1 != null) {
          _cC1.SelectedIndexChanged -= cC1_SelectedIndexChanged;
        }

        _cC1 = value;
        if (_cC1 != null) {
          _cC1.SelectedIndexChanged += cC1_SelectedIndexChanged;
        }
      }
    }

    private ComboBox _cB1;

    internal ComboBox cB1 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _cB1;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_cB1 != null) {
          _cB1.SelectedIndexChanged -= cB1_SelectedIndexChanged;
        }

        _cB1 = value;
        if (_cB1 != null) {
          _cB1.SelectedIndexChanged += cB1_SelectedIndexChanged;
        }
      }
    }

    private ComboBox _cA1;

    internal ComboBox cA1 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _cA1;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_cA1 != null) {
          _cA1.SelectedIndexChanged -= cA1_SelectedIndexChanged;
        }

        _cA1 = value;
        if (_cA1 != null) {
          _cA1.SelectedIndexChanged += cA1_SelectedIndexChanged;
        }
      }
    }

    internal Label Label11;
    internal Label Label12;
    internal Label Label13;
    private ComboBox _aD0;

    internal ComboBox aD0 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _aD0;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_aD0 != null) {
          _aD0.SelectedIndexChanged -= aD0_SelectedIndexChanged;
        }

        _aD0 = value;
        if (_aD0 != null) {
          _aD0.SelectedIndexChanged += aD0_SelectedIndexChanged;
        }
      }
    }

    private ComboBox _aC0;

    internal ComboBox aC0 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _aC0;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_aC0 != null) {
          _aC0.SelectedIndexChanged -= aC0_SelectedIndexChanged;
        }

        _aC0 = value;
        if (_aC0 != null) {
          _aC0.SelectedIndexChanged += aC0_SelectedIndexChanged;
        }
      }
    }

    private ComboBox _aB0;

    internal ComboBox aB0 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _aB0;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_aB0 != null) {
          _aB0.SelectedIndexChanged -= aB0_SelectedIndexChanged;
        }

        _aB0 = value;
        if (_aB0 != null) {
          _aB0.SelectedIndexChanged += aB0_SelectedIndexChanged;
        }
      }
    }

    private ComboBox _aA0;

    internal ComboBox aA0 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _aA0;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_aA0 != null) {
          _aA0.SelectedIndexChanged -= aA0_SelectedIndexChanged;
        }

        _aA0 = value;
        if (_aA0 != null) {
          _aA0.SelectedIndexChanged += aA0_SelectedIndexChanged;
        }
      }
    }

    internal Label Label14;
    internal Label Label15;
    internal Label Label16;
    private ComboBox _aD1;

    internal ComboBox aD1 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _aD1;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_aD1 != null) {
          _aD1.SelectedIndexChanged -= aD1_SelectedIndexChanged;
        }

        _aD1 = value;
        if (_aD1 != null) {
          _aD1.SelectedIndexChanged += aD1_SelectedIndexChanged;
        }
      }
    }

    private ComboBox _aC1;

    internal ComboBox aC1 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _aC1;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_aC1 != null) {
          _aC1.SelectedIndexChanged -= aC1_SelectedIndexChanged;
        }

        _aC1 = value;
        if (_aC1 != null) {
          _aC1.SelectedIndexChanged += aC1_SelectedIndexChanged;
        }
      }
    }

    private ComboBox _aB1;

    internal ComboBox aB1 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _aB1;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_aB1 != null) {
          _aB1.SelectedIndexChanged -= aB1_SelectedIndexChanged;
        }

        _aB1 = value;
        if (_aB1 != null) {
          _aB1.SelectedIndexChanged += aB1_SelectedIndexChanged;
        }
      }
    }

    private ComboBox _aA1;

    internal ComboBox aA1 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _aA1;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_aA1 != null) {
          _aA1.SelectedIndexChanged -= aA1_SelectedIndexChanged;
        }

        _aA1 = value;
        if (_aA1 != null) {
          _aA1.SelectedIndexChanged += aA1_SelectedIndexChanged;
        }
      }
    }

    private TextBox _CompiledCmbCmd;

    internal TextBox CompiledCmbCmd {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _CompiledCmbCmd;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_CompiledCmbCmd != null) {
          _CompiledCmbCmd.TextChanged -= CompiledCmbCmd_TextChanged;
        }

        _CompiledCmbCmd = value;
        if (_CompiledCmbCmd != null) {
          _CompiledCmbCmd.TextChanged += CompiledCmbCmd_TextChanged;
        }
      }
    }

    internal Label Label17;
    private Button _PrimR;

    internal Button PrimR {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _PrimR;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_PrimR != null) {
          _PrimR.Click -= PrimR_Click;
        }

        _PrimR = value;
        if (_PrimR != null) {
          _PrimR.Click += PrimR_Click;
        }
      }
    }

    internal Button EnvR;
    internal ColorDialog ColorSelector;
    internal Button EnvA;
    internal Button PrimA;
  }
}