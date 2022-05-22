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
    internal class SpeechSeg
    {
        private TTSVoice _voice;

        private List<TextFragment> _textFragments = new List<TextFragment>();

        private AudioData _audio;

        internal List<TextFragment> FragmentList => _textFragments;

        internal AudioData Audio => _audio;

        internal TTSVoice Voice => _voice;

        internal bool IsText => _audio == null;

        internal SpeechSeg(TTSVoice voice, AudioData audio)
        {
            _voice = voice;
            _audio = audio;
        }

        internal void AddFrag(TextFragment textFragment)
        {
            if (_audio != null)
            {
                throw new InvalidOperationException();
            }
            _textFragments.Add(textFragment);
        }
    }
}