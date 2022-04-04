#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Theme.Switcher
{
    public class DownloadThemePackage : KryptonForm
    {
        #region Design Code
        private KryptonPanel kryptonPanel1;
        private KryptonBorderEdge kryptonBorderEdge1;
        private KryptonPanel kryptonPanel2;
        private ProgressBar pbDownloadProgress;
        private KryptonWrapLabel kwlSpeed;
        private KryptonWrapLabel kwlProgressPercentage;
        private KryptonWrapLabel kwlSize;
        private KryptonButton kbtnStop;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kwlSize = new Krypton.Toolkit.KryptonWrapLabel();
            this.kwlProgressPercentage = new Krypton.Toolkit.KryptonWrapLabel();
            this.kwlSpeed = new Krypton.Toolkit.KryptonWrapLabel();
            this.pbDownloadProgress = new System.Windows.Forms.ProgressBar();
            this.kbtnStop = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnStop);
            this.kryptonPanel1.Controls.Add(this.kryptonBorderEdge1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 144);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel1.Size = new System.Drawing.Size(598, 50);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderPrimary;
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonBorderEdge1.Location = new System.Drawing.Point(0, 0);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new System.Drawing.Size(598, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.pbDownloadProgress);
            this.kryptonPanel2.Controls.Add(this.kwlSpeed);
            this.kryptonPanel2.Controls.Add(this.kwlProgressPercentage);
            this.kryptonPanel2.Controls.Add(this.kwlSize);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(598, 144);
            this.kryptonPanel2.TabIndex = 1;
            // 
            // kwlSize
            // 
            this.kwlSize.AutoSize = false;
            this.kwlSize.Dock = System.Windows.Forms.DockStyle.Top;
            this.kwlSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlSize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kwlSize.Location = new System.Drawing.Point(0, 0);
            this.kwlSize.Name = "kwlSize";
            this.kwlSize.Size = new System.Drawing.Size(598, 38);
            this.kwlSize.StateCommon.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlSize.Text = "{0} {1} / {2} {3}";
            this.kwlSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // kwlProgressPercentage
            // 
            this.kwlProgressPercentage.AutoSize = false;
            this.kwlProgressPercentage.Dock = System.Windows.Forms.DockStyle.Top;
            this.kwlProgressPercentage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlProgressPercentage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kwlProgressPercentage.Location = new System.Drawing.Point(0, 38);
            this.kwlProgressPercentage.Name = "kwlProgressPercentage";
            this.kwlProgressPercentage.Size = new System.Drawing.Size(598, 38);
            this.kwlProgressPercentage.StateCommon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlProgressPercentage.Text = "{0}%";
            this.kwlProgressPercentage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // kwlSpeed
            // 
            this.kwlSpeed.AutoSize = false;
            this.kwlSpeed.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kwlSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlSpeed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kwlSpeed.Location = new System.Drawing.Point(0, 106);
            this.kwlSpeed.Name = "kwlSpeed";
            this.kwlSpeed.Size = new System.Drawing.Size(598, 38);
            this.kwlSpeed.StateCommon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlSpeed.Text = "{0} kb/s";
            this.kwlSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbDownloadProgress
            // 
            this.pbDownloadProgress.Location = new System.Drawing.Point(13, 80);
            this.pbDownloadProgress.Name = "pbDownloadProgress";
            this.pbDownloadProgress.Size = new System.Drawing.Size(573, 23);
            this.pbDownloadProgress.TabIndex = 5;
            // 
            // kbtnStop
            // 
            this.kbtnStop.Location = new System.Drawing.Point(254, 13);
            this.kbtnStop.Name = "kbtnStop";
            this.kbtnStop.Size = new System.Drawing.Size(90, 25);
            this.kbtnStop.TabIndex = 1;
            this.kbtnStop.Values.Text = "&Stop";
            // 
            // DownloadThemePackage
            // 
            this.ClientSize = new System.Drawing.Size(598, 194);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DownloadThemePackage";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private WebClient _client;

        private Stopwatch _stopwatch = new Stopwatch();
        #endregion

        #region Constructors
        public DownloadThemePackage()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods
        private void DownloadFile(string urlAddress, string location)
        {
            using (_client = new WebClient())
            {
                _client.DownloadFileCompleted += DownloadCompleted;

                _client.DownloadProgressChanged += ProgressChanged;

                Uri url = urlAddress.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ? new Uri(urlAddress) : new Uri("http://" + urlAddress);

                _stopwatch.Start();

                try
                {
                    _client.DownloadFileAsync(url, location);
                }
                catch (Exception e)
                {
                    ExceptionCapture.CaptureException(e);
                }
            }
        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            kwlSpeed.Text = $"{(e.BytesReceived / 1024d / _stopwatch.Elapsed.TotalSeconds).ToString("0.00")}kb/s";

            pbDownloadProgress.Value = e.ProgressPercentage;

            kwlProgressPercentage.Text = $"{e.ProgressPercentage}%";

            kwlSize.Text = $"{(e.BytesReceived / 1024d / 1024d).ToString("0.00")} MB's / {(e.TotalBytesToReceive / 1024d / 1024d).ToString("0.00")} MB's";
        }

        private void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            _stopwatch.Reset();

            if (e.Cancelled)
            {
                KryptonMessageBox.Show("The download has been cancelled.", "Download Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult result = KryptonMessageBox.Show("The download has been completed! Unpack now?", "Download Complete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.OK)
                {

                }
            }
        }
        #endregion
    }
}