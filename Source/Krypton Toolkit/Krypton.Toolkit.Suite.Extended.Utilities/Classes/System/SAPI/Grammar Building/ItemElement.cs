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

internal sealed class ItemElement : BuilderElements
{
    private readonly int _minRepeat = 1;

    private readonly int _maxRepeat = 1;

    internal ItemElement(GrammarBuilderBase builder)
        : this(builder, 1, 1)
    {
    }

    internal ItemElement(int minRepeat, int maxRepeat)
        : this((GrammarBuilderBase)null, minRepeat, maxRepeat)
    {
    }

    internal ItemElement(GrammarBuilderBase builder, int minRepeat, int maxRepeat)
    {
        if (builder != null)
        {
            Add(builder);
        }
        _minRepeat = minRepeat;
        _maxRepeat = maxRepeat;
    }

    internal ItemElement(List<GrammarBuilderBase> builders, int minRepeat, int maxRepeat)
    {
        foreach (GrammarBuilderBase builder in builders)
        {
            base.Items.Add(builder);
        }
        _minRepeat = minRepeat;
        _maxRepeat = maxRepeat;
    }

    internal ItemElement(GrammarBuilder builders)
    {
        foreach (GrammarBuilderBase item in builders.InternalBuilder.Items)
        {
            base.Items.Add(item);
        }
    }

    public override bool Equals(object obj)
    {
        ItemElement itemElement = obj as ItemElement;
        if (itemElement == null)
        {
            return false;
        }
        if (!base.Equals(obj))
        {
            return false;
        }
        if (_minRepeat == itemElement._minRepeat)
        {
            return _maxRepeat == itemElement._maxRepeat;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    internal override GrammarBuilderBase Clone()
    {
        ItemElement itemElement = new ItemElement(_minRepeat, _maxRepeat);
        itemElement.CloneItems(this);
        return itemElement;
    }

    internal override IElement CreateElement(IElementFactory elementFactory, IElement parent, IRule rule, IdentifierCollection ruleIds)
    {
        IItem item = elementFactory.CreateItem(parent, rule, _minRepeat, _maxRepeat, 0.5f, 1f);
        CreateChildrenElements(elementFactory, item, rule, ruleIds);
        return item;
    }
}