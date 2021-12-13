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
    /// This event describes what happens when the mouse button is lifted after 
    /// middle-click-dragging a rectangle to zoom into. The coordinates of that rectangle
    /// are calculated, and the plot's axis limits are adjusted accordingly.
    /// </summary>
    public class ApplyZoomRectangleEvent : IUIEvent
    {
        private readonly float X;
        private readonly float Y;
        private readonly Configuration Configuration;
        private readonly ScottPlot.Settings Settings;
        private readonly Plot Plot;
        public RenderType RenderType => Configuration.QualityConfiguration.MouseInteractiveDropped;

        public ApplyZoomRectangleEvent(float x, float y, Configuration config, ScottPlot.Settings settings, Plot plt)
        {
            X = x;
            Y = y;
            Configuration = config;
            Settings = settings;
            Plot = plt;
        }

        public void ProcessEvent()
        {
            Settings.RecallAxisLimits();

            var originalLimits = Plot.GetAxisLimits();

            Settings.MouseZoomRect(X, Y, finalize: true);

            if (Configuration.LockHorizontalAxis)
                Plot.SetAxisLimitsX(originalLimits.XMin, originalLimits.XMax);

            if (Configuration.LockVerticalAxis)
                Plot.SetAxisLimitsY(originalLimits.YMin, originalLimits.YMax);
        }
    }
}