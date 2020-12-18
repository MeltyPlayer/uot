using System;
using System.IO;
using System.Xml;
using Microsoft.VisualBasic;
using Tao.DevIl;

namespace UoT {
  public partial class LevelCreator {
    public LevelCreator() {
      InitializeComponent();
      _LevelNameText.Name = "LevelNameText";
      _Button3.Name = "Button3";
      _SeparateCollisionToggle.Name = "SeparateCollisionToggle";
      _Button1.Name = "Button1";
      _UpdateRawDataButton.Name = "UpdateRawDataButton";
      _NewToolStripMenuItem.Name = "NewToolStripMenuItem";
      _OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
      _SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
    }

    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    private bool SeparateCollisionMap = false;
    /* TODO ERROR: Skipped EndRegionDirectiveTrivia *//* TODO ERROR: Skipped RegionDirectiveTrivia */
    public enum Commands {
      // commands
      SINGLEROOM = 0x16,
      ENVVARS = 0x12,
      TIMECONTROL = 0x10,
      MESHDATA = 0xA,
      MULTIROOM = 0x18,
      SCENESTART = 0x15,
      HEADEREND = 0x14,
      EXITS = 0x13,
      SKYBOX = 0x11,
      ROOMACTORS = 0x1,
      SCENEACTORS = 0xE,
      GROUPS = 0xB,
      LINKS = 0x0,

      // banks
      MAPBANK = 0x3,
      SCENEBANK = 0x2
    }

    public enum HeaderTypes {
      SCENE = 0,
      MAP = 1
    }

    public struct Output {
      public byte[] RawHeader;
      public byte[] RawData;
    }

    public struct Header {
      public int Command;
    }

    public struct Actor {
      public short x;
      public short y;
      public short z;
      public short xr;
      public short yr;
      public short zr;
      public uint no;
      public uint var;
    }

    public struct Group {
      public uint val;
    }

    public struct Pointers {
      public uint ActorPtr;
      public uint GroupPtr;
      public uint GraphicsPtr;
      public uint VertStart;
      public uint CollisionPtr;
      public uint ScActorPtr;
      public uint LinkActorPtr;
    }

    public struct Count {
      public byte RmActorCount;
      public byte ScActorCount;
      public byte LinkCount;
      public byte GrCount;
    }

    public struct Env {
      public byte EchoLevel;
    }

    public struct ColPoly {
      public int Param;
      public int A;
      public int B;
      public int C;
      public short nX;
      public short nY;
      public short nZ;
      public short Distance;
    }

    public struct ColVert {
      public short x;
      public short y;
      public short z;
    }

    public struct ColHead {
      public short MinX;
      public short MinY;
      public short MinZ;
      public short MaxX;
      public short MaxY;
      public short MaxZ;
      public uint VertCnt;
      public uint VertOff;
      public uint PolyCnt;
      public uint PolyOff;
      public uint PolyTypeOff;
      public uint CamDataOff;
      public uint WaterBoxCnt;
      public uint WaterBoxOff;
    }

    public string TemplateFilename = "";
    public string TemplateName = "";
    public OBJData.OBJModel CollisionOBJ = new OBJData.OBJModel();
    public OBJData.OBJModel GraphicsOBJ = new OBJData.OBJModel();
    public Pointers Pointer = new Pointers();
    public Count Counts = new Count();
    public Group[] Groups = new Group[0];
    public Actor[] RoomActors = new Actor[0];
    public Actor[] SceneActors = new Actor[0];
    public Actor[] LinkActors = new Actor[0];
    public Env Environment = new Env();
    public Output MapBuff = new Output();
    public Output SceneBuff = new Output();
    public ColHead CollisionHeader = new ColHead();
    public ColVert[] CollisionVertices;
    public ColPoly[] CollisionPolies;
    public string objGraphicsFile = "";
    public string objCollisionFile = "";
    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    private void ObjExport_Load(object sender, EventArgs e) {
      Il.ilInit();
      NewLevel();
    }

