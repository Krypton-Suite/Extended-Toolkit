namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class SquareZoomOut : IAxisRule
    {
        private readonly IXAxis _xAxis;
        private readonly IYAxis _yAxis;

        public SquareZoomOut(IXAxis xAxis, IYAxis yAxis)
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
            double unitsPerPxY = _yAxis.Height / rp.DataRect.Height;
            var maxUnitsPerPx = Math.Max(unitsPerPxX, unitsPerPxY);

            var halfHeight = rp.DataRect.Height / 2 * maxUnitsPerPx;
            var yMin = _yAxis.Range.Center - halfHeight;
            var yMax = _yAxis.Range.Center + halfHeight;
            _yAxis.Range.Set(yMin, yMax);

            var halfWidth = rp.DataRect.Width / 2 * maxUnitsPerPx;
            var xMin = _xAxis.Range.Center - halfWidth;
            var xMax = _xAxis.Range.Center + halfWidth;
            _xAxis.Range.Set(xMin, xMax);
        }
    }
}