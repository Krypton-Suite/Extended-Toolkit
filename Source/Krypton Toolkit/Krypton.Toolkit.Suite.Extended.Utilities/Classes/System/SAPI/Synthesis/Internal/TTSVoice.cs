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

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Synthesis
{
    internal class TTSVoice
    {
        private ITtsEngineProxy _engine;

        private VoiceInfo _voiceId;

        private List<LexiconEntry> _lexicons = new();

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
                    intPtr = _engine.GetOutputFormat(targetWaveFormat != null ? gCHandle.AddrOfPinnedObject() : IntPtr.Zero);
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