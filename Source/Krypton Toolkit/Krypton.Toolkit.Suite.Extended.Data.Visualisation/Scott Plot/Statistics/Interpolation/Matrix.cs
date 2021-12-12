namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class Matrix
    {
        public double[,] a;

        public double[] y, x;

        public Matrix(int size)
        {
            a = new double[size, size];

            y = new double[size];

            x = new double[size];
        }
    }
}