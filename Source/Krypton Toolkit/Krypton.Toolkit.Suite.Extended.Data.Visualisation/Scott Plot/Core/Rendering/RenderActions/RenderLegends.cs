namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class RenderLegends : IRenderAction
    {
        public void Render(RenderPack rp)
        {
            rp.Plot.Legend.Render(rp);
        }
    }
}