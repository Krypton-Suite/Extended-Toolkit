namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot;

public class SquarePreserveY : IAxisRule
{
    private readonly IXAxis _xAxis;
    private readonly IYAxis _yAxis;

    public SquarePreserveY(IXAxis xAxis, IYAxis yAxis)
    {
        _xAxis = xAxis;
        _yAxis = yAxis;
    }

    public void Apply(RenderPack rp, bool beforeLayout)
    {
        // rules that refer to the datarect must wait for the layout to occur
        if (beforeLayout)
        {
            return;
        }

        double unitsPerPxY = _yAxis.Height / rp.DataRect.Height;
        var halfWidth = rp.DataRect.Width / 2 * unitsPerPxY;
        var xMin = _xAxis.Range.Center - halfWidth;
        var xMax = _xAxis.Range.Center + halfWidth;
        _xAxis.Range.Set(xMin, xMax);
    }
}