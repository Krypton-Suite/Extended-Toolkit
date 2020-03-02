using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.Colour.Controls
{
    [ToolboxBitmap(typeof(KryptonTrackBar))]
    public class KryptonGreenTrackBar : KryptonTrackBar
    {
        #region Constructor
        public KryptonGreenTrackBar()
        {
            Maximum = 255;

            StateCommon.Tick.Color1 = Color.Green;

            StateCommon.Track.Color1 = Color.Green;

            StateCommon.Track.Color2 = Color.Green;

            StateCommon.Track.Color3 = Color.Green;

            StateCommon.Track.Color4 = Color.Green;

            StateCommon.Track.Color5 = Color.Green;

            TickStyle = TickStyle.None;

            Size = new Size(182, 27);
        }
        #endregion
    }
}