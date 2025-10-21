namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot;

public class FixedWidth : IAxisManager
{
    /// <summary>
    /// Fractional amount to expand the axis vertically if data runs outside the current view
    /// </summary>
    public double ExpandFractionY = 0.5;

    public AxisLimits GetAxisLimits(AxisLimits viewLimits, AxisLimits dataLimits)
    {
        double xMin = dataLimits.Left;
        double xMax = dataLimits.Right;

        var expandY = ExpandFractionY * dataLimits.VerticalSpan;

        var yMin = dataLimits.Bottom < viewLimits.Bottom ? dataLimits.Bottom - expandY : viewLimits.Bottom;
        var yMax = dataLimits.Top > viewLimits.Top ? dataLimits.Top + expandY : viewLimits.Top;

        return new AxisLimits(xMin, xMax, yMin, yMax);
    }
}