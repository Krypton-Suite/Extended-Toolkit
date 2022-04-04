#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.System.AudioFormat;
using Krypton.Toolkit.Suite.Extended.Utilities.System.Internal;
using Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop;
using Krypton.Toolkit.Suite.Extended.Utilities.SystemInternal.Speech;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Recognition
{
    public class SpeechRecognizer : IDisposable
    {
        private bool _disposed;

        private RecognizerBase _recognizerBase;

        private SapiRecognizer _sapiRecognizer;

        private EventHandler<AudioSignalProblemOccurredEventArgs> _audioSignalProblemOccurredDelegate;

        private EventHandler<AudioLevelUpdatedEventArgs> _audioLevelUpdatedDelegate;

        private EventHandler<AudioStateChangedEventArgs> _audioStateChangedDelegate;

        private EventHandler<SpeechHypothesizedEventArgs> _speechHypothesizedDelegate;

        public RecognizerState State => RecoBase.State;

        public bool Enabled
        {
            get
            {
                return RecoBase.Enabled;
            }
            set
            {
                RecoBase.Enabled = value;
            }
        }

        /// <filterpriority>2</filterpriority>
        public bool PauseRecognizerOnRecognition
        {
            get
            {
                return RecoBase.PauseRecognizerOnRecognition;
            }
            set
            {
                RecoBase.PauseRecognizerOnRecognition = value;
            }
        }

        public ReadOnlyCollection<Grammar> Grammars => RecoBase.Grammars;

        public RecognizerInfo RecognizerInfo => RecoBase.RecognizerInfo;

        public AudioState AudioState => RecoBase.AudioState;

        /// <filterpriority>2</filterpriority>
        public int AudioLevel => RecoBase.AudioLevel;

        /// <filterpriority>2</filterpriority>
        public TimeSpan AudioPosition => RecoBase.AudioPosition;

        /// <filterpriority>2</filterpriority>
        public TimeSpan RecognizerAudioPosition => RecoBase.RecognizerAudioPosition;

        /// <filterpriority>2</filterpriority>
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
                    try
                    {
                        _recognizerBase.Initialize(_sapiRecognizer, false);
                    }
                    catch (COMException e)
                    {
                        throw RecognizerBase.ExceptionFromSapiCreateRecognizerError(e);
                    }
                    PauseRecognizerOnRecognition = false;
                    _recognizerBase._haveInputSource = true;
                    if (AudioPosition != TimeSpan.Zero)
                    {
                        _recognizerBase.AudioState = AudioState.Silence;
                    }
                    _recognizerBase.StateChanged += StateChangedProxy;
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

        public event EventHandler<StateChangedEventArgs> StateChanged;

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

        public SpeechRecognizer()
        {
            _sapiRecognizer = new SapiRecognizer(SapiRecognizer.RecognizerType.Shared);
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

        public void LoadGrammar(Grammar grammar)
        {
            RecoBase.LoadGrammar(grammar);
        }

        /// <filterpriority>2</filterpriority>
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
            if (Enabled)
            {
                return RecoBase.EmulateRecognize(inputText);
            }
            throw new InvalidOperationException(SR.Get(SRID.RecognizerNotEnabled));
        }

        public RecognitionResult EmulateRecognize(string inputText, CompareOptions compareOptions)
        {
            if (Enabled)
            {
                return RecoBase.EmulateRecognize(inputText, compareOptions);
            }
            throw new InvalidOperationException(SR.Get(SRID.RecognizerNotEnabled));
        }

        public RecognitionResult EmulateRecognize(RecognizedWordUnit[] wordUnits, CompareOptions compareOptions)
        {
            if (Enabled)
            {
                return RecoBase.EmulateRecognize(wordUnits, compareOptions);
            }
            throw new InvalidOperationException(SR.Get(SRID.RecognizerNotEnabled));
        }

        public void EmulateRecognizeAsync(string inputText)
        {
            if (Enabled)
            {
                RecoBase.EmulateRecognizeAsync(inputText);
                return;
            }
            throw new InvalidOperationException(SR.Get(SRID.RecognizerNotEnabled));
        }

        public void EmulateRecognizeAsync(string inputText, CompareOptions compareOptions)
        {
            if (Enabled)
            {
                RecoBase.EmulateRecognizeAsync(inputText, compareOptions);
                return;
            }
            throw new InvalidOperationException(SR.Get(SRID.RecognizerNotEnabled));
        }

        public void EmulateRecognizeAsync(RecognizedWordUnit[] wordUnits, CompareOptions compareOptions)
        {
            if (Enabled)
            {
                RecoBase.EmulateRecognizeAsync(wordUnits, compareOptions);
                return;
            }
            throw new InvalidOperationException(SR.Get(SRID.RecognizerNotEnabled));
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

        private void StateChangedProxy(object sender, StateChangedEventArgs e)
        {
            this.StateChanged?.Invoke(this, e);
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
