#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation
{
    public abstract class Plottable
    {
        public bool visible = true;
        public abstract void Render(Settings settings);
        public abstract override string ToString();
        public abstract AxisLimits2D GetLimits();
        public abstract int GetPointCount();
        public abstract LegendItem[] GetLegendItems();
    }
}
