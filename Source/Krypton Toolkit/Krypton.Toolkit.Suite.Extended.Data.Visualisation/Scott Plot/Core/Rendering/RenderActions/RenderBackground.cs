namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class RenderBackground : IRenderAction
    {
        public void Render(RenderPack rp)
        {
            using SKPaint paint = new() { Color = rp.Plot.DataBackground.ToSkColor() };
            rp.Canvas.DrawRect(rp.DataRect.ToSkRect(), paint);
        }
    }
}