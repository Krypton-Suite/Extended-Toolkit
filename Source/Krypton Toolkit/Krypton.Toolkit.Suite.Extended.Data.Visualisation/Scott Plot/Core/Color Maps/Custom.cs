namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot;

public class Custom : ColormapBase
{
    public override string Name { get; }

    private readonly Color[] _colors;

    public Custom(Color[] colors, string name = "custom")
    {
        _colors = colors;
        Name = name;
    }

    public override Color GetColor(double position)
    {
        var index = (int)((_colors.Length - 1) * position);
        return _colors[index];
    }
}
