namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class MinimumSpan : IAxisRule
    {
        private readonly IXAxis _xAxis;
        private readonly IYAxis _yAxis;

        public double XSpan;
        public double YSpan;

        public MinimumSpan(IXAxis xAxis, IYAxis yAxis, double xSpan = double.Epsilon, double ySpan = double.Epsilon)
        {
            _xAxis = xAxis;
            _yAxis = yAxis;
            XSpan = xSpan;
            YSpan = ySpan;
        }

        public void Apply(RenderPack rp, bool beforeLayout)
        {
            if (_xAxis.Range.Span < XSpan)
            {
                var xMin = _xAxis.Range.Center - XSpan / 2;
                var xMax = _xAxis.Range.Center + XSpan / 2;
                _xAxis.Range.Set(xMin, xMax);
            }

            if (_yAxis.Range.Span < YSpan)
            {
                var yMin = _yAxis.Range.Center - YSpan / 2;
                var yMax = _yAxis.Range.Center + YSpan / 2;
                _yAxis.Range.Set(yMin, yMax);
            }
        }
    }
}