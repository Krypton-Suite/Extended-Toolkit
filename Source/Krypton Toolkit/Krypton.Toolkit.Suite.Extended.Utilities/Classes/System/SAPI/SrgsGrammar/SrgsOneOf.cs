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

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsGrammar
{
    [Serializable]
    [DebuggerDisplay("{DebuggerDisplayString ()}")]
    [DebuggerTypeProxy(typeof(OneOfDebugDisplay))]
    public class SrgsOneOf : SrgsElement, IOneOf, IElement
    {
        internal class OneOfDebugDisplay
        {
            private Collection<SrgsItem> _items;

            [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
            public SrgsItem[] AKeys
            {
                get
                {
                    SrgsItem[] array = new SrgsItem[_items.Count];
                    for (int i = 0; i < _items.Count; i++)
                    {
                        array[i] = _items[i];
                    }
                    return array;
                }
            }

            public OneOfDebugDisplay(SrgsOneOf oneOf)
            {
                _items = oneOf._items;
            }
        }

        private SrgsItemList _items = new();

        public Collection<SrgsItem> Items => _items;

        internal override SrgsElement[] Children
        {
            get
            {
                SrgsElement[] array = new SrgsElement[_items.Count];
                int num = 0;
                foreach (SrgsItem item in _items)
                {
                    array[num++] = item;
                }
                return array;
            }
        }

        public SrgsOneOf()
        {
        }

        public SrgsOneOf(params string[] items)
            : this()
        {
            Helpers.ThrowIfNull(items, "items");
            int num = 0;
            while (true)
            {
                if (num < items.Length)
                {
                    if (items[num] == null)
                    {
                        break;
                    }
                    _items.Add(new SrgsItem(items[num]));
                    num++;
                    continue;
                }
                return;
            }
            throw new ArgumentNullException("items", SR.Get(SRID.ParamsEntryNullIllegal));
        }

        public SrgsOneOf(params SrgsItem[] items)
            : this()
        {
            Helpers.ThrowIfNull(items, "items");
            int num = 0;
            while (true)
            {
                if (num < items.Length)
                {
                    SrgsItem srgsItem = items[num];
                    if (srgsItem == null)
                    {
                        break;
                    }
                    _items.Add(srgsItem);
                    num++;
                    continue;
                }
                return;
            }
            throw new ArgumentNullException("items", SR.Get(SRID.ParamsEntryNullIllegal));
        }

        public void Add(SrgsItem item)
        {
            Helpers.ThrowIfNull(item, "item");
            Items.Add(item);
        }

        internal override void WriteSrgs(XmlWriter writer)
        {
            writer.WriteStartElement("one-of");
            foreach (SrgsItem item in _items)
            {
                item.WriteSrgs(writer);
            }
            writer.WriteEndElement();
        }

        internal override string DebuggerDisplayString()
        {
            StringBuilder stringBuilder = new StringBuilder("SrgsOneOf Count = ");
            stringBuilder.Append(_items.Count);
            return stringBuilder.ToString();
        }
    }
}
