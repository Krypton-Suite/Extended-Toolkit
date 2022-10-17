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
    /// Indicates a plottable has data distributed along both axes
    /// and can return the X/Y location of the point nearest a given X/Y location.
    /// </summary>
    public interface IHasPoints : IHasPointsGeneric<double, double>
    {
    }

    /// <summary>
    /// Indicates a plottable has data distributed along the horizontal axis 
    /// and can return the X/Y location of the point nearest a given X value.
    /// </summary>
    public interface IHasPointsGenericX<TX, TY>
    {
        (TX x, TY y, int index) GetPointNearestX(TX x);
    }

    /// <summary>
    /// Indicates a plottable has data distributed along the vertical axis 
    /// and can return the X/Y location of the point nearest a given Y value.
    /// </summary>
    public interface IHasPointsGenericY<TX, TY>
    {
        (TX x, TY y, int index) GetPointNearestY(TY y);
    }

    /// <summary>
    /// Indicates a plottable has data distributed along both axes
    /// and can return the X/Y location of the point nearest a given X/Y location.
    /// </summary>
    public interface IHasPointsGeneric<TX, TY> : IHasPointsGenericX<TX, TY>, IHasPointsGenericY<TX, TY>
    {
        (TX x, TY y, int index) GetPointNearest(TX x, TY y, TX xyRatio);
    }
}
