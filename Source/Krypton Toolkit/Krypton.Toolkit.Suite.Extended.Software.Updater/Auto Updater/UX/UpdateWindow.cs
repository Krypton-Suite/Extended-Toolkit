#region License

/**
 * MIT License
 *
 * Copyright (c) 2012 - 2023 RBSoft
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 **/

#endregion

using Application = System.Windows.Forms.Application;
// ReSharper disable InconsistentNaming

namespace Krypton.Toolkit.Suite.Extended.Software.Updater
{
    public partial class UpdateWindow : KryptonForm
    {
        #region Instance Fields

        private readonly UpdateInfoEventArgs _args;

        #endregion

        #region Identity

        public UpdateWindow(UpdateInfoEventArgs args)
        {
            InitializeComponent();

            InitializeBrowserControl();

            _args = args;

            kbtnSkip.Visible = AutoUpdater.ShowSkipButton;

            kbtnRemind.Visible = AutoUpdater.ShowRemindLaterButton;

            Text = string.Format(AutoUpdaterLanguageManager.WindowStrings.WindowTitle, AutoUpdater.AppTitle,
                _args.CurrentVersion);

            kwlHeader.Text = string.Format(AutoUpdaterLanguageManager.WindowStrings.HeaderText, AutoUpdater.AppTitle);

            kwlDetails.Text = string.Format(AutoUpdaterLanguageManager.WindowStrings.Description, AutoUpdater.AppTitle,
                _args.CurrentVersion, _args.InstalledVersion);

            kwlReleaseNotes.Text = AutoUpdaterLanguageManager.WindowStrings.ReleaseNotesText;

            kbtnRemind.Text = AutoUpdaterLanguageManager.WindowStrings.RemindLaterButtonText;

            kbtnSkip.Text = AutoUpdaterLanguageManager.WindowStrings.SkipButtonText;

            kbtnUpdate.Text = AutoUpdaterLanguageManager.WindowStrings.UpdateButtonText;

            if (AutoUpdater.Mandatory && AutoUpdater.UpdateMode == UpdateMode.Forced)
            {
                ControlBox = false;
            }
        }

        #endregion

        private async void InitializeBrowserControl()
        {
            if (string.IsNullOrEmpty(_args.ChangelogURL))
            {
                ReducedUpdateWindow reducedUpdateWindow = new(_args);

                reducedUpdateWindow.Show();

                Hide();
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
                    kwbReleaseNotes.Hide();
                    wvReleaseNotes.CoreWebView2InitializationCompleted += WebView_CoreWebView2InitializationCompleted;
                    await wvReleaseNotes.EnsureCoreWebView2Async(
                        await CoreWebView2Environment.CreateAsync(null, Path.GetTempPath()));
                }
                else
                {
                    UseLatestIE();
                    if (null != AutoUpdater.BasicAuthChangeLog)
                    {
                        kwbReleaseNotes.Navigate(_args.ChangelogURL, "", null,
                            $"Authorization: {AutoUpdater.BasicAuthChangeLog}");
                    }
                    else
                    {
                        kwbReleaseNotes.Navigate(_args.ChangelogURL);
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

            wvReleaseNotes.CoreWebView2.Settings.AreDefaultContextMenusEnabled = false;
            wvReleaseNotes.CoreWebView2.Settings.IsStatusBarEnabled = false;
            wvReleaseNotes.CoreWebView2.Settings.AreDevToolsEnabled = Debugger.IsAttached;
            wvReleaseNotes.CoreWebView2.Settings.UserAgent = AutoUpdater.GetUserAgent();
            wvReleaseNotes.CoreWebView2.Profile.ClearBrowsingDataAsync();
            wvReleaseNotes.Show();
            wvReleaseNotes.BringToFront();
            if (null != AutoUpdater.BasicAuthChangeLog)
            {
                wvReleaseNotes.CoreWebView2.BasicAuthenticationRequested += delegate (
                    object _,
                    CoreWebView2BasicAuthenticationRequestedEventArgs args)
                {
                    args.Response.UserName = ((BasicAuthentication)AutoUpdater.BasicAuthChangeLog).Username;
                    args.Response.Password = ((BasicAuthentication)AutoUpdater.BasicAuthChangeLog).Password;
                };
            }

            wvReleaseNotes.CoreWebView2.Navigate(_args.ChangelogURL);
        }

        private void UseLatestIE()
        {
            int ieValue = kwbReleaseNotes.Version.Major switch
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
                using RegistryKey? registryKey =
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

        private void UpdateWindow_Load(object sender, EventArgs e)
        {

        }

        private void kbtnUpdate_Click(object sender, EventArgs e)
        {
            if (AutoUpdater.OpenDownloadPage)
            {
                var processStartInfo = new ProcessStartInfo(_args.DownloadURL);

                Process.Start(processStartInfo);

                DialogResult = DialogResult.OK;
            }
            else
            {
                if (AutoUpdater.DownloadUpdate(_args))
                {
                    DialogResult = DialogResult.OK;
                }
            }
        }

        private void kbtnSkip_Click(object sender, EventArgs e)
        {
            AutoUpdater.PersistenceProvider.SetSkippedVersion(new Version(_args.CurrentVersion));
        }

        private void kbtnRemind_Click(object sender, EventArgs e)
        {
            if (AutoUpdater.LetUserSelectRemindLater)
            {
                using var remindLaterForm = new RemindLaterWindow();
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

        private void UpdateWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            AutoUpdater.Running = false;
        }

        private void UpdateWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (AutoUpdater.Mandatory && AutoUpdater.UpdateMode == UpdateMode.Forced)
            {
                AutoUpdater.Exit();
            }
        }
    }
}
