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

namespace Krypton.Toolkit.Suite.Extended.Floating.Toolbars
{
    public partial class ToolStripExistingComponentChooser : KryptonForm
    {
        #region Variables
        private List<ToolStripPanelExtended> _srcComponentList = new List<ToolStripPanelExtended>();
        #endregion

        #region Properties
        public Control? SourceComponentContainer
        {
            set
            {
                if (value != null)
                {
                    foreach (Control item in value.Controls)
                    {
                        if ((item is ToolStripPanelExtended))
                        {
                            _srcComponentList.Add(item as ToolStripPanelExtended);
                        }
                    }

                    InitialSettings();
                }
            }
        }

        public List<ToolStripPanelExtended> SelectedComponents
        {
            get
            {
                List<ToolStripPanelExtended> tspe = new List<ToolStripPanelExtended>();

                if (klbSelected.Items.Count > 0)
                {
                    foreach (ToolStripPanelExtended toolStripPanel in _srcComponentList)
                    {
                        if (klbSelected.Items.Contains(toolStripPanel.Name))
                        {
                            tspe.Add(toolStripPanel);
                        }
                    }
                }

                return tspe;
            }
        }
        #endregion

        #region Constructor
        public ToolStripExistingComponentChooser(List<ToolStripPanelExtended> panels)
        {
            InitializeComponent();

            if (panels != null)
            {
                foreach (ToolStripPanelExtended item in panels)
                {
                    klbSelected.Items.Add(item.Name);
                }
            }
        }
        #endregion

        #region Methods
        private void InitialSettings()
        {
            foreach (ToolStripPanelExtended ToolStripPanel in _srcComponentList)
            {
                if (!klbSelected.Items.Contains(ToolStripPanel.Name))
                {
                    klblAvailable.Items.Add(ToolStripPanel.Name);
                }
            }
        }
        #endregion

        private void KlblAvailable_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool flag = klblAvailable.SelectedItems.Count > 0;

            kbtnAddSelected.Enabled = flag;
        }

        private void KlbSelected_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool flag = klbSelected.SelectedItems.Count > 0;

            kbtnRemoveSelected.Enabled = flag;
        }

        private void KbtnAddSelected_Click(object sender, EventArgs e)
        {
            klbSelected.Items.Add(klblAvailable.SelectedItem);

            klblAvailable.Items.Remove(klblAvailable.SelectedItem);
        }

        private void KbtnAddAll_Click(object sender, EventArgs e)
        {
            object[] allObjects = new string[klblAvailable.Items.Count];

            klblAvailable.Items.CopyTo(allObjects, 0);

            klblAvailable.Items.Clear();

            klbSelected.Items.AddRange(allObjects);
        }

        private void KbtnRemoveSelected_Click(object sender, EventArgs e)
        {
            klblAvailable.Items.Add(klbSelected.SelectedItem);

            klbSelected.Items.Remove(klbSelected.SelectedItem);
        }

        private void KbtnRemoveAll_Click(object sender, EventArgs e)
        {
            object[] allObjects = new string[klbSelected.Items.Count];

            klbSelected.Items.CopyTo(allObjects, 0);

            klbSelected.Items.Clear();

            klblAvailable.Items.AddRange(allObjects);
        }
    }
}