namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot;

internal static class InternationalizationExtensions
{
    public static bool Uses24HourClock(this CultureInfo culture) =>
        culture.DateTimeFormat.LongTimePattern.Contains('H');
}