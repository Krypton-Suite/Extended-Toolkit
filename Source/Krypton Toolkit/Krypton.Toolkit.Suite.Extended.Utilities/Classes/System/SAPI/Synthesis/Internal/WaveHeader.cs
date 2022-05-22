#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Synthesis
{
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
}