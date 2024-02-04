namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class RenderPanels : IRenderAction
    {
        public void Render(RenderPack rp)
        {
            foreach (IPanel panel in rp.Plot.Axes.GetPanels())
            {
                float size = rp.Layout.PanelSizes[panel];
                float offset = rp.Layout.PanelOffsets[panel];
                panel.Render(rp, size, offset);
            }
        }
    }
}