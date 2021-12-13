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
    /// A "renderable" is any object which can be drawn on the figure.
    /// </summary>
    public interface IRenderable
    {
        bool IsVisible { get; set; }
        void Render(PlotDimensions dims, Bitmap bmp, bool lowQuality = false);
    }
}
