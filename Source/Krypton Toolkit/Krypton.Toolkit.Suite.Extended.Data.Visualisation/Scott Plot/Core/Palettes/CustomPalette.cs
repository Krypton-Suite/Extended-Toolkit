namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    internal class CustomPalette : IPalette
    {
        public Color[] Colors { get; }

        public string Name { get; }

        public string Description { get; }

        public CustomPalette(Color[] colors, string name, string description)
        {
            Colors = colors;
            Name = name;
            Description = description;
        }

        public CustomPalette(string[] hex, string name, string description)
        {
            Colors = Color.FromHex(hex);
            Name = name;
            Description = description;
        }

        public Color GetColor(int index) => Colors[index % Colors.Length];
    }
}