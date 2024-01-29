namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    internal class SquareMarker : IMarker
    {
        public void Render(SKCanvas canvas, SKPaint paint, Pixel center, float size, FillStyle fill, LineStyle outline)
        {
            PixelRect rect = new(center: center, radius: size / 2);

            fill.ApplyToPaint(paint);
            canvas.DrawRect(rect.ToSkRect(), paint);

            if (outline.Width > 0)
            {
                outline.ApplyToPaint(paint);
                canvas.DrawRect(rect.ToSkRect(), paint);
            }
        }
    }
}