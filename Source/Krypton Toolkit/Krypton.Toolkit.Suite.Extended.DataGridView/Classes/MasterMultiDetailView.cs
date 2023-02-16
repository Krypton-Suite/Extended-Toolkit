#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
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
        /// <param name="tabPageCaption">The caption text of the current tab page.</param>
        /// <param name="columns">optional columns if not already added via designer</param>
        public void AddMultiDetail(IBindingListView source, string targetKeyColumn, string tabPageCaption, DataGridViewColumn[]? columns = null)
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
