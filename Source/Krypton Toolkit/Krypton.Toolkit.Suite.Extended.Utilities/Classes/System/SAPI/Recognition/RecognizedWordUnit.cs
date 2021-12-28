#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.SystemInternal.Speech;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Recognition
{
    [Serializable]
    [DebuggerDisplay("Text: {Text}")]
    public class RecognizedWordUnit
    {
        internal TimeSpan _audioPosition;

        internal TimeSpan _audioDuration;

        private string _text;

        private string _lexicalForm;

        private float _confidence;

        private string _pronunciation;

        private DisplayAttributes _displayAttributes;

        public string Text => _text;

        public float Confidence => _confidence;

        public string Pronunciation => _pronunciation;

        public string LexicalForm => _lexicalForm;

        public DisplayAttributes DisplayAttributes => _displayAttributes;

        public RecognizedWordUnit(string text, float confidence, string pronunciation, string lexicalForm, DisplayAttributes displayAttributes, TimeSpan audioPosition, TimeSpan audioDuration)
        {
            if (lexicalForm == null)
            {
                throw new ArgumentNullException("lexicalForm");
            }
            if (confidence < 0f || confidence > 1f)
            {
                throw new ArgumentOutOfRangeException(SR.Get(SRID.InvalidConfidence));
            }
            _text = ((text == null || text.Length == 0) ? null : text);
            _confidence = confidence;
            _pronunciation = ((pronunciation == null || pronunciation.Length == 0) ? null : pronunciation);
            _lexicalForm = lexicalForm;
            _displayAttributes = displayAttributes;
            _audioPosition = audioPosition;
            _audioDuration = audioDuration;
        }

        internal static byte DisplayAttributesToSapiAttributes(DisplayAttributes displayAttributes)
        {
            return (byte)((uint)displayAttributes >> 1);
        }

        internal static DisplayAttributes SapiAttributesToDisplayAttributes(byte sapiAttributes)
        {
            return (DisplayAttributes)(sapiAttributes << 1);
        }
    }
}
