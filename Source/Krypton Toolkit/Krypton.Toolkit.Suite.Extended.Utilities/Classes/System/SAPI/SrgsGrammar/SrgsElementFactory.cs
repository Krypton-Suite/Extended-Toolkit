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
    internal class SrgsElementFactory : IElementFactory
    {
        private SrgsGrammar _grammar;

        private static readonly char[] _pronSeparator = new char[5]
        {
            ' ',
            '\t',
            '\n',
            '\r',
            ';'
        };

        IGrammar IElementFactory.Grammar => _grammar;

        IRuleRef IElementFactory.Null => SrgsRuleRef.Null;

        IRuleRef IElementFactory.Void => SrgsRuleRef.Void;

        IRuleRef IElementFactory.Garbage => SrgsRuleRef.Garbage;

        internal SrgsElementFactory(SrgsGrammar grammar)
        {
            _grammar = grammar;
        }

        void IElementFactory.RemoveAllRules()
        {
        }

        IPropertyTag IElementFactory.CreatePropertyTag(IElement parent)
        {
            return new SrgsNameValueTag();
        }

        ISemanticTag IElementFactory.CreateSemanticTag(IElement parent)
        {
            return new SrgsSemanticInterpretationTag();
        }

        IElementText IElementFactory.CreateText(IElement parent, string value)
        {
            return new SrgsText(value);
        }

        IToken IElementFactory.CreateToken(IElement parent, string content, string pronunciation, string display, float reqConfidence)
        {
            SrgsToken srgsToken = new SrgsToken(content);
            if (!string.IsNullOrEmpty(pronunciation))
            {
                int num = 0;
                int num2 = 0;
                while (num < pronunciation.Length)
                {
                    num2 = pronunciation.IndexOfAny(_pronSeparator, num);
                    if (num2 == -1)
                    {
                        num2 = pronunciation.Length;
                    }
                    string text = pronunciation.Substring(num, num2 - num);
                    switch (_grammar.PhoneticAlphabet)
                    {
                        case AlphabetType.Sapi:
                            text = PhonemeConverter.ConvertPronToId(text, _grammar.Culture.LCID);
                            break;
                        case AlphabetType.Ipa:
                            PhonemeConverter.ValidateUpsIds(text);
                            break;
                        case AlphabetType.Ups:
                            text = PhonemeConverter.UpsConverter.ConvertPronToId(text);
                            break;
                    }
                    num = num2 + 1;
                }
                srgsToken.Pronunciation = pronunciation;
            }
            if (!string.IsNullOrEmpty(display))
            {
                srgsToken.Display = display;
            }
            if (reqConfidence >= 0f)
            {
                throw new NotSupportedException(SR.Get(SRID.ReqConfidenceNotSupported));
            }
            return srgsToken;
        }

        IItem IElementFactory.CreateItem(IElement parent, IRule rule, int minRepeat, int maxRepeat, float repeatProbability, float weight)
        {
            SrgsItem srgsItem = new SrgsItem();
            if (minRepeat != 1 || maxRepeat != 1)
            {
                srgsItem.SetRepeat(minRepeat, maxRepeat);
            }
            srgsItem.RepeatProbability = repeatProbability;
            srgsItem.Weight = weight;
            return srgsItem;
        }

        IRuleRef IElementFactory.CreateRuleRef(IElement parent, Uri srgsUri)
        {
            return new SrgsRuleRef(srgsUri);
        }

        IRuleRef IElementFactory.CreateRuleRef(IElement parent, Uri srgsUri, string semanticKey, string parameters)
        {
            return new SrgsRuleRef(semanticKey, parameters, srgsUri);
        }

        IOneOf IElementFactory.CreateOneOf(IElement parent, IRule rule)
        {
            return new SrgsOneOf();
        }

        ISubset IElementFactory.CreateSubset(IElement parent, string text, MatchMode matchMode)
        {
            SubsetMatchingMode matchingMode = SubsetMatchingMode.Subsequence;
            switch (matchMode)
            {
                case MatchMode.OrderedSubset:
                    matchingMode = SubsetMatchingMode.OrderedSubset;
                    break;
                case MatchMode.OrderedSubsetContentRequired:
                    matchingMode = SubsetMatchingMode.OrderedSubsetContentRequired;
                    break;
                case MatchMode.Subsequence:
                    matchingMode = SubsetMatchingMode.Subsequence;
                    break;
                case MatchMode.SubsequenceContentRequired:
                    matchingMode = SubsetMatchingMode.SubsequenceContentRequired;
                    break;
            }
            return new SrgsSubset(text, matchingMode);
        }

        void IElementFactory.InitSpecialRuleRef(IElement parent, IRuleRef special)
        {
        }

        void IElementFactory.AddScript(IGrammar grammar, string sRule, string code)
        {
            SrgsGrammar srgsGrammar = (SrgsGrammar)grammar;
            SrgsRule srgsRule = srgsGrammar.Rules[sRule];
            if (srgsRule != null)
            {
                srgsRule.Script += code;
            }
            else
            {
                srgsGrammar.AddScript(sRule, code);
            }
        }

        string IElementFactory.AddScript(IGrammar grammar, string sRule, string code, string filename, int line)
        {
            return code;
        }

        void IElementFactory.AddScript(IGrammar grammar, string script, string filename, int line)
        {
            SrgsGrammar srgsGrammar = (SrgsGrammar)grammar;
            srgsGrammar.AddScript(null, script);
        }

        void IElementFactory.AddItem(IOneOf oneOf, IItem value)
        {
            ((SrgsOneOf)oneOf).Add((SrgsItem)value);
        }

        void IElementFactory.AddElement(IRule rule, IElement value)
        {
            ((SrgsRule)rule).Elements.Add((SrgsElement)value);
        }

        void IElementFactory.AddElement(IItem item, IElement value)
        {
            ((SrgsItem)item).Elements.Add((SrgsElement)value);
        }
    }
}
