#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Synthesis
{
    internal class TTSVoice
    {
        private ITtsEngineProxy _engine;

        private VoiceInfo _voiceId;

        private List<LexiconEntry> _lexicons = new List<LexiconEntry>();

        private byte[] _waveFormat;

        internal ITtsEngineProxy TtsEngine => _engine;

        internal VoiceInfo VoiceInfo => _voiceId;

        internal TTSVoice(ITtsEngineProxy engine, VoiceInfo voiceId)
        {
            _engine = engine;
            _voiceId = voiceId;
        }

        public override bool Equals(object obj)
        {
            TTSVoice tTSVoice = obj as TTSVoice;
            if (tTSVoice != null)
            {
                return _voiceId.Equals(tTSVoice.VoiceInfo);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return _voiceId.GetHashCode();
        }

        internal void UpdateLexicons(List<LexiconEntry> lexicons)
        {
            for (int num = _lexicons.Count - 1; num >= 0; num--)
            {
                LexiconEntry lexiconEntry = _lexicons[num];
                if (!lexicons.Contains(lexiconEntry))
                {
                    _lexicons.RemoveAt(num);
                    TtsEngine.RemoveLexicon(lexiconEntry._uri);
                }
            }
            foreach (LexiconEntry lexicon in lexicons)
            {
                if (!_lexicons.Contains(lexicon))
                {
                    TtsEngine.AddLexicon(lexicon._uri, lexicon._mediaType);
                    _lexicons.Add(lexicon);
                }
            }
        }

        internal byte[] WaveFormat(byte[] targetWaveFormat)
        {
            if (targetWaveFormat == null && _waveFormat == null && VoiceInfo.SupportedAudioFormats.Count > 0)
            {
                targetWaveFormat = VoiceInfo.SupportedAudioFormats[0].WaveFormat;
            }
            if (targetWaveFormat == null && _waveFormat != null)
            {
                return _waveFormat;
            }
            if (_waveFormat == null || !object.Equals(targetWaveFormat, _waveFormat))
            {
                IntPtr intPtr = IntPtr.Zero;
                GCHandle gCHandle = default(GCHandle);
                if (targetWaveFormat != null)
                {
                    gCHandle = GCHandle.Alloc(targetWaveFormat, GCHandleType.Pinned);
                }
                try
                {
                    intPtr = _engine.GetOutputFormat((targetWaveFormat != null) ? gCHandle.AddrOfPinnedObject() : IntPtr.Zero);
                }
                finally
                {
                    if (targetWaveFormat != null)
                    {
                        gCHandle.Free();
                    }
                }
                if (intPtr != IntPtr.Zero)
                {
                    _waveFormat = WAVEFORMATEX.ToBytes(intPtr);
                    Marshal.FreeCoTaskMem(intPtr);
                }
                else
                {
                    _waveFormat = WAVEFORMATEX.Default.ToBytes();
                }
            }
            return _waveFormat;
        }
    }
}