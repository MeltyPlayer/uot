namespace UoT.ui.main.files {
  partial class ZFileTreeView {
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZFileTreeView));
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.splitContainer2 = new System.Windows.Forms.SplitContainer();
      this.searchTextBox_ = new System.Windows.Forms.TextBox();
      this.searchButton_ = new System.Windows.Forms.Button();
      this.fileTreeView_ = new System.Windows.Forms.TreeView();
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
      this.splitContainer1.Panel2.Controls.Add(this.fileTreeView_);
      this.splitContainer1.Size = new System.Drawing.Size(225, 627);
      this.splitContainer1.SplitterDistance = 25;
      this.splitContainer1.TabIndex = 0;
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
      this.splitContainer2.Panel1.Controls.Add(this.searchTextBox_);
      // 
      // splitContainer2.Panel2
      // 
      this.splitContainer2.Panel2.Controls.Add(this.searchButton_);
      this.splitContainer2.Size = new System.Drawing.Size(225, 25);
      this.splitContainer2.SplitterDistance = 195;
      this.splitContainer2.TabIndex = 0;
      // 
      // searchTextBox_
      // 
      this.searchTextBox_.Dock = System.Windows.Forms.DockStyle.Fill;
      this.searchTextBox_.Location = new System.Drawing.Point(0, 0);
      this.searchTextBox_.Name = "searchTextBox_";
      this.searchTextBox_.Size = new System.Drawing.Size(195, 20);
      this.searchTextBox_.TabIndex = 16;
      // 
      // searchButton_
      // 
      this.searchButton_.Dock = System.Windows.Forms.DockStyle.Fill;
      this.searchButton_.Image = ((System.Drawing.Image)(resources.GetObject("searchButton_.Image")));
      this.searchButton_.Location = new System.Drawing.Point(0, 0);
      this.searchButton_.Name = "searchButton_";
      this.searchButton_.Size = new System.Drawing.Size(26, 25);
      this.searchButton_.TabIndex = 14;
      this.searchButton_.UseVisualStyleBackColor = true;
      // 
      // fileTreeView_
      // 
      this.fileTreeView_.Dock = System.Windows.Forms.DockStyle.Fill;
      this.fileTreeView_.HideSelection = false;
      this.fileTreeView_.HotTracking = true;
      this.fileTreeView_.Location = new System.Drawing.Point(0, 0);
      this.fileTreeView_.Name = "fileTreeView_";
      this.fileTreeView_.Size = new System.Drawing.Size(225, 598);
      this.fileTreeView_.TabIndex = 15;
      // 
      // ZFileTreeView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.splitContainer1);
      this.Name = "ZFileTreeView";
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
    private System.Windows.Forms.TextBox searchTextBox_;
    private System.Windows.Forms.Button searchButton_;
    private System.Windows.Forms.TreeView fileTreeView_;
  }
}
