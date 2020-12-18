using System;
using System.Windows.Forms;

namespace UoT {
  public partial class CombinerEditor {
    public CombinerEditor() {
      InitializeComponent();
      _cA0.Name = "cA0";
      _cB0.Name = "cB0";
      _cC0.Name = "cC0";
      _cD0.Name = "cD0";
      _cD1.Name = "cD1";
      _cC1.Name = "cC1";
      _cB1.Name = "cB1";
      _cA1.Name = "cA1";
      _aD0.Name = "aD0";
      _aC0.Name = "aC0";
      _aB0.Name = "aB0";
      _aA0.Name = "aA0";
      _aD1.Name = "aD1";
      _aC1.Name = "aC1";
      _aB1.Name = "aB1";
      _aA1.Name = "aA1";
      _CompiledCmbCmd.Name = "CompiledCmbCmd";
      _PrimR.Name = "PrimR";
    }

    private Structs.UnpackedCombiner CombinerColors;
    private Structs.UnpackedCombiner CombinerColorsCopy;
    private Structs.DLCommand CompiledCmb = new Structs.DLCommand();

    private void Decode(uint MUXS0, uint MUXS1) {
      GlobalVars.DLParser.UnpackMUX(MUXS0, MUXS1, ref CombinerColors);
      {
        var withBlock = CombinerColors;
        cA0.SelectedIndex = (int)withBlock.cA[0];
        cA1.SelectedIndex = (int)withBlock.cA[1];
        cB0.SelectedIndex = (int)withBlock.cB[0];
        cB1.SelectedIndex = (int)withBlock.cB[1];
        cC0.SelectedIndex = (int)withBlock.cC[0];
        cC1.SelectedIndex = (int)withBlock.cC[1];
        cD0.SelectedIndex = (int)withBlock.cD[0];
        cD1.SelectedIndex = (int)withBlock.cD[1];
        aA0.SelectedIndex = (int)withBlock.aA[0];
        aA1.SelectedIndex = (int)withBlock.aA[1];
        aB0.SelectedIndex = (int)withBlock.aB[0];
        aB1.SelectedIndex = (int)withBlock.aB[1];
        aC0.SelectedIndex = (int)withBlock.aC[0];
        aC1.SelectedIndex = (int)withBlock.aC[1];
        aD0.SelectedIndex = (int)withBlock.aD[0];
        aD1.SelectedIndex = (int)withBlock.aD[1];
      }
    }

    private void UpdateEnvColor(Structs.DLCommand Cmd) {
      if (Cmd.CMDHigh > 0L) {
        var tempEnv = new Structs.Color4UByte();
        tempEnv.r = Cmd.CMDParams[4];
        tempEnv.g = Cmd.CMDParams[5];
        tempEnv.b = Cmd.CMDParams[6];
        tempEnv.a = 0xFF;
        EnvR.BackColor = Functions.RGBA8ColorToColorObject(tempEnv);
        tempEnv.r = 0xFF;
        tempEnv.g = 0xFF;
        tempEnv.b = 0xFF;
        tempEnv.a = Cmd.CMDParams[7];
        EnvA.BackColor = Functions.RGBA8ColorToColorObject(tempEnv);
        EnvR.Enabled = true;
        EnvA.Enabled = true;
      } else {
        EnvR.Enabled = false;
        EnvA.Enabled = false;
      }
    }

    private void UpdatePrimColor(Structs.DLCommand Cmd) {
      if (Cmd.CMDHigh > 0L) {
        var tempPrim = new Structs.Color4UByte();
        tempPrim.r = Cmd.CMDParams[4];
        tempPrim.g = Cmd.CMDParams[5];
        tempPrim.b = Cmd.CMDParams[6];
        tempPrim.a = 0xFF;
        PrimR.BackColor = Functions.RGBA8ColorToColorObject(tempPrim);
        tempPrim.r = 0xFF;
        tempPrim.g = 0xFF;
        tempPrim.b = 0xFF;
        tempPrim.a = Cmd.CMDParams[7];
        PrimA.BackColor = Functions.RGBA8ColorToColorObject(tempPrim);
        PrimA.Enabled = true;
        PrimR.Enabled = true;
      } else {
        PrimA.Enabled = false;
        PrimR.Enabled = false;
      }
    }

