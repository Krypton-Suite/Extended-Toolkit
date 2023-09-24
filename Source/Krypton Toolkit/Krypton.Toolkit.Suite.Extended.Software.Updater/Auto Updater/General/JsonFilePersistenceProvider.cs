﻿namespace Krypton.Toolkit.Suite.Extended.Software.Updater
{
    /// <summary>Provides a mechanism for storing AutoUpdater state between sessions on a Json formatted file.</summary>
    public class JsonFilePersistenceProvider : IPersistenceProvider
    {
        /// <summary>Initializes a new instance of the JsonFilePersistenceProvider class.</summary>
        /// <remarks>The path for the Json formatted file must be specified using the FileName property.</remarks>
        public JsonFilePersistenceProvider(string jsonPath)
        {
            FileName = jsonPath;
            ReadFile();
        }

        /// <summary>
        ///     Path for the Json formatted file.
        /// </summary>
        private string FileName { get; }

        /// <summary>
        /// </summary>
        private PersistedValues PersistedValues { get; set; }

        /// <inheritdoc />
        public Version? GetSkippedVersion()
        {
            return PersistedValues.SkippedVersion;
        }

        /// <inheritdoc />
        public DateTime? GetRemindLater()
        {
            return PersistedValues.RemindLaterAt;
        }

        /// <inheritdoc />
        public void SetSkippedVersion(Version? version)
        {
            PersistedValues.SkippedVersion = version;
            Save();
        }

        /// <inheritdoc />
        public void SetRemindLater(DateTime? remindLaterAt)
        {
            PersistedValues.RemindLaterAt = remindLaterAt;
            Save();
        }

        /// <summary>
        ///     Stores applied modifications into the Json formatted file specified in the FileName property.
        /// </summary>
        private void Save()
        {
            string json;

            using (var stream = new MemoryStream())
            {
                var serializer = new DataContractJsonSerializer(PersistedValues.GetType());
                serializer.WriteObject(stream, PersistedValues);

                using (var reader = new StreamReader(stream))
                {
                    stream.Seek(0, SeekOrigin.Begin);
                    json = reader.ReadToEnd();
                }
            }

            File.WriteAllText(FileName, json);
        }

        /// <summary>
        ///     Reads a Json formatted file and returns an initialized instance of the class PersistedValues.
        /// </summary>
        /// <remarks>The function creates a new instance, initialized with default parameters, in case the file does not exist.</remarks>
        private void ReadFile()
        {
            PersistedValues? jsonFile = null;

            if (File.Exists(FileName))
            {
                using var stream = new MemoryStream(Encoding.UTF8.GetBytes(File.ReadAllText(FileName)));
                var serializer =
                    new DataContractJsonSerializer(typeof(PersistedValues));
                jsonFile = (PersistedValues)serializer.ReadObject(stream);
            }

            PersistedValues = jsonFile ?? new PersistedValues();
        }
    }
}