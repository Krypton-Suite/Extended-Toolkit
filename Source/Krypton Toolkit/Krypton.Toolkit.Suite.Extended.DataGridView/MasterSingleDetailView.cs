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
    /// This is a MasterDetail DataGridView that allows a single detail block to be displayed under each master row
    /// </summary>
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(MasterSingleDetailView), "Designers.MasterSingleDetailView.bmp")]
    [DesignerCategory("code")]
    [Designer("Krypton.Toolkit.Suite.Extended.DataGridView.MasterSingleDetailViewDesigner, Krypton.Toolkit.Suite.Extended.DataGridView")]
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
        }

        public SingleDetailView SingleChildView => childView;

        /// <summary>
        /// Add the tableName to be used for the Details from within the DataSource
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="targetKeyColumn"></param>
        /// <param name="columns">optional columns if not already added via designer</param>
        public void AddSingleDetail(string tableName, string targetKeyColumn, DataGridViewColumn[] columns = null)
        {
            AddSingleDetail(new DataView(DataSet.Tables[tableName]), targetKeyColumn, columns);
        }

        /// <summary>
        /// Adds a dataSource type to the Child Detail View
        /// </summary>
        /// <param name="source"></param>
        /// <param name="targetKeyColumn">The foreign key fieldname to be used for the master -> child relationship</param>
        /// <param name="columns">optional columns if not already added via designer</param>
        public void AddSingleDetail(IBindingListView source, string targetKeyColumn, DataGridViewColumn[] columns = null)
        {
            if (!source.SupportsFiltering)
            {
                throw new NotImplementedException(@"'source' must implement Filtering. Use SimpleFilteredList class");
            }

            SetStyles(childView);
            if (columns != null)
            {
                childView.AutoGenerateColumns = false;
                childView.Columns.Clear();
                childView.Columns.AddRange(columns);
            }
            childView.DataSource = source;
            childView.ChildGrids[childView] = targetKeyColumn;
        }

    }
}
