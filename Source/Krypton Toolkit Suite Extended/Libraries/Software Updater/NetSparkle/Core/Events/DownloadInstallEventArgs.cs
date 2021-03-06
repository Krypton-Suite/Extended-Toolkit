﻿#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;

namespace Krypton.Toolkit.Suite.Extended.Software.Updater.NetSparkle
{
    /// <summary>
    /// Event called when the download/install window closes
    /// </summary>
    /// <param name="sender">Sender of this event</param>
    /// <param name="args">DownloadInstallArgs with info on whether to install or not</param>
    public delegate void DownloadInstallEventHandler(object sender, DownloadInstallEventArgs args);

    /// <summary>
    /// Args sent via the DownloadInstallEventHandler when the download/install window closes
    /// </summary>
    public class DownloadInstallEventArgs : EventArgs
    {
        /// <summary>
        /// Whether or not the listener should perform the installation process
        /// </summary>
        public bool ShouldInstall { get; set; }

        /// <summary>
        /// True if the download/install event was already handled; false otherwise
        /// </summary>
        public bool WasHandled { get; set; }

        /// <summary>
        /// Constructor for DownloadInstallArgs
        /// </summary>
        /// <param name="shouldInstall">True if the listener should start the download process; false otherwise</param>
        public DownloadInstallEventArgs(bool shouldInstall) : base()
        {
            ShouldInstall = shouldInstall;
        }
    }
}