#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.System.Recognition;
using Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsGrammar;
using Krypton.Toolkit.Suite.Extended.Utilities.SystemInternal.Speech;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsParser
{
    internal class SrgsDocumentParser : ISrgsParser
    {
        private SrgsGrammar.SrgsGrammar _grammar;

        private IElementFactory _parser;

        public IElementFactory ElementFactory
        {
            set
            {
                _parser = value;
            }
        }

        internal SrgsDocumentParser(SrgsGrammar.SrgsGrammar grammar)
        {
            _grammar = grammar;
        }

        public void Parse()
        {
            try
            {
                ProcessGrammarElement(_grammar, _parser.Grammar);
            }
            catch
            {
                _parser.RemoveAllRules();
                throw;
            }
        }

        private void ProcessGrammarElement(SrgsGrammar.SrgsGrammar source, IGrammar grammar)
        {
            grammar.Culture = source.Culture;
            grammar.Mode = source.Mode;
            if (source.Root != null)
            {
                grammar.Root = source.Root.Id;
            }
            grammar.TagFormat = source.TagFormat;
            grammar.XmlBase = source.XmlBase;
            grammar.GlobalTags = source.GlobalTags;
            grammar.PhoneticAlphabet = source.PhoneticAlphabet;
            foreach (SrgsRule rule2 in source.Rules)
            {
                IRule rule = ParseRule(grammar, rule2);
                rule.PostParse(grammar);
            }
            grammar.AssemblyReferences = source.AssemblyReferences;
            grammar.CodeBehind = source.CodeBehind;
            grammar.Debug = source.Debug;
            grammar.ImportNamespaces = source.ImportNamespaces;
            grammar.Language = ((source.Language == null) ? "C#" : source.Language);
            grammar.Namespace = source.Namespace;
            _parser.AddScript(grammar, source.Script, null, -1);
            grammar.PostParse(null);
        }

        private IRule ParseRule(IGrammar grammar, SrgsRule srgsRule)
        {
            string id = srgsRule.Id;
            bool hasSCript = srgsRule.OnInit != null || srgsRule.OnParse != null || srgsRule.OnError != null || srgsRule.OnRecognition != null;
            IRule rule = grammar.CreateRule(id, (srgsRule.Scope != 0) ? RulePublic.False : RulePublic.True, srgsRule.Dynamic, hasSCript);
            if (srgsRule.OnInit != null)
            {
                rule.CreateScript(grammar, id, srgsRule.OnInit, RuleMethodScript.onInit);
            }
            if (srgsRule.OnParse != null)
            {
                rule.CreateScript(grammar, id, srgsRule.OnParse, RuleMethodScript.onParse);
            }
            if (srgsRule.OnError != null)
            {
                rule.CreateScript(grammar, id, srgsRule.OnError, RuleMethodScript.onError);
            }
            if (srgsRule.OnRecognition != null)
            {
                rule.CreateScript(grammar, id, srgsRule.OnRecognition, RuleMethodScript.onRecognition);
            }
            if (srgsRule.Script.Length > 0)
            {
                _parser.AddScript(grammar, id, srgsRule.Script);
            }
            rule.BaseClass = srgsRule.BaseClass;
            foreach (SrgsElement sortedTagElement in GetSortedTagElements(srgsRule.Elements))
            {
                ProcessChildNodes(sortedTagElement, rule, rule);
            }
            return rule;
        }

        private IRuleRef ParseRuleRef(SrgsRuleRef srgsRuleRef, IElement parent)
        {
            IRuleRef ruleRef = null;
            bool flag = true;
            if (srgsRuleRef == SrgsRuleRef.Null)
            {
                ruleRef = _parser.Null;
            }
            else if (srgsRuleRef == SrgsRuleRef.Void)
            {
                ruleRef = _parser.Void;
            }
            else if (srgsRuleRef == SrgsRuleRef.Garbage)
            {
                ruleRef = _parser.Garbage;
            }
            else
            {
                ruleRef = _parser.CreateRuleRef(parent, srgsRuleRef.Uri, srgsRuleRef.SemanticKey, srgsRuleRef.Params);
                flag = false;
            }
            if (flag)
            {
                _parser.InitSpecialRuleRef(parent, ruleRef);
            }
            ruleRef.PostParse(parent);
            return ruleRef;
        }

        private IOneOf ParseOneOf(SrgsOneOf srgsOneOf, IElement parent, IRule rule)
        {
            IOneOf oneOf = _parser.CreateOneOf(parent, rule);
            foreach (SrgsItem item in srgsOneOf.Items)
            {
                ProcessChildNodes(item, oneOf, rule);
            }
            oneOf.PostParse(parent);
            return oneOf;
        }

        private IItem ParseItem(SrgsItem srgsItem, IElement parent, IRule rule)
        {
            IItem item = _parser.CreateItem(parent, rule, srgsItem.MinRepeat, srgsItem.MaxRepeat, srgsItem.RepeatProbability, srgsItem.Weight);
            foreach (SrgsElement sortedTagElement in GetSortedTagElements(srgsItem.Elements))
            {
                ProcessChildNodes(sortedTagElement, item, rule);
            }
            item.PostParse(parent);
            return item;
        }

        private IToken ParseToken(SrgsToken srgsToken, IElement parent)
        {
            return _parser.CreateToken(parent, srgsToken.Text, srgsToken.Pronunciation, srgsToken.Display, -1f);
        }

        private void ParseText(IElement parent, string sChars, string pronunciation, string display, float reqConfidence)
        {
            XmlParser.ParseText(parent, sChars, pronunciation, display, reqConfidence, _parser.CreateToken);
        }

        private ISubset ParseSubset(SrgsSubset srgsSubset, IElement parent)
        {
            MatchMode matchMode = MatchMode.Subsequence;
            switch (srgsSubset.MatchingMode)
            {
                case SubsetMatchingMode.OrderedSubset:
                    matchMode = MatchMode.OrderedSubset;
                    break;
                case SubsetMatchingMode.OrderedSubsetContentRequired:
                    matchMode = MatchMode.OrderedSubsetContentRequired;
                    break;
                case SubsetMatchingMode.Subsequence:
                    matchMode = MatchMode.Subsequence;
                    break;
                case SubsetMatchingMode.SubsequenceContentRequired:
                    matchMode = MatchMode.SubsequenceContentRequired;
                    break;
            }
            return _parser.CreateSubset(parent, srgsSubset.Text, matchMode);
        }

        private ISemanticTag ParseSemanticTag(SrgsSemanticInterpretationTag srgsTag, IElement parent)
        {
            ISemanticTag semanticTag = _parser.CreateSemanticTag(parent);
            semanticTag.Content(parent, srgsTag.Script, 0);
            semanticTag.PostParse(parent);
            return semanticTag;
        }

        private IPropertyTag ParseNameValueTag(SrgsNameValueTag srgsTag, IElement parent)
        {
            IPropertyTag propertyTag = _parser.CreatePropertyTag(parent);
            propertyTag.NameValue(parent, srgsTag.Name, srgsTag.Value);
            propertyTag.PostParse(parent);
            return propertyTag;
        }

        private void ProcessChildNodes(SrgsElement srgsElement, IElement parent, IRule rule)
        {
            Type type = srgsElement.GetType();
            IElement element = null;
            IRule rule2 = parent as IRule;
            IItem item = parent as IItem;
            if (type == typeof(SrgsRuleRef))
            {
                element = ParseRuleRef((SrgsRuleRef)srgsElement, parent);
            }
            else if (type == typeof(SrgsOneOf))
            {
                element = ParseOneOf((SrgsOneOf)srgsElement, parent, rule);
            }
            else if (type == typeof(SrgsItem))
            {
                element = ParseItem((SrgsItem)srgsElement, parent, rule);
            }
            else if (type == typeof(SrgsToken))
            {
                element = ParseToken((SrgsToken)srgsElement, parent);
            }
            else if (type == typeof(SrgsNameValueTag))
            {
                element = ParseNameValueTag((SrgsNameValueTag)srgsElement, parent);
            }
            else if (type == typeof(SrgsSemanticInterpretationTag))
            {
                element = ParseSemanticTag((SrgsSemanticInterpretationTag)srgsElement, parent);
            }
            else if (type == typeof(SrgsSubset))
            {
                element = ParseSubset((SrgsSubset)srgsElement, parent);
            }
            else if (type == typeof(SrgsText))
            {
                SrgsText srgsText = (SrgsText)srgsElement;
                string text = srgsText.Text;
                IElementText value = _parser.CreateText(parent, text);
                ParseText(parent, text, null, null, -1f);
                if (rule2 != null)
                {
                    _parser.AddElement(rule2, value);
                }
                else if (item != null)
                {
                    _parser.AddElement(item, value);
                }
                else
                {
                    XmlParser.ThrowSrgsException(SRID.InvalidElement);
                }
            }
            else
            {
                XmlParser.ThrowSrgsException(SRID.InvalidElement);
            }
            IOneOf oneOf = parent as IOneOf;
            if (oneOf != null)
            {
                IItem item2 = element as IItem;
                if (item2 != null)
                {
                    _parser.AddItem(oneOf, item2);
                }
                else
                {
                    XmlParser.ThrowSrgsException(SRID.InvalidElement);
                }
            }
            else if (rule2 != null)
            {
                _parser.AddElement(rule2, element);
            }
            else if (item != null)
            {
                _parser.AddElement(item, element);
            }
            else
            {
                XmlParser.ThrowSrgsException(SRID.InvalidElement);
            }
        }

        private IEnumerable<SrgsElement> GetSortedTagElements(Collection<SrgsElement> elements)
        {
            if (_grammar.TagFormat == SrgsTagFormat.KeyValuePairs)
            {
                List<SrgsElement> list = new List<SrgsElement>();
                foreach (SrgsElement element in elements)
                {
                    if (!(element is SrgsNameValueTag))
                    {
                        list.Add(element);
                    }
                }
                {
                    foreach (SrgsElement element2 in elements)
                    {
                        if (element2 is SrgsNameValueTag)
                        {
                            list.Add(element2);
                        }
                    }
                    return list;
                }
            }
            return elements;
        }
    }
}