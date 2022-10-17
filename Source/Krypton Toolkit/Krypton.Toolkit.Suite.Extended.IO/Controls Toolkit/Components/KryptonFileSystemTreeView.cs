﻿#region MIT License
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

namespace Krypton.Toolkit.Suite.Extended.IO
{
    [ToolboxBitmap(typeof(KryptonTreeView)), Description("A directory and file browser.")]
    public class KryptonFileSystemTreeView : KryptonTreeView
    {
        #region Variables
        private bool _showFiles = true;

        private DriveInfo[] _drives;

        private ImageList _imageList = new ImageList();

        private Hashtable _systemIcons = new Hashtable();

        private Icon _folderIcon = null;

        private static readonly int Folder = 0;
        #endregion

        #region Property
        public DriveInfo[] Drives { get => _drives; set => _drives = value; }

        public Icon FolderIcon { get => _folderIcon; set => _folderIcon = value; }
        #endregion

        #region Constructor
        public KryptonFileSystemTreeView()
        {
            Drives = DriveInfo.GetDrives();

            ImageList = _imageList;

            MouseDown += KryptonFileSystemTreeView_MouseDown;

            BeforeExpand += KryptonFileSystemTreeView_BeforeExpand;

            try
            {
                string localFolderIcon = "Icons\\Folder.ico";

                //Icon folderIcon = Icon.ExtractAssociatedIcon(@"C:\\Windows"), 

                Icon applicationIcon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

                if (File.Exists(localFolderIcon))
                {
                    FolderIcon = new Icon(localFolderIcon);
                }
                else
                {
                    FolderIcon = applicationIcon;
                }

                //FolderIcon = folderIcon;
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }
        #endregion

        #region Event Handlers
        private void KryptonFileSystemTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node is KryptonTreeNode) return;

            //KryptonDirectoryNode
        }

        private void KryptonFileSystemTreeView_MouseDown(object sender, MouseEventArgs e)
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}