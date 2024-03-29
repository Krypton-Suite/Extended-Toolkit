﻿#region MIT License
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
    /// Shaded horizontal region between two X values
    /// </summary>
    public class HSpan : AxisSpan
    {
        public double X1 { get => Position1; set => Position1 = value; }
        public double X2 { get => Position2; set => Position2 = value; }
        public HSpan() : base(true) { }
        public override string ToString() => $"Horizontal span between Y1={X1} and Y2={X2}";
    }

    /// <summary>
    /// Shade the region between two Y values
    /// </summary>
    public class VSpan : AxisSpan
    {
        public double Y1 { get => Position1; set => Position1 = value; }
        public double Y2 { get => Position2; set => Position2 = value; }
        public VSpan() : base(false) { }
        public override string ToString() => $"Vertical span between X1={Y1} and X2={Y2}";
    }

    public abstract class AxisSpan : IPlottable, IDraggable
    {
        // location and orientation
        protected double Position1;
        protected double Position2;
        private double Min => Math.Min(Position1, Position2);
        private double Max => Math.Max(Position1, Position2);
        readonly bool _isHorizontal;

        /// <summary>
        /// If true, AxisAuto() will ignore the position of this span when determining axis limits
        /// </summary>
        public bool IgnoreAxisAuto = false;

        // configuration
        public int XAxisIndex { get; set; } = 0;
        public int YAxisIndex { get; set; } = 0;
        public bool IsVisible { get; set; } = true;
        public Color Color = Color.FromArgb(128, Color.Magenta);
        public string Label;

        // mouse interaction
        public bool DragEnabled { get; set; }
        public bool DragFixedSize { get; set; }
        public double DragLimitMin = double.NegativeInfinity;
        public double DragLimitMax = double.PositiveInfinity;
        public Cursor DragCursor => _isHorizontal ? Cursor.WE : Cursor.NS;

        /// <summary>
        /// This event is invoked after the line is dragged 
        /// </summary>
        public event EventHandler Dragged = delegate { };

        public AxisSpan(bool isHorizontal)
        {
            _isHorizontal = isHorizontal;
        }

        public void ValidateData(bool deep = false)
        {
            if (double.IsNaN(Position1) || double.IsInfinity(Position1))
            {
                throw new InvalidOperationException("position1 must be a valid number");
            }

            if (double.IsNaN(Position2) || double.IsInfinity(Position2))
            {
                throw new InvalidOperationException("position2 must be a valid number");
            }
        }

        public LegendItem[]? GetLegendItems()
        {
            var singleItem = new LegendItem()
            {
                label = Label,
                color = Color,
                markerSize = 0,
                lineWidth = 10
            };
            return new[] { singleItem };
        }

        public AxisLimits GetAxisLimits()
        {
            if (IgnoreAxisAuto)
            {
                return new AxisLimits(double.NaN, double.NaN, double.NaN, double.NaN);
            }

            if (_isHorizontal)
            {
                return new AxisLimits(Min, Max, double.NaN, double.NaN);
            }
            else
            {
                return new AxisLimits(double.NaN, double.NaN, Min, Max);
            }
        }

        private enum Edge { Edge1, Edge2, Neither };
        Edge _edgeUnderMouse = Edge.Neither;

        /// <summary>
        /// Return True if either span edge is within a certain number of pixels (snap) to the mouse
        /// </summary>
        /// <param name="coordinateX">mouse position (coordinate space)</param>
        /// <param name="coordinateY">mouse position (coordinate space)</param>
        /// <param name="snapX">snap distance (pixels)</param>
        /// <param name="snapY">snap distance (pixels)</param>
        /// <returns></returns>
        public bool IsUnderMouse(double coordinateX, double coordinateY, double snapX, double snapY)
        {
            if (_isHorizontal)
            {
                if (Math.Abs(Position1 - coordinateX) <= snapX)
                {
                    _edgeUnderMouse = Edge.Edge1;
                }
                else if (Math.Abs(Position2 - coordinateX) <= snapX)
                {
                    _edgeUnderMouse = Edge.Edge2;
                }
                else
                {
                    _edgeUnderMouse = Edge.Neither;
                }
            }
            else
            {
                if (Math.Abs(Position1 - coordinateY) <= snapY)
                {
                    _edgeUnderMouse = Edge.Edge1;
                }
                else if (Math.Abs(Position2 - coordinateY) <= snapY)
                {
                    _edgeUnderMouse = Edge.Edge2;
                }
                else
                {
                    _edgeUnderMouse = Edge.Neither;
                }
            }

            return _edgeUnderMouse != Edge.Neither;
        }

        /// <summary>
        /// Move the span to a new coordinate in plot space.
        /// </summary>
        /// <param name="coordinateX">new X position</param>
        /// <param name="coordinateY">new Y position</param>
        /// <param name="fixedSize">if True, both edges will be moved to maintain the size of the span</param>
        public void DragTo(double coordinateX, double coordinateY, bool fixedSize)
        {
            if (!DragEnabled)
            {
                return;
            }

            if (_isHorizontal)
            {
                coordinateX = Math.Max(coordinateX, DragLimitMin);
                coordinateX = Math.Min(coordinateX, DragLimitMax);
            }
            else
            {
                coordinateY = Math.Max(coordinateY, DragLimitMin);
                coordinateY = Math.Min(coordinateY, DragLimitMax);
            }

            double sizeBeforeDrag = Position2 - Position1;
            if (_edgeUnderMouse == Edge.Edge1)
            {
                Position1 = _isHorizontal ? coordinateX : coordinateY;
                if (DragFixedSize || fixedSize)
                {
                    Position2 = Position1 + sizeBeforeDrag;
                }
            }
            else if (_edgeUnderMouse == Edge.Edge2)
            {
                Position2 = _isHorizontal ? coordinateX : coordinateY;
                if (DragFixedSize || fixedSize)
                {
                    Position1 = Position2 - sizeBeforeDrag;
                }
            }
            else
            {
                Debug.WriteLine("DragTo() called but no side selected. Call IsUnderMouse() to select a side.");
            }

            // ensure fixed-width spans stay entirely inside the allowable range
            double belowLimit = DragLimitMin - Position1;
            double aboveLimit = Position2 - DragLimitMax;
            if (belowLimit > 0)
            {
                Position1 += belowLimit;
                Position2 += belowLimit;
            }
            if (aboveLimit > 0)
            {
                Position1 -= aboveLimit;
                Position2 -= aboveLimit;
            }

            Dragged(this, EventArgs.Empty);
        }

        private RectangleF GetClippedRectangle(PlotDimensions dims)
        {
            // clip the rectangle to the size of the data area to avoid GDI rendering errors
            float ClippedPixelX(double x) => dims.GetPixelX(Math.Max(dims.XMin, Math.Min(x, dims.XMax)));
            float ClippedPixelY(double y) => dims.GetPixelY(Math.Max(dims.YMin, Math.Min(y, dims.YMax)));

            float left = _isHorizontal ? ClippedPixelX(Min) : dims.DataOffsetX;
            float right = _isHorizontal ? ClippedPixelX(Max) : dims.DataOffsetX + dims.DataWidth;
            float top = _isHorizontal ? dims.DataOffsetY : ClippedPixelY(Max);
            float bottom = _isHorizontal ? dims.DataOffsetY + dims.DataHeight : ClippedPixelY(Min);

            float width = right - left + 1;
            float height = bottom - top + 1;

            return new RectangleF(left, top, width, height);
        }

        public void Render(PlotDimensions dims, Bitmap bmp, bool lowQuality = false)
        {
            using (var gfx = GDI.Graphics(bmp, dims, lowQuality))
            {
                using (var brush = GDI.Brush(Color))
                {
                    RectangleF rect = GetClippedRectangle(dims);
                    gfx.FillRectangle(brush, rect);
                }
            }
        }
    }
}
