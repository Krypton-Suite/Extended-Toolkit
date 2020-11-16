#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Core;
using System;
using System.Diagnostics;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    public partial class AboutDialog : KryptonForm
    {
        #region Designer Code
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.kpnlBottom = new Krypton.Toolkit.KryptonPanel();
            this.kbtnSystemInformation = new Krypton.Toolkit.KryptonButton();
            this.kbtnClose = new Krypton.Toolkit.KryptonButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.pbxApplicationImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlBottom)).BeginInit();
            this.kpnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxApplicationImage)).BeginInit();
            this.SuspendLayout();
            // 
            // kpnlBottom
            // 
            this.kpnlBottom.Controls.Add(this.kbtnSystemInformation);
            this.kpnlBottom.Controls.Add(this.kbtnClose);
            this.kpnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kpnlBottom.Location = new System.Drawing.Point(0, 740);
            this.kpnlBottom.Name = "kpnlBottom";
            this.kpnlBottom.Size = new System.Drawing.Size(1184, 52);
            this.kpnlBottom.TabIndex = 0;
            // 
            // kbtnSystemInformation
            // 
            this.kbtnSystemInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kbtnSystemInformation.AutoSize = true;
            this.kbtnSystemInformation.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnSystemInformation.Location = new System.Drawing.Point(12, 10);
            this.kbtnSystemInformation.Name = "kbtnSystemInformation";
            this.kbtnSystemInformation.Size = new System.Drawing.Size(165, 30);
            this.kbtnSystemInformation.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnSystemInformation.TabIndex = 46;
            this.kbtnSystemInformation.Values.Text = "System &Information...";
            this.kbtnSystemInformation.Click += new System.EventHandler(this.kbtnSystemInformation_Click);
            // 
            // kbtnClose
            // 
            this.kbtnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnClose.AutoSize = true;
            this.kbtnClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnClose.Location = new System.Drawing.Point(1121, 10);
            this.kbtnClose.Name = "kbtnClose";
            this.kbtnClose.Size = new System.Drawing.Size(51, 30);
            this.kbtnClose.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnClose.TabIndex = 45;
            this.kbtnClose.Values.Text = "&Close";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 738);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1184, 2);
            this.panel1.TabIndex = 1;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.pbxApplicationImage);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(1184, 738);
            this.kryptonPanel1.TabIndex = 2;
            // 
            // pbxApplicationImage
            // 
            this.pbxApplicationImage.BackColor = System.Drawing.Color.Transparent;
            this.pbxApplicationImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbxApplicationImage.Location = new System.Drawing.Point(334, 12);
            this.pbxApplicationImage.Name = "pbxApplicationImage";
            this.pbxApplicationImage.Size = new System.Drawing.Size(512, 512);
            this.pbxApplicationImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbxApplicationImage.TabIndex = 0;
            this.pbxApplicationImage.TabStop = false;
            // 
            // AboutDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 792);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kpnlBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About {0}";
            this.Load += new System.EventHandler(this.AboutDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kpnlBottom)).EndInit();
            this.kpnlBottom.ResumeLayout(false);
            this.kpnlBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxApplicationImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonPanel kpnlBottom;
        private Krypton.Toolkit.KryptonButton kbtnSystemInformation;
        private Krypton.Toolkit.KryptonButton kbtnClose;
        private System.Windows.Forms.Panel panel1;
        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.PictureBox pbxApplicationImage;
        #endregion

        #region Variables
        private IAboutStripped _about;
        #endregion

        public AboutDialog()
        {
            InitializeComponent();
        }

        private void AboutDialog_Load(object sender, EventArgs e)
        {
            //ShowIcon = _about.UseIcon;

            if (_about.ApplicationIcon != null)
            {
                Icon = _about.ApplicationIcon;
            }

            //kbtnSystemInformation.Visible = _about.ShowSystemInformationButton;

            Text = $"About { _about.ApplicationName }";

            pbxApplicationImage.Image = _about.ApplicationIconImage;
        }

        private void kbtnSystemInformation_Click(object sender, EventArgs e)
        {
            Process.Start("msinfo32.exe");
        }
    }
}