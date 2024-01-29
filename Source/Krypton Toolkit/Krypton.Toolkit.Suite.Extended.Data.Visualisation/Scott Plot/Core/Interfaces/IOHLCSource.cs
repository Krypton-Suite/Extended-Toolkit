namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public interface IOhlcSource
    {
        List<Ohlc> GetOhlCs();
        public CoordinateRange GetLimitsX();
        public CoordinateRange GetLimitsY();
        AxisLimits GetLimits();
    }
}