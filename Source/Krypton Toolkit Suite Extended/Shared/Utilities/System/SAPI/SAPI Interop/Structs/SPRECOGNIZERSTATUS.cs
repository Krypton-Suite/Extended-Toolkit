using System;
using System.Runtime.InteropServices;

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