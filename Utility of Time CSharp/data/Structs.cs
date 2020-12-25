﻿using System.Collections;

namespace UoT {
  /* TODO ERROR: Skipped RegionDirectiveTrivia */
  public struct Color3UByte {
    public byte r;
    public byte g;
    public byte b;
  }

  public struct Color4UByte {
    public byte r;
    public byte g;
    public byte b;
    public byte a;
  }

  public struct RendererOptions {
    public bool Textures;
    public bool ColorCombiner;
    public bool AntiAliasing;
    public bool Anisotropic;
  }

  public struct BankSwitch {
    public int Bank04;
    public int Bank05;
    public int AnimBank;
  }

  public enum UseBank {
    Inline = -1,
    Item0 = 0,
    Item1 = 1,
    Item2 = 2,
    Item3 = 3
  }
  /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
  /* TODO ERROR: Skipped RegionDirectiveTrivia */
  public struct Limb {
    public double r;
    public double g;
    public double b;
    public short x;
    public short y;
    public short z;
    public sbyte firstChild;
    public sbyte nextSibling;
    public uint DisplayList;
    public uint DisplayListLow;
  }

  public struct FrameAdvancer {
    public bool Advancing;
    public uint FrameNo;
    public uint CurrFrame;
    public double Frames;
    public double CurrentTime;
    public double LastUpdateTime;
    public double ElapsedSeconds;
    public double ElapsedMilliseconds;
    public double DeltaTime;
    public double FramesAdvanced;
    public int FramesAdvancedInt;
    public double FrameDelta;
    public double FPS;
  }
  /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
  /* TODO ERROR: Skipped RegionDirectiveTrivia */
  public struct Rooms {
    public int startoff;
    public int endoff;
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
    public uint offset;
    public byte pickR;
    public byte pickG;
    public byte pickB;
    public bool picked;
    public string ident;
    public N64DisplayList[] DisplayLists;
  }

  public struct MapOffset {
    public uint StartOff;
    public uint EndOff;
  }

  public struct Door {
    public short x;
    public short y;
    public short z;
    public short yr;
    public uint no;
    public uint var;
    public uint offset;
    public byte loadMapFront;
    public byte loadMapBack;
    public byte pickR;
    public byte pickG;
    public byte pickB;
  }

  public struct Exits {
    public uint Index;
    public uint scOff;
  }

  public struct CollisionTriColorSelect {
    public short g;
    public short b;
  }

  public struct CollisionTypes {
    public uint scOff;
    public uint unk1;
    public uint unk2;
    public uint unk3;
    public uint unk4;
    public byte WalkOnSound;
  }

  public struct CollisionTypePresets {
    public string Data;
    public string Description;
    public string Index;
    public string Type;
  }

  public struct CollisionVertex {
    public ArrayList x;
    public ArrayList y;
    public ArrayList z;
    public ArrayList VertR;
    public ArrayList VertG;
    public ArrayList VertB;
    public ArrayList EdgeR;
    public ArrayList EdgeG;
    public ArrayList EdgeB;
    public ArrayList FaceR;
    public ArrayList FaceG;
    public ArrayList FaceB;
  }

  public struct PolygonCollision {
    public uint scOff;
    public int Param;
    public int A;
    public int B;
    public int C;
    public short nX;
    public short nY;
    public short nZ;
    public byte pickR;
    public byte pickG;
    public byte pickB;
  }
  /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
  /* TODO ERROR: Skipped RegionDirectiveTrivia */
  public struct N64Vertex {
    public short[] x;
    public short[] y;
    public short[] z;
    public short[] u;
    public short[] v;
    public byte[] r;
    public byte[] g;
    public byte[] b;
    public byte[] a;
  }
  /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
  /* TODO ERROR: Skipped RegionDirectiveTrivia */
  public struct ActorTbl {
    public uint Startoff;
    public uint Endoff;
    public uint StartVoff;
    public uint EndVoff;
  }

  public struct ObjectTbl {
    public uint Startoff;
    public uint Endoff;
  }
  /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
  /* TODO ERROR: Skipped RegionDirectiveTrivia */
  public enum FileTypes {
    MAP = 1,
    ACTORMODEL = 0,
    ACTORCODE = 2
  }

  public struct ObjectExchange {
    public Bank04 Bank4;
    public Bank05 Bank5;
    public AnimBank Anims;
  }

  public struct Bank04 {
    public BankBuffers[] Banks;
  }

  public struct Bank05 {
    public BankBuffers[] Banks;
  }

  public struct AnimBank {
    public BankBuffers[] Banks;
  }

  public struct BankBuffers {
    public string Name;
    public uint StartOffset;
    public uint EndOffset;
    public byte[] Data;
  }

  public struct ZFileTypes {
    public ZSc[] Levels;
    public ZObj[] Objects;
    public ZCodeFiles[] ActorCode;
    public ZOtherData[] Others;
  }

