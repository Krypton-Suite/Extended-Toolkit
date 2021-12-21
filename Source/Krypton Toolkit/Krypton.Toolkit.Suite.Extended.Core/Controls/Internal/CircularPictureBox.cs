#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace Krypton.Toolkit.Suite.Extended.Core
{
    [ToolboxItem(false)]
    public class CircularPictureBox : PictureBox, IContentValues
    {
        private ToolTipValues _values;

        public ToolTipValues ToolTipValues { get => _values; set { _values = value; } }

        public CircularPictureBox()
        {
            BackColor = SystemColors.Control;
        }

        protected override void OnResize(EventArgs e)
        {
            using (GraphicsPath graphicsPath = new GraphicsPath())
            {
                graphicsPath.AddEllipse(new Rectangle(0, 0, Width - 1, Height - 1));

                Region = new Region(graphicsPath);
            }

            base.OnResize(e);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            using (GraphicsPath graphicsPath = new GraphicsPath())
            {
                graphicsPath.AddEllipse(0, 0, Width - 1, Height - 1);

                Region = new Region(graphicsPath);

                pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                pe.Graphics.DrawEllipse(new Pen(new SolidBrush(BackColor), 1), 0, 0, Width - 1, Height - 1);
            }

            base.OnPaint(pe);
        }

        public Image GetImage(PaletteState state) => throw new NotImplementedException();

        public Color GetImageTransparentColor(PaletteState state) => throw new NotImplementedException();

        public string GetShortText() => throw new NotImplementedException();

        public string GetLongText() => throw new NotImplementedException();
    }
}