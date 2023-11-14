#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
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
    public class SrgsSubset : SrgsElement, ISubset, IElement
    {
        private SubsetMatchingMode _matchMode;

        private string _text;

        public SubsetMatchingMode MatchingMode
        {
            get => _matchMode;
            set
            {
                if (value != SubsetMatchingMode.OrderedSubset && value != 0 && value != SubsetMatchingMode.OrderedSubsetContentRequired && value != SubsetMatchingMode.SubsequenceContentRequired)
                {
                    throw new ArgumentException(SR.Get(SRID.InvalidSubsetAttribute), "value");
                }
                _matchMode = value;
            }
        }

        public string Text
        {
            get => _text;
            set
            {
                Helpers.ThrowIfEmptyOrNull(value, "value");
                value = value.Trim(Helpers._achTrimChars);
                Helpers.ThrowIfEmptyOrNull(value, "value");
                _text = value;
            }
        }

        public SrgsSubset(string text)
            : this(text, SubsetMatchingMode.Subsequence)
        {
        }

        public SrgsSubset(string text, SubsetMatchingMode matchingMode)
        {
            Helpers.ThrowIfEmptyOrNull(text, "text");
            if (matchingMode != SubsetMatchingMode.OrderedSubset && matchingMode != 0 && matchingMode != SubsetMatchingMode.OrderedSubsetContentRequired && matchingMode != SubsetMatchingMode.SubsequenceContentRequired)
            {
                throw new ArgumentException(SR.Get(SRID.InvalidSubsetAttribute), "matchingMode");
            }
            _matchMode = matchingMode;
            _text = text.Trim(Helpers._achTrimChars);
            Helpers.ThrowIfEmptyOrNull(_text, "text");
        }

        internal override void WriteSrgs(XmlWriter writer)
        {
            writer.WriteStartElement("sapi", "subset", "http://schemas.microsoft.com/Speech/2002/06/SRGSExtensions");
            if (_matchMode != 0)
            {
                string value = null;
                switch (_matchMode)
                {
                    case SubsetMatchingMode.Subsequence:
                        value = "subsequence";
                        break;
                    case SubsetMatchingMode.OrderedSubset:
                        value = "ordered-subset";
                        break;
                    case SubsetMatchingMode.SubsequenceContentRequired:
                        value = "subsequence-content-required";
                        break;
                    case SubsetMatchingMode.OrderedSubsetContentRequired:
                        value = "ordered-subset-content-required";
                        break;
                }
                writer.WriteAttributeString("sapi", "match", "http://schemas.microsoft.com/Speech/2002/06/SRGSExtensions", value);
            }
            if (_text != null && _text.Length > 0)
            {
                writer.WriteString(_text);
            }
            writer.WriteEndElement();
        }

        internal override void Validate(SrgsGrammar grammar)
        {
            grammar.HasSapiExtension = true;
            base.Validate(grammar);
        }

        internal override string DebuggerDisplayString()
        {
            return $"{_text} [{_matchMode}]";
        }
    }
}
