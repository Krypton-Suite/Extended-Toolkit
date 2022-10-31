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

namespace Krypton.Toolkit.Suite.Extended.Software.Updater.SharpUpdate
{
    internal class SharpUpdateFileInfo
    {
        /// <summary>
        /// Holds the url for download
        /// </summary>
        private string url;

        /// <summary>
        /// Holds th filename
        /// </summary>
        private string fileName;

        /// <summary>
        /// Holds the md5 checksum
        /// </summary>
        private string md5;

        /// <summary>
        /// Holds the path to the temporarly downloaded file
        /// </summary>
        private string tempFile;

        /// <summary>
        /// Creates a new SharpUpdateFileInfo object
        /// </summary>
        internal SharpUpdateFileInfo(string url, string fileName, string md5)
        {
            this.url = url;
            this.fileName = fileName;
            this.md5 = md5;
        }

        /// <summary>
        /// The download url for the file
        /// </summary>
        internal string Url => url;

        //set { url = value; }
        /// <summary>
        /// The filename
        /// </summary>
        internal string FileName => fileName;

        //set { fileName = value; }
        /// <summary>
        /// The Md5-Checksum of the file
        /// </summary>
        internal string Md5 => md5;

        //set { md5 = value; }
        /// <summary>
        /// Path to the downloaded file
        /// </summary>
        internal string TempFile
        {
            get => tempFile;
            set => tempFile = value;
        }
    }
}