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

        #endregion

        #region Implementation

        private void OnRecentFile_Click(object sender, EventArgs e)
        {

        }

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
