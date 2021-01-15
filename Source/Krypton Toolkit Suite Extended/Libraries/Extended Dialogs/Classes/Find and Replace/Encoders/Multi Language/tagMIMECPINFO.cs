#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.Runtime.InteropServices;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct tagMIMECPINFO
    {
        public uint dwFlags;
        public uint uiCodePage;
        public uint uiFamilyCodePage;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x40)]
        public ushort[] wszDescription;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
        public ushort[] wszWebCharset;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
        public ushort[] wszHeaderCharset;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
        public ushort[] wszBodyCharset;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x20)]
        public ushort[] wszFixedWidthFont;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x20)]
        public ushort[] wszProportionalFont;
        public byte bGDICharset;
    }
}