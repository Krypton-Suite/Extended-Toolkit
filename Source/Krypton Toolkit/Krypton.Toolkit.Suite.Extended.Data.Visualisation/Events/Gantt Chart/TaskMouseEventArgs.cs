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
    /// Provides data for TaskMouseEvent
    /// </summary>
    public class TaskMouseEventArgs : MouseEventArgs
    {
        /// <summary>
        /// Subject Task of the event
        /// </summary>
        public GanttChartTask Task { get; private set; }

        /// <summary>
        /// Rectangle bounds of the Task
        /// </summary>
        public RectangleF Rectangle { get; private set; }

        /// <summary>
        /// Initialize a new instance of TaskMouseEventArgs with the MouseEventArgs parameters and the Task involved.
        /// </summary>
        public TaskMouseEventArgs(GanttChartTask task, RectangleF rectangle, MouseButtons buttons, int clicks, int x, int y, int delta) : base(buttons, clicks, x, y, delta)
        {
            Task = task;

            Rectangle = rectangle;
        }
    }
}