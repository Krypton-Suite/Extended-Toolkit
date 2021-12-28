#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

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