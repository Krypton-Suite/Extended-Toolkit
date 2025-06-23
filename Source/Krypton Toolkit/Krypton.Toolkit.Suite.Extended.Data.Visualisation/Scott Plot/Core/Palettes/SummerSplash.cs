/* This palette can be found in several places:
 * https://www.canva.com/colors/color-palettes/summer-splash/
 * https://color.adobe.com/My-Color-Theme-color-theme-17257636/
 * "The Indian Ocean" on https://evening-ridge-43372.herokuapp.com/
 */

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot;

public class SummerSplash : IPalette
{
    public string Name { get; } = "Summer Splash";

    public string Description { get; } = string.Empty;

    public Color[] Colors { get; } = Color.FromHex(_hexColors);

    private static readonly string[] _hexColors =
    [
        "#05445E", "#189AB4", "#75E6DA", "#D4F1F4"
    ];

    public Color GetColor(int index) => Colors[index % Colors.Length];
}