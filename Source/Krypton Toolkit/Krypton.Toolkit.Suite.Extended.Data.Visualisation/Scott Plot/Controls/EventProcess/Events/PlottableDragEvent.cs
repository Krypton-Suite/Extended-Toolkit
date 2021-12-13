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
    /// This event describes what happens when a draggable plottable (like an axis line)
    /// has been moved from its initial position. This event places the plottable of interest
    /// at the current mouse position.
    /// This is typically called on MouseMove events while left-click-dragging a draggable plottable.
    /// </summary>
    public class PlottableDragEvent : IUIEvent
    {
        private readonly float X;
        private readonly float Y;
        private readonly IDraggable PlottableBeingDragged;
        private readonly Plot Plot;
        private readonly bool ShiftDown;
        private readonly Configuration Configuration;
        public RenderType RenderType => Configuration.QualityConfiguration.MouseInteractiveDragged;

        public PlottableDragEvent(float x, float y, bool shiftDown, IDraggable plottable, Plot plt, Configuration config)
        {
            X = x;
            Y = y;
            ShiftDown = shiftDown;
            Plot = plt;
            PlottableBeingDragged = plottable;
            Configuration = config;
        }

        public void ProcessEvent()
        {
            double xCoord = Plot.GetCoordinateX(X);
            double yCoord = Plot.GetCoordinateY(Y);
            PlottableBeingDragged.DragTo(xCoord, yCoord, fixedSize: ShiftDown);
        }
    }
}