﻿#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
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
 *
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Software.Updater.NetSparkle
{
    /// <summary>
    /// UI factory for default interface
    /// </summary>
    public class UIFactory : IUIFactory
    {
        private Icon _applicationIcon = null;

        public UIFactory()
        {
            HideReleaseNotes = false;
            HideRemindMeLaterButton = false;
            HideSkipButton = false;
        }

        public UIFactory(Icon applicationIcon)
        {
            _applicationIcon = applicationIcon;
            HideReleaseNotes = false;
            HideRemindMeLaterButton = false;
            HideSkipButton = false;
        }

        /// <summary>
        /// Hides the release notes view when an update is found.
        /// </summary>
        public bool HideReleaseNotes { get; set; }

        /// <summary>
        /// Hides the skip this update button when an update is found.
        /// </summary>
        public bool HideSkipButton { get; set; }

        /// <summary>
        /// Hides the remind me later button when an update is found.
        /// </summary>
        public bool HideRemindMeLaterButton { get; set; }

        /// <summary>
        /// Create sparkle form implementation
        /// </summary>
        /// <param name="sparkle">The <see cref="SparkleUpdater"/> instance to use</param>
        /// <param name="updates">Sorted array of updates from latest to earliest</param>
        /// <param name="isUpdateAlreadyDownloaded">If true, make sure UI text shows that the user is about to install the file instead of download it.</param>
        public virtual IUpdateAvailable CreateUpdateAvailableWindow(SparkleUpdater sparkle, List<AppCastItem> updates, bool isUpdateAlreadyDownloaded = false)
        {
            var window = new UpdateAvailableDialog(sparkle, updates, _applicationIcon, isUpdateAlreadyDownloaded);
            if (HideReleaseNotes)
            {
                (window as IUpdateAvailable).HideReleaseNotes();
            }
            if (HideSkipButton)
            {
                (window as IUpdateAvailable).HideSkipButton();
            }
            if (HideRemindMeLaterButton)
            {
                (window as IUpdateAvailable).HideRemindMeLaterButton();
            }
            return window;
        }

        /// <summary>
        /// Create download progress window
        /// </summary>
        /// <param name="item">Appcast item to download</param>
        public virtual IDownloadProgress CreateProgressWindow(AppCastItem item)
        {
            return new DownloadProgressDialog(item, _applicationIcon);
        }

        /// <summary>
        /// Inform user in some way that NetSparkle is checking for updates
        /// </summary>
        public virtual ICheckingForUpdates ShowCheckingForUpdates()
        {
            return new CheckingForUpdatesDialog(_applicationIcon);
        }

        /// <summary>
        /// Initialize UI. Called when Sparkle is constructed and/or when the UIFactory is set.
        /// </summary>
        public virtual void Init()
        {
            // enable visual style to ensure that we have XP style or higher
            // also in WPF applications
            Application.EnableVisualStyles();
        }

        /// <summary>
        /// Show user a message saying downloaded update format is unknown
        /// </summary>
        /// <param name="downloadFileName">The filename to be inserted into the message text</param>
        public virtual void ShowUnknownInstallerFormatMessage(string downloadFileName)
        {
            ShowMessage(NetSparkleResources.DefaultUIFactory_MessageTitle,
                string.Format(NetSparkleResources.DefaultUIFactory_ShowUnknownInstallerFormatMessageText, downloadFileName));
        }

        /// <summary>
        /// Show user that current installed version is up-to-date
        /// </summary>
        public virtual void ShowVersionIsUpToDate()
        {
            ShowMessage(NetSparkleResources.DefaultUIFactory_MessageTitle, NetSparkleResources.DefaultUIFactory_ShowVersionIsUpToDateMessage);
        }

        /// <summary>
        /// Show message that latest update was skipped by user
        /// </summary>
        public virtual void ShowVersionIsSkippedByUserRequest()
        {
            ShowMessage(NetSparkleResources.DefaultUIFactory_MessageTitle, NetSparkleResources.DefaultUIFactory_ShowVersionIsSkippedByUserRequestMessage);
        }

        /// <summary>
        /// Show message that appcast is not available
        /// </summary>
        /// <param name="appcastUrl">the URL for the appcast file</param>
        public virtual void ShowCannotDownloadAppcast(string appcastUrl)
        {
            ShowMessage(NetSparkleResources.DefaultUIFactory_ErrorTitle, NetSparkleResources.DefaultUIFactory_ShowCannotDownloadAppcastMessage);
        }

        public virtual bool CanShowToastMessages()
        {
            return true;
        }

        /// <summary>
        /// Show 'toast' window to notify new version is available
        /// </summary>
        /// <param name="updates">Appcast updates</param>
        /// <param name="clickHandler">handler for click</param>
        public virtual void ShowToast(List<AppCastItem> updates, Action<List<AppCastItem>> clickHandler)
        {
            Thread thread = new Thread(() =>
            {
                var toast = new NetSparkleToastNotifier(_applicationIcon)
                {
                    ClickAction = clickHandler,
                    Updates = updates
                };
                toast.Show(NetSparkleResources.DefaultUIFactory_ToastMessage, NetSparkleResources.DefaultUIFactory_ToastCallToAction, 5);
                Application.Run(toast);
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        /// <summary>
        /// Show message on download error
        /// </summary>
        /// <param name="message">Error message from exception</param>
        /// <param name="appcastUrl">the URL for the appcast file</param>
        public virtual void ShowDownloadErrorMessage(string message, string appcastUrl)
        {
            ShowMessage(NetSparkleResources.DefaultUIFactory_ErrorTitle, string.Format(NetSparkleResources.DefaultUIFactory_ShowDownloadErrorMessage, message));
        }

        private void ShowMessage(string title, string message)
        {
            var messageWindow = new MessageNotificationDialog(title, message, _applicationIcon);
            messageWindow.StartPosition = FormStartPosition.CenterScreen;
            messageWindow.ShowDialog();
        }

        /// <summary>
        /// Shut down the UI so we can run an update.
        /// If in WPF, System.Windows.Application.Current.Shutdown().
        /// If in WinForms, Application.Exit().
        /// </summary>
        public void Shutdown()
        {
            Application.Exit();
        }

        #region --- Windows Forms Result Converters ---

        /// <summary>
        /// Method performs simple conversion of DialogResult to boolean.
        /// This method is a convenience when upgrading legacy code.
        /// </summary>
        /// <param name="dialogResult">WinForms DialogResult instance</param>
        /// <returns>Boolean based on dialog result</returns>
        public static bool ConvertDialogResultToDownloadProgressResult(DialogResult dialogResult)
        {
            return (dialogResult != DialogResult.Abort) && (dialogResult != DialogResult.Cancel);
        }

        /// <summary>
        /// Method performs simple conversion of DialogResult to UpdateAvailableResult.
        /// This method is a convenience when upgrading legacy code.
        /// </summary>
        /// <param name="dialogResult">WinForms DialogResult instance</param>
        /// <returns>Enumeration value based on dialog result</returns>
        public static UpdateAvailableResult ConvertDialogResultToUpdateAvailableResult(DialogResult dialogResult)
        {
            switch (dialogResult)
            {
                case DialogResult.Yes:
                    return UpdateAvailableResult.InstallUpdate;
                case DialogResult.No:
                    return UpdateAvailableResult.SkipUpdate;
                case DialogResult.Retry:
                case DialogResult.Cancel:
                    return UpdateAvailableResult.RemindMeLater;
            }

            return UpdateAvailableResult.None;
        }

        #endregion
    }
}