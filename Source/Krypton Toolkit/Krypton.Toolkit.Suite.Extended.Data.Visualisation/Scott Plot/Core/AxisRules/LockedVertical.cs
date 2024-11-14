namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class LockedVertical : IAxisRule
    {
        private readonly IYAxis _yAxis;

        public LockedVertical(IYAxis yAxis)
        {
            _yAxis = yAxis;
        }

        public void Apply(RenderPack rp, bool beforeLayout)
        {
            // rules that refer to the last render must wait for a render to occur
            if (rp.Plot.LastRender.Count == 0)
            {
                return;
            }

            // TODO: reference the correct axis from the previous render
            double yMin = rp.Plot.LastRender.AxisLimits.Bottom;
            double yTop = rp.Plot.LastRender.AxisLimits.Top;
            _yAxis.Range.Set(yMin, yTop);
        }
    }
}