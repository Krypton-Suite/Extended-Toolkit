#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsParser;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.GrammarBuilding
{
    [DebuggerDisplay("{DebugSummary}")]
    internal sealed class RuleRefElement : GrammarBuilderBase
    {
        private readonly RuleElement _rule;

        private readonly string _semanticKey;

        internal RuleElement Rule => _rule;

        internal override string DebugSummary => "#" + Rule.Name + ((_semanticKey != null) ? (":" + _semanticKey) : "");

        internal RuleRefElement(RuleElement rule)
        {
            _rule = rule;
        }

        internal RuleRefElement(RuleElement rule, string semanticKey)
        {
            _rule = rule;
            _semanticKey = semanticKey;
        }

        public override bool Equals(object obj)
        {
            RuleRefElement ruleRefElement = obj as RuleRefElement;
            if (ruleRefElement == null)
            {
                return false;
            }
            if (_semanticKey == ruleRefElement._semanticKey)
            {
                return _rule.Equals(ruleRefElement._rule);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        internal void Add(GrammarBuilderBase item)
        {
            _rule.Add(item);
        }

        internal override GrammarBuilderBase Clone()
        {
            return new RuleRefElement(_rule, _semanticKey);
        }

        internal void CloneItems(RuleRefElement builders)
        {
            _rule.CloneItems(builders._rule);
        }

        internal override IElement CreateElement(IElementFactory elementFactory, IElement parent, IRule rule, IdentifierCollection ruleIds)
        {
            return elementFactory.CreateRuleRef(parent, new Uri("#" + Rule.RuleName, UriKind.Relative), _semanticKey, null);
        }
    }
}