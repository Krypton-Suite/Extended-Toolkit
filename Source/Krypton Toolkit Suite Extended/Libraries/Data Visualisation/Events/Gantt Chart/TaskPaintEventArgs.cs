#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation
{
    /// <summary>
    /// Provides data for TaskPaintEvent
    /// </summary>
    public class TaskPaintEventArgs : ChartPaintEventArgs
    {
        /// <summary>
        /// Get the task to be painted
        /// </summary>
        public GanttChartTask Task { get; private set; }
        /// <summary>
        /// Get the rectangle bounds of the task
        /// </summary>
        public RectangleF Rectangle => new RectangleF(Chart.GetSpan(Task.Start), Row * Chart.BarSpacing + Chart.BarSpacing + Chart.HeaderOneHeight, Chart.GetSpan(Task.Duration), Chart.BarHeight);

        /// <summary>
        /// Get the row number of the task
        /// </summary>
        public int Row { get; private set; }
        /// <summary>
        /// Get or set the font to be used to draw the task label
        /// </summary>
        public Font Font { get; set; }
        /// <summary>
        /// Get or set the formatting of the task
        /// </summary>
        public TaskFormat Format { get; set; }
        /// <summary>
        /// Get whether the task is in a critical path
        /// </summary>
        public bool IsCritical { get; private set; }
        /// <summary>
        /// Initialize a new instance of TaskPaintEventArgs with the editable default font and task paint format
        /// </summary>
        public TaskPaintEventArgs(Graphics graphics, Rectangle clipRect, GanttChart chart, GanttChartTask task, int row, bool critical, Font font, TaskFormat format) // need to create a paint event for each task for custom painting
            : base(graphics, clipRect, chart)
        {
            Task = task;
            Row = row;
            Font = font;
            Format = format;
            IsCritical = critical;
        }
    }
}