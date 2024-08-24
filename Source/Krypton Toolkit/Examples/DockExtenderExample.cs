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
using Krypton.Toolkit.Suite.Extended.Dock.Extender;

namespace Examples
{
    public partial class DockExtenderExample : KryptonForm
    {
        #region Instance Fields

        private string _someText =
            @"It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).";
        private string[] _someWords;
        private Random _rnd;
        private KryptonDockExtender _dockExtender;

        #endregion

        public DockExtenderExample()
        {
            InitializeComponent();

            kryptonLabel3.Text = _someText;

            _someWords = _someText.Split(' ');

            _rnd = new Random(-1);

            SetupTree();

            SetupList();

            _dockExtender = new(this);

            IFloatable floatable;

            floatable = _dockExtender.Attach(toolStrip1, toolStrip1, null);

            floatable.DockOnInside = false;

            floatable.Docking += Floatable_Docking;

            floatable = _dockExtender.Attach(kpnlBottom, kryptonTableLayoutPanel2, ksBottom);

            floatable.Docking += Floatable_Docking;

            floatable = _dockExtender.Attach(kpnlLeft, kryptonTableLayoutPanel1, ksLeft);

            floatable.Text = @"Left Panel";

            foreach (KryptonFloatableForm floatables in _dockExtender.Floaties)
            {
                ToolStripItem item = viewToolStripMenuItem.DropDownItems.Add(floatables.Text);

                item.MouseUp += Item_MouseUp;

                item.Tag = floatables;
            }
        }

        private void Item_MouseUp(object sender, MouseEventArgs e)
        {
            ToolStripItem item = sender as ToolStripItem;

            KryptonFloatableForm floatable = item.Tag as KryptonFloatableForm;

            floatable.Show();
        }

        private void Floatable_Docking(object sender, EventArgs e)
        {
            kryptonListView1.BringToFront();

            menuStrip1.SendToBack();

            statusStrip1.SendToBack();

            BringToFront();
        }

        private void SetupList()
        {
            for (int i = 0; i < 5; i++)
            {
                kryptonListView1.Columns.Add(_someWords[_rnd.Next(_someWords.Length - 1)]);
            }

            for (int i = 0; i < 100; i++)
            {
                ListViewItem item = kryptonListView1.Items.Add(_someWords[_rnd.Next(_someWords.Length - 1)]);

                for (int j = 0; j < 4; j++)
                {
                    item.SubItems.Add(_someWords[_rnd.Next(_someWords.Length - 1)]);
                }
            }
        }

        private void SetupTree()
        {
            for (int i = 1; i < 20; i++)
            {
                TreeNode node = kryptonTreeView1.Nodes.Add(_someWords[_rnd.Next(_someWords.Length - 1)]);

                SetupTreeBranch(node, 3);
            }
        }

        private void SetupTreeBranch(TreeNode node, int depth)
        {
            if (depth == 0)
            {
                return;
            }

            for (int i = 0; i < 3; i++)
            {
                TreeNode nodes = node.Nodes.Add(_someWords[_rnd.Next(_someWords.Length - 1)]);

                SetupTreeBranch(nodes, depth - 1);
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void kbtnBottomClose_Click(object sender, EventArgs e)
        {
            _dockExtender.Hide(kpnlBottom);
        }

        private void kbtnLeftClose_Click(object sender, EventArgs e)
        {
            _dockExtender.Hide(kpnlLeft);
        }

        private void kpnlLeft_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void kryptonLabel2_VisibleChanged(object sender, EventArgs e)
        {
            kbtnLeftClose.Visible = kryptonLabel2.Visible;
        }

        private void kryptonLabel1_VisibleChanged(object sender, EventArgs e)
        {
            kbtnBottomClose.Visible = kryptonLabel1.Visible;
        }
    }
}
