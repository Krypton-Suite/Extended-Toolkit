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

namespace Krypton.Toolkit.Suite.Extended.Tool.Strip.Items
{
    //[ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ContextMenuStrip | ToolStripItemDesignerAvailability.MenuStrip | )]
    public class MRUMenuItem : ToolStripMenuItem
    {
        #region Variables

        private Control _outputControl;

        private string _applicationName, _defaultText = "Mo&st Recently Used...";

        private MostRecentlyUsedFileManager _recentlyUsedFileManager = null;
        #endregion

        #region Public

        public string DefaultText { get => _defaultText; set { _defaultText = value; Invalidate(); } }

        #endregion

        #region Constructor
        public MRUMenuItem(string defaultText)
        {
            _defaultText = defaultText;

            Text = _defaultText;

            _recentlyUsedFileManager = new MostRecentlyUsedFileManager(this, _applicationName, MyOwnRecentFileGotClicked_Handler, MyOwnRecentFilesGotCleared_Handler);
        }
        #endregion

        #region Implementation

        private void MyOwnRecentFileGotClicked_Handler(object sender, EventArgs e)
        {
            string fileName = (sender as ToolStripItem).Text;

            if (!File.Exists(fileName))
            {
                if (KryptonMessageBox.Show($"{fileName} doesn't exist. Remove from recent workspaces?", "File not found", KryptonMessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _recentlyUsedFileManager.RemoveRecentFile(fileName);
                }
                else
                {
                    return;
                }
            }

            OpenFile(fileName, _outputControl);
        }

        private void MyOwnRecentFilesGotCleared_Handler(object sender, EventArgs e)
        {

        }

        private void OpenFile(string filePath, Control outputControl)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    if (outputControl != null)
                    {
                        StreamReader sr = new StreamReader(filePath);

                        outputControl.Text = sr.ReadToEnd();

                        sr.Close();

                        sr.Dispose();
                    }

                    _recentlyUsedFileManager.AddRecentFile(filePath);
                }
                else
                {
                    KryptonMessageBox.Show($"Error: file '{filePath}' could not be found!");
                }
            }
            catch (IOException e)
            {
                DebugUtilities.NotImplemented(e.ToString());
            }
        }

        #endregion
    }
}