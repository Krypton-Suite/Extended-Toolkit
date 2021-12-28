using System;
using System.Data;
using System.Drawing;

using Krypton.Toolkit;

namespace TreeGridViewApp
{
    /// <summary>
    /// Summary description for form.
    /// </summary>
    public partial class DataSourceForm1 : KryptonForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private DataTable dtSource;

        void PopulateDt()
        {
            //read Data
            var set = new DataSet();
            //set.ReadXml(@"DataSource\invoices.xml");
            {
                set.ReadXml(@"DataSource\sales_by_category.xml");
                treeGridView1.IdColumnName = "CategoryID";
                treeGridView1.ParentIdColumnName = "CategoryName";
            }
            //{
            //set.ReadXml(@"DataSource\test.xml");
            //treeGridView1.IdColumnName = "ID";
            //treeGridView1.ParentIdColumnName = "ParentID";
            //}
            treeGridView1.UseParentRelationship = true;

            dtSource = set.Tables[0];
        }

        public DataSourceForm1()
        {
            InitializeComponent();
            treeGridView1.FontParentBold = true;
        }
        private void Form1_Load(object sender, System.EventArgs e)
        {
            attachmentColumn.DefaultCellStyle.NullValue = null;

            // load image strip
            this.imageStrip.ImageSize = new System.Drawing.Size(16, 16);
            this.imageStrip.TransparentColor = System.Drawing.Color.Magenta;
            this.imageStrip.ImageSize = new Size(16, 16);
            this.imageStrip.Images.AddStrip(Properties.Resources.newGroupPostIconStrip);

            treeGridView1.ImageList = imageStrip;

            //Populate Source
            PopulateDt();

            //populate Combo
            for (int k = 0; k < dtSource.Columns.Count ; k++)
            {
                toolStripComboBox1.ComboBox.Items.Add(k);
            }
            toolStripComboBox1.ComboBox.SelectedIndex = 0;

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.treeGridView1.ExpandAll();

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.treeGridView1.CollapseAll();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            treeGridView1.GridNodes.Clear();
            treeGridView1.Columns.Clear();

            //set some properties
            treeGridView1.IsOneLevel = toolStripButton4.Checked;
            treeGridView1.ImageIndexParent = 0;
            treeGridView1.ImageIndexChild = 1;

            treeGridView1.UseParentRelationship = false;
            treeGridView1.GroupByColumnIndex = (int)toolStripComboBox1.SelectedIndex;

            //bind data
            treeGridView1.DataSource = dtSource;

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            toolStripButton3_Click(this, e);
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolStripButton3_Click(this, e);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            treeGridView1.GridNodes.Clear();
            treeGridView1.Columns.Clear();

            //set some properties
            treeGridView1.IsOneLevel = toolStripButton4.Checked;
            treeGridView1.ImageIndexParent = 0;
            treeGridView1.ImageIndexChild = 1;

            

            //bind data
            treeGridView1.DataSource = dtSource;
        }





    }

}

