namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public interface IOhlcSource
    {
        List<OHLC> GetOhlCs();
        public CoordinateRange GetLimitsX();
        public CoordinateRange GetLimitsY();
        AxisLimits GetLimits();
    }
}