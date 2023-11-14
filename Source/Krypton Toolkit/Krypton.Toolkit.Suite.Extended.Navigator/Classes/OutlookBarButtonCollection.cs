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
 */
#endregion

using System.Collections;
// ReSharper disable ConditionIsAlwaysTrueOrFalse

namespace Krypton.Toolkit.Suite.Extended.Navigator
{
    public class OutlookBarButtonCollection : CollectionBase
    {

        private OutlookBar _owner;

        public OutlookBarButtonCollection(OutlookBar owner)
            : base()
        {
            this._owner = owner;
        }



        // Properties
        /*public int this[OutlookBarButton item]
        {
            get
            {
                return this.List.IndexOf(item);
            }
        }*/

        public int SelectedIndex(OutlookBarButton? item)
        {
            return this.List.IndexOf(item);
        }

        public OutlookBarButton this[int index] => (OutlookBarButton)List[index];

        public OutlookBarButton? this[string text]
        {
            get
            {
                foreach (OutlookBarButton? b in List)
                {
                    if (b != null && b.Text.Equals(text))
                    {
                        return b;
                    }
                }
                return null;
            }
        }

        internal OutlookBarButton? this[int x, int y]
        {
            get
            {
                foreach (OutlookBarButton b in List)
                {
                    if (!(b.Rectangle == null))
                    {
                        if (b.Rectangle.Contains(new Point(x, y)))
                        {
                            return b;
                        }
                    }
                    if (!(b.Rectangle == null))
                    {
                        if (b.Rectangle.Contains(new Point(x, y)))
                        {
                            return b;
                        }
                    }
                }
                return null;
            }
        }

        public OutlookBarButton Add(OutlookBarButton item)
        {
            item.Owner = this._owner;
            int i = List.Add(item);
            return (OutlookBarButton)List[i];
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")]
        public void AddRange(OutlookBarButtonCollection items)
        {
            foreach (OutlookBarButton item in items)
            {
                this.Add(item);
            }
        }

        public void Insert(int index, OutlookBarButton value)
        {
            List.Insert(index, value);
        }

        public void Remove(OutlookBarButton value)
        {
            List.Remove(value);
        }

        public bool Contains(OutlookBarButton item)
        {
            return List.Contains(item);
        }

        protected override void OnValidate(object value)
        {
            if (!typeof(OutlookBarButton).IsAssignableFrom(value.GetType()))
            {
                throw new ArgumentException(@"Value must be of type OutlookBarButton.", "value");
            }
        }

        public int CountVisible()
        {
            int functionReturnValue = 0;
            foreach (OutlookBarButton b in this.List)
            {
                if (b.Visible & b.Allowed)
                {
                    functionReturnValue += 1;
                }
            }
            return functionReturnValue;
        }

    }

}