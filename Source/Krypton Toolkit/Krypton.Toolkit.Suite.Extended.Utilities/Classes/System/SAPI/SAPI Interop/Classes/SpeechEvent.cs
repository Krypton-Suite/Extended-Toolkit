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

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    internal class SpeechEvent : IDisposable
    {
        private SPEVENTENUM _eventId;

        private SPEVENTLPARAMTYPE _paramType;

        private ulong _audioStreamOffset;

        private ulong _wParam;

        private ulong _lParam;

        private TimeSpan _audioPosition;

        private int _sizeMemoryPressure;

        internal SPEVENTENUM EventId => _eventId;

        internal ulong AudioStreamOffset => _audioStreamOffset;

        internal ulong WParam => _wParam;

        internal ulong LParam => _lParam;

        internal TimeSpan AudioPosition => _audioPosition;

        private SpeechEvent(SPEVENTENUM eEventId, SPEVENTLPARAMTYPE elParamType, ulong ullAudioStreamOffset, IntPtr wParam, IntPtr lParam)
        {
            _eventId = eEventId;
            _paramType = elParamType;
            _audioStreamOffset = ullAudioStreamOffset;
            _wParam = (ulong)wParam.ToInt64();
            _lParam = (ulong)(long)lParam;
            if (_paramType == SPEVENTLPARAMTYPE.SPET_LPARAM_IS_POINTER || _paramType == SPEVENTLPARAMTYPE.SPET_LPARAM_IS_STRING)
            {
                GC.AddMemoryPressure(_sizeMemoryPressure = Marshal.SizeOf((object)_lParam));
            }
        }

        private SpeechEvent(SPEVENT sapiEvent, SpeechAudioFormatInfo audioFormat)
            : this(sapiEvent.eEventId, sapiEvent.elParamType, sapiEvent.ullAudioStreamOffset, sapiEvent.wParam, sapiEvent.lParam)
        {
            if (audioFormat == null || audioFormat.EncodingFormat == (EncodingFormat)0)
            {
                _audioPosition = TimeSpan.Zero;
            }
            else
            {
                _audioPosition = ((audioFormat.AverageBytesPerSecond > 0) ? new TimeSpan((long)(sapiEvent.ullAudioStreamOffset * 10000000 / (ulong)audioFormat.AverageBytesPerSecond)) : TimeSpan.Zero);
            }
        }

        private SpeechEvent(SPEVENTEX sapiEventEx)
            : this(sapiEventEx.eEventId, sapiEventEx.elParamType, sapiEventEx.ullAudioStreamOffset, sapiEventEx.wParam, sapiEventEx.lParam)
        {
            _audioPosition = new TimeSpan((long)sapiEventEx.ullAudioTimeOffset);
        }

        ~SpeechEvent()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (_lParam != 0L)
            {
                if (_paramType == SPEVENTLPARAMTYPE.SPET_LPARAM_IS_TOKEN || _paramType == SPEVENTLPARAMTYPE.SPET_LPARAM_IS_OBJECT)
                {
                    Marshal.Release((IntPtr)(long)_lParam);
                }
                else if (_paramType == SPEVENTLPARAMTYPE.SPET_LPARAM_IS_POINTER || _paramType == SPEVENTLPARAMTYPE.SPET_LPARAM_IS_STRING)
                {
                    Marshal.FreeCoTaskMem((IntPtr)(long)_lParam);
                }
                if (_sizeMemoryPressure > 0)
                {
                    GC.RemoveMemoryPressure(_sizeMemoryPressure);
                    _sizeMemoryPressure = 0;
                }
                _lParam = 0uL;
            }
            GC.SuppressFinalize(this);
        }

        internal static SpeechEvent TryCreateSpeechEvent(ISpEventSource sapiEventSource, bool additionalSapiFeatures, SpeechAudioFormatInfo audioFormat)
        {
            SpeechEvent result = null;
            uint pulFetched;
            if (additionalSapiFeatures)
            {
                SPEVENTEX pEventArray;
                ((ISpEventSource2)sapiEventSource).GetEventsEx(1u, out pEventArray, out pulFetched);
                if (pulFetched == 1)
                {
                    result = new SpeechEvent(pEventArray);
                }
            }
            else
            {
                SPEVENT pEventArray2;
                sapiEventSource.GetEvents(1u, out pEventArray2, out pulFetched);
                if (pulFetched == 1)
                {
                    result = new SpeechEvent(pEventArray2, audioFormat);
                }
            }
            return result;
        }
    }
}