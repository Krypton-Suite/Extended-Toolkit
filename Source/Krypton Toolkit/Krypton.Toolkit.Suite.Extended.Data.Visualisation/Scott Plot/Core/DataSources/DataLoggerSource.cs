namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class DataLoggerSource
    {
        // TODO: support unevenly spaced X positions

        // TODO: render using SignalXY binary search strategy

        public readonly List<Coordinates> Coordinates = [];
        public double Period = 1;

        private double _yMin = double.PositiveInfinity;
        private double _yMax = double.NegativeInfinity;

        public int CountOnLastRender = -1;
        public int CountTotal => Coordinates.Count;

        public DataLoggerSource()
        {
        }

        public void Add(double y)
        {
            var x = Coordinates.Count * Period;
            Add(x, y);
        }

        public void Add(double x, double y)
        {
            Add(new Coordinates(x, y));
        }

        public void Add(Coordinates coordinates)
        {
            if (Coordinates.Any())
            {
                if (coordinates.X < Coordinates.Last().X)
                {
                    throw new ArgumentException("new X values cannot be smaller than existing ones");
                }
            }

            Coordinates.Add(coordinates);
            _yMin = Math.Min(_yMin, coordinates.Y);
            _yMax = Math.Max(_yMax, coordinates.Y);
        }

        public void Clear()
        {
            Coordinates.Clear();
            _yMin = double.PositiveInfinity;
            _yMax = double.NegativeInfinity;
        }

        public AxisLimits GetAxisLimits()
        {
            return Coordinates.Any()
                ? new AxisLimits(Coordinates.First().X, Coordinates.Last().X, _yMin, _yMax)
                : AxisLimits.NoLimits;
        }
    }
}