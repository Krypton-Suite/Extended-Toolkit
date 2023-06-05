namespace Krypton.Toolkit.Suite.Extended.Software.Updater
{
    partial class NetSparkleCheckingForUpdatesWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NetSparkleCheckingForUpdatesWindow));
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonTableLayoutPanel1 = new Krypton.Toolkit.KryptonTableLayoutPanel();
            this.pbxApplicationIcon = new System.Windows.Forms.PictureBox();
            this.kwlblCheckingForUpdates = new Krypton.Toolkit.KryptonWrapLabel();
            this.kpbProgress = new Krypton.Toolkit.KryptonProgressBar();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnCancel = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.kryptonTableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxApplicationIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(530, 167);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // kryptonTableLayoutPanel1
            // 
            this.kryptonTableLayoutPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("kryptonTableLayoutPanel1.BackgroundImage")));
            this.kryptonTableLayoutPanel1.ColumnCount = 3;
            this.kryptonTableLayoutPanel1.Controls.Add(this.pbxApplicationIcon, 0, 0);
            this.kryptonTableLayoutPanel1.Controls.Add(this.kwlblCheckingForUpdates, 1, 0);
            this.kryptonTableLayoutPanel1.Controls.Add(this.kpbProgress, 1, 1);
            this.kryptonTableLayoutPanel1.Controls.Add(this.kryptonPanel2, 1, 2);
            this.kryptonTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonTableLayoutPanel1.Name = "kryptonTableLayoutPanel1";
            this.kryptonTableLayoutPanel1.RowCount = 3;
            this.kryptonTableLayoutPanel1.Size = new System.Drawing.Size(530, 167);
            this.kryptonTableLayoutPanel1.TabIndex = 0;
            // 
            // pbxApplicationIcon
            // 
            this.pbxApplicationIcon.BackColor = System.Drawing.Color.Transparent;
            this.pbxApplicationIcon.Location = new System.Drawing.Point(3, 3);
            this.pbxApplicationIcon.Name = "pbxApplicationIcon";
            this.pbxApplicationIcon.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.pbxApplicationIcon.Size = new System.Drawing.Size(48, 48);
            this.pbxApplicationIcon.TabIndex = 0;
            this.pbxApplicationIcon.TabStop = false;
            // 
            // kwlblCheckingForUpdates
            // 
            this.kwlblCheckingForUpdates.AutoSize = false;
            this.kryptonTableLayoutPanel1.SetColumnSpan(this.kwlblCheckingForUpdates, 2);
            this.kwlblCheckingForUpdates.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlblCheckingForUpdates.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kwlblCheckingForUpdates.LabelStyle = Krypton.Toolkit.LabelStyle.NormalControl;
            this.kwlblCheckingForUpdates.Location = new System.Drawing.Point(41, 0);
            this.kwlblCheckingForUpdates.Name = "kwlblCheckingForUpdates";
            this.kwlblCheckingForUpdates.Size = new System.Drawing.Size(486, 69);
            this.kwlblCheckingForUpdates.StateCommon.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlblCheckingForUpdates.Text = "Checking for Updates...";
            this.kwlblCheckingForUpdates.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // kpbProgress
            // 
            this.kryptonTableLayoutPanel1.SetColumnSpan(this.kpbProgress, 2);
            this.kpbProgress.Location = new System.Drawing.Point(41, 72);
            this.kpbProgress.Name = "kpbProgress";
            this.kpbProgress.Size = new System.Drawing.Size(486, 23);
            this.kpbProgress.TabIndex = 2;
            this.kpbProgress.UseKrypton = true;
            // 
            // kryptonPanel2
            // 
            this.kryptonTableLayoutPanel1.SetColumnSpan(this.kryptonPanel2, 2);
            this.kryptonPanel2.Location = new System.Drawing.Point(41, 101);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(486, 63);
            this.kryptonPanel2.TabIndex = 3;
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.Location = new System.Drawing.Point(198, 18);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.Size = new System.Drawing.Size(90, 25);
            this.kbtnCancel.TabIndex = 0;
            this.kbtnCancel.Values.Text = "&Cancel";
            this.kbtnCancel.Click += new System.EventHandler(this.kbtnCancel_Click);
            // 
            // NetSparkleCheckingForUpdatesWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(530, 167);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NetSparkleCheckingForUpdatesWindow";
            this.Text = "Checking for Updates";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NetSparkleCheckingForUpdatesWindow_FormClosing);
            this.Controls.SetChildIndex(this.kryptonPanel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonTableLayoutPanel1.ResumeLayout(false);
            this.kryptonTableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxApplicationIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private KryptonPanel kryptonPanel1;
        private KryptonTableLayoutPanel kryptonTableLayoutPanel1;
        private PictureBox pbxApplicationIcon;
        private KryptonWrapLabel kwlblCheckingForUpdates;
        private KryptonProgressBar kpbProgress;
        private KryptonPanel kryptonPanel2;
        private KryptonButton kbtnCancel;
    }
}