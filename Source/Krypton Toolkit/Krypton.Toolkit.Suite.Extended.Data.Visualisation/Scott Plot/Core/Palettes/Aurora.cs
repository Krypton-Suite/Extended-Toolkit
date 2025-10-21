/* Sourced from Nord:
 * https://github.com/arcticicestudio/nord
 * https://www.nordtheme.com/docs/colors-and-palettes
 */

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot;

public class Aurora : IPalette
{
    public string Name { get; } = "Aurora";

    public string Description { get; } = "From the Nord " +
                                         "collection of palettes: https://github.com/arcticicestudio/nord";

    public Color[] Colors { get; } = Color.FromHex(_hexColors);

    private static readonly string[] _hexColors =
    [
        "#BF616A", "#D08770", "#EBCB8B", "#A3BE8C", "#B48EAD"
    ];

    public Color GetColor(int index) => Colors[index % Colors.Length];
}