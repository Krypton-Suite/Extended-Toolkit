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

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.GrammarBuilding
{
    internal sealed class TagElement : BuilderElements
    {
        private readonly object _value;

        internal override string DebugSummary => $"{base.DebugSummary} {{{_value}}}";

        internal TagElement(object value)
        {
            _value = value;
        }

        internal TagElement(GrammarBuilderBase builder, object value)
            : this(value)
        {
            Add(builder);
        }

        internal TagElement(GrammarBuilder builder, object value)
            : this(value)
        {
            Add(builder);
        }

        public override bool Equals(object obj)
        {
            TagElement tagElement = obj as TagElement;
            if (tagElement == null)
            {
                return false;
            }
            if (!base.Equals(obj))
            {
                return false;
            }
            return _value.Equals(tagElement._value);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        internal override GrammarBuilderBase Clone()
        {
            TagElement tagElement = new TagElement(_value);
            tagElement.CloneItems(this);
            return tagElement;
        }

        internal override IElement CreateElement(IElementFactory elementFactory, IElement parent, IRule rule, IdentifierCollection ruleIds)
        {
            IItem item = parent as IItem;
            if (item != null)
            {
                CreateChildrenElements(elementFactory, item, rule, ruleIds);
            }
            else if (parent == rule)
            {
                CreateChildrenElements(elementFactory, rule, ruleIds);
            }
            IPropertyTag propertyTag = elementFactory.CreatePropertyTag(parent);
            propertyTag.NameValue(parent, null, _value);
            return propertyTag;
        }
    }
}