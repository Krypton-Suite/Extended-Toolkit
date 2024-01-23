namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class BottomAxis : XAxisBase, IXAxis
    {
        public override Edge Edge => Edge.Bottom;

        public BottomAxis()
        {
            TickGenerator = new TickGenerators.NumericAutomatic();
        }
    }
}