using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Software.Updater.NetSparkle
{
    public class UpdateAvailableDialog : KryptonForm, IUpdateAvailable
    {
        #region Designer Code
        private KryptonPanel kryptonPanel1;
        private System.Windows.Forms.WebBrowser wbChangeLog;
        private KryptonLabel klblReleaseNotes;
        private KryptonLabel klblInfo;
        private KryptonLabel klblHeader;
        private KryptonButton kbtnSkip;
        private KryptonButton kbtnUpdate;
        private KryptonButton kbtnRemindLater;
        private KryptonPanel kpnlNotes;
        private System.Windows.Forms.PictureBox pbxApplicationIcon;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateAvailableDialog));
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.wbChangeLog = new System.Windows.Forms.WebBrowser();
            this.klblReleaseNotes = new Krypton.Toolkit.KryptonLabel();
            this.klblInfo = new Krypton.Toolkit.KryptonLabel();
            this.klblHeader = new Krypton.Toolkit.KryptonLabel();
            this.pbxApplicationIcon = new System.Windows.Forms.PictureBox();
            this.kbtnUpdate = new Krypton.Toolkit.KryptonButton();
            this.kbtnSkip = new Krypton.Toolkit.KryptonButton();
            this.kbtnRemindLater = new Krypton.Toolkit.KryptonButton();
            this.kpnlNotes = new Krypton.Toolkit.KryptonPanel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxApplicationIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlNotes)).BeginInit();
            this.kpnlNotes.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kpnlNotes);
            this.kryptonPanel1.Controls.Add(this.kbtnSkip);
            this.kryptonPanel1.Controls.Add(this.kbtnUpdate);
            this.kryptonPanel1.Controls.Add(this.kbtnRemindLater);
            this.kryptonPanel1.Controls.Add(this.klblReleaseNotes);
            this.kryptonPanel1.Controls.Add(this.klblInfo);
            this.kryptonPanel1.Controls.Add(this.klblHeader);
            this.kryptonPanel1.Controls.Add(this.pbxApplicationIcon);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(578, 479);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // wbChangeLog
            // 
            this.wbChangeLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbChangeLog.Location = new System.Drawing.Point(0, 0);
            this.wbChangeLog.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbChangeLog.Name = "wbChangeLog";
            this.wbChangeLog.Size = new System.Drawing.Size(500, 307);
            this.wbChangeLog.TabIndex = 4;
            // 
            // klblReleaseNotes
            // 
            this.klblReleaseNotes.Location = new System.Drawing.Point(66, 98);
            this.klblReleaseNotes.Name = "klblReleaseNotes";
            this.klblReleaseNotes.Size = new System.Drawing.Size(121, 21);
            this.klblReleaseNotes.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblReleaseNotes.TabIndex = 3;
            this.klblReleaseNotes.Values.Text = "Release Notes:";
            // 
            // klblInfo
            // 
            this.klblInfo.Location = new System.Drawing.Point(66, 41);
            this.klblInfo.Name = "klblInfo";
            this.klblInfo.Size = new System.Drawing.Size(335, 38);
            this.klblInfo.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.klblInfo.TabIndex = 2;
            this.klblInfo.Values.Text = "APP is now available (you have OLDVERSION). \r\nWould you like to [DOWNLOAD] it now" +
    "?";
            // 
            // klblHeader
            // 
            this.klblHeader.Location = new System.Drawing.Point(66, 12);
            this.klblHeader.Name = "klblHeader";
            this.klblHeader.Size = new System.Drawing.Size(258, 23);
            this.klblHeader.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblHeader.TabIndex = 1;
            this.klblHeader.Values.Text = "A new version of {0} is available!";
            // 
            // pbxApplicationIcon
            // 
            this.pbxApplicationIcon.BackColor = System.Drawing.Color.Transparent;
            this.pbxApplicationIcon.Location = new System.Drawing.Point(12, 12);
            this.pbxApplicationIcon.Name = "pbxApplicationIcon";
            this.pbxApplicationIcon.Size = new System.Drawing.Size(48, 48);
            this.pbxApplicationIcon.TabIndex = 1;
            this.pbxApplicationIcon.TabStop = false;
            // 
            // kbtnUpdate
            // 
            this.kbtnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnUpdate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.kbtnUpdate.Location = new System.Drawing.Point(413, 440);
            this.kbtnUpdate.Margin = new System.Windows.Forms.Padding(2);
            this.kbtnUpdate.Name = "kbtnUpdate";
            this.kbtnUpdate.Size = new System.Drawing.Size(153, 28);
            this.kbtnUpdate.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kbtnUpdate.TabIndex = 14;
            this.kbtnUpdate.Values.Image = global::Krypton.Toolkit.Suite.Extended.Software.Updater.Properties.Resources.download;
            this.kbtnUpdate.Values.Text = "Update";
            this.kbtnUpdate.Click += new System.EventHandler(this.kbtnUpdate_Click);
            // 
            // kbtnSkip
            // 
            this.kbtnSkip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kbtnSkip.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.kbtnSkip.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.kbtnSkip.Location = new System.Drawing.Point(66, 440);
            this.kbtnSkip.Margin = new System.Windows.Forms.Padding(2);
            this.kbtnSkip.Name = "kbtnSkip";
            this.kbtnSkip.Size = new System.Drawing.Size(153, 28);
            this.kbtnSkip.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kbtnSkip.TabIndex = 13;
            this.kbtnSkip.Values.Image = global::Krypton.Toolkit.Suite.Extended.Software.Updater.Properties.Resources.hand_point;
            this.kbtnSkip.Values.Text = "Skip this version";
            this.kbtnSkip.Click += new System.EventHandler(this.kbtnSkip_Click);
            // 
            // kbtnRemindLater
            // 
            this.kbtnRemindLater.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnRemindLater.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.kbtnRemindLater.Location = new System.Drawing.Point(256, 440);
            this.kbtnRemindLater.Margin = new System.Windows.Forms.Padding(2);
            this.kbtnRemindLater.Name = "kbtnRemindLater";
            this.kbtnRemindLater.Size = new System.Drawing.Size(153, 28);
            this.kbtnRemindLater.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kbtnRemindLater.TabIndex = 15;
            this.kbtnRemindLater.Values.Image = global::Krypton.Toolkit.Suite.Extended.Software.Updater.Properties.Resources.clock_go;
            this.kbtnRemindLater.Values.Text = "Remind &me later";
            this.kbtnRemindLater.Click += new System.EventHandler(this.kbtnRemindLater_Click);
            // 
            // kpnlNotes
            // 
            this.kpnlNotes.Controls.Add(this.wbChangeLog);
            this.kpnlNotes.Location = new System.Drawing.Point(66, 125);
            this.kpnlNotes.Name = "kpnlNotes";
            this.kpnlNotes.Size = new System.Drawing.Size(500, 307);
            this.kpnlNotes.TabIndex = 16;
            // 
            // UpdateAvailableDialog
            // 
            this.ClientSize = new System.Drawing.Size(578, 479);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "UpdateAvailableDialog";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Software Update";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UpdateAvailableDialog_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxApplicationIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlNotes)).EndInit();
            this.kpnlNotes.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private readonly SparkleUpdater _sparkle;
        private readonly List<AppCastItem> _updates;
        private System.Windows.Forms.Timer _ensureDialogShownTimer;

        /// <summary>
        /// Event fired when the user has responded to the 
        /// skip, later, install question.
        /// </summary>
        public event UserRespondedToUpdate UserResponded;

        /// <summary>
        /// Template for HTML code drawing release notes separator. {0} used for version number, {1} for publication date
        /// </summary>
        private CancellationToken _cancellationToken;
        private CancellationTokenSource _cancellationTokenSource;

        private ReleaseNotesGrabber _releaseNotesGrabber;

        private bool _didSendResponse = false;

        public UpdateAvailableDialog(SparkleUpdater sparkle, List<AppCastItem> items, Icon applicationIcon = null, bool isUpdateAlreadyDownloaded = false, string separatorTemplate = "", string headAddition = "")
        {
            _sparkle = sparkle;
            _updates = items;
            _releaseNotesGrabber = new ReleaseNotesGrabber(separatorTemplate, headAddition, sparkle);

            InitializeComponent();

            // init ui 
            try
            {
                wbChangeLog.AllowWebBrowserDrop = false;
                wbChangeLog.AllowNavigation = false;
            }
            catch (Exception ex)
            {
                _sparkle.LogWriter.PrintMessage("Error in browser init: {0}", ex.Message);
            }

            AppCastItem item = items.FirstOrDefault();

            var downloadInstallText = isUpdateAlreadyDownloaded ? "install" : "download";
            klblHeader.Text = $"A new version of { item.AppName } is available!";
            if (item != null)
            {
                var versionString = "";
                try
                {
                    // Use try/catch since Version constructor can throw an exception and we don't want to
                    // die just because the user has a malformed version string
                    Version versionObj = new Version(item.AppVersionInstalled);
                    versionString = Utilities.GetVersionString(versionObj);
                }
                catch
                {
                    versionString = "?";
                }
                klblInfo.Text = string.Format("{0} {3} is now available (you have {1}). Would you like to {2} it now?", item.AppName, versionString,
                    downloadInstallText, item.Version);
            }
            else
            {
                // TODO: string translations (even though I guess this window should never be called with 0 app cast items...)
                klblInfo.Text = string.Format("Would you like to {0} it now?", downloadInstallText);
            }

            bool isUserMissingCriticalUpdate = items.Any(x => x.IsCriticalUpdate);
            kbtnRemindLater.Enabled = isUserMissingCriticalUpdate == false;
            kbtnSkip.Enabled = isUserMissingCriticalUpdate == false;
            //if (isUserMissingCriticalUpdate)
            //{
            //    FormClosing += UpdateAvailableWindow_FormClosing; // no closing a critical update!
            //}

            if (applicationIcon != null)
            {
                using (Icon icon = new Icon(applicationIcon, new Size(48, 48)))
                {
                    pbxApplicationIcon.Image = icon.ToBitmap();
                }
                Icon = applicationIcon;
            }
            _cancellationTokenSource = new CancellationTokenSource();
            _cancellationToken = _cancellationTokenSource.Token;

            wbChangeLog.DocumentText = _releaseNotesGrabber.GetLoadingText();
            EnsureDialogShown();
            LoadReleaseNotes(items);
        }

        private async void LoadReleaseNotes(List<AppCastItem> items)
        {
            AppCastItem latestVersion = items.OrderByDescending(p => p.Version).FirstOrDefault();
            string releaseNotes = await _releaseNotesGrabber.DownloadAllReleaseNotes(items, latestVersion, _cancellationToken);
            wbChangeLog.Invoke((MethodInvoker)delegate
            {
                // see https://stackoverflow.com/a/15209861/3938401
                wbChangeLog.Navigate("about:blank");
                wbChangeLog.Document.OpenNew(true);
                wbChangeLog.Document.Write(releaseNotes);
                wbChangeLog.DocumentText = releaseNotes;
            });
        }

        private void UpdateAvailableDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_didSendResponse)
            {
                DialogResult = DialogResult.None;
                _didSendResponse = true;
                UserResponded?.Invoke(this, new UpdateResponseEventArgs(UpdateAvailableResult.None, CurrentItem));
            }
        }

        /// <summary>
        /// The current item being installed
        /// </summary>
        AppCastItem IUpdateAvailable.CurrentItem => CurrentItem;

        public AppCastItem CurrentItem
        {
            get { return _updates.Count() > 0 ? _updates[0] : null; }
        }

        /// <summary>
        /// The result of ShowDialog()
        /// </summary>
        UpdateAvailableResult IUpdateAvailable.Result => UIFactory.ConvertDialogResultToUpdateAvailableResult(DialogResult);

        /// <summary>
        /// Hides the release notes
        /// </summary>
        void IUpdateAvailable.HideReleaseNotes()
        {
            RemoveReleaseNotesControls();
        }

        /// <summary>
        /// Shows the dialog
        /// </summary>
        void IUpdateAvailable.Show(bool IsOnMainThread)
        {
            Show();
            if (!IsOnMainThread)
            {
                Application.Run(this);
            }
        }

        void IUpdateAvailable.BringToFront()
        {
            BringToFront();
        }

        void IUpdateAvailable.Close()
        {
            _cancellationTokenSource?.Cancel();
            CloseForm();
        }

        private void CloseForm()
        {
            if (InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate () { Close(); });
            }
            else
            {
                Close();
            }
        }

        /// <summary>
        /// Removes the release notes control
        /// </summary>
        public void RemoveReleaseNotesControls()
        {
            if (klblReleaseNotes.Parent == null)
                return;

            // calc new size
            Size newSize = new Size(Size.Width, Size.Height - klblReleaseNotes.Height - kpnlNotes.Height);

            // remove the no more needed controls            
            klblReleaseNotes.Parent.Controls.Remove(klblReleaseNotes);
            wbChangeLog.Parent.Controls.Remove(wbChangeLog);
            klblReleaseNotes.Parent.Controls.Remove(klblReleaseNotes);

            // resize the window
            /*this.MinimumSize = newSize;
            this.Size = this.MinimumSize;
            this.MaximumSize = this.MinimumSize;*/
            Size = newSize;
        }

        void SendResponse(UpdateAvailableResult response)
        {
            _cancellationTokenSource?.Cancel();
            _didSendResponse = true;
            UserResponded?.Invoke(this, new UpdateResponseEventArgs(response, CurrentItem));
        }

        private void kbtnSkip_Click(object sender, EventArgs e)
        {
            // set the dialog result to no
            DialogResult = DialogResult.No;

            // close the windows
            SendResponse(UpdateAvailableResult.SkipUpdate);
        }

        private void kbtnRemindLater_Click(object sender, EventArgs e)
        {
            // set the dialog result ot retry
            DialogResult = DialogResult.Retry;

            // close the window
            SendResponse(UpdateAvailableResult.RemindMeLater);
        }

        private void kbtnUpdate_Click(object sender, EventArgs e)
        {
            // set the result to yes
            DialogResult = DialogResult.Yes;

            // close the dialog
            SendResponse(UpdateAvailableResult.InstallUpdate);
        }

        /// <summary>
        /// This was the only way Deadpikle could guarantee that the 
        /// update available window was shown above a main WPF MahApps window.
        /// It's an ugly hack but...oh well. :\
        /// </summary>
        public void EnsureDialogShown()
        {
            _ensureDialogShownTimer = new System.Windows.Forms.Timer();
            _ensureDialogShownTimer.Tick += new EventHandler(EnsureDialogeShown_tick);
            _ensureDialogShownTimer.Interval = 250; // in milliseconds
            _ensureDialogShownTimer.Start();
        }

        private void EnsureDialogeShown_tick(object sender, EventArgs e)
        {
            // http://stackoverflow.com/a/4831839/3938401 for activating/bringing to front code
            Activate();
            TopMost = true;  // important
            TopMost = false; // important
            Focus();         // important
            _ensureDialogShownTimer.Enabled = false;
            _ensureDialogShownTimer = null;
        }

        /// <summary>
        /// Hides the remind me later button for the update available window
        /// </summary>
        public void HideRemindMeLaterButton()
        {
            kbtnRemindLater.Visible = false;
        }

        /// <summary>
        /// Hides the skip button for the update available window
        /// </summary>
        public void HideSkipButton()
        {
            kbtnSkip.Visible = false;
        }
    }
}