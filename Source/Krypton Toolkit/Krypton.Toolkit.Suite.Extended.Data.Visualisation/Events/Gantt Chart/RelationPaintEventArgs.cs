#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.Threading.Tasks;

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation
{
    /// <summary>
    /// Provides data for RelationPaintEvent
    /// </summary>
    public class RelationPaintEventArgs : ChartPaintEventArgs
    {
        /// <summary>
        /// Get the precedent task in the relation
        /// </summary>
        public Task Precedent { get; private set; }

        /// <summary>
        /// Get the dependant task in the relation
        /// </summary>
        public Task Dependant { get; private set; }

        /// <summary>
        /// Get or set the formatting to use for drawing the relation
        /// </summary>
        public RelationFormat Format { get; set; }

        /// <summary>
        /// Initialize a new instance of RelationPaintEventArgs with the editable default font and relation paint format
        /// </summary>
        public RelationPaintEventArgs(Graphics graphics, Rectangle clipRect, GanttChart chart, Task before, Task after, RelationFormat format)
            : base(graphics, clipRect, chart)
        {
            this.Precedent = before;
            this.Dependant = after;
            this.Format = format;
        }
    }
}