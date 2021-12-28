﻿#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
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

        public readonly VLine VerticalLine = new();

        /// <summary>
        /// X position (axis units) of the vertical line
        /// </summary>
        public double X { get => VerticalLine.X; set => VerticalLine.X = value; }

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
                VerticalLine.LineStyle = value;
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
                VerticalLine.LineWidth = value;
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
                VerticalLine.PositionLabelFont = value;
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
                VerticalLine.PositionLabelBackground = value;
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
                VerticalLine.PositionLabel = value;
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
                VerticalLine.Color = value;
                HorizontalLine.PositionLabelBackground = value;
                VerticalLine.PositionLabelBackground = value;
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

        public LegendItem[] GetLegendItems() => null;

        public void ValidateData(bool deep = false) { }

        public void Render(PlotDimensions dims, Bitmap bmp, bool lowQuality = false)
        {
            if (IsVisible == false)
                return;

            HorizontalLine.Render(dims, bmp, lowQuality);
            VerticalLine.Render(dims, bmp, lowQuality);
        }

        [Obsolete("Use VerticalLine.PositionFormatter()")]
        public bool IsDateTimeX
        {
            get => isDateTimeX;
            set
            {
                isDateTimeX = value;
                VerticalLine.PositionFormatter = value ?
                    position => DateTime.FromOADate(position).ToString(stringFormatX) :
                    position => position.ToString(stringFormatX);
            }
        }

        [Obsolete]
        private bool isDateTimeX = false;

        [Obsolete("Use VerticalLine.PositionFormatter()")]
        public string StringFormatX
        {
            get => stringFormatX;
            set
            {
                stringFormatX = value;
                VerticalLine.PositionFormatter = isDateTimeX ?
                    position => DateTime.FromOADate(position).ToString(stringFormatX) :
                    position => position.ToString(stringFormatX);
            }
        }

        [Obsolete]
        private string stringFormatX = "F2";

        [Obsolete("Use VerticalLine.IsVisible")]
        public bool IsVisibleX
        {
            get => VerticalLine.IsVisible;
            set => VerticalLine.IsVisible = value;
        }

        [Obsolete("Use HorizontalLine.PositionFormatter()")]
        public bool IsDateTimeY
        {
            get => isDateTimeY;
            set
            {
                isDateTimeY = value;
                HorizontalLine.PositionFormatter = value ?
                    position => DateTime.FromOADate(position).ToString(stringFormatY) :
                    (position) => position.ToString(stringFormatY);
            }
        }

        [Obsolete]
        private bool isDateTimeY = false;

        [Obsolete("Use HorizontalLine.PositionFormat()")]
        public string StringFormatY
        {
            get => stringFormatY;
            set
            {
                stringFormatY = value;
                HorizontalLine.PositionFormatter = isDateTimeY ?
                    position => DateTime.FromOADate(position).ToString(stringFormatY) :
                    position => position.ToString(stringFormatY);
            }
        }

        [Obsolete]
        private string stringFormatY = "F2";

        [Obsolete("Use HorizontalLine.IsVisible")]
        public bool IsVisibleY
        {
            get => HorizontalLine.IsVisible;
            set => HorizontalLine.IsVisible = value;
        }
    }
}
