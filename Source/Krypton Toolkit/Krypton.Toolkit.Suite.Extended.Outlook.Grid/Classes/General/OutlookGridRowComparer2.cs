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

namespace Krypton.Toolkit.Suite.Extended.Outlook.Grid;

internal class OutlookGridRowComparer2 : IComparer<OutlookGridRow>
{
    List<Tuple<int, SortOrder, IComparer?>> _sortColumnIndexAndOrder;

    /// <summary>
    /// Initializes a new instance of the <see cref="OutlookGridRowComparer2"/> class.
    /// </summary>
    /// <param name="sortList">The sort list, tuple (column index, sortorder, Icomparer)</param>
    public OutlookGridRowComparer2(List<Tuple<int, SortOrder, IComparer?>> sortList)
    {
        _sortColumnIndexAndOrder = sortList;
    }

    #region IComparer Members

    /// <summary>
    /// Compares the specified x.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <returns></returns>
    /// <exception cref="System.Exception">OutlookGridRowComparer:  + this.ToString()</exception>
    public int Compare(OutlookGridRow? x, OutlookGridRow? y)
    {
        if (x == null && y == null)
        {
            return 0;
        }

        if (x == null)
        {
            return -1;
        }

        if (y == null)
        {
            return 1;
        }

        int compareResult = 0, orderModifier;

        try
        {
            for (int i = 0; i < _sortColumnIndexAndOrder.Count; i++)
            {
                if (compareResult == 0)
                {
                    orderModifier = _sortColumnIndexAndOrder[i].Item2 == SortOrder.Ascending ? 1 : -1;

                    object o1 = x.Cells[_sortColumnIndexAndOrder[i].Item1].Value;
                    object o2 = y.Cells[_sortColumnIndexAndOrder[i].Item1].Value;
                    if (_sortColumnIndexAndOrder[i].Item3 != null)
                    {
                        compareResult = _sortColumnIndexAndOrder[i].Item3!.Compare(o1, o2) * orderModifier;
                    }
                    else
                    {
                        if ((o1 == null || o1 == DBNull.Value) && o2 != null && o2 != DBNull.Value)
                        {
                            compareResult = 1;
                        }
                        else if (o1 != null && o1 != DBNull.Value && (o2 == null || o2 == DBNull.Value))
                        {
                            compareResult = -1;
                        }
                        else
                        {
                            compareResult = o1 switch
                            {
                                string => string.Compare(o1.ToString(), o2?.ToString()) * orderModifier,
                                DateTime dt1 when o2 is DateTime dt2 => dt1.CompareTo(dt2) * orderModifier,
                                int i1 when o2 is int i2 => i1.CompareTo(i2) * orderModifier,
                                bool b1 when o2 is bool b2 => (b1 == b2 ? 0 : b1 ? 1 : -1) * orderModifier,
                                float n1f when o2 is float n2f => (n1f > n2f ? 1 : n1f < n2f ? -1 : 0) * orderModifier,
                                double n1d when o2 is double n2d =>
                                    (n1d > n2d ? 1 : n1d < n2d ? -1 : 0) * orderModifier,
                                decimal d1 when o2 is decimal d2 => (d1 > d2 ? 1 : d1 < d2 ? -1 : 0) * orderModifier,
                                long n1l when o2 is long n2l => (n1l > n2l ? 1 : n1l < n2l ? -1 : 0) * orderModifier,
                                TimeSpan t1 when o2 is TimeSpan t2 => (t1 > t2 ? 1 : t1 < t2 ? -1 : 0) * orderModifier,
                                TextAndImage ti1 when o2 is TextAndImage ti2 => ti1.CompareTo(ti2) * orderModifier,
                                Token tok1 when o2 is Token tok2 => tok1.CompareTo(tok2) * orderModifier,
                                _ => compareResult
                            };
                        }
                    }
                }
            }
            return compareResult;
        }
        catch (Exception ex)
        {
            throw new Exception($"OutlookGridRowComparer: {ToString()}", ex);
        }
    }
    #endregion
}