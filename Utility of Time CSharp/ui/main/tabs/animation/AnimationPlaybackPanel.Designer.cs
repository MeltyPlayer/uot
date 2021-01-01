namespace UoT {
  partial class AnimationPlaybackPanel {
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnimationPlaybackPanel));
      this.PlaybackGroup = new System.Windows.Forms.GroupBox();
      this.FrameRateSelector = new System.Windows.Forms.NumericUpDown();
      this.Label27 = new System.Windows.Forms.Label();
      this.FrameNo = new System.Windows.Forms.Label();
      this.AnimationElapse = new System.Windows.Forms.Label();
      this.LoopCheckBox = new System.Windows.Forms.CheckBox();
      this.StopButton = new System.Windows.Forms.Button();
      this.PlayButton = new System.Windows.Forms.Button();
      this.FrameTrackBar = new UoT.TransparentTrackBar();
      this.PlaybackGroup.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.FrameRateSelector)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.FrameTrackBar)).BeginInit();
      this.SuspendLayout();
      // 
      // PlaybackGroup
      // 
      this.PlaybackGroup.Controls.Add(this.FrameRateSelector);
      this.PlaybackGroup.Controls.Add(this.Label27);
      this.PlaybackGroup.Controls.Add(this.FrameNo);
      this.PlaybackGroup.Controls.Add(this.AnimationElapse);
      this.PlaybackGroup.Controls.Add(this.LoopCheckBox);
      this.PlaybackGroup.Controls.Add(this.StopButton);
      this.PlaybackGroup.Controls.Add(this.PlayButton);
      this.PlaybackGroup.Controls.Add(this.FrameTrackBar);
      this.PlaybackGroup.Dock = System.Windows.Forms.DockStyle.Fill;
      this.PlaybackGroup.Location = new System.Drawing.Point(0, 0);
      this.PlaybackGroup.Name = "PlaybackGroup";
      this.PlaybackGroup.Size = new System.Drawing.Size(212, 117);
      this.PlaybackGroup.TabIndex = 17;
      this.PlaybackGroup.TabStop = false;
      this.PlaybackGroup.Text = "Playback";
      // 
      // FrameRateSelector
      // 
      this.FrameRateSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.FrameRateSelector.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.FrameRateSelector.Location = new System.Drawing.Point(134, 63);
      this.FrameRateSelector.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
      this.FrameRateSelector.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.FrameRateSelector.Name = "FrameRateSelector";
      this.FrameRateSelector.Size = new System.Drawing.Size(40, 20);
      this.FrameRateSelector.TabIndex = 11;
      this.FrameRateSelector.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
      // 
      // Label27
      // 
      this.Label27.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.Label27.AutoSize = true;
      this.Label27.Location = new System.Drawing.Point(176, 65);
      this.Label27.Name = "Label27";
      this.Label27.Size = new System.Drawing.Size(27, 13);
      this.Label27.TabIndex = 12;
      this.Label27.Text = "FPS";
      // 
      // FrameNo
      // 
      this.FrameNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.FrameNo.Location = new System.Drawing.Point(160, 17);
      this.FrameNo.Name = "FrameNo";
      this.FrameNo.Size = new System.Drawing.Size(41, 13);
      this.FrameNo.TabIndex = 8;
      this.FrameNo.Text = "0/0";
      this.FrameNo.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // AnimationElapse
      // 
      this.AnimationElapse.AutoSize = true;
      this.AnimationElapse.Location = new System.Drawing.Point(12, 17);
      this.AnimationElapse.Name = "AnimationElapse";
      this.AnimationElapse.Size = new System.Drawing.Size(27, 13);
      this.AnimationElapse.TabIndex = 7;
      this.AnimationElapse.Text = "0:0s";
      // 
      // LoopCheckBox
      // 
      this.LoopCheckBox.Image = global::UoT.Properties.Resources.Button_Refresh_icon;
      this.LoopCheckBox.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.LoopCheckBox.Location = new System.Drawing.Point(16, 89);
      this.LoopCheckBox.Name = "LoopCheckBox";
      this.LoopCheckBox.Size = new System.Drawing.Size(70, 24);
      this.LoopCheckBox.TabIndex = 3;
      this.LoopCheckBox.Text = "Loop";
      this.LoopCheckBox.UseVisualStyleBackColor = true;
      // 
      // StopButton
      // 
      this.StopButton.Image = global::UoT.Properties.Resources.Button_Stop_icon;
      this.StopButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.StopButton.Location = new System.Drawing.Point(68, 59);
      this.StopButton.Name = "StopButton";
      this.StopButton.Size = new System.Drawing.Size(51, 28);
      this.StopButton.TabIndex = 2;
      this.StopButton.Text = "Stop";
      this.StopButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.StopButton.UseVisualStyleBackColor = true;
      // 
      // PlayButton
      // 
      this.PlayButton.Image = ((System.Drawing.Image)(resources.GetObject("PlayButton.Image")));
      this.PlayButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.PlayButton.Location = new System.Drawing.Point(15, 59);
      this.PlayButton.Name = "PlayButton";
      this.PlayButton.Size = new System.Drawing.Size(51, 28);
      this.PlayButton.TabIndex = 1;
      this.PlayButton.Text = "Play";
      this.PlayButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.PlayButton.UseVisualStyleBackColor = true;
      // 
      // FrameTrackBar
      // 
      this.FrameTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.FrameTrackBar.AutoSize = false;
      this.FrameTrackBar.BackColor = System.Drawing.SystemColors.Control;
      this.FrameTrackBar.LargeChange = 2;
      this.FrameTrackBar.Location = new System.Drawing.Point(8, 32);
      this.FrameTrackBar.Maximum = 1;
      this.FrameTrackBar.Name = "FrameTrackBar";
      this.FrameTrackBar.Size = new System.Drawing.Size(197, 24);
      this.FrameTrackBar.TabIndex = 14;
      // 
      // AnimationPlaybackPanel
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.PlaybackGroup);
      this.Name = "AnimationPlaybackPanel";
      this.Size = new System.Drawing.Size(212, 117);
      this.PlaybackGroup.ResumeLayout(false);
      this.PlaybackGroup.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.FrameRateSelector)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.FrameTrackBar)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion
    internal System.Windows.Forms.GroupBox PlaybackGroup;
    internal System.Windows.Forms.Label Label27;
    internal System.Windows.Forms.Label FrameNo;
    internal System.Windows.Forms.Label AnimationElapse;
    private System.Windows.Forms.NumericUpDown FrameRateSelector;
    private System.Windows.Forms.CheckBox LoopCheckBox;
    private System.Windows.Forms.Button StopButton;
    private System.Windows.Forms.Button PlayButton;
    private TransparentTrackBar FrameTrackBar;
  }
}