    private void Dialog1_Load(object sender, EventArgs e) {
      for (int i = 0, loopTo = RDP_Defs.ColorAStr.Length - 1; i <= loopTo; i++) {
        cA0.Items.Add(RDP_Defs.ColorAStr[i]);
        cA1.Items.Add(RDP_Defs.ColorAStr[i]);
      }

      for (int i = 0, loopTo1 = RDP_Defs.ColorBStr.Length - 1; i <= loopTo1; i++) {
        cB0.Items.Add(RDP_Defs.ColorBStr[i]);
        cB1.Items.Add(RDP_Defs.ColorBStr[i]);
      }

      for (int i = 0, loopTo2 = RDP_Defs.ColorCStr.Length - 1; i <= loopTo2; i++) {
        cC0.Items.Add(RDP_Defs.ColorCStr[i]);
        cC1.Items.Add(RDP_Defs.ColorCStr[i]);
      }

      for (int i = 0, loopTo3 = RDP_Defs.ColorDStr.Length - 1; i <= loopTo3; i++) {
        cD0.Items.Add(RDP_Defs.ColorDStr[i]);
        cD1.Items.Add(RDP_Defs.ColorDStr[i]);
      }

      for (int i = 0, loopTo4 = RDP_Defs.AlphaAStr.Length - 1; i <= loopTo4; i++) {
        aA0.Items.Add(RDP_Defs.AlphaAStr[i]);
        aA1.Items.Add(RDP_Defs.AlphaAStr[i]);
      }

      for (int i = 0, loopTo5 = RDP_Defs.AlphaBStr.Length - 1; i <= loopTo5; i++) {
        aB0.Items.Add(RDP_Defs.AlphaBStr[i]);
        aB1.Items.Add(RDP_Defs.AlphaBStr[i]);
      }

      for (int i = 0, loopTo6 = RDP_Defs.AlphaCStr.Length - 1; i <= loopTo6; i++) {
        aC0.Items.Add(RDP_Defs.AlphaCStr[i]);
        aC1.Items.Add(RDP_Defs.AlphaCStr[i]);
      }

      for (int i = 0, loopTo7 = RDP_Defs.AlphaDStr.Length - 1; i <= loopTo7; i++) {
        aD0.Items.Add(RDP_Defs.AlphaDStr[i]);
        aD1.Items.Add(RDP_Defs.AlphaDStr[i]);
      }

      UpdateEnvColor(GlobalVars.LinkedCommands.EnvColor);
      UpdatePrimColor(GlobalVars.LinkedCommands.PrimColor);
      Decode(Convert.ToUInt32(My.MyProject.Forms.MainWin.LowordText.Text, 16), Convert.ToUInt32(My.MyProject.Forms.MainWin.HiwordText.Text, 16));
    }

    private void Compile() {
      CompiledCmb = GlobalVars.CompileDL.Compile((int)Structs.UCodes.RDP, (uint)RDP_Defs.RDP.G_SETCOMBINE, CombinerColors);
      CompiledCmbCmd.Text = CompiledCmb.CMDParams[0].ToString("X2") + CompiledCmb.CMDLow.ToString("X6") + CompiledCmb.CMDHigh.ToString("X8");
    }

    private void cA0_SelectedIndexChanged(object sender, EventArgs e) {
      CombinerColors.cA[0] = (uint)cA0.SelectedIndex;
      Compile();
    }

    private void cB0_SelectedIndexChanged(object sender, EventArgs e) {
      CombinerColors.cB[0] = (uint)cB0.SelectedIndex;
      Compile();
    }

    private void cC0_SelectedIndexChanged(object sender, EventArgs e) {
      CombinerColors.cC[0] = (uint)cC0.SelectedIndex;
      Compile();
    }

    private void cD0_SelectedIndexChanged(object sender, EventArgs e) {
      CombinerColors.cD[0] = (uint)cD0.SelectedIndex;
      Compile();
    }

