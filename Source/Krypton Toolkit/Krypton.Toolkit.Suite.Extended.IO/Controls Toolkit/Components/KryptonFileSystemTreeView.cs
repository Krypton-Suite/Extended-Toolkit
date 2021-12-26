#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
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