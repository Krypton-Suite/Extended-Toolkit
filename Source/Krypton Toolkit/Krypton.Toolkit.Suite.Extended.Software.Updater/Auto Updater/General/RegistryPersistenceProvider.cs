#region License

/**
 * MIT License
 *
 * Copyright (c) 2012 - 2023 RBSoft
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
 **/

#endregion

namespace Krypton.Toolkit.Suite.Extended.Software.Updater
{
    /// <summary>
    ///     Provides a mechanism for storing AutoUpdater state between sessions based on storing data on the Windows Registry.
    /// </summary>
    public class RegistryPersistenceProvider : IPersistenceProvider
    {
        private const string REMIND_LATER_VALUE_NAME = "RemindLaterAt";

        private const string SKIPPED_VERSION_VALUE_NAME = "SkippedVersion";

        /// <summary>
        ///     Initializes a new instance of the RegistryPersistenceProvider class indicating the path for the Windows registry
        ///     key to use for storing the data.
        /// </summary>
        /// <param name="registryLocation"></param>
        public RegistryPersistenceProvider(string registryLocation)
        {
            RegistryLocation = registryLocation;
        }

        /// <summary>
        ///     Gets/sets the path for the Windows Registry key that will contain the data.
        /// </summary>
        private string RegistryLocation { get; }

        /// <inheritdoc />
        public Version? GetSkippedVersion()
        {
            try
            {
                using RegistryKey? updateKey = Registry.CurrentUser.OpenSubKey(RegistryLocation);
                object? skippedVersionValue = updateKey?.GetValue(SKIPPED_VERSION_VALUE_NAME);

                if (skippedVersionValue != null)
                {
                    return new Version(skippedVersionValue.ToString());
                }
            }
            catch (Exception)
            {
                // ignored
            }

            return null;
        }


        /// <inheritdoc />
        public DateTime? GetRemindLater()
        {
            using RegistryKey? updateKey = Registry.CurrentUser.OpenSubKey(RegistryLocation);
            object? remindLaterValue = updateKey?.GetValue(REMIND_LATER_VALUE_NAME);

            if (remindLaterValue == null)
            {
                return null;
            }

            try
            {
                return Convert.ToDateTime(remindLaterValue.ToString(),
                    CultureInfo.CreateSpecificCulture("en-US").DateTimeFormat);
            }
            catch (FormatException)
            {
                // ignored
            }

            return null;
        }

        /// <inheritdoc />
        public void SetSkippedVersion(Version? version)
        {
            using RegistryKey? autoUpdaterKey = Registry.CurrentUser.CreateSubKey(RegistryLocation);
            autoUpdaterKey?.SetValue(SKIPPED_VERSION_VALUE_NAME, version != null ? version.ToString() : string.Empty);
        }

        /// <inheritdoc />
        public void SetRemindLater(DateTime? remindLaterAt)
        {
            using RegistryKey? autoUpdaterKey = Registry.CurrentUser.CreateSubKey(RegistryLocation);
            autoUpdaterKey?.SetValue(REMIND_LATER_VALUE_NAME,
                remindLaterAt != null
                    ? remindLaterAt.Value.ToString(CultureInfo.CreateSpecificCulture("en-US").DateTimeFormat)
                    : string.Empty);
        }
    }
}