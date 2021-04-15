#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation
{
    // Axes (the plural of Axis) represents an X and Y axis
    public class Axes
    {
        public bool equalAxes = false;
        public Axis x = new Axis();
        public Axis y = new Axis();

        public bool HasBeenSet => ((x.hasBeenSet) || (y.hasBeenSet));

        public double[] Limits => new double[] { x.Min, x.Max, y.Min, y.Max };

        public override string ToString() => $"Axes: X=({x.Min}, {x.Max}), Y=({x.Min}, {x.Max})";

        public double[] ToArray() => new double[] { x.Min, x.Max, y.Min, y.Max };

        public void Set(double? x1 = null, double? x2 = null, double? y1 = null, double? y2 = null)
        {
            x.Min = x1 ?? x.Min;
            x.Max = x2 ?? x.Max;
            y.Min = y1 ?? y.Min;
            y.Max = y2 ?? y.Max;
        }

        public void Set(double[] limits)
        {
            if ((limits == null) || (limits.Length != 4))
                throw new ArgumentException();

            Set(limits[0], limits[1], limits[2], limits[3]);
        }

        public void Set(AxisLimits2D limits)
        {
            limits.MakeRational();
            Set(limits.x1, limits.x2, limits.y1, limits.y2);
        }

        public void Set(ValueTuple<double, double, double, double> limits) => Set(limits.Item1, limits.Item2, limits.Item3, limits.Item4);

        public void Zoom(double xFrac = 1, double yFrac = 1, double? centerX = null, double? centerY = null)
        {
            x.Zoom(xFrac, centerX);
            y.Zoom(yFrac, centerY);
        }

        public void Reset()
        {
            x.Min = 0;
            x.Max = 0;
            x.hasBeenSet = false;

            y.Min = 0;
            y.Max = 0;
            y.hasBeenSet = false;
        }

        public void ApplyBounds()
        {
            x.ApplyBounds();
            y.ApplyBounds();
        }
    }
}