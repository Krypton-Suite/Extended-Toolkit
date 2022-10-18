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
    /// Universal interface for creating UI utilized by SparkleUpdater
    /// </summary>
    public interface IUIFactory
    {
        /// <summary>
        /// Create sparkle form implementation. This is the form that tells the user that an update is available, shows changelogs if necessary, etc.
        /// </summary>
        /// <param name="sparkle">The <see cref="SparkleUpdater"/> instance to use</param>
        /// <param name="updates">Sorted array of updates from latest to previous</param>
        /// <param name="isUpdateAlreadyDownloaded">If true, make sure UI text shows that the user is about to install the file instead of download it.</param>
        IUpdateAvailable CreateUpdateAvailableWindow(SparkleUpdater sparkle, List<AppCastItem> updates, bool isUpdateAlreadyDownloaded = false);

        /// <summary>
        /// Create download progress window
        /// </summary>
        /// <param name="item">Appcast item to download</param>
        IDownloadProgress CreateProgressWindow(AppCastItem item);

        /// <summary>
        /// Inform user in some way that NetSparkle is checking for updates
        /// </summary>
        ICheckingForUpdates ShowCheckingForUpdates();

        /// <summary>
        /// Initialize UI. Called when Sparkle is constructed and/or when the UIFactory is set.
        /// </summary>
        void Init();

        /// <summary>
        /// Show user a message saying downloaded update format is unknown
        /// </summary>
        void ShowUnknownInstallerFormatMessage(string downloadFileName);

        /// <summary>
        /// Show user that current installed version is up-to-date
        /// </summary>
        void ShowVersionIsUpToDate();

        /// <summary>
        /// Show message that latest update was skipped by user
        /// </summary>
        void ShowVersionIsSkippedByUserRequest();

        /// <summary>
        /// Show message that appcast is not available
        /// </summary>
        void ShowCannotDownloadAppcast(string appcastUrl);

        /// <summary>
        /// See if this UIFactory can show toast messages
        /// </summary>
        /// <returns>true if the UIFactory can show for toast messages; false otherwise</returns>
        bool CanShowToastMessages();

        /// <summary>
        /// Show 'toast' window to notify new version is available
        /// </summary>
        /// <param name="updates">Appcast updates</param>
        /// <param name="clickHandler">handler for click</param>
        void ShowToast(List<AppCastItem> updates, Action<List<AppCastItem>> clickHandler);

        /// <summary>
        /// Show message on download error
        /// </summary>
        /// <param name="message">Error message from exception</param>
        /// <param name="appcastUrl">the URL for the appcast file</param>
        void ShowDownloadErrorMessage(string message, string appcastUrl);

        /// <summary>
        /// Shut down the UI so we can run an update.
        /// If in WPF, System.Windows.Application.Current.Shutdown().
        /// If in WinForms, Application.Exit().
        /// </summary>
        void Shutdown();

        /// <summary>
        /// Hides the release notes view when an update is found.
        /// </summary>
        bool HideReleaseNotes { get; set; }

        /// <summary>
        /// Hides the skip this update button when an update is found.
        /// </summary>
        bool HideSkipButton { get; set; }

        /// <summary>
        /// Hides the remind me later button when an update is found.
        /// </summary>
        bool HideRemindMeLaterButton { get; set; }
    }
}