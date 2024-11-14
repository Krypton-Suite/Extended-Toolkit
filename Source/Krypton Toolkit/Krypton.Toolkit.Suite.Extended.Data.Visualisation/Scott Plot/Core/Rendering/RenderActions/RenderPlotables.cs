namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class RenderPlotables : IRenderAction
    {
        public void Render(RenderPack rp)
        {
            foreach (IPlottable plottable in rp.Plot.PlottableList)
            {
                if (!plottable.IsVisible)
                {
                    continue;
                }

                plottable.Axes.DataRect = rp.DataRect;
                rp.Canvas.Save();

                if (plottable is IPlottableGl plottableGl)
                {
                    plottableGl.Render(rp);
                }
                else
                {
                    rp.ClipToDataArea();
                    plottable.Render(rp);
                }

                rp.DisableClipping();
            }
        }
    }
}