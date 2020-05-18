using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.Software.Updater.AutoUpdaterDotNET
{
    public class UpdateDialog : KryptonForm
    {
        #region Designer Code
        private KryptonPanel kryptonPanel1;
        private System.Windows.Forms.PictureBox pictureBoxIcon;
        private KryptonLabel labelReleaseNotes;
        private KryptonLabel labelDescription;
        private KryptonLabel labelUpdate;
        private System.Windows.Forms.WebBrowser webBrowser;
        private KryptonButton kbtnUpdate;
        private KryptonButton kbtnSkip;
        private KryptonButton kbtnRemindLater;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateDialog));
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.labelReleaseNotes = new Krypton.Toolkit.KryptonLabel();
            this.labelDescription = new Krypton.Toolkit.KryptonLabel();
            this.labelUpdate = new Krypton.Toolkit.KryptonLabel();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.kbtnUpdate = new Krypton.Toolkit.KryptonButton();
            this.kbtnSkip = new Krypton.Toolkit.KryptonButton();
            this.kbtnRemindLater = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.pictureBoxIcon);
            this.kryptonPanel1.Controls.Add(this.labelReleaseNotes);
            this.kryptonPanel1.Controls.Add(this.labelDescription);
            this.kryptonPanel1.Controls.Add(this.labelUpdate);
            this.kryptonPanel1.Controls.Add(this.webBrowser);
            this.kryptonPanel1.Controls.Add(this.kbtnUpdate);
            this.kryptonPanel1.Controls.Add(this.kbtnSkip);
            this.kryptonPanel1.Controls.Add(this.kbtnRemindLater);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(643, 612);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // pictureBoxIcon
            // 
            this.pictureBoxIcon.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxIcon.Image = global::Krypton.Toolkit.Extended.Software.Updater.Properties.Resources.update;
            this.pictureBoxIcon.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBoxIcon.InitialImage = global::Krypton.Toolkit.Extended.Software.Updater.Properties.Resources.update;
            this.pictureBoxIcon.Location = new System.Drawing.Point(11, 13);
            this.pictureBoxIcon.Name = "pictureBoxIcon";
            this.pictureBoxIcon.Size = new System.Drawing.Size(70, 66);
            this.pictureBoxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxIcon.TabIndex = 16;
            this.pictureBoxIcon.TabStop = false;
            // 
            // labelReleaseNotes
            // 
            this.labelReleaseNotes.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelReleaseNotes.Location = new System.Drawing.Point(90, 89);
            this.labelReleaseNotes.Name = "labelReleaseNotes";
            this.labelReleaseNotes.Size = new System.Drawing.Size(103, 21);
            this.labelReleaseNotes.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.labelReleaseNotes.TabIndex = 15;
            this.labelReleaseNotes.Values.Text = "Release Notes:";
            // 
            // labelDescription
            // 
            this.labelDescription.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelDescription.Location = new System.Drawing.Point(90, 49);
            this.labelDescription.MaximumSize = new System.Drawing.Size(550, 0);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(499, 20);
            this.labelDescription.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelDescription.TabIndex = 14;
            this.labelDescription.Values.Text = "{0} {1} is now available. You have version {2} installed. Would you like to downl" +
    "oad it now?";
            // 
            // labelUpdate
            // 
            this.labelUpdate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelUpdate.Location = new System.Drawing.Point(90, 13);
            this.labelUpdate.MaximumSize = new System.Drawing.Size(550, 0);
            this.labelUpdate.Name = "labelUpdate";
            this.labelUpdate.Size = new System.Drawing.Size(231, 23);
            this.labelUpdate.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.labelUpdate.TabIndex = 13;
            this.labelUpdate.Values.Text = "A new version of {0} is available!";
            // 
            // webBrowser
            // 
            this.webBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser.Location = new System.Drawing.Point(93, 119);
            this.webBrowser.Margin = new System.Windows.Forms.Padding(2);
            this.webBrowser.MinimumSize = new System.Drawing.Size(23, 23);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.ScriptErrorsSuppressed = true;
            this.webBrowser.Size = new System.Drawing.Size(538, 432);
            this.webBrowser.TabIndex = 9;
            // 
            // kbtnUpdate
            // 
            this.kbtnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnUpdate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.kbtnUpdate.Location = new System.Drawing.Point(478, 572);
            this.kbtnUpdate.Margin = new System.Windows.Forms.Padding(2);
            this.kbtnUpdate.Name = "kbtnUpdate";
            this.kbtnUpdate.Size = new System.Drawing.Size(153, 28);
            this.kbtnUpdate.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kbtnUpdate.TabIndex = 11;
            this.kbtnUpdate.Values.Image = global::Krypton.Toolkit.Extended.Software.Updater.Properties.Resources.download;
            this.kbtnUpdate.Values.Text = "Update";
            this.kbtnUpdate.Click += new System.EventHandler(this.kbtnUpdate_Click);
            // 
            // kbtnSkip
            // 
            this.kbtnSkip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kbtnSkip.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.kbtnSkip.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.kbtnSkip.Location = new System.Drawing.Point(94, 572);
            this.kbtnSkip.Margin = new System.Windows.Forms.Padding(2);
            this.kbtnSkip.Name = "kbtnSkip";
            this.kbtnSkip.Size = new System.Drawing.Size(153, 28);
            this.kbtnSkip.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kbtnSkip.TabIndex = 10;
            this.kbtnSkip.Values.Image = global::Krypton.Toolkit.Extended.Software.Updater.Properties.Resources.hand_point;
            this.kbtnSkip.Values.Text = "Skip this version";
            this.kbtnSkip.Click += new System.EventHandler(this.kbtnSkip_Click);
            // 
            // kbtnRemindLater
            // 
            this.kbtnRemindLater.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnRemindLater.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.kbtnRemindLater.Location = new System.Drawing.Point(321, 572);
            this.kbtnRemindLater.Margin = new System.Windows.Forms.Padding(2);
            this.kbtnRemindLater.Name = "kbtnRemindLater";
            this.kbtnRemindLater.Size = new System.Drawing.Size(153, 28);
            this.kbtnRemindLater.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kbtnRemindLater.TabIndex = 12;
            this.kbtnRemindLater.Values.Image = global::Krypton.Toolkit.Extended.Software.Updater.Properties.Resources.clock_go;
            this.kbtnRemindLater.Values.Text = "Remind &me later";
            this.kbtnRemindLater.Click += new System.EventHandler(this.kbtnRemindLater_Click);
            // 
            // UpdateDialog
            // 
            this.AcceptButton = this.kbtnUpdate;
            this.ClientSize = new System.Drawing.Size(643, 612);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "{0} {1} is available!";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UpdateDialog_FormClosing);
            this.Load += new System.EventHandler(this.UpdateDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variable
        private readonly UpdateInfoEventArgs _args;
        #endregion

        #region Constructor
        public UpdateDialog(UpdateInfoEventArgs args)
        {
            _args = args;

            InitializeComponent();

            UseLatestIE();

            kbtnSkip.Visible = AutoUpdater.ShowSkipButton;

            kbtnRemindLater.Visible = AutoUpdater.ShowRemindLaterButton;
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateDialog));
            Text = string.Format(resources.GetString("$this.Text", CultureInfo.CurrentCulture),
                AutoUpdater.AppTitle, _args.CurrentVersion);
            labelUpdate.Text = string.Format(resources.GetString("labelUpdate.Text", CultureInfo.CurrentCulture),
                AutoUpdater.AppTitle);
            labelDescription.Text =
                string.Format(resources.GetString("labelDescription.Text", CultureInfo.CurrentCulture),
                    AutoUpdater.AppTitle, _args.CurrentVersion, _args.InstalledVersion);

            if (AutoUpdater.Mandatory && AutoUpdater.UpdateMode == Mode.FORCED)
            {
                ControlBox = false;
            }
        }
        #endregion

        private void UseLatestIE()
        {
            int ieValue = 0;
            switch (webBrowser.Version.Major)
            {
                case 11:
                    ieValue = 11001;
                    break;
                case 10:
                    ieValue = 10001;
                    break;
                case 9:
                    ieValue = 9999;
                    break;
                case 8:
                    ieValue = 8888;
                    break;
                case 7:
                    ieValue = 7000;
                    break;
            }

            if (ieValue != 0)
            {
                try
                {
                    using (RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", true))
                    {
                        registryKey?.SetValue(Path.GetFileName(Process.GetCurrentProcess().MainModule.FileName),
                            ieValue,
                            RegistryValueKind.DWord);
                    }
                }
                catch (Exception)
                {
                    // ignored
                }
            }
        }

        private void UpdateDialog_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_args.ChangelogURL))
            {
                var reduceHeight = labelReleaseNotes.Height + webBrowser.Height;
                labelReleaseNotes.Hide();
                webBrowser.Hide();
                Height -= reduceHeight;
            }
            else
            {
                if (null != AutoUpdater.BasicAuthChangeLog)
                {
                    webBrowser.Navigate(_args.ChangelogURL, "", null,
                        $"Authorization: {AutoUpdater.BasicAuthChangeLog}");
                }
                else
                {
                    webBrowser.Navigate(_args.ChangelogURL);
                }
            }

            var labelSize = new Size(Width - 110, 0);
            labelDescription.MaximumSize = labelUpdate.MaximumSize = labelSize;
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

        private void kbtnRemindLater_Click(object sender, EventArgs e)
        {
            if (AutoUpdater.LetUserSelectRemindLater)
            {
                using (var remindLaterForm = new RemindLaterDialog())
                {
                    var dialogResult = remindLaterForm.ShowDialog();

                    if (dialogResult.Equals(DialogResult.OK))
                    {
                        AutoUpdater.RemindLaterTimeSpan = remindLaterForm.RemindLaterFormat;
                        AutoUpdater.RemindLaterAt = remindLaterForm.RemindLaterAt;
                    }
                    else if (dialogResult.Equals(DialogResult.Abort))
                    {
                        kbtnUpdate_Click(sender, e);
                        return;
                    }
                    else
                    {
                        return;
                    }
                }
            }

            AutoUpdater.PersistenceProvider.SetSkippedVersion(null);

            DateTime remindLaterDateTime = DateTime.Now;
            switch (AutoUpdater.RemindLaterTimeSpan)
            {
                case RemindLaterFormat.DAYS:
                    remindLaterDateTime = DateTime.Now + TimeSpan.FromDays(AutoUpdater.RemindLaterAt);
                    break;
                case RemindLaterFormat.HOURS:
                    remindLaterDateTime = DateTime.Now + TimeSpan.FromHours(AutoUpdater.RemindLaterAt);
                    break;
                case RemindLaterFormat.MINUTES:
                    remindLaterDateTime = DateTime.Now + TimeSpan.FromMinutes(AutoUpdater.RemindLaterAt);
                    break;
            }

            AutoUpdater.PersistenceProvider.SetRemindLater(remindLaterDateTime);
            AutoUpdater.SetTimer(remindLaterDateTime);

            DialogResult = DialogResult.Cancel;
        }

        private void UpdateDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            AutoUpdater.Running = false;
        }
    }
}