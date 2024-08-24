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

using DebugUtilities = Krypton.Toolkit.Suite.Extended.Debug.Tools.DebugUtilities;

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

        static MostRecentlyUsedFileManager() { }

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
                DebugUtilities.NotImplemented(exc.ToString());
            }

            if (OnClearRecentFilesClick != null)
            {
                OnClearRecentFilesClick(sender, e);
            }
        }

        private void RefreshRecentFilesMenu()
        {
            RegistryKey key;

            string? value;

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
                DebugUtilities.NotImplemented(e.ToString());

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
        public static void StaticAddRecentFile(string fileNameWithFullPath)
        {
            MostRecentlyUsedFileManager manager = new MostRecentlyUsedFileManager();

            string value;

            try
            {
                RegistryKey? key = Registry.CurrentUser.CreateSubKey(manager._subKeyName, RegistryKeyPermissionCheck.ReadWriteSubTree);

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
                DebugUtilities.NotImplemented(e.ToString());
            }

            manager.RefreshRecentFilesMenu();
        }

        public void AddRecentFile(string fileNameWithFullPath)
        {
            string value = null;

            try
            {
                // Create or append a registry key
                RegistryKey key =
                    Registry.CurrentUser.CreateSubKey(_subKeyName, RegistryKeyPermissionCheck.ReadWriteSubTree);

                for (int i = 0; true; i++)
                {
                    // Grab the current key value
                    value = key.GetValue(i.ToString(), null) as string;

                    if (value == null)
                    {
                        // Set the key value
                        key.SetValue(i.ToString(), fileNameWithFullPath);

                        key.Close();
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
                DebugUtilities.NotImplemented(e.ToString());
            }

            RefreshRecentFilesMenu();
        }

        /// <summary>Removes the recent file from the MRU list.</summary>
        /// <param name="fileNameWithFullPath">The file name with full path.</param>
        public static void StaticRemoveRecentFile(string fileNameWithFullPath)
        {
            MostRecentlyUsedFileManager manager = new MostRecentlyUsedFileManager();

            try
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(manager._subKeyName, true);

                string[] valueNames = key.GetValueNames();

                foreach (string valueName in valueNames)
                {
                    if (key.GetValue(valueName, null) as string == fileNameWithFullPath)
                    {
                        key.DeleteValue(valueName);

                        manager.RefreshRecentFilesMenu();

                        break;
                    }
                }
            }
            catch (Exception e)
            {
                DebugUtilities.NotImplemented(e.ToString());
            }

            manager.RefreshRecentFilesMenu();
        }

        public void RemoveRecentFile(string fileNameWithFullPath)
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(_subKeyName, true);

                string[] keyValues = key.GetValueNames();

                foreach (string keyValue in keyValues)
                {
                    if (key.GetValue(keyValue, null) as string == fileNameWithFullPath)
                    {
                        key.DeleteValue(keyValue);

                        RefreshRecentFilesMenu();

                        break;
                    }
                }
            }
            catch (Exception e)
            {
                DebugUtilities.NotImplemented(e.ToString());
            }

            RefreshRecentFilesMenu();
        }

        #endregion
    }
}