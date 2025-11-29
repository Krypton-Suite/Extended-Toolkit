namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot;

public class MinimumBoundary : IAxisRule
{
    private readonly IXAxis _xAxis;
    private readonly IYAxis _yAxis;
    public AxisLimits Limits { get; set; }

    public MinimumBoundary(IXAxis xAxis, IYAxis yAxis, AxisLimits limits)
    {
        _xAxis = xAxis;
        _yAxis = yAxis;
        Limits = limits;
    }

    public void Apply(RenderPack rp, bool beforeLayout)
    {
        double xSpan = Math.Max(_xAxis.Range.Span, Limits.HorizontalSpan);
        double ySpan = Math.Max(_yAxis.Range.Span, Limits.VerticalSpan);

        if (_xAxis.Range.Max < Limits.Right)
        {
            _xAxis.Range.Max = Limits.Right;
            _xAxis.Range.Min = Limits.Right - xSpan;
        }

        if (_xAxis.Range.Min > Limits.Left)
        {
            _xAxis.Range.Min = Limits.Left;
            _xAxis.Range.Max = Limits.Left + xSpan;
        }

        if (_yAxis.Range.Max < Limits.Top)
        {
            _yAxis.Range.Max = Limits.Top;
            _yAxis.Range.Min = Limits.Top - ySpan;
        }

        if (_yAxis.Range.Min > Limits.Bottom)
        {
            _yAxis.Range.Min = Limits.Bottom;
            _yAxis.Range.Max = Limits.Bottom + ySpan;
        }
    }
}