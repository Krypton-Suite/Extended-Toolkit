#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.DataGridView
{
    /// <summary>
    /// TODO: use Krypton.Navigator
    /// </summary>
    public class MultiDetailView : TabControl, IDetailView<TabControl>
    {
        /// <inheritdoc />
        public Dictionary<KryptonDataGridView, string> ChildGrids { get; } = new();

        public MultiDetailView()
        {
            Visible = false;
        }

        /// <inheritdoc />
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataGridViewCell DetailsCurrentCell
        {
            get => ((KryptonDataGridView) SelectedTab.Controls[0]).CurrentCell;
            set => ((KryptonDataGridView)SelectedTab.Controls[0]).CurrentCell = value;
        }

        /// <inheritdoc />
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataGridViewRow DetailsCurrentRow => ((KryptonDataGridView)SelectedTab.Controls[0]).CurrentRow;

        /// <inheritdoc />
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event DataGridViewCellMouseEventHandler DetailsCellMouseClick
        {
            add
            {
                foreach (TabPage page in TabPages)
                {
                    ((KryptonDataGridView) page.Controls[0]).CellMouseClick += value;
                }
            }

            remove
            {
                foreach (TabPage page in TabPages)
                {
                    ((KryptonDataGridView) page.Controls[0]).CellMouseClick -= value;
                }
            }
        }
    }
}
