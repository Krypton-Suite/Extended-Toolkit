﻿namespace Krypton.Toolkit.Suite.Extended.Outlook.Grid
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
        TextInfo ti = CultureInfo.CurrentCulture.TextInfo;

        /// <summary>
        /// Enum of Date interval for the OutlookGridDateTimeGroup
        /// </summary>
        public enum DateInterval
        {
            /// <summary>
            /// Day
            /// </summary>
            Day,
            /// <summary>
            /// Month
            /// </summary>
            Month,
            /// <summary>
            /// Quarter
            /// </summary>
            Quarter,
            /// <summary>
            /// Year
            /// </summary>
            Year,
            /// <summary>
            /// Smart : intelligent grouping like Outlook for dates
            /// </summary>
            Smart
        }

        /// <summary>
        /// The Date Interval of OutlookGridDateTimeGroup
        /// </summary>
        public DateInterval Interval { get; set; }

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
        public OutlookGridDateTimeGroup(IOutlookGridGroup parentGroup)
            : base(parentGroup)
        {
            AllowHiddenWhenGrouped = true;
            Interval = DateInterval.Smart;
        }

        ///<summary>
        ///Gets or sets the displayed text.
        ///</summary>
        public override string Text
        {
            get
            {
                return string.Format("{0}: {1} ({2})", Column.DataGridViewColumn.HeaderText, Value.ToString(), ItemCount == 1 ? OneItemText : ItemCount.ToString() + XXXItemsText);
            }
            //set
            //{
            //    text = value;
            //}
        }

        private DateTime valDateTime;

        /// <summary>
        /// Gets or sets the Date value
        /// </summary>
        public override object Value
        {
            get
            {
                return base.Value;
            }
            set
            {
                switch (Interval)
                {
                    case DateInterval.Smart:
                        //If no date Time let the valDateTime to the min value !
                        if (value != null && value != DBNull.Value)
                            valDateTime = DateTime.Parse(value.ToString());
                        else
                            valDateTime = DateTime.MinValue;

                        base.Value = OutlookGridGroupHelpers.GetDayText(valDateTime);
                        break;
                    case DateInterval.Year:
                        //If no date Time let the valDateTime to the min value !
                        if (value != null && value != DBNull.Value)
                        {
                            valDateTime = DateTime.Parse(value.ToString());
                            base.Value = valDateTime.Year;
                        }
                        else
                        {
                            valDateTime = DateTime.MinValue;
                            base.Value = LanguageManager.Instance.GetString("NODATE");
                        }
                        break;
                    case DateInterval.Month:
                        //If no date Time let the valDateTime to the min value !
                        if (value != null && value != DBNull.Value)
                        {
                            valDateTime = DateTime.Parse(value.ToString());
                            base.Value = ti.ToTitleCase(valDateTime.ToString("MMMM")) + " " + valDateTime.Year;
                        }
                        else
                        {
                            valDateTime = DateTime.MinValue;
                            base.Value = LanguageManager.Instance.GetString("NODATE");
                        }
                        break;
                    case DateInterval.Day:
                        if (value != null && value != DBNull.Value)
                        {
                            valDateTime = DateTime.Parse(value.ToString());
                            base.Value = valDateTime.Date.ToShortDateString();
                        }
                        else
                        {
                            valDateTime = DateTime.MinValue;
                            base.Value = LanguageManager.Instance.GetString("NODATE");
                        }
                        break;
                    case DateInterval.Quarter:
                        if (value != null && value != DBNull.Value)
                        {
                            valDateTime = DateTime.Parse(value.ToString());
                            base.Value = OutlookGridGroupHelpers.GetQuarterAsString(valDateTime) + " " + valDateTime.Year;
                        }
                        else
                        {
                            valDateTime = DateTime.MinValue;
                            base.Value = LanguageManager.Instance.GetString("NODATE");
                        }
                        break;
                    default:
                        throw new Exception("Unknown Interval !");

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
            OutlookGridDateTimeGroup gr = new OutlookGridDateTimeGroup(ParentGroup);
            gr.Column = Column;
            gr.Value = valDateTime; //thx Resharper !
            gr.Collapsed = Collapsed;
            gr.Height = Height;
            gr.GroupImage = GroupImage;
            gr.FormatStyle = FormatStyle;
            gr.XXXItemsText = XXXItemsText;
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
            int orderModifier = (Column.SortDirection == SortOrder.Ascending ? 1 : -1);
            DateTime val;
            if (obj is DateTime)
            {
                //TODO necessary ??? 
                val = DateTime.Parse(obj.ToString());
            }
            else if (obj is OutlookGridDateTimeGroup)
            {
                val = ((OutlookGridDateTimeGroup)obj).valDateTime;
            }
            else
            {
                val = new DateTime();
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
                    return OutlookGridGroupHelpers.GetDateCodeNumeric(valDateTime).CompareTo(OutlookGridGroupHelpers.GetDateCodeNumeric(val)) * orderModifier;
                case DateInterval.Year:
                    if (valDateTime.Year == val.Year)
                    {
                        return 0;
                    }
                    else
                    {
                        return valDateTime.Year.CompareTo(val.Year) * orderModifier;
                    }
                case DateInterval.Month:
                    if (valDateTime.Month == val.Month && valDateTime.Year == val.Year)
                    {
                        return 0;
                    }
                    else
                    {
                        return valDateTime.Date.CompareTo(val.Date) * orderModifier;
                    }
                case DateInterval.Day:
                    if (valDateTime.Date == val.Date)
                    {
                        return 0;
                    }
                    else
                    {
                        return valDateTime.Date.CompareTo(val.Date) * orderModifier;
                    }
                case DateInterval.Quarter:
                    if (OutlookGridGroupHelpers.GetQuarter(valDateTime) == OutlookGridGroupHelpers.GetQuarter(val) && valDateTime.Year == val.Year)
                    {
                        return 0;
                    }
                    else
                    {
                        return valDateTime.Date.CompareTo(val.Date) * orderModifier;
                    }
                default:
                    throw new Exception("Unknown Interval !");

            }
        }
        #endregion IComparable Members
    }
}