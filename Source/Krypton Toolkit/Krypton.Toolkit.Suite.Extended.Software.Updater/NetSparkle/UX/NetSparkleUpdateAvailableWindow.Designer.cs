namespace Krypton.Toolkit.Suite.Extended.Software.Updater
{
    partial class NetSparkleUpdateAvailableWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NetSparkleUpdateAvailableWindow));
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonTableLayoutPanel1 = new Krypton.Toolkit.KryptonTableLayoutPanel();
            this.pbxApplicationIcon = new System.Windows.Forms.PictureBox();
            this.kwlReleaseNotes = new Krypton.Toolkit.KryptonLabel();
            this.kwlHeader = new Krypton.Toolkit.KryptonLabel();
            this.kwbReleaseNotes = new Krypton.Toolkit.KryptonWebBrowser();
            this.kryptonTableLayoutPanel2 = new Krypton.Toolkit.KryptonTableLayoutPanel();
            this.kbtnSkipVersion = new Krypton.Toolkit.KryptonButton();
            this.kbtnRemindLater = new Krypton.Toolkit.KryptonButton();
            this.kbtnInstallUpdate = new Krypton.Toolkit.KryptonButton();
            this.kwlInformationText = new Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.kryptonTableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxApplicationIcon)).BeginInit();
            this.kryptonTableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonTableLayoutPanel1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(604, 556);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // kryptonTableLayoutPanel1
            // 
            this.kryptonTableLayoutPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("kryptonTableLayoutPanel1.BackgroundImage")));
            this.kryptonTableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.kryptonTableLayoutPanel1.ColumnCount = 2;
            this.kryptonTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.kryptonTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.kryptonTableLayoutPanel1.Controls.Add(this.pbxApplicationIcon, 0, 0);
            this.kryptonTableLayoutPanel1.Controls.Add(this.kwlReleaseNotes, 1, 2);
            this.kryptonTableLayoutPanel1.Controls.Add(this.kwlHeader, 1, 0);
            this.kryptonTableLayoutPanel1.Controls.Add(this.kwbReleaseNotes, 1, 3);
            this.kryptonTableLayoutPanel1.Controls.Add(this.kryptonTableLayoutPanel2, 1, 4);
            this.kryptonTableLayoutPanel1.Controls.Add(this.kwlInformationText, 1, 1);
            this.kryptonTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonTableLayoutPanel1.Name = "kryptonTableLayoutPanel1";
            this.kryptonTableLayoutPanel1.RowCount = 5;
            this.kryptonTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.kryptonTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.kryptonTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.kryptonTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.kryptonTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.kryptonTableLayoutPanel1.Size = new System.Drawing.Size(604, 556);
            this.kryptonTableLayoutPanel1.TabIndex = 0;
            // 
            // pbxApplicationIcon
            // 
            this.pbxApplicationIcon.BackColor = System.Drawing.Color.Transparent;
            this.pbxApplicationIcon.Location = new System.Drawing.Point(3, 3);
            this.pbxApplicationIcon.Name = "pbxApplicationIcon";
            this.pbxApplicationIcon.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.pbxApplicationIcon.Size = new System.Drawing.Size(32, 32);
            this.pbxApplicationIcon.TabIndex = 0;
            this.pbxApplicationIcon.TabStop = false;
            // 
            // kwlReleaseNotes
            // 
            this.kwlReleaseNotes.AutoSize = false;
            this.kwlReleaseNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kwlReleaseNotes.LabelStyle = Krypton.Toolkit.LabelStyle.NormalPanel;
            this.kwlReleaseNotes.Location = new System.Drawing.Point(41, 72);
            this.kwlReleaseNotes.Name = "kwlReleaseNotes";
            this.kwlReleaseNotes.Size = new System.Drawing.Size(560, 20);
            this.kwlReleaseNotes.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlReleaseNotes.TabIndex = 3;
            this.kwlReleaseNotes.Values.Text = "kryptonLabel3";
            // 
            // kwlHeader
            // 
            this.kwlHeader.AutoSize = false;
            this.kwlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kwlHeader.LabelStyle = Krypton.Toolkit.LabelStyle.NormalPanel;
            this.kwlHeader.Location = new System.Drawing.Point(41, 3);
            this.kwlHeader.Name = "kwlHeader";
            this.kwlHeader.Size = new System.Drawing.Size(560, 32);
            this.kwlHeader.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlHeader.TabIndex = 1;
            this.kwlHeader.Values.Text = "kryptonLabel1";
            // 
            // kwbReleaseNotes
            // 
            this.kwbReleaseNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kwbReleaseNotes.IsWebBrowserContextMenuEnabled = false;
            this.kwbReleaseNotes.Location = new System.Drawing.Point(41, 98);
            this.kwbReleaseNotes.Name = "kwbReleaseNotes";
            this.kwbReleaseNotes.Size = new System.Drawing.Size(560, 415);
            this.kwbReleaseNotes.TabIndex = 4;
            // 
            // kryptonTableLayoutPanel2
            // 
            this.kryptonTableLayoutPanel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("kryptonTableLayoutPanel2.BackgroundImage")));
            this.kryptonTableLayoutPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.kryptonTableLayoutPanel2.ColumnCount = 3;
            this.kryptonTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.kryptonTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.kryptonTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.kryptonTableLayoutPanel2.Controls.Add(this.kbtnSkipVersion, 0, 0);
            this.kryptonTableLayoutPanel2.Controls.Add(this.kbtnRemindLater, 1, 0);
            this.kryptonTableLayoutPanel2.Controls.Add(this.kbtnInstallUpdate, 2, 0);
            this.kryptonTableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonTableLayoutPanel2.Location = new System.Drawing.Point(41, 519);
            this.kryptonTableLayoutPanel2.Name = "kryptonTableLayoutPanel2";
            this.kryptonTableLayoutPanel2.RowCount = 1;
            this.kryptonTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.kryptonTableLayoutPanel2.Size = new System.Drawing.Size(560, 34);
            this.kryptonTableLayoutPanel2.TabIndex = 9;
            // 
            // kbtnSkipVersion
            // 
            this.kbtnSkipVersion.Dock = System.Windows.Forms.DockStyle.Left;
            this.kbtnSkipVersion.Location = new System.Drawing.Point(3, 3);
            this.kbtnSkipVersion.Name = "kbtnSkipVersion";
            this.kbtnSkipVersion.Size = new System.Drawing.Size(141, 28);
            this.kbtnSkipVersion.TabIndex = 0;
            this.kbtnSkipVersion.Values.Image = global::Krypton.Toolkit.Suite.Extended.Software.Updater.Properties.Resources.hand_point;
            this.kbtnSkipVersion.Values.Text = "&Skip this version";
            this.kbtnSkipVersion.Click += new System.EventHandler(this.kbtnSkipVersion_Click);
            // 
            // kbtnRemindLater
            // 
            this.kbtnRemindLater.Dock = System.Windows.Forms.DockStyle.Right;
            this.kbtnRemindLater.Location = new System.Drawing.Point(259, 3);
            this.kbtnRemindLater.Name = "kbtnRemindLater";
            this.kbtnRemindLater.Size = new System.Drawing.Size(146, 28);
            this.kbtnRemindLater.TabIndex = 1;
            this.kbtnRemindLater.Values.Image = global::Krypton.Toolkit.Suite.Extended.Software.Updater.Properties.Resources.clock_play;
            this.kbtnRemindLater.Values.Text = "R&emind me later";
            this.kbtnRemindLater.Click += new System.EventHandler(this.kbtnRemindLater_Click);
            // 
            // kbtnInstallUpdate
            // 
            this.kbtnInstallUpdate.Dock = System.Windows.Forms.DockStyle.Right;
            this.kbtnInstallUpdate.Location = new System.Drawing.Point(411, 3);
            this.kbtnInstallUpdate.Name = "kbtnInstallUpdate";
            this.kbtnInstallUpdate.Size = new System.Drawing.Size(146, 28);
            this.kbtnInstallUpdate.TabIndex = 2;
            this.kbtnInstallUpdate.Values.Image = global::Krypton.Toolkit.Suite.Extended.Software.Updater.Properties.Resources.download;
            this.kbtnInstallUpdate.Values.Text = "&Install update";
            this.kbtnInstallUpdate.Click += new System.EventHandler(this.kbtnInstallUpdate_Click);
            // 
            // kwlInformationText
            // 
            this.kwlInformationText.AutoSize = false;
            this.kwlInformationText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kwlInformationText.LabelStyle = Krypton.Toolkit.LabelStyle.NormalPanel;
            this.kwlInformationText.Location = new System.Drawing.Point(41, 41);
            this.kwlInformationText.Name = "kwlInformationText";
            this.kwlInformationText.Size = new System.Drawing.Size(560, 25);
            this.kwlInformationText.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlInformationText.TabIndex = 11;
            this.kwlInformationText.Values.Text = "kryptonLabel2";
            // 
            // NetSparkleUpdateAvailableWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 556);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NetSparkleUpdateAvailableWindow";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update Available";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NetSparkleUpdateAvailableWindow_FormClosing);
            this.Controls.SetChildIndex(this.kryptonPanel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonTableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxApplicationIcon)).EndInit();
            this.kryptonTableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private KryptonPanel kryptonPanel1;
        private KryptonTableLayoutPanel kryptonTableLayoutPanel1;
        private PictureBox pbxApplicationIcon;
        private KryptonLabel kwlReleaseNotes;
        private KryptonLabel kwlHeader;
        private KryptonWebBrowser kwbReleaseNotes;
        private KryptonTableLayoutPanel kryptonTableLayoutPanel2;
        private KryptonButton kbtnSkipVersion;
        private KryptonButton kbtnRemindLater;
        private KryptonButton kbtnInstallUpdate;
        private KryptonLabel kwlInformationText;
    }
}