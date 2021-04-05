using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Krypton.Toolkit.Suite.Extended.DataGridView.Implementation;

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
