namespace Krypton.Toolkit.Suite.Extended.Outlook.Grid
{
    /// <summary>
    /// Each arrange/grouping class must implement the IOutlookGridGroup interface
    /// the Group object will determine for each object in the grid, whether it
    /// falls in or outside its group.
    /// It uses the IComparable.CompareTo function to determine if the item is in the group.
    /// This class group the elements by default (string, int, ...)
    /// </summary>
    public class OutlookGridDefaultGroup : IOutlookGridGroup
    {
        #region "Variables"
        /// <summary>
        /// The Value of the group
        /// </summary>
        private object _val;
        /// <summary>
        /// Boolean if the group is collapsed or not
        /// </summary>
        private bool _collapsed;
        /// <summary>
        /// The associated DataGridView column.
        /// </summary>
        private OutlookGridColumn _column;
        /// <summary>
        /// The number of items in this group.
        /// </summary>
        private int _itemCount;
        /// <summary>
        /// The height (in pixels).
        /// </summary>
        private int _height;

        /// <summary>
        /// The string to format the value of the group
        /// </summary>
        private string _formatStyle;
        /// <summary>
        /// The picture associated to the group
        /// </summary>
        private Image _groupImage;
        /// <summary>
        /// The text associated for the group text (1 item)
        /// </summary>
        private string _oneItemText;
        /// <summary>
        /// The text associated for the group text (XXX items)
        /// </summary>
        private string _xXxItemsText;
        /// <summary>
        /// Allows the column to be hidden when it is grouped by
        /// </summary>
        private bool _allowHiddenWhenGrouped;
        /// <summary>
        /// Sort groups using count items value
        /// </summary>
        private bool _sortBySummaryCount;
        #endregion

        #region "Constructor"

        /// <summary>
        /// Initializes a new instance of the <see cref="OutlookGridDefaultGroup"/> class.
        /// </summary>
        public OutlookGridDefaultGroup()
        {
            _val = null;
            _column = null;
            if (KryptonManager.CurrentGlobalPalette.GetRenderer() == KryptonManager.RenderOffice2013)
                _height = StaticValues._2013GroupRowHeight; // special height for office 2013
            else
                _height = StaticValues._defaultGroupRowHeight; // default height
            Rows = new List<OutlookGridRow>();
            Children = new OutlookGridGroupCollection();
            _formatStyle = "";
            _oneItemText = LanguageManager.Instance.GetString("OneItem");
            _xXxItemsText = LanguageManager.Instance.GetString("XXXItems");
            _allowHiddenWhenGrouped = true;
            _sortBySummaryCount = false;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parentGroup">The parent group if any.</param>
        public OutlookGridDefaultGroup(IOutlookGridGroup parentGroup) : this()
        {
            if (parentGroup != null)
                Children.ParentGroup = parentGroup;
        }
        #endregion

        #region IOutlookGridGroup Members

        /// <summary>
        /// Gets or sets the list of rows associated to the group.
        /// </summary>
        public List<OutlookGridRow> Rows { get; set; }

        /// <summary>
        /// Gets or sets the parent group.
        /// </summary>
        /// <value>The parent group.</value>
        public IOutlookGridGroup ParentGroup { get; set; }

        /// <summary>
        /// Gets or sets the level.
        /// </summary>
        /// <value>The level.</value>
        public int Level { get; set; }

        /// <summary>
        /// Gets or sets the children.
        /// </summary>
        /// <value>The children.</value>
        public OutlookGridGroupCollection Children { get; set; }

        /// <summary>
        /// Gets or sets the displayed text
        /// </summary>
        public virtual string Text
        {
            get
            {
                string formattedValue = "";
                string res = "";
                //For formatting number we need to cast the object value to the number before applying formatting
                if (_val == null || string.IsNullOrEmpty(_val.ToString()))
                {
                    formattedValue = LanguageManager.Instance.GetString("UNKNOWN");
                }
                else if (!String.IsNullOrEmpty(_formatStyle))
                {
                    if (_val is string)
                    {
                        formattedValue = string.Format(_formatStyle, Value.ToString());
                    }
                    else if (_val is DateTime)
                    {
                        formattedValue = ((DateTime)Value).ToString(_formatStyle);
                    }
                    else if (_val is int)
                    {
                        formattedValue = ((int)Value).ToString(_formatStyle);
                    }
                    else if (_val is float)
                    {
                        formattedValue = ((float)Value).ToString(_formatStyle);
                    }
                    else if (_val is double)
                    {
                        formattedValue = ((double)Value).ToString(_formatStyle);
                    }
                    else if (_val is decimal)
                    {
                        formattedValue = ((decimal)Value).ToString(_formatStyle);
                    }
                    else if (_val is long)
                    {
                        formattedValue = ((long)Value).ToString(_formatStyle);
                    }
                    else if (_val is TimeSpan)
                    {
                        formattedValue = ((TimeSpan)Value).ToString(_formatStyle);
                    }
                    else
                    {
                        formattedValue = Value.ToString();
                    }
                }
                else
                {
                    formattedValue = Value.ToString();
                }

                res = string.Format("{0}: {1} ({2})", _column.DataGridViewColumn.HeaderText, formattedValue, _itemCount == 1 ? _oneItemText : _itemCount.ToString() + XXXItemsText);
                //if (KryptonManager.CurrentGlobalPalette.GetRenderer() == KryptonManager.RenderOffice2013)
                //    return res.ToUpper();
                //else
                return res;
            }
            //set
            //{
            //    text = value;
            //}
        }

        /// <summary>
        /// Gets or sets the Value of the group
        /// </summary>
        public virtual object Value
        {
            get
            {
                return _val;
            }
            set
            {
                _val = value;
            }
        }

        /// <summary>
        /// Boolean if the group is collapsed or not
        /// </summary>
        public virtual bool Collapsed
        {
            get
            {
                return _collapsed;
            }
            set
            {
                _collapsed = value;
            }
        }

        /// <summary>
        /// Gets or sets the associated DataGridView column.
        /// </summary>
        public virtual OutlookGridColumn Column
        {
            get
            {
                return _column;
            }
            set
            {
                _column = value;
            }
        }

        /// <summary>
        /// Gets or set the number of items in this group.
        /// </summary>
        public virtual int ItemCount
        {
            get
            {
                return _itemCount;
            }
            set
            {
                _itemCount = value;
            }
        }

        /// <summary>
        /// Gets or sets the height (in pixels).
        /// </summary>
        public virtual int Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
            }
        }

