#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    internal struct SPRECOCONTEXTSTATUS
    {
        internal SPINTERFERENCE eInterference;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 255)]
        internal short[] szRequestTypeOfUI;

        internal uint dwReserved1;

        internal uint dwReserved2;
    }
}