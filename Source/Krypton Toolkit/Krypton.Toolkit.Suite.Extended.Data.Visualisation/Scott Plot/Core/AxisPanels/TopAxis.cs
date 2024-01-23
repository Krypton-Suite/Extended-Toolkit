namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class TopAxis : XAxisBase, IXAxis
    {
        public override Edge Edge => Edge.Top;

        public TopAxis()
        {
            TickGenerator = new TickGenerators.NumericAutomatic();
        }
    }
}