        /// <summary>
        /// Gets or sets the Format Info.
        /// </summary>
        public virtual string FormatStyle
        {
            get
            {
                return _formatStyle;
            }
            set
            {
                _formatStyle = value;
            }
        }

        /// <summary>
        /// Gets or sets the picture.
        /// </summary>
        public virtual Image GroupImage
        {
            get
            {
                return _groupImage;
            }
            set
            {
                _groupImage = value;
            }
        }

        /// <summary>
        /// Gets or sets the text associated to One Item
        /// </summary>
        public virtual string OneItemText
        {
            get { return _oneItemText; }
            set { _oneItemText = value; }
        }

        /// <summary>
        /// Gets or sets the text associated to several Items
        /// </summary>
        public virtual string XXXItemsText
        {
            get { return _xXxItemsText; }
            set { _xXxItemsText = value; }
        }

        /// <summary>
        /// Gets or sets the boolean that hides the column automatically when grouped.
        /// </summary>
        public virtual bool AllowHiddenWhenGrouped
        {
            get { return _allowHiddenWhenGrouped; }
            set { _allowHiddenWhenGrouped = value; }
        }

        /// <summary>
        /// Gets or sets the boolean that sort groups using summary value
        /// </summary>
        public virtual bool SortBySummaryCount
        {
            get { return _sortBySummaryCount; }
            set { _sortBySummaryCount = value; }
        }

        ///// <summary>
        ///// Gets or sets the items comparer.
        ///// </summary>
        ///// <value>
        ///// The items comparer.
        ///// </value>
        //public virtual IComparer ItemsComparer
        //{
        //    get { return _itemsComparer; }
        //    set { _itemsComparer = value; }
        //}

        #endregion

        #region ICloneable Members

        /// <summary>
        /// Overrides the Clone() function
        /// </summary>
        /// <returns>OutlookgGridDefaultGroup</returns>
        public virtual object Clone()
        {
            var gr = new OutlookGridDefaultGroup(ParentGroup)
            {
                _column = _column,
                _val = _val,
                _collapsed = _collapsed,
                _height = _height,
                _groupImage = _groupImage,
                _formatStyle = _formatStyle,
                _xXxItemsText = XXXItemsText,
                _oneItemText = OneItemText,
                _allowHiddenWhenGrouped = _allowHiddenWhenGrouped,
                _sortBySummaryCount = _sortBySummaryCount
            };

            return gr;
        }

        #endregion

        #region IComparable Members

