#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
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
    /// <summary>
    /// Deals with the back-end logic of a most recently used file <see cref="MRUMenuItem"/>.
    /// Adapted from (https://www.codeproject.com/Articles/407513/Add-Most-Recently-Used-Files-MRU-List-to-Windows).
    /// </summary>
    internal class MostRecentlyUsedFileManager
    {
        #region Instance Fields

        private bool _useConfirmClearListDialogue;

        private string _applicationName, _subKeyName, _filePath;

        private MRUMenuItem _parentMenuItem;

        private ToolStripMenuItemUACSheld _clearListItem;

        private UtilityMethods _utilityMethods = new();

        private GlobalMethods _globalMethods = new();

        #endregion

        #region Events

        private Action<object, EventArgs> OnRecentFileClick;

        private Action<object, EventArgs> OnClearRecentFilesClick;

        #endregion

        #region Public

        public bool UseConfirmClearListDialogue { get => _useConfirmClearListDialogue; set => _useConfirmClearListDialogue = value; }

        public string ApplicationName { get => _applicationName; set => _applicationName = value; }

        public string FilePath { get => _filePath; set => _filePath = value; }

        #endregion

        #region Identity

        /// <summary>Initializes a new instance of the <see cref="MostRecentlyUsedFileManager" /> class.</summary>
        /// <param name="parentMenuItem">The parent menu item.</param>
        /// <param name="applicationName">Name of the application.</param>
        /// <param name="onRecentFileClick">The on recent file click.</param>
        /// <param name="onClearRecentFilesClick">The on clear recent files click.</param>
        /// <param name="useConfirmClearListDialogue">if set to <c>true</c> [use confirm clear list dialogue].</param>
        /// <exception cref="System.ArgumentException">Bad argument.</exception>
        public MostRecentlyUsedFileManager(MRUMenuItem parentMenuItem, string applicationName, Action<object, EventArgs> onRecentFileClick, Action<object, EventArgs>? onClearRecentFilesClick = null, bool useConfirmClearListDialogue = false)
        {
            if (parentMenuItem == null || onRecentFileClick == null || applicationName == null || applicationName.Length == 0 || applicationName.Contains("\\"))
            {
                throw new ArgumentException("Bad argument.");
            }

            _parentMenuItem = parentMenuItem;

            _applicationName = applicationName;

            OnRecentFileClick = onRecentFileClick;

            OnClearRecentFilesClick = onClearRecentFilesClick;

            _subKeyName = $"Software\\{applicationName}\\MRU";

            UseConfirmClearListDialogue = useConfirmClearListDialogue;

            RefreshRecentFilesMenu();
        }

        #endregion

        #region Implementation

        /// <summary>
        /// Called when [clear recent files click].
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="evt">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnClearRecentFiles_Click(object obj, EventArgs evt)
        {
            try
            {
                if (UseConfirmClearListDialogue)
                {
                    if (_globalMethods.CheckIfTargetPlatformIsSupported(UseConfirmClearListDialogue))
                    {
                        if (_globalMethods.GetIsTargetPlatformSupported())
                        {
                            if (KryptonMessageBox.Show("You are about to clear your recent files list. Do you want to continue?", "Clear Recent Files", KryptonMessageBoxButtons.YesNo, KryptonMessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                ClearRecentFiles();
                            }
                            else if (KryptonMessageBox.Show("You are about to clear your recent files list. Do you want to continue?", "Clear Recent Files", KryptonMessageBoxButtons.YesNo, KryptonMessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                ClearRecentFiles();
                            }
                        }
                    }
                }
                else
                {
                    ClearRecentFiles();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            if (OnClearRecentFilesClick != null)
            {
                OnClearRecentFilesClick(obj, evt);
            }
        }

        /// <summary>
        /// Clears the recent files.
        /// </summary>
        private void ClearRecentFiles()
        {
            try
            {
                RegistryKey rK = Registry.CurrentUser.OpenSubKey(_subKeyName, true);

                if (rK == null)
                {
                    return;
                }

                string[] values = rK.GetValueNames();

                foreach (string valueName in values)
                {
                    rK.DeleteValue(valueName, true);
                }

                rK.Close();

                _parentMenuItem.DropDownItems.Clear();

                _parentMenuItem.Enabled = false;
            }
            catch (Exception ex)
            {
                ExceptionCapture.CaptureException(ex);
            }
        }

        /// <summary>
        /// Refreshes the recent files menu.
        /// </summary>
        private void RefreshRecentFilesMenu()
        {
            RegistryKey rK;

            string s;

            ToolStripItem tSI;

            try
            {
                rK = Registry.CurrentUser.OpenSubKey(_subKeyName, false);

                if (rK == null)
                {
                    _parentMenuItem.Enabled = false;

                    return;
                }
            }
            catch (Exception ex)
            {
                //ExceptionCapture.CaptureException($"Cannot open recent files registry key:\n{ex.Message}");

                ExceptionCapture.CaptureException(ex);

                return;
            }

            _parentMenuItem.DropDownItems.Clear();

            string[] valueNames = rK.GetValueNames();

            foreach (string valueName in valueNames)
            {
                s = rK.GetValue(valueName, null) as string;

                if (s == null)
                {
                    continue;
                }

                tSI = _parentMenuItem.DropDownItems.Add(s);

                tSI.Click += new EventHandler(OnRecentFileClick);
            }

            if (_parentMenuItem.DropDownItems.Count == 0)
            {
                _parentMenuItem.Enabled = false;

                return;
            }

            _parentMenuItem.DropDownItems.Add("-");

            tSI = _parentMenuItem.DropDownItems.Add("&Clear list");

            tSI.Click += OnClearRecentFiles_Click;

            _parentMenuItem.Enabled = true;
        }
        #endregion

        #region Public members
        /// <summary>
        /// Adds the recent file.
        /// </summary>
        /// <param name="fileNameWithFullPath">The file name with full path.</param>
        public void AddRecentFile(string fileNameWithFullPath)
        {
            string s;

            try
            {
                RegistryKey rK = Registry.CurrentUser.CreateSubKey(_subKeyName, RegistryKeyPermissionCheck.ReadWriteSubTree);

                for (int i = 0; true; i++)
                {
                    s = rK.GetValue(i.ToString(), null) as string;

                    if (s == null)
                    {
                        rK.SetValue(i.ToString(), fileNameWithFullPath);

                        rK.Close();

                        break;
                    }
                    else if (s == fileNameWithFullPath)
                    {
                        rK.Close();

                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionCapture.CaptureException(ex);
            }

            RefreshRecentFilesMenu();
        }


        /// <summary>
        /// Removes the recent file.
        /// </summary>
        /// <param name="fileNameWithFullPath">The file name with full path.</param>
        public void RemoveRecentFile(string fileNameWithFullPath)
        {
            try
            {
                RegistryKey rK = Registry.CurrentUser.OpenSubKey(_subKeyName, true);

                string[] valuesNames = rK.GetValueNames();

                foreach (string valueName in valuesNames)
                {
                    if ((rK.GetValue(valueName, null) as string) == fileNameWithFullPath)
                    {
                        rK.DeleteValue(valueName, true);

                        RefreshRecentFilesMenu();

                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            RefreshRecentFilesMenu();
        }

        #endregion
    }
}
