using System.Collections;
using System.Collections.Generic;

namespace UoT {
  public static partial class Structs {

    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public class Color3UByte {
      public byte r;
      public byte g;
      public byte b;
    }

    public class Color4UByte {
      public byte r;
      public byte g;
      public byte b;
      public byte a;
    }

    public class OpenGLExtensions {
      public bool GLMultiTexture;
      public bool GLFragProg;
      public bool GLAnisotropic;
      public bool GLMultiSample;
      public bool GLSL;
      public float[] AnisotropicSamples;
    }

    public class WOGLExtensions {
      public bool WGLMultiSample;
      public float[] MultiSampleLevels;
    }

    public class RendererOptions {
      public bool Textures;
      public bool ColorCombiner;
      public bool AntiAliasing;
      public bool Anisotropic;
    }

    public class BankSwitch {
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
    public class Limb {
      public double r;
      public double g;
      public double b;
      public short x;
      public short y;
      public short z;
      public sbyte c0;
      public sbyte c1;
      public uint DisplayList;
      public uint DisplayListLow;
    }

    public class AnimTrackIndex {
      public uint XRot;
      public uint YRot;
      public uint ZRot;
    }

    public class AnimTrack {
      public short[] Frames;
      public int Type; // 0 = constant, 1 = keyframe
    }

    public class Animation {
      public short[] Angles;
      public AnimTrack[] Tracks;
      public uint XTrans;
      public uint YTrans;
      public uint ZTrans;
      public uint FrameOffset;
      public uint TrackOffset;
      public uint FrameCount;
      public uint AngleCount;
      public uint TrackCount;
      public int ConstTrackCount;
    }

    public class FrameAdvancer {
      public bool Advancing;
      public uint FrameNo;
      public uint CurrFrame;
      public float Frames;
      public float CurrentTime;
      public float LastUpdateTime;
      public float ElapsedSeconds;
      public float ElapsedMilliseconds;
      public float DeltaTime;
      public float FramesAdvanced;
      public int FramesAdvancedInt;
      public float FrameDelta;
      public float FPS;
    }
    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public class Rooms {
      public int startoff;
      public int endoff;
    }

    public class Actor {
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

    public class MapOffset {
      public uint StartOff;
      public uint EndOff;
    }

    public class Door {
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

    public class Exits {
      public uint Index;
      public uint scOff;
    }

    public class CollisionTriColorSelect {
      public short g;
      public short b;
    }

    public class CollisionTypes {
      public uint scOff;
      public uint unk1;
      public uint unk2;
      public uint unk3;
      public uint unk4;
      public byte WalkOnSound;
    }

    public class CollisionTypePresets {
      public string Data;
      public string Description;
      public string Index;
      public string Type;
    }

    public class CollisionVertex {
      public IList<double> x;
      public IList<double> y;
      public IList<double> z;
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

    public class PolygonCollision {
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
    public class N64Vertex {
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
    public class ActorTbl {
      public uint Startoff;
      public uint Endoff;
      public uint StartVoff;
      public uint EndVoff;
    }

    public class ObjectTbl {
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

    public class ObjectExchange {
      public readonly Bank04 Bank4 = new Bank04();
      public readonly Bank05 Bank5 = new Bank05();
      public readonly AnimBank Anims = new AnimBank();
    }

    public class Bank04 {
      public readonly IList<BankBuffers> Banks = new List<BankBuffers>();
    }

    public class Bank05 {
      public readonly IList<BankBuffers> Banks = new List<BankBuffers>();
    }

    public class AnimBank {
      public readonly IList<BankBuffers> Banks = new List<BankBuffers>();
    }

    public class BankBuffers {
      public string Name;
      public uint StartOffset;
      public uint EndOffset;
      public byte[] Data;
    }

    public class ZFileTypes {
      public readonly IList<ZSc> Levels = new List<ZSc>();
      public readonly IList<ZObj> Objects = new List<ZObj>();
      public readonly IList<ZCodeFiles> ActorCode = new List<ZCodeFiles>();
      public readonly IList<ZOtherData> Others = new List<ZOtherData>();
    }

    public class ZSeg {
      public uint Offset;
      public byte Bank;

      public object getSegment(byte[] data, uint index) {
        Bank = data[(int)index];
        Offset = Functions.ReadUInt24(data, (uint)(index + 1L));
        return default;
      }
    }

    public class ZMap {
      public int startoff;
      public int endoff;
      public string filename;
    }

    public class ZSc {
      public int startoff;
      public int endoff;
      public string filename;
      public readonly IList<ZMap> Maps = new List<ZMap>();
    }

    public class ZObj {
      public int startoff;
      public int endoff;
      public string filename;
    }

    public class ZCodeFiles {
      public int startoff;
      public int endoff;
      public string filename;
    }

    public class ZOtherData {
      public int startoff;
      public int endoff;
      public string filename;
    }

    public class FileBuffers {
      public byte[] Level;
      public byte[] Map;
      public byte[] ActorModel;
    }

    public class ZSegment {
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

    public class DLCommand {
      public byte[] CMDParams;
      public uint CMDHigh;
      public uint CMDLow;
      public string Name;
      public int DLPos;
    }

    public class N64DisplayList {
      public bool Skip;
      public bool Highlight;
      public Color3UByte PickCol;
      public ZSegment StartPos;
      public ZSegment EndPos;
      public int CommandCount;
      public DLCommand[] Commands;
      public DLCommand[] CommandsCopy;
    }

    public class ZCamera {
      public short x;
      public short y;
      public short z;
    }

    public class OGLDisplayList {
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

    public class GeometryAvgPos {
      public short xAvg;
      public short yAvg;
      public short zAvg;
    }

    public class ShaderCache {
      public uint MUXS0;
      public uint MUXS1;
      public string[] Equation;
      public uint FragShader;
    }

    public class TCache {
      public Texture Texture;
    }
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public class UnpackedCombiner {
      public uint[] cA;
      public uint[] cB;
      public uint[] cC;
      public uint[] cD;
      public uint[] aA;
      public uint[] aB;
      public uint[] aC;
      public uint[] aD;
    }

    public class UnpackedGeometryMode {
      public bool ZBUFFER;
      public bool CULLBACK;
      public bool CULLFRONT;
      public bool FOG;
      public bool LIGHTING;
      public bool TEXTUREGEN;
      public bool TEXTUREGENLINEAR;
      public bool SHADINGSMOOTH;
    }

    public class UnpackedVtxLoad {
      public uint Count;
      public ZSegment Offset;
      public uint Length;
      public uint n0;
      public uint v0;
    }

    public class UnpackedOtherModesL {
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

    public class UnpackedTriangle {
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
    public class Tools {
      public int CurrentTool;
      public int SelectedItemType;
      public int Axis;
      public string AxisDisp;
      public string ToolDisp;
      public bool NoDepthTest;
    }

    public class DLEdit {
      public DLCommand PrimColor;
      public DLCommand EnvColor;
    }

    public class PickableItems {
      public byte r;
      public byte g;
      public byte b;
      public byte a;
    }

    public class PickedItems {
      public PickableItems[] CollisionTriangles;
      public PickableItems[] CollisionVertices;
      public PickableItems[] GraphicsVertices;
      public PickableItems[] RoomActors;
      public PickableItems[] SceneActors;
      public PickableItems[] LinkActors;
    }

    public class ActorDB {
      public string desc;
      public uint no;

      public class variable {
        public uint var;
        public string desc;
      }

      public variable[] var;
      public uint grp;
    }
    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
  }
}