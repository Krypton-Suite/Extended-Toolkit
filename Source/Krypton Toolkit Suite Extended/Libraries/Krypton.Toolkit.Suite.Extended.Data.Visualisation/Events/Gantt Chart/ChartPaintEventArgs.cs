﻿#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation
{
    /// <summary>
    /// Provides data for ChartPaintEvent
    /// </summary>
    public class ChartPaintEventArgs : PaintEventArgs
    {
        /// <summary>
        /// Get the chart that for this event
        /// </summary>
        public GanttChart Chart { get; private set; }

        /// <summary>
        /// Initialize a new instance of ChartPaintEventArgs with the PaintEventArgs graphics and clip rectangle, and the chart itself.
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="clipRect"></param>
        /// <param name="chart"></param>
        public ChartPaintEventArgs(Graphics graphics, Rectangle clipRect, GanttChart chart)
            : base(graphics, clipRect)
        {
            this.Chart = chart;
        }
    }
}