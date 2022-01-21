using System;
using System.Drawing;

using Krypton.Toolkit;
using Krypton.Toolkit.Suite.Extended.TreeGridView;

namespace TreeGridViewApp
{
    public partial class MainForm1 : KryptonForm
    {
        public MainForm1()
        {
            InitializeComponent();
            // load image strip
            imageStrip.ImageSize = new Size(16, 16);
            imageStrip.TransparentColor = Color.Magenta;
            imageStrip.ImageSize = new Size(16, 16);
            imageStrip.Images.AddStrip(Properties.Resources.newGroupPostIconStrip);
        }
        private void rbOffice2010Blue_CheckedChanged(object sender, EventArgs e)
        {
            kryptonPalette.BasePaletteMode = PaletteMode.Office2010Blue;
        }

        private void rbOffice2007Blue_CheckedChanged(object sender, EventArgs e)
        {
            kryptonPalette.BasePaletteMode = PaletteMode.Office2007Blue;
        }

        private void rbOffice2007Black_CheckedChanged(object sender, EventArgs e)
        {
            kryptonPalette.BasePaletteMode = PaletteMode.Office2007Black;
        }

        private void rbOffice2003_CheckedChanged(object sender, EventArgs e)
        {
            kryptonPalette.BasePaletteMode = PaletteMode.ProfessionalOffice2003;
        }

        private void rbSystem_CheckedChanged(object sender, EventArgs e)
        {
            kryptonPalette.BasePaletteMode = PaletteMode.ProfessionalSystem;
        }

        private void rbSparkle_CheckedChanged(object sender, EventArgs e)
        {
            kryptonPalette.BasePaletteMode = PaletteMode.SparkleBlue;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            KryptonTreeGridNodeRow node1 = treeGridView1.GridNodes.Add("Using DataView filter when binding to DataGridView", "You", @"10/19/2005 1:02 AM");
            node1.ImageIndex = 0;
            var node2 = node1.Nodes.Add("Re: Using DataView filter when binding to DataGridView", "Me", @"10/19/2005 1:04 AM");
            node2.ImageIndex = 1;
            var node = node2.Nodes.Add("Re: Using DataView filter when binding to DataGridView", "Another", @"10/19/2005 1:20 AM");
            node.ImageIndex = 2;
            node = node2.Nodes.Add("Re: Using DataView filter when binding to DataGridView", "you", @"10/19/2005 1:21 AM");
            node.ImageIndex = 1;
            node = node1.Nodes.Add("Re: Using DataView filter when binding to DataGridView", "you", @"10/19/2005 1:10 AM");
            node.ImageIndex = 1;
        }

        private void KryptonButton1_Click(object sender, EventArgs e)
        {
            new DataSourceForm1().ShowDialog(this);
        }
    }
}
