namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public static class DataOperations
    {
        public static double[,] ResizeHalf(double[,] values)
        {
            var height = values.GetLength(0);
            var width = values.GetLength(1);

            var heightNew = (int)Math.Floor((double)height / 2);
            var widthNew = (int)Math.Floor((double)width / 2);

            var output = new double[heightNew, widthNew];

            for (var y = 0; y < heightNew; y++)
            {
                for (var x = 0; x < widthNew; x++)
                {
                    double sum = 0;
                    sum += values[y * 2, x * 2];
                    sum += values[y * 2 + 1, x * 2];
                    sum += values[y * 2, x * 2 + 1];
                    sum += values[y * 2 + 1, x * 2 + 1];
                    output[y, x] = sum / 4;
                }
            }

            return output;
        }

        public static double[,] ReplaceNullWithNaN(double?[,] values)
        {
            var height = values.GetLength(0);
            var width = values.GetLength(1);
            var output = new double[height, width];

            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    output[y, x] = values[y, x] ?? double.NaN;
                }
            }

            return output;
        }

        public static double?[,] ReplaceNaNWithNull(double[,] values)
        {
            var height = values.GetLength(0);
            var width = values.GetLength(1);
            var output = new double?[height, width];

            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    output[y, x] = double.IsNaN(values[y, x]) ? null : values[y, x];
                }
            }

            return output;
        }
    }
}