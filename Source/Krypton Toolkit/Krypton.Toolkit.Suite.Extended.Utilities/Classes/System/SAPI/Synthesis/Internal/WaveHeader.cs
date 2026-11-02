#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
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

internal sealed class WaveHeader : IDisposable
{
    internal const int WHDR_DONE = 1;

    internal const int WHDR_PREPARED = 2;

    internal const int WHDR_BEGINLOOP = 4;

    internal const int WHDR_ENDLOOP = 8;

    internal const int WHDR_INQUEUE = 16;

    internal const int WAVE_FORMAT_PCM = 1;

    private GCHandle _gcHandle;

    private GCHandle _gcHandleWaveHdr;

    private WAVEHDR _waveHdr;

    internal int _dwBufferLength;

    internal GCHandle WAVEHDR
    {
        get
        {
            if (!_gcHandleWaveHdr.IsAllocated)
            {
                _waveHdr.lpData = _gcHandle.AddrOfPinnedObject();
                _waveHdr.dwBufferLength = (uint)_dwBufferLength;
                _waveHdr.dwBytesRecorded = 0u;
                _waveHdr.dwUser = 0u;
                _waveHdr.dwFlags = 0u;
                _waveHdr.dwLoops = 0u;
                _waveHdr.lpNext = IntPtr.Zero;
                _gcHandleWaveHdr = GCHandle.Alloc(_waveHdr, GCHandleType.Pinned);
            }
            return _gcHandleWaveHdr;
        }
    }

    internal int SizeHDR => Marshal.SizeOf((object)_waveHdr);

    internal WaveHeader(byte[] buffer)
    {
        _dwBufferLength = buffer.Length;
        _gcHandle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
    }

    ~WaveHeader()
    {
        Dispose(false);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (disposing)
        {
            ReleaseData();
            if (_gcHandleWaveHdr.IsAllocated)
            {
                _gcHandleWaveHdr.Free();
            }
        }
    }

    internal void ReleaseData()
    {
        if (_gcHandle.IsAllocated)
        {
            _gcHandle.Free();
        }
    }
}