namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot;

public interface IFunctionSource
{
    CoordinateRange RangeX { get; }
    CoordinateRange GetRangeY(CoordinateRange rangeX);
    double Get(double x);
}