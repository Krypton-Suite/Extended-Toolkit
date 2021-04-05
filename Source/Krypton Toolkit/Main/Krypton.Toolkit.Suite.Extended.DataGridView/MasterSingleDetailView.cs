using System.ComponentModel;
using System.Data;
using System.Drawing;

using Krypton.Toolkit.Suite.Extended.DataGridView.Designers;
using Krypton.Toolkit.Suite.Extended.DataGridView.Implementation;

namespace Krypton.Toolkit.Suite.Extended.DataGridView
{
    /// <summary>
    /// This is a MasterDetail DataGridView that allows a single detail block to be displayed under each master row
    /// </summary>
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(MasterSingleDetailView), "Designers.MasterSingleDetailView.bmp   ")]
    [DesignerCategory("code")]
    [Designer(typeof(MasterSingleDetailViewDesigner))]
    [Description("This is a MasterDetail DataGridView that allows a single detail block to be displayed under each master row.")]
    public class MasterSingleDetailView : MasterDetailGridView<KryptonDataGridView>
    {
        private readonly SingleDetailView childView;

        internal override IDetailView<KryptonDataGridView> ChildView => childView;

        /// <summary>
        /// 
        /// </summary>
        public MasterSingleDetailView()
        {
            childView = new SingleDetailView();
            Controls.Add(childView);
            SetStyles(childView);
        }

        /// <summary>
        /// Add the tableName to be used for the Details from within the DataSource
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="targetColumn"></param>
        public void AddSingleDetail(string tableName, string targetColumn)
        {
            childView.ChildGrids[childView] = targetColumn;
            childView.DataSource = new DataView(DataSet.Tables[tableName]);
            ConvertToExtKryptonColumns(this);

        }

    }
}
