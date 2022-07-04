#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Developer.Utilities;

using Microsoft.Win32;

namespace Krypton.Toolkit.Suite.Extended.IO
{
    public class MostRecentlyUsedFileManager
    {
        #region Instance Fields

        private ToolStripMenuItem _parentMenuItem;

        private string _applicationName;

        private string _clearListText;

        private string _subKeyName;

        #endregion

        #region Events

        private Action<object, EventArgs> OnRecentFileClick;

        private Action<object, EventArgs> OnClearRecentFilesClick;

        #endregion

        #region Identity

        static MostRecentlyUsedFileManager() {}

        public MostRecentlyUsedFileManager()
        {
            
        }

        /// <summary>Initializes a new instance of the <see cref="MostRecentlyUsedFileManager" /> class.</summary>
        /// <param name="parentMenuItem">The parent menu item.</param>
        /// <param name="applicationName">Name of the application.</param>
        /// <param name="onRecentFileClick">The on recent file click.</param>
        /// <param name="onClearRecentFilesClick">The on clear recent files click.</param>
        /// <exception cref="System.ArgumentException">Bad argument.</exception>
        public MostRecentlyUsedFileManager(ToolStripMenuItem parentMenuItem, string applicationName, Action<object, EventArgs> onRecentFileClick, Action<object, EventArgs> onClearRecentFilesClick = null)
        {
            if (parentMenuItem == null || onRecentFileClick == null || applicationName == null || applicationName.Length == 0 || applicationName.Contains("\\"))
            {
                throw new ArgumentException("Bad argument.");
            }

            _parentMenuItem = parentMenuItem;

            _applicationName = applicationName;

            OnClearRecentFilesClick = onClearRecentFilesClick;

            OnRecentFileClick = onRecentFileClick;

            _subKeyName = $"Software\\{applicationName}\\MostRecentlyUsed";

            RefreshRecentFilesMenu();
        }

        #endregion

        #region Implementation

        private void OnClearRecentFiles_Click(object sender, EventArgs e)
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(_subKeyName, true);

                if (key == null)
                {
                    return;
                }

                string[] keyValues = key.GetValueNames();

                foreach (string keyValue in keyValues)
                {
                    key.DeleteValue(keyValue);
                }

                key.Close();

                _parentMenuItem.DropDownItems.Clear();

                _parentMenuItem.Enabled = false;
            }
            catch (Exception exc)
            {
                ExceptionCapture.CaptureException(exc);
            }

            if (OnClearRecentFilesClick != null)
            {
                OnClearRecentFilesClick(sender, e);
            }
        }

        private void RefreshRecentFilesMenu()
        {
            RegistryKey key;

            string value;

            ToolStripItem item;

            try
            {
                key = Registry.CurrentUser.OpenSubKey(_subKeyName, false);

                if (key == null)
                {
                    _parentMenuItem.Enabled = false;

                    return;
                }
            }
            catch (Exception e)
            {
                ExceptionCapture.CaptureException(e);

                return;
            }

            _parentMenuItem.DropDownItems.Clear();

            string[] valueNames = key.GetValueNames();

            foreach (string valueName in valueNames)
            {
                value = key.GetValue(valueName, null) as string;

                if (value == null)
                {
                    continue;
                }

                item = _parentMenuItem.DropDownItems.Add(value);

                item.Click += new EventHandler(OnRecentFileClick);
            }

            if (_parentMenuItem.DropDownItems.Count == 0)
            {
                _parentMenuItem.Enabled = false;

                return;
            }

            _parentMenuItem.DropDownItems.Add("-");

            item = _parentMenuItem.DropDownItems.Add(_clearListText);

            item.Click += OnClearRecentFiles_Click;

            _parentMenuItem.Enabled = true;
        }

        /// <summary>Adds the recent file to the MRU list.</summary>
        /// <param name="fileNameWithFullPath">The file name with full path.</param>
        public static void AddRecentFile(string fileNameWithFullPath)
        {
            MostRecentlyUsedFileManager manager = new MostRecentlyUsedFileManager();

            string value;

            try
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(manager._subKeyName, RegistryKeyPermissionCheck.ReadWriteSubTree);

                for (int i = 0; true; i++)
                {
                    value = key.GetValue(i.ToString(), null) as string;

                    if (value == null)
                    {
                        key.SetValue(i.ToString(), fileNameWithFullPath);

                        key.Close();

                        break;
                    }
                    else if (value == fileNameWithFullPath)
                    {
                        key.Close();

                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionCapture.CaptureException(e);
            }

            manager.RefreshRecentFilesMenu();
        }

        /// <summary>Removes the recent file from the MRU list.</summary>
        /// <param name="fileNameWithFullPath">The file name with full path.</param>
        public static void RemoveRecentFile(string fileNameWithFullPath)
        {
            MostRecentlyUsedFileManager manager = new MostRecentlyUsedFileManager();

            try
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(manager._subKeyName, true);

                string[] valueNames = key.GetValueNames();

                foreach (string valueName in valueNames)
                {
                    if ((key.GetValue(valueName, null) as string) == fileNameWithFullPath)
                    {
                        key.DeleteValue(valueName);

                        manager.RefreshRecentFilesMenu();

                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionCapture.CaptureException(e);
            }

            manager.RefreshRecentFilesMenu();
        }

        #endregion
    }
}