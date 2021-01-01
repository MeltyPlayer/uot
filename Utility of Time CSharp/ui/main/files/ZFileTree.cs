using System.Windows.Forms;

using UoT.memory.files;

namespace UoT.ui.main.files {
  public partial class ZFileTree : UserControl {
    public ZFileTree() {
      this.InitializeComponent();
    }

    public delegate void FileSelectedHandler(IZFile file);
    public event FileSelectedHandler FileSelected = delegate {};
  }
}
