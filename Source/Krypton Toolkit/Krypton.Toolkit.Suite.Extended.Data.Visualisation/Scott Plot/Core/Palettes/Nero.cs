/* no info on where this palette originated */

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot;

public class Nero : IPalette
{
    public string Name { get; } = "Nero";

    public string Description { get; } = string.Empty;

    public Color[] Colors { get; } = Color.FromHex(_hexColors);

    private static readonly string[] _hexColors =
    [
        "#013A20", "#478C5C", "#94C973", "#BACC81", "#CDD193"
    ];

    public Color GetColor(int index) => Colors[index % Colors.Length];
}