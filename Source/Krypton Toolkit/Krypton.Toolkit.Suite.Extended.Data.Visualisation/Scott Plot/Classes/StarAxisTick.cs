namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public struct StarAxisTick
    {
        public readonly double Location;
        public readonly double[] Labels;

        public StarAxisTick(double location, double[] labels)
        {
            Location = location;
            Labels = labels;
        }

        public StarAxisTick(double location, double max)
        {
            Location = location;
            Labels = new double[] { location * max };
        }
    }
}