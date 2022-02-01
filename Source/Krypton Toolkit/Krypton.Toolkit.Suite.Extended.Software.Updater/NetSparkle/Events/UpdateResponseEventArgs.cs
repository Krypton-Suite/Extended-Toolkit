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
    /// Event arguments for when a user responds to an available update UI
    /// </summary>
    public class UpdateResponseEventArgs : EventArgs
    {
        /// <summary>
        /// The user's response to the update
        /// </summary>
        public UpdateAvailableResult Result { get; set; }

        /// <summary>
        /// The AppCastItem that the user is responding to an update notice for
        /// </summary>
        public AppCastItem UpdateItem { get; set; }

        /// <summary>
        /// Constructor for UpdateResponseArgs that allows for easy setting
        /// of the result
        /// </summary>
        /// <param name="result">User's response of type UpdateAvailableResult</param>
        /// <param name="item">Item that the user is responding to an update message for</param>
        public UpdateResponseEventArgs(UpdateAvailableResult result, AppCastItem item) : base()
        {
            Result = result;
            UpdateItem = item;
        }
    }
}
