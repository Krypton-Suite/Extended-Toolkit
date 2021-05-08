#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.Versioning;
using System.Windows.Forms;

using Krypton.Toolkit.Suite.Extended.Developer.Utilities;

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
            string sign = (fileSize < 0 ? "-" : ""), suffix;

            double readable = (fileSize < 0 ? -fileSize : fileSize);

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
                return fileSize.ToString(sign + "0 B"); // Byte
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
            long absolute_i = (size < 0 ? -size : size);
            // Determine the suffix and readable value
            string suffix;
            double readable;
            if (absolute_i >= 0x1000000000000000) // Exabyte
            {
                suffix = "EB";
                readable = (size >> 50);
            }
            else if (absolute_i >= 0x4000000000000) // Petabyte
            {
                suffix = "PB";
                readable = (size >> 40);
            }
            else if (absolute_i >= 0x10000000000) // Terabyte
            {
                suffix = "TB";
                readable = (size >> 30);
            }
            else if (absolute_i >= 0x40000000) // Gigabyte
            {
                suffix = "GB";
                readable = (size >> 20);
            }
            else if (absolute_i >= 0x100000) // Megabyte
            {
                suffix = "MB";
                readable = (size >> 10);
            }
            else if (absolute_i >= 0x400) // Kilobyte
            {
                suffix = "KB";
                readable = size;
            }
            else
            {
                return size.ToString("0 B"); // Byte
            }
            // Divide by 1024 to get fractional value
            readable = (readable / 1024);
            // Return formatted number with suffix
            return readable.ToString("0.### ") + suffix;
        }

        /// <summary>
        /// Returns the size of the online file.
        /// </summary>
        /// <param name="onlineFileURL">The online file URL.</param>
        /// <param name="fileSize">Size of the file.</param>
        public void ReturnOnlineFileSize(string onlineFileURL, KryptonLabel fileSize)
        {
            string URL = onlineFileURL, fileType = URL.Substring(URL.LastIndexOf(".") + 1, (URL.Length - URL.LastIndexOf(".") - 1)), fileName = URL.Substring(URL.LastIndexOf("/") + 1, (URL.Length - URL.LastIndexOf("/") - 1));

            WebRequest request = (HttpWebRequest)WebRequest.Create(onlineFileURL);

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
        /// <param name="FilePath">The file path.</param>
        /// <param name="Output">The output.</param>
        public void FormatFileLength(string FilePath, KryptonLabel Output)
        {
            long fileSize = (long)ReturnFileLength(FilePath), result;

            if (fileSize >= 1073741824)
            {
                result = fileSize / 1073741824;

                Output.Text = string.Format("File Size: {0:##:##} GB", result);
            }
            else if (fileSize >= 1048576)
            {
                result = fileSize / 1048576;

                Output.Text = string.Format("File Size: {0:##:##} MB", result);
            }
            else if (fileSize >= 1024)
            {
                result = fileSize / 1024;

                Output.Text = string.Format("File Size: {0:##:##} KB", result);
            }
        }

        /// <summary>
        /// Retrieves the file length from the specified file.
        /// </summary>
        /// <param name="FilePath">The file path to the specified file.</param>
        /// <returns>The file length from the specified file.</returns>
        public int ReturnFileLength(string FilePath)
        {
            return Convert.ToInt32(ReturnFileInformation(FilePath).Length);
        }

        /// <summary>
        /// Retrieves the file last accessed time from the specified file.
        /// </summary>
        /// <param name="FilePath">The file path to the specified file.</param>
        /// <returns>The file last accessed time from the specified file.</returns>
        public DateTime ReturnFileLastAccessedTime(string FilePath)
        {
            return ReturnFileInformation(FilePath).LastAccessTime;
        }

        /// <summary>
        /// Retrieves the file creation time from the specified file.
        /// </summary>
        /// <param name="FilePath">The file path to the specified file.</param>
        /// <returns>The file creation time from the specified file.</returns>
        public DateTime ReturnFileCreationTime(string FilePath)
        {
            return ReturnFileInformation(FilePath).CreationTime;
        }

        /// <summary>
        /// Retrieves the file last write time from the specified file.
        /// </summary>
        /// <param name="FilePath">The file path to the specified file.</param>
        /// <returns>The file last write time from the specified file.</returns>
        public DateTime ReturnFileLastWriteTime(string FilePath)
        {
            return ReturnFileInformation(FilePath).LastWriteTime;
        }

        /// <summary>
        /// Retrieves the file name from the specified file.
        /// </summary>
        /// <param name="FilePath">The file path to the specified file.</param>
        /// <returns>The file name from the specified file.</returns>
        public string ReturnFileName(string FilePath)
        {
            return ReturnFileInformation(FilePath).Name;
        }

        /// <summary>
        /// Retrieves the file extension from the specified file.
        /// </summary>
        /// <param name="FilePath">The file path to the specified file.</param>
        /// <returns>The file extension from the specified file.</returns>
        public string ReturnFileExtension(string FilePath)
        {
            return ReturnFileInformation(FilePath).Extension;
        }

        /// <summary>
        /// Retrieves the file information from the specified file.
        /// </summary>
        /// <param name="FilePath">The file path to the specified file.</param>
        /// <returns>The file information from the specified file.</returns>
        public FileInfo ReturnFileInformation(string FilePath)
        {
            FileInfo fileInformation = new FileInfo(FilePath);

            return fileInformation;
        }

        /// <summary>
        /// Loads from file.
        /// </summary>
        /// <param name="FilePath">The file path.</param>
        /// <returns></returns>
        public string LoadFromFile(string FilePath)
        {
            string fileContent = string.Empty;

            try
            {
                if (new FileInfo(FilePath).Length == 0)
                {
                    KryptonMessageBox.Show("The file specified is a zero-byte file. Please try again.", "Zero-Byte File Detected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    fileContent = File.OpenRead(FilePath).ToString();
                }
            }
            catch (Exception exc)
            {
                ExceptionCapture.CaptureException(exc);
            }

            return fileContent;
        }

        /// <summary>
        /// Determines whether [is file locked] [the specified file].
        /// </summary>
        /// <param name="File">The file.</param>
        /// <returns>
        ///   <c>true</c> if [is file locked] [the specified file]; otherwise, <c>false</c>.
        /// </returns>
        protected virtual bool IsFileLocked(FileInfo File)
        {
            FileStream fs = null;

            try
            {
                fs = File.Open(FileMode.Open, FileAccess.Read, FileShare.None);
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