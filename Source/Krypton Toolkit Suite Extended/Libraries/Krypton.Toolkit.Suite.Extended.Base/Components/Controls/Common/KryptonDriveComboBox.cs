#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    public class KryptonDriveComboBox : KryptonImageCombo
    {
        #region Properties
        /// <summary>Gets the selected drive.</summary>
        /// <value>The selected drive.</value>
        [Description("Gets the selected drive.")]
        public string SelectedDrive
        {
            get
            {
                if (base.SelectedIndex != -1)
                    return (base.SelectedItem as ImageComboItem).ItemValue;
                else
                    return null;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new ComboBox.ObjectCollection Items => base.Items;
        #endregion

        #region Constructors
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

            ShellAPI.SHFILEINFO shInfo = new ShellAPI.SHFILEINFO();

            ShellAPI.SHGFI dwAttribs = ShellAPI.SHGFI.SHGFI_ICON | ShellAPI.SHGFI.SHGFI_SMALLICON | ShellAPI.SHGFI.SHGFI_SYSICONINDEX | ShellAPI.SHGFI.SHGFI_DISPLAYNAME;

            ListDictionary iconDictionary = new ListDictionary();

            foreach (string drive in Directory.GetLogicalDrives())
            {
                IntPtr m_pHandle = ShellAPI.SHGetFileInfo(drive, ShellAPI.FILE_ATTRIBUTE_NORMAL, ref shInfo, (uint)Marshal.SizeOf(shInfo), dwAttribs);

                if (m_pHandle.Equals(IntPtr.Zero) == false)
                {
                    int idxIcon = 0;

                    if (iconDictionary.Contains(shInfo.iIcon) == false)
                    {
                        ImageList.Images.Add(Icon.FromHandle(shInfo.hIcon).Clone() as Icon);

                        User32API.DestroyIcon(shInfo.hIcon);

                        iconDictionary.Add(shInfo.iIcon, iconDictionary.Count);

                        idxIcon = iconDictionary.Count - 1;
                    }
                    else
                    {
                        idxIcon = Convert.ToInt32(iconDictionary[shInfo.iIcon]);
                    }

                    ImageComboItem item = new ImageComboItem(shInfo.szDisplayName, idxIcon, false);

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