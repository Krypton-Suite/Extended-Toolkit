#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Controls
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