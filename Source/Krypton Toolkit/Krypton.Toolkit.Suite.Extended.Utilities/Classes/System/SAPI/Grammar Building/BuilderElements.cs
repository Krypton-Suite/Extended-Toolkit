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

internal abstract class BuilderElements : GrammarBuilderBase
{
    private readonly List<GrammarBuilderBase> _items = [];

    internal List<GrammarBuilderBase> Items => _items;

    internal override string DebugSummary
    {
        get
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (GrammarBuilderBase item in _items)
            {
                if (stringBuilder.Length > 0)
                {
                    stringBuilder.Append(" ");
                }
                stringBuilder.Append(item.DebugSummary);
            }
            return stringBuilder.ToString();
        }
    }

    internal BuilderElements()
    {
    }

    public override bool Equals(object obj)
    {
        BuilderElements builderElements = obj as BuilderElements;
        if (builderElements == null)
        {
            return false;
        }
        if (builderElements.Count != Count || builderElements.Items.Count != Items.Count)
        {
            return false;
        }
        for (int i = 0; i < Items.Count; i++)
        {
            if (!Items[i].Equals(builderElements.Items[i]))
            {
                return false;
            }
        }
        return true;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    protected void Optimize(Collection<RuleElement> newRules)
    {
        SortedDictionary<int, Collection<BuilderElements>> sortedDictionary = new SortedDictionary<int, Collection<BuilderElements>>();
        GetDictionaryElements(sortedDictionary);
        int[] array = new int[sortedDictionary.Keys.Count];
        int num = array.Length - 1;
        foreach (int key in sortedDictionary.Keys)
        {
            array[num--] = key;
        }
        for (int i = 0; i < array.Length && array[i] >= 3; i++)
        {
            Collection<BuilderElements> collection = sortedDictionary[array[i]];
            for (int j = 0; j < collection.Count; j++)
            {
                RuleElement ruleElement = null;
                RuleRefElement ruleRefElement = null;
                for (int k = j + 1; k < collection.Count; k++)
                {
                    if (collection[j] == null || !collection[j].Equals(collection[k]))
                    {
                        continue;
                    }
                    BuilderElements builderElements = collection[k];
                    BuilderElements parent = builderElements.Parent;
                    if (builderElements is SemanticKeyElement)
                    {
                        parent.Items[parent.Items.IndexOf(builderElements)] = collection[j];
                    }
                    else
                    {
                        if (ruleElement == null)
                        {
                            ruleElement = new RuleElement(builderElements, "_");
                            newRules.Add(ruleElement);
                        }
                        if (ruleRefElement == null)
                        {
                            ruleRefElement = new RuleRefElement(ruleElement);
                            collection[j].Parent.Items[collection[j].Parent.Items.IndexOf(collection[j])] = ruleRefElement;
                        }
                        parent.Items[builderElements.Parent.Items.IndexOf(builderElements)] = ruleRefElement;
                    }
                    builderElements.RemoveDictionaryElements(sortedDictionary);
                    collection[k] = null;
                }
            }
        }
    }

    internal void Add(string phrase)
    {
        _items.Add(new GrammarBuilderPhrase(phrase));
    }

    internal void Add(GrammarBuilder builder)
    {
        foreach (GrammarBuilderBase item in builder.InternalBuilder.Items)
        {
            _items.Add(item);
        }
    }

    internal void Add(GrammarBuilderBase item)
    {
        _items.Add(item);
    }

    internal void CloneItems(BuilderElements builders)
    {
        foreach (GrammarBuilderBase item in builders.Items)
        {
            _items.Add(item);
        }
    }

    internal void CreateChildrenElements(IElementFactory elementFactory, IRule parent, IdentifierCollection ruleIds)
    {
        foreach (GrammarBuilderBase item in Items)
        {
            IElement element = item.CreateElement(elementFactory, parent, parent, ruleIds);
            if (element != null)
            {
                element.PostParse(parent);
                elementFactory.AddElement(parent, element);
            }
        }
    }

    internal void CreateChildrenElements(IElementFactory elementFactory, IItem parent, IRule rule, IdentifierCollection ruleIds)
    {
        foreach (GrammarBuilderBase item in Items)
        {
            IElement element = item.CreateElement(elementFactory, parent, rule, ruleIds);
            if (element != null)
            {
                element.PostParse(parent);
                elementFactory.AddElement(parent, element);
            }
        }
    }

    internal override int CalcCount(BuilderElements parent)
    {
        base.CalcCount(parent);
        int num = 1;
        foreach (GrammarBuilderBase item in Items)
        {
            num += item.CalcCount(this);
        }
        Count = num;
        return num;
    }

    private void GetDictionaryElements(SortedDictionary<int, Collection<BuilderElements>> dict)
    {
        foreach (GrammarBuilderBase item in Items)
        {
            BuilderElements builderElements = item as BuilderElements;
            if (builderElements != null)
            {
                if (!dict.ContainsKey(builderElements.Count))
                {
                    dict.Add(builderElements.Count, []);
                }
                dict[builderElements.Count].Add(builderElements);
                builderElements.GetDictionaryElements(dict);
            }
        }
    }

    private void RemoveDictionaryElements(SortedDictionary<int, Collection<BuilderElements>> dict)
    {
        foreach (GrammarBuilderBase item in Items)
        {
            BuilderElements builderElements = item as BuilderElements;
            if (builderElements != null)
            {
                builderElements.RemoveDictionaryElements(dict);
                dict[builderElements.Count].Remove(builderElements);
            }
        }
    }
}