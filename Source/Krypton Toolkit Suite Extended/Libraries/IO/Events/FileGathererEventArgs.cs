using System;
using System.Collections.Generic;

namespace Krypton.Toolkit.Extended.IO
{
    public class FileGathererEventArgs : EventArgs
    {
        #region Properties
        public List<string> FileListing { get; set; }
        #endregion

        #region Constructor
        public FileGathererEventArgs(List<string> fileListing)
        {
            FileListing = fileListing;
        }
        #endregion

        #region Methods
        public void AddToFileListStack(string item) => FileListing.Add(item);

        public List<string> GetFileListing() => FileListing;
        #endregion
    }
}