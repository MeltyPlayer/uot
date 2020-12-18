using System;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Tao.DevIl;

namespace UoT {
  public class OBJParser {
    public OBJData.OBJModel Parse(string fn, bool SkipMtl) {
      try {
        if (File.Exists(fn)) {
          Il.ilInit();
          var tempObj = new OBJData.OBJModel();
          tempObj.Parts = new OBJData.OBJGroup[0];
          tempObj.Vertices = new OBJData.OBJVert[0];
          tempObj.TexCoords = new OBJData.OBJUV[0];
          tempObj.Normals = new OBJData.OBJNormal[0];
          var objText = new StreamReader(fn);
          string CurLine = "";
          string[] CurTokens;
          string CurMtlLine = "";
          string[] CurMtlTokens;
          int vCnt = 0;
          int vtCnt = 0;
          int fCnt = 0;
          int mtlCnt = 0;
          int mtlFileCnt = 0;
          int texCnt = 0;
          int grpCnt = 0;
          var fSplit = new char[] { ' ', '/' };
          while (objText.Peek() != -1) {
            CurLine = objText.ReadLine();
            CurTokens = CurLine.Split(' ');
            switch (CurTokens[0] ?? "") {
              case var @case when CultureInfo.CurrentCulture.CompareInfo.Compare(@case, "v", CompareOptions.IgnoreCase | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth) == 0: {
                  Array.Resize(ref tempObj.Vertices, vCnt + 1);
                  {
                    var withBlock = tempObj.Vertices[vCnt];
                    withBlock.x = (short)Conversions.ToDouble(CurTokens[1]);
                    withBlock.y = (short)Conversions.ToDouble(CurTokens[2]);
                    withBlock.z = (short)Conversions.ToDouble(CurTokens[3]);
                  }

                  vCnt += 1;
                  break;
                }

              case var case1 when CultureInfo.CurrentCulture.CompareInfo.Compare(case1, "vt", CompareOptions.IgnoreCase | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth) == 0: {
                  Array.Resize(ref tempObj.TexCoords, vtCnt + 1);
                  {
                    var withBlock1 = tempObj.TexCoords[vtCnt];
                    withBlock1.s = (short)Conversions.ToDouble(CurTokens[1]);
                    withBlock1.t = (short)Conversions.ToDouble(CurTokens[2]);
                  }

                  vtCnt += 1;
                  break;
                }

              case var case2 when CultureInfo.CurrentCulture.CompareInfo.Compare(case2, "g", CompareOptions.IgnoreCase | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth) == 0: {
                  grpCnt += 1;
                  Array.Resize(ref tempObj.Parts, grpCnt + 1);
                  tempObj.Parts[grpCnt].grpId = CurTokens[1];
                  break;
                }

              case var case3 when CultureInfo.CurrentCulture.CompareInfo.Compare(case3, "f", CompareOptions.IgnoreCase | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth) == 0: {
                  Array.Resize(ref tempObj.Parts[grpCnt].Faces, fCnt + 1);
                  {
                    var withBlock2 = tempObj.Parts[grpCnt].Faces[fCnt];
                    if (CurTokens[1].Contains("/")) {
                      CurTokens = CurLine.Split(fSplit);
                      switch (CurTokens.Length) {
                        case 7: { // tex coords
                            withBlock2.V1 = Conversions.ToInteger(CurTokens[1]);
                            withBlock2.V2 = Conversions.ToInteger(CurTokens[3]);
                            withBlock2.V3 = Conversions.ToInteger(CurTokens[5]);
                            withBlock2.uV1 = Conversions.ToInteger(CurTokens[2]);
                            withBlock2.uV2 = Conversions.ToInteger(CurTokens[4]);
                            withBlock2.uV3 = Conversions.ToInteger(CurTokens[6]);
                            break;
                          }

                        case 10: { // tex coords + normals
                            withBlock2.V1 = Conversions.ToInteger(CurTokens[1]);
                            withBlock2.V2 = Conversions.ToInteger(CurTokens[4]);
                            withBlock2.V3 = Conversions.ToInteger(CurTokens[7]);
                            withBlock2.uV1 = Conversions.ToInteger(CurTokens[2]);
                            withBlock2.uV2 = Conversions.ToInteger(CurTokens[5]);
                            withBlock2.uV3 = Conversions.ToInteger(CurTokens[8]);
                            withBlock2.nV1 = Conversions.ToInteger(CurTokens[3]);
                            withBlock2.nV2 = Conversions.ToInteger(CurTokens[6]);
                            withBlock2.nV3 = Conversions.ToInteger(CurTokens[9]);
                            break;
                          }
                      }
                    } else { // just geometry
                      withBlock2.uV1 = Conversions.ToInteger(CurTokens[1]);
                      withBlock2.uV2 = Conversions.ToInteger(CurTokens[2]);
                      withBlock2.uV3 = Conversions.ToInteger(CurTokens[3]);
                    }
                  }

                  fCnt += 1;
                  break;
                }

              case var case4 when CultureInfo.CurrentCulture.CompareInfo.Compare(case4, "mtllib", CompareOptions.IgnoreCase | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth) == 0: {
                  if (!SkipMtl) {
                    tempObj.mtlFile = new StreamReader(Functions.GetDir(fn) + @"\" + CurTokens[1]);
                    mtlFileCnt += 1;
                  }

                  break;
                }

              case var case5 when CultureInfo.CurrentCulture.CompareInfo.Compare(case5, "usemtl", CompareOptions.IgnoreCase | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth) == 0: {
                  if (!SkipMtl) {
                    if (tempObj.mtlFile is object) {
                      while (tempObj.mtlFile.Peek() != -1) {
                        CurMtlLine = tempObj.mtlFile.ReadLine();
                        CurMtlTokens = CurMtlLine.Split(' ');
                        switch (CurMtlTokens[0] ?? "") {
                          case var case6 when CultureInfo.CurrentCulture.CompareInfo.Compare(case6, "newmtl", CompareOptions.IgnoreCase | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth) == 0: {
                              Array.Resize(ref tempObj.Parts[grpCnt].Materials, mtlCnt + 1);
                              {
                                var withBlock3 = tempObj.Parts[grpCnt].Materials[mtlCnt];
                                withBlock3.mtlId = CurMtlTokens[1];
                              }

                              mtlCnt += 1;
                              break;
                            }

                          case var case7 when CultureInfo.CurrentCulture.CompareInfo.Compare(case7, "map_Ka", CompareOptions.IgnoreCase | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth) == 0: {
                              {
                                var withBlock4 = tempObj.Parts[grpCnt].Materials[mtlCnt - 1];
                                withBlock4.texFile = Functions.GetDir(fn) + @"\" + CurMtlTokens[1];
                                if (!File.Exists(withBlock4.texFile)) {
                                  Interaction.MsgBox("Couldn't find material texture " + CurMtlTokens[1] + ". It should be in the same directory as the obj file.");
                                  break;
                                }

                                Array.Resize(ref withBlock4.Textures, texCnt + 1);
                                IntPtr texData = (IntPtr)0;
                                int tImg = 0;
                                tImg = Il.ilGenImage();
                                Il.ilBindImage(tImg);
                                Il.ilLoad(Il.IL_PNG, withBlock4.texFile);
                                texData = Il.ilGetData();
                                Il.ilConvertImage(Il.IL_RGBA, Il.IL_UNSIGNED_BYTE);
                                {
                                  var withBlock5 = withBlock4.Textures[texCnt];
                                  withBlock5.width = (int)Functions.Pow2((ulong)Il.ilGetInteger(Il.IL_IMAGE_WIDTH));
                                  withBlock5.height = (int)Functions.Pow2((ulong)Il.ilGetInteger(Il.IL_IMAGE_HEIGHT));
                                  withBlock5.bpp = Il.ilGetInteger(Il.IL_IMAGE_BPP);
                                  withBlock5.Data = new byte[(withBlock5.width * withBlock5.height * 4)];
                                  Marshal.Copy(texData, withBlock5.Data, 0, withBlock5.Data.Length - 1);
                                }

                                Il.ilDeleteImage(tImg);
                              }

                              texCnt += 1;
                              break;
                            }
                        }
                      }
                    }
                  }

                  break;
                }
            }
          }

          return tempObj;
        } else {
          Interaction.MsgBox("Could not find Wavefrong OBJ file " + fn + "!");
        }
      } catch (Exception ex) {
        Interaction.MsgBox("Error encountered in OBJ Parser." + Environment.NewLine + Environment.NewLine + "Details: " + ex.Message, MsgBoxStyle.Critical, "Error while parsing obj model!");
        return default;
      }

      return default;
    }
  }
}