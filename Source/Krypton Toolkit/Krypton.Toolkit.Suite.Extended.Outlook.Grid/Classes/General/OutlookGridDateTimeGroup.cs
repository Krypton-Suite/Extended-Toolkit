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
    /// this group simple example of an implementation which groups the items into day categories
    /// based on, today, yesterday, last week etc
    /// 
    /// for this we need to override the Value property (used for comparison)
    /// and the CompareTo function.
    /// Also the Clone method must be overriden, so this Group object can create clones of itself.
    /// Cloning of the group is used by the OutlookGrid
    /// 
    public class OutlookGridDateTimeGroup : OutlookGridDefaultGroup
    {
        private readonly TextInfo _ti = CultureInfo.CurrentCulture.TextInfo;

        /// <summary>
        /// The Date Interval of OutlookGridDateTimeGroup
        /// </summary>
        public DateInterval Interval { get; set; }

        public static OutlookGridLanguageStrings LanguageStrings => KryptonOutlookGridGroupBox.Strings;

        /// <summary>
        /// Initializes a new instance of the <see cref="OutlookGridDateTimeGroup"/> class.
        /// </summary>
        public OutlookGridDateTimeGroup()
            : base()
        {
            AllowHiddenWhenGrouped = true;
            Interval = DateInterval.Smart;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parentGroup">The parentGroup if any.</param>
        public OutlookGridDateTimeGroup(IOutlookGridGroup? parentGroup)
            : base(parentGroup)
        {
            AllowHiddenWhenGrouped = true;
            Interval = DateInterval.Smart;
        }

        ///<summary>
        ///Gets or sets the displayed text.
        ///</summary>
        public override string Text => $"{Column.DataGridViewColumn.HeaderText}: {Value} ({(ItemCount == 1 ? OneItemText : ItemCount + XxxItemsText)})";

        private DateTime _valDateTime;

        /// <summary>
        /// Gets or sets the Date value
        /// </summary>
        public override object Value
        {
            get => base.Value;

            set
            {
                switch (Interval)
                {
                    case DateInterval.Smart:
                        //If no date Time let the valDateTime to the min value !
                        if (value != null && value != DBNull.Value)
                        {
                            _valDateTime = DateTime.Parse(value.ToString());
                        }
                        else
                        {
                            _valDateTime = DateTime.MinValue;
                        }

                        base.Value = OutlookGridGroupHelpers.GetDayText(_valDateTime);
                        break;
                    case DateInterval.Year:
                        //If no date Time let the valDateTime to the min value !
                        if (value != null && value != DBNull.Value)
                        {
                            _valDateTime = DateTime.Parse(value.ToString());
                            base.Value = _valDateTime.Year;
                        }
                        else
                        {
                            _valDateTime = DateTime.MinValue;
                            base.Value = Strings.NoDate;
                        }
                        break;
                    case DateInterval.Month:
                        //If no date Time let the valDateTime to the min value !
                        if (value != null && value != DBNull.Value)
                        {
                            _valDateTime = DateTime.Parse(value.ToString());
                            base.Value = $"{_ti.ToTitleCase(_valDateTime.ToString("MMMM"))} {_valDateTime.Year}";
                        }
                        else
                        {
                            _valDateTime = DateTime.MinValue;
                            base.Value = Strings.NoDate;
                        }
                        break;
                    case DateInterval.Day:
                        if (value != null && value != DBNull.Value)
                        {
                            _valDateTime = DateTime.Parse(value.ToString());
                            base.Value = _valDateTime.Date.ToShortDateString();
                        }
                        else
                        {
                            _valDateTime = DateTime.MinValue;
                            base.Value = Strings.NoDate;
                        }
                        break;
                    case DateInterval.Quarter:
                        if (value != null && value != DBNull.Value)
                        {
                            _valDateTime = DateTime.Parse(value.ToString());
                            base.Value =
                                $"{OutlookGridGroupHelpers.GetQuarterAsString(_valDateTime)} {_valDateTime.Year}";
                        }
                        else
                        {
                            _valDateTime = DateTime.MinValue;
                            base.Value = Strings.NoDate;
                        }
                        break;
                    default:
                        throw new("Unknown Interval !");

                }

            }
        }

        #region ICloneable Members

        /// <summary>
        /// Overrides the Clone() function
        /// </summary>
        /// <returns>OutlookGridDateTimeGroup</returns>
        public override object Clone()
        {
            OutlookGridDateTimeGroup gr = new(ParentGroup);
            gr.Column = Column;
            gr.Value = _valDateTime; //thx Resharper !
            gr.Collapsed = Collapsed;
            gr.Height = Height;
            gr.GroupImage = GroupImage;
            gr.FormatStyle = FormatStyle;
            gr.XxxItemsText = XxxItemsText;
            gr.OneItemText = OneItemText;
            gr.AllowHiddenWhenGrouped = AllowHiddenWhenGrouped;
            gr.SortBySummaryCount = SortBySummaryCount;
            gr.Interval = Interval;

            return gr;
        }

        #endregion

        #region IComparable Members

        /// <summary>
        /// Overrides CompareTo
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override int CompareTo(object obj)
        {
            int orderModifier = Column.SortDirection == SortOrder.Ascending ? 1 : -1;
            DateTime val;
            if (obj is DateTime)
            {
                //TODO necessary ??? 
                val = DateTime.Parse(obj.ToString());
            }
            else if (obj is OutlookGridDateTimeGroup)
            {
                val = ((OutlookGridDateTimeGroup)obj)._valDateTime;
            }
            else
            {
                val = new();
            }

            switch (Interval)
            {
                case DateInterval.Smart:
                    //if (OutlookGridGroupHelpers.GetDateCode(valDateTime.Date) == OutlookGridGroupHelpers.GetDateCode(val.Date))
                    //{
                    //    return 0;
                    //}
                    //else
                    //{
                    //    return DateTime.Compare(valDateTime.Date, val.Date) * orderModifier;
                    //}
                    return OutlookGridGroupHelpers.GetDateCodeNumeric(_valDateTime).CompareTo(OutlookGridGroupHelpers.GetDateCodeNumeric(val)) * orderModifier;
                case DateInterval.Year:
                    if (_valDateTime.Year == val.Year)
                    {
                        return 0;
                    }
                    else
                    {
                        return _valDateTime.Year.CompareTo(val.Year) * orderModifier;
                    }
                case DateInterval.Month:
                    if (_valDateTime.Month == val.Month && _valDateTime.Year == val.Year)
                    {
                        return 0;
                    }
                    else
                    {
                        return _valDateTime.Date.CompareTo(val.Date) * orderModifier;
                    }
                case DateInterval.Day:
                    if (_valDateTime.Date == val.Date)
                    {
                        return 0;
                    }
                    else
                    {
                        return _valDateTime.Date.CompareTo(val.Date) * orderModifier;
                    }
                case DateInterval.Quarter:
                    if (OutlookGridGroupHelpers.GetQuarter(_valDateTime) == OutlookGridGroupHelpers.GetQuarter(val) && _valDateTime.Year == val.Year)
                    {
                        return 0;
                    }
                    else
                    {
                        return _valDateTime.Date.CompareTo(val.Date) * orderModifier;
                    }
                default:
                    throw new("Unknown Interval !");

            }
        }
        #endregion IComparable Members
    }
}