using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace UoT {
  [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
  public partial class MainWin : Form {
    internal StatusStrip UoTStatus;
    internal ToolStripStatusLabel ToolStripStatusLabel4;
    internal PictureBox PictureBox4;
    internal ToolStripSeparator ToolStripSeparator1;
    internal ToolStripSeparator ToolStripSeparator2;
    internal ToolStripSeparator ToolStripSeparator3;
    internal Label Label12;
    private TrackBar _TrackBar4;

    internal TrackBar TrackBar4 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _TrackBar4;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_TrackBar4 != null) {
          _TrackBar4.ValueChanged -= TrackBar4_ValueChanged;
        }

        _TrackBar4 = value;
        if (_TrackBar4 != null) {
          _TrackBar4.ValueChanged += TrackBar4_ValueChanged;
        }
      }
    }

    internal ToolStripMenuItem FileToolStripMenuItem;
    private ToolStripMenuItem _OpenModelToolStripMenuItem;

    internal ToolStripMenuItem OpenModelToolStripMenuItem {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _OpenModelToolStripMenuItem;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_OpenModelToolStripMenuItem != null) {
          _OpenModelToolStripMenuItem.Click -= LoadZOBJToolStripMenuItem_Click;
        }

        _OpenModelToolStripMenuItem = value;
        if (_OpenModelToolStripMenuItem != null) {
          _OpenModelToolStripMenuItem.Click += LoadZOBJToolStripMenuItem_Click;
        }
      }
    }

    private ToolStripMenuItem _QuitToolStripMenuItem;

    internal ToolStripMenuItem QuitToolStripMenuItem {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _QuitToolStripMenuItem;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_QuitToolStripMenuItem != null) {
          _QuitToolStripMenuItem.Click -= QuitToolStripMenuItem_Click;
        }

        _QuitToolStripMenuItem = value;
        if (_QuitToolStripMenuItem != null) {
          _QuitToolStripMenuItem.Click += QuitToolStripMenuItem_Click;
        }
      }
    }

    internal ToolStripMenuItem FeaturesToolStripMenuItem;
    internal ToolStripMenuItem MouseToolToolStripMenuItem;
    internal ToolStripMenuItem OptionsToolStripMenuItem;
    internal ToolStripMenuItem LaunchROMInPJ64ToolStripMenuItem;
    internal ToolStripMenuItem HelpToolStripMenuItem;
    internal ToolStripMenuItem AboutToolStripMenuItem;
    internal ToolStripMenuItem ControlsInfoToolStripMenuItem;
    internal ToolStripMenuItem SaveChangesToolStripMenuItem;
    internal ToolStripMenuItem RenderModeToolStripMenuItem;
    private ToolStripMenuItem _ViewingMeshToolStripMenuItem1;

    internal ToolStripMenuItem ViewingMeshToolStripMenuItem1 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _ViewingMeshToolStripMenuItem1;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_ViewingMeshToolStripMenuItem1 != null) {
          _ViewingMeshToolStripMenuItem1.Click -= ViewingMeshToolStripMenuItem1_Click;
        }

        _ViewingMeshToolStripMenuItem1 = value;
        if (_ViewingMeshToolStripMenuItem1 != null) {
          _ViewingMeshToolStripMenuItem1.Click += ViewingMeshToolStripMenuItem1_Click;
        }
      }
    }

    private ToolStripMenuItem _CollisionMeshToolStripMenuItem;

    internal ToolStripMenuItem CollisionMeshToolStripMenuItem {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _CollisionMeshToolStripMenuItem;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_CollisionMeshToolStripMenuItem != null) {
          _CollisionMeshToolStripMenuItem.Click -= CollisionMeshToolStripMenuItem_Click_1;
        }

        _CollisionMeshToolStripMenuItem = value;
        if (_CollisionMeshToolStripMenuItem != null) {
          _CollisionMeshToolStripMenuItem.Click += CollisionMeshToolStripMenuItem_Click_1;
        }
      }
    }

    internal ToolStripMenuItem PrimitiveTypeToolStripMenuItem;
    private ToolStripMenuItem _FilledToolStripMenuItem;

    internal ToolStripMenuItem FilledToolStripMenuItem {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _FilledToolStripMenuItem;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_FilledToolStripMenuItem != null) {
          _FilledToolStripMenuItem.Click -= FilledToolStripMenuItem_Click_1;
        }

        _FilledToolStripMenuItem = value;
        if (_FilledToolStripMenuItem != null) {
          _FilledToolStripMenuItem.Click += FilledToolStripMenuItem_Click_1;
        }
      }
    }

    private ToolStripMenuItem _WireframeToolStripMenuItem;

    internal ToolStripMenuItem WireframeToolStripMenuItem {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _WireframeToolStripMenuItem;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_WireframeToolStripMenuItem != null) {
          _WireframeToolStripMenuItem.Click -= WireframeToolStripMenuItem_Click_1;
        }

        _WireframeToolStripMenuItem = value;
        if (_WireframeToolStripMenuItem != null) {
          _WireframeToolStripMenuItem.Click += WireframeToolStripMenuItem_Click_1;
        }
      }
    }

    private Timer _ActorInputTimer;

    internal Timer ActorInputTimer {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _ActorInputTimer;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_ActorInputTimer != null) {
          _ActorInputTimer.Tick -= Timer1_Tick;
          _ActorInputTimer.Tick -= Timer1_Tick;
        }

        _ActorInputTimer = value;
        if (_ActorInputTimer != null) {
          _ActorInputTimer.Tick += Timer1_Tick;
          _ActorInputTimer.Tick += Timer1_Tick;
        }
      }
    }

    internal ToolStripSeparator ToolStripSeparator4;
    internal ToolStripSeparator ToolStripSeparator6;
    internal ToolStripSeparator ToolStripSeparator5;
    private ToolStripMenuItem _SetupToolStripMenuItem;

    internal ToolStripMenuItem SetupToolStripMenuItem {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _SetupToolStripMenuItem;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_SetupToolStripMenuItem != null) {
          _SetupToolStripMenuItem.Click -= SetupToolStripMenuItem_Click_2;
        }

        _SetupToolStripMenuItem = value;
        if (_SetupToolStripMenuItem != null) {
          _SetupToolStripMenuItem.Click += SetupToolStripMenuItem_Click_2;
        }
      }
    }

    internal ToolStripMenuItem EditToolStripMenuItem;
    internal ToolStripMenuItem ZeldaResourceExtractorToolStripMenuItem;
    internal ToolStripSeparator ToolStripSeparator10;
    internal ToolStripSeparator ToolStripSeparator8;
    internal ToolStripSeparator ToolStripSeparator7;
    internal ToolStripMenuItem ImportCSVToolStripMenuItem;
    internal ToolStripMenuItem ResetSelectedVerticesToolStripMenuItem;
    internal ToolStripMenuItem ResetAllGraphicsToolStripMenuItem;
    internal ToolStripMenuItem ResetAllCollisionToolStripMenuItem;
    internal ToolStripSeparator ToolStripSeparator11;
    internal ToolStripMenuItem ResetSelectedActorToolStripMenuItem;
    private ToolStripMenuItem _ResetAllActorsToolStripMenuItem;

    internal ToolStripMenuItem ResetAllActorsToolStripMenuItem {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _ResetAllActorsToolStripMenuItem;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_ResetAllActorsToolStripMenuItem != null) {
          _ResetAllActorsToolStripMenuItem.Click -= ResetAllActorsToolStripMenuItem_Click;
        }

        _ResetAllActorsToolStripMenuItem = value;
        if (_ResetAllActorsToolStripMenuItem != null) {
          _ResetAllActorsToolStripMenuItem.Click += ResetAllActorsToolStripMenuItem_Click;
        }
      }
    }

    private ToolStripMenuItem _ResetAllSceneActorsToolStripMenuItem;

    internal ToolStripMenuItem ResetAllSceneActorsToolStripMenuItem {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _ResetAllSceneActorsToolStripMenuItem;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_ResetAllSceneActorsToolStripMenuItem != null) {
          _ResetAllSceneActorsToolStripMenuItem.Click -= ResetAllSceneActorsToolStripMenuItem_Click;
        }

        _ResetAllSceneActorsToolStripMenuItem = value;
        if (_ResetAllSceneActorsToolStripMenuItem != null) {
          _ResetAllSceneActorsToolStripMenuItem.Click += ResetAllSceneActorsToolStripMenuItem_Click;
        }
      }
    }

    internal TabPage CollisionTab;
    internal GroupBox CollisionGroupBox;
    internal Label Label36;
    internal TextBox ColWalkSound;
    internal Label Label38;
    internal Label Label37;
    internal Label Label35;
    internal Label Label33;
    internal Label Label32;
    internal Label Label23;
    internal Label Label13;
    internal Label Label1;
    internal TextBox ColVar4;
    private Button _ApplyCollisionButton;

    internal Button ApplyCollisionButton {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _ApplyCollisionButton;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_ApplyCollisionButton != null) {
          _ApplyCollisionButton.Click -= Button22_Click_1;
          _ApplyCollisionButton.Click -= Button22_Click_1;
        }

        _ApplyCollisionButton = value;
        if (_ApplyCollisionButton != null) {
          _ApplyCollisionButton.Click += Button22_Click_1;
          _ApplyCollisionButton.Click += Button22_Click_1;
        }
      }
    }

    internal TextBox ColVar2;
    internal TextBox ColVar3;
    internal TextBox ColVar1;
    internal Label Label34;
    internal TextBox ColTypeText;
    private ComboBox _ColTypeBox;

    internal ComboBox ColTypeBox {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _ColTypeBox;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_ColTypeBox != null) {
          _ColTypeBox.SelectedIndexChanged -= ComboBox1_SelectedIndexChanged_1;
          _ColTypeBox.SelectedIndexChanged -= ComboBox1_SelectedIndexChanged_1;
        }

        _ColTypeBox = value;
        if (_ColTypeBox != null) {
          _ColTypeBox.SelectedIndexChanged += ComboBox1_SelectedIndexChanged_1;
          _ColTypeBox.SelectedIndexChanged += ComboBox1_SelectedIndexChanged_1;
        }
      }
    }

    internal Label Label31;
    internal TextBox ExitTextBox;
    private ComboBox _ExitCombobox;

    internal ComboBox ExitCombobox {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _ExitCombobox;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_ExitCombobox != null) {
          _ExitCombobox.SelectedIndexChanged -= ComboBox8_SelectedIndexChanged_1;
          _ExitCombobox.SelectedIndexChanged -= ComboBox8_SelectedIndexChanged_1;
        }

        _ExitCombobox = value;
        if (_ExitCombobox != null) {
          _ExitCombobox.SelectedIndexChanged += ComboBox8_SelectedIndexChanged_1;
          _ExitCombobox.SelectedIndexChanged += ComboBox8_SelectedIndexChanged_1;
        }
      }
    }

    internal Label Label10;
    internal TabPage MiscTab;
    internal GroupBox GroupBox10;
    private CheckBox _CheckBox15;

    internal CheckBox CheckBox15 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _CheckBox15;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_CheckBox15 != null) {
          _CheckBox15.CheckedChanged -= CheckBox15_CheckedChanged_1;
        }

        _CheckBox15 = value;
        if (_CheckBox15 != null) {
          _CheckBox15.CheckedChanged += CheckBox15_CheckedChanged_1;
        }
      }
    }

    private CheckBox _CheckBox14;

    internal CheckBox CheckBox14 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _CheckBox14;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_CheckBox14 != null) {
          _CheckBox14.CheckedChanged -= CheckBox14_CheckedChanged_1;
        }

        _CheckBox14 = value;
        if (_CheckBox14 != null) {
          _CheckBox14.CheckedChanged += CheckBox14_CheckedChanged_1;
        }
      }
    }

    private CheckBox _CheckBox13;

    internal CheckBox CheckBox13 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _CheckBox13;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_CheckBox13 != null) {
          _CheckBox13.CheckedChanged -= CheckBox13_CheckedChanged_1;
        }

        _CheckBox13 = value;
        if (_CheckBox13 != null) {
          _CheckBox13.CheckedChanged += CheckBox13_CheckedChanged_1;
        }
      }
    }

    internal TabPage LevelFlagsTab;
    internal GroupBox GroupBox6;
    internal ComboBox ComboBox6;
    internal Label Label2;
    internal Button Button11;
    internal TextBox TextBox13;
    internal Label Label21;
    internal TabPage ActorsTab;
    private ComboBox _SceneActorCombobox;

    internal ComboBox SceneActorCombobox {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _SceneActorCombobox;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_SceneActorCombobox != null) {
          _SceneActorCombobox.SelectedIndexChanged -= ComboBox5_SelectedIndexChanged;
          _SceneActorCombobox.SelectedIndexChanged -= ComboBox5_SelectedIndexChanged;
        }

        _SceneActorCombobox = value;
        if (_SceneActorCombobox != null) {
          _SceneActorCombobox.SelectedIndexChanged += ComboBox5_SelectedIndexChanged;
          _SceneActorCombobox.SelectedIndexChanged += ComboBox5_SelectedIndexChanged;
        }
      }
    }

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

    internal TextBox ActorVarText;
    internal TextBox ActorNumberText;
    internal Label Label6;
    internal Label Label8;
    internal GroupBox GroupBox4;
    internal Label Label14;
    internal Label Label17;
    private TextBox _TextBox9;

    internal TextBox TextBox9 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _TextBox9;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_TextBox9 != null) {
          _TextBox9.TextChanged -= TextBox9_TextChanged;
        }

        _TextBox9 = value;
        if (_TextBox9 != null) {
          _TextBox9.TextChanged += TextBox9_TextChanged;
        }
      }
    }

    internal Label Label18;
    private TextBox _TextBox8;

    internal TextBox TextBox8 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _TextBox8;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_TextBox8 != null) {
          _TextBox8.TextChanged -= TextBox8_TextChanged;
        }

        _TextBox8 = value;
        if (_TextBox8 != null) {
          _TextBox8.TextChanged += TextBox8_TextChanged;
        }
      }
    }

    internal Label Label19;
    private TextBox _TextBox7;

    internal TextBox TextBox7 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _TextBox7;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_TextBox7 != null) {
          _TextBox7.TextChanged -= TextBox7_TextChanged;
        }

        _TextBox7 = value;
        if (_TextBox7 != null) {
          _TextBox7.TextChanged += TextBox7_TextChanged;
        }
      }
    }

    private TextBox _TextBox10;

    internal TextBox TextBox10 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _TextBox10;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_TextBox10 != null) {
          _TextBox10.TextChanged -= TextBox10_TextChanged;
        }

        _TextBox10 = value;
        if (_TextBox10 != null) {
          _TextBox10.TextChanged += TextBox10_TextChanged;
        }
      }
    }

    internal Label Label16;
    private TextBox _TextBox11;

    internal TextBox TextBox11 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _TextBox11;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_TextBox11 != null) {
          _TextBox11.TextChanged -= TextBox11_TextChanged;
        }

        _TextBox11 = value;
        if (_TextBox11 != null) {
          _TextBox11.TextChanged += TextBox11_TextChanged;
        }
      }
    }

    internal Label Label15;
    private TextBox _TextBox12;

    internal TextBox TextBox12 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _TextBox12;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_TextBox12 != null) {
          _TextBox12.TextChanged -= TextBox12_TextChanged;
        }

        _TextBox12 = value;
        if (_TextBox12 != null) {
          _TextBox12.TextChanged += TextBox12_TextChanged;
        }
      }
    }

    internal GroupBox GroupBox5;
    internal Label Label7;
    private TextBox _ActorGroupText;

    internal TextBox ActorGroupText {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _ActorGroupText;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_ActorGroupText != null) {
          _ActorGroupText.TextChanged -= ActorGroupText_TextChanged;
        }

        _ActorGroupText = value;
        if (_ActorGroupText != null) {
          _ActorGroupText.TextChanged += ActorGroupText_TextChanged;
        }
      }
    }

    internal Label Label22;
    private ComboBox _RoomActorCombobox;

    internal ComboBox RoomActorCombobox {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _RoomActorCombobox;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_RoomActorCombobox != null) {
          _RoomActorCombobox.SelectedIndexChanged -= RoomActorCombobox_SelectedIndexChanged;
          _RoomActorCombobox.SelectedIndexChanged -= RoomActorCombobox_SelectedIndexChanged;
        }

        _RoomActorCombobox = value;
        if (_RoomActorCombobox != null) {
          _RoomActorCombobox.SelectedIndexChanged += RoomActorCombobox_SelectedIndexChanged;
          _RoomActorCombobox.SelectedIndexChanged += RoomActorCombobox_SelectedIndexChanged;
        }
      }
    }

    internal Label Label24;
    internal TabControl EditingTabs;
    internal ToolStripSeparator ToolStripSeparator9;
    private ToolStripMenuItem _SelectAllRoomActorsToolStripMenuItem;

    internal ToolStripMenuItem SelectAllRoomActorsToolStripMenuItem {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _SelectAllRoomActorsToolStripMenuItem;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_SelectAllRoomActorsToolStripMenuItem != null) {
          _SelectAllRoomActorsToolStripMenuItem.Click -= SelectAllRoomActorsToolStripMenuItem_Click;
        }

        _SelectAllRoomActorsToolStripMenuItem = value;
        if (_SelectAllRoomActorsToolStripMenuItem != null) {
          _SelectAllRoomActorsToolStripMenuItem.Click += SelectAllRoomActorsToolStripMenuItem_Click;
        }
      }
    }

    private ToolStripMenuItem _SelectAllSceneActorsToolStripMenuItem;

    internal ToolStripMenuItem SelectAllSceneActorsToolStripMenuItem {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _SelectAllSceneActorsToolStripMenuItem;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_SelectAllSceneActorsToolStripMenuItem != null) {
          _SelectAllSceneActorsToolStripMenuItem.Click -= SelectAllSceneActorsToolStripMenuItem_Click;
        }

        _SelectAllSceneActorsToolStripMenuItem = value;
        if (_SelectAllSceneActorsToolStripMenuItem != null) {
          _SelectAllSceneActorsToolStripMenuItem.Click += SelectAllSceneActorsToolStripMenuItem_Click;
        }
      }
    }

    internal Label Label43;
    private TrackBar _TrackBar1;

    internal TrackBar TrackBar1 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _TrackBar1;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_TrackBar1 != null) {
          _TrackBar1.ValueChanged -= TrackBar1_ValueChanged;
        }

        _TrackBar1 = value;
        if (_TrackBar1 != null) {
          _TrackBar1.ValueChanged += TrackBar1_ValueChanged;
        }
      }
    }

    internal ToolStripMenuItem ReloadCurrentFileToolStripMenuItem;
    private CheckBox _CheckBox5;

    internal CheckBox CheckBox5 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _CheckBox5;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_CheckBox5 != null) {
          _CheckBox5.CheckedChanged -= CheckBox5_CheckedChanged;
        }

        _CheckBox5 = value;
        if (_CheckBox5 != null) {
          _CheckBox5.CheckedChanged += CheckBox5_CheckedChanged;
        }
      }
    }

    internal ToolStripMenuItem SearchForUpdatesToolStripMenuItem;
    private Tao.Platform.Windows.SimpleOpenGlControl _UoTRender;

    internal Tao.Platform.Windows.SimpleOpenGlControl UoTRender {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _UoTRender;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_UoTRender != null) {
          _UoTRender.KeyDown -= SimpleOpenGlControl1_KeyDown;
          _UoTRender.KeyDown -= SimpleOpenGlControl1_KeyDown;
          _UoTRender.KeyUp -= SimpleOpenGlControl1_KeyUp;
          _UoTRender.KeyUp -= SimpleOpenGlControl1_KeyUp;
          _UoTRender.MouseDown -= SimpleOpenGlControl1_MouseDown;
          _UoTRender.MouseUp -= SimpleOpenGlControl1_MouseUp;
          _UoTRender.MouseWheel -= ScrollSensitivity;
          _UoTRender.MouseWheel -= ScrollSensitivity;
          _UoTRender.MouseMove -= SimpleOpenGlControl1_MouseMove;
          _UoTRender.MouseMove -= SimpleOpenGlControl1_MouseMove;
        }

        _UoTRender = value;
        if (_UoTRender != null) {
          _UoTRender.KeyDown += SimpleOpenGlControl1_KeyDown;
          _UoTRender.KeyDown += SimpleOpenGlControl1_KeyDown;
          _UoTRender.KeyUp += SimpleOpenGlControl1_KeyUp;
          _UoTRender.KeyUp += SimpleOpenGlControl1_KeyUp;
          _UoTRender.MouseDown += SimpleOpenGlControl1_MouseDown;
          _UoTRender.MouseUp += SimpleOpenGlControl1_MouseUp;
          _UoTRender.MouseWheel += ScrollSensitivity;
          _UoTRender.MouseWheel += ScrollSensitivity;
          _UoTRender.MouseMove += SimpleOpenGlControl1_MouseMove;
          _UoTRender.MouseMove += SimpleOpenGlControl1_MouseMove;
        }
      }
    }

    internal ToolStripMenuItem SelectAllGraphicsToolStripMenuItem;
    internal ToolStripMenuItem SelectAllCollisionToolStripMenuItem;
    internal ToolStripStatusLabel ToolStripStatusLabel5;
    private ToolStripStatusLabel _ToolStatusLabel;

    internal ToolStripStatusLabel ToolStatusLabel {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _ToolStatusLabel;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_ToolStatusLabel != null) {
          _ToolStatusLabel.Click -= ToolStatusLabel_Click;
        }

        _ToolStatusLabel = value;
        if (_ToolStatusLabel != null) {
          _ToolStatusLabel.Click += ToolStatusLabel_Click;
        }
      }
    }

    internal ContextMenuStrip ActorContextMenu;
    internal ToolStripMenuItem EditToolStripMenuItem2;
    internal ToolStripMenuItem CamXRotationToolStripMenuItem;
    private ToolStripMenuItem _DegreesToolStripMenuItem;

    internal ToolStripMenuItem DegreesToolStripMenuItem {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _DegreesToolStripMenuItem;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_DegreesToolStripMenuItem != null) {
          _DegreesToolStripMenuItem.Click -= DegreesToolStripMenuItem_Click;
        }

        _DegreesToolStripMenuItem = value;
        if (_DegreesToolStripMenuItem != null) {
          _DegreesToolStripMenuItem.Click += DegreesToolStripMenuItem_Click;
        }
      }
    }

    private ToolStripMenuItem _DegreesToolStripMenuItem1;

    internal ToolStripMenuItem DegreesToolStripMenuItem1 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _DegreesToolStripMenuItem1;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_DegreesToolStripMenuItem1 != null) {
          _DegreesToolStripMenuItem1.Click -= DegreesToolStripMenuItem1_Click;
        }

        _DegreesToolStripMenuItem1 = value;
        if (_DegreesToolStripMenuItem1 != null) {
          _DegreesToolStripMenuItem1.Click += DegreesToolStripMenuItem1_Click;
        }
      }
    }

    internal ToolStripMenuItem CamYRotationToolStripMenuItem;
    private ToolStripMenuItem _DegreesToolStripMenuItem2;

    internal ToolStripMenuItem DegreesToolStripMenuItem2 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _DegreesToolStripMenuItem2;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_DegreesToolStripMenuItem2 != null) {
          _DegreesToolStripMenuItem2.Click -= DegreesToolStripMenuItem2_Click;
        }

        _DegreesToolStripMenuItem2 = value;
        if (_DegreesToolStripMenuItem2 != null) {
          _DegreesToolStripMenuItem2.Click += DegreesToolStripMenuItem2_Click;
        }
      }
    }

    private ToolStripMenuItem _DegreesToolStripMenuItem3;

    internal ToolStripMenuItem DegreesToolStripMenuItem3 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _DegreesToolStripMenuItem3;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_DegreesToolStripMenuItem3 != null) {
          _DegreesToolStripMenuItem3.Click -= DegreesToolStripMenuItem3_Click;
        }

        _DegreesToolStripMenuItem3 = value;
        if (_DegreesToolStripMenuItem3 != null) {
          _DegreesToolStripMenuItem3.Click += DegreesToolStripMenuItem3_Click;
        }
      }
    }

    internal ToolStripMenuItem CamZRotationToolStripMenuItem;
    private ToolStripMenuItem _DegreesToolStripMenuItem4;

    internal ToolStripMenuItem DegreesToolStripMenuItem4 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _DegreesToolStripMenuItem4;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_DegreesToolStripMenuItem4 != null) {
          _DegreesToolStripMenuItem4.Click -= DegreesToolStripMenuItem4_Click;
        }

        _DegreesToolStripMenuItem4 = value;
        if (_DegreesToolStripMenuItem4 != null) {
          _DegreesToolStripMenuItem4.Click += DegreesToolStripMenuItem4_Click;
        }
      }
    }

    private ToolStripMenuItem _DegreesToolStripMenuItem5;

    internal ToolStripMenuItem DegreesToolStripMenuItem5 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _DegreesToolStripMenuItem5;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_DegreesToolStripMenuItem5 != null) {
          _DegreesToolStripMenuItem5.Click -= DegreesToolStripMenuItem5_Click;
        }

        _DegreesToolStripMenuItem5 = value;
        if (_DegreesToolStripMenuItem5 != null) {
          _DegreesToolStripMenuItem5.Click += DegreesToolStripMenuItem5_Click;
        }
      }
    }

    private Timer _RotationTimer;

    internal Timer RotationTimer {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _RotationTimer;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_RotationTimer != null) {
          _RotationTimer.Tick -= RotationTimer_Tick;
        }

        _RotationTimer = value;
        if (_RotationTimer != null) {
          _RotationTimer.Tick += RotationTimer_Tick;
        }
      }
    }

    internal TabPage AnimationsTab;
    private Button _Button5;

    internal Button Button5 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _Button5;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_Button5 != null) {
          _Button5.Click -= Button5_Click;
        }

        _Button5 = value;
        if (_Button5 != null) {
          _Button5.Click += Button5_Click;
        }
      }
    }

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

    private ListBox _AnimationList;

    internal ListBox AnimationList {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _AnimationList;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_AnimationList != null) {
          _AnimationList.SelectedIndexChanged -= AnimationList_SelectedIndexChanged;
        }

        _AnimationList = value;
        if (_AnimationList != null) {
          _AnimationList.SelectedIndexChanged += AnimationList_SelectedIndexChanged;
        }
      }
    }

    private CheckBox _CheckBox1;

    internal CheckBox CheckBox1 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _CheckBox1;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_CheckBox1 != null) {
          _CheckBox1.CheckedChanged -= CheckBox1_CheckedChanged;
        }

        _CheckBox1 = value;
        if (_CheckBox1 != null) {
          _CheckBox1.CheckedChanged += CheckBox1_CheckedChanged;
        }
      }
    }

    private OpenFileDialog _LoadIndividual;

    internal OpenFileDialog LoadIndividual {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _LoadIndividual;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_LoadIndividual != null) {
          _LoadIndividual.FileOk -= LoadIndividual_FileOk;
        }

        _LoadIndividual = value;
        if (_LoadIndividual != null) {
          _LoadIndividual.FileOk += LoadIndividual_FileOk;
        }
      }
    }

    private ToolStripMenuItem _CopyToolStripMenuItem;

    internal ToolStripMenuItem CopyToolStripMenuItem {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _CopyToolStripMenuItem;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_CopyToolStripMenuItem != null) {
          _CopyToolStripMenuItem.Click -= CopyToolStripMenuItem_Click;
        }

        _CopyToolStripMenuItem = value;
        if (_CopyToolStripMenuItem != null) {
          _CopyToolStripMenuItem.Click += CopyToolStripMenuItem_Click;
        }
      }
    }

    internal ToolStripSeparator ToolStripSeparator14;
    internal ToolStripSeparator ToolStripSeparator13;
    internal ToolStripMenuItem PasteToolStripMenuItem;
    internal ToolStripMenuItem PositionToolStripMenuItem;
    private ToolStripMenuItem _XToolStripMenuItem1;

    internal ToolStripMenuItem XToolStripMenuItem1 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _XToolStripMenuItem1;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_XToolStripMenuItem1 != null) {
          _XToolStripMenuItem1.Click -= XToolStripMenuItem1_Click;
        }

        _XToolStripMenuItem1 = value;
        if (_XToolStripMenuItem1 != null) {
          _XToolStripMenuItem1.Click += XToolStripMenuItem1_Click;
        }
      }
    }

    private ToolStripMenuItem _YToolStripMenuItem1;

    internal ToolStripMenuItem YToolStripMenuItem1 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _YToolStripMenuItem1;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_YToolStripMenuItem1 != null) {
          _YToolStripMenuItem1.Click -= YToolStripMenuItem1_Click;
        }

        _YToolStripMenuItem1 = value;
        if (_YToolStripMenuItem1 != null) {
          _YToolStripMenuItem1.Click += YToolStripMenuItem1_Click;
        }
      }
    }

    private ToolStripMenuItem _ZToolStripMenuItem;

    internal ToolStripMenuItem ZToolStripMenuItem {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _ZToolStripMenuItem;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_ZToolStripMenuItem != null) {
          _ZToolStripMenuItem.Click -= ZToolStripMenuItem_Click;
        }

        _ZToolStripMenuItem = value;
        if (_ZToolStripMenuItem != null) {
          _ZToolStripMenuItem.Click += ZToolStripMenuItem_Click;
        }
      }
    }

    private ToolStripMenuItem _AllToolStripMenuItem1;

    internal ToolStripMenuItem AllToolStripMenuItem1 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _AllToolStripMenuItem1;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_AllToolStripMenuItem1 != null) {
          _AllToolStripMenuItem1.Click -= AllToolStripMenuItem1_Click;
        }

        _AllToolStripMenuItem1 = value;
        if (_AllToolStripMenuItem1 != null) {
          _AllToolStripMenuItem1.Click += AllToolStripMenuItem1_Click;
        }
      }
    }

    internal ToolStripMenuItem RotationToolStripMenuItem;
    private ToolStripMenuItem _XToolStripMenuItem2;

    internal ToolStripMenuItem XToolStripMenuItem2 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _XToolStripMenuItem2;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_XToolStripMenuItem2 != null) {
          _XToolStripMenuItem2.Click -= XToolStripMenuItem2_Click;
        }

        _XToolStripMenuItem2 = value;
        if (_XToolStripMenuItem2 != null) {
          _XToolStripMenuItem2.Click += XToolStripMenuItem2_Click;
        }
      }
    }

    private ToolStripMenuItem _YToolStripMenuItem2;

    internal ToolStripMenuItem YToolStripMenuItem2 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _YToolStripMenuItem2;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_YToolStripMenuItem2 != null) {
          _YToolStripMenuItem2.Click -= YToolStripMenuItem2_Click;
        }

        _YToolStripMenuItem2 = value;
        if (_YToolStripMenuItem2 != null) {
          _YToolStripMenuItem2.Click += YToolStripMenuItem2_Click;
        }
      }
    }

    private ToolStripMenuItem _ZToolStripMenuItem1;

    internal ToolStripMenuItem ZToolStripMenuItem1 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _ZToolStripMenuItem1;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_ZToolStripMenuItem1 != null) {
          _ZToolStripMenuItem1.Click -= ZToolStripMenuItem1_Click;
        }

        _ZToolStripMenuItem1 = value;
        if (_ZToolStripMenuItem1 != null) {
          _ZToolStripMenuItem1.Click += ZToolStripMenuItem1_Click;
        }
      }
    }

    private ToolStripMenuItem _AllToolStripMenuItem;

    internal ToolStripMenuItem AllToolStripMenuItem {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _AllToolStripMenuItem;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_AllToolStripMenuItem != null) {
          _AllToolStripMenuItem.Click -= AllToolStripMenuItem_Click_1;
        }

        _AllToolStripMenuItem = value;
        if (_AllToolStripMenuItem != null) {
          _AllToolStripMenuItem.Click += AllToolStripMenuItem_Click_1;
        }
      }
    }

    private ToolStripMenuItem _NumberAndVariableToolStripMenuItem;

    internal ToolStripMenuItem NumberAndVariableToolStripMenuItem {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _NumberAndVariableToolStripMenuItem;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_NumberAndVariableToolStripMenuItem != null) {
          _NumberAndVariableToolStripMenuItem.Click -= NumberAndVariableToolStripMenuItem_Click;
        }

        _NumberAndVariableToolStripMenuItem = value;
        if (_NumberAndVariableToolStripMenuItem != null) {
          _NumberAndVariableToolStripMenuItem.Click += NumberAndVariableToolStripMenuItem_Click;
        }
      }
    }

    private ToolStripMenuItem _DeselectToolStripMenuItem;

    internal ToolStripMenuItem DeselectToolStripMenuItem {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _DeselectToolStripMenuItem;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_DeselectToolStripMenuItem != null) {
          _DeselectToolStripMenuItem.Click -= DeselectToolStripMenuItem_Click;
        }

        _DeselectToolStripMenuItem = value;
        if (_DeselectToolStripMenuItem != null) {
          _DeselectToolStripMenuItem.Click += DeselectToolStripMenuItem_Click;
        }
      }
    }

    private ToolStripMenuItem _ClearClipboardToolStripMenuItem;

    internal ToolStripMenuItem ClearClipboardToolStripMenuItem {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _ClearClipboardToolStripMenuItem;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_ClearClipboardToolStripMenuItem != null) {
          _ClearClipboardToolStripMenuItem.Click -= ClearClipboardToolStripMenuItem_Click;
        }

        _ClearClipboardToolStripMenuItem = value;
        if (_ClearClipboardToolStripMenuItem != null) {
          _ClearClipboardToolStripMenuItem.Click += ClearClipboardToolStripMenuItem_Click;
        }
      }
    }

    internal ToolStripMenuItem AlignToolItem;
    private ToolStripMenuItem _XToolStripMenuItem3;

    internal ToolStripMenuItem XToolStripMenuItem3 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _XToolStripMenuItem3;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_XToolStripMenuItem3 != null) {
          _XToolStripMenuItem3.Click -= XToolStripMenuItem3_Click;
        }

        _XToolStripMenuItem3 = value;
        if (_XToolStripMenuItem3 != null) {
          _XToolStripMenuItem3.Click += XToolStripMenuItem3_Click;
        }
      }
    }

    private ToolStripMenuItem _YToolStripMenuItem3;

    internal ToolStripMenuItem YToolStripMenuItem3 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _YToolStripMenuItem3;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_YToolStripMenuItem3 != null) {
          _YToolStripMenuItem3.Click -= YToolStripMenuItem3_Click;
        }

        _YToolStripMenuItem3 = value;
        if (_YToolStripMenuItem3 != null) {
          _YToolStripMenuItem3.Click += YToolStripMenuItem3_Click;
        }
      }
    }

    private ToolStripMenuItem _ZToolStripMenuItem2;

    internal ToolStripMenuItem ZToolStripMenuItem2 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _ZToolStripMenuItem2;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_ZToolStripMenuItem2 != null) {
          _ZToolStripMenuItem2.Click -= ZToolStripMenuItem2_Click;
        }

        _ZToolStripMenuItem2 = value;
        if (_ZToolStripMenuItem2 != null) {
          _ZToolStripMenuItem2.Click += ZToolStripMenuItem2_Click;
        }
      }
    }

    internal ContextMenuStrip BackupMenuStrip;
    internal ToolStripMenuItem RestorToolStripMenuItem;
    internal Button CollisionPresetButton;
    internal TabControl ROMBrowser;
    internal TabPage ROMDataTabs;
    internal Label Label29;
    internal TextBox TreeFind;
    private TreeView _FileTree;

    internal TreeView FileTree {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _FileTree;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_FileTree != null) {
          _FileTree.NodeMouseDoubleClick -= FileTree_NodeMouseDoubleClick;
        }

        _FileTree = value;
        if (_FileTree != null) {
          _FileTree.NodeMouseDoubleClick += FileTree_NodeMouseDoubleClick;
        }
      }
    }

    internal Label Label46;
    private ComboBox _MapsCombobox;

    internal ComboBox MapsCombobox {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _MapsCombobox;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_MapsCombobox != null) {
          _MapsCombobox.SelectedIndexChanged -= MapsCombobox_SelectedIndexChanged;
        }

        _MapsCombobox = value;
        if (_MapsCombobox != null) {
          _MapsCombobox.SelectedIndexChanged += MapsCombobox_SelectedIndexChanged;
        }
      }
    }

    internal Label Label45;
    internal TextBox AnimStart;
    internal Label Label30;
    internal TextBox LimbStart;
    private Button _Button7;

    internal Button Button7 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _Button7;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_Button7 != null) {
          _Button7.Click -= Button7_Click;
        }

        _Button7 = value;
        if (_Button7 != null) {
          _Button7.Click += Button7_Click;
        }
      }
    }

    internal GroupBox GroupBox1;
    internal TextBox TriTypeText;
    internal Label Label48;
    internal Label Label47;
    private ComboBox _ColTriangleBox;

    internal ComboBox ColTriangleBox {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _ColTriangleBox;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_ColTriangleBox != null) {
          _ColTriangleBox.SelectedIndexChanged -= ColTriangleBox_SelectedIndexChanged;
        }

        _ColTriangleBox = value;
        if (_ColTriangleBox != null) {
          _ColTriangleBox.SelectedIndexChanged += ColTriangleBox_SelectedIndexChanged;
        }
      }
    }

    private Button _Button9;

    internal Button Button9 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _Button9;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_Button9 != null) {
          _Button9.Click -= Button9_Click;
        }

        _Button9 = value;
        if (_Button9 != null) {
          _Button9.Click += Button9_Click;
        }
      }
    }

    internal ToolStripMenuItem FileToolStripMenuItem1;
    private ToolStripMenuItem _ToolStripMenuItem2;

    internal ToolStripMenuItem ToolStripMenuItem2 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _ToolStripMenuItem2;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_ToolStripMenuItem2 != null) {
          _ToolStripMenuItem2.Click -= ToolStripMenuItem2_Click;
        }

        _ToolStripMenuItem2 = value;
        if (_ToolStripMenuItem2 != null) {
          _ToolStripMenuItem2.Click += ToolStripMenuItem2_Click;
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

    internal ToolStripSeparator toolStripSeparator12;
    private ToolStripMenuItem _ExitToolStripMenuItem;

    internal ToolStripMenuItem ExitToolStripMenuItem {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _ExitToolStripMenuItem;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_ExitToolStripMenuItem != null) {
          _ExitToolStripMenuItem.Click -= ExitToolStripMenuItem_Click;
        }

        _ExitToolStripMenuItem = value;
        if (_ExitToolStripMenuItem != null) {
          _ExitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
        }
      }
    }

    internal ToolStripMenuItem EditToolStripMenuItem1;
    private ToolStripMenuItem _UndoToolStripMenuItem;

    internal ToolStripMenuItem UndoToolStripMenuItem {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _UndoToolStripMenuItem;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_UndoToolStripMenuItem != null) {
          _UndoToolStripMenuItem.Click -= UndoToolStripMenuItem_Click;
        }

        _UndoToolStripMenuItem = value;
        if (_UndoToolStripMenuItem != null) {
          _UndoToolStripMenuItem.Click += UndoToolStripMenuItem_Click;
        }
      }
    }

    private ToolStripMenuItem _WireframeModeToolStripMenuItem;

    internal ToolStripMenuItem WireframeModeToolStripMenuItem {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _WireframeModeToolStripMenuItem;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_WireframeModeToolStripMenuItem != null) {
          _WireframeModeToolStripMenuItem.Click -= WireframeModeToolStripMenuItem_Click;
        }

        _WireframeModeToolStripMenuItem = value;
        if (_WireframeModeToolStripMenuItem != null) {
          _WireframeModeToolStripMenuItem.Click += WireframeModeToolStripMenuItem_Click;
        }
      }
    }

    internal ToolStripMenuItem RenderToolStripMenuItem;
    private ToolStripMenuItem _GraphicsToolStripMenuItem;

    internal ToolStripMenuItem GraphicsToolStripMenuItem {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _GraphicsToolStripMenuItem;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_GraphicsToolStripMenuItem != null) {
          _GraphicsToolStripMenuItem.Click -= GraphicsToolStripMenuItem_Click;
        }

        _GraphicsToolStripMenuItem = value;
        if (_GraphicsToolStripMenuItem != null) {
          _GraphicsToolStripMenuItem.Click += GraphicsToolStripMenuItem_Click;
        }
      }
    }

    private ToolStripMenuItem _CollisionOverlayToolStripMenuItem;

    internal ToolStripMenuItem CollisionOverlayToolStripMenuItem {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _CollisionOverlayToolStripMenuItem;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_CollisionOverlayToolStripMenuItem != null) {
          _CollisionOverlayToolStripMenuItem.Click -= CollisionOverlayToolStripMenuItem_Click;
        }

        _CollisionOverlayToolStripMenuItem = value;
        if (_CollisionOverlayToolStripMenuItem != null) {
          _CollisionOverlayToolStripMenuItem.Click += CollisionOverlayToolStripMenuItem_Click;
        }
      }
    }

    internal ToolStripMenuItem ToolsToolStripMenuItem1;
    internal ToolStripMenuItem MouseToolToolStripMenuItem1;
    private ToolStripMenuItem _CameraOnlyMenu;

    internal ToolStripMenuItem CameraOnlyMenu {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _CameraOnlyMenu;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_CameraOnlyMenu != null) {
          _CameraOnlyMenu.Click -= CameraOnlyToolStripMenuItem1_Click;
        }

        _CameraOnlyMenu = value;
        if (_CameraOnlyMenu != null) {
          _CameraOnlyMenu.Click += CameraOnlyToolStripMenuItem1_Click;
        }
      }
    }

    private ToolStripMenuItem _ActorSelectorMenu;

    internal ToolStripMenuItem ActorSelectorMenu {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _ActorSelectorMenu;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_ActorSelectorMenu != null) {
          _ActorSelectorMenu.Click -= ActorSelectorToolStripMenuItem2_Click;
        }

        _ActorSelectorMenu = value;
        if (_ActorSelectorMenu != null) {
          _ActorSelectorMenu.Click += ActorSelectorToolStripMenuItem2_Click;
        }
      }
    }

    private ToolStripMenuItem _CollisionToolStripMenuItem;

    internal ToolStripMenuItem CollisionToolStripMenuItem {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _CollisionToolStripMenuItem;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_CollisionToolStripMenuItem != null) {
          _CollisionToolStripMenuItem.Click -= CollisionToolStripMenuItem_Click;
        }

        _CollisionToolStripMenuItem = value;
        if (_CollisionToolStripMenuItem != null) {
          _CollisionToolStripMenuItem.Click += CollisionToolStripMenuItem_Click;
        }
      }
    }

    internal ToolStripMenuItem CollisionSelectorMenu;
    internal ToolStripMenuItem EdgeToolStripMenuItem;
    internal ToolStripMenuItem TriangleToolStripMenuItem;
    internal ToolStripMenuItem VertexToolStripMenuItem;
    internal ToolStripMenuItem LockAxesToolStripMenuItem;
    private ToolStripMenuItem _XToolStripMenuItem;

    internal ToolStripMenuItem XToolStripMenuItem {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _XToolStripMenuItem;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_XToolStripMenuItem != null) {
          _XToolStripMenuItem.Click -= XToolStripMenuItem_Click;
        }

        _XToolStripMenuItem = value;
        if (_XToolStripMenuItem != null) {
          _XToolStripMenuItem.Click += XToolStripMenuItem_Click;
        }
      }
    }

    private ToolStripMenuItem _YToolStripMenuItem;

    internal ToolStripMenuItem YToolStripMenuItem {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _YToolStripMenuItem;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_YToolStripMenuItem != null) {
          _YToolStripMenuItem.Click -= YToolStripMenuItem_Click;
        }

        _YToolStripMenuItem = value;
        if (_YToolStripMenuItem != null) {
          _YToolStripMenuItem.Click += YToolStripMenuItem_Click;
        }
      }
    }

    private ToolStripMenuItem _DisableToolStripMenuItem;

    internal ToolStripMenuItem DisableToolStripMenuItem {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _DisableToolStripMenuItem;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_DisableToolStripMenuItem != null) {
          _DisableToolStripMenuItem.Click -= DisableToolStripMenuItem_Click;
        }

        _DisableToolStripMenuItem = value;
        if (_DisableToolStripMenuItem != null) {
          _DisableToolStripMenuItem.Click += DisableToolStripMenuItem_Click;
        }
      }
    }

    internal ToolStripMenuItem OptionsToolStripMenuItem2;
    private ToolStripMenuItem _DisableDepthTestToolStripMenuItem;

    internal ToolStripMenuItem DisableDepthTestToolStripMenuItem {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _DisableDepthTestToolStripMenuItem;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_DisableDepthTestToolStripMenuItem != null) {
          _DisableDepthTestToolStripMenuItem.Click -= DisableDepthTestToolStripMenuItem_Click;
        }

        _DisableDepthTestToolStripMenuItem = value;
        if (_DisableDepthTestToolStripMenuItem != null) {
          _DisableDepthTestToolStripMenuItem.Click += DisableDepthTestToolStripMenuItem_Click;
        }
      }
    }

    internal ToolStripMenuItem ToolsToolStripMenuItem;
    private ToolStripMenuItem _OptionsToolStripMenuItem1;

    internal ToolStripMenuItem OptionsToolStripMenuItem1 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _OptionsToolStripMenuItem1;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_OptionsToolStripMenuItem1 != null) {
          _OptionsToolStripMenuItem1.Click -= OptionsToolStripMenuItem1_Click;
        }

        _OptionsToolStripMenuItem1 = value;
        if (_OptionsToolStripMenuItem1 != null) {
          _OptionsToolStripMenuItem1.Click += OptionsToolStripMenuItem1_Click;
        }
      }
    }

    internal ToolStripMenuItem HelpToolStripMenuItem1;
    private ToolStripMenuItem _AboutUoTToolStripMenuItem;

    internal ToolStripMenuItem AboutUoTToolStripMenuItem {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _AboutUoTToolStripMenuItem;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_AboutUoTToolStripMenuItem != null) {
          _AboutUoTToolStripMenuItem.Click -= AboutUoTToolStripMenuItem_Click;
        }

        _AboutUoTToolStripMenuItem = value;
        if (_AboutUoTToolStripMenuItem != null) {
          _AboutUoTToolStripMenuItem.Click += AboutUoTToolStripMenuItem_Click;
        }
      }
    }

    internal MenuStrip UoTMainMenu;
    internal ToolStripMenuItem ToolStripMenuItem3;
    internal ToolStripMenuItem UndoToolStripMenuItem1;
    internal ToolStripMenuItem RedoToolStripMenuItem;
    internal ContextMenuStrip VertContextMenu;
    internal ToolStripMenuItem ToolStripMenuItem5;
    internal ToolStripSeparator ToolStripSeparator15;
    internal ToolStripMenuItem ToolStripMenuItem6;
    internal ToolStripMenuItem ToolStripMenuItem7;
    internal ToolStripMenuItem ToolStripMenuItem8;
    internal ToolStripMenuItem ToolStripMenuItem9;
    internal ToolStripMenuItem ToolStripMenuItem10;
    internal ToolStripMenuItem ToolStripMenuItem11;
    internal ToolStripMenuItem ToolStripMenuItem12;
    internal ToolStripMenuItem ToolStripMenuItem13;
    internal ToolStripMenuItem ToolStripMenuItem14;
    internal ToolStripMenuItem ToolStripMenuItem15;
    internal ToolStripMenuItem ToolStripMenuItem16;
    internal ToolStripMenuItem ToolStripMenuItem17;
    internal ToolStripMenuItem ToolStripMenuItem18;
    internal ToolStripMenuItem ToolStripMenuItem19;
    internal ToolStripSeparator ToolStripSeparator16;
    private ToolStripMenuItem _ToolStripMenuItem20;

    internal ToolStripMenuItem ToolStripMenuItem20 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _ToolStripMenuItem20;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_ToolStripMenuItem20 != null) {
          _ToolStripMenuItem20.Click -= ToolStripMenuItem20_Click;
        }

        _ToolStripMenuItem20 = value;
        if (_ToolStripMenuItem20 != null) {
          _ToolStripMenuItem20.Click += ToolStripMenuItem20_Click;
        }
      }
    }

    internal ToolStripMenuItem ToolStripMenuItem21;
    internal ToolStripMenuItem ToolStripMenuItem22;
    internal ToolStripMenuItem ToolStripMenuItem23;
    internal ToolStripMenuItem ToolStripMenuItem24;
    internal ToolStripMenuItem ToolStripMenuItem25;
    internal ToolStripMenuItem ToolStripMenuItem26;
    internal ToolStripMenuItem ToolStripMenuItem27;
    internal ToolStripMenuItem ToolStripMenuItem28;
    internal ToolStripMenuItem ToolStripMenuItem29;
    internal ToolStripMenuItem ToolStripMenuItem30;
    internal ToolStripMenuItem ToolStripMenuItem31;
    internal ToolStripMenuItem ToolStripMenuItem32;
    internal ToolStripMenuItem ToolStripMenuItem33;
    private ToolStripMenuItem _ToolStripMenuItem34;

    internal ToolStripMenuItem ToolStripMenuItem34 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _ToolStripMenuItem34;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_ToolStripMenuItem34 != null) {
          _ToolStripMenuItem34.Click -= ToolStripMenuItem34_Click;
        }

        _ToolStripMenuItem34 = value;
        if (_ToolStripMenuItem34 != null) {
          _ToolStripMenuItem34.Click += ToolStripMenuItem34_Click;
        }
      }
    }

    private ToolStripMenuItem _ToolStripMenuItem35;

    internal ToolStripMenuItem ToolStripMenuItem35 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _ToolStripMenuItem35;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_ToolStripMenuItem35 != null) {
          _ToolStripMenuItem35.Click -= ToolStripMenuItem35_Click;
        }

        _ToolStripMenuItem35 = value;
        if (_ToolStripMenuItem35 != null) {
          _ToolStripMenuItem35.Click += ToolStripMenuItem35_Click;
        }
      }
    }

    internal ToolStripMenuItem ContentsToolStripMenuItem;
    private ToolStripMenuItem _CustomLevel;

    internal ToolStripMenuItem CustomLevel {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _CustomLevel;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_CustomLevel != null) {
          _CustomLevel.Click -= CustomLevel_Click;
        }

        _CustomLevel = value;
        if (_CustomLevel != null) {
          _CustomLevel.Click += CustomLevel_Click;
        }
      }
    }

    internal GroupBox GroupBox9;
    internal ProgressBar ProgressBar1;
    internal Label Label28;
    internal Button Button16;
    internal Button Button15;
    internal TabPage DLTab;
    internal ColorDialog ColorDialog1;
    private ToolStripMenuItem _DisplayListSelectorToolStripMenuItem;

    internal ToolStripMenuItem DisplayListSelectorToolStripMenuItem {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _DisplayListSelectorToolStripMenuItem;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_DisplayListSelectorToolStripMenuItem != null) {
          _DisplayListSelectorToolStripMenuItem.Click -= DisplayListSelectorToolStripMenuItem_Click;
        }

        _DisplayListSelectorToolStripMenuItem = value;
        if (_DisplayListSelectorToolStripMenuItem != null) {
          _DisplayListSelectorToolStripMenuItem.Click += DisplayListSelectorToolStripMenuItem_Click;
        }
      }
    }

    private SaveFileDialog _RipDL;

    internal SaveFileDialog RipDL {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _RipDL;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_RipDL != null) {
          _RipDL.FileOk -= RipDL_FileOk;
        }

        _RipDL = value;
        if (_RipDL != null) {
          _RipDL.FileOk += RipDL_FileOk;
        }
      }
    }

    private SaveFileDialog _SaveROMAs;

    internal SaveFileDialog SaveROMAs {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _SaveROMAs;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_SaveROMAs != null) {
          _SaveROMAs.FileOk -= SaveROMAs_FileOk;
        }

        _SaveROMAs = value;
        if (_SaveROMAs != null) {
          _SaveROMAs.FileOk += SaveROMAs_FileOk;
        }
      }
    }

    internal ContextMenuStrip DLEditorContextMenu;
    internal ToolStripMenuItem Copy;
    internal ToolStripMenuItem Paste;
    internal ToolStripMenuItem Reset;
    internal GroupBox GroupBox8;
    internal ToolStripStatusLabel CamXLabel;
    internal ToolStripStatusLabel CamYLabel;
    internal ToolStripStatusLabel CamZLabel;
    internal TabPage IndividualFiles;
    private RadioButton _RadioButton2;

    internal RadioButton RadioButton2 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _RadioButton2;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_RadioButton2 != null) {
          _RadioButton2.CheckedChanged -= RadioButton2_CheckedChanged;
        }

        _RadioButton2 = value;
        if (_RadioButton2 != null) {
          _RadioButton2.CheckedChanged += RadioButton2_CheckedChanged;
        }
      }
    }

    internal GroupBox GroupBox7;
    private TextBox _WholeCommandTxt;

    internal TextBox WholeCommandTxt {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _WholeCommandTxt;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_WholeCommandTxt != null) {
          _WholeCommandTxt.TextChanged -= WholeCommandTxt_TextChanged;
        }

        _WholeCommandTxt = value;
        if (_WholeCommandTxt != null) {
          _WholeCommandTxt.TextChanged += WholeCommandTxt_TextChanged;
        }
      }
    }

    internal Label Label3;
    private Button _Button8;

    internal Button Button8 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _Button8;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_Button8 != null) {
          _Button8.Click -= Button8_Click;
        }

        _Button8 = value;
        if (_Button8 != null) {
          _Button8.Click += Button8_Click;
        }
      }
    }

    private TextBox _HiwordText;

    internal TextBox HiwordText {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _HiwordText;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_HiwordText != null) {
          _HiwordText.KeyPress -= CommandCodeText_KeyDown;
          _HiwordText.TextChanged -= CommandCodeText_TextChanged;
        }

        _HiwordText = value;
        if (_HiwordText != null) {
          _HiwordText.KeyPress += CommandCodeText_KeyDown;
          _HiwordText.TextChanged += CommandCodeText_TextChanged;
        }
      }
    }

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

    private TextBox _LowordText;

    internal TextBox LowordText {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _LowordText;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_LowordText != null) {
          _LowordText.KeyPress -= CommandCodeText_KeyDown;
          _LowordText.TextChanged -= CommandCodeText_TextChanged;
        }

        _LowordText = value;
        if (_LowordText != null) {
          _LowordText.KeyPress += CommandCodeText_KeyDown;
          _LowordText.TextChanged += CommandCodeText_TextChanged;
        }
      }
    }

    private TextBox _CommandCodeText;

    internal TextBox CommandCodeText {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _CommandCodeText;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_CommandCodeText != null) {
          _CommandCodeText.KeyPress -= CommandCodeText_KeyDown;
          _CommandCodeText.TextChanged -= CommandCodeText_TextChanged;
        }

        _CommandCodeText = value;
        if (_CommandCodeText != null) {
          _CommandCodeText.KeyPress += CommandCodeText_KeyDown;
          _CommandCodeText.TextChanged += CommandCodeText_TextChanged;
        }
      }
    }

    internal ComboBox CommandJumpBox;
    internal Label Label26;
    internal Label Label25;
    internal Label Label9;
    private Button _Button4;

    internal Button Button4 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _Button4;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_Button4 != null) {
          _Button4.Click -= Button4_Click;
        }

        _Button4 = value;
        if (_Button4 != null) {
          _Button4.Click += Button4_Click;
        }
      }
    }

    private ListBox _CommandsListbox;

    internal ListBox CommandsListbox {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _CommandsListbox;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_CommandsListbox != null) {
          _CommandsListbox.SelectedIndexChanged -= CommandsListbox_SelectedIndexChanged;
          _CommandsListbox.DoubleClick -= CommandsListbox_DoubleClick;
        }

        _CommandsListbox = value;
        if (_CommandsListbox != null) {
          _CommandsListbox.SelectedIndexChanged += CommandsListbox_SelectedIndexChanged;
          _CommandsListbox.DoubleClick += CommandsListbox_DoubleClick;
        }
      }
    }

    private ComboBox _DListSelection;

    internal ComboBox DListSelection {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _DListSelection;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_DListSelection != null) {
          _DListSelection.SelectedIndexChanged -= DListSelection_SelectedIndexChanged;
        }

        _DListSelection = value;
        if (_DListSelection != null) {
          _DListSelection.SelectedIndexChanged += DListSelection_SelectedIndexChanged;
        }
      }
    }

    private RadioButton _RadioButton1;

    internal RadioButton RadioButton1 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _RadioButton1;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_RadioButton1 != null) {
          _RadioButton1.CheckedChanged -= RadioButton1_CheckedChanged;
        }

        _RadioButton1 = value;
        if (_RadioButton1 != null) {
          _RadioButton1.CheckedChanged += RadioButton1_CheckedChanged;
        }
      }
    }

    internal GroupBox GroupBox3;
    private Button _Button12;

    internal Button Button12 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _Button12;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_Button12 != null) {
          _Button12.Click -= Button12_Click;
        }

        _Button12 = value;
        if (_Button12 != null) {
          _Button12.Click += Button12_Click;
        }
      }
    }

    internal Label Label4;
    private Button _Button10;

    internal Button Button10 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _Button10;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_Button10 != null) {
          _Button10.Click -= Button10_Click;
        }

        _Button10 = value;
        if (_Button10 != null) {
          _Button10.Click += Button10_Click;
        }
      }
    }

    private CheckBox _CheckBox2;

    internal CheckBox CheckBox2 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _CheckBox2;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_CheckBox2 != null) {
          _CheckBox2.CheckedChanged -= CheckBox2_CheckedChanged;
        }

        _CheckBox2 = value;
        if (_CheckBox2 != null) {
          _CheckBox2.CheckedChanged += CheckBox2_CheckedChanged;
        }
      }
    }

    internal ToolStripMenuItem RendererToolStripMenuItem;
    private ToolStripMenuItem _TexturesToolStripMenuItem;

    internal ToolStripMenuItem TexturesToolStripMenuItem {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _TexturesToolStripMenuItem;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_TexturesToolStripMenuItem != null) {
          _TexturesToolStripMenuItem.Click -= TexturesToolStripMenuItem_Click;
        }

        _TexturesToolStripMenuItem = value;
        if (_TexturesToolStripMenuItem != null) {
          _TexturesToolStripMenuItem.Click += TexturesToolStripMenuItem_Click;
        }
      }
    }

    private ToolStripMenuItem _ColorCombinerToolStripMenuItem;

    internal ToolStripMenuItem ColorCombinerToolStripMenuItem {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _ColorCombinerToolStripMenuItem;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_ColorCombinerToolStripMenuItem != null) {
          _ColorCombinerToolStripMenuItem.Click -= ColorCombinerToolStripMenuItem_Click;
        }

        _ColorCombinerToolStripMenuItem = value;
        if (_ColorCombinerToolStripMenuItem != null) {
          _ColorCombinerToolStripMenuItem.Click += ColorCombinerToolStripMenuItem_Click;
        }
      }
    }

    private ToolStripMenuItem _AnisotropicFilteringToolStripMenuItem;

    internal ToolStripMenuItem AnisotropicFilteringToolStripMenuItem {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _AnisotropicFilteringToolStripMenuItem;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_AnisotropicFilteringToolStripMenuItem != null) {
          _AnisotropicFilteringToolStripMenuItem.Click -= AnisotropicFilteringToolStripMenuItem_Click;
        }

        _AnisotropicFilteringToolStripMenuItem = value;
        if (_AnisotropicFilteringToolStripMenuItem != null) {
          _AnisotropicFilteringToolStripMenuItem.Click += AnisotropicFilteringToolStripMenuItem_Click;
        }
      }
    }

    private ToolStripMenuItem _FullSceneAntialiasingToolStripMenuItem;

    internal ToolStripMenuItem FullSceneAntialiasingToolStripMenuItem {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _FullSceneAntialiasingToolStripMenuItem;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_FullSceneAntialiasingToolStripMenuItem != null) {
          _FullSceneAntialiasingToolStripMenuItem.Click -= FullSceneAntialiasingToolStripMenuItem_Click;
        }

        _FullSceneAntialiasingToolStripMenuItem = value;
        if (_FullSceneAntialiasingToolStripMenuItem != null) {
          _FullSceneAntialiasingToolStripMenuItem.Click += FullSceneAntialiasingToolStripMenuItem_Click;
        }
      }
    }

    internal Label FrameNo;
    internal Label AnimationElapse;
    internal Label Label5;
    private TrackBar _CurrentFrame;

    internal TrackBar CurrentFrame {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _CurrentFrame;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_CurrentFrame != null) {
          _CurrentFrame.Scroll -= CurrentFrame_Scroll;
        }

        _CurrentFrame = value;
        if (_CurrentFrame != null) {
          _CurrentFrame.Scroll += CurrentFrame_Scroll;
        }
      }
    }

    private ComboBox _animationbank;

    internal ComboBox animationbank {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _animationbank;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_animationbank != null) {
          _animationbank.SelectedIndexChanged -= animationbank_SelectedIndexChanged;
        }

        _animationbank = value;
        if (_animationbank != null) {
          _animationbank.SelectedIndexChanged += animationbank_SelectedIndexChanged;
        }
      }
    }

    internal Label Label27;
    private NumericUpDown _AnimationFPS;

    internal NumericUpDown AnimationFPS {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _AnimationFPS;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_AnimationFPS != null) {
          _AnimationFPS.ValueChanged -= NumericUpDown1_ValueChanged;
          _AnimationFPS.ValueChanged -= NumericUpDown1_ValueChanged;
        }

        _AnimationFPS = value;
        if (_AnimationFPS != null) {
          _AnimationFPS.ValueChanged += NumericUpDown1_ValueChanged;
          _AnimationFPS.ValueChanged += NumericUpDown1_ValueChanged;
        }
      }
    }

    internal GroupBox AnimationSetGroup;
    internal GroupBox PlaybackGroup;
    internal Label Label20;
    internal ContextMenuStrip VarContextMenu;
    internal ContextMenuStrip NumContextMenu;
    internal ContextMenuStrip GrpContextMenu;
    private Button _Button6;

    internal Button Button6 {
      [MethodImpl(MethodImplOptions.Synchronized)]
      get {
        return _Button6;
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      set {
        if (_Button6 != null) {
          _Button6.Click -= Button6_Click_1;
        }

        _Button6 = value;
        if (_Button6 != null) {
          _Button6.Click += Button6_Click_1;
        }
      }
    }
  }
}