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
    public class SingleDetailView : KryptonDataGridView, IDetailView<KryptonDataGridView>
    {
        /// <inheritdoc />
        public Dictionary<KryptonDataGridView, string> ChildGrids { get; } = new();

        public SingleDetailView()
        {
            Visible = false;
        }

        /// <inheritdoc />
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataGridViewCell DetailsCurrentCell
        {
            get => CurrentCell;
            set => CurrentCell = value;
        }

        /// <inheritdoc />
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataGridViewRow DetailsCurrentRow => CurrentRow;

        /// <inheritdoc />
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event DataGridViewCellMouseEventHandler DetailsCellMouseClick
        {
            add => CellMouseClick += value;
            remove => CellMouseClick -= value;
        }
    }
}
