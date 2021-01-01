namespace UoT.ui.main.files {
  partial class ZFileTree {
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZFileTree));
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.searchTextBox = new System.Windows.Forms.TextBox();
      this.fileTreeView = new System.Windows.Forms.TreeView();
      this.searchButton = new System.Windows.Forms.Button();
      this.splitContainer2 = new System.Windows.Forms.SplitContainer();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
      this.splitContainer2.Panel1.SuspendLayout();
      this.splitContainer2.Panel2.SuspendLayout();
      this.splitContainer2.SuspendLayout();
      this.SuspendLayout();
      // 
      // splitContainer1
      // 
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.Location = new System.Drawing.Point(0, 0);
      this.splitContainer1.Name = "splitContainer1";
      this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.fileTreeView);
      this.splitContainer1.Size = new System.Drawing.Size(225, 627);
      this.splitContainer1.SplitterDistance = 25;
      this.splitContainer1.TabIndex = 0;
      // 
      // searchTextBox
      // 
      this.searchTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.searchTextBox.Location = new System.Drawing.Point(0, 0);
      this.searchTextBox.Name = "searchTextBox";
      this.searchTextBox.Size = new System.Drawing.Size(195, 20);
      this.searchTextBox.TabIndex = 16;
      // 
      // fileTreeView
      // 
      this.fileTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.fileTreeView.HideSelection = false;
      this.fileTreeView.HotTracking = true;
      this.fileTreeView.Location = new System.Drawing.Point(0, 0);
      this.fileTreeView.Name = "fileTreeView";
      this.fileTreeView.Size = new System.Drawing.Size(225, 598);
      this.fileTreeView.TabIndex = 15;
      // 
      // searchButton
      // 
      this.searchButton.Dock = System.Windows.Forms.DockStyle.Fill;
      this.searchButton.Image = ((System.Drawing.Image)(resources.GetObject("searchButton.Image")));
      this.searchButton.Location = new System.Drawing.Point(0, 0);
      this.searchButton.Name = "searchButton";
      this.searchButton.Size = new System.Drawing.Size(26, 25);
      this.searchButton.TabIndex = 14;
      this.searchButton.UseVisualStyleBackColor = true;
      // 
      // splitContainer2
      // 
      this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer2.IsSplitterFixed = true;
      this.splitContainer2.Location = new System.Drawing.Point(0, 0);
      this.splitContainer2.Name = "splitContainer2";
      // 
      // splitContainer2.Panel1
      // 
      this.splitContainer2.Panel1.Controls.Add(this.searchTextBox);
      // 
      // splitContainer2.Panel2
      // 
      this.splitContainer2.Panel2.Controls.Add(this.searchButton);
      this.splitContainer2.Size = new System.Drawing.Size(225, 25);
      this.splitContainer2.SplitterDistance = 195;
      this.splitContainer2.TabIndex = 0;
      // 
      // ZFileTree
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.splitContainer1);
      this.Name = "ZFileTree";
      this.Size = new System.Drawing.Size(225, 627);
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      this.splitContainer2.Panel1.ResumeLayout(false);
      this.splitContainer2.Panel1.PerformLayout();
      this.splitContainer2.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
      this.splitContainer2.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.SplitContainer splitContainer2;
    private System.Windows.Forms.TextBox searchTextBox;
    private System.Windows.Forms.Button searchButton;
    private System.Windows.Forms.TreeView fileTreeView;
  }
}