        /// <summary>
        /// This is a comparison operation based on the type of the value. 
        /// </summary>
        /// <param name="obj">the value in the related column of the item to compare to</param>
        /// <returns></returns>
        public virtual int CompareTo(object obj)
        {
            int orderModifier = (Column.SortDirection == SortOrder.Ascending ? 1 : -1);
            int compareResult = 0;
            object o2 = ((OutlookGridDefaultGroup)obj).Value;

            if ((_val == null || _val == DBNull.Value) && (o2 != null && o2 != DBNull.Value))
            {
                compareResult = 1;
            }
            else if ((_val != null && _val != DBNull.Value) && (o2 == null || o2 == DBNull.Value))
            {
                compareResult = -1;
            }
            else
            {
                if (_val is string)
                {
                    compareResult = string.Compare(_val.ToString(), o2.ToString()) * orderModifier;
                }
                else if (_val is DateTime)
                {
                    compareResult = ((DateTime)_val).CompareTo((DateTime)o2) * orderModifier;
                }
                else if (_val is int)
                {
                    compareResult = ((int)_val).CompareTo((int)o2) * orderModifier;
                }
                else if (_val is bool)
                {
                    bool b1 = (bool)_val;
                    bool b2 = (bool)o2;
                    compareResult = (b1 == b2 ? 0 : b1 == true ? 1 : -1) * orderModifier;
                }
                else if (_val is float)
                {
                    float n1 = (float)_val;
                    float n2 = (float)o2;
                    compareResult = (n1 > n2 ? 1 : n1 < n2 ? -1 : 0) * orderModifier;
                }
                else if (_val is double)
                {
                    double n1 = (double)_val;
                    double n2 = (double)o2;
                    compareResult = (n1 > n2 ? 1 : n1 < n2 ? -1 : 0) * orderModifier;
                }
                else if (_val is decimal)
                {
                    decimal n1 = (decimal)_val;
                    decimal n2 = (decimal)o2;
                    compareResult = (n1 > n2 ? 1 : n1 < n2 ? -1 : 0) * orderModifier;
                }
                else if (_val is long)
                {
                    long n1 = (long)_val;
                    long n2 = (long)o2;
                    compareResult = (n1 > n2 ? 1 : n1 < n2 ? -1 : 0) * orderModifier;
                }
                else if (_val is TimeSpan)
                {
                    TimeSpan t1 = (TimeSpan)_val;
                    TimeSpan t2 = (TimeSpan)o2;
                    compareResult = (t1 > t2 ? 1 : t1 < t2 ? -1 : 0) * orderModifier;
                }
                else if (_val is TextAndImage)
                {
                    compareResult = ((TextAndImage)_val).CompareTo((TextAndImage)o2) * orderModifier;
                }
                //TODO implement a value for Token Column ??
                else if (_val is Token)
                {
                    compareResult = ((Token)_val).CompareTo((Token)o2) * orderModifier;
                }
            }
            return compareResult;
        }
        #endregion
    }

    /// <summary>
    /// This group simple example of an implementation which groups the items into Alphabetic categories
    /// based only on the first letter of each item
    /// 
    /// For this we need to override the Value property (used for comparison)
    /// and the CompareTo function.
    /// Also the Clone method must be overriden, so this Group object can create clones of itself.
    /// Cloning of the group is used by the OutlookGrid
    /// </summary>
    public sealed class OutlookGridAlphabeticGroup : OutlookGridDefaultGroup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OutlookGridAlphabeticGroup"/> class.
        /// </summary>
        public OutlookGridAlphabeticGroup()
            : base()
        {
            AllowHiddenWhenGrouped = false;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="parentGroup">The parentGroup if any.</param>
        public OutlookGridAlphabeticGroup(IOutlookGridGroup parentGroup)
            : base(parentGroup)
        {
            AllowHiddenWhenGrouped = false;
        }

        /// <summary>
        /// Gets or sets the displayed text.
        /// </summary>
        public override string Text
        {
            get
            {
                return string.Format("{0}: {1} ({2})", Column.DataGridViewColumn.HeaderText, Value.ToString(), ItemCount == 1 ? OneItemText : ItemCount.ToString() + XXXItemsText);
            }
        }

        /// <summary>
        /// Gets or sets the Alphabetic value
        /// </summary>
        public override object Value
        {
            get
            {
                return base.Value;
            }
            set
            {
                //Note : value with Clone() is already 1 character, but no problem here
                if (value != null && !string.IsNullOrEmpty(value.ToString())) //useful for textand image object
                    base.Value = value.ToString().Substring(0, 1).ToUpper();
                else
                    base.Value = "";
            }
        }

        #region ICloneable Members

        /// <summary>
        /// Overrides the Clone() function
        /// </summary>
        /// <returns>OutlookGridAlphabeticGroup</returns>
        public override object Clone()
        {
            OutlookGridAlphabeticGroup gr = new OutlookGridAlphabeticGroup(ParentGroup)
            {
                Column = Column,
                Value = Value,
                Collapsed = Collapsed,
                Height = Height,
                GroupImage = GroupImage,
                FormatStyle = FormatStyle,
                XXXItemsText = XXXItemsText,
                OneItemText = OneItemText,
                AllowHiddenWhenGrouped = AllowHiddenWhenGrouped,
                SortBySummaryCount = SortBySummaryCount
            };

            return gr;
        }

        #endregion

        #region IComparable Members
        /// <summary>
        /// overide the CompareTo, so only the first character is compared, instead of the whole string
        /// this will result in classifying each item into a letter of the Alphabet.
        /// for instance, this is usefull when grouping names, they will be categorized under the letters A, B, C etc..
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override int CompareTo(object obj)
        {
            int orderModifier = (Column.SortDirection == SortOrder.Ascending ? 1 : -1);

            if (obj is OutlookGridAlphabeticGroup)
            {
                return string.Compare(Value.ToString(), ((OutlookGridAlphabeticGroup)obj).Value.ToString()) * orderModifier;
            }
            else
            {
                return 0;
            }
        }
        #endregion IComparable Members
    }

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