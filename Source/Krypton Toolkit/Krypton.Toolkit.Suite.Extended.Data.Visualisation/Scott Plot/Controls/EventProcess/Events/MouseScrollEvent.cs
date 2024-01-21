#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
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
            {
                xFrac = 1;
            }

            if (Configuration.LockVerticalAxis)
            {
                yFrac = 1;
            }

            Settings.AxesZoomTo(xFrac, yFrac, X, Y);
        }
    }
}