using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    public class KryptonBorderedLabel : KryptonLabel
    {
        public KryptonBorderedLabel()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);

            UpdateStyles();

            BackColor = Color.Transparent;
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            //default Paint
            base.OnPaint(e);
            //get Forecolor
            ForeColor = KryptonManager.CurrentGlobalPalette.GetBorderColor1(PaletteBorderStyle.InputControlCustom1, PaletteState.Normal);
            //get Graphics
            Graphics screenGraphics = e.Graphics;
            //Set Rectangle to draw 
            Rectangle rect = new Rectangle(e.ClipRectangle.X, e.ClipRectangle.Y, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);
            //Draw the border
            screenGraphics.DrawRectangle(new Pen(ForeColor), rect);
        }

    }
}