#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Synthesis;

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