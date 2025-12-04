#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.GrammarBuilding;

internal sealed class RuleElement : BuilderElements
{
    private readonly string _name;

    private string _ruleName;

    private IRule? _rule;

    internal override string DebugSummary => $"{_name}={base.DebugSummary}";

    internal string Name => _name;

    internal string RuleName => _ruleName;

    internal RuleElement(string name)
    {
        _name = name;
    }

    internal RuleElement(GrammarBuilderBase builder, string name)
        : this(name)
    {
        Add(builder);
    }

    public override bool Equals(object obj)
    {
        RuleElement? ruleElement = obj as RuleElement;
        if (ruleElement == null)
        {
            return false;
        }
        if (!base.Equals(obj))
        {
            return false;
        }
        return _name == ruleElement._name;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    internal override GrammarBuilderBase Clone()
    {
        RuleElement ruleElement = new RuleElement(_name);
        ruleElement.CloneItems(this);
        return ruleElement;
    }

    internal override IElement CreateElement(IElementFactory elementFactory, IElement parent, IRule rule, IdentifierCollection ruleIds)
    {
        if (_rule == null)
        {
            IGrammar grammar = elementFactory.Grammar;
            _ruleName = ruleIds.CreateNewIdentifier(Name);
            _rule = grammar.CreateRule(_ruleName, RulePublic.False, RuleDynamic.NotSet, false);
            CreateChildrenElements(elementFactory, _rule, ruleIds);
            _rule.PostParse(grammar);
        }
        return _rule;
    }

    internal override int CalcCount(BuilderElements parent)
    {
        _rule = null;
        return base.CalcCount(parent);
    }
}