    private void cA1_SelectedIndexChanged(object sender, EventArgs e) {
      CombinerColors.cA[1] = (uint)cA1.SelectedIndex;
      Compile();
    }

    private void cB1_SelectedIndexChanged(object sender, EventArgs e) {
      CombinerColors.cB[1] = (uint)cB1.SelectedIndex;
      Compile();
    }

    private void cC1_SelectedIndexChanged(object sender, EventArgs e) {
      CombinerColors.cC[1] = (uint)cC1.SelectedIndex;
      Compile();
    }

    private void cD1_SelectedIndexChanged(object sender, EventArgs e) {
      CombinerColors.cD[1] = (uint)cD1.SelectedIndex;
      Compile();
    }

    private void aA0_SelectedIndexChanged(object sender, EventArgs e) {
      CombinerColors.aA[0] = (uint)aA0.SelectedIndex;
      Compile();
    }

    private void aB0_SelectedIndexChanged(object sender, EventArgs e) {
      CombinerColors.aB[0] = (uint)aB0.SelectedIndex;
      Compile();
    }

    private void aC0_SelectedIndexChanged(object sender, EventArgs e) {
      CombinerColors.aC[0] = (uint)aC0.SelectedIndex;
      Compile();
    }

    private void aD0_SelectedIndexChanged(object sender, EventArgs e) {
      CombinerColors.aD[0] = (uint)aD0.SelectedIndex;
      Compile();
    }

    private void aA1_SelectedIndexChanged(object sender, EventArgs e) {
      CombinerColors.aA[1] = (uint)aA1.SelectedIndex;
      Compile();
    }

    private void aB1_SelectedIndexChanged(object sender, EventArgs e) {
      CombinerColors.aB[1] = (uint)aB1.SelectedIndex;
      Compile();
    }

    private void aC1_SelectedIndexChanged(object sender, EventArgs e) {
      CombinerColors.aC[1] = (uint)aC1.SelectedIndex;
      Compile();
    }

    private void aD1_SelectedIndexChanged(object sender, EventArgs e) {
      CombinerColors.aD[1] = (uint)aD1.SelectedIndex;
      Compile();
    }

    private void Button1_Click(object sender, EventArgs e) {
      Compile();
    }

    private void CompiledCmbCmd_TextChanged(object sender, EventArgs e) {
      My.MyProject.Forms.MainWin.LowordText.Text = CompiledCmb.CMDLow.ToString("X6");
      My.MyProject.Forms.MainWin.HiwordText.Text = CompiledCmb.CMDHigh.ToString("X8");
      Functions.UpdateCommand(ref GlobalVars.N64DList[My.MyProject.Forms.MainWin.DListSelection.SelectedIndex - 1], (uint)My.MyProject.Forms.MainWin.CommandsListbox.SelectedIndex, Convert.ToByte(My.MyProject.Forms.MainWin.CommandCodeText.Text, 16), Convert.ToUInt32(My.MyProject.Forms.MainWin.HiwordText.Text, 16), Convert.ToUInt32(My.MyProject.Forms.MainWin.LowordText.Text, 16));
    }

    private void PrimR_Click(object sender, EventArgs e) {
      if (ColorSelector.ShowDialog() == DialogResult.OK) {
        GlobalVars.LinkedCommands.PrimColor = GlobalVars.CompileDL.Compile((int)Structs.UCodes.RDP, (uint)RDP_Defs.RDP.G_SETPRIMCOLOR, ColorSelector.Color);
        Functions.UpdateCommand(ref GlobalVars.N64DList[GlobalVars.LinkedCommands.PrimColor.DLPos], (uint)GlobalVars.LinkedCommands.PrimColor.DLPos, GlobalVars.LinkedCommands.PrimColor.CMDParams[0], GlobalVars.LinkedCommands.PrimColor.CMDHigh, GlobalVars.LinkedCommands.PrimColor.CMDLow);
        UpdatePrimColor(GlobalVars.LinkedCommands.PrimColor);
      }
    }
  }
}