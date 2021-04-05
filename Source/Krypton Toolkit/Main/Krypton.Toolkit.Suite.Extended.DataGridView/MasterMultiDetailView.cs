#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using Krypton.Toolkit.Suite.Extended.DataGridView.Designers;
using Krypton.Toolkit.Suite.Extended.DataGridView.Implementation;

namespace Krypton.Toolkit.Suite.Extended.DataGridView
{
    /// <summary>
    /// This is a MasterDetail DataGridView that allows a multiple detail block to be displayed under each master row
    /// </summary>
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(MasterMultiDetailView), "Designers.MasterMultiDetailView.bmp")]
    [DesignerCategory("code")]
    [Designer(typeof(MasterMultiDetailViewDesigner))]
    [Description("This is a MasterDetail DataGridView that allows a multiple detail block to be displayed under each master row")]
    // TODO: Replace the TabControl with the Krypton Equivalent
    public class MasterMultiDetailView : MasterDetailGridView<TabControl>
    {
        private readonly MultiDetailView childViews;

        internal override IDetailView<TabControl> ChildView => childViews;

        public MasterMultiDetailView()
        {
            childViews = new MultiDetailView();
            Controls.Add(childViews);
        }

        /// <summary>
        /// Add Detail Grid View tab 
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="targetColumn"></param>
        /// <param name="pageCaption"></param>
        public void AddMultiDetail(string tableName, string targetColumn, string pageCaption)
        {
            var tPage = new TabPage() { Text = pageCaption };
            childViews.TabPages.Add(tPage);
            var newGrid = new KryptonDataGridView() { Dock = DockStyle.Fill, DataSource = new DataView(DataSet.Tables[tableName]) };
            SetStyles(newGrid);
            ConvertToExtKryptonColumns(newGrid);
            tPage.Controls.Add(newGrid);
            childViews.ChildGrids[newGrid] = targetColumn;
        }

    }
}
