#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Software.Updater.AutoUpdaterDotNET
{
    internal class RemindLaterDialog : KryptonForm
    {
        #region Designer Code
        private KryptonPanel kryptonPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.PictureBox pictureBoxIcon;
        private KryptonLabel labelTitle;
        private KryptonRadioButton krbNo;
        private KryptonComboBox kcmbRemindLater;
        private KryptonRadioButton krbYes;
        private KryptonLabel labelDescription;
        private KryptonButton kbtnOK;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.labelTitle = new Krypton.Toolkit.KryptonLabel();
            this.krbNo = new Krypton.Toolkit.KryptonRadioButton();
            this.kcmbRemindLater = new Krypton.Toolkit.KryptonComboBox();
            this.krbYes = new Krypton.Toolkit.KryptonRadioButton();
            this.labelDescription = new Krypton.Toolkit.KryptonLabel();
            this.kbtnOK = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbRemindLater)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.tableLayoutPanel);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(499, 198);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 280F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 135F));
            this.tableLayoutPanel.Controls.Add(this.pictureBoxIcon, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.labelTitle, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.krbNo, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.kcmbRemindLater, 2, 2);
            this.tableLayoutPanel.Controls.Add(this.krbYes, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.labelDescription, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.kbtnOK, 2, 4);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 5;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(499, 198);
            this.tableLayoutPanel.TabIndex = 8;
            // 
            // pictureBoxIcon
            // 
            this.pictureBoxIcon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxIcon.Image = global::Krypton.Toolkit.Suite.Extended.Software.Updater.Properties.Resources.clock_go_32;
            this.pictureBoxIcon.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBoxIcon.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxIcon.Name = "pictureBoxIcon";
            this.tableLayoutPanel.SetRowSpan(this.pictureBoxIcon, 2);
            this.pictureBoxIcon.Size = new System.Drawing.Size(79, 90);
            this.pictureBoxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxIcon.TabIndex = 1;
            this.pictureBoxIcon.TabStop = false;
            // 
            // labelTitle
            // 
            this.tableLayoutPanel.SetColumnSpan(this.labelTitle, 2);
            this.labelTitle.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelTitle.Location = new System.Drawing.Point(88, 6);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(409, 23);
            this.labelTitle.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Values.Text = "Do you want to download updates later?";
            // 
            // krbNo
            // 
            this.tableLayoutPanel.SetColumnSpan(this.krbNo, 2);
            this.krbNo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.krbNo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.krbNo.Location = new System.Drawing.Point(91, 137);
            this.krbNo.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.krbNo.Name = "krbNo";
            this.krbNo.Size = new System.Drawing.Size(406, 20);
            this.krbNo.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.krbNo.TabIndex = 4;
            this.krbNo.Values.Text = "&No, download updates now (recommended)";
            // 
            // kcmbRemindLater
            // 
            this.kcmbRemindLater.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kcmbRemindLater.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.kcmbRemindLater.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kcmbRemindLater.DropDownWidth = 115;
            this.kcmbRemindLater.FormattingEnabled = true;
            this.kcmbRemindLater.IntegralHeight = false;
            this.kcmbRemindLater.Items.AddRange(new object[] {
            "After 30 minutes",
            "After 12 hours",
            "After 1 day",
            "After 2 days",
            "After 4 days",
            "After 8 days",
            "After 10 days"});
            this.kcmbRemindLater.Location = new System.Drawing.Point(375, 104);
            this.kcmbRemindLater.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.kcmbRemindLater.Name = "kcmbRemindLater";
            this.kcmbRemindLater.Size = new System.Drawing.Size(115, 21);
            this.kcmbRemindLater.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcmbRemindLater.TabIndex = 5;
            // 
            // krbYes
            // 
            this.krbYes.Checked = true;
            this.krbYes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.krbYes.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.krbYes.Location = new System.Drawing.Point(91, 105);
            this.krbYes.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.krbYes.Name = "krbYes";
            this.krbYes.Size = new System.Drawing.Size(271, 20);
            this.krbYes.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.krbYes.TabIndex = 3;
            this.krbYes.Values.Text = "&Yes, please remind me later : ";
            this.krbYes.CheckedChanged += new System.EventHandler(this.krbYes_CheckedChanged);
            // 
            // labelDescription
            // 
            this.tableLayoutPanel.SetColumnSpan(this.labelDescription, 2);
            this.labelDescription.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelDescription.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelDescription.Location = new System.Drawing.Point(88, 41);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(409, 52);
            this.labelDescription.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelDescription.TabIndex = 2;
            this.labelDescription.Values.Text = "You should download updates now. This only takes few minutes \r\ndepending on your " +
    "internet connection and ensures that \r\nyou have latest version of the applicatio" +
    "n.\r\n";
            // 
            // kbtnOK
            // 
            this.kbtnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kbtnOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kbtnOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.kbtnOK.Location = new System.Drawing.Point(375, 163);
            this.kbtnOK.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.kbtnOK.Name = "kbtnOK";
            this.kbtnOK.Size = new System.Drawing.Size(115, 32);
            this.kbtnOK.TabIndex = 6;
            this.kbtnOK.Values.Image = global::Krypton.Toolkit.Suite.Extended.Software.Updater.Properties.Resources.clock_play;
            this.kbtnOK.Values.Text = "&OK";
            this.kbtnOK.Click += new System.EventHandler(this.kbtnOK_Click);
            // 
            // RemindLaterDialog
            // 
            this.AcceptButton = this.kbtnOK;
            this.ClientSize = new System.Drawing.Size(499, 198);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RemindLaterDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Remind me later for update";
            this.Load += new System.EventHandler(this.RemindLaterDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbRemindLater)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        public RemindLaterFormat RemindLaterFormat { get; private set; }

        public int RemindLaterAt { get; private set; }
        #endregion

        #region Constructor
        public RemindLaterDialog()
        {
            InitializeComponent();
        }
        #endregion

        private void RemindLaterDialog_Load(object sender, EventArgs e)
        {
            kcmbRemindLater.SelectedIndex = 0;

            krbYes.Checked = true;
        }

        private void kbtnOK_Click(object sender, EventArgs e)
        {
            if (krbYes.Checked)
            {
                switch (kcmbRemindLater.SelectedIndex)
                {
                    case 0:
                        RemindLaterFormat = RemindLaterFormat.MINUTES;
                        RemindLaterAt = 30;
                        break;
                    case 1:
                        RemindLaterFormat = RemindLaterFormat.HOURS;
                        RemindLaterAt = 12;
                        break;
                    case 2:
                        RemindLaterFormat = RemindLaterFormat.DAYS;
                        RemindLaterAt = 1;
                        break;
                    case 3:
                        RemindLaterFormat = RemindLaterFormat.DAYS;
                        RemindLaterAt = 2;
                        break;
                    case 4:
                        RemindLaterFormat = RemindLaterFormat.DAYS;
                        RemindLaterAt = 4;
                        break;
                    case 5:
                        RemindLaterFormat = RemindLaterFormat.DAYS;
                        RemindLaterAt = 8;
                        break;
                    case 6:
                        RemindLaterFormat = RemindLaterFormat.DAYS;
                        RemindLaterAt = 10;
                        break;
                }

                DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult = DialogResult.Abort;
            }
        }

        private void krbYes_CheckedChanged(object sender, EventArgs e)
        {
            kcmbRemindLater.Enabled = krbYes.Checked;
        }
    }
}