#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Tool.Strip.Items
{
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ContextMenuStrip | ToolStripItemDesignerAvailability.MenuStrip)]
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
                if (KryptonMessageBox.Show($"{fileName} doesn't exist. Remove from recent workspaces?", "File not found", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
                ExceptionCapture.CaptureException(e);
            }
    }

        #endregion
    }
}