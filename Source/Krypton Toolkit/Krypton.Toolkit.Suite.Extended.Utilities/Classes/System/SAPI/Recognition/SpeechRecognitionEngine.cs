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
using Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop;
using Krypton.Toolkit.Suite.Extended.Utilities.SystemInternal.Speech;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Recognition
{
    public class SpeechRecognitionEngine : IDisposable
    {
        private bool _disposed;

        private RecognizerBase _recognizerBase;

        private SapiRecognizer _sapiRecognizer;

        private EventHandler<AudioSignalProblemOccurredEventArgs> _audioSignalProblemOccurredDelegate;

        private EventHandler<AudioLevelUpdatedEventArgs> _audioLevelUpdatedDelegate;

        private EventHandler<AudioStateChangedEventArgs> _audioStateChangedDelegate;

        private EventHandler<SpeechHypothesizedEventArgs> _speechHypothesizedDelegate;

        /// <filterpriority>2</filterpriority>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public TimeSpan InitialSilenceTimeout
        {
            get
            {
                return RecoBase.InitialSilenceTimeout;
            }
            set
            {
                RecoBase.InitialSilenceTimeout = value;
            }
        }

        /// <filterpriority>2</filterpriority>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public TimeSpan BabbleTimeout
        {
            get
            {
                return RecoBase.BabbleTimeout;
            }
            set
            {
                RecoBase.BabbleTimeout = value;
            }
        }

        /// <filterpriority>2</filterpriority>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public TimeSpan EndSilenceTimeout
        {
            get
            {
                return TimeSpan.FromMilliseconds(RecoBase.QueryRecognizerSettingAsInt("ResponseSpeed"));
            }
            set
            {
                if (value.TotalMilliseconds < 0.0 || value.TotalMilliseconds > 10000.0)
                {
                    throw new ArgumentOutOfRangeException("value", SR.Get(SRID.EndSilenceOutOfRange));
                }
                RecoBase.UpdateRecognizerSetting("ResponseSpeed", (int)value.TotalMilliseconds);
            }
        }

        /// <filterpriority>2</filterpriority>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public TimeSpan EndSilenceTimeoutAmbiguous
        {
            get
            {
                return TimeSpan.FromMilliseconds(RecoBase.QueryRecognizerSettingAsInt("ComplexResponseSpeed"));
            }
            set
            {
                if (value.TotalMilliseconds < 0.0 || value.TotalMilliseconds > 10000.0)
                {
                    throw new ArgumentOutOfRangeException("value", SR.Get(SRID.EndSilenceOutOfRange));
                }
                RecoBase.UpdateRecognizerSetting("ComplexResponseSpeed", (int)value.TotalMilliseconds);
            }
        }

        public ReadOnlyCollection<Grammar> Grammars => RecoBase.Grammars;

        public RecognizerInfo RecognizerInfo => RecoBase.RecognizerInfo;

        public AudioState AudioState => RecoBase.AudioState;

        /// <filterpriority>2</filterpriority>
        public int AudioLevel => RecoBase.AudioLevel;

        public TimeSpan RecognizerAudioPosition => RecoBase.RecognizerAudioPosition;

        /// <filterpriority>2</filterpriority>
        public TimeSpan AudioPosition => RecoBase.AudioPosition;

        public SpeechAudioFormatInfo AudioFormat => RecoBase.AudioFormat;

        public int MaxAlternates
        {
            get
            {
                return RecoBase.MaxAlternates;
            }
            set
            {
                RecoBase.MaxAlternates = value;
            }
        }

        private RecognizerBase RecoBase
        {
            get
            {
                if (_disposed)
                {
                    throw new ObjectDisposedException("SpeechRecognitionEngine");
                }
                if (_recognizerBase == null)
                {
                    _recognizerBase = new RecognizerBase();
                    _recognizerBase.Initialize(_sapiRecognizer, true);
                    _recognizerBase.RecognizeCompleted += RecognizeCompletedProxy;
                    _recognizerBase.EmulateRecognizeCompleted += EmulateRecognizeCompletedProxy;
                    _recognizerBase.LoadGrammarCompleted += LoadGrammarCompletedProxy;
                    _recognizerBase.SpeechDetected += SpeechDetectedProxy;
                    _recognizerBase.SpeechRecognized += SpeechRecognizedProxy;
                    _recognizerBase.SpeechRecognitionRejected += SpeechRecognitionRejectedProxy;
                    _recognizerBase.RecognizerUpdateReached += RecognizerUpdateReachedProxy;
                }
                return _recognizerBase;
            }
        }

        public event EventHandler<RecognizeCompletedEventArgs> RecognizeCompleted;

        public event EventHandler<EmulateRecognizeCompletedEventArgs> EmulateRecognizeCompleted;

        public event EventHandler<LoadGrammarCompletedEventArgs> LoadGrammarCompleted;

        public event EventHandler<SpeechDetectedEventArgs> SpeechDetected;

        public event EventHandler<SpeechRecognizedEventArgs> SpeechRecognized;

        public event EventHandler<SpeechRecognitionRejectedEventArgs> SpeechRecognitionRejected;

        /// <filterpriority>2</filterpriority>
        public event EventHandler<RecognizerUpdateReachedEventArgs> RecognizerUpdateReached;

        public event EventHandler<SpeechHypothesizedEventArgs> SpeechHypothesized
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            add
            {
                Helpers.ThrowIfNull(value, "value");
                if (_speechHypothesizedDelegate == null)
                {
                    RecoBase.SpeechHypothesized += SpeechHypothesizedProxy;
                }
                _speechHypothesizedDelegate = (EventHandler<SpeechHypothesizedEventArgs>)Delegate.Combine(_speechHypothesizedDelegate, value);
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            remove
            {
                Helpers.ThrowIfNull(value, "value");
                _speechHypothesizedDelegate = (EventHandler<SpeechHypothesizedEventArgs>)Delegate.Remove(_speechHypothesizedDelegate, value);
                if (_speechHypothesizedDelegate == null)
                {
                    RecoBase.SpeechHypothesized -= SpeechHypothesizedProxy;
                }
            }
        }

        /// <filterpriority>2</filterpriority>
        public event EventHandler<AudioSignalProblemOccurredEventArgs> AudioSignalProblemOccurred
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            add
            {
                Helpers.ThrowIfNull(value, "value");
                if (_audioSignalProblemOccurredDelegate == null)
                {
                    RecoBase.AudioSignalProblemOccurred += AudioSignalProblemOccurredProxy;
                }
                _audioSignalProblemOccurredDelegate = (EventHandler<AudioSignalProblemOccurredEventArgs>)Delegate.Combine(_audioSignalProblemOccurredDelegate, value);
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            remove
            {
                Helpers.ThrowIfNull(value, "value");
                _audioSignalProblemOccurredDelegate = (EventHandler<AudioSignalProblemOccurredEventArgs>)Delegate.Remove(_audioSignalProblemOccurredDelegate, value);
                if (_audioSignalProblemOccurredDelegate == null)
                {
                    RecoBase.AudioSignalProblemOccurred -= AudioSignalProblemOccurredProxy;
                }
            }
        }

        /// <filterpriority>2</filterpriority>
        public event EventHandler<AudioLevelUpdatedEventArgs> AudioLevelUpdated
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            add
            {
                Helpers.ThrowIfNull(value, "value");
                if (_audioLevelUpdatedDelegate == null)
                {
                    RecoBase.AudioLevelUpdated += AudioLevelUpdatedProxy;
                }
                _audioLevelUpdatedDelegate = (EventHandler<AudioLevelUpdatedEventArgs>)Delegate.Combine(_audioLevelUpdatedDelegate, value);
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            remove
            {
                Helpers.ThrowIfNull(value, "value");
                _audioLevelUpdatedDelegate = (EventHandler<AudioLevelUpdatedEventArgs>)Delegate.Remove(_audioLevelUpdatedDelegate, value);
                if (_audioLevelUpdatedDelegate == null)
                {
                    RecoBase.AudioLevelUpdated -= AudioLevelUpdatedProxy;
                }
            }
        }

        public event EventHandler<AudioStateChangedEventArgs> AudioStateChanged
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            add
            {
                Helpers.ThrowIfNull(value, "value");
                if (_audioStateChangedDelegate == null)
                {
                    RecoBase.AudioStateChanged += AudioStateChangedProxy;
                }
                _audioStateChangedDelegate = (EventHandler<AudioStateChangedEventArgs>)Delegate.Combine(_audioStateChangedDelegate, value);
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            remove
            {
                Helpers.ThrowIfNull(value, "value");
                _audioStateChangedDelegate = (EventHandler<AudioStateChangedEventArgs>)Delegate.Remove(_audioStateChangedDelegate, value);
                if (_audioStateChangedDelegate == null)
                {
                    RecoBase.AudioStateChanged -= AudioStateChangedProxy;
                }
            }
        }

        public SpeechRecognitionEngine()
        {
            Initialize(null);
        }

        public SpeechRecognitionEngine(CultureInfo culture)
        {
            Helpers.ThrowIfNull(culture, "culture");
            if (culture.Equals(CultureInfo.InvariantCulture))
            {
                throw new ArgumentException(SR.Get(SRID.InvariantCultureInfo), "culture");
            }
            foreach (RecognizerInfo item in InstalledRecognizers())
            {
                if (culture.Equals(item.Culture))
                {
                    Initialize(item);
                    return;
                }
            }
            foreach (RecognizerInfo item2 in InstalledRecognizers())
            {
                if (Helpers.CompareInvariantCulture(item2.Culture, culture))
                {
                    Initialize(item2);
                    return;
                }
            }
            throw new ArgumentException(SR.Get(SRID.RecognizerNotFound), "culture");
        }

        public SpeechRecognitionEngine(string recognizerId)
        {
            Helpers.ThrowIfEmptyOrNull(recognizerId, "recognizerId");
            foreach (RecognizerInfo item in InstalledRecognizers())
            {
                if (recognizerId.Equals(item.Id, StringComparison.OrdinalIgnoreCase))
                {
                    Initialize(item);
                    return;
                }
            }
            throw new ArgumentException(SR.Get(SRID.RecognizerNotFound), "recognizerId");
        }

        public SpeechRecognitionEngine(RecognizerInfo recognizerInfo)
        {
            Helpers.ThrowIfNull(recognizerInfo, "recognizerInfo");
            Initialize(recognizerInfo);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && !_disposed)
            {
                if (_recognizerBase != null)
                {
                    _recognizerBase.Dispose();
                    _recognizerBase = null;
                }
                if (_sapiRecognizer != null)
                {
                    _sapiRecognizer.Dispose();
                    _sapiRecognizer = null;
                }
                _disposed = true;
            }
        }

        public static ReadOnlyCollection<RecognizerInfo> InstalledRecognizers()
        {
            List<RecognizerInfo> list = new List<RecognizerInfo>();
            using (ObjectTokenCategory objectTokenCategory = ObjectTokenCategory.Create("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Speech\\Recognizers"))
            {
                if (objectTokenCategory != null)
                {
                    foreach (ObjectToken item in (IEnumerable<ObjectToken>)objectTokenCategory)
                    {
                        RecognizerInfo recognizerInfo = RecognizerInfo.Create(item);
                        if (recognizerInfo != null)
                        {
                            list.Add(recognizerInfo);
                        }
                    }
                }
            }
            return new ReadOnlyCollection<RecognizerInfo>(list);
        }

        public void SetInputToWaveFile(string path)
        {
            Helpers.ThrowIfEmptyOrNull(path, "path");
            RecoBase.SetInput(path);
        }

        public void SetInputToWaveStream(Stream audioSource)
        {
            RecoBase.SetInput(audioSource, null);
        }

        public void SetInputToAudioStream(Stream audioSource, SpeechAudioFormatInfo audioFormat)
        {
            Helpers.ThrowIfNull(audioSource, "audioSource");
            Helpers.ThrowIfNull(audioFormat, "audioFormat");
            RecoBase.SetInput(audioSource, audioFormat);
        }

        public void SetInputToNull()
        {
            RecoBase.SetInput(null, null);
        }

        public void SetInputToDefaultAudioDevice()
        {
            RecoBase.SetInputToDefaultAudioDevice();
        }

        public RecognitionResult Recognize()
        {
            return RecoBase.Recognize(RecoBase.InitialSilenceTimeout);
        }

        public RecognitionResult Recognize(TimeSpan initialSilenceTimeout)
        {
            if (Grammars.Count == 0)
            {
                throw new InvalidOperationException(SR.Get(SRID.RecognizerHasNoGrammar));
            }
            return RecoBase.Recognize(initialSilenceTimeout);
        }

        public void RecognizeAsync()
        {
            RecognizeAsync(RecognizeMode.Single);
        }

        public void RecognizeAsync(RecognizeMode mode)
        {
            if (Grammars.Count == 0)
            {
                throw new InvalidOperationException(SR.Get(SRID.RecognizerHasNoGrammar));
            }
            RecoBase.RecognizeAsync(mode);
        }

        public void RecognizeAsyncCancel()
        {
            RecoBase.RecognizeAsyncCancel();
        }

        public void RecognizeAsyncStop()
        {
            RecoBase.RecognizeAsyncStop();
        }

        /// <filterpriority>2</filterpriority>
        public object QueryRecognizerSetting(string settingName)
        {
            return RecoBase.QueryRecognizerSetting(settingName);
        }

        /// <filterpriority>2</filterpriority>
        public void UpdateRecognizerSetting(string settingName, string updatedValue)
        {
            RecoBase.UpdateRecognizerSetting(settingName, updatedValue);
        }

        /// <filterpriority>2</filterpriority>
        public void UpdateRecognizerSetting(string settingName, int updatedValue)
        {
            RecoBase.UpdateRecognizerSetting(settingName, updatedValue);
        }

        public void LoadGrammar(Grammar grammar)
        {
            RecoBase.LoadGrammar(grammar);
        }

        public void LoadGrammarAsync(Grammar grammar)
        {
            RecoBase.LoadGrammarAsync(grammar);
        }

        public void UnloadGrammar(Grammar grammar)
        {
            RecoBase.UnloadGrammar(grammar);
        }

        public void UnloadAllGrammars()
        {
            RecoBase.UnloadAllGrammars();
        }

        public RecognitionResult EmulateRecognize(string inputText)
        {
            return EmulateRecognize(inputText, CompareOptions.IgnoreCase | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth);
        }

        public RecognitionResult EmulateRecognize(string inputText, CompareOptions compareOptions)
        {
            if (Grammars.Count == 0)
            {
                throw new InvalidOperationException(SR.Get(SRID.RecognizerHasNoGrammar));
            }
            return RecoBase.EmulateRecognize(inputText, compareOptions);
        }

        public RecognitionResult EmulateRecognize(RecognizedWordUnit[] wordUnits, CompareOptions compareOptions)
        {
            if (Grammars.Count == 0)
            {
                throw new InvalidOperationException(SR.Get(SRID.RecognizerHasNoGrammar));
            }
            return RecoBase.EmulateRecognize(wordUnits, compareOptions);
        }

        public void EmulateRecognizeAsync(string inputText)
        {
            EmulateRecognizeAsync(inputText, CompareOptions.IgnoreCase | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth);
        }

        public void EmulateRecognizeAsync(string inputText, CompareOptions compareOptions)
        {
            if (Grammars.Count == 0)
            {
                throw new InvalidOperationException(SR.Get(SRID.RecognizerHasNoGrammar));
            }
            RecoBase.EmulateRecognizeAsync(inputText, compareOptions);
        }

        public void EmulateRecognizeAsync(RecognizedWordUnit[] wordUnits, CompareOptions compareOptions)
        {
            if (Grammars.Count == 0)
            {
                throw new InvalidOperationException(SR.Get(SRID.RecognizerHasNoGrammar));
            }
            RecoBase.EmulateRecognizeAsync(wordUnits, compareOptions);
        }

        /// <filterpriority>2</filterpriority>
        public void RequestRecognizerUpdate()
        {
            RecoBase.RequestRecognizerUpdate();
        }

        /// <filterpriority>2</filterpriority>
        public void RequestRecognizerUpdate(object userToken)
        {
            RecoBase.RequestRecognizerUpdate(userToken);
        }

        /// <filterpriority>2</filterpriority>
        public void RequestRecognizerUpdate(object userToken, TimeSpan audioPositionAheadToRaiseUpdate)
        {
            RecoBase.RequestRecognizerUpdate(userToken, audioPositionAheadToRaiseUpdate);
        }

        private void Initialize(RecognizerInfo recognizerInfo)
        {
            try
            {
                _sapiRecognizer = new SapiRecognizer(SapiRecognizer.RecognizerType.InProc);
            }
            catch (COMException e)
            {
                throw RecognizerBase.ExceptionFromSapiCreateRecognizerError(e);
            }
            if (recognizerInfo != null)
            {
                ObjectToken objectToken = recognizerInfo.GetObjectToken();
                if (objectToken == null)
                {
                    throw new ArgumentException(SR.Get(SRID.NullParamIllegal), "recognizerInfo");
                }
                try
                {
                    _sapiRecognizer.SetRecognizer(objectToken.SAPIToken);
                }
                catch (COMException e2)
                {
                    throw new ArgumentException(SR.Get(SRID.RecognizerNotFound), RecognizerBase.ExceptionFromSapiCreateRecognizerError(e2));
                }
            }
            _sapiRecognizer.SetRecoState(SPRECOSTATE.SPRST_INACTIVE);
        }

        private void RecognizeCompletedProxy(object sender, RecognizeCompletedEventArgs e)
        {
            this.RecognizeCompleted?.Invoke(this, e);
        }

        private void EmulateRecognizeCompletedProxy(object sender, EmulateRecognizeCompletedEventArgs e)
        {
            this.EmulateRecognizeCompleted?.Invoke(this, e);
        }

        private void LoadGrammarCompletedProxy(object sender, LoadGrammarCompletedEventArgs e)
        {
            this.LoadGrammarCompleted?.Invoke(this, e);
        }

        private void SpeechDetectedProxy(object sender, SpeechDetectedEventArgs e)
        {
            this.SpeechDetected?.Invoke(this, e);
        }

        private void SpeechRecognizedProxy(object sender, SpeechRecognizedEventArgs e)
        {
            this.SpeechRecognized?.Invoke(this, e);
        }

        private void SpeechRecognitionRejectedProxy(object sender, SpeechRecognitionRejectedEventArgs e)
        {
            this.SpeechRecognitionRejected?.Invoke(this, e);
        }

        private void RecognizerUpdateReachedProxy(object sender, RecognizerUpdateReachedEventArgs e)
        {
            this.RecognizerUpdateReached?.Invoke(this, e);
        }

        private void SpeechHypothesizedProxy(object sender, SpeechHypothesizedEventArgs e)
        {
            _speechHypothesizedDelegate?.Invoke(this, e);
        }

        private void AudioSignalProblemOccurredProxy(object sender, AudioSignalProblemOccurredEventArgs e)
        {
            _audioSignalProblemOccurredDelegate?.Invoke(this, e);
        }

        private void AudioLevelUpdatedProxy(object sender, AudioLevelUpdatedEventArgs e)
        {
            _audioLevelUpdatedDelegate?.Invoke(this, e);
        }

        private void AudioStateChangedProxy(object sender, AudioStateChangedEventArgs e)
        {
            _audioStateChangedDelegate?.Invoke(this, e);
        }
    }
}
