#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.File.Copier
{
    public class DirectoryPathChangedEventArgs : EventArgs
    {
        #region Properties
        /// <summary>Gets or sets the directory path.</summary>
        /// <value>The directory path.</value>
        public string DirectoryPath { get; set; }
        #endregion

        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="DirectoryPathChangedEventArgs" /> class.</summary>
        /// <param name="directoryPath">The directory path.</param>
        public DirectoryPathChangedEventArgs(string directoryPath)
        {
            DirectoryPath = directoryPath;
        }
        #endregion

        #region Methods
        /// <summary>Gets the directory path.</summary>
        /// <returns>The full path of the selected directory.</returns>
        public string GetDirectoryPath() => Path.GetFullPath(DirectoryPath);
        #endregion
    }
}