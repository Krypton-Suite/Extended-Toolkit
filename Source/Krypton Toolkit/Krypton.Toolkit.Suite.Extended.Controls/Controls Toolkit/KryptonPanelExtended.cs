#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Controls
{
    public class KryptonPanelExtended : KryptonPanel
    {
        #region Variables
        private int _cornerRadius;

        private Pen _pen;
        #endregion

        #region Property
        public int CornerRadius { get => _cornerRadius; set { _cornerRadius = value; Invalidate(); } }
        #endregion

        #region Constructor
        public KryptonPanelExtended()
        {
            DoubleBuffered = true;

            CornerRadius = 0;
        }
        #endregion

        #region Methods
        private Rectangle GetUpperLeft(int value) => new Rectangle(0, 0, value, value);

        private Rectangle GetUpperRight(int value) => new Rectangle(Width - value, 0, value, value);

        private Rectangle GetLowerRight(int value) => new Rectangle(Width - value, Height - value, value, value);

        private Rectangle GetLowerLeft(int value) => new Rectangle(0, Height - value, value, value);

        private void ExtendDraw(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            GraphicsPath path = new GraphicsPath();

            path.StartFigure();

            path.AddArc(GetUpperLeft(CornerRadius), 180, 90);

            path.AddLine(CornerRadius, 0, Width - CornerRadius, 0);

            path.AddArc(GetUpperRight(CornerRadius), 270, 90);

            path.AddLine(Width, CornerRadius, Width, Height - CornerRadius);

            path.AddArc(GetLowerRight(CornerRadius), 0, 90);

            path.AddLine(Width - CornerRadius, Height, CornerRadius, Height);

            path.AddArc(GetLowerLeft(CornerRadius), 90, 90);

            path.AddLine(0, Height - CornerRadius, 0, CornerRadius);

            path.CloseFigure();

            Region = new Region(path);
        }

        private void DrawSingleBorder(Graphics graphics)
        {
            graphics.DrawArc(_pen, new Rectangle(0, 0, CornerRadius, CornerRadius), 180, 90);

            graphics.DrawArc(_pen, new Rectangle(Width - CornerRadius - 1, -1, CornerRadius, CornerRadius), 270, 90);

            graphics.DrawArc(_pen, new Rectangle(Width - CornerRadius - 1, Height - CornerRadius - 1, CornerRadius, CornerRadius), 0, 90);

            graphics.DrawArc(_pen, new Rectangle(0, Height - CornerRadius - 1, CornerRadius, CornerRadius), 90, 90);

            graphics.DrawRectangle(_pen, 0.0f, 0.0f, (float)Width - 1.0f, (float)Height - 1.0f);
        }
        private void Draw3DBorder(Graphics graphics)
        {
            DrawSingleBorder(graphics);
        }
        private void DrawBorder(Graphics graphics)
        {
            DrawSingleBorder(graphics);
        }
        #endregion

        #region Overrides
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            ExtendDraw(e);

            DrawBorder(e.Graphics);
        }
        #endregion
    }
}