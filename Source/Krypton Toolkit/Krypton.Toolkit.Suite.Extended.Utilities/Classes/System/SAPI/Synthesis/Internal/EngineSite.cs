#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.System.Internal;
using Krypton.Toolkit.Suite.Extended.Utilities.System.TTSEngine;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Synthesis
{
    internal class EngineSite : ITtsEngineSite, ITtsEventSink
    {
        private int _eventInterest;

        private SPVESACTIONS _actions = SPVESACTIONS.SPVES_RATE | SPVESACTIONS.SPVES_VOLUME;

        private AudioBase _audio;

        private Prompt _prompt;

        private Exception _exception;

        private int _defaultRate;

        private int _volume = 100;

        private ResourceLoader _resourceLoader;

        private TtsEventMapper _eventMapper;

        private const int WAVE_FORMAT_PCM = 1;

        internal TtsEventMapper EventMapper
        {
            get
            {
                return _eventMapper;
            }
            set
            {
                _eventMapper = value;
            }
        }

        public int EventInterest => _eventInterest;

        public int Actions => (int)_actions;

        public int Rate
        {
            get
            {
                _actions &= ~SPVESACTIONS.SPVES_RATE;
                return _defaultRate;
            }
        }

        public int Volume
        {
            get
            {
                _actions &= ~SPVESACTIONS.SPVES_VOLUME;
                return _volume;
            }
        }

        internal int VoiceRate
        {
            get
            {
                return _defaultRate;
            }
            set
            {
                _defaultRate = value;
                _actions |= SPVESACTIONS.SPVES_RATE;
            }
        }

        internal int VoiceVolume
        {
            get
            {
                return _volume;
            }
            set
            {
                _volume = value;
                _actions |= SPVESACTIONS.SPVES_VOLUME;
            }
        }

        internal Exception LastException
        {
            get
            {
                return _exception;
            }
            set
            {
                _exception = value;
            }
        }

        internal EngineSite(ResourceLoader resourceLoader)
        {
            _resourceLoader = resourceLoader;
        }

        public void AddEvents([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] SpeechEventInfo[] events, int ulCount)
        {
            try
            {
                for (int i = 0; i < events.Length; i++)
                {
                    SpeechEventInfo sapiEvent = events[i];
                    int num = 1 << (int)sapiEvent.EventId;
                    if (sapiEvent.EventId == 2 && _eventMapper != null)
                    {
                        _eventMapper.FlushEvent();
                    }
                    if ((num & _eventInterest) != 0)
                    {
                        TTSEvent evt = CreateTtsEvent(sapiEvent);
                        if (_eventMapper == null)
                        {
                            AddEvent(evt);
                        }
                        else
                        {
                            _eventMapper.AddEvent(evt);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Exception ex = _exception = exception;
                _actions |= SPVESACTIONS.SPVES_ABORT;
            }
        }

        public int Write(IntPtr pBuff, int cb)
        {
            try
            {
                _audio.Play(pBuff, cb);
                return cb;
            }
            catch (Exception exception)
            {
                Exception ex = _exception = exception;
                _actions |= SPVESACTIONS.SPVES_ABORT;
                return cb;
            }
        }

        public SkipInfo GetSkipInfo()
        {
            return new SkipInfo(1, 1);
        }

        public void CompleteSkip(int ulNumSkipped)
        {
        }

        public Stream LoadResource(Uri uri, string mediaType)
        {
            try
            {
                string mimeType;
                Uri baseUri;
                string localPath;
                using (Stream stream = _resourceLoader.LoadFile(uri, out mimeType, out baseUri, out localPath))
                {
                    int num = (int)stream.Length;
                    MemoryStream memoryStream = new MemoryStream(num);
                    byte[] array = new byte[num];
                    stream.Read(array, 0, array.Length);
                    _resourceLoader.UnloadFile(localPath);
                    memoryStream.Write(array, 0, num);
                    memoryStream.Position = 0L;
                    return memoryStream;
                }
            }
            catch (Exception exception)
            {
                Exception ex = _exception = exception;
                _actions |= SPVESACTIONS.SPVES_ABORT;
            }
            return null;
        }

        public void AddEvent(TTSEvent evt)
        {
            _audio.InjectEvent(evt);
        }

        public void FlushEvent()
        {
        }

        internal void SetEventsInterest(int eventInterest)
        {
            _eventInterest = eventInterest;
            if (_eventMapper != null)
            {
                _eventMapper.FlushEvent();
            }
        }

        internal void Abort()
        {
            _actions = SPVESACTIONS.SPVES_ABORT;
        }

        internal void InitRun(AudioBase audioDevice, int defaultRate, Prompt prompt)
        {
            _audio = audioDevice;
            _prompt = prompt;
            _defaultRate = defaultRate;
            _actions = (SPVESACTIONS.SPVES_RATE | SPVESACTIONS.SPVES_VOLUME);
        }

        private TTSEvent CreateTtsEvent(SpeechEventInfo sapiEvent)
        {
            switch (sapiEvent.EventId)
            {
                case 6:
                    return TTSEvent.CreatePhonemeEvent(((char)((int)sapiEvent.Param2 & 0xFFFF)).ToString() ?? "", ((char)(sapiEvent.Param1 & 0xFFFF)).ToString() ?? "", TimeSpan.FromMilliseconds(sapiEvent.Param1 >> 16), (SynthesizerEmphasis)((uint)(int)sapiEvent.Param2 >> 16), _prompt, _audio.Duration);
                case 4:
                    {
                        string bookmark = Marshal.PtrToStringUni(sapiEvent.Param2);
                        return new TTSEvent((TtsEventId)sapiEvent.EventId, _prompt, null, null, _audio.Duration, _audio.Position, bookmark, (uint)sapiEvent.Param1, sapiEvent.Param2);
                    }
                default:
                    return new TTSEvent((TtsEventId)sapiEvent.EventId, _prompt, null, null, _audio.Duration, _audio.Position, null, (uint)sapiEvent.Param1, sapiEvent.Param2);
            }
        }
    }
}