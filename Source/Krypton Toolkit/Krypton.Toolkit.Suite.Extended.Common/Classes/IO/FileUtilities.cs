#region MIT License
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

namespace Krypton.Toolkit.Suite.Extended.Common;

public class FileUtilities
{
    #region Constructor        
    /// <summary>
    /// Initializes a new instance of the <see cref="FileUtilities"/> class.
    /// </summary>
    public FileUtilities()
    {

    }
    #endregion

    #region Methods        
    /// <summary>
    /// Gets the file information.
    /// </summary>
    /// <param name="filePath">The file path.</param>
    /// <returns></returns>
    public static FileInfo GetFileInformation(string filePath)
    {
        return new FileInfo(filePath);
    }

    /// <summary>
    /// Gets the readable size of the file.
    /// https://stackoverflow.com/questions/281640/how-do-i-get-a-human-readable-file-size-in-bytes-abbreviation-using-net
    /// </summary>
    /// <param name="fileLength">Length of the file.</param>
    /// <returns></returns>
    public static string GetReadableFileSize(long fileLength)
    {
        // Get absolute value
        long absolute_i = fileLength < 0 ? -fileLength : fileLength;

        // Determine the suffix and readable value
        string suffix;

        double readable;

        if (absolute_i >= 0x1000000000000000) // Exabyte
        {
            suffix = "EB";

            readable = fileLength >> 50;
        }
        else if (absolute_i >= 0x4000000000000) // Petabyte
        {
            suffix = "PB";

            readable = fileLength >> 40;
        }
        else if (absolute_i >= 0x10000000000) // Terabyte
        {
            suffix = "TB";

            readable = fileLength >> 30;
        }
        else if (absolute_i >= 0x40000000) // Gigabyte
        {
            suffix = "GB";

            readable = fileLength >> 20;
        }
        else if (absolute_i >= 0x100000) // Megabyte
        {
            suffix = "MB";

            readable = fileLength >> 10;
        }
        else if (absolute_i >= 0x400) // Kilobyte
        {
            suffix = "KB";

            readable = fileLength;
        }
        else
        {
            return fileLength.ToString("0 B"); // Byte
        }

        // Divide by 1024 to get fractional value
        readable = readable / 1024;

        // Return formatted number with suffix
        return readable.ToString("0.### ") + suffix;
    }

    /// <summary>
    /// Gets the file size on disk.
    /// Code from: https://stackoverflow.com/questions/3750590/get-size-of-file-on-disk & https://stackoverflow.com/questions/5959983/how-to-check-logical-and-physical-file-size-on-disk-using-c-sharp-file-api
    /// </summary>
    /// <param name="filePath">The file path.</param>
    /// <returns></returns>
    /// <exception cref="Win32Exception"></exception>
    public static long GetFileSizeOnDisk(string filePath)
    {
        return new FileInfo(filePath).Length;

        //FileInfo info = new FileInfo(filePath);
        //uint clusterSize;
        //using (var searcher = new ManagementObjectSearcher("select BlockSize,NumberOfBlocks from Win32_Volume WHERE DriveLetter = '" + info.Directory.Root.FullName.TrimEnd('\\') + "'"))
        //{
        //    clusterSize = (uint)(((ManagementObject)(searcher.Get().First()))["BlockSize"]);
        //}
        //uint hosize;
        //uint losize = GetCompressedFileSizeW(filePath, out hosize);
        //long size;
        //size = (long)hosize << 32 | losize;
        //return ((size + clusterSize - 1) / clusterSize) * clusterSize;
    }

    [DllImport("kernel32.dll")]
    static extern uint GetCompressedFileSizeW(
        [In, MarshalAs(UnmanagedType.LPWStr)] string lpFileName,
        [Out, MarshalAs(UnmanagedType.U4)] out uint lpFileSizeHigh);

    /// <summary>
    /// Imports the content from file.
    /// </summary>
    /// <param name="filePath">The file path.</param>
    /// <param name="listBox">The list box.</param>
    public static void ImportContentFromFile(string filePath, KryptonListBox listBox)
    {
        List<string> fileData = [];

        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                fileData.Add(line);
            }
        }

        if (fileData.Count != 0)
        {
            foreach (string item in fileData)
            {
                listBox.Items.Add(item);
            }
        }
    }
    #endregion
}