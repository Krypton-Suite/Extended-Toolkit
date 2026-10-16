namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot;

public sealed class MirroredYAxis : YAxisBase, IYAxis
{
    private readonly Edge _edge;
    private readonly IYAxis _axis;
    public override Edge Edge => _edge;
#pragma warning disable WFO2000 // Live snapshot of the source axis limits.
    public override CoordinateRangeMutable Range => new(_axis.Min, _axis.Max);
#pragma warning restore WFO2000

    public MirroredYAxis(IYAxis axis, Edge? edge)
    {
        _axis = axis;
        _edge = edge ?? axis.Edge;
        TickGenerator = axis.TickGenerator;
    }
}