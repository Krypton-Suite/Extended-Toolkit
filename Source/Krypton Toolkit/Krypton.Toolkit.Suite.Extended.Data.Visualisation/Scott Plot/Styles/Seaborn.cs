namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    internal class Seaborn : Default
    {
        public override Color DataBackgroundColor => ColorTranslator.FromHtml("#eaeaf2");
        public override Color FrameColor => Color.Transparent;
        public override Color GridLineColor => Color.White;
        public override Color AxisLabelColor => ColorTranslator.FromHtml("#777777");
        public override Color TitleFontColor => ColorTranslator.FromHtml("#777777");
        public override Color TickLabelColor => ColorTranslator.FromHtml("#AAAAAA");
        public override Color TickMajorColor => ColorTranslator.FromHtml("#eaeaf2");
        public override Color TickMinorColor => ColorTranslator.FromHtml("#eaeaf2");
    }
}
