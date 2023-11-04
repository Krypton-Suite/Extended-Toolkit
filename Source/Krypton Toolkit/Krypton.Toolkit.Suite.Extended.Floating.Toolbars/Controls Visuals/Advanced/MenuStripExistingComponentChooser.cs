﻿#region MIT License
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
    public partial class MenuStripExistingComponentChooser : KryptonForm
    {
        #region Variables
        private List<MenuStripPanelExtended?> _srcComponentList = new();
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
                        if ((item is MenuStripPanelExtended))
                        {
                            _srcComponentList.Add(item as MenuStripPanelExtended);
                        }
                    }

                    InitialSettings();
                }
            }
        }

        public List<MenuStripPanelExtended>? SelectedComponents
        {
            get
            {
                List<MenuStripPanelExtended?> tspe = new List<MenuStripPanelExtended?>();

                if (klbSelected.Items.Count > 0)
                {
                    foreach (MenuStripPanelExtended? toolStripPanel in _srcComponentList)
                    {
                        if (toolStripPanel != null && klbSelected.Items.Contains(toolStripPanel.Name))
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
        public MenuStripExistingComponentChooser(List<MenuStripPanelExtended>? panels)
        {
            InitializeComponent();

            if (panels != null)
            {
                foreach (MenuStripPanelExtended item in panels)
                {
                    klbSelected.Items.Add(item.Name);
                }
            }
        }
        #endregion

        #region Methods
        private void InitialSettings()
        {
            foreach (MenuStripPanelExtended? menuStripPanel in _srcComponentList)
            {
                if (menuStripPanel != null && !klbSelected.Items.Contains(menuStripPanel.Name))
                {
                    klblAvailable.Items.Add(menuStripPanel.Name);
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
            if (klblAvailable.SelectedItem != null)
            {
                klbSelected.Items.Add(klblAvailable.SelectedItem);

                klblAvailable.Items.Remove(klblAvailable.SelectedItem);
            }
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
            if (klbSelected.SelectedItem != null)
            {
                klblAvailable.Items.Add(klbSelected.SelectedItem);

                klbSelected.Items.Remove(klbSelected.SelectedItem);
            }
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