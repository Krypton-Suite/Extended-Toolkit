namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public interface IDateTimeUnit
    {
        (double[] Ticks, string[] Labels) GetTicksAndLabels(DateTime from, DateTime to, string format);
    }
}
