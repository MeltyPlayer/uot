using System.Windows.Forms;

namespace UoT {
  public partial class HexEditor {
    public HexEditor() {
      InitializeComponent();
      _DataGridView1.Name = "DataGridView1";
    }

    private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {
    }
  }
}