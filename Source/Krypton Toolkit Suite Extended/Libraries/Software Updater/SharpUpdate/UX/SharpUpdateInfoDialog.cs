#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Software.Updater.SharpUpdate.Language;
using System;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Software.Updater.SharpUpdate
{
    internal class SharpUpdateInfoDialog : KryptonForm
    {
        #region Design Code
        private KryptonButton kbtnBack;
        private KryptonTextBox ktxtDescription;
        private KryptonLabel klblDescription;
        private KryptonLabel klblVersions;
        private System.Windows.Forms.PictureBox pictureBox1;
        private KryptonPanel kryptonPanel1;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnBack = new Krypton.Toolkit.KryptonButton();
            this.ktxtDescription = new Krypton.Toolkit.KryptonTextBox();
            this.klblDescription = new Krypton.Toolkit.KryptonLabel();
            this.klblVersions = new Krypton.Toolkit.KryptonLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnBack);
            this.kryptonPanel1.Controls.Add(this.ktxtDescription);
            this.kryptonPanel1.Controls.Add(this.klblDescription);
            this.kryptonPanel1.Controls.Add(this.klblVersions);
            this.kryptonPanel1.Controls.Add(this.pictureBox1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(284, 261);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnBack
            // 
            this.kbtnBack.Location = new System.Drawing.Point(98, 225);
            this.kbtnBack.Name = "kbtnBack";
            this.kbtnBack.Size = new System.Drawing.Size(90, 25);
            this.kbtnBack.TabIndex = 9;
            this.kbtnBack.Values.Text = "&Back";
            this.kbtnBack.Click += new System.EventHandler(this.kbtnBack_Click);
            // 
            // ktxtDescription
            // 
            this.ktxtDescription.Location = new System.Drawing.Point(12, 124);
            this.ktxtDescription.Multiline = true;
            this.ktxtDescription.Name = "ktxtDescription";
            this.ktxtDescription.ReadOnly = true;
            this.ktxtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ktxtDescription.Size = new System.Drawing.Size(260, 95);
            this.ktxtDescription.TabIndex = 8;
            this.ktxtDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ktxtDescription_KeyDown);
            // 
            // klblDescription
            // 
            this.klblDescription.Location = new System.Drawing.Point(12, 98);
            this.klblDescription.Name = "klblDescription";
            this.klblDescription.Size = new System.Drawing.Size(75, 20);
            this.klblDescription.TabIndex = 7;
            this.klblDescription.Values.Text = "Description:";
            // 
            // klblVersions
            // 
            this.klblVersions.AutoSize = false;
            this.klblVersions.Location = new System.Drawing.Point(98, 22);
            this.klblVersions.Name = "klblVersions";
            this.klblVersions.Size = new System.Drawing.Size(174, 61);
            this.klblVersions.StateCommon.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.klblVersions.TabIndex = 6;
            this.klblVersions.Values.Text = "";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Krypton.Toolkit.Suite.Extended.Software.Updater.Properties.Resources.update2;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // SharpUpdateInfoDialog
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SharpUpdateInfoDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Constructor
        internal SharpUpdateInfoDialog(ISharpUpdatable applicationInfo, SharpUpdateXML updateInfo)
        {
            InitializeComponent();

            try
            {
                if (applicationInfo.ApplicationIcon != null) Icon = applicationInfo.ApplicationIcon;

                Text = LanguageEN.SharpUpdateInfoForm_Title;

                klblVersions.Text = string.Format(LanguageEN.SharpUpdateInfoForm_Version, applicationInfo.ApplicationAssembly.GetName().Version.ToString(), updateInfo.Version.ToString());

                klblDescription.Text = LanguageEN.SharpUpdateInfoForm_lblDescription;

                ktxtDescription.Text = updateInfo.Description;

                kbtnBack.Text = LanguageEN.SharpUpdateInfoForm_btnBack;
            }
            catch (Exception e)
            {

                throw;
            }
        }
        #endregion

        private void kbtnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ktxtDescription_KeyDown(object sender, KeyEventArgs e)
        {
            // Only allow Cntrl - C to copy text
            if (!(e.Control && e.KeyCode == Keys.C)) e.SuppressKeyPress = true;
        }
    }
}