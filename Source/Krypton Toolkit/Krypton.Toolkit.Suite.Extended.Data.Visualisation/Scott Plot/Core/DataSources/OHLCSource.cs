namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot;

public class OhlcSource : IOhlcSource
{
    private readonly List<Ohlc> _prices;

    public OhlcSource(List<Ohlc> prices)
    {
        _prices = prices;
    }

    public List<Ohlc> GetOhlCs()
    {
        return _prices;
    }

    public AxisLimits GetLimits()
    {
        return _prices.Any() ? new AxisLimits(GetLimitsX(), GetLimitsY()) : AxisLimits.NoLimits;
    }

    public CoordinateRange GetLimitsX()
    {
        var dates = _prices.Select(x => x.DateTime);
        return new CoordinateRange(dates.Min().ToNumber(), dates.Max().ToNumber());
    }

    public CoordinateRange GetLimitsY()
    {
        var priceRanges = _prices.Select(x => x.GetPriceRange());
        double min = priceRanges.Select(x => x.Min).Min();
        double max = priceRanges.Select(x => x.Max).Max();
        return new CoordinateRange(min, max);
    }
}