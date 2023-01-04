using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Krypton.Toolkit.Suite.Extended.TreeGridView;

namespace Examples
{
    public partial class TreeGridViewAdvancedExample : KryptonForm
    {
        public TreeGridViewAdvancedExample()
        {
            InitializeComponent();

            // load image strip
            imageStrip.ImageSize = new Size(16, 16);
            imageStrip.TransparentColor = Color.Magenta;
            imageStrip.ImageSize = new Size(16, 16);
            imageStrip.Images.AddStrip(Properties.Resources.newGroupPostIconStrip);
        }

        private void TreeGridViewAdvancedExample_Shown(object sender, EventArgs e)
        {
            KryptonTreeGridNodeRow? node1 = kryptonTreeGridView1.GridNodes.Add("Using DataView filter when binding to DataGridView", "You", @"10/19/2005 1:02 AM");
            node1.ImageIndex = 0;
            var node2 = node1.Nodes.Add("Re: Using DataView filter when binding to DataGridView", "Me", @"10/19/2005 1:04 AM");
            node2.ImageIndex = 1;
            var node = node2.Nodes.Add("Re: Using DataView filter when binding to DataGridView", "Another", @"10/19/2005 1:20 AM");
            node.ImageIndex = 2;
            node = node2.Nodes.Add("Re: Using DataView filter when binding to DataGridView", "you", @"10/19/2005 1:21 AM");
            node.ImageIndex = 1;
            node = node1.Nodes.Add("Re: Using DataView filter when binding to DataGridView", "you", @"10/19/2005 1:10 AM");
        }

        private void kbtnDataSource_Click(object sender, EventArgs e)
        {
            TreeGridViewDataSourceExample treeGridViewDataSource = new();

            treeGridViewDataSource.Show();
        }
    }
}
