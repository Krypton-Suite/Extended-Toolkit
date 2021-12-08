#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation
{
    /// <summary>
    /// Provides data for ScalePaintEvent
    /// </summary>
    public class TimelinePaintEventArgs : ChartPaintEventArgs
    {
        /// <summary>
        /// Get the datetime value of the tick mark
        /// </summary>
        public DateTime DateTime { get; private set; }
        /// <summary>
        /// Get the dateimte value of the preview mark
        /// </summary>
        public DateTime DateTimePrev { get; private set; }
        /// <summary>
        /// Get or set whether painting of the tick mark has already been handled. If it is already handled, Chart will not paint the tick mark.
        /// </summary>
        public bool Handled { get; private set; }
        /// <summary>
        /// Get or set the label for the minor scale
        /// </summary>
        LabelFormat Minor { get; set; }
        /// <summary>
        /// Get or set the label for the major scale
        /// </summary>
        LabelFormat Major { get; set; }

        public TimelinePaintEventArgs(Graphics graphics, Rectangle clipRect, GanttChart chart, DateTime datetime, DateTime datetimeprev, LabelFormat minor, LabelFormat major)
            : base(graphics, clipRect, chart)
        {
            Handled = false;
            DateTime = datetime;
            DateTimePrev = datetimeprev;
            Minor = minor;
            Major = major;
        }
    }
}