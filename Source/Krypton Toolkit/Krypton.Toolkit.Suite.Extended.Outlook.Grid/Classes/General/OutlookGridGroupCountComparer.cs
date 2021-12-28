#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */

//--------------------------------------------------------------------------------
// Copyright (C) 2013-2021 JDH Software - <support@jdhsoftware.com>
//
// This program is provided to you under the terms of the Microsoft Public
// License (Ms-PL) as published at https://github.com/Cocotteseb/Krypton-OutlookGrid/blob/master/LICENSE.md
//
// Visit https://www.jdhsoftware.com and follow @jdhsoftware on Twitter
//
//--------------------------------------------------------------------------------
#endregion

namespace Krypton.Toolkit.Suite.Extended.Outlook.Grid
{
    internal class OutlookGridGroupCountComparer : IComparer<IOutlookGridGroup>
    {
        public OutlookGridGroupCountComparer()
        {
        }

        #region IComparer Members

        public int Compare(IOutlookGridGroup x, IOutlookGridGroup y)
        {
            int compareResult = 0;
            try
            {
                int orderModifier = (x.Column.SortDirection == SortOrder.Ascending ? 1 : -1);

                int c1 = x.ItemCount;
                int c2 = y.ItemCount;
                compareResult = c1.CompareTo(c2) * orderModifier;

                if (compareResult == 0)
                {
                    compareResult = x.CompareTo(y);
                }
                return compareResult;
            }
            catch (Exception ex)
            {
                throw new Exception("OutlookGridGroupCountComparer: " + this.ToString(), ex);
            }
        }
        #endregion
    }
}