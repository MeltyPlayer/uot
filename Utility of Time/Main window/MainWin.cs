using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Reflection;
using System.Text.RegularExpressions;

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

using Tao.FreeGlut;
using Tao.OpenGl;
using Tao.Platform.Windows;
using UoT.Tao.Platform.Windows;

namespace UoT {
  public partial class MainWin {

    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public MainWin() : base() {

      // This call is required by the Windows Form Designer.
      InitializeComponent();
      // Add any initialization after the InitializeComponent() call
      UoTRender.InitializeContexts();
      _ToolStatusLabel.Name = "ToolStatusLabel";
      _TrackBar4.Name = "TrackBar4";
      _OpenModelToolStripMenuItem.Name = "OpenModelToolStripMenuItem";
      _QuitToolStripMenuItem.Name = "QuitToolStripMenuItem";
      _ResetAllActorsToolStripMenuItem.Name = "ResetAllActorsToolStripMenuItem";
      _ResetAllSceneActorsToolStripMenuItem.Name = "ResetAllSceneActorsToolStripMenuItem";
      _SelectAllRoomActorsToolStripMenuItem.Name = "SelectAllRoomActorsToolStripMenuItem";
      _SelectAllSceneActorsToolStripMenuItem.Name = "SelectAllSceneActorsToolStripMenuItem";
      _ViewingMeshToolStripMenuItem1.Name = "ViewingMeshToolStripMenuItem1";
      _CollisionMeshToolStripMenuItem.Name = "CollisionMeshToolStripMenuItem";
      _FilledToolStripMenuItem.Name = "FilledToolStripMenuItem";
      _WireframeToolStripMenuItem.Name = "WireframeToolStripMenuItem";
      _SetupToolStripMenuItem.Name = "SetupToolStripMenuItem";
      _Button9.Name = "Button9";
      _ColTriangleBox.Name = "ColTriangleBox";
      _ApplyCollisionButton.Name = "ApplyCollisionButton";
      _ColTypeBox.Name = "ColTypeBox";
      _ExitCombobox.Name = "ExitCombobox";
      _CheckBox5.Name = "CheckBox5";
      _CheckBox15.Name = "CheckBox15";
      _CheckBox14.Name = "CheckBox14";
      _CheckBox13.Name = "CheckBox13";
      _MapsCombobox.Name = "MapsCombobox";
      _Button2.Name = "Button2";
      _TextBox9.Name = "TextBox9";
      _TextBox8.Name = "TextBox8";
      _TextBox7.Name = "TextBox7";
      _TextBox10.Name = "TextBox10";
      _TextBox11.Name = "TextBox11";
      _TextBox12.Name = "TextBox12";
      _Button6.Name = "Button6";
      _SceneActorCombobox.Name = "SceneActorCombobox";
      _ActorGroupText.Name = "ActorGroupText";
      _RoomActorCombobox.Name = "RoomActorCombobox";
      _CurrentFrame.Name = "CurrentFrame";
      _CheckBox2.Name = "CheckBox2";
      _AnimationList.Name = "AnimationList";
      _animationbank.Name = "animationbank";
      _AnimationFPS.Name = "AnimationFPS";
      _CheckBox1.Name = "CheckBox1";
      _Button5.Name = "Button5";
      _Button3.Name = "Button3";
      _RadioButton2.Name = "RadioButton2";
      _WholeCommandTxt.Name = "WholeCommandTxt";
      _Button8.Name = "Button8";
      _HiwordText.Name = "HiwordText";
      _Button1.Name = "Button1";
      _LowordText.Name = "LowordText";
      _CommandCodeText.Name = "CommandCodeText";
      _Button4.Name = "Button4";
      _CommandsListbox.Name = "CommandsListbox";
      _DListSelection.Name = "DListSelection";
      _RadioButton1.Name = "RadioButton1";
      _Button12.Name = "Button12";
      _Button10.Name = "Button10";
      _TrackBar1.Name = "TrackBar1";
      _UoTRender.Name = "UoTRender";
      _DeselectToolStripMenuItem.Name = "DeselectToolStripMenuItem";
      _DegreesToolStripMenuItem.Name = "DegreesToolStripMenuItem";
      _DegreesToolStripMenuItem1.Name = "DegreesToolStripMenuItem1";
      _DegreesToolStripMenuItem2.Name = "DegreesToolStripMenuItem2";
      _DegreesToolStripMenuItem3.Name = "DegreesToolStripMenuItem3";
      _DegreesToolStripMenuItem4.Name = "DegreesToolStripMenuItem4";
      _DegreesToolStripMenuItem5.Name = "DegreesToolStripMenuItem5";
      _XToolStripMenuItem3.Name = "XToolStripMenuItem3";
      _YToolStripMenuItem3.Name = "YToolStripMenuItem3";
      _ZToolStripMenuItem2.Name = "ZToolStripMenuItem2";
      _CopyToolStripMenuItem.Name = "CopyToolStripMenuItem";
      _XToolStripMenuItem1.Name = "XToolStripMenuItem1";
      _YToolStripMenuItem1.Name = "YToolStripMenuItem1";
      _ZToolStripMenuItem.Name = "ZToolStripMenuItem";
      _AllToolStripMenuItem1.Name = "AllToolStripMenuItem1";
      _XToolStripMenuItem2.Name = "XToolStripMenuItem2";
      _YToolStripMenuItem2.Name = "YToolStripMenuItem2";
      _ZToolStripMenuItem1.Name = "ZToolStripMenuItem1";
      _AllToolStripMenuItem.Name = "AllToolStripMenuItem";
      _NumberAndVariableToolStripMenuItem.Name = "NumberAndVariableToolStripMenuItem";
      _ClearClipboardToolStripMenuItem.Name = "ClearClipboardToolStripMenuItem";
      _Button7.Name = "Button7";
      _FileTree.Name = "FileTree";
      _ToolStripMenuItem35.Name = "ToolStripMenuItem35";
      _ToolStripMenuItem2.Name = "ToolStripMenuItem2";
      _CustomLevel.Name = "CustomLevel";
      _SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
      _ToolStripMenuItem34.Name = "ToolStripMenuItem34";
      _ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
      _UndoToolStripMenuItem.Name = "UndoToolStripMenuItem";
      _WireframeModeToolStripMenuItem.Name = "WireframeModeToolStripMenuItem";
      _GraphicsToolStripMenuItem.Name = "GraphicsToolStripMenuItem";
      _CollisionOverlayToolStripMenuItem.Name = "CollisionOverlayToolStripMenuItem";
      _CameraOnlyMenu.Name = "CameraOnlyMenu";
      _ActorSelectorMenu.Name = "ActorSelectorMenu";
      _CollisionToolStripMenuItem.Name = "CollisionToolStripMenuItem";
      _DisplayListSelectorToolStripMenuItem.Name = "DisplayListSelectorToolStripMenuItem";
      _XToolStripMenuItem.Name = "XToolStripMenuItem";
      _YToolStripMenuItem.Name = "YToolStripMenuItem";
      _DisableToolStripMenuItem.Name = "DisableToolStripMenuItem";
      _DisableDepthTestToolStripMenuItem.Name = "DisableDepthTestToolStripMenuItem";
      _OptionsToolStripMenuItem1.Name = "OptionsToolStripMenuItem1";
      _TexturesToolStripMenuItem.Name = "TexturesToolStripMenuItem";
      _ColorCombinerToolStripMenuItem.Name = "ColorCombinerToolStripMenuItem";
      _AnisotropicFilteringToolStripMenuItem.Name = "AnisotropicFilteringToolStripMenuItem";
      _FullSceneAntialiasingToolStripMenuItem.Name = "FullSceneAntialiasingToolStripMenuItem";
      _AboutUoTToolStripMenuItem.Name = "AboutUoTToolStripMenuItem";
      _ToolStripMenuItem20.Name = "ToolStripMenuItem20";
    }
    // Form overrides dispose to clean up the component list.
    [DebuggerNonUserCode()]
    protected override void Dispose(bool disposing) {
      if (disposing && components is object) {
        components.Dispose();
      }

      base.Dispose(disposing);
      UoTRender.DestroyContexts();
    }

    // Required by the Windows Form Designer
    private System.ComponentModel.IContainer components;
    private OpenFileDialog _LoadROM;

    internal OpenFileDialog LoadROM {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _LoadROM;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_LoadROM != null) {
          _LoadROM.FileOk -= LoadActorGFX_FileOk;
        }

        _LoadROM = value;
        if (_LoadROM != null) {
          _LoadROM.FileOk += LoadActorGFX_FileOk;
        }
      }
    }

    // NOTE: The following procedure is required by the Windows Form Designer
    // It can be modified using the Windows Form Designer.  
    // Do not modify it using the code editor.
    [DebuggerStepThrough()]
    private void InitializeComponent() {
      components = new System.ComponentModel.Container();
      var resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWin));
      _LoadROM = new OpenFileDialog();
      _LoadROM.FileOk += new System.ComponentModel.CancelEventHandler(LoadActorGFX_FileOk);
      UoTStatus = new StatusStrip();
      _ToolStatusLabel = new ToolStripStatusLabel();
      _ToolStatusLabel.Click += new EventHandler(ToolStatusLabel_Click);
      CamXLabel = new ToolStripStatusLabel();
      CamYLabel = new ToolStripStatusLabel();
      CamZLabel = new ToolStripStatusLabel();
      ToolStripStatusLabel5 = new ToolStripStatusLabel();
      ToolStripStatusLabel4 = new ToolStripStatusLabel();
      ToolStripSeparator4 = new ToolStripSeparator();
      ToolStripSeparator2 = new ToolStripSeparator();
      ToolStripSeparator1 = new ToolStripSeparator();
      ToolStripSeparator6 = new ToolStripSeparator();
      ToolStripSeparator5 = new ToolStripSeparator();
      ToolStripSeparator3 = new ToolStripSeparator();
      Label12 = new Label();
      _TrackBar4 = new TrackBar();
      _TrackBar4.ValueChanged += new EventHandler(TrackBar4_ValueChanged);
      FileToolStripMenuItem = new ToolStripMenuItem();
      _OpenModelToolStripMenuItem = new ToolStripMenuItem();
      _OpenModelToolStripMenuItem.Click += new EventHandler(LoadZOBJToolStripMenuItem_Click);
      SaveChangesToolStripMenuItem = new ToolStripMenuItem();
      ReloadCurrentFileToolStripMenuItem = new ToolStripMenuItem();
      ImportCSVToolStripMenuItem = new ToolStripMenuItem();
      ToolStripSeparator10 = new ToolStripSeparator();
      _QuitToolStripMenuItem = new ToolStripMenuItem();
      _QuitToolStripMenuItem.Click += new EventHandler(QuitToolStripMenuItem_Click);
      EditToolStripMenuItem = new ToolStripMenuItem();
      ResetSelectedVerticesToolStripMenuItem = new ToolStripMenuItem();
      ResetAllGraphicsToolStripMenuItem = new ToolStripMenuItem();
      ResetAllCollisionToolStripMenuItem = new ToolStripMenuItem();
      ToolStripSeparator11 = new ToolStripSeparator();
      ResetSelectedActorToolStripMenuItem = new ToolStripMenuItem();
      _ResetAllActorsToolStripMenuItem = new ToolStripMenuItem();
      _ResetAllActorsToolStripMenuItem.Click += new EventHandler(ResetAllActorsToolStripMenuItem_Click);
      _ResetAllSceneActorsToolStripMenuItem = new ToolStripMenuItem();
      _ResetAllSceneActorsToolStripMenuItem.Click += new EventHandler(ResetAllSceneActorsToolStripMenuItem_Click);
      ToolStripSeparator9 = new ToolStripSeparator();
      _SelectAllRoomActorsToolStripMenuItem = new ToolStripMenuItem();
      _SelectAllRoomActorsToolStripMenuItem.Click += new EventHandler(SelectAllRoomActorsToolStripMenuItem_Click);
      _SelectAllSceneActorsToolStripMenuItem = new ToolStripMenuItem();
      _SelectAllSceneActorsToolStripMenuItem.Click += new EventHandler(SelectAllSceneActorsToolStripMenuItem_Click);
      SelectAllGraphicsToolStripMenuItem = new ToolStripMenuItem();
      SelectAllCollisionToolStripMenuItem = new ToolStripMenuItem();
      OptionsToolStripMenuItem = new ToolStripMenuItem();
      LaunchROMInPJ64ToolStripMenuItem = new ToolStripMenuItem();
      ZeldaResourceExtractorToolStripMenuItem = new ToolStripMenuItem();
      FeaturesToolStripMenuItem = new ToolStripMenuItem();
      RenderModeToolStripMenuItem = new ToolStripMenuItem();
      _ViewingMeshToolStripMenuItem1 = new ToolStripMenuItem();
      _ViewingMeshToolStripMenuItem1.Click += new EventHandler(ViewingMeshToolStripMenuItem1_Click);
      _CollisionMeshToolStripMenuItem = new ToolStripMenuItem();
      _CollisionMeshToolStripMenuItem.Click += new EventHandler(CollisionMeshToolStripMenuItem_Click_1);
      PrimitiveTypeToolStripMenuItem = new ToolStripMenuItem();
      _FilledToolStripMenuItem = new ToolStripMenuItem();
      _FilledToolStripMenuItem.Click += new EventHandler(FilledToolStripMenuItem_Click_1);
      _WireframeToolStripMenuItem = new ToolStripMenuItem();
      _WireframeToolStripMenuItem.Click += new EventHandler(WireframeToolStripMenuItem_Click_1);
      ToolStripSeparator8 = new ToolStripSeparator();
      MouseToolToolStripMenuItem = new ToolStripMenuItem();
      _SetupToolStripMenuItem = new ToolStripMenuItem();
      _SetupToolStripMenuItem.Click += new EventHandler(SetupToolStripMenuItem_Click_2);
      HelpToolStripMenuItem = new ToolStripMenuItem();
      ControlsInfoToolStripMenuItem = new ToolStripMenuItem();
      ToolStripSeparator7 = new ToolStripSeparator();
      AboutToolStripMenuItem = new ToolStripMenuItem();
      SearchForUpdatesToolStripMenuItem = new ToolStripMenuItem();
      _ActorInputTimer = new Timer(components);
      _ActorInputTimer.Tick += new EventHandler(Timer1_Tick);
      _ActorInputTimer.Tick += new EventHandler(Timer1_Tick);
      _ActorInputTimer.Tick += new EventHandler(Timer1_Tick);
      _ActorInputTimer.Tick += new EventHandler(Timer1_Tick);
      CollisionTab = new TabPage();
      GroupBox1 = new GroupBox();
      _Button9 = new Button();
      _Button9.Click += new EventHandler(Button9_Click);
      TriTypeText = new TextBox();
      Label48 = new Label();
      Label47 = new Label();
      _ColTriangleBox = new ComboBox();
      _ColTriangleBox.SelectedIndexChanged += new EventHandler(ColTriangleBox_SelectedIndexChanged);
      CollisionGroupBox = new GroupBox();
      Label36 = new Label();
      ColWalkSound = new TextBox();
      Label38 = new Label();
      Label37 = new Label();
      Label35 = new Label();
      Label33 = new Label();
      Label32 = new Label();
      Label23 = new Label();
      Label13 = new Label();
      Label1 = new Label();
      ColVar4 = new TextBox();
      _ApplyCollisionButton = new Button();
      _ApplyCollisionButton.Click += new EventHandler(Button22_Click_1);
      _ApplyCollisionButton.Click += new EventHandler(Button22_Click_1);
      _ApplyCollisionButton.Click += new EventHandler(Button22_Click_1);
      _ApplyCollisionButton.Click += new EventHandler(Button22_Click_1);
      ColVar2 = new TextBox();
      ColVar3 = new TextBox();
      ColVar1 = new TextBox();
      CollisionPresetButton = new Button();
      Label34 = new Label();
      ColTypeText = new TextBox();
      _ColTypeBox = new ComboBox();
      _ColTypeBox.SelectedIndexChanged += new EventHandler(ComboBox1_SelectedIndexChanged_1);
      _ColTypeBox.SelectedIndexChanged += new EventHandler(ComboBox1_SelectedIndexChanged_1);
      _ColTypeBox.SelectedIndexChanged += new EventHandler(ComboBox1_SelectedIndexChanged_1);
      _ColTypeBox.SelectedIndexChanged += new EventHandler(ComboBox1_SelectedIndexChanged_1);
      Label31 = new Label();
      ExitTextBox = new TextBox();
      _ExitCombobox = new ComboBox();
      _ExitCombobox.SelectedIndexChanged += new EventHandler(ComboBox8_SelectedIndexChanged_1);
      _ExitCombobox.SelectedIndexChanged += new EventHandler(ComboBox8_SelectedIndexChanged_1);
      _ExitCombobox.SelectedIndexChanged += new EventHandler(ComboBox8_SelectedIndexChanged_1);
      _ExitCombobox.SelectedIndexChanged += new EventHandler(ComboBox8_SelectedIndexChanged_1);
      Label10 = new Label();
      MiscTab = new TabPage();
      GroupBox9 = new GroupBox();
      ProgressBar1 = new ProgressBar();
      Label28 = new Label();
      Button16 = new Button();
      Button15 = new Button();
      Label45 = new Label();
      AnimStart = new TextBox();
      Label30 = new Label();
      LimbStart = new TextBox();
      GroupBox10 = new GroupBox();
      _CheckBox5 = new CheckBox();
      _CheckBox5.CheckedChanged += new EventHandler(CheckBox5_CheckedChanged);
      _CheckBox15 = new CheckBox();
      _CheckBox15.CheckedChanged += new EventHandler(CheckBox15_CheckedChanged_1);
      _CheckBox14 = new CheckBox();
      _CheckBox14.CheckedChanged += new EventHandler(CheckBox14_CheckedChanged_1);
      _CheckBox13 = new CheckBox();
      _CheckBox13.CheckedChanged += new EventHandler(CheckBox13_CheckedChanged_1);
      GroupBox8 = new GroupBox();
      _MapsCombobox = new ComboBox();
      _MapsCombobox.SelectedIndexChanged += new EventHandler(MapsCombobox_SelectedIndexChanged);
      Label46 = new Label();
      LevelFlagsTab = new TabPage();
      GroupBox6 = new GroupBox();
      ComboBox6 = new ComboBox();
      Label2 = new Label();
      Button11 = new Button();
      TextBox13 = new TextBox();
      Label21 = new Label();
      ActorsTab = new TabPage();
      _Button2 = new Button();
      _Button2.Click += new EventHandler(Button2_Click);
      GroupBox4 = new GroupBox();
      Label14 = new Label();
      Label17 = new Label();
      _TextBox9 = new TextBox();
      _TextBox9.TextChanged += new EventHandler(TextBox9_TextChanged);
      Label18 = new Label();
      _TextBox8 = new TextBox();
      _TextBox8.TextChanged += new EventHandler(TextBox8_TextChanged);
      Label19 = new Label();
      _TextBox7 = new TextBox();
      _TextBox7.TextChanged += new EventHandler(TextBox7_TextChanged);
      _TextBox10 = new TextBox();
      _TextBox10.TextChanged += new EventHandler(TextBox10_TextChanged);
      Label16 = new Label();
      _TextBox11 = new TextBox();
      _TextBox11.TextChanged += new EventHandler(TextBox11_TextChanged);
      Label15 = new Label();
      _TextBox12 = new TextBox();
      _TextBox12.TextChanged += new EventHandler(TextBox12_TextChanged);
      GroupBox5 = new GroupBox();
      _Button6 = new Button();
      /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
      _Button6.Click += new EventHandler(Button6_Click_1);
      _SceneActorCombobox = new ComboBox();
      _SceneActorCombobox.SelectedIndexChanged += new EventHandler(ComboBox5_SelectedIndexChanged);
      _SceneActorCombobox.SelectedIndexChanged += new EventHandler(ComboBox5_SelectedIndexChanged);
      _SceneActorCombobox.SelectedIndexChanged += new EventHandler(ComboBox5_SelectedIndexChanged);
      _SceneActorCombobox.SelectedIndexChanged += new EventHandler(ComboBox5_SelectedIndexChanged);
      ActorNumberText = new TextBox();
      Label7 = new Label();
      ActorVarText = new TextBox();
      Label8 = new Label();
      Label6 = new Label();
      _ActorGroupText = new TextBox();
      _ActorGroupText.TextChanged += new EventHandler(ActorGroupText_TextChanged);
      Label22 = new Label();
      _RoomActorCombobox = new ComboBox();
      _RoomActorCombobox.SelectedIndexChanged += new EventHandler(RoomActorCombobox_SelectedIndexChanged);
      _RoomActorCombobox.SelectedIndexChanged += new EventHandler(RoomActorCombobox_SelectedIndexChanged);
      _RoomActorCombobox.SelectedIndexChanged += new EventHandler(RoomActorCombobox_SelectedIndexChanged);
      _RoomActorCombobox.SelectedIndexChanged += new EventHandler(RoomActorCombobox_SelectedIndexChanged);
      Label24 = new Label();
      EditingTabs = new TabControl();
      AnimationsTab = new TabPage();
      Label5 = new Label();
      _CurrentFrame = new TrackBar();
      _CurrentFrame.Scroll += new EventHandler(CurrentFrame_Scroll);
      AnimationSetGroup = new GroupBox();
      Label20 = new Label();
      _CheckBox2 = new CheckBox();
      _CheckBox2.CheckedChanged += new EventHandler(CheckBox2_CheckedChanged);
      _AnimationList = new ListBox();
      _AnimationList.SelectedIndexChanged += new EventHandler(AnimationList_SelectedIndexChanged);
      _animationbank = new ComboBox();
      _animationbank.SelectedIndexChanged += new EventHandler(animationbank_SelectedIndexChanged);
      PlaybackGroup = new GroupBox();
      _AnimationFPS = new NumericUpDown();
      _AnimationFPS.ValueChanged += new EventHandler(NumericUpDown1_ValueChanged);
      _AnimationFPS.ValueChanged += new EventHandler(NumericUpDown1_ValueChanged);
      _AnimationFPS.ValueChanged += new EventHandler(NumericUpDown1_ValueChanged);
      _AnimationFPS.ValueChanged += new EventHandler(NumericUpDown1_ValueChanged);
      Label27 = new Label();
      FrameNo = new Label();
      AnimationElapse = new Label();
      _CheckBox1 = new CheckBox();
      _CheckBox1.CheckedChanged += new EventHandler(CheckBox1_CheckedChanged);
      _Button5 = new Button();
      _Button5.Click += new EventHandler(Button5_Click);
      _Button3 = new Button();
      _Button3.Click += new EventHandler(Button3_Click);
      DLTab = new TabPage();
      _RadioButton2 = new RadioButton();
      _RadioButton2.CheckedChanged += new EventHandler(RadioButton2_CheckedChanged);
      GroupBox7 = new GroupBox();
      _WholeCommandTxt = new TextBox();
      _WholeCommandTxt.TextChanged += new EventHandler(WholeCommandTxt_TextChanged);
      Label3 = new Label();
      _Button8 = new Button();
      _Button8.Click += new EventHandler(Button8_Click);
      _HiwordText = new TextBox();
      _HiwordText.KeyPress += new KeyPressEventHandler(CommandCodeText_KeyDown);
      _HiwordText.TextChanged += new EventHandler(CommandCodeText_TextChanged);
      _Button1 = new Button();
      _Button1.Click += new EventHandler(Button1_Click);
      _LowordText = new TextBox();
      _LowordText.KeyPress += new KeyPressEventHandler(CommandCodeText_KeyDown);
      _LowordText.TextChanged += new EventHandler(CommandCodeText_TextChanged);
      _CommandCodeText = new TextBox();
      _CommandCodeText.KeyPress += new KeyPressEventHandler(CommandCodeText_KeyDown);
      _CommandCodeText.TextChanged += new EventHandler(CommandCodeText_TextChanged);
      CommandJumpBox = new ComboBox();
      Label26 = new Label();
      Label25 = new Label();
      Label9 = new Label();
      _Button4 = new Button();
      _Button4.Click += new EventHandler(Button4_Click);
      _CommandsListbox = new ListBox();
      _CommandsListbox.SelectedIndexChanged += new EventHandler(CommandsListbox_SelectedIndexChanged);
      _CommandsListbox.DoubleClick += new EventHandler(CommandsListbox_DoubleClick);
      DLEditorContextMenu = new ContextMenuStrip(components);
      Copy = new ToolStripMenuItem();
      Paste = new ToolStripMenuItem();
      Reset = new ToolStripMenuItem();
      _DListSelection = new ComboBox();
      _DListSelection.SelectedIndexChanged += new EventHandler(DListSelection_SelectedIndexChanged);
      _RadioButton1 = new RadioButton();
      _RadioButton1.CheckedChanged += new EventHandler(RadioButton1_CheckedChanged);
      GroupBox3 = new GroupBox();
      _Button12 = new Button();
      _Button12.Click += new EventHandler(Button12_Click);
      Label4 = new Label();
      _Button10 = new Button();
      _Button10.Click += new EventHandler(Button10_Click);
      BackupMenuStrip = new ContextMenuStrip(components);
      RestorToolStripMenuItem = new ToolStripMenuItem();
      Label43 = new Label();
      _TrackBar1 = new TrackBar();
      _TrackBar1.ValueChanged += new EventHandler(TrackBar1_ValueChanged);

      var assembly = Assembly.GetExecutingAssembly();
      var names = assembly.GetManifestResourceNames();

      foreach (var name in names) {
        Console.WriteLine(name);
      }

      _UoTRender = new UoT.Tao.Platform.Windows.SimpleOpenGlControl();
      _UoTRender.KeyDown += new KeyEventHandler(SimpleOpenGlControl1_KeyDown);
      _UoTRender.KeyDown += new KeyEventHandler(SimpleOpenGlControl1_KeyDown);
      _UoTRender.KeyDown += new KeyEventHandler(SimpleOpenGlControl1_KeyDown);
      _UoTRender.KeyDown += new KeyEventHandler(SimpleOpenGlControl1_KeyDown);
      _UoTRender.KeyUp += new KeyEventHandler(SimpleOpenGlControl1_KeyUp);
      _UoTRender.KeyUp += new KeyEventHandler(SimpleOpenGlControl1_KeyUp);
      _UoTRender.KeyUp += new KeyEventHandler(SimpleOpenGlControl1_KeyUp);
      _UoTRender.KeyUp += new KeyEventHandler(SimpleOpenGlControl1_KeyUp);
      _UoTRender.MouseDown += new MouseEventHandler(SimpleOpenGlControl1_MouseDown);
      _UoTRender.MouseUp += new MouseEventHandler(SimpleOpenGlControl1_MouseUp);
      _UoTRender.MouseWheel += new MouseEventHandler(ScrollSensitivity);
      _UoTRender.MouseWheel += new MouseEventHandler(ScrollSensitivity);
      _UoTRender.MouseWheel += new MouseEventHandler(ScrollSensitivity);
      _UoTRender.MouseWheel += new MouseEventHandler(ScrollSensitivity);
      _UoTRender.MouseMove += new MouseEventHandler(SimpleOpenGlControl1_MouseMove);
      _UoTRender.MouseMove += new MouseEventHandler(SimpleOpenGlControl1_MouseMove);
      _UoTRender.MouseMove += new MouseEventHandler(SimpleOpenGlControl1_MouseMove);
      _UoTRender.MouseMove += new MouseEventHandler(SimpleOpenGlControl1_MouseMove);
      ActorContextMenu = new ContextMenuStrip(components);
      _DeselectToolStripMenuItem = new ToolStripMenuItem();
      _DeselectToolStripMenuItem.Click += new EventHandler(DeselectToolStripMenuItem_Click);
      ToolStripSeparator14 = new ToolStripSeparator();
      EditToolStripMenuItem2 = new ToolStripMenuItem();
      CamXRotationToolStripMenuItem = new ToolStripMenuItem();
      _DegreesToolStripMenuItem = new ToolStripMenuItem();
      _DegreesToolStripMenuItem.Click += new EventHandler(DegreesToolStripMenuItem_Click);
      _DegreesToolStripMenuItem1 = new ToolStripMenuItem();
      _DegreesToolStripMenuItem1.Click += new EventHandler(DegreesToolStripMenuItem1_Click);
      CamYRotationToolStripMenuItem = new ToolStripMenuItem();
      _DegreesToolStripMenuItem2 = new ToolStripMenuItem();
      _DegreesToolStripMenuItem2.Click += new EventHandler(DegreesToolStripMenuItem2_Click);
      _DegreesToolStripMenuItem3 = new ToolStripMenuItem();
      _DegreesToolStripMenuItem3.Click += new EventHandler(DegreesToolStripMenuItem3_Click);
      CamZRotationToolStripMenuItem = new ToolStripMenuItem();
      _DegreesToolStripMenuItem4 = new ToolStripMenuItem();
      _DegreesToolStripMenuItem4.Click += new EventHandler(DegreesToolStripMenuItem4_Click);
      _DegreesToolStripMenuItem5 = new ToolStripMenuItem();
      _DegreesToolStripMenuItem5.Click += new EventHandler(DegreesToolStripMenuItem5_Click);
      AlignToolItem = new ToolStripMenuItem();
      _XToolStripMenuItem3 = new ToolStripMenuItem();
      _XToolStripMenuItem3.Click += new EventHandler(XToolStripMenuItem3_Click);
      _YToolStripMenuItem3 = new ToolStripMenuItem();
      _YToolStripMenuItem3.Click += new EventHandler(YToolStripMenuItem3_Click);
      _ZToolStripMenuItem2 = new ToolStripMenuItem();
      _ZToolStripMenuItem2.Click += new EventHandler(ZToolStripMenuItem2_Click);
      ToolStripSeparator13 = new ToolStripSeparator();
      _CopyToolStripMenuItem = new ToolStripMenuItem();
      _CopyToolStripMenuItem.Click += new EventHandler(CopyToolStripMenuItem_Click);
      PasteToolStripMenuItem = new ToolStripMenuItem();
      PositionToolStripMenuItem = new ToolStripMenuItem();
      _XToolStripMenuItem1 = new ToolStripMenuItem();
      _XToolStripMenuItem1.Click += new EventHandler(XToolStripMenuItem1_Click);
      _YToolStripMenuItem1 = new ToolStripMenuItem();
      _YToolStripMenuItem1.Click += new EventHandler(YToolStripMenuItem1_Click);
      _ZToolStripMenuItem = new ToolStripMenuItem();
      _ZToolStripMenuItem.Click += new EventHandler(ZToolStripMenuItem_Click);
      _AllToolStripMenuItem1 = new ToolStripMenuItem();
      _AllToolStripMenuItem1.Click += new EventHandler(AllToolStripMenuItem1_Click);
      RotationToolStripMenuItem = new ToolStripMenuItem();
      _XToolStripMenuItem2 = new ToolStripMenuItem();
      _XToolStripMenuItem2.Click += new EventHandler(XToolStripMenuItem2_Click);
      _YToolStripMenuItem2 = new ToolStripMenuItem();
      _YToolStripMenuItem2.Click += new EventHandler(YToolStripMenuItem2_Click);
      _ZToolStripMenuItem1 = new ToolStripMenuItem();
      _ZToolStripMenuItem1.Click += new EventHandler(ZToolStripMenuItem1_Click);
      _AllToolStripMenuItem = new ToolStripMenuItem();
      _AllToolStripMenuItem.Click += new EventHandler(AllToolStripMenuItem_Click_1);
      _NumberAndVariableToolStripMenuItem = new ToolStripMenuItem();
      _NumberAndVariableToolStripMenuItem.Click += new EventHandler(NumberAndVariableToolStripMenuItem_Click);
      _ClearClipboardToolStripMenuItem = new ToolStripMenuItem();
      _ClearClipboardToolStripMenuItem.Click += new EventHandler(ClearClipboardToolStripMenuItem_Click);
      _RotationTimer = new Timer(components);
      _RotationTimer.Tick += new EventHandler(RotationTimer_Tick);
      _LoadIndividual = new OpenFileDialog();
      _LoadIndividual.FileOk += new System.ComponentModel.CancelEventHandler(LoadIndividual_FileOk);
      ROMBrowser = new TabControl();
      ROMDataTabs = new TabPage();
      _Button7 = new Button();
      _Button7.Click += new EventHandler(Button7_Click);
      IndividualFiles = new TabPage();
      Label29 = new Label();
      TreeFind = new TextBox();
      _FileTree = new TreeView();
      _FileTree.NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler(FileTree_NodeMouseDoubleClick);
      FileToolStripMenuItem1 = new ToolStripMenuItem();
      _ToolStripMenuItem35 = new ToolStripMenuItem();
      _ToolStripMenuItem35.Click += new EventHandler(ToolStripMenuItem35_Click);
      _ToolStripMenuItem2 = new ToolStripMenuItem();
      _ToolStripMenuItem2.Click += new EventHandler(ToolStripMenuItem2_Click);
      _CustomLevel = new ToolStripMenuItem();
      _CustomLevel.Click += new EventHandler(CustomLevel_Click);
      toolStripSeparator = new ToolStripSeparator();
      _SaveToolStripMenuItem = new ToolStripMenuItem();
      _SaveToolStripMenuItem.Click += new EventHandler(SaveToolStripMenuItem_Click);
      _ToolStripMenuItem34 = new ToolStripMenuItem();
      _ToolStripMenuItem34.Click += new EventHandler(ToolStripMenuItem34_Click);
      toolStripSeparator12 = new ToolStripSeparator();
      _ExitToolStripMenuItem = new ToolStripMenuItem();
      _ExitToolStripMenuItem.Click += new EventHandler(ExitToolStripMenuItem_Click);
      EditToolStripMenuItem1 = new ToolStripMenuItem();
      _UndoToolStripMenuItem = new ToolStripMenuItem();
      _UndoToolStripMenuItem.Click += new EventHandler(UndoToolStripMenuItem_Click);
      _WireframeModeToolStripMenuItem = new ToolStripMenuItem();
      _WireframeModeToolStripMenuItem.Click += new EventHandler(WireframeModeToolStripMenuItem_Click);
      RenderToolStripMenuItem = new ToolStripMenuItem();
      _GraphicsToolStripMenuItem = new ToolStripMenuItem();
      _GraphicsToolStripMenuItem.Click += new EventHandler(GraphicsToolStripMenuItem_Click);
      _CollisionOverlayToolStripMenuItem = new ToolStripMenuItem();
      _CollisionOverlayToolStripMenuItem.Click += new EventHandler(CollisionOverlayToolStripMenuItem_Click);
      ToolsToolStripMenuItem1 = new ToolStripMenuItem();
      MouseToolToolStripMenuItem1 = new ToolStripMenuItem();
      _CameraOnlyMenu = new ToolStripMenuItem();
      _CameraOnlyMenu.Click += new EventHandler(CameraOnlyToolStripMenuItem1_Click);
      _ActorSelectorMenu = new ToolStripMenuItem();
      _ActorSelectorMenu.Click += new EventHandler(ActorSelectorToolStripMenuItem2_Click);
      _CollisionToolStripMenuItem = new ToolStripMenuItem();
      _CollisionToolStripMenuItem.Click += new EventHandler(CollisionToolStripMenuItem_Click);
      CollisionSelectorMenu = new ToolStripMenuItem();
      EdgeToolStripMenuItem = new ToolStripMenuItem();
      TriangleToolStripMenuItem = new ToolStripMenuItem();
      VertexToolStripMenuItem = new ToolStripMenuItem();
      _DisplayListSelectorToolStripMenuItem = new ToolStripMenuItem();
      _DisplayListSelectorToolStripMenuItem.Click += new EventHandler(DisplayListSelectorToolStripMenuItem_Click);
      LockAxesToolStripMenuItem = new ToolStripMenuItem();
      _XToolStripMenuItem = new ToolStripMenuItem();
      _XToolStripMenuItem.Click += new EventHandler(XToolStripMenuItem_Click);
      _YToolStripMenuItem = new ToolStripMenuItem();
      _YToolStripMenuItem.Click += new EventHandler(YToolStripMenuItem_Click);
      _DisableToolStripMenuItem = new ToolStripMenuItem();
      _DisableToolStripMenuItem.Click += new EventHandler(DisableToolStripMenuItem_Click);
      OptionsToolStripMenuItem2 = new ToolStripMenuItem();
      _DisableDepthTestToolStripMenuItem = new ToolStripMenuItem();
      _DisableDepthTestToolStripMenuItem.Click += new EventHandler(DisableDepthTestToolStripMenuItem_Click);
      ToolsToolStripMenuItem = new ToolStripMenuItem();
      _OptionsToolStripMenuItem1 = new ToolStripMenuItem();
      _OptionsToolStripMenuItem1.Click += new EventHandler(OptionsToolStripMenuItem1_Click);
      RendererToolStripMenuItem = new ToolStripMenuItem();
      _TexturesToolStripMenuItem = new ToolStripMenuItem();
      _TexturesToolStripMenuItem.Click += new EventHandler(TexturesToolStripMenuItem_Click);
      _ColorCombinerToolStripMenuItem = new ToolStripMenuItem();
      _ColorCombinerToolStripMenuItem.Click += new EventHandler(ColorCombinerToolStripMenuItem_Click);
      _AnisotropicFilteringToolStripMenuItem = new ToolStripMenuItem();
      _AnisotropicFilteringToolStripMenuItem.Click += new EventHandler(AnisotropicFilteringToolStripMenuItem_Click);
      _FullSceneAntialiasingToolStripMenuItem = new ToolStripMenuItem();
      _FullSceneAntialiasingToolStripMenuItem.Click += new EventHandler(FullSceneAntialiasingToolStripMenuItem_Click);
      HelpToolStripMenuItem1 = new ToolStripMenuItem();
      ContentsToolStripMenuItem = new ToolStripMenuItem();
      _AboutUoTToolStripMenuItem = new ToolStripMenuItem();
      _AboutUoTToolStripMenuItem.Click += new EventHandler(AboutUoTToolStripMenuItem_Click);
      UoTMainMenu = new MenuStrip();
      ToolStripMenuItem3 = new ToolStripMenuItem();
      UndoToolStripMenuItem1 = new ToolStripMenuItem();
      RedoToolStripMenuItem = new ToolStripMenuItem();
      VertContextMenu = new ContextMenuStrip(components);
      ToolStripMenuItem5 = new ToolStripMenuItem();
      ToolStripSeparator15 = new ToolStripSeparator();
      ToolStripMenuItem6 = new ToolStripMenuItem();
      ToolStripMenuItem7 = new ToolStripMenuItem();
      ToolStripMenuItem8 = new ToolStripMenuItem();
      ToolStripMenuItem9 = new ToolStripMenuItem();
      ToolStripMenuItem10 = new ToolStripMenuItem();
      ToolStripMenuItem11 = new ToolStripMenuItem();
      ToolStripMenuItem12 = new ToolStripMenuItem();
      ToolStripMenuItem13 = new ToolStripMenuItem();
      ToolStripMenuItem14 = new ToolStripMenuItem();
      ToolStripMenuItem15 = new ToolStripMenuItem();
      ToolStripMenuItem16 = new ToolStripMenuItem();
      ToolStripMenuItem17 = new ToolStripMenuItem();
      ToolStripMenuItem18 = new ToolStripMenuItem();
      ToolStripMenuItem19 = new ToolStripMenuItem();
      ToolStripSeparator16 = new ToolStripSeparator();
      _ToolStripMenuItem20 = new ToolStripMenuItem();
      _ToolStripMenuItem20.Click += new EventHandler(ToolStripMenuItem20_Click);
      ToolStripMenuItem21 = new ToolStripMenuItem();
      ToolStripMenuItem22 = new ToolStripMenuItem();
      ToolStripMenuItem23 = new ToolStripMenuItem();
      ToolStripMenuItem24 = new ToolStripMenuItem();
      ToolStripMenuItem25 = new ToolStripMenuItem();
      ToolStripMenuItem26 = new ToolStripMenuItem();
      ToolStripMenuItem27 = new ToolStripMenuItem();
      ToolStripMenuItem28 = new ToolStripMenuItem();
      ToolStripMenuItem29 = new ToolStripMenuItem();
      ToolStripMenuItem30 = new ToolStripMenuItem();
      ToolStripMenuItem31 = new ToolStripMenuItem();
      ToolStripMenuItem32 = new ToolStripMenuItem();
      ToolStripMenuItem33 = new ToolStripMenuItem();
      ColorDialog1 = new ColorDialog();
      _RipDL = new SaveFileDialog();
      _RipDL.FileOk += new System.ComponentModel.CancelEventHandler(RipDL_FileOk);
      _SaveROMAs = new SaveFileDialog();
      _SaveROMAs.FileOk += new System.ComponentModel.CancelEventHandler(SaveROMAs_FileOk);
      VarContextMenu = new ContextMenuStrip(components);
      NumContextMenu = new ContextMenuStrip(components);
      GrpContextMenu = new ContextMenuStrip(components);
      UoTStatus.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)_TrackBar4).BeginInit();
      CollisionTab.SuspendLayout();
      GroupBox1.SuspendLayout();
      CollisionGroupBox.SuspendLayout();
      MiscTab.SuspendLayout();
      GroupBox9.SuspendLayout();
      GroupBox10.SuspendLayout();
      GroupBox8.SuspendLayout();
      LevelFlagsTab.SuspendLayout();
      GroupBox6.SuspendLayout();
      ActorsTab.SuspendLayout();
      GroupBox4.SuspendLayout();
      GroupBox5.SuspendLayout();
      EditingTabs.SuspendLayout();
      AnimationsTab.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)_CurrentFrame).BeginInit();
      AnimationSetGroup.SuspendLayout();
      PlaybackGroup.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)_AnimationFPS).BeginInit();
      DLTab.SuspendLayout();
      GroupBox7.SuspendLayout();
      DLEditorContextMenu.SuspendLayout();
      GroupBox3.SuspendLayout();
      BackupMenuStrip.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)_TrackBar1).BeginInit();
      ActorContextMenu.SuspendLayout();
      ROMBrowser.SuspendLayout();
      ROMDataTabs.SuspendLayout();
      UoTMainMenu.SuspendLayout();
      VertContextMenu.SuspendLayout();
      SuspendLayout();
      // 
      // LoadROM
      // 
      _LoadROM.Filter = "N64 ROMs (*.z64, *.v64, *.n64, *.rom)|*.z64;*.v64;*.n64";
      _LoadROM.Title = "Load Ocarina of Time Debug ROM";
      // 
      // UoTStatus
      // 
      UoTStatus.AutoSize = false;
      UoTStatus.Items.AddRange(new ToolStripItem[] { _ToolStatusLabel, CamXLabel, CamYLabel, CamZLabel });
      UoTStatus.Location = new Point(0, 620);
      UoTStatus.Name = "UoTStatus";
      UoTStatus.Size = new Size(1160, 29);
      UoTStatus.TabIndex = 1;
      UoTStatus.Text = "UoTStatusStrip";
      // 
      // ToolStatusLabel
      // 
      _ToolStatusLabel.Font = new Font("Verdana", 9.75f, FontStyle.Underline, GraphicsUnit.Point, Conversions.ToByte(0));
      _ToolStatusLabel.ForeColor = Color.Red;
      _ToolStatusLabel.Name = "_ToolStatusLabel";
      _ToolStatusLabel.Size = new Size(96, 24);
      _ToolStatusLabel.Text = "Tool: Camera";
      // 
      // CamXLabel
      // 
      CamXLabel.Name = "CamXLabel";
      CamXLabel.Size = new Size(41, 24);
      CamXLabel.Text = "Cam X:";
      // 
      // CamYLabel
      // 
      CamYLabel.Name = "CamYLabel";
      CamYLabel.Size = new Size(41, 24);
      CamYLabel.Text = "Cam Y:";
      // 
      // CamZLabel
      // 
      CamZLabel.Name = "CamZLabel";
      CamZLabel.Size = new Size(41, 24);
      CamZLabel.Text = "Cam Z:";
      // 
      // ToolStripStatusLabel5
      // 
      ToolStripStatusLabel5.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;

      ToolStripStatusLabel5.BorderStyle = Border3DStyle.SunkenOuter;
      ToolStripStatusLabel5.Name = "ToolStripStatusLabel5";
      ToolStripStatusLabel5.Size = new Size(29, 22);
      ToolStripStatusLabel5.Text = "FPS";
      // 
      // ToolStripStatusLabel4
      // 
      ToolStripStatusLabel4.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;

      ToolStripStatusLabel4.BorderStyle = Border3DStyle.SunkenOuter;
      ToolStripStatusLabel4.DisplayStyle = ToolStripItemDisplayStyle.Text;
      ToolStripStatusLabel4.Font = new Font("Trebuchet MS", 9.0f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
      ToolStripStatusLabel4.Name = "ToolStripStatusLabel4";
      ToolStripStatusLabel4.Size = new Size(111, 22);
      ToolStripStatusLabel4.Text = "Tool: Camera only";
      // 
      // ToolStripSeparator4
      // 
      ToolStripSeparator4.Name = "ToolStripSeparator4";
      ToolStripSeparator4.Size = new Size(6, 41);
      // 
      // ToolStripSeparator2
      // 
      ToolStripSeparator2.Name = "ToolStripSeparator2";
      ToolStripSeparator2.Size = new Size(6, 41);
      // 
      // ToolStripSeparator1
      // 
      ToolStripSeparator1.Name = "ToolStripSeparator1";
      ToolStripSeparator1.Size = new Size(6, 41);
      // 
      // ToolStripSeparator6
      // 
      ToolStripSeparator6.Alignment = ToolStripItemAlignment.Right;
      ToolStripSeparator6.Name = "ToolStripSeparator6";
      ToolStripSeparator6.RightToLeft = RightToLeft.No;
      ToolStripSeparator6.Size = new Size(6, 41);
      // 
      // ToolStripSeparator5
      // 
      ToolStripSeparator5.Name = "ToolStripSeparator5";
      ToolStripSeparator5.Size = new Size(6, 41);
      // 
      // ToolStripSeparator3
      // 
      ToolStripSeparator3.Alignment = ToolStripItemAlignment.Right;
      ToolStripSeparator3.Name = "ToolStripSeparator3";
      ToolStripSeparator3.RightToLeft = RightToLeft.No;
      ToolStripSeparator3.Size = new Size(6, 41);
      // 
      // Label12
      // 
      Label12.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      Label12.AutoSize = true;
      Label12.BackColor = SystemColors.Control;
      Label12.Font = new Font("Trebuchet MS", 9.0f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
      Label12.Location = new Point(946, 626);
      Label12.Name = "Label12";
      Label12.Size = new Size(95, 18);
      Label12.TabIndex = 39;
      Label12.Text = "Tool Sensitivity:";
      // 
      // TrackBar4
      // 
      _TrackBar4.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      _TrackBar4.AutoSize = false;
      _TrackBar4.Cursor = Cursors.Hand;
      _TrackBar4.LargeChange = 1;
      _TrackBar4.Location = new Point(1047, 627);
      _TrackBar4.Maximum = 15;
      _TrackBar4.Minimum = 1;
      _TrackBar4.Name = "_TrackBar4";
      _TrackBar4.Size = new Size(90, 15);
      _TrackBar4.TabIndex = 99;
      _TrackBar4.Value = 2;
      // 
      // FileToolStripMenuItem
      // 
      FileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { _OpenModelToolStripMenuItem, SaveChangesToolStripMenuItem, ReloadCurrentFileToolStripMenuItem, ImportCSVToolStripMenuItem, ToolStripSeparator10, _QuitToolStripMenuItem });
      FileToolStripMenuItem.Name = "FileToolStripMenuItem";
      FileToolStripMenuItem.Size = new Size(37, 17);
      FileToolStripMenuItem.Text = "File";
      // 
      // OpenModelToolStripMenuItem
      // 
      _OpenModelToolStripMenuItem.Name = "_OpenModelToolStripMenuItem";
      _OpenModelToolStripMenuItem.ShortcutKeyDisplayString = "Alt+O";
      _OpenModelToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
      _OpenModelToolStripMenuItem.Size = new Size(202, 22);
      _OpenModelToolStripMenuItem.Text = "&Open ROM...";
      // 
      // SaveChangesToolStripMenuItem
      // 
      SaveChangesToolStripMenuItem.Name = "SaveChangesToolStripMenuItem";
      SaveChangesToolStripMenuItem.ShortcutKeyDisplayString = "Alt+S";
      SaveChangesToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.S;
      SaveChangesToolStripMenuItem.Size = new Size(202, 22);
      SaveChangesToolStripMenuItem.Text = "&Save";
      // 
      // ReloadCurrentFileToolStripMenuItem
      // 
      ReloadCurrentFileToolStripMenuItem.Name = "ReloadCurrentFileToolStripMenuItem";
      ReloadCurrentFileToolStripMenuItem.Size = new Size(202, 22);
      ReloadCurrentFileToolStripMenuItem.Text = "&Reload current file";
      // 
      // ImportCSVToolStripMenuItem
      // 
      ImportCSVToolStripMenuItem.Name = "ImportCSVToolStripMenuItem";
      ImportCSVToolStripMenuItem.Size = new Size(202, 22);
      ImportCSVToolStripMenuItem.Text = "Convert Wavefront OBJ...";
      // 
      // ToolStripSeparator10
      // 
      ToolStripSeparator10.Name = "ToolStripSeparator10";
      ToolStripSeparator10.Size = new Size(199, 6);
      // 
      // QuitToolStripMenuItem
      // 
      _QuitToolStripMenuItem.Name = "_QuitToolStripMenuItem";
      _QuitToolStripMenuItem.Size = new Size(202, 22);
      _QuitToolStripMenuItem.Text = "E&xit";
      // 
      // EditToolStripMenuItem
      // 
      EditToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ResetSelectedVerticesToolStripMenuItem, ResetAllGraphicsToolStripMenuItem, ResetAllCollisionToolStripMenuItem, ToolStripSeparator11, ResetSelectedActorToolStripMenuItem, _ResetAllActorsToolStripMenuItem, _ResetAllSceneActorsToolStripMenuItem, ToolStripSeparator9, _SelectAllRoomActorsToolStripMenuItem, _SelectAllSceneActorsToolStripMenuItem, SelectAllGraphicsToolStripMenuItem, SelectAllCollisionToolStripMenuItem });
      EditToolStripMenuItem.Name = "EditToolStripMenuItem";
      EditToolStripMenuItem.Size = new Size(40, 17);
      EditToolStripMenuItem.Text = "Edit";
      // 
      // ResetSelectedVerticesToolStripMenuItem
      // 
      ResetSelectedVerticesToolStripMenuItem.Name = "ResetSelectedVerticesToolStripMenuItem";
      ResetSelectedVerticesToolStripMenuItem.ShortcutKeyDisplayString = "V";
      ResetSelectedVerticesToolStripMenuItem.Size = new Size(218, 22);
      ResetSelectedVerticesToolStripMenuItem.Text = "Reset selected vertices";
      // 
      // ResetAllGraphicsToolStripMenuItem
      // 
      ResetAllGraphicsToolStripMenuItem.Name = "ResetAllGraphicsToolStripMenuItem";
      ResetAllGraphicsToolStripMenuItem.ShortcutKeyDisplayString = "";
      ResetAllGraphicsToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.V;
      ResetAllGraphicsToolStripMenuItem.Size = new Size(218, 22);
      ResetAllGraphicsToolStripMenuItem.Text = "Reset all graphics";
      // 
      // ResetAllCollisionToolStripMenuItem
      // 
      ResetAllCollisionToolStripMenuItem.Name = "ResetAllCollisionToolStripMenuItem";
      ResetAllCollisionToolStripMenuItem.ShortcutKeyDisplayString = "";
      ResetAllCollisionToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;
      ResetAllCollisionToolStripMenuItem.Size = new Size(218, 22);
      ResetAllCollisionToolStripMenuItem.Text = "Reset all collision";
      // 
      // ToolStripSeparator11
      // 
      ToolStripSeparator11.Name = "ToolStripSeparator11";
      ToolStripSeparator11.Size = new Size(215, 6);
      // 
      // ResetSelectedActorToolStripMenuItem
      // 
      ResetSelectedActorToolStripMenuItem.Name = "ResetSelectedActorToolStripMenuItem";
      ResetSelectedActorToolStripMenuItem.ShortcutKeyDisplayString = "B";
      ResetSelectedActorToolStripMenuItem.Size = new Size(218, 22);
      ResetSelectedActorToolStripMenuItem.Text = "Reset selected actors";
      // 
      // ResetAllActorsToolStripMenuItem
      // 
      _ResetAllActorsToolStripMenuItem.Name = "_ResetAllActorsToolStripMenuItem";
      _ResetAllActorsToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.B;
      _ResetAllActorsToolStripMenuItem.Size = new Size(218, 22);
      _ResetAllActorsToolStripMenuItem.Text = "Reset all room actors";
      // 
      // ResetAllSceneActorsToolStripMenuItem
      // 
      _ResetAllSceneActorsToolStripMenuItem.Name = "_ResetAllSceneActorsToolStripMenuItem";
      _ResetAllSceneActorsToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
      _ResetAllSceneActorsToolStripMenuItem.Size = new Size(218, 22);
      _ResetAllSceneActorsToolStripMenuItem.Text = "Reset all scene actors";
      // 
      // ToolStripSeparator9
      // 
      ToolStripSeparator9.Name = "ToolStripSeparator9";
      ToolStripSeparator9.Size = new Size(215, 6);
      // 
      // SelectAllRoomActorsToolStripMenuItem
      // 
      _SelectAllRoomActorsToolStripMenuItem.Name = "_SelectAllRoomActorsToolStripMenuItem";
      _SelectAllRoomActorsToolStripMenuItem.ShortcutKeys = Keys.F11;
      _SelectAllRoomActorsToolStripMenuItem.Size = new Size(218, 22);
      _SelectAllRoomActorsToolStripMenuItem.Text = "Select all room actors";
      // 
      // SelectAllSceneActorsToolStripMenuItem
      // 
      _SelectAllSceneActorsToolStripMenuItem.Name = "_SelectAllSceneActorsToolStripMenuItem";
      _SelectAllSceneActorsToolStripMenuItem.ShortcutKeys = Keys.F12;
      _SelectAllSceneActorsToolStripMenuItem.Size = new Size(218, 22);
      _SelectAllSceneActorsToolStripMenuItem.Text = "Select all scene actors";
      // 
      // SelectAllGraphicsToolStripMenuItem
      // 
      SelectAllGraphicsToolStripMenuItem.Name = "SelectAllGraphicsToolStripMenuItem";
      SelectAllGraphicsToolStripMenuItem.Size = new Size(218, 22);
      SelectAllGraphicsToolStripMenuItem.Text = "Select all graphics";
      // 
      // SelectAllCollisionToolStripMenuItem
      // 
      SelectAllCollisionToolStripMenuItem.Name = "SelectAllCollisionToolStripMenuItem";
      SelectAllCollisionToolStripMenuItem.Size = new Size(218, 22);
      SelectAllCollisionToolStripMenuItem.Text = "Select all collision";
      // 
      // OptionsToolStripMenuItem
      // 
      OptionsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { LaunchROMInPJ64ToolStripMenuItem, ZeldaResourceExtractorToolStripMenuItem });
      OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem";
      OptionsToolStripMenuItem.Size = new Size(59, 17);
      OptionsToolStripMenuItem.Text = "Options";
      // 
      // LaunchROMInPJ64ToolStripMenuItem
      // 
      LaunchROMInPJ64ToolStripMenuItem.Name = "LaunchROMInPJ64ToolStripMenuItem";
      LaunchROMInPJ64ToolStripMenuItem.ShortcutKeyDisplayString = "";
      LaunchROMInPJ64ToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.P;
      LaunchROMInPJ64ToolStripMenuItem.Size = new Size(217, 22);
      LaunchROMInPJ64ToolStripMenuItem.Text = "&Launch ROM in &PJ64...";
      // 
      // ZeldaResourceExtractorToolStripMenuItem
      // 
      ZeldaResourceExtractorToolStripMenuItem.Name = "ZeldaResourceExtractorToolStripMenuItem";
      ZeldaResourceExtractorToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.R;
      ZeldaResourceExtractorToolStripMenuItem.Size = new Size(217, 22);
      ZeldaResourceExtractorToolStripMenuItem.Text = "Extract &ROM...";
      // 
      // FeaturesToolStripMenuItem
      // 
      FeaturesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { RenderModeToolStripMenuItem, PrimitiveTypeToolStripMenuItem, ToolStripSeparator8, MouseToolToolStripMenuItem, _SetupToolStripMenuItem });
      FeaturesToolStripMenuItem.Name = "FeaturesToolStripMenuItem";
      FeaturesToolStripMenuItem.Size = new Size(81, 17);
      FeaturesToolStripMenuItem.Text = "Preferences";
      // 
      // RenderModeToolStripMenuItem
      // 
      RenderModeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { _ViewingMeshToolStripMenuItem1, _CollisionMeshToolStripMenuItem });
      RenderModeToolStripMenuItem.Name = "RenderModeToolStripMenuItem";
      RenderModeToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.R;
      RenderModeToolStripMenuItem.Size = new Size(162, 22);
      RenderModeToolStripMenuItem.Text = "&Render";
      // 
      // ViewingMeshToolStripMenuItem1
      // 
      _ViewingMeshToolStripMenuItem1.Checked = true;
      _ViewingMeshToolStripMenuItem1.CheckState = CheckState.Checked;
      _ViewingMeshToolStripMenuItem1.Name = "_ViewingMeshToolStripMenuItem1";
      _ViewingMeshToolStripMenuItem1.Size = new Size(143, 22);
      _ViewingMeshToolStripMenuItem1.Text = "Graphics Mesh";
      // 
      // CollisionMeshToolStripMenuItem
      // 
      _CollisionMeshToolStripMenuItem.Name = "_CollisionMeshToolStripMenuItem";
      _CollisionMeshToolStripMenuItem.Size = new Size(143, 22);
      _CollisionMeshToolStripMenuItem.Text = "Collision Mesh";
      // 
      // PrimitiveTypeToolStripMenuItem
      // 
      PrimitiveTypeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { _FilledToolStripMenuItem, _WireframeToolStripMenuItem });
      PrimitiveTypeToolStripMenuItem.Name = "PrimitiveTypeToolStripMenuItem";
      PrimitiveTypeToolStripMenuItem.ShortcutKeyDisplayString = "F1";
      PrimitiveTypeToolStripMenuItem.Size = new Size(162, 22);
      PrimitiveTypeToolStripMenuItem.Text = "&Primitive Mode";
      // 
      // FilledToolStripMenuItem
      // 
      _FilledToolStripMenuItem.AutoSize = false;
      _FilledToolStripMenuItem.Image = (Image)resources.GetObject("FilledToolStripMenuItem.Image");
      _FilledToolStripMenuItem.Name = "_FilledToolStripMenuItem";
      _FilledToolStripMenuItem.Size = new Size(152, 20);
      _FilledToolStripMenuItem.Text = "&Filled";
      // 
      // WireframeToolStripMenuItem
      // 
      _WireframeToolStripMenuItem.AutoSize = false;
      _WireframeToolStripMenuItem.Image = (Image)resources.GetObject("WireframeToolStripMenuItem.Image");
      _WireframeToolStripMenuItem.Name = "_WireframeToolStripMenuItem";
      _WireframeToolStripMenuItem.Size = new Size(152, 20);
      _WireframeToolStripMenuItem.Text = "&Wireframe";
      // 
      // ToolStripSeparator8
      // 
      ToolStripSeparator8.Name = "ToolStripSeparator8";
      ToolStripSeparator8.Size = new Size(159, 6);
      // 
      // MouseToolToolStripMenuItem
      // 
      MouseToolToolStripMenuItem.Name = "MouseToolToolStripMenuItem";
      MouseToolToolStripMenuItem.Size = new Size(162, 22);
      MouseToolToolStripMenuItem.Text = "&Mouse Tool...";
      // 
      // SetupToolStripMenuItem
      // 
      _SetupToolStripMenuItem.Name = "_SetupToolStripMenuItem";
      _SetupToolStripMenuItem.ShortcutKeyDisplayString = "";
      _SetupToolStripMenuItem.Size = new Size(162, 22);
      _SetupToolStripMenuItem.Text = "&Setup...";
      // 
      // HelpToolStripMenuItem
      // 
      HelpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ControlsInfoToolStripMenuItem, ToolStripSeparator7, AboutToolStripMenuItem, SearchForUpdatesToolStripMenuItem });
      HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
      HelpToolStripMenuItem.Size = new Size(41, 17);
      HelpToolStripMenuItem.Text = "Help";
      // 
      // ControlsInfoToolStripMenuItem
      // 
      ControlsInfoToolStripMenuItem.Name = "ControlsInfoToolStripMenuItem";
      ControlsInfoToolStripMenuItem.ShortcutKeyDisplayString = "";
      ControlsInfoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.H;
      ControlsInfoToolStripMenuItem.Size = new Size(217, 22);
      ControlsInfoToolStripMenuItem.Text = "&Controls";
      // 
      // ToolStripSeparator7
      // 
      ToolStripSeparator7.Name = "ToolStripSeparator7";
      ToolStripSeparator7.Size = new Size(214, 6);
      // 
      // AboutToolStripMenuItem
      // 
      AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
      AboutToolStripMenuItem.ShortcutKeyDisplayString = "";
      AboutToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Q;
      AboutToolStripMenuItem.Size = new Size(217, 22);
      AboutToolStripMenuItem.Text = "A&bout Utility of Time";
      // 
      // SearchForUpdatesToolStripMenuItem
      // 
      SearchForUpdatesToolStripMenuItem.Name = "SearchForUpdatesToolStripMenuItem";
      SearchForUpdatesToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.U;
      SearchForUpdatesToolStripMenuItem.Size = new Size(217, 22);
      SearchForUpdatesToolStripMenuItem.Text = "Search for updates...";
      // 
      // ActorInputTimer
      // 
      _ActorInputTimer.Interval = 1;
      // 
      // CollisionTab
      // 
      CollisionTab.Controls.Add(GroupBox1);
      CollisionTab.Controls.Add(CollisionGroupBox);
      CollisionTab.Location = new Point(4, 55);
      CollisionTab.Name = "CollisionTab";
      CollisionTab.Padding = new Padding(3);
      CollisionTab.Size = new Size(224, 528);
      CollisionTab.TabIndex = 4;
      CollisionTab.Text = "Collision";
      CollisionTab.UseVisualStyleBackColor = true;
      // 
      // GroupBox1
      // 
      GroupBox1.Controls.Add(_Button9);
      GroupBox1.Controls.Add(TriTypeText);
      GroupBox1.Controls.Add(Label48);
      GroupBox1.Controls.Add(Label47);
      GroupBox1.Controls.Add(_ColTriangleBox);
      GroupBox1.Location = new Point(3, 9);
      GroupBox1.Name = "GroupBox1";
      GroupBox1.Size = new Size(218, 112);
      GroupBox1.TabIndex = 93;
      GroupBox1.TabStop = false;
      GroupBox1.Text = "Triangles";
      // 
      // Button9
      // 
      _Button9.Location = new Point(155, 83);
      _Button9.Name = "_Button9";
      _Button9.Size = new Size(56, 23);
      _Button9.TabIndex = 4;
      _Button9.Text = "Apply";
      _Button9.UseVisualStyleBackColor = true;
      // 
      // TriTypeText
      // 
      TriTypeText.Location = new Point(138, 46);
      TriTypeText.Name = "TriTypeText";
      TriTypeText.Size = new Size(56, 20);
      TriTypeText.TabIndex = 3;
      // 
      // Label48
      // 
      Label48.AutoSize = true;
      Label48.Location = new Point(9, 25);
      Label48.Name = "Label48";
      Label48.Size = new Size(36, 16);
      Label48.TabIndex = 2;
      Label48.Text = "Index";
      // 
      // Label47
      // 
      Label47.AutoSize = true;
      Label47.Location = new Point(135, 25);
      Label47.Name = "Label47";
      Label47.Size = new Size(32, 16);
      Label47.TabIndex = 1;
      Label47.Text = "Type";
      // 
      // ColTriangleBox
      // 
      _ColTriangleBox.DropDownStyle = ComboBoxStyle.DropDownList;
      _ColTriangleBox.FormattingEnabled = true;
      _ColTriangleBox.Location = new Point(11, 44);
      _ColTriangleBox.Name = "_ColTriangleBox";
      _ColTriangleBox.Size = new Size(100, 24);
      _ColTriangleBox.TabIndex = 0;
      // 
      // CollisionGroupBox
      // 
      CollisionGroupBox.Controls.Add(Label36);
      CollisionGroupBox.Controls.Add(ColWalkSound);
      CollisionGroupBox.Controls.Add(Label38);
      CollisionGroupBox.Controls.Add(Label37);
      CollisionGroupBox.Controls.Add(Label35);
      CollisionGroupBox.Controls.Add(Label33);
      CollisionGroupBox.Controls.Add(Label32);
      CollisionGroupBox.Controls.Add(Label23);
      CollisionGroupBox.Controls.Add(Label13);
      CollisionGroupBox.Controls.Add(Label1);
      CollisionGroupBox.Controls.Add(ColVar4);
      CollisionGroupBox.Controls.Add(_ApplyCollisionButton);
      CollisionGroupBox.Controls.Add(ColVar2);
      CollisionGroupBox.Controls.Add(ColVar3);
      CollisionGroupBox.Controls.Add(ColVar1);
      CollisionGroupBox.Controls.Add(CollisionPresetButton);
      CollisionGroupBox.Controls.Add(Label34);
      CollisionGroupBox.Controls.Add(ColTypeText);
      CollisionGroupBox.Controls.Add(_ColTypeBox);
      CollisionGroupBox.Controls.Add(Label31);
      CollisionGroupBox.Controls.Add(ExitTextBox);
      CollisionGroupBox.Controls.Add(_ExitCombobox);
      CollisionGroupBox.Controls.Add(Label10);
      CollisionGroupBox.FlatStyle = FlatStyle.Popup;
      CollisionGroupBox.Location = new Point(3, 124);
      CollisionGroupBox.Name = "CollisionGroupBox";
      CollisionGroupBox.Size = new Size(218, 342);
      CollisionGroupBox.TabIndex = 86;
      CollisionGroupBox.TabStop = false;
      CollisionGroupBox.Text = "Types";
      // 
      // Label36
      // 
      Label36.AutoSize = true;
      Label36.Location = new Point(115, 135);
      Label36.Name = "Label36";
      Label36.Size = new Size(20, 16);
      Label36.TabIndex = 107;
      Label36.Text = "0x";
      // 
      // ColWalkSound
      // 
      ColWalkSound.AutoCompleteMode = AutoCompleteMode.Suggest;
      ColWalkSound.AutoCompleteSource = AutoCompleteSource.CustomSource;
      ColWalkSound.CharacterCasing = CharacterCasing.Upper;
      ColWalkSound.Location = new Point(138, 128);
      ColWalkSound.MaxLength = 1;
      ColWalkSound.Name = "ColWalkSound";
      ColWalkSound.Size = new Size(55, 20);
      ColWalkSound.TabIndex = 105;
      // 
      // Label38
      // 
      Label38.AutoSize = true;
      Label38.Location = new Point(121, 109);
      Label38.Name = "Label38";
      Label38.Size = new Size(91, 16);
      Label38.TabIndex = 106;
      Label38.Text = "Walked on sound";
      // 
      // Label37
      // 
      Label37.AutoSize = true;
      Label37.Location = new Point(9, 263);
      Label37.Name = "Label37";
      Label37.Size = new Size(20, 16);
      Label37.TabIndex = 104;
      Label37.Text = "0x";
      // 
      // Label35
      // 
      Label35.AutoSize = true;
      Label35.Location = new Point(9, 221);
      Label35.Name = "Label35";
      Label35.Size = new Size(20, 16);
      Label35.TabIndex = 103;
      Label35.Text = "0x";
      // 
      // Label33
      // 
      Label33.AutoSize = true;
      Label33.Location = new Point(9, 179);
      Label33.Name = "Label33";
      Label33.Size = new Size(20, 16);
      Label33.TabIndex = 102;
      Label33.Text = "0x";
      // 
      // Label32
      // 
      Label32.AutoSize = true;
      Label32.Location = new Point(9, 135);
      Label32.Name = "Label32";
      Label32.Size = new Size(20, 16);
      Label32.TabIndex = 101;
      Label32.Text = "0x";
      // 
      // Label23
      // 
      Label23.AutoSize = true;
      Label23.Location = new Point(27, 198);
      Label23.Name = "Label23";
      Label23.Size = new Size(42, 16);
      Label23.TabIndex = 100;
      Label23.Text = "Flags 3";
      // 
      // Label13
      // 
      Label13.AutoSize = true;
      Label13.Location = new Point(27, 240);
      Label13.Name = "Label13";
      Label13.Size = new Size(42, 16);
      Label13.TabIndex = 99;
      Label13.Text = "Flags 4";
      // 
      // Label1
      // 
      Label1.AutoSize = true;
      Label1.Location = new Point(26, 156);
      Label1.Name = "Label1";
      Label1.Size = new Size(42, 16);
      Label1.TabIndex = 98;
      Label1.Text = "Flags 2";
      // 
      // ColVar4
      // 
      ColVar4.AutoCompleteMode = AutoCompleteMode.Suggest;
      ColVar4.AutoCompleteSource = AutoCompleteSource.CustomSource;
      ColVar4.CharacterCasing = CharacterCasing.Upper;
      ColVar4.Location = new Point(30, 256);
      ColVar4.MaxLength = 4;
      ColVar4.Name = "ColVar4";
      ColVar4.Size = new Size(55, 20);
      ColVar4.TabIndex = 17;
      // 
      // ApplyCollisionButton
      // 
      _ApplyCollisionButton.BackColor = SystemColors.Control;
      _ApplyCollisionButton.Location = new Point(155, 313);
      _ApplyCollisionButton.Name = "_ApplyCollisionButton";
      _ApplyCollisionButton.Size = new Size(56, 23);
      _ApplyCollisionButton.TabIndex = 18;
      _ApplyCollisionButton.Text = "Apply";
      _ApplyCollisionButton.UseVisualStyleBackColor = true;
      // 
      // ColVar2
      // 
      ColVar2.AutoCompleteMode = AutoCompleteMode.Suggest;
      ColVar2.AutoCompleteSource = AutoCompleteSource.CustomSource;
      ColVar2.CharacterCasing = CharacterCasing.Upper;
      ColVar2.Location = new Point(29, 172);
      ColVar2.MaxLength = 4;
      ColVar2.Name = "ColVar2";
      ColVar2.Size = new Size(56, 20);
      ColVar2.TabIndex = 16;
      // 
      // ColVar3
      // 
      ColVar3.AutoCompleteMode = AutoCompleteMode.Suggest;
      ColVar3.AutoCompleteSource = AutoCompleteSource.CustomSource;
      ColVar3.CharacterCasing = CharacterCasing.Upper;
      ColVar3.Location = new Point(30, 214);
      ColVar3.MaxLength = 4;
      ColVar3.Name = "ColVar3";
      ColVar3.Size = new Size(55, 20);
      ColVar3.TabIndex = 15;
      // 
      // ColVar1
      // 
      ColVar1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      ColVar1.AutoCompleteSource = AutoCompleteSource.CustomSource;
      ColVar1.CharacterCasing = CharacterCasing.Upper;
      ColVar1.Location = new Point(30, 128);
      ColVar1.MaxLength = 4;
      ColVar1.Name = "ColVar1";
      ColVar1.Size = new Size(55, 20);
      ColVar1.TabIndex = 14;
      // 
      // CollisionPresetButton
      // 
      CollisionPresetButton.BackColor = SystemColors.Control;
      CollisionPresetButton.Location = new Point(13, 297);
      CollisionPresetButton.Name = "CollisionPresetButton";
      CollisionPresetButton.Size = new Size(101, 23);
      CollisionPresetButton.TabIndex = 13;
      CollisionPresetButton.Text = "Preset Database";
      CollisionPresetButton.UseVisualStyleBackColor = false;
      // 
      // Label34
      // 
      Label34.AutoSize = true;
      Label34.Location = new Point(27, 112);
      Label34.Name = "Label34";
      Label34.Size = new Size(42, 16);
      Label34.TabIndex = 97;
      Label34.Text = "Flags 1";
      // 
      // ColTypeText
      // 
      ColTypeText.CharacterCasing = CharacterCasing.Upper;
      ColTypeText.Location = new Point(138, 78);
      ColTypeText.MaxLength = 4;
      ColTypeText.Name = "ColTypeText";
      ColTypeText.ReadOnly = true;
      ColTypeText.Size = new Size(55, 20);
      ColTypeText.TabIndex = 91;
      // 
      // ColTypeBox
      // 
      _ColTypeBox.DropDownStyle = ComboBoxStyle.DropDownList;
      _ColTypeBox.FormattingEnabled = true;
      _ColTypeBox.Location = new Point(11, 78);
      _ColTypeBox.Name = "_ColTypeBox";
      _ColTypeBox.Size = new Size(102, 24);
      _ColTypeBox.TabIndex = 12;
      // 
      // Label31
      // 
      Label31.AutoSize = true;
      Label31.Location = new Point(8, 62);
      Label31.Name = "Label31";
      Label31.Size = new Size(54, 16);
      Label31.TabIndex = 87;
      Label31.Text = "Variables";
      // 
      // ExitTextBox
      // 
      ExitTextBox.CharacterCasing = CharacterCasing.Upper;
      ExitTextBox.Location = new Point(138, 38);
      ExitTextBox.MaxLength = 4;
      ExitTextBox.Name = "ExitTextBox";
      ExitTextBox.Size = new Size(55, 20);
      ExitTextBox.TabIndex = 11;
      // 
      // ExitCombobox
      // 
      _ExitCombobox.DropDownStyle = ComboBoxStyle.DropDownList;
      _ExitCombobox.FormattingEnabled = true;
      _ExitCombobox.Location = new Point(11, 38);
      _ExitCombobox.Name = "_ExitCombobox";
      _ExitCombobox.Size = new Size(102, 24);
      _ExitCombobox.TabIndex = 10;
      // 
      // Label10
      // 
      Label10.AutoSize = true;
      Label10.Location = new Point(8, 20);
      Label10.Name = "Label10";
      Label10.Size = new Size(33, 16);
      Label10.TabIndex = 83;
      Label10.Text = "Exits";
      // 
      // MiscTab
      // 
      MiscTab.Controls.Add(GroupBox9);
      MiscTab.Controls.Add(Label45);
      MiscTab.Controls.Add(AnimStart);
      MiscTab.Controls.Add(Label30);
      MiscTab.Controls.Add(LimbStart);
      MiscTab.Controls.Add(GroupBox10);
      MiscTab.Controls.Add(GroupBox8);
      MiscTab.Location = new Point(4, 55);
      MiscTab.Name = "MiscTab";
      MiscTab.Size = new Size(224, 528);
      MiscTab.TabIndex = 3;
      MiscTab.Text = "Miscellaneous";
      MiscTab.UseVisualStyleBackColor = true;
      // 
      // GroupBox9
      // 
      GroupBox9.Controls.Add(ProgressBar1);
      GroupBox9.Controls.Add(Label28);
      GroupBox9.Controls.Add(Button16);
      GroupBox9.Controls.Add(Button15);
      GroupBox9.Location = new Point(28, 120);
      GroupBox9.Name = "GroupBox9";
      GroupBox9.Size = new Size(173, 100);
      GroupBox9.TabIndex = 97;
      GroupBox9.TabStop = false;
      GroupBox9.Text = "Collision Matcher";
      // 
      // ProgressBar1
      // 
      ProgressBar1.Location = new Point(12, 77);
      ProgressBar1.Name = "ProgressBar1";
      ProgressBar1.Size = new Size(150, 10);
      ProgressBar1.Style = ProgressBarStyle.Continuous;
      ProgressBar1.TabIndex = 92;
      // 
      // Label28
      // 
      Label28.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      Label28.AutoSize = true;
      Label28.BackColor = SystemColors.Control;
      Label28.Location = new Point(119, 0);
      Label28.Name = "Label28";
      Label28.Size = new Size(50, 16);
      Label28.TabIndex = 89;
      Label28.Text = "Working";
      Label28.Visible = false;
      // 
      // Button16
      // 
      Button16.Location = new Point(12, 23);
      Button16.Name = "Button16";
      Button16.Size = new Size(150, 23);
      Button16.TabIndex = 91;
      Button16.Text = "Match collision to graphics";
      Button16.UseVisualStyleBackColor = true;
      // 
      // Button15
      // 
      Button15.Location = new Point(12, 46);
      Button15.Name = "Button15";
      Button15.Size = new Size(150, 23);
      Button15.TabIndex = 90;
      Button15.Text = "Match graphics to collision";
      Button15.UseVisualStyleBackColor = true;
      // 
      // Label45
      // 
      Label45.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      Label45.AutoSize = true;
      Label45.Location = new Point(12, 412);
      Label45.Name = "Label45";
      Label45.Size = new Size(71, 16);
      Label45.TabIndex = 94;
      Label45.Text = "Animation at";
      Label45.Visible = false;
      // 
      // AnimStart
      // 
      AnimStart.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      AnimStart.Location = new Point(14, 429);
      AnimStart.Name = "AnimStart";
      AnimStart.Size = new Size(100, 20);
      AnimStart.TabIndex = 93;
      AnimStart.Visible = false;
      // 
      // Label30
      // 
      Label30.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      Label30.AutoSize = true;
      Label30.Location = new Point(12, 370);
      Label30.Name = "Label30";
      Label30.Size = new Size(72, 16);
      Label30.TabIndex = 92;
      Label30.Text = "Heirarchy at";
      Label30.Visible = false;
      // 
      // LimbStart
      // 
      LimbStart.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      LimbStart.Location = new Point(13, 389);
      LimbStart.Name = "LimbStart";
      LimbStart.Size = new Size(100, 20);
      LimbStart.TabIndex = 91;
      LimbStart.Visible = false;
      // 
      // GroupBox10
      // 
      GroupBox10.Controls.Add(_CheckBox5);
      GroupBox10.Controls.Add(_CheckBox15);
      GroupBox10.Controls.Add(_CheckBox14);
      GroupBox10.Controls.Add(_CheckBox13);
      GroupBox10.Location = new Point(28, 9);
      GroupBox10.Name = "GroupBox10";
      GroupBox10.Size = new Size(173, 105);
      GroupBox10.TabIndex = 90;
      GroupBox10.TabStop = false;
      GroupBox10.Text = "Hide";
      // 
      // CheckBox5
      // 
      _CheckBox5.AutoSize = true;
      _CheckBox5.Location = new Point(12, 59);
      _CheckBox5.Name = "_CheckBox5";
      _CheckBox5.Size = new Size(111, 20);
      _CheckBox5.TabIndex = 3;
      _CheckBox5.Text = "Link actor cubes";
      _CheckBox5.UseVisualStyleBackColor = true;
      // 
      // CheckBox15
      // 
      _CheckBox15.AutoSize = true;
      _CheckBox15.Location = new Point(12, 77);
      _CheckBox15.Name = "_CheckBox15";
      _CheckBox15.Size = new Size(82, 20);
      _CheckBox15.TabIndex = 2;
      _CheckBox15.Text = "Axis guides";
      _CheckBox15.UseVisualStyleBackColor = true;
      // 
      // CheckBox14
      // 
      _CheckBox14.AutoSize = true;
      _CheckBox14.Location = new Point(12, 40);
      _CheckBox14.Name = "_CheckBox14";
      _CheckBox14.Size = new Size(119, 20);
      _CheckBox14.TabIndex = 1;
      _CheckBox14.Text = "Scene actor cubes";
      _CheckBox14.UseVisualStyleBackColor = true;
      // 
      // CheckBox13
      // 
      _CheckBox13.AutoSize = true;
      _CheckBox13.Location = new Point(12, 22);
      _CheckBox13.Name = "_CheckBox13";
      _CheckBox13.Size = new Size(116, 20);
      _CheckBox13.TabIndex = 0;
      _CheckBox13.Text = "Room actor cubes";
      _CheckBox13.UseVisualStyleBackColor = true;
      // 
      // GroupBox8
      // 
      GroupBox8.Controls.Add(_MapsCombobox);
      GroupBox8.Controls.Add(Label46);
      GroupBox8.Location = new Point(28, 227);
      GroupBox8.Name = "GroupBox8";
      GroupBox8.Size = new Size(173, 85);
      GroupBox8.TabIndex = 98;
      GroupBox8.TabStop = false;
      GroupBox8.Text = "Individual level";
      // 
      // MapsCombobox
      // 
      _MapsCombobox.DropDownStyle = ComboBoxStyle.DropDownList;
      _MapsCombobox.FormattingEnabled = true;
      _MapsCombobox.Location = new Point(12, 43);
      _MapsCombobox.Name = "_MapsCombobox";
      _MapsCombobox.Size = new Size(150, 24);
      _MapsCombobox.TabIndex = 95;
      // 
      // Label46
      // 
      Label46.AutoSize = true;
      Label46.Location = new Point(9, 24);
      Label46.Name = "Label46";
      Label46.Size = new Size(93, 16);
      Label46.TabIndex = 96;
      Label46.Text = "Referenced maps";
      // 
      // LevelFlagsTab
      // 
      LevelFlagsTab.BackColor = Color.Transparent;
      LevelFlagsTab.Controls.Add(GroupBox6);
      LevelFlagsTab.Location = new Point(4, 55);
      LevelFlagsTab.Name = "LevelFlagsTab";
      LevelFlagsTab.Size = new Size(224, 528);
      LevelFlagsTab.TabIndex = 2;
      LevelFlagsTab.Text = "Level Flags";
      LevelFlagsTab.UseVisualStyleBackColor = true;
      // 
      // GroupBox6
      // 
      GroupBox6.Controls.Add(ComboBox6);
      GroupBox6.Controls.Add(Label2);
      GroupBox6.Controls.Add(Button11);
      GroupBox6.Controls.Add(TextBox13);
      GroupBox6.Controls.Add(Label21);
      GroupBox6.Location = new Point(3, 9);
      GroupBox6.Name = "GroupBox6";
      GroupBox6.Size = new Size(218, 74);
      GroupBox6.TabIndex = 77;
      GroupBox6.TabStop = false;
      GroupBox6.Text = "Ambience";
      // 
      // ComboBox6
      // 
      ComboBox6.DropDownStyle = ComboBoxStyle.DropDownList;
      ComboBox6.FormattingEnabled = true;
      ComboBox6.Items.AddRange(new object[] { "No Change", "Morning", "Mid Day", "Night" });
      ComboBox6.Location = new Point(10, 36);
      ComboBox6.Name = "ComboBox6";
      ComboBox6.Size = new Size(82, 24);
      ComboBox6.TabIndex = 7;
      // 
      // Label2
      // 
      Label2.AutoSize = true;
      Label2.Location = new Point(7, 20);
      Label2.Name = "Label2";
      Label2.Size = new Size(69, 16);
      Label2.TabIndex = 65;
      Label2.Text = "Time of day:";
      // 
      // Button11
      // 
      Button11.BackColor = SystemColors.Control;
      Button11.FlatStyle = FlatStyle.System;
      Button11.Location = new Point(137, 37);
      Button11.Name = "Button11";
      Button11.Size = new Size(23, 23);
      Button11.TabIndex = 9;
      Button11.Text = "?";
      Button11.UseVisualStyleBackColor = true;
      // 
      // TextBox13
      // 
      TextBox13.BorderStyle = BorderStyle.FixedSingle;
      TextBox13.CharacterCasing = CharacterCasing.Upper;
      TextBox13.Location = new Point(96, 38);
      TextBox13.MaxLength = 2;
      TextBox13.Name = "TextBox13";
      TextBox13.Size = new Size(35, 20);
      TextBox13.TabIndex = 8;
      // 
      // Label21
      // 
      Label21.AutoSize = true;
      Label21.Location = new Point(93, 21);
      Label21.Name = "Label21";
      Label21.Size = new Size(40, 16);
      Label21.TabIndex = 74;
      Label21.Text = "Music:";
      // 
      // ActorsTab
      // 
      ActorsTab.BackColor = Color.Transparent;
      ActorsTab.Controls.Add(_Button2);
      ActorsTab.Controls.Add(GroupBox4);
      ActorsTab.Controls.Add(GroupBox5);
      ActorsTab.Location = new Point(4, 55);
      ActorsTab.Name = "ActorsTab";
      ActorsTab.Padding = new Padding(3);
      ActorsTab.Size = new Size(224, 528);
      ActorsTab.TabIndex = 1;
      ActorsTab.Text = "Actors";
      ActorsTab.UseVisualStyleBackColor = true;
      // 
      // Button2
      // 
      _Button2.BackColor = SystemColors.Control;
      _Button2.Location = new Point(129, 378);
      _Button2.Name = "_Button2";
      _Button2.Size = new Size(85, 23);
      _Button2.TabIndex = 14;
      _Button2.Text = "Apply";
      _Button2.UseVisualStyleBackColor = true;
      // 
      // GroupBox4
      // 
      GroupBox4.Controls.Add(Label14);
      GroupBox4.Controls.Add(Label17);
      GroupBox4.Controls.Add(_TextBox9);
      GroupBox4.Controls.Add(Label18);
      GroupBox4.Controls.Add(_TextBox8);
      GroupBox4.Controls.Add(Label19);
      GroupBox4.Controls.Add(_TextBox7);
      GroupBox4.Controls.Add(_TextBox10);
      GroupBox4.Controls.Add(Label16);
      GroupBox4.Controls.Add(_TextBox11);
      GroupBox4.Controls.Add(Label15);
      GroupBox4.Controls.Add(_TextBox12);
      GroupBox4.Location = new Point(3, 230);
      GroupBox4.Name = "GroupBox4";
      GroupBox4.Size = new Size(218, 142);
      GroupBox4.TabIndex = 72;
      GroupBox4.TabStop = false;
      GroupBox4.Text = "Position";
      // 
      // Label14
      // 
      Label14.AutoSize = true;
      Label14.Location = new Point(20, 19);
      Label14.Name = "Label14";
      Label14.Size = new Size(70, 16);
      Label14.TabIndex = 59;
      Label14.Text = "Actor X Pos.";
      // 
      // Label17
      // 
      Label17.AutoSize = true;
      Label17.Location = new Point(112, 19);
      Label17.Name = "Label17";
      Label17.Size = new Size(70, 16);
      Label17.TabIndex = 66;
      Label17.Text = "Actor X Rot.";
      // 
      // TextBox9
      // 
      _TextBox9.BorderStyle = BorderStyle.FixedSingle;
      _TextBox9.Location = new Point(23, 113);
      _TextBox9.Name = "_TextBox9";
      _TextBox9.Size = new Size(84, 20);
      _TextBox9.TabIndex = 10;
      // 
      // Label18
      // 
      Label18.AutoSize = true;
      Label18.Location = new Point(112, 58);
      Label18.Name = "Label18";
      Label18.Size = new Size(70, 16);
      Label18.TabIndex = 67;
      Label18.Text = "Actor Y Rot.";
      // 
      // TextBox8
      // 
      _TextBox8.BorderStyle = BorderStyle.FixedSingle;
      _TextBox8.Location = new Point(23, 74);
      _TextBox8.Name = "_TextBox8";
      _TextBox8.Size = new Size(84, 20);
      _TextBox8.TabIndex = 9;
      // 
      // Label19
      // 
      Label19.AutoSize = true;
      Label19.Location = new Point(112, 97);
      Label19.Name = "Label19";
      Label19.Size = new Size(69, 16);
      Label19.TabIndex = 68;
      Label19.Text = "Actor Z Rot.";
      // 
      // TextBox7
      // 
      _TextBox7.BorderStyle = BorderStyle.FixedSingle;
      _TextBox7.Location = new Point(23, 35);
      _TextBox7.Name = "_TextBox7";
      _TextBox7.Size = new Size(84, 20);
      _TextBox7.TabIndex = 8;
      // 
      // TextBox10
      // 
      _TextBox10.BorderStyle = BorderStyle.FixedSingle;
      _TextBox10.Location = new Point(115, 35);
      _TextBox10.Name = "_TextBox10";
      _TextBox10.Size = new Size(83, 20);
      _TextBox10.TabIndex = 11;
      // 
      // Label16
      // 
      Label16.AutoSize = true;
      Label16.Location = new Point(20, 97);
      Label16.Name = "Label16";
      Label16.Size = new Size(69, 16);
      Label16.TabIndex = 61;
      Label16.Text = "Actor Z Pos.";
      // 
      // TextBox11
      // 
      _TextBox11.BorderStyle = BorderStyle.FixedSingle;
      _TextBox11.Location = new Point(115, 74);
      _TextBox11.Name = "_TextBox11";
      _TextBox11.Size = new Size(83, 20);
      _TextBox11.TabIndex = 12;
      // 
      // Label15
      // 
      Label15.AutoSize = true;
      Label15.Location = new Point(20, 58);
      Label15.Name = "Label15";
      Label15.Size = new Size(70, 16);
      Label15.TabIndex = 60;
      Label15.Text = "Actor Y Pos.";
      // 
      // TextBox12
      // 
      _TextBox12.BorderStyle = BorderStyle.FixedSingle;
      _TextBox12.Location = new Point(115, 113);
      _TextBox12.Name = "_TextBox12";
      _TextBox12.Size = new Size(83, 20);
      _TextBox12.TabIndex = 13;
      // 
      // GroupBox5
      // 
      GroupBox5.Controls.Add(_Button6);
      GroupBox5.Controls.Add(_SceneActorCombobox);
      GroupBox5.Controls.Add(ActorNumberText);
      GroupBox5.Controls.Add(Label7);
      GroupBox5.Controls.Add(ActorVarText);
      GroupBox5.Controls.Add(Label8);
      GroupBox5.Controls.Add(Label6);
      GroupBox5.Controls.Add(_ActorGroupText);
      GroupBox5.Controls.Add(Label22);
      GroupBox5.Controls.Add(_RoomActorCombobox);
      GroupBox5.Controls.Add(Label24);
      GroupBox5.Location = new Point(3, 9);
      GroupBox5.Name = "GroupBox5";
      GroupBox5.Size = new Size(218, 215);
      GroupBox5.TabIndex = 73;
      GroupBox5.TabStop = false;
      GroupBox5.Text = "Actors";
      // 
      // Button6
      // 
      _Button6.BackColor = SystemColors.Control;
      _Button6.Location = new Point(123, 178);
      _Button6.Name = "_Button6";
      _Button6.Size = new Size(75, 23);
      _Button6.TabIndex = 54;
      _Button6.Text = "Database";
      _Button6.UseVisualStyleBackColor = false;
      // 
      // SceneActorCombobox
      // 
      _SceneActorCombobox.DropDownStyle = ComboBoxStyle.DropDownList;
      _SceneActorCombobox.FormattingEnabled = true;
      _SceneActorCombobox.Location = new Point(19, 79);
      _SceneActorCombobox.Name = "_SceneActorCombobox";
      _SceneActorCombobox.Size = new Size(180, 24);
      _SceneActorCombobox.TabIndex = 1;
      // 
      // ActorNumberText
      // 
      ActorNumberText.BorderStyle = BorderStyle.FixedSingle;
      ActorNumberText.CharacterCasing = CharacterCasing.Upper;
      ActorNumberText.Location = new Point(20, 128);
      ActorNumberText.MaxLength = 4;
      ActorNumberText.Name = "ActorNumberText";
      ActorNumberText.Size = new Size(83, 20);
      ActorNumberText.TabIndex = 2;
      // 
      // Label7
      // 
      Label7.AutoSize = true;
      Label7.Location = new Point(17, 160);
      Label7.Name = "Label7";
      Label7.Size = new Size(86, 16);
      Label7.TabIndex = 39;
      Label7.Text = "Models (groups)";
      // 
      // ActorVarText
      // 
      ActorVarText.BorderStyle = BorderStyle.FixedSingle;
      ActorVarText.CharacterCasing = CharacterCasing.Upper;
      ActorVarText.Location = new Point(113, 128);
      ActorVarText.MaxLength = 4;
      ActorVarText.Name = "ActorVarText";
      ActorVarText.Size = new Size(85, 20);
      ActorVarText.TabIndex = 3;
      // 
      // Label8
      // 
      Label8.AutoSize = true;
      Label8.Location = new Point(17, 110);
      Label8.Name = "Label8";
      Label8.Size = new Size(46, 16);
      Label8.TabIndex = 33;
      Label8.Text = "Number";
      // 
      // Label6
      // 
      Label6.AutoSize = true;
      Label6.Location = new Point(111, 111);
      Label6.Name = "Label6";
      Label6.Size = new Size(49, 16);
      Label6.TabIndex = 34;
      Label6.Text = "Variable";
      // 
      // ActorGroupText
      // 
      _ActorGroupText.BorderStyle = BorderStyle.FixedSingle;
      _ActorGroupText.CharacterCasing = CharacterCasing.Upper;
      _ActorGroupText.Location = new Point(20, 179);
      _ActorGroupText.MaxLength = 4;
      _ActorGroupText.Name = "_ActorGroupText";
      _ActorGroupText.Size = new Size(83, 20);
      _ActorGroupText.TabIndex = 5;
      _ActorGroupText.Text = "0001";
      // 
      // Label22
      // 
      Label22.AutoSize = true;
      Label22.Location = new Point(16, 18);
      Label22.Name = "Label22";
      Label22.Size = new Size(70, 16);
      Label22.TabIndex = 52;
      Label22.Text = "Room Actors";
      // 
      // RoomActorCombobox
      // 
      _RoomActorCombobox.DropDownStyle = ComboBoxStyle.DropDownList;
      _RoomActorCombobox.FormattingEnabled = true;
      _RoomActorCombobox.Location = new Point(19, 34);
      _RoomActorCombobox.Name = "_RoomActorCombobox";
      _RoomActorCombobox.Size = new Size(180, 24);
      _RoomActorCombobox.TabIndex = 0;
      // 
      // Label24
      // 
      Label24.AutoSize = true;
      Label24.Location = new Point(17, 62);
      Label24.Name = "Label24";
      Label24.Size = new Size(73, 16);
      Label24.TabIndex = 53;
      Label24.Text = "Scene Actors";
      // 
      // EditingTabs
      // 
      EditingTabs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
      EditingTabs.Appearance = TabAppearance.Buttons;
      EditingTabs.Controls.Add(ActorsTab);
      EditingTabs.Controls.Add(LevelFlagsTab);
      EditingTabs.Controls.Add(CollisionTab);
      EditingTabs.Controls.Add(MiscTab);
      EditingTabs.Controls.Add(AnimationsTab);
      EditingTabs.Controls.Add(DLTab);
      EditingTabs.Font = new Font("Trebuchet MS", 8.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
      EditingTabs.HotTrack = true;
      EditingTabs.Location = new Point(930, 33);
      EditingTabs.Multiline = true;
      EditingTabs.Name = "EditingTabs";
      EditingTabs.SelectedIndex = 0;
      EditingTabs.Size = new Size(232, 587);
      EditingTabs.SizeMode = TabSizeMode.FillToRight;
      EditingTabs.TabIndex = 3;
      // 
      // AnimationsTab
      // 
      AnimationsTab.Controls.Add(Label5);
      AnimationsTab.Controls.Add(_CurrentFrame);
      AnimationsTab.Controls.Add(AnimationSetGroup);
      AnimationsTab.Controls.Add(PlaybackGroup);
      AnimationsTab.Location = new Point(4, 55);
      AnimationsTab.Name = "AnimationsTab";
      AnimationsTab.Size = new Size(224, 528);
      AnimationsTab.TabIndex = 7;
      AnimationsTab.Text = "Animations";
      AnimationsTab.UseVisualStyleBackColor = true;
      // 
      // Label5
      // 
      Label5.Anchor = AnchorStyles.Bottom;
      Label5.AutoSize = true;
      Label5.Location = new Point(19, 319);
      Label5.Name = "Label5";
      Label5.Size = new Size(42, 16);
      Label5.TabIndex = 6;
      Label5.Text = "Tracks";
      // 
      // CurrentFrame
      // 
      _CurrentFrame.Anchor = AnchorStyles.Bottom;
      _CurrentFrame.AutoSize = false;
      _CurrentFrame.LargeChange = 2;
      _CurrentFrame.Location = new Point(15, 337);
      _CurrentFrame.Minimum = 1;
      _CurrentFrame.Name = "_CurrentFrame";
      _CurrentFrame.Size = new Size(197, 30);
      _CurrentFrame.TabIndex = 5;
      _CurrentFrame.Value = 1;
      // 
      // AnimationSetGroup
      // 
      AnimationSetGroup.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      AnimationSetGroup.Controls.Add(Label20);
      AnimationSetGroup.Controls.Add(_CheckBox2);
      AnimationSetGroup.Controls.Add(_AnimationList);
      AnimationSetGroup.Controls.Add(_animationbank);
      AnimationSetGroup.Location = new Point(10, 4);
      AnimationSetGroup.Name = "AnimationSetGroup";
      AnimationSetGroup.Size = new Size(206, 276);
      AnimationSetGroup.TabIndex = 13;
      AnimationSetGroup.TabStop = false;
      AnimationSetGroup.Text = "Animation Sets";
      // 
      // Label20
      // 
      Label20.AutoSize = true;
      Label20.Location = new Point(3, 29);
      Label20.Name = "Label20";
      Label20.Size = new Size(32, 16);
      Label20.TabIndex = 10;
      Label20.Text = "Bank";
      // 
      // CheckBox2
      // 
      _CheckBox2.Anchor = AnchorStyles.Bottom;
      _CheckBox2.AutoSize = true;
      _CheckBox2.Location = new Point(6, 248);
      _CheckBox2.Name = "_CheckBox2";
      _CheckBox2.Size = new Size(56, 20);
      _CheckBox2.TabIndex = 4;
      _CheckBox2.Text = "Bones";
      _CheckBox2.UseVisualStyleBackColor = true;
      // 
      // AnimationList
      // 
      _AnimationList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      _AnimationList.FormattingEnabled = true;
      _AnimationList.ItemHeight = 16;
      _AnimationList.Location = new Point(6, 58);
      _AnimationList.Name = "_AnimationList";
      _AnimationList.Size = new Size(192, 180);
      _AnimationList.TabIndex = 0;
      // 
      // animationbank
      // 
      _animationbank.DropDownStyle = ComboBoxStyle.DropDownList;
      _animationbank.FormattingEnabled = true;
      _animationbank.Items.AddRange(new object[] { "Inline with object" });
      _animationbank.Location = new Point(47, 25);
      _animationbank.Name = "_animationbank";
      _animationbank.Size = new Size(151, 24);
      _animationbank.TabIndex = 9;
      // 
      // PlaybackGroup
      // 
      PlaybackGroup.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      PlaybackGroup.Controls.Add(_AnimationFPS);
      PlaybackGroup.Controls.Add(Label27);
      PlaybackGroup.Controls.Add(FrameNo);
      PlaybackGroup.Controls.Add(AnimationElapse);
      PlaybackGroup.Controls.Add(_CheckBox1);
      PlaybackGroup.Controls.Add(_Button5);
      PlaybackGroup.Controls.Add(_Button3);
      PlaybackGroup.Location = new Point(10, 286);
      PlaybackGroup.Name = "PlaybackGroup";
      PlaybackGroup.Size = new Size(206, 232);
      PlaybackGroup.TabIndex = 14;
      PlaybackGroup.TabStop = false;
      PlaybackGroup.Text = "Playback";
      // 
      // AnimationFPS
      // 
      _AnimationFPS.Anchor = AnchorStyles.Bottom;
      _AnimationFPS.Font = new Font("Trebuchet MS", 8.25f, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
      _AnimationFPS.Location = new Point(128, 131);
      _AnimationFPS.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
      _AnimationFPS.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
      _AnimationFPS.Name = "_AnimationFPS";
      _AnimationFPS.Size = new Size(40, 20);
      _AnimationFPS.TabIndex = 11;
      _AnimationFPS.Value = new decimal(new int[] { 30, 0, 0, 0 });
      // 
      // Label27
      // 
      Label27.Anchor = AnchorStyles.Bottom;
      Label27.AutoSize = true;
      Label27.Location = new Point(173, 133);
      Label27.Name = "Label27";
      Label27.Size = new Size(25, 16);
      Label27.TabIndex = 12;
      Label27.Text = "FPS";
      // 
      // FrameNo
      // 
      FrameNo.Anchor = AnchorStyles.Bottom;
      FrameNo.AutoSize = true;
      FrameNo.Location = new Point(160, 90);
      FrameNo.Name = "FrameNo";
      FrameNo.Size = new Size(38, 16);
      FrameNo.TabIndex = 8;
      FrameNo.Text = "00/00";
      // 
      // AnimationElapse
      // 
      AnimationElapse.Anchor = AnchorStyles.Bottom;
      AnimationElapse.AutoSize = true;
      AnimationElapse.Location = new Point(9, 90);
      AnimationElapse.Name = "AnimationElapse";
      AnimationElapse.Size = new Size(41, 16);
      AnimationElapse.TabIndex = 7;
      AnimationElapse.Text = "00:00s";
      // 
      // CheckBox1
      // 
      _CheckBox1.Anchor = AnchorStyles.Bottom;
      _CheckBox1.Image = My.Resources.Resources.Button_Refresh_icon;
      _CheckBox1.ImageAlign = ContentAlignment.MiddleRight;
      _CheckBox1.Location = new Point(126, 31);
      _CheckBox1.Name = "_CheckBox1";
      _CheckBox1.Size = new Size(69, 20);
      _CheckBox1.TabIndex = 3;
      _CheckBox1.Text = "Loop";
      _CheckBox1.UseVisualStyleBackColor = true;
      // 
      // Button5
      // 
      _Button5.Anchor = AnchorStyles.Bottom;
      _Button5.Image = My.Resources.Resources.Button_Stop_icon;
      _Button5.ImageAlign = ContentAlignment.MiddleRight;
      _Button5.Location = new Point(69, 123);
      _Button5.Name = "_Button5";
      _Button5.Size = new Size(53, 36);
      _Button5.TabIndex = 2;
      _Button5.Text = "Stop";
      _Button5.TextAlign = ContentAlignment.MiddleLeft;
      _Button5.UseVisualStyleBackColor = true;
      // 
      // Button3
      // 
      _Button3.Anchor = AnchorStyles.Bottom;
      _Button3.Image = My.Resources.Resources.Button_Play_icon;
      _Button3.ImageAlign = ContentAlignment.MiddleRight;
      _Button3.Location = new Point(12, 123);
      _Button3.Name = "_Button3";
      _Button3.Size = new Size(51, 36);
      _Button3.TabIndex = 1;
      _Button3.Text = "Play";
      _Button3.TextAlign = ContentAlignment.MiddleLeft;
      _Button3.UseVisualStyleBackColor = true;
      // 
      // DLTab
      // 
      DLTab.Controls.Add(_RadioButton2);
      DLTab.Controls.Add(GroupBox7);
      DLTab.Controls.Add(_DListSelection);
      DLTab.Controls.Add(_RadioButton1);
      DLTab.Controls.Add(GroupBox3);
      DLTab.Location = new Point(4, 55);
      DLTab.Name = "DLTab";
      DLTab.Size = new Size(224, 528);
      DLTab.TabIndex = 8;
      DLTab.Text = "Graphics";
      DLTab.UseVisualStyleBackColor = true;
      // 
      // RadioButton2
      // 
      _RadioButton2.AutoSize = true;
      _RadioButton2.Location = new Point(18, 85);
      _RadioButton2.Name = "_RadioButton2";
      _RadioButton2.Size = new Size(84, 20);
      _RadioButton2.TabIndex = 67;
      _RadioButton2.TabStop = true;
      _RadioButton2.Text = "Hide others";
      _RadioButton2.UseVisualStyleBackColor = true;
      // 
      // GroupBox7
      // 
      GroupBox7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      GroupBox7.Controls.Add(_WholeCommandTxt);
      GroupBox7.Controls.Add(Label3);
      GroupBox7.Controls.Add(_Button8);
      GroupBox7.Controls.Add(_HiwordText);
      GroupBox7.Controls.Add(_Button1);
      GroupBox7.Controls.Add(_LowordText);
      GroupBox7.Controls.Add(_CommandCodeText);
      GroupBox7.Controls.Add(CommandJumpBox);
      GroupBox7.Controls.Add(Label26);
      GroupBox7.Controls.Add(Label25);
      GroupBox7.Controls.Add(Label9);
      GroupBox7.Controls.Add(_Button4);
      GroupBox7.Controls.Add(_CommandsListbox);
      GroupBox7.Location = new Point(10, 176);
      GroupBox7.Name = "GroupBox7";
      GroupBox7.Size = new Size(206, 343);
      GroupBox7.TabIndex = 69;
      GroupBox7.TabStop = false;
      GroupBox7.Text = "Commands";
      // 
      // WholeCommandTxt
      // 
      _WholeCommandTxt.Anchor = AnchorStyles.Bottom;
      _WholeCommandTxt.CharacterCasing = CharacterCasing.Upper;
      _WholeCommandTxt.Location = new Point(7, 306);
      _WholeCommandTxt.MaxLength = 32;
      _WholeCommandTxt.Name = "_WholeCommandTxt";
      _WholeCommandTxt.Size = new Size(107, 20);
      _WholeCommandTxt.TabIndex = 71;
      // 
      // Label3
      // 
      Label3.Anchor = AnchorStyles.Bottom;
      Label3.AutoSize = true;
      Label3.Location = new Point(3, 223);
      Label3.Name = "Label3";
      Label3.Size = new Size(47, 16);
      Label3.TabIndex = 69;
      Label3.Text = "Jump to";
      // 
      // Button8
      // 
      _Button8.Anchor = AnchorStyles.Bottom;
      _Button8.Location = new Point(57, 219);
      _Button8.Name = "_Button8";
      _Button8.Size = new Size(67, 23);
      _Button8.TabIndex = 68;
      _Button8.Text = "Previous";
      _Button8.UseVisualStyleBackColor = true;
      // 
      // HiwordText
      // 
      _HiwordText.Anchor = AnchorStyles.Bottom;
      _HiwordText.CharacterCasing = CharacterCasing.Upper;
      _HiwordText.Location = new Point(109, 278);
      _HiwordText.MaxLength = 8;
      _HiwordText.Name = "_HiwordText";
      _HiwordText.Size = new Size(90, 20);
      _HiwordText.TabIndex = 65;
      // 
      // Button1
      // 
      _Button1.Anchor = AnchorStyles.Bottom;
      _Button1.Location = new Point(130, 219);
      _Button1.Name = "_Button1";
      _Button1.Size = new Size(67, 23);
      _Button1.TabIndex = 67;
      _Button1.Text = "Next";
      _Button1.UseVisualStyleBackColor = true;
      // 
      // LowordText
      // 
      _LowordText.Anchor = AnchorStyles.Bottom;
      _LowordText.CharacterCasing = CharacterCasing.Upper;
      _LowordText.Location = new Point(37, 278);
      _LowordText.MaxLength = 6;
      _LowordText.Name = "_LowordText";
      _LowordText.Size = new Size(66, 20);
      _LowordText.TabIndex = 64;
      // 
      // CommandCodeText
      // 
      _CommandCodeText.Anchor = AnchorStyles.Bottom;
      _CommandCodeText.CharacterCasing = CharacterCasing.Upper;
      _CommandCodeText.Location = new Point(7, 278);
      _CommandCodeText.MaxLength = 2;
      _CommandCodeText.Name = "_CommandCodeText";
      _CommandCodeText.Size = new Size(24, 20);
      _CommandCodeText.TabIndex = 63;
      // 
      // CommandJumpBox
      // 
      CommandJumpBox.Anchor = AnchorStyles.Bottom;
      CommandJumpBox.DropDownStyle = ComboBoxStyle.DropDownList;
      CommandJumpBox.FormattingEnabled = true;
      CommandJumpBox.Location = new Point(6, 189);
      CommandJumpBox.Name = "CommandJumpBox";
      CommandJumpBox.Size = new Size(192, 24);
      CommandJumpBox.TabIndex = 66;
      // 
      // Label26
      // 
      Label26.Anchor = AnchorStyles.Bottom;
      Label26.AutoSize = true;
      Label26.Location = new Point(132, 259);
      Label26.Name = "Label26";
      Label26.Size = new Size(45, 16);
      Label26.TabIndex = 65;
      Label26.Text = "Param1";
      // 
      // Label25
      // 
      Label25.Anchor = AnchorStyles.Bottom;
      Label25.AutoSize = true;
      Label25.Location = new Point(48, 259);
      Label25.Name = "Label25";
      Label25.Size = new Size(45, 16);
      Label25.TabIndex = 64;
      Label25.Text = "Param0";
      // 
      // Label9
      // 
      Label9.Anchor = AnchorStyles.Bottom;
      Label9.AutoSize = true;
      Label9.Location = new Point(5, 259);
      Label9.Name = "Label9";
      Label9.Size = new Size(29, 16);
      Label9.TabIndex = 63;
      Label9.Text = "Cmd";
      // 
      // Button4
      // 
      _Button4.Anchor = AnchorStyles.Bottom;
      _Button4.Location = new Point(127, 304);
      _Button4.Name = "_Button4";
      _Button4.Size = new Size(70, 23);
      _Button4.TabIndex = 62;
      _Button4.Text = "Set";
      _Button4.UseVisualStyleBackColor = true;
      // 
      // CommandsListbox
      // 
      _CommandsListbox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      _CommandsListbox.ContextMenuStrip = DLEditorContextMenu;
      _CommandsListbox.FormattingEnabled = true;
      _CommandsListbox.ItemHeight = 16;
      _CommandsListbox.Location = new Point(6, 22);
      _CommandsListbox.Name = "_CommandsListbox";
      _CommandsListbox.Size = new Size(192, 148);
      _CommandsListbox.TabIndex = 61;
      // 
      // DLEditorContextMenu
      // 
      DLEditorContextMenu.Items.AddRange(new ToolStripItem[] { Copy, Paste, Reset });
      DLEditorContextMenu.Name = "DLEditorContextMenu";
      DLEditorContextMenu.Size = new Size(103, 70);
      // 
      // Copy
      // 
      Copy.Name = "Copy";
      Copy.Size = new Size(102, 22);
      Copy.Text = "Copy";
      // 
      // Paste
      // 
      Paste.Name = "Paste";
      Paste.Size = new Size(102, 22);
      Paste.Text = "Paste";
      Paste.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // Reset
      // 
      Reset.Name = "Reset";
      Reset.Size = new Size(102, 22);
      Reset.Text = "Reset";
      // 
      // DListSelection
      // 
      _DListSelection.DropDownStyle = ComboBoxStyle.DropDownList;
      _DListSelection.FormattingEnabled = true;
      _DListSelection.Location = new Point(18, 29);
      _DListSelection.Name = "_DListSelection";
      _DListSelection.Size = new Size(192, 24);
      _DListSelection.TabIndex = 58;
      // 
      // RadioButton1
      // 
      _RadioButton1.AutoSize = true;
      _RadioButton1.Checked = true;
      _RadioButton1.Location = new Point(18, 59);
      _RadioButton1.Name = "_RadioButton1";
      _RadioButton1.Size = new Size(132, 20);
      _RadioButton1.TabIndex = 66;
      _RadioButton1.TabStop = true;
      _RadioButton1.Text = "Highlight and draw all";
      _RadioButton1.UseVisualStyleBackColor = true;
      // 
      // GroupBox3
      // 
      GroupBox3.Controls.Add(_Button12);
      GroupBox3.Controls.Add(Label4);
      GroupBox3.Controls.Add(_Button10);
      GroupBox3.Location = new Point(10, 4);
      GroupBox3.Name = "GroupBox3";
      GroupBox3.Size = new Size(206, 166);
      GroupBox3.TabIndex = 68;
      GroupBox3.TabStop = false;
      GroupBox3.Text = "Display Lists";
      // 
      // Button12
      // 
      _Button12.Location = new Point(85, 130);
      _Button12.Name = "_Button12";
      _Button12.Size = new Size(66, 23);
      _Button12.TabIndex = 2;
      _Button12.Text = "All ";
      _Button12.UseVisualStyleBackColor = true;
      // 
      // Label4
      // 
      Label4.AutoSize = true;
      Label4.Location = new Point(8, 111);
      Label4.Name = "Label4";
      Label4.Size = new Size(83, 16);
      Label4.TabIndex = 1;
      Label4.Text = "Dump raw data";
      // 
      // Button10
      // 
      _Button10.Location = new Point(9, 130);
      _Button10.Name = "_Button10";
      _Button10.Size = new Size(68, 23);
      _Button10.TabIndex = 0;
      _Button10.Text = "Selected";
      _Button10.UseVisualStyleBackColor = true;
      // 
      // BackupMenuStrip
      // 
      BackupMenuStrip.Items.AddRange(new ToolStripItem[] { RestorToolStripMenuItem });
      BackupMenuStrip.Name = "BackupMenuStrip";
      BackupMenuStrip.Size = new Size(175, 26);
      // 
      // RestorToolStripMenuItem
      // 
      RestorToolStripMenuItem.Name = "RestorToolStripMenuItem";
      RestorToolStripMenuItem.Size = new Size(174, 22);
      RestorToolStripMenuItem.Text = "Restore from backup";
      // 
      // Label43
      // 
      Label43.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      Label43.AutoSize = true;
      Label43.Font = new Font("Trebuchet MS", 9.0f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
      Label43.Location = new Point(763, 626);
      Label43.Name = "Label43";
      Label43.Size = new Size(89, 18);
      Label43.TabIndex = 102;
      Label43.Text = "Camera speed:";
      // 
      // TrackBar1
      // 
      _TrackBar1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      _TrackBar1.AutoSize = false;
      _TrackBar1.Cursor = Cursors.Hand;
      _TrackBar1.Location = new Point(850, 628);
      _TrackBar1.Maximum = 40;
      _TrackBar1.Minimum = 1;
      _TrackBar1.Name = "_TrackBar1";
      _TrackBar1.Size = new Size(90, 15);
      _TrackBar1.TabIndex = 103;
      _TrackBar1.Value = 20;
      // 
      // UoTRender
      // 
      _UoTRender.AccumBits = Conversions.ToByte(0);
      _UoTRender.AllowDrop = true;
      _UoTRender.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

      _UoTRender.AutoCheckErrors = false;
      _UoTRender.AutoFinish = true;
      _UoTRender.AutoMakeCurrent = true;
      _UoTRender.AutoSize = true;
      _UoTRender.AutoSwapBuffers = false;
      _UoTRender.AutoValidate = AutoValidate.EnablePreventFocusChange;
      _UoTRender.BackColor = Color.Black;
      _UoTRender.BackgroundImageLayout = ImageLayout.Stretch;
      _UoTRender.BorderStyle = BorderStyle.Fixed3D;
      _UoTRender.ColorBits = Conversions.ToByte(32);
      _UoTRender.Cursor = Cursors.Default;
      _UoTRender.DepthBits = Conversions.ToByte(24);
      _UoTRender.Location = new Point(229, 33);
      _UoTRender.Name = "_UoTRender";
      _UoTRender.Size = new Size(700, 586);
      _UoTRender.StencilBits = Conversions.ToByte(0);
      _UoTRender.TabIndex = 0;
      // 
      // ActorContextMenu
      // 
      ActorContextMenu.BackColor = SystemColors.Control;
      ActorContextMenu.Items.AddRange(new ToolStripItem[] { _DeselectToolStripMenuItem, ToolStripSeparator14, EditToolStripMenuItem2, AlignToolItem, ToolStripSeparator13, _CopyToolStripMenuItem, PasteToolStripMenuItem, _ClearClipboardToolStripMenuItem });
      ActorContextMenu.Name = "ContextMenuStrip4";
      ActorContextMenu.RenderMode = ToolStripRenderMode.Professional;
      ActorContextMenu.Size = new Size(152, 148);
      // 
      // DeselectToolStripMenuItem
      // 
      _DeselectToolStripMenuItem.Name = "_DeselectToolStripMenuItem";
      _DeselectToolStripMenuItem.Size = new Size(151, 22);
      _DeselectToolStripMenuItem.Text = "Deselect";
      // 
      // ToolStripSeparator14
      // 
      ToolStripSeparator14.Name = "ToolStripSeparator14";
      ToolStripSeparator14.Size = new Size(148, 6);
      // 
      // EditToolStripMenuItem2
      // 
      EditToolStripMenuItem2.DropDownItems.AddRange(new ToolStripItem[] { CamXRotationToolStripMenuItem, CamYRotationToolStripMenuItem, CamZRotationToolStripMenuItem });
      EditToolStripMenuItem2.Name = "EditToolStripMenuItem2";
      EditToolStripMenuItem2.Size = new Size(151, 22);
      EditToolStripMenuItem2.Text = "Rotate";
      // 
      // CamXRotationToolStripMenuItem
      // 
      CamXRotationToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { _DegreesToolStripMenuItem, _DegreesToolStripMenuItem1 });
      CamXRotationToolStripMenuItem.Name = "CamXRotationToolStripMenuItem";
      CamXRotationToolStripMenuItem.Size = new Size(80, 22);
      CamXRotationToolStripMenuItem.Text = "X";
      // 
      // DegreesToolStripMenuItem
      // 
      _DegreesToolStripMenuItem.Name = "_DegreesToolStripMenuItem";
      _DegreesToolStripMenuItem.Size = new Size(139, 22);
      _DegreesToolStripMenuItem.Text = "+ 90 degrees";
      // 
      // DegreesToolStripMenuItem1
      // 
      _DegreesToolStripMenuItem1.Name = "_DegreesToolStripMenuItem1";
      _DegreesToolStripMenuItem1.Size = new Size(139, 22);
      _DegreesToolStripMenuItem1.Text = "- 90 degrees";
      // 
      // CamYRotationToolStripMenuItem
      // 
      CamYRotationToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { _DegreesToolStripMenuItem2, _DegreesToolStripMenuItem3 });
      CamYRotationToolStripMenuItem.Name = "CamYRotationToolStripMenuItem";
      CamYRotationToolStripMenuItem.Size = new Size(80, 22);
      CamYRotationToolStripMenuItem.Text = "Y";
      // 
      // DegreesToolStripMenuItem2
      // 
      _DegreesToolStripMenuItem2.Name = "_DegreesToolStripMenuItem2";
      _DegreesToolStripMenuItem2.Size = new Size(142, 22);
      _DegreesToolStripMenuItem2.Text = " + 90 degrees";
      // 
      // DegreesToolStripMenuItem3
      // 
      _DegreesToolStripMenuItem3.Name = "_DegreesToolStripMenuItem3";
      _DegreesToolStripMenuItem3.Size = new Size(142, 22);
      _DegreesToolStripMenuItem3.Text = "- 90 degrees";
      // 
      // CamZRotationToolStripMenuItem
      // 
      CamZRotationToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { _DegreesToolStripMenuItem4, _DegreesToolStripMenuItem5 });
      CamZRotationToolStripMenuItem.Name = "CamZRotationToolStripMenuItem";
      CamZRotationToolStripMenuItem.Size = new Size(80, 22);
      CamZRotationToolStripMenuItem.Text = "Z";
      // 
      // DegreesToolStripMenuItem4
      // 
      _DegreesToolStripMenuItem4.Name = "_DegreesToolStripMenuItem4";
      _DegreesToolStripMenuItem4.Size = new Size(139, 22);
      _DegreesToolStripMenuItem4.Text = "+ 90 degrees";
      // 
      // DegreesToolStripMenuItem5
      // 
      _DegreesToolStripMenuItem5.Name = "_DegreesToolStripMenuItem5";
      _DegreesToolStripMenuItem5.Size = new Size(139, 22);
      _DegreesToolStripMenuItem5.Text = "- 90 degrees";
      // 
      // AlignToolItem
      // 
      AlignToolItem.DropDownItems.AddRange(new ToolStripItem[] { _XToolStripMenuItem3, _YToolStripMenuItem3, _ZToolStripMenuItem2 });
      AlignToolItem.Name = "AlignToolItem";
      AlignToolItem.Size = new Size(151, 22);
      AlignToolItem.Text = "Align";
      // 
      // XToolStripMenuItem3
      // 
      _XToolStripMenuItem3.Name = "_XToolStripMenuItem3";
      _XToolStripMenuItem3.Size = new Size(80, 22);
      _XToolStripMenuItem3.Text = "X";
      // 
      // YToolStripMenuItem3
      // 
      _YToolStripMenuItem3.Name = "_YToolStripMenuItem3";
      _YToolStripMenuItem3.Size = new Size(80, 22);
      _YToolStripMenuItem3.Text = "Y";
      // 
      // ZToolStripMenuItem2
      // 
      _ZToolStripMenuItem2.Name = "_ZToolStripMenuItem2";
      _ZToolStripMenuItem2.Size = new Size(80, 22);
      _ZToolStripMenuItem2.Text = "Z";
      // 
      // ToolStripSeparator13
      // 
      ToolStripSeparator13.Name = "ToolStripSeparator13";
      ToolStripSeparator13.Size = new Size(148, 6);
      // 
      // CopyToolStripMenuItem
      // 
      _CopyToolStripMenuItem.Name = "_CopyToolStripMenuItem";
      _CopyToolStripMenuItem.Size = new Size(151, 22);
      _CopyToolStripMenuItem.Text = "Copy attributes";
      // 
      // PasteToolStripMenuItem
      // 
      PasteToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { PositionToolStripMenuItem, RotationToolStripMenuItem, _NumberAndVariableToolStripMenuItem });
      PasteToolStripMenuItem.Enabled = false;
      PasteToolStripMenuItem.Name = "PasteToolStripMenuItem";
      PasteToolStripMenuItem.Size = new Size(151, 22);
      PasteToolStripMenuItem.Text = "Paste attributes";
      // 
      // PositionToolStripMenuItem
      // 
      PositionToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { _XToolStripMenuItem1, _YToolStripMenuItem1, _ZToolStripMenuItem, _AllToolStripMenuItem1 });
      PositionToolStripMenuItem.Name = "PositionToolStripMenuItem";
      PositionToolStripMenuItem.Size = new Size(173, 22);
      PositionToolStripMenuItem.Text = "Position";
      // 
      // XToolStripMenuItem1
      // 
      _XToolStripMenuItem1.Name = "_XToolStripMenuItem1";
      _XToolStripMenuItem1.Size = new Size(85, 22);
      _XToolStripMenuItem1.Text = "X";
      // 
      // YToolStripMenuItem1
      // 
      _YToolStripMenuItem1.Name = "_YToolStripMenuItem1";
      _YToolStripMenuItem1.Size = new Size(85, 22);
      _YToolStripMenuItem1.Text = "Y";
      // 
      // ZToolStripMenuItem
      // 
      _ZToolStripMenuItem.Name = "_ZToolStripMenuItem";
      _ZToolStripMenuItem.Size = new Size(85, 22);
      _ZToolStripMenuItem.Text = "Z";
      // 
      // AllToolStripMenuItem1
      // 
      _AllToolStripMenuItem1.Name = "_AllToolStripMenuItem1";
      _AllToolStripMenuItem1.Size = new Size(85, 22);
      _AllToolStripMenuItem1.Text = "All";
      // 
      // RotationToolStripMenuItem
      // 
      RotationToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { _XToolStripMenuItem2, _YToolStripMenuItem2, _ZToolStripMenuItem1, _AllToolStripMenuItem });
      RotationToolStripMenuItem.Name = "RotationToolStripMenuItem";
      RotationToolStripMenuItem.Size = new Size(173, 22);
      RotationToolStripMenuItem.Text = "Rotation";
      // 
      // XToolStripMenuItem2
      // 
      _XToolStripMenuItem2.Name = "_XToolStripMenuItem2";
      _XToolStripMenuItem2.Size = new Size(85, 22);
      _XToolStripMenuItem2.Text = "X";
      // 
      // YToolStripMenuItem2
      // 
      _YToolStripMenuItem2.Name = "_YToolStripMenuItem2";
      _YToolStripMenuItem2.Size = new Size(85, 22);
      _YToolStripMenuItem2.Text = "Y";
      // 
      // ZToolStripMenuItem1
      // 
      _ZToolStripMenuItem1.Name = "_ZToolStripMenuItem1";
      _ZToolStripMenuItem1.Size = new Size(85, 22);
      _ZToolStripMenuItem1.Text = "Z";
      // 
      // AllToolStripMenuItem
      // 
      _AllToolStripMenuItem.Name = "_AllToolStripMenuItem";
      _AllToolStripMenuItem.Size = new Size(85, 22);
      _AllToolStripMenuItem.Text = "All";
      // 
      // NumberAndVariableToolStripMenuItem
      // 
      _NumberAndVariableToolStripMenuItem.Name = "_NumberAndVariableToolStripMenuItem";
      _NumberAndVariableToolStripMenuItem.Size = new Size(173, 22);
      _NumberAndVariableToolStripMenuItem.Text = "Number and Variable";
      // 
      // ClearClipboardToolStripMenuItem
      // 
      _ClearClipboardToolStripMenuItem.Enabled = false;
      _ClearClipboardToolStripMenuItem.Name = "_ClearClipboardToolStripMenuItem";
      _ClearClipboardToolStripMenuItem.Size = new Size(151, 22);
      _ClearClipboardToolStripMenuItem.Text = "Clear clipboard";
      // 
      // RotationTimer
      // 
      _RotationTimer.Interval = 1;
      // 
      // LoadIndividual
      // 
      _LoadIndividual.Filter = "Levels (*.scene)|*.zscene|ZOBJ Files (*.zobj)|*.zobj";
      // 
      // ROMBrowser
      // 
      ROMBrowser.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      ROMBrowser.Appearance = TabAppearance.Buttons;
      ROMBrowser.Controls.Add(ROMDataTabs);
      ROMBrowser.Controls.Add(IndividualFiles);
      ROMBrowser.HotTrack = true;
      ROMBrowser.Location = new Point(0, 33);
      ROMBrowser.Name = "ROMBrowser";
      ROMBrowser.SelectedIndex = 0;
      ROMBrowser.Size = new Size(227, 587);
      ROMBrowser.TabIndex = 104;
      // 
      // ROMDataTabs
      // 
      ROMDataTabs.Controls.Add(_Button7);
      ROMDataTabs.Location = new Point(4, 25);
      ROMDataTabs.Name = "ROMDataTabs";
      ROMDataTabs.Padding = new Padding(3);
      ROMDataTabs.Size = new Size(219, 558);
      ROMDataTabs.TabIndex = 0;
      ROMDataTabs.Text = "ROM Files";
      ROMDataTabs.UseVisualStyleBackColor = true;
      // 
      // Button7
      // 
      _Button7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      _Button7.Location = new Point(153, 526);
      _Button7.Name = "_Button7";
      _Button7.Size = new Size(60, 23);
      _Button7.TabIndex = 0;
      _Button7.Text = "Search";
      _Button7.UseVisualStyleBackColor = true;
      // 
      // IndividualFiles
      // 
      IndividualFiles.Location = new Point(4, 25);
      IndividualFiles.Name = "IndividualFiles";
      IndividualFiles.Size = new Size(219, 558);
      IndividualFiles.TabIndex = 1;
      IndividualFiles.Text = "Individuals";
      IndividualFiles.UseVisualStyleBackColor = true;
      // 
      // Label29
      // 
      Label29.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      Label29.AutoSize = true;
      Label29.Location = new Point(7, 567);
      Label29.Name = "Label29";
      Label29.Size = new Size(27, 13);
      Label29.TabIndex = 13;
      Label29.Text = "Find";
      // 
      // TreeFind
      // 
      TreeFind.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      TreeFind.Location = new Point(10, 586);
      TreeFind.Name = "TreeFind";
      TreeFind.Size = new Size(141, 20);
      TreeFind.TabIndex = 12;
      // 
      // FileTree
      // 
      _FileTree.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      _FileTree.ContextMenuStrip = BackupMenuStrip;
      _FileTree.HideSelection = false;
      _FileTree.HotTracking = true;
      _FileTree.Location = new Point(7, 62);
      _FileTree.Name = "_FileTree";
      _FileTree.Size = new Size(210, 496);
      _FileTree.TabIndex = 10;
      // 
      // FileToolStripMenuItem1
      // 
      FileToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { _ToolStripMenuItem35, _ToolStripMenuItem2, _CustomLevel, toolStripSeparator, _SaveToolStripMenuItem, _ToolStripMenuItem34, toolStripSeparator12, _ExitToolStripMenuItem });
      FileToolStripMenuItem1.Name = "FileToolStripMenuItem1";
      FileToolStripMenuItem1.Size = new Size(37, 27);
      FileToolStripMenuItem1.Text = "&File";
      // 
      // ToolStripMenuItem35
      // 
      _ToolStripMenuItem35.Image = (Image)resources.GetObject("ToolStripMenuItem35.Image");
      _ToolStripMenuItem35.ImageTransparentColor = Color.Magenta;
      _ToolStripMenuItem35.Name = "_ToolStripMenuItem35";
      _ToolStripMenuItem35.Size = new Size(153, 22);
      _ToolStripMenuItem35.Text = "&Open ROM";
      // 
      // ToolStripMenuItem2
      // 
      _ToolStripMenuItem2.Image = (Image)resources.GetObject("ToolStripMenuItem2.Image");
      _ToolStripMenuItem2.ImageTransparentColor = Color.Magenta;
      _ToolStripMenuItem2.Name = "_ToolStripMenuItem2";
      _ToolStripMenuItem2.Size = new Size(153, 22);
      _ToolStripMenuItem2.Text = "&Open Individual";
      // 
      // CustomLevel
      // 
      _CustomLevel.Name = "_CustomLevel";
      _CustomLevel.Size = new Size(153, 22);
      _CustomLevel.Text = "New level...";
      _CustomLevel.Visible = false;
      // 
      // toolStripSeparator
      // 
      toolStripSeparator.Name = "toolStripSeparator";
      toolStripSeparator.Size = new Size(150, 6);
      // 
      // SaveToolStripMenuItem
      // 
      _SaveToolStripMenuItem.Image = (Image)resources.GetObject("SaveToolStripMenuItem.Image");
      _SaveToolStripMenuItem.ImageTransparentColor = Color.Magenta;
      _SaveToolStripMenuItem.Name = "_SaveToolStripMenuItem";
      _SaveToolStripMenuItem.ShowShortcutKeys = false;
      _SaveToolStripMenuItem.Size = new Size(153, 22);
      _SaveToolStripMenuItem.Text = "&Save ROM";
      // 
      // ToolStripMenuItem34
      // 
      _ToolStripMenuItem34.Name = "_ToolStripMenuItem34";
      _ToolStripMenuItem34.Size = new Size(153, 22);
      _ToolStripMenuItem34.Text = "Save ROM &As";
      _ToolStripMenuItem34.Visible = false;
      // 
      // toolStripSeparator12
      // 
      toolStripSeparator12.Name = "toolStripSeparator12";
      toolStripSeparator12.Size = new Size(150, 6);
      // 
      // ExitToolStripMenuItem
      // 
      _ExitToolStripMenuItem.Name = "_ExitToolStripMenuItem";
      _ExitToolStripMenuItem.Size = new Size(153, 22);
      _ExitToolStripMenuItem.Text = "E&xit";
      // 
      // EditToolStripMenuItem1
      // 
      EditToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { _UndoToolStripMenuItem, _WireframeModeToolStripMenuItem, RenderToolStripMenuItem });
      EditToolStripMenuItem1.Name = "EditToolStripMenuItem1";
      EditToolStripMenuItem1.Size = new Size(44, 27);
      EditToolStripMenuItem1.Text = "&View";
      // 
      // UndoToolStripMenuItem
      // 
      _UndoToolStripMenuItem.Name = "_UndoToolStripMenuItem";
      _UndoToolStripMenuItem.ShortcutKeys = Keys.F1;
      _UndoToolStripMenuItem.Size = new Size(152, 22);
      _UndoToolStripMenuItem.Text = "Editor tabs";
      // 
      // WireframeModeToolStripMenuItem
      // 
      _WireframeModeToolStripMenuItem.CheckOnClick = true;
      _WireframeModeToolStripMenuItem.Name = "_WireframeModeToolStripMenuItem";
      _WireframeModeToolStripMenuItem.ShortcutKeyDisplayString = "F4";
      _WireframeModeToolStripMenuItem.ShortcutKeys = Keys.F4;
      _WireframeModeToolStripMenuItem.Size = new Size(152, 22);
      _WireframeModeToolStripMenuItem.Text = "Wireframe";
      // 
      // RenderToolStripMenuItem
      // 
      RenderToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { _GraphicsToolStripMenuItem, _CollisionOverlayToolStripMenuItem });
      RenderToolStripMenuItem.Name = "RenderToolStripMenuItem";
      RenderToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+R";
      RenderToolStripMenuItem.Size = new Size(152, 22);
      RenderToolStripMenuItem.Text = "Render";
      // 
      // GraphicsToolStripMenuItem
      // 
      _GraphicsToolStripMenuItem.Checked = true;
      _GraphicsToolStripMenuItem.CheckOnClick = true;
      _GraphicsToolStripMenuItem.CheckState = CheckState.Checked;
      _GraphicsToolStripMenuItem.Name = "_GraphicsToolStripMenuItem";
      _GraphicsToolStripMenuItem.Size = new Size(156, 22);
      _GraphicsToolStripMenuItem.Text = "Graphics";
      // 
      // CollisionOverlayToolStripMenuItem
      // 
      _CollisionOverlayToolStripMenuItem.Checked = true;
      _CollisionOverlayToolStripMenuItem.CheckState = CheckState.Checked;
      _CollisionOverlayToolStripMenuItem.Name = "_CollisionOverlayToolStripMenuItem";
      _CollisionOverlayToolStripMenuItem.Size = new Size(156, 22);
      _CollisionOverlayToolStripMenuItem.Text = "Collision overlay";
      // 
      // ToolsToolStripMenuItem1
      // 
      ToolsToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { MouseToolToolStripMenuItem1, LockAxesToolStripMenuItem, OptionsToolStripMenuItem2 });
      ToolsToolStripMenuItem1.Name = "ToolsToolStripMenuItem1";
      ToolsToolStripMenuItem1.Size = new Size(45, 27);
      ToolsToolStripMenuItem1.Text = "&Tools";
      // 
      // MouseToolToolStripMenuItem1
      // 
      MouseToolToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { _CameraOnlyMenu, _ActorSelectorMenu, _CollisionToolStripMenuItem, CollisionSelectorMenu, _DisplayListSelectorToolStripMenuItem });
      MouseToolToolStripMenuItem1.Name = "MouseToolToolStripMenuItem1";
      MouseToolToolStripMenuItem1.ShortcutKeyDisplayString = "";
      MouseToolToolStripMenuItem1.Size = new Size(163, 22);
      MouseToolToolStripMenuItem1.Text = "Mouse Tool";
      // 
      // CameraOnlyMenu
      // 
      _CameraOnlyMenu.Name = "_CameraOnlyMenu";
      _CameraOnlyMenu.ShortcutKeyDisplayString = "1";
      _CameraOnlyMenu.Size = new Size(191, 22);
      _CameraOnlyMenu.Text = "Camera only";
      // 
      // ActorSelectorMenu
      // 
      _ActorSelectorMenu.Name = "_ActorSelectorMenu";
      _ActorSelectorMenu.ShortcutKeyDisplayString = "2";
      _ActorSelectorMenu.Size = new Size(191, 22);
      _ActorSelectorMenu.Text = "Actor Selector";
      // 
      // CollisionToolStripMenuItem
      // 
      _CollisionToolStripMenuItem.Name = "_CollisionToolStripMenuItem";
      _CollisionToolStripMenuItem.ShortcutKeyDisplayString = "3";
      _CollisionToolStripMenuItem.Size = new Size(191, 22);
      _CollisionToolStripMenuItem.Text = "Collision Tri Selector";
      // 
      // CollisionSelectorMenu
      // 
      CollisionSelectorMenu.DropDownItems.AddRange(new ToolStripItem[] { EdgeToolStripMenuItem, TriangleToolStripMenuItem, VertexToolStripMenuItem });
      CollisionSelectorMenu.Name = "CollisionSelectorMenu";
      CollisionSelectorMenu.ShortcutKeyDisplayString = "";
      CollisionSelectorMenu.Size = new Size(191, 22);
      CollisionSelectorMenu.Text = "Geometry Editor";
      CollisionSelectorMenu.Visible = false;
      // 
      // EdgeToolStripMenuItem
      // 
      EdgeToolStripMenuItem.Name = "EdgeToolStripMenuItem";
      EdgeToolStripMenuItem.ShortcutKeyDisplayString = "4";
      EdgeToolStripMenuItem.Size = new Size(130, 22);
      EdgeToolStripMenuItem.Text = "Edge";
      // 
      // TriangleToolStripMenuItem
      // 
      TriangleToolStripMenuItem.Name = "TriangleToolStripMenuItem";
      TriangleToolStripMenuItem.ShortcutKeyDisplayString = "5";
      TriangleToolStripMenuItem.Size = new Size(130, 22);
      TriangleToolStripMenuItem.Text = "Triangle";
      // 
      // VertexToolStripMenuItem
      // 
      VertexToolStripMenuItem.Name = "VertexToolStripMenuItem";
      VertexToolStripMenuItem.ShortcutKeyDisplayString = "6";
      VertexToolStripMenuItem.Size = new Size(130, 22);
      VertexToolStripMenuItem.Text = "Vertex";
      // 
      // DisplayListSelectorToolStripMenuItem
      // 
      _DisplayListSelectorToolStripMenuItem.Name = "_DisplayListSelectorToolStripMenuItem";
      _DisplayListSelectorToolStripMenuItem.ShortcutKeyDisplayString = "7";
      _DisplayListSelectorToolStripMenuItem.Size = new Size(191, 22);
      _DisplayListSelectorToolStripMenuItem.Text = "Display List selector";
      // 
      // LockAxesToolStripMenuItem
      // 
      LockAxesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { _XToolStripMenuItem, _YToolStripMenuItem, _DisableToolStripMenuItem });
      LockAxesToolStripMenuItem.Name = "LockAxesToolStripMenuItem";
      LockAxesToolStripMenuItem.ShortcutKeyDisplayString = "Space";
      LockAxesToolStripMenuItem.Size = new Size(163, 22);
      LockAxesToolStripMenuItem.Text = "Lock axes";
      // 
      // XToolStripMenuItem
      // 
      _XToolStripMenuItem.Name = "_XToolStripMenuItem";
      _XToolStripMenuItem.ShortcutKeyDisplayString = "";
      _XToolStripMenuItem.Size = new Size(111, 22);
      _XToolStripMenuItem.Text = "X";
      // 
      // YToolStripMenuItem
      // 
      _YToolStripMenuItem.Name = "_YToolStripMenuItem";
      _YToolStripMenuItem.ShortcutKeyDisplayString = "";
      _YToolStripMenuItem.Size = new Size(111, 22);
      _YToolStripMenuItem.Text = "Y";
      // 
      // DisableToolStripMenuItem
      // 
      _DisableToolStripMenuItem.Name = "_DisableToolStripMenuItem";
      _DisableToolStripMenuItem.ShortcutKeyDisplayString = "";
      _DisableToolStripMenuItem.Size = new Size(111, 22);
      _DisableToolStripMenuItem.Text = "Disable";
      // 
      // OptionsToolStripMenuItem2
      // 
      OptionsToolStripMenuItem2.DropDownItems.AddRange(new ToolStripItem[] { _DisableDepthTestToolStripMenuItem });
      OptionsToolStripMenuItem2.Name = "OptionsToolStripMenuItem2";
      OptionsToolStripMenuItem2.Size = new Size(163, 22);
      OptionsToolStripMenuItem2.Text = "Options";
      // 
      // DisableDepthTestToolStripMenuItem
      // 
      _DisableDepthTestToolStripMenuItem.CheckOnClick = true;
      _DisableDepthTestToolStripMenuItem.Name = "_DisableDepthTestToolStripMenuItem";
      _DisableDepthTestToolStripMenuItem.Size = new Size(224, 22);
      _DisableDepthTestToolStripMenuItem.Text = "Select actors behind graphics";
      // 
      // ToolsToolStripMenuItem
      // 
      ToolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { _OptionsToolStripMenuItem1, RendererToolStripMenuItem });
      ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem";
      ToolsToolStripMenuItem.Size = new Size(81, 27);
      ToolsToolStripMenuItem.Text = "&Preferences";
      // 
      // OptionsToolStripMenuItem1
      // 
      _OptionsToolStripMenuItem1.Name = "_OptionsToolStripMenuItem1";
      _OptionsToolStripMenuItem1.Size = new Size(122, 22);
      _OptionsToolStripMenuItem1.Text = "&Setup";
      // 
      // RendererToolStripMenuItem
      // 
      RendererToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { _TexturesToolStripMenuItem, _ColorCombinerToolStripMenuItem, _AnisotropicFilteringToolStripMenuItem, _FullSceneAntialiasingToolStripMenuItem });
      RendererToolStripMenuItem.Name = "RendererToolStripMenuItem";
      RendererToolStripMenuItem.Size = new Size(122, 22);
      RendererToolStripMenuItem.Text = "Renderer";
      // 
      // TexturesToolStripMenuItem
      // 
      _TexturesToolStripMenuItem.Checked = true;
      _TexturesToolStripMenuItem.CheckState = CheckState.Checked;
      _TexturesToolStripMenuItem.Name = "_TexturesToolStripMenuItem";
      _TexturesToolStripMenuItem.Size = new Size(184, 22);
      _TexturesToolStripMenuItem.Text = "Textures";
      // 
      // ColorCombinerToolStripMenuItem
      // 
      _ColorCombinerToolStripMenuItem.Checked = true;
      _ColorCombinerToolStripMenuItem.CheckState = CheckState.Checked;
      _ColorCombinerToolStripMenuItem.Name = "_ColorCombinerToolStripMenuItem";
      _ColorCombinerToolStripMenuItem.Size = new Size(184, 22);
      _ColorCombinerToolStripMenuItem.Text = "Color Combiner";
      // 
      // AnisotropicFilteringToolStripMenuItem
      // 
      _AnisotropicFilteringToolStripMenuItem.Checked = true;
      _AnisotropicFilteringToolStripMenuItem.CheckState = CheckState.Checked;
      _AnisotropicFilteringToolStripMenuItem.Name = "_AnisotropicFilteringToolStripMenuItem";
      _AnisotropicFilteringToolStripMenuItem.Size = new Size(184, 22);
      _AnisotropicFilteringToolStripMenuItem.Text = "Anisotropic Filtering";
      // 
      // FullSceneAntialiasingToolStripMenuItem
      // 
      _FullSceneAntialiasingToolStripMenuItem.Checked = true;
      _FullSceneAntialiasingToolStripMenuItem.CheckState = CheckState.Checked;
      _FullSceneAntialiasingToolStripMenuItem.Name = "_FullSceneAntialiasingToolStripMenuItem";
      _FullSceneAntialiasingToolStripMenuItem.Size = new Size(184, 22);
      _FullSceneAntialiasingToolStripMenuItem.Text = "Full Scene Antialiasing";
      // 
      // HelpToolStripMenuItem1
      // 
      HelpToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { ContentsToolStripMenuItem, _AboutUoTToolStripMenuItem });
      HelpToolStripMenuItem1.Name = "HelpToolStripMenuItem1";
      HelpToolStripMenuItem1.Size = new Size(41, 27);
      HelpToolStripMenuItem1.Text = "&Help";
      // 
      // ContentsToolStripMenuItem
      // 
      ContentsToolStripMenuItem.Name = "ContentsToolStripMenuItem";
      ContentsToolStripMenuItem.Size = new Size(127, 22);
      ContentsToolStripMenuItem.Text = "&Contents";
      // 
      // AboutUoTToolStripMenuItem
      // 
      _AboutUoTToolStripMenuItem.Name = "_AboutUoTToolStripMenuItem";
      _AboutUoTToolStripMenuItem.Size = new Size(127, 22);
      _AboutUoTToolStripMenuItem.Text = "&About UoT";
      // 
      // UoTMainMenu
      // 
      UoTMainMenu.AllowMerge = false;
      UoTMainMenu.AutoSize = false;
      UoTMainMenu.BackColor = SystemColors.ControlLight;
      UoTMainMenu.Font = new Font("Trebuchet MS", 8.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
      UoTMainMenu.Items.AddRange(new ToolStripItem[] { FileToolStripMenuItem1, ToolStripMenuItem3, EditToolStripMenuItem1, ToolsToolStripMenuItem, ToolsToolStripMenuItem1, HelpToolStripMenuItem1 });
      UoTMainMenu.Location = new Point(0, 0);
      UoTMainMenu.Name = "UoTMainMenu";
      UoTMainMenu.RenderMode = ToolStripRenderMode.Professional;
      UoTMainMenu.Size = new Size(1160, 31);
      UoTMainMenu.Stretch = false;
      UoTMainMenu.TabIndex = 40;
      UoTMainMenu.Text = "MenuStrip1";
      // 
      // ToolStripMenuItem3
      // 
      ToolStripMenuItem3.DropDownItems.AddRange(new ToolStripItem[] { UndoToolStripMenuItem1, RedoToolStripMenuItem });
      ToolStripMenuItem3.Name = "ToolStripMenuItem3";
      ToolStripMenuItem3.Size = new Size(40, 27);
      ToolStripMenuItem3.Text = "Edit";
      ToolStripMenuItem3.Visible = false;
      // 
      // UndoToolStripMenuItem1
      // 
      UndoToolStripMenuItem1.Name = "UndoToolStripMenuItem1";
      UndoToolStripMenuItem1.ShortcutKeys = Keys.Control | Keys.Z;
      UndoToolStripMenuItem1.Size = new Size(140, 22);
      UndoToolStripMenuItem1.Text = "&Undo";
      // 
      // RedoToolStripMenuItem
      // 
      RedoToolStripMenuItem.Name = "RedoToolStripMenuItem";
      RedoToolStripMenuItem.Size = new Size(140, 22);
      RedoToolStripMenuItem.Text = "&Redo";
      RedoToolStripMenuItem.Visible = false;
      // 
      // VertContextMenu
      // 
      VertContextMenu.BackColor = SystemColors.Control;
      VertContextMenu.Items.AddRange(new ToolStripItem[] { ToolStripMenuItem5, ToolStripSeparator15, ToolStripMenuItem6, ToolStripMenuItem16, ToolStripSeparator16, _ToolStripMenuItem20, ToolStripMenuItem21, ToolStripMenuItem33 });
      VertContextMenu.Name = "ContextMenuStrip4";
      VertContextMenu.RenderMode = ToolStripRenderMode.Professional;
      VertContextMenu.Size = new Size(152, 148);
      // 
      // ToolStripMenuItem5
      // 
      ToolStripMenuItem5.Name = "ToolStripMenuItem5";
      ToolStripMenuItem5.Size = new Size(151, 22);
      ToolStripMenuItem5.Text = "Deselect";
      // 
      // ToolStripSeparator15
      // 
      ToolStripSeparator15.Name = "ToolStripSeparator15";
      ToolStripSeparator15.Size = new Size(148, 6);
      // 
      // ToolStripMenuItem6
      // 
      ToolStripMenuItem6.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItem7, ToolStripMenuItem10, ToolStripMenuItem13 });
      ToolStripMenuItem6.Name = "ToolStripMenuItem6";
      ToolStripMenuItem6.Size = new Size(151, 22);
      ToolStripMenuItem6.Text = "Rotate";
      // 
      // ToolStripMenuItem7
      // 
      ToolStripMenuItem7.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItem8, ToolStripMenuItem9 });
      ToolStripMenuItem7.Name = "ToolStripMenuItem7";
      ToolStripMenuItem7.Size = new Size(80, 22);
      ToolStripMenuItem7.Text = "X";
      // 
      // ToolStripMenuItem8
      // 
      ToolStripMenuItem8.Name = "ToolStripMenuItem8";
      ToolStripMenuItem8.Size = new Size(139, 22);
      ToolStripMenuItem8.Text = "+ 90 degrees";
      // 
      // ToolStripMenuItem9
      // 
      ToolStripMenuItem9.Name = "ToolStripMenuItem9";
      ToolStripMenuItem9.Size = new Size(139, 22);
      ToolStripMenuItem9.Text = "- 90 degrees";
      // 
      // ToolStripMenuItem10
      // 
      ToolStripMenuItem10.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItem11, ToolStripMenuItem12 });
      ToolStripMenuItem10.Name = "ToolStripMenuItem10";
      ToolStripMenuItem10.Size = new Size(80, 22);
      ToolStripMenuItem10.Text = "Y";
      // 
      // ToolStripMenuItem11
      // 
      ToolStripMenuItem11.Name = "ToolStripMenuItem11";
      ToolStripMenuItem11.Size = new Size(142, 22);
      ToolStripMenuItem11.Text = " + 90 degrees";
      // 
      // ToolStripMenuItem12
      // 
      ToolStripMenuItem12.Name = "ToolStripMenuItem12";
      ToolStripMenuItem12.Size = new Size(142, 22);
      ToolStripMenuItem12.Text = "- 90 degrees";
      // 
      // ToolStripMenuItem13
      // 
      ToolStripMenuItem13.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItem14, ToolStripMenuItem15 });
      ToolStripMenuItem13.Name = "ToolStripMenuItem13";
      ToolStripMenuItem13.Size = new Size(80, 22);
      ToolStripMenuItem13.Text = "Z";
      // 
      // ToolStripMenuItem14
      // 
      ToolStripMenuItem14.Name = "ToolStripMenuItem14";
      ToolStripMenuItem14.Size = new Size(139, 22);
      ToolStripMenuItem14.Text = "+ 90 degrees";
      // 
      // ToolStripMenuItem15
      // 
      ToolStripMenuItem15.Name = "ToolStripMenuItem15";
      ToolStripMenuItem15.Size = new Size(139, 22);
      ToolStripMenuItem15.Text = "- 90 degrees";
      // 
      // ToolStripMenuItem16
      // 
      ToolStripMenuItem16.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItem17, ToolStripMenuItem18, ToolStripMenuItem19 });
      ToolStripMenuItem16.Name = "ToolStripMenuItem16";
      ToolStripMenuItem16.Size = new Size(151, 22);
      ToolStripMenuItem16.Text = "Align";
      // 
      // ToolStripMenuItem17
      // 
      ToolStripMenuItem17.Name = "ToolStripMenuItem17";
      ToolStripMenuItem17.Size = new Size(80, 22);
      ToolStripMenuItem17.Text = "X";
      // 
      // ToolStripMenuItem18
      // 
      ToolStripMenuItem18.Name = "ToolStripMenuItem18";
      ToolStripMenuItem18.Size = new Size(80, 22);
      ToolStripMenuItem18.Text = "Y";
      // 
      // ToolStripMenuItem19
      // 
      ToolStripMenuItem19.Name = "ToolStripMenuItem19";
      ToolStripMenuItem19.Size = new Size(80, 22);
      ToolStripMenuItem19.Text = "Z";
      // 
      // ToolStripSeparator16
      // 
      ToolStripSeparator16.Name = "ToolStripSeparator16";
      ToolStripSeparator16.Size = new Size(148, 6);
      // 
      // ToolStripMenuItem20
      // 
      _ToolStripMenuItem20.Name = "_ToolStripMenuItem20";
      _ToolStripMenuItem20.Size = new Size(151, 22);
      _ToolStripMenuItem20.Text = "Copy attributes";
      // 
      // ToolStripMenuItem21
      // 
      ToolStripMenuItem21.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItem22, ToolStripMenuItem27, ToolStripMenuItem32 });
      ToolStripMenuItem21.Enabled = false;
      ToolStripMenuItem21.Name = "ToolStripMenuItem21";
      ToolStripMenuItem21.Size = new Size(151, 22);
      ToolStripMenuItem21.Text = "Paste attributes";
      // 
      // ToolStripMenuItem22
      // 
      ToolStripMenuItem22.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItem23, ToolStripMenuItem24, ToolStripMenuItem25, ToolStripMenuItem26 });
      ToolStripMenuItem22.Name = "ToolStripMenuItem22";
      ToolStripMenuItem22.Size = new Size(173, 22);
      ToolStripMenuItem22.Text = "Position";
      // 
      // ToolStripMenuItem23
      // 
      ToolStripMenuItem23.Name = "ToolStripMenuItem23";
      ToolStripMenuItem23.Size = new Size(85, 22);
      ToolStripMenuItem23.Text = "X";
      // 
      // ToolStripMenuItem24
      // 
      ToolStripMenuItem24.Name = "ToolStripMenuItem24";
      ToolStripMenuItem24.Size = new Size(85, 22);
      ToolStripMenuItem24.Text = "Y";
      // 
      // ToolStripMenuItem25
      // 
      ToolStripMenuItem25.Name = "ToolStripMenuItem25";
      ToolStripMenuItem25.Size = new Size(85, 22);
      ToolStripMenuItem25.Text = "Z";
      // 
      // ToolStripMenuItem26
      // 
      ToolStripMenuItem26.Name = "ToolStripMenuItem26";
      ToolStripMenuItem26.Size = new Size(85, 22);
      ToolStripMenuItem26.Text = "All";
      // 
      // ToolStripMenuItem27
      // 
      ToolStripMenuItem27.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItem28, ToolStripMenuItem29, ToolStripMenuItem30, ToolStripMenuItem31 });
      ToolStripMenuItem27.Name = "ToolStripMenuItem27";
      ToolStripMenuItem27.Size = new Size(173, 22);
      ToolStripMenuItem27.Text = "Rotation";
      // 
      // ToolStripMenuItem28
      // 
      ToolStripMenuItem28.Name = "ToolStripMenuItem28";
      ToolStripMenuItem28.Size = new Size(85, 22);
      ToolStripMenuItem28.Text = "X";
      // 
      // ToolStripMenuItem29
      // 
      ToolStripMenuItem29.Name = "ToolStripMenuItem29";
      ToolStripMenuItem29.Size = new Size(85, 22);
      ToolStripMenuItem29.Text = "Y";
      // 
      // ToolStripMenuItem30
      // 
      ToolStripMenuItem30.Name = "ToolStripMenuItem30";
      ToolStripMenuItem30.Size = new Size(85, 22);
      ToolStripMenuItem30.Text = "Z";
      // 
      // ToolStripMenuItem31
      // 
      ToolStripMenuItem31.Name = "ToolStripMenuItem31";
      ToolStripMenuItem31.Size = new Size(85, 22);
      ToolStripMenuItem31.Text = "All";
      // 
      // ToolStripMenuItem32
      // 
      ToolStripMenuItem32.Name = "ToolStripMenuItem32";
      ToolStripMenuItem32.Size = new Size(173, 22);
      ToolStripMenuItem32.Text = "Number and Variable";
      // 
      // ToolStripMenuItem33
      // 
      ToolStripMenuItem33.Enabled = false;
      ToolStripMenuItem33.Name = "ToolStripMenuItem33";
      ToolStripMenuItem33.Size = new Size(151, 22);
      ToolStripMenuItem33.Text = "Clear clipboard";
      // 
      // RipDL
      // 
      _RipDL.Filter = "RAW F3DEX2 Display List (*.f3dex2)|*.f3dex2";
      // 
      // SaveROMAs
      // 
      _SaveROMAs.Filter = "N64 ROMs|*.z64;*.n64;*.v64;*.rom";
      // 
      // VarContextMenu
      // 
      VarContextMenu.Name = "VarContextMenu";
      VarContextMenu.Size = new Size(61, 4);
      // 
      // NumContextMenu
      // 
      NumContextMenu.Name = "NumContextMenu";
      NumContextMenu.Size = new Size(61, 4);
      // 
      // GrpContextMenu
      // 
      GrpContextMenu.Name = "GrpContextMenu";
      GrpContextMenu.Size = new Size(61, 4);
      // 
      // MainWin
      // 
      AllowDrop = true;
      AutoScaleMode = AutoScaleMode.Inherit;
      ClientSize = new Size(1160, 649);
      Controls.Add(Label29);
      Controls.Add(TreeFind);
      Controls.Add(_FileTree);
      Controls.Add(ROMBrowser);
      Controls.Add(Label12);
      Controls.Add(Label43);
      Controls.Add(EditingTabs);
      Controls.Add(_TrackBar1);
      Controls.Add(_TrackBar4);
      Controls.Add(UoTStatus);
      Controls.Add(UoTMainMenu);
      Controls.Add(_UoTRender);
      DoubleBuffered = true;
      Icon = (Icon)resources.GetObject("$this.Icon");
      MainMenuStrip = UoTMainMenu;
      Name = "MainWin";
      SizeGripStyle = SizeGripStyle.Show;
      Text = "Utility of Time R8";
      UoTStatus.ResumeLayout(false);
      UoTStatus.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)_TrackBar4).EndInit();
      CollisionTab.ResumeLayout(false);
      GroupBox1.ResumeLayout(false);
      GroupBox1.PerformLayout();
      CollisionGroupBox.ResumeLayout(false);
      CollisionGroupBox.PerformLayout();
      MiscTab.ResumeLayout(false);
      MiscTab.PerformLayout();
      GroupBox9.ResumeLayout(false);
      GroupBox9.PerformLayout();
      GroupBox10.ResumeLayout(false);
      GroupBox10.PerformLayout();
      GroupBox8.ResumeLayout(false);
      GroupBox8.PerformLayout();
      LevelFlagsTab.ResumeLayout(false);
      GroupBox6.ResumeLayout(false);
      GroupBox6.PerformLayout();
      ActorsTab.ResumeLayout(false);
      GroupBox4.ResumeLayout(false);
      GroupBox4.PerformLayout();
      GroupBox5.ResumeLayout(false);
      GroupBox5.PerformLayout();
      EditingTabs.ResumeLayout(false);
      AnimationsTab.ResumeLayout(false);
      AnimationsTab.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)_CurrentFrame).EndInit();
      AnimationSetGroup.ResumeLayout(false);
      AnimationSetGroup.PerformLayout();
      PlaybackGroup.ResumeLayout(false);
      PlaybackGroup.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)_AnimationFPS).EndInit();
      DLTab.ResumeLayout(false);
      DLTab.PerformLayout();
      GroupBox7.ResumeLayout(false);
      GroupBox7.PerformLayout();
      DLEditorContextMenu.ResumeLayout(false);
      GroupBox3.ResumeLayout(false);
      GroupBox3.PerformLayout();
      BackupMenuStrip.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)_TrackBar1).EndInit();
      ActorContextMenu.ResumeLayout(false);
      ROMBrowser.ResumeLayout(false);
      ROMDataTabs.ResumeLayout(false);
      UoTMainMenu.ResumeLayout(false);
      UoTMainMenu.PerformLayout();
      VertContextMenu.ResumeLayout(false);
      Load += new EventHandler(Form1_Load);
      Enter += new EventHandler(Form1_Enter);
      Resize += new EventHandler(MainWin_ResizeEnd);
      FormClosing += new FormClosingEventHandler(MainWin_FormClosing);
      ResumeLayout(false);
      PerformLayout();
    }
    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */


    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    private Structs.ActorTbl[] ActorTable;
    private IList<Structs.ObjectTbl> ObjectTable = new List<Structs.ObjectTbl>();
    private int RecentROMCount = 0;
    private int RecentIndCount = 0;
    private int MapSt = 0;
    private int SceneSt = 0;
    private int ScBuffSize = 0;
    private int MapBuffSize = 0;
    private int ObjBuffSize = 0;
    private string ObjectFilename = "";
    private int ActorBuffSize = 0;
    private string ScFilename = "";
    private string MapFilename = "";
    private string ObjectFilemame = "";
    private string ActorFilename = "";
    private int MapCount = 0;
    private int SceneCount = 0;
    private int ObjectCount = 0;
    private Structs.ZFileTypes ROMFiles = new Structs.ZFileTypes();
    private FileStream ROMFileStream;
    private byte[] ROMData;
    private byte[] Z64Code;
    private string IndMapFileName = "";
    private string IndScFileName = "";
    private Structs.N64DisplayList[] ActorN64DLists;
    private Structs.OGLDisplayList[] ActorOGLDLists;
    private int[] CurrSelNode = new int[2];

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    private string PrintToolStr = "";
    private bool PrintTool = false;
    private Structs.Actor[] RoomActors;
    private Structs.Door[] SceneActors;
    private int rmActorCount = 0;
    private int scActorCount = 0;
    private int[] CopyActor = new int[] { -1, -1, -1, -1, -1, -1, -1, -1 }; // x pos, y pos, z pos, x rot, y rot, z rot, number, variable
    private uint[] ActorPointer = new uint[] { 0U, 0U, 0U }; // header pos, count, pointer
    private bool RelocateActorPtr = false;
    private float ActorScale = 16.0f;
    private float ActorScaleP = 45.0f;
    private float ActorScaleW = 2.05f;
    private bool[] HideActors = new bool[4];
    private int RotCoef = 0x4000;
    private int DefRotCoef = 0x4000;
    private ArrayList ActorDBGroups = new ArrayList();
    private ArrayList ActorDBNumber = new ArrayList();
    private ArrayList ActorDBVars = new ArrayList();
    private ArrayList ActorDBDesc = new ArrayList();
    private int[] UsedGroupIndex;
    private int[] UsedSceneGroupIndex;
    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    private Structs.Animation[] AnimationEntries = new Structs.Animation[0];
    private Structs.Limb[] LimbEntries = new Structs.Limb[0];
    private int CurrLimb = 0;
    private Structs.Color3UByte BoneColorFactor = new Structs.Color3UByte();
    private int CurrParent = 0;
    private uint AnimTick = 0U;
    private double CurrFrame = 0d;
    private int CurrAnimation = 0;
    private bool LoopAnimation = false;
    private bool ShowBones = false;
    private bool HasLimbs = false;
    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    private float[] LAmbient = new float[] { 1.0f, 1.0f, 1.0f, 1.0f };
    private float[] LDiffuse = new float[] { 1.0f, 1.0f, 1.0f, 1.0f };
    private float[] LSpecular = new float[] { 1.0f, 1.0f, 1.0f, 1.0f };
    private float[] LPosition = new float[] { 1.0f, 1.0f, 1.0f, 1.0f };
    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    private Structs.CollisionTriColorSelect[] CollisionTriColor;
    private uint ColA, ColB, ColC;
    private Structs.CollisionVertex CollisionVerts = new Structs.CollisionVertex();
    private Structs.CollisionVertex CollisionVertsCopy;
    private Structs.PolygonCollision[] CollisionPolies;
    private ArrayList SelectedCollisionVert = new ArrayList();
    private Structs.CollisionTypes[] ColTypes;
    private Structs.CollisionTypePresets[] ColPresets;
    private Structs.ZCamera[] CamData;
    private bool TriSel = false;
    private bool Highlight = false;
    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    private Structs.MapOffset[] SceneMaps;
    private Structs.Exits[] SceneExits;
    private bool ScannedObjSet = false;
    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public enum ToolID {
      // identifiers
      CAMERA = 0,
      ACTOR = 1,
      VERTEX = 2,
      EDGE = 3,
      FACE = 4,
      COLTRI = 5,
      DLIST = 6,
      NONE = default,

      // axis locks
      NOLOCK = 0,
      LOCKTOX = 1,
      LOCKTOY = 2,
      LOCKTOZ = 3,
      NOMOVE = 4

      // selected item identifiers

    }

    public struct CmdCopy {
      public byte Cmd;
      public uint CmdLow;
      public uint CmdHigh;
    }

    private Point CursorPosOld;
    private bool HoldCursor = false;
    private Structs.Tools ToolModes;
    private string[] AxisStrings = new string[] { "(X + Y)", "(X)", "(Y)", "(Z)" };
    private string[] ToolStrings = new string[] { "Camera only", "Actor selector", "Vertex selector", "Edge selector", "Face selector", "Collision triangle selector", "Display List selector" };
    private bool HighlightDL = true;
    private int EditRotAxis = 0;
    private int EditRotType = 0;
    private bool MPick = false;
    private byte[] ReadPixel = new byte[3];
    private bool[] ChangePosition = new bool[] { false, false, false, false, false, false };
    private int ToolSensitivity = 2;
    private int ButtonPress = 0;
    private uint AxisGuideDList = 0U;
    private uint ActorBoxDList = 0U;
    private int comb5 = 0;
    private int comb7 = 0;
    private ArrayList Objects = new ArrayList();
    private ArrayList ObjectsDesc = new ArrayList();
    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    private bool RipAllDLs = false;
    private FileStream RawDLFile;
    private bool colTri = false;
    private TreeNode oldSelectedNode;
    private TreeNode newSelectedNode;
    private iniwriter UoTIniFile = new iniwriter(Application.StartupPath + "/uot.ini");
    private bool Working = false;
    private string AppDirectory = Application.StartupPath;
    private bool key_w, key_a, key_s, key_d, key_q, key_e, key_u, key_o, key_up, key_lf, key_dn, key_rt, key_ctrl, key_alt;
    private bool MouseLeft = false;
    private bool MouseRight = false;
    private bool MouseMiddle = false;
    private double CameraCoef = 46.1209812309812d;
    private bool MouseOver = false;
    private double CamXRot = 0.0d;
    private double CamYRot = 0.0d;
    private double CamZRot = 0.0d;
    private double CamXRotd = 0d;
    private double CamYRotd = 0d;
    private double CamZRotd = 0d;
    private double CosYRot = 0d;
    private double SinYRot = 0d;
    private double NewMouseX = 0.0d;
    private double NewMouseY = 0.0d;
    private double OldMouseX = 0.0d;
    private double OldMouseY = 0.0d;
    private Point LocalMouse;
    private Point oldLocalMouse;
    private double Dx = 0d;
    private double Dy = 0d;
    private double Dz = 0d;
    private bool RenderCollision = true;
    private bool RenderGraphics = true;
    private bool wireframe = false;
    private int LoadedDataType = 0;
    private int[] viewport = new int[4];
    private string identity;
    private bool AppExit = false;
    private double PIRad = Math.PI / 180d;
    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    private Process crc = new Process();
    private Process cfix = new Process();
    private int zlestart16 = 0;
    private int zleend16 = 0;
    private int zlestart6 = 0;
    private int zleend6 = 0;
    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    private int i1 = 0;
    private int i2 = 0;
    private int i3 = 0;
    private int i4 = 0;
    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    private void Initialize() {
      ResetOGL();
      Wgl.wglSwapIntervalEXT(1);
      Reshape();
      FatherLoop();
    }

    private void ResetOGL() {
      Gl.glShadeModel(Gl.GL_SMOOTH);
      Gl.glEnable(Gl.GL_POINT_SMOOTH);
      Gl.glHint(Gl.GL_POINT_SMOOTH_HINT, Gl.GL_NICEST);
      Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_FILL);
      Gl.glClearDepth(5.0d);
      Gl.glDepthFunc(Gl.GL_LEQUAL);
      Gl.glEnable(Gl.GL_DEPTH_TEST);
      Gl.glDepthMask(Gl.GL_TRUE);
      Gl.glHint(Gl.GL_PERSPECTIVE_CORRECTION_HINT, Gl.GL_NICEST);
      Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_AMBIENT, LAmbient);
      Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_DIFFUSE, LDiffuse);
      Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_SPECULAR, LAmbient);
      Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, LPosition);
      Gl.glEnable(Gl.GL_LIGHT0);
      Gl.glEnable(Gl.GL_LIGHTING);
      Gl.glEnable(Gl.GL_NORMALIZE);
      Gl.glEnable(Gl.GL_CULL_FACE);
      Gl.glCullFace(Gl.GL_BACK);
      Gl.glEnable(Gl.GL_BLEND);
      Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);
      Gl.glClearColor(0.2f, 0.5f, 0.7f, 1f);
    }

    private void FatherLoop() {
      while (!AppExit) {
        MainLoop();
        Application.DoEvents();
        UoTRender.Invalidate();
      }

      UoTRender.DestroyContexts();
      Environment.Exit(0);
    }

    private void SyncCameraToActor(int ActorType, int Actor) {
      switch (ActorType) {
        case 0: {
            GlobalVars.CamXPos = -RoomActors[Actor].x;
            GlobalVars.CamYPos = -RoomActors[Actor].y - 1000;
            GlobalVars.CamZPos = -RoomActors[Actor].z - 1000;
            break;
          }

        case 1: {
            GlobalVars.CamXPos = -SceneActors[Actor].x;
            GlobalVars.CamYPos = -SceneActors[Actor].y - 1000;
            GlobalVars.CamZPos = -SceneActors[Actor].z - 1000;
            break;
          }
      }

      CamXRot = 45d;
    }

    private void MainLoop() {
      try {
        Gl.glClear(Gl.GL_DEPTH_BUFFER_BIT | Gl.GL_COLOR_BUFFER_BIT);
        LocalMouse = UoTRender.PointToClient(Cursor.Position);
        NewMouseX = LocalMouse.X;
        NewMouseY = LocalMouse.Y;
        CamXRotd = CamXRot * PIRad;
        CamYRotd = CamYRot * PIRad;
        bool MouseChanged = false;
        if (NewMouseX != OldMouseX) {
          Dx = (NewMouseX - OldMouseX) * ToolSensitivity;
          MouseChanged = true;
        }

        if (NewMouseY != OldMouseY) {
          Dy = (NewMouseY - OldMouseY) * ToolSensitivity;
          MouseChanged = true;
        }

        if (MouseChanged) {
          if (MouseLeft) {
            if (OldMouseX < NewMouseX) {
              // (MOUSE MOVE RIGHT)
              if (ToolModes.SelectedItemType == (int)ToolID.NONE) {
                CamYRot += (NewMouseX - OldMouseX) * 0.5d;
                if (CamYRot > 360d) {
                  CamYRot = 0d;
                }
              }

              if ((ToolModes.Axis == (int)ToolID.NOLOCK | ToolModes.Axis == (int)ToolID.LOCKTOX) & !(ToolModes.Axis == (int)ToolID.NOMOVE)) {
                if (ToolModes.SelectedItemType == (int)ToolID.ACTOR) {
                  if (GlobalVars.OnSceneActor) {
                    for (int i = 0, loopTo = GlobalVars.SelectedSceneActors.Count - 1; i <= loopTo; i++) {
                      i1 = Conversions.ToInteger(GlobalVars.SelectedSceneActors[i]);
                      SceneActors[i1].x = (short)(SceneActors[i1].x + Math.Cos(CamYRotd) * Dx);
                      SceneActors[i1].z = (short)(SceneActors[i1].z + Math.Sin(CamYRotd) * Dx);
                    }
                  } else {
                    for (int i = 0, loopTo1 = GlobalVars.SelectedRoomActors.Count - 1; i <= loopTo1; i++) {
                      i1 = Conversions.ToInteger(GlobalVars.SelectedRoomActors[i]);
                      RoomActors[i1].x = (short)(RoomActors[i1].x + Math.Cos(CamYRotd) * Dx);
                      RoomActors[i1].z = (short)(RoomActors[i1].z + Math.Sin(CamYRotd) * Dx);
                    }
                  }

                  GlobalVars.CamXPos += -Math.Cos(CamYRotd) * Dx;
                  GlobalVars.CamZPos += -Math.Sin(CamYRotd) * Dx;
                  UpdateActorPos();
                } else if (ToolModes.SelectedItemType == (int)ToolID.VERTEX) {
                  if (RenderGraphics) {
                  }

                  if (RenderCollision) {
                    var loopTo2 = SelectedCollisionVert.Count - 1;
                    for (i2 = 0; i2 <= loopTo2; i2++) {
                      CollisionVerts.x[Conversions.ToInteger(SelectedCollisionVert[i2])] += Math.Cos(CamYRotd) * Dx;
                      CollisionVerts.z[Conversions.ToInteger(SelectedCollisionVert[i2])] += Math.Sin(CamYRotd) * Dx;
                    }
                  }

                  GlobalVars.CamXPos += -Math.Cos(CamYRotd) * Dx;
                  GlobalVars.CamZPos += -Math.Sin(CamYRotd) * Dx;
                }
              }
            }

            if (OldMouseX > NewMouseX) {
              // (MOUSE MOVE LEFT) 
              if (ToolModes.SelectedItemType == (int)ToolID.NONE) {
                CamYRot -= (OldMouseX - NewMouseX) * 0.5d;
                if (CamYRot < -360) {
                  CamYRot = 0d;
                }
              }

              if ((ToolModes.Axis == (int)ToolID.NOLOCK | ToolModes.Axis == (int)ToolID.LOCKTOX) & !(ToolModes.Axis == (int)ToolID.NOMOVE)) {
                if (ToolModes.SelectedItemType == (int)ToolID.ACTOR) {
                  if (GlobalVars.OnSceneActor) {
                    for (int i = 0, loopTo3 = GlobalVars.SelectedSceneActors.Count - 1; i <= loopTo3; i++) {
                      i1 = Conversions.ToInteger(GlobalVars.SelectedSceneActors[i]);
                      SceneActors[i1].x = (short)(SceneActors[i1].x + Math.Cos(CamYRotd) * Dx);
                      SceneActors[i1].z = (short)(SceneActors[i1].z + Math.Sin(CamYRotd) * Dx);
                    }
                  } else {
                    for (int i = 0, loopTo4 = GlobalVars.SelectedRoomActors.Count - 1; i <= loopTo4; i++) {
                      i1 = Conversions.ToInteger(GlobalVars.SelectedRoomActors[i]);
                      RoomActors[i1].x = (short)(RoomActors[i1].x + Math.Cos(CamYRotd) * Dx);
                      RoomActors[i1].z = (short)(RoomActors[i1].z + Math.Sin(CamYRotd) * Dx);
                    }
                  }

                  GlobalVars.CamXPos -= Math.Cos(CamYRotd) * Dx;
                  GlobalVars.CamZPos -= Math.Sin(CamYRotd) * Dx;
                  UpdateActorPos();
                } else if (ToolModes.SelectedItemType == (int)ToolID.VERTEX) {
                  if (RenderGraphics) {
                  }

                  if (RenderCollision) {
                    var loopTo5 = SelectedCollisionVert.Count - 1;
                    for (i2 = 0; i2 <= loopTo5; i2++) {
                      CollisionVerts.x[Conversions.ToInteger(SelectedCollisionVert[i2])] += Math.Cos(CamYRotd) * Dx;
                      CollisionVerts.z[Conversions.ToInteger(SelectedCollisionVert[i2])] += Math.Sin(CamYRotd) * Dx;
                    }
                  }

                  GlobalVars.CamXPos -= Math.Cos(CamYRotd) * Dx;
                  GlobalVars.CamZPos -= Math.Sin(CamYRotd) * Dx;
                }
              }
            }

            if (OldMouseY > NewMouseY) {
              // (MOUSE MOVE UP) 
              if (ToolModes.SelectedItemType == (int)ToolID.NONE) {
                if (CamXRot <= -90) {
                  CamXRot = -90;
                } else {
                  CamXRot += (long)Dy / ToolSensitivity * 0.5d;
                }
              }

              if ((ToolModes.Axis == (int)ToolID.NOLOCK | ToolModes.Axis == (int)ToolID.LOCKTOY) & !(ToolModes.Axis == (int)ToolID.NOMOVE)) {
                if (ToolModes.SelectedItemType == (int)ToolID.ACTOR) {
                  if (GlobalVars.OnSceneActor) {
                    for (int i = 0, loopTo6 = GlobalVars.SelectedSceneActors.Count - 1; i <= loopTo6; i++)
                      SceneActors[Conversions.ToInteger(GlobalVars.SelectedSceneActors[i])].y = (short)(SceneActors[Conversions.ToInteger(GlobalVars.SelectedSceneActors[i])].y - Dy);
                  } else {
                    for (int i = 0, loopTo7 = GlobalVars.SelectedRoomActors.Count - 1; i <= loopTo7; i++)
                      RoomActors[Conversions.ToInteger(GlobalVars.SelectedRoomActors[i])].y = (short)(RoomActors[Conversions.ToInteger(GlobalVars.SelectedRoomActors[i])].y - Dy);
                  }

                  GlobalVars.CamYPos += Dy;
                  UpdateActorPos();
                } else if (ToolModes.SelectedItemType == (int)ToolID.VERTEX) {
                  if (RenderGraphics) {
                  }

                  if (RenderCollision) {
                    var loopTo8 = SelectedCollisionVert.Count - 1;
                    for (i2 = 0; i2 <= loopTo8; i2++)
                      CollisionVerts.y[Conversions.ToInteger(SelectedCollisionVert[i2])] -= Dy;
                  }

                  GlobalVars.CamYPos += Dy;
                }
              }
            }

            if (OldMouseY < NewMouseY) {
              // (MOUSE MOVE DOWN) 
              if (ToolModes.SelectedItemType == (int)ToolID.NONE) {
                if (CamXRot >= 90d) {
                  CamXRot = 90d;
                } else {
                  CamXRot += (long)Dy / ToolSensitivity * 0.5d;
                }
              }

              if ((ToolModes.Axis == (int)ToolID.NOLOCK | ToolModes.Axis == (int)ToolID.LOCKTOY) & !(ToolModes.Axis == (int)ToolID.NOMOVE)) {
                if (ToolModes.SelectedItemType == (int)ToolID.ACTOR) {
                  if (GlobalVars.OnSceneActor) {
                    for (int i = 0, loopTo9 = GlobalVars.SelectedSceneActors.Count - 1; i <= loopTo9; i++)
                      SceneActors[Conversions.ToInteger(GlobalVars.SelectedSceneActors[i])].y = (short)(SceneActors[Conversions.ToInteger(GlobalVars.SelectedSceneActors[i])].y - Dy);
                  } else {
                    for (int i = 0, loopTo10 = GlobalVars.SelectedRoomActors.Count - 1; i <= loopTo10; i++)
                      RoomActors[Conversions.ToInteger(GlobalVars.SelectedRoomActors[i])].y = (short)(RoomActors[Conversions.ToInteger(GlobalVars.SelectedRoomActors[i])].y - Dy);
                  }

                  GlobalVars.CamYPos += Dy;
                  UpdateActorPos();
                } else if (ToolModes.SelectedItemType == (int)ToolID.VERTEX) {
                  if (RenderGraphics) {
                  }

                  if (RenderCollision) {
                    var loopTo11 = SelectedCollisionVert.Count - 1;
                    for (i2 = 0; i2 <= loopTo11; i2++)
                      CollisionVerts.y[Conversions.ToInteger(SelectedCollisionVert[i2])] -= Dy;
                  }

                  GlobalVars.CamYPos += Dy;
                }
              }
            }
          } else if (MouseMiddle) {
            if (OldMouseY < NewMouseY) {
              // (MOUSE MOVE DOWN) 
              if (ToolModes.SelectedItemType == (int)ToolID.NONE) {
                GlobalVars.CamYPos += (OldMouseY - NewMouseY) * (CameraCoef / 8d);
              } else if (ToolModes.SelectedItemType == (int)ToolID.ACTOR) {
                if (GlobalVars.OnSceneActor) {
                  for (int i = 0, loopTo12 = GlobalVars.SelectedSceneActors.Count - 1; i <= loopTo12; i++) {
                    i1 = Conversions.ToInteger(GlobalVars.SelectedSceneActors[i]);
                    SceneActors[i1].x = (short)(SceneActors[i1].x + Math.Sin(CamYRotd) * Dy);
                    SceneActors[i1].z = (short)(SceneActors[i1].z - Math.Cos(CamYRotd) * Dy);
                  }
                } else {
                  for (int i = 0, loopTo13 = GlobalVars.SelectedRoomActors.Count - 1; i <= loopTo13; i++) {
                    i1 = Conversions.ToInteger(GlobalVars.SelectedRoomActors[i]);
                    RoomActors[i1].x = (short)(RoomActors[i1].x + Math.Sin(CamYRotd) * Dy);
                    RoomActors[i1].z = (short)(RoomActors[i1].z - Math.Cos(CamYRotd) * Dy);
                  }
                }

                GlobalVars.CamXPos -= Math.Sin(CamYRotd) * Dy;
                GlobalVars.CamZPos += Math.Cos(CamYRotd) * Dy;
                UpdateActorPos();
              }
            }

            if (OldMouseY > NewMouseY) {
              // (MOUSE MOVE DOWN) 
              if (ToolModes.SelectedItemType == (int)ToolID.NONE) {
                GlobalVars.CamYPos -= (NewMouseY - OldMouseY) * (CameraCoef / 8d);
              } else if (ToolModes.SelectedItemType == (int)ToolID.ACTOR) {
                if (GlobalVars.OnSceneActor) {
                  for (int i = 0, loopTo14 = GlobalVars.SelectedSceneActors.Count - 1; i <= loopTo14; i++) {
                    i1 = Conversions.ToInteger(GlobalVars.SelectedSceneActors[i]);
                    SceneActors[i1].x = (short)(SceneActors[i1].x + Math.Sin(CamYRotd) * Dy);
                    SceneActors[i1].z = (short)(SceneActors[i1].z - Math.Cos(CamYRotd) * Dy);
                  }
                } else {
                  for (int i = 0, loopTo15 = GlobalVars.SelectedRoomActors.Count - 1; i <= loopTo15; i++) {
                    i1 = Conversions.ToInteger(GlobalVars.SelectedRoomActors[i]);
                    RoomActors[i1].x = (short)(RoomActors[i1].x + Math.Sin(CamYRotd) * Dy);
                    RoomActors[i1].z = (short)(RoomActors[i1].z - Math.Cos(CamYRotd) * Dy);
                  }
                }

                GlobalVars.CamXPos -= Math.Sin(CamYRotd) * Dy;
                GlobalVars.CamZPos += Math.Cos(CamYRotd) * Dy;
                UpdateActorPos();
              }
            }
          }
        }

        if (HoldCursor) {
          Cursor.Position = CursorPosOld;
          var curColor = Color.White;
          switch (ToolModes.SelectedItemType) {
            case (int)ToolID.ACTOR: {
                curColor = Color.Aquamarine;
                break;
              }

            case (int)ToolID.VERTEX: {
                curColor = Color.Tomato;
                break;
              }

            case (int)ToolID.DLIST: {
                curColor = Color.Blue;
                break;
              }
          }

          Functions.GLPrint2D("+", UoTRender.PointToClient(Cursor.Position), curColor, Glut.GLUT_BITMAP_TIMES_ROMAN_24, -10, -15, true);
        }

        if (PrintTool) {
          Gl.glDisable(Gl.GL_TEXTURE_2D);
          Gl.glDisable(Gl.GL_FRAGMENT_PROGRAM_ARB);
          Functions.GLPrint2D(PrintToolStr, UoTRender.PointToClient(Cursor.Position), Color.White, Glut.GLUT_BITMAP_HELVETICA_18, 0, 0, true);
        }

        if (key_w) {
          if (CamXRot >= 90d | CamXRot <= -90) {
            GlobalVars.CamYPos += Math.Sin(CamXRotd) * CameraCoef;
          } else {
            GlobalVars.CamXPos -= Math.Sin(CamYRotd) * CameraCoef;
            GlobalVars.CamZPos += Math.Cos(CamYRotd) * CameraCoef;
            GlobalVars.CamYPos += Math.Sin(CamXRotd) * CameraCoef;
          }
        }

        if (key_s) {
          if (CamXRot >= 90d | CamXRot <= -90) {
            GlobalVars.CamYPos -= Math.Sin(CamXRotd) * CameraCoef;
          } else {
            GlobalVars.CamXPos += Math.Sin(CamYRotd) * CameraCoef;
            GlobalVars.CamZPos -= Math.Cos(CamYRotd) * CameraCoef;
            GlobalVars.CamYPos -= Math.Sin(CamXRotd) * CameraCoef;
          }
        }

        if (key_d) {
          GlobalVars.CamXPos -= Math.Cos(CamYRotd) * CameraCoef;
          GlobalVars.CamZPos -= Math.Sin(CamYRotd) * CameraCoef;
        }

        if (key_a) {
          GlobalVars.CamXPos += Math.Cos(CamYRotd) * CameraCoef;
          GlobalVars.CamZPos += Math.Sin(CamYRotd) * CameraCoef;
        }

        UpdateCamLabels();
        Gl.glPushMatrix();
        Gl.glLoadIdentity();
        Gl.glRotatef((float)CamXRot, 1.0f, 0.0f, 0.0f);
        Gl.glRotatef((float)CamYRot, 0.0f, 1.0f, 0.0f);
        Gl.glRotatef((float)CamZRot, 0.0f, 0.0f, 1.0f);
        Gl.glTranslated(GlobalVars.CamXPos, GlobalVars.CamYPos, GlobalVars.CamZPos);
        if (LoadedDataType == (int)Structs.FileTypes.MAP)
          DrawActorBoxes(false);
        if (RenderGraphics)
          DrawDLArray(GlobalVars.N64DList, (int)ToolID.NONE);
        if (RenderCollision)
          DrawCollision(CollisionPolies, CollisionVerts, false);
        Gl.glPopMatrix();
        UoTRender.SwapBuffers();
        if (MouseChanged & !HoldCursor) {
          MouseOver = true;
          if (ToolModes.CurrentTool < (int)ToolID.DLIST) {
            PickItem(ToolModes.CurrentTool, default);
          }
        }
      } catch (Exception err) {
        GenericCatch(err);
      }
    }

    private void GenericCatch(Exception err) {
      Interaction.MsgBox("Error!" + Environment.NewLine + Environment.NewLine + "From routine: " + err.TargetSite.Name + "()" + Environment.NewLine + Environment.NewLine + "Details: " + err.Message, MsgBoxStyle.Critical, "Bug");
    }

    private void UpdateCamLabels() {
      CamXLabel.Text = "Cam X: " + GlobalVars.CamXPos.ToString();
      CamYLabel.Text = "Cam Y: " + GlobalVars.CamYPos.ToString();
      CamZLabel.Text = "Cam Z: " + GlobalVars.CamZPos.ToString();
    }

    private void DrawActorBoxes(bool SelectionMode) {
      Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_FILL);
      Functions.SetOGLDefaultParams();
      if (RoomActors.Length > 0 & !HideActors[0]) {
        for (int i = 0, loopTo = RoomActors.Length - 1; i <= loopTo; i++) {
          Gl.glPushMatrix();
          Gl.glTranslatef(RoomActors[i].x, RoomActors[i].y + 16, RoomActors[i].z);
          Gl.glRotatef(RoomActors[i].xr / 180, 1.0f, 0.0f, 0.0f);
          Gl.glRotatef(RoomActors[i].yr / 180, 0.0f, 1.0f, 0.0f);
          Gl.glRotatef(RoomActors[i].zr / 180, 0.0f, 0.0f, 1.0f);
          if (SelectionMode) {
            if (ToolModes.NoDepthTest)
              Gl.glDisable(Gl.GL_DEPTH_TEST);
            Gl.glColor3ub(RoomActors[i].pickR, RoomActors[i].pickG, RoomActors[i].pickB);
            Glut.glutSolidCube(ActorScaleP);
            if (ToolModes.NoDepthTest)
              Gl.glEnable(Gl.GL_DEPTH_TEST);
          } else {
            Gl.glScalef(ActorScale, ActorScale, ActorScale);
            Gl.glCallList(ActorBoxDList);
          }

          if (!GlobalVars.SelectedRoomActors.Contains(i)) {
            Gl.glColor3f(0f, 0f, 0f);
            Gl.glLineWidth(2f);
          } else {
            if (!HideActors[2]) {
              Gl.glCallList(AxisGuideDList);
            }

            if (GlobalVars.SelectedRoomActors.IndexOf(i) > 0)
              Gl.glColor3f(0.0f, 0.6f, 0.2f);
            else
              Gl.glColor3f(1f, 0f, 0f);
            Gl.glLineWidth(3f);
          }

          Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_LINE);
          Glut.glutSolidCube(ActorScaleW);
          Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_FILL);
          Gl.glLineWidth(1f);
          Gl.glPopMatrix();
        }
      }

      if (SceneActors.Length > 0 & !HideActors[1]) {
        for (int i = 0, loopTo1 = SceneActors.Length - 1; i <= loopTo1; i++) {
          Gl.glPushMatrix();
          Gl.glTranslatef(SceneActors[i].x, SceneActors[i].y + 16, SceneActors[i].z);
          Gl.glRotatef(SceneActors[i].yr / 180, 0.0f, 1.0f, 0.0f);
          if (SelectionMode) {
            Gl.glColor3ub(SceneActors[i].pickR, SceneActors[i].pickG, SceneActors[i].pickB);
            Glut.glutSolidCube(ActorScaleP);
          } else {
            Gl.glScalef(ActorScale, ActorScale, ActorScale);
            Gl.glCallList(ActorBoxDList);
          }

          if (!GlobalVars.SelectedSceneActors.Contains(i)) {
            Gl.glColor3f(0f, 0f, 0f);
            Gl.glLineWidth(2f);
          } else {
            if (!HideActors[2]) {
              Gl.glCallList(AxisGuideDList);
            }

            if (GlobalVars.SelectedRoomActors.IndexOf(i) > 0)
              Gl.glColor3f(0.0f, 0.6f, 0.2f);
            else
              Gl.glColor3f(1f, 0f, 0f);
            Gl.glLineWidth(3f);
          }

          Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_LINE);
          Glut.glutSolidCube(2.06d);
          Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_FILL);
          Gl.glLineWidth(1f);
          Gl.glPopMatrix();
        }
      }

      if (wireframe) {
        Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_LINE);
      }
    }

    private void DrawDLArray(Structs.N64DisplayList[] DLists, int SelectionMode) {
      if (Conversions.ToBoolean(SelectionMode)) {
        GlobalVars.DLParser.ParseMode = (int)F3DEX2_Parser.Parse.GEOMETRY;
      } else {
        GlobalVars.DLParser.ParseMode = (int)F3DEX2_Parser.Parse.EVERYTHING;
      }

      if (!HasLimbs) {
        for (int i = 0, loopTo = DLists.Length - 1; i <= loopTo; i++)
          DrawDL(i, SelectionMode);
      } else {
        CurrLimb = 0;
        Gl.glPushMatrix();
        if (AnimationEntries is object) {
          {
            var withBlock = AnimationEntries[CurrAnimation];
            Gl.glTranslatef((float)Functions.AngleToRad(withBlock.Angles[(int)withBlock.XTrans]), (float)Functions.AngleToRad(withBlock.Angles[(int)withBlock.YTrans]), (float)Functions.AngleToRad(withBlock.Angles[(int)withBlock.ZTrans]));
          }
        }

        var loopTo1 = LimbEntries.Length - 1;
        for (CurrLimb = 0; CurrLimb <= loopTo1; CurrLimb++) {
          {
            var withBlock1 = BoneColorFactor;
            withBlock1.r = 0;
            withBlock1.g = 0;
            withBlock1.b = 0;
          }

          DrawJoint(CurrLimb);
        }

        Gl.glPopMatrix();
      }
    }

    private void DrawJoint(int id) {
      {
        var withBlock = LimbEntries[id];
        if (id + 1 < LimbEntries.Length - 1) {
          CurrLimb = id + 1;
        } else {
          CurrLimb = id;
        }

        int dlIndex = -1;
        if (withBlock.DisplayList > default(uint)) {
          dlIndex = Functions.SearchDLCache(GlobalVars.N64DList, withBlock.DisplayList); // index of limb's requested DL, -1 if none found
        }

        if (ShowBones) { // draw bones
          Gl.glDepthRange(0d, 0d);
          Gl.glLineWidth(9f);
          Gl.glBegin(Gl.GL_LINES);
          Gl.glColor3f(1f, 1f, 1f);
          Gl.glVertex3f(0f, 0f, 0f);
          Gl.glVertex3f(withBlock.x, withBlock.y, withBlock.z);
          Gl.glEnd();
          Gl.glDepthRange(0d, -0.5d);
          Gl.glPointSize(11f);
          Gl.glBegin(Gl.GL_POINTS);
          Gl.glColor3f(0f, 0f, 0f);
          Gl.glVertex3f(withBlock.x, withBlock.y, withBlock.z);
          Gl.glEnd();
          Gl.glPointSize(8f);
          Gl.glBegin(Gl.GL_POINTS);
          Gl.glColor3ub(BoneColorFactor.r, BoneColorFactor.g, BoneColorFactor.b);
          Gl.glVertex3f(withBlock.x, withBlock.y, withBlock.z);
          Gl.glEnd();
          Gl.glPointSize(1f);
          Gl.glLineWidth(1f);
          Gl.glDepthRange(0d, 1d);
        }

        Gl.glPushMatrix();
        Gl.glTranslatef(withBlock.x, withBlock.y, withBlock.z); // translate to given coordinates
        if (GlobalVars.ZAnimationCounter.Advancing) {
          var argCurrentFrame = CurrentFrame;
          GlobalVars.AnimParser.Animate(AnimationEntries, CurrAnimation, LoopAnimation, ref argCurrentFrame);
          CurrentFrame = argCurrentFrame;
          UpdateAnimationTab();
        }

        if (AnimationEntries is object) {
          {
            var withBlock1 = GlobalVars.AnimParser;
            Gl.glRotatef(withBlock1.GetTrackRot(AnimationEntries[CurrAnimation], GlobalVars.ZAnimationCounter, 2, id), 0f, 0f, 1f);
            Gl.glRotatef(withBlock1.GetTrackRot(AnimationEntries[CurrAnimation], GlobalVars.ZAnimationCounter, 1, id), 0f, 1f, 0f);
            Gl.glRotatef(withBlock1.GetTrackRot(AnimationEntries[CurrAnimation], GlobalVars.ZAnimationCounter, 0, id), 1f, 0f, 0f);
          }
        }

        if (dlIndex > -1) {
          DrawDL(dlIndex, Conversions.ToInteger(false));
        }

        if (withBlock.c0 > -1) {
          BoneColorFactor.r = 255;
          BoneColorFactor.g = 0;
          BoneColorFactor.b = 0;
          DrawJoint(withBlock.c0);
        } else {
          BoneColorFactor.r = 255;
          BoneColorFactor.g = 255;
          BoneColorFactor.b = 255;
        }

        Gl.glPopMatrix();
        if (withBlock.c1 > -1) {
          BoneColorFactor.r = 0;
          BoneColorFactor.g = 0;
          BoneColorFactor.b = 255;
          DrawJoint(withBlock.c1);
        } else {
          BoneColorFactor.r = 255;
          BoneColorFactor.g = 255;
          BoneColorFactor.b = 255;
        }
      }
    }

    private void UpdateAnimationTab() {
      FrameNo.Text = GlobalVars.ZAnimationCounter.CurrFrame.ToString() + "/" + CurrentFrame.Maximum;
      AnimationElapse.Text = Conversions.ToInteger(GlobalVars.ZAnimationCounter.ElapsedSeconds.ToString()) + ":" + Conversions.ToInteger(GlobalVars.ZAnimationCounter.ElapsedMilliseconds.ToString()) + "s";
    }

    private void DrawDL(int index, int SelectionMode) {
      if (!GlobalVars.N64DList[index].Skip) {
        if (SelectionMode == (int)ToolID.NONE) {
          GlobalVars.DLParser.ParseDL(GlobalVars.N64DList[index]);
          if (GlobalVars.N64DList[index].Highlight) {
            GlobalVars.DLParser.ParseMode = (int)F3DEX2_Parser.Parse.GEOMETRY;
            Gl.glBindProgramARB(Gl.GL_FRAGMENT_PROGRAM_ARB, GlobalVars.HighlightProg);
            Gl.glEnable(Gl.GL_FRAGMENT_PROGRAM_ARB);
            Gl.glEnable(Gl.GL_BLEND);
            Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);
            GlobalVars.DLParser.ParseDL(GlobalVars.N64DList[index]);
            GlobalVars.DLParser.ParseMode = (int)F3DEX2_Parser.Parse.EVERYTHING;
          }
        } else if (SelectionMode == (int)ToolID.DLIST) {
          Gl.glColor3ub(GlobalVars.N64DList[index].PickCol.r, GlobalVars.N64DList[index].PickCol.g, GlobalVars.N64DList[index].PickCol.b);
          GlobalVars.DLParser.ParseDL(GlobalVars.N64DList[index]);
          ReadPixel = MousePixelRead((int)NewMouseX, (int)NewMouseY);
          if (ReadPixel[0] == GlobalVars.N64DList[index].PickCol.r & ReadPixel[1] == GlobalVars.N64DList[index].PickCol.g & ReadPixel[2] == GlobalVars.N64DList[index].PickCol.b) {
            DListSelection.SelectedIndex = index + 1;
            EditingTabs.SelectedTab = EditingTabs.TabPages["DLTab"];
            ToolModes.SelectedItemType = (int)ToolID.DLIST;
            return;
          }

          ToolModes.SelectedItemType = (int)ToolID.NONE;
        }
      }
    }

    private void DrawCollision(Structs.PolygonCollision[] Polygons, Structs.CollisionVertex Vertices, bool SelectionMode) {
      Gl.glDisable(Gl.GL_TEXTURE_2D);
      Gl.glDisable(Gl.GL_FRAGMENT_PROGRAM_ARB);
      Gl.glDisable(Gl.GL_CULL_FACE);
      Gl.glEnable(Gl.GL_BLEND);
      Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);
      Gl.glAlphaFunc(Gl.GL_GREATER, 0.0f);
      if (!SelectionMode) {
        Gl.glEnable(Gl.GL_POLYGON_OFFSET_LINE);
        Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_LINE);
        Gl.glPolygonOffset((float)-5.0d, (float)-5.0d);
        Gl.glBegin(Gl.GL_TRIANGLES);
        Gl.glColor3f(0f, 0f, 0f);
        for (int i = 0, loopTo = Polygons.Length - 1; i <= loopTo; i++) {
          {
            var withBlock = Polygons[i];
            ColA = (uint)withBlock.A;
            ColB = (uint)withBlock.B;
            ColC = (uint)withBlock.C;
          }

          Gl.glVertex3i(Conversions.ToInteger(Vertices.x[(int)ColA]), Conversions.ToInteger(Vertices.y[(int)ColA]), Conversions.ToInteger(Vertices.z[(int)ColA]));
          Gl.glVertex3i(Conversions.ToInteger(Vertices.x[(int)ColB]), Conversions.ToInteger(Vertices.y[(int)ColB]), Conversions.ToInteger(Vertices.z[(int)ColB]));
          Gl.glVertex3i(Conversions.ToInteger(Vertices.x[(int)ColC]), Conversions.ToInteger(Vertices.y[(int)ColC]), Conversions.ToInteger(Vertices.z[(int)ColC]));
        }

        Gl.glEnd();
        Gl.glDisable(Gl.GL_POLYGON_OFFSET_LINE);
        Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_FILL);
        Gl.glPolygonOffset(-6, -6);
        Gl.glEnable(Gl.GL_POLYGON_OFFSET_FILL);
        Gl.glBegin(Gl.GL_TRIANGLES);
        for (int i = 0, loopTo1 = Polygons.Length - 1; i <= loopTo1; i++) {
          {
            var withBlock1 = Polygons[i];
            ColA = (uint)withBlock1.A;
            ColB = (uint)withBlock1.B;
            ColC = (uint)withBlock1.C;
          }

          Gl.glColor4f(1f, CollisionTriColor[i].g, CollisionTriColor[i].b, 0.25f);
          Gl.glVertex3i(Conversions.ToInteger(Vertices.x[(int)ColA]), Conversions.ToInteger(Vertices.y[(int)ColA]), Conversions.ToInteger(Vertices.z[(int)ColA]));
          Gl.glVertex3i(Conversions.ToInteger(Vertices.x[(int)ColB]), Conversions.ToInteger(Vertices.y[(int)ColB]), Conversions.ToInteger(Vertices.z[(int)ColB]));
          Gl.glVertex3i(Conversions.ToInteger(Vertices.x[(int)ColC]), Conversions.ToInteger(Vertices.y[(int)ColC]), Conversions.ToInteger(Vertices.z[(int)ColC]));
        }

        Gl.glEnd();
        switch (ToolModes.CurrentTool) {
          case (int)ToolID.VERTEX: {
              Gl.glPointSize(14f);
              Gl.glBegin(Gl.GL_POINTS);
              for (int i = 0, loopTo2 = Vertices.x.Count - 1; i <= loopTo2; i++) {
                if (SelectedCollisionVert.Contains(i))
                  Gl.glColor3f(1f, 0f, 0f);
                else
                  Gl.glColor3f(1f, 1f, 1f);
                Gl.glVertex3i(Conversions.ToInteger(Vertices.x[i]), Conversions.ToInteger(Vertices.y[i]), Conversions.ToInteger(Vertices.z[i]));
              }

              Gl.glEnd();
              Gl.glPointSize(11f);
              Gl.glBegin(Gl.GL_POINTS);
              for (int i = 0, loopTo3 = Vertices.x.Count - 1; i <= loopTo3; i++) {
                if (SelectedCollisionVert.Contains(i))
                  Gl.glColor3f(0f, 0f, 1f);
                else
                  Gl.glColor3f(0f, 0f, 0f);
                Gl.glVertex3i(Conversions.ToInteger(Vertices.x[i]), Conversions.ToInteger(Vertices.y[i]), Conversions.ToInteger(Vertices.z[i]));
              }

              Gl.glEnd();
              break;
            }

          case (int)ToolID.COLTRI: {
              break;
            }
        }
      } else {
        switch (ToolModes.CurrentTool) {
          case (int)ToolID.VERTEX: {
              Gl.glDisable(Gl.GL_BLEND);
              Gl.glPointSize(23f);
              Gl.glBegin(Gl.GL_POINTS);
              for (int i = 0, loopTo4 = Vertices.x.Count - 1; i <= loopTo4; i++) {
                Gl.glColor3ub(Conversions.ToByte(Vertices.VertR[i]), Conversions.ToByte(Vertices.VertG[i]), Conversions.ToByte(Vertices.VertB[i]));
                Gl.glVertex3i(Conversions.ToInteger(Vertices.x[i]), Conversions.ToInteger(Vertices.y[i]), Conversions.ToInteger(Vertices.z[i]));
              }

              Gl.glEnd();
              break;
            }

          case (int)ToolID.EDGE: {
              int curedge = 0;
              Gl.glEnable(Gl.GL_POLYGON_OFFSET_LINE);
              Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_LINE);
              Gl.glPolygonOffset((float)-8.0d, (float)-8.0d);
              Gl.glLineWidth(10f);
              Gl.glBegin(Gl.GL_TRIANGLES);
              for (int i = 0, loopTo5 = Vertices.EdgeR.Count - 1; i <= loopTo5; i++) {
                ColA = (uint)Polygons[curedge].A;
                ColB = (uint)Polygons[curedge + 1].B;
                Gl.glColor3ub(Conversions.ToByte(Vertices.EdgeR[i]), Conversions.ToByte(Vertices.EdgeG[i]), Conversions.ToByte(Vertices.EdgeB[i]));
                Gl.glVertex3i(Conversions.ToInteger(Vertices.x[(int)ColA]), Conversions.ToInteger(Vertices.y[(int)ColA]), Conversions.ToInteger(Vertices.z[(int)ColA]));
                Gl.glVertex3i(Conversions.ToInteger(Vertices.x[(int)ColB]), Conversions.ToInteger(Vertices.y[(int)ColB]), Conversions.ToInteger(Vertices.z[(int)ColB]));
                curedge += 1;
              }

              Gl.glEnd();
              Gl.glDisable(Gl.GL_POLYGON_OFFSET_LINE);
              Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_FILL);
              break;
            }

          case (int)ToolID.COLTRI: {
              Gl.glPolygonOffset(-8, -8);
              Gl.glEnable(Gl.GL_POLYGON_OFFSET_FILL);
              Gl.glBegin(Gl.GL_TRIANGLES);
              for (int i = 0, loopTo6 = Polygons.Length - 1; i <= loopTo6; i++) {
                {
                  var withBlock2 = Polygons[i];
                  ColA = (uint)withBlock2.A;
                  ColB = (uint)withBlock2.B;
                  ColC = (uint)withBlock2.C;
                  Gl.glColor3ub(withBlock2.pickR, withBlock2.pickG, withBlock2.pickB);
                  Gl.glVertex3i(Conversions.ToInteger(Vertices.x[(int)ColA]), Conversions.ToInteger(Vertices.y[(int)ColA]), Conversions.ToInteger(Vertices.z[(int)ColA]));
                  Gl.glVertex3i(Conversions.ToInteger(Vertices.x[(int)ColB]), Conversions.ToInteger(Vertices.y[(int)ColB]), Conversions.ToInteger(Vertices.z[(int)ColB]));
                  Gl.glVertex3i(Conversions.ToInteger(Vertices.x[(int)ColC]), Conversions.ToInteger(Vertices.y[(int)ColC]), Conversions.ToInteger(Vertices.z[(int)ColC]));
                }
              }

              Gl.glEnd();
              Gl.glDisable(Gl.GL_POLYGON_OFFSET_FILL);
              break;
            }
        }
      }

      Functions.SetOGLDefaultParams();
    }

    public void FixCollision() {
      cfix.Start();
      cfix.WaitForExit();
      File.Delete(Application.StartupPath + @"\collision_fixer.ini");
      File.Delete(Application.StartupPath + @"\romname.ini");
    }

    private void SimpleOpenGlControl1_KeyDown(object sender, KeyEventArgs e) {
      switch (e.KeyCode) {
        case Keys.E: {
            CameraSensitivity(true);
            break;
          }

        case Keys.Q: {
            CameraSensitivity(false);
            break;
          }

        case Keys.ControlKey: {
            if (!key_ctrl) {
              key_ctrl = true;
            }

            break;
          }

        case Keys.I: {
            ButtonPress = 1;
            ActorInputTimer.Start();
            break;
          }

        case Keys.K: {
            ButtonPress = 2;
            ActorInputTimer.Start();
            break;
          }

        case Keys.J: {
            ButtonPress = 0;
            ActorInputTimer.Start();
            break;
          }

        case Keys.L: {
            ButtonPress = 3;
            ActorInputTimer.Start();
            break;
          }

        case Keys.U: {
            ButtonPress = 4;
            ActorInputTimer.Start();
            break;
          }

        case Keys.O: {
            ButtonPress = 5;
            ActorInputTimer.Start();
            break;
          }

        case var @case when @case == Keys.Q: {
            if (!key_q)
              key_q = true;
            break;
          }

        case var case1 when case1 == Keys.E: {
            if (!key_e)
              key_e = true;
            break;
          }

        case Keys.W: {
            if (!key_w)
              key_w = true;
            break;
          }

        case Keys.D: {
            if (!key_d)
              key_d = true;
            break;
          }

        case Keys.S: {
            if (!key_s)
              key_s = true;
            break;
          }

        case Keys.A: {
            if (!key_a)
              key_a = true;
            break;
          }

        case Keys.F1: {
            ToggleWire();
            break;
          }

        case Keys.T: {
            ButtonPress = 6;
            ActorInputTimer.Start();
            break;
          }

        case Keys.Y: {
            ButtonPress = 7;
            ActorInputTimer.Start();
            break;
          }

        case Keys.G: {
            ButtonPress = 8;
            ActorInputTimer.Start();
            break;
          }

        case Keys.H: {
            ButtonPress = 9;
            ActorInputTimer.Start();
            break;
          }

        case Keys.B: {
            if (LoadedDataType == (int)Structs.FileTypes.MAP) {
              ResetActors(false);
            }

            break;
          }

        case Keys.R: {
            if (key_ctrl) {
              if (RenderGraphics & !RenderCollision) {
                RenderGraphics = false;
                RenderCollision = true;
                ViewingMeshToolStripMenuItem1.Checked = false;
                CollisionMeshToolStripMenuItem.Checked = true;
              } else if (RenderGraphics & RenderCollision) {
                RenderGraphics = true;
                RenderCollision = false;
                ViewingMeshToolStripMenuItem1.Checked = true;
                CollisionMeshToolStripMenuItem.Checked = false;
              } else {
                RenderGraphics = true;
                RenderCollision = true;
                ViewingMeshToolStripMenuItem1.Checked = true;
                CollisionMeshToolStripMenuItem.Checked = true;
              }
            } else {
              ResetView();
            }

            break;
          }

        case Keys.Alt: {
            key_alt = true;
            break;
          }

        case Keys.D1: {
            SwitchTool((int)ToolID.CAMERA);
            break;
          }

        case Keys.D2: {
            SwitchTool((int)ToolID.ACTOR);
            break;
          }

        case Keys.D3: {
            SwitchTool((int)ToolID.VERTEX);
            break;
          }

        case Keys.D4: {
            SwitchTool((int)ToolID.EDGE);
            break;
          }

        case Keys.D5: {
            SwitchTool((int)ToolID.FACE);
            break;
          }

        case Keys.D6: {
            SwitchTool((int)ToolID.COLTRI);
            break;
          }

        case Keys.D7: {
            SwitchTool((int)ToolID.DLIST);
            break;
          }

        case Keys.P: {
            if (key_ctrl & LoadedDataType == (int)Structs.FileTypes.MAP) {
              My.MyProject.Forms.ActorPresets.Show();
              My.MyProject.Forms.ActorPresets.Focus();
              key_ctrl = false;
            }

            break;
          }
      }
    }

    public void ToggleWire() {
      if (!wireframe) {
        wireframe = true;
        Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_LINE);
      } else {
        wireframe = false;
        Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_FILL);
      }
    }

    public void BuildAxis() {
      AxisGuideDList = (uint)Gl.glGenLists(1);
      Gl.glNewList(AxisGuideDList, Gl.GL_COMPILE);
      Gl.glBegin(Gl.GL_LINES);
      Gl.glColor3f(0f, 0f, 1f);
      Gl.glVertex3f(420f, 0.1f, 0.1f);
      Gl.glVertex3f(-420, 0.1f, 0.1f);
      Gl.glEnd();
      Gl.glBegin(Gl.GL_LINES);
      Gl.glColor3f(1f, 0f, 0f);
      Gl.glVertex3f(0.1f, 420f, 0.1f);
      Gl.glVertex3f(0.1f, -420, 0.1f);
      Gl.glEnd();
      Gl.glBegin(Gl.GL_LINES);
      Gl.glColor3f(0f, 1f, 0f);
      Gl.glVertex3f(0.1f, 0.1f, 420f);
      Gl.glVertex3f(0.1f, 0.1f, -420);
      Gl.glVertex3f(0.1f, 0.1f, 420f);
      Gl.glEnd();
      Gl.glEndList();
      Gl.glLineWidth(1f);
      ActorBoxDList = (uint)Gl.glGenLists(1);
      Gl.glNewList(ActorBoxDList, Gl.GL_COMPILE);
      Gl.glBegin(Gl.GL_QUADS);
      // top
      Gl.glColor3f(1f, 1f, 1f);
      Gl.glVertex3f(1.0f, 1.0f, -1.0f);
      Gl.glVertex3f(-1.0f, 1.0f, -1.0f);
      Gl.glVertex3f(-1.0f, 1.0f, 1.0f);
      Gl.glVertex3f(1.0f, 1.0f, 1.0f);
      // bottom
      Gl.glColor3f(0f, 0f, 0f);
      Gl.glVertex3f(1.0f, -1.0f, 1.0f);
      Gl.glVertex3f(-1.0f, -1.0f, 1.0f);
      Gl.glVertex3f(-1.0f, -1.0f, -1.0f);
      Gl.glVertex3f(1.0f, -1.0f, -1.0f);
      // front
      Gl.glColor3f(1f, 0f, 0f);
      Gl.glVertex3f(1.0f, 1.0f, 1.0f);
      Gl.glVertex3f(-1.0f, 1.0f, 1.0f);
      Gl.glVertex3f(-1.0f, -1.0f, 1.0f);
      Gl.glVertex3f(1.0f, -1.0f, 1.0f);
      // back
      Gl.glColor3f(0f, 1f, 0f);
      Gl.glVertex3f(1.0f, -1.0f, -1.0f);
      Gl.glVertex3f(-1.0f, -1.0f, -1.0f);
      Gl.glVertex3f(-1.0f, 1.0f, -1.0f);
      Gl.glVertex3f(1.0f, 1.0f, -1.0f);
      // left
      Gl.glColor3f(1f, 1f, 0f);
      Gl.glVertex3f(-1.0f, 1.0f, 1.0f);
      Gl.glVertex3f(-1.0f, 1.0f, -1.0f);
      Gl.glVertex3f(-1.0f, -1.0f, -1.0f);
      Gl.glVertex3f(-1.0f, -1.0f, 1.0f);
      // right
      Gl.glColor3f(0f, 0f, 1f);
      Gl.glVertex3f(1.0f, 1.0f, -1.0f);
      Gl.glVertex3f(1.0f, 1.0f, 1.0f);
      Gl.glVertex3f(1.0f, -1.0f, 1.0f);
      Gl.glVertex3f(1.0f, -1.0f, -1.0f);
      Gl.glEnd();
      Gl.glEndList();
    }

    private void QuitToolStripMenuItem_Click(object sender, EventArgs e) {
      Close();
    }

    private void LoadZOBJToolStripMenuItem_Click(object sender, EventArgs e) {
      LoadROM.ShowDialog();
    }

    private void Form1_Load(object sender, EventArgs e) {
      try {
        Glut.glutInit();
        Wgl.ReloadFunctions();
        Gl.ReloadFunctions();
        UoTRender.CreateGraphics();
        string extstr = Gl.glGetString(Gl.GL_EXTENSIONS).ToLower();
        GlobalVars.GLExtensions.GLMultiTexture = extstr.Contains("gl_arb_multitexture");
        GlobalVars.GLExtensions.GLFragProg = extstr.Contains("gl_arb_fragment_program");
        GlobalVars.GLExtensions.GLAnisotropic = extstr.Contains("gl_ext_texture_filter_anisotropic");
        GlobalVars.GLExtensions.GLSL = extstr.Contains("gl_arb_fragment_shader");
        GlobalVars.GLExtensions.GLMultiSample = extstr.Contains("gl_arb_multisample");
        GlobalVars.WGLExtensions.WGLMultiSample = Wgl.wglGetProcAddress("WGL_ARB_Multisample") != default;
        var blank_tex = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF };
        Gl.glBindTexture(Gl.GL_TEXTURE_2D, 2);
        Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGBA, 1, 1, 0, Gl.GL_RGBA, Gl.GL_UNSIGNED_BYTE, blank_tex);
        AnimationFPS.Value = 30m;
        {
          var withBlock = CollisionVerts;
          withBlock.x = new List<double>();
          withBlock.y = new List<double>();
          withBlock.z = new List<double>();
          withBlock.VertR = new ArrayList();
          withBlock.VertG = new ArrayList();
          withBlock.VertB = new ArrayList();
          withBlock.FaceR = new ArrayList();
          withBlock.FaceG = new ArrayList();
          withBlock.FaceB = new ArrayList();
          withBlock.EdgeR = new ArrayList();
          withBlock.EdgeG = new ArrayList();
          withBlock.EdgeB = new ArrayList();
        }

        CollisionPolies = new Structs.PolygonCollision[0];
        if (GlobalVars.GLExtensions.GLAnisotropic) {
          GlobalVars.RenderToggles.Anisotropic = true;
          GlobalVars.GLExtensions.AnisotropicSamples = new float[1];
          Gl.glGetFloatv(Gl.GL_MAX_TEXTURE_MAX_ANISOTROPY_EXT, GlobalVars.GLExtensions.AnisotropicSamples);
        }

        var highlightbytes = System.Text.Encoding.ASCII.GetBytes(GlobalVars.HighlightShader);
        if (GlobalVars.GLExtensions.GLFragProg) {
          Gl.glGenProgramsARB(1, out GlobalVars.HighlightProg);
          Gl.glBindProgramARB(Gl.GL_FRAGMENT_PROGRAM_ARB, GlobalVars.HighlightProg);
          Gl.glProgramStringARB(Gl.GL_FRAGMENT_PROGRAM_ARB, Gl.GL_PROGRAM_FORMAT_ASCII_ARB, highlightbytes.Length, highlightbytes);
        }

        // EditingTabs.TabPages.Remove(GraphicsTab)

        AppDirectory = Application.StartupPath;
        if (!File.Exists(AppDirectory + "/uot.ini")) {
          var createini = File.Create(AppDirectory + "/uot.ini");
          createini.Dispose();
        }

        UoTIniFile = new iniwriter(AppDirectory + "/uot.ini");
        BuildAxis();
        ToolModes = new Structs.Tools();
        SwitchTool((int)ToolID.CAMERA);
        {
          var withBlock1 = cfix.StartInfo;
          withBlock1.UseShellExecute = true;
          withBlock1.CreateNoWindow = true;
          withBlock1.WindowStyle = ProcessWindowStyle.Hidden;
          withBlock1.FileName = AppDirectory + @"\ext\collision_fixer.exe";
          withBlock1.WorkingDirectory = AppDirectory + @"\ext";
        }

        {
          var withBlock2 = crc.StartInfo;
          withBlock2.UseShellExecute = true;
          withBlock2.CreateNoWindow = true;
          withBlock2.WindowStyle = ProcessWindowStyle.Hidden;
          withBlock2.FileName = AppDirectory + @"\ext\rn64crc.exe";
        }

        string winw = UoTIniFile.GetString("Settings", "WinResW", null);
        string winh = UoTIniFile.GetString("Settings", "WinResH", null);
        string toolst = UoTIniFile.GetString("Settings", "ToolSensitivity", null);
        string camst = UoTIniFile.GetString("Settings", "CameraSpeed", null);
        GlobalVars.DefROM = UoTIniFile.GetString("Settings", "DefaultROM", null);
        if (string.IsNullOrEmpty(GlobalVars.DefROM) | !File.Exists(GlobalVars.DefROM)) {
          LoadROM.ShowDialog();
        }

        if (!string.IsNullOrEmpty(toolst)) {
          if (Conversions.ToInteger(toolst) <= 15 & Conversions.ToInteger(toolst) >= 1) {
            TrackBar4.Value = Conversions.ToInteger(toolst);
          } else {
            TrackBar4.Value = 4;
          }
        } else {
          TrackBar4.Value = 4;
        }

        if (!string.IsNullOrEmpty(camst)) {
          if (Conversions.ToInteger(camst) <= 40 & Conversions.ToInteger(camst) >= 1) {
            TrackBar1.Value = Conversions.ToInteger(camst);
          } else {
            TrackBar1.Value = 20;
          }
        } else {
          TrackBar1.Value = 20;
        }

        if (!string.IsNullOrEmpty(winw) & !string.IsNullOrEmpty(winh)) {
          Size = new Size(Conversions.ToInteger(winw), Conversions.ToInteger(winh));
        } else {
          Size = new Size(1168, 676);
        }

        GlobalVars.DLParser.Initialize();
        GlobalVars.args = Environment.GetCommandLineArgs();
        if (GlobalVars.args.Length == 2) {
          LoadROM.FileName = GlobalVars.args[1];
          Start(false);
        } else if (File.Exists(GlobalVars.DefROM)) {
          LoadROM.FileName = GlobalVars.DefROM;
          Start(false);
        }

        GlobalVars.args = new string[0];
        Show();
        Focus();
        Initialize();
      } catch (Exception err) {
      }
    }

    private void ResetView() { // Reset to default view
      CamXRot = 0.0d;
      CamYRot = 0.0d;
      CamZRot = 0.0d;
      GlobalVars.CamXPos = 0.0d;
      GlobalVars.CamYPos = 0.0d;
      GlobalVars.CamZPos = 0.0d;
    }

    private Structs.ActorDB[] ReadActorDBHuman(string fn) {
      if (File.Exists(fn)) {
        Structs.ActorDB[] tDB;
        var tReader = new StreamReader(fn);
        string[] Tokens;
        string[] nextTokens;
        int actorCnt = 0;
        int varCnt = 0;
        tDB = new Structs.ActorDB[0];

        readMain:
        ;
        
        while (tReader.Peek() != -1) {
          Tokens = tReader.ReadLine().Split(' ');
          if (Tokens.Length > 1) {
            string testOne = Tokens[0];
            int intTest = 0;
            if (int.TryParse(testOne, out intTest)) {
              goto readActor;
            } else {
              goto readMain;
            }

            readActor:
            ;
            Array.Resize(ref tDB, actorCnt + 1);
            {
              var withBlock = tDB[actorCnt];
              withBlock.no = (uint)int.Parse(Tokens[0], NumberStyles.HexNumber);
              if (int.TryParse(Tokens[1], out intTest)) {
                if (Tokens[1].Contains("+")) {
                  withBlock.grp = (uint)int.Parse(Strings.Mid(Tokens[1], 1, 4), NumberStyles.HexNumber);
                } else {
                  withBlock.grp = (uint)int.Parse(Tokens[1], NumberStyles.HexNumber);
                }

                withBlock.desc = "";
                if (Tokens.Length > 2) {
                  for (int i = 2, loopTo = Tokens.Length - 1; i <= loopTo; i++)
                    withBlock.desc += Tokens[i] + " ";
                }
              }
            }

            nextTokens = tReader.ReadLine().Split(' ');
            if (nextTokens.Length > 1) {
              readVars:
              ;
              while (string.IsNullOrEmpty(nextTokens[0]) & CultureInfo.CurrentCulture.CompareInfo.Compare(nextTokens[1], "-", CompareOptions.IgnoreCase | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth) == 0) {
                Array.Resize(ref tDB[actorCnt].var, varCnt + 1);
                {
                  var withBlock1 = tDB[actorCnt].var[varCnt];
                  int argresult = (int)withBlock1.var;
                  int.TryParse(nextTokens[2], out argresult);
                  withBlock1.desc = "";
                  if (withBlock1.var > -1 & CultureInfo.CurrentCulture.CompareInfo.Compare(nextTokens[3], "=", CompareOptions.IgnoreCase | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth) == 0) {
                    for (int I = 4, loopTo1 = nextTokens.Length - 1; I <= loopTo1; I++)
                      withBlock1.desc += nextTokens[I] + " ";
                  }
                }

                varCnt += 1;
                nextTokens = tReader.ReadLine().Split(' ');
                if (nextTokens.Length <= 1) {
                  break;
                }
              }
            }

            varCnt = 0;
          } else {
            goto readMain;
          }

          actorCnt += 1;
        }

        return tDB;
      }

      return default;
    }

    private void PopulateNumContext(Structs.ActorDB[] DB) {
    }

    private void PopulateVarContext(Structs.ActorDB[] DB, int Actor) {
      for (int I = 0, loopTo = DB[Actor].var.Length - 1; I <= loopTo; I++)
        VarContextMenu.Items.Add(DB[Actor].var[I].desc);
    }

    private void SwitchGame(int game) {
      string curline = "";
      switch (game) {
        case 0: {
            GlobalVars.ExtraDataPrefix = @"\ext\OoT";
            break;
          }

        case 1: {
            GlobalVars.ExtraDataPrefix = @"\ext\MM";
            break;
          }
      }

      if (File.Exists(AppDirectory + GlobalVars.ExtraDataPrefix + @"\oot_actors_human.txt")) {
        GlobalVars.ActorDataBase = ReadActorDBHuman(AppDirectory + GlobalVars.ExtraDataPrefix + @"\oot_actors_human.txt");
      } else {
        GlobalVars.ActorDataBase = new Structs.ActorDB[0];
      }

      ActorDBGroups.Clear();
      ActorDBNumber.Clear();
      ActorDBVars.Clear();
      ActorDBDesc.Clear();
      Objects.Clear();
      ObjectsDesc.Clear();
      if (File.Exists(AppDirectory + GlobalVars.ExtraDataPrefix + @"\objlist.txt")) {
        var objfile = new StreamReader(AppDirectory + GlobalVars.ExtraDataPrefix + @"\objlist.txt");
        while (objfile.Peek() != -1) {
          curline = objfile.ReadLine();
          Objects.Add(Strings.Mid(curline, 1, 4));
          ObjectsDesc.Add(Strings.Mid(curline, 28));
        }

        objfile.Dispose();
      }
    }

    private void ScanCollisionPresets() {
      ColPresets = new Structs.CollisionTypePresets[0];
      string curline = "";
      if (File.Exists(AppDirectory + GlobalVars.ExtraDataPrefix + @"\CollisionPresets.txt")) {
        var presLines = new string[3];
        var colpres = new StreamReader(AppDirectory + GlobalVars.ExtraDataPrefix + @"\CollisionPresets.txt");
        int endpos = 0;
        int no = 0;
        string type = "";
        while (colpres.Peek() != -1) {
          curline = colpres.ReadLine();
          presLines = curline.Split(ControlChars.Tab);
          if (CultureInfo.CurrentCulture.CompareInfo.Compare(presLines[0], "g", CompareOptions.IgnoreCase | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth) == 0) {
            type = presLines[1];
            do {
              curline = colpres.ReadLine();
              if (string.IsNullOrEmpty(curline)) {
                break;
              }

              presLines = curline.Split(ControlChars.Tab);
              Array.Resize(ref ColPresets, no + 1);
              {
                var withBlock = ColPresets[no];
                withBlock.Type = type;
                withBlock.Data = presLines[0];
                withBlock.Description = presLines[1];
                withBlock.Index = presLines[2];
                switch (withBlock.Index ?? "") {
                  case "1": {
                      ColVar1.AutoCompleteCustomSource.Add(withBlock.Data + " - " + withBlock.Description);
                      break;
                    }

                  case "2": {
                      ColVar2.AutoCompleteCustomSource.Add(withBlock.Data + " - " + withBlock.Description);
                      break;
                    }

                  case "3": {
                      ColVar3.AutoCompleteCustomSource.Add(withBlock.Data + " - " + withBlock.Description);
                      break;
                    }

                  case "4": {
                      ColVar4.AutoCompleteCustomSource.Add(withBlock.Data + " - " + withBlock.Description);
                      break;
                    }

                  case "5": {
                      ColWalkSound.AutoCompleteCustomSource.Add(withBlock.Data + " - " + withBlock.Description);
                      break;
                    }
                }
              }

              no += 1;
            }
            while (true);
            break;
          } else if (string.IsNullOrEmpty(presLines[0])) {
          }
        }

        colpres.Dispose();
      }
    }

    private void ProcessSceneHeader() {
      try {
        int mscenePos = 0;
        int scenePos = 0;
        int scActorPos = 0;
        int scRoomCnt = 0;
        int scRoomPos = 0;
        CollisionTriColor = new Structs.CollisionTriColorSelect[0];
        SceneActors = new Structs.Door[0];
        ColTypes = new Structs.CollisionTypes[0];
        SceneExits = new Structs.Exits[0];
        CollisionPolies = new Structs.PolygonCollision[0];
        scActorCount = 0;
        {
          var withBlock = CollisionVerts;
          withBlock.x.Clear();
          withBlock.y.Clear();
          withBlock.z.Clear();
          withBlock.VertR.Clear();
          withBlock.VertG.Clear();
          withBlock.VertB.Clear();
          withBlock.FaceR.Clear();
          withBlock.FaceG.Clear();
          withBlock.FaceB.Clear();
          withBlock.EdgeR.Clear();
          withBlock.EdgeG.Clear();
          withBlock.EdgeB.Clear();
        }

        ColVar1.AutoCompleteCustomSource.Clear();
        ColVar2.AutoCompleteCustomSource.Clear();
        ColVar3.AutoCompleteCustomSource.Clear();
        ColVar4.AutoCompleteCustomSource.Clear();
        ColWalkSound.AutoCompleteCustomSource.Clear();
        ExitCombobox.Items.Clear();
        ExitCombobox.Items.Add("Exit Selection");
        ExitCombobox.SelectedIndex = 0;
        ExitCombobox.Enabled = false;
        ColTypeBox.Items.Clear();
        ColTypeBox.Items.Add("Collision Types");
        ColTypeBox.SelectedIndex = 0;
        ColTypeBox.Enabled = false;
        SceneActorCombobox.Items.Clear();
        SceneActorCombobox.Items.Add("None selected");
        SceneActorCombobox.SelectedIndex = 0;
        SceneActorCombobox.Enabled = false;
        ColTriangleBox.Items.Clear();
        ColTriangleBox.Items.Add("Triangles");
        ColTriangleBox.SelectedIndex = 0;
        ColTriangleBox.Enabled = false;
        if (LoadedDataType == (int)Structs.FileTypes.MAP) {
          while (scenePos < GlobalVars.ZSceneBuffer.Length) {
            mscenePos = scenePos;
            switch (GlobalVars.ZSceneBuffer[mscenePos]) {
              case 0xE: {
                  SceneActorCombobox.Enabled = true;
                  scActorCount = GlobalVars.ZSceneBuffer[mscenePos + 1];
                  scActorPos = (int)Functions.ReadUInt24(GlobalVars.ZSceneBuffer, (uint)(mscenePos + 5));
                  i1 = scActorPos;
                  SceneActors = new Structs.Door[scActorCount];
                  UsedSceneGroupIndex = new int[scActorCount];
                  for (int i = 0, loopTo = scActorCount - 1; i <= loopTo; i++) {
                    {
                      this.SceneActors[i] = new Structs.Door {
                        pickR = (byte)GlobalVars.Rand.Next(0, 255),
                        pickG = (byte)GlobalVars.Rand.Next(0, 255),
                        pickB = (byte)GlobalVars.Rand.Next(0, 255),
                        loadMapFront = GlobalVars.ZSceneBuffer[i1],
                        loadMapBack = GlobalVars.ZSceneBuffer[i1 + 2],
                        offset = (uint)i1,
                        no = (uint)(GlobalVars.ZSceneBuffer[i1 + 4] * 0x100 + GlobalVars.ZSceneBuffer[i1 + 5]),
                        x = (short)(GlobalVars.ZSceneBuffer[i1 + 6] * 0x100 + GlobalVars.ZSceneBuffer[i1 + 7]),
                        y = (short)(GlobalVars.ZSceneBuffer[i1 + 8] * 0x100 + GlobalVars.ZSceneBuffer[i1 + 9]),
                        z = (short)(GlobalVars.ZSceneBuffer[i1 + 10] * 0x100 + GlobalVars.ZSceneBuffer[i1 + 11]),
                        yr = (short)(GlobalVars.ZSceneBuffer[i1 + 12] * 0x100 + GlobalVars.ZSceneBuffer[i1 + 13]),
                        var = (uint)(GlobalVars.ZSceneBuffer[i1 + 14] * 0x100 + GlobalVars.ZSceneBuffer[i1 + 15]),
                      };
                    }

                    i1 += 16;
                    RoomActorCombobox.Items.Add("Scene Actor #" + i.ToString() + " - " + IdentifyActor(0U, i));
                  }

                  scenePos = mscenePos + 8;
                  break;
                }

              case 4: {
                  int cnt = GlobalVars.ZSceneBuffer[scenePos + 1];
                  int pos = (int)Functions.ReadUInt24(GlobalVars.ZSceneBuffer, (uint)(scenePos + 5));
                  int i1 = pos;
                  uint curmap = 0U;
                  SceneMaps = new Structs.MapOffset[cnt];
                  for (int i = 0, loopTo1 = cnt - 1; i <= loopTo1; i++) {
                    var startMap = Functions.ReadUInt32(GlobalVars.ZSceneBuffer, (uint)i1);
                    var endMap = Functions.ReadUInt32(GlobalVars.ZSceneBuffer, (uint)(i1 + 4));

                    this.SceneMaps[i] = new Structs.MapOffset {
                        StartOff = startMap,
                        EndOff = endMap,
                    };

                    i1 += 8;
                  }

                  scenePos = mscenePos + 8;
                  break;
                }

              case 20: {
                  break;
                }

              case 19: {
                  ExitCombobox.Enabled = true;
                  ExitTextBox.Enabled = true;
                  int ExitOffset = (int)Functions.ReadUInt24(GlobalVars.ZSceneBuffer, (uint)(scenePos + 5));
                  int ExitCount = GlobalVars.ZSceneBuffer[scenePos + 8];
                  Array.Resize(ref SceneExits, ExitCount);
                  for (int i = 0, loopTo2 = ExitCount - 1; i <= loopTo2; i++) {
                    this.SceneExits[i] = new Structs.Exits {
                      Index = (uint)Functions.ReadInt16(GlobalVars.ZSceneBuffer, (uint)ExitOffset),
                      scOff = (uint)ExitOffset,
                    };

                    ExitCombobox.Items.Add(i);
                    ExitOffset += 2;
                  }

                  break;
                }

              case 3: {
                  ColTypeBox.Enabled = true;
                  uint colPtr = (uint)(Functions.ReadUInt24(GlobalVars.ZSceneBuffer, (uint)(scenePos + 5)) + 12L);
                  uint VariableOffset = Functions.ReadUInt24(GlobalVars.ZSceneBuffer, (uint)(colPtr + 17L));
                  uint PolygonOffset = Functions.ReadUInt24(GlobalVars.ZSceneBuffer, (uint)(colPtr + 13L));
                  uint VertexOffset = Functions.ReadUInt24(GlobalVars.ZSceneBuffer, (uint)(colPtr + 5L));
                  int ctCnt = 0;
                  while (VariableOffset < PolygonOffset) {
                    Array.Resize(ref ColTypes, ctCnt + 1);
                    {
                      var newCollisionTypes = new Structs.CollisionTypes {
                        scOff = VariableOffset,
                        unk1 = (uint)Functions.ReadInt16(GlobalVars.ZSceneBuffer, VariableOffset),
                        unk2 = (uint)Functions.ReadInt16(GlobalVars.ZSceneBuffer, (uint)(VariableOffset + 2L)),
                        unk3 = (uint)Functions.ReadInt16(GlobalVars.ZSceneBuffer, (uint)(VariableOffset + 4L)),
                        unk4 = (uint)(Functions.ReadInt16(GlobalVars.ZSceneBuffer, (uint)(VariableOffset + 6L)) >> 4),
                        WalkOnSound = (byte)(GlobalVars.ZSceneBuffer[(int)(VariableOffset + 7L)] << 4 >> 4),
                      };

                      ColTypes[ctCnt] = newCollisionTypes;

                      ColVar1.AutoCompleteCustomSource.Add(
                          newCollisionTypes.unk1.ToString("X4"));
                      ColVar2.AutoCompleteCustomSource.Add(newCollisionTypes.unk2.ToString("X4"));
                      ColVar3.AutoCompleteCustomSource.Add(newCollisionTypes.unk3.ToString("X4"));
                      ColVar4.AutoCompleteCustomSource.Add(newCollisionTypes.unk4.ToString("X4"));
                      ColWalkSound.AutoCompleteCustomSource.Add(newCollisionTypes.WalkOnSound.ToString("X0"));
                    }

                  ColTypeBox.Items.Add(ctCnt);
                    VariableOffset = (uint)(VariableOffset + 8L);
                    ctCnt += 1;
                  }

                  ScanCollisionPresets();
                  ColTypeBox.SelectedIndex = 0;
                  zlestart16 = (int)PolygonOffset;
                  zlestart6 = (int)VertexOffset;
                  zleend6 = (int)colPtr;
                  ColTriangleBox.Enabled = true;
                  int triCount = 0;
                  while (PolygonOffset < VertexOffset) {
                    Array.Resize(ref CollisionPolies, triCount + 1);
                    CollisionPolies[triCount] = new Structs.PolygonCollision {
                      scOff = PolygonOffset,
                      Param = Functions.ReadInt16(GlobalVars.ZSceneBuffer, PolygonOffset),
                      A = Functions.ReadInt16(GlobalVars.ZSceneBuffer, (uint)(PolygonOffset + 2L)) & 0xFFF,
                      B = Functions.ReadInt16(GlobalVars.ZSceneBuffer, (uint)(PolygonOffset + 4L)) & 0xFFF,
                      C = Functions.ReadInt16(GlobalVars.ZSceneBuffer, (uint)(PolygonOffset + 6L)) & 0xFFF,
                      nX = (short)Functions.ReadInt16(GlobalVars.ZSceneBuffer, (uint)(PolygonOffset + 8L)),
                      nY = (short)Functions.ReadInt16(GlobalVars.ZSceneBuffer, (uint)(PolygonOffset + 10L)),
                      nZ = (short)Functions.ReadInt16(GlobalVars.ZSceneBuffer, (uint)(PolygonOffset + 12L)),
                      pickR = (byte)GlobalVars.Rand.Next(0, 255),
                      pickG = (byte)GlobalVars.Rand.Next(0, 255),
                      pickB = (byte)GlobalVars.Rand.Next(0, 255),
                    };

                    PolygonOffset = (uint)(PolygonOffset + 16L);
                    triCount += 1;
                    ColTriangleBox.Items.Add(triCount);
                  }

                  CollisionTriColor = new Structs.CollisionTriColorSelect[triCount + 1];
                  short cx = 0;
                  short cy = 0;
                  short cz = 0;
                  int edgecnt = -1;
                  while (VertexOffset < colPtr) {
                    CollisionVerts.x.Add((short)Functions.ReadInt16(GlobalVars.ZSceneBuffer, VertexOffset));
                    CollisionVerts.y.Add((short)Functions.ReadInt16(GlobalVars.ZSceneBuffer, (uint)(VertexOffset + 2L)));
                    CollisionVerts.z.Add((short)Functions.ReadInt16(GlobalVars.ZSceneBuffer, (uint)(VertexOffset + 4L)));
                    CollisionVerts.VertR.Add(GlobalVars.Rand.Next(0, 255));
                    CollisionVerts.VertG.Add(GlobalVars.Rand.Next(0, 255));
                    CollisionVerts.VertB.Add(GlobalVars.Rand.Next(0, 255));
                    VertexOffset = (uint)(VertexOffset + 6L);
                    edgecnt += 1;
                    if (edgecnt == 2) {
                      CollisionVerts.EdgeR.Add(GlobalVars.Rand.Next(0, 255));
                      CollisionVerts.EdgeG.Add(GlobalVars.Rand.Next(0, 255));
                      CollisionVerts.EdgeB.Add(GlobalVars.Rand.Next(0, 255));
                      edgecnt = 0;
                    }
                  }

                  RoomActorCombobox.SelectedIndex = 0;
                  scenePos += 8;
                  mscenePos += 8;
                  ChangeColor();
                  break;
                }

              default: {
                  mscenePos += 8;
                  scenePos += 8;
                  break;
                }
            }
          }
        }
      } catch (Exception err) {
        Interaction.MsgBox("Error parsing scene header: " + Environment.NewLine + Environment.NewLine + "Details: " + err.Message);
        return;
      }
    }

    private object FindAllDLs(byte[] Buffer, ref Structs.N64DisplayList[] DL) {
      int DLCnt = 0;
      DListSelection.Items.Clear();
      DListSelection.Items.Add("Render all");
      for (int i = 0, loopTo = Buffer.Length - 8; i <= loopTo; i += 8) {
        if (Buffer[i] == 0xE7 & Buffer[i + 1] == 0 & Buffer[i + 2] == 0 & Buffer[i + 3] == 0 & Buffer[i + 4] == 0 & Buffer[i + 5] == 0 & Buffer[i + 6] == 0 & Buffer[i + 7] == 0) {

          i = ReadInDL(GlobalVars.ZFileBuffer, ref DL, i, DLCnt);
          DLCnt += 1;
        }
      }

      return default;
    }

    private void GetEntryPoints() {
      try {
        int DLCnt = 0;
        int FileTreeIndex = 0;
        GlobalVars.N64DList = new Structs.N64DisplayList[0];
        AnimationEntries = new Structs.Animation[0];
        LimbEntries = new Structs.Limb[0];
        GlobalVars.AnimParser.ResetAnimation(ref GlobalVars.AnimationStopWatch, ref GlobalVars.ZAnimationCounter);
        GlobalVars.AnimParser.StopAnimation(ref GlobalVars.AnimationStopWatch, ref GlobalVars.ZAnimationCounter);
        CurrentFrame.Value = 1;
        DListSelection.Items.Clear();
        AnimationList.Items.Clear();
        switch (LoadedDataType) {
          case (int)Structs.FileTypes.MAP: {
              FindAllDLs(GlobalVars.ZFileBuffer, ref GlobalVars.N64DList);
              HasLimbs = false;
              break;
            }

          case (int)Structs.FileTypes.ACTORMODEL: {
              animationbank.SelectedIndex = 0;
              LimbEntries = GlobalVars.AnimParser.GetHierarchies(GlobalVars.ZFileBuffer, 6);
              if (LimbEntries is object) {
                HasLimbs = true;
                AnimationEntries = GlobalVars.AnimParser.GetAnimations(GlobalVars.ZFileBuffer, LimbEntries.Length - 1, 6);
                if (AnimationEntries is object) {
                  AnimationList.SelectedIndex = 0;
                }
              } else {
                HasLimbs = false;
                FindAllDLs(GlobalVars.ZFileBuffer, ref GlobalVars.N64DList);
              }

              break;
            }
        }
      } catch (Exception err) {
        Interaction.MsgBox("Error in entry point searching: " + Environment.NewLine + Environment.NewLine + "Debug Info: " + err.Message);
        return;
      }
    }

    private int ReadInDL(byte[] Data, ref Structs.N64DisplayList[] DisplayList, int Offset, int Index) {
      if (Data[Offset] == 0xDE) {
        while (Data[Offset] == 0xDE)
          Offset = Data[Offset + 5] * 0x10000 + Data[Offset + 6] * 0x100 + Data[Offset + 7];
      }

      Array.Resize(ref DisplayList, Index + 1);
      DisplayList[Index] = new Structs.N64DisplayList();
      int EPLoc = Offset;
      DListSelection.Items.Add((Index + 1).ToString() + ". " + Conversion.Hex(Offset));
      {
        var withBlock = DisplayList[Index];
        withBlock.StartPos = new Structs.ZSegment();
        withBlock.StartPos.Offset = (uint)Offset;
        withBlock.StartPos.Bank = (byte)GlobalVars.CurrentBank;
        withBlock.Skip = false;
        withBlock.PickCol = new Structs.Color3UByte();
        withBlock.PickCol.r = (byte)GlobalVars.Rand.Next(0, 255);
        withBlock.PickCol.g = (byte)GlobalVars.Rand.Next(0, 255);
        withBlock.PickCol.b = (byte)GlobalVars.Rand.Next(0, 255);
        do {
          Array.Resize(ref withBlock.Commands, withBlock.CommandCount + 1);
          Array.Resize(ref withBlock.CommandsCopy, withBlock.CommandCount + 1);
          withBlock.Commands[withBlock.CommandCount].CMDParams = new byte[8];
          withBlock.Commands[withBlock.CommandCount].Name = GlobalVars.DLParser.IdentifyCommand(Data[EPLoc]);
          for (int i = 0; i <= 7; i++)
            withBlock.Commands[withBlock.CommandCount].CMDParams[i] = Data[EPLoc + i];
          withBlock.Commands[withBlock.CommandCount].CMDHigh = Functions.ReadUInt32(Data, (uint)(EPLoc + 4));
          withBlock.Commands[withBlock.CommandCount].CMDLow = Functions.ReadUInt24(Data, (uint)(EPLoc + 1));
          withBlock.Commands[withBlock.CommandCount].DLPos = withBlock.CommandCount;
          if (Data[EPLoc] == (int)F3DEX2_Defs.F3DZEX.ENDDL | EPLoc >= Data.Length) {
            EPLoc += 8;
            break;
          }

          EPLoc += 8;
          withBlock.CommandCount += 1;
        }
        while (true);
        withBlock.CommandsCopy = withBlock.Commands;
      }

      return EPLoc;
    }

    private void AboutToolStripMenuItem_Click(object sender, EventArgs e) {
      My.MyProject.Forms.AboutBoxDialog.Show();
      My.MyProject.Forms.AboutBoxDialog.Focus();
    }

    private string IdentifyActor(uint ActorType, int Actor) {
      if (ActorType == 0L) {
        for (int I = 0, loopTo = GlobalVars.ActorDataBase.Length - 1; I <= loopTo; I++) {
          {
            var withBlock = GlobalVars.ActorDataBase[I];
            if (withBlock.no == RoomActors[Actor].no) {
              return GlobalVars.ActorDataBase[I].desc;
            }
          }
        }
      } else {
        for (int I = 0, loopTo1 = GlobalVars.ActorDataBase.Length - 1; I <= loopTo1; I++) {
          {
            var withBlock1 = GlobalVars.ActorDataBase[I];
            if (withBlock1.no == SceneActors[Actor].no & (withBlock1.grp == 1L | withBlock1.grp == 0L)) {
              return GlobalVars.ActorDataBase[I].desc;
            }
          }
        }
      }

      return "?";
    }

    private void ProcessMapHeader() {
      try {
        int HDPos = GlobalVars.objectset;
        string Identity = "";
        int GROff = 0;
        int CurGr = 0;
        int ActorStart = 0;
        int ObjSetCnt = 0;
        int ObjSetStart = 0;
        int CurObjSet = 0;
        RoomActors = new Structs.Actor[0];
        UsedGroupIndex = new int[0];
        ComboBox6.SelectedIndex = 0;
        rmActorCount = 0;
        ActorVarText.Text = "";
        ActorVarText.Enabled = false;
        ActorGroupText.Text = "0001";
        ActorGroupText.Enabled = false;
        ActorNumberText.Text = "";
        ActorNumberText.Enabled = false;
        RoomActorCombobox.Items.Clear();
        RoomActorCombobox.Items.Add("None selected");
        RoomActorCombobox.SelectedIndex = 0;
        RoomActorCombobox.Enabled = false;
        while (GlobalVars.ZFileBuffer[HDPos] != 0x14) {
          switch (GlobalVars.ZFileBuffer[HDPos]) {
            case 1: {
                rmActorCount = GlobalVars.ZFileBuffer[HDPos + 1];
                ActorPointer[0] = (uint)HDPos;
                ActorPointer[1] = (uint)rmActorCount;
                if (rmActorCount > 0) {
                  RoomActorCombobox.Enabled = true;
                  ActorVarText.Enabled = true;
                  ActorNumberText.Enabled = true;
                  ActorStart = (int)Functions.ReadUInt24(GlobalVars.ZFileBuffer, (uint)(HDPos + 5));
                  ActorPointer[2] = (uint)ActorStart;
                  i1 = ActorStart;
                  RoomActors = new Structs.Actor[rmActorCount];
                  UsedGroupIndex = new int[rmActorCount];
                  for (int i = 0, loopTo = rmActorCount - 1; i <= loopTo; i++) {
                    {
                      RoomActors[i] = new Structs.Actor {
                        pickR = (byte)GlobalVars.Rand.Next(0, 255),
                        pickG = (byte)GlobalVars.Rand.Next(0, 255),
                        pickB = (byte)GlobalVars.Rand.Next(0, 255),
                        offset = (uint)i1,
                        no = (uint)Functions.ReadInt16(GlobalVars.ZFileBuffer, (uint)(i1 + 0)),
                        x = (short)Functions.ReadInt16(GlobalVars.ZFileBuffer, (uint)(i1 + 2)),
                        y = (short)Functions.ReadInt16(GlobalVars.ZFileBuffer, (uint)(i1 + 4)),
                        z = (short)Functions.ReadInt16(GlobalVars.ZFileBuffer, (uint)(i1 + 6)),
                        xr = (short)Functions.ReadInt16(GlobalVars.ZFileBuffer, (uint)(i1 + 8)),
                        yr = (short)Functions.ReadInt16(GlobalVars.ZFileBuffer, (uint)(i1 + 10)),
                        zr = (short)Functions.ReadInt16(GlobalVars.ZFileBuffer, (uint)(i1 + 12)),
                        var = (uint)Functions.ReadInt16(GlobalVars.ZFileBuffer, (uint)(i1 + 14)),
                      };
                    }

                    i1 += 16;
                    RoomActorCombobox.Items.Add("Room Actor #" + i.ToString() + " - " + IdentifyActor(0U, i));
                  }
                }

                break;
              }

            case 0xB: {
                ActorGroupText.Enabled = true;
                uint Cnt = GlobalVars.ZFileBuffer[HDPos + 1];
                GlobalVars.ActorGroupOffset = Functions.ReadUInt24(GlobalVars.ZFileBuffer, (uint)(HDPos + 5));
                CurGr = Conversions.ToInteger(GlobalVars.ActorGroupOffset);
                uint gr = 0U;
                string desc = "?";
                int objind = 0;
                for (int i = 0, loopTo1 = (int)(Cnt - 1L); i <= loopTo1; i++) {
                  gr = (uint)Functions.ReadInt16(GlobalVars.ZFileBuffer, (uint)CurGr);
                  GlobalVars.ActorGroups.Add(gr);
                  objind = Objects.IndexOf(gr.ToString("X4"));
                  desc = "?";
                  if (objind > -1) {
                    desc = Conversions.ToString(ObjectsDesc[objind]);
                  }
                  // Group.Items.Add((i + 1).ToString & " - " & desc)
                  CurGr += 2;
                }

                break;
              }

            case 0x12: {
                break;
              }
            // environment stuff
            case var @case when @case == (0x18 & Conversions.ToInteger(!ScannedObjSet)): {
                if (string.IsNullOrEmpty(IndMapFileName)) {
                  FileTree.SelectedNode.Nodes.Add("Object Sets");
                  FileTree.SelectedNode.Nodes[0].Nodes.Add("1. 0x0");
                }

                ObjSetStart = (int)Functions.ReadUInt24(GlobalVars.ZFileBuffer, (uint)(HDPos + 5));
                ObjSetCnt = GlobalVars.ZFileBuffer[HDPos + 15];
                CurObjSet = ObjSetStart;
                uint ObjSetOffset = 0U;
                uint ObjSetSeg = 3U;
                uint ObjSetIncr = 0U;
                for (int i = 0, loopTo2 = ObjSetCnt - 1; i <= loopTo2; i++) {
                  ObjSetOffset = Functions.ReadUInt24(GlobalVars.ZFileBuffer, (uint)(CurObjSet + 1));
                  ObjSetSeg = GlobalVars.ZFileBuffer[CurObjSet];
                  if (ObjSetSeg != 0x3L & ObjSetOffset > 0L) {
                    break;
                  }

                  if (string.IsNullOrEmpty(IndMapFileName) & ObjSetOffset > 0L & GlobalVars.ZFileBuffer[(int)ObjSetOffset] == 0x16) {
                    FileTree.SelectedNode.Nodes[0].Nodes.Add((ObjSetIncr + 2L).ToString() + ". 0x" + Conversion.Hex(ObjSetOffset));
                    ObjSetIncr = (uint)(ObjSetIncr + 1L);
                  }

                  CurObjSet += 4;
                }

                break;
              }
          }

          HDPos += 8;
        }
      } catch (Exception err) {
        rmActorCount = 0;
        Interaction.MsgBox("Error in grabbing actors: " + Environment.NewLine + Environment.NewLine + "Debug Info: " + err.Message);
        return;
      }
    }

    private void LoadActorGFX_FileOk(object sender, System.ComponentModel.CancelEventArgs e) {
      GlobalVars.DefROM = LoadROM.FileName;
      UoTIniFile.WriteString("Settings", "DefaultROM", GlobalVars.DefROM);
      Start(false);
    }

    private void GetROMFileTable(uint segoff, uint nameoff, bool DebugROM) {
      var curfilebyte = new byte[0];
      int nameinc = 0;
      int seginc = 0;
      int namebuffpos = 0;
      int segbuffpos = 0;
      int curnamepos = 0;
      int cursegpos = 0;
      string curfilename = "";
      int sccount = -1;
      int mapcount = 0;
      int scinc = 0;
      int scfile = -1;
      bool done = false;
      uint endb = 0U;
      uint startb = 0U;
      var tempstart = new uint[0];
      var tempend = new uint[0];
      FileTree.Nodes.Clear();
      FileTree.Nodes.Add("Actor models");
      FileTree.Nodes.Add("Actor code");
      FileTree.Nodes.Add("Levels");
      FileTree.Nodes.Add("Others");
      namebuffpos = 0;
      curnamepos = (int)nameoff;
      segbuffpos = (int)segoff;
      do {
        startb = Functions.ReadUInt32(ROMData, (uint)segbuffpos);
        endb = Functions.ReadUInt32(ROMData, (uint)(segbuffpos + 4));
        if (startb == 0L & endb == 0L) {
          break;
        }

        Array.Resize(ref tempstart, seginc + 1);
        Array.Resize(ref tempend, seginc + 1);
        tempend[seginc] = endb;
        tempstart[seginc] = startb;
        segbuffpos += 16;
        seginc += 1;
      }
      while (true);
      while (nameinc <= seginc - 1) {
        namebuffpos = 0;
        if (ROMData[curnamepos] == 0) {
          while (ROMData[curnamepos] == 0)
            curnamepos += 1;
        }

        while (ROMData[curnamepos] != 0) {
          Array.Resize(ref curfilebyte, namebuffpos + 1);
          curfilebyte[namebuffpos] = ROMData[curnamepos];
          curnamepos += 1;
          namebuffpos += 1;
        }

        curfilename = System.Text.Encoding.UTF8.GetString(curfilebyte, 0, namebuffpos);
        switch (curfilename.ToLower() ?? "") {
          case var @case when CultureInfo.CurrentCulture.CompareInfo.Compare(@case, "gameplay_keep", CompareOptions.IgnoreCase | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth) == 0: {
              break;
            }

          case var case1 when CultureInfo.CurrentCulture.CompareInfo.Compare(case1, "gameplay_field_keep", CompareOptions.IgnoreCase | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth) == 0: {
              break;
            }

          case var case2 when CultureInfo.CurrentCulture.CompareInfo.Compare(case2, "gameplay_dangeon_keep", CompareOptions.IgnoreCase | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth) == 0: {
              break;
            }
        }

        if (curfilename.Contains("_scene")) {
          sccount += 1;
          
          var newLevel = new Structs.ZSc();
          newLevel.filename = curfilename;
          newLevel.startoff = (int)tempstart[nameinc];
          newLevel.endoff = (int)tempend[nameinc];

          this.ROMFiles.Levels.Add(newLevel);

          FileTree.Nodes[2].Nodes.Add(curfilename);
          mapcount = 0;
        } else if (curfilename.Contains("room_")) {
          var newMap = new Structs.ZMap();
          newMap.filename = curfilename;
          newMap.startoff = (int)tempstart[nameinc];
          newMap.endoff = (int)tempend[nameinc];

          this.ROMFiles.Levels[sccount].Maps.Add(newMap);

          FileTree.Nodes[2].Nodes[sccount].Nodes.Add(curfilename);
          mapcount += 1;
        } else if (CultureInfo.CurrentCulture.CompareInfo.Compare(Strings.Mid(curfilename, 1, 7).ToLower(), "object_", CompareOptions.IgnoreCase | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth) == 0) {
          var newObj = new Structs.ZObj();
          newObj.filename = curfilename;
          newObj.startoff = (int)tempstart[nameinc];
          newObj.endoff = (int)tempend[nameinc];

          this.ROMFiles.Objects.Add(newObj);

          FileTree.Nodes[0].Nodes.Add(curfilename);
          mapcount = 0;
          sccount = -1;
        } else if (CultureInfo.CurrentCulture.CompareInfo.Compare(Strings.Mid(curfilename, 1, 4).ToLower(), "ovl_", CompareOptions.IgnoreCase | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth) == 0) {
          this.ROMFiles.ActorCode.Add(new Structs.ZCodeFiles {
              filename = curfilename,
              startoff = (int)tempstart[nameinc],
              endoff = (int)tempend[nameinc],
          });

          FileTree.Nodes[1].Nodes.Add(curfilename);
        } else {
          this.ROMFiles.Others.Add(new Structs.ZOtherData {
              filename = curfilename,
              startoff = (int)tempstart[nameinc],
              endoff = (int)tempend[nameinc],
          });

          FileTree.Nodes[3].Nodes.Add(curfilename);
          mapcount = 0;
          sccount = -1;
        }

        nameinc += 1;
      }

      PopulateCommonBanks(GlobalVars.CommonBanks);
      Reshape();
    }

    public void PopulateCommonBanks(Structs.ObjectExchange Banks) {
      using var romFS = new FileStream(GlobalVars.DefROM, FileMode.Open);

      Banks.Bank4.Banks.Clear();
      Banks.Bank5.Banks.Clear();
      Banks.Anims.Banks.Clear();

      for (var i = 0; i < 1; ++i) {
        Banks.Bank4.Banks.Add(new Structs.BankBuffers());
      }
      for (var i = 0; i < 2; ++i) {
        Banks.Bank5.Banks.Add(new Structs.BankBuffers());
        Banks.Anims.Banks.Add(new Structs.BankBuffers());
      }

      GlobalVars.CommonBankUse.AnimBank = -1;
      GlobalVars.CommonBankUse.Bank04 = 0;
      GlobalVars.CommonBankUse.Bank05 = 0;
      foreach (var obj in ROMFiles.Others) {
        var filename = obj.filename;

        var endOff = obj.endoff;
        var startOff = obj.startoff;
        var fileSize = endOff - startOff;

        if (CultureInfo.CurrentCulture.CompareInfo.Compare(filename, "gameplay_keep", CompareOptions.IgnoreCase | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth) == 0) {
          Banks.Bank4.Banks[0].Data = new byte[fileSize];

          romFS.Position = startOff;
          romFS.Read(Banks.Bank4.Banks[0].Data, 0, fileSize);
          
          Banks.Bank4.Banks[0].StartOffset = (uint) startOff;
          Banks.Bank4.Banks[0].EndOffset = (uint)endOff;
        } else if (CultureInfo.CurrentCulture.CompareInfo.Compare(filename, "gameplay_field_keep", CompareOptions.IgnoreCase | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth) == 0) {
          Banks.Bank5.Banks[0].Data = new byte[fileSize];

          romFS.Position = startOff;
          romFS.Read(Banks.Bank5.Banks[0].Data, 0, fileSize);
          
          Banks.Bank5.Banks[0].StartOffset = (uint) startOff;
          Banks.Bank5.Banks[0].EndOffset = (uint) endOff;
        } else if (CultureInfo.CurrentCulture.CompareInfo.Compare(filename, "gameplay_dangeon_keep", CompareOptions.IgnoreCase | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth) == 0) {
          Banks.Bank5.Banks[1].Data = new byte[fileSize];

          romFS.Position = startOff;
          romFS.Read(Banks.Bank5.Banks[1].Data, 0, fileSize);
          
          Banks.Bank5.Banks[1].StartOffset = (uint) startOff;
          Banks.Bank5.Banks[1].EndOffset = (uint) endOff;
        }
      }

      animationbank.Items.Clear();
      animationbank.Items.Add("Inline with model");

      var objAnimeMatcher = new Regex("object_.*_anime");

      foreach (var obj in ROMFiles.Objects) {
        var filename = obj.filename;
        if (filename == null) {
          continue;
        }

        var endOff = obj.endoff;
        var startOff = obj.startoff;
        var fileSize = endOff - startOff;

        if (objAnimeMatcher.IsMatch(filename.ToLower())) {
          animationbank.Items.Add(filename);

          var newAnimData = new Structs.BankBuffers();
          Banks.Anims.Banks.Add(newAnimData);
          
          newAnimData.Data = new byte[fileSize];
          romFS.Position = startOff;
          romFS.Read(newAnimData.Data, 0, fileSize);

          newAnimData.StartOffset = (uint) startOff;
          newAnimData.EndOffset = (uint) endOff;
        }
      }
    }

    public void Start(bool individual) {
      try {
        GlobalVars.N64DList = new Structs.N64DisplayList[0];
        GlobalVars.DLParser.KillTexCache();
        Working = true;
        if (!individual) {
          ROMFileStream = new FileStream(LoadROM.FileName, FileMode.Open);
          ROMData = new byte[(int)(ROMFileStream.Length - 1L + 1)];
          ROMFileStream.Position = 0L;
          ROMFileStream.Read(ROMData, 0, (int)(ROMFileStream.Length - 1L));
          ROMFileStream.Close();
          string ROMID = "";
          var ROMIDBytes = new byte[6];
          string BuildDate = "";
          var BuildDateBytes = new byte[17];
          int tSegOff = 0;
          int tNameOff = 0;
          bool DebugROM = false;
          string ROMType = "";
          for (int i = 0, loopTo = ROMData.Length - 1; i <= loopTo; i += 16) {
            for (int i1 = 0; i1 <= 5; i1++)
              ROMIDBytes[i1] = ROMData[i + i1];
            ROMID = System.Text.Encoding.ASCII.GetString(ROMIDBytes);
            if (CultureInfo.CurrentCulture.CompareInfo.Compare(ROMID, "zelda@", CompareOptions.IgnoreCase | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth) == 0) {
              i += 0xD;
              if (ROMData[i] >> 4 != 3) {
                while (ROMData[i] >> 4 != 3)
                  i += 1;
              }

              for (int i1 = 0; i1 <= 16; i1++)
                BuildDateBytes[i1] = ROMData[i + i1];
              BuildDate = System.Text.Encoding.ASCII.GetString(BuildDateBytes);
              tSegOff = i + 0x20;
              int CodeOff = 0;
              Z64Code = new byte[0];
              switch (BuildDate ?? "") {
                case var @case when CultureInfo.CurrentCulture.CompareInfo.Compare(@case, "00-07-31 17:04:16", CompareOptions.IgnoreCase | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth) == 0: {
                    DebugROM = false;
                    tNameOff = -1;
                    ROMType = "Majora's Mask (U)";
                    SwitchGame(1);
                    break;
                  }

                case var case1 when CultureInfo.CurrentCulture.CompareInfo.Compare(case1, "03-02-21 00:16:31", CompareOptions.IgnoreCase | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth) == 0: {
                    DebugROM = true;
                    tNameOff = 0xBE80;
                    ROMType = "Master Quest Debug ROM (E)";
                    CodeOff = 0xA94000;
                    Z64Code = new byte[1290032];
                    for (int ii = 0; ii <= 0x13AF30 - 1; ii++)
                      Z64Code[ii] = ROMData[CodeOff + ii];
                    ParseActorTable(0xF9440U, 0xF5BE0U, 0x10A6D0U, 0x10B360U);
                    SwitchGame(0);
                    break;
                  }

                default: {
                    Interaction.MsgBox("ROM not recognized, build date: " + BuildDate);
                    GlobalVars.ExtraDataPrefix = @"\ext";
                    Working = false;
                    return;
                  }
              }

              break;
            }
          }

          GetROMFileTable((uint)tSegOff, (uint)tNameOff, DebugROM);
          Text = "Utility of Time R8 - " + LoadROM.FileName + " - " + ROMType;
          ROMData = new byte[0];
          IndMapFileName = "";
          IndScFileName = "";
        } else {
          Text = "Utility of Time R8 - " + IndScFileName;
          if (IndScFileName.Contains(".zscene")) {
            SetVariables(0);
          } else if (IndScFileName.Contains(".zobj")) {
            SetVariables(1);
          }
        }
      } catch (Exception err) {
        Interaction.MsgBox("Error reading file: " + err.Message, MsgBoxStyle.Critical, "Error");
      }
    }

    private void ParseActorTable(uint ActorTableOff, uint ActorTableEnd, uint ObjectTableOff, uint ObjectTableEnd) {
      uint tActorTbl = ActorTableOff;
      uint tActorTblEnd = ActorTableEnd;
      uint tObjectTbl = ObjectTableOff;
      uint tObjectTblEnd = ObjectTableEnd;
      
      while (tObjectTbl < tObjectTblEnd) {
        var newObject = new Structs.ObjectTbl();
        this.ObjectTable.Add(newObject);
        newObject.Startoff = Functions.ReadUInt32(Z64Code, tObjectTbl);
        newObject.Endoff = Functions.ReadUInt32(Z64Code, (uint)(tObjectTbl + 4L));
        tObjectTbl = (uint)(tObjectTbl + 8L);
      }
    }

    public void Reshape() {
      GlobalVars.winw = UoTRender.Width;
      GlobalVars.winh = UoTRender.Height;
      GlobalVars.ogltop = UoTRender.Top;
      GlobalVars.oglleft = UoTRender.Left;
      Gl.glViewport(0, 0, UoTRender.Width, UoTRender.Height);
      Gl.glMatrixMode(Gl.GL_PROJECTION);
      Gl.glLoadIdentity();
      Glu.gluPerspective(45.0d, UoTRender.Width / (double)UoTRender.Height, 1.0d, 999999d);
      Gl.glMatrixMode(Gl.GL_MODELVIEW);
      Gl.glLoadIdentity();
    }

    private void Form1_Enter(object sender, EventArgs e) {
      Focus();
    }

    private void KeyCheckUp(object sender, KeyEventArgs e) {
      switch (e.KeyCode) {
        case Keys.Alt: {
            key_alt = false;
            break;
          }

        case Keys.ControlKey: {
            key_ctrl = false;
            break;
          }

        case Keys.I:
        case Keys.J:
        case Keys.K:
        case Keys.L:
        case Keys.U:
        case Keys.O:
        case Keys.T:
        case Keys.Y:
        case Keys.G:
        case Keys.H: {
            ActorInputTimer.Stop();
            break;
          }

        case Keys.W: {
            key_w = false;
            break;
          }

        case Keys.D: {
            key_d = false;
            break;
          }

        case Keys.S: {
            key_s = false;
            break;
          }

        case Keys.A: {
            key_a = false;
            break;
          }

        case var @case when @case == Keys.O: {
            key_o = false;
            break;
          }

        case var case1 when case1 == Keys.U: {
            key_u = false;
            break;
          }

        case Keys.Q: {
            key_q = false;
            break;
          }

        case Keys.E: {
            key_e = false;
            break;
          }
      }
    }

    private void SimpleOpenGlControl1_KeyUp(object sender, KeyEventArgs e) {
      KeyCheckUp(sender, e);
    }

    private void SetupToolStripMenuItem_Click(object sender, EventArgs e) {
      My.MyProject.Forms.SetupDialog.ShowDialog();
    }

    private void PickItem(int CurrentTool, MouseButtons Button) {
      Gl.glPushMatrix();
      Gl.glRotatef((float)CamXRot, 1.0f, 0.0f, 0.0f);
      Gl.glRotatef((float)CamYRot, 0.0f, 1.0f, 0.0f);
      Gl.glRotatef((float)CamZRot, 0.0f, 0.0f, 1.0f);
      Gl.glTranslatef((float)GlobalVars.CamXPos, (float)GlobalVars.CamYPos, (float)GlobalVars.CamZPos);
      switch (CurrentTool) {
        case (int)ToolID.ACTOR: {
            if (LoadedDataType == (int)Structs.FileTypes.MAP) {
              DrawActorBoxes(true);
              ReadPixel = MousePixelRead((int)NewMouseX, (int)NewMouseY);
              for (int g = 0, loopTo = RoomActors.Length - 1; g <= loopTo; g++) {
                if (ReadPixel[0] == RoomActors[g].pickR & ReadPixel[1] == RoomActors[g].pickG & ReadPixel[2] == RoomActors[g].pickB) {
                  if (!MouseOver) {
                    if (Button == MouseButtons.Right & GlobalVars.SelectedRoomActors.Count > 0) {
                      ActorContextMenu.Show(MousePosition.X, MousePosition.Y);
                    } else {
                      SceneActorCombobox.SelectedIndex = 0;
                      GlobalVars.SelectedSceneActors.Clear();
                      if (!key_ctrl) {
                        GlobalVars.SelectedRoomActors.Clear();
                        GlobalVars.SelectedRoomActors.Add(g);
                        // SyncCameraToActor(0, g)
                        RoomActorCombobox.SelectedIndex = g + 1;
                      } else {
                        MPick = true;
                        if (!GlobalVars.SelectedRoomActors.Contains(g)) {
                          GlobalVars.SelectedRoomActors.Add(g);
                        }

                        RoomActorCombobox.SelectedIndex = 0;
                      }

                      ToolModes.SelectedItemType = (int)ToolID.ACTOR;
                      UpdateActorPos();
                    }

                    EditingTabs.SelectedTab = EditingTabs.TabPages["ActorsTab"];
                  } else {
                    PrintTool = true;
                    PrintToolStr = RoomActorCombobox.Items[g + 1].ToString();
                  }

                  break;
                }
              }

              for (int g = 0, loopTo1 = SceneActors.Length - 1; g <= loopTo1; g++) {
                if (ReadPixel[0] == SceneActors[g].pickR & ReadPixel[1] == SceneActors[g].pickG & ReadPixel[2] == SceneActors[g].pickB) {
                  if (!MouseOver) {
                    if (Button == MouseButtons.Right & GlobalVars.SelectedSceneActors.Count > 0) {
                      ActorContextMenu.Show(MousePosition.X, MousePosition.Y);
                    } else {
                      MPick = true;
                      RoomActorCombobox.SelectedIndex = 0;
                      GlobalVars.SelectedRoomActors.Clear();
                      if (!key_ctrl) {
                        GlobalVars.SelectedSceneActors.Clear();
                        GlobalVars.SelectedSceneActors.Add(g);
                        // SyncCameraToActor(1, g)
                        SceneActorCombobox.SelectedIndex = g + 1;
                      } else {
                        if (!GlobalVars.SelectedSceneActors.Contains(g)) {
                          GlobalVars.SelectedSceneActors.Add(g);
                        }

                        SceneActorCombobox.SelectedIndex = 0;
                      }

                      ToolModes.SelectedItemType = (int)ToolID.ACTOR;
                      UpdateActorPos();
                    }

                    EditingTabs.SelectedTab = EditingTabs.TabPages["ActorsTab"];
                  } else {
                    PrintTool = true;
                    PrintToolStr = SceneActorCombobox.Items[g + 1].ToString();
                  }

                  break;
                }
              }
            }

            PrintTool = false;
            break;
          }

        case (int)ToolID.VERTEX: {
            Gl.glEnable(Gl.GL_POLYGON_OFFSET_POINT);
            Gl.glPolygonOffset(-6, -6);
            if (RenderGraphics) {
              DrawDLArray(GlobalVars.N64DList, (int)ToolID.VERTEX);
            }

            if (RenderCollision) {
              DrawCollision(CollisionPolies, CollisionVerts, true);
            }

            ReadPixel = MousePixelRead((int)NewMouseX, (int)NewMouseY);
            if (!MouseOver) {
              VertexSelect();
            }

            Gl.glDisable(Gl.GL_POLYGON_OFFSET_POINT);
            break;
          }

        case (int)ToolID.EDGE: {
            if (!MouseOver) {
              EdgeSelect();
            }

            break;
          }

        case (int)ToolID.DLIST: {
            Gl.glEnable(Gl.GL_POLYGON_OFFSET_FILL);
            Gl.glPolygonOffset(-7, -7);
            if (RenderGraphics) {
              DrawDLArray(GlobalVars.N64DList, (int)ToolID.DLIST);
            }

            Gl.glDisable(Gl.GL_POLYGON_OFFSET_FILL);
            break;
          }

        case (int)ToolID.COLTRI: {
            if (RenderCollision) {
              DrawCollision(CollisionPolies, CollisionVerts, true);
              ReadPixel = MousePixelRead((int)NewMouseX, (int)NewMouseY);
              var loopTo2 = CollisionPolies.Length - 1;
              for (i1 = 0; i1 <= loopTo2; i1++) {
                if (ReadPixel[0] == CollisionPolies[i1].pickR & ReadPixel[1] == CollisionPolies[i1].pickG & ReadPixel[2] == CollisionPolies[i1].pickB) {
                  if (!MouseOver) {
                    int sel = CollisionPolies[i1].Param;
                    for (int i2 = 0, loopTo3 = CollisionTriColor.Length - 1; i2 <= loopTo3; i2++) {
                      CollisionTriColor[i2].g = 1;
                      CollisionTriColor[i2].b = 1;
                    }

                    CollisionTriColor[i1].g = 0;
                    CollisionTriColor[i1].b = 0;
                    colTri = true;
                    ColTriangleBox.SelectedIndex = i1 + 1;
                    colTri = false;
                    EditingTabs.SelectedTab = EditingTabs.TabPages["CollisionTab"];
                  } else {
                    PrintTool = true;
                    PrintToolStr = Conversions.ToString(Operators.ConcatenateObject("Triangle ", ColTriangleBox.Items[i1 + 1]));
                  }

                  break;
                }
              }
            }

            PrintTool = false;
            break;
          }
      }

      Gl.glPopMatrix();
    }

    private byte[] MousePixelRead(int x, int y) {
      byte[] MousePixelReadRet = default;
      MousePixelReadRet = new byte[3];
      Gl.glGetIntegerv(Gl.GL_VIEWPORT, viewport);
      Gl.glReadPixels(x, viewport[3] - y, 1, 1, Gl.GL_RGB, Gl.GL_UNSIGNED_BYTE, MousePixelReadRet);
      return MousePixelReadRet;
    }

    private void EdgeSelect() {
      for (int i = 0, loopTo = CollisionVerts.EdgeR.Count - 1; i <= loopTo; i++) {
        if (Conversions.ToBoolean(Operators.AndObject(Operators.AndObject(Operators.ConditionalCompareObjectEqual(ReadPixel[0], CollisionVerts.EdgeR[i], true), Operators.ConditionalCompareObjectEqual(ReadPixel[1], CollisionVerts.EdgeG[i], true)), Operators.ConditionalCompareObjectEqual(ReadPixel[2], CollisionVerts.EdgeB[i], true)))) {
          Interaction.MsgBox(i);
        }
      }
    }

    private void VertexSelect() {
      if (RenderCollision) {
        for (int g = 0, loopTo = CollisionVerts.VertR.Count - 1; g <= loopTo; g++) {
          if (Conversions.ToBoolean(Operators.AndObject(Operators.AndObject(Operators.ConditionalCompareObjectEqual(ReadPixel[0], CollisionVerts.VertR[g], true), Operators.ConditionalCompareObjectEqual(ReadPixel[1], CollisionVerts.VertG[g], true)), Operators.ConditionalCompareObjectEqual(ReadPixel[2], CollisionVerts.VertB[g], true)))) {
            if (key_ctrl) {
              if (MouseLeft) {
                if (SelectedCollisionVert.Contains(g)) {
                  SelectedCollisionVert.Remove(g);
                }
              }

              if (!SelectedCollisionVert.Contains(g)) {
                SelectedCollisionVert.Add(g);
              }
            } else {
              if (MouseRight) {
                VertContextMenu.Show(MousePosition.X, MousePosition.Y);
              }

              if (SelectedCollisionVert.Count > 1) {
                SelectedCollisionVert.Clear();
                SelectedCollisionVert.Add(g);
              } else {
                SelectedCollisionVert.Clear();
                SelectedCollisionVert.Add(g);
              }
            }

            ToolModes.SelectedItemType = (int)ToolID.VERTEX;
            return;
          }
        }
      }
    }

    private void SimpleOpenGlControl1_MouseDown(object sender, MouseEventArgs e) {
      Cursor.Hide();
      MouseDown1(sender, e);
    }

    private void SimpleOpenGlControl1_MouseUp(object sender, MouseEventArgs e) {
      Cursor.Show();
      MouseUp1(sender, e);
    }

    private void MouseDown1(object sender, MouseEventArgs e) {
      if (!HoldCursor) {
        HoldCursor = true;
        CursorPosOld = new Point(MousePosition.X, MousePosition.Y);
        oldLocalMouse = UoTRender.PointToClient(CursorPosOld);
        OldMouseX = oldLocalMouse.X;
        OldMouseY = oldLocalMouse.Y;
        MouseOver = false;
        if (ToolModes.CurrentTool != (int)ToolID.NONE)
          PickItem(ToolModes.CurrentTool, e.Button);
        switch (e.Button) {
          case MouseButtons.Left: {
              MouseLeft = true;
              break;
            }

          case MouseButtons.Right: {
              MouseRight = true;
              break;
            }

          case MouseButtons.Middle: {
              MouseMiddle = true;
              break;
            }
        }
      } else {
        MouseLeft = false;
        MouseRight = false;
        MouseMiddle = false;
      }
    }

    private void MouseUp1(object sender, MouseEventArgs e) {
      HoldCursor = false;
      ToolModes.SelectedItemType = (int)ToolID.NONE;
      switch (e.Button) {
        case MouseButtons.Left: {
            MouseLeft = false;
            break;
          }

        case MouseButtons.Right: {
            MouseRight = false;
            break;
          }

        case MouseButtons.Middle: {
            MouseMiddle = false;
            break;
          }
      }
    }

    private void UpdateActorPos() {
      if (!GlobalVars.OnSceneActor) {
        if (RoomActorCombobox.SelectedIndex > 0) {
          int c7 = RoomActorCombobox.SelectedIndex - 1;
          TextBox7.Text = ((int)RoomActors[c7].x).ToString();
          TextBox8.Text = ((int)RoomActors[c7].y).ToString();
          TextBox9.Text = ((int)RoomActors[c7].z).ToString();
          TextBox10.Text = ((int)RoomActors[c7].xr).ToString();
          TextBox11.Text = ((int)RoomActors[c7].yr).ToString();
          TextBox12.Text = ((int)RoomActors[c7].zr).ToString();
          TextBox10.Enabled = true;
          TextBox11.Enabled = true;
          TextBox12.Enabled = true;
        }
      } else if (SceneActorCombobox.SelectedIndex > 0) {
        int c5 = SceneActorCombobox.SelectedIndex - 1;
        TextBox7.Text = ((int)SceneActors[c5].x).ToString();
        TextBox8.Text = ((int)SceneActors[c5].y).ToString();
        TextBox9.Text = ((int)SceneActors[c5].z).ToString();
        TextBox10.Enabled = false;
        TextBox11.Enabled = false;
        TextBox12.Enabled = false;
      }

      ChangePosition[0] = false;
      ChangePosition[1] = false;
      ChangePosition[2] = false;
      ChangePosition[3] = false;
      ChangePosition[4] = false;
    }

    private void ToolStripButton12_Click(object sender, EventArgs e) {
      ToggleWire();
      UoTRender.Focus();
    }

    private void ToolStripButton1_Click(object sender, EventArgs e) {
      My.MyProject.Forms.SetupDialog.ShowDialog();
      My.MyProject.Forms.SetupDialog.Focus();
    }

    private void RoomActorCombobox_SelectedIndexChanged(object sender, EventArgs e) {
      try {
        comb7 = RoomActorCombobox.SelectedIndex - 1;
        if (RoomActorCombobox.SelectedIndex == 0) {
          ActorVarText.Text = "";
          ActorNumberText.Text = "";
          GlobalVars.ActorType = 1;
          TextBox7.Text = "";
          TextBox8.Text = "";
          TextBox9.Text = "";
          TextBox10.Text = "";
          TextBox11.Text = "";
          TextBox12.Text = "";
          ToolModes.SelectedItemType = (int)ToolID.NONE;
          VarContextMenu.Items.Clear();
          if (!MPick) {
            GlobalVars.SelectedRoomActors.Clear();
          }
        } else {
          SceneActorCombobox.SelectedIndex = 0;
          GlobalVars.OnSceneActor = false;
          GlobalVars.ActorType = 0;
          ActorNumberText.Enabled = true;
          ActorVarText.Enabled = true;
          ActorVarText.Text = RoomActors[comb7].var.ToString("X4");
          ActorNumberText.Text = RoomActors[comb7].no.ToString("X4");
          VarContextMenu.Items.Clear();
          for (int I = 0, loopTo = GlobalVars.ActorDataBase.Length - 1; I <= loopTo; I++) {
            {
              var withBlock = GlobalVars.ActorDataBase[I];
              if (withBlock.no == RoomActors[comb7].no & GlobalVars.ActorGroups.Contains(withBlock.grp)) {
                PopulateVarContext(GlobalVars.ActorDataBase, I);
                break;
              }
            }
          }

          UpdateActorPos();
          if (!MPick) {
            GlobalVars.SelectedRoomActors.Clear();
            GlobalVars.SelectedRoomActors.Add(comb7);
          }
        }
      } catch (Exception err) {
        Interaction.MsgBox("Error in room actor selection." + Environment.NewLine + Environment.NewLine + "Debug Info: " + err.Message, MsgBoxStyle.Critical);
        RoomActorCombobox.SelectedIndex = 0;
        SceneActorCombobox.SelectedIndex = 0;
        return;
      }
    }

    private void ComboBox5_SelectedIndexChanged(object sender, EventArgs e) {
      try {
        comb5 = SceneActorCombobox.SelectedIndex - 1;
        if (SceneActorCombobox.SelectedIndex == 0) {
          GlobalVars.OnSceneActor = false;
          GlobalVars.ActorType = 1;
          ToolModes.SelectedItemType = (int)ToolID.NONE;
          ActorVarText.Text = "";
          ActorNumberText.Text = "";
          TextBox7.Text = "";
          TextBox8.Text = "";
          TextBox9.Text = "";
          TextBox10.Text = "";
          TextBox11.Text = "";
          TextBox12.Text = "";
          if (!MPick) {
            GlobalVars.SelectedSceneActors.Clear();
          }
        } else {
          RoomActorCombobox.SelectedIndex = 0;
          GlobalVars.OnSceneActor = true;
          GlobalVars.ActorType = 0;
          TextBox10.Enabled = false;
          TextBox11.Enabled = false;
          TextBox12.Enabled = false;
          TextBox7.Text = SceneActors[SceneActorCombobox.SelectedIndex - 1].x.ToString();
          TextBox8.Text = SceneActors[SceneActorCombobox.SelectedIndex - 1].y.ToString();
          TextBox9.Text = SceneActors[SceneActorCombobox.SelectedIndex - 1].z.ToString();
          ActorNumberText.Text = SceneActors[SceneActorCombobox.SelectedIndex - 1].no.ToString("X4");
          ActorVarText.Text = SceneActors[SceneActorCombobox.SelectedIndex - 1].var.ToString("X4");
          ActorNumberText.Enabled = true;
          ActorVarText.Enabled = true;
          GlobalVars.SelectedRoomActors.Clear();
          if (!MPick) {
            GlobalVars.SelectedSceneActors.Clear();
            GlobalVars.SelectedSceneActors.Add(SceneActorCombobox.SelectedIndex - 1);
          } else {
            MPick = false;
          }
        }
      } catch (Exception err) {
        Interaction.MsgBox("Error in scene actor selection processing." + Environment.NewLine + Environment.NewLine + "Debug Info: " + err.Message, MsgBoxStyle.Critical);
        SceneActorCombobox.SelectedIndex = 0;
        RoomActorCombobox.SelectedIndex = 0;
        return;
      }
    }

    public void UpdateActors() {
      try {
        if (GlobalVars.OnSceneActor) {
          for (int i = 0, loopTo = GlobalVars.SelectedSceneActors.Count - 1; i <= loopTo; i++) {
            i1 = Conversions.ToInteger(GlobalVars.SelectedSceneActors[i]);
            if (ActorNumberText.Text.Length == 4) {
              SceneActors[i1].no = Convert.ToUInt16(ActorNumberText.Text, 16);
            }

            if (ActorVarText.Text.Length == 4) {
              SceneActors[i1].var = Convert.ToUInt16(ActorVarText.Text, 16);
            }

            if (Information.IsNumeric(TextBox7.Text) & ChangePosition[0])
              SceneActors[i1].x = Conversions.ToShort(TextBox7.Text);
            if (Information.IsNumeric(TextBox8.Text) & ChangePosition[1])
              SceneActors[i1].y = Conversions.ToShort(TextBox8.Text);
            if (Information.IsNumeric(TextBox9.Text) & ChangePosition[2])
              SceneActors[i1].z = Conversions.ToShort(TextBox9.Text);
          }
        } else {
          for (int i = 0, loopTo1 = GlobalVars.SelectedRoomActors.Count - 1; i <= loopTo1; i++) {
            i1 = Conversions.ToInteger(GlobalVars.SelectedRoomActors[i]);
            if (Information.IsNumeric(TextBox7.Text) & ChangePosition[0]) {
              RoomActors[i1].x = (short)Conversions.ToInteger(TextBox7.Text);
            }

            if (Information.IsNumeric(TextBox8.Text) & ChangePosition[1]) {
              RoomActors[i1].y = (short)Conversions.ToInteger(TextBox8.Text);
            }

            if (Information.IsNumeric(TextBox9.Text) & ChangePosition[2]) {
              RoomActors[i1].z = (short)Conversions.ToInteger(TextBox9.Text);
            }

            if (Information.IsNumeric(TextBox10.Text) & ChangePosition[3]) {
              RoomActors[i1].xr = (short)Conversions.ToInteger(TextBox10.Text);
            }

            if (Information.IsNumeric(TextBox11.Text) & ChangePosition[4]) {
              RoomActors[i1].yr = (short)Conversions.ToInteger(TextBox11.Text);
            }

            if (Information.IsNumeric(TextBox12.Text) & ChangePosition[5]) {
              RoomActors[i1].zr = (short)Conversions.ToInteger(TextBox12.Text);
            }

            if (ActorNumberText.Text.Length == 4) {
              RoomActors[i1].no = Convert.ToUInt16(ActorNumberText.Text, 16);
            }

            if (ActorVarText.Text.Length == 4) {
              RoomActors[i1].var = Convert.ToUInt16(ActorVarText.Text, 16);
            }
          }
        }
      } catch (Exception err) {
      }
    }

    private void UpdateActorIdents() {
      int oldint = 0;
      int c7 = RoomActorCombobox.SelectedIndex;
      string identity = "";
      if (!GlobalVars.OnSceneActor) {
        oldint = c7;
        RoomActorCombobox.Items.Clear();
        RoomActorCombobox.Items.Add("Room Actor Selection");
        for (int i = 0, loopTo = RoomActors.Length - 1; i <= loopTo; i++)
          RoomActorCombobox.Items.Add(i.ToString() + " - " + IdentifyActor(0U, i));
        if (GlobalVars.SelectedRoomActors.Count == 1) {
          RoomActorCombobox.SelectedIndex = oldint;
        }
      } else {
        oldint = SceneActorCombobox.SelectedIndex;
        SceneActorCombobox.Items.Clear();
        SceneActorCombobox.Items.Add("None selected");
        for (int i = 0, loopTo1 = SceneActors.Length - 1; i <= loopTo1; i++)
          SceneActorCombobox.Items.Add((i + 1).ToString() + " - " + IdentifyActor(1U, i));
        if (GlobalVars.SelectedSceneActors.Count == 1) {
          SceneActorCombobox.SelectedIndex = oldint;
        }
      }
    }

    private void Button2_Click(object sender, EventArgs e) {
      UpdateActors();
      UpdateActorIdents();
    }

    private void ScrollSensitivity(object sender, MouseEventArgs e) {
      int tAxis = ToolModes.Axis;
      if (e.Delta < 0) {
        if (tAxis > 0) {
          tAxis -= 1;
        } else {
          tAxis = 2;
        }
      } else if (tAxis < 2) {
        tAxis += 1;
      } else {
        tAxis = 0;
      }

      LockAxes(tAxis);
    }

    private void CameraSensitivity(bool up) {
      if (!up) {
        if (TrackBar1.Value > TrackBar1.Minimum) {
          TrackBar1.Value -= 1;
        }
      } else if (TrackBar1.Value < TrackBar1.Maximum) {
        TrackBar1.Value += 1;
      }

      CameraCoef = TrackBar1.Value;
    }

    private void MatchCollision(int mm) {
      Working = true;
      Label28.Show();
      ProgressBar1.Maximum = CollisionVerts.x.Count;
      for (int i = 0, loopTo = CollisionVerts.x.Count - 1; i <= loopTo; i++) {
        ProgressBar1.Value += 1;
        ProgressBar1.Refresh();
        // For i0 As Integer = 0 To Vertices.Length - 1
        // For i1 = 0 To Vertices(i0).x.Count - 1
        // If Vertices(i0).ox(i1) = CollisionVerts.ox(i) And Vertices(i0).oy(i1) = CollisionVerts.oy(i) And Vertices(i0).oz(i1) = CollisionVerts.oz(i) Then
        // Select Case mm
        // Case 0
        // CollisionVerts.x(i) = Vertices(i0).x(i1)
        // CollisionVerts.y(i) = Vertices(i0).y(i1)
        // CollisionVerts.z(i) = Vertices(i0).z(i1)
        // Case 1
        // Vertices(i0).x(i1) = CollisionVerts.x(i)
        // Vertices(i0).y(i1) = CollisionVerts.y(i)
        // Vertices(i0).z(i1) = CollisionVerts.z(i)
        // End Select
        // End If
        // Next
        // Next
      }

      ProgressBar1.Value = 0;
      Label28.Hide();
      Working = false;
    }

    private void Button16_Click(object sender, EventArgs e) {
      MatchCollision(1);
    }

    private void Button15_Click(object sender, EventArgs e) {
      MatchCollision(0);
    }

    private void CollisionMeshToolStripMenuItem_Click(object sender, EventArgs e) {
      RenderCollision = true;
      RenderGraphics = false;
    }

    private void BothToolStripMenuItem_Click(object sender, EventArgs e) {
      RenderGraphics = true;
      RenderCollision = true;
    }

    private void FilledToolStripMenuItem_Click_1(object sender, EventArgs e) {
      wireframe = false;
      Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_FILL);
    }

    private void WireframeToolStripMenuItem_Click_1(object sender, EventArgs e) {
      wireframe = true;
      Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_LINE);
    }

    private void SimpleOpenGlControl1_MouseMove(object sender, MouseEventArgs e) {
      oldLocalMouse = UoTRender.PointToClient(Cursor.Position);
    }

    public void ToggleTabs() {
      if (EditingTabs.Visible) {
        EditingTabs.Visible = false;
        UoTRender.Width += 235;
        UndoToolStripMenuItem.Checked = false;
        Reshape();
      } else {
        EditingTabs.Visible = true;
        UoTRender.Width -= 235;
        UndoToolStripMenuItem.Checked = true;
        Reshape();
      }
    }

    private void Button18_MouseDown(object sender, MouseEventArgs e) {
      ButtonPress = 0;
      ActorInputTimer.Start();
    }

    private void Button18_MouseUp(object sender, MouseEventArgs e) {
      ActorInputTimer.Stop();
    }

    private void Timer1_Tick(object sender, EventArgs e) {
      CosYRot = Math.Cos(CamYRotd) * ToolSensitivity;
      SinYRot = Math.Sin(CamYRotd) * ToolSensitivity;
      switch (ToolModes.CurrentTool) {
        case (int)ToolID.ACTOR: {
            switch (ButtonPress) {
              case 0: {
                  if (GlobalVars.OnSceneActor) {
                    for (int i = 0, loopTo = GlobalVars.SelectedSceneActors.Count - 1; i <= loopTo; i++) {
                      i1 = Conversions.ToInteger(GlobalVars.SelectedSceneActors[i]);
                      SceneActors[i1].x = (short)(SceneActors[i1].x - CosYRot);
                      SceneActors[i1].z = (short)(SceneActors[i1].z - SinYRot);
                    }
                  } else {
                    for (int i = 0, loopTo1 = GlobalVars.SelectedRoomActors.Count - 1; i <= loopTo1; i++) {
                      RoomActors[Conversions.ToInteger(GlobalVars.SelectedRoomActors[i])].x = (short)(RoomActors[Conversions.ToInteger(GlobalVars.SelectedRoomActors[i])].x - CosYRot);
                      RoomActors[Conversions.ToInteger(GlobalVars.SelectedRoomActors[i])].z = (short)(RoomActors[Conversions.ToInteger(GlobalVars.SelectedRoomActors[i])].z - SinYRot);
                    }
                  }

                  break;
                }

              case 1: {
                  if (GlobalVars.OnSceneActor) {
                    for (int i = 0, loopTo2 = GlobalVars.SelectedSceneActors.Count - 1; i <= loopTo2; i++)
                      SceneActors[Conversions.ToInteger(GlobalVars.SelectedSceneActors[i])].y = (short)(SceneActors[Conversions.ToInteger(GlobalVars.SelectedSceneActors[i])].y + ToolSensitivity);
                  } else {
                    for (int i = 0, loopTo3 = GlobalVars.SelectedRoomActors.Count - 1; i <= loopTo3; i++)
                      RoomActors[Conversions.ToInteger(GlobalVars.SelectedRoomActors[i])].y = (short)(RoomActors[Conversions.ToInteger(GlobalVars.SelectedRoomActors[i])].y + ToolSensitivity);
                  }

                  break;
                }

              case 2: {
                  if (GlobalVars.OnSceneActor) {
                    for (int i = 0, loopTo4 = GlobalVars.SelectedSceneActors.Count - 1; i <= loopTo4; i++)
                      SceneActors[Conversions.ToInteger(GlobalVars.SelectedSceneActors[i])].y = (short)(SceneActors[Conversions.ToInteger(GlobalVars.SelectedSceneActors[i])].y - ToolSensitivity);
                  } else {
                    for (int i = 0, loopTo5 = GlobalVars.SelectedRoomActors.Count - 1; i <= loopTo5; i++)
                      RoomActors[Conversions.ToInteger(GlobalVars.SelectedRoomActors[i])].y = (short)(RoomActors[Conversions.ToInteger(GlobalVars.SelectedRoomActors[i])].y - ToolSensitivity);
                  }

                  break;
                }

              case 3: {
                  if (GlobalVars.OnSceneActor) {
                    for (int i = 0, loopTo6 = GlobalVars.SelectedSceneActors.Count - 1; i <= loopTo6; i++) {
                      i1 = Conversions.ToInteger(GlobalVars.SelectedSceneActors[i]);
                      SceneActors[i1].x = (short)(SceneActors[i1].x + CosYRot);
                      SceneActors[i1].z = (short)(SceneActors[i1].z + SinYRot);
                    }
                  } else {
                    for (int i = 0, loopTo7 = GlobalVars.SelectedRoomActors.Count - 1; i <= loopTo7; i++) {
                      RoomActors[Conversions.ToInteger(GlobalVars.SelectedRoomActors[i])].x = (short)(RoomActors[Conversions.ToInteger(GlobalVars.SelectedRoomActors[i])].x + CosYRot);
                      RoomActors[Conversions.ToInteger(GlobalVars.SelectedRoomActors[i])].z = (short)(RoomActors[Conversions.ToInteger(GlobalVars.SelectedRoomActors[i])].z + SinYRot);
                    }
                  }

                  break;
                }

              case 4: {
                  if (GlobalVars.OnSceneActor) {
                    for (int i = 0, loopTo8 = GlobalVars.SelectedSceneActors.Count - 1; i <= loopTo8; i++) {
                      i1 = Conversions.ToInteger(GlobalVars.SelectedSceneActors[i]);
                      SceneActors[i1].x = (short)(SceneActors[i1].x - SinYRot);
                      SceneActors[i1].z = (short)(SceneActors[i1].z + CosYRot);
                    }
                  } else {
                    for (int i = 0, loopTo9 = GlobalVars.SelectedRoomActors.Count - 1; i <= loopTo9; i++) {
                      RoomActors[Conversions.ToInteger(GlobalVars.SelectedRoomActors[i])].x = (short)(RoomActors[Conversions.ToInteger(GlobalVars.SelectedRoomActors[i])].x - CosYRot);
                      RoomActors[Conversions.ToInteger(GlobalVars.SelectedRoomActors[i])].z = (short)(RoomActors[Conversions.ToInteger(GlobalVars.SelectedRoomActors[i])].z + SinYRot);
                    }
                  }

                  break;
                }

              case 5: {
                  if (GlobalVars.OnSceneActor) {
                    for (int i = 0, loopTo10 = GlobalVars.SelectedSceneActors.Count - 1; i <= loopTo10; i++) {
                      i1 = Conversions.ToInteger(GlobalVars.SelectedSceneActors[i]);
                      SceneActors[i1].x = (short)(SceneActors[i1].x + SinYRot);
                      SceneActors[i1].z = (short)(SceneActors[i1].z - CosYRot);
                    }
                  } else {
                    for (int i = 0, loopTo11 = GlobalVars.SelectedRoomActors.Count - 1; i <= loopTo11; i++) {
                      RoomActors[Conversions.ToInteger(GlobalVars.SelectedRoomActors[i])].x = (short)(RoomActors[Conversions.ToInteger(GlobalVars.SelectedRoomActors[i])].x + CosYRot);
                      RoomActors[Conversions.ToInteger(GlobalVars.SelectedRoomActors[i])].z = (short)(RoomActors[Conversions.ToInteger(GlobalVars.SelectedRoomActors[i])].z - SinYRot);
                    }
                  }

                  break;
                }
            }

            UpdateActorPos();
            break;
          }

        case (int)ToolID.VERTEX: {
            if (SelectedCollisionVert.Count > 0) {
              var loopTo12 = SelectedCollisionVert.Count - 1;
              for (i1 = 0; i1 <= loopTo12; i1++) {
                switch (ButtonPress) {
                  case 0: {
                      CollisionVerts.x[Conversions.ToInteger(SelectedCollisionVert[i1])] -= CosYRot;
                      CollisionVerts.z[Conversions.ToInteger(SelectedCollisionVert[i1])] -= SinYRot;
                      break;
                    }

                  case 1: {
                      CollisionVerts.y[Conversions.ToInteger(SelectedCollisionVert[i1])] += ToolSensitivity;
                      break;
                    }

                  case 2: {
                      CollisionVerts.y[Conversions.ToInteger(SelectedCollisionVert[i1])] -= ToolSensitivity;
                      break;
                    }

                  case 3: {
                      CollisionVerts.x[Conversions.ToInteger(SelectedCollisionVert[i1])] += CosYRot;
                      CollisionVerts.z[Conversions.ToInteger(SelectedCollisionVert[i1])] += SinYRot;
                      break;
                    }

                  case 4: {
                      CollisionVerts.x[Conversions.ToInteger(SelectedCollisionVert[i1])] -= SinYRot;
                      CollisionVerts.z[Conversions.ToInteger(SelectedCollisionVert[i1])] += CosYRot;
                      break;
                    }

                  case 5: {
                      CollisionVerts.x[Conversions.ToInteger(SelectedCollisionVert[i1])] += SinYRot;
                      CollisionVerts.z[Conversions.ToInteger(SelectedCollisionVert[i1])] -= CosYRot;
                      break;
                    }
                }
              }
            }

            break;
          }

        case (int)ToolID.EDGE: {
            break;
          }

        case (int)ToolID.FACE: {
            break;
          }
      }
    }

    private void Button8_MouseDown(object sender, MouseEventArgs e) {
      ButtonPress = 1;
      ActorInputTimer.Start();
    }

    private void Button8_MouseUp(object sender, MouseEventArgs e) {
      ActorInputTimer.Stop();
    }

    private void Button20_MouseDown(object sender, MouseEventArgs e) {
      ButtonPress = 2;
      ActorInputTimer.Start();
    }

    private void Button20_MouseUp(object sender, MouseEventArgs e) {
      ActorInputTimer.Stop();
    }

    private void Button4_MouseDown(object sender, MouseEventArgs e) {
      ButtonPress = 3;
      ActorInputTimer.Start();
    }

    private void Button4_MouseUp(object sender, MouseEventArgs e) {
      ActorInputTimer.Stop();
    }

    private void Button19_MouseDown(object sender, MouseEventArgs e) {
      ButtonPress = 5;
      ActorInputTimer.Start();
    }

    private void Button19_MouseUp(object sender, MouseEventArgs e) {
      ActorInputTimer.Stop();
    }

    private void Button17_MouseDown(object sender, MouseEventArgs e) {
      ButtonPress = 4;
      ActorInputTimer.Start();
    }

    private void Button17_MouseUp(object sender, MouseEventArgs e) {
      ActorInputTimer.Stop();
    }

    private void SetupToolStripMenuItem_Click_2(object sender, EventArgs e) {
      My.MyProject.Forms.SetupDialog.ShowDialog();
    }

    private void TextBox1_TextChanged(object sender, EventArgs e) {
      ChangePosition[0] = true;
    }

    private void TextBox2_TextChanged(object sender, EventArgs e) {
      ChangePosition[1] = true;
    }

    private void TextBox3_TextChanged(object sender, EventArgs e) {
      ChangePosition[2] = true;
    }

    private void CollisionMeshToolStripMenuItem_Click_1(object sender, EventArgs e) {
      if (RenderCollision == false) {
        RenderCollision = true;
        CollisionMeshToolStripMenuItem.Checked = true;
      } else {
        RenderCollision = false;
        CollisionMeshToolStripMenuItem.Checked = false;
      }
    }

    private void Button21_Click(object sender, EventArgs e) {
      MatchCollision(2);
    }

    private void ToolStripMenuItem3_Click(object sender, EventArgs e) {
      ToolModes.CurrentTool = (int)ToolID.COLTRI;
    }

    private void MainWin_ResizeEnd(object sender, EventArgs e) {
      if (Width < 800) {
        Width = 800;
      }

      if (Height < 600) {
        Height = 600;
      }

      Reshape();
    }

    private void ChangeColor() {
      if (!string.IsNullOrEmpty(ColTypeText.Text)) {
        for (int i = 0, loopTo = CollisionPolies.Length - 1; i <= loopTo; i++) {
          if (Conversions.ToInteger(ColTypeText.Text) == CollisionPolies[i].Param) {
            CollisionTriColor[i] = new Structs.CollisionTriColorSelect
                {g = 0, b = 0};
          } else {
            CollisionTriColor[i] = new Structs.CollisionTriColorSelect
                {g = 1, b = 1};
          }
        }
      } else {
        for (int i = 0, loopTo1 = CollisionPolies.Length - 1; i <= loopTo1; i++) {
          CollisionTriColor[i] = new Structs.CollisionTriColorSelect
              {g = 1, b = 1};
        }
      }
    }

    private void ComboBox1_SelectedIndexChanged_1(object sender, EventArgs e) {
      if (ColTypeBox.SelectedIndex > 0) {
        int SelParam = CollisionPolies[ColTypeBox.SelectedIndex - 1].Param;
        string v1 = ColTypes[SelParam].unk1.ToString("X4");
        string v2 = ColTypes[SelParam].unk2.ToString("X4");
        string v3 = ColTypes[SelParam].unk3.ToString("X4");
        string v4 = ColTypes[SelParam].unk4.ToString("X3");
        string v5 = ColTypes[SelParam].WalkOnSound.ToString("X0");
        ColTypeText.Text = (ColTypeBox.SelectedIndex - 1).ToString();
        ColVar1.Text = v1;
        ColVar2.Text = v2;
        ColVar3.Text = v3;
        ColVar4.Text = v4;
        ColWalkSound.Text = v5;
        ColWalkSound.Enabled = true;
        ColVar1.Enabled = true;
        ColVar3.Enabled = true;
        ColVar2.Enabled = true;
        ColVar4.Enabled = true;
        if (!colTri) {
          ChangeColor();
          colTri = false;
        }
      } else {
        ColTypeText.Text = "";
        ColVar1.Text = "";
        ColVar3.Text = "";
        ColVar2.Text = "";
        ColVar4.Text = "";
        ColWalkSound.Text = "";
        ColWalkSound.Enabled = false;
        ColVar1.Enabled = false;
        ColVar3.Enabled = false;
        ColVar2.Enabled = false;
        ColVar4.Enabled = false;
        ChangeColor();
      }
    }

    private void Button22_Click_1(object sender, EventArgs e) {
      if (CollisionPolies.Length > 0) {
        if (ExitCombobox.SelectedIndex > 0) {
          SceneExits[ExitCombobox.SelectedIndex - 1].Index = Convert.ToUInt16(ExitTextBox.Text, 16);
        }

        ColTypes[ColTypeBox.SelectedIndex - 1].unk1 = Convert.ToUInt32(ColVar1.Text, 16);
        ColTypes[ColTypeBox.SelectedIndex - 1].unk2 = Convert.ToUInt32(ColVar2.Text, 16);
        ColTypes[ColTypeBox.SelectedIndex - 1].unk3 = Convert.ToUInt32(ColVar3.Text, 16);
        ColTypes[ColTypeBox.SelectedIndex - 1].unk4 = Convert.ToUInt32(ColVar4.Text, 16);
        ColTypes[ColTypeBox.SelectedIndex - 1].WalkOnSound = (byte)Convert.ToUInt32(ColWalkSound.Text, 16);
      }
    }

    private void ComboBox8_SelectedIndexChanged_1(object sender, EventArgs e) {
      if (ExitCombobox.SelectedIndex > 0) {
        ExitTextBox.Enabled = true;
        ExitTextBox.Text = SceneExits[ExitCombobox.SelectedIndex - 1].Index.ToString("X4");
      } else {
        ExitTextBox.Enabled = false;
        ExitTextBox.Text = "";
      }
    }

    private void Button16_Click_1(object sender, EventArgs e) {
      MatchCollision(0);
    }

    private void Button15_Click_1(object sender, EventArgs e) {
      MatchCollision(1);
    }

    private void CheckBox13_CheckedChanged(object sender, EventArgs e) {
      if (HideActors[0]) {
        HideActors[0] = false;
      } else {
        HideActors[0] = true;
      }
    }

    private void CheckBox14_CheckedChanged(object sender, EventArgs e) {
      if (HideActors[1]) {
        HideActors[1] = false;
      } else {
        HideActors[1] = true;
      }
    }

    private void CheckBox15_CheckedChanged(object sender, EventArgs e) {
      if (HideActors[2]) {
        HideActors[2] = false;
      } else {
        HideActors[2] = true;
      }
    }

    private void Button23_Click_1(object sender, EventArgs e) {
      My.MyProject.Forms.ActorPresets.Show();
      My.MyProject.Forms.ActorPresets.Focus();
    }

    private void TextBox22_TextChanged(object sender, EventArgs e) {
      ChangePosition[3] = true;
    }

    private void TextBox21_TextChanged(object sender, EventArgs e) {
      ChangePosition[4] = true;
    }

    private void Button26_MouseDown(object sender, MouseEventArgs e) {
      ButtonPress = 6;
      ActorInputTimer.Start();
    }

    private void Button26_MouseUp(object sender, MouseEventArgs e) {
      ActorInputTimer.Stop();
    }

    private void Button24_MouseDown(object sender, MouseEventArgs e) {
      ButtonPress = 7;
      ActorInputTimer.Start();
    }

    private void Button24_MouseUp(object sender, MouseEventArgs e) {
      ActorInputTimer.Stop();
    }

    private void Button27_MouseDown(object sender, MouseEventArgs e) {
      ButtonPress = 8;
      ActorInputTimer.Start();
    }

    private void Button27_MouseUp(object sender, MouseEventArgs e) {
      ActorInputTimer.Stop();
    }

    private void Button25_MouseDown(object sender, MouseEventArgs e) {
      ButtonPress = 9;
      ActorInputTimer.Start();
    }

    private void Button25_MouseUp(object sender, MouseEventArgs e) {
      ActorInputTimer.Stop();
    }

    private void ResetAllActorsToolStripMenuItem_Click(object sender, EventArgs e) {
      for (int i = 0, loopTo = RoomActors.Length - 1; i <= loopTo; i++) {
        RoomActors[i].x = RoomActors[i].x;
        RoomActors[i].y = RoomActors[i].y;
        RoomActors[i].z = RoomActors[i].z;
        RoomActors[i].xr = RoomActors[i].xr;
        RoomActors[i].yr = RoomActors[i].yr;
        RoomActors[i].zr = RoomActors[i].zr;
      }
    }

    private void ResetAllSceneActorsToolStripMenuItem_Click(object sender, EventArgs e) {
      for (int i = 0, loopTo = SceneActors.Length - 1; i <= loopTo; i++) {
        SceneActors[i].x = SceneActors[i].x;
        SceneActors[i].y = SceneActors[i].y;
        SceneActors[i].z = SceneActors[i].z;
      }
      // For i As Integer = 0 To linkx.Count - 1
      // linkx(i) = olinkx(i)
      // linky(i) = olinky(i)
      // linkz(i) = olinkz(i)
      // linkxr(i) = olinkxr(i)
      // linkyr(i) = olinkyr(i)
      // linkzr(i) = olinkzr(i)
      // Next
    }

    private void ResetActors(bool all) {
      if (!GlobalVars.OnSceneActor) {
        for (int i = 0, loopTo = GlobalVars.SelectedRoomActors.Count - 1; i <= loopTo; i++) {
          i1 = Conversions.ToInteger(GlobalVars.SelectedRoomActors[i]);
          RoomActors[i1].x = RoomActors[i1].x;
          RoomActors[i1].y = RoomActors[i1].y;
          RoomActors[i1].z = RoomActors[i1].z;
          RoomActors[i1].xr = RoomActors[i1].xr;
          RoomActors[i1].yr = RoomActors[i1].yr;
          RoomActors[i1].zr = RoomActors[i1].zr;
        }
      } else {
        for (int i = 0, loopTo1 = GlobalVars.SelectedSceneActors.Count - 1; i <= loopTo1; i++) {
          i1 = Conversions.ToInteger(GlobalVars.SelectedSceneActors[i]);
          SceneActors[i1].x = SceneActors[i1].x;
          SceneActors[i1].y = SceneActors[i1].y;
          SceneActors[i1].z = SceneActors[i1].z;
        }
      }
    }

    private void EditDatabaseToolStripMenuItem_Click(object sender, EventArgs e) {
      Process.Start(Application.StartupPath + GlobalVars.ExtraDataPrefix + @"\actor_db.txt");
    }

    private void CheckBox13_CheckedChanged_1(object sender, EventArgs e) {
      if (HideActors[0]) {
        HideActors[0] = false;
      } else {
        HideActors[0] = true;
      }
    }

    private void CheckBox14_CheckedChanged_1(object sender, EventArgs e) {
      if (HideActors[1]) {
        HideActors[1] = false;
      } else {
        HideActors[1] = true;
      }
    }

    private void CheckBox15_CheckedChanged_1(object sender, EventArgs e) {
      if (HideActors[2]) {
        HideActors[2] = false;
      } else {
        HideActors[2] = true;
      }
    }

    private void SelectAllRoomActorsToolStripMenuItem_Click(object sender, EventArgs e) {
      if (RoomActors.Length > 0) {
        MPick = true;
        GlobalVars.SelectedRoomActors.Clear();
        GlobalVars.SelectedSceneActors.Clear();
        for (int i = 0, loopTo = rmActorCount - 1; i <= loopTo; i++)
          GlobalVars.SelectedRoomActors.Add(i);
        RoomActorCombobox.SelectedIndex = 0;
      }
    }

    private void SelectAllSceneActorsToolStripMenuItem_Click(object sender, EventArgs e) {
      if (SceneActors.Length > 0) {
        MPick = true;
        GlobalVars.SelectedRoomActors.Clear();
        GlobalVars.SelectedSceneActors.Clear();
        for (int i = 0, loopTo = SceneActors.Length - 1; i <= loopTo; i++)
          GlobalVars.SelectedSceneActors.Add(i);
        SceneActorCombobox.SelectedIndex = 0;
      }
    }

    private void TextBox7_TextChanged(object sender, EventArgs e) {
      ChangePosition[0] = true;
    }

    private void TextBox8_TextChanged(object sender, EventArgs e) {
      ChangePosition[1] = true;
    }

    private void TextBox9_TextChanged(object sender, EventArgs e) {
      ChangePosition[2] = true;
    }

    private void TextBox10_TextChanged(object sender, EventArgs e) {
      ChangePosition[3] = true;
    }

    private void TextBox11_TextChanged(object sender, EventArgs e) {
      ChangePosition[4] = true;
    }

    private void TextBox12_TextChanged(object sender, EventArgs e) {
      ChangePosition[5] = true;
    }

    private void CheckBox5_CheckedChanged(object sender, EventArgs e) {
      if (HideActors[3]) {
        HideActors[3] = false;
      } else {
        HideActors[3] = true;
      }
    }

    private void ViewingMeshToolStripMenuItem1_Click(object sender, EventArgs e) {
      if (RenderGraphics) {
        RenderGraphics = false;
        ViewingMeshToolStripMenuItem1.Checked = false;
      } else if (!RenderGraphics) {
        RenderGraphics = true;
        ViewingMeshToolStripMenuItem1.Checked = true;
      }
    }

    private void SetVariables(int ftype) {
      GlobalVars.DLParser.Initialize();
      switch (ftype) {
        case 0: {
            GlobalVars.CurrentBank = 0x3;
            RenderGraphics = true;
            RenderCollision = true;
            LoadedDataType = (int)Structs.FileTypes.MAP;
            RenderModeToolStripMenuItem.Enabled = true;
            ViewingMeshToolStripMenuItem1.Checked = true;
            CollisionMeshToolStripMenuItem.Checked = true;
            EditingTabs.TabPages.Remove(ActorsTab);
            EditingTabs.TabPages.Remove(LevelFlagsTab);
            EditingTabs.TabPages.Add(ActorsTab);
            EditingTabs.TabPages.Add(LevelFlagsTab);
            GlobalVars.objectset = 0;
            LoadedDataType = (int)Structs.FileTypes.MAP;
            ProcessMapHeader();
            ProcessSceneHeader();
            GetEntryPoints();
            break;
          }

        case 1: {
            GlobalVars.CurrentBank = 0x6;
            RenderGraphics = true;
            RenderCollision = false;
            SwitchTool((int)ToolID.CAMERA);
            LoadedDataType = (int)Structs.FileTypes.ACTORMODEL;
            EditingTabs.TabPages.Remove(ActorsTab);
            EditingTabs.TabPages.Remove(LevelFlagsTab);
            GetEntryPoints();
            break;
          }
      }
    }

    private void ExitToolStripMenuItem_Click(object sender, EventArgs e) {
      Close();
    }

    private void OptionsToolStripMenuItem1_Click(object sender, EventArgs e) {
      My.MyProject.Forms.SetupDialog.ShowDialog();
    }

    private void UndoToolStripMenuItem_Click(object sender, EventArgs e) {
      ToggleTabs();
    }

    private void ActorGroupText_TextChanged(object sender, EventArgs e) {
      if (string.IsNullOrEmpty(ActorGroupText.Text))
        ActorGroupText.Text = "0001";
    }

    private void HighlightToolStripMenuItem_Click(object sender, EventArgs e) {
      if (!Highlight)
        Highlight = true;
      else
        Highlight = false;
    }

    private void SaveToolStripMenuItem_Click(object sender, EventArgs e) {
      SaveData(LoadedDataType, false);
      SaveFiles(GlobalVars.DefROM);
    }

    private void SaveData(int DataType, bool SaveAs) {
      if (LoadedDataType == (int)Structs.FileTypes.MAP) {
        // If IndMapFileName = "" Then
        // If MsgBox("Would you like to create backups of the current map and scene? (RECOMMENDED)" & Environment.NewLine & Environment.NewLine & _
        // "You can restore previously created backups to your ROM by right clicking the file in the tree view, and clicking restore backup.", MsgBoxStyle.Question, "Create backups?") Then
        // If Not Directory.Exists(AppDirectory & "\Backups") Then
        // Directory.CreateDirectory(AppDirectory & "\Backups")
        // End If
        // If Not Directory.Exists(AppDirectory & "\Backups\" & DefROM) Then
        // Directory.CreateDirectory(AppDirectory & "\Backups\" & DefROM)
        // End If
        // Dim backupmap As FileStream = File.Create(MapFileName & "_backup_" & Date.Now.ToShortTimeString.Replace(":", "").Replace(" ", "") & ".zmap")
        // Dim backupsc As FileStream = File.Create(ScFileName & "_backup_" & Date.Now.ToShortTimeString.Replace(":", "").Replace(" ", "") & ".zscene")
        // backupmap.Write(ZFileBuffer, 0, ZFileBuffer.Length - 1)
        // backupsc.Write(ZSceneBuffer, 0, ZSceneBuffer.Length - 1)
        // backupmap.Dispose()
        // backupsc.Dispose()
        // End If
        // End If

        // start saving to room file buffer...

        int DLStart = 0;
        for (int i = 0, loopTo = GlobalVars.N64DList.Length - 1; i <= loopTo; i++) {
          DLStart = (int)GlobalVars.N64DList[i].StartPos.Offset;
          for (int ii = 0, loopTo1 = GlobalVars.N64DList[i].CommandCount - 1; ii <= loopTo1; ii++) {
            GlobalVars.N64DList[i].CommandsCopy[ii] = GlobalVars.N64DList[i].Commands[ii];
            GlobalVars.ZFileBuffer[DLStart] = GlobalVars.N64DList[i].Commands[ii].CMDParams[0];
            DLStart += 1;
            Functions.WriteInt24(ref GlobalVars.ZFileBuffer, GlobalVars.N64DList[i].Commands[ii].CMDLow, ref DLStart);
            Functions.WriteInt32(ref GlobalVars.ZFileBuffer, GlobalVars.N64DList[i].Commands[ii].CMDHigh, ref DLStart);
          }
        }

        int AGrOff = Conversions.ToInteger(GlobalVars.ActorGroupOffset);
        for (int i = 0, loopTo2 = GlobalVars.ActorGroups.Count - 1; i <= loopTo2; i++) {
          short argOffset = (short)AGrOff;
          Functions.WriteInt16(ref GlobalVars.ZFileBuffer, ref argOffset, Conversions.ToShort(GlobalVars.ActorGroups[i]));
        }

        if (rmActorCount > 0) {
          int ActorStart = (int)RoomActors[0].offset;
          for (int i = 0, loopTo3 = RoomActors.Length - 1; i <= loopTo3; i++) {
            short argOffset1 = (short)ActorStart;
            Functions.WriteInt16(ref GlobalVars.ZFileBuffer, ref argOffset1, (short)RoomActors[i].no);
            short argOffset2 = (short)ActorStart;
            Functions.WriteInt16(ref GlobalVars.ZFileBuffer, ref argOffset2, RoomActors[i].x);
            short argOffset3 = (short)ActorStart;
            Functions.WriteInt16(ref GlobalVars.ZFileBuffer, ref argOffset3, RoomActors[i].y);
            short argOffset4 = (short)ActorStart;
            Functions.WriteInt16(ref GlobalVars.ZFileBuffer, ref argOffset4, RoomActors[i].z);
            short argOffset5 = (short)ActorStart;
            Functions.WriteInt16(ref GlobalVars.ZFileBuffer, ref argOffset5, RoomActors[i].xr);
            short argOffset6 = (short)ActorStart;
            Functions.WriteInt16(ref GlobalVars.ZFileBuffer, ref argOffset6, RoomActors[i].yr);
            short argOffset7 = (short)ActorStart;
            Functions.WriteInt16(ref GlobalVars.ZFileBuffer, ref argOffset7, RoomActors[i].zr);
            short argOffset8 = (short)ActorStart;
            Functions.WriteInt16(ref GlobalVars.ZFileBuffer, ref argOffset8, (short)RoomActors[i].var);
          }
        }
        // start saving to scene file buffer...

        int ExitOffset = 0;
        for (int i = 0, loopTo4 = SceneExits.Length - 1; i <= loopTo4; i++) {
          ExitOffset = (int)SceneExits[i].scOff;
          short argOffset9 = (short)ExitOffset;
          Functions.WriteInt16(ref GlobalVars.ZSceneBuffer, ref argOffset9, (short)SceneExits[i].Index);
        }

        int ColTypeOff = 0;
        for (int i = 0, loopTo5 = ColTypes.Length - 1; i <= loopTo5; i++) {
          ColTypeOff = (int)ColTypes[i].scOff;
          short argOffset10 = (short)ColTypeOff;
          Functions.WriteInt16(ref GlobalVars.ZSceneBuffer, ref argOffset10, (short)ColTypes[i].unk1);
          short argOffset11 = (short)ColTypeOff;
          Functions.WriteInt16(ref GlobalVars.ZSceneBuffer, ref argOffset11, (short)ColTypes[i].unk2);
          short argOffset12 = (short)ColTypeOff;
          Functions.WriteInt16(ref GlobalVars.ZSceneBuffer, ref argOffset12, (short)ColTypes[i].unk3);
          GlobalVars.ZSceneBuffer[ColTypeOff] = (byte)(ColTypes[i].unk4 >> 8);
          GlobalVars.ZSceneBuffer[ColTypeOff + 1] = (byte)((ColTypes[i].unk4 << 8 >> 4) + ColTypes[i].WalkOnSound);
        }

        if (CollisionPolies.Length > 0) {
          int ColParamOff = 0;
          for (int i = 0, loopTo6 = CollisionPolies.Length - 1; i <= loopTo6; i++) {
            ColParamOff = (int)CollisionPolies[i].scOff;
            short argOffset13 = (short)ColParamOff;
            Functions.WriteInt16(ref GlobalVars.ZSceneBuffer, ref argOffset13, (short)CollisionPolies[i].Param);
          }
        }

        if (scActorCount > 0) {
          int ActorStart = (int)SceneActors[0].offset;
          for (int i = 0, loopTo7 = SceneActors.Length - 1; i <= loopTo7; i++) {
            GlobalVars.ZSceneBuffer[ActorStart + 0] = SceneActors[i].loadMapFront;
            GlobalVars.ZSceneBuffer[ActorStart + 2] = SceneActors[i].loadMapBack;
            ActorStart += 4;
            short argOffset14 = (short)ActorStart;
            Functions.WriteInt16(ref GlobalVars.ZSceneBuffer, ref argOffset14, (short)SceneActors[i].no);
            short argOffset15 = (short)ActorStart;
            Functions.WriteInt16(ref GlobalVars.ZSceneBuffer, ref argOffset15, SceneActors[i].x);
            short argOffset16 = (short)ActorStart;
            Functions.WriteInt16(ref GlobalVars.ZSceneBuffer, ref argOffset16, SceneActors[i].y);
            short argOffset17 = (short)ActorStart;
            Functions.WriteInt16(ref GlobalVars.ZSceneBuffer, ref argOffset17, SceneActors[i].z);
            short argOffset18 = (short)ActorStart;
            Functions.WriteInt16(ref GlobalVars.ZSceneBuffer, ref argOffset18, SceneActors[i].yr);
            short argOffset19 = (short)ActorStart;
            Functions.WriteInt16(ref GlobalVars.ZSceneBuffer, ref argOffset19, (short)SceneActors[i].var);
          }
        }
      }
    }

    private void SaveFiles(string fn) {
      if (string.IsNullOrEmpty(IndMapFileName)) { // write files to ROM
        if (!string.IsNullOrEmpty(GlobalVars.DefROM)) {
          ROMFileStream = new FileStream(fn, FileMode.Open);
          ROMFileStream.Position = MapSt;
          ROMFileStream.Write(GlobalVars.ZFileBuffer, 0, GlobalVars.ZFileBuffer.Length);
          if (LoadedDataType == (int)Structs.FileTypes.MAP) {
            ROMFileStream.Position = SceneSt;
            ROMFileStream.Write(GlobalVars.ZSceneBuffer, 0, GlobalVars.ZSceneBuffer.Length);
          }

          ROMFileStream.Close();
          crc.StartInfo.Arguments = "-u " + GlobalVars.DefROM;
          crc.Start();
          crc.WaitForExit();
        }

        Interaction.MsgBox("ROM saved!", MsgBoxStyle.Information, "Save");
      } else { // write to individually loaded files
        if (GlobalVars.ZFileBuffer is object)
          File.WriteAllBytes(IndMapFileName, GlobalVars.ZFileBuffer);
        if (GlobalVars.ZSceneBuffer is object)
          File.WriteAllBytes(IndScFileName, GlobalVars.ZSceneBuffer);
        Interaction.MsgBox("Individual file(s) saved!", MsgBoxStyle.Information, "Save");
      }
    }

    private void LockAxes(int axis) {
      ToolModes.AxisDisp = AxisStrings[axis];
      switch (axis) {
        case (int)ToolID.NOLOCK: {
            DisableToolStripMenuItem.Checked = true;
            XToolStripMenuItem.Checked = false;
            YToolStripMenuItem.Checked = false;
            break;
          }

        case (int)ToolID.LOCKTOX: {
            DisableToolStripMenuItem.Checked = false;
            XToolStripMenuItem.Checked = true;
            YToolStripMenuItem.Checked = false;
            break;
          }

        case (int)ToolID.LOCKTOY: {
            DisableToolStripMenuItem.Checked = false;
            XToolStripMenuItem.Checked = false;
            YToolStripMenuItem.Checked = true;
            break;
          }
      }

      if (ToolModes.CurrentTool == (int)ToolID.ACTOR) {
        ToolStatusLabel.Text = "Tool: Actor Selector " + ToolModes.AxisDisp;
      } else if (ToolModes.CurrentTool == (int)ToolID.VERTEX) {
        ToolStatusLabel.Text = "Tool: Vertex editor " + ToolModes.AxisDisp;
      }

      ToolModes.Axis = axis;
    }

    private void SwitchTool(int tool) {
      ToolModes.CurrentTool = tool;
      ToolModes.ToolDisp = ToolStrings[tool];
      ToolStatusLabel.Text = "Tool: " + ToolModes.ToolDisp;
      if (tool < (int)ToolID.COLTRI) {
        ToolStatusLabel.Text += ToolModes.AxisDisp;
      }

      PrintTool = false;
      switch (tool) {
        case (int)ToolID.CAMERA: {
            ActorSelectorMenu.Checked = false;
            CollisionSelectorMenu.Checked = false;
            CameraOnlyMenu.Checked = true;
            EdgeToolStripMenuItem.Checked = false;
            VertexToolStripMenuItem.Checked = false;
            TriangleToolStripMenuItem.Checked = false;
            DisplayListSelectorToolStripMenuItem.Checked = false;
            break;
          }

        case var @case when @case == ((int)ToolID.ACTOR & Conversions.ToInteger(LoadedDataType == (int)Structs.FileTypes.MAP)): {
            ActorSelectorMenu.Checked = true;
            CollisionSelectorMenu.Checked = false;
            CameraOnlyMenu.Checked = false;
            EdgeToolStripMenuItem.Checked = false;
            VertexToolStripMenuItem.Checked = false;
            TriangleToolStripMenuItem.Checked = false;
            DisplayListSelectorToolStripMenuItem.Checked = false;
            EditingTabs.SelectedTab = EditingTabs.TabPages["ActorsTab"];
            break;
          }

        case (int)ToolID.VERTEX: {
            ActorSelectorMenu.Checked = false;
            CollisionSelectorMenu.Checked = false;
            CameraOnlyMenu.Checked = false;
            EdgeToolStripMenuItem.Checked = false;
            VertexToolStripMenuItem.Checked = true;
            TriangleToolStripMenuItem.Checked = false;
            DisplayListSelectorToolStripMenuItem.Checked = false;
            break;
          }

        case (int)ToolID.EDGE: {
            ActorSelectorMenu.Checked = false;
            CollisionSelectorMenu.Checked = false;
            CameraOnlyMenu.Checked = false;
            EdgeToolStripMenuItem.Checked = true;
            VertexToolStripMenuItem.Checked = false;
            TriangleToolStripMenuItem.Checked = false;
            DisplayListSelectorToolStripMenuItem.Checked = false;
            break;
          }

        case (int)ToolID.FACE: {
            ActorSelectorMenu.Checked = false;
            CollisionSelectorMenu.Checked = false;
            CameraOnlyMenu.Checked = false;
            EdgeToolStripMenuItem.Checked = false;
            VertexToolStripMenuItem.Checked = false;
            TriangleToolStripMenuItem.Checked = true;
            DisplayListSelectorToolStripMenuItem.Checked = false;
            break;
          }

        case var case1 when case1 == ((int)ToolID.COLTRI & Conversions.ToInteger(LoadedDataType == (int)Structs.FileTypes.MAP)): {
            ActorSelectorMenu.Checked = false;
            CollisionSelectorMenu.Checked = false;
            CameraOnlyMenu.Checked = false;
            EdgeToolStripMenuItem.Checked = false;
            VertexToolStripMenuItem.Checked = false;
            TriangleToolStripMenuItem.Checked = true;
            DisplayListSelectorToolStripMenuItem.Checked = false;
            EditingTabs.SelectedTab = EditingTabs.TabPages["CollisionTab"];
            break;
          }

        case (int)ToolID.DLIST: {
            ActorSelectorMenu.Checked = false;
            CollisionSelectorMenu.Checked = false;
            CameraOnlyMenu.Checked = false;
            EdgeToolStripMenuItem.Checked = false;
            VertexToolStripMenuItem.Checked = false;
            TriangleToolStripMenuItem.Checked = false;
            DisplayListSelectorToolStripMenuItem.Checked = true;
            EditingTabs.SelectedTab = EditingTabs.TabPages["DLTab"];
            break;
          }
      }
    }

    private void XToolStripMenuItem_Click(object sender, EventArgs e) {
      LockAxes((int)ToolID.LOCKTOX);
    }

    private void YToolStripMenuItem_Click(object sender, EventArgs e) {
      LockAxes((int)ToolID.LOCKTOY);
    }

    private void DisableToolStripMenuItem_Click(object sender, EventArgs e) {
      LockAxes((int)ToolID.NONE);
    }

    private void ActorSelectorToolStripMenuItem2_Click(object sender, EventArgs e) {
      SwitchTool((int)ToolID.ACTOR);
    }

    private void CameraOnlyToolStripMenuItem1_Click(object sender, EventArgs e) {
      SwitchTool((int)ToolID.CAMERA);
    }

    private void RotationTimer_Tick(object sender, EventArgs e) {
      RotCoef -= 0x800;
      if (RotCoef == 0) {
        RotCoef = 0x4000;
        RotationTimer.Stop();
      }

      if (RoomActors.Length > 0) {
        switch (EditRotType) {
          case 0: {
              switch (EditRotAxis) {
                case 0: {
                    for (int i = 0, loopTo = GlobalVars.SelectedRoomActors.Count - 1; i <= loopTo; i++)
                      RoomActors[Conversions.ToInteger(GlobalVars.SelectedRoomActors[i])].xr = (short)(RoomActors[Conversions.ToInteger(GlobalVars.SelectedRoomActors[i])].xr + 0x800);
                    break;
                  }

                case 1: {
                    for (int i = 0, loopTo1 = GlobalVars.SelectedRoomActors.Count - 1; i <= loopTo1; i++)
                      RoomActors[Conversions.ToInteger(GlobalVars.SelectedRoomActors[i])].yr = (short)(RoomActors[Conversions.ToInteger(GlobalVars.SelectedRoomActors[i])].yr + 0x800);
                    break;
                  }

                case 2: {
                    for (int i = 0, loopTo2 = GlobalVars.SelectedRoomActors.Count - 1; i <= loopTo2; i++)
                      RoomActors[Conversions.ToInteger(GlobalVars.SelectedRoomActors[i])].zr = (short)(RoomActors[Conversions.ToInteger(GlobalVars.SelectedRoomActors[i])].zr + 0x800);
                    break;
                  }
              }

              break;
            }

          case 1: {
              switch (EditRotAxis) {
                case 0: {
                    for (int i = 0, loopTo3 = GlobalVars.SelectedRoomActors.Count - 1; i <= loopTo3; i++)
                      RoomActors[Conversions.ToInteger(GlobalVars.SelectedRoomActors[i])].xr = (short)(RoomActors[Conversions.ToInteger(GlobalVars.SelectedRoomActors[i])].xr - 0x800);
                    break;
                  }

                case 1: {
                    for (int i = 0, loopTo4 = GlobalVars.SelectedRoomActors.Count - 1; i <= loopTo4; i++)
                      RoomActors[Conversions.ToInteger(GlobalVars.SelectedRoomActors[i])].yr = (short)(RoomActors[Conversions.ToInteger(GlobalVars.SelectedRoomActors[i])].yr - 0x800);
                    break;
                  }

                case 2: {
                    for (int i = 0, loopTo5 = GlobalVars.SelectedRoomActors.Count - 1; i <= loopTo5; i++)
                      RoomActors[Conversions.ToInteger(GlobalVars.SelectedRoomActors[i])].zr = (short)(RoomActors[Conversions.ToInteger(GlobalVars.SelectedRoomActors[i])].zr - 0x800);
                    break;
                  }
              }

              break;
            }
        }
      } else if (SceneActors.Length > 0) {
        switch (EditRotType) {
          case 0: {
              switch (EditRotAxis) {
                case 1: {
                    for (int i = 0, loopTo6 = GlobalVars.SelectedSceneActors.Count - 1; i <= loopTo6; i++)
                      SceneActors[Conversions.ToInteger(GlobalVars.SelectedSceneActors[i])].yr = (short)(SceneActors[Conversions.ToInteger(GlobalVars.SelectedSceneActors[i])].yr + 0x800);
                    break;
                  }
              }

              break;
            }

          case 1: {
              switch (EditRotAxis) {
                case 1: {
                    for (int i = 0, loopTo7 = GlobalVars.SelectedSceneActors.Count - 1; i <= loopTo7; i++)
                      SceneActors[Conversions.ToInteger(GlobalVars.SelectedSceneActors[i])].yr = (short)(SceneActors[Conversions.ToInteger(GlobalVars.SelectedSceneActors[i])].yr - 0x800);
                    break;
                  }
              }

              break;
            }
        }
      }
    }

    private void DegreesToolStripMenuItem_Click(object sender, EventArgs e) {
      EditRotType = 0;
      EditRotAxis = 1;
      RotationTimer.Start();
    }

    private void DegreesToolStripMenuItem1_Click(object sender, EventArgs e) {
      EditRotType = 1;
      EditRotAxis = 1;
      RotationTimer.Start();
    }

    private void DegreesToolStripMenuItem2_Click(object sender, EventArgs e) {
      EditRotType = 0;
      EditRotAxis = 0;
      RotationTimer.Start();
    }

    private void DegreesToolStripMenuItem3_Click(object sender, EventArgs e) {
      EditRotType = 1;
      EditRotAxis = 0;
      RotationTimer.Start();
    }

    private void DegreesToolStripMenuItem4_Click(object sender, EventArgs e) {
      EditRotType = 0;
      EditRotAxis = 2;
      RotationTimer.Start();
    }

    private void DegreesToolStripMenuItem5_Click(object sender, EventArgs e) {
      EditRotType = 1;
      EditRotAxis = 2;
      RotationTimer.Start();
    }

    private void AnimationList_SelectedIndexChanged(object sender, EventArgs e) {
      if (AnimationEntries is object) {
        if (AnimationList.SelectedIndex > -1) {
          CurrAnimation = AnimationList.SelectedIndex;
          CurrentFrame.Maximum = (int)(AnimationEntries[CurrAnimation].FrameCount - 1L);
          GlobalVars.AnimParser.ResetAnimation(ref GlobalVars.AnimationStopWatch, ref GlobalVars.ZAnimationCounter);
          GlobalVars.AnimParser.StopAnimation(ref GlobalVars.AnimationStopWatch, ref GlobalVars.ZAnimationCounter);
          CurrentFrame.Value = 1;
          AnimationElapse.Text = "00:00s";
          FrameNo.Text = "0/" + CurrentFrame.Maximum.ToString();
        }
      }
    }

    private void Button3_Click(object sender, EventArgs e) {
      if (AnimationEntries is object & AnimationList.SelectedIndex > -1) {
        GlobalVars.AnimParser.StartAnimation(ref GlobalVars.AnimationStopWatch, ref GlobalVars.ZAnimationCounter);
      }
    }

    private void CheckBox1_CheckedChanged(object sender, EventArgs e) {
      if (LoopAnimation)
        LoopAnimation = false;
      else
        LoopAnimation = true;
    }

    private void ResetSelectedToolStripMenuItem_Click(object sender, EventArgs e) {
      ResetActors(false);
    }

    private void ResetAllToolStripMenuItem_Click(object sender, EventArgs e) {
      ResetActors(true);
    }

    private void GraphicsToolStripMenuItem_Click(object sender, EventArgs e) {
      if (RenderGraphics)
        RenderGraphics = false;
      else
        RenderGraphics = true;
    }

    private void CollisionOverlayToolStripMenuItem_Click(object sender, EventArgs e) {
      if (RenderCollision)
        RenderCollision = false;
      else
        RenderCollision = true;
    }

    private void WireframeModeToolStripMenuItem_Click(object sender, EventArgs e) {
      ToggleWire();
    }

    private void LoadIndividual_FileOk(object sender, System.ComponentModel.CancelEventArgs e) {
      if (LoadIndividual.FileName.Contains(".zscene")) {
        IndScFileName = LoadIndividual.FileName;
        GlobalVars.ZSceneBuffer = File.ReadAllBytes(IndScFileName);
        MapsCombobox.Items.Clear();
        MapsCombobox.Enabled = true;
        int tScPos = 0;
        int MapCount = 0;
        int MapPos = 0;
        while (GlobalVars.ZSceneBuffer[tScPos] != 0x14) {
          switch (GlobalVars.ZSceneBuffer[tScPos]) {
            case 0x4: {
                MapCount = GlobalVars.ZSceneBuffer[tScPos + 1];
                MapPos = GlobalVars.ZSceneBuffer[tScPos + 5] * 0x10000 + GlobalVars.ZSceneBuffer[tScPos + 6] * 0x100 + GlobalVars.ZSceneBuffer[tScPos + 7];
                for (int i = 0, loopTo = MapCount - 1; i <= loopTo; i++) {
                  MapsCombobox.Items.Add(GlobalVars.ZSceneBuffer[MapPos].ToString("X2") + GlobalVars.ZSceneBuffer[MapPos + 1].ToString("X2") + GlobalVars.ZSceneBuffer[MapPos + 2].ToString("X2") + GlobalVars.ZSceneBuffer[MapPos + 3].ToString("X2"));
                  MapPos += 8;
                }

                break;
              }
          }

          tScPos += 8;
        }

        Text = "Utility of Time - " + LoadIndividual.FileName;
        if (MapsCombobox.Items.Count > 0) {
          MapsCombobox.SelectedIndex = 0;
          EditingTabs.SelectedTab = EditingTabs.TabPages["MiscTab"];
        } else {
          MapsCombobox.Enabled = false;
        }
      } else if (LoadIndividual.FileName.Contains(".zobj")) {
        EditingTabs.SelectedTab = EditingTabs.TabPages["DLTab"];
        Text = "Utility of Time - " + LoadIndividual.FileName;
        IndMapFileName = LoadIndividual.FileName;
        GlobalVars.ZFileBuffer = File.ReadAllBytes(IndMapFileName);
        GlobalVars.ZSceneBuffer = null;
        SetVariables(1);
      }
    }

    private void MapsCombobox_SelectedIndexChanged(object sender, EventArgs e) {
      var Files = Directory.GetFiles(Functions.GetFileName(LoadIndividual.FileName, true));
      for (int i = 0, loopTo = Files.Length - 1; i <= loopTo; i++) {
        if (Files[i].Contains(MapsCombobox.SelectedItem.ToString())) {
          IndMapFileName = Files[i];
          GlobalVars.ZFileBuffer = File.ReadAllBytes(IndMapFileName);
          Start(true);
          return;
        }
      }

      Interaction.MsgBox("Map not found in the same directory as the loaded level!", MsgBoxStyle.Critical, "Error");
    }

    private void PasteActor(int Actor_Type, bool x, bool y, bool z, bool xr, bool yr, bool zr, bool no, bool var) {
      switch (Actor_Type) {
        case 0: {
            for (int i1 = 0, loopTo = GlobalVars.SelectedSceneActors.Count - 1; i1 <= loopTo; i1++) {
              if (x)
                SceneActors[Conversions.ToInteger(GlobalVars.SelectedSceneActors[i1])].x = (short)CopyActor[0];
              if (y)
                SceneActors[Conversions.ToInteger(GlobalVars.SelectedSceneActors[i1])].y = (short)CopyActor[1];
              if (z)
                SceneActors[Conversions.ToInteger(GlobalVars.SelectedSceneActors[i1])].z = (short)CopyActor[2];
              if (yr)
                SceneActors[Conversions.ToInteger(GlobalVars.SelectedSceneActors[i1])].yr = (short)CopyActor[4];
              if (no)
                SceneActors[Conversions.ToInteger(GlobalVars.SelectedSceneActors[i1])].no = (uint)CopyActor[6];
              if (var)
                SceneActors[Conversions.ToInteger(GlobalVars.SelectedSceneActors[i1])].var = (uint)CopyActor[7];
            }

            break;
          }

        case 1: {
            for (int i1 = 0, loopTo1 = GlobalVars.SelectedRoomActors.Count - 1; i1 <= loopTo1; i1++) {
              if (x)
                RoomActors[Conversions.ToInteger(GlobalVars.SelectedRoomActors[i1])].x = (short)CopyActor[0];
              if (y)
                RoomActors[Conversions.ToInteger(GlobalVars.SelectedRoomActors[i1])].y = (short)CopyActor[1];
              if (z)
                RoomActors[Conversions.ToInteger(GlobalVars.SelectedRoomActors[i1])].z = (short)CopyActor[2];
              if (xr)
                RoomActors[Conversions.ToInteger(GlobalVars.SelectedRoomActors[i1])].xr = (short)CopyActor[3];
              if (yr)
                RoomActors[Conversions.ToInteger(GlobalVars.SelectedRoomActors[i1])].yr = (short)CopyActor[4];
              if (zr)
                RoomActors[Conversions.ToInteger(GlobalVars.SelectedRoomActors[i1])].zr = (short)CopyActor[5];
              if (no)
                RoomActors[Conversions.ToInteger(GlobalVars.SelectedRoomActors[i1])].no = (uint)CopyActor[6];
              if (var)
                RoomActors[Conversions.ToInteger(GlobalVars.SelectedRoomActors[i1])].var = (uint)CopyActor[7];
            }

            break;
          }
      }

      UpdateActorPos();
      if (no | var) {
        ActorNumberText.Text = CopyActor[6].ToString("X4");
        ActorVarText.Text = CopyActor[7].ToString("X4");
        UpdateActorIdents();
      }
    }

    private void CopyToolStripMenuItem_Click(object sender, EventArgs e) {
      CopyActor[0] = RoomActors[Conversions.ToInteger(GlobalVars.SelectedRoomActors[0])].x;
      CopyActor[1] = RoomActors[Conversions.ToInteger(GlobalVars.SelectedRoomActors[0])].y;
      CopyActor[2] = RoomActors[Conversions.ToInteger(GlobalVars.SelectedRoomActors[0])].z;
      CopyActor[3] = RoomActors[Conversions.ToInteger(GlobalVars.SelectedRoomActors[0])].xr;
      CopyActor[4] = RoomActors[Conversions.ToInteger(GlobalVars.SelectedRoomActors[0])].yr;
      CopyActor[5] = RoomActors[Conversions.ToInteger(GlobalVars.SelectedRoomActors[0])].zr;
      CopyActor[6] = (int)RoomActors[Conversions.ToInteger(GlobalVars.SelectedRoomActors[0])].no;
      CopyActor[7] = (int)RoomActors[Conversions.ToInteger(GlobalVars.SelectedRoomActors[0])].var;
      PasteToolStripMenuItem.Enabled = true;
      PasteToolStripMenuItem.Text = "Paste attributes from actor " + GlobalVars.SelectedRoomActors[0].ToString();
      ClearClipboardToolStripMenuItem.Enabled = true;
    }

    private void XToolStripMenuItem1_Click(object sender, EventArgs e) {
      PasteActor(GlobalVars.ActorType, true, false, false, false, false, false, false, false);
    }

    private void YToolStripMenuItem1_Click(object sender, EventArgs e) {
      PasteActor(GlobalVars.ActorType, false, true, false, false, false, false, false, false);
    }

    private void ZToolStripMenuItem_Click(object sender, EventArgs e) {
      PasteActor(GlobalVars.ActorType, false, false, true, false, false, false, false, false);
    }

    private void AllToolStripMenuItem1_Click(object sender, EventArgs e) {
      PasteActor(GlobalVars.ActorType, true, true, true, false, false, false, false, false);
    }

    private void XToolStripMenuItem2_Click(object sender, EventArgs e) {
      PasteActor(GlobalVars.ActorType, false, false, false, true, false, false, false, false);
    }

    private void YToolStripMenuItem2_Click(object sender, EventArgs e) {
      PasteActor(GlobalVars.ActorType, false, false, false, false, true, false, false, false);
    }

    private void ZToolStripMenuItem1_Click(object sender, EventArgs e) {
      PasteActor(GlobalVars.ActorType, false, false, false, false, false, true, false, false);
    }

    private void AllToolStripMenuItem_Click_1(object sender, EventArgs e) {
      PasteActor(GlobalVars.ActorType, false, false, false, true, true, true, false, false);
    }

    private void NumberAndVariableToolStripMenuItem_Click(object sender, EventArgs e) {
      PasteActor(GlobalVars.ActorType, false, false, false, false, false, false, true, true);
    }

    private void DeselectToolStripMenuItem_Click(object sender, EventArgs e) {
      GlobalVars.SelectedRoomActors.Clear();
    }

    private void ClearClipboardToolStripMenuItem_Click(object sender, EventArgs e) {
      PasteToolStripMenuItem.Enabled = false;
      PasteToolStripMenuItem.Text = "Paste attributes";
      for (int i = 0; i <= 7; i++)
        CopyActor[i] = -1;
      ClearClipboardToolStripMenuItem.Enabled = false;
    }

    private void RecentROMsItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e) {
      if (File.Exists(e.ClickedItem.Text)) {
        LoadROM.FileName = e.ClickedItem.Text;
        Start(false);
      }
    }

    private void AboutUoTToolStripMenuItem_Click(object sender, EventArgs e) {
      My.MyProject.Forms.AboutBoxDialog.Show();
      My.MyProject.Forms.AboutBoxDialog.Focus();
    }

    private void XToolStripMenuItem3_Click(object sender, EventArgs e) {
      for (int i = 0, loopTo = GlobalVars.SelectedRoomActors.Count - 1; i <= loopTo; i++)
        RoomActors[Conversions.ToInteger(GlobalVars.SelectedRoomActors[i])].x = RoomActors[Conversions.ToInteger(GlobalVars.SelectedRoomActors[0])].x;
    }

    private void YToolStripMenuItem3_Click(object sender, EventArgs e) {
      for (int i = 0, loopTo = GlobalVars.SelectedRoomActors.Count - 1; i <= loopTo; i++)
        RoomActors[Conversions.ToInteger(GlobalVars.SelectedRoomActors[i])].y = RoomActors[Conversions.ToInteger(GlobalVars.SelectedRoomActors[0])].y;
    }

    private void ZToolStripMenuItem2_Click(object sender, EventArgs e) {
      for (int i = 0, loopTo = GlobalVars.SelectedRoomActors.Count - 1; i <= loopTo; i++)
        RoomActors[Conversions.ToInteger(GlobalVars.SelectedRoomActors[i])].z = RoomActors[Conversions.ToInteger(GlobalVars.SelectedRoomActors[0])].z;
    }

    private void SelectAllActorsToolStripMenuItem_Click(object sender, EventArgs e) {
    }

    private void SpawnActor(short x, short y, short z, short CamXRot, short CamYRot, short CamZRot, uint Number, uint Variable, uint Offset) {
      Array.Resize(ref RoomActors, rmActorCount + 1);
      Array.Resize(ref UsedGroupIndex, rmActorCount + 1);
      {
        var withBlock = RoomActors[rmActorCount];
        withBlock.y = (short)(y + CamYRotd);
        withBlock.x = (short)(-x + Math.Sin(CamYRotd) * 640d);
        withBlock.z = (short)(-z - Math.Cos(CamYRotd) * 640d);
        withBlock.xr = CamXRot;
        withBlock.yr = CamYRot;
        withBlock.zr = CamZRot;
        withBlock.no = Number;
        withBlock.var = Variable;
        withBlock.pickR = (byte)GlobalVars.Rand.Next(0, 255);
        withBlock.pickG = (byte)GlobalVars.Rand.Next(0, 255);
        withBlock.pickB = (byte)GlobalVars.Rand.Next(0, 255);
        withBlock.offset = Offset;
      }

      RoomActorCombobox.Items.Add(rmActorCount.ToString() + " - " + IdentifyActor(0U, rmActorCount));
      RoomActorCombobox.SelectedIndex = rmActorCount + 1;
      Array.Resize(ref GlobalVars.ZFileBuffer, GlobalVars.ZFileBuffer.Length - 1 + rmActorCount * 0x16 + 1);
      rmActorCount += 1;
    }

    private void Button6_Click(object sender, EventArgs e) {
      if (!RelocateActorPtr) {
        if (Interaction.MsgBox("Relocate actors to end of file?", MsgBoxStyle.YesNo) == MsgBoxResult.Yes) {
          ActorPointer[2] = (uint)(GlobalVars.ZFileBuffer.Length - 1);
          RelocateActorPtr = true;
        }
      }

      SpawnActor((short)GlobalVars.CamXPos, (short)GlobalVars.CamYPos, (short)GlobalVars.CamZPos, 0, 0, 0, 0xDEADU, 0xBEEFU, 0U);
    }

    private void MainWin_FormClosing(object sender, FormClosingEventArgs e) {
      UoTIniFile.WriteString("Settings", "ToolSensitivity", TrackBar4.Value.ToString());
      UoTIniFile.WriteString("Settings", "CameraSpeed", TrackBar1.Value.ToString());
      UoTIniFile.WriteString("Settings", "WinResW", Width.ToString());
      UoTIniFile.WriteString("Settings", "WinResH", Height.ToString());
      AppExit = true;
    }

    private void DisableDepthTestToolStripMenuItem_Click(object sender, EventArgs e) {
      if (ToolModes.NoDepthTest)
        ToolModes.NoDepthTest = false;
      else
        ToolModes.NoDepthTest = true;
    }

    private void RoomToolStripMenuItem_Click(object sender, EventArgs e) {
      GlobalVars.SelectedRoomActors.Clear();
      GlobalVars.SelectedSceneActors.Clear();
      for (int i = 0, loopTo = RoomActors.Length - 1; i <= loopTo; i++)
        GlobalVars.SelectedRoomActors.Add(i);
    }

    private void SceneToolStripMenuItem_Click(object sender, EventArgs e) {
      GlobalVars.SelectedSceneActors.Clear();
      GlobalVars.SelectedRoomActors.Clear();
      for (int i = 0, loopTo = SceneActors.Length - 1; i <= loopTo; i++)
        GlobalVars.SelectedSceneActors.Add(i);
    }

    private void CollisionToolStripMenuItem_Click(object sender, EventArgs e) {
      SwitchTool((int)ToolID.COLTRI);
    }

    private void DisplayListSelectorToolStripMenuItem_Click(object sender, EventArgs e) {
      SwitchTool((int)ToolID.DLIST);
    }

    private void Button7_Click(object sender, EventArgs e) {
      for (int i1 = 0, loopTo = FileTree.Nodes.Count - 1; i1 <= loopTo; i1++) {
        for (int i = 0, loopTo1 = FileTree.Nodes[i1].Nodes.Count - 1; i <= loopTo1; i++) {
          if (FileTree.Nodes[i1].Nodes[i].Text.ToLower().Contains(TreeFind.Text.ToLower())) {
            FileTree.TopNode = FileTree.Nodes[i1].Nodes[i];
            break;
          }
        }
      }
    }

    private void FileTree_NodeMouseDoubleClick(object sender, EventArgs e) {
      if (FileTree.SelectedNode == null) {
        return;
      }

      string CurrentNodeText = FileTree.SelectedNode.Text;
      switch (CurrentNodeText ?? "") {
        case var @case when CultureInfo.CurrentCulture.CompareInfo.Compare(@case, "Actor models", CompareOptions.IgnoreCase | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth) == 0:
        case var case1 when CultureInfo.CurrentCulture.CompareInfo.Compare(case1, "Levels", CompareOptions.IgnoreCase | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth) == 0:
        case var case2 when CultureInfo.CurrentCulture.CompareInfo.Compare(case2, "Others", CompareOptions.IgnoreCase | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth) == 0:
        case var case3 when CultureInfo.CurrentCulture.CompareInfo.Compare(case3, "Actor code", CompareOptions.IgnoreCase | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth) == 0: {
            return;
          }
      }

      string CurrentNodeParent = FileTree.SelectedNode.Parent.Text;
      int filetype = FileTree.SelectedNode.Parent.Index;
      int filename = FileTree.SelectedNode.Index;
      ROMFileStream.Close();
      ROMFileStream = new FileStream(GlobalVars.DefROM, FileMode.Open);
      if (CurrentNodeParent.Contains("_scene")) {
        SceneSt = ROMFiles.Levels[filetype].startoff;
        MapSt = ROMFiles.Levels[filetype].Maps[filename].startoff;
        MapBuffSize = ROMFiles.Levels[filetype].Maps[filename].endoff - MapSt;
        ScBuffSize = ROMFiles.Levels[filetype].endoff - SceneSt;
        MapFilename = ROMFiles.Levels[filetype].Maps[filename].filename;
        ScFilename = ROMFiles.Levels[filetype].filename;
        GlobalVars.ZSceneBuffer = new byte[ScBuffSize];
        ROMFileStream.Position = SceneSt;
        ROMFileStream.Read(GlobalVars.ZSceneBuffer, 0, ScBuffSize);
        GlobalVars.ZFileBuffer = new byte[MapBuffSize];
        ROMFileStream.Position = MapSt;
        ROMFileStream.Read(GlobalVars.ZFileBuffer, 0, MapBuffSize);
        SetVariables(0);
        IndMapFileName = "";
        IndScFileName = "";
        MapsCombobox.Items.Clear();
        MapsCombobox.Enabled = false;
        ScannedObjSet = false;
        oldSelectedNode = FileTree.SelectedNode;
      } else {
        switch (CurrentNodeParent ?? "") {
          case var case4 when CultureInfo.CurrentCulture.CompareInfo.Compare(case4, "Actor models", CompareOptions.IgnoreCase | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth) == 0: {
              ObjectFilename = ROMFiles.Objects[filename].filename;
              ObjBuffSize = ROMFiles.Objects[filename].endoff - ROMFiles.Objects[filename].startoff;
              GlobalVars.ZFileBuffer = new byte[ObjBuffSize];
              ROMFileStream.Position = ROMFiles.Objects[filename].startoff;
              ROMFileStream.Read(GlobalVars.ZFileBuffer, 0, ObjBuffSize);
              SetVariables(1);
              IndMapFileName = "";
              IndScFileName = "";
              MapsCombobox.Items.Clear();
              MapsCombobox.Enabled = false;
              oldSelectedNode = FileTree.SelectedNode;
              break;
            }

          case var case5 when CultureInfo.CurrentCulture.CompareInfo.Compare(case5, "Object Sets", CompareOptions.IgnoreCase | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth) == 0: {
              GlobalVars.objectset = (int)Convert.ToUInt32(Strings.Mid(CurrentNodeText, 6), 16);
              ScannedObjSet = true;
              ProcessMapHeader();
              break;
            }

          case var case6 when CultureInfo.CurrentCulture.CompareInfo.Compare(case6, "Actor Code", CompareOptions.IgnoreCase | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth) == 0: {
              ActorFilename = ROMFiles.ActorCode[filename].filename;
              ActorBuffSize = ROMFiles.ActorCode[filename].endoff - ROMFiles.ActorCode[filename].startoff;
              GlobalVars.ZFileBuffer = new byte[ActorBuffSize];
              ROMFileStream.Position = ROMFiles.ActorCode[filename].startoff;
              ROMFileStream.Read(GlobalVars.ZFileBuffer, 0, ActorBuffSize);

              // RSPInterpreter.Parse(ZFileBuffer)

              IndMapFileName = "";
              IndScFileName = "";
              LoadedDataType = (int)Structs.FileTypes.ACTORCODE;
              MapsCombobox.Items.Clear();
              MapsCombobox.Enabled = false;
              oldSelectedNode = FileTree.SelectedNode;
              break;
            }

          case var case7 when CultureInfo.CurrentCulture.CompareInfo.Compare(case7, "Levels", CompareOptions.IgnoreCase | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth) == 0: {
              return;
            }

          case var case8 when CultureInfo.CurrentCulture.CompareInfo.Compare(case8, "Others", CompareOptions.IgnoreCase | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth) == 0: {
              GlobalVars.CurrentBank = 1;
              RenderGraphics = true;
              RenderCollision = false;
              if (ToolModes.CurrentTool == (int)ToolID.ACTOR) {
                ToolModes.CurrentTool = (int)ToolID.CAMERA;
              }

              return;
            }

          default: {
              return;
            }
        }
      }

      ROMFileStream.Close();
    }

    private void ToolStripMenuItem2_Click(object sender, EventArgs e) {
      LoadIndividual.ShowDialog();
    }

    private void ColTriangleBox_SelectedIndexChanged(object sender, EventArgs e) {
      if (ColTriangleBox.SelectedIndex > 0) {
        int colTriangle = ColTriangleBox.SelectedIndex - 1;
        TriTypeText.Text = CollisionPolies[colTriangle].Param.ToString("X4");
        ColTypeBox.SelectedIndex = CollisionPolies[colTriangle].Param + 1;
      }
    }

    private void Button9_Click(object sender, EventArgs e) {
      if (ColTriangleBox.SelectedIndex > 0) {
        int colTriangle = ColTriangleBox.SelectedIndex - 1;
        CollisionPolies[colTriangle].Param = Conversions.ToInteger(TriTypeText.Text);
        ColTypeBox.SelectedIndex = CollisionPolies[colTriangle].Param + 1;
      }
    }

    private void PasteVertex(short x, short y, short z, int mode) {
    }

    private void ToolStripMenuItem20_Click(object sender, EventArgs e) {
      CopyActor[0] = Conversions.ToInteger(CollisionVerts.x[Conversions.ToInteger(SelectedCollisionVert[0])]);
      CopyActor[1] = Conversions.ToInteger(CollisionVerts.y[Conversions.ToInteger(SelectedCollisionVert[0])]);
      CopyActor[2] = Conversions.ToInteger(CollisionVerts.z[Conversions.ToInteger(SelectedCollisionVert[0])]);
      CopyActor[3] = -1;
      CopyActor[4] = -1;
      CopyActor[5] = -1;
      CopyActor[6] = -1;
      CopyActor[7] = 1;
      PasteToolStripMenuItem.Enabled = true;
      PasteToolStripMenuItem.Text = "Paste attributes from actor " + GlobalVars.SelectedRoomActors[0].ToString();
      ClearClipboardToolStripMenuItem.Enabled = true;
    }

    private void ToolStripMenuItem35_Click(object sender, EventArgs e) {
      LoadROM.ShowDialog();
    }

    private void ToolStatusLabel_Click(object sender, EventArgs e) {
      if (ToolModes.CurrentTool < 6) {
        SwitchTool(ToolModes.CurrentTool + 1);
      } else {
        SwitchTool((int)ToolID.CAMERA);
      }
    }

    private void CustomLevel_Click(object sender, EventArgs e) {
      My.MyProject.Forms.LevelCreator.Show();
      My.MyProject.Forms.LevelCreator.Focus();
    }

    private void DListSelection_SelectedIndexChanged(object sender, EventArgs e) {
      CommandsListbox.Items.Clear();
      CommandJumpBox.Items.Clear();
      if (DListSelection.SelectedIndex > 0) {
        if (HighlightDL) {
          EnableDLHighlight();
        } else {
          DisableDLHighlight();
        }

        for (int i = 0, loopTo = GlobalVars.N64DList[DListSelection.SelectedIndex - 1].Commands.Length - 1; i <= loopTo; i++) {
          CommandsListbox.Items.Add(GlobalVars.N64DList[DListSelection.SelectedIndex - 1].Commands[i].Name);
          if (!CommandJumpBox.Items.Contains(GlobalVars.N64DList[DListSelection.SelectedIndex - 1].Commands[i].Name)) {
            CommandJumpBox.Items.Add(GlobalVars.N64DList[DListSelection.SelectedIndex - 1].Commands[i].Name);
          }
        }
      } else {
        for (int i = 0, loopTo1 = GlobalVars.N64DList.Length - 1; i <= loopTo1; i++) {
          GlobalVars.N64DList[i].Highlight = false;
          GlobalVars.N64DList[i].Skip = false;
        }
      }
    }

    private void UpdateCommandDisplay() {
      CommandCodeText.Text = GlobalVars.N64DList[DListSelection.SelectedIndex - 1].Commands[CommandsListbox.SelectedIndex].CMDParams[0].ToString("X2");
      LowordText.Text = GlobalVars.N64DList[DListSelection.SelectedIndex - 1].Commands[CommandsListbox.SelectedIndex].CMDLow.ToString("X6");
      HiwordText.Text = GlobalVars.N64DList[DListSelection.SelectedIndex - 1].Commands[CommandsListbox.SelectedIndex].CMDHigh.ToString("X8");
      WholeCommandTxt.Text = CommandCodeText.Text + LowordText.Text + HiwordText.Text;
    }

    private void CommandsListbox_SelectedIndexChanged(object sender, EventArgs e) {
      if (CommandsListbox.SelectedIndex >= 0) {
        UpdateCommandDisplay();
        switch (CommandsListbox.SelectedItem) {
          case "G_SETCOMBINE": {
              if (!My.MyProject.Forms.CombinerEditor.Visible) {
                GlobalVars.LinkedCommands.EnvColor = RDP_Defs.FindLinkedCommand(GlobalVars.N64DList[DListSelection.SelectedIndex - 1], (byte)RDP_Defs.RDP.G_SETENVCOLOR, CommandsListbox.SelectedIndex);
                GlobalVars.LinkedCommands.PrimColor = RDP_Defs.FindLinkedCommand(GlobalVars.N64DList[DListSelection.SelectedIndex - 1], (byte)RDP_Defs.RDP.G_SETPRIMCOLOR, CommandsListbox.SelectedIndex);
              } else {
                My.MyProject.Forms.CombinerEditor.Close();
              }

              My.MyProject.Forms.CombinerEditor.Show();
              My.MyProject.Forms.CombinerEditor.Focus();
              return;
            }
        }
      } else {
        CommandCodeText.Text = "";
        LowordText.Text = "";
        HiwordText.Text = "";
      }

      if (My.MyProject.Forms.CombinerEditor.Visible) {
        My.MyProject.Forms.CombinerEditor.Close();
      }
    }

    private void CommandsListbox_DoubleClick(object sender, EventArgs e) {
      if (CommandsListbox.SelectedIndex >= 0) {
      }
    }

    private void Button4_Click(object sender, EventArgs e) {
      string cmd = Strings.Mid(WholeCommandTxt.Text, 1, 2);
      string lo = Strings.Mid(WholeCommandTxt.Text, 3, 6);
      string hi = Strings.Mid(WholeCommandTxt.Text, 9, 8);
      CommandCodeText.Text = cmd;
      LowordText.Text = lo;
      HiwordText.Text = hi;
      Functions.UpdateCommand(ref GlobalVars.N64DList[DListSelection.SelectedIndex - 1], (uint)CommandsListbox.SelectedIndex, Convert.ToByte(cmd, 16), Convert.ToUInt32(hi, 16), Convert.ToUInt32(lo, 16));
    }

    private void EnableDLHighlight() {
      for (int i = 0, loopTo = GlobalVars.N64DList.Length - 1; i <= loopTo; i++) {
        if (i == DListSelection.SelectedIndex - 1) {
          GlobalVars.N64DList[i].Highlight = true;
        } else {
          GlobalVars.N64DList[i].Highlight = false;
        }

        GlobalVars.N64DList[i].Skip = false;
      }
    }

    private void DisableDLHighlight() {
      for (int i = 0, loopTo = GlobalVars.N64DList.Length - 1; i <= loopTo; i++) {
        if (i == DListSelection.SelectedIndex - 1) {
          GlobalVars.N64DList[i].Skip = false;
        } else {
          GlobalVars.N64DList[i].Skip = true;
        }

        GlobalVars.N64DList[i].Highlight = false;
      }
    }

    private void RadioButton1_CheckedChanged(object sender, EventArgs e) {
      HighlightDL = true;
      EnableDLHighlight();
    }

    private void RadioButton2_CheckedChanged(object sender, EventArgs e) {
      HighlightDL = false;
      DisableDLHighlight();
    }

    private void CommandCodeText_KeyDown(object sender, KeyPressEventArgs e) {
      e.Handled = Functions.HexOnly(Conversions.ToString(char.ToUpper(e.KeyChar)));
    }

    private void Button1_Click(object sender, EventArgs e) {
      int st = 0;
      if (CommandsListbox.SelectedIndex == CommandsListbox.Items.Count - 1) {
        st = 0;
      } else {
        st = CommandsListbox.SelectedIndex + 1;
      }

      for (int i = st, loopTo = CommandsListbox.Items.Count - 1; i <= loopTo; i++) {
        if (CultureInfo.CurrentCulture.CompareInfo.Compare(CommandsListbox.Items[i].ToString() ?? "", CommandJumpBox.SelectedItem.ToString() ?? "", CompareOptions.IgnoreCase | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth) == 0) {
          CommandsListbox.SelectedIndex = i;
          return;
        }
      }
    }

    private void Button8_Click(object sender, EventArgs e) {
      int st = 0;
      if (CommandsListbox.SelectedIndex == 0) {
        st = CommandsListbox.Items.Count - 1;
      } else {
        st = CommandsListbox.SelectedIndex - 1;
      }

      for (int i = st; i >= 0; i -= 1) {
        if (CultureInfo.CurrentCulture.CompareInfo.Compare(CommandsListbox.Items[i].ToString() ?? "", CommandJumpBox.SelectedItem.ToString() ?? "", CompareOptions.IgnoreCase | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth) == 0) {
          CommandsListbox.SelectedIndex = i;
          return;
        }
      }
    }

    private void Button10_Click(object sender, EventArgs e) {
      if (DListSelection.SelectedIndex > 0) {
        RipAllDLs = false;
        RipDL.ShowDialog();
      }
    }

    private void Button12_Click(object sender, EventArgs e) {
      RipAllDLs = true;
      RipDL.ShowDialog();
    }

    private void WriteDLToFile(Structs.N64DisplayList DL, ref FileStream file) {
      for (int i = 0, loopTo = DL.Commands.Length - 1; i <= loopTo; i++) {
        for (int ii = 0; ii <= 7; ii++)
          file.WriteByte(DL.Commands[i].CMDParams[ii]);
      }
    }

    private void RipDL_FileOk(object sender, System.ComponentModel.CancelEventArgs e) {
      if (File.Exists(RipDL.FileName)) {
        File.Delete(RipDL.FileName);
      }

      RawDLFile = File.Create(RipDL.FileName);
      if (RipAllDLs) {
        for (int I = 0, loopTo = GlobalVars.N64DList.Length - 1; I <= loopTo; I++)
          WriteDLToFile(GlobalVars.N64DList[I], ref RawDLFile);
      } else {
        WriteDLToFile(GlobalVars.N64DList[DListSelection.SelectedIndex - 1], ref RawDLFile);
      }

      RawDLFile.Dispose();
    }

    private void Button13_Click(object sender, EventArgs e) {
      GlobalVars.N64DList[DListSelection.SelectedIndex - 1].Commands[CommandsListbox.SelectedIndex] = GlobalVars.N64DList[DListSelection.SelectedIndex - 1].CommandsCopy[CommandsListbox.SelectedIndex];
    }

    private void ToolStripMenuItem34_Click(object sender, EventArgs e) {
      SaveROMAs.ShowDialog();
    }

    private void SaveROMAs_FileOk(object sender, System.ComponentModel.CancelEventArgs e) {
      if (!string.IsNullOrEmpty(GlobalVars.DefROM)) {
        var romFS = new FileStream(SaveROMAs.FileName, FileMode.Create);
      }
    }

    private void WholeCommandTxt_TextChanged(object sender, EventArgs e) {
    }

    private void CommandCodeText_TextChanged(object sender, EventArgs e) {
      WholeCommandTxt.Text = CommandCodeText.Text + LowordText.Text + HiwordText.Text;
    }

    private void CheckBox2_CheckedChanged(object sender, EventArgs e) {
      if (!ShowBones)
        ShowBones = true;
      else
        ShowBones = false;
    }

    private void TexturesToolStripMenuItem_Click(object sender, EventArgs e) {
      var argMenuItem = TexturesToolStripMenuItem;
      Functions.ToggleBoolean(ref GlobalVars.RenderToggles.Textures, ref argMenuItem);
      TexturesToolStripMenuItem = argMenuItem;
    }

    private void ColorCombinerToolStripMenuItem_Click(object sender, EventArgs e) {
      var argMenuItem = ColorCombinerToolStripMenuItem;
      Functions.ToggleBoolean(ref GlobalVars.RenderToggles.ColorCombiner, ref argMenuItem);
      ColorCombinerToolStripMenuItem = argMenuItem;
    }

    private void AnisotropicFilteringToolStripMenuItem_Click(object sender, EventArgs e) {
      var argMenuItem = AnisotropicFilteringToolStripMenuItem;
      Functions.ToggleBoolean(ref GlobalVars.RenderToggles.Anisotropic, ref argMenuItem);
      AnisotropicFilteringToolStripMenuItem = argMenuItem;
    }

    private void FullSceneAntialiasingToolStripMenuItem_Click(object sender, EventArgs e) {
      var argMenuItem = FullSceneAntialiasingToolStripMenuItem;
      Functions.ToggleBoolean(ref GlobalVars.RenderToggles.AntiAliasing, ref argMenuItem);
      FullSceneAntialiasingToolStripMenuItem = argMenuItem;
    }

    private void Button5_Click(object sender, EventArgs e) {
      GlobalVars.AnimParser.StopAnimation(ref GlobalVars.AnimationStopWatch, ref GlobalVars.ZAnimationCounter);
    }

    private void animationbank_SelectedIndexChanged(object sender, EventArgs e) {
      if (LimbEntries is object) {
        if (LimbEntries.Length > 0) {
          GlobalVars.CommonBankUse.AnimBank = animationbank.SelectedIndex - 1;
          if (GlobalVars.CommonBankUse.AnimBank == (int)Structs.UseBank.Inline) {
            AnimationEntries = GlobalVars.AnimParser.GetAnimations(GlobalVars.ZFileBuffer, LimbEntries.Length, 6);
          } else {
            AnimationEntries = GlobalVars.AnimParser.GetAnimations(GlobalVars.CommonBanks.Anims.Banks[GlobalVars.CommonBankUse.AnimBank].Data, LimbEntries.Length, 6);
          }

          if (AnimationEntries is object) {
            AnimationList.SelectedIndex = 0;
          }
        }
      }
    }

    private void TrackBar1_ValueChanged(object sender, EventArgs e) {
      CameraCoef = TrackBar1.Value * 8;
    }

    private void TrackBar4_ValueChanged(object sender, EventArgs e) {
      ToolSensitivity = TrackBar4.Value;
    }

    private void NumericUpDown1_ValueChanged(object sender, EventArgs e) {
      GlobalVars.ZAnimationCounter.FPS = (float)AnimationFPS.Value;
    }

    private void CurrentFrame_Scroll(object sender, EventArgs e) {
      GlobalVars.ZAnimationCounter.CurrFrame = (uint)(CurrentFrame.Value - 1);
      UpdateAnimationTab();
    }

    private void VarPresetButton_Click(object sender, EventArgs e) {
      VarContextMenu.Show(MousePosition.X, MousePosition.Y);
    }

    private void NumButton_Click(object sender, EventArgs e) {
      NumContextMenu.Show(MousePosition.X, MousePosition.Y);
    }

    private void GrpPresetButton_Click(object sender, EventArgs e) {
      GrpContextMenu.Show(MousePosition.X, MousePosition.Y);
    }

    private void Button6_Click_1(object sender, EventArgs e) {
      My.MyProject.Forms.ActorPresets.ShowDialog();
    }
  }
}