using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace UoT {
  [DesignerGenerated()]
  public partial class LevelCreator : Form {

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
      var resources = new System.ComponentModel.ComponentResourceManager(typeof(LevelCreator));
      TabControl1 = new TabControl();
      TabPage1 = new TabPage();
      Label6 = new Label();
      _LevelNameText = new TextBox();
      _LevelNameText.TextChanged += new EventHandler(TextBox5_TextChanged);
      TabControl3 = new TabControl();
      TabPage5 = new TabPage();
      Label9 = new Label();
      LinkActorCount = new NumericUpDown();
      Label5 = new Label();
      SceneActorCount = new NumericUpDown();
      TabPage6 = new TabPage();
      TabPage7 = new TabPage();
      GroupBox2 = new GroupBox();
      _Button3 = new Button();
      _Button3.Click += new EventHandler(Button3_Click);
      _SeparateCollisionToggle = new CheckBox();
      _SeparateCollisionToggle.CheckedChanged += new EventHandler(CheckBox1_CheckedChanged);
      ObjCollisionText = new TextBox();
      Label1 = new Label();
      _Button1 = new Button();
      _Button1.Click += new EventHandler(Button1_Click);
      OBJGraphicsText = new TextBox();
      GroupBox1 = new GroupBox();
      EchoLevelMenu = new ComboBox();
      Label4 = new Label();
      SkyboxToggle = new CheckBox();
      Label3 = new Label();
      RoomGroupCount = new NumericUpDown();
      Label2 = new Label();
      RoomActorCount = new NumericUpDown();
      TabPage3 = new TabPage();
      GroupBox3 = new GroupBox();
      Label8 = new Label();
      RadioButton4 = new RadioButton();
      RadioButton5 = new RadioButton();
      RadioButton6 = new RadioButton();
      Label7 = new Label();
      RadioButton3 = new RadioButton();
      RadioButton2 = new RadioButton();
      RadioButton1 = new RadioButton();
      _UpdateRawDataButton = new Button();
      _UpdateRawDataButton.Click += new EventHandler(Button4_Click_1);
      MapRawDataDisplay = new TextBox();
      MenuStrip1 = new MenuStrip();
      FileToolStripMenuItem1 = new ToolStripMenuItem();
      _NewToolStripMenuItem = new ToolStripMenuItem();
      _NewToolStripMenuItem.Click += new EventHandler(NewToolStripMenuItem_Click);
      _OpenToolStripMenuItem = new ToolStripMenuItem();
      _OpenToolStripMenuItem.Click += new EventHandler(OpenToolStripMenuItem_Click);
      toolStripSeparator = new ToolStripSeparator();
      _SaveToolStripMenuItem = new ToolStripMenuItem();
      _SaveToolStripMenuItem.Click += new EventHandler(SaveToolStripMenuItem_Click);
      toolStripSeparator2 = new ToolStripSeparator();
      ExitToolStripMenuItem = new ToolStripMenuItem();
      _OpenTemplate = new OpenFileDialog();
      _OpenTemplate.FileOk += new System.ComponentModel.CancelEventHandler(OpenTemplate_FileOk);
      _SaveTemplate = new SaveFileDialog();
      _SaveTemplate.FileOk += new System.ComponentModel.CancelEventHandler(SaveTemplate_FileOk);
      _OpenOBJGraphics = new OpenFileDialog();
      _OpenOBJGraphics.FileOk += new System.ComponentModel.CancelEventHandler(OpenOBJGraphics_FileOk);
      _OpenOBJCollision = new OpenFileDialog();
      _OpenOBJCollision.FileOk += new System.ComponentModel.CancelEventHandler(OpenOBJCollision_FileOk);
      Label10 = new Label();
      Label11 = new Label();
      SceneRawDataDisplay = new TextBox();
      GroupBox4 = new GroupBox();
      TabControl1.SuspendLayout();
      TabPage1.SuspendLayout();
      TabControl3.SuspendLayout();
      TabPage5.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)LinkActorCount).BeginInit();
      ((System.ComponentModel.ISupportInitialize)SceneActorCount).BeginInit();
      GroupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)RoomGroupCount).BeginInit();
      ((System.ComponentModel.ISupportInitialize)RoomActorCount).BeginInit();
      TabPage3.SuspendLayout();
      GroupBox3.SuspendLayout();
      MenuStrip1.SuspendLayout();
      GroupBox4.SuspendLayout();
      SuspendLayout();
      // 
      // TabControl1
      // 
      TabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      TabControl1.Controls.Add(TabPage1);
      TabControl1.Controls.Add(TabPage3);
      TabControl1.Location = new Point(0, 27);
      TabControl1.Name = "TabControl1";
      TabControl1.SelectedIndex = 0;
      TabControl1.Size = new Size(353, 569);
      TabControl1.TabIndex = 0;
      // 
      // TabPage1
      // 
      TabPage1.Controls.Add(Label6);
      TabPage1.Controls.Add(_LevelNameText);
      TabPage1.Controls.Add(TabControl3);
      TabPage1.Controls.Add(GroupBox2);
      TabPage1.Controls.Add(_Button3);
      TabPage1.Controls.Add(_SeparateCollisionToggle);
      TabPage1.Controls.Add(ObjCollisionText);
      TabPage1.Controls.Add(Label1);
      TabPage1.Controls.Add(_Button1);
      TabPage1.Controls.Add(OBJGraphicsText);
      TabPage1.Controls.Add(GroupBox1);
      TabPage1.Location = new Point(4, 22);
      TabPage1.Name = "TabPage1";
      TabPage1.Padding = new Padding(3);
      TabPage1.Size = new Size(345, 543);
      TabPage1.TabIndex = 0;
      TabPage1.Text = "Setup";
      TabPage1.UseVisualStyleBackColor = true;
      // 
      // Label6
      // 
      Label6.AutoSize = true;
      Label6.Location = new Point(6, 10);
      Label6.Name = "Label6";
      Label6.Size = new Size(62, 13);
      Label6.TabIndex = 15;
      Label6.Text = "Level name";
      // 
      // LevelNameText
      // 
      _LevelNameText.Location = new Point(8, 26);
      _LevelNameText.Name = "_LevelNameText";
      _LevelNameText.Size = new Size(331, 20);
      _LevelNameText.TabIndex = 14;
      // 
      // TabControl3
      // 
      TabControl3.Controls.Add(TabPage5);
      TabControl3.Controls.Add(TabPage6);
      TabControl3.Controls.Add(TabPage7);
      TabControl3.Location = new Point(14, 329);
      TabControl3.Name = "TabControl3";
      TabControl3.SelectedIndex = 0;
      TabControl3.Size = new Size(320, 199);
      TabControl3.TabIndex = 12;
      // 
      // TabPage5
      // 
      TabPage5.Controls.Add(Label9);
      TabPage5.Controls.Add(LinkActorCount);
      TabPage5.Controls.Add(Label5);
      TabPage5.Controls.Add(SceneActorCount);
      TabPage5.Location = new Point(4, 22);
      TabPage5.Name = "TabPage5";
      TabPage5.Padding = new Padding(3);
      TabPage5.Size = new Size(312, 173);
      TabPage5.TabIndex = 0;
      TabPage5.Text = "Actors";
      TabPage5.UseVisualStyleBackColor = true;
      // 
      // Label9
      // 
      Label9.AutoSize = true;
      Label9.Location = new Point(91, 27);
      Label9.Name = "Label9";
      Label9.Size = new Size(32, 13);
      Label9.TabIndex = 14;
      Label9.Text = "Links";
      // 
      // LinkActorCount
      // 
      LinkActorCount.Location = new Point(94, 43);
      LinkActorCount.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
      LinkActorCount.Name = "LinkActorCount";
      LinkActorCount.Size = new Size(47, 20);
      LinkActorCount.TabIndex = 13;
      // 
      // Label5
      // 
      Label5.AutoSize = true;
      Label5.Location = new Point(33, 27);
      Label5.Name = "Label5";
      Label5.Size = new Size(37, 13);
      Label5.TabIndex = 12;
      Label5.Text = "Actors";
      // 
      // SceneActorCount
      // 
      SceneActorCount.Location = new Point(36, 43);
      SceneActorCount.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
      SceneActorCount.Name = "SceneActorCount";
      SceneActorCount.Size = new Size(47, 20);
      SceneActorCount.TabIndex = 11;
      // 
      // TabPage6
      // 
      TabPage6.Location = new Point(4, 22);
      TabPage6.Name = "TabPage6";
      TabPage6.Size = new Size(312, 173);
      TabPage6.TabIndex = 4;
      TabPage6.Text = "Exits";
      TabPage6.UseVisualStyleBackColor = true;
      // 
      // TabPage7
      // 
      TabPage7.Location = new Point(4, 22);
      TabPage7.Name = "TabPage7";
      TabPage7.Size = new Size(312, 173);
      TabPage7.TabIndex = 5;
      TabPage7.Text = "Collision types";
      TabPage7.UseVisualStyleBackColor = true;
      // 
      // GroupBox2
      // 
      GroupBox2.Location = new Point(7, 312);
      GroupBox2.Name = "GroupBox2";
      GroupBox2.Size = new Size(332, 227);
      GroupBox2.TabIndex = 13;
      GroupBox2.TabStop = false;
      GroupBox2.Text = "Scene";
      // 
      // Button3
      // 
      _Button3.Enabled = false;
      _Button3.Location = new Point(302, 134);
      _Button3.Name = "_Button3";
      _Button3.Size = new Size(38, 23);
      _Button3.TabIndex = 5;
      _Button3.Text = "...";
      _Button3.UseVisualStyleBackColor = true;
      // 
      // SeparateCollisionToggle
      // 
      _SeparateCollisionToggle.AutoSize = true;
      _SeparateCollisionToggle.Location = new Point(9, 112);
      _SeparateCollisionToggle.Name = "_SeparateCollisionToggle";
      _SeparateCollisionToggle.Size = new Size(132, 17);
      _SeparateCollisionToggle.TabIndex = 4;
      _SeparateCollisionToggle.Text = "Separate collision map";
      _SeparateCollisionToggle.UseVisualStyleBackColor = true;
      // 
      // ObjCollisionText
      // 
      ObjCollisionText.Enabled = false;
      ObjCollisionText.Location = new Point(8, 135);
      ObjCollisionText.Name = "ObjCollisionText";
      ObjCollisionText.Size = new Size(288, 20);
      ObjCollisionText.TabIndex = 3;
      // 
      // Label1
      // 
      Label1.AutoSize = true;
      Label1.Location = new Point(5, 60);
      Label1.Name = "Label1";
      Label1.Size = new Size(55, 13);
      Label1.TabIndex = 2;
      Label1.Text = "Obj Model";
      // 
      // Button1
      // 
      _Button1.Location = new Point(302, 75);
      _Button1.Name = "_Button1";
      _Button1.Size = new Size(38, 23);
      _Button1.TabIndex = 1;
      _Button1.Text = "...";
      _Button1.UseVisualStyleBackColor = true;
      // 
      // OBJGraphicsText
      // 
      OBJGraphicsText.AcceptsReturn = true;
      OBJGraphicsText.Location = new Point(8, 76);
      OBJGraphicsText.Name = "OBJGraphicsText";
      OBJGraphicsText.Size = new Size(288, 20);
      OBJGraphicsText.TabIndex = 0;
      // 
      // GroupBox1
      // 
      GroupBox1.Controls.Add(EchoLevelMenu);
      GroupBox1.Controls.Add(Label4);
      GroupBox1.Controls.Add(SkyboxToggle);
      GroupBox1.Controls.Add(Label3);
      GroupBox1.Controls.Add(RoomGroupCount);
      GroupBox1.Controls.Add(Label2);
      GroupBox1.Controls.Add(RoomActorCount);
      GroupBox1.Location = new Point(8, 162);
      GroupBox1.Name = "GroupBox1";
      GroupBox1.Size = new Size(332, 145);
      GroupBox1.TabIndex = 11;
      GroupBox1.TabStop = false;
      GroupBox1.Text = "Map";
      // 
      // EchoLevelMenu
      // 
      EchoLevelMenu.FormattingEnabled = true;
      EchoLevelMenu.Items.AddRange(new object[] { "None", "Faint", "Normal", "Maximum" });
      EchoLevelMenu.Location = new Point(176, 43);
      EchoLevelMenu.Name = "EchoLevelMenu";
      EchoLevelMenu.Size = new Size(105, 21);
      EchoLevelMenu.TabIndex = 16;
      // 
      // Label4
      // 
      Label4.AutoSize = true;
      Label4.Location = new Point(173, 27);
      Label4.Name = "Label4";
      Label4.Size = new Size(57, 13);
      Label4.TabIndex = 15;
      Label4.Text = "Echo level";
      // 
      // SkyboxToggle
      // 
      SkyboxToggle.AutoSize = true;
      SkyboxToggle.Location = new Point(176, 70);
      SkyboxToggle.Name = "SkyboxToggle";
      SkyboxToggle.Size = new Size(95, 17);
      SkyboxToggle.TabIndex = 14;
      SkyboxToggle.Text = "Enable skybox";
      SkyboxToggle.UseVisualStyleBackColor = true;
      // 
      // Label3
      // 
      Label3.AutoSize = true;
      Label3.Location = new Point(101, 28);
      Label3.Name = "Label3";
      Label3.Size = new Size(41, 13);
      Label3.TabIndex = 12;
      Label3.Text = "Groups";
      // 
      // RoomGroupCount
      // 
      RoomGroupCount.Location = new Point(104, 44);
      RoomGroupCount.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
      RoomGroupCount.Name = "RoomGroupCount";
      RoomGroupCount.Size = new Size(47, 20);
      RoomGroupCount.TabIndex = 11;
      // 
      // Label2
      // 
      Label2.AutoSize = true;
      Label2.Location = new Point(43, 28);
      Label2.Name = "Label2";
      Label2.Size = new Size(37, 13);
      Label2.TabIndex = 10;
      Label2.Text = "Actors";
      // 
      // RoomActorCount
      // 
      RoomActorCount.Location = new Point(46, 44);
      RoomActorCount.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
      RoomActorCount.Name = "RoomActorCount";
      RoomActorCount.Size = new Size(47, 20);
      RoomActorCount.TabIndex = 9;
      // 
      // TabPage3
      // 
      TabPage3.Controls.Add(GroupBox3);
      TabPage3.Location = new Point(4, 22);
      TabPage3.Name = "TabPage3";
      TabPage3.Size = new Size(345, 543);
      TabPage3.TabIndex = 2;
      TabPage3.Text = "Graphics";
      TabPage3.UseVisualStyleBackColor = true;
      // 
      // GroupBox3
      // 
      GroupBox3.Controls.Add(Label8);
      GroupBox3.Controls.Add(RadioButton4);
      GroupBox3.Controls.Add(RadioButton5);
      GroupBox3.Controls.Add(RadioButton6);
      GroupBox3.Controls.Add(Label7);
      GroupBox3.Controls.Add(RadioButton3);
      GroupBox3.Controls.Add(RadioButton2);
      GroupBox3.Controls.Add(RadioButton1);
      GroupBox3.Location = new Point(8, 3);
      GroupBox3.Name = "GroupBox3";
      GroupBox3.Size = new Size(334, 166);
      GroupBox3.TabIndex = 0;
      GroupBox3.TabStop = false;
      GroupBox3.Text = "Textures";
      // 
      // Label8
      // 
      Label8.AutoSize = true;
      Label8.Location = new Point(180, 69);
      Label8.Name = "Label8";
      Label8.Size = new Size(70, 13);
      Label8.TabIndex = 7;
      Label8.Text = "Y Parameters";
      // 
      // RadioButton4
      // 
      RadioButton4.AutoSize = true;
      RadioButton4.Location = new Point(183, 133);
      RadioButton4.Name = "RadioButton4";
      RadioButton4.Size = new Size(94, 17);
      RadioButton4.TabIndex = 6;
      RadioButton4.Text = "Clamp to Edge";
      RadioButton4.UseVisualStyleBackColor = true;
      // 
      // RadioButton5
      // 
      RadioButton5.AutoSize = true;
      RadioButton5.Location = new Point(183, 110);
      RadioButton5.Name = "RadioButton5";
      RadioButton5.Size = new Size(51, 17);
      RadioButton5.TabIndex = 5;
      RadioButton5.Text = "Mirror";
      RadioButton5.UseVisualStyleBackColor = true;
      // 
      // RadioButton6
      // 
      RadioButton6.AutoSize = true;
      RadioButton6.Checked = true;
      RadioButton6.Location = new Point(183, 87);
      RadioButton6.Name = "RadioButton6";
      RadioButton6.Size = new Size(60, 17);
      RadioButton6.TabIndex = 4;
      RadioButton6.TabStop = true;
      RadioButton6.Text = "Repeat";
      RadioButton6.UseVisualStyleBackColor = true;
      // 
      // Label7
      // 
      Label7.AutoSize = true;
      Label7.Location = new Point(15, 69);
      Label7.Name = "Label7";
      Label7.Size = new Size(70, 13);
      Label7.TabIndex = 3;
      Label7.Text = "X Parameters";
      // 
      // RadioButton3
      // 
      RadioButton3.AutoSize = true;
      RadioButton3.Location = new Point(18, 133);
      RadioButton3.Name = "RadioButton3";
      RadioButton3.Size = new Size(94, 17);
      RadioButton3.TabIndex = 2;
      RadioButton3.Text = "Clamp to Edge";
      RadioButton3.UseVisualStyleBackColor = true;
      // 
      // RadioButton2
      // 
      RadioButton2.AutoSize = true;
      RadioButton2.Location = new Point(18, 110);
      RadioButton2.Name = "RadioButton2";
      RadioButton2.Size = new Size(51, 17);
      RadioButton2.TabIndex = 1;
      RadioButton2.Text = "Mirror";
      RadioButton2.UseVisualStyleBackColor = true;
      // 
      // RadioButton1
      // 
      RadioButton1.AutoSize = true;
      RadioButton1.Checked = true;
      RadioButton1.Location = new Point(18, 87);
      RadioButton1.Name = "RadioButton1";
      RadioButton1.Size = new Size(60, 17);
      RadioButton1.TabIndex = 0;
      RadioButton1.TabStop = true;
      RadioButton1.Text = "Repeat";
      RadioButton1.UseVisualStyleBackColor = true;
      // 
      // UpdateRawDataButton
      // 
      _UpdateRawDataButton.Location = new Point(264, 529);
      _UpdateRawDataButton.Name = "_UpdateRawDataButton";
      _UpdateRawDataButton.Size = new Size(81, 23);
      _UpdateRawDataButton.TabIndex = 18;
      _UpdateRawDataButton.Text = "Update";
      _UpdateRawDataButton.UseVisualStyleBackColor = true;
      // 
      // MapRawDataDisplay
      // 
      MapRawDataDisplay.Location = new Point(7, 38);
      MapRawDataDisplay.Multiline = true;
      MapRawDataDisplay.Name = "MapRawDataDisplay";
      MapRawDataDisplay.Size = new Size(339, 209);
      MapRawDataDisplay.TabIndex = 0;
      // 
      // MenuStrip1
      // 
      MenuStrip1.Items.AddRange(new ToolStripItem[] { FileToolStripMenuItem1 });
      MenuStrip1.Location = new Point(0, 0);
      MenuStrip1.Name = "MenuStrip1";
      MenuStrip1.Size = new Size(706, 24);
      MenuStrip1.TabIndex = 3;
      MenuStrip1.Text = "MenuStrip1";
      // 
      // FileToolStripMenuItem1
      // 
      FileToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { _NewToolStripMenuItem, _OpenToolStripMenuItem, toolStripSeparator, _SaveToolStripMenuItem, toolStripSeparator2, ExitToolStripMenuItem });
      FileToolStripMenuItem1.Name = "FileToolStripMenuItem1";
      FileToolStripMenuItem1.Size = new Size(35, 20);
      FileToolStripMenuItem1.Text = "&File";
      // 
      // NewToolStripMenuItem
      // 
      _NewToolStripMenuItem.Image = (Image)resources.GetObject("NewToolStripMenuItem.Image");
      _NewToolStripMenuItem.ImageTransparentColor = Color.Magenta;
      _NewToolStripMenuItem.Name = "_NewToolStripMenuItem";
      _NewToolStripMenuItem.Size = new Size(181, 22);
      _NewToolStripMenuItem.Text = "&New level";
      // 
      // OpenToolStripMenuItem
      // 
      _OpenToolStripMenuItem.Image = (Image)resources.GetObject("OpenToolStripMenuItem.Image");
      _OpenToolStripMenuItem.ImageTransparentColor = Color.Magenta;
      _OpenToolStripMenuItem.Name = "_OpenToolStripMenuItem";
      _OpenToolStripMenuItem.Size = new Size(181, 22);
      _OpenToolStripMenuItem.Text = "&Open template";
      // 
      // toolStripSeparator
      // 
      toolStripSeparator.Name = "toolStripSeparator";
      toolStripSeparator.Size = new Size(178, 6);
      // 
      // SaveToolStripMenuItem
      // 
      _SaveToolStripMenuItem.Image = (Image)resources.GetObject("SaveToolStripMenuItem.Image");
      _SaveToolStripMenuItem.ImageTransparentColor = Color.Magenta;
      _SaveToolStripMenuItem.Name = "_SaveToolStripMenuItem";
      _SaveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
      _SaveToolStripMenuItem.Size = new Size(181, 22);
      _SaveToolStripMenuItem.Text = "&Save template";
      // 
      // toolStripSeparator2
      // 
      toolStripSeparator2.Name = "toolStripSeparator2";
      toolStripSeparator2.Size = new Size(178, 6);
      // 
      // ExitToolStripMenuItem
      // 
      ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
      ExitToolStripMenuItem.Size = new Size(181, 22);
      ExitToolStripMenuItem.Text = "E&xit";
      // 
      // OpenTemplate
      // 
      _OpenTemplate.Filter = "UoT Level Templates (*.uot)|*.uot";
      // 
      // SaveTemplate
      // 
      _SaveTemplate.Filter = "UoT Level Templates (*.xml)|*.xml";
      // 
      // OpenOBJGraphics
      // 
      _OpenOBJGraphics.Filter = "Wavefront OBJ Models (*.obj)|*.obj";
      // 
      // OpenOBJCollision
      // 
      _OpenOBJCollision.Filter = "Wavefront OBJ Models (*.obj)|*.obj";
      // 
      // Label10
      // 
      Label10.AutoSize = true;
      Label10.Location = new Point(359, 59);
      Label10.Name = "Label10";
      Label10.Size = new Size(28, 13);
      Label10.TabIndex = 1;
      Label10.Text = "Map";
      // 
      // Label11
      // 
      Label11.AutoSize = true;
      Label11.Location = new Point(4, 250);
      Label11.Name = "Label11";
      Label11.Size = new Size(38, 13);
      Label11.TabIndex = 3;
      Label11.Text = "Scene";
      // 
      // SceneRawDataDisplay
      // 
      SceneRawDataDisplay.Location = new Point(6, 266);
      SceneRawDataDisplay.Multiline = true;
      SceneRawDataDisplay.Name = "SceneRawDataDisplay";
      SceneRawDataDisplay.Size = new Size(339, 254);
      SceneRawDataDisplay.TabIndex = 2;
      // 
      // GroupBox4
      // 
      GroupBox4.Controls.Add(_UpdateRawDataButton);
      GroupBox4.Controls.Add(SceneRawDataDisplay);
      GroupBox4.Controls.Add(Label11);
      GroupBox4.Controls.Add(MapRawDataDisplay);
      GroupBox4.Location = new Point(355, 37);
      GroupBox4.Name = "GroupBox4";
      GroupBox4.Size = new Size(351, 559);
      GroupBox4.TabIndex = 4;
      GroupBox4.TabStop = false;
      GroupBox4.Text = "Raw Data";
      // 
      // LevelCreator
      // 
      AutoScaleDimensions = new SizeF(6.0f, 13.0f);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(706, 598);
      Controls.Add(TabControl1);
      Controls.Add(Label10);
      Controls.Add(MenuStrip1);
      Controls.Add(GroupBox4);
      MainMenuStrip = MenuStrip1;
      Name = "LevelCreator";
      ShowIcon = false;
      Text = "Zelda Level Creator alpha";
      TabControl1.ResumeLayout(false);
      TabPage1.ResumeLayout(false);
      TabPage1.PerformLayout();
      TabControl3.ResumeLayout(false);
      TabPage5.ResumeLayout(false);
      TabPage5.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)LinkActorCount).EndInit();
      ((System.ComponentModel.ISupportInitialize)SceneActorCount).EndInit();
      GroupBox1.ResumeLayout(false);
      GroupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)RoomGroupCount).EndInit();
      ((System.ComponentModel.ISupportInitialize)RoomActorCount).EndInit();
      TabPage3.ResumeLayout(false);
      GroupBox3.ResumeLayout(false);
      GroupBox3.PerformLayout();
      MenuStrip1.ResumeLayout(false);
      MenuStrip1.PerformLayout();
      GroupBox4.ResumeLayout(false);
      GroupBox4.PerformLayout();
      Load += new EventHandler(ObjExport_Load);
      ResumeLayout(false);
      PerformLayout();
    }

    internal TabControl TabControl1;
    internal TabPage TabPage1;
    internal Label Label1;
    private Button _Button1;

    internal Button Button1 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _Button1;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_Button1 != null) {
          _Button1.Click -= Button1_Click;
        }

        _Button1 = value;
        if (_Button1 != null) {
          _Button1.Click += Button1_Click;
        }
      }
    }

    internal TextBox OBJGraphicsText;
    private Button _Button3;

    internal Button Button3 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _Button3;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_Button3 != null) {
          _Button3.Click -= Button3_Click;
        }

        _Button3 = value;
        if (_Button3 != null) {
          _Button3.Click += Button3_Click;
        }
      }
    }

    private CheckBox _SeparateCollisionToggle;

    internal CheckBox SeparateCollisionToggle {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _SeparateCollisionToggle;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_SeparateCollisionToggle != null) {
          _SeparateCollisionToggle.CheckedChanged -= CheckBox1_CheckedChanged;
        }

        _SeparateCollisionToggle = value;
        if (_SeparateCollisionToggle != null) {
          _SeparateCollisionToggle.CheckedChanged += CheckBox1_CheckedChanged;
        }
      }
    }

    internal TextBox ObjCollisionText;
    internal TabControl TabControl3;
    internal TabPage TabPage5;
    internal GroupBox GroupBox2;
    internal GroupBox GroupBox1;
    internal MenuStrip MenuStrip1;
    private OpenFileDialog _OpenTemplate;

    internal OpenFileDialog OpenTemplate {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _OpenTemplate;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_OpenTemplate != null) {
          _OpenTemplate.FileOk -= OpenTemplate_FileOk;
        }

        _OpenTemplate = value;
        if (_OpenTemplate != null) {
          _OpenTemplate.FileOk += OpenTemplate_FileOk;
        }
      }
    }

    private SaveFileDialog _SaveTemplate;

    internal SaveFileDialog SaveTemplate {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _SaveTemplate;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_SaveTemplate != null) {
          _SaveTemplate.FileOk -= SaveTemplate_FileOk;
        }

        _SaveTemplate = value;
        if (_SaveTemplate != null) {
          _SaveTemplate.FileOk += SaveTemplate_FileOk;
        }
      }
    }

    internal TabPage TabPage6;
    internal TabPage TabPage7;
    internal ComboBox EchoLevelMenu;
    internal Label Label4;
    internal CheckBox SkyboxToggle;
    internal Label Label3;
    internal NumericUpDown RoomGroupCount;
    internal Label Label2;
    internal NumericUpDown RoomActorCount;
    internal Label Label5;
    internal NumericUpDown SceneActorCount;
    private OpenFileDialog _OpenOBJGraphics;

    internal OpenFileDialog OpenOBJGraphics {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _OpenOBJGraphics;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_OpenOBJGraphics != null) {
          _OpenOBJGraphics.FileOk -= OpenOBJGraphics_FileOk;
        }

        _OpenOBJGraphics = value;
        if (_OpenOBJGraphics != null) {
          _OpenOBJGraphics.FileOk += OpenOBJGraphics_FileOk;
        }
      }
    }

    private OpenFileDialog _OpenOBJCollision;

    internal OpenFileDialog OpenOBJCollision {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _OpenOBJCollision;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_OpenOBJCollision != null) {
          _OpenOBJCollision.FileOk -= OpenOBJCollision_FileOk;
        }

        _OpenOBJCollision = value;
        if (_OpenOBJCollision != null) {
          _OpenOBJCollision.FileOk += OpenOBJCollision_FileOk;
        }
      }
    }

    internal ToolStripMenuItem FileToolStripMenuItem1;
    private ToolStripMenuItem _NewToolStripMenuItem;

    internal ToolStripMenuItem NewToolStripMenuItem {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _NewToolStripMenuItem;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_NewToolStripMenuItem != null) {
          _NewToolStripMenuItem.Click -= NewToolStripMenuItem_Click;
        }

        _NewToolStripMenuItem = value;
        if (_NewToolStripMenuItem != null) {
          _NewToolStripMenuItem.Click += NewToolStripMenuItem_Click;
        }
      }
    }

    private ToolStripMenuItem _OpenToolStripMenuItem;

    internal ToolStripMenuItem OpenToolStripMenuItem {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _OpenToolStripMenuItem;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_OpenToolStripMenuItem != null) {
          _OpenToolStripMenuItem.Click -= OpenToolStripMenuItem_Click;
        }

        _OpenToolStripMenuItem = value;
        if (_OpenToolStripMenuItem != null) {
          _OpenToolStripMenuItem.Click += OpenToolStripMenuItem_Click;
        }
      }
    }

    internal ToolStripSeparator toolStripSeparator;
    private ToolStripMenuItem _SaveToolStripMenuItem;

    internal ToolStripMenuItem SaveToolStripMenuItem {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _SaveToolStripMenuItem;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_SaveToolStripMenuItem != null) {
          _SaveToolStripMenuItem.Click -= SaveToolStripMenuItem_Click;
        }

        _SaveToolStripMenuItem = value;
        if (_SaveToolStripMenuItem != null) {
          _SaveToolStripMenuItem.Click += SaveToolStripMenuItem_Click;
        }
      }
    }

    internal ToolStripSeparator toolStripSeparator2;
    internal ToolStripMenuItem ExitToolStripMenuItem;
    internal TextBox MapRawDataDisplay;
    internal TabPage TabPage3;
    internal GroupBox GroupBox3;
    internal RadioButton RadioButton3;
    internal RadioButton RadioButton2;
    internal RadioButton RadioButton1;
    internal Label Label8;
    internal RadioButton RadioButton4;
    internal RadioButton RadioButton5;
    internal RadioButton RadioButton6;
    internal Label Label7;
    internal Label Label9;
    internal NumericUpDown LinkActorCount;
    private Button _UpdateRawDataButton;

    internal Button UpdateRawDataButton {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _UpdateRawDataButton;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_UpdateRawDataButton != null) {
          _UpdateRawDataButton.Click -= Button4_Click_1;
        }

        _UpdateRawDataButton = value;
        if (_UpdateRawDataButton != null) {
          _UpdateRawDataButton.Click += Button4_Click_1;
        }
      }
    }

    internal Label Label11;
    internal TextBox SceneRawDataDisplay;
    internal Label Label10;
    internal GroupBox GroupBox4;
    internal Label Label6;
    private TextBox _LevelNameText;

    internal TextBox LevelNameText {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _LevelNameText;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_LevelNameText != null) {
          _LevelNameText.TextChanged -= TextBox5_TextChanged;
        }

        _LevelNameText = value;
        if (_LevelNameText != null) {
          _LevelNameText.TextChanged += TextBox5_TextChanged;
        }
      }
    }
  }
}