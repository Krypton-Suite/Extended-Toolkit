namespace Krypton.Toolkit.Suite.Extended.Software.Updater
{
    partial class UpdateDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateDialog));
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonTableLayoutPanel1 = new Krypton.Toolkit.KryptonTableLayoutPanel();
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.klblTitle = new Krypton.Toolkit.KryptonLabel();
            this.klblDescription = new Krypton.Toolkit.KryptonLabel();
            this.klblReleaseNotes = new Krypton.Toolkit.KryptonLabel();
            this.kbtnSkip = new Krypton.Toolkit.KryptonButton();
            this.kbtnRemind = new Krypton.Toolkit.KryptonButton();
            this.kbtnUpdate = new Krypton.Toolkit.KryptonButton();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.wvChangelog = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.kwbChangelog = new Krypton.Toolkit.KryptonWebBrowser();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.kryptonTableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wvChangelog)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonTableLayoutPanel1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(643, 612);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kryptonTableLayoutPanel1
            // 
            this.kryptonTableLayoutPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("kryptonTableLayoutPanel1.BackgroundImage")));
            this.kryptonTableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.kryptonTableLayoutPanel1.ColumnCount = 4;
            this.kryptonTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.kryptonTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.kryptonTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.kryptonTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.kryptonTableLayoutPanel1.Controls.Add(this.pictureBoxIcon, 0, 0);
            this.kryptonTableLayoutPanel1.Controls.Add(this.klblTitle, 1, 0);
            this.kryptonTableLayoutPanel1.Controls.Add(this.klblDescription, 1, 1);
            this.kryptonTableLayoutPanel1.Controls.Add(this.klblReleaseNotes, 1, 2);
            this.kryptonTableLayoutPanel1.Controls.Add(this.kbtnSkip, 1, 4);
            this.kryptonTableLayoutPanel1.Controls.Add(this.kbtnRemind, 2, 4);
            this.kryptonTableLayoutPanel1.Controls.Add(this.kbtnUpdate, 3, 4);
            this.kryptonTableLayoutPanel1.Controls.Add(this.kryptonPanel2, 1, 3);
            this.kryptonTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonTableLayoutPanel1.Name = "kryptonTableLayoutPanel1";
            this.kryptonTableLayoutPanel1.RowCount = 5;
            this.kryptonTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.kryptonTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.kryptonTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.kryptonTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.kryptonTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.kryptonTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.kryptonTableLayoutPanel1.Size = new System.Drawing.Size(643, 612);
            this.kryptonTableLayoutPanel1.TabIndex = 0;
            // 
            // pictureBoxIcon
            // 
            this.pictureBoxIcon.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxIcon.Image = global::Krypton.Toolkit.Suite.Extended.Software.Updater.Properties.Resources.update2;
            this.pictureBoxIcon.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBoxIcon.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxIcon.Name = "pictureBoxIcon";
            this.pictureBoxIcon.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.kryptonTableLayoutPanel1.SetRowSpan(this.pictureBoxIcon, 2);
            this.pictureBoxIcon.Size = new System.Drawing.Size(70, 66);
            this.pictureBoxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxIcon.TabIndex = 9;
            this.pictureBoxIcon.TabStop = false;
            // 
            // klblTitle
            // 
            this.klblTitle.AutoSize = false;
            this.kryptonTableLayoutPanel1.SetColumnSpan(this.klblTitle, 3);
            this.klblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.klblTitle.LabelStyle = Krypton.Toolkit.LabelStyle.TitlePanel;
            this.klblTitle.Location = new System.Drawing.Point(79, 3);
            this.klblTitle.Name = "klblTitle";
            this.klblTitle.Size = new System.Drawing.Size(561, 25);
            this.klblTitle.TabIndex = 10;
            this.klblTitle.Values.Text = "kryptonLabel1";
            // 
            // klblDescription
            // 
            this.klblDescription.AutoSize = false;
            this.kryptonTableLayoutPanel1.SetColumnSpan(this.klblDescription, 3);
            this.klblDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.klblDescription.Location = new System.Drawing.Point(79, 34);
            this.klblDescription.Name = "klblDescription";
            this.klblDescription.Size = new System.Drawing.Size(561, 35);
            this.klblDescription.TabIndex = 11;
            this.klblDescription.Values.Text = "kryptonLabel2";
            // 
            // klblReleaseNotes
            // 
            this.kryptonTableLayoutPanel1.SetColumnSpan(this.klblReleaseNotes, 3);
            this.klblReleaseNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.klblReleaseNotes.LabelStyle = Krypton.Toolkit.LabelStyle.BoldPanel;
            this.klblReleaseNotes.Location = new System.Drawing.Point(79, 75);
            this.klblReleaseNotes.Name = "klblReleaseNotes";
            this.klblReleaseNotes.Size = new System.Drawing.Size(561, 20);
            this.klblReleaseNotes.TabIndex = 12;
            this.klblReleaseNotes.Values.Text = "kryptonLabel3";
            // 
            // kbtnSkip
            // 
            this.kbtnSkip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.kbtnSkip.AutoSize = true;
            this.kbtnSkip.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnSkip.Location = new System.Drawing.Point(79, 587);
            this.kbtnSkip.Name = "kbtnSkip";
            this.kbtnSkip.Size = new System.Drawing.Size(111, 22);
            this.kbtnSkip.TabIndex = 14;
            this.kbtnSkip.Values.Image = global::Krypton.Toolkit.Suite.Extended.Software.Updater.Properties.Resources.hand_point;
            this.kbtnSkip.Values.Text = "kryptonButton1";
            this.kbtnSkip.Click += new System.EventHandler(this.kbtnSkip_Click);
            // 
            // kbtnRemind
            // 
            this.kbtnRemind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnRemind.AutoSize = true;
            this.kbtnRemind.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnRemind.Location = new System.Drawing.Point(340, 587);
            this.kbtnRemind.Name = "kbtnRemind";
            this.kbtnRemind.Size = new System.Drawing.Size(111, 22);
            this.kbtnRemind.TabIndex = 15;
            this.kbtnRemind.Values.Image = global::Krypton.Toolkit.Suite.Extended.Software.Updater.Properties.Resources.clock_go;
            this.kbtnRemind.Values.Text = "kryptonButton2";
            this.kbtnRemind.Click += new System.EventHandler(this.kbtnRemind_Click);
            // 
            // kbtnUpdate
            // 
            this.kbtnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnUpdate.AutoSize = true;
            this.kbtnUpdate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnUpdate.Location = new System.Drawing.Point(529, 587);
            this.kbtnUpdate.Name = "kbtnUpdate";
            this.kbtnUpdate.Size = new System.Drawing.Size(111, 22);
            this.kbtnUpdate.TabIndex = 16;
            this.kbtnUpdate.Values.Image = global::Krypton.Toolkit.Suite.Extended.Software.Updater.Properties.Resources.download;
            this.kbtnUpdate.Values.Text = "kryptonButton3";
            this.kbtnUpdate.Click += new System.EventHandler(this.kbtnUpdate_Click);
            // 
            // kryptonPanel2
            // 
            this.kryptonTableLayoutPanel1.SetColumnSpan(this.kryptonPanel2, 3);
            this.kryptonPanel2.Controls.Add(this.wvChangelog);
            this.kryptonPanel2.Controls.Add(this.kwbChangelog);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(79, 101);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(561, 480);
            this.kryptonPanel2.TabIndex = 17;
            // 
            // wvChangelog
            // 
            this.wvChangelog.AllowExternalDrop = true;
            this.wvChangelog.CreationProperties = null;
            this.wvChangelog.DefaultBackgroundColor = System.Drawing.Color.White;
            this.wvChangelog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wvChangelog.Location = new System.Drawing.Point(0, 0);
            this.wvChangelog.Name = "wvChangelog";
            this.wvChangelog.Size = new System.Drawing.Size(561, 480);
            this.wvChangelog.TabIndex = 14;
            this.wvChangelog.ZoomFactor = 1D;
            // 
            // kwbChangelog
            // 
            this.kwbChangelog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kwbChangelog.Location = new System.Drawing.Point(0, 0);
            this.kwbChangelog.Name = "kwbChangelog";
            this.kwbChangelog.Size = new System.Drawing.Size(561, 480);
            this.kwbChangelog.TabIndex = 0;
            // 
            // UpdateDialog
            // 
            this.AcceptButton = this.kbtnUpdate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 612);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "UpdateDialog";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UpdateDialog_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UpdateDialog_FormClosed);
            this.Load += new System.EventHandler(this.UpdateDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonTableLayoutPanel1.ResumeLayout(false);
            this.kryptonTableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.wvChangelog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KryptonPanel kryptonPanel1;
        private KryptonTableLayoutPanel kryptonTableLayoutPanel1;
        private PictureBox pictureBoxIcon;
        private KryptonLabel klblTitle;
        private KryptonLabel klblDescription;
        private KryptonLabel klblReleaseNotes;
        private KryptonButton kbtnSkip;
        private KryptonButton kbtnRemind;
        private KryptonButton kbtnUpdate;
        private KryptonPanel kryptonPanel2;
        private KryptonWebBrowser kwbChangelog;
        private Microsoft.Web.WebView2.WinForms.WebView2 wvChangelog;
    }
}