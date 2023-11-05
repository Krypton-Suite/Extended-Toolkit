using Application = System.Windows.Forms.Application;

namespace Krypton.Toolkit.Suite.Extended.Software.Updater
{
    public partial class UpdateDialog : KryptonForm
    {
        #region Instance Fields

        private readonly UpdateInfoEventArgs _updateInfoEventArgs;

        #endregion

        public UpdateDialog(UpdateInfoEventArgs updateInfoEventArgs)
        {
            InitializeComponent();

            _updateInfoEventArgs = updateInfoEventArgs;

            TopMost = AutoUpdater.TopMost;

            if (AutoUpdater.Icon != null)
            {
                pictureBoxIcon.Image = AutoUpdater.Icon;

                Icon = Icon.FromHandle(AutoUpdater.Icon.GetHicon());
            }

            kbtnSkip.Visible = AutoUpdater.ShowSkipButton;

            kbtnRemind.Visible = AutoUpdater.ShowRemindLaterButton;

            InitializeBrowserControl();

            SetupUI();
        }

        private async void InitializeBrowserControl()
        {
            if (string.IsNullOrEmpty(_updateInfoEventArgs.ChangelogURL))
            {
                int reduceHeight = klblReleaseNotes.Height + kryptonPanel2.Height;
                klblReleaseNotes.Hide();
                kryptonPanel2.Hide();
                Height -= reduceHeight;
            }
            else
            {
                var webView2RuntimeFound = false;
                try
                {
                    string availableBrowserVersion = CoreWebView2Environment.GetAvailableBrowserVersionString();
                    var requiredMinBrowserVersion = "86.0.616.0";
                    if (!string.IsNullOrEmpty(availableBrowserVersion)
                        && CoreWebView2Environment.CompareBrowserVersions(availableBrowserVersion,
                            requiredMinBrowserVersion) >= 0)
                    {
                        webView2RuntimeFound = true;
                    }
                }
                catch (Exception)
                {
                    // ignored
                }

                if (webView2RuntimeFound)
                {
                    kwbChangelog.Hide();
                    wvChangelog.CoreWebView2InitializationCompleted += WebView_CoreWebView2InitializationCompleted;
                    await wvChangelog.EnsureCoreWebView2Async(
                        await CoreWebView2Environment.CreateAsync(null, Path.GetTempPath()));
                }
                else
                {
                    UseLatestIE();
                    if (null != AutoUpdater.BasicAuthChangeLog)
                    {
                        kwbChangelog.Navigate(_updateInfoEventArgs.ChangelogURL, "", null,
                            $"Authorization: {AutoUpdater.BasicAuthChangeLog}");
                    }
                    else
                    {
                        kwbChangelog.Navigate(_updateInfoEventArgs.ChangelogURL);
                    }
                }
            }
        }

        private void WebView_CoreWebView2InitializationCompleted(object sender,
       CoreWebView2InitializationCompletedEventArgs e)
        {
            if (!e.IsSuccess)
            {
                if (AutoUpdater.ReportErrors)
                {
                    KryptonMessageBox.Show(this, e.InitializationException.Message, e.InitializationException.GetType().ToString(),
                        KryptonMessageBoxButtons.OK, KryptonMessageBoxIcon.Error);
                }

                return;
            }

            wvChangelog.CoreWebView2.Settings.AreDefaultContextMenusEnabled = false;
            wvChangelog.CoreWebView2.Settings.IsStatusBarEnabled = false;
            wvChangelog.CoreWebView2.Settings.AreDevToolsEnabled = Debugger.IsAttached;
            wvChangelog.CoreWebView2.Settings.UserAgent = AutoUpdater.GetUserAgent();
            wvChangelog.CoreWebView2.Profile.ClearBrowsingDataAsync();
            wvChangelog.Show();
            wvChangelog.BringToFront();
            if (null != AutoUpdater.BasicAuthChangeLog)
            {
                wvChangelog.CoreWebView2.BasicAuthenticationRequested += delegate (
                    object _,
                    CoreWebView2BasicAuthenticationRequestedEventArgs args)
                {
                    args.Response.UserName = ((BasicAuthentication)AutoUpdater.BasicAuthChangeLog).Username;
                    args.Response.Password = ((BasicAuthentication)AutoUpdater.BasicAuthChangeLog).Password;
                };
            }

            wvChangelog.CoreWebView2.Navigate(_updateInfoEventArgs.ChangelogURL);
        }

