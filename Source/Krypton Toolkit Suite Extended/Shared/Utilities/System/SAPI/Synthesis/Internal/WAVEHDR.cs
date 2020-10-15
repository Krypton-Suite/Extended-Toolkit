using System;

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