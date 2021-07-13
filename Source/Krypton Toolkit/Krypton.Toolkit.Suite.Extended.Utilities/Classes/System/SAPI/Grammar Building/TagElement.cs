#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.System.Recognition;
using Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsParser;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.GrammarBuilding
{
    internal sealed class TagElement : BuilderElements
    {
        private readonly object _value;

        internal override string DebugSummary => string.Concat(base.DebugSummary, " {", _value, "}");

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