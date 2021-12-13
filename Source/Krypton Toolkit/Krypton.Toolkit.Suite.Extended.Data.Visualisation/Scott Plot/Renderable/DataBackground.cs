#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class DataBackground : IRenderable
    {
        public Color Color { get; set; } = Color.White;
        public bool IsVisible { get; set; } = true;

        public void Render(PlotDimensions dims, Bitmap bmp, bool lowQuality = false)
        {
            using (var gfx = GDI.Graphics(bmp, dims, lowQuality: true, false))
            using (var brush = GDI.Brush(Color))
            {
                var dataRect = new RectangleF(x: dims.DataOffsetX, y: dims.DataOffsetY, width: dims.DataWidth, height: dims.DataHeight);
                gfx.FillRectangle(brush, dataRect);
            }
        }
    }
}
