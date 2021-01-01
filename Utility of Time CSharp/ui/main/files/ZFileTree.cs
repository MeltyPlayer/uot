using System.Windows.Forms;

namespace UoT {
  public interface IZFile {
    string FileName { get; }
    string BetterFileName { get; }
  }

  public partial class ZFileTree : UserControl {
    public ZFileTree() {
      this.InitializeComponent();
    }

    public delegate void FileSelectedHandler(IZFile file);
    public event FileSelectedHandler FileSelected = delegate {};
  }
}
