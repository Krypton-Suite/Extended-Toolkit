﻿#region MIT License
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

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsCompiler
{
    internal class RuleRef : ParseElement, IRuleRef, IElement
    {
        private enum SpecialRuleRefType
        {
            Null,
            Void,
            Garbage
        }

        private SpecialRuleRefType _type;

        private const string szSpecialVoid = "VOID";

        internal static IRuleRef Null => new RuleRef(SpecialRuleRefType.Null, null);

        internal static IRuleRef Void => new RuleRef(SpecialRuleRefType.Void, null);

        internal static IRuleRef Garbage => new RuleRef(SpecialRuleRefType.Garbage, null);

        private RuleRef(SpecialRuleRefType type, Rule rule)
            : base(rule)
        {
            _type = type;
        }

        internal RuleRef(ParseElementCollection parent, Backend backend, Uri uri, List<Rule> undefRules, string semanticKey, string initParameters)
            : base(parent._rule)
        {
            string originalString = uri.OriginalString;
            Rule rule = null;
            int num = originalString.IndexOf('#');
            if (num == 0)
            {
                rule = GetRuleRef(backend, originalString.Substring(1), undefRules);
            }
            else
            {
                StringBuilder stringBuilder = new StringBuilder("URL:");
                if (!string.IsNullOrEmpty(initParameters))
                {
                    stringBuilder.Append((num > 0) ? originalString.Substring(0, num) : originalString);
                    stringBuilder.Append('>');
                    stringBuilder.Append(initParameters);
                    if (num > 0)
                    {
                        stringBuilder.Append(originalString.Substring(num));
                    }
                }
                else
                {
                    stringBuilder.Append(originalString);
                }
                string text = stringBuilder.ToString();
                rule = backend.FindRule(text);
                if (rule == null)
                {
                    rule = backend.CreateRule(text, SPCFGRULEATTRIBUTES.SPRAF_Import);
                }
            }
            Arc arc = backend.RuleTransition(rule, _rule, 1f);
            if (!string.IsNullOrEmpty(semanticKey))
            {
                backend.AddPropertyTag(arc, arc, new CfgGrammar.CfgProperty
                {
                    _pszName = "SemanticKey",
                    _comValue = semanticKey,
                    _comType = VarEnum.VT_EMPTY
                });
            }
            parent.AddArc(arc);
        }

        internal void InitSpecialRuleRef(Backend backend, ParseElementCollection parent)
        {
            Rule rule = null;
            switch (_type)
            {
                case SpecialRuleRefType.Null:
                    parent.AddArc(backend.EpsilonTransition(1f));
                    break;
                case SpecialRuleRefType.Void:
                    rule = backend.FindRule("VOID");
                    if (rule == null)
                    {
                        rule = backend.CreateRule("VOID", (SPCFGRULEATTRIBUTES)0);
                        ((IElement)rule).PostParse((IElement)parent);
                    }
                    parent.AddArc(backend.RuleTransition(rule, parent._rule, 1f));
                    break;
                case SpecialRuleRefType.Garbage:
                    {
                        OneOf oneOf = new OneOf(parent._rule, backend);
                        oneOf.AddArc(backend.RuleTransition(CfgGrammar.SPRULETRANS_WILDCARD, parent._rule, 0.5f));
                        oneOf.AddArc(backend.EpsilonTransition(0.5f));
                        ((IElement)oneOf).PostParse((IElement)parent);
                        break;
                    }
            }
        }

        private static Rule GetRuleRef(Backend backend, string sRuleId, List<Rule> undefRules)
        {
            Rule rule = backend.FindRule(sRuleId);
            if (rule == null)
            {
                rule = backend.CreateRule(sRuleId, (SPCFGRULEATTRIBUTES)0);
                undefRules.Insert(0, rule);
            }
            return rule;
        }
    }
}