    private void AddGroup(ref Group[] _Groups, int Count) {
      for (int i = 0, loopTo = Count - 1; i <= loopTo; i++) {
        Array.Resize(ref _Groups, Counts.GrCount + 1);
        {
          var withBlock = _Groups[Counts.GrCount];
          withBlock.val = 0xB00BU;
        }

        Counts.GrCount = (byte)(Counts.GrCount + 1);
      }
    }

    private void AddRoomActor(ref Actor[] _Actors, int count) {
      for (int i = 0, loopTo = count - 1; i <= loopTo; i++) {
        Array.Resize(ref _Actors, Counts.RmActorCount + 1);
        {
          var withBlock = _Actors[Counts.RmActorCount];
          withBlock.x = 0;
          withBlock.y = 0;
          withBlock.z = 0;
          withBlock.xr = 0;
          withBlock.yr = 0;
          withBlock.zr = 0;
          withBlock.no = 0xDEADU;
          withBlock.var = 0xBEEFU;
        }

        Counts.RmActorCount = (byte)(Counts.RmActorCount + 1);
      }
    }

    private void AddSceneActor(ref Actor[] _SceneActors, int count) {
      for (int i = 0, loopTo = count - 1; i <= loopTo; i++) {
        Array.Resize(ref _SceneActors, Counts.ScActorCount + 1);
        {
          var withBlock = _SceneActors[Counts.ScActorCount];
          withBlock.x = 0;
          withBlock.y = 0;
          withBlock.z = 0;
          withBlock.xr = -1;
          withBlock.yr = 0;
          withBlock.zr = -1;
          withBlock.no = 0xDEADU;
          withBlock.var = 0xBEEFU;
        }

        Counts.ScActorCount = (byte)(Counts.ScActorCount + 1);
      }
    }

    private void AddLinkActor(ref Actor[] _LinkActors, int count) {
      for (int i = 0, loopTo = count - 1; i <= loopTo; i++) {
        Array.Resize(ref _LinkActors, Counts.LinkCount + 1);
        {
          var withBlock = _LinkActors[Counts.LinkCount];
          withBlock.x = 0;
          withBlock.y = 0;
          withBlock.z = 0;
          withBlock.xr = 0;
          withBlock.yr = 0;
          withBlock.zr = 0;
          withBlock.no = 0xDEADU;
          withBlock.var = 0xBEEFU;
        }

        Counts.LinkCount = (byte)(Counts.LinkCount + 1);
      }
    }

    private void CheckBox1_CheckedChanged(object sender, EventArgs e) {
      if (SeparateCollisionMap) {
        ObjCollisionText.Text = "";
        objCollisionFile = "";
        ObjCollisionText.Enabled = false;
        Button3.Enabled = false;
        SeparateCollisionMap = false;
        CollisionOBJ = default;
      } else {
        ObjCollisionText.Enabled = true;
        Button3.Enabled = true;
        SeparateCollisionMap = true;
        CollisionOBJ = new OBJData.OBJModel();
      }
    }

