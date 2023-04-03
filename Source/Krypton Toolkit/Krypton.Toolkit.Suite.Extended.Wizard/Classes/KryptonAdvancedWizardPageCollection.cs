#region MIT License
/*
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
 * Base code by Steve Bate 2003 - 2017 (https://github.com/SteveBate/AdvancedWizard), modifications by Peter Wagner (aka Wagnerp) 2021 - 2023.
 *
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Wizard
{
    [Serializable]
    public class KryptonAdvancedWizardPageCollection : IList
    {
        public event EventHandler<WizardPageEventArgs> OnPageAdded;

        public KryptonAdvancedWizardPageCollection() : this(5) { }

        public KryptonAdvancedWizardPageCollection(int initialCount) => _items = new ArrayList(initialCount);

        bool IList.Contains(object wizardPage) => _items.Contains(wizardPage);

        public bool Contains(KryptonAdvancedWizardPage page) => _items.Contains(page);

        public int Count => _items.Count;

        public bool IsSynchronized => _items.IsSynchronized;

        public object SyncRoot => _items.SyncRoot;

        public void CopyTo(KryptonAdvancedWizardPageCollection pages) => pages.Items.AddRange(Items);

        public void Clear() => _items.Clear();

        public int IndexOf(KryptonAdvancedWizardPage page) => _items.IndexOf(page);

        public void Insert(int index, KryptonAdvancedWizardPage page) => _items.Insert(index, page);

        public bool IsFixedSize => _items.IsFixedSize;

        public bool IsReadOnly => _items.IsReadOnly;

        public KryptonAdvancedWizardPage this[int index]
        {
            get => (KryptonAdvancedWizardPage)_items[index];
            set => _items[index] = value;
        }

        object IList.this[int index]
        {
            get => this[index];
            set
            {
                var page = value as KryptonAdvancedWizardPage;
                if (page != null)
                {
                    this[index] = page;
                }
            }
        }

        public void CopyTo(Array array, int index)
        {
            if (array.Length - index < Count)
            {
                throw new ArgumentException("The Array to Copy To must have enough elements to copy all the items from this collection.", nameof(array));
            }

            for (int i = 0; i < Count; i++)
            {
                array.SetValue(_items[i], index + i);
            }
        }

        public int Add(KryptonAdvancedWizardPage page)
        {
            OnPageAdded?.Invoke(this, new WizardPageEventArgs(page));
            return _items.Add(page);
        }

        public void Remove(KryptonAdvancedWizardPage page) => _items.Remove(page);

        public void RemoveAt(int index) => _items.RemoveAt(index);

        public IEnumerator GetEnumerator() => _items.GetEnumerator();

        public IEnumerator GetEnumerator(int index, int count) => _items.GetEnumerator(index, count);

        internal ArrayList Items => _items;

        int IList.IndexOf(object @object) => _items.IndexOf(@object);

        int IList.Add(object @object)
        {
            var o = @object as KryptonAdvancedWizardPage;
            if (o == null)
            {
                return -1;
            }

            return Add(o);
        }

        void IList.Insert(int index, object @object)
        {
            if (!(@object is KryptonAdvancedWizardPage))
            {
                throw new ArgumentException("This collection can only contain WizardPage objects.", nameof(@object));
            }

            _items.Insert(index, @object);
        }

        void IList.Remove(object @object)
        {
            if (!(@object is KryptonAdvancedWizardPage))
            {
                return;
            }

            _items.Remove(@object);
        }

        private readonly ArrayList _items;
    }
}