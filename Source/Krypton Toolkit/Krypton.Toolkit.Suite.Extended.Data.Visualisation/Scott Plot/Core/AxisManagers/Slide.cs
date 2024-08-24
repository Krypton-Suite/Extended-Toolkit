namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    /// <summary>
    /// Slide the view to the right to keep the newest data points in view
    /// </summary>
    public class Slide : IAxisManager
    {
        /// <summary>
        /// Amount of horizontal area to display (in axis units)
        /// </summary>
        public double Width { get; set; } = 1000;

        /// <summary>
        /// Defines the amount of whitespace added to the right of the data when data runs outside the current view.
        /// 0 for a view that slides every time new data is added
        /// 1 for a view that only slides forward when new data runs off the screen
        /// </summary>
        public double PaddingFractionX = 0;

        /// <summary>
        /// Defines the amount of whitespace added to the top or bottom of the data when data runs outside the current view.
        /// 0 sets axis limits to tightly fit the data height
        /// 1 sets axis limits to double the vertical span in the direction of the vertical overflow
        /// </summary>
        public double PaddingFractionY = .5;

        public AxisLimits GetAxisLimits(AxisLimits viewLimits, AxisLimits dataLimits)
        {
            var padHorizontal = Width * PaddingFractionX;
            var padVertical = viewLimits.VerticalSpan * PaddingFractionY;

            var xOverflow = dataLimits.Right > viewLimits.Right || dataLimits.Right < viewLimits.Left;
            var xMax = xOverflow ? dataLimits.Right + padHorizontal : viewLimits.Right;
            var xMin = xOverflow ? xMax - Width : viewLimits.Left;

            var yOverflow = dataLimits.Bottom < viewLimits.Bottom || dataLimits.Top > viewLimits.Top;
            var yMin = yOverflow ? dataLimits.Bottom - padVertical : viewLimits.Bottom;
            var yMax = yOverflow ? dataLimits.Top + padVertical : viewLimits.Top;

            return new AxisLimits(xMin, xMax, yMin, yMax);
        }
    }
}