  public struct ZSeg {
    public uint Offset;
    public byte Bank;

    public object getSegment(byte[] data, uint index) {
      Bank = data[(int)index];
      Offset = IoUtil.ReadUInt24(data, (uint)(index + 1L));
      return default;
    }
  }

  public struct ZMap {
    public int startoff;
    public int endoff;
    public string filename;
  }

  public struct ZSc {
    public int startoff;
    public int endoff;
    public string filename;
    public ZMap[] Maps;
  }

  public struct ZObj {
    public int startoff;
    public int endoff;
    public string filename;
    public string betterFilename;
  }

  public struct ZCodeFiles {
    public int startoff;
    public int endoff;
    public string filename;
  }

  public struct ZOtherData {
    public int startoff;
    public int endoff;
    public string filename;
  }

  public struct FileBuffers {
    public byte[] Level;
    public byte[] Map;
    public byte[] ActorModel;
  }

  public struct ZSegment {
    public byte Bank;
    public uint Offset;
  }
  /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
  /* TODO ERROR: Skipped RegionDirectiveTrivia */
  public enum UCodes {
    RDP = 0,
    F3DEX = 1,
    F3DEX2 = 2
  }

  public struct DLCommand {
    public byte[] CMDParams;
    public uint CMDHigh;
    public uint CMDLow;
    public string Name;
    public int DLPos;
  }

  public struct N64DisplayList {
    public bool Skip;
    public bool Highlight;
    public Color3UByte PickCol;
    public ZSegment StartPos;
    public ZSegment EndPos;
    public int CommandCount;
    public DLCommand[] Commands;
    public DLCommand[] CommandsCopy;
  }

  public struct ZCamera {
    public short x;
    public short y;
    public short z;
  }

  public struct OGLDisplayList {
    public int MainDL;
    public int HighlighterDL;
    public int PickableDL;
    public byte PickR;
    public byte PickG;
    public byte PickB;
    public int N64Offset;
    public bool Highlight;
    public bool Skip;
  }

  public struct GeometryAvgPos {
    public short xAvg;
    public short yAvg;
    public short zAvg;
  }

  public struct ShaderCache {
    public uint MUXS0;
    public uint MUXS1;
    public string[] Equation;
    public uint FragShader;
  }

  /* TODO ERROR: Skipped RegionDirectiveTrivia */
  public struct UnpackedCombiner {
    public uint[] cA;
    public uint[] cB;
    public uint[] cC;
    public uint[] cD;
    public uint[] aA;
    public uint[] aB;
    public uint[] aC;
    public uint[] aD;
  }

  public struct UnpackedGeometryMode {
    public bool ZBUFFER;
    public bool CULLBACK;
    public bool CULLFRONT;
    public bool FOG;
    public bool LIGHTING;
    public bool TEXTUREGEN;
    public bool TEXTUREGENLINEAR;
    public bool SHADINGSMOOTH;
  }

  public struct UnpackedVtxLoad {
    public uint Count;
    public ZSegment Offset;
    public uint Length;
    public uint n0;
    public uint v0;
  }

  public struct UnpackedOtherModesL {
    public bool AAEN;
    public bool ZCMP;
    public bool ZUPD;
    public bool IMRD;
    public bool CLRONCVG;
    public bool CVGDSTWRAP;
    public bool CVGDSTFULL;
    public bool CVGDSTSAVE;
    public bool ZMODEINTER;
    public bool ZMODEXLU;
    public bool ZMODEDEC;
    public bool CVGXALPHA;
    public bool ALPHACVGSEL;
    public bool FORCEBL;
    public byte MDSFT;
  }

  public struct UnpackedTriangle {
    public bool TRI2;
    public byte VertA;
    public byte VertB;
    public byte VertC;
    public byte _VertA;
    public byte _VertB;
    public byte _VertC;
  }
  /* TODO ERROR: Skipped EndRegionDirectiveTrivia *//* TODO ERROR: Skipped EndRegionDirectiveTrivia */
  /* TODO ERROR: Skipped RegionDirectiveTrivia */
  public struct Tools {
    public int CurrentTool;
    public int SelectedItemType;
    public int Axis;
    public string AxisDisp;
    public string ToolDisp;
    public bool NoDepthTest;
  }

  public struct DLEdit {
    public DLCommand PrimColor;
    public DLCommand EnvColor;
  }

  public struct PickableItems {
    public byte r;
    public byte g;
    public byte b;
    public byte a;
  }

  public struct PickedItems {
    public PickableItems[] CollisionTriangles;
    public PickableItems[] CollisionVertices;
    public PickableItems[] GraphicsVertices;
    public PickableItems[] RoomActors;
    public PickableItems[] SceneActors;
    public PickableItems[] LinkActors;
  }

  public struct ActorDB {
    public string desc;
    public uint no;

    public struct variable {
      public uint var;
      public string desc;
    }

    public variable[] var;
    public uint grp;
  }
  /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
}