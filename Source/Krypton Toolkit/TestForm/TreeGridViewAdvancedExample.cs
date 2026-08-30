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

namespace TestForm
{
    public partial class TreeGridViewAdvancedExample : KryptonForm
    {
        public TreeGridViewAdvancedExample()
        {
            InitializeComponent();
        }

        private void TreeGridViewAdvancedExample_Load(object sender, EventArgs e)
        {
            BuildIssue533SampleTree();
            kryptonTreeGridView1.ExpandAll();
        }

        /// <summary>
        /// Regression sample for https://github.com/Krypton-Suite/Extended-Toolkit/issues/533
        /// </summary>
        private void BuildIssue533SampleTree()
        {
            kryptonTreeGridView1.GridNodes.Clear();

            var rootNode = kryptonTreeGridView1.GridNodes.Add("Root", "", "", "");
            var childNode1 = rootNode.Nodes.Add("jane doe", "18", "2022-12-12", "engineer");
            rootNode.Nodes.Add("joe doe", "18", "2022-12-12", "engineer");
            childNode1.Nodes.Add("ch-joe doe", "18", "2022-12-12", "engineer");

            for (int i = 0; i < 3; i++)
            {
                var childNodex = rootNode.Nodes.Add($"ch-joe doe {i}", "18", "2022-12-12", "engineer");
                for (int j = 0; j < 3; j++)
                {
                    childNodex.Nodes.Add($"ccx - joe doe {i}", "18", "2022-12-12", "intern");
                }
            }
        }

        private void kbtnExpandAll_Click(object sender, EventArgs e)
        {
            kryptonTreeGridView1.ExpandAll();
        }

        private void kbtnCollapseAll_Click(object sender, EventArgs e)
        {
            kryptonTreeGridView1.CollapseAll();
        }

        private void kbtnDataSource_Click(object sender, EventArgs e)
        {
            TreeGridViewDataSourceExample treeGridViewDataSource = new();
            treeGridViewDataSource.Show();
        }
    }
}
