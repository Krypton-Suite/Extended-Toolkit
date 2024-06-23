﻿namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    internal class Asterisk : IMarker
    {
        public void Render(SKCanvas canvas, SKPaint paint, Pixel center, float size, FillStyle fill, LineStyle outline)
        {
            float crossOffset = size / 2;

            float eksOffset = (float)(size / 2.828);

            var path = new SKPath();
            // Same as cross marker
            path.MoveTo(center.X + crossOffset, center.Y);
            path.LineTo(center.X - crossOffset, center.Y);
            path.MoveTo(center.X, center.Y + crossOffset);
            path.LineTo(center.X, center.Y - crossOffset);

            // Similar to eks (X) marker, but with length = size / 2
            path.MoveTo(center.X + eksOffset, center.Y + eksOffset);
            path.LineTo(center.X - eksOffset, center.Y - eksOffset);
            path.MoveTo(center.X - eksOffset, center.Y + eksOffset);
            path.LineTo(center.X + eksOffset, center.Y - eksOffset);

            outline.ApplyToPaint(paint);
            canvas.DrawPath(path, paint);
        }
    }
}