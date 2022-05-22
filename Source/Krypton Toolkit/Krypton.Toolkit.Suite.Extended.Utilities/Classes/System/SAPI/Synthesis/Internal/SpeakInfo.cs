#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.System.TTSEngine;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Synthesis
{
    internal sealed class SpeakInfo
    {
        private TTSVoice _ttsVoice;

        private bool _fNotInTextSeg = true;

        private List<SpeechSeg> _listSeg = new List<SpeechSeg>();

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