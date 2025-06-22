namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot;

public class LockedHorizontal : IAxisRule
{
    readonly IXAxis _xAxis;

    public LockedHorizontal(IXAxis xAxis)
    {
        _xAxis = xAxis;
    }

    public void Apply(RenderPack rp, bool beforeLayout)
    {
        // rules that refer to the last render must wait for a render to occur
        if (rp.Plot.LastRender.Count == 0)
        {
            return;
        }

        // TODO: reference the correct axis from the previous render
        double xMin = rp.Plot.LastRender.AxisLimits.Left;
        double xMax = rp.Plot.LastRender.AxisLimits.Right;
        _xAxis.Range.Set(xMin, xMax);
    }
}