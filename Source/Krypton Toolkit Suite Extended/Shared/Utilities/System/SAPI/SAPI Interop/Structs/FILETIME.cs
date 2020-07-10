using System;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    [Serializable]
    internal struct FILETIME
    {
        internal uint dwLowDateTime;

        internal uint dwHighDateTime;
    }
}