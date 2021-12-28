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
    /// This event is called after the mouse button is lifted (typically following panning and zooming).
    /// It assumes all the axis manipulation (panning/zooming) has already been performed,
    /// and the purpose of this event is only to request an immediate high quality render.
    /// </summary>
    public class MouseUpClearRenderEvent : IUIEvent
    {
        private readonly Configuration Configuration;
        public RenderType RenderType => Configuration.QualityConfiguration.MouseInteractiveDropped;

        public MouseUpClearRenderEvent(Configuration config)
        {
            Configuration = config;
        }

        public void ProcessEvent()
        {
        }
    }
}