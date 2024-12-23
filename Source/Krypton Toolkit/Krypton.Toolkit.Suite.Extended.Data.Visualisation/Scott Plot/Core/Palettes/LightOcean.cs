﻿/* A 9-color palette by Arthurits created by a mixture of light greens, blues, and purples
 */

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class LightOcean : IPalette
    {
        public string Name { get; } = "Light ocean";

        public string Description { get; } =
            "A 9-color palette by Arthurits created by a mixture of light greens, blues, and purples";

        public Color[] Colors { get; } = Color.FromHex(_hexColors);

        private static readonly string[] _hexColors =
        [
            "#dfedd9", "#dbecdc", "#dbede4",
            "#daeeec", "#daeef3", "#dae6f2",
            "#dadef1", "#dedaee", "#e5daed"
        ];

        public Color GetColor(int index) => Colors[index % Colors.Length];
    }
}