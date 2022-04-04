#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.Collections;

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

        public int SelectedIndex(OutlookBarButton item)
        {
            return this.List.IndexOf(item);
        }

        public OutlookBarButton this[int index]
        {
            get { return (OutlookBarButton)List[index]; }
        }

        public OutlookBarButton this[string text]
        {
            get
            {
                foreach (OutlookBarButton b in List)
                {
                    if (b.Text.Equals(text)) return b;
                }
                return null;
            }
        }

        internal OutlookBarButton this[int x, int y]
        {
            get
            {
                foreach (OutlookBarButton b in List)
                {
                    if (!(b.Rectangle == null))
                    {
                        if (b.Rectangle.Contains(new Point(x, y))) return b;
                    }
                    if (!(b.Rectangle == null))
                    {
                        if (b.Rectangle.Contains(new Point(x, y))) return b;
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
                throw new ArgumentException("value must be of type OutlookBarButton.", "value");
            }
        }

        public int CountVisible()
        {
            int functionReturnValue = 0;
            foreach (OutlookBarButton b in this.List)
            {
                if (b.Visible & b.Allowed) functionReturnValue += 1;
            }
            return functionReturnValue;
        }

    }

}