#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

#define TRACE
using Krypton.Toolkit.Suite.Extended.Utilities.System.AudioFormat;
using Krypton.Toolkit.Suite.Extended.Utilities.System.Internal;
using Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop;
using Krypton.Toolkit.Suite.Extended.Utilities.SystemInternal.Speech;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Recognition
{
    internal class RecognizerBase : IRecognizerInternal, IDisposable, ISpGrammarResourceLoader
    {
        private class RecognizerBaseThunk : ISpGrammarResourceLoader
        {
            private WeakReference _recognizerRef;

            internal RecognizerBase Recognizer => (RecognizerBase)_recognizerRef.Target;

            internal RecognizerBaseThunk(RecognizerBase recognizer)
            {
                _recognizerRef = new WeakReference(recognizer);
            }

            int ISpGrammarResourceLoader.LoadResource(string bstrResourceUri, bool fAlwaysReload, out IStream pStream, ref string pbstrMIMEType, ref short pfModified, ref string pbstrRedirectUrl)
            {
                return ((ISpGrammarResourceLoader)Recognizer).LoadResource(bstrResourceUri, fAlwaysReload, out pStream, ref pbstrMIMEType, ref pfModified, ref pbstrRedirectUrl);
            }

            string ISpGrammarResourceLoader.GetLocalCopy(Uri resourcePath, out string mimeType, out Uri redirectUrl)
            {
                return ((ISpGrammarResourceLoader)Recognizer).GetLocalCopy(resourcePath, out mimeType, out redirectUrl);
            }

            void ISpGrammarResourceLoader.ReleaseLocalCopy(string path)
            {
                ((ISpGrammarResourceLoader)Recognizer).ReleaseLocalCopy(path);
            }
        }

        private List<Grammar> _grammars;

        private ReadOnlyCollection<Grammar> _readOnlyGrammars;

        private RecognizerInfo _recognizerInfo;

        private bool _disposed;

        private ulong _currentGrammarId;

        private SapiRecoContext _sapiContext;

        private SapiRecognizer _sapiRecognizer;

        private bool _supportsSapi53;

        private EventNotify _eventNotify;

        private ulong _eventInterest;

        private EventHandler<AudioSignalProblemOccurredEventArgs> _audioSignalProblemOccurredDelegate;

        private EventHandler<AudioLevelUpdatedEventArgs> _audioLevelUpdatedDelegate;

        private EventHandler<AudioStateChangedEventArgs> _audioStateChangedDelegate;

        private EventHandler<SpeechHypothesizedEventArgs> _speechHypothesizedDelegate;

        private bool _enabled = true;

        private int _maxAlternates;

        internal AudioState _audioState;

        private SpeechAudioFormatInfo _audioFormat;

        private RecognizeMode _recognizeMode = RecognizeMode.Multiple;

        private bool _isRecognizeCancelled;

        private bool _isRecognizing;

        private bool _isEmulateRecognition;

        private bool _isWaitingForRecognition;

        private RecognitionResult _lastResult;

        private Exception _lastException;

        private bool _pauseRecognizerOnRecognition = true;

        private bool _detectingInitialSilenceTimeout;

        private bool _detectingBabbleTimeout;

        private bool _initialSilenceTimeoutReached;

        private bool _babbleTimeoutReached;

        private TimeSpan _initialSilenceTimeout;

        private TimeSpan _babbleTimeout;

        internal bool _haveInputSource;

        private Stream _inputStream;

        private Dictionary<int, object> _bookmarkTable = new Dictionary<int, object>();

        private uint _nextBookmarkId = 3u;

        private uint _prevMaxBookmarkId = 2u;

        private OperationLock _waitForGrammarsToLoad = new OperationLock();

        private object _grammarDataLock = new object();

        private const uint _nullBookmarkId = 0u;

        private const uint _initialSilenceBookmarkId = 1u;

        private const uint _babbleBookmarkId = 2u;

        private const uint _firstUnusedBookmarkId = 3u;

        private AsyncSerializedWorker _asyncWorker;

        private AsyncSerializedWorker _asyncWorkerUI;

        private AutoResetEvent _handlerWaitHandle = new AutoResetEvent(false);

        private object _thisObjectLock = new object();

        private Exception _loadException;

        private Grammar _topLevel;

        private bool _inproc;

        private TimeSpan _defaultTimeout = TimeSpan.FromSeconds(30.0);

        private RecognizerBaseThunk _recoThunk;

        internal bool PauseRecognizerOnRecognition
        {
            get
            {
                return _pauseRecognizerOnRecognition;
            }
            set
            {
                if (value != _pauseRecognizerOnRecognition)
                {
                    _pauseRecognizerOnRecognition = value;
                    lock (SapiRecognizer)
                    {
                        foreach (Grammar grammar in _grammars)
                        {
                            SapiGrammar sapiGrammar = grammar.InternalData._sapiGrammar;
                            ActivateRule(sapiGrammar, grammar.Uri, grammar.RuleName);
                        }
                    }
                }
            }
        }

        internal TimeSpan InitialSilenceTimeout
        {
            get
            {
                lock (SapiRecognizer)
                {
                    return _initialSilenceTimeout;
                }
            }
            set
            {
                if (value < TimeSpan.Zero)
                {
                    throw new ArgumentOutOfRangeException("value", SR.Get(SRID.NegativeTimesNotSupported));
                }
                lock (SapiRecognizer)
                {
                    if (_isRecognizing)
                    {
                        throw new InvalidOperationException(SR.Get(SRID.RecognizerAlreadyRecognizing));
                    }
                    _initialSilenceTimeout = value;
                }
            }
        }

        internal TimeSpan BabbleTimeout
        {
            get
            {
                lock (SapiRecognizer)
                {
                    return _babbleTimeout;
                }
            }
            set
            {
                if (value < TimeSpan.Zero)
                {
                    throw new ArgumentOutOfRangeException("value", SR.Get(SRID.NegativeTimesNotSupported));
                }
                lock (SapiRecognizer)
                {
                    if (_isRecognizing)
                    {
                        throw new InvalidOperationException(SR.Get(SRID.RecognizerAlreadyRecognizing));
                    }
                    _babbleTimeout = value;
                }
            }
        }

        internal RecognizerState State
        {
            get
            {
                try
                {
                    SPRECOSTATE recoState = SapiRecognizer.GetRecoState();
                    if (recoState == SPRECOSTATE.SPRST_ACTIVE || recoState == SPRECOSTATE.SPRST_ACTIVE_ALWAYS)
                    {
                        return RecognizerState.Listening;
                    }
                    return RecognizerState.Stopped;
                }
                catch (COMException e)
                {
                    throw ExceptionFromSapiCreateRecognizerError(e);
                }
            }
        }

        internal bool Enabled
        {
            get
            {
                lock (SapiRecognizer)
                {
                    return _enabled;
                }
            }
            set
            {
                lock (SapiRecognizer)
                {
                    if (value != _enabled)
                    {
                        try
                        {
                            SapiContext.SetContextState(value ? SPCONTEXTSTATE.SPCS_ENABLED : SPCONTEXTSTATE.SPCS_DISABLED);
                            _enabled = value;
                        }
                        catch (COMException e)
                        {
                            throw ExceptionFromSapiCreateRecognizerError(e);
                        }
                    }
                }
            }
        }

        internal ReadOnlyCollection<Grammar> Grammars => _readOnlyGrammars;

        internal RecognizerInfo RecognizerInfo
        {
            get
            {
                if (_recognizerInfo == null)
                {
                    try
                    {
                        _recognizerInfo = SapiRecognizer.GetRecognizerInfo();
                    }
                    catch (COMException e)
                    {
                        throw ExceptionFromSapiCreateRecognizerError(e);
                    }
                }
                return _recognizerInfo;
            }
        }

        internal AudioState AudioState
        {
            get
            {
                if (!_haveInputSource)
                {
                    return AudioState.Stopped;
                }
                return _audioState;
            }
            set
            {
                _audioState = value;
            }
        }

        internal int AudioLevel
        {
            get
            {
                int result = 0;
                if (_haveInputSource)
                {
                    try
                    {
                        SPRECOGNIZERSTATUS status = SapiRecognizer.GetStatus();
                        lock (SapiRecognizer)
                        {
                            if (_supportsSapi53)
                            {
                                return (int)status.AudioStatus.dwAudioLevel;
                            }
                            return 0;
                        }
                    }
                    catch (COMException e)
                    {
                        throw ExceptionFromSapiCreateRecognizerError(e);
                    }
                }
                return result;
            }
        }

        internal TimeSpan AudioPosition
        {
            get
            {
                if (!_haveInputSource)
                {
                    return TimeSpan.Zero;
                }
                try
                {
                    SPRECOGNIZERSTATUS status = SapiRecognizer.GetStatus();
                    lock (SapiRecognizer)
                    {
                        SpeechAudioFormatInfo audioFormat = AudioFormat;
                        return (audioFormat.AverageBytesPerSecond > 0) ? new TimeSpan((long)(status.AudioStatus.CurDevicePos * 10000000 / (ulong)audioFormat.AverageBytesPerSecond)) : TimeSpan.Zero;
                    }
                }
                catch (COMException e)
                {
                    throw ExceptionFromSapiCreateRecognizerError(e);
                }
            }
        }

        internal TimeSpan RecognizerAudioPosition
        {
            get
            {
                if (!_haveInputSource)
                {
                    return TimeSpan.Zero;
                }
                try
                {
                    SPRECOGNIZERSTATUS status = SapiRecognizer.GetStatus();
                    lock (SapiRecognizer)
                    {
                        return new TimeSpan((long)status.ullRecognitionStreamTime);
                    }
                }
                catch (COMException e)
                {
                    throw ExceptionFromSapiCreateRecognizerError(e);
                }
            }
        }

        internal SpeechAudioFormatInfo AudioFormat
        {
            get
            {
                lock (SapiRecognizer)
                {
                    if (!_haveInputSource)
                    {
                        return null;
                    }
                    if (_audioFormat == null)
                    {
                        _audioFormat = GetSapiAudioFormat();
                    }
                }
                return _audioFormat;
            }
        }

        internal int MaxAlternates
        {
            get
            {
                return _maxAlternates;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", SR.Get(SRID.MaxAlternatesInvalid));
                }
                if (value != _maxAlternates)
                {
                    SapiContext.SetMaxAlternates((uint)value);
                    _maxAlternates = value;
                }
            }
        }

        private SapiRecoContext SapiContext
        {
            get
            {
                if (_disposed)
                {
                    throw new ObjectDisposedException("RecognizerBase");
                }
                return _sapiContext;
            }
        }

        private SapiRecognizer SapiRecognizer
        {
            get
            {
                if (_disposed)
                {
                    throw new ObjectDisposedException("RecognizerBase");
                }
                return _sapiRecognizer;
            }
        }

        internal event EventHandler<RecognizeCompletedEventArgs> RecognizeCompleted;

        internal event EventHandler<EmulateRecognizeCompletedEventArgs> EmulateRecognizeCompleted;

        internal event EventHandler<StateChangedEventArgs> StateChanged;

        internal event EventHandler<LoadGrammarCompletedEventArgs> LoadGrammarCompleted;

        internal event EventHandler<SpeechDetectedEventArgs> SpeechDetected;

        internal event EventHandler<SpeechRecognizedEventArgs> SpeechRecognized;

        internal event EventHandler<SpeechRecognitionRejectedEventArgs> SpeechRecognitionRejected;

        internal event EventHandler<SpeechHypothesizedEventArgs> SpeechHypothesized
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            add
            {
                if (_speechHypothesizedDelegate == null)
                {
                    AddEventInterest(549755813888uL);
                }
                _speechHypothesizedDelegate = (EventHandler<SpeechHypothesizedEventArgs>)Delegate.Combine(_speechHypothesizedDelegate, value);
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            remove
            {
                _speechHypothesizedDelegate = (EventHandler<SpeechHypothesizedEventArgs>)Delegate.Remove(_speechHypothesizedDelegate, value);
                if (_speechHypothesizedDelegate == null)
                {
                    RemoveEventInterest(549755813888uL);
                }
            }
        }

        internal event EventHandler<AudioSignalProblemOccurredEventArgs> AudioSignalProblemOccurred
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            add
            {
                if (_audioSignalProblemOccurredDelegate == null)
                {
                    AddEventInterest(17592186044416uL);
                }
                _audioSignalProblemOccurredDelegate = (EventHandler<AudioSignalProblemOccurredEventArgs>)Delegate.Combine(_audioSignalProblemOccurredDelegate, value);
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            remove
            {
                _audioSignalProblemOccurredDelegate = (EventHandler<AudioSignalProblemOccurredEventArgs>)Delegate.Remove(_audioSignalProblemOccurredDelegate, value);
                if (_audioSignalProblemOccurredDelegate == null)
                {
                    RemoveEventInterest(17592186044416uL);
                }
            }
        }

        internal event EventHandler<AudioLevelUpdatedEventArgs> AudioLevelUpdated
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            add
            {
                if (_audioLevelUpdatedDelegate == null)
                {
                    AddEventInterest(1125899906842624uL);
                }
                _audioLevelUpdatedDelegate = (EventHandler<AudioLevelUpdatedEventArgs>)Delegate.Combine(_audioLevelUpdatedDelegate, value);
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            remove
            {
                _audioLevelUpdatedDelegate = (EventHandler<AudioLevelUpdatedEventArgs>)Delegate.Remove(_audioLevelUpdatedDelegate, value);
                if (_audioLevelUpdatedDelegate == null)
                {
                    RemoveEventInterest(1125899906842624uL);
                }
            }
        }

        internal event EventHandler<AudioStateChangedEventArgs> AudioStateChanged
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            add
            {
                _audioStateChangedDelegate = (EventHandler<AudioStateChangedEventArgs>)Delegate.Combine(_audioStateChangedDelegate, value);
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            remove
            {
                _audioStateChangedDelegate = (EventHandler<AudioStateChangedEventArgs>)Delegate.Remove(_audioStateChangedDelegate, value);
            }
        }

        internal event EventHandler<RecognizerUpdateReachedEventArgs> RecognizerUpdateReached;

        private event EventHandler<RecognizeCompletedEventArgs> RecognizeCompletedSync;

        private event EventHandler<EmulateRecognizeCompletedEventArgs> EmulateRecognizeCompletedSync;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~RecognizerBase()
        {
            Dispose(false);
        }

        internal void LoadGrammar(Grammar grammar)
        {
            try
            {
                ValidateGrammar(grammar, default(GrammarState));
                if (!_supportsSapi53)
                {
                    CheckGrammarOptionsOnSapi51(grammar);
                }
                ulong grammarId;
                SapiGrammar sapiGrammar = CreateNewSapiGrammar(out grammarId);
                try
                {
                    LoadSapiGrammar(grammar, sapiGrammar, grammar.Enabled, grammar.Weight, grammar.Priority);
                }
                catch
                {
                    sapiGrammar.Dispose();
                    grammar.State = GrammarState.Unloaded;
                    grammar.InternalData = null;
                    throw;
                }
                grammar.InternalData = new InternalGrammarData(grammarId, sapiGrammar, grammar.Enabled, grammar.Weight, grammar.Priority);
                lock (SapiRecognizer)
                {
                    _grammars.Add(grammar);
                }
                grammar.Recognizer = this;
                grammar.State = GrammarState.Loaded;
            }
            catch (Exception loadException)
            {
                Exception ex = _loadException = loadException;
                throw;
            }
        }

        internal void LoadGrammarAsync(Grammar grammar)
        {
            if (!_supportsSapi53)
            {
                CheckGrammarOptionsOnSapi51(grammar);
            }
            ValidateGrammar(grammar, default(GrammarState));
            ulong grammarId;
            SapiGrammar sapiGrammar = CreateNewSapiGrammar(out grammarId);
            grammar.InternalData = new InternalGrammarData(grammarId, sapiGrammar, grammar.Enabled, grammar.Weight, grammar.Priority);
            lock (SapiRecognizer)
            {
                _grammars.Add(grammar);
            }
            grammar.Recognizer = this;
            grammar.State = GrammarState.Loading;
            _waitForGrammarsToLoad.StartOperation();
            if (!ThreadPool.QueueUserWorkItem(LoadGrammarAsyncCallback, grammar))
            {
                throw new OperationCanceledException(SR.Get(SRID.OperationAborted));
            }
        }

        internal void UnloadGrammar(Grammar grammar)
        {
            ValidateGrammar(grammar, GrammarState.Loaded, GrammarState.LoadFailed);
            grammar.InternalData?._sapiGrammar.Dispose();
            lock (SapiRecognizer)
            {
                _grammars.Remove(grammar);
            }
            grammar.State = GrammarState.Unloaded;
            grammar.InternalData = null;
        }

        internal void UnloadAllGrammars()
        {
            List<Grammar> list;
            lock (SapiRecognizer)
            {
                list = new List<Grammar>(_grammars);
            }
            _waitForGrammarsToLoad.WaitForOperationsToFinish();
            foreach (Grammar item in list)
            {
                UnloadGrammar(item);
            }
        }

        void IRecognizerInternal.SetGrammarState(Grammar grammar, bool enabled)
        {
            InternalGrammarData internalData = grammar.InternalData;
            lock (_grammarDataLock)
            {
                if (grammar.Loaded)
                {
                    internalData._sapiGrammar.SetGrammarState(enabled ? SPGRAMMARSTATE.SPGS_ENABLED : SPGRAMMARSTATE.SPGS_DISABLED);
                }
                internalData._grammarEnabled = enabled;
            }
        }

        void IRecognizerInternal.SetGrammarWeight(Grammar grammar, float weight)
        {
            if (!_supportsSapi53)
            {
                throw new NotSupportedException(SR.Get(SRID.NotSupportedWithThisVersionOfSAPI2, "Weight"));
            }
            InternalGrammarData internalData = grammar.InternalData;
            lock (_grammarDataLock)
            {
                if (grammar.Loaded)
                {
                    if (grammar.IsDictation(grammar.Uri))
                    {
                        internalData._sapiGrammar.SetDictationWeight(weight);
                    }
                    else
                    {
                        internalData._sapiGrammar.SetRuleWeight(grammar.RuleName, 0u, weight);
                    }
                }
                internalData._grammarWeight = weight;
            }
        }

        void IRecognizerInternal.SetGrammarPriority(Grammar grammar, int priority)
        {
            if (!_supportsSapi53)
            {
                throw new NotSupportedException(SR.Get(SRID.NotSupportedWithThisVersionOfSAPI2, "Priority"));
            }
            InternalGrammarData internalData = grammar.InternalData;
            lock (_grammarDataLock)
            {
                if (grammar.Loaded)
                {
                    if (grammar.IsDictation(grammar.Uri))
                    {
                        throw new NotSupportedException(SR.Get(SRID.CannotSetPriorityOnDictation));
                    }
                    internalData._sapiGrammar.SetRulePriority(grammar.RuleName, 0u, priority);
                }
                internalData._grammarPriority = priority;
            }
        }

        Grammar IRecognizerInternal.GetGrammarFromId(ulong id)
        {
            lock (SapiRecognizer)
            {
                foreach (Grammar grammar in _grammars)
                {
                    InternalGrammarData internalData = grammar.InternalData;
                    if (internalData._grammarId == id)
                    {
                        return grammar;
                    }
                }
            }
            return null;
        }

        void IRecognizerInternal.SetDictationContext(Grammar grammar, string precedingText, string subsequentText)
        {
            if (precedingText == null)
            {
                precedingText = string.Empty;
            }
            if (subsequentText == null)
            {
                subsequentText = string.Empty;
            }
            SPTEXTSELECTIONINFO info = new SPTEXTSELECTIONINFO(0u, 0u, (uint)precedingText.Length, 0u);
            string text = precedingText + subsequentText + "\0\0";
            SapiGrammar sapiGrammar = grammar.InternalData._sapiGrammar;
            sapiGrammar.SetWordSequenceData(text, info);
        }

        internal RecognitionResult EmulateRecognize(string inputText)
        {
            Helpers.ThrowIfEmptyOrNull(inputText, "inputText");
            return InternalEmulateRecognize(inputText, SpeechEmulationCompareFlags.SECFDefault, false, null);
        }

        internal void EmulateRecognizeAsync(string inputText)
        {
            Helpers.ThrowIfEmptyOrNull(inputText, "inputText");
            InternalEmulateRecognizeAsync(inputText, SpeechEmulationCompareFlags.SECFDefault, false, null);
        }

        internal RecognitionResult EmulateRecognize(string inputText, CompareOptions compareOptions)
        {
            Helpers.ThrowIfEmptyOrNull(inputText, "inputText");
            bool flag = compareOptions == CompareOptions.IgnoreCase || compareOptions == CompareOptions.OrdinalIgnoreCase;
            if (!_supportsSapi53 && !flag)
            {
                throw new NotSupportedException(SR.Get(SRID.NotSupportedWithThisVersionOfSAPICompareOption));
            }
            return InternalEmulateRecognize(inputText, ConvertCompareOptions(compareOptions), !flag, null);
        }

        internal void EmulateRecognizeAsync(string inputText, CompareOptions compareOptions)
        {
            Helpers.ThrowIfEmptyOrNull(inputText, "inputText");
            bool flag = compareOptions == CompareOptions.IgnoreCase || compareOptions == CompareOptions.OrdinalIgnoreCase;
            if (!_supportsSapi53 && !flag)
            {
                throw new NotSupportedException(SR.Get(SRID.NotSupportedWithThisVersionOfSAPICompareOption));
            }
            InternalEmulateRecognizeAsync(inputText, ConvertCompareOptions(compareOptions), !flag, null);
        }

        internal RecognitionResult EmulateRecognize(RecognizedWordUnit[] wordUnits, CompareOptions compareOptions)
        {
            if (!_supportsSapi53)
            {
                throw new NotSupportedException(SR.Get(SRID.NotSupportedWithThisVersionOfSAPI));
            }
            Helpers.ThrowIfNull(wordUnits, "wordUnits");
            foreach (RecognizedWordUnit recognizedWordUnit in wordUnits)
            {
                if (recognizedWordUnit == null)
                {
                    throw new ArgumentException(SR.Get(SRID.ArrayOfNullIllegal), "wordUnits");
                }
            }
            return InternalEmulateRecognize(null, ConvertCompareOptions(compareOptions), true, wordUnits);
        }

        internal void EmulateRecognizeAsync(RecognizedWordUnit[] wordUnits, CompareOptions compareOptions)
        {
            if (!_supportsSapi53)
            {
                throw new NotSupportedException(SR.Get(SRID.NotSupportedWithThisVersionOfSAPI));
            }
            Helpers.ThrowIfNull(wordUnits, "wordUnits");
            foreach (RecognizedWordUnit recognizedWordUnit in wordUnits)
            {
                if (recognizedWordUnit == null)
                {
                    throw new ArgumentException(SR.Get(SRID.ArrayOfNullIllegal), "wordUnits");
                }
            }
            InternalEmulateRecognizeAsync(null, ConvertCompareOptions(compareOptions), true, wordUnits);
        }

        internal void RequestRecognizerUpdate()
        {
            RequestRecognizerUpdate(null);
        }

        internal void RequestRecognizerUpdate(object userToken)
        {
            uint num = AddBookmarkItem(userToken);
            SapiContext.Bookmark(SPBOOKMARKOPTIONS.SPBO_PAUSE, 0uL, new IntPtr(num));
        }

        internal void RequestRecognizerUpdate(object userToken, TimeSpan audioPositionAheadToRaiseUpdate)
        {
            if (audioPositionAheadToRaiseUpdate < TimeSpan.Zero)
            {
                throw new NotSupportedException(SR.Get(SRID.NegativeTimesNotSupported));
            }
            if (!_supportsSapi53)
            {
                throw new NotSupportedException(SR.Get(SRID.NotSupportedWithThisVersionOfSAPI));
            }
            uint num = AddBookmarkItem(userToken);
            SapiContext.Bookmark(SPBOOKMARKOPTIONS.SPBO_PAUSE | SPBOOKMARKOPTIONS.SPBO_AHEAD | SPBOOKMARKOPTIONS.SPBO_TIME_UNITS, (ulong)audioPositionAheadToRaiseUpdate.Ticks, new IntPtr(num));
        }

        internal void Initialize(SapiRecognizer recognizer, bool inproc)
        {
            _sapiRecognizer = recognizer;
            _inproc = inproc;
            _recoThunk = new RecognizerBaseThunk(this);
            try
            {
                _sapiContext = _sapiRecognizer.CreateRecoContext();
            }
            catch (COMException ex)
            {
                if (!_supportsSapi53 && ex.ErrorCode == -2147200966)
                {
                    throw new PlatformNotSupportedException(SR.Get(SRID.RecognitionNotSupported));
                }
                throw ExceptionFromSapiCreateRecognizerError(ex);
            }
            _supportsSapi53 = recognizer.IsSapi53;
            if (_supportsSapi53)
            {
                _sapiContext.SetGrammarOptions(SPGRAMMAROPTIONS.SPGO_ALL);
            }
            try
            {
                ISpPhoneticAlphabetSelection spPhoneticAlphabetSelection = _sapiContext as ISpPhoneticAlphabetSelection;
                if (spPhoneticAlphabetSelection != null)
                {
                    spPhoneticAlphabetSelection.SetAlphabetToUPS(true);
                }
                else
                {
                    Trace.TraceInformation("SAPI does not implement phonetic alphabet selection.");
                }
            }
            catch (COMException)
            {
                Trace.TraceError("Cannot force SAPI to set the alphabet to UPS");
            }
            _sapiContext.SetAudioOptions(SPAUDIOOPTIONS.SPAO_RETAIN_AUDIO, IntPtr.Zero, IntPtr.Zero);
            MaxAlternates = 10;
            ResetBookmarkTable();
            _eventInterest = 854759695187968uL;
            _sapiContext.SetInterest(_eventInterest, _eventInterest);
            _asyncWorker = new AsyncSerializedWorker(DispatchEvents, null);
            _asyncWorkerUI = new AsyncSerializedWorker(null, AsyncOperationManager.CreateOperation(null));
            _asyncWorkerUI.WorkItemPending += SignalHandlerThread;
            _eventNotify = _sapiContext.CreateEventNotify(_asyncWorker, _supportsSapi53);
            _grammars = new List<Grammar>();
            _readOnlyGrammars = new ReadOnlyCollection<Grammar>(_grammars);
            UpdateAudioFormat(null);
            InitialSilenceTimeout = TimeSpan.FromSeconds(30.0);
        }

        internal void RecognizeAsync(RecognizeMode mode)
        {
            lock (SapiRecognizer)
            {
                if (_isRecognizing)
                {
                    throw new InvalidOperationException(SR.Get(SRID.RecognizerAlreadyRecognizing));
                }
                if (!_haveInputSource)
                {
                    throw new InvalidOperationException(SR.Get(SRID.RecognizerNoInputSource));
                }
                _isRecognizing = true;
            }
            _recognizeMode = mode;
            if (_supportsSapi53)
            {
                if (!ThreadPool.QueueUserWorkItem(RecognizeAsyncWaitForGrammarsToLoad))
                {
                    throw new OperationCanceledException(SR.Get(SRID.OperationAborted));
                }
            }
            else
            {
                try
                {
                    SapiRecognizer.SetRecoState(SPRECOSTATE.SPRST_ACTIVE_ALWAYS);
                }
                catch (COMException ex)
                {
                    throw ExceptionFromSapiStreamError((SAPIErrorCodes)ex.ErrorCode);
                }
                catch
                {
                    throw;
                }
            }
        }

        internal RecognitionResult Recognize(TimeSpan initialSilenceTimeout)
        {
            RecognitionResult result = null;
            bool completed = false;
            bool flag = false;
            bool flag2 = false;
            EventHandler<RecognizeCompletedEventArgs> value = delegate (object sender, RecognizeCompletedEventArgs eventArgs)
            {
                result = eventArgs.Result;
                completed = true;
            };
            TimeSpan initialSilenceTimeout2 = _initialSilenceTimeout;
            InitialSilenceTimeout = initialSilenceTimeout;
            RecognizeCompletedSync += value;
            TimeSpan timeout = TimeSpan.FromTicks(Math.Max(initialSilenceTimeout.Ticks, _defaultTimeout.Ticks));
            try
            {
                _asyncWorkerUI.AsyncMode = false;
                RecognizeAsync(RecognizeMode.Single);
                while (!completed && !_disposed)
                {
                    if (!flag2)
                    {
                        flag = _handlerWaitHandle.WaitOne(timeout, false);
                        if (!flag)
                        {
                            EndRecognitionWithTimeout();
                            flag2 = true;
                        }
                    }
                    else
                    {
                        flag = _handlerWaitHandle.WaitOne(timeout, false);
                    }
                    if (flag)
                    {
                        _asyncWorkerUI.ConsumeQueue();
                    }
                }
            }
            finally
            {
                RecognizeCompletedSync -= value;
                _initialSilenceTimeout = initialSilenceTimeout2;
                _asyncWorkerUI.AsyncMode = true;
            }
            return result;
        }

        internal void RecognizeAsyncCancel()
        {
            bool flag = false;
            lock (SapiRecognizer)
            {
                if (_isRecognizing)
                {
                    if (!_isEmulateRecognition)
                    {
                        flag = true;
                        _isRecognizeCancelled = true;
                    }
                    else
                    {
                        _isRecognizing = (_isEmulateRecognition = false);
                    }
                }
            }
            if (flag)
            {
                try
                {
                    SapiRecognizer.SetRecoState(SPRECOSTATE.SPRST_INACTIVE_WITH_PURGE);
                }
                catch (COMException e)
                {
                    throw ExceptionFromSapiCreateRecognizerError(e);
                }
            }
        }

        internal void RecognizeAsyncStop()
        {
            bool flag = false;
            lock (SapiRecognizer)
            {
                if (_isRecognizing)
                {
                    flag = true;
                    _isRecognizeCancelled = true;
                }
            }
            if (flag)
            {
                try
                {
                    SapiRecognizer.SetRecoState(SPRECOSTATE.SPRST_INACTIVE);
                }
                catch (COMException e)
                {
                    throw ExceptionFromSapiCreateRecognizerError(e);
                }
            }
        }

        internal void SetInput(string path)
        {
            Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            SetInput(stream, null);
            _inputStream = stream;
        }

        internal void SetInput(Stream stream, SpeechAudioFormatInfo audioFormat)
        {
            lock (SapiRecognizer)
            {
                if (_isRecognizing)
                {
                    throw new InvalidOperationException(SR.Get(SRID.RecognizerAlreadyRecognizing));
                }
                try
                {
                    if (stream == null)
                    {
                        SapiRecognizer.SetInput(null, false);
                        _haveInputSource = false;
                    }
                    else
                    {
                        SapiRecognizer.SetInput(new SpAudioStreamWrapper(stream, audioFormat), false);
                        _haveInputSource = true;
                    }
                }
                catch (COMException e)
                {
                    throw ExceptionFromSapiCreateRecognizerError(e);
                }
                CloseCachedInputStream();
                UpdateAudioFormat(audioFormat);
            }
        }

        internal void SetInputToDefaultAudioDevice()
        {
            lock (SapiRecognizer)
            {
                if (_isRecognizing)
                {
                    throw new InvalidOperationException(SR.Get(SRID.RecognizerAlreadyRecognizing));
                }
                ISpObjectTokenCategory spObjectTokenCategory = (ISpObjectTokenCategory)new SpObjectTokenCategory();
                try
                {
                    spObjectTokenCategory.SetId("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Speech\\AudioInput", false);
                    string ppszCoMemTokenId;
                    spObjectTokenCategory.GetDefaultTokenId(out ppszCoMemTokenId);
                    ISpObjectToken spObjectToken = (ISpObjectToken)new SpObjectToken();
                    try
                    {
                        spObjectToken.SetId(null, ppszCoMemTokenId, false);
                        SapiRecognizer.SetInput(spObjectToken, true);
                    }
                    catch (COMException e)
                    {
                        throw ExceptionFromSapiCreateRecognizerError(e);
                    }
                    finally
                    {
                        Marshal.ReleaseComObject(spObjectToken);
                    }
                }
                catch (COMException e2)
                {
                    throw ExceptionFromSapiCreateRecognizerError(e2);
                }
                finally
                {
                    Marshal.ReleaseComObject(spObjectTokenCategory);
                }
                UpdateAudioFormat(null);
                _haveInputSource = true;
            }
        }

        internal int QueryRecognizerSettingAsInt(string settingName)
        {
            Helpers.ThrowIfEmptyOrNull(settingName, "settingName");
            return SapiRecognizer.GetPropertyNum(settingName);
        }

        internal object QueryRecognizerSetting(string settingName)
        {
            Helpers.ThrowIfEmptyOrNull(settingName, "settingName");
            try
            {
                return SapiRecognizer.GetPropertyNum(settingName);
            }
            catch (Exception ex)
            {
                if (!(ex is COMException) && !(ex is InvalidOperationException) && !(ex is KeyNotFoundException))
                {
                    throw;
                }
                return SapiRecognizer.GetPropertyString(settingName);
            }
        }

        internal void UpdateRecognizerSetting(string settingName, string updatedValue)
        {
            Helpers.ThrowIfEmptyOrNull(settingName, "settingName");
            SapiRecognizer.SetPropertyString(settingName, updatedValue);
        }

        internal void UpdateRecognizerSetting(string settingName, int updatedValue)
        {
            Helpers.ThrowIfEmptyOrNull(settingName, "settingName");
            SapiRecognizer.SetPropertyNum(settingName, updatedValue);
        }

        internal static Exception ExceptionFromSapiCreateRecognizerError(COMException e)
        {
            return ExceptionFromSapiCreateRecognizerError((SAPIErrorCodes)e.ErrorCode);
        }

        internal static Exception ExceptionFromSapiCreateRecognizerError(SAPIErrorCodes errorCode)
        {
            SRID sRID = SapiConstants.SapiErrorCode2SRID(errorCode);
            switch (errorCode)
            {
                case SAPIErrorCodes.CLASS_E_CLASSNOTAVAILABLE:
                case SAPIErrorCodes.REGDB_E_CLASSNOTREG:
                    {
                        OperatingSystem oSVersion = Environment.OSVersion;
                        if (IntPtr.Size == 8 && oSVersion.Platform == PlatformID.Win32NT && oSVersion.Version.Major == 5)
                        {
                            return new NotSupportedException(SR.Get(SRID.RecognitionNotSupportedOn64bit));
                        }
                        return new PlatformNotSupportedException(SR.Get(SRID.RecognitionNotSupported));
                    }
                case SAPIErrorCodes.SPERR_SHARED_ENGINE_DISABLED:
                case SAPIErrorCodes.SPERR_RECOGNIZER_NOT_FOUND:
                    return new PlatformNotSupportedException(SR.Get(sRID));
                default:
                    {
                        Exception result = null;
                        if (sRID >= SRID.NullParamIllegal)
                        {
                            return new InvalidOperationException(SR.Get(sRID));
                        }
                        try
                        {
                            Marshal.ThrowExceptionForHR((int)errorCode);
                            return result;
                        }
                        catch (Exception result2)
                        {
                            return result2;
                        }
                    }
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                lock (_thisObjectLock)
                {
                    if (_asyncWorkerUI != null)
                    {
                        _asyncWorkerUI.Enabled = false;
                        _asyncWorkerUI.Purge();
                        _asyncWorker.Enabled = false;
                        _asyncWorker.Purge();
                    }
                    if (_sapiContext != null)
                    {
                        _sapiContext.DisposeEventNotify(_eventNotify);
                        _handlerWaitHandle.Close();
                        UnloadAllGrammars();
                        _waitForGrammarsToLoad.Dispose();
                    }
                    CloseCachedInputStream();
                    if (_sapiContext != null)
                    {
                        _sapiContext.Dispose();
                        _sapiContext = null;
                    }
                    if (_sapiRecognizer != null)
                    {
                        _sapiRecognizer.Dispose();
                        _sapiRecognizer = null;
                    }
                    if (_recognizerInfo != null)
                    {
                        _recognizerInfo.Dispose();
                        _recognizerInfo = null;
                    }
                    _disposed = true;
                }
            }
        }

        private void LoadSapiGrammar(Grammar grammar, SapiGrammar sapiGrammar, bool enabled, float weight, int priority)
        {
            Uri uri = grammar.BaseUri;
            if (_supportsSapi53 && uri == null && grammar.Uri != null)
            {
                string originalString = grammar.Uri.OriginalString;
                int num = originalString.LastIndexOfAny(new char[2]
                {
                    '\\',
                    '/'
                });
                if (num >= 0)
                {
                    uri = new Uri(originalString.Substring(0, num + 1), UriKind.RelativeOrAbsolute);
                }
            }
            if (grammar.IsDictation(grammar.Uri))
            {
                LoadSapiDictationGrammar(sapiGrammar, grammar.Uri, grammar.RuleName, enabled, weight, priority);
            }
            else
            {
                LoadSapiGrammarFromCfg(sapiGrammar, grammar, uri, enabled, weight, priority);
            }
        }

        private void LoadSapiDictationGrammar(SapiGrammar sapiGrammar, Uri uri, string ruleName, bool enabled, float weight, int priority)
        {
            try
            {
                if (Grammar.IsDictationGrammar(uri))
                {
                    string pszTopicName = string.IsNullOrEmpty(uri.Fragment) ? null : uri.Fragment.Substring(1, uri.Fragment.Length - 1);
                    sapiGrammar.LoadDictation(pszTopicName, SPLOADOPTIONS.SPLO_STATIC);
                }
            }
            catch (COMException ex)
            {
                SAPIErrorCodes errorCode = (SAPIErrorCodes)ex.ErrorCode;
                if (errorCode == SAPIErrorCodes.SPERR_NOT_FOUND)
                {
                    throw new ArgumentException(SR.Get(SRID.DictationTopicNotFound, uri), ex);
                }
                ThrowIfSapiErrorCode((SAPIErrorCodes)ex.ErrorCode);
                throw;
            }
            SetSapiGrammarProperties(sapiGrammar, uri, ruleName, enabled, weight, priority);
        }

        int ISpGrammarResourceLoader.LoadResource(string bstrResourceUri, bool fAlwaysReload, out IStream pStream, ref string pbstrMIMEType, ref short pfModified, ref string pbstrRedirectUrl)
        {
            try
            {
                int num = bstrResourceUri.IndexOf('>');
                string onInitParameter = null;
                if (num > 0)
                {
                    onInitParameter = bstrResourceUri.Substring(num + 1);
                    bstrResourceUri = bstrResourceUri.Substring(0, num);
                }
                string text = pbstrMIMEType;
                string[] array = pbstrRedirectUrl.Split(new char[1]
                {
                    ' '
                }, StringSplitOptions.None);
                uint num2 = uint.Parse(array[0], CultureInfo.InvariantCulture);
                uint num3 = uint.Parse(array[1], CultureInfo.InvariantCulture);
                Uri redirectUri;
                Grammar grammar = Grammar.Create(bstrResourceUri, text, onInitParameter, out redirectUri);
                if (redirectUri != null)
                {
                    pbstrRedirectUrl = redirectUri.ToString();
                }
                if (grammar == null)
                {
                    throw new FormatException(SR.Get(SRID.SapiErrorRuleNotFound2, text, bstrResourceUri));
                }
                grammar.SapiGrammarId = num3;
                Grammar grammar2 = _topLevel.Find(num2);
                if (grammar2 == null)
                {
                    _topLevel.AddRuleRef(grammar, num3);
                }
                else
                {
                    grammar2.AddRuleRef(grammar, num3);
                }
                MemoryStream stream = new MemoryStream(grammar.CfgData);
                SpStreamWrapper spStreamWrapper = (SpStreamWrapper)(pStream = new SpStreamWrapper(stream));
                pfModified = 0;
                return 0;
            }
            catch (Exception loadException)
            {
                pStream = null;
                _loadException = loadException;
                return -2147200988;
            }
        }

        string ISpGrammarResourceLoader.GetLocalCopy(Uri resourcePath, out string mimeType, out Uri redirectUrl)
        {
            redirectUrl = null;
            mimeType = null;
            return null;
        }

        void ISpGrammarResourceLoader.ReleaseLocalCopy(string path)
        {
        }

        private void LoadSapiGrammarFromCfg(SapiGrammar sapiGrammar, Grammar grammar, Uri baseUri, bool enabled, float weight, int priority)
        {
            byte[] cfgData = grammar.CfgData;
            GCHandle gCHandle = GCHandle.Alloc(cfgData, GCHandleType.Pinned);
            IntPtr grammar2 = gCHandle.AddrOfPinnedObject();
            try
            {
                if (_supportsSapi53)
                {
                    _loadException = null;
                    _topLevel = grammar;
                    if (_inproc)
                    {
                        sapiGrammar.SetGrammarLoader(_recoThunk);
                    }
                    sapiGrammar.LoadCmdFromMemory2(grammar2, SPLOADOPTIONS.SPLO_STATIC, null, (baseUri == null) ? null : baseUri.ToString());
                }
                else
                {
                    sapiGrammar.LoadCmdFromMemory(grammar2, SPLOADOPTIONS.SPLO_STATIC);
                }
            }
            catch (COMException ex)
            {
                switch (ex.ErrorCode)
                {
                    case -2147201021:
                        throw new FormatException(SR.Get(SRID.RecognizerInvalidBinaryGrammar), ex);
                    case -2147200988:
                        throw new FormatException(SR.Get(SRID.SapiErrorInvalidImport), ex);
                    case -2147200990:
                        throw new NotSupportedException(SR.Get(SRID.SapiErrorTooManyGrammars), ex);
                    case -2147200966:
                        throw new FileNotFoundException(SR.Get(SRID.ReferencedGrammarNotFound), ex);
                    case -1:
                        if (_loadException != null)
                        {
                            throw _loadException;
                        }
                        ThrowIfSapiErrorCode((SAPIErrorCodes)ex.ErrorCode);
                        break;
                    default:
                        ThrowIfSapiErrorCode((SAPIErrorCodes)ex.ErrorCode);
                        break;
                }
                throw;
            }
            catch (ArgumentException innerException)
            {
                throw new FormatException(SR.Get(SRID.RecognizerInvalidBinaryGrammar), innerException);
            }
            finally
            {
                gCHandle.Free();
            }
            SetSapiGrammarProperties(sapiGrammar, null, grammar.RuleName, enabled, weight, priority);
        }

        private void SetSapiGrammarProperties(SapiGrammar sapiGrammar, Uri uri, string ruleName, bool enabled, float weight, int priority)
        {
            if (!enabled)
            {
                sapiGrammar.SetGrammarState(SPGRAMMARSTATE.SPGS_DISABLED);
            }
            if (_supportsSapi53)
            {
                if (priority != 0)
                {
                    if (Grammar.IsDictationGrammar(uri))
                    {
                        throw new NotSupportedException(SR.Get(SRID.CannotSetPriorityOnDictation));
                    }
                    sapiGrammar.SetRulePriority(ruleName, 0u, priority);
                }
                if (!weight.Equals(1f))
                {
                    if (Grammar.IsDictationGrammar(uri))
                    {
                        sapiGrammar.SetDictationWeight(weight);
                    }
                    else
                    {
                        sapiGrammar.SetRuleWeight(ruleName, 0u, weight);
                    }
                }
            }
            else if (priority != 0 || !weight.Equals(1f))
            {
                throw new NotSupportedException(SR.Get(SRID.NotSupportedWithThisVersionOfSAPI));
            }
            ActivateRule(sapiGrammar, uri, ruleName);
        }

        private void LoadGrammarAsyncCallback(object grammarObject)
        {
            Grammar grammar = (Grammar)grammarObject;
            InternalGrammarData internalData = grammar.InternalData;
            Exception ex = null;
            try
            {
                lock (_grammarDataLock)
                {
                    LoadSapiGrammar(grammar, internalData._sapiGrammar, internalData._grammarEnabled, internalData._grammarWeight, internalData._grammarPriority);
                    grammar.State = GrammarState.Loaded;
                }
            }
            catch (Exception ex2)
            {
                ex = ex2;
            }
            finally
            {
                if (ex != null)
                {
                    grammar.State = GrammarState.LoadFailed;
                    grammar.LoadException = ex;
                }
                _waitForGrammarsToLoad.FinishOperation();
                _asyncWorkerUI.PostOperation(new WaitCallback(LoadGrammarAsyncCompletedCallback), grammarObject);
            }
        }

        private void LoadGrammarAsyncCompletedCallback(object grammarObject)
        {
            Grammar grammar = (Grammar)grammarObject;
            this.LoadGrammarCompleted?.Invoke(this, new LoadGrammarCompletedEventArgs(grammar, grammar.LoadException, false, null));
        }

        private SapiGrammar CreateNewSapiGrammar(out ulong grammarId)
        {
            ulong currentGrammarId = _currentGrammarId;
            do
            {
                _currentGrammarId++;
                bool flag = false;
                lock (SapiRecognizer)
                {
                    foreach (Grammar grammar in _grammars)
                    {
                        if (_currentGrammarId == grammar.InternalData._grammarId)
                        {
                            flag = true;
                            break;
                        }
                    }
                }
                if (!flag)
                {
                    SapiGrammar result = SapiContext.CreateGrammar(_currentGrammarId);
                    grammarId = _currentGrammarId;
                    return result;
                }
            }
            while (_currentGrammarId != currentGrammarId);
            throw new InvalidOperationException(SR.Get(SRID.SapiErrorTooManyGrammars));
        }

        private void ValidateGrammar(Grammar grammar, params GrammarState[] validStates)
        {
            Helpers.ThrowIfNull(grammar, "grammar");
            foreach (GrammarState grammarState in validStates)
            {
                if (grammar.State == grammarState)
                {
                    if (grammar.State != 0 && grammar.Recognizer != this)
                    {
                        throw new InvalidOperationException(SR.Get(SRID.GrammarWrongRecognizer));
                    }
                    return;
                }
            }
            switch (grammar.State)
            {
                case GrammarState.Unloaded:
                    throw new InvalidOperationException(SR.Get(SRID.GrammarNotLoaded));
                case GrammarState.Loading:
                    throw new InvalidOperationException(SR.Get(SRID.GrammarLoadingInProgress));
                case GrammarState.LoadFailed:
                    throw new InvalidOperationException(SR.Get(SRID.GrammarLoadFailed));
                case GrammarState.Loaded:
                    throw new InvalidOperationException(SR.Get(SRID.GrammarAlreadyLoaded));
            }
        }

        private RecognitionResult InternalEmulateRecognize(string phrase, SpeechEmulationCompareFlags flag, bool useReco2, RecognizedWordUnit[] wordUnits)
        {
            RecognitionResult result = null;
            bool completed = false;
            EventHandler<EmulateRecognizeCompletedEventArgs> value = delegate (object sender, EmulateRecognizeCompletedEventArgs eventArgs)
            {
                result = eventArgs.Result;
                completed = true;
            };
            EmulateRecognizeCompletedSync += value;
            try
            {
                _asyncWorkerUI.AsyncMode = false;
                InternalEmulateRecognizeAsync(phrase, flag, useReco2, wordUnits);
                do
                {
                    _handlerWaitHandle.WaitOne();
                    _asyncWorkerUI.ConsumeQueue();
                }
                while (!completed && !_disposed);
            }
            finally
            {
                EmulateRecognizeCompletedSync -= value;
                _asyncWorkerUI.AsyncMode = true;
            }
            return result;
        }

        private void InternalEmulateRecognizeAsync(string phrase, SpeechEmulationCompareFlags flag, bool useReco2, RecognizedWordUnit[] wordUnits)
        {
            lock (SapiRecognizer)
            {
                if (_isRecognizing)
                {
                    throw new InvalidOperationException(SR.Get(SRID.RecognizerAlreadyRecognizing));
                }
                _isRecognizing = true;
                _isEmulateRecognition = true;
            }
            if (useReco2 || _supportsSapi53)
            {
                GCHandle[] memHandles = null;
                ISpPhrase spPhrase = null;
                IntPtr coMem;
                spPhrase = ((wordUnits != null) ? SPPHRASE.CreatePhraseFromWordUnits(wordUnits, RecognizerInfo.Culture, out memHandles, out coMem) : SPPHRASE.CreatePhraseFromText(phrase.Trim(), RecognizerInfo.Culture, out memHandles, out coMem));
                try
                {
                    SAPIErrorCodes sAPIErrorCodes = SapiRecognizer.EmulateRecognition(spPhrase, (uint)flag);
                    if (sAPIErrorCodes != 0)
                    {
                        EmulateRecognizedFailReportError(sAPIErrorCodes);
                    }
                }
                finally
                {
                    GCHandle[] array = memHandles;
                    foreach (GCHandle gCHandle in array)
                    {
                        gCHandle.Free();
                    }
                    Marshal.FreeCoTaskMem(coMem);
                }
            }
            else
            {
                SAPIErrorCodes sAPIErrorCodes2 = SapiRecognizer.EmulateRecognition(phrase);
                if (sAPIErrorCodes2 != 0)
                {
                    EmulateRecognizedFailReportError(sAPIErrorCodes2);
                }
            }
        }

        private void EmulateRecognizedFailReportError(SAPIErrorCodes hr)
        {
            _lastException = ExceptionFromSapiCreateRecognizerError(hr);
            if (hr < SAPIErrorCodes.S_OK || hr == SAPIErrorCodes.SP_NO_RULE_ACTIVE)
            {
                FireEmulateRecognizeCompletedEvent(null, _lastException, true);
            }
        }

        private void ActivateRule(SapiGrammar sapiGrammar, Uri uri, string ruleName)
        {
            SPRULESTATE sPRULESTATE = (!_pauseRecognizerOnRecognition) ? SPRULESTATE.SPRS_ACTIVE : SPRULESTATE.SPRS_ACTIVE_WITH_AUTO_PAUSE;
            SAPIErrorCodes sAPIErrorCodes = (!Grammar.IsDictationGrammar(uri)) ? sapiGrammar.SetRuleState(ruleName, sPRULESTATE) : sapiGrammar.SetDictationState(sPRULESTATE);
            if (sAPIErrorCodes == SAPIErrorCodes.SPERR_NOT_TOPLEVEL_RULE || sAPIErrorCodes == SAPIErrorCodes.SP_NO_RULES_TO_ACTIVATE)
            {
                if (uri == null)
                {
                    if (string.IsNullOrEmpty(ruleName))
                    {
                        throw new FormatException(SR.Get(SRID.RecognizerNoRootRuleToActivate));
                    }
                    throw new ArgumentException(SR.Get(SRID.RecognizerRuleNotFoundStream, ruleName), "ruleName");
                }
                if (string.IsNullOrEmpty(ruleName))
                {
                    throw new FormatException(SR.Get(SRID.RecognizerNoRootRuleToActivate1, uri));
                }
                throw new ArgumentException(SR.Get(SRID.RecognizerRuleNotFound, ruleName, uri), "ruleName");
            }
            if (sAPIErrorCodes != SAPIErrorCodes.SPERR_AUDIO_NOT_FOUND && sAPIErrorCodes < SAPIErrorCodes.S_OK)
            {
                ThrowIfSapiErrorCode(sAPIErrorCodes);
                throw new COMException(SR.Get(SRID.RecognizerRuleActivationFailed), (int)sAPIErrorCodes);
            }
        }

        private void RecognizeAsyncWaitForGrammarsToLoad(object unused)
        {
            _waitForGrammarsToLoad.WaitForOperationsToFinish();
            Exception ex = null;
            bool flag = false;
            lock (SapiRecognizer)
            {
                foreach (Grammar grammar in _grammars)
                {
                    if (grammar.State == GrammarState.LoadFailed)
                    {
                        ex = grammar.LoadException;
                        break;
                    }
                }
                if (_isRecognizeCancelled)
                {
                    flag = true;
                }
            }
            if (ex == null && !flag)
            {
                try
                {
                    if (!_isEmulateRecognition)
                    {
                        SapiRecognizer.SetRecoState(SPRECOSTATE.SPRST_ACTIVE_ALWAYS);
                    }
                }
                catch (COMException ex2)
                {
                    ex = ExceptionFromSapiStreamError((SAPIErrorCodes)ex2.ErrorCode);
                }
                catch (Exception ex3)
                {
                    ex = ex3;
                }
            }
            if (ex != null || flag)
            {
                RecognizeCompletedEventArgs recognizeCompletedEventArgs = new RecognizeCompletedEventArgs(null, false, false, false, TimeSpan.Zero, ex, flag, null);
                _asyncWorkerUI.PostOperation(new WaitCallback(RecognizeAsyncWaitForGrammarsToLoadFailed), recognizeCompletedEventArgs);
            }
        }

        private void RecognizeAsyncWaitForGrammarsToLoadFailed(object eventArgs)
        {
            lock (SapiRecognizer)
            {
                _isRecognizeCancelled = false;
                _isRecognizing = false;
            }
            this.RecognizeCompleted?.Invoke(this, (RecognizeCompletedEventArgs)eventArgs);
        }

        private void SignalHandlerThread(object ignored)
        {
            if (!_asyncWorkerUI.AsyncMode)
            {
                _handlerWaitHandle.Set();
            }
        }

        private void DispatchEvents(object eventData)
        {
            lock (_thisObjectLock)
            {
                SpeechEvent speechEvent = eventData as SpeechEvent;
                if (!_disposed && eventData != null)
                {
                    switch (speechEvent.EventId)
                    {
                        case SPEVENTENUM.SPEI_SOUND_START:
                        case SPEVENTENUM.SPEI_SOUND_END:
                        case SPEVENTENUM.SPEI_PROPERTY_NUM_CHANGE:
                        case SPEVENTENUM.SPEI_PROPERTY_STRING_CHANGE:
                        case SPEVENTENUM.SPEI_REQUEST_UI:
                        case SPEVENTENUM.SPEI_RECO_STATE_CHANGE:
                        case SPEVENTENUM.SPEI_ADAPTATION:
                            break;
                        case SPEVENTENUM.SPEI_START_SR_STREAM:
                            ProcessStartStreamEvent();
                            break;
                        case SPEVENTENUM.SPEI_PHRASE_START:
                            ProcessPhraseStartEvent(speechEvent);
                            break;
                        case SPEVENTENUM.SPEI_SR_BOOKMARK:
                            ProcessBookmarkEvent(speechEvent);
                            break;
                        case SPEVENTENUM.SPEI_HYPOTHESIS:
                            ProcessHypothesisEvent(speechEvent);
                            break;
                        case SPEVENTENUM.SPEI_RECOGNITION:
                        case SPEVENTENUM.SPEI_FALSE_RECOGNITION:
                            ProcessRecognitionEvent(speechEvent);
                            break;
                        case SPEVENTENUM.SPEI_RECO_OTHER_CONTEXT:
                            ProcessRecoOtherContextEvent();
                            break;
                        case SPEVENTENUM.SPEI_END_SR_STREAM:
                            ProcessEndStreamEvent(speechEvent);
                            break;
                        case SPEVENTENUM.SPEI_INTERFERENCE:
                            ProcessInterferenceEvent((uint)speechEvent.LParam);
                            break;
                        case SPEVENTENUM.SPEI_SR_AUDIO_LEVEL:
                            ProcessAudioLevelEvent((int)speechEvent.WParam);
                            break;
                    }
                }
            }
        }

        private void ProcessStartStreamEvent()
        {
            lock (SapiRecognizer)
            {
                _audioState = AudioState.Silence;
            }
            FireAudioStateChangedEvent(_audioState);
            FireStateChangedEvent(RecognizerState.Listening);
            TimeSpan initialSilenceTimeout = InitialSilenceTimeout;
            if (_recognizeMode == RecognizeMode.Single && initialSilenceTimeout != TimeSpan.Zero)
            {
                if (_supportsSapi53)
                {
                    SapiContext.Bookmark(SPBOOKMARKOPTIONS.SPBO_PAUSE | SPBOOKMARKOPTIONS.SPBO_TIME_UNITS, (ulong)initialSilenceTimeout.Ticks, new IntPtr(1));
                }
                else
                {
                    SapiContext.Bookmark(SPBOOKMARKOPTIONS.SPBO_PAUSE, TimeSpanToStreamPosition(initialSilenceTimeout), new IntPtr(1));
                }
                _detectingInitialSilenceTimeout = true;
            }
        }

        private void ProcessPhraseStartEvent(SpeechEvent speechEvent)
        {
            _isWaitingForRecognition = true;
            lock (SapiRecognizer)
            {
                _audioState = AudioState.Speech;
            }
            FireAudioStateChangedEvent(_audioState);
            _detectingInitialSilenceTimeout = false;
            TimeSpan babbleTimeout = BabbleTimeout;
            if (_recognizeMode == RecognizeMode.Single && babbleTimeout != TimeSpan.Zero)
            {
                if (_supportsSapi53)
                {
                    SapiContext.Bookmark(SPBOOKMARKOPTIONS.SPBO_TIME_UNITS, (ulong)(babbleTimeout + speechEvent.AudioPosition).Ticks, new IntPtr(2));
                }
                else
                {
                    SapiContext.Bookmark(SPBOOKMARKOPTIONS.SPBO_NONE, TimeSpanToStreamPosition(babbleTimeout) + speechEvent.AudioStreamOffset, new IntPtr(2));
                }
                _detectingBabbleTimeout = true;
            }
            FireSpeechDetectedEvent(speechEvent.AudioPosition);
        }

        private void ProcessBookmarkEvent(SpeechEvent speechEvent)
        {
            uint num = (uint)speechEvent.LParam;
            try
            {
                switch (num)
                {
                    case 1u:
                        if (_detectingInitialSilenceTimeout)
                        {
                            EndRecognitionWithTimeout();
                        }
                        break;
                    case 2u:
                        if (_detectingBabbleTimeout && !_initialSilenceTimeoutReached)
                        {
                            _babbleTimeoutReached = true;
                            SapiRecognizer.SetRecoState(SPRECOSTATE.SPRST_INACTIVE_WITH_PURGE);
                        }
                        break;
                    default:
                        {
                            object bookmarkItemAndRemove = GetBookmarkItemAndRemove(num);
                            this.RecognizerUpdateReached?.Invoke(this, new RecognizerUpdateReachedEventArgs(bookmarkItemAndRemove, speechEvent.AudioPosition));
                            break;
                        }
                }
            }
            catch (COMException e)
            {
                throw ExceptionFromSapiCreateRecognizerError(e);
            }
            finally
            {
                if (((int)speechEvent.WParam & 1) != 0)
                {
                    SapiContext.Resume();
                }
            }
        }

        private void ProcessHypothesisEvent(SpeechEvent speechEvent)
        {
            RecognitionResult recognitionResult = CreateRecognitionResult(speechEvent);
            bool enabled;
            lock (SapiRecognizer)
            {
                enabled = _enabled;
            }
            if (recognitionResult.Grammar != null && recognitionResult.Grammar.Enabled && enabled)
            {
                FireSpeechHypothesizedEvent(recognitionResult);
            }
        }

        private void ProcessRecognitionEvent(SpeechEvent speechEvent)
        {
            _detectingInitialSilenceTimeout = false;
            _detectingBabbleTimeout = false;
            bool flag = true;
            bool flag2 = (speechEvent.WParam & 2) != 0;
            try
            {
                RecognitionResult recognitionResult = CreateRecognitionResult(speechEvent);
                bool enabled;
                lock (SapiRecognizer)
                {
                    _audioState = AudioState.Silence;
                    flag = _isRecognizeCancelled;
                    enabled = _enabled;
                }
                FireAudioStateChangedEvent(_audioState);
                if (((recognitionResult.Grammar != null && recognitionResult.Grammar.Enabled) || (speechEvent.EventId == SPEVENTENUM.SPEI_FALSE_RECOGNITION && recognitionResult.GrammarId == 0)) && enabled)
                {
                    if (speechEvent.EventId == SPEVENTENUM.SPEI_RECOGNITION)
                    {
                        _lastResult = recognitionResult;
                        SpeechRecognizedEventArgs speechRecognizedEventArgs = new SpeechRecognizedEventArgs(recognitionResult);
                        recognitionResult.Grammar.OnRecognitionInternal(speechRecognizedEventArgs);
                        FireSpeechRecognizedEvent(speechRecognizedEventArgs);
                    }
                    else
                    {
                        _lastResult = null;
                        if (recognitionResult.GrammarId != 0L || !(_babbleTimeoutReached || flag))
                        {
                            FireSpeechRecognitionRejectedEvent(recognitionResult);
                        }
                    }
                }
            }
            finally
            {
                if (_recognizeMode == RecognizeMode.Single)
                {
                    try
                    {
                        SapiRecognizer.SetRecoState(SPRECOSTATE.SPRST_INACTIVE_WITH_PURGE);
                    }
                    catch (COMException e)
                    {
                        throw ExceptionFromSapiCreateRecognizerError(e);
                    }
                }
                if (((int)speechEvent.WParam & 1) != 0)
                {
                    SapiContext.Resume();
                }
            }
            if (_inproc || flag2)
            {
                _isWaitingForRecognition = false;
            }
            if (flag2 && !_inproc)
            {
                FireEmulateRecognizeCompletedEvent(_lastResult, _lastException, flag);
            }
        }

        private void ProcessRecoOtherContextEvent()
        {
            if (_isEmulateRecognition && !_inproc)
            {
                FireEmulateRecognizeCompletedEvent(_lastResult, _lastException, false);
            }
            lock (SapiRecognizer)
            {
                _audioState = AudioState.Silence;
            }
            FireAudioStateChangedEvent(_audioState);
        }

        private void ProcessEndStreamEvent(SpeechEvent speechEvent)
        {
            if (_supportsSapi53 || !_isEmulateRecognition || !_isWaitingForRecognition)
            {
                if (((int)speechEvent.WParam & 2) == 0)
                {
                    ResetBookmarkTable();
                }
                bool initialSilenceTimeoutReached = _initialSilenceTimeoutReached;
                bool babbleTimeoutReached = _babbleTimeoutReached;
                RecognitionResult lastResult = _lastResult;
                Exception lastException = _lastException;
                _initialSilenceTimeoutReached = false;
                _babbleTimeoutReached = false;
                _detectingInitialSilenceTimeout = false;
                _detectingBabbleTimeout = false;
                _lastResult = null;
                _lastException = null;
                bool isStreamReleased = false;
                bool isRecognizeCancelled;
                lock (SapiRecognizer)
                {
                    _audioState = AudioState.Stopped;
                    if (((int)speechEvent.WParam & 1) == 1)
                    {
                        isStreamReleased = true;
                        _haveInputSource = false;
                    }
                    isRecognizeCancelled = _isRecognizeCancelled;
                    _isRecognizeCancelled = false;
                    _isRecognizing = false;
                }
                FireAudioStateChangedEvent(_audioState);
                if (!_isEmulateRecognition)
                {
                    FireRecognizeCompletedEvent(lastResult, initialSilenceTimeoutReached, babbleTimeoutReached, isStreamReleased, speechEvent.AudioPosition, (speechEvent.LParam == 0L) ? null : ExceptionFromSapiStreamError((SAPIErrorCodes)speechEvent.LParam), isRecognizeCancelled);
                }
                else
                {
                    FireEmulateRecognizeCompletedEvent(lastResult, (speechEvent.LParam == 0L) ? lastException : ExceptionFromSapiStreamError((SAPIErrorCodes)speechEvent.LParam), isRecognizeCancelled);
                }
                FireStateChangedEvent(RecognizerState.Stopped);
            }
        }

        private void ProcessInterferenceEvent(uint interference)
        {
            FireSignalProblemOccurredEvent((AudioSignalProblem)interference);
        }

        private void ProcessAudioLevelEvent(int audioLevel)
        {
            FireAudioLevelUpdatedEvent(audioLevel);
        }

        private void EndRecognitionWithTimeout()
        {
            _initialSilenceTimeoutReached = true;
            SapiRecognizer.SetRecoState(SPRECOSTATE.SPRST_INACTIVE_WITH_PURGE);
        }

        private RecognitionResult CreateRecognitionResult(SpeechEvent speechEvent)
        {
            ISpRecoResult spRecoResult = (ISpRecoResult)Marshal.GetObjectForIUnknown((IntPtr)(long)speechEvent.LParam);
            RecognitionResult recognitionResult = null;
            IntPtr ppCoMemSerializedResult;
            spRecoResult.Serialize(out ppCoMemSerializedResult);
            byte[] array = null;
            try
            {
                uint num = (uint)Marshal.ReadInt32(ppCoMemSerializedResult);
                array = new byte[num];
                Marshal.Copy(ppCoMemSerializedResult, array, 0, (int)num);
            }
            finally
            {
                Marshal.FreeCoTaskMem(ppCoMemSerializedResult);
            }
            return new RecognitionResult(this, spRecoResult, array, MaxAlternates);
        }

        private void UpdateAudioFormat(SpeechAudioFormatInfo audioFormat)
        {
            lock (SapiRecognizer)
            {
                try
                {
                    _audioFormat = GetSapiAudioFormat();
                }
                catch (ArgumentException)
                {
                    _audioFormat = audioFormat;
                }
                _eventNotify.AudioFormat = _audioFormat;
            }
        }

        private SpeechAudioFormatInfo GetSapiAudioFormat()
        {
            IntPtr intPtr = IntPtr.Zero;
            SpeechAudioFormatInfo result = null;
            bool flag = false;
            try
            {
                try
                {
                    intPtr = SapiRecognizer.GetFormat(SPSTREAMFORMATTYPE.SPWF_SRENGINE);
                    if (intPtr != IntPtr.Zero && (result = AudioFormatConverter.ToSpeechAudioFormatInfo(intPtr)) != null)
                    {
                        flag = true;
                    }
                }
                catch (COMException)
                {
                    flag = false;
                }
                if (!flag)
                {
                    return new SpeechAudioFormatInfo(16000, AudioBitsPerSample.Sixteen, AudioChannel.Mono);
                }
                return result;
            }
            finally
            {
                if (intPtr != IntPtr.Zero)
                {
                    Marshal.FreeCoTaskMem(intPtr);
                }
            }
        }

        private ulong TimeSpanToStreamPosition(TimeSpan time)
        {
            return (ulong)(time.Ticks * AudioFormat.AverageBytesPerSecond) / 10000000uL;
        }

        private static void ThrowIfSapiErrorCode(SAPIErrorCodes errorCode)
        {
            SRID sRID = SapiConstants.SapiErrorCode2SRID(errorCode);
            if (sRID >= SRID.NullParamIllegal)
            {
                throw new InvalidOperationException(SR.Get(sRID));
            }
        }

        private static Exception ExceptionFromSapiStreamError(SAPIErrorCodes errorCode)
        {
            SRID sRID = SapiConstants.SapiErrorCode2SRID(errorCode);
            if (sRID >= SRID.NullParamIllegal)
            {
                return new InvalidOperationException(SR.Get(sRID));
            }
            return new COMException(SR.Get(SRID.AudioDeviceInternalError), (int)errorCode);
        }

        private static SpeechEmulationCompareFlags ConvertCompareOptions(CompareOptions compareOptions)
        {
            CompareOptions compareOptions2 = CompareOptions.IgnoreCase | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth | CompareOptions.OrdinalIgnoreCase | CompareOptions.Ordinal;
            SpeechEmulationCompareFlags speechEmulationCompareFlags = (SpeechEmulationCompareFlags)0;
            if ((compareOptions & CompareOptions.IgnoreCase) != 0 || (compareOptions & CompareOptions.OrdinalIgnoreCase) != 0)
            {
                speechEmulationCompareFlags |= SpeechEmulationCompareFlags.SECFIgnoreCase;
            }
            if ((compareOptions & CompareOptions.IgnoreKanaType) != 0)
            {
                speechEmulationCompareFlags |= SpeechEmulationCompareFlags.SECFIgnoreKanaType;
            }
            if ((compareOptions & CompareOptions.IgnoreWidth) != 0)
            {
                speechEmulationCompareFlags |= SpeechEmulationCompareFlags.SECFIgnoreWidth;
            }
            if ((compareOptions & ~compareOptions2) != 0)
            {
                throw new NotSupportedException(SR.Get(SRID.NotSupportedWithThisVersionOfSAPICompareOption));
            }
            return speechEmulationCompareFlags;
        }

        internal void AddEventInterest(ulong interest)
        {
            if ((_eventInterest & interest) != interest)
            {
                _eventInterest |= interest;
                SapiContext.SetInterest(_eventInterest, _eventInterest);
            }
        }

        internal void RemoveEventInterest(ulong interest)
        {
            if ((_eventInterest & interest) != 0L)
            {
                _eventInterest &= ~interest;
                SapiContext.SetInterest(_eventInterest, _eventInterest);
            }
        }

        private uint AddBookmarkItem(object userToken)
        {
            uint result = 0u;
            if (userToken != null)
            {
                lock (_bookmarkTable)
                {
                    result = _nextBookmarkId++;
                    if (_nextBookmarkId == 0)
                    {
                        throw new InvalidOperationException(SR.Get(SRID.RecognizerUpdateTableTooLarge));
                    }
                    _bookmarkTable[(int)result] = userToken;
                    return result;
                }
            }
            return result;
        }

        private void ResetBookmarkTable()
        {
            lock (_bookmarkTable)
            {
                if (_bookmarkTable.Count > 0)
                {
                    int[] array = new int[_bookmarkTable.Count];
                    _bookmarkTable.Keys.CopyTo(array, 0);
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (array[i] <= _prevMaxBookmarkId)
                        {
                            _bookmarkTable.Remove(array[i]);
                        }
                    }
                }
                if (_bookmarkTable.Count == 0)
                {
                    _nextBookmarkId = 3u;
                    _prevMaxBookmarkId = 2u;
                }
                else
                {
                    _prevMaxBookmarkId = _nextBookmarkId - 1;
                }
            }
        }

        private object GetBookmarkItemAndRemove(uint bookmarkId)
        {
            object result = null;
            if (bookmarkId != 0)
            {
                lock (_bookmarkTable)
                {
                    result = _bookmarkTable[(int)bookmarkId];
                    _bookmarkTable.Remove((int)bookmarkId);
                    return result;
                }
            }
            return result;
        }

        private void CloseCachedInputStream()
        {
            if (_inputStream != null)
            {
                _inputStream.Close();
                _inputStream = null;
            }
        }

        private void FireAudioStateChangedEvent(AudioState audioState)
        {
            EventHandler<AudioStateChangedEventArgs> audioStateChangedDelegate = _audioStateChangedDelegate;
            if (audioStateChangedDelegate != null)
            {
                _asyncWorkerUI.PostOperation(audioStateChangedDelegate, this, new AudioStateChangedEventArgs(audioState));
            }
        }

        private void FireSignalProblemOccurredEvent(AudioSignalProblem audioSignalProblem)
        {
            EventHandler<AudioSignalProblemOccurredEventArgs> audioSignalProblemOccurredDelegate = _audioSignalProblemOccurredDelegate;
            if (audioSignalProblemOccurredDelegate != null)
            {
                TimeSpan recognizerPosition = TimeSpan.Zero;
                TimeSpan audioPosition = TimeSpan.Zero;
                try
                {
                    SPRECOGNIZERSTATUS status = SapiRecognizer.GetStatus();
                    lock (SapiRecognizer)
                    {
                        SpeechAudioFormatInfo audioFormat = AudioFormat;
                        audioPosition = ((audioFormat.AverageBytesPerSecond > 0) ? new TimeSpan((long)(status.AudioStatus.CurDevicePos * 10000000 / (ulong)audioFormat.AverageBytesPerSecond)) : TimeSpan.Zero);
                        recognizerPosition = new TimeSpan((long)status.ullRecognitionStreamTime);
                    }
                }
                catch (COMException e)
                {
                    throw ExceptionFromSapiCreateRecognizerError(e);
                }
                _asyncWorkerUI.PostOperation(audioSignalProblemOccurredDelegate, this, new AudioSignalProblemOccurredEventArgs(audioSignalProblem, AudioLevel, audioPosition, recognizerPosition));
            }
        }

        private void FireAudioLevelUpdatedEvent(int audioLevel)
        {
            EventHandler<AudioLevelUpdatedEventArgs> audioLevelUpdatedDelegate = _audioLevelUpdatedDelegate;
            if (audioLevelUpdatedDelegate != null)
            {
                _asyncWorkerUI.PostOperation(audioLevelUpdatedDelegate, this, new AudioLevelUpdatedEventArgs(audioLevel));
            }
        }

        private void FireStateChangedEvent(RecognizerState recognizerState)
        {
            EventHandler<StateChangedEventArgs> stateChanged = this.StateChanged;
            if (stateChanged != null)
            {
                _asyncWorkerUI.PostOperation(stateChanged, this, new StateChangedEventArgs(recognizerState));
            }
        }

        private void FireSpeechDetectedEvent(TimeSpan audioPosition)
        {
            EventHandler<SpeechDetectedEventArgs> speechDetected = this.SpeechDetected;
            if (speechDetected != null)
            {
                _asyncWorkerUI.PostOperation(speechDetected, this, new SpeechDetectedEventArgs(audioPosition));
            }
        }

        private void FireSpeechHypothesizedEvent(RecognitionResult result)
        {
            EventHandler<SpeechHypothesizedEventArgs> speechHypothesizedDelegate = _speechHypothesizedDelegate;
            if (speechHypothesizedDelegate != null)
            {
                _asyncWorkerUI.PostOperation(speechHypothesizedDelegate, this, new SpeechHypothesizedEventArgs(result));
            }
        }

        private void FireSpeechRecognitionRejectedEvent(RecognitionResult result)
        {
            EventHandler<SpeechRecognitionRejectedEventArgs> speechRecognitionRejected = this.SpeechRecognitionRejected;
            SpeechRecognitionRejectedEventArgs speechRecognitionRejectedEventArgs = new SpeechRecognitionRejectedEventArgs(result);
            if (speechRecognitionRejected != null)
            {
                _asyncWorkerUI.PostOperation(speechRecognitionRejected, this, speechRecognitionRejectedEventArgs);
            }
        }

        private void FireSpeechRecognizedEvent(SpeechRecognizedEventArgs recognitionEventArgs)
        {
            EventHandler<SpeechRecognizedEventArgs> speechRecognized = this.SpeechRecognized;
            if (speechRecognized != null)
            {
                _asyncWorkerUI.PostOperation(speechRecognized, this, recognitionEventArgs);
            }
        }

        private void FireRecognizeCompletedEvent(RecognitionResult result, bool initialSilenceTimeoutReached, bool babbleTimeoutReached, bool isStreamReleased, TimeSpan audioPosition, Exception exception, bool isRecognizeCancelled)
        {
            EventHandler<RecognizeCompletedEventArgs> eventHandler = this.RecognizeCompletedSync;
            if (eventHandler == null)
            {
                eventHandler = this.RecognizeCompleted;
            }
            if (eventHandler != null)
            {
                _asyncWorkerUI.PostOperation(eventHandler, this, new RecognizeCompletedEventArgs(result, initialSilenceTimeoutReached, babbleTimeoutReached, isStreamReleased, audioPosition, exception, isRecognizeCancelled, null));
            }
        }

        private void FireEmulateRecognizeCompletedEvent(RecognitionResult result, Exception exception, bool isRecognizeCancelled)
        {
            EventHandler<EmulateRecognizeCompletedEventArgs> eventHandler;
            lock (SapiRecognizer)
            {
                eventHandler = this.EmulateRecognizeCompletedSync;
                if (eventHandler == null)
                {
                    eventHandler = this.EmulateRecognizeCompleted;
                }
                _lastResult = null;
                _lastException = null;
                _isEmulateRecognition = false;
                _isRecognizing = false;
                _isWaitingForRecognition = false;
            }
            if (eventHandler != null)
            {
                _asyncWorkerUI.PostOperation(eventHandler, this, new EmulateRecognizeCompletedEventArgs(result, exception, isRecognizeCancelled, null));
            }
        }

        private static void CheckGrammarOptionsOnSapi51(Grammar grammar)
        {
            SRID sRID = (SRID)(-1);
            if (grammar.BaseUri != null && !grammar.IsSrgsDocument)
            {
                sRID = SRID.NotSupportedWithThisVersionOfSAPIBaseUri;
            }
            else if (grammar.IsStg || grammar.Sapi53Only)
            {
                sRID = SRID.NotSupportedWithThisVersionOfSAPITagFormat;
            }
            if (sRID != (SRID)(-1))
            {
                throw new NotSupportedException(SR.Get(sRID));
            }
        }
    }
}
