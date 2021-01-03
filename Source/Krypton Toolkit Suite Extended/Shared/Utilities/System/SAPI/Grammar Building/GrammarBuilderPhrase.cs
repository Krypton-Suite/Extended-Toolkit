#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.System.Recognition;
using Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsCompiler;
using Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsParser;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.GrammarBuilding
{
    internal sealed class GrammarBuilderPhrase : GrammarBuilderBase
    {
        private readonly string _phrase;

        private readonly bool _subsetMatching;

        private readonly MatchMode _matchMode;

        internal override string DebugSummary => "‘" + _phrase + "’";

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