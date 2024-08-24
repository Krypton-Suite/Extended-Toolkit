namespace Krypton.Toolkit.Suite.Extended.Software.Updater
{
    partial class DownloadUpdateDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownloadUpdateDialog));
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonTableLayoutPanel1 = new Krypton.Toolkit.KryptonTableLayoutPanel();
            this.pbxIcon = new System.Windows.Forms.PictureBox();
            this.kryptonTableLayoutPanel2 = new Krypton.Toolkit.KryptonTableLayoutPanel();
            this.kpbDownloadProgress = new Krypton.Toolkit.KryptonProgressBar();
            this.kwlInformation = new Krypton.Toolkit.KryptonWrapLabel();
            this.kwlSize = new Krypton.Toolkit.KryptonWrapLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.kryptonTableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).BeginInit();
            this.kryptonTableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonTableLayoutPanel1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(413, 111);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kryptonTableLayoutPanel1
            // 
            this.kryptonTableLayoutPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("kryptonTableLayoutPanel1.BackgroundImage")));
            this.kryptonTableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.kryptonTableLayoutPanel1.ColumnCount = 2;
            this.kryptonTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.kryptonTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.kryptonTableLayoutPanel1.Controls.Add(this.pbxIcon, 0, 0);
            this.kryptonTableLayoutPanel1.Controls.Add(this.kryptonTableLayoutPanel2, 1, 0);
            this.kryptonTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonTableLayoutPanel1.Name = "kryptonTableLayoutPanel1";
            this.kryptonTableLayoutPanel1.RowCount = 1;
            this.kryptonTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.kryptonTableLayoutPanel1.Size = new System.Drawing.Size(413, 111);
            this.kryptonTableLayoutPanel1.TabIndex = 1;
            // 
            // pbxIcon
            // 
            this.pbxIcon.BackColor = System.Drawing.Color.Transparent;
            this.pbxIcon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxIcon.Image = global::Krypton.Toolkit.Suite.Extended.Software.Updater.Properties.Resources.download_32;
            this.pbxIcon.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pbxIcon.Location = new System.Drawing.Point(4, 4);
            this.pbxIcon.Margin = new System.Windows.Forms.Padding(4);
            this.pbxIcon.Name = "pbxIcon";
            this.pbxIcon.Size = new System.Drawing.Size(59, 103);
            this.pbxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbxIcon.TabIndex = 1;
            this.pbxIcon.TabStop = false;
            // 
            // kryptonTableLayoutPanel2
            // 
            this.kryptonTableLayoutPanel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("kryptonTableLayoutPanel2.BackgroundImage")));
            this.kryptonTableLayoutPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.kryptonTableLayoutPanel2.ColumnCount = 1;
            this.kryptonTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.kryptonTableLayoutPanel2.Controls.Add(this.kpbDownloadProgress, 0, 2);
            this.kryptonTableLayoutPanel2.Controls.Add(this.kwlInformation, 0, 0);
            this.kryptonTableLayoutPanel2.Controls.Add(this.kwlSize, 0, 1);
            this.kryptonTableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonTableLayoutPanel2.Location = new System.Drawing.Point(70, 3);
            this.kryptonTableLayoutPanel2.Name = "kryptonTableLayoutPanel2";
            this.kryptonTableLayoutPanel2.RowCount = 3;
            this.kryptonTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.kryptonTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.kryptonTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.kryptonTableLayoutPanel2.Size = new System.Drawing.Size(340, 105);
            this.kryptonTableLayoutPanel2.TabIndex = 0;
            // 
            // kpbDownloadProgress
            // 
            this.kpbDownloadProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kpbDownloadProgress.Location = new System.Drawing.Point(3, 76);
            this.kpbDownloadProgress.Name = "kpbDownloadProgress";
            this.kpbDownloadProgress.Size = new System.Drawing.Size(334, 26);
            this.kpbDownloadProgress.StateCommon.Back.Color1 = System.Drawing.Color.Green;
            this.kpbDownloadProgress.StateDisabled.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.OneNote;
            this.kpbDownloadProgress.StateNormal.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.OneNote;
            this.kpbDownloadProgress.TabIndex = 0;
            this.kpbDownloadProgress.Text = "0%";
            this.kpbDownloadProgress.UseValueAsText = true;
            this.kpbDownloadProgress.Values.Text = "0%";
            // 
            // kwlInformation
            // 
            this.kwlInformation.AutoSize = false;
            this.kwlInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kwlInformation.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kwlInformation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kwlInformation.LabelStyle = Krypton.Toolkit.LabelStyle.AlternateControl;
            this.kwlInformation.Location = new System.Drawing.Point(3, 0);
            this.kwlInformation.Name = "kwlInformation";
            this.kwlInformation.Size = new System.Drawing.Size(334, 58);
            this.kwlInformation.Text = "Downloading update...";
            this.kwlInformation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // kwlSize
            // 
            this.kwlSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kwlSize.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kwlSize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kwlSize.LabelStyle = Krypton.Toolkit.LabelStyle.AlternateControl;
            this.kwlSize.Location = new System.Drawing.Point(3, 58);
            this.kwlSize.Name = "kwlSize";
            this.kwlSize.Size = new System.Drawing.Size(334, 15);
            this.kwlSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DownloadUpdateDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackStyle = Krypton.Toolkit.PaletteBackStyle.PanelClient;
            this.ClientSize = new System.Drawing.Size(413, 111);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DownloadUpdateDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Software Update";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DownloadUpdateDialog_FormClosing);
            this.Load += new System.EventHandler(this.DownloadUpdateDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonTableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).EndInit();
            this.kryptonTableLayoutPanel2.ResumeLayout(false);
            this.kryptonTableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private KryptonPanel kryptonPanel1;
        private KryptonTableLayoutPanel kryptonTableLayoutPanel1;
        private KryptonTableLayoutPanel kryptonTableLayoutPanel2;
        private KryptonProgressBar kpbDownloadProgress;
        private KryptonWrapLabel kwlInformation;
        private PictureBox pbxIcon;
        private KryptonWrapLabel kwlSize;
    }
}