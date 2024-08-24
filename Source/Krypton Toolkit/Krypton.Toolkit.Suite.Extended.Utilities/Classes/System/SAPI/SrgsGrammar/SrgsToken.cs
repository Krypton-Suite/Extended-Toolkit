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

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsGrammar
{
    [Serializable]
    [DebuggerDisplay("{DebuggerDisplayString ()}")]
    public class SrgsToken : SrgsElement, IToken, IElement
    {
        private string _text = string.Empty;

        private string _pronunciation;

        private string _display;

        public string Text
        {
            get => _text;
            set
            {
                Helpers.ThrowIfEmptyOrNull(value, "value");
                string text = value.Trim(Helpers._achTrimChars);
                if (string.IsNullOrEmpty(text) || text.IndexOf('"') >= 0)
                {
                    throw new ArgumentException(SR.Get(SRID.InvalidTokenString), "value");
                }
                _text = text;
            }
        }

        public string Pronunciation
        {
            get => _pronunciation;
            set
            {
                Helpers.ThrowIfEmptyOrNull(value, "value");
                _pronunciation = value;
            }
        }

        public string Display
        {
            get => _display;
            set
            {
                Helpers.ThrowIfEmptyOrNull(value, "value");
                _display = value;
            }
        }

        public SrgsToken(string text)
        {
            Helpers.ThrowIfEmptyOrNull(text, "text");
            Text = text;
        }

        internal override void WriteSrgs(XmlWriter writer)
        {
            writer.WriteStartElement("token");
            if (_display != null)
            {
                writer.WriteAttributeString("sapi", "display", "http://schemas.microsoft.com/Speech/2002/06/SRGSExtensions", _display);
            }
            if (_pronunciation != null)
            {
                writer.WriteAttributeString("sapi", "pron", "http://schemas.microsoft.com/Speech/2002/06/SRGSExtensions", _pronunciation);
            }
            if (_text != null && _text.Length > 0)
            {
                writer.WriteString(_text);
            }
            writer.WriteEndElement();
        }

        internal override void Validate(SrgsGrammar grammar)
        {
            if (_pronunciation != null || _display != null)
            {
                grammar.HasPronunciation = true;
            }
            if (_pronunciation != null)
            {
                int num = 0;
                int num2 = 0;
                while (num < _pronunciation.Length)
                {
                    num2 = _pronunciation.IndexOf(';', num);
                    if (num2 == -1)
                    {
                        num2 = _pronunciation.Length;
                    }
                    string text = _pronunciation.Substring(num, num2 - num);
                    switch (grammar.PhoneticAlphabet)
                    {
                        case AlphabetType.Sapi:
                            PhonemeConverter.ConvertPronToId(text, grammar.Culture.LCID);
                            break;
                        case AlphabetType.Ups:
                            PhonemeConverter.UpsConverter.ConvertPronToId(text);
                            break;
                        case AlphabetType.Ipa:
                            PhonemeConverter.ValidateUpsIds(text.ToCharArray());
                            break;
                    }
                    num = num2 + 1;
                }
            }
            base.Validate(grammar);
        }

        internal override string DebuggerDisplayString()
        {
            StringBuilder stringBuilder = new StringBuilder("Token '");
            stringBuilder.Append(_text);
            stringBuilder.Append("'");
            if (_pronunciation != null)
            {
                stringBuilder.Append(" Pronunciation '");
                stringBuilder.Append(_pronunciation);
                stringBuilder.Append("'");
            }
            return stringBuilder.ToString();
        }
    }
}
