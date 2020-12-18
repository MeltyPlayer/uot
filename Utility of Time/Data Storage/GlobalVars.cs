using System;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;

namespace UoT {
  static class GlobalVars {
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    private const double m_Pi = 3.1415926535897931d;

    public enum ZResTypes {
      Animation = 0,
      DList = 1,
      Texture = 2
    }

    public static string ExtraDataPrefix = @"\ext\";
    public static Structs.ActorDB[] ActorDataBase;
    /* TODO ERROR: Skipped EndRegionDirectiveTrivia *//* TODO ERROR: Skipped RegionDirectiveTrivia */
    public static int winh = 0;
    public static int winw = 0;
    public static int ogltop = 0;
    public static int oglleft;
    public static string DefROM = "";
    public static string[] args = new string[] { "" };
    public static string HighlightShader = "!!ARBfp1.0" + Environment.NewLine + "OUTPUT FinalColor = result.color;" + Environment.NewLine + "MOV FinalColor, {1.0,0.0,0.0,0.3};" + Environment.NewLine + "END";


    public static int HighlightProg;
    public static int envlightoff = 0;
    public static double CamXPos = 0d;
    public static double CamYPos = 0d;
    public static double CamZPos = 0d;
    public static int objectset = 0;
    public static bool OnSceneActor = false;
    public static int ActorType = 0;
    public static bool sceneused = false;
    public static int envboxoff = 0;
    public static Keys[] HotKeys;
    /* TODO ERROR: Skipped EndRegionDirectiveTrivia *//* TODO ERROR: Skipped RegionDirectiveTrivia */
    public static ArrayList SelectedRoomActors = new ArrayList();
    public static ArrayList SelectedSceneActors = new ArrayList();
    public static ArrayList actornp = new ArrayList();
    public static ArrayList actorvp = new ArrayList();
    public static ArrayList actorgp = new ArrayList();
    public static ArrayList actornpu = new ArrayList();
    public static ArrayList actorvpu = new ArrayList();
    public static ArrayList actorgpu = new ArrayList();
    public static uint sceneobjset = 0U;
    /* TODO ERROR: Skipped EndRegionDirectiveTrivia *//* TODO ERROR: Skipped RegionDirectiveTrivia */
    public static ArrayList ActorGroups = new ArrayList();
    public static object ActorGroupOffset;
    /* TODO ERROR: Skipped EndRegionDirectiveTrivia *//* TODO ERROR: Skipped RegionDirectiveTrivia */
    public static Structs.PickedItems PickedEntities = new Structs.PickedItems();
    public static int CurrentBank = 0;
    public static byte[] ZFileBuffer;
    public static byte[] ExternalHierarchy;
    public static byte[] ExternalAnimBank;
    public static byte[] ZSceneBuffer;
    public static Structs.ObjectExchange CommonBanks = new Structs.ObjectExchange();
    public static Structs.BankSwitch CommonBankUse = new Structs.BankSwitch();
    public static Structs.N64DisplayList[] N64DList = new Structs.N64DisplayList[0];
    public static Structs.RendererOptions RenderToggles = new Structs.RendererOptions();
    public static Structs.OpenGLExtensions GLExtensions = new Structs.OpenGLExtensions();
    public static Structs.WOGLExtensions WGLExtensions = new Structs.WOGLExtensions();
    public static ZAnimation AnimParser = new ZAnimation();
    public static F3DEX2_Parser DLParser = new F3DEX2_Parser();
    public static N64DlistAssembler CompileDL = new N64DlistAssembler();
    public static OBJParser ParseOBJ = new OBJParser();
    public static Structs.DLEdit LinkedCommands = new Structs.DLEdit();
    public static Structs.FrameAdvancer ZAnimationCounter = new Structs.FrameAdvancer();
    public static Random Rand = new Random();
    public static SLERP Interpolate = new SLERP();
    public static Stopwatch AnimationStopWatch = new Stopwatch();
    public static Structs.N64Vertex AllVertices = new Structs.N64Vertex();
    /* TODO ERROR: Skipped EndRegionDirectiveTrivia *//* TODO ERROR: Skipped RegionDirectiveTrivia */
    public static TextureUpscaler.RGBA RGBA = new TextureUpscaler.RGBA();
    public static TextureUpscaler.CI CI = new TextureUpscaler.CI();
    public static TextureUpscaler.IA IA = new TextureUpscaler.IA();
    public static TextureUpscaler.I I = new TextureUpscaler.I();
    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
  }
}