    private byte[] CompileMapHeader() { // NEEDS MODULARITY
      var tBuffer = new byte[1];
      int tPos = 0;
      {
        var withBlock = Pointer;
        withBlock.GroupPtr = 0x38U;
        withBlock.ActorPtr = (uint)(withBlock.GroupPtr + Counts.GrCount * 2);
        withBlock.GraphicsPtr = (uint)(withBlock.ActorPtr + Counts.RmActorCount * 16);
        withBlock.VertStart = (uint)(withBlock.GraphicsPtr + 32L);
      }

      Functions.WriteInt32(ref tBuffer, 0x16000000U, ref tPos);
      Functions.WriteInt32(ref tBuffer, (uint)(0 | Environment.EchoLevel), ref tPos);
      Functions.WriteInt32(ref tBuffer, 0x12000000U, ref tPos);
      Functions.WriteInt32(ref tBuffer, 0U, ref tPos);
      Functions.WriteInt32(ref tBuffer, 0x10000000U, ref tPos);
      Functions.WriteInt32(ref tBuffer, 0U, ref tPos);
      Functions.WriteInt32(ref tBuffer, 0xA000000U, ref tPos);
      Functions.WriteInt32(ref tBuffer, (uint)(0x3000000L | Pointer.GraphicsPtr), ref tPos);
      short argOffset = (short)tPos;
      Functions.WriteInt16(ref tBuffer, ref argOffset, (short)(0xB00 | Counts.GrCount));
      Functions.WriteInt32(ref tBuffer, (uint)(0x3000000L | Pointer.GroupPtr), ref tPos);
      short argOffset1 = (short)tPos;
      Functions.WriteInt16(ref tBuffer, ref argOffset1, (short)(0x100 | Counts.RmActorCount));
      Functions.WriteInt32(ref tBuffer, (uint)(0x3000000L | Pointer.ActorPtr), ref tPos);
      Functions.WriteInt32(ref tBuffer, 0x14000000U, ref tPos);
      Functions.WriteInt32(ref tBuffer, 0U, ref tPos);
      int tPos1 = (int)Pointer.GroupPtr;
      for (int i = 0, loopTo = Counts.GrCount - 1; i <= loopTo; i++) {
        short argOffset2 = (short)tPos1;
        Functions.WriteInt16(ref tBuffer, ref argOffset2, (short)Groups[i].val);
      }

      for (int i = 0, loopTo1 = Counts.RmActorCount - 1; i <= loopTo1; i++) {
        short argOffset3 = (short)tPos1;
        Functions.WriteInt16(ref tBuffer, ref argOffset3, RoomActors[i].x);
        short argOffset4 = (short)tPos1;
        Functions.WriteInt16(ref tBuffer, ref argOffset4, RoomActors[i].y);
        short argOffset5 = (short)tPos1;
        Functions.WriteInt16(ref tBuffer, ref argOffset5, RoomActors[i].z);
        short argOffset6 = (short)tPos1;
        Functions.WriteInt16(ref tBuffer, ref argOffset6, RoomActors[i].xr);
        short argOffset7 = (short)tPos1;
        Functions.WriteInt16(ref tBuffer, ref argOffset7, RoomActors[i].yr);
        short argOffset8 = (short)tPos1;
        Functions.WriteInt16(ref tBuffer, ref argOffset8, RoomActors[i].zr);
        short argOffset9 = (short)tPos1;
        Functions.WriteInt16(ref tBuffer, ref argOffset9, (short)RoomActors[i].no);
        short argOffset10 = (short)tPos1;
        Functions.WriteInt16(ref tBuffer, ref argOffset10, (short)RoomActors[i].var);
      }

      short argOffset11 = (short)tPos1;
      Functions.WriteInt16(ref tBuffer, ref argOffset11, 1);
      short argOffset12 = (short)tPos1;
      Functions.WriteInt16(ref tBuffer, ref argOffset12, 0);
      Functions.WriteInt32(ref tBuffer, (uint)(0x3000000 | tPos1 + 8), ref tPos1);
      Functions.WriteInt32(ref tBuffer, (uint)(0x3000000 | tPos1 + 8), ref tPos1);
      Functions.WriteInt32(ref tBuffer, (uint)(0x3000000 | tPos1 + 16 + GraphicsOBJ.Vertices.Length * 16), ref tPos1);
      Functions.WriteInt32(ref tBuffer, 0x1000000U, ref tPos1);
      for (int i = 0; i <= 2; i++)
        Functions.WriteInt32(ref tBuffer, 0U, ref tPos1);
      for (int i = 0, loopTo2 = GraphicsOBJ.Vertices.Length - 1; i <= loopTo2; i++) {
        {
          var withBlock1 = GraphicsOBJ.Vertices[i];
          short argOffset13 = (short)tPos1;
          Functions.WriteInt16(ref tBuffer, ref argOffset13, withBlock1.x);
          short argOffset14 = (short)tPos1;
          Functions.WriteInt16(ref tBuffer, ref argOffset14, withBlock1.y);
          short argOffset15 = (short)tPos1;
          Functions.WriteInt16(ref tBuffer, ref argOffset15, withBlock1.z);
          short argOffset16 = (short)tPos1;
          Functions.WriteInt16(ref tBuffer, ref argOffset16, 0);
          short argOffset17 = (short)tPos1;
          Functions.WriteInt16(ref tBuffer, ref argOffset17, GraphicsOBJ.TexCoords[i].s);
          short argOffset18 = (short)tPos1;
          Functions.WriteInt16(ref tBuffer, ref argOffset18, GraphicsOBJ.TexCoords[i].t);
          Array.Resize(ref tBuffer, tPos1 + 4 + 1);
          tBuffer[tPos1] = 0xFF;
          tBuffer[tPos1 + 1] = 0xFF;
          tBuffer[tPos1 + 2] = 0xFF;
          tBuffer[tPos1 + 3] = 0xFF;
          tPos1 += 4;
        }
      }

      Array.Resize(ref tBuffer, tBuffer.Length - 2 + 1);
      File.WriteAllBytes("C:/Test.zmap", tBuffer);
      return tBuffer;
    }

