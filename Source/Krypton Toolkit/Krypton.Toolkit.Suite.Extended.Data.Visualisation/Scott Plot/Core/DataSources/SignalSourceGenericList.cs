namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot;

public class SignalSourceGenericList<T> : SignalSourceBase, ISignalSource
{
    private readonly List<T> _ys;
    public override int Length => _ys.Count;

    public SignalSourceGenericList(List<T> ys, double period)
    {
        _ys = ys;
        Period = period;
    }

    public IReadOnlyList<double> GetYs()
    {
        return NumericConversion.GenericToDoubleArray(_ys);
    }

    public override SignalRangeY GetLimitsY(int firstIndex, int lastIndex)
    {
        double min = double.PositiveInfinity;
        double max = double.NegativeInfinity;

        for (int i = firstIndex; i <= lastIndex; i++)
        {
            T genericValue = _ys[i];
            double value = NumericConversion.GenericToDouble(ref genericValue);
            min = Math.Min(min, value);
            max = Math.Max(max, value);
        }

        return new SignalRangeY(min, max);
    }

    public PixelColumn GetPixelColumn(IAxes axes, int xPixelIndex)
    {
        float xPixel = axes.DataRect.Left + xPixelIndex;
        double xRangeMin = axes.GetCoordinateX(xPixel);
        float xUnitsPerPixel = (float)(axes.XAxis.Width / axes.DataRect.Width);
        double xRangeMax = xRangeMin + xUnitsPerPixel;

        if (RangeContainsSignal(xRangeMin, xRangeMax) == false)
        {
            return PixelColumn.WithoutData(xPixel);
        }

        // determine column limits horizontally
        int i1 = GetIndex(xRangeMin, true);
        int i2 = GetIndex(xRangeMax, true);
        float yEnter = axes.GetPixelY(NumericConversion.GenericToDouble(_ys, i1) + YOffset);
        float yExit = axes.GetPixelY(NumericConversion.GenericToDouble(_ys, i2) + YOffset);

        // determine column span vertically
        double yMin = double.PositiveInfinity;
        double yMax = double.NegativeInfinity;
        for (int i = i1; i <= i2; i++)
        {
            double value = NumericConversion.GenericToDouble(_ys, i);
            yMin = Math.Min(yMin, value);
            yMax = Math.Max(yMax, value);
        }
        yMin += YOffset;
        yMax += YOffset;

        float yBottom = axes.GetPixelY(yMin);
        float yTop = axes.GetPixelY(yMax);

        return new PixelColumn(xPixel, yEnter, yExit, yBottom, yTop);
    }
}