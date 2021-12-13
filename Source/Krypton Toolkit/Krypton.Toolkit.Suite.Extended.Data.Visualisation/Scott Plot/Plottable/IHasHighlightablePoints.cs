#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    interface IHasHighlightablePoints
    {
        (double x, double y, int index) HighlightPoint(int index);
        (double x, double y, int index) HighlightPointNearestX(double x);
        (double x, double y, int index) HighlightPointNearestY(double y);
        (double x, double y, int index) HighlightPointNearest(double x, double y);
        void HighlightClear();
    }
}
