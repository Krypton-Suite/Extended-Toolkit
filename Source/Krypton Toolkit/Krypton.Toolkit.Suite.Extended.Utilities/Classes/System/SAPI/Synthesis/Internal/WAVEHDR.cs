#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Synthesis
{
    internal struct WAVEHDR
    {
        internal IntPtr lpData;

        internal uint dwBufferLength;

        internal uint dwBytesRecorded;

        internal uint dwUser;

        internal uint dwFlags;

        internal uint dwLoops;

        internal IntPtr lpNext;

        internal uint reserved;
    }
}