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
    /// Configuration data for this software and NetSparkle instance.
    /// Allows you to get information on the versions that the user
    /// skipped, when the last update was performed, etc.
    /// </summary>
    public class SavedConfigurationData
    {
        /// <summary>
        /// Whether or not to check for an update
        /// </summary>
        public bool CheckForUpdate { get; set; }
        /// <summary>
        /// The last DateTime that an update check was performed
        /// </summary>
        public DateTime LastCheckTime { get; set; }
        /// <summary>
        /// The previous version of the software that the user ran
        /// </summary>
        public string PreviousVersionOfSoftwareRan { get; set; }
        /// <summary>
        /// The last version (as a string) that the user chose
        /// to skip.
        /// Can be blank.
        /// </summary>
        public string LastVersionSkipped { get; set; }
        /// <summary>
        /// Whether or not the software has run at least one time.
        /// </summary>
        public bool DidRunOnce { get; set; }
        /// <summary>
        /// Last DateTime that the configuration data was updated.
        /// </summary>
        public DateTime LastConfigUpdate { get; set; }
    }
}