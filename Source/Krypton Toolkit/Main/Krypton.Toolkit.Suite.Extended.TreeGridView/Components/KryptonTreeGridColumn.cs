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
    public class KryptonTreeGridColumn : KryptonDataGridViewTextBoxColumn
    {
        public KryptonTreeGridColumn()
        {
            CellTemplate = new KryptonTreeGridCell();
        }

        // Need to override Clone for design-time support.
        public override object Clone()
        {
            var c = (KryptonTreeGridColumn)base.Clone();
            c.DefaultNodeImage = DefaultNodeImage;
            return c;
        }

        public Image DefaultNodeImage { get; set; }
    }
}