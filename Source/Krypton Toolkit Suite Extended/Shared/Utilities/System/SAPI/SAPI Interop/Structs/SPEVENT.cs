using System;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    internal struct SPEVENT
    {
        public SPEVENTENUM eEventId;

        public SPEVENTLPARAMTYPE elParamType;

        public uint ulStreamNum;

        public ulong ullAudioStreamOffset;

        public IntPtr wParam;

        public IntPtr lParam;
    }
}