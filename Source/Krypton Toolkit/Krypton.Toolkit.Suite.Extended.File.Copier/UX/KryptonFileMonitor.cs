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
    public partial class KryptonFileMonitor : KryptonForm, ICopyFileDetails
    {
        #region ICopyFileDetails Implementation
        public ISynchronizeInvoke SynchronizationObject { get; set; }

        public event CopyFiles.DEL_cancelCopy EN_cancelCopy;

        public void Update(int totalFiles, int copiedFiles, long totalBytes, long copiedBytes, string currentFilename)
        {
            pbTotalFiles.Maximum = totalFiles;

            pbTotalFiles.Value = copiedFiles;

            pbCurrentFile.Maximum = 100;

            if (totalFiles != 0)
            {
                pbCurrentFile.Value = Convert.ToInt32(100f / (totalFiles / 1024f) * (copiedBytes / 1024f));
            }

            klblTotalFiles.Text = $"Total Files: ({copiedFiles} / {totalFiles})";

            klblCurrentFile.Text = $"Current File: {currentFilename}";
        }
        #endregion

        #region Constructor
        public KryptonFileMonitor()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods
        private void RaiseCancel()
        {
            if (EN_cancelCopy != null)
            {
                EN_cancelCopy();
            }
        }
        #endregion

        private void KryptonFileMonitor_FormClosed(object sender, FormClosedEventArgs e)
        {
            RaiseCancel();
        }

        private void kbtnCancel_Click(object sender, EventArgs e)
        {
            RaiseCancel();
        }
    }
}