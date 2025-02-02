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
    internal sealed class SpeakInfo
    {
        private TTSVoice _ttsVoice;

        private bool _fNotInTextSeg = true;

        private List<SpeechSeg> _listSeg = [];

        private SpeechSeg _lastSeg;

        private VoiceSynthesis _voiceSynthesis;

        internal TTSVoice Voice => _ttsVoice;

        internal SpeakInfo(VoiceSynthesis voiceSynthesis, TTSVoice ttsVoice)
        {
            _voiceSynthesis = voiceSynthesis;
            _ttsVoice = ttsVoice;
        }

        internal void SetVoice(string name, CultureInfo culture, VoiceGender gender, VoiceAge age, int variant)
        {
            TTSVoice engine = _voiceSynthesis.GetEngine(name, culture, gender, age, variant, false);
            if (!engine.Equals(_ttsVoice))
            {
                _ttsVoice = engine;
                _fNotInTextSeg = true;
            }
        }

        internal void AddAudio(AudioData audio)
        {
            AddNewSeg(null, audio);
            _fNotInTextSeg = true;
        }

        internal void AddText(TTSVoice ttsVoice, TextFragment textFragment)
        {
            if (_fNotInTextSeg || ttsVoice != _ttsVoice)
            {
                AddNewSeg(ttsVoice, null);
                _fNotInTextSeg = false;
            }
            _lastSeg.AddFrag(textFragment);
        }

        internal SpeechSeg RemoveFirst()
        {
            SpeechSeg result = null;
            if (_listSeg.Count > 0)
            {
                result = _listSeg[0];
                _listSeg.RemoveAt(0);
            }
            return result;
        }

        private void AddNewSeg(TTSVoice pCurrVoice, AudioData audio)
        {
            SpeechSeg speechSeg = new SpeechSeg(pCurrVoice, audio);
            _listSeg.Add(speechSeg);
            _lastSeg = speechSeg;
        }
    }
}