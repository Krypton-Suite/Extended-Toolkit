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
    public class BenchmarkMessage : Message
    {
        private readonly Stopwatch Sw = new Stopwatch();
        public double MSec => Sw.ElapsedTicks * 1000.0 / Stopwatch.Frequency;
        public double Hz => (MSec > 0) ? 1000.0 / MSec : 0;
        public string Message => $"Rendered in {MSec:00.00} ms ({Hz:0000.00} Hz)";

        public void Restart() => Sw.Restart();
        public void Stop()
        {
            Sw.Stop();
            Text = Message;
        }

        public BenchmarkMessage()
        {
            HAlign = HorizontalAlignment.Left;
            VAlign = VerticalAlignment.Lower;
            FontColor = Color.Black;
            FillColor = Color.FromArgb(200, Color.Yellow);
            BorderColor = Color.Black;
        }
    }

    public class ErrorMessage : Message
    {
        public ErrorMessage()
        {
            HAlign = HorizontalAlignment.Left;
            VAlign = VerticalAlignment.Upper;
            FontColor = Color.Black;
            FillColor = Color.FromArgb(50, Color.Red);
            BorderColor = Color.Black;
        }
    }

    public class Message : IRenderable
    {
        public string Text;

        public HorizontalAlignment HAlign;
        public VerticalAlignment VAlign;

        public Color FontColor = Color.Black;
        public string FontName = InstalledFont.Monospace();
        public float FontSize = 12;
        public bool FontBold = false;

        public Color FillColor = Color.LightGray;
        public Color BorderColor = Color.Black;
        public float BorderWidth = 1;

        public float Padding = 3;

        public bool IsVisible { get; set; } = false;

        public void Render(PlotDimensions dims, Bitmap bmp, bool lowQuality = false)
        {
            if (!IsVisible || string.IsNullOrWhiteSpace(Text))
                return;

            using (var gfx = GDI.Graphics(bmp, dims, lowQuality, false))
            using (var font = GDI.Font(FontName, FontSize, FontBold))
            using (var fontBrush = new SolidBrush(FontColor))
            using (var fillBrush = new SolidBrush(FillColor))
            using (var borderPen = new Pen(BorderColor, BorderWidth))
            {
                SizeF textSize = GDI.MeasureString(gfx, Text, font);
                float textHeight = textSize.Height;
                float textWidth = textSize.Width;

                float textY = 0;
                if (VAlign == VerticalAlignment.Upper)
                    textY = dims.DataOffsetY + Padding;
                else if (VAlign == VerticalAlignment.Middle)
                    textY = dims.DataOffsetY + dims.DataHeight / 2 - textHeight / 2;
                else if (VAlign == VerticalAlignment.Lower)
                    textY = dims.DataOffsetY + dims.DataHeight - textHeight - Padding;

                float textX = 0;
                if (HAlign == HorizontalAlignment.Left)
                    textX = dims.DataOffsetX + Padding;
                else if (HAlign == HorizontalAlignment.Center)
                    textX = dims.DataOffsetX + dims.DataWidth / 2 - textWidth / 2;
                else if (HAlign == HorizontalAlignment.Right)
                    textX = dims.DataOffsetX + dims.DataWidth - textWidth - Padding;

                RectangleF textRect = new RectangleF(textX, textY, textWidth, textHeight);
                gfx.FillRectangle(fillBrush, textRect);
                gfx.DrawRectangle(borderPen, Rectangle.Round(textRect));
                gfx.DrawString(Text, font, fontBrush, textX, textY);
            }
        }
    }
}
