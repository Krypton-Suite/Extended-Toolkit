﻿#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Software.Updater.NetSparkle
{
    /// <summary>
    /// Interface for UI element that shows the release notes, 
    /// and the skip, install, and later buttons
    /// </summary>
    public interface IUpdateAvailable
    {
        /// <summary>
        /// Event fired when the user has responded to the 
        /// skip, later, install question.
        /// </summary>
        event UserRespondedToUpdate UserResponded;

        /// <summary>
        /// Show the UI
        /// </summary>
        void Show(bool IsOnMainThread);

        /// <summary>
        /// Hides the release notes 
        /// </summary>
        void HideReleaseNotes();

        /// <summary>
        /// Hides the remind me later button
        /// </summary>
        void HideRemindMeLaterButton();

        /// <summary>
        /// Hides the skip update button
        /// </summary>
        void HideSkipButton();

        /// <summary>
        /// Gets the result for skip, later, or install
        /// </summary>
        UpdateAvailableResult Result { get; }

        /// <summary>
        /// Gets or sets the current item being installed
        /// </summary>
        AppCastItem CurrentItem { get; }

        /// <summary>
        /// Brings the form to the front of all windows
        /// </summary>
        void BringToFront();

        /// <summary>
        /// Close the form
        /// </summary>
        void Close();
    }
}