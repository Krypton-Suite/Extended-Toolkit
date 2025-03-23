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

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Synthesis
{
    internal class AudioDeviceOut : AudioBase, IDisposable
    {
        private class InItem : IDisposable
        {
            internal WaveHeader _waveHeader;

            internal object? _userData;

            internal InItem(WaveHeader waveHeader)
            {
                _waveHeader = waveHeader;
            }

            internal InItem(object? userData)
            {
                _userData = userData;
            }

            public void Dispose()
            {
                if (_waveHeader != null)
                {
                    _waveHeader.Dispose();
                }
                GC.SuppressFinalize(this);
            }

            internal void ReleaseData()
            {
                if (_waveHeader != null)
                {
                    _waveHeader.ReleaseData();
                }
            }
        }

        private List<InItem> _queueIn = [];

        private List<InItem> _queueOut = [];

        private int _blockAlign;

        private int _bytesWritten;

        private int _nAvgBytesPerSec;

        private IntPtr _hwo;

        private int _curDevice;

        private ManualResetEvent _evt = new(false);

        private SafeNativeMethods.WaveOutProc _delegate;

        private IAsyncDispatch _asyncDispatch;

        private bool _deviceOpen;

        private object _noWriteOutLock = new();

        private bool _fPaused;

        internal override TimeSpan Duration
        {
            get
            {
                if (_nAvgBytesPerSec == 0)
                {
                    return new TimeSpan(0L);
                }
                return new TimeSpan((long)_bytesWritten * 10000000L / _nAvgBytesPerSec);
            }
        }

        internal AudioDeviceOut(int curDevice, IAsyncDispatch asyncDispatch)
        {
            _delegate = CallBackProc;
            _asyncDispatch = asyncDispatch;
            _curDevice = curDevice;
        }

        ~AudioDeviceOut()
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
            if (_deviceOpen && _hwo != IntPtr.Zero)
            {
                SafeNativeMethods.waveOutClose(_hwo);
                _deviceOpen = false;
            }
            if (disposing)
            {
                ((IDisposable)_evt).Dispose();
            }
        }

        internal override void Begin(byte[] wfx)
        {
            if (_deviceOpen)
            {
                throw new InvalidOperationException();
            }
            WAVEFORMATEX.AvgBytesPerSec(wfx, out _nAvgBytesPerSec, out _blockAlign);
            MMSYSERR mMSYSERR;
            lock (_noWriteOutLock)
            {
                mMSYSERR = SafeNativeMethods.waveOutOpen(ref _hwo, _curDevice, wfx, _delegate, IntPtr.Zero, 196608u);
                if (_fPaused && mMSYSERR == MMSYSERR.NOERROR)
                {
                    mMSYSERR = SafeNativeMethods.waveOutPause(_hwo);
                }
                _aborted = false;
                _deviceOpen = true;
            }
            if (mMSYSERR != 0)
            {
                throw new AudioException(mMSYSERR);
            }
            _bytesWritten = 0;
            _evt.Set();
        }

        internal override void End()
        {
            if (!_deviceOpen)
            {
                throw new InvalidOperationException();
            }
            lock (_noWriteOutLock)
            {
                _deviceOpen = false;
                CheckForAbort();
                if (_queueIn.Count != 0)
                {
                    SafeNativeMethods.waveOutReset(_hwo);
                }
                MMSYSERR mMSYSERR = SafeNativeMethods.waveOutClose(_hwo);
            }
        }

        internal override void Play(byte[] buffer)
        {
            if (_deviceOpen)
            {
                int num = buffer.Length;
                _bytesWritten += num;
                WaveHeader waveHeader = new WaveHeader(buffer);
                GCHandle wAVEHDR = waveHeader.WAVEHDR;
                MMSYSERR mMSYSERR = SafeNativeMethods.waveOutPrepareHeader(_hwo, wAVEHDR.AddrOfPinnedObject(), waveHeader.SizeHDR);
                if (mMSYSERR != 0)
                {
                    throw new AudioException(mMSYSERR);
                }
                lock (_noWriteOutLock)
                {
                    if (!_aborted)
                    {
                        lock (_queueIn)
                        {
                            InItem item = new InItem(waveHeader);
                            _queueIn.Add(item);
                            _evt.Reset();
                        }
                        mMSYSERR = SafeNativeMethods.waveOutWrite(_hwo, wAVEHDR.AddrOfPinnedObject(), waveHeader.SizeHDR);
                        if (mMSYSERR != 0)
                        {
                            lock (_queueIn)
                            {
                                _queueIn.RemoveAt(_queueIn.Count - 1);
                                throw new AudioException(mMSYSERR);
                            }
                        }
                    }
                }
            }
        }

        internal override void Pause()
        {
            lock (_noWriteOutLock)
            {
                if (!_aborted && !_fPaused)
                {
                    if (_deviceOpen)
                    {
                        MMSYSERR mMSYSERR = SafeNativeMethods.waveOutPause(_hwo);
                    }
                    _fPaused = true;
                }
            }
        }

        internal override void Resume()
        {
            lock (_noWriteOutLock)
            {
                if (!_aborted && _fPaused && _deviceOpen)
                {
                    MMSYSERR mMSYSERR = SafeNativeMethods.waveOutRestart(_hwo);
                }
            }
            _fPaused = false;
        }

        internal override void Abort()
        {
            lock (_noWriteOutLock)
            {
                _aborted = true;
                if (_queueIn.Count > 0)
                {
                    SafeNativeMethods.waveOutReset(_hwo);
                    _evt.WaitOne();
                }
            }
        }

        internal override void InjectEvent(TTSEvent? ttsEvent)
        {
            if (_asyncDispatch != null && !_aborted)
            {
                lock (_queueIn)
                {
                    if (_queueIn.Count == 0)
                    {
                        _asyncDispatch.Post(ttsEvent);
                    }
                    else
                    {
                        _queueIn.Add(new InItem(ttsEvent));
                    }
                }
            }
        }

        internal override void WaitUntilDone()
        {
            if (!_deviceOpen)
            {
                throw new InvalidOperationException();
            }
            _evt.WaitOne();
        }

        internal static int NumDevices()
        {
            return SafeNativeMethods.waveOutGetNumDevs();
        }

        internal static int GetDevicedId(string name)
        {
            for (int i = 0; i < NumDevices(); i++)
            {
                string prodName;
                if (GetDeviceName(i, out prodName) == MMSYSERR.NOERROR && string.Compare(prodName, name, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    return i;
                }
            }
            return -1;
        }

        internal static MMSYSERR GetDeviceName(int deviceId, [MarshalAs(UnmanagedType.LPWStr)] out string prodName)
        {
            prodName = string.Empty;
            SafeNativeMethods.WAVEOUTCAPS caps = default(SafeNativeMethods.WAVEOUTCAPS);
            MMSYSERR mMSYSERR = SafeNativeMethods.waveOutGetDevCaps((IntPtr)deviceId, ref caps, Marshal.SizeOf((object)caps));
            if (mMSYSERR != 0)
            {
                return mMSYSERR;
            }
            prodName = caps.szPname;
            return MMSYSERR.NOERROR;
        }

        private void CallBackProc(IntPtr hwo, MM_MSG uMsg, IntPtr dwInstance, IntPtr dwParam1, IntPtr dwParam2)
        {
            if (uMsg == MM_MSG.MM_WOM_DONE)
            {
                lock (_queueIn)
                {
                    InItem inItem = _queueIn[0];
                    inItem.ReleaseData();
                    _queueIn.RemoveAt(0);
                    _queueOut.Add(inItem);
                    while (_queueIn.Count > 0)
                    {
                        inItem = _queueIn[0];
                        if (inItem._waveHeader != null)
                        {
                            break;
                        }
                        if (_asyncDispatch != null && !_aborted)
                        {
                            _asyncDispatch.Post(inItem._userData);
                        }
                        _queueIn.RemoveAt(0);
                    }
                }
                if (_queueIn.Count == 0)
                {
                    _evt.Set();
                }
            }
        }

        private void ClearBuffers()
        {
            foreach (InItem item in _queueOut)
            {
                WaveHeader waveHeader = item._waveHeader;
                MMSYSERR mMSYSERR = SafeNativeMethods.waveOutUnprepareHeader(_hwo, waveHeader.WAVEHDR.AddrOfPinnedObject(), waveHeader.SizeHDR);
            }
        }

        private void CheckForAbort()
        {
            if (_aborted)
            {
                lock (_queueIn)
                {
                    foreach (InItem item in _queueIn)
                    {
                        if (item._waveHeader != null)
                        {
                            WaveHeader waveHeader = item._waveHeader;
                            SafeNativeMethods.waveOutUnprepareHeader(_hwo, waveHeader.WAVEHDR.AddrOfPinnedObject(), waveHeader.SizeHDR);
                        }
                        else
                        {
                            _asyncDispatch.Post(item._userData);
                        }
                    }
                    _queueIn.Clear();
                    _evt.Set();
                }
            }
            ClearBuffers();
        }
    }
}