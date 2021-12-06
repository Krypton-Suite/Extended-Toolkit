#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Software.Updater.NetSparkle
{
    /// <summary>
    /// Interface for UIs that tell the user that NetSparkle is checking for updates
    /// </summary>
    public interface ICheckingForUpdates
    {
        /// <summary>
        /// Event to fire when the checking for updates UI is closing
        /// </summary>
        event EventHandler UpdatesUIClosing;

        /// <summary>
        /// Show the UI
        /// </summary>
        void Show();

        /// <summary>
        /// Close the form
        /// </summary>
        void Close();
    }
}