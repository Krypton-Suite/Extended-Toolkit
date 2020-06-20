using System;
using System.Collections.Generic;

namespace Krypton.Toolkit.Extended.IO
{
    public class FileGathererEventArgs : EventArgs
    {
        #region Properties
        public List<string> FileListing { get; set; }

        public Stack<string> FileStack { get; set; }
        #endregion

        #region Constructor
        public FileGathererEventArgs(List<string> fileListing)
        {
            FileListing = fileListing;
        }

        public FileGathererEventArgs(Stack<string> fileStack)
        {
            FileStack = fileStack;
        }
        #endregion

        #region Methods
        public void AddToFileListStack(string item) => FileListing.Add(item);

        public void AppendFileStack(string item) => FileStack.Push(item);

        public List<string> GetFileListing() => FileListing;

        public Stack<string> GetFileStack() => FileStack;
        #endregion
    }
}