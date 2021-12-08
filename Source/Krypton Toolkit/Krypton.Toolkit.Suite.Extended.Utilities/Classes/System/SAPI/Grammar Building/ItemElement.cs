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
}