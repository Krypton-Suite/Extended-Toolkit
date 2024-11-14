namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class BollingerBands
    {
        public readonly double[] Means;
        public readonly double[] UpperValues;
        public readonly double[] LowerValues;
        public readonly DateTime[] DateTimes;
        public readonly double[] Dates;

        public BollingerBands(List<Ohlc> ohlcs, int n, double sdCoeff = 2)
        {
            double[] prices = ohlcs.Select(x => x.Close).ToArray();
            double[] sma = Series.MovingAverage(prices, n, preserveLength: true);
            double[] smstd = Series.SimpleMovingStandardDeviation(prices, n, preserveLength: true);

            UpperValues = new double[prices.Length];
            LowerValues = new double[prices.Length];
            for (int i = 0; i < prices.Length; i++)
            {
                LowerValues[i] = sma[i] - sdCoeff * smstd[i];
                UpperValues[i] = sma[i] + sdCoeff * smstd[i];
            }

            // skip the first points which all contain NaN
            Means = sma.Skip(n).ToArray();
            LowerValues = LowerValues.Skip(n).ToArray();
            UpperValues = UpperValues.Skip(n).ToArray();
            DateTimes = ohlcs.Skip(n).Select(x => x.DateTime).ToArray();
            Dates = DateTimes.Select(x => x.ToOADate()).ToArray();
        }
    }
}