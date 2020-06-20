using System;
using System.IO;

namespace Krypton.Toolkit.Extended.IO
{
    public class DirectoryPathChangedEventArgs : EventArgs
    {
        #region Properties
        public string DirectoryPath { get; set; }
        #endregion

        #region Constructor
        public DirectoryPathChangedEventArgs(string directoryPath)
        {
            DirectoryPath = directoryPath;
        }
        #endregion

        #region Methods
        public string GetDirectoryPath() => Path.GetFullPath(DirectoryPath);
        #endregion
    }
}