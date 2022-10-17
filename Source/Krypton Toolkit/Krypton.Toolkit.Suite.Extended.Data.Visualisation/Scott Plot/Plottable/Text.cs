﻿#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    /// <summary>
    /// Display a text label at an X/Y position in coordinate space
    /// </summary>
    public class Text : IPlottable
    {
        // data
        public double X;
        public double Y;
        public string Label;

        // customization
        public bool IsVisible { get; set; } = true;
        public int XAxisIndex { get; set; } = 0;
        public int YAxisIndex { get; set; } = 0;
        public bool BackgroundFill = false;
        public Color BackgroundColor;
        public Font Font = new Font();
        public Color Color { set => Font.Color = value; }
        public string FontName { set => Font.Name = value; }
        public float FontSize { set => Font.Size = value; }
        public bool FontBold { set => Font.Bold = value; }
        public Alignment Alignment { set => Font.Alignment = value; }
        public float Rotation { set => Font.Rotation = value; }

        public override string ToString() => $"PlottableText \"{Label}\" at ({X}, {Y})";
        public AxisLimits GetAxisLimits() => new AxisLimits(X, X, Y, Y);
        public LegendItem[] GetLegendItems() => null;

        public void ValidateData(bool deep = false)
        {
            if (double.IsNaN(X) || double.IsNaN(Y))
                throw new InvalidOperationException("X and Y cannot be NaN");

            if (double.IsInfinity(X) || double.IsInfinity(Y))
                throw new InvalidOperationException("X and Y cannot be Infinity");

            if (string.IsNullOrWhiteSpace(Label))
                throw new InvalidOperationException("text cannot be null or whitespace");
        }

        public void Render(PlotDimensions dims, Bitmap bmp, bool lowQuality = false)
        {
            if (string.IsNullOrWhiteSpace(Label) || IsVisible == false)
                return;

            using (Graphics gfx = GDI.Graphics(bmp, dims, lowQuality))
            using (var font = GDI.Font(Font))
            using (var fontBrush = new SolidBrush(Font.Color))
            using (var frameBrush = new SolidBrush(BackgroundColor))
            {
                float pixelX = dims.GetPixelX(X);
                float pixelY = dims.GetPixelY(Y);
                SizeF stringSize = GDI.MeasureString(gfx, Label, font);

                gfx.TranslateTransform(pixelX, pixelY);
                gfx.RotateTransform(Font.Rotation);

                if (BackgroundFill)
                {
                    RectangleF stringRect = new RectangleF(0, 0, stringSize.Width, stringSize.Height);
                    gfx.FillRectangle(frameBrush, stringRect);
                }

                StringFormat sf = GDI.StringFormat(Font.Alignment);
                gfx.DrawString(Label, font, fontBrush, new PointF(0, 0), sf);

                gfx.ResetTransform();
            }
        }
    }
}
