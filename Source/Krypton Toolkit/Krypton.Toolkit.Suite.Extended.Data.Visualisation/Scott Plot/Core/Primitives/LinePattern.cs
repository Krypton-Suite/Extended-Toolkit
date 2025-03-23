namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    // NOTE: names are consistent with matplotlib linestyles
// https://matplotlib.org/stable/gallery/lines_bars_and_markers/linestyles.html

// TODO: add support for more line styles

    public enum LinePattern
    {
        Solid,
        Dashed,
        DenselyDashed,
        Dotted,
    }

    public static class LinePatternExtensions
    {
        public static SKPathEffect? GetPathEffect(this LinePattern pattern)
        {
            return pattern switch
            {
                LinePattern.Solid => null,
                LinePattern.Dashed => SKPathEffect.CreateDash([10, 10], 0),
                LinePattern.DenselyDashed => SKPathEffect.CreateDash([6, 6], 0),
                LinePattern.Dotted => SKPathEffect.CreateDash([3, 5], 0),
                _ => throw new NotImplementedException($"Line pattern '{pattern}' has no matching path effect"),
            };
        }
    }
}