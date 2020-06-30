using System;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Software.Updater.NetSparkle
{
    public class DownloadProgressDialog : KryptonForm, IDownloadProgress
    {
        #region Designer Code
        private KryptonPanel kryptonPanel1;
        private KryptonLabel klblDownloadProgress;
        private KryptonLabel klblHeader;
        private KryptonButton kbtnInstall;
        private System.Windows.Forms.ProgressBar pbDownload;
        private KryptonButton kbtnCancel;
        private System.Windows.Forms.PictureBox pbxApplicationIcon;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownloadProgressDialog));
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.pbxApplicationIcon = new System.Windows.Forms.PictureBox();
            this.klblHeader = new Krypton.Toolkit.KryptonLabel();
            this.klblDownloadProgress = new Krypton.Toolkit.KryptonLabel();
            this.pbDownload = new System.Windows.Forms.ProgressBar();
            this.kbtnInstall = new Krypton.Toolkit.KryptonButton();
            this.kbtnCancel = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxApplicationIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnCancel);
            this.kryptonPanel1.Controls.Add(this.kbtnInstall);
            this.kryptonPanel1.Controls.Add(this.pbDownload);
            this.kryptonPanel1.Controls.Add(this.klblDownloadProgress);
            this.kryptonPanel1.Controls.Add(this.klblHeader);
            this.kryptonPanel1.Controls.Add(this.pbxApplicationIcon);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(429, 133);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // pbxApplicationIcon
            // 
            this.pbxApplicationIcon.BackColor = System.Drawing.Color.Transparent;
            this.pbxApplicationIcon.Location = new System.Drawing.Point(12, 12);
            this.pbxApplicationIcon.Name = "pbxApplicationIcon";
            this.pbxApplicationIcon.Size = new System.Drawing.Size(48, 48);
            this.pbxApplicationIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbxApplicationIcon.TabIndex = 1;
            this.pbxApplicationIcon.TabStop = false;
            // 
            // klblHeader
            // 
            this.klblHeader.Location = new System.Drawing.Point(66, 12);
            this.klblHeader.Name = "klblHeader";
            this.klblHeader.Size = new System.Drawing.Size(145, 24);
            this.klblHeader.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblHeader.TabIndex = 2;
            this.klblHeader.Values.Text = "Downloading {0}";
            // 
            // klblDownloadProgress
            // 
            this.klblDownloadProgress.Location = new System.Drawing.Point(66, 42);
            this.klblDownloadProgress.Name = "klblDownloadProgress";
            this.klblDownloadProgress.Size = new System.Drawing.Size(128, 21);
            this.klblDownloadProgress.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.klblDownloadProgress.TabIndex = 3;
            this.klblDownloadProgress.Values.Text = "({0} MB / {1} MB)";
            // 
            // pbDownload
            // 
            this.pbDownload.Location = new System.Drawing.Point(12, 69);
            this.pbDownload.Name = "pbDownload";
            this.pbDownload.Size = new System.Drawing.Size(405, 27);
            this.pbDownload.TabIndex = 4;
            // 
            // kbtnInstall
            // 
            this.kbtnInstall.Location = new System.Drawing.Point(131, 69);
            this.kbtnInstall.Name = "kbtnInstall";
            this.kbtnInstall.Size = new System.Drawing.Size(167, 25);
            this.kbtnInstall.TabIndex = 1;
            this.kbtnInstall.Values.Text = "Install && &Relaunch";
            this.kbtnInstall.Click += new System.EventHandler(this.kbtnInstall_Click);
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Location = new System.Drawing.Point(169, 100);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.Size = new System.Drawing.Size(90, 25);
            this.kbtnCancel.TabIndex = 3;
            this.kbtnCancel.Values.Text = "&Cancel";
            this.kbtnCancel.Click += new System.EventHandler(this.kbtnCancel_Click);
            // 
            // DownloadProgressDialog
            // 
            this.CancelButton = this.kbtnCancel;
            this.ClientSize = new System.Drawing.Size(429, 133);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DownloadProgressDialog";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Software Download";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DownloadProgressDialog_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxApplicationIcon)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// Event to fire when the download UI is complete; tells you 
        /// if the install process should happen or not
        /// </summary>
        public event DownloadInstallEventHandler DownloadProcessCompleted;

        private bool _shouldLaunchInstallFileOnClose = false;
        private bool _didCallDownloadProcessCompletedHandler = false;

        public DownloadProgressDialog(AppCastItem item, Icon applicationIcon)
        {
            InitializeComponent();

            pbxApplicationIcon.Image = applicationIcon.ToBitmap();

            Icon = applicationIcon;

            kbtnInstall.Visible = false;

            klblHeader.Text = $"Downloading { item.AppName } { item.Version }";

            klblDownloadProgress.Text = string.Empty;

            pbDownload.Maximum = 100;

            pbDownload.Minimum = 0;

            pbDownload.Step = 1;
        }

        private void kbtnInstall_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            _shouldLaunchInstallFileOnClose = true;
            _didCallDownloadProcessCompletedHandler = true;
            DownloadProcessCompleted?.Invoke(this, new DownloadInstallEventArgs(true));
        }

        private void kbtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            _didCallDownloadProcessCompletedHandler = true;
            DownloadProcessCompleted?.Invoke(this, new DownloadInstallEventArgs(false));
        }

        /// <summary>
        /// Show the UI and waits
        /// </summary>
        void IDownloadProgress.Show(bool isOnMainThread)
        {
            Show();
            if (!isOnMainThread)
            {
                Application.Run(this);
            }
        }

        /// <summary>
        /// Update UI to show file is downloaded and signature check result
        /// </summary>
        public void FinishedDownloadingFile(bool isDownloadedFileValid)
        {
            pbDownload.Visible = false;
            kbtnCancel.Visible = false;
            klblDownloadProgress.Visible = false;
            if (isDownloadedFileValid)
            {
                kbtnInstall.Visible = true;
            }
            else
            {
                kbtnInstall.Visible = false;
            }
        }

        /// <summary>
        /// Display an error message
        /// </summary>
        /// <param name="errorMessage">The error message to display</param>
        public bool DisplayErrorMessage(string errorMessage)
        {
            klblDownloadProgress.Visible = true;
            pbDownload.Visible = false;
            kbtnInstall.Visible = false;
            kbtnCancel.Text = "&Close";
            klblDownloadProgress.Text = errorMessage;
            return true;
        }

        /// <summary>
        /// Close UI
        /// </summary>
        void IDownloadProgress.Close()
        {
            DialogResult = DialogResult.Abort;
            CloseForm();
        }

        private void CloseForm()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate () { Close(); });
            }
            else
            {
                Close();
            }
        }

        /// <summary>
        /// Event called when the client download progress changes
        /// </summary>
        private void OnDownloadProgressChanged(object sender, long bytesReceived, long totalBytesToReceive, int percentage)
        {
            pbDownload.Value = percentage;
            klblDownloadProgress.Text = "(" + Utilities.ConvertNumBytesToUserReadableString(bytesReceived) + " / " +
                Utilities.ConvertNumBytesToUserReadableString(totalBytesToReceive) + ")";
        }

        /// <summary>
        /// 
        /// </summary>
        public void OnDownload_ProgressChanged(object sender, ItemDownloadProgressEventArgs e)
        {
            OnDownloadProgressChanged(sender, e.BytesReceived, e.TotalBytesToReceive, e.ProgressPercentage);
        }

        public void SetDownloadAndInstallButtonEnabled(bool shouldBeEnabled)
        {
            kbtnInstall.Enabled = shouldBeEnabled;
        }

        private void DownloadProgressDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_didCallDownloadProcessCompletedHandler)
            {
                _didCallDownloadProcessCompletedHandler = true;

                DownloadProcessCompleted?.Invoke(this, new DownloadInstallEventArgs(_shouldLaunchInstallFileOnClose));
            }
        }
    }
}