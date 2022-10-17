#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
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