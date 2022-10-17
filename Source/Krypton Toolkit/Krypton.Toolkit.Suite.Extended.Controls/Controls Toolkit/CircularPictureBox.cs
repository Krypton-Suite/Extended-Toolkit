#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Controls
{
    public class CircularPictureBox : PictureBox
    {
        #region Constructor
        public CircularPictureBox() => BackColor = SystemColors.Control;
        #endregion

        #region Overrides
        protected override void OnResize(EventArgs e)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddEllipse(new Rectangle(0, 0, Width - 1, Height - 1));

                Region = new Region(path);
            }

            base.OnResize(e);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddEllipse(new Rectangle(0, 0, Width - 1, Height - 1));

                Region = new Region(path);

                pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                pe.Graphics.DrawEllipse(new Pen(new SolidBrush(BackColor), 1), 0, 0, Width - 1, Height - 1);
            }

            base.OnPaint(pe);
        }
        #endregion
    }
}