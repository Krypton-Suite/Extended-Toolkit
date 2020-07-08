using System;
using System.Runtime.InteropServices;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    [StructLayout(LayoutKind.Sequential)]
    internal class SPWAVEFORMATEX
    {
        public uint cbUsed;

        public Guid Guid;

        public ushort wFormatTag;

        public ushort nChannels;

        public uint nSamplesPerSec;

        public uint nAvgBytesPerSec;

        public ushort nBlockAlign;

        public ushort wBitsPerSample;

        public ushort cbSize;
    }
}