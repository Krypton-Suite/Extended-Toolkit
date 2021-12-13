#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

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