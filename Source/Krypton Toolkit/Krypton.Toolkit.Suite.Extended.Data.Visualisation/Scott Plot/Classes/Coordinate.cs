#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    /// <summary>
    /// Describes an X/Y position in coordinate space
    /// </summary>
    public class Coordinate
    {
        public double X;
        public double Y;

        public Coordinate(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// True as lone as neither coordinate is NaN or Infinity
        /// </summary>
        public bool IsFinite()
        {
            return
                !double.IsNaN(X) &&
                !double.IsNaN(Y) &&
                !double.IsInfinity(X) &&
                !double.IsInfinity(Y);
        }

        /// <summary>
        /// Return the distance to another coordinate (in coordinate units)
        /// </summary>
        public double Distance(Coordinate other)
        {
            double dX = Math.Abs(other.X - X);
            double dY = Math.Abs(other.Y - Y);
            return Math.Sqrt(dX * dX + dY * dY);
        }
    }
}