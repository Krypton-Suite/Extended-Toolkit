#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.File.Copier
{
    public class FileGathererEventArgs : EventArgs
    {
        #region Properties
        public List<string> FileListing { get; set; }

        public Stack<string> FileStack { get; set; }

        public ProgressBar ProgressBar { get; set; }

        public int ProgressBarMaximum { get; set; }
        #endregion

        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="FileGathererEventArgs" /> class.</summary>
        /// <param name="fileListing">The file listing.</param>
        public FileGathererEventArgs(List<string> fileListing)
        {
            FileListing = fileListing;
        }

        /// <summary>Initializes a new instance of the <see cref="FileGathererEventArgs" /> class.</summary>
        /// <param name="fileListing">The file listing.</param>
        /// <param name="progressBar">The progress bar.</param>
        /// <param name="progressBarMaximum">The progress bar maximum.</param>
        public FileGathererEventArgs(List<string> fileListing, ProgressBar progressBar, int progressBarMaximum)
        {
            FileListing = fileListing;

            ProgressBar = progressBar;

            ProgressBarMaximum = progressBarMaximum;
        }


        /// <summary>Initializes a new instance of the <see cref="FileGathererEventArgs" /> class.</summary>
        /// <param name="fileStack">The file stack.</param>
        public FileGathererEventArgs(Stack<string> fileStack)
        {
            FileStack = fileStack;
        }
        #endregion

        #region Methods
        /// <summary>Adds to file list stack.</summary>
        /// <param name="item">The item.</param>
        public void AddToFileListStack(string item) => FileListing.Add(item);

        /// <summary>Appends the file stack.</summary>
        /// <param name="item">The item.</param>
        public void AppendFileStack(string item) => FileStack.Push(item);

        /// <summary>Gets the file listing.</summary>
        /// <returns>The list of contents.</returns>
        public List<string> GetFileListing() => FileListing;

        /// <summary>Gets the file stack.</summary>
        /// <returns>The file stack.</returns>
        public Stack<string> GetFileStack() => FileStack;

        /// <summary>Updates the progressbar value.</summary>
        /// <param name="progressBar">The progress bar.</param>
        /// <param name="currentValue">The current value.</param>
        public void UpdateProgressbarValue(ProgressBar progressBar, int currentValue)
        {
            progressBar.Maximum = ProgressBarMaximum;

            progressBar.Minimum = 0;

            progressBar.Value = currentValue;
        }
        #endregion
    }
}