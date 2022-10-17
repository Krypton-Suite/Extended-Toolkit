#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.InputBox
{
    [ToolboxItem(false)]
    public class InternalKryptonBorderedLabel : KryptonLabel
    {
        #region Identity

        public InternalKryptonBorderedLabel()
        {
            SetStyle(
                ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw |
                ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);

            UpdateStyles();

            BackColor = Color.Transparent;
        }
        #endregion

        #region Protected Overrides
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            ForeColor = KryptonManager.CurrentGlobalPalette.GetBorderColor1(PaletteBorderStyle.InputControlCustom1, PaletteState.Normal);

            Graphics gfx = e.Graphics;

            Rectangle r = new Rectangle(e.ClipRectangle.X, e.ClipRectangle.Y, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);

            gfx.DrawRectangle(new Pen(ForeColor), r);
        }
        #endregion
    }
}