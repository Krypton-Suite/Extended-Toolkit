using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.DataGridView.Implementation
{
    public interface IDetailView<T> where T : Control
    {
        /// <summary>
        /// Link the TargetColumn to the gridView
        /// </summary>
        Dictionary <KryptonDataGridView, string> ChildGrids { get; }

        /// <summary>
        /// The current active Details View cell
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        DataGridViewCell DetailsCurrentCell { get; set; }

        /// <summary>
        /// Current active Details View row
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataGridViewRow DetailsCurrentRow { get; }

        /// <summary>
        /// Route the Details mouse click through to the 
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        event DataGridViewCellMouseEventHandler DetailsCellMouseClick;

    }
}
