#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.System.AudioFormat;
using Krypton.Toolkit.Suite.Extended.Utilities.System.Internal;
using Krypton.Toolkit.Suite.Extended.Utilities.System.TTSEngine;
using Krypton.Toolkit.Suite.Extended.Utilities.SystemInternal.Speech;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Synthesis
{
    public sealed class SpeechSynthesizer : IDisposable
    {
        private VoiceSynthesis _voiceSynthesis;

        private bool _isDisposed;

        private bool paused;

        private Stream _outputStream;

        private bool _closeStreamOnExit;

        public SynthesizerState State => VoiceSynthesizer.State;

        /// <filterpriority>2</filterpriority>
        public int Rate
        {
            get
            {
                return VoiceSynthesizer.Rate;
            }
            set
            {
                if (value < -10 || value > 10)
                {
                    throw new ArgumentOutOfRangeException("value", SR.Get(SRID.RateOutOfRange));
                }
                VoiceSynthesizer.Rate = value;
            }
        }

        /// <filterpriority>2</filterpriority>
        public int Volume
        {
            get
            {
                return VoiceSynthesizer.Volume;
            }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentOutOfRangeException("value", SR.Get(SRID.ResourceUsageOutOfRange));
                }
                VoiceSynthesizer.Volume = value;
            }
        }

        public VoiceInfo Voice => VoiceSynthesizer.CurrentVoice(true).VoiceInfo;

        private VoiceSynthesis VoiceSynthesizer
        {
            get
            {
                if (_voiceSynthesis == null && _isDisposed)
                {
                    throw new ObjectDisposedException("SpeechSynthesizer");
                }
                if (_voiceSynthesis == null)
                {
                    WeakReference speechSynthesizer = new WeakReference(this);
                    _voiceSynthesis = new VoiceSynthesis(speechSynthesizer);
                }
                return _voiceSynthesis;
            }
        }

        public event EventHandler<SpeakStartedEventArgs> SpeakStarted
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            add
            {
                Helpers.ThrowIfNull(value, "value");
                VoiceSynthesis voiceSynthesizer = VoiceSynthesizer;
                voiceSynthesizer._speakStarted = (EventHandler<SpeakStartedEventArgs>)Delegate.Combine(voiceSynthesizer._speakStarted, value);
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            remove
            {
                Helpers.ThrowIfNull(value, "value");
                VoiceSynthesis voiceSynthesizer = VoiceSynthesizer;
                voiceSynthesizer._speakStarted = (EventHandler<SpeakStartedEventArgs>)Delegate.Remove(voiceSynthesizer._speakStarted, value);
            }
        }

        public event EventHandler<SpeakCompletedEventArgs> SpeakCompleted
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            add
            {
                Helpers.ThrowIfNull(value, "value");
                VoiceSynthesis voiceSynthesizer = VoiceSynthesizer;
                voiceSynthesizer._speakCompleted = (EventHandler<SpeakCompletedEventArgs>)Delegate.Combine(voiceSynthesizer._speakCompleted, value);
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            remove
            {
                Helpers.ThrowIfNull(value, "value");
                VoiceSynthesis voiceSynthesizer = VoiceSynthesizer;
                voiceSynthesizer._speakCompleted = (EventHandler<SpeakCompletedEventArgs>)Delegate.Remove(voiceSynthesizer._speakCompleted, value);
            }
        }

        public event EventHandler<SpeakProgressEventArgs> SpeakProgress
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            add
            {
                Helpers.ThrowIfNull(value, "value");
                VoiceSynthesizer.AddEvent(TtsEventId.WordBoundary, ref VoiceSynthesizer._speakProgress, value);
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            remove
            {
                Helpers.ThrowIfNull(value, "value");
                VoiceSynthesizer.RemoveEvent(TtsEventId.WordBoundary, ref VoiceSynthesizer._speakProgress, value);
            }
        }

        /// <filterpriority>2</filterpriority>
        public event EventHandler<BookmarkReachedEventArgs> BookmarkReached
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            add
            {
                Helpers.ThrowIfNull(value, "value");
                VoiceSynthesizer.AddEvent(TtsEventId.Bookmark, ref VoiceSynthesizer._bookmarkReached, value);
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            remove
            {
                Helpers.ThrowIfNull(value, "value");
                VoiceSynthesizer.RemoveEvent(TtsEventId.Bookmark, ref VoiceSynthesizer._bookmarkReached, value);
            }
        }

        public event EventHandler<VoiceChangeEventArgs> VoiceChange
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            add
            {
                Helpers.ThrowIfNull(value, "value");
                VoiceSynthesizer.AddEvent(TtsEventId.VoiceChange, ref VoiceSynthesizer._voiceChange, value);
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            remove
            {
                Helpers.ThrowIfNull(value, "value");
                VoiceSynthesizer.RemoveEvent(TtsEventId.VoiceChange, ref VoiceSynthesizer._voiceChange, value);
            }
        }

        /// <filterpriority>2</filterpriority>
        public event EventHandler<PhonemeReachedEventArgs> PhonemeReached
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            add
            {
                Helpers.ThrowIfNull(value, "value");
                VoiceSynthesizer.AddEvent(TtsEventId.Phoneme, ref VoiceSynthesizer._phonemeReached, value);
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            remove
            {
                Helpers.ThrowIfNull(value, "value");
                VoiceSynthesizer.RemoveEvent(TtsEventId.Phoneme, ref VoiceSynthesizer._phonemeReached, value);
            }
        }

        /// <filterpriority>2</filterpriority>
        public event EventHandler<VisemeReachedEventArgs> VisemeReached
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            add
            {
                Helpers.ThrowIfNull(value, "value");
                VoiceSynthesizer.AddEvent(TtsEventId.Viseme, ref VoiceSynthesizer._visemeReached, value);
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            remove
            {
                Helpers.ThrowIfNull(value, "value");
                VoiceSynthesizer.RemoveEvent(TtsEventId.Viseme, ref VoiceSynthesizer._visemeReached, value);
            }
        }

        public event EventHandler<StateChangedEventArgs> StateChanged
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            add
            {
                Helpers.ThrowIfNull(value, "value");
                VoiceSynthesis voiceSynthesizer = VoiceSynthesizer;
                voiceSynthesizer._stateChanged = (EventHandler<StateChangedEventArgs>)Delegate.Combine(voiceSynthesizer._stateChanged, value);
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            remove
            {
                Helpers.ThrowIfNull(value, "value");
                VoiceSynthesis voiceSynthesizer = VoiceSynthesizer;
                voiceSynthesizer._stateChanged = (EventHandler<StateChangedEventArgs>)Delegate.Remove(voiceSynthesizer._stateChanged, value);
            }
        }

        ~SpeechSynthesizer()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void SelectVoice(string name)
        {
            Helpers.ThrowIfEmptyOrNull(name, "name");
            TTSVoice engine = VoiceSynthesizer.GetEngine(name, CultureInfo.CurrentUICulture, VoiceGender.NotSet, VoiceAge.NotSet, 1, true);
            if (engine == null || name != engine.VoiceInfo.Name)
            {
                throw new ArgumentException(SR.Get(SRID.SynthesizerSetVoiceNoMatch));
            }
            VoiceSynthesizer.Voice = engine;
        }

        public void SelectVoiceByHints(VoiceGender gender)
        {
            SelectVoiceByHints(gender, VoiceAge.NotSet, 1, CultureInfo.CurrentUICulture);
        }

        public void SelectVoiceByHints(VoiceGender gender, VoiceAge age)
        {
            SelectVoiceByHints(gender, age, 1, CultureInfo.CurrentUICulture);
        }

        public void SelectVoiceByHints(VoiceGender gender, VoiceAge age, int voiceAlternate)
        {
            SelectVoiceByHints(gender, age, voiceAlternate, CultureInfo.CurrentUICulture);
        }

        public void SelectVoiceByHints(VoiceGender gender, VoiceAge age, int voiceAlternate, CultureInfo culture)
        {
            Helpers.ThrowIfNull(culture, "culture");
            if (voiceAlternate < 0)
            {
                throw new ArgumentOutOfRangeException("voiceAlternate", SR.Get(SRID.PromptBuilderInvalidVariant));
            }
            if (!VoiceInfo.ValidateGender(gender))
            {
                throw new ArgumentException(SR.Get(SRID.EnumInvalid, "VoiceGender"), "gender");
            }
            if (!VoiceInfo.ValidateAge(age))
            {
                throw new ArgumentException(SR.Get(SRID.EnumInvalid, "VoiceAge"), "age");
            }
            TTSVoice engine = VoiceSynthesizer.GetEngine(null, culture, gender, age, voiceAlternate, true);
            if (engine == null)
            {
                throw new InvalidOperationException(SR.Get(SRID.SynthesizerSetVoiceNoMatch));
            }
            VoiceSynthesizer.Voice = engine;
        }

        public Prompt SpeakAsync(string textToSpeak)
        {
            Helpers.ThrowIfNull(textToSpeak, "textToSpeak");
            Prompt prompt = new Prompt(textToSpeak, SynthesisTextFormat.Text);
            SpeakAsync(prompt);
            return prompt;
        }

        public void SpeakAsync(Prompt prompt)
        {
            Helpers.ThrowIfNull(prompt, "prompt");
            prompt.Synthesizer = this;
            VoiceSynthesizer.SpeakAsync(prompt);
        }

        public Prompt SpeakSsmlAsync(string textToSpeak)
        {
            Helpers.ThrowIfNull(textToSpeak, "textToSpeak");
            Prompt prompt = new Prompt(textToSpeak, SynthesisTextFormat.Ssml);
            SpeakAsync(prompt);
            return prompt;
        }

        public Prompt SpeakAsync(PromptBuilder promptBuilder)
        {
            Helpers.ThrowIfNull(promptBuilder, "promptBuilder");
            Prompt prompt = new Prompt(promptBuilder);
            SpeakAsync(prompt);
            return prompt;
        }

        public void Speak(string textToSpeak)
        {
            Speak(new Prompt(textToSpeak, SynthesisTextFormat.Text));
        }

        public void Speak(Prompt prompt)
        {
            Helpers.ThrowIfNull(prompt, "prompt");
            if (State == SynthesizerState.Paused)
            {
                throw new InvalidOperationException(SR.Get(SRID.SynthesizerSyncSpeakWhilePaused));
            }
            prompt.Synthesizer = this;
            prompt._syncSpeak = true;
            VoiceSynthesizer.Speak(prompt);
        }

        public void Speak(PromptBuilder promptBuilder)
        {
            Speak(new Prompt(promptBuilder));
        }

        public void SpeakSsml(string textToSpeak)
        {
            Speak(new Prompt(textToSpeak, SynthesisTextFormat.Ssml));
        }

        public void Pause()
        {
            if (!paused)
            {
                VoiceSynthesizer.Pause();
                paused = true;
            }
        }

        public void Resume()
        {
            if (paused)
            {
                VoiceSynthesizer.Resume();
                paused = false;
            }
        }

        public void SpeakAsyncCancel(Prompt prompt)
        {
            Helpers.ThrowIfNull(prompt, "prompt");
            VoiceSynthesizer.Abort(prompt);
        }

        public void SpeakAsyncCancelAll()
        {
            VoiceSynthesizer.Abort();
        }

        public void SetOutputToWaveFile(string path)
        {
            Helpers.ThrowIfEmptyOrNull(path, "path");
            SetOutputToNull();
            SetOutputStream(new FileStream(path, FileMode.Create, FileAccess.Write), null, true, true);
        }

        public void SetOutputToWaveFile(string path, SpeechAudioFormatInfo formatInfo)
        {
            Helpers.ThrowIfEmptyOrNull(path, "path");
            Helpers.ThrowIfNull(formatInfo, "formatInfo");
            SetOutputToNull();
            SetOutputStream(new FileStream(path, FileMode.Create, FileAccess.Write), formatInfo, true, true);
        }

        public void SetOutputToWaveStream(Stream audioDestination)
        {
            Helpers.ThrowIfNull(audioDestination, "audioDestination");
            SetOutputStream(audioDestination, null, true, false);
        }

        public void SetOutputToAudioStream(Stream audioDestination, SpeechAudioFormatInfo formatInfo)
        {
            Helpers.ThrowIfNull(audioDestination, "audioDestination");
            Helpers.ThrowIfNull(formatInfo, "formatInfo");
            SetOutputStream(audioDestination, formatInfo, false, false);
        }

        public void SetOutputToDefaultAudioDevice()
        {
            SetOutputStream(null, null, true, false);
        }

        public void SetOutputToNull()
        {
            if (_outputStream != Stream.Null)
            {
                VoiceSynthesizer.SetOutput(Stream.Null, null, true);
            }
            if (_outputStream != null && _closeStreamOnExit)
            {
                _outputStream.Close();
            }
            _outputStream = Stream.Null;
        }

        /// <filterpriority>2</filterpriority>
        public Prompt GetCurrentlySpokenPrompt()
        {
            return VoiceSynthesizer.Prompt;
        }

        public ReadOnlyCollection<InstalledVoice> GetInstalledVoices()
        {
            return VoiceSynthesizer.GetInstalledVoices(null);
        }

        public ReadOnlyCollection<InstalledVoice> GetInstalledVoices(CultureInfo culture)
        {
            Helpers.ThrowIfNull(culture, "culture");
            if (culture.Equals(CultureInfo.InvariantCulture))
            {
                throw new ArgumentException(SR.Get(SRID.InvariantCultureInfo), "culture");
            }
            return VoiceSynthesizer.GetInstalledVoices(culture);
        }

        /// <filterpriority>2</filterpriority>
        public void AddLexicon(Uri uri, string mediaType)
        {
            Helpers.ThrowIfNull(uri, "uri");
            VoiceSynthesizer.AddLexicon(uri, mediaType);
        }

        /// <filterpriority>2</filterpriority>
        public void RemoveLexicon(Uri uri)
        {
            Helpers.ThrowIfNull(uri, "uri");
            VoiceSynthesizer.RemoveLexicon(uri);
        }

        private void SetOutputStream(Stream stream, SpeechAudioFormatInfo formatInfo, bool headerInfo, bool closeStreamOnExit)
        {
            SetOutputToNull();
            _outputStream = stream;
            _closeStreamOnExit = closeStreamOnExit;
            VoiceSynthesizer.SetOutput(stream, formatInfo, headerInfo);
        }

        private void Dispose(bool disposing)
        {
            if (!_isDisposed && disposing && _voiceSynthesis != null)
            {
                _isDisposed = true;
                SpeakAsyncCancelAll();
                if (_outputStream != null)
                {
                    if (_closeStreamOnExit)
                    {
                        _outputStream.Close();
                    }
                    else
                    {
                        _outputStream.Flush();
                    }
                    _outputStream = null;
                }
            }
            if (_voiceSynthesis != null)
            {
                _voiceSynthesis.Dispose();
                _voiceSynthesis = null;
            }
            _isDisposed = true;
        }
    }
}