        private void UseLatestIE()
        {
            int ieValue = kwbChangelog.Version.Major switch
            {
                11 => 11001,
                10 => 10001,
                9 => 9999,
                8 => 8888,
                7 => 7000,
                _ => 0
            };

            if (ieValue == 0)
            {
                return;
            }

            try
            {
                using RegistryKey registryKey =
                    Registry.CurrentUser.OpenSubKey(
                        @"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION",
                        true);
                registryKey?.SetValue(
                    Path.GetFileName(Process.GetCurrentProcess().MainModule?.FileName ??
                                     Assembly.GetEntryAssembly()?.Location ?? Application.ExecutablePath),
                    ieValue,
                    RegistryValueKind.DWord);
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void SetupUI()
        {
            Text = string.Format(AutoUpdaterLanguageManager.WindowStrings.WindowTitle, AutoUpdater.AppTitle,
                _updateInfoEventArgs.CurrentVersion);

            klblTitle.Text = string.Format(AutoUpdaterLanguageManager.WindowStrings.HeaderText,
                CultureInfo.CurrentCulture, AutoUpdater.AppTitle);

            klblDescription.Text = string.Format(AutoUpdaterLanguageManager.WindowStrings.Description,
                AutoUpdater.AppTitle, _updateInfoEventArgs.CurrentVersion, _updateInfoEventArgs.InstalledVersion);

            klblReleaseNotes.Text = AutoUpdaterLanguageManager.WindowStrings.ReleaseNotesText;

            if (AutoUpdater.Mandatory && AutoUpdater.UpdateMode == Mode.Forced)
            {
                CloseBox = false;
            }
        }

        private void UpdateDialog_Load(object sender, EventArgs e)
        {

        }

        private void kbtnUpdate_Click(object sender, EventArgs e)
        {
            if (AutoUpdater.OpenDownloadPage)
            {
                var processStartInfo = new ProcessStartInfo(_updateInfoEventArgs.DownloadURL);

                GlobalToolkitUtilities.LaunchProcess(processStartInfo);

                DialogResult = DialogResult.OK;
            }
            else
            {
                if (AutoUpdater.DownloadUpdate(_updateInfoEventArgs))
                {
                    DialogResult = DialogResult.OK;
                }
            }
        }

        private void kbtnSkip_Click(object sender, EventArgs e)
        {
            AutoUpdater.PersistenceProvider.SetSkippedVersion(new Version(_updateInfoEventArgs.CurrentVersion));
        }

        private void kbtnRemind_Click(object sender, EventArgs e)
        {
            if (AutoUpdater.LetUserSelectRemindLater)
            {
                using var remindLaterForm = new RemindLaterForm();
                DialogResult dialogResult = remindLaterForm.ShowDialog(this);

                switch (dialogResult)
                {
                    case DialogResult.OK:
                        AutoUpdater.RemindLaterTimeSpan = remindLaterForm.RemindLaterFormat;
                        AutoUpdater.RemindLaterAt = remindLaterForm.RemindLaterAt;
                        break;
                    case DialogResult.Abort:
                        kbtnUpdate_Click(sender, e);
                        return;
                    default:
                        return;
                }
            }

            AutoUpdater.PersistenceProvider.SetSkippedVersion(null);

            DateTime remindLaterDateTime = AutoUpdater.RemindLaterTimeSpan switch
            {
                RemindLaterFormat.Days => DateTime.Now + TimeSpan.FromDays(AutoUpdater.RemindLaterAt),
                RemindLaterFormat.Hours => DateTime.Now + TimeSpan.FromHours(AutoUpdater.RemindLaterAt),
                RemindLaterFormat.Minutes => DateTime.Now + TimeSpan.FromMinutes(AutoUpdater.RemindLaterAt),
                _ => DateTime.Now
            };

            AutoUpdater.PersistenceProvider.SetRemindLater(remindLaterDateTime);
            AutoUpdater.SetTimer(remindLaterDateTime);

            DialogResult = DialogResult.Cancel;
        }

        private void UpdateDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            AutoUpdater.Running = false;
        }

        private void UpdateDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (AutoUpdater.Mandatory && AutoUpdater.UpdateMode == Mode.Forced)
            {
                AutoUpdater.Exit();
            }
        }
    }
}
