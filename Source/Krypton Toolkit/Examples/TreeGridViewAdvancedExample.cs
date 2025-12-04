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
using Krypton.Toolkit.Suite.Extended.TreeGridView;
#pragma warning disable CS8602

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
