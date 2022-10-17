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

namespace Krypton.Toolkit.Suite.Extended.Error.Reporting
{
    /// <summary>
    /// a class for file operations that can be mocked out for tests
    /// </summary>
    internal class FileService : IFileService
    {
        public bool Exists(string file)
        {
            return File.Exists(file);
        }

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