using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Colour.Controls
{
    [ToolboxBitmap(typeof(KryptonTrackBar))]
    public class KryptonAlphaTrackBar : KryptonTrackBar
    {
        #region Constructor
        public KryptonAlphaTrackBar()
        {
            Maximum = 255;

            TickStyle = TickStyle.None;

            Size = new Size(182, 27);
        }
        #endregion
    }
}