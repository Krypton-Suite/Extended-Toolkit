namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot;

internal static class EnumerableExtensions
{
    public static IEnumerable<T> One<T>(T item)
    {
        yield return item;
    }
}