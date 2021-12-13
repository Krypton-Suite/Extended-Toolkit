#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public struct AxisLimits : IEquatable<AxisLimits>
    {
        public readonly double XMin;
        public readonly double XMax;
        public readonly double YMin;
        public readonly double YMax;
        public override string ToString() => $"AxisLimits: x=[{XMin}, {XMax}] y=[{YMin}, {YMax}]";

        public readonly double XSpan;
        public readonly double YSpan;
        public readonly double XCenter;
        public readonly double YCenter;

        public AxisLimits(double xMin, double xMax, double yMin, double yMax)
        {
            (XMin, XMax, YMin, YMax) = (xMin, xMax, yMin, yMax);
            (XSpan, YSpan) = (XMax - XMin, YMax - YMin);
            (XCenter, YCenter) = (XMin + XSpan / 2, YMin + YSpan / 2);
        }

        public bool Equals(AxisLimits other) =>
            other.XMin == XMin &&
            other.XMax == XMax &&
            other.YMin == YMin &&
            other.YMax == YMax;
    }
}