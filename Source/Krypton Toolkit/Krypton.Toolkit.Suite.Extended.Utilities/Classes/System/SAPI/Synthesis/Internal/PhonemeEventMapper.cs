#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

#define TRACE
using Krypton.Toolkit.Suite.Extended.Utilities.System.Internal;
using Krypton.Toolkit.Suite.Extended.Utilities.System.TTSEngine;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Synthesis
{
    internal class PhonemeEventMapper : TtsEventMapper
    {
        public enum PhonemeConversion
        {
            IpaToSapi,
            SapiToIpa,
            NoConversion
        }

        private PhonemeConversion _conversion;

        private StringBuilder _phonemes;

        private Queue _queue;

        private Queue _phonemeQueue;

        private AlphabetConverter _alphabetConverter;

        private int _lastComplete;

        internal PhonemeEventMapper(ITtsEventSink sink, PhonemeConversion conversion, AlphabetConverter alphabetConverter)
            : base(sink)
        {
            _queue = new Queue();
            _phonemeQueue = new Queue();
            _conversion = conversion;
            _alphabetConverter = alphabetConverter;
            Reset();
        }

        public override void AddEvent(TTSEvent evt)
        {
            if (_conversion == PhonemeConversion.NoConversion)
            {
                SendToOutput(evt);
            }
            else if (evt.Id == TtsEventId.Phoneme)
            {
                _phonemeQueue.Enqueue(evt);
                int num = _phonemes.Length + 1;
                _phonemes.Append(evt.Phoneme);
                while (true)
                {
                    string phonemes = _phonemes.ToString(0, num);
                    if (_alphabetConverter.IsPrefix(phonemes, _conversion == PhonemeConversion.SapiToIpa))
                    {
                        if (_alphabetConverter.IsConvertibleUnit(phonemes, _conversion == PhonemeConversion.SapiToIpa))
                        {
                            _lastComplete = num;
                        }
                        num++;
                    }
                    else
                    {
                        if (_lastComplete == 0)
                        {
                            break;
                        }
                        ConvertCompleteUnit();
                        _lastComplete = 0;
                        num = 1;
                    }
                    if (num > _phonemes.Length)
                    {
                        return;
                    }
                }
                Trace.TraceError("Cannot convert the phonemes correctly. Attempt to start over...");
                Reset();
            }
            else
            {
                SendToQueue(evt);
            }
        }

        public override void FlushEvent()
        {
            ConvertCompleteUnit();
            while (_queue.Count > 0)
            {
                SendToOutput((TTSEvent)_queue.Dequeue());
            }
            _phonemeQueue.Clear();
            _lastComplete = 0;
            base.FlushEvent();
        }

        private void ConvertCompleteUnit()
        {
            if (_lastComplete == 0)
            {
                return;
            }
            if (_phonemeQueue.Count == 0)
            {
                Trace.TraceError("Failed to convert phonemes. Phoneme queue is empty.");
                return;
            }
            char[] array = new char[_lastComplete];
            _phonemes.CopyTo(0, array, 0, _lastComplete);
            _phonemes.Remove(0, _lastComplete);
            char[] value = (_conversion != 0) ? _alphabetConverter.SapiToIpa(array) : _alphabetConverter.IpaToSapi(array);
            TTSEvent tTSEvent = null;
            long num = 0L;
            tTSEvent = (TTSEvent)_phonemeQueue.Peek();
            TTSEvent tTSEvent2;
            for (int i = 0; i < _lastComplete; i += tTSEvent2.Phoneme.Length)
            {
                tTSEvent2 = (TTSEvent)_phonemeQueue.Dequeue();
                num += tTSEvent2.PhonemeDuration.Milliseconds;
            }
            TTSEvent evt = TTSEvent.CreatePhonemeEvent(new string(value), "", TimeSpan.FromMilliseconds(num), tTSEvent.PhonemeEmphasis, tTSEvent.Prompt, tTSEvent.AudioPosition);
            SendToQueue(evt);
        }

        private void Reset()
        {
            _phonemeQueue.Clear();
            _phonemes = new StringBuilder();
            _lastComplete = 0;
        }

        private void SendToQueue(TTSEvent evt)
        {
            if (evt.Id == TtsEventId.Phoneme)
            {
                if (_queue.Count > 0)
                {
                    TTSEvent tTSEvent = _queue.Dequeue() as TTSEvent;
                    if (tTSEvent.Id == TtsEventId.Phoneme)
                    {
                        tTSEvent.NextPhoneme = evt.Phoneme;
                    }
                    else
                    {
                        Trace.TraceError("First event in the queue of the phone mapper is not a PHONEME event");
                    }
                    SendToOutput(tTSEvent);
                    while (_queue.Count > 0)
                    {
                        SendToOutput(_queue.Dequeue() as TTSEvent);
                    }
                }
                _queue.Enqueue(evt);
            }
            else if (_queue.Count > 0)
            {
                _queue.Enqueue(evt);
            }
            else
            {
                SendToOutput(evt);
            }
        }
    }
}