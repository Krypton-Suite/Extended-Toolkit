#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Software.Updater.NetSparkle
{
    public class DownloadProgressDialog : KryptonForm, IDownloadProgress
    {
        #region Design Code
        private KryptonPanel kryptonPanel1;
        private KryptonButton btnCancel;
        private KryptonButton kbtnInstall;
        private KryptonPanel kryptonPanel2;
        private ProgressBar pbDownload;
        private KryptonLabel klblDownloadProgress;
        private KryptonLabel klblHeader;
        private PictureBox pbxApplicationIcon;
        private KryptonBorderEdge kryptonBorderEdge1;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownloadProgressDialog));
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnInstall = new Krypton.Toolkit.KryptonButton();
            this.btnCancel = new Krypton.Toolkit.KryptonButton();
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.pbDownload = new System.Windows.Forms.ProgressBar();
            this.klblDownloadProgress = new Krypton.Toolkit.KryptonLabel();
            this.klblHeader = new Krypton.Toolkit.KryptonLabel();
            this.pbxApplicationIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxApplicationIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnInstall);
            this.kryptonPanel1.Controls.Add(this.btnCancel);
            this.kryptonPanel1.Controls.Add(this.kryptonBorderEdge1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 103);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel1.Size = new System.Drawing.Size(487, 50);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // kbtnInstall
            // 
            this.kbtnInstall.Enabled = false;
            this.kbtnInstall.Location = new System.Drawing.Point(212, 13);
            this.kbtnInstall.Name = "kbtnInstall";
            this.kbtnInstall.Size = new System.Drawing.Size(167, 25);
            this.kbtnInstall.TabIndex = 3;
            this.kbtnInstall.Values.Text = "Install && &Relaunch";
            this.kbtnInstall.Click += new System.EventHandler(this.kbtnInstall_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(385, 13);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 25);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Values.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderSecondary;
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonBorderEdge1.Location = new System.Drawing.Point(0, 0);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new System.Drawing.Size(487, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.pbDownload);
            this.kryptonPanel2.Controls.Add(this.klblDownloadProgress);
            this.kryptonPanel2.Controls.Add(this.klblHeader);
            this.kryptonPanel2.Controls.Add(this.pbxApplicationIcon);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(487, 103);
            this.kryptonPanel2.TabIndex = 2;
            // 
            // pbDownload
            // 
            this.pbDownload.Location = new System.Drawing.Point(12, 69);
            this.pbDownload.Name = "pbDownload";
            this.pbDownload.Size = new System.Drawing.Size(463, 27);
            this.pbDownload.TabIndex = 8;
            // 
            // klblDownloadProgress
            // 
            this.klblDownloadProgress.Location = new System.Drawing.Point(66, 42);
            this.klblDownloadProgress.Name = "klblDownloadProgress";
            this.klblDownloadProgress.Size = new System.Drawing.Size(128, 21);
            this.klblDownloadProgress.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.klblDownloadProgress.TabIndex = 7;
            this.klblDownloadProgress.Values.Text = "({0} MB / {1} MB)";
            // 
            // klblHeader
            // 
            this.klblHeader.Location = new System.Drawing.Point(66, 12);
            this.klblHeader.Name = "klblHeader";
            this.klblHeader.Size = new System.Drawing.Size(145, 24);
            this.klblHeader.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblHeader.TabIndex = 6;
            this.klblHeader.Values.Text = "Downloading {0}";
            // 
            // pbxApplicationIcon
            // 
            this.pbxApplicationIcon.BackColor = System.Drawing.Color.Transparent;
            this.pbxApplicationIcon.Location = new System.Drawing.Point(12, 12);
            this.pbxApplicationIcon.Name = "pbxApplicationIcon";
            this.pbxApplicationIcon.Size = new System.Drawing.Size(48, 48);
            this.pbxApplicationIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbxApplicationIcon.TabIndex = 5;
            this.pbxApplicationIcon.TabStop = false;
            // 
            // DownloadProgressDialog
            // 
            this.ClientSize = new System.Drawing.Size(487, 153);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DownloadProgressDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Downloading Update";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DownloadProgressDialog_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxApplicationIcon)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region IDownloadProgress
        public event DownloadInstallEventHandler DownloadProcessCompleted;

        public bool DisplayErrorMessage(string errorMessage)
        {
            klblDownloadProgress.Text = errorMessage;

            btnCancel.Text = "&Close";

            return true;
        }

        public void FinishedDownloadingFile(bool isDownloadedFileValid)
        {
            kbtnInstall.Enabled = isDownloadedFileValid;
        }

        public void OnDownload_ProgressChanged(object sender, ItemDownloadProgressEventArgs args)
        {
            OnDownloadProgressChanged(sender, args.BytesReceived, args.TotalBytesToReceive, args.ProgressPercentage);
        }

        public void SetDownloadAndInstallButtonEnabled(bool shouldBeEnabled)
        {
            kbtnInstall.Enabled = shouldBeEnabled;
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

        void IDownloadProgress.Close()
        {
            DialogResult = DialogResult.Abort;
            CloseForm();
        }

        private void OnDownloadProgressChanged(object sender, long bytesReceived, long totalBytesToReceive, int percentage)
        {
            pbDownload.Value = percentage;
            klblDownloadProgress.Text = "(" + Utilities.ConvertNumBytesToUserReadableString(bytesReceived) + " / " +
                Utilities.ConvertNumBytesToUserReadableString(totalBytesToReceive) + ")";
        }
        #endregion

        #region Fields
        private bool _shouldLaunchInstallFileOnClose = false, _didCallDownloadProcessCompletedHandler = false;
        #endregion

        #region Constructors
        public DownloadProgressDialog(AppCastItem item, Icon applicationIcon = null)
        {
            InitializeComponent();

            if (applicationIcon != null)
            {
                Icon = applicationIcon;

                pbxApplicationIcon.Image = new Icon(applicationIcon, new Size(48, 48)).ToBitmap();
            }
            else
            {
                Icon = NetSparkleResources.update1;

                pbxApplicationIcon.Image = NetSparkleResources.update_48_x_48;
            }

            kbtnInstall.Visible = false;

            klblHeader.Text = $"Downloading { item.AppName } { item.Version }";

            klblDownloadProgress.Text = string.Empty;

            pbDownload.Maximum = 100;

            pbDownload.Minimum = 0;

            pbDownload.Step = 1;
        }
        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            _didCallDownloadProcessCompletedHandler = true;
            DownloadProcessCompleted?.Invoke(this, new DownloadInstallEventArgs(false));
        }

        private void kbtnInstall_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            _shouldLaunchInstallFileOnClose = true;
            _didCallDownloadProcessCompletedHandler = true;
            DownloadProcessCompleted?.Invoke(this, new DownloadInstallEventArgs(true));
        }

        private void DownloadProgressDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_didCallDownloadProcessCompletedHandler)
            {
                _didCallDownloadProcessCompletedHandler = true;

                DownloadProcessCompleted?.Invoke(this, new DownloadInstallEventArgs(_shouldLaunchInstallFileOnClose));
            }
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
    }
}