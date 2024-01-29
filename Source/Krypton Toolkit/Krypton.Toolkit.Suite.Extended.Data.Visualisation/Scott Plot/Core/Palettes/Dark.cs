/* This a qualitative 8-color palette generated using https://colorbrewer2.org
 * © Cynthia Brewer, Mark Harrower and The Pennsylvania State University
 * It is is both LCD and print friendly but not blind nor photocopy friendly
 */

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class Dark : IPalette
    {
        public string Name { get; } = "Dark";

        public string Description { get; } = "A qualitative 8-color palette generated using colorbrewer2.org";

        public Color[] Colors { get; } = Color.FromHex(_hexColors);

        private static readonly string[] _hexColors =
        [
            "#1b9e77", "#d95f02", "#7570b3", "#e7298a", "#66a61e",
            "#e6ab02", "#a6761d", "#666666"
        ];

        public Color GetColor(int index) => Colors[index % Colors.Length];
    }
}