#region MIT License

/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
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
using System.Data;

namespace Examples
{
    public partial class TreeGridViewDataSourceExample : KryptonForm
    {
        private DataTable _dataTableSource;

        public TreeGridViewDataSourceExample()
        {
            InitializeComponent();

            kryptonTreeGridView1.FontParentBold = true;
        }

        private void PopulateDataTable()
        {
            //read Data
            var set = new DataSet();
            //set.ReadXml(@"DataSource\invoices.xml");
            {
                set.ReadXml(@"DataSource\sales_by_category.xml");
                kryptonTreeGridView1.IdColumnName = "CategoryID";
                kryptonTreeGridView1.ParentIdColumnName = "CategoryName";
            }
            //{
            //set.ReadXml(@"DataSource\test.xml");
            //treeGridView1.IdColumnName = "ID";
            //treeGridView1.ParentIdColumnName = "ParentID";
            //}
            kryptonTreeGridView1.UseParentRelationship = true;

            _dataTableSource = set.Tables[0];
        }

        private void TreeGridViewDataSourceExample_Load(object sender, EventArgs e)
        {
            attachmentColumn.DefaultCellStyle.NullValue = null;

            // load image strip
            this.imageStrip.ImageSize = new System.Drawing.Size(16, 16);
            this.imageStrip.TransparentColor = System.Drawing.Color.Magenta;
            this.imageStrip.ImageSize = new Size(16, 16);
            this.imageStrip.Images.AddStrip(Properties.Resources.newGroupPostIconStrip);

            kryptonTreeGridView1.ImageList = imageStrip;

            //Populate Source
            PopulateDataTable();

            //populate Combo
            for (int k = 0; k < _dataTableSource.Columns.Count; k++)
            {
                toolStripComboBox1.ComboBox.Items.Add(k);
            }
            toolStripComboBox1.ComboBox.SelectedIndex = 0;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            kryptonTreeGridView1.ExpandAll();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            kryptonTreeGridView1.CollapseAll();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            kryptonTreeGridView1.GridNodes.Clear();
            kryptonTreeGridView1.Columns.Clear();

            //set some properties
            kryptonTreeGridView1.IsOneLevel = toolStripButton4.Checked;
            kryptonTreeGridView1.ImageIndexParent = 0;
            kryptonTreeGridView1.ImageIndexChild = 1;

            kryptonTreeGridView1.UseParentRelationship = false;
            kryptonTreeGridView1.GroupByColumnIndex = (int)toolStripComboBox1.SelectedIndex;

            //bind data
            kryptonTreeGridView1.DataSource = _dataTableSource;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            toolStripButton3_Click(sender, e);
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolStripButton3_Click(sender, e);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            kryptonTreeGridView1.GridNodes.Clear();
            kryptonTreeGridView1.Columns.Clear();

            //set some properties
            kryptonTreeGridView1.IsOneLevel = toolStripButton4.Checked;
            kryptonTreeGridView1.ImageIndexParent = 0;
            kryptonTreeGridView1.ImageIndexChild = 1;

            //bind data
            kryptonTreeGridView1.DataSource = _dataTableSource;
        }
    }
}
