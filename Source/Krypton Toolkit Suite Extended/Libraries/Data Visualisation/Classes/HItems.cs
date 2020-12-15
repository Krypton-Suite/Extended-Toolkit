#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.Collections;
using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation
{
    public class HItems
    {
        // Wish I had enough time to create my own class and don't to use an ArrayList
        ArrayList arrItem;
        private ArrayList Items
        {
            get { return arrItem; }
            set { arrItem = value; }
        }

        //Holding maximum value to speedup later calculations
        private double dMaximumValue;

        // Constructor
        public HItems()
        {
            arrItem = new ArrayList();
            dMaximumValue = 0;
        }



        // Add a new bar item
        protected void AddItem(HBarData item)
        {
            arrItem.Add(item);

            // Set first value as the maximum. If control modified to support negeative numbers
            // This will help to calculate true maximum, the reason is that the default is 0
            // which is always bigger than negative values, thus it's always bigger than all
            // values, while maximum value of array is something else(it's also negative) not 0
            if (arrItem.Count == 1)
            {
                dMaximumValue = item.Value;
            }
            else if (dMaximumValue < item.Value)
            {
                dMaximumValue = item.Value;
            }
        }

        // Add a new bar
        protected void AddItem(double dValue, string strLabel, Color colorBar)
        {
            HBarData item = new HBarData(dValue, strLabel, colorBar);
            AddItem(item);
        }

        // Insert a bar item at a specified index
        protected void InsertItem(int nIndex, HBarData item)
        {
            arrItem.Insert(nIndex, item);
            if (dMaximumValue < item.Value)
            {
                dMaximumValue = item.Value;
            }
        }

        // Insert a bar at a specified index
        protected void InsertItem(int nIndex, double dValue, string strLabel, Color colorBar)
        {
            HBarData item = new HBarData(dValue, strLabel, colorBar);
            InsertItem(nIndex, item);
        }

        // Remove an item from a specified index
        protected void RemoveItem(int nIndex)
        {
            // Get the value for later calculations
            double dValue = ((HBarData)arrItem[nIndex]).Value;

            arrItem.RemoveAt(nIndex);
            // If removing maximum item, maximum mustbe recalculated
            if (dValue == dMaximumValue)
            {
                // Recalculate maximum value in array
                CalculteMaximum();
            }

        }

        protected void CalculteMaximum()
        {
            if (arrItem.Count <= 0) return;

            dMaximumValue = ((HBarData)arrItem[0]).Value;
            for (int i = 0; i < arrItem.Count; i++)
            {
                if (dMaximumValue < ((HBarData)arrItem[i]).Value)
                {
                    dMaximumValue = ((HBarData)arrItem[i]).Value;
                }
            }
        }



        // Add a bar to the end of the list
        public void Add(double dValue, string strLabel, Color colorBar)
        {
            AddItem(dValue, strLabel, colorBar);
        }

        // Insert a bar at a specified index
        public bool SetAt(int nIndex, double dValue, string strLabel, Color colorBar)
        {
            if (nIndex < 0 || arrItem.Count < nIndex) return false;
            else if (arrItem.Count == nIndex)
            {
                AddItem(dValue, strLabel, colorBar);
                return true;
            }
            else
            {
                InsertItem(nIndex, dValue, strLabel, colorBar);
                return true;
            }
        }

        // Get a bar value
        public bool GetAt(int nIndex, out double dValue)
        {
            dValue = 0;
            if (nIndex < 0 || arrItem.Count <= nIndex) return false;

            dValue = ((HBarData)arrItem[nIndex]).Value;
            return true;
        }

        // Get a bar item
        public bool GetAt(int nIndex, out HBarData bar)
        {
            bar = null;
            if (nIndex < 0 || arrItem.Count <= nIndex) return false;

            bar = ((HBarData)arrItem[nIndex]);
            return true;
        }

        // Remove a bar
        public bool RemoveAt(int nIndex)
        {
            if (nIndex < 0 || arrItem.Count <= nIndex) return false;

            RemoveItem(nIndex);
            return true;
        }

        // Get number of bars
        public int Count
        {
            get { return arrItem.Count; }
        }

        // Get maximum value of bars vaues
        public double MaxValue
        {
            get { return dMaximumValue; }
        }

        // Get total value of summation all bars
        public double TotalValue
        {
            get
            {
                double dTotal = 0;
                for (int i = 0; i < arrItem.Count; i++)
                {
                    dTotal += ((HBarData)arrItem[i]).Value;
                }

                return dTotal;
            }
        }
    }
}