using System.Runtime.InteropServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace UoT {
  public class iniwriter {
    // API functions
    [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileStringA", CharSet = CharSet.Ansi)]

    private static extern int GetPrivateProfileString(ref string lpApplicationName, ref string lpKeyName, ref string lpDefault, System.Text.StringBuilder lpReturnedString, int nSize, ref string lpFileName);



    [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileStringA", CharSet = CharSet.Ansi)]

    private static extern int WritePrivateProfileString(ref string lpApplicationName, ref string lpKeyName, ref string lpString, ref string lpFileName);

    [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileIntA", CharSet = CharSet.Ansi)]

    private static extern int GetPrivateProfileInt(ref string lpApplicationName, ref string lpKeyName, int nDefault, ref string lpFileName);

    [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileStringA", CharSet = CharSet.Ansi)]

    private static extern int FlushPrivateProfileString(int lpApplicationName, int lpKeyName, int lpString, ref string lpFileName);


    private string strFilename;

    // Constructor, accepting a filename
    public iniwriter(string Filename) {
      strFilename = Filename;
    }

    // Read-only filename property
    public string FileName {
      get {
        return strFilename;
      }
    }

    public string GetString(string Section, string Key, string Default) {
      // Returns a string from your INI file
      int intCharCount;
      var objResult = new System.Text.StringBuilder(256);
      intCharCount = iniwriter.GetPrivateProfileString(ref Section, ref Key, ref Default, objResult, objResult.Capacity, ref strFilename);
      if (intCharCount > 0) {
        return Strings.Left(objResult.ToString(), intCharCount);
      } else {
        return "";
      }
    }

    public int GetInteger(string Section, string Key, int Default) {
      // Returns an integer from your INI file
      return iniwriter.GetPrivateProfileInt(ref Section, ref Key, Default, ref strFilename);
    }

    public bool GetBoolean(string Section, string Key, bool Default) {
      // Returns a boolean from your INI file
      return iniwriter.GetPrivateProfileInt(ref Section, ref Key, Conversions.ToInteger(Default), ref strFilename) == 1;
    }

    public void WriteString(string Section, string Key, string Value) {
      // Writes a string to your INI file
      iniwriter.WritePrivateProfileString(ref Section, ref Key, ref Value, ref strFilename);
      Flush();
    }

    public void WriteInteger(string Section, string Key, int Value) {
      // Writes an integer to your INI file
      WriteString(Section, Key, Value.ToString());
      Flush();
    }

    public void WriteBoolean(string Section, string Key, bool Value) {
      // Writes a boolean to your INI file
      WriteString(Section, Key, Conversions.ToInteger(Value).ToString());
      Flush();
    }

    private void Flush() {
      // Stores all the cached changes to your INI file
      iniwriter.FlushPrivateProfileString(0, 0, 0, ref strFilename);
    }
  }
}