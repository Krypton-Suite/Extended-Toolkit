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
            if (confidence is < 0f or > 1f)
            {
                throw new ArgumentOutOfRangeException(SR.Get(SRID.InvalidConfidence));
            }
            _text = text == null || text.Length == 0 ? null : text;
            _confidence = confidence;
            _pronunciation = pronunciation == null || pronunciation.Length == 0 ? null : pronunciation;
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
