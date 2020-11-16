﻿#region BSD License
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
    public struct tagRFC1766INFO
    {
        public uint lcid;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public ushort[] wszRfc1766;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x20)]
        public ushort[] wszLocaleName;
    }
}