#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Synthesis
{
    public class SpeakProgressEventArgs : PromptEventArgs
    {
        private TimeSpan _audioPosition;

        private int _iWordPos;

        private int _cWordLen;

        private string _word;

        public TimeSpan AudioPosition => _audioPosition;

        public int CharacterPosition => _iWordPos;

        public int CharacterCount
        {
            get
            {
                return _cWordLen;
            }
            internal set
            {
                _cWordLen = value;
            }
        }

        public string Text
        {
            get
            {
                return _word;
            }
            internal set
            {
                _word = value;
            }
        }

        internal SpeakProgressEventArgs(Prompt prompt, TimeSpan audioPosition, int iWordPos, int cWordLen)
            : base(prompt)
        {
            _audioPosition = audioPosition;
            _iWordPos = iWordPos;
            _cWordLen = cWordLen;
        }
    }
}
