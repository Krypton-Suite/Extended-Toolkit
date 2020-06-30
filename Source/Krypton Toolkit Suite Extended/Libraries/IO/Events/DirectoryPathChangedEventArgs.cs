using System;
using System.IO;

namespace Krypton.Toolkit.Suite.Extended.IO
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