/* Sourced from Nord:
 * https://github.com/arcticicestudio/nord
 * https://www.nordtheme.com/docs/colors-and-palettes
 */

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot;

public class SnowStorm : IPalette
{
    public string Name { get; } = "Snow Storm";

    public string Description { get; } = "From the " +
                                         "Nord collection of palettes: https://github.com/arcticicestudio/nord";

    public Color[] Colors { get; } = Color.FromHex(_hexColors);

    private static readonly string[] _hexColors =
    [
        "#D8DEE9", "#E5E9F0", "#ECEFF4"
    ];

    public Color GetColor(int index) => Colors[index % Colors.Length];
}