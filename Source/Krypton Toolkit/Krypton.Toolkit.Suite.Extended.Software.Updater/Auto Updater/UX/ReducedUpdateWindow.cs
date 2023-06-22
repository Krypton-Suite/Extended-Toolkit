#region License

/*
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
 */

#endregion

namespace Krypton.Toolkit.Suite.Extended.Software.Updater
{
    public partial class ReducedUpdateWindow : KryptonForm
    {
        #region Instance Fields

        private readonly UpdateInfoEventArgs _args;

        #endregion

        public ReducedUpdateWindow(UpdateInfoEventArgs args)
        {
            InitializeComponent();

            _args = args;

            kbtnSkip.Visible = AutoUpdater.ShowSkipButton;

            kbtnRemind.Visible = AutoUpdater.ShowRemindLaterButton;

            Text = string.Format(AutoUpdaterLanguageManager.WindowStrings.WindowTitle, AutoUpdater.AppTitle,
                _args.CurrentVersion);

            kwlHeader.Text = string.Format(AutoUpdaterLanguageManager.WindowStrings.HeaderText, AutoUpdater.AppTitle);

            kwlDescription.Text = string.Format(AutoUpdaterLanguageManager.WindowStrings.Description, AutoUpdater.AppTitle,
                _args.CurrentVersion, _args.InstalledVersion);

            kbtnRemind.Text = AutoUpdaterLanguageManager.WindowStrings.RemindLaterButtonText;

            kbtnSkip.Text = AutoUpdaterLanguageManager.WindowStrings.SkipButtonText;

            kbtnUpdate.Text = AutoUpdaterLanguageManager.WindowStrings.UpdateButtonText;

            if (AutoUpdater.Mandatory && AutoUpdater.UpdateMode == UpdateMode.Forced)
            {
                ControlBox = false;
            }
        }

        private void kbtnSkip_Click(object sender, EventArgs e)
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

        private void kbtnRemind_Click(object sender, EventArgs e)
        {
            AutoUpdater.PersistenceProvider.SetSkippedVersion(new Version(_args.CurrentVersion));
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

        private void ReducedUpdateWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            AutoUpdater.Running = false;
        }

        private void ReducedUpdateWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (AutoUpdater.Mandatory && AutoUpdater.UpdateMode == UpdateMode.Forced)
            {
                AutoUpdater.Exit();
            }
        }
    }
}
