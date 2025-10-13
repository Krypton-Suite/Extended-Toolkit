/* A 9-color palette by Arthurits created by lightening the colors in the visible spectrum
 */

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot;

public class LightSpectrum : IPalette
{
    public string Name { get; } = "Light spectrum";

    public string Description { get; } =
        "A 9-color palette by Arthurits created by lightening the colors in the visible spectrum";

    public Color[] Colors { get; } = Color.FromHex(_hexColors);

    private static readonly string[] _hexColors =
    [
        "#fce5e6", "#fff8e7", "#fffce8",
        "#eff5e4", "#e7f2e6", "#ddf0f5",
        "#e6f2fc", "#e6eaf7", "#eee0f0"
    ];

    public Color GetColor(int index) => Colors[index % Colors.Length];
}