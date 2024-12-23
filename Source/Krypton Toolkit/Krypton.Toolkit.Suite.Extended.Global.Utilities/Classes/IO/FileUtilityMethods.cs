﻿#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Global.Utilities
{
    /// <summary>
    /// This class is used to retrieve data for the downloaded file.
    /// Version: 1.0.6
    /// Date: Thursday 31st December 2015
    /// Modified: Tuesday 6th April 2021
    /// </summary>
    public class FileUtilityMethods
    {
        //GlobalMethods globalMethods = new GlobalMethods();

        /// <summary>
        /// Initializes a new instance of the <see cref="FileUtilityMethods"/> class.
        /// </summary>
        public FileUtilityMethods()
        {

        }

        /// <summary>
        /// Parses the size of the readable file.
        /// </summary>
        /// <param name="fileSize">Size of the file.</param>
        /// <returns></returns>
        public static string ParseReadableFileSize(long fileSize)
        {
            string sign = fileSize < 0 ? "-" : "", suffix;

            double readable = fileSize < 0 ? -fileSize : fileSize;

            if (fileSize >= 0x40000000) // Gigabyte
            {
                suffix = "GB";

                readable = (double)(fileSize >> 20);
            }
            else if (fileSize >= 0x100000) // Megabyte
            {
                suffix = "MB";

                readable = (double)(fileSize >> 10);
            }
            else if (fileSize >= 0x400) // Kilobyte
            {
                suffix = "KB";

                readable = (double)fileSize;
            }
            else
            {
                return fileSize.ToString($"{sign}0 B"); // Byte
            }

            readable = readable / 1024;

            return sign + readable.ToString("0.### ") + suffix;
        }

        /// <summary>
        /// Parses the size of the readable file.
        /// </summary>
        /// <param name="fileSize">Size of the file.</param>
        /// <returns></returns>
        public string ParseReadableFileSize(int fileSize)
        {
            string output;

            decimal size;

            if (fileSize >= 1073741824)
            {
                size = decimal.Divide(fileSize, 1073741824);

                output = string.Format("{0:##.##} GB", size);
            }
            else if (fileSize >= 1048576)
            {
                size = decimal.Divide(fileSize, 1048576);

                output = string.Format("{0:##.##} MB", size);
            }
            else if (fileSize >= 1024)
            {
                size = decimal.Divide(fileSize, 1024);

                output = output = string.Format("{0:##.##} KB", size);
            }
            else if (fileSize > 0 & fileSize < 1024)
            {
                size = fileSize;

                output = output = string.Format("{0:##.##} Bytes", size);
            }
            else
            {
                output = "Zero Byte File";
            }

            return output;
        }

        /// <summary>
        /// This is a highly optimized function to get the file size abbreviation in bytes for an arbitrary, 64-bit file size. It returns the file size to three decimals followed by the abbreviation, like KB, MB, GB, etc. Use this function to display a human-readable, user-friendly file size to your users.
        /// https://www.somacon.com/p576.php
        /// </summary>
        /// <param name="size">The size.</param>
        /// <returns>
        ///   Returns the human-readable file size for an arbitrary, 64-bit file size.
        /// </returns>
        public string GetBytesReadable(long size)
        {
            // Get absolute value
            long absoluteI = size < 0 ? -size : size;
            // Determine the suffix and readable value
            string suffix;
            double readable;
            if (absoluteI >= 0x1000000000000000) // Exabyte
            {
                suffix = "EB";
                readable = size >> 50;
            }
            else if (absoluteI >= 0x4000000000000) // Petabyte
            {
                suffix = "PB";
                readable = size >> 40;
            }
            else if (absoluteI >= 0x10000000000) // Terabyte
            {
                suffix = "TB";
                readable = size >> 30;
            }
            else if (absoluteI >= 0x40000000) // Gigabyte
            {
                suffix = "GB";
                readable = size >> 20;
            }
            else if (absoluteI >= 0x100000) // Megabyte
            {
                suffix = "MB";
                readable = size >> 10;
            }
            else if (absoluteI >= 0x400) // Kilobyte
            {
                suffix = "KB";
                readable = size;
            }
            else
            {
                return size.ToString("0 B"); // Byte
            }
            // Divide by 1024 to get fractional value
            readable = readable / 1024;
            // Return formatted number with suffix
            return readable.ToString("0.### ") + suffix;
        }

        /// <summary>
        /// Returns the size of the online file.
        /// </summary>
        /// <param name="onlineFileUrl">The online file URL.</param>
        /// <param name="fileSize">Size of the file.</param>
        public void ReturnOnlineFileSize(string onlineFileUrl, KryptonLabel fileSize)
        {
            string url = onlineFileUrl, fileType = url.Substring(url.LastIndexOf(".") + 1, url.Length - url.LastIndexOf(".") - 1), fileName = url.Substring(url.LastIndexOf("/") + 1, url.Length - url.LastIndexOf("/") - 1);

            WebRequest request = (HttpWebRequest)WebRequest.Create(onlineFileUrl);

            request.Method = "HEAD";

            WebResponse response = (HttpWebResponse)request.GetResponse();

            long contentLength = 0, result;

            if (long.TryParse(response.Headers.Get("Content-Length"), out contentLength))
            {
                if (contentLength >= 1073741824)
                {
                    result = contentLength / 1073741824;

                    fileSize.Text = string.Format("Package Size: {0:##.##} GB", result);
                }
                else if (contentLength >= 1048576)
                {
                    result = contentLength / 1048576;

                    fileSize.Text = string.Format("Package Size: {0:##.##} MB", result);
                }
                else if (contentLength >= 1024)
                {
                    result = contentLength / 1024;

                    fileSize.Text = string.Format("Package Size: {0:##.##} KB", result);
                }
                else
                {
                    result = contentLength;

                    fileSize.Text = string.Format("Package Size: {0:##:##} Bytes", result);
                }
            }
        }

        /// <summary>
        /// Formats the length of the file.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="output">The output.</param>
        public void FormatFileLength(string filePath, KryptonLabel output)
        {
            long fileSize = (long)ReturnFileLength(filePath), result;

            if (fileSize >= 1073741824)
            {
                result = fileSize / 1073741824;

                output.Text = string.Format("File Size: {0:##:##} GB", result);
            }
            else if (fileSize >= 1048576)
            {
                result = fileSize / 1048576;

                output.Text = string.Format("File Size: {0:##:##} MB", result);
            }
            else if (fileSize >= 1024)
            {
                result = fileSize / 1024;

                output.Text = string.Format("File Size: {0:##:##} KB", result);
            }
        }

        /// <summary>
        /// Retrieves the file length from the specified file.
        /// </summary>
        /// <param name="filePath">The file path to the specified file.</param>
        /// <returns>The file length from the specified file.</returns>
        public int ReturnFileLength(string filePath)
        {
            return Convert.ToInt32(ReturnFileInformation(filePath).Length);
        }

        /// <summary>
        /// Retrieves the file last accessed time from the specified file.
        /// </summary>
        /// <param name="filePath">The file path to the specified file.</param>
        /// <returns>The file last accessed time from the specified file.</returns>
        public DateTime ReturnFileLastAccessedTime(string filePath)
        {
            return ReturnFileInformation(filePath).LastAccessTime;
        }

        /// <summary>
        /// Retrieves the file creation time from the specified file.
        /// </summary>
        /// <param name="filePath">The file path to the specified file.</param>
        /// <returns>The file creation time from the specified file.</returns>
        public DateTime ReturnFileCreationTime(string filePath)
        {
            return ReturnFileInformation(filePath).CreationTime;
        }

        /// <summary>
        /// Retrieves the file last write time from the specified file.
        /// </summary>
        /// <param name="filePath">The file path to the specified file.</param>
        /// <returns>The file last write time from the specified file.</returns>
        public DateTime ReturnFileLastWriteTime(string filePath)
        {
            return ReturnFileInformation(filePath).LastWriteTime;
        }

        /// <summary>
        /// Retrieves the file name from the specified file.
        /// </summary>
        /// <param name="filePath">The file path to the specified file.</param>
        /// <returns>The file name from the specified file.</returns>
        public string ReturnFileName(string filePath)
        {
            return ReturnFileInformation(filePath).Name;
        }

        /// <summary>
        /// Retrieves the file extension from the specified file.
        /// </summary>
        /// <param name="filePath">The file path to the specified file.</param>
        /// <returns>The file extension from the specified file.</returns>
        public string ReturnFileExtension(string filePath)
        {
            return ReturnFileInformation(filePath).Extension;
        }

        /// <summary>
        /// Retrieves the file information from the specified file.
        /// </summary>
        /// <param name="filePath">The file path to the specified file.</param>
        /// <returns>The file information from the specified file.</returns>
        public FileInfo ReturnFileInformation(string filePath)
        {
            FileInfo fileInformation = new FileInfo(filePath);

            return fileInformation;
        }

        /// <summary>
        /// Loads from file.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        public string LoadFromFile(string filePath)
        {
            string fileContent = string.Empty;

            try
            {
                if (new FileInfo(filePath).Length == 0)
                {
                    KryptonMessageBox.Show("The file specified is a zero-byte file. Please try again.", "Zero-Byte File Detected", KryptonMessageBoxButtons.OK, KryptonMessageBoxIcon.Error);
                }
                else
                {
                    fileContent = File.OpenRead(filePath).ToString();
                }
            }
            catch (Exception exc)
            {
                DebugUtilities.NotImplemented(exc.ToString());
            }

            return fileContent;
        }

        /// <summary>
        /// Determines whether [is file locked] [the specified file].
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns>
        ///   <c>true</c> if [is file locked] [the specified file]; otherwise, <c>false</c>.
        /// </returns>
        protected virtual bool IsFileLocked(FileInfo file)
        {
            FileStream? fs = null;

            try
            {
                fs = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            }
            catch (IOException)
            {
                return true;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }

            return false;
        }

        /// <summary>
        /// Returns the file information on the selected file.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>Returns the file information on the selected file.</returns>
        public FileInfo ReturnFileInformationOn(string filePath) => new FileInfo(filePath);

        /// <summary>Gets the directory contents of the selected path.</summary>
        /// <param name="directoryPath">The directory path.</param>
        /// <returns>The contents of the selected path.</returns>
        public List<string> GetDirectoryContents(string directoryPath)
        {
            List<string> content = new List<string>();

            foreach (string item in Directory.GetFiles(directoryPath))
            {
                content.Add(item);
            }

            return content;
        }

        /// <summary>Gets the files in the chosen directory.</summary>
        /// <param name="directoryPath">The directory path.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public string[] GetFiles(string directoryPath)
        {
            string[] temp = Directory.GetFiles(directoryPath);

            return temp;
        }

        /// <summary>Gets the directories.</summary>
        /// <param name="directoryPath">The directory path.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public string[] GetDirectories(string directoryPath)
        {
            string[] temp = Directory.GetDirectories(directoryPath);

            return temp;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="FileUtilityMethods"/> class.
        /// </summary>
        ~FileUtilityMethods()
        {
            GC.SuppressFinalize(this);
        }
    }

    public static class FileUtilityMethodsExtended
    {
        /// <summary>Gets the framework version of an assembly. See: https://www.nimaara.com/how-to-obtain-the-framework-version-of-a-net-assembly/. </summary>
        /// <param name="assembly">The assembly.</param>
        /// <returns> </returns>
        public static string GetFrameworkVersion(this Assembly assembly)
        {
            var targetFrameAttribute = assembly.GetCustomAttributes(true)
                .OfType<TargetFrameworkAttribute>().FirstOrDefault();
            if (targetFrameAttribute == null)
            {
                return ".NET 2, 3 or 3.5";
            }

            return targetFrameAttribute.FrameworkDisplayName.Replace(".NET Framework", ".NET");
        }
    }
}