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
    /// The Crosshair plot type draws a vertical and horizontal line to label a point
    /// on the plot and displays the coordinates of that point in labels that overlap
    /// the axis tick labels. 
    /// 
    /// This plot type is typically used in combination with
    /// MouseMove events to track the location of the mouse and/or with plot types that
    /// have GetPointNearest() methods.
    /// </summary>
    public class Crosshair : IPlottable
    {
        public bool IsVisible { get; set; } = true;
        public int XAxisIndex { get; set; } = 0;
        public int YAxisIndex { get; set; } = 0;

        public readonly HLine HorizontalLine = new();

        public readonly VLine? VerticalLine = new();

        /// <summary>
        /// X position (axis units) of the vertical line
        /// </summary>
        public double X { get => VerticalLine!.X; set => VerticalLine!.X = value; }

        /// <summary>
        /// X position (axis units) of the horizontal line
        /// </summary>
        public double Y { get => HorizontalLine.Y; set => HorizontalLine.Y = value; }

        /// <summary>
        /// Sets style for horizontal and vertical lines
        /// </summary>
        public LineStyle LineStyle
        {
            set
            {
                HorizontalLine.LineStyle = value;
                if (VerticalLine != null)
                {
                    VerticalLine.LineStyle = value;
                }
            }
            [Obsolete("The get method only remain for the compatibility. Get HorizontalLine.LineStyle and VerticalLine.LineStyle instead.")]
            get => HorizontalLine.LineStyle;
        }

        /// <summary>
        /// Sets the line width for vertical and horizontal lines
        /// </summary>
        public float LineWidth
        {
            set
            {
                HorizontalLine.LineWidth = value;
                if (VerticalLine != null)
                {
                    VerticalLine.LineWidth = value;
                }
            }
            [Obsolete("The get method only remain for the compatibility. Get HorizontalLine.LineWidth and VerticalLine.LineWidth instead.")]
            get => HorizontalLine.LineWidth;
        }

        /// <summary>
        /// Sets font of the position labels for horizontal and vertical lines
        /// </summary>
        public Font LabelFont
        {
            set
            {
                HorizontalLine.PositionLabelFont = value;
                if (VerticalLine != null)
                {
                    VerticalLine.PositionLabelFont = value;
                }
            }
            [Obsolete("The get method only remain for the compatibility. Get HorizontalLine.PositionLabelFont and VerticalLine.PositionLabelFont instead.")]
            get => HorizontalLine.PositionLabelFont;
        }

        /// <summary>
        /// Sets background color of the position labels for horizontal and vertical lines
        /// </summary>
        public Color LabelBackgroundColor
        {
            set
            {
                HorizontalLine.PositionLabelBackground = value;
                if (VerticalLine != null)
                {
                    VerticalLine.PositionLabelBackground = value;
                }
            }
            [Obsolete("The get method only remain for the compatibility. Get HorizontalLine.PositionLabelBackground and VerticalLine.PositionLabelBackground instead.")]
            get => HorizontalLine.PositionLabelBackground;
        }

        /// <summary>
        /// Sets visibility of the text labels for each line drawn over the axis
        /// </summary>
        public bool PositionLabel
        {
            set
            {
                HorizontalLine.PositionLabel = value;
                if (VerticalLine != null)
                {
                    VerticalLine.PositionLabel = value;
                }
            }
        }

        /// <summary>
        /// Sets color for horizontal and vertical lines and their position label backgrounds
        /// </summary>
        public Color Color
        {
            set
            {
                HorizontalLine.Color = value;
                if (VerticalLine != null)
                {
                    VerticalLine.Color = value;
                }
                HorizontalLine.PositionLabelBackground = value;
                if (VerticalLine != null)
                {
                    VerticalLine.PositionLabelBackground = value;
                }
            }
        }

        public Crosshair()
        {
            LineStyle = LineStyle.Dash;
            LineWidth = 1;
            Color = Color.FromArgb(200, Color.Red);
            PositionLabel = true;
        }

        public AxisLimits GetAxisLimits() => new(double.NaN, double.NaN, double.NaN, double.NaN);

        public LegendItem[]? GetLegendItems() => null;

        public void ValidateData(bool deep = false) { }

        public void Render(PlotDimensions dims, Bitmap bmp, bool lowQuality = false)
        {
            if (IsVisible == false)
            {
                return;
            }

            HorizontalLine.Render(dims, bmp, lowQuality);
            VerticalLine?.Render(dims, bmp, lowQuality);
        }

        [Obsolete("Use VerticalLine.PositionFormatter()")]
        public bool IsDateTimeX
        {
            get => _isDateTimeX;
            set
            {
                _isDateTimeX = value;
                if (VerticalLine != null)
                {
                    VerticalLine.PositionFormatter = value
                        ? position => DateTime.FromOADate(position).ToString(_stringFormatX)
                        : position => position.ToString(_stringFormatX);
                }
            }
        }

        [Obsolete]
        private bool _isDateTimeX;

        [Obsolete("Use VerticalLine.PositionFormatter()")]
        public string StringFormatX
        {
            get => _stringFormatX;
            set
            {
                _stringFormatX = value;
                if (VerticalLine != null)
                {
                    VerticalLine.PositionFormatter = _isDateTimeX ? position => DateTime.FromOADate(position).ToString(_stringFormatX) : position => position.ToString(_stringFormatX);
                }
            }
        }

        [Obsolete]
        private string _stringFormatX = "F2";

        [Obsolete("Use VerticalLine.IsVisible")]
        public bool IsVisibleX
        {
            get => VerticalLine!.IsVisible;
            set => VerticalLine!.IsVisible = value;
        }

        [Obsolete("Use HorizontalLine.PositionFormatter()")]
        public bool IsDateTimeY
        {
            get => _isDateTimeY;
            set
            {
                _isDateTimeY = value;
                HorizontalLine.PositionFormatter = value ?
                    position => DateTime.FromOADate(position).ToString(_stringFormatY) :
                    (position) => position.ToString(_stringFormatY);
            }
        }

        [Obsolete]
        private bool _isDateTimeY;

        [Obsolete("Use HorizontalLine.PositionFormat()")]
        public string StringFormatY
        {
            get => _stringFormatY;
            set
            {
                _stringFormatY = value;
                HorizontalLine.PositionFormatter = _isDateTimeY ?
                    position => DateTime.FromOADate(position).ToString(_stringFormatY) :
                    position => position.ToString(_stringFormatY);
            }
        }

        [Obsolete]
        private string _stringFormatY = "F2";

        [Obsolete("Use HorizontalLine.IsVisible")]
        public bool IsVisibleY
        {
            get => HorizontalLine.IsVisible;
            set => HorizontalLine.IsVisible = value;
        }
    }
}
