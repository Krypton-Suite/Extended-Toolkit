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