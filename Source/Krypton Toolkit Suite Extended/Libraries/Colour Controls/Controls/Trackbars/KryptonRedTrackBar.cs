using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.Colour.Controls
{
    [ToolboxBitmap(typeof(KryptonTrackBar))]
    public class KryptonRedTrackBar : KryptonTrackBar
    {
        #region Constructor
        public KryptonRedTrackBar()
        {
            Maximum = 255;

            StateCommon.Tick.Color1 = Color.Red;

            StateCommon.Track.Color1 = Color.Red;

            StateCommon.Track.Color2 = Color.Red;

            StateCommon.Track.Color3 = Color.Red;

            StateCommon.Track.Color4 = Color.Red;

            StateCommon.Track.Color5 = Color.Red;

            TickStyle = TickStyle.None;

            Size = new Size(182, 27);
        }
        #endregion
    }
}