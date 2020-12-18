
namespace UoT {
  static class _3ds {
    public enum MaxModel {
      MAIN3DS = 0x4D4D,

      // Main Chunks

      EDIT3DS = 0x3D3D,  // start of the editor config
      KEYF3DS = 0xB000,  // start of the keyframer config

      // sub defines of EDIT3DS

      EDIT_MATERIAL = 0xAFFF,
      EDIT_CONFIG1 = 0x100,
      EDIT_CONFIG2 = 0x3E3D,
      EDIT_VIEW_P1 = 0x7012,
      EDIT_VIEW_P2 = 0x7011,
      EDIT_VIEW_P3 = 0x7020,
      EDIT_VIEW1 = 0x7001,
      EDIT_BACKGR = 0x1200,
      EDIT_AMBIENT = 0x2100,
      EDIT_OBJECT = 0x4000,
      EDIT_UNKNW01 = 0x1100,
      EDIT_UNKNW02 = 0x1201,
      EDIT_UNKNW03 = 0x1300,
      EDIT_UNKNW04 = 0x1400,
      EDIT_UNKNW05 = 0x1420,
      EDIT_UNKNW06 = 0x1450,
      EDIT_UNKNW07 = 0x1500,
      EDIT_UNKNW08 = 0x2200,
      EDIT_UNKNW09 = 0x2201,
      EDIT_UNKNW10 = 0x2210,
      EDIT_UNKNW11 = 0x2300,
      EDIT_UNKNW12 = 0x2302,
      EDIT_UNKNW13 = 0x3000,
      EDIT_UNKNW14 = 0xAFFF,

      // sub defines of EDIT_OBJECT
      OBJ_TRIMESH = 0x4100,
      OBJ_LIGHT = 0x4600,
      OBJ_CAMERA = 0x4700,
      OBJ_UNKNWN01 = 0x4010,
      OBJ_UNKNWN02 = 0x4012, // Could be shadow

      // sub defines of OBJ_CAMERA
      CAM_UNKNWN01 = 0x4710,
      CAM_UNKNWN02 = 0x4720,

      // sub defines of OBJ_LIGHT
      LIT_OFF = 0x4620,
      LIT_SPOT = 0x4610,
      LIT_UNKNWN01 = 0x465A,

      // sub defines of OBJ_TRIMESH
      TRI_VERTEXL = 0x4110,
      TRI_FACEL2 = 0x4111,
      TRI_FACEL1 = 0x4120,
      TRI_SMOOTH = 0x4150,
      TRI_LOCAL = 0x4160,
      TRI_VISIBLE = 0x4165,

      // sub defs of KEYF3DS

      KEYF_UNKNWN01 = 0xB009,
      KEYF_UNKNWN02 = 0xB00A,
      KEYF_FRAMES = 0xB008,
      KEYF_OBJDES = 0xB002,

      // these define the different color chunk types
      COL_RGB = 0x10,
      COL_TRU = 0x11,
      COL_UNK = 0x13,

      // defines for viewport chunks

      TOP = 0x1,
      BOTTOM = 0x2,
      LEFT = 0x3,
      RIGHT = 0x4,
      FRONT = 0x5,
      BACK = 0x6,
      USER = 0x7,
      CAMERA = 0x8, // &hFFFF is the actual code read from file
      LIGHT = 0x9,
      DISABLED = 0x10,
      BOGUS = 0x11
    }
  }
}