#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.DataGridView
{
    /// <summary>
    /// This is a MasterDetail DataGridView that allows a multiple detail block to be displayed under each master row
    /// </summary>
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(MasterMultiDetailView), "Designers.MasterMultiDetailView.bmp")]
    [DesignerCategory("code")]
    [Designer("Krypton.Toolkit.Suite.Extended.DataGridView.MasterMultiDetailViewDesigner, Krypton.Toolkit.Suite.Extended.DataGridView")]
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
        /// <param name="targetKeyColumn"></param>
        /// <param name="tabPageCaption"></param>
        /// <param name="columns">optional columns if not already added via designer</param>
        public void AddMultiDetail(string tableName, string targetKeyColumn, string tabPageCaption, DataGridViewColumn[] columns = null)
        {
            AddMultiDetail(new DataView(DataSet.Tables[tableName]), targetKeyColumn, tabPageCaption, columns);
        }

        /// <summary>
        /// Adds a dataSource type to the Child Detail View
        /// </summary>
        /// <param name="source"></param>
        /// <param name="targetKeyColumn">The foreign key fieldname to be used for the master -> child relationship</param>
        /// <param name="columns">optional columns if not already added via designer</param>
        public void AddMultiDetail(IBindingListView source, string targetKeyColumn, string tabPageCaption, DataGridViewColumn[] columns = null)
        {
            if (!source.SupportsFiltering)
            {
                throw new NotImplementedException(@"'source' must implement Filtering. Use SimpleFilteredList class");
            }

            TabPage tPage = new() { Text = tabPageCaption };
            childViews.TabPages.Add(tPage);
            KryptonDataGridView newGrid = new()
            {
                Dock = DockStyle.Fill
            };
            SetStyles(newGrid);
            if (columns != null)
            {
                newGrid.AutoGenerateColumns = false;
                newGrid.Columns.Clear();
                newGrid.Columns.AddRange(columns);
            }
            newGrid.DataSource = source;
            tPage.Controls.Add(newGrid);
            childViews.ChildGrids[newGrid] = targetKeyColumn;
        }

    }
}
