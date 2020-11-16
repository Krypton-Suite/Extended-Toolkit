#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */

// Original license

/**
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
* KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
* IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
* PURPOSE.
*
* License: GNU Lesser General Public License (LGPLv3)
*
* Email: pavel_torgashov@ukr.net.
*
* Copyright (C) Pavel Torgashov, 2011-2016.
*/
#endregion

using System;
using System.Runtime.InteropServices;

namespace Krypton.Toolkit.Suite.Extended.Fast.Coloured.Text.Box
{
    public static class PlatformType
    {
        const ushort PROCESSOR_ARCHITECTURE_INTEL = 0;
        const ushort PROCESSOR_ARCHITECTURE_IA64 = 6;
        const ushort PROCESSOR_ARCHITECTURE_AMD64 = 9;
        const ushort PROCESSOR_ARCHITECTURE_UNKNOWN = 0xFFFF;

        [StructLayout(LayoutKind.Sequential)]
        struct SYSTEM_INFO
        {
            public ushort wProcessorArchitecture;
            public ushort wReserved;
            public uint dwPageSize;
            public IntPtr lpMinimumApplicationAddress;
            public IntPtr lpMaximumApplicationAddress;
            public UIntPtr dwActiveProcessorMask;
            public uint dwNumberOfProcessors;
            public uint dwProcessorType;
            public uint dwAllocationGranularity;
            public ushort wProcessorLevel;
            public ushort wProcessorRevision;
        };

        [DllImport("kernel32.dll")]
        static extern void GetNativeSystemInfo(ref SYSTEM_INFO lpSystemInfo);

        [DllImport("kernel32.dll")]
        static extern void GetSystemInfo(ref SYSTEM_INFO lpSystemInfo);

        public static Platform GetOperationSystemPlatform()
        {
            var sysInfo = new SYSTEM_INFO();

            // WinXP and older - use GetNativeSystemInfo
            if (Environment.OSVersion.Version.Major > 5 ||
                (Environment.OSVersion.Version.Major == 5 && Environment.OSVersion.Version.Minor >= 1))
            {
                GetNativeSystemInfo(ref sysInfo);
            }
            // else use GetSystemInfo
            else
            {
                GetSystemInfo(ref sysInfo);
            }

            switch (sysInfo.wProcessorArchitecture)
            {
                case PROCESSOR_ARCHITECTURE_IA64:
                case PROCESSOR_ARCHITECTURE_AMD64:
                    return Platform.X64;

                case PROCESSOR_ARCHITECTURE_INTEL:
                    return Platform.X86;

                default:
                    return Platform.Unknown;
            }
        }
    }
}