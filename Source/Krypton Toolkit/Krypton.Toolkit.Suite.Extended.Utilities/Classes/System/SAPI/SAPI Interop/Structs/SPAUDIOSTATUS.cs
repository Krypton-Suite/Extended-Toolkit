#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    internal struct SPAUDIOSTATUS
    {
        internal int cbFreeBuffSpace;

        internal uint cbNonBlockingIO;

        internal SPAUDIOSTATE State;

        internal ulong CurSeekPos;

        internal ulong CurDevicePos;

        internal uint dwAudioLevel;

        internal uint dwReserved2;
    }
}