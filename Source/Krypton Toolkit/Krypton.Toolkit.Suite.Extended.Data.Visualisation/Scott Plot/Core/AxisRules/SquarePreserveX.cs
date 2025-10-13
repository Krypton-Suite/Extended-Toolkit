namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot;

public class SquarePreserveX : IAxisRule
{
    private readonly IXAxis _xAxis;
    private readonly IYAxis _yAxis;

    public SquarePreserveX(IXAxis xAxis, IYAxis yAxis)
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

        double unitsPerPxX = _xAxis.Width / rp.DataRect.Width;
        var halfHeight = rp.DataRect.Height / 2 * unitsPerPxX;
        var yMin = _yAxis.Range.Center - halfHeight;
        var yMax = _yAxis.Range.Center + halfHeight;
        _yAxis.Range.Set(yMin, yMax);
    }
}