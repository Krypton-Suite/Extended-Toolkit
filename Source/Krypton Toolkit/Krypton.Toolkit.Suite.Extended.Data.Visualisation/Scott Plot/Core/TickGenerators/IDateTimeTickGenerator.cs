namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public interface IDateTimeTickGenerator : ITickGenerator
    {
        IEnumerable<double> ConvertToCoordinateSpace(IEnumerable<DateTime> dates);
    }
}