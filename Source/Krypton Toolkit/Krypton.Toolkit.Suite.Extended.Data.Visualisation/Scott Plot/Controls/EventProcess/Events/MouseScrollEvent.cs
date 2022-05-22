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
    /// This event describes a zoom operation performed by scrolling the mouse wheel.
    /// </summary>
    public class MouseScrollEvent : IUIEvent
    {
        private readonly float X;
        private readonly float Y;
        private readonly bool ScrolledUp;
        private readonly Configuration Configuration;
        private readonly Settings Settings;
        public RenderType RenderType => Configuration.QualityConfiguration.MouseWheelScrolled;

        public MouseScrollEvent(float x, float y, bool scrolledUp, Configuration config, Settings settings)
        {
            X = x;
            Y = y;
            ScrolledUp = scrolledUp;
            Configuration = config;
            Settings = settings;
        }

        public void ProcessEvent()
        {
            double increment = 1.0 + Configuration.ScrollWheelZoomFraction;
            double decrement = 1.0 - Configuration.ScrollWheelZoomFraction;

            double xFrac = ScrolledUp ? increment : decrement;
            double yFrac = ScrolledUp ? increment : decrement;

            if (Configuration.LockHorizontalAxis)
                xFrac = 1;
            if (Configuration.LockVerticalAxis)
                yFrac = 1;

            Settings.AxesZoomTo(xFrac, yFrac, X, Y);
        }
    }
}