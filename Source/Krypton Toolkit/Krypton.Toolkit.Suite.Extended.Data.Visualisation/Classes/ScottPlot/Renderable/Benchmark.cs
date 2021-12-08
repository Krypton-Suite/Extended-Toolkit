#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation
{
    public class Benchmark : IRenderable
    {
        private Stopwatch stopwatch = new Stopwatch();
        public double msec { get { return stopwatch.ElapsedTicks * 1000.0 / Stopwatch.Frequency; } }
        public double hz { get { return (msec > 0) ? 1000.0 / msec : 0; } }
        public string text { get; private set; }

        public string FontName = Fonts.GetMonospaceFontName();
        public float FontSize = 10;
        public Color FillColour = Color.FromArgb(150, Color.LightYellow);
        public Color FontColour = Color.Black;

        public bool Visible = false;

        public void Start() => stopwatch.Restart();
        public void Stop() => stopwatch.Stop();
        public override string ToString() => text;

        public void UpdateMessage(int plottableCount, int pointCount)
        {
            text = "";
            text += string.Format("Full render of {0:n0} objects ({1:n0} points)", plottableCount, pointCount);
            text += string.Format(" took {0:0.000} ms ({1:0.00 Hz})", msec, hz);
            if (plottableCount == 1)
                text = text.Replace("objects", "object");
        }

        public void Render(Settings settings)
        {
            if (Visible == false)
                return;

            using (var font = new Font(FontName, FontSize, FontStyle.Regular, GraphicsUnit.Pixel))
            using (var fontBrush = new SolidBrush(FontColour))
            using (var fillBrush = new SolidBrush(FillColour))
            using (var outline = new Pen(FontColour))
            {
                int debugPadding = 3;
                SizeF txtSize = settings.gfxData.MeasureString(text, font);
                PointF txtLoc = new PointF(
                    x: settings.dataSize.Width + settings.dataOrigin.X - debugPadding - txtSize.Width,
                    y: settings.dataSize.Height + settings.dataOrigin.Y - debugPadding - txtSize.Height);
                RectangleF textRect = new RectangleF(txtLoc, txtSize);

                settings.gfxFigure.FillRectangle(fillBrush, textRect);
                settings.gfxFigure.DrawRectangle(outline, Rectangle.Round(textRect));
                settings.gfxFigure.DrawString(text, font, fontBrush, txtLoc);
            }
        }
    }
}