using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
