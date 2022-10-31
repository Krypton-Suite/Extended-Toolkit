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

using Krypton.Toolkit.Suite.Extended.Utilities.System.Recognition;
using Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsParser;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.GrammarBuilding
{
    internal sealed class SemanticKeyElement : BuilderElements
    {
        private readonly string _semanticKey;

        private readonly RuleRefElement _ruleRef;

        internal override string DebugSummary => _ruleRef.Rule.DebugSummary;

        internal SemanticKeyElement(string semanticKey)
        {
            _semanticKey = semanticKey;
            RuleElement ruleElement = new RuleElement(semanticKey);
            _ruleRef = new RuleRefElement(ruleElement, _semanticKey);
            base.Items.Add(ruleElement);
            base.Items.Add(_ruleRef);
        }

        public override bool Equals(object obj)
        {
            SemanticKeyElement semanticKeyElement = obj as SemanticKeyElement;
            if (semanticKeyElement == null)
            {
                return false;
            }
            if (!base.Equals(obj))
            {
                return false;
            }
            return _semanticKey == semanticKeyElement._semanticKey;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        internal new void Add(string phrase)
        {
            _ruleRef.Add(new GrammarBuilderPhrase(phrase));
        }

        internal new void Add(GrammarBuilder builder)
        {
            foreach (GrammarBuilderBase item in builder.InternalBuilder.Items)
            {
                _ruleRef.Add(item);
            }
        }

        internal override GrammarBuilderBase Clone()
        {
            SemanticKeyElement semanticKeyElement = new SemanticKeyElement(_semanticKey);
            semanticKeyElement._ruleRef.CloneItems(_ruleRef);
            return semanticKeyElement;
        }

        internal override IElement CreateElement(IElementFactory elementFactory, IElement parent, IRule rule, IdentifierCollection ruleIds)
        {
            _ruleRef.Rule.CreateElement(elementFactory, parent, rule, ruleIds);
            return _ruleRef.CreateElement(elementFactory, parent, rule, ruleIds);
        }
    }
}