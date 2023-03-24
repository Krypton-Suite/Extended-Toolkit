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

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.GrammarBuilding
{
    [DebuggerDisplay("{DebugSummary}")]
    internal sealed class RuleRefElement : GrammarBuilderBase
    {
        private readonly RuleElement _rule;

        private readonly string _semanticKey;

        internal RuleElement Rule => _rule;

        internal override string DebugSummary => $"#{Rule.Name}{((_semanticKey != null) ? (":" + _semanticKey) : "")}";

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
            return elementFactory.CreateRuleRef(parent, new Uri($"#{Rule.RuleName}", UriKind.Relative), _semanticKey, null);
        }
    }
}