namespace Krypton.Toolkit.Suite.Extended.Error.Reporting
{
    internal interface IFileService
    {
        bool Exists(string file);
        string TempFile(string file);
        FileSaveResult Write(string file, string report);
    }

    internal class FileSaveResult
    {
        public bool Saved { get; set; }
        public Exception Exception { get; set; }
    }

    /// <summary>
    /// a class for file operations that can be mocked out for tests
    /// </summary>
    internal class FileService : IFileService
    {
        public bool Exists(string file) => File.Exists(file);

        /// <summary>
        /// Returns a file with given name, in system TEMP path
        /// </summary>
        /// <returns>The filename, ready for use</returns>
        public string TempFile(string file)
        {
            var tempFile = Path.Combine(Path.GetTempPath(), file);
            DeleteIfExists(tempFile);
            return tempFile;
        }

        /// <summary>
        /// writes a given filename with the given text content (presumably a report) to disk
        /// </summary>
        /// <param name="file"></param>
        /// <param name="report"></param>
        /// <returns>whether save succeeded and the exception in a single <see cref="FileSaveResult"/> object </returns>
        public FileSaveResult Write(string file, string report)
        {
            var result = new FileSaveResult();

            try
            {
                using (var stream = File.OpenWrite(file))
                {
                    var writer = new StreamWriter(stream);
                    writer.Write(report);
                    writer.Flush();
                }
                result.Saved = true;
            }
            catch (Exception exception)
            {
                result.Saved = false;
                result.Exception = exception;
            }

            return result;
        }

        private static void DeleteIfExists(string file)
        {
            if (File.Exists(file))
            {
                File.Delete(file);
            }
        }
    }
}