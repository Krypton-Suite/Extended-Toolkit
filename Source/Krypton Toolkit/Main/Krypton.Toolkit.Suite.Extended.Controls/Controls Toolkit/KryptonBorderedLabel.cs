namespace Krypton.Toolkit.Suite.Extended.Controls
{
    public class KryptonBorderedLabel : KryptonLabel
    {
        #region Identity

        public KryptonBorderedLabel()
        {
            SetStyle(
                ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw |
                ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);

            UpdateStyles();

            BackColor = Color.Transparent;
        }
        #endregion

        #region Protected Overrides
        // TODO: Help to get this 'Kryptonised'
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