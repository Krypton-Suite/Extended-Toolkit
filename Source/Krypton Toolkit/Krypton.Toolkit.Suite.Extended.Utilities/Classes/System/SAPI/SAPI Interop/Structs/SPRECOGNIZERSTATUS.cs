#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    internal struct SPRECOGNIZERSTATUS
    {
        internal SPAUDIOSTATUS AudioStatus;

        internal ulong ullRecognitionStreamPos;

        internal uint ulStreamNumber;

        internal uint ulNumActive;

        internal Guid clsidEngine;

        internal uint cLangIDs;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        internal short[] aLangID;

        internal ulong ullRecognitionStreamTime;
    }
}