    private byte[] CompileSceneHeader() { // NEEDS MODULARITY
      return default;
    }

    private void LoadTemplate(string fn) {
      XmlReader TemplateParser = new XmlTextReader(fn);
      TemplateParser.Read();
      while (!TemplateParser.EOF) {
        TemplateParser.Read();
        if (!TemplateParser.IsStartElement()) {
          break;
        }
      }
    }

    private void SaveTemplateFile(string fn) {
      var TemplateParser = new XmlTextWriter(fn, System.Text.Encoding.UTF8);
      TemplateParser.WriteStartDocument();
      TemplateParser.WriteStartElement("UoT Level Template");
      TemplateParser.WriteElementString("Title", TemplateName);
      TemplateParser.WriteStartElement("OBJ Models");
      TemplateParser.WriteElementString("Graphics", objGraphicsFile);
      if (SeparateCollisionMap)
        TemplateParser.WriteElementString("Collision", objCollisionFile);
      else
        TemplateParser.WriteElementString("Collision", objGraphicsFile);
      TemplateParser.WriteEndElement();
      TemplateParser.WriteStartElement("Map Data"); // <Map Data>
      if (Counts.GrCount > 0) {
        TemplateParser.WriteStartElement("Groups"); // <Groups>
        for (int i = 0, loopTo = Counts.GrCount - 1; i <= loopTo; i++)
          TemplateParser.WriteElementString("group", Groups[i].val.ToString("X4")); // <group> data </group>
        TemplateParser.WriteEndElement(); // </Groups>
      }

      if (Counts.RmActorCount > 0) {
        TemplateParser.WriteStartElement("Actors"); // <Actors>
        for (int i = 0, loopTo1 = Counts.RmActorCount - 1; i <= loopTo1; i++) {
          TemplateParser.WriteStartElement("actor"); // <actor>
          TemplateParser.WriteElementString("xPos", RoomActors[i].x.ToString("X4"));
          TemplateParser.WriteElementString("yPos", RoomActors[i].y.ToString("X4"));
          TemplateParser.WriteElementString("zPos", RoomActors[i].z.ToString("X4"));
          TemplateParser.WriteElementString("xRot", RoomActors[i].xr.ToString("X4"));
          TemplateParser.WriteElementString("yRot", RoomActors[i].yr.ToString("X4"));
          TemplateParser.WriteElementString("zRot", RoomActors[i].zr.ToString("X4"));
          TemplateParser.WriteElementString("Number", RoomActors[i].no.ToString("X4"));
          TemplateParser.WriteElementString("Variable", RoomActors[i].var.ToString("X4"));
          TemplateParser.WriteEndElement(); // </actor>
        }

        TemplateParser.WriteEndElement(); // </Actors>
      }

      TemplateParser.WriteEndElement(); // </Map Data>


      // SCENE DATA


      TemplateParser.WriteStartElement("Scene Data"); // <Scene Data>
      if (Counts.ScActorCount > 0) {
        TemplateParser.WriteStartElement("Actors"); // <Actors>
        for (int i = 0, loopTo2 = Counts.ScActorCount - 1; i <= loopTo2; i++) {
          TemplateParser.WriteStartElement("scactor"); // <scactor>
          TemplateParser.WriteElementString("xPos", SceneActors[i].x.ToString("X4"));
          TemplateParser.WriteElementString("yPos", SceneActors[i].y.ToString("X4"));
          TemplateParser.WriteElementString("zPos", SceneActors[i].z.ToString("X4"));
          TemplateParser.WriteElementString("yRot", SceneActors[i].yr.ToString("X4"));
          TemplateParser.WriteElementString("Number", SceneActors[i].no.ToString("X4"));
          TemplateParser.WriteElementString("Variable", SceneActors[i].var.ToString("X4"));
          TemplateParser.WriteEndElement(); // </scactor>
        }

        TemplateParser.WriteEndElement(); // </Actors>
      }

      if (Counts.LinkCount > 0) {
        TemplateParser.WriteStartElement("Links"); // <Links>
        for (int i = 0, loopTo3 = Counts.LinkCount - 1; i <= loopTo3; i++) {
          TemplateParser.WriteStartElement("link"); // <link>
          TemplateParser.WriteElementString("xPos", LinkActors[i].x.ToString("X4"));
          TemplateParser.WriteElementString("yPos", LinkActors[i].y.ToString("X4"));
          TemplateParser.WriteElementString("zPos", LinkActors[i].z.ToString("X4"));
          TemplateParser.WriteElementString("xRot", LinkActors[i].xr.ToString("X4"));
          TemplateParser.WriteElementString("yRot", LinkActors[i].yr.ToString("X4"));
          TemplateParser.WriteElementString("zRot", LinkActors[i].zr.ToString("X4"));
          TemplateParser.WriteElementString("Number", LinkActors[i].no.ToString("X4"));
          TemplateParser.WriteElementString("Variable", LinkActors[i].var.ToString("X4"));
          TemplateParser.WriteEndElement(); // </link>
        }

        TemplateParser.WriteEndElement(); // </Links>
      }

      TemplateParser.WriteEndElement(); // </Scene Data>
      TemplateParser.WriteEndDocument();
      TemplateParser.Close();
    }

