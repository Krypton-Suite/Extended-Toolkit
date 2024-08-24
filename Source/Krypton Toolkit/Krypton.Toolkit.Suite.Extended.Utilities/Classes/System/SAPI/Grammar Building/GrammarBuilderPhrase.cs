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

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.GrammarBuilding
{
    internal sealed class GrammarBuilderPhrase : GrammarBuilderBase
    {
        private readonly string _phrase;

        private readonly bool _subsetMatching;

        private readonly MatchMode _matchMode;

        internal override string DebugSummary => $"‘{_phrase}’";

        internal GrammarBuilderPhrase(string phrase)
            : this(phrase, false, SubsetMatchingMode.OrderedSubset)
        {
        }

        internal GrammarBuilderPhrase(string phrase, SubsetMatchingMode subsetMatchingCriteria)
            : this(phrase, true, subsetMatchingCriteria)
        {
        }

        private GrammarBuilderPhrase(string phrase, bool subsetMatching, SubsetMatchingMode subsetMatchingCriteria)
        {
            _phrase = string.Copy(phrase);
            _subsetMatching = subsetMatching;
            switch (subsetMatchingCriteria)
            {
                case SubsetMatchingMode.OrderedSubset:
                    _matchMode = MatchMode.OrderedSubset;
                    break;
                case SubsetMatchingMode.OrderedSubsetContentRequired:
                    _matchMode = MatchMode.OrderedSubsetContentRequired;
                    break;
                case SubsetMatchingMode.Subsequence:
                    _matchMode = MatchMode.Subsequence;
                    break;
                case SubsetMatchingMode.SubsequenceContentRequired:
                    _matchMode = MatchMode.SubsequenceContentRequired;
                    break;
            }
        }

        private GrammarBuilderPhrase(string phrase, bool subsetMatching, MatchMode matchMode)
        {
            _phrase = string.Copy(phrase);
            _subsetMatching = subsetMatching;
            _matchMode = matchMode;
        }

        public override bool Equals(object obj)
        {
            GrammarBuilderPhrase grammarBuilderPhrase = obj as GrammarBuilderPhrase;
            if (grammarBuilderPhrase == null)
            {
                return false;
            }
            if (_phrase == grammarBuilderPhrase._phrase && _matchMode == grammarBuilderPhrase._matchMode)
            {
                return _subsetMatching == grammarBuilderPhrase._subsetMatching;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return _phrase.GetHashCode();
        }

        internal override GrammarBuilderBase Clone()
        {
            return new GrammarBuilderPhrase(_phrase, _subsetMatching, _matchMode);
        }

        internal override IElement CreateElement(IElementFactory elementFactory, IElement parent, IRule rule, IdentifierCollection ruleIds)
        {
            return CreatePhraseElement(elementFactory, parent);
        }

        private IElement CreatePhraseElement(IElementFactory elementFactory, IElement parent)
        {
            if (_subsetMatching)
            {
                return elementFactory.CreateSubset(parent, _phrase, _matchMode);
            }
            if (elementFactory is SrgsElementCompilerFactory)
            {
                XmlParser.ParseText(parent, _phrase, null, null, -1f, elementFactory.CreateToken);
                return null;
            }
            return elementFactory.CreateText(parent, _phrase);
        }
    }
}