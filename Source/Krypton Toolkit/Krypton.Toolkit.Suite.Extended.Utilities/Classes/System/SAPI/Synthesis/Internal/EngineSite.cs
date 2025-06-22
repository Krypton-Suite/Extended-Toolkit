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
        get => _eventMapper;
        set => _eventMapper = value;
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
        get => _defaultRate;
        set
        {
            _defaultRate = value;
            _actions |= SPVESACTIONS.SPVES_RATE;
        }
    }

    internal int VoiceVolume
    {
        get => _volume;
        set
        {
            _volume = value;
            _actions |= SPVESACTIONS.SPVES_VOLUME;
        }
    }

    internal Exception LastException
    {
        get => _exception;
        set => _exception = value;
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
        _actions = SPVESACTIONS.SPVES_RATE | SPVESACTIONS.SPVES_VOLUME;
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