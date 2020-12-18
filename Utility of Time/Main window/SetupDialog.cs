using System;
using System.IO;
using System.Windows.Forms;

namespace UoT {
  public partial class SetupDialog {
    public SetupDialog() {
      InitializeComponent();
      _OK_Button.Name = "OK_Button";
      _Cancel_Button.Name = "Cancel_Button";
      _Button2.Name = "Button2";
    }

    private string bankmt;
    private iniwriter iniwrite = new iniwriter(Application.StartupPath + "/uot.ini");

    private void OK_Button_Click(object sender, EventArgs e) {
      if (!string.IsNullOrEmpty(TextBox2.Text) & File.Exists(TextBox2.Text) == true) {
        GlobalVars.DefROM = TextBox2.Text;
        iniwrite.WriteString("Settings", "DefaultROM", GlobalVars.DefROM);
        My.MyProject.Forms.MainWin.LoadROM.FileName = GlobalVars.DefROM;
        My.MyProject.Forms.MainWin.Start(false);
      }

      DialogResult = DialogResult.OK;
      Close();
    }

    private void Cancel_Button_Click(object sender, EventArgs e) {
      DialogResult = DialogResult.Cancel;
      Close();
    }

    private void Dialog3_Load(object sender, EventArgs e) {
      GlobalVars.DefROM = iniwrite.GetString("Settings", "DefaultROM", null);
      TextBox2.Text = GlobalVars.DefROM;
    }

    private void Button2_Click(object sender, EventArgs e) {
      if (OpenFileDialog1.ShowDialog() == DialogResult.Cancel) {
        OpenFileDialog1.Dispose();
      }
    }

    private void OpenFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e) {
      TextBox2.Text = OpenFileDialog1.FileName;
    }

    private void Button3_Click(object sender, EventArgs e) {
      if (OpenFileDialog2.ShowDialog() == DialogResult.Cancel) {
        OpenFileDialog2.Dispose();
      }
    }
  }
}