/* Sourced from Son A. Pham's Sublime color scheme by the same name
 * https://github.com/sonph/onehalf
 */

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot;

public class OneHalfDark : IPalette
{
    public string Name { get; } = "One Half (Dark)";

    public string Description { get; } = "A Sublime color scheme by Son A. Pham: https://github.com/sonph/onehalf";

    public Color[] Colors { get; } = Color.FromHex(_hexColors);

    private static readonly string[] _hexColors =
    [
        "#e06c75", "#98c379", "#e5c07b", "#61aff0", "#c678dd", "#56b6c2", "#dcdfe4"
    ];

    public Color GetColor(int index) => Colors[index % Colors.Length];
}