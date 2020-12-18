using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace UoT {
  [DesignerGenerated()]
  public partial class HexEditor : Form {

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
      _DataGridView1 = new DataGridView();
      _DataGridView1.CellContentClick += new DataGridViewCellEventHandler(DataGridView1_CellContentClick);
      Column1 = new DataGridViewTextBoxColumn();
      Column2 = new DataGridViewTextBoxColumn();
      Column3 = new DataGridViewTextBoxColumn();
      Column4 = new DataGridViewTextBoxColumn();
      ((System.ComponentModel.ISupportInitialize)_DataGridView1).BeginInit();
      SuspendLayout();
      // 
      // DataGridView1
      // 
      _DataGridView1.AllowUserToAddRows = false;
      _DataGridView1.AllowUserToDeleteRows = false;
      _DataGridView1.AllowUserToOrderColumns = true;
      _DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      _DataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4 });
      _DataGridView1.Dock = DockStyle.Fill;
      _DataGridView1.Location = new Point(0, 0);
      _DataGridView1.Name = "_DataGridView1";
      _DataGridView1.Size = new Size(745, 444);
      _DataGridView1.TabIndex = 0;
      // 
      // Column1
      // 
      Column1.HeaderText = "0 - 3";
      Column1.Name = "Column1";
      // 
      // Column2
      // 
      Column2.HeaderText = "4 - 7";
      Column2.Name = "Column2";
      // 
      // Column3
      // 
      Column3.HeaderText = "8 - A";
      Column3.Name = "Column3";
      // 
      // Column4
      // 
      Column4.HeaderText = "B - F";
      Column4.Name = "Column4";
      // 
      // HexEditor
      // 
      AutoScaleDimensions = new SizeF(6.0f, 13.0f);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(745, 444);
      Controls.Add(_DataGridView1);
      Name = "HexEditor";
      Text = "HexEditor";
      ((System.ComponentModel.ISupportInitialize)_DataGridView1).EndInit();
      ResumeLayout(false);
    }

    private DataGridView _DataGridView1;

    internal DataGridView DataGridView1 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _DataGridView1;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_DataGridView1 != null) {
          _DataGridView1.CellContentClick -= DataGridView1_CellContentClick;
        }

        _DataGridView1 = value;
        if (_DataGridView1 != null) {
          _DataGridView1.CellContentClick += DataGridView1_CellContentClick;
        }
      }
    }

    internal DataGridViewTextBoxColumn Column1;
    internal DataGridViewTextBoxColumn Column2;
    internal DataGridViewTextBoxColumn Column3;
    internal DataGridViewTextBoxColumn Column4;
  }
}