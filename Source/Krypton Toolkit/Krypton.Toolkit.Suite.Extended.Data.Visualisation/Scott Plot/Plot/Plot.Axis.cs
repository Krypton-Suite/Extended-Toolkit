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
    public partial class Plot
    {
        #region shortcuts: primary axes

        /// <summary>
        /// Axis on the bottom edge of the plot
        /// </summary>
        public Axis XAxis => settings.XAxis;

        /// <summary>
        /// Axis on the top edge of the plot
        /// </summary>
        public Axis XAxis2 => settings.XAxis2;

        /// <summary>
        /// Axis on the left edge of the plot
        /// </summary>
        public Axis YAxis => settings.YAxis;

        /// <summary>
        /// Axis on the right edge of the plot
        /// </summary>
        public Axis YAxis2 => settings.YAxis2;

        #endregion

        #region shortcuts: axis label, tick, and grid

        /// <summary>
        /// Set the label for the vertical axis to the right of the plot (XAxis)
        /// </summary>
        /// <param name="label">new text</param>
        public void XLabel(string label) => XAxis.Label(label);

        /// <summary>
        /// Set the label for the vertical axis to the right of the plot (YAxis2)
        /// </summary>
        /// <param name="label">new text</param>
        public void YLabel(string label) => YAxis.Label(label);

        /// <summary>
        /// Set the label for the horizontal axis above the plot (XAxis2)
        /// </summary>
        /// <param name="label">new text</param>
        /// <param name="bold">controls font weight</param>
        public void Title(string label, bool bold = true) => XAxis2.Label(label, bold: bold);

        /// <summary>
        /// Configure color and visibility of the frame that outlines the data area.
        /// Note that the axis lines of all 4 primary axes touch each other, 
        /// giving the appearance of a rectangle framing the data area.
        /// This method allows the user to customize these lines as a group or individually.
        /// </summary>
        /// <param name="visible">visibility of the frames for the 4 primary axes</param>
        /// <param name="color">color for the 4 primary axis lines</param>
        /// <param name="left">visibility of the left axis (YAxis) line</param>
        /// <param name="right">visibility of the right axis (YAxis2) line</param>
        /// <param name="bottom">visibility of the bottom axis (XAxis) line</param>
        /// <param name="top">visibility of the top axis (XAxis2) line</param>
        [Obsolete("This method has been deprecated. Visibility and customization can be controlled with methods like YAxis.Hide(), YAxis.Line(), etc.", true)]
        public void Frame(bool? visible = null, Color? color = null, bool? left = null, bool? right = null, bool? bottom = null, bool? top = null)
        {
            var primaryAxes = new Axis[] { XAxis, XAxis2, YAxis, YAxis2 };

            foreach (var axis in primaryAxes)
            {
                axis.Line(visible, color);
            }

            YAxis.Line(visible: left);
            YAxis2.Line(visible: right);
            XAxis.Line(visible: bottom);
            XAxis2.Line(visible: top);
        }

        /// <summary>
        /// Give the plot a frameless appearance by hiding all axes.
        /// Axes are hidden by making them invisible and setting their size to zero.
        /// This causes the data area to go right up to the edge of the plot.
        /// </summary>
        public void Frameless(bool hideAllAxes = true)
        {
            foreach (var axis in settings.Axes)
            {
                axis.Hide(hideAllAxes);
            }
        }

        /// <summary>
        /// Control visibility of axes.
        /// </summary>
        [Obsolete("This method is deprecated. Call Frameless() to control axis visibility.")]
        public void Frame(bool enable) => Frameless(!enable);

        /// <summary>
        /// Customize basic options for the primary X and Y axes. 
        /// Call XAxis.Grid() and YAxis.Grid() to further customize grid settings.
        /// </summary>
        /// <param name="enable">sets visibility of X and Y grid lines</param>
        /// <param name="color">sets color of of X and Y grid lines</param>
        /// <param name="lineStyle">defines the style for X and Y grid lines</param>
        public void Grid(bool? enable = null, Color? color = null, LineStyle? lineStyle = null)
        {
            if (enable.HasValue)
            {
                XAxis.Grid(enable.Value);
                YAxis.Grid(enable.Value);
            }

            XAxis.MajorGrid(color: color, lineStyle: lineStyle);
            YAxis.MajorGrid(color: color, lineStyle: lineStyle);
        }

        /// <summary>
        /// Set padding around the data area by defining the minimum size and padding for all axes
        /// </summary>
        /// <param name="left">YAxis size (in pixels) that defines the area to the left of the plot</param>
        /// <param name="right">YAxis2 size (in pixels) that defines the area to the right of the plot</param>
        /// <param name="bottom">XAxis size (in pixels) that defines the area to the bottom of the plot</param>
        /// <param name="top">XAxis2 size (in pixels) that defines the area to the top of the plot</param>
        /// <param name="padding">Customize the default padding between axes and the edge of the plot</param>
        public void Layout(float? left = null, float? right = null, float? bottom = null, float? top = null, float? padding = 5)
        {
            YAxis.Layout(padding, left);
            YAxis2.Layout(padding, right);
            XAxis.Layout(padding, bottom);
            XAxis2.Layout(padding, top);
        }

        /// <summary>
        /// Adjust this axis layout based on the layout of a source plot
        /// </summary>
        /// <param name="sourcePlot">plot to use for layout reference</param>
        /// <param name="horizontal">if true, horizontal layout will be matched</param>
        /// <param name="vertical">if true, vertical layout will be matched</param>
        public void MatchLayout(Plot sourcePlot, bool horizontal = true, bool vertical = true)
        {
            var sourceSettings = sourcePlot.GetSettings(false);

            if (horizontal)
            {
                YAxis.SetSizeLimit(sourceSettings.YAxis.GetSize());
                YAxis2.SetSizeLimit(sourceSettings.YAxis2.GetSize());
            }

            if (vertical)
            {
                XAxis.SetSizeLimit(sourceSettings.XAxis.GetSize());
                XAxis2.SetSizeLimit(sourceSettings.XAxis2.GetSize());
            }
        }

        /// <summary>
        /// Get the axis limits for the given plot and apply them to this plot
        /// </summary>
        public void MatchAxis(Plot sourcePlot, bool horizontal = true, bool vertical = true)
        {
            var sourceLimits = sourcePlot.GetAxisLimits();

            AxisAuto();

            if (horizontal)
            {
                SetAxisLimitsX(sourceLimits.XMin, sourceLimits.XMax);
            }

            if (vertical)
            {
                SetAxisLimitsY(sourceLimits.YMin, sourceLimits.YMax);
            }
        }

        /// <summary>
        /// Manually define X axis tick labels using consecutive integer positions (0, 1, 2, etc.)
        /// </summary>
        /// <param name="labels">new tick labels for the X axis</param>
        public void XTicks(string[] labels) => XTicks(DataGen.Consecutive(labels.Length), labels);

        /// <summary>
        /// Manually define X axis tick positions and labels
        /// </summary>
        /// <param name="positions">positions on the X axis</param>
        /// <param name="labels">new tick labels for the X axis</param>
        public void XTicks(double[] positions = null, string[] labels = null) =>
            XAxis.ManualTickPositions(positions, labels);

        /// <summary>
        /// Manually define Y axis tick labels using consecutive integer positions (0, 1, 2, etc.)
        /// </summary>
        /// <param name="labels">new tick labels for the Y axis</param>
        public void YTicks(string[] labels) => YTicks(DataGen.Consecutive(labels.Length), labels);

        /// <summary>
        /// Manually define Y axis tick positions and labels
        /// </summary>
        /// <param name="positions">positions on the Y axis</param>
        /// <param name="labels">new tick labels for the Y axis</param>
        public void YTicks(double[] positions = null, string[] labels = null) =>
            YAxis.ManualTickPositions(positions, labels);

        /// <summary>
        /// Set the culture to use for number-to-string converstion for tick labels of all axes.
        /// </summary>
        /// <param name="culture">standard culture</param>
        public void SetCulture(CultureInfo culture)
        {
            foreach (var axis in settings.Axes)
            {
                axis.SetCulture(culture);
            }
        }

        /// <summary>
        /// Set the culture to use for number-to-string converstion for tick labels of all axes.
        /// This overload allows you to manually define every format string, 
        /// allowing extensive customization of number and date formatting.
        /// </summary>
        /// <param name="shortDatePattern"></param>
        /// <param name="decimalSeparator">Separates the decimal digits</param>
        /// <param name="numberGroupSeparator">Separates large numbers ito groups of digits for readability</param>
        /// <param name="decimalDigits">Number of digits after the numberDecimalSeparator</param>
        /// <param name="numberNegativePattern">Appearance of negative numbers</param>
        /// <param name="numberGroupSizes">Sizes of decimal groups which are separated by the numberGroupSeparator</param>
        public void SetCulture(string shortDatePattern = null, string decimalSeparator = null, string numberGroupSeparator = null,
            int? decimalDigits = null, int? numberNegativePattern = null, int[] numberGroupSizes = null)
        {
            foreach (var axis in settings.Axes)
            {
                axis.SetCulture(shortDatePattern, decimalSeparator, numberGroupSeparator, decimalDigits, numberNegativePattern, numberGroupSizes);
            }
        }

        #endregion

        #region Axis creation

        /// <summary>
        /// Create and return an additional axis
        /// </summary>
        /// <param name="edge">Edge of the plot the new axis will belong to</param>
        /// <param name="axisIndex">Only plottables with the same axis index will use this axis</param>
        /// <param name="title">defualt label to use for the axis</param>
        /// <param name="color">defualt color to use for the axis</param>
        /// <returns>The axis that was just created and added to the plot. You can further customize it by interacting with it.</returns>
        public Axis AddAxis(Edge edge, int axisIndex, string title = null, Color? color = null)
        {
            if (axisIndex <= 1)
            {
                throw new ArgumentException("The default axes already occupy indexes 0 and 1. Additional axes require higher indexes.");
            }

            Axis axis;

            if (edge == Edge.Left)
            {
                axis = new AdditionalLeftAxis(axisIndex, title);
            }
            else if (edge == Edge.Right)
            {
                axis = new AdditionalRightAxis(axisIndex, title);
            }
            else if (edge == Edge.Bottom)
            {
                axis = new AdditionalBottomAxis(axisIndex, title);
            }
            else if (edge == Edge.Top)
            {
                axis = new AdditionalTopAxis(axisIndex, title);
            }
            else
            {
                throw new NotImplementedException("unsupported edge");
            }

            if (color.HasValue)
            {
                axis.Color(color.Value);
            }

            settings.Axes.Add(axis);
            return axis;
        }

        #endregion

        #region coordinate/pixel conversions

        /// <summary>
        /// Return the coordinate (in coordinate space) for the given pixel
        /// </summary>
        /// <param name="xPixel">horizontal pixel location</param>
        /// <param name="yPixel">vertical pixel location</param>
        /// <returns>point in coordinate space</returns>
        public (double x, double y) GetCoordinate(float xPixel, float yPixel) =>
            (settings.XAxis.Dims.GetUnit(xPixel), settings.YAxis.Dims.GetUnit(yPixel));

        /// <summary>
        /// Return the X position (in coordinate space) for the given pixel column
        /// </summary>
        /// <param name="xPixel">horizontal pixel location</param>
        /// <returns>horizontal position in coordinate space</returns>
        public double GetCoordinateX(float xPixel) => settings.XAxis.Dims.GetUnit(xPixel);

        /// <summary>
        /// Return the Y position (in coordinate space) for the given pixel row
        /// </summary>
        /// <param name="yPixel">vertical pixel location</param>
        /// <returns>vertical position in coordinate space</returns>
        public double GetCoordinateY(float yPixel) => settings.YAxis.Dims.GetUnit(yPixel);

        /// <summary>
        /// Return the pixel for the given point in coordinate space
        /// </summary>
        /// <param name="x">horizontal coordinate</param>
        /// <param name="y">vertical coordinate</param>
        /// <returns>pixel location</returns>
        public (float xPixel, float yPixel) GetPixel(double x, double y) =>
            (settings.XAxis.Dims.GetPixel(x), settings.YAxis.Dims.GetPixel(y));

        /// <summary>
        /// Return the horizontal pixel location given position in coordinate space
        /// </summary>
        /// <param name="x">horizontal coordinate</param>
        /// <returns>horizontal pixel position</returns>
        public float GetPixelX(double x) => settings.XAxis.Dims.GetPixel(x);

        /// <summary>
        /// Return the vertical pixel location given position in coordinate space
        /// </summary>
        /// <param name="y">vertical coordinate</param>
        /// <returns>vertical pixel position</returns>
        public float GetPixelY(double y) => settings.YAxis.Dims.GetPixel(y);

        #endregion

        #region axis limits: get and set

        /// <summary>
        /// Returns the current limits for a given pair of axes.
        /// </summary>
        /// <param name="xAxisIndex">which axis index to reference</param>
        /// <param name="yAxisIndex">which axis index to reference</param>
        /// <returns>current limits</returns>
        public AxisLimits GetAxisLimits(int xAxisIndex = 0, int yAxisIndex = 0)
        {
            (double xMin, double xMax) = settings.GetXAxis(xAxisIndex).Dims.RationalLimits();
            (double yMin, double yMax) = settings.GetYAxis(yAxisIndex).Dims.RationalLimits();
            return new AxisLimits(xMin, xMax, yMin, yMax);
        }

        /// <summary>
        /// Set limits for the a given pair of axes
        /// </summary>
        /// <param name="xMin">lower limit of the horizontal axis</param>
        /// <param name="xMax">upper limit of the horizontal axis</param>
        /// <param name="yMin">lower limit of the vertical axis</param>
        /// <param name="yMax">upper limit of the vertical axis</param>
        /// <param name="xAxisIndex">index of the axis the horizontal limits apply to</param>
        /// <param name="yAxisIndex">index of the axis the vertical limits apply to</param>
        public void SetAxisLimits(
            double? xMin = null, double? xMax = null,
            double? yMin = null, double? yMax = null,
            int xAxisIndex = 0, int yAxisIndex = 0)
        {
            bool notAllAxesDefined = xMin is null || xMax is null || yMin is null || yMax is null;
            if (notAllAxesDefined)
            {
                settings.AxisAutoUnsetAxes();
            }

            settings.AxisSet(xMin, xMax, yMin, yMax, xAxisIndex, yAxisIndex);
        }

        /// <summary>
        /// Set limits for the primary X axis
        /// </summary>
        /// <param name="xMin">lower limit of the horizontal axis</param>
        /// <param name="xMax">upper limit of the horizontal axis</param>
        public void SetAxisLimitsX(double xMin, double xMax) => SetAxisLimits(xMin, xMax, null, null);

        /// <summary>
        /// Set limits for the primary Y axis
        /// </summary>
        /// <param name="yMin">lower limit of the vertical axis</param>
        /// <param name="yMax">upper limit of the vertical axis</param>
        public void SetAxisLimitsY(double yMin, double yMax) => SetAxisLimits(null, null, yMin, yMax);

        /// <summary>
        /// Set limits for a pair of axes
        /// </summary>
        /// <param name="limits">new limits</param>
        /// <param name="xAxisIndex">index of the axis the horizontal limits apply to</param>
        /// <param name="yAxisIndex">index of the axis the vertical limits apply to</param>
        public void SetAxisLimits(AxisLimits limits, int xAxisIndex = 0, int yAxisIndex = 0) =>
            settings.AxisSet(limits, xAxisIndex, yAxisIndex);

        /// <summary>
        /// Set maximum outer limits beyond which the plot cannot be zoomed-out or panned.
        /// </summary>
        [Obsolete("use SetOuterViewLimits() or SetInnerViewLimits()", true)]
        public void SetViewLimits(
            double xMin = double.NegativeInfinity, double xMax = double.PositiveInfinity,
            double yMin = double.NegativeInfinity, double yMax = double.PositiveInfinity) =>
            SetOuterViewLimits(xMin, xMax, yMin, yMax);

        /// <summary>
        /// Set maximum outer limits beyond which the plot cannot be zoomed-out or panned.
        /// </summary>
        public void SetOuterViewLimits(
            double xMin = double.NegativeInfinity, double xMax = double.PositiveInfinity,
            double yMin = double.NegativeInfinity, double yMax = double.PositiveInfinity,
            int xAxisIndex = 0, int yAxisIndex = 0)
        {
            settings.GetXAxis(xAxisIndex).Dims.SetBoundsOuter(xMin, xMax);
            settings.GetYAxis(yAxisIndex).Dims.SetBoundsOuter(yMin, yMax);
        }

        /// <summary>
        /// Set minimum innter limits which will always be visible on the plot.
        /// </summary>
        public void SetInnerViewLimits(
            double xMin = double.NegativeInfinity, double xMax = double.PositiveInfinity,
            double yMin = double.NegativeInfinity, double yMax = double.PositiveInfinity,
            int xAxisIndex = 0, int yAxisIndex = 0)
        {
            settings.GetXAxis(xAxisIndex).Dims.SetBoundsInner(xMin, xMax);
            settings.GetYAxis(yAxisIndex).Dims.SetBoundsInner(yMin, yMax);
        }

        #endregion

        #region axis limits: fit to plottable data

        /// <summary>
        /// Auto-scale the axis limits to fit the data. This function is an alias for AxisAuto().
        /// </summary>
        /// <param name="x">horizontal margin in the range [0, 1]</param>
        /// <param name="y">vertical margin in the range [0, 1]</param>
        /// <returns>Current default margins for automatic axis scaling</returns>
        public (double x, double y) Margins(double? x = null, double? y = null)
        {
            return Margins(x, y, 0, 0);
        }

        /// <summary>
        /// Auto-scale the axis limits to fit the data. This function is an alias for AxisAuto().
        /// This overload is for multi-axis plots (plots with multiple X and Y axes) and will only adjust the specified axes.
        /// </summary>
        /// <param name="x">horizontal margin in the range [0, 1]</param>
        /// <param name="y">vertical margin in the range [0, 1]</param>
        /// <param name="xAxisIndex">Only adjust the specified axis (for plots with multiple X axes)</param>
        /// <param name="yAxisIndex">Only adjust the specified axis (for plots with multiple Y axes)</param>
        /// <returns>Current default margins for automatic axis scaling</returns>
        public (double x, double y) Margins(double? x, double? y, int xAxisIndex, int yAxisIndex)
        {
            AxisAuto(x, y, xAxisIndex, yAxisIndex);
            return (settings.MarginsX, settings.MarginsY);
        }

        /// <summary>
        /// Automatically set axis limits to fit the data.
        /// </summary>
        /// <param name="horizontalMargin">Extra space (fraction) to add to the left and right of the limits of the data</param>
        /// <param name="verticalMargin">Extra space (fraction) to add above and below the limits of the data</param>
        public void AxisAuto(double? horizontalMargin = null, double? verticalMargin = null)
        {
            AxisAuto(horizontalMargin, verticalMargin, xAxisIndex: 0, yAxisIndex: 0);
        }

        /// <summary>
        /// Automatically set axis limits to fit the data.
        /// This overload is designed for multi-axis plots (with multiple X axes or multiple Y axes).
        /// </summary>
        /// <param name="horizontalMargin">Extra space (fraction) to add to the left and right of the limits of the data</param>
        /// <param name="verticalMargin">Extra space (fraction) to add above and below the limits of the data</param>
        /// <param name="xAxisIndex">Only adjust the specified axis (for plots with multiple X axes)</param>
        /// <param name="yAxisIndex">Only adjust the specified axis (for plots with multiple Y axes)</param>
        public void AxisAuto(double? horizontalMargin, double? verticalMargin, int xAxisIndex, int yAxisIndex)
        {
            settings.MarginsX = horizontalMargin ?? settings.MarginsX;
            settings.MarginsY = verticalMargin ?? settings.MarginsY;

            settings.AxisAutoX(xAxisIndex, settings.MarginsX);
            settings.AxisAutoY(yAxisIndex, settings.MarginsY);
        }

        /// <summary>
        /// Automatically adjust axis limits to fit the data
        /// </summary>
        /// <param name="margin">amount of space to the left and right of the data (as a fraction of its width)</param>
        public void AxisAutoX(double margin = .05)
        {
            // TODO: improve support for non-primary axis indexes

            if (settings.Plottables.Count == 0)
            {
                SetAxisLimits(yMin: -10, yMax: 10);
                return;
            }

            AxisLimits originalLimits = GetAxisLimits();
            AxisAuto(horizontalMargin: margin);
            SetAxisLimits(yMin: originalLimits.YMin, yMax: originalLimits.YMax);
        }

        /// <summary>
        /// Automatically adjust axis limits to fit the data (with a little extra margin)
        /// </summary>
        /// <param name="margin">amount of space above and below the data (as a fraction of its height)</param>
        public void AxisAutoY(double margin = .1)
        {
            // TODO: improve support for non-primary axis indexes

            if (settings.Plottables.Count == 0)
            {
                SetAxisLimits(xMin: -10, xMax: 10);
                return;
            }

            AxisLimits originalLimits = GetAxisLimits();
            AxisAuto(verticalMargin: margin);
            SetAxisLimits(xMin: originalLimits.XMin, xMax: originalLimits.XMax);
        }

        #endregion

        #region axis limits: scaling

        /// <summary>
        /// Adjust axis limits to achieve a certain pixel scale (units per pixel)
        /// </summary>
        /// <param name="unitsPerPixelX">zoom so 1 pixel equals this many horizontal units in coordinate space</param>
        /// <param name="unitsPerPixelY">zoom so 1 pixel equals this many vertical units in coordinate space</param>
        public void AxisScale(double? unitsPerPixelX = null, double? unitsPerPixelY = null)
        {
            if (unitsPerPixelX != null)
            {
                double spanX = unitsPerPixelX.Value * settings.XAxis.Dims.DataSizePx;
                SetAxisLimits(xMin: settings.XAxis.Dims.Center - spanX / 2, xMax: settings.XAxis.Dims.Center + spanX / 2);
            }

            if (unitsPerPixelY != null)
            {
                double spanY = unitsPerPixelY.Value * settings.YAxis.Dims.DataSizePx;
                SetAxisLimits(xMin: settings.YAxis.Dims.Center - spanY / 2, xMax: settings.YAxis.Dims.Center + spanY / 2);
            }
        }

        /// <summary>
        /// Lock X and Y axis scales (units per pixel) together to protect symmetry of circles and squares
        /// </summary>
        /// <param name="enable">if true, scales are locked such that zooming one zooms the other</param>
        /// <param name="scaleMode">defines behavior for how to adjust axis limits to achieve equal scales</param>
        public void AxisScaleLock(bool enable, EqualScaleMode scaleMode = EqualScaleMode.PreserveSmallest)
        {
            settings.AxisAutoUnsetAxes();
            settings.EqualScaleMode = enable ? scaleMode : EqualScaleMode.Disabled;
            settings.LayoutAuto();
            settings.EnforceEqualAxisScales();
        }

        #endregion

        #region axis limits: pan and zoom

        /// <summary>
        /// Zoom in or out. The amount of zoom is defined as a fraction of the current axis span.
        /// </summary>
        /// <param name="xFrac">horizontal zoom (>1 means zoom in)</param>
        /// <param name="yFrac">vertical zoom (>1 means zoom in)</param>
        /// <param name="zoomToX">if defined, zoom will be centered at this point</param>
        /// <param name="zoomToY">if defined, zoom will be centered at this point</param>
        /// <param name="xAxisIndex">index of the axis to zoom</param>
        /// <param name="yAxisIndex">index of the axis to zoom</param>
        public void AxisZoom(
            double xFrac = 1, double yFrac = 1,
            double? zoomToX = null, double? zoomToY = null,
            int xAxisIndex = 0, int yAxisIndex = 0)
        {
            var xAxis = settings.GetXAxis(xAxisIndex);
            var yAxis = settings.GetYAxis(yAxisIndex);

            if (xAxis.Dims.HasBeenSet == false || yAxis.Dims.HasBeenSet == false)
            {
                settings.AxisAutoAll();
            }

            xAxis.Dims.Zoom(xFrac, zoomToX ?? xAxis.Dims.Center);
            yAxis.Dims.Zoom(yFrac, zoomToY ?? yAxis.Dims.Center);
        }

        /// <summary>
        /// Pan the primary X and Y axis without affecting zoom
        /// </summary>
        /// <param name="dx">horizontal distance to pan (in coordinate units)</param>
        /// <param name="dy">vertical distance to pan (in coordinate units)</param>
        public void AxisPan(double dx = 0, double dy = 0)
        {
            if (!settings.AllAxesHaveBeenSet)
            {
                settings.AxisAutoAll();
            }

            settings.XAxis.Dims.Pan(dx);
            settings.YAxis.Dims.Pan(dy);
        }

        #endregion

        #region obsolete

        [Obsolete("Use SetAxisLimits() and GetAxisLimits()", true)]
        public AxisLimits AxisLimits(int xAxisIndex = 0, int yAxisIndex = 0) => throw new NotImplementedException();

        [Obsolete("use GetCoordinateX()", true)]
        public double CoordinateFromPixelX(float pixelX) => throw new NotImplementedException();

        [Obsolete("use GetCoordinateY()", true)]
        public double CoordinateFromPixelY(float pixelY) => throw new NotImplementedException();

        [Obsolete("use GetCoordinateX()", true)]
        public double CoordinateFromPixelX(double pixelX) => throw new NotImplementedException();

        [Obsolete("use GetCoordinateY()", true)]
        public double CoordinateFromPixelY(double pixelY) => throw new NotImplementedException();

        [Obsolete("use GetCoordinate(), GetCoordinateX() or GetCoordinateY()", true)]
        public PointF CoordinateFromPixel(int pixelX, int pixelY) => throw new NotImplementedException();

        [Obsolete("use GetCoordinate(), GetCoordinateX() or GetCoordinateY()", true)]
        public PointF CoordinateFromPixel(float pixelX, float pixelY) => throw new NotImplementedException();

        [Obsolete("use GetCoordinate(), GetCoordinateX() or GetCoordinateY()", true)]
        public PointF CoordinateFromPixel(double pixelX, double pixelY) => throw new NotImplementedException();

        [Obsolete("use GetCoordinate(), GetCoordinateX() or GetCoordinateY()", true)]
        public PointF CoordinateFromPixel(Point pixel) => throw new NotImplementedException();

        [Obsolete("use GetCoordinate(), GetCoordinateX() or GetCoordinateY()", true)]
        public PointF CoordinateFromPixel(PointF pixel) => throw new NotImplementedException();

        [Obsolete("use GetPixel, GetPixelX(), or GetPixelY()", true)]
        public PointF CoordinateToPixel(PointF location) => throw new NotImplementedException();

        [Obsolete("use GetPixel, GetPixelX(), or GetPixelY()", true)]
        public PointF CoordinateToPixel(double locationX, double locationY) => throw new NotImplementedException();

        [Obsolete("use GetPixelX()", true)]
        public float CoordinateToPixelX(double locationX) => throw new NotImplementedException();

        [Obsolete("use GetPixelY()", true)]
        public float CoordinateToPixelY(double locationY) => throw new NotImplementedException();

        [Obsolete("use GetAxisLimits() and SetAxisLimits()", true)]
        public AxisLimits Axis(double? x1 = null, double? x2 = null, double? y1 = null, double? y2 = null)
            => throw new NotImplementedException();

        [Obsolete("use GetAxisLimits() and SetAxisLimits()", true)]
        public void Axis(double[] axisLimits, int xAxisIndex = 0, int yAxisIndex = 0) => throw new NotImplementedException();

        [Obsolete("use GetAxisLimits() and SetAxisLimits()", true)]
        public double[] Axis(double? x1 = null, double? x2 = null, double? y1 = null, double? y2 = null, double? _ = null) => null;

        [Obsolete("use GetAxisLimits() and SetAxisLimits()", true)]
        public double[] Axis(double[] axisLimits) => null;

        [Obsolete("use GetAxisLimits() and SetAxisLimits()", true)]
        public void Axis(AxisLimits limits, int xAxisIndex = 0, int yAxisIndex = 0) => throw new NotImplementedException();

        [Obsolete("use AxisScaleLock()", true)]
        public bool EqualAxis;

        [Obsolete("Use AxisAuto() or Margins()", true)]
        public double[] AutoAxis() => null;

        [Obsolete("Use AxisAuto() or Margins()", true)]
        public double[] AutoScale() => null;


        [Obsolete("Individual axes (e.g., XAxis and YAxis) have their own tick configuration methods", true)]
        public void Ticks(
            bool? displayTicksX = null,
            bool? displayTicksY = null,
            bool? displayTicksXminor = null,
            bool? displayTicksYminor = null,
            bool? displayTickLabelsX = null,
            bool? displayTickLabelsY = null,
            Color? color = null,
            bool? useMultiplierNotation = null,
            bool? useOffsetNotation = null,
            bool? useExponentialNotation = null,
            bool? dateTimeX = null,
            bool? dateTimeY = null,
            bool? rulerModeX = null,
            bool? rulerModeY = null,
            bool? invertSignX = null,
            bool? invertSignY = null,
            string fontName = null,
            float? fontSize = null,
            float? xTickRotation = null,
            bool? logScaleX = null,
            bool? logScaleY = null,
            string numericFormatStringX = null,
            string numericFormatStringY = null,
            bool? snapToNearestPixel = null,
            int? baseX = null,
            int? baseY = null,
            string prefixX = null,
            string prefixY = null,
            string dateTimeFormatStringX = null,
            string dateTimeFormatStringY = null
            ) => throw new NotImplementedException();

        #endregion
    }
}