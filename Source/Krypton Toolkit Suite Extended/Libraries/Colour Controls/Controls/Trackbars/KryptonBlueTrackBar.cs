using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.Colour.Controls
{
    [ToolboxBitmap(typeof(KryptonTrackBar))]
    public class KryptonBlueTrackBar : KryptonTrackBar
    {
        #region Constructor
        public KryptonBlueTrackBar()
        {
            Maximum = 255;

            StateCommon.Tick.Color1 = Color.Blue;

            StateCommon.Track.Color1 = Color.Blue;

            StateCommon.Track.Color2 = Color.Blue;

            StateCommon.Track.Color3 = Color.Blue;

            StateCommon.Track.Color4 = Color.Blue;

            StateCommon.Track.Color5 = Color.Blue;

            TickStyle = TickStyle.None;

            Size = new Size(182, 27);
        }
        #endregion
    }
}