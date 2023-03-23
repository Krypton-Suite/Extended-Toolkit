#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class ZoomRectangle : IRenderable
    {
        private float X;
        private float Y;
        private float Width;
        private float Height;

        public Color FillColor { get; set; } = Color.FromArgb(50, Color.Red);
        public Color BorderColor { get; set; } = Color.FromArgb(100, Color.Red);
        public bool IsVisible { get; set; } = true;

        public void Clear() => IsVisible = false;

        public void Set(float x, float y, float width, float height) =>
            (X, Y, Width, Height, IsVisible) = (x, y, width, height, true);

        public void Render(PlotDimensions dims, Bitmap bmp, bool lowQuality = false)
        {
            if (!IsVisible)
            {
                return;
            }

            using (var gfx = GDI.Graphics(bmp, dims, lowQuality: true, false))
            using (var fillBrush = GDI.Brush(FillColor))
            using (var borderPen = GDI.Pen(BorderColor))
            {
                gfx.FillRectangle(fillBrush, X + dims.DataOffsetX, Y + dims.DataOffsetY, Width, Height);
                gfx.DrawRectangle(borderPen, X + dims.DataOffsetX, Y + dims.DataOffsetY, Width, Height);
            }
        }
    }
}