    private void OpenTemplate_FileOk(object sender, System.ComponentModel.CancelEventArgs e) {
      LoadTemplate(OpenTemplate.FileName);
    }

    private void SaveTemplate_FileOk(object sender, System.ComponentModel.CancelEventArgs e) {
      SaveTemplateFile(SaveTemplate.FileName);
    }

    private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e) {
      {
        var withBlock = Environment;
        switch (EchoLevelMenu.SelectedIndex) {
          case 0: {
              withBlock.EchoLevel = 0;
              break;
            }

          case 1: {
              withBlock.EchoLevel = 1;
              break;
            }

          case 2: {
              withBlock.EchoLevel = 4;
              break;
            }

          case 3: {
              withBlock.EchoLevel = 0xF;
              break;
            }
        }
      }
    }

    private void Button1_Click(object sender, EventArgs e) {
      OpenOBJGraphics.ShowDialog();
    }

    private void Button3_Click(object sender, EventArgs e) {
      OpenOBJCollision.ShowDialog();
    }

    private void OpenOBJGraphics_FileOk(object sender, System.ComponentModel.CancelEventArgs e) {
      objGraphicsFile = OpenOBJGraphics.FileName;
      GraphicsOBJ = GlobalVars.ParseOBJ.Parse(objGraphicsFile, false);
      OBJGraphicsText.Text = objGraphicsFile;
    }

