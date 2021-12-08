#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsParser;

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