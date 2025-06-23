namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot;

internal class Circle : IMarker
{
    public void Render(SKCanvas canvas, SKPaint paint, Pixel center, float size, FillStyle fill, LineStyle outline)
    {
        float radius = size / 2;

        fill.ApplyToPaint(paint);
        canvas.DrawCircle(center.ToSkPoint(), radius, paint);

        if (outline.Width > 0)
        {
            outline.ApplyToPaint(paint);
            canvas.DrawCircle(center.ToSkPoint(), radius, paint);
        }
    }
}