    private void OpenOBJCollision_FileOk(object sender, System.ComponentModel.CancelEventArgs e) {
      objCollisionFile = OpenOBJCollision.FileName;
      CollisionOBJ = GlobalVars.ParseOBJ.Parse(objCollisionFile, true);
      ObjCollisionText.Text = objCollisionFile;
    }

    private void Button4_Click_1(object sender, EventArgs e) {
      RoomActors = new Actor[(int)(RoomActorCount.Value - 1m + 1)];
      Counts.RmActorCount = 0;
      if (RoomActorCount.Value > 0m)
        AddRoomActor(ref RoomActors, (int)RoomActorCount.Value);
      Groups = new Group[(int)(RoomGroupCount.Value - 1m + 1)];
      Counts.GrCount = 0;
      if (RoomGroupCount.Value > 0m)
        AddGroup(ref Groups, (int)RoomGroupCount.Value);
      MapBuff.RawHeader = CompileMapHeader();
      SceneActors = new Actor[(int)(SceneActorCount.Value - 1m + 1)];
      Counts.ScActorCount = 0;
      if (SceneActorCount.Value > 0m)
        AddSceneActor(ref SceneActors, (int)SceneActorCount.Value);
      LinkActors = new Actor[(int)(LinkActorCount.Value - 1m + 1)];
      Counts.LinkCount = 0;
      if (LinkActorCount.Value > 0m)
        AddLinkActor(ref LinkActors, (int)LinkActorCount.Value);

      // SceneBuff.RawHeader = compilesceneheader()

    }

    private void SaveToolStripMenuItem_Click(object sender, EventArgs e) {
      SaveTemplate.FileName = TemplateName + ".xml";
      SaveTemplate.ShowDialog();
    }

    private void TextBox5_TextChanged(object sender, EventArgs e) {
      TemplateName = LevelNameText.Text;
      Text = "UoT Level Creator Alpha - " + TemplateName;
    }

    private void OpenToolStripMenuItem_Click(object sender, EventArgs e) {
      OpenTemplate.ShowDialog();
    }

    private void AskToSave() {
      var SaveQuestion = Interaction.MsgBox("Would you like to save your current level template?", MsgBoxStyle.YesNo, "Save changes");
      if (SaveQuestion == MsgBoxResult.Yes) {
        SaveTemplate.ShowDialog();
      }
    }

    private void NewLevel() {
      RoomActorCount.Value = 0m;
      SceneActorCount.Value = 0m;
      RoomGroupCount.Value = 0m;
      LinkActorCount.Value = 0m;
      MapRawDataDisplay.Text = "";
      SceneRawDataDisplay.Text = "";
      EchoLevelMenu.SelectedIndex = 1;
      SkyboxToggle.Checked = true;
      LevelNameText.Text = "Untitled level";
      {
        var withBlock = Counts;
        withBlock.RmActorCount = 0;
        withBlock.ScActorCount = 0;
        withBlock.LinkCount = 0;
        withBlock.GrCount = 0;
      }

      CollisionVertices = new ColVert[0];
      CollisionPolies = new ColPoly[0];
      MapBuff.RawData = new byte[0];
      MapBuff.RawHeader = new byte[0];
      SceneBuff.RawData = new byte[0];
      SceneBuff.RawHeader = new byte[0];
      GraphicsOBJ = new OBJData.OBJModel();
      CollisionOBJ = new OBJData.OBJModel();
    }

    private void NewToolStripMenuItem_Click(object sender, EventArgs e) {
      AskToSave();
      NewLevel();
    }
  }
}