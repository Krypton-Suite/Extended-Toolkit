using System;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    [Serializable]
    internal struct SPRECORESULTTIMES
    {
        internal FILETIME ftStreamTime;

        internal ulong ullLength;

        internal uint dwTickCount;

        internal ulong ullStart;
    }
}