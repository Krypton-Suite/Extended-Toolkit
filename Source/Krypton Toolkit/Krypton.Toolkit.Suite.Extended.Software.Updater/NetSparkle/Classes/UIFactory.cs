﻿#region License

/*
 * The MIT License
 *
 * Copyright (c) 2022 Deadpikle
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

#endregion

using Krypton.Toolkit.Suite.Extended.Software.Updater.NetSparkle.Resources;

using Application = System.Windows.Forms.Application;

namespace Krypton.Toolkit.Suite.Extended.Software.Updater
{
    /// <summary>
    /// UI factory for WinForms .NET Core interface
    /// </summary>
    public class UIFactory : IUIFactory
    {
        private Icon? _applicationIcon = null;

        /// <inheritdoc/>
        public UIFactory()
        {
            HideReleaseNotes = false;
            HideRemindMeLaterButton = false;
            HideSkipButton = false;
        }

        /// <inheritdoc/>
        public UIFactory(Icon applicationIcon) : this()
        {
            _applicationIcon = applicationIcon;
        }

        /// <inheritdoc/>
        public bool HideReleaseNotes { get; set; }

        /// <inheritdoc/>
        public bool HideSkipButton { get; set; }

        /// <inheritdoc/>
        public bool HideRemindMeLaterButton { get; set; }

        /// <inheritdoc/>
        public string ReleaseNotesHTMLTemplate { get; set; }

        /// <inheritdoc/>
        public string AdditionalReleaseNotesHeaderHTML { get; set; }

        /// <summary>
        /// The DateTime.ToString() format used when formatting dates to show in the release notes
        /// header. NetSparkle is not responsible for what happens if you send a bad format! :)
        /// </summary>
        public string ReleaseNotesDateTimeFormat { get; set; } = "D";

        /// <summary>
        /// <para>
        /// Easily set / override the ReleaseNotesGrabber used by the <see cref="NetSparkleUpdateAvailableWindow"/>.
        /// Note that this will NOT automatically use the <see cref="UIFactory"/> ReleaseNotesHTMLTemplate,
        /// AdditionalReleaseNotesHeaderHTML, and ReleaseNotesDateTimeFormat that you may have set on 
        /// the UIFactory - you must set these on this manual override yourself!
        /// </para>
        /// <para>
        /// Use this if you want to easily override the ReleaseNotesGrabber with your own subclass.
        /// </para>
        /// </summary>
        public ReleaseNotesGrabber? ReleaseNotesGrabberOverride { get; set; } = null;

        /// <inheritdoc/>
        public virtual IUpdateAvailable CreateUpdateAvailableWindow(SparkleUpdater sparkle, List<AppCastItem> updates, bool isUpdateAlreadyDownloaded = false)
        {
            var window = new NetSparkleUpdateAvailableWindow(sparkle, updates, _applicationIcon, isUpdateAlreadyDownloaded,
                ReleaseNotesHTMLTemplate, AdditionalReleaseNotesHeaderHTML, ReleaseNotesDateTimeFormat);
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
            if (ReleaseNotesGrabberOverride != null)
            {
                window.ReleaseNotesGrabber = ReleaseNotesGrabberOverride;
            }
            window.Initialize();
            return window;
        }

        /// <inheritdoc/>
        public virtual IDownloadProgress CreateProgressWindow(SparkleUpdater sparkle, AppCastItem? item)
        {
            return new NetSparkleDownloadProgressWindow(item, _applicationIcon)
            {
                SoftwareWillRelaunchAfterUpdateInstalled = sparkle.RelaunchAfterUpdate
            };
        }

        /// <inheritdoc/>
        public virtual ICheckingForUpdates ShowCheckingForUpdates(SparkleUpdater sparkle)
        {
            return new NetSparkleCheckingForUpdatesWindow(_applicationIcon);
        }

        /// <inheritdoc/>
        public virtual void Init(SparkleUpdater sparkle)
        {
            // enable visual style to ensure that we have XP style or higher
            // also in WPF applications
            Application.EnableVisualStyles();
        }

        /// <inheritdoc/>
        public virtual void ShowUnknownInstallerFormatMessage(SparkleUpdater sparkle, string downloadFileName)
        {
            ShowMessage(NetSparkleResources.DefaultUIFactory_MessageTitle,
                string.Format(NetSparkleResources.DefaultUIFactory_ShowUnknownInstallerFormatMessageText, downloadFileName));
        }

        /// <inheritdoc/>
        public virtual void ShowVersionIsUpToDate(SparkleUpdater sparkle)
        {
            ShowMessage(NetSparkleResources.DefaultUIFactory_MessageTitle, NetSparkleResources.DefaultUIFactory_ShowVersionIsUpToDateMessage);
        }

        /// <inheritdoc/>
        public virtual void ShowVersionIsSkippedByUserRequest(SparkleUpdater sparkle)
        {
            ShowMessage(NetSparkleResources.DefaultUIFactory_MessageTitle, NetSparkleResources.DefaultUIFactory_ShowVersionIsSkippedByUserRequestMessage);
        }

        /// <inheritdoc/>
        public virtual void ShowCannotDownloadAppcast(SparkleUpdater sparkle, string appcastUrl)
        {
            ShowMessage(NetSparkleResources.DefaultUIFactory_ErrorTitle, NetSparkleResources.DefaultUIFactory_ShowCannotDownloadAppcastMessage);
        }

        /// <inheritdoc/>
        public virtual bool CanShowToastMessages(SparkleUpdater sparkle)
        {
            return true;
        }

        /// <inheritdoc/>
        public virtual void ShowToast(SparkleUpdater sparkle, List<AppCastItem> updates, Action<List<AppCastItem>> clickHandler)
        {
            Thread thread = new Thread(() =>
            {
                var toast = new NetSparkleToastNotifierWindow(_applicationIcon)
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

        /// <inheritdoc/>
        public virtual void ShowDownloadErrorMessage(SparkleUpdater sparkle, string message, string appcastUrl)
        {
            ShowMessage(NetSparkleResources.DefaultUIFactory_ErrorTitle, string.Format(NetSparkleResources.DefaultUIFactory_ShowDownloadErrorMessage, message));
        }

        private void ShowMessage(string title, string message)
        {
            var messageWindow = new NetSparkleMessageNotificationWindow(title, message, _applicationIcon);
            messageWindow.StartPosition = FormStartPosition.CenterScreen;
            messageWindow.ShowDialog();
        }

        /// <inheritdoc/>
        public void Shutdown(SparkleUpdater sparkle)
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