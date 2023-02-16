#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
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
    internal class AudioFileOut : AudioBase, IDisposable
    {
        protected ManualResetEvent _evt = new(false);

        protected bool _deviceOpen;

        protected Stream _stream;

        protected PcmConverter _pcmConverter = new();

        protected bool _doConversion;

        protected bool _paused;

        protected int _totalByteWrittens;

        protected int _bytesWritten;

        private IAsyncDispatch _asyncDispatch;

        private object _noWriteOutLock = new();

        private WAVEFORMATEX _wfxIn;

        private WAVEFORMATEX _wfxOut;

        private bool _hasHeader;

        private long _startStreamPosition;

        internal override TimeSpan Duration
        {
            get
            {
                if (_wfxIn.nAvgBytesPerSec == 0)
                {
                    return new TimeSpan(0L);
                }
                return new TimeSpan((long)_bytesWritten * 10000000L / _wfxIn.nAvgBytesPerSec);
            }
        }

        internal override long Position => _stream.Position;

        internal override byte[] WaveFormat => _wfxOut.ToBytes();

        internal AudioFileOut(Stream stream, SpeechAudioFormatInfo? formatInfo, bool headerInfo, IAsyncDispatch asyncDispatch)
        {
            _asyncDispatch = asyncDispatch;
            _stream = stream;
            _startStreamPosition = _stream.Position;
            _hasHeader = headerInfo;
            _wfxOut = default(WAVEFORMATEX);
            if (formatInfo != null)
            {
                _wfxOut.wFormatTag = (short)formatInfo.EncodingFormat;
                _wfxOut.wBitsPerSample = (short)formatInfo.BitsPerSample;
                _wfxOut.nSamplesPerSec = formatInfo.SamplesPerSecond;
                _wfxOut.nChannels = (short)formatInfo.ChannelCount;
            }
            else
            {
                _wfxOut = WAVEFORMATEX.Default;
            }
            _wfxOut.nBlockAlign = (short)(_wfxOut.nChannels * _wfxOut.wBitsPerSample / 8);
            _wfxOut.nAvgBytesPerSec = _wfxOut.wBitsPerSample * _wfxOut.nSamplesPerSec * _wfxOut.nChannels / 8;
        }

        public void Dispose()
        {
            _evt.Close();
            GC.SuppressFinalize(this);
        }

        internal override void Begin(byte[] wfx)
        {
            if (_deviceOpen)
            {
                throw new InvalidOperationException();
            }
            _wfxIn = WAVEFORMATEX.ToWaveHeader(wfx);
            _doConversion = _pcmConverter.PrepareConverter(ref _wfxIn, ref _wfxOut);
            if (_totalByteWrittens == 0 && _hasHeader)
            {
                AudioBase.WriteWaveHeader(_stream, _wfxOut, _startStreamPosition, 0);
            }
            _bytesWritten = 0;
            _aborted = false;
            _deviceOpen = true;
        }

        internal override void End()
        {
            if (!_deviceOpen)
            {
                throw new InvalidOperationException();
            }
            _deviceOpen = false;
            if (!_aborted && _hasHeader)
            {
                long position = _stream.Position;
                AudioBase.WriteWaveHeader(_stream, _wfxOut, _startStreamPosition, _totalByteWrittens);
                _stream.Seek(position, SeekOrigin.Begin);
            }
        }

        internal override void Play(byte[] buffer)
        {
            if (_deviceOpen)
            {
                byte[] array = _doConversion ? _pcmConverter.ConvertSamples(buffer) : buffer;
                if (_paused)
                {
                    _evt.WaitOne();
                    _evt.Reset();
                }
                if (!_aborted)
                {
                    _stream.Write(array, 0, array.Length);
                    _totalByteWrittens += array.Length;
                    _bytesWritten += array.Length;
                }
            }
        }

        internal override void Pause()
        {
            if (!_aborted && !_paused)
            {
                lock (_noWriteOutLock)
                {
                    _paused = true;
                }
            }
        }

        internal override void Resume()
        {
            if (!_aborted && _paused)
            {
                lock (_noWriteOutLock)
                {
                    _paused = false;
                    _evt.Set();
                }
            }
        }

        internal override void Abort()
        {
            lock (_noWriteOutLock)
            {
                _aborted = true;
                _paused = false;
                _evt.Set();
            }
        }

        internal override void InjectEvent(TTSEvent ttsEvent)
        {
            if (!_aborted && _asyncDispatch != null)
            {
                _asyncDispatch.Post(ttsEvent);
            }
        }

        internal override void WaitUntilDone()
        {
            lock (_noWriteOutLock)
            {
            }
        }
    }
}