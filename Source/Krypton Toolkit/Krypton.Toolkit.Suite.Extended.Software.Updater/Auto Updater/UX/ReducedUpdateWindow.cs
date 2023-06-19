using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
