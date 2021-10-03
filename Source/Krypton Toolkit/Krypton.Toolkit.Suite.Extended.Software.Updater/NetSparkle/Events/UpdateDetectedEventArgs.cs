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
    /// Contains all information for the update detected event
    /// </summary>
    public class UpdateDetectedEventArgs : EventArgs
    {
        /// <summary>
        /// The next action
        /// </summary>
        public NextUpdateAction NextAction { get; set; }
        /// <summary>
        /// The application configuration
        /// </summary>
        public Configuration ApplicationConfig { get; set; }
        /// <summary>
        /// The latest available version
        /// </summary>
        public AppCastItem LatestVersion { get; set; }

        /// <summary>
        /// All app cast items that were sent in the appcast
        /// </summary>
        public List<AppCastItem> AppCastItems { get; set; }
    }
}