
using Application = System.Windows.Forms.Application;
using Size = System.Drawing.Size;
// ReSharper disable InconsistentNaming

namespace Krypton.Toolkit.Suite.Extended.Software.Updater
{
    public partial class NetSparkleUpdateAvailableWindow : KryptonForm, IUpdateAvailable
    {
        #region Instance Fields

        private readonly SparkleUpdater _sparkle;
        private readonly List<AppCastItem> _updates;
        private System.Windows.Forms.Timer _ensureDialogShownTimer;
        private string _releaseNotesHTMLTemplate;
        private string _additionalReleaseNotesHeaderHTML;
        private string _releaseNotesDateFormat;

        /// <summary>
        /// Template for HTML code drawing release notes separator. {0} used for version number, {1} for publication date
        /// </summary>
        private CancellationToken _cancellationToken;
        private CancellationTokenSource _cancellationTokenSource;

        private bool _didSendResponse;

        #endregion

        #region Public

        /// <summary>
        /// Object responsible for downloading and formatting markdown release notes for display in HTML
        /// </summary>
        public ReleaseNotesGrabber? ReleaseNotesGrabber { get; set; }

        AppCastItem IUpdateAvailable.CurrentItem => CurrentItem;

        #endregion

        #region Identity

        public NetSparkleUpdateAvailableWindow(SparkleUpdater sparkle, List<AppCastItem> items, Icon? applicationIcon = null, bool isUpdateAlreadyDownloaded = false,
            string releaseNotesHTMLTemplate = "", string additionalReleaseNotesHeaderHTML = "", string releaseNotesDateFormat = "D")
        {
            InitializeComponent();

            _sparkle = sparkle;
            _updates = items;
            _releaseNotesHTMLTemplate = releaseNotesHTMLTemplate;
            _additionalReleaseNotesHeaderHTML = additionalReleaseNotesHeaderHTML;
            _releaseNotesDateFormat = releaseNotesDateFormat;

            kwbReleaseNotes.Text = @"Release Notes:";

            try
            {
                kwbReleaseNotes.AllowWebBrowserDrop = false;

                kwbReleaseNotes.AllowNavigation = false;
            }
            catch (Exception e)
            {
                _sparkle.LogWriter.PrintMessage($@"Error in browser init: {e.Message}");
            }

            AppCastItem? castItem = items.FirstOrDefault()!;

            var downloadInstallText = isUpdateAlreadyDownloaded ? @"install" : @"download";

            kwlHeader.Text = kwlHeader.Text.Replace("APP", castItem != null ? castItem.AppName : "the application");

            if (castItem != null)
            {
                string versionString = string.Empty;

                try
                {
                    Version version = new(castItem.Version);

                    versionString = Utilities.GetVersionString(version);
                }
                catch
                {
                    versionString = @"?";
                }

                kwlInformationText.Text =
                    $@"{castItem.AppName} {castItem.Version} is now available (you have {versionString}). Would you like to {downloadInstallText} it now?";
            }
            else
            {
                kwlInformationText.Text = $@"Would you like to {downloadInstallText} it now?";
            }

            bool isUserMissingCriticalUpdate = items.Any(x => x.IsCriticalUpdate);

            kbtnRemindLater.Enabled = isUserMissingCriticalUpdate == false;

            kbtnSkipVersion.Enabled = isUserMissingCriticalUpdate == false;

            if (applicationIcon != null)
            {
                pbxApplicationIcon.Image = new Icon(applicationIcon, new Size(48, 48)).ToBitmap();

                Icon = applicationIcon;
            }

            _cancellationTokenSource = new();

            _cancellationToken = _cancellationTokenSource.Token;
        }

        #endregion

        #region IUpdateAvailable Implementation

        public event UserRespondedToUpdate? UserResponded;
        public void Show(bool isOnMainThread)
        {
            Show();

            if (!isOnMainThread)
            {
                Application.Run(this);
            }
        }

        public void HideReleaseNotes() => RemoveReleaseNotesControls();

