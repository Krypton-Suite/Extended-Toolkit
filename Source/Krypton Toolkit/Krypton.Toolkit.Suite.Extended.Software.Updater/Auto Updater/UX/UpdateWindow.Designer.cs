namespace Krypton.Toolkit.Suite.Extended.Software.Updater
{
    partial class UpdateWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateWindow));
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonTableLayoutPanel1 = new Krypton.Toolkit.KryptonTableLayoutPanel();
            this.pbxApplicationIcon = new System.Windows.Forms.PictureBox();
            this.kwlHeader = new Krypton.Toolkit.KryptonWrapLabel();
            this.kwlDetails = new Krypton.Toolkit.KryptonWrapLabel();
            this.kwlReleaseNotes = new Krypton.Toolkit.KryptonWrapLabel();
            this.kbtnSkip = new Krypton.Toolkit.KryptonButton();
            this.kbtnRemind = new Krypton.Toolkit.KryptonButton();
            this.kbtnUpdate = new Krypton.Toolkit.KryptonButton();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.wvReleaseNotes = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.kwbReleaseNotes = new Krypton.Toolkit.KryptonWebBrowser();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.kryptonTableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxApplicationIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wvReleaseNotes)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonTableLayoutPanel1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(693, 661);
            this.kryptonPanel1.TabIndex = 1;
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
            this.kryptonTableLayoutPanel1.Controls.Add(this.pbxApplicationIcon, 0, 0);
            this.kryptonTableLayoutPanel1.Controls.Add(this.kwlHeader, 1, 0);
            this.kryptonTableLayoutPanel1.Controls.Add(this.kwlDetails, 1, 1);
            this.kryptonTableLayoutPanel1.Controls.Add(this.kwlReleaseNotes, 1, 2);
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
            this.kryptonTableLayoutPanel1.Size = new System.Drawing.Size(693, 661);
            this.kryptonTableLayoutPanel1.TabIndex = 0;
            // 
            // pbxApplicationIcon
            // 
            this.pbxApplicationIcon.BackColor = System.Drawing.Color.Transparent;
            this.pbxApplicationIcon.Image = global::Krypton.Toolkit.Suite.Extended.Software.Updater.Properties.Resources.update2;
            this.pbxApplicationIcon.Location = new System.Drawing.Point(3, 3);
            this.pbxApplicationIcon.Name = "pbxApplicationIcon";
            this.pbxApplicationIcon.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.kryptonTableLayoutPanel1.SetRowSpan(this.pbxApplicationIcon, 2);
            this.pbxApplicationIcon.Size = new System.Drawing.Size(69, 69);
            this.pbxApplicationIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbxApplicationIcon.TabIndex = 0;
            this.pbxApplicationIcon.TabStop = false;
            // 
            // kwlHeader
            // 
            this.kwlHeader.AutoSize = false;
            this.kryptonTableLayoutPanel1.SetColumnSpan(this.kwlHeader, 3);
            this.kwlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kwlHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.kwlHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kwlHeader.LabelStyle = Krypton.Toolkit.LabelStyle.NormalControl;
            this.kwlHeader.Location = new System.Drawing.Point(78, 0);
            this.kwlHeader.Name = "kwlHeader";
            this.kwlHeader.Size = new System.Drawing.Size(612, 23);
            this.kwlHeader.StateCommon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.kwlHeader.Text = "kryptonWrapLabel1";
            // 
            // kwlDetails
            // 
            this.kwlDetails.AutoSize = false;
            this.kryptonTableLayoutPanel1.SetColumnSpan(this.kwlDetails, 3);
            this.kwlDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kwlDetails.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kwlDetails.LabelStyle = Krypton.Toolkit.LabelStyle.NormalControl;
            this.kwlDetails.Location = new System.Drawing.Point(78, 23);
            this.kwlDetails.Name = "kwlDetails";
            this.kwlDetails.Size = new System.Drawing.Size(612, 52);
            this.kwlDetails.StateCommon.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlDetails.Text = "kryptonWrapLabel2";
            // 
            // kwlReleaseNotes
            // 
            this.kwlReleaseNotes.AutoSize = false;
            this.kryptonTableLayoutPanel1.SetColumnSpan(this.kwlReleaseNotes, 3);
            this.kwlReleaseNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kwlReleaseNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlReleaseNotes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kwlReleaseNotes.LabelStyle = Krypton.Toolkit.LabelStyle.NormalControl;
            this.kwlReleaseNotes.Location = new System.Drawing.Point(78, 75);
            this.kwlReleaseNotes.Name = "kwlReleaseNotes";
            this.kwlReleaseNotes.Size = new System.Drawing.Size(612, 18);
            this.kwlReleaseNotes.StateCommon.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlReleaseNotes.Text = "kryptonWrapLabel3";
            // 
            // kbtnSkip
            // 
            this.kbtnSkip.AutoSize = true;
            this.kbtnSkip.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnSkip.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.kbtnSkip.Dock = System.Windows.Forms.DockStyle.Left;
            this.kbtnSkip.Location = new System.Drawing.Point(78, 632);
            this.kbtnSkip.Name = "kbtnSkip";
            this.kbtnSkip.Size = new System.Drawing.Size(137, 26);
            this.kbtnSkip.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnSkip.TabIndex = 5;
            this.kbtnSkip.Values.Image = global::Krypton.Toolkit.Suite.Extended.Software.Updater.Properties.Resources.hand_point;
            this.kbtnSkip.Values.Text = "&Skip this version";
            this.kbtnSkip.Click += new System.EventHandler(this.kbtnSkip_Click);
            // 
            // kbtnRemind
            // 
            this.kbtnRemind.AutoSize = true;
            this.kbtnRemind.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnRemind.Dock = System.Windows.Forms.DockStyle.Right;
            this.kbtnRemind.Location = new System.Drawing.Point(343, 632);
            this.kbtnRemind.Name = "kbtnRemind";
            this.kbtnRemind.Size = new System.Drawing.Size(139, 26);
            this.kbtnRemind.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnRemind.TabIndex = 6;
            this.kbtnRemind.Values.Image = global::Krypton.Toolkit.Suite.Extended.Software.Updater.Properties.Resources.clock_go;
            this.kbtnRemind.Values.Text = "R&emind me later";
            this.kbtnRemind.Click += new System.EventHandler(this.kbtnRemind_Click);
            // 
            // kbtnUpdate
            // 
            this.kbtnUpdate.AutoSize = true;
            this.kbtnUpdate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnUpdate.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kbtnUpdate.Dock = System.Windows.Forms.DockStyle.Right;
            this.kbtnUpdate.Location = new System.Drawing.Point(614, 632);
            this.kbtnUpdate.Name = "kbtnUpdate";
            this.kbtnUpdate.Size = new System.Drawing.Size(76, 26);
            this.kbtnUpdate.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnUpdate.TabIndex = 7;
            this.kbtnUpdate.Values.Image = global::Krypton.Toolkit.Suite.Extended.Software.Updater.Properties.Resources.download;
            this.kbtnUpdate.Values.Text = "&Update";
            this.kbtnUpdate.Click += new System.EventHandler(this.kbtnUpdate_Click);
            // 
            // kryptonPanel2
            // 
            this.kryptonTableLayoutPanel1.SetColumnSpan(this.kryptonPanel2, 3);
            this.kryptonPanel2.Controls.Add(this.wvReleaseNotes);
            this.kryptonPanel2.Controls.Add(this.kwbReleaseNotes);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(78, 96);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(612, 530);
            this.kryptonPanel2.TabIndex = 8;
            // 
            // wvReleaseNotes
            // 
            this.wvReleaseNotes.AllowExternalDrop = true;
            this.wvReleaseNotes.CreationProperties = null;
            this.wvReleaseNotes.DefaultBackgroundColor = System.Drawing.Color.White;
            this.wvReleaseNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wvReleaseNotes.Location = new System.Drawing.Point(0, 0);
            this.wvReleaseNotes.Name = "wvReleaseNotes";
            this.wvReleaseNotes.Size = new System.Drawing.Size(612, 530);
            this.wvReleaseNotes.TabIndex = 1;
            this.wvReleaseNotes.ZoomFactor = 1D;
            // 
            // kwbReleaseNotes
            // 
            this.kwbReleaseNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kwbReleaseNotes.Location = new System.Drawing.Point(0, 0);
            this.kwbReleaseNotes.Name = "kwbReleaseNotes";
            this.kwbReleaseNotes.ScriptErrorsSuppressed = true;
            this.kwbReleaseNotes.Size = new System.Drawing.Size(612, 530);
            this.kwbReleaseNotes.TabIndex = 0;
            // 
            // UpdateWindow
            // 
            this.AcceptButton = this.kbtnUpdate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 661);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UpdateWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UpdateWindow_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UpdateWindow_FormClosed);
            this.Load += new System.EventHandler(this.UpdateWindow_Load);
            this.Controls.SetChildIndex(this.kryptonPanel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonTableLayoutPanel1.ResumeLayout(false);
            this.kryptonTableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxApplicationIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.wvReleaseNotes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KryptonPanel kryptonPanel1;
        private KryptonTableLayoutPanel kryptonTableLayoutPanel1;
        private PictureBox pbxApplicationIcon;
        private KryptonWrapLabel kwlHeader;
        private KryptonWrapLabel kwlDetails;
        private KryptonWrapLabel kwlReleaseNotes;
        private KryptonButton kbtnSkip;
        private KryptonButton kbtnRemind;
        private KryptonButton kbtnUpdate;
        private KryptonPanel kryptonPanel2;
        private KryptonWebBrowser kwbReleaseNotes;
        private Microsoft.Web.WebView2.WinForms.WebView2 wvReleaseNotes;
    }
}