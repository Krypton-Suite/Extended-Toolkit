namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot;

internal class VerticalBar : IMarker
{
    public void Render(SKCanvas canvas, SKPaint paint, Pixel center, float size, FillStyle fill, LineStyle outline)
    {
        float offset = size / 2;

        var path = new SKPath();
        path.MoveTo(center.X, center.Y + offset);
        path.LineTo(center.X, center.Y - offset);

        outline.ApplyToPaint(paint);
        canvas.DrawPath(path, paint);
    }
}