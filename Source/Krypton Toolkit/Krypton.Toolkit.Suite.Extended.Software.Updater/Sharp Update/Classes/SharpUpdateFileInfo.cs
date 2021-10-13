#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
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
        internal string Url
        {
            get { return url; }
            //set { url = value; }
        }

        /// <summary>
        /// The filename
        /// </summary>
        internal string FileName
        {
            get { return fileName; }
            //set { fileName = value; }
        }

        /// <summary>
        /// The Md5-Checksum of the file
        /// </summary>
        internal string Md5
        {
            get { return md5; }
            //set { md5 = value; }
        }

        /// <summary>
        /// Path to the downloaded file
        /// </summary>
        internal string TempFile
        {
            get { return tempFile; }
            set { tempFile = value; }
        }
    }
}