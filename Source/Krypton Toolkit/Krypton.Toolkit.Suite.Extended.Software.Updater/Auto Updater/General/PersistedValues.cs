namespace Krypton.Toolkit.Suite.Extended.Software.Updater
{
    /// <summary>
    ///     Provides way to serialize and deserialize AutoUpdater persisted values.
    /// </summary>
    [DataContract]
    public class PersistedValues
    {
        /// <summary>
        ///     Application version to be skipped.
        /// </summary>
        /// <remarks>The SetSkippedVersion function sets this property and calls the Save() method for making changes permanent.</remarks>
        [DataMember]
        public Version? SkippedVersion { get; set; }

        /// <summary>
        ///     Date and time at which the user must be given again the possibility to upgrade the application.
        /// </summary>
        [DataMember]
        public DateTime? RemindLaterAt { get; set; }
    }
}