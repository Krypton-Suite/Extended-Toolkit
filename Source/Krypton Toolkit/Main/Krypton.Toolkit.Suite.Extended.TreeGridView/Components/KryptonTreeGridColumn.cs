#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.TreeGridView
{
    /// <summary>
    /// Just like a tree view, I wanted to have the concept of a node. 
    /// I made the nodes class derive from a DataGridViewRow since a node in the list is the same as a row, just with a bit more info
    /// </summary>
    public class KryptonTreeGridColumn : KryptonDataGridViewTextBoxColumn
    {
        public KryptonTreeGridColumn()
        {
            CellTemplate = new KryptonTreeGridCell();
        }

        /// <summary>
        /// Need to override Clone for design-time support.
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            var c = (KryptonTreeGridColumn)base.Clone();
            c.DefaultNodeImage = DefaultNodeImage;
            return c;
        }

        public Image? DefaultNodeImage { get; set; }
    }
}