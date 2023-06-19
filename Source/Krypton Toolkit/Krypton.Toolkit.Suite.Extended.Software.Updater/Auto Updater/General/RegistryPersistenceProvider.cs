﻿namespace Krypton.Toolkit.Suite.Extended.Software.Updater
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