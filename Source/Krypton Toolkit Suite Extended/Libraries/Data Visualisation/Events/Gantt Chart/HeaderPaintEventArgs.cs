using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation
{
    /// <summary>
    /// Provides data for ChartPaintEvent
    /// </summary>
    public class HeaderPaintEventArgs : ChartPaintEventArgs
    {
        /// <summary>
        /// Get or set the font to use for drawing the text on the header
        /// </summary>
        public Font Font { get; set; }
        /// <summary>
        /// Get or set the header formatting
        /// </summary>
        public HeaderFormat Format { get; set; }

        /// <summary>
        /// Initialize a new instance of HeaderPaintEventArgs with the editable default font and header format
        /// </summary>
        public HeaderPaintEventArgs(Graphics graphics, Rectangle clipRect, GanttChart chart, Font font, HeaderFormat format)
            : base(graphics, clipRect, chart)
        {
            this.Font = font;
            this.Format = format;
        }
    }
}