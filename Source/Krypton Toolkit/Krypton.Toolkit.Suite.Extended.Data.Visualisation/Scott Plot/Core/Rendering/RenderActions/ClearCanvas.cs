namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class ClearCanvas : IRenderAction
    {
        public void Render(RenderPack rp)
        {
            rp.Canvas.Clear(rp.Plot.FigureBackground.ToSkColor());
        }
    }
}