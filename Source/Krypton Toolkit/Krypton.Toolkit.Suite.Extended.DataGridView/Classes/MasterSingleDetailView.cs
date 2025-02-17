#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 */
#endregion

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
        public void AddSingleDetail(string tableName, string targetKeyColumn, DataGridViewColumn[]? columns = null)
        {
            AddSingleDetail(new DataView(DataSet.Tables[tableName]), targetKeyColumn, columns);
        }

        /// <summary>
        /// Adds a dataSource type to the Child Detail View
        /// </summary>
        /// <param name="source"></param>
        /// <param name="targetKeyColumn">The foreign key fieldname to be used for the master -> child relationship</param>
        /// <param name="columns">optional columns if not already added via designer</param>
        public void AddSingleDetail(IBindingListView source, string targetKeyColumn, DataGridViewColumn[]? columns = null)
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
