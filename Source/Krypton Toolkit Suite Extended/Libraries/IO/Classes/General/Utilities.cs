#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Common;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Krypton.Toolkit.Suite.Extended.IO
{
    public class Utilities
    {
        public Utilities()
        {

        }

        #region Methods
        /// <summary>Populates the directory information.</summary>
        /// <param name="directory">The directory.</param>
        /// <param name="target">The target.</param>
        public void PopulateDirectoryInformation(string directory, KryptonLabel target)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(directory);

            target.Text = $"Directory Name: { directoryInfo.Name }\nCreated: { directoryInfo.CreationTime.ToString() }\nModified: { directoryInfo.LastWriteTime }\nSize: { ParseReadableSize(GetDirectorySize(directoryInfo)) }\nAttributes: { directoryInfo.Attributes }";
        }

        /// <summary>Parses the size of the readable.</summary>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        private string ParseReadableSize(long size)
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
        ///  Gets the size of the directory.
        ///  https://stackoverflow.com/questions/468119/whats-the-best-way-to-calculate-the-size-of-a-directory-in-net
        /// </summary>
        /// <param name="directory">The directory.</param>
        /// <returns></returns>
        private long GetDirectorySize(DirectoryInfo directory)
        {
            DirectoryInfo[] directories = directory.GetDirectories();

            long totalSize = 0;

            FileInfo[] files = directory.GetFiles();

            foreach (FileInfo file in files)
            {
                totalSize += file.Length;
            }

            foreach (DirectoryInfo directoryInfo in directories)
            {
                totalSize += GetDirectorySize(directoryInfo);
            }

            return totalSize;
        }

        /// <summary>Gets the size of the file.</summary>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        private long GetFileSize(string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);

            return fileInfo.Length;
        }

        /// <summary>Populates the file information.</summary>
        /// <param name="file">The file.</param>
        /// <param name="target">The target.</param>
        public void PopulateFileInformation(string file, KryptonLabel target)
        {
            FileInfo fileInfo = new FileInfo(file);

            target.Text = $"File Name: { fileInfo.Name }\nCreated: { fileInfo.CreationTime.ToString() }\nModified: { fileInfo.LastWriteTime }\nSize: { ParseReadableSize(GetFileSize(file)) }\nAttributes: { fileInfo.Attributes }";
        }

        /// <summary>Gets the file hash.</summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="hashType">Type of the hash.</param>
        /// <param name="target">The target.</param>
        public void GetFileHash(string filePath, SupportedHashAlgorithims hashType, KryptonLabel target) => target.Text = GetHash(hashType, filePath);

        private string GetHash(SupportedHashAlgorithims hashType, string filePath)
        {
            switch (hashType)
            {
                case SupportedHashAlgorithims.MESSAGEDIGEST5:
                    return MakeHashString(MD5.Create().ComputeHash(new FileStream(filePath, FileMode.Open)));
                case SupportedHashAlgorithims.SECUREHASHALGORITHIM1:
                    return MakeHashString(SHA1.Create().ComputeHash(new FileStream(filePath, FileMode.Open)));
                case SupportedHashAlgorithims.SECUREHASHALGORITHIM256:
                    return MakeHashString(SHA256.Create().ComputeHash(new FileStream(filePath, FileMode.Open)));
                case SupportedHashAlgorithims.SECUREHASHALGORITHIM384:
                    return MakeHashString(SHA384.Create().ComputeHash(new FileStream(filePath, FileMode.Open)));
                case SupportedHashAlgorithims.SECUREHASHALGORITHIM512:
                    return MakeHashString(SHA512.Create().ComputeHash(new FileStream(filePath, FileMode.Open)));
                // TODO: Why do we need to do this?
#if !NETCOREAPP
                case SupportedHashAlgorithims.RACEINTEGRITYPRIMITIVESEVALUATIONMESSAGEDIGEST:
                    return MakeHashString(RIPEMD160.Create().ComputeHash(new FileStream(filePath, FileMode.Open)));
#endif 
                default:
                    return "";
            }
        }

        /// <summary>
        /// Converts byte[] to string
        /// </summary>
        /// <param name="hash">The hash to convert</param>
        /// <returns>Hash as string</returns>
        private static string MakeHashString(byte[] hash)
        {
            StringBuilder s = new StringBuilder();

            foreach (byte b in hash)
                s.Append(b.ToString("x2").ToLower());

            return s.ToString();
        }
        #endregion
    }
}