namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class Custom : HexColourset, IPalette
    {
        public override string[] hexColors { get; } = new string[] { };

        public Custom(string[] htmlColors)
        {
            if (htmlColors is null)
                throw new ArgumentNullException("must provide at least one color");

            if (htmlColors.Length == 0)
                throw new ArgumentException("must provide at least one color");

            hexColors = htmlColors;
        }
    }
}
