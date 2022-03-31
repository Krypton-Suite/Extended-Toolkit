#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Synthesis
{
    [TypeLibType(16)]
    internal struct WAVEFORMATEX
    {
        internal short wFormatTag;

        internal short nChannels;

        internal int nSamplesPerSec;

        internal int nAvgBytesPerSec;

        internal short nBlockAlign;

        internal short wBitsPerSample;

        internal short cbSize;

        internal static WAVEFORMATEX Default
        {
            get
            {
                WAVEFORMATEX result = default(WAVEFORMATEX);
                result.wFormatTag = 1;
                result.nChannels = 1;
                result.nSamplesPerSec = 22050;
                result.nAvgBytesPerSec = 44100;
                result.nBlockAlign = 2;
                result.wBitsPerSample = 16;
                result.cbSize = 0;
                return result;
            }
        }

        internal int Length => 18 + cbSize;

        internal static WAVEFORMATEX ToWaveHeader(byte[] waveHeader)
        {
            GCHandle gCHandle = GCHandle.Alloc(waveHeader, GCHandleType.Pinned);
            IntPtr ptr = gCHandle.AddrOfPinnedObject();
            WAVEFORMATEX result = default(WAVEFORMATEX);
            result.wFormatTag = Marshal.ReadInt16(ptr);
            result.nChannels = Marshal.ReadInt16(ptr, 2);
            result.nSamplesPerSec = Marshal.ReadInt32(ptr, 4);
            result.nAvgBytesPerSec = Marshal.ReadInt32(ptr, 8);
            result.nBlockAlign = Marshal.ReadInt16(ptr, 12);
            result.wBitsPerSample = Marshal.ReadInt16(ptr, 14);
            result.cbSize = Marshal.ReadInt16(ptr, 16);
            if (result.cbSize != 0)
            {
                throw new InvalidOperationException();
            }
            gCHandle.Free();
            return result;
        }

        internal static void AvgBytesPerSec(byte[] waveHeader, out int avgBytesPerSec, out int nBlockAlign)
        {
            GCHandle gCHandle = GCHandle.Alloc(waveHeader, GCHandleType.Pinned);
            IntPtr ptr = gCHandle.AddrOfPinnedObject();
            avgBytesPerSec = Marshal.ReadInt32(ptr, 8);
            nBlockAlign = Marshal.ReadInt16(ptr, 12);
            gCHandle.Free();
        }

        internal byte[] ToBytes()
        {
            GCHandle gCHandle = GCHandle.Alloc(this, GCHandleType.Pinned);
            byte[] result = ToBytes(gCHandle.AddrOfPinnedObject());
            gCHandle.Free();
            return result;
        }

        internal static byte[] ToBytes(IntPtr waveHeader)
        {
            int num = Marshal.ReadInt16(waveHeader, 16);
            byte[] array = new byte[18 + num];
            Marshal.Copy(waveHeader, array, 0, 18 + num);
            return array;
        }
    }
}