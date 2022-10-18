#region MIT License
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