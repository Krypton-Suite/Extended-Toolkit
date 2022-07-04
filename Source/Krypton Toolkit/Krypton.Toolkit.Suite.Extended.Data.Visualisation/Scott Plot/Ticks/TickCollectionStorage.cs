#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class TickCollectionStorage
    {
        public static double[] tickPositionsMajor;
#pragma warning disable CS8632
        public static double[]? tickPositionsMinor;
#pragma warning restore CS8632
        public static string[] tickLabels;
        public static double[] manualTickPositions;
        public static string[] manualTickLabels;
    }
}