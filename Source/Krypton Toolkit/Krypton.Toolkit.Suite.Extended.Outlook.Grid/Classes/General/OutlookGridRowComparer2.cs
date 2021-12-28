﻿#region BSD License
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
    internal class OutlookGridRowComparer2 : IComparer<OutlookGridRow>
    {
        List<Tuple<int, SortOrder, IComparer>> sortColumnIndexAndOrder;

        /// <summary>
        /// Initializes a new instance of the <see cref="OutlookGridRowComparer2"/> class.
        /// </summary>
        /// <param name="sortList">The sort list, tuple (column index, sortorder, Icomparer)</param>
        public OutlookGridRowComparer2(List<Tuple<int, SortOrder, IComparer>> sortList)
        {
            sortColumnIndexAndOrder = sortList;
        }

        #region IComparer Members

        /// <summary>
        /// Compares the specified x.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">OutlookGridRowComparer:  + this.ToString()</exception>
        public int Compare(OutlookGridRow x, OutlookGridRow y)
        {
            int compareResult = 0;
            int orderModifier;
            try
            {
                for (int i = 0; i < sortColumnIndexAndOrder.Count; i++)
                {
                    if (compareResult == 0)
                    {
                        orderModifier = (sortColumnIndexAndOrder[i].Item2 == SortOrder.Ascending ? 1 : -1);

                        object o1 = x.Cells[sortColumnIndexAndOrder[i].Item1].Value;
                        object o2 = y.Cells[sortColumnIndexAndOrder[i].Item1].Value;
                        if (sortColumnIndexAndOrder[i].Item3 != null)
                        {
                            compareResult = sortColumnIndexAndOrder[i].Item3.Compare(o1, o2) * orderModifier;
                        }
                        else
                        {
                            if ((o1 == null || o1 == DBNull.Value) && (o2 != null && o2 != DBNull.Value))
                            {
                                compareResult = 1;
                            }
                            else if ((o1 != null && o1 != DBNull.Value) && (o2 == null || o2 == DBNull.Value))
                            {
                                compareResult = -1;
                            }
                            else
                            {
                                if (o1 is string)
                                {
                                    compareResult = string.Compare(o1.ToString(), o2.ToString()) * orderModifier;
                                }
                                else if (o1 is DateTime)
                                {
                                    compareResult = ((DateTime)o1).CompareTo((DateTime)o2) * orderModifier;
                                }
                                else if (o1 is int)
                                {
                                    compareResult = ((int)o1).CompareTo((int)o2) * orderModifier;
                                }
                                else if (o1 is bool)
                                {
                                    bool b1 = (bool)o1;
                                    bool b2 = (bool)o2;
                                    compareResult = (b1 == b2 ? 0 : b1 == true ? 1 : -1) * orderModifier;
                                }
                                else if (o1 is float)
                                {
                                    float n1 = (float)o1;
                                    float n2 = (float)o2;
                                    compareResult = (n1 > n2 ? 1 : n1 < n2 ? -1 : 0) * orderModifier;
                                }
                                else if (o1 is double)
                                {
                                    double n1 = (double)o1;
                                    double n2 = (double)o2;
                                    compareResult = (n1 > n2 ? 1 : n1 < n2 ? -1 : 0) * orderModifier;
                                }
                                else if (o1 is decimal)
                                {
                                    decimal d1 = (decimal)o1;
                                    decimal d2 = (decimal)o2;
                                    compareResult = (d1 > d2 ? 1 : d1 < d2 ? -1 : 0) * orderModifier;
                                }
                                else if (o1 is long)
                                {
                                    long n1 = (long)o1;
                                    long n2 = (long)o2;
                                    compareResult = (n1 > n2 ? 1 : n1 < n2 ? -1 : 0) * orderModifier;
                                }
                                else if (o1 is TimeSpan)
                                {
                                    TimeSpan t1 = (TimeSpan)o1;
                                    TimeSpan t2 = (TimeSpan)o2;
                                    compareResult = (t1 > t2 ? 1 : t1 < t2 ? -1 : 0) * orderModifier;
                                }
                                else if (o1 is TextAndImage)
                                {
                                    compareResult = ((TextAndImage)o1).CompareTo((TextAndImage)o2) * orderModifier;
                                }
                                else if (o1 is Token)
                                {
                                    compareResult = ((Token)o1).CompareTo((Token)o2) * orderModifier;
                                }
                            }
                        }
                    }
                }
                return compareResult;
            }
            catch (Exception ex)
            {
                throw new Exception("OutlookGridRowComparer: " + ToString(), ex);
            }
        }
        #endregion
    }
}