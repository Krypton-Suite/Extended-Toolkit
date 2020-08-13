using Krypton.Toolkit.Suite.Extended.Drawing.Suite;
using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.IO
{
    [ToolboxItem(false)]
    public class KryptonDriveComboBox : KryptonImageComboBox
    {
        #region Properties
        public string SelectedDrive
        {
            get
            {
                if (base.SelectedIndex != 1)
                {
                    return (base.SelectedItem as ImageComboItem).ItemValue;
                }
                else
                {
                    return null;
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public new ComboBox.ObjectCollection Items => Items;
        #endregion

        #region Constructor
        public KryptonDriveComboBox() : base()
        {
            ImageList.ColorDepth = ColorDepth.Depth32Bit;

            DrawMode = DrawMode.OwnerDrawFixed;

            DropDownStyle = ComboBoxStyle.DropDownList;

            BuildDriveList();
        }
        #endregion

        #region Methods
        public void BuildDriveList()
        {
            base.Items.Clear();

            ShellAPI.SHFILEINFO shFInfo = new ShellAPI.SHFILEINFO();

            ShellAPI.SHGFI dwAttribs = ShellAPI.SHGFI.SHGFI_ICON | ShellAPI.SHGFI.SHGFI_SMALLICON | ShellAPI.SHGFI.SHGFI_SYSICONINDEX | ShellAPI.SHGFI.SHGFI_DISPLAYNAME;

            ListDictionary _iconDict = new ListDictionary();

            foreach (string drive in Directory.GetLogicalDrives())
            {
                IntPtr m_pHandle = ShellAPI.SHGetFileInfo(drive, ShellAPI.FILE_ATTRIBUTE_NORMAL, ref shFInfo, (uint)Marshal.SizeOf(shFInfo), dwAttribs);

                if (m_pHandle.Equals(IntPtr.Zero) == false)
                {
                    int idxIcon = 0;

                    if (_iconDict.Contains(shFInfo.iIcon) == false)
                    {
                        base.ImageList.Images.Add(Icon.FromHandle(shFInfo.hIcon).Clone() as Icon);

                        User32API.DestroyIcon(shFInfo.hIcon);

                        _iconDict.Add(shFInfo.iIcon, _iconDict.Count);

                        idxIcon = _iconDict.Count - 1;
                    }
                    else
                    {
                        idxIcon = Convert.ToInt32(_iconDict[shFInfo.iIcon]);
                    }

                    ImageComboItem item = new ImageComboItem(shFInfo.szDisplayName, idxIcon, false);

                    item.ItemValue = drive;

                    base.Items.Add(item);
                }
            }

            if (base.Items.Count != 0)
            {
                base.SelectedIndex = 0;
            }
        }
        #endregion
    }
}