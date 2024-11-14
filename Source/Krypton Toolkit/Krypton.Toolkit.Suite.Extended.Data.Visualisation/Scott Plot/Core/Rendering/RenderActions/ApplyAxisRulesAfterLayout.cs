namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class ApplyAxisRulesAfterLayout : IRenderAction
    {
        public void Render(RenderPack rp)
        {
            rp.Plot.Axes.Rules.ForEach(x => x.Apply(rp, beforeLayout: false));
        }
    }
}