        public void HideRemindMeLaterButton() => kbtnRemindLater.Visible = false;

        public void HideSkipButton() => kbtnSkipVersion.Visible = false;

        void IUpdateAvailable.BringToFront() => BringToFront();

        void IUpdateAvailable.Close()
        {
            _cancellationTokenSource.Cancel();

            CloseForm();
        }

        public UpdateAvailableResult Result => UIFactory.ConvertDialogResultToUpdateAvailableResult(DialogResult);

        public AppCastItem? CurrentItem => _updates.Count > 0 ? _updates[0] : null;

        #endregion

        private void NetSparkleUpdateAvailableWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_didSendResponse)
            {
                // user closed form in some other way other than standard buttons
                DialogResult = DialogResult.None;
                _didSendResponse = true;
                UserResponded?.Invoke(this, new UpdateResponseEventArgs(UpdateAvailableResult.None, CurrentItem));
            }
        }

        private void kbtnSkipVersion_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;

            SendResponse(UpdateAvailableResult.SkipUpdate);
        }

        private void kbtnRemindLater_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Retry;

            SendResponse(UpdateAvailableResult.RemindMeLater);
        }

        private void kbtnInstallUpdate_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;

            SendResponse(UpdateAvailableResult.InstallUpdate);
        }

        #region Implementation

        /// <summary>
        /// Setup the ReleaseNotesGrabber (if needed) and load the release notes
        /// </summary>
        public void Initialize()
        {
            if (ReleaseNotesGrabber == null)
            {
                ReleaseNotesGrabber = new ReleaseNotesGrabber(_releaseNotesHTMLTemplate, _additionalReleaseNotesHeaderHTML, _sparkle)
                {
                    DateFormat = _releaseNotesDateFormat
                };
            }

            kwbReleaseNotes.DocumentText = ReleaseNotesGrabber.GetLoadingText();

            EnsureDialogShown();

            LoadReleaseNotes(_updates);
        }

        private async void LoadReleaseNotes(List<AppCastItem> items)
        {
            AppCastItem? latestVersion = items.OrderByDescending(p => p.Version).FirstOrDefault();

            string releaseNotes = await ReleaseNotesGrabber?.DownloadAllReleaseNotes(items, latestVersion, _cancellationToken)!;

            kwbReleaseNotes.Invoke((MethodInvoker)delegate
            {
                // see https://stackoverflow.com/a/15209861/3938401
                kwbReleaseNotes.Navigate("about:blank");

                kwbReleaseNotes.Document.OpenNew(true);

                kwbReleaseNotes.Document.Write(releaseNotes);

                kwbReleaseNotes.DocumentText = releaseNotes;
            });
        }

        private void CloseForm()
        {
            if (InvokeRequired && !IsDisposed && !Disposing)
            {
                this.Invoke((MethodInvoker)delegate ()
                {
                    if (!IsDisposed && !Disposing)
                    {
                        Close();
                    }
                });
            }
            else if (!IsDisposed && !Disposing)
            {
                Close();
            }
        }

        /// <summary>
        /// Removes the release notes control
        /// </summary>
        public void RemoveReleaseNotesControls()
        {
            if (kwlReleaseNotes.Parent == null)
            {
                return;
            }

            // calc new size
            Size newSize = new Size(Size.Width, Size.Height - kwlReleaseNotes.Height - kwbReleaseNotes.Height);

            // remove the no more needed controls            
            kwlReleaseNotes.Parent.Controls.Remove(kwlReleaseNotes);
            kwbReleaseNotes.Parent.Controls.Remove(kwbReleaseNotes);

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

        /// <summary>
        /// This was the only way Deadpikle could guarantee that the 
        /// update available window was shown above a main WPF MahApps window.
        /// It's an ugly hack but...oh well. :\
        /// </summary>
        public void EnsureDialogShown()
        {
            _ensureDialogShownTimer = new System.Windows.Forms.Timer();
            _ensureDialogShownTimer.Tick += EnsureDialogeShown_tick;
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

        #endregion
    }
}
