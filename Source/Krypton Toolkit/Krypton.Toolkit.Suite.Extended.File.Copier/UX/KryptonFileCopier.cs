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
    public partial class KryptonFileCopier : KryptonForm
    {
        #region Variables

        private FileDialogType _fileDialogType;

        private string _sourceDirectory, _targetDirectory;
        #endregion

        #region Properties
        public string SourceDirectory { get => _sourceDirectory; set => _sourceDirectory = value; }

        public string TargetDirectory { get => _targetDirectory; set => _targetDirectory = value; }
        #endregion

        #region Constructors
        public KryptonFileCopier()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods
        private void CopyFiles()
        {
            if (kflListing.FileListing.Items.Count > 0)
            {
                List<string> tempFiles = new();

                foreach (string item in kflListing.FileListing.Items)
                {
                    tempFiles.Add(item);
                }

                string? tempPath = null;

                switch (_fileDialogType)
                {
                    case FileDialogType.Krypton:
                        KryptonFolderBrowserDialog kfbd = new();

                        kfbd.Title = @"Select a Destination:";

                        if (kfbd.ShowDialog() == DialogResult.OK)
                        {
                            tempPath = Path.GetFullPath(kfbd.SelectedPath);
                        }
                        break;
                    case FileDialogType.Standard:
                        FolderBrowserDialog fbd = new();

                        fbd.Description = @"Select a Destination:";

                        if (fbd.ShowDialog() == DialogResult.OK)
                        {
                            tempPath = Path.GetFullPath(fbd.SelectedPath);
                        }
                        break;
                    case FileDialogType.WindowsAPICodePack:
                        CommonOpenFileDialog cofd = new();

                        cofd.IsFolderPicker = true;

                        cofd.Title = "Select a destination:";

                        if (cofd.ShowDialog() == CommonFileDialogResult.Ok)
                        {
                            tempPath = Path.GetFullPath(cofd.FileName);
                        }
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                CopyFiles copy = new(tempFiles, tempPath);

                KryptonFileMonitor monitor = new();

                monitor.SynchronizationObject = this;

                copy.CopyAsync(monitor);
            }
        }
        #endregion

        private void kbtnCopyFiles_Click(object sender, EventArgs e)
        {
            if (kchkUseDebugConsole.Checked)
            {
                List<string> files = new();

                foreach (string item in kflListing.FileListing.Items)
                {
                    files.Add(item);
                }

                KryptonDeveloperDebugConsole debugConsole = new(HelperUtilites.ReturnDirectoryListing(files));

                debugConsole.Show();
            }
            else
            {
                CopyFiles();
            }
        }
    }
}