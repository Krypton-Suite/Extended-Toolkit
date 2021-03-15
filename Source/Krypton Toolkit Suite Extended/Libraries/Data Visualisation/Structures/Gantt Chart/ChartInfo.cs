#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation
{
    /// <summary>
    /// Provides information about the chart at a specific row and date/time.
    /// </summary>
    public struct ChartInfo
    {
        /// <summary>
        /// Get or set the chart row number
        /// </summary>
        public int Row { get; set; }
        /// <summary>
        /// Get or set the chart date/time
        /// </summary>
        public DateTime DateTime { get; set; }
        /// <summary>
        /// Get or set the task
        /// </summary>
        public GanttChartTask Task { get; set; }
        /// <summary>
        /// Construct a passive data structure to hold chart information
        /// </summary>
        /// <param name="row"></param>
        /// <param name="dateTime"></param>
        /// <param name="task"></param>
        public ChartInfo(int row, DateTime dateTime, GanttChartTask task)
            : this()
        {
            Row = row;
            DateTime = dateTime;
            Task = task;
        }
    }
}