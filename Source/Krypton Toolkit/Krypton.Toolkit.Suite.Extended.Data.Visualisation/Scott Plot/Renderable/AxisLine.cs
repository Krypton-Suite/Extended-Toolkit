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
    public class AxisLineOptional : IRenderable
    {
        public bool IsVisible { get; set; } = true;
        public Color Color = Color.Black;
        public float Width = 1;
        public Edge Edge;
        public float PixelOffset;

        public void Render(PlotDimensions dims, Bitmap bmp, bool lowQuality = false)
        {
            if (IsVisible == false)
                return;

            using (var gfx = GDI.Graphics(bmp, dims, lowQuality, false))
            using (var pen = GDI.Pen(Color, Width))
            {
                float left = dims.DataOffsetX;
                float right = dims.DataOffsetX + dims.DataWidth;
                float top = dims.DataOffsetY;
                float bottom = dims.DataOffsetY + dims.DataHeight;

                if (Edge == Edge.Bottom)
                    gfx.DrawLine(pen, left, bottom + PixelOffset, right, bottom + PixelOffset);
                else if (Edge == Edge.Left)
                    gfx.DrawLine(pen, left - PixelOffset, bottom, left - PixelOffset, top);
                else if (Edge == Edge.Right)
                    gfx.DrawLine(pen, right + PixelOffset, bottom, right + PixelOffset, top);
                else if (Edge == Edge.Top)
                    gfx.DrawLine(pen, left, top - PixelOffset, right, top - PixelOffset);
                else
                    throw new NotImplementedException();
            }
        }
    }
}
