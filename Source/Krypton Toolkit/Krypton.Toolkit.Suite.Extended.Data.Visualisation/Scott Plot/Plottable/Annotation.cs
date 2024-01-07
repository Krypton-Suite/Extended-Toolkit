#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
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
    /// <summary>
    /// Text placed at a location relative to the data area that does not move when the axis limits change
    /// </summary>
    public class Annotation : IPlottable
    {
        /// <summary>
        /// Horizontal location (in pixel units) relative to the data area
        /// </summary>
        public double X;

        /// <summary>
        /// Vertical position (in pixel units) relative to the data area
        /// </summary>
        public double Y;

        /// <summary>
        /// Text displayed in the annotation
        /// </summary>
        public string Label;

        public readonly Font Font = new Font();

        public bool Background = true;
        public Color BackgroundColor = Color.Yellow;

        public bool Shadow = true;
        public Color ShadowColor = Color.FromArgb(25, Color.Black);

        public bool Border = true;
        public float BorderWidth = 1;
        public Color BorderColor = Color.Black;

        public bool IsVisible { get; set; } = true;
        public int XAxisIndex { get; set; } = 0;
        public int YAxisIndex { get; set; } = 0;

        public override string ToString() => $"PlottableAnnotation at ({X} px, {Y} px)";
        public LegendItem[]? GetLegendItems() => null;
        public AxisLimits GetAxisLimits() => new AxisLimits(double.NaN, double.NaN, double.NaN, double.NaN);

        public void ValidateData(bool deep = false)
        {
            if (double.IsNaN(X) || double.IsInfinity(X))
            {
                throw new InvalidOperationException("xPixel must be a valid number");
            }

            if (double.IsNaN(Y) || double.IsInfinity(Y))
            {
                throw new InvalidOperationException("xPixel must be a valid number");
            }
        }

        // TODO: the negative coordiante thing is silly. Use alignment fields to control this behavior.

        public void Render(PlotDimensions dims, Bitmap bmp, bool lowQuality = false)
        {
            if (!IsVisible)
            {
                return;
            }

            using var gfx = GDI.Graphics(bmp, dims, lowQuality, false);
            using var font = GDI.Font(Font);
            using var fontBrush = new SolidBrush(Font.Color);
            using var shadowBrush = new SolidBrush(ShadowColor);
            using var backgroundBrush = new SolidBrush(BackgroundColor);
            using var borderPen = new Pen(BorderColor, BorderWidth);

            SizeF size = GDI.MeasureString(gfx, Label, font);

            double x = (X >= 0) ? X : dims.DataWidth + X - size.Width;
            double y = (Y >= 0) ? Y : dims.DataHeight + Y - size.Height;
            PointF location = new PointF((float)x + dims.DataOffsetX, (float)y + dims.DataOffsetY);

            if (Background && Shadow)
            {
                gfx.FillRectangle(shadowBrush, location.X + 5, location.Y + 5, size.Width, size.Height);
            }

            if (Background)
            {
                gfx.FillRectangle(backgroundBrush, location.X, location.Y, size.Width, size.Height);
            }

            if (Border)
            {
                gfx.DrawRectangle(borderPen, location.X, location.Y, size.Width, size.Height);
            }

            gfx.DrawString(Label, font, fontBrush, location);
        }
    }
}
