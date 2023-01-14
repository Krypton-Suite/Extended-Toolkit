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
    public class ToolStripExistingComponentChooser : KryptonForm
    {
        #region Designer Code
        private KryptonPanel kryptonPanel1;
        private KryptonButton kbtnCancel;
        private KryptonButton kbtnOk;
        private KryptonGroupBox kgbSelected;
        private KryptonListBox klbSelected;
        private KryptonButton kbtnAddAll;
        private KryptonButton kbtnRemoveSelected;
        private KryptonButton kbtnRemoveAll;
        private KryptonButton kbtnAddSelected;
        private KryptonGroupBox kgbAvailable;
        private KryptonListBox klblAvailable;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnCancel = new Krypton.Toolkit.KryptonButton();
            this.kbtnOk = new Krypton.Toolkit.KryptonButton();
            this.kgbSelected = new Krypton.Toolkit.KryptonGroupBox();
            this.klbSelected = new Krypton.Toolkit.KryptonListBox();
            this.kbtnAddAll = new Krypton.Toolkit.KryptonButton();
            this.kbtnRemoveSelected = new Krypton.Toolkit.KryptonButton();
            this.kbtnRemoveAll = new Krypton.Toolkit.KryptonButton();
            this.kbtnAddSelected = new Krypton.Toolkit.KryptonButton();
            this.kgbAvailable = new Krypton.Toolkit.KryptonGroupBox();
            this.klblAvailable = new Krypton.Toolkit.KryptonListBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kgbSelected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kgbSelected.Panel)).BeginInit();
            this.kgbSelected.Panel.SuspendLayout();
            this.kgbSelected.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kgbAvailable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kgbAvailable.Panel)).BeginInit();
            this.kgbAvailable.Panel.SuspendLayout();
            this.kgbAvailable.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnCancel);
            this.kryptonPanel1.Controls.Add(this.kbtnOk);
            this.kryptonPanel1.Controls.Add(this.kgbSelected);
            this.kryptonPanel1.Controls.Add(this.kbtnAddAll);
            this.kryptonPanel1.Controls.Add(this.kbtnRemoveSelected);
            this.kryptonPanel1.Controls.Add(this.kbtnRemoveAll);
            this.kryptonPanel1.Controls.Add(this.kbtnAddSelected);
            this.kryptonPanel1.Controls.Add(this.kgbAvailable);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(493, 236);
            this.kryptonPanel1.TabIndex = 2;
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Location = new System.Drawing.Point(396, 81);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.Size = new System.Drawing.Size(85, 25);
            this.kbtnCancel.StateCommon.Content.LongText.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCancel.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCancel.TabIndex = 7;
            this.kbtnCancel.Values.Text = "&Cancel";
            // 
            // kbtnOk
            // 
            this.kbtnOk.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kbtnOk.Location = new System.Drawing.Point(396, 33);
            this.kbtnOk.Name = "kbtnOk";
            this.kbtnOk.Size = new System.Drawing.Size(85, 25);
            this.kbtnOk.StateCommon.Content.LongText.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.TabIndex = 6;
            this.kbtnOk.Values.Text = "O&k";
            // 
            // kgbSelected
            // 
            this.kgbSelected.Location = new System.Drawing.Point(226, 12);
            this.kgbSelected.Name = "kgbSelected";
            // 
            // kgbSelected.Panel
            // 
            this.kgbSelected.Panel.Controls.Add(this.klbSelected);
            this.kgbSelected.Size = new System.Drawing.Size(164, 212);
            this.kgbSelected.StateCommon.Content.LongText.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kgbSelected.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kgbSelected.TabIndex = 2;
            this.kgbSelected.Values.Heading = "Selected";
            // 
            // klbSelected
            // 
            this.klbSelected.Dock = System.Windows.Forms.DockStyle.Fill;
            this.klbSelected.Location = new System.Drawing.Point(0, 0);
            this.klbSelected.Name = "klbSelected";
            this.klbSelected.Size = new System.Drawing.Size(160, 189);
            this.klbSelected.StateCommon.Item.Content.LongText.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klbSelected.StateCommon.Item.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klbSelected.TabIndex = 1;
            this.klbSelected.SelectedIndexChanged += new System.EventHandler(this.KlbSelected_SelectedIndexChanged);
            // 
            // kbtnAddAll
            // 
            this.kbtnAddAll.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnAddAll.Location = new System.Drawing.Point(182, 90);
            this.kbtnAddAll.Name = "kbtnAddAll";
            this.kbtnAddAll.Size = new System.Drawing.Size(38, 25);
            this.kbtnAddAll.StateCommon.Content.LongText.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnAddAll.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnAddAll.TabIndex = 5;
            this.kbtnAddAll.Values.Text = ">>";
            this.kbtnAddAll.Click += new System.EventHandler(this.KbtnAddAll_Click);
            // 
            // kbtnRemoveSelected
            // 
            this.kbtnRemoveSelected.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnRemoveSelected.Enabled = false;
            this.kbtnRemoveSelected.Location = new System.Drawing.Point(182, 121);
            this.kbtnRemoveSelected.Name = "kbtnRemoveSelected";
            this.kbtnRemoveSelected.Size = new System.Drawing.Size(38, 25);
            this.kbtnRemoveSelected.StateCommon.Content.LongText.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnRemoveSelected.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnRemoveSelected.TabIndex = 4;
            this.kbtnRemoveSelected.Values.Text = "<";
            this.kbtnRemoveSelected.Click += new System.EventHandler(this.KbtnRemoveSelected_Click);
            // 
            // kbtnRemoveAll
            // 
            this.kbtnRemoveAll.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnRemoveAll.Location = new System.Drawing.Point(182, 152);
            this.kbtnRemoveAll.Name = "kbtnRemoveAll";
            this.kbtnRemoveAll.Size = new System.Drawing.Size(38, 25);
            this.kbtnRemoveAll.StateCommon.Content.LongText.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnRemoveAll.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnRemoveAll.TabIndex = 3;
            this.kbtnRemoveAll.Values.Text = "<<";
            this.kbtnRemoveAll.Click += new System.EventHandler(this.KbtnRemoveAll_Click);
            // 
            // kbtnAddSelected
            // 
            this.kbtnAddSelected.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnAddSelected.Enabled = false;
            this.kbtnAddSelected.Location = new System.Drawing.Point(182, 59);
            this.kbtnAddSelected.Name = "kbtnAddSelected";
            this.kbtnAddSelected.Size = new System.Drawing.Size(38, 25);
            this.kbtnAddSelected.StateCommon.Content.LongText.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnAddSelected.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnAddSelected.TabIndex = 2;
            this.kbtnAddSelected.Values.Text = ">";
            this.kbtnAddSelected.Click += new System.EventHandler(this.KbtnAddSelected_Click);
            // 
            // kgbAvailable
            // 
            this.kgbAvailable.Location = new System.Drawing.Point(12, 12);
            this.kgbAvailable.Name = "kgbAvailable";
            // 
            // kgbAvailable.Panel
            // 
            this.kgbAvailable.Panel.Controls.Add(this.klblAvailable);
            this.kgbAvailable.Size = new System.Drawing.Size(164, 212);
            this.kgbAvailable.StateCommon.Content.LongText.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kgbAvailable.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kgbAvailable.TabIndex = 1;
            this.kgbAvailable.Values.Heading = "Available";
            // 
            // klblAvailable
            // 
            this.klblAvailable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.klblAvailable.Location = new System.Drawing.Point(0, 0);
            this.klblAvailable.Name = "klblAvailable";
            this.klblAvailable.Size = new System.Drawing.Size(160, 189);
            this.klblAvailable.StateCommon.Item.Content.LongText.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblAvailable.StateCommon.Item.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblAvailable.TabIndex = 1;
            this.klblAvailable.SelectedIndexChanged += new System.EventHandler(this.KlblAvailable_SelectedIndexChanged);
            // 
            // ToolStripExistingComponentChooser
            // 
            this.ClientSize = new System.Drawing.Size(493, 236);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ToolStripExistingComponentChooser";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kgbSelected.Panel)).EndInit();
            this.kgbSelected.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kgbSelected)).EndInit();
            this.kgbSelected.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kgbAvailable.Panel)).EndInit();
            this.kgbAvailable.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kgbAvailable)).EndInit();
            this.kgbAvailable.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

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