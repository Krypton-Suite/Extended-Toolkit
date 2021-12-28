#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.System.AudioFormat;
using Krypton.Toolkit.Suite.Extended.Utilities.System.Internal;
using Krypton.Toolkit.Suite.Extended.Utilities.System.ObjectTokens;
using Krypton.Toolkit.Suite.Extended.Utilities.System.TTSEngine;
using Krypton.Toolkit.Suite.Extended.Utilities.SystemInternal.Speech;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Synthesis
{
    internal sealed class VoiceSynthesis : IDisposable
    {
        private enum Action
        {
            GetVoice,
            SpeakText
        }

        private class Parameters
        {
            internal Action _action;

            internal object _parameter;

            internal Parameters(Action action, object parameter)
            {
                _action = action;
                _parameter = parameter;
            }
        }

        private class ParametersSpeak
        {
            internal string _textToSpeak;

            internal Prompt _prompt;

            internal bool _isXml;

            internal Uri _audioFile;

            internal ParametersSpeak(string textToSpeak, Prompt prompt, bool isXml, Uri audioFile)
            {
                _textToSpeak = textToSpeak;
                _prompt = prompt;
                _isXml = isXml;
                _audioFile = audioFile;
            }
        }

        internal EventHandler<StateChangedEventArgs> _stateChanged;

        internal EventHandler<SpeakStartedEventArgs> _speakStarted;

        internal EventHandler<SpeakCompletedEventArgs> _speakCompleted;

        internal EventHandler<SpeakProgressEventArgs> _speakProgress;

        internal EventHandler<BookmarkReachedEventArgs> _bookmarkReached;

        internal EventHandler<VoiceChangeEventArgs> _voiceChange;

        internal EventHandler<PhonemeReachedEventArgs> _phonemeReached;

        internal EventHandler<VisemeReachedEventArgs> _visemeReached;

        private WaitCallback _eventStateChanged;

        private WaitCallback _signalWorkerCallback;

        private readonly ResourceLoader _resourceLoader;

        private readonly EngineSite _site;

        private EngineSiteSapi _siteSapi;

        private IntPtr _iSite;

        private int _ttsInterest;

        private ManualResetEvent _evtPendingSpeak = new ManualResetEvent(false);

        private ManualResetEvent _evtPendingGetProxy = new ManualResetEvent(false);

        private Exception _pendingException;

        private Queue<Parameters> _pendingSpeakQueue = new Queue<Parameters>();

        private TTSVoice _pendingVoice;

        private Thread _workerThread;

        private bool _fExitWorkerThread;

        private object _processingSpeakLock = new object();

        private Dictionary<VoiceInfo, TTSVoice> _voiceDictionary = new Dictionary<VoiceInfo, TTSVoice>();

        private List<InstalledVoice> _installedVoices;

        private static List<InstalledVoice> _allVoices;

        private object _enabledVoicesLock = new object();

        private TTSVoice _defaultVoice;

        private TTSVoice _currentVoice;

        private bool _defaultVoiceInitialized;

        private object _defaultVoiceLock = new object();

        private AudioBase _waveOut;

        private int _defaultRate;

        private bool _isDisposed;

        private List<LexiconEntry> _lexicons = new List<LexiconEntry>();

        private SynthesizerState _synthesizerState;

        private Prompt _currentPrompt;

        private const string defaultVoiceRate = "DefaultTTSRate";

        private AsyncSerializedWorker _asyncWorker;

        private AsyncSerializedWorker _asyncWorkerUI;

        private const bool _pexml = false;

        private int _ttsEvents = 6;

        private object _thisObjectLock = new object();

        private AutoResetEvent _workerWaitHandle = new AutoResetEvent(false);

        private WeakReference _speechSyntesizer;

        private readonly string[] xmlEscapeStrings = new string[5]
        {
            "&quot;",
            "&apos;",
            "&amp;",
            "&lt;",
            "&gt;"
        };

        private readonly char[] xmlEscapeChars = new char[5]
        {
            '"',
            '\'',
            '&',
            '<',
            '>'
        };

        internal Prompt Prompt
        {
            get
            {
                lock (_pendingSpeakQueue)
                {
                    return _currentPrompt;
                }
            }
        }

        internal SynthesizerState State => _synthesizerState;

        internal int Rate
        {
            get
            {
                return _site.VoiceRate;
            }
            set
            {
                _site.VoiceRate = (_defaultRate = value);
            }
        }

        internal int Volume
        {
            get
            {
                return _site.VoiceVolume;
            }
            set
            {
                _site.VoiceVolume = value;
            }
        }

        internal TTSVoice Voice
        {
            set
            {
                lock (_defaultVoiceLock)
                {
                    if (_currentVoice == _defaultVoice && value == null)
                    {
                        _defaultVoiceInitialized = false;
                    }
                    _currentVoice = value;
                }
            }
        }

        private IntPtr ComEngineSite
        {
            get
            {
                if (_iSite == IntPtr.Zero)
                {
                    _siteSapi = new EngineSiteSapi(_site, _resourceLoader);
                    _iSite = Marshal.GetComInterfaceForObject(_siteSapi, typeof(ISpEngineSite));
                }
                return _iSite;
            }
        }

        internal VoiceSynthesis(WeakReference speechSynthesizer)
        {
            _asyncWorker = new AsyncSerializedWorker(ProcessPostData, null);
            _asyncWorkerUI = new AsyncSerializedWorker(null, AsyncOperationManager.CreateOperation(null));
            _eventStateChanged = OnStateChanged;
            _signalWorkerCallback = SignalWorkerThread;
            _speechSyntesizer = speechSynthesizer;
            _resourceLoader = new ResourceLoader();
            _site = new EngineSite(_resourceLoader);
            _evtPendingSpeak.Reset();
            _waveOut = new AudioDeviceOut(SAPICategories.DefaultDeviceOut(), _asyncWorker);
            if (_allVoices == null)
            {
                _allVoices = BuildInstalledVoices(this);
                if (_allVoices.Count == 0)
                {
                    _allVoices = null;
                    throw new PlatformNotSupportedException(SR.Get(SRID.SynthesizerVoiceFailed));
                }
            }
            _installedVoices = new List<InstalledVoice>(_allVoices.Count);
            foreach (InstalledVoice allVoice in _allVoices)
            {
                _installedVoices.Add(new InstalledVoice(this, allVoice.VoiceInfo));
            }
            _site.VoiceRate = (_defaultRate = (int)GetDefaultRate());
            _workerThread = new Thread(ThreadProc);
            _workerThread.IsBackground = true;
            _workerThread.Start();
            SetInterest(_ttsEvents);
        }

        ~VoiceSynthesis()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        internal void Speak(Prompt prompt)
        {
            bool done = false;
            EventHandler<StateChangedEventArgs> eventHandler = delegate (object sender, StateChangedEventArgs args)
            {
                if (prompt.IsCompleted && args.State == SynthesizerState.Ready)
                {
                    done = true;
                    _workerWaitHandle.Set();
                }
            };
            try
            {
                _stateChanged = (EventHandler<StateChangedEventArgs>)Delegate.Combine(_stateChanged, eventHandler);
                _asyncWorkerUI.AsyncMode = false;
                _asyncWorkerUI.WorkItemPending += _signalWorkerCallback;
                QueuePrompt(prompt);
                while (!done && !_isDisposed)
                {
                    _workerWaitHandle.WaitOne();
                    _asyncWorkerUI.ConsumeQueue();
                }
                if (prompt._exception != null)
                {
                    throw prompt._exception;
                }
            }
            finally
            {
                _asyncWorkerUI.AsyncMode = true;
                _asyncWorkerUI.WorkItemPending -= _signalWorkerCallback;
                _stateChanged = (EventHandler<StateChangedEventArgs>)Delegate.Remove(_stateChanged, eventHandler);
            }
        }

        internal void SpeakAsync(Prompt prompt)
        {
            QueuePrompt(prompt);
        }

        internal void OnSpeakStarted(SpeakStartedEventArgs e)
        {
            if (_speakStarted != null)
            {
                _asyncWorkerUI.PostOperation(_speakStarted, _speechSyntesizer.Target, e);
            }
        }

        internal void FireSpeakCompleted(object sender, SpeakCompletedEventArgs e)
        {
            if (_speakCompleted != null && !e.Prompt._syncSpeak)
            {
                _speakCompleted(sender, e);
            }
            e.Prompt.Synthesizer = null;
        }

        internal void OnSpeakCompleted(SpeakCompletedEventArgs e)
        {
            e.Prompt.IsCompleted = true;
            _asyncWorkerUI.PostOperation(new EventHandler<SpeakCompletedEventArgs>(FireSpeakCompleted), _speechSyntesizer.Target, e);
        }

        internal void OnSpeakProgress(SpeakProgressEventArgs e)
        {
            if (_speakProgress != null)
            {
                string empty = string.Empty;
                if (e.Prompt._media == SynthesisMediaType.Ssml)
                {
                    int newLength = e.CharacterCount;
                    empty = RemoveEscapeString(e.Prompt._text, e.CharacterPosition, newLength, out newLength);
                    e.CharacterCount = newLength;
                }
                else
                {
                    empty = e.Prompt._text.Substring(e.CharacterPosition, e.CharacterCount);
                }
                e.Text = empty;
                _asyncWorkerUI.PostOperation(_speakProgress, _speechSyntesizer.Target, e);
            }
        }

        private string RemoveEscapeString(string text, int start, int length, out int newLength)
        {
            newLength = length;
            int num = text.LastIndexOf('>', start);
            int num2 = num;
            StringBuilder stringBuilder = new StringBuilder(text.Substring(0, num2));
            do
            {
                int num3 = -1;
                int num4 = int.MaxValue;
                for (int i = 0; i < xmlEscapeStrings.Length; i++)
                {
                    int num5;
                    if ((num5 = text.IndexOf(xmlEscapeStrings[i], num2, StringComparison.Ordinal)) >= 0 && num4 > num5)
                    {
                        num4 = num5;
                        num3 = i;
                    }
                }
                if (num3 < 0)
                {
                    num4 = text.Length;
                }
                else if (num4 >= num)
                {
                    newLength += xmlEscapeStrings[num3].Length - 1;
                }
                else
                {
                    num4 += xmlEscapeStrings[num3].Length;
                    num3 = -1;
                }
                int length2 = num4 - num2;
                stringBuilder.Append(text.Substring(num2, length2));
                if (num3 >= 0)
                {
                    stringBuilder.Append(xmlEscapeChars[num3]);
                    int length3 = xmlEscapeStrings[num3].Length;
                    num4 += length3;
                }
                num2 = num4;
            }
            while (start + length > stringBuilder.Length);
            return stringBuilder.ToString().Substring(start, length);
        }

        internal void OnBookmarkReached(BookmarkReachedEventArgs e)
        {
            if (_bookmarkReached != null)
            {
                _asyncWorkerUI.PostOperation(_bookmarkReached, _speechSyntesizer.Target, e);
            }
        }

        internal void OnVoiceChange(VoiceChangeEventArgs e)
        {
            if (_voiceChange != null)
            {
                _asyncWorkerUI.PostOperation(_voiceChange, _speechSyntesizer.Target, e);
            }
        }

        internal void OnPhonemeReached(PhonemeReachedEventArgs e)
        {
            if (_phonemeReached != null)
            {
                _asyncWorkerUI.PostOperation(_phonemeReached, _speechSyntesizer.Target, e);
            }
        }

        private void OnVisemeReached(VisemeReachedEventArgs e)
        {
            if (_visemeReached != null)
            {
                _asyncWorkerUI.PostOperation(_visemeReached, _speechSyntesizer.Target, e);
            }
        }

        private void OnStateChanged(object o)
        {
            lock (_thisObjectLock)
            {
                StateChangedEventArgs stateChangedEventArgs = (StateChangedEventArgs)o;
                if (_stateChanged != null)
                {
                    _asyncWorkerUI.PostOperation(_stateChanged, _speechSyntesizer.Target, stateChangedEventArgs);
                }
            }
        }

        internal void AddEvent<T>(TtsEventId ttsEvent, ref EventHandler<T> internalEventHandler, EventHandler<T> eventHandler) where T : PromptEventArgs
        {
            lock (_thisObjectLock)
            {
                Helpers.ThrowIfNull(eventHandler, "eventHandler");
                bool flag = internalEventHandler == null;
                internalEventHandler = (EventHandler<T>)Delegate.Combine(internalEventHandler, eventHandler);
                if (flag)
                {
                    _ttsEvents |= 1 << (int)ttsEvent;
                    SetInterest(_ttsEvents);
                }
            }
        }

        internal void RemoveEvent<T>(TtsEventId ttsEvent, ref EventHandler<T> internalEventHandler, EventHandler<T> eventHandler) where T : EventArgs
        {
            lock (_thisObjectLock)
            {
                Helpers.ThrowIfNull(eventHandler, "eventHandler");
                internalEventHandler = (EventHandler<T>)Delegate.Remove(internalEventHandler, eventHandler);
                if (internalEventHandler == null)
                {
                    _ttsEvents &= ~(1 << (int)ttsEvent);
                    SetInterest(_ttsEvents);
                }
            }
        }

        internal void SetOutput(Stream stream, SpeechAudioFormatInfo formatInfo, bool headerInfo)
        {
            lock (_pendingSpeakQueue)
            {
                if (State == SynthesizerState.Speaking)
                {
                    throw new InvalidOperationException(SR.Get(SRID.SynthesizerSetOutputSpeaking));
                }
                if (State == SynthesizerState.Paused)
                {
                    throw new InvalidOperationException(SR.Get(SRID.SynthesizerSyncSetOutputWhilePaused));
                }
                lock (_processingSpeakLock)
                {
                    if (stream == null)
                    {
                        _waveOut = new AudioDeviceOut(SAPICategories.DefaultDeviceOut(), _asyncWorker);
                    }
                    else
                    {
                        _waveOut = new AudioFileOut(stream, formatInfo, headerInfo, _asyncWorker);
                    }
                }
            }
        }

        internal void Abort()
        {
            lock (_pendingSpeakQueue)
            {
                lock (_site)
                {
                    if (_currentPrompt != null)
                    {
                        _site.Abort();
                        _waveOut.Abort();
                    }
                }
                lock (_processingSpeakLock)
                {
                    Parameters[] array = _pendingSpeakQueue.ToArray();
                    Parameters[] array2 = array;
                    foreach (Parameters parameters in array2)
                    {
                        ParametersSpeak parametersSpeak = parameters._parameter as ParametersSpeak;
                        if (parametersSpeak != null)
                        {
                            parametersSpeak._prompt._exception = new OperationCanceledException(SR.Get(SRID.PromptAsyncOperationCancelled));
                        }
                    }
                    _evtPendingSpeak.Set();
                }
            }
        }

        internal void Abort(Prompt prompt)
        {
            lock (_pendingSpeakQueue)
            {
                bool flag = false;
                foreach (Parameters item in _pendingSpeakQueue)
                {
                    ParametersSpeak parametersSpeak = item._parameter as ParametersSpeak;
                    if (parametersSpeak._prompt == prompt)
                    {
                        parametersSpeak._prompt._exception = new OperationCanceledException(SR.Get(SRID.PromptAsyncOperationCancelled));
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    lock (_site)
                    {
                        if (_currentPrompt == prompt)
                        {
                            _site.Abort();
                            _waveOut.Abort();
                        }
                    }
                    lock (_processingSpeakLock)
                    {
                    }
                }
            }
        }

        internal void Pause()
        {
            lock (_waveOut)
            {
                if (_waveOut != null)
                {
                    _waveOut.Pause();
                }
                lock (_pendingSpeakQueue)
                {
                    if (_pendingSpeakQueue.Count > 0 && State == SynthesizerState.Ready)
                    {
                        OnStateChanged(SynthesizerState.Speaking);
                    }
                    OnStateChanged(SynthesizerState.Paused);
                }
            }
        }

        internal void Resume()
        {
            lock (_waveOut)
            {
                if (_waveOut != null)
                {
                    _waveOut.Resume();
                }
                lock (_pendingSpeakQueue)
                {
                    if (_pendingSpeakQueue.Count > 0 || _currentPrompt != null)
                    {
                        OnStateChanged(SynthesizerState.Speaking);
                    }
                    else
                    {
                        if (State == SynthesizerState.Paused)
                        {
                            OnStateChanged(SynthesizerState.Speaking);
                        }
                        OnStateChanged(SynthesizerState.Ready);
                    }
                }
            }
        }

        internal void AddLexicon(Uri uri, string mediaType)
        {
            LexiconEntry item = new LexiconEntry(uri, mediaType);
            lock (_processingSpeakLock)
            {
                foreach (LexiconEntry lexicon in _lexicons)
                {
                    if (lexicon._uri.Equals(uri))
                    {
                        throw new InvalidOperationException(SR.Get(SRID.DuplicatedEntry));
                    }
                }
                _lexicons.Add(item);
            }
        }

        internal void RemoveLexicon(Uri uri)
        {
            lock (_processingSpeakLock)
            {
                foreach (LexiconEntry lexicon in _lexicons)
                {
                    if (lexicon._uri.Equals(uri))
                    {
                        _lexicons.Remove(lexicon);
                        return;
                    }
                }
                throw new InvalidOperationException(SR.Get(SRID.FileNotFound, uri.ToString()));
            }
        }

        internal TTSVoice GetEngine(string name, CultureInfo culture, VoiceGender gender, VoiceAge age, int variant, bool switchContext)
        {
            TTSVoice defaultVoice = (_currentVoice != null) ? _currentVoice : GetVoice(switchContext);
            return GetEngineWithVoice(defaultVoice, null, name, culture, gender, age, variant, switchContext);
        }

        internal ReadOnlyCollection<InstalledVoice> GetInstalledVoices(CultureInfo culture)
        {
            if (culture == null || culture == CultureInfo.InvariantCulture)
            {
                return new ReadOnlyCollection<InstalledVoice>(_installedVoices);
            }
            Collection<InstalledVoice> collection = new Collection<InstalledVoice>();
            foreach (InstalledVoice installedVoice in _installedVoices)
            {
                if (culture.Equals(installedVoice.VoiceInfo.Culture))
                {
                    collection.Add(installedVoice);
                }
            }
            return new ReadOnlyCollection<InstalledVoice>(collection);
        }

        internal TTSVoice CurrentVoice(bool switchContext)
        {
            lock (_defaultVoiceLock)
            {
                if (_currentVoice == null)
                {
                    GetVoice(switchContext);
                }
                return _currentVoice;
            }
        }

        private void ThreadProc()
        {
            do
            {
                _evtPendingSpeak.WaitOne();
                Parameters parameters;
                lock (_pendingSpeakQueue)
                {
                    if (_pendingSpeakQueue.Count > 0)
                    {
                        parameters = _pendingSpeakQueue.Dequeue();
                        ParametersSpeak parametersSpeak = parameters._parameter as ParametersSpeak;
                        if (parametersSpeak != null)
                        {
                            lock (_site)
                            {
                                if (_currentPrompt == null && State != SynthesizerState.Paused)
                                {
                                    OnStateChanged(SynthesizerState.Speaking);
                                }
                                _currentPrompt = parametersSpeak._prompt;
                                _waveOut.IsAborted = false;
                            }
                        }
                        else
                        {
                            _currentPrompt = null;
                        }
                    }
                    else
                    {
                        parameters = null;
                    }
                }
                if (parameters != null)
                {
                    switch (parameters._action)
                    {
                        case Action.GetVoice:
                            try
                            {
                                _pendingVoice = null;
                                _pendingException = null;
                                _pendingVoice = GetProxyEngine((VoiceInfo)parameters._parameter);
                            }
                            catch (Exception pendingException)
                            {
                                Exception ex = _pendingException = pendingException;
                            }
                            finally
                            {
                                _evtPendingGetProxy.Set();
                            }
                            break;
                        case Action.SpeakText:
                            {
                                ParametersSpeak parametersSpeak2 = (ParametersSpeak)parameters._parameter;
                                try
                                {
                                    InjectEvent(TtsEventId.StartInputStream, parametersSpeak2._prompt, parametersSpeak2._prompt._exception, null);
                                    if (parametersSpeak2._prompt._exception == null)
                                    {
                                        List<LexiconEntry> list = new List<LexiconEntry>();
                                        TTSVoice ttsVoice = (_currentVoice != null) ? _currentVoice : GetVoice(false);
                                        SpeakInfo speakInfo = new SpeakInfo(this, ttsVoice);
                                        if (parametersSpeak2._textToSpeak != null)
                                        {
                                            if (!parametersSpeak2._isXml)
                                            {
                                                FragmentState fragState = default(FragmentState);
                                                fragState.Action = TtsEngineAction.Speak;
                                                fragState.Prosody = new Prosody();
                                                TextFragment textFragment = new TextFragment(fragState, string.Copy(parametersSpeak2._textToSpeak));
                                                speakInfo.AddText(ttsVoice, textFragment);
                                            }
                                            else
                                            {
                                                TextFragmentEngine engine = new TextFragmentEngine(speakInfo, parametersSpeak2._textToSpeak, false, _resourceLoader, list);
                                                SsmlParser.Parse(parametersSpeak2._textToSpeak, engine, speakInfo.Voice);
                                            }
                                        }
                                        else
                                        {
                                            speakInfo.AddAudio(new AudioData(parametersSpeak2._audioFile, _resourceLoader));
                                        }
                                        list.AddRange(_lexicons);
                                        SpeakText(speakInfo, parametersSpeak2._prompt, list);
                                    }
                                    ChangeStateToReady(parametersSpeak2._prompt, parametersSpeak2._prompt._exception);
                                }
                                catch (Exception exception)
                                {
                                    ChangeStateToReady(parametersSpeak2._prompt, exception);
                                }
                                break;
                            }
                    }
                }
                lock (_pendingSpeakQueue)
                {
                    if (_pendingSpeakQueue.Count == 0)
                    {
                        _evtPendingSpeak.Reset();
                    }
                }
            }
            while (!_fExitWorkerThread);
            _synthesizerState = SynthesizerState.Ready;
        }

        private void AddSpeakParameters(Parameters param)
        {
            lock (_pendingSpeakQueue)
            {
                _pendingSpeakQueue.Enqueue(param);
                if (_pendingSpeakQueue.Count == 1)
                {
                    _evtPendingSpeak.Set();
                }
            }
        }

        private void SpeakText(SpeakInfo speakInfo, Prompt prompt, List<LexiconEntry> lexicons)
        {
            VoiceInfo voiceInfo = null;
            SpeechSeg speechSeg;
            while ((speechSeg = speakInfo.RemoveFirst()) != null)
            {
                TTSVoice voice = speechSeg.Voice;
                if (voice != null && (voiceInfo == null || !voiceInfo.Equals(voice.VoiceInfo)))
                {
                    voiceInfo = voice.VoiceInfo;
                    InjectEvent(TtsEventId.VoiceChange, prompt, null, voiceInfo);
                }
                lock (_processingSpeakLock)
                {
                    if (speechSeg.IsText)
                    {
                        lock (_site)
                        {
                            if (_waveOut.IsAborted)
                            {
                                _waveOut.IsAborted = false;
                                throw new OperationCanceledException(SR.Get(SRID.PromptAsyncOperationCancelled));
                            }
                            _site.InitRun(_waveOut, _defaultRate, prompt);
                            _waveOut.Begin(voice.WaveFormat(_waveOut.WaveFormat));
                        }
                        try
                        {
                            voice.UpdateLexicons(lexicons);
                            _site.SetEventsInterest(_ttsInterest);
                            byte[] wfx = voice.WaveFormat(_waveOut.WaveFormat);
                            ITtsEngineProxy ttsEngine = voice.TtsEngine;
                            if ((_ttsInterest & 0x40) != 0 && ttsEngine.EngineAlphabet != AlphabetType.Ipa)
                            {
                                _site.EventMapper = new PhonemeEventMapper(_site, PhonemeEventMapper.PhonemeConversion.SapiToIpa, ttsEngine.AlphabetConverter);
                            }
                            else
                            {
                                _site.EventMapper = null;
                            }
                            _site.LastException = null;
                            ttsEngine.Speak(speechSeg.FragmentList, wfx);
                        }
                        finally
                        {
                            _waveOut.WaitUntilDone();
                            _waveOut.End();
                        }
                    }
                    else
                    {
                        _waveOut.PlayWaveFile(speechSeg.Audio);
                        speechSeg.Audio.Dispose();
                    }
                    lock (_site)
                    {
                        _currentPrompt = null;
                        if (_waveOut.IsAborted || _site.LastException != null)
                        {
                            _waveOut.IsAborted = false;
                            if (_site.LastException != null)
                            {
                                Exception lastException = _site.LastException;
                                _site.LastException = null;
                                throw lastException;
                            }
                            throw new OperationCanceledException(SR.Get(SRID.PromptAsyncOperationCancelled));
                        }
                    }
                }
            }
        }

        private static uint GetDefaultRate()
        {
            uint value = 0u;
            using (ObjectTokenCategory objectTokenCategory = ObjectTokenCategory.Create("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Speech\\Voices"))
            {
                if (objectTokenCategory == null)
                {
                    return value;
                }
                objectTokenCategory.TryGetDWORD("DefaultTTSRate", ref value);
                return value;
            }
        }

        private void InjectEvent(TtsEventId evtId, Prompt prompt, Exception exception, VoiceInfo voiceInfo)
        {
            if (evtId == TtsEventId.EndInputStream)
            {
                if (_site.EventMapper != null)
                {
                    _site.EventMapper.FlushEvent();
                }
                prompt._exception = exception;
            }
            int num = 1 << (int)evtId;
            if ((num & _ttsInterest) != 0)
            {
                TTSEvent evt = new TTSEvent(evtId, prompt, exception, voiceInfo);
                _asyncWorker.Post(evt);
            }
        }

        private void OnStateChanged(SynthesizerState state)
        {
            if (_synthesizerState != state)
            {
                SynthesizerState synthesizerState = _synthesizerState;
                _synthesizerState = state;
                if (_eventStateChanged != null)
                {
                    _asyncWorker.PostOperation(_eventStateChanged, new StateChangedEventArgs(state, synthesizerState));
                }
            }
        }

        private void ChangeStateToReady(Prompt prompt, Exception exception)
        {
            lock (_waveOut)
            {
                lock (_pendingSpeakQueue)
                {
                    if (_pendingSpeakQueue.Count == 0)
                    {
                        _currentPrompt = null;
                        if (State != SynthesizerState.Paused)
                        {
                            SynthesizerState synthesizerState = _synthesizerState;
                            _synthesizerState = SynthesizerState.Ready;
                            InjectEvent(TtsEventId.EndInputStream, prompt, exception, null);
                            if (_eventStateChanged != null)
                            {
                                _asyncWorker.PostOperation(_eventStateChanged, new StateChangedEventArgs(_synthesizerState, synthesizerState));
                            }
                        }
                        else
                        {
                            InjectEvent(TtsEventId.EndInputStream, prompt, exception, null);
                        }
                    }
                    else
                    {
                        InjectEvent(TtsEventId.EndInputStream, prompt, exception, null);
                    }
                }
            }
        }

        private TTSVoice GetVoice(VoiceInfo voiceInfo, bool switchContext)
        {
            TTSVoice value = null;
            lock (_voiceDictionary)
            {
                if (!_voiceDictionary.TryGetValue(voiceInfo, out value))
                {
                    if (switchContext)
                    {
                        ExecuteOnBackgroundThread(Action.GetVoice, voiceInfo);
                        return (_pendingException == null) ? _pendingVoice : null;
                    }
                    return GetProxyEngine(voiceInfo);
                }
                return value;
            }
        }

        private void ExecuteOnBackgroundThread(Action action, object parameter)
        {
            lock (_pendingSpeakQueue)
            {
                _evtPendingGetProxy.Reset();
                _pendingSpeakQueue.Enqueue(new Parameters(action, parameter));
                if (_pendingSpeakQueue.Count == 1)
                {
                    _evtPendingSpeak.Set();
                }
            }
            _evtPendingGetProxy.WaitOne();
        }

        private TTSVoice GetEngineWithVoice(TTSVoice defaultVoice, VoiceInfo defaultVoiceId, string name, CultureInfo culture, VoiceGender gender, VoiceAge age, int variant, bool switchContext)
        {
            TTSVoice tTSVoice = null;
            lock (_enabledVoicesLock)
            {
                if (!string.IsNullOrEmpty(name))
                {
                    tTSVoice = MatchVoice(name, variant, switchContext);
                }
                if (tTSVoice == null)
                {
                    InstalledVoice viDefault = null;
                    if (defaultVoice != null || defaultVoiceId != null)
                    {
                        viDefault = InstalledVoice.Find(_installedVoices, (defaultVoice != null) ? defaultVoice.VoiceInfo : defaultVoiceId);
                        if (viDefault != null && viDefault.Enabled && variant == 1)
                        {
                            VoiceInfo voiceInfo = viDefault.VoiceInfo;
                            if (viDefault.Enabled && voiceInfo.Culture.Equals(culture) && (gender == VoiceGender.NotSet || gender == VoiceGender.Neutral || gender == voiceInfo.Gender) && (age == VoiceAge.NotSet || age == voiceInfo.Age))
                            {
                                tTSVoice = defaultVoice;
                            }
                        }
                    }
                    while (tTSVoice == null && _installedVoices.Count > 0)
                    {
                        if (viDefault == null)
                        {
                            viDefault = InstalledVoice.FirstEnabled(_installedVoices, CultureInfo.CurrentUICulture);
                        }
                        if (viDefault == null)
                        {
                            break;
                        }
                        tTSVoice = MatchVoice(culture, gender, age, variant, switchContext, ref viDefault);
                    }
                }
                if (tTSVoice == null)
                {
                    if (defaultVoice == null)
                    {
                        throw new InvalidOperationException(SR.Get(SRID.SynthesizerVoiceFailed));
                    }
                    return defaultVoice;
                }
                return tTSVoice;
            }
        }

        private TTSVoice MatchVoice(string name, int variant, bool switchContext)
        {
            TTSVoice result = null;
            VoiceInfo voiceInfo = null;
            int num = variant;
            foreach (InstalledVoice installedVoice in _installedVoices)
            {
                int num2;
                if (installedVoice.Enabled && (num2 = name.IndexOf(installedVoice.VoiceInfo.Name, StringComparison.Ordinal)) >= 0)
                {
                    int num3 = num2 + installedVoice.VoiceInfo.Name.Length;
                    if ((num2 == 0 || name[num2 - 1] == ' ') && (num3 == name.Length || name[num3] == ' '))
                    {
                        voiceInfo = installedVoice.VoiceInfo;
                        if (num-- == 1)
                        {
                            break;
                        }
                    }
                }
            }
            if (voiceInfo != null)
            {
                result = GetVoice(voiceInfo, switchContext);
            }
            return result;
        }

        private TTSVoice MatchVoice(CultureInfo culture, VoiceGender gender, VoiceAge age, int variant, bool switchContext, ref InstalledVoice viDefault)
        {
            TTSVoice tTSVoice = null;
            List<InstalledVoice> list = new List<InstalledVoice>(_installedVoices);
            for (int num = list.Count - 1; num >= 0; num--)
            {
                if (!list[num].Enabled)
                {
                    list.RemoveAt(num);
                }
            }
            while (tTSVoice == null && list.Count > 0)
            {
                InstalledVoice installedVoice = MatchVoice(viDefault, culture, gender, age, variant, list);
                if (installedVoice == null)
                {
                    continue;
                }
                tTSVoice = GetVoice(installedVoice.VoiceInfo, switchContext);
                if (tTSVoice == null)
                {
                    list.Remove(installedVoice);
                    installedVoice.SetEnabledFlag(false, switchContext);
                    if (installedVoice == viDefault)
                    {
                        viDefault = null;
                    }
                }
                break;
            }
            return tTSVoice;
        }

        private static InstalledVoice MatchVoice(InstalledVoice defaultTokenInfo, CultureInfo culture, VoiceGender gender, VoiceAge age, int variant, List<InstalledVoice> tokensInfo)
        {
            InstalledVoice installedVoice = defaultTokenInfo;
            int num = CalcMatchValue(culture, gender, age, installedVoice.VoiceInfo);
            int num2 = -1;
            for (int i = 0; i < tokensInfo.Count; i++)
            {
                InstalledVoice installedVoice2 = tokensInfo[i];
                if (installedVoice2.Enabled)
                {
                    int num3 = CalcMatchValue(culture, gender, age, installedVoice2.VoiceInfo);
                    if (installedVoice2.Equals(defaultTokenInfo))
                    {
                        num2 = i;
                    }
                    if (num3 > num)
                    {
                        installedVoice = installedVoice2;
                        num = num3;
                    }
                    if (num3 == 7 && (variant == 1 || num2 >= 0))
                    {
                        break;
                    }
                }
            }
            if (variant > 1)
            {
                tokensInfo[num2] = tokensInfo[0];
                tokensInfo[0] = defaultTokenInfo;
                int num4 = variant;
                do
                {
                    foreach (InstalledVoice item in tokensInfo)
                    {
                        if (item.Enabled && CalcMatchValue(culture, gender, age, item.VoiceInfo) == num)
                        {
                            variant--;
                            installedVoice = item;
                        }
                        if (variant == 0)
                        {
                            break;
                        }
                    }
                    if (variant > 0)
                    {
                        variant = num4 % (num4 - variant);
                    }
                }
                while (variant > 0);
            }
            return installedVoice;
        }

        private static int CalcMatchValue(CultureInfo culture, VoiceGender gender, VoiceAge age, VoiceInfo voiceInfo)
        {
            int num;
            if (voiceInfo != null)
            {
                num = 0;
                CultureInfo culture2 = voiceInfo.Culture;
                if (culture != null && Helpers.CompareInvariantCulture(culture2, culture))
                {
                    if (culture.Equals(culture2))
                    {
                        num |= 4;
                    }
                    if (gender == VoiceGender.NotSet || voiceInfo.Gender == gender)
                    {
                        num |= 2;
                    }
                    if (age == VoiceAge.NotSet || voiceInfo.Age == age)
                    {
                        num |= 1;
                    }
                }
            }
            else
            {
                num = -1;
            }
            return num;
        }

        private TTSVoice GetProxyEngine(VoiceInfo voiceInfo)
        {
            ITtsEngineProxy ttsEngineProxy = GetSsmlEngine(voiceInfo);
            if (ttsEngineProxy == null)
            {
                ttsEngineProxy = GetComEngine(voiceInfo);
            }
            TTSVoice tTSVoice = null;
            if (ttsEngineProxy != null)
            {
                tTSVoice = new TTSVoice(ttsEngineProxy, voiceInfo);
                _voiceDictionary.Add(voiceInfo, tTSVoice);
            }
            return tTSVoice;
        }

        private ITtsEngineProxy GetSsmlEngine(VoiceInfo voiceInfo)
        {
            ITtsEngineProxy result = null;
            try
            {
                if (string.IsNullOrEmpty(voiceInfo.AssemblyName))
                {
                    return result;
                }
                Assembly assembly;
                if (!((assembly = Assembly.Load(voiceInfo.AssemblyName)) != null))
                {
                    return result;
                }
                Type[] types = assembly.GetTypes();
                TtsEngineSsml ttsEngineSsml = null;
                Type[] array = types;
                foreach (Type type in array)
                {
                    if (type.IsSubclassOf(typeof(TtsEngineSsml)))
                    {
                        string[] args = new string[1]
                        {
                            voiceInfo.Clsid
                        };
                        ttsEngineSsml = (assembly.CreateInstance(type.ToString(), false, BindingFlags.Default, null, args, CultureInfo.CurrentUICulture, null) as TtsEngineSsml);
                        break;
                    }
                }
                if (ttsEngineSsml == null)
                {
                    return result;
                }
                result = new TtsProxySsml(ttsEngineSsml, _site, voiceInfo.Culture.LCID);
                return result;
            }
            catch (ArgumentException)
            {
                return result;
            }
            catch (IOException)
            {
                return result;
            }
            catch (BadImageFormatException)
            {
                return result;
            }
        }

        private ITtsEngineProxy GetComEngine(VoiceInfo voiceInfo)
        {
            ITtsEngineProxy result = null;
            try
            {
                ObjectToken objectToken = ObjectToken.Open(null, voiceInfo.RegistryKeyPath, false);
                if (objectToken == null)
                {
                    return result;
                }
                object obj = objectToken.CreateObjectFromToken<object>("CLSID");
                if (obj == null)
                {
                    return result;
                }
                ITtsEngineSsml ttsEngineSsml = obj as ITtsEngineSsml;
                if (ttsEngineSsml == null)
                {
                    ITtsEngine ttsEngine = obj as ITtsEngine;
                    if (ttsEngine == null)
                    {
                        return result;
                    }
                    result = new TtsProxySapi(ttsEngine, ComEngineSite, voiceInfo.Culture.LCID);
                    return result;
                }
                result = new TtsProxyCom(ttsEngineSsml, ComEngineSite, voiceInfo.Culture.LCID);
                return result;
            }
            catch (ArgumentException)
            {
                return result;
            }
            catch (IOException)
            {
                return result;
            }
            catch (BadImageFormatException)
            {
                return result;
            }
            catch (COMException)
            {
                return result;
            }
            catch (FormatException)
            {
                return result;
            }
        }

        private TTSVoice GetVoice(bool switchContext)
        {
            lock (_defaultVoiceLock)
            {
                if (!_defaultVoiceInitialized)
                {
                    _defaultVoice = null;
                    ObjectToken objectToken = SAPICategories.DefaultToken("Voices");
                    if (objectToken != null)
                    {
                        VoiceGender gender = VoiceGender.NotSet;
                        VoiceAge age = VoiceAge.NotSet;
                        SsmlParserHelpers.TryConvertGender(objectToken.Gender.ToLowerInvariant(), out gender);
                        SsmlParserHelpers.TryConvertAge(objectToken.Age.ToLowerInvariant(), out age);
                        _defaultVoice = GetEngineWithVoice(null, new VoiceInfo(objectToken), objectToken.TokenName(), objectToken.Culture, gender, age, 1, switchContext);
                        objectToken = null;
                    }
                    if (_defaultVoice == null)
                    {
                        VoiceInfo defaultVoiceId = (objectToken != null) ? new VoiceInfo(objectToken) : null;
                        _defaultVoice = GetEngineWithVoice(null, defaultVoiceId, null, CultureInfo.CurrentUICulture, VoiceGender.NotSet, VoiceAge.NotSet, 1, switchContext);
                    }
                    _defaultVoiceInitialized = true;
                    _currentVoice = _defaultVoice;
                }
            }
            return _defaultVoice;
        }

        private static List<InstalledVoice> BuildInstalledVoices(VoiceSynthesis voiceSynthesizer)
        {
            List<InstalledVoice> list = new List<InstalledVoice>();
            using (ObjectTokenCategory objectTokenCategory = ObjectTokenCategory.Create("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Speech\\Voices"))
            {
                if (objectTokenCategory != null)
                {
                    foreach (ObjectToken item in objectTokenCategory.FindMatchingTokens(null, null))
                    {
                        if (item != null && item.Attributes != null)
                        {
                            list.Add(new InstalledVoice(voiceSynthesizer, new VoiceInfo(item)));
                        }
                    }
                    return list;
                }
                return list;
            }
        }

        private void SignalWorkerThread(object ignored)
        {
            if (!_asyncWorkerUI.AsyncMode)
            {
                _workerWaitHandle.Set();
            }
        }

        private void ProcessPostData(object arg)
        {
            TTSEvent tTSEvent = arg as TTSEvent;
            if (tTSEvent != null)
            {
                lock (_thisObjectLock)
                {
                    if (!_isDisposed)
                    {
                        DispatchEvent(tTSEvent);
                    }
                }
            }
        }

        private void DispatchEvent(TTSEvent ttsEvent)
        {
            Prompt prompt = ttsEvent.Prompt;
            TtsEventId id = ttsEvent.Id;
            prompt._exception = ttsEvent.Exception;
            switch (id)
            {
                case TtsEventId.SentenceBoundary:
                    break;
                case TtsEventId.StartInputStream:
                    OnSpeakStarted(new SpeakStartedEventArgs(prompt));
                    break;
                case TtsEventId.EndInputStream:
                    OnSpeakCompleted(new SpeakCompletedEventArgs(prompt));
                    break;
                case TtsEventId.WordBoundary:
                    OnSpeakProgress(new SpeakProgressEventArgs(prompt, ttsEvent.AudioPosition, (int)ttsEvent.LParam, (int)ttsEvent.WParam));
                    break;
                case TtsEventId.Bookmark:
                    OnBookmarkReached(new BookmarkReachedEventArgs(prompt, ttsEvent.Bookmark, ttsEvent.AudioPosition));
                    break;
                case TtsEventId.VoiceChange:
                    {
                        VoiceInfo voice = ttsEvent.Voice;
                        OnVoiceChange(new VoiceChangeEventArgs(prompt, voice));
                        break;
                    }
                case TtsEventId.Phoneme:
                    OnPhonemeReached(new PhonemeReachedEventArgs(prompt, ttsEvent.Phoneme, ttsEvent.AudioPosition, ttsEvent.PhonemeDuration, ttsEvent.PhonemeEmphasis, ttsEvent.NextPhoneme));
                    break;
                case TtsEventId.Viseme:
                    OnVisemeReached(new VisemeReachedEventArgs(prompt, (int)ttsEvent.LParam & 0xFFFF, ttsEvent.AudioPosition, TimeSpan.FromMilliseconds(ttsEvent.WParam >> 16), (SynthesizerEmphasis)((uint)(int)ttsEvent.LParam >> 16), (int)(ttsEvent.WParam & 0xFFFF)));
                    break;
                default:
                    throw new InvalidOperationException(SR.Get(SRID.SynthesizerUnknownEvent));
            }
        }

        private void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                lock (_thisObjectLock)
                {
                    _fExitWorkerThread = true;
                    Abort();
                    for (int i = 0; i < 20; i++)
                    {
                        if (State == SynthesizerState.Ready)
                        {
                            break;
                        }
                        Thread.Sleep(100);
                    }
                    if (disposing)
                    {
                        _evtPendingSpeak.Set();
                        _workerThread.Join();
                        foreach (KeyValuePair<VoiceInfo, TTSVoice> item in _voiceDictionary)
                        {
                            if (item.Value != null)
                            {
                                item.Value.TtsEngine.ReleaseInterface();
                            }
                        }
                        _voiceDictionary.Clear();
                        _evtPendingSpeak.Close();
                        _evtPendingGetProxy.Close();
                        _workerWaitHandle.Close();
                    }
                    if (_iSite != IntPtr.Zero)
                    {
                        Marshal.Release(_iSite);
                    }
                    _isDisposed = true;
                }
            }
        }

        private void QueuePrompt(Prompt prompt)
        {
            switch (prompt._media)
            {
                case SynthesisMediaType.Text:
                    Speak(prompt._text, prompt, false);
                    break;
                case SynthesisMediaType.Ssml:
                    Speak(prompt._text, prompt, true);
                    break;
                case SynthesisMediaType.WaveAudio:
                    SpeakStream(prompt._audio, prompt);
                    break;
                default:
                    throw new ArgumentException(SR.Get(SRID.SynthesizerUnknownMediaType));
            }
        }

        private void Speak(string textToSpeak, Prompt prompt, bool fIsXml)
        {
            Helpers.ThrowIfNull(textToSpeak, "textToSpeak");
            if (_isDisposed)
            {
                throw new ObjectDisposedException("VoiceSynthesis");
            }
            AddSpeakParameters(new Parameters(Action.SpeakText, new ParametersSpeak(textToSpeak, prompt, fIsXml, null)));
        }

        private void SpeakStream(Uri audio, Prompt prompt)
        {
            AddSpeakParameters(new Parameters(Action.SpeakText, new ParametersSpeak(null, prompt, false, audio)));
        }

        private void SetInterest(int ttsInterest)
        {
            _ttsInterest = ttsInterest;
            lock (_pendingSpeakQueue)
            {
                _site.SetEventsInterest(_ttsInterest);
            }
        }
    }
}