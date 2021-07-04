using System.ComponentModel;
using System.Drawing;

namespace Cyotek.Windows.Forms
{
  public class EditColorCancelEventArgs : CancelEventArgs
  {
    #region Constructors

    public EditColorCancelEventArgs(Color color, int colorIndex)
    {
      this.Color = color;
      this.ColorIndex = colorIndex;
    }

    protected EditColorCancelEventArgs()
    { }

    #endregion

    #region Properties

    public Color Color { get; protected set; }

    public int ColorIndex { get; protected set; }

    #endregion
  }
}
