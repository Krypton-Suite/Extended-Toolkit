namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class SimpleMovingAverage
    {
        public readonly double[] Means;
        public readonly DateTime[] DateTimes;
        public readonly double[] Dates;

        public SimpleMovingAverage(List<Ohlc> ohlcs, int n)
        {
            double[] prices = ohlcs.Select(x => x.Close).ToArray();
            Means = Series.MovingAverage(prices, n);
            DateTimes = ohlcs.Skip(n).Select(x => x.DateTime).ToArray();
            Dates = DateTimes.Select(x => x.ToOADate()).ToArray();
        }
    }
}