#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.System.TTSEngine;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Synthesis
{
    internal class TTSEvent
    {
        private TtsEventId _evtId;

        private Exception _exception;

        private VoiceInfo _voice;

        private TimeSpan _audioPosition;

        private string _bookmark;

        private uint _wParam;

        private IntPtr _lParam;

        private Prompt _prompt;

        private string _phoneme;

        private string _nextPhoneme;

        private TimeSpan _phonemeDuration;

        private SynthesizerEmphasis _phonemeEmphasis;

        internal TtsEventId Id => _evtId;

        internal Exception Exception => _exception;

        internal Prompt Prompt => _prompt;

        internal VoiceInfo Voice => _voice;

        internal TimeSpan AudioPosition => _audioPosition;

        internal string Bookmark => _bookmark;

        internal IntPtr LParam => _lParam;

        internal uint WParam => _wParam;

        internal SynthesizerEmphasis PhonemeEmphasis => _phonemeEmphasis;

        internal string Phoneme => _phoneme;

        internal string NextPhoneme
        {
            get
            {
                return _nextPhoneme;
            }
            set
            {
                _nextPhoneme = value;
            }
        }

        internal TimeSpan PhonemeDuration => _phonemeDuration;

        internal TTSEvent(TtsEventId id, Prompt prompt, Exception exception, VoiceInfo voice)
        {
            _evtId = id;
            _prompt = prompt;
            _exception = exception;
            _voice = voice;
        }

        internal TTSEvent(TtsEventId id, Prompt prompt, Exception exception, VoiceInfo voice, TimeSpan audioPosition, long streamPosition, string bookmark, uint wParam, IntPtr lParam)
            : this(id, prompt, exception, voice)
        {
            _audioPosition = audioPosition;
            _bookmark = bookmark;
            _wParam = wParam;
            _lParam = lParam;
        }

        private TTSEvent()
        {
        }

        internal static TTSEvent CreatePhonemeEvent(string phoneme, string nextPhoneme, TimeSpan duration, SynthesizerEmphasis emphasis, Prompt prompt, TimeSpan audioPosition)
        {
            TTSEvent tTSEvent = new TTSEvent();
            tTSEvent._evtId = TtsEventId.Phoneme;
            tTSEvent._audioPosition = audioPosition;
            tTSEvent._prompt = prompt;
            tTSEvent._phoneme = phoneme;
            tTSEvent._nextPhoneme = nextPhoneme;
            tTSEvent._phonemeDuration = duration;
            tTSEvent._phonemeEmphasis = emphasis;
            return tTSEvent;
        }
    }
}