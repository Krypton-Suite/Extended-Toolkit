#region MIT License
/*
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