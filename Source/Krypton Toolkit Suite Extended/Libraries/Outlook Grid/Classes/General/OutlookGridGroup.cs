using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

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
        protected object val;
        /// <summary>
        /// Boolean if the group is collapsed or not
        /// </summary>
        protected bool collapsed;
        /// <summary>
        /// The associated DataGridView column.
        /// </summary>
        protected OutlookGridColumn column;
        /// <summary>
        /// The number of items in this group.
        /// </summary>
        protected int itemCount;
        /// <summary>
        /// The height (in pixels).
        /// </summary>
        protected int height;
        /// <summary>
        /// The list of rows associated to the group.
        /// </summary>
        protected List<OutlookGridRow> rows;
        /// <summary>
        /// The parent group if any.
        /// </summary>
        protected IOutlookGridGroup parentGroup;
        /// <summary>
        /// The level (nested) of grouping
        /// </summary>
        protected int level;
        /// <summary>
        /// The children groups
        /// </summary>
        protected OutlookGridGroupCollection children;
        /// <summary>
        /// The string to format the value of the group
        /// </summary>
        protected string formatStyle;
        /// <summary>
        /// The picture associated to the group
        /// </summary>
        protected Image groupImage;
        /// <summary>
        /// The text associated for the group text (1 item)
        /// </summary>
        protected string oneItemText;
        /// <summary>
        /// The text associated for the group text (XXX items)
        /// </summary>
        protected string xXXItemsText;
        /// <summary>
        /// Allows the column to be hidden when it is grouped by
        /// </summary>
        protected bool allowHiddenWhenGrouped;
        /// <summary>
        /// Sort groups using count items value
        /// </summary>
        protected bool sortBySummaryCount;
        /// <summary>
        /// Specific Comparer object for items in the group, if needed
        /// </summary>
        protected IComparer itemsComparer;


        #endregion

        #region "Constructor"

        /// <summary>
        /// Initializes a new instance of the <see cref="OutlookGridDefaultGroup"/> class.
        /// </summary>
        public OutlookGridDefaultGroup()
        {
            val = null;
            column = null;
            if (KryptonManager.CurrentGlobalPalette.GetRenderer() == KryptonManager.RenderOffice2013)
                height = StaticValues._2013GroupRowHeight; // special height for office 2013
            else
                height = StaticValues._defaultGroupRowHeight; // default height
            rows = new List<OutlookGridRow>();
            children = new OutlookGridGroupCollection();
            formatStyle = "";
            oneItemText = LanguageManager.Instance.GetLocalisedString("OneItem");
            XXXItemsText = LanguageManager.Instance.GetLocalisedString("XXXItems");
            allowHiddenWhenGrouped = true;
            sortBySummaryCount = false;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parentGroup">The parent group if any.</param>
        public OutlookGridDefaultGroup(IOutlookGridGroup parentGroup) : this()
        {
            if (parentGroup != null)
                children.ParentGroup = parentGroup;
        }
        #endregion

        #region IOutlookGridGroup Members

        /// <summary>
        /// Gets or sets the list of rows associated to the group.
        /// </summary>
        public List<OutlookGridRow> Rows
        {
            get
            {
                return rows;
            }
            set
            {
                rows = value;
            }
        }

        /// <summary>
        /// Gets or sets the parent group.
        /// </summary>
        /// <value>The parent group.</value>
        public IOutlookGridGroup ParentGroup
        {
            get
            {
                return parentGroup;
            }
            set
            {
                parentGroup = value;
            }
        }

        /// <summary>
        /// Gets or sets the level.
        /// </summary>
        /// <value>The level.</value>
        public int Level
        {
            get
            {
                return level;
            }
            set
            {
                level = value;
            }
        }

        /// <summary>
        /// Gets or sets the children.
        /// </summary>
        /// <value>The children.</value>
        public OutlookGridGroupCollection Children
        {
            get
            {
                return children;
            }
            set
            {
                children = value;
            }
        }

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
                if (val == null || string.IsNullOrEmpty(val.ToString()))
                {
                    formattedValue = LanguageManager.Instance.GetLocalisedString("UNKNOWN");
                }
                else if (!String.IsNullOrEmpty(formatStyle))
                {
                    if (val is string)
                    {
                        formattedValue = string.Format(formatStyle, Value.ToString());
                    }
                    else if (val is DateTime)
                    {
                        formattedValue = ((DateTime)Value).ToString(formatStyle);
                    }
                    else if (val is int)
                    {
                        formattedValue = ((int)Value).ToString(formatStyle);
                    }
                    else if (val is float)
                    {
                        formattedValue = ((float)Value).ToString(formatStyle);
                    }
                    else if (val is double)
                    {
                        formattedValue = ((double)Value).ToString(formatStyle);
                    }
                    else if (val is decimal)
                    {
                        formattedValue = ((decimal)Value).ToString(formatStyle);
                    }
                    else if (val is long)
                    {
                        formattedValue = ((long)Value).ToString(formatStyle);
                    }
                    else if (val is TimeSpan)
                    {
                        formattedValue = ((TimeSpan)Value).ToString(formatStyle);
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

                res = string.Format("{0}: {1} ({2})", column.DataGridViewColumn.HeaderText, formattedValue, itemCount == 1 ? oneItemText : itemCount.ToString() + XXXItemsText);
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
                return val;
            }
            set
            {
                val = value;
            }
        }

        /// <summary>
        /// Boolean if the group is collapsed or not
        /// </summary>
        public virtual bool Collapsed
        {
            get
            {
                return collapsed;
            }
            set
            {
                collapsed = value;
            }
        }

        /// <summary>
        /// Gets or sets the associated DataGridView column.
        /// </summary>
        public virtual OutlookGridColumn Column
        {
            get
            {
                return column;
            }
            set
            {
                column = value;
            }
        }

        /// <summary>
        /// Gets or set the number of items in this group.
        /// </summary>
        public virtual int ItemCount
        {
            get
            {
                return itemCount;
            }
            set
            {
                itemCount = value;
            }
        }

        /// <summary>
        /// Gets or sets the height (in pixels).
        /// </summary>
        public virtual int Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
            }
        }

        /// <summary>
        /// Gets or sets the Format Info.
        /// </summary>
        public virtual string FormatStyle
        {
            get
            {
                return formatStyle;
            }
            set
            {
                formatStyle = value;
            }
        }

        /// <summary>
        /// Gets or sets the picture.
        /// </summary>
        public virtual Image GroupImage
        {
            get
            {
                return groupImage;
            }
            set
            {
                groupImage = value;
            }
        }

        /// <summary>
        /// Gets or sets the text associated to One Item
        /// </summary>
        public virtual string OneItemText
        {
            get { return oneItemText; }
            set { oneItemText = value; }
        }

        /// <summary>
        /// Gets or sets the text associated to several Items
        /// </summary>
        public virtual string XXXItemsText
        {
            get { return xXXItemsText; }
            set { xXXItemsText = value; }
        }

        /// <summary>
        /// Gets or sets the boolean that hides the column automatically when grouped.
        /// </summary>
        public virtual bool AllowHiddenWhenGrouped
        {
            get { return allowHiddenWhenGrouped; }
            set { allowHiddenWhenGrouped = value; }
        }

        /// <summary>
        /// Gets or sets the boolean that sort groups using summary value
        /// </summary>
        public virtual bool SortBySummaryCount
        {
            get { return sortBySummaryCount; }
            set { sortBySummaryCount = value; }
        }

        /// <summary>
        /// Gets or sets the items comparer.
        /// </summary>
        /// <value>
        /// The items comparer.
        /// </value>
        public virtual IComparer ItemsComparer
        {
            get { return itemsComparer; }
            set { itemsComparer = value; }
        }

        #endregion

        #region ICloneable Members

        /// <summary>
        /// Overrides the Clone() function
        /// </summary>
        /// <returns>OutlookgGridDefaultGroup</returns>
        public virtual object Clone()
        {
            OutlookGridDefaultGroup gr = new OutlookGridDefaultGroup(parentGroup);
            gr.column = column;
            gr.val = val;
            gr.collapsed = collapsed;
            //gr.text = this.text;
            gr.height = height;
            gr.groupImage = groupImage;
            gr.formatStyle = formatStyle;
            gr.xXXItemsText = XXXItemsText;
            gr.oneItemText = OneItemText;
            gr.allowHiddenWhenGrouped = allowHiddenWhenGrouped;
            gr.sortBySummaryCount = sortBySummaryCount;

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

            if ((val == null || val == DBNull.Value) && (o2 != null && o2 != DBNull.Value))
            {
                compareResult = 1;
            }
            else if ((val != null && val != DBNull.Value) && (o2 == null || o2 == DBNull.Value))
            {
                compareResult = -1;
            }
            else
            {
                if (val is string)
                {
                    compareResult = string.Compare(val.ToString(), o2.ToString()) * orderModifier;
                }
                else if (val is DateTime)
                {
                    compareResult = ((DateTime)val).CompareTo((DateTime)o2) * orderModifier;
                }
                else if (val is int)
                {
                    compareResult = ((int)val).CompareTo((int)o2) * orderModifier;
                }
                else if (val is bool)
                {
                    bool b1 = (bool)val;
                    bool b2 = (bool)o2;
                    compareResult = (b1 == b2 ? 0 : b1 == true ? 1 : -1) * orderModifier;
                }
                else if (val is float)
                {
                    float n1 = (float)val;
                    float n2 = (float)o2;
                    compareResult = (n1 > n2 ? 1 : n1 < n2 ? -1 : 0) * orderModifier;
                }
                else if (val is double)
                {
                    double n1 = (double)val;
                    double n2 = (double)o2;
                    compareResult = (n1 > n2 ? 1 : n1 < n2 ? -1 : 0) * orderModifier;
                }
                else if (val is decimal)
                {
                    decimal n1 = (decimal)val;
                    decimal n2 = (decimal)o2;
                    compareResult = (n1 > n2 ? 1 : n1 < n2 ? -1 : 0) * orderModifier;
                }
                else if (val is long)
                {
                    long n1 = (long)val;
                    long n2 = (long)o2;
                    compareResult = (n1 > n2 ? 1 : n1 < n2 ? -1 : 0) * orderModifier;
                }
                else if (val is TimeSpan)
                {
                    TimeSpan t1 = (TimeSpan)val;
                    TimeSpan t2 = (TimeSpan)o2;
                    compareResult = (t1 > t2 ? 1 : t1 < t2 ? -1 : 0) * orderModifier;
                }
                else if (val is TextAndImage)
                {
                    compareResult = ((TextAndImage)val).CompareTo((TextAndImage)o2) * orderModifier;
                }
                //TODO implement a value for Token Column ??
                else if (val is Token)
                {
                    compareResult = ((Token)val).CompareTo((Token)o2) * orderModifier;
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
    public class OutlookGridAlphabeticGroup : OutlookGridDefaultGroup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OutlookGridAlphabeticGroup"/> class.
        /// </summary>
        public OutlookGridAlphabeticGroup()
            : base()
        {
            allowHiddenWhenGrouped = false;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="parentGroup">The parentGroup if any.</param>
        public OutlookGridAlphabeticGroup(IOutlookGridGroup parentGroup)
            : base(parentGroup)
        {
            allowHiddenWhenGrouped = false;
        }

        /// <summary>
        /// Gets or sets the displayed text.
        /// </summary>
        public override string Text
        {
            get
            {
                //return string.Format("{0}: {1} ({2})", LanguageManager.Instance.GetLocalisedString("AlphabeticGroupText"), Value.ToString(), itemCount == 1 ? LanguageManager.Instance.GetLocalisedString("OneItem") : itemCount.ToString() + LanguageManager.Instance.GetLocalisedString("XXXItems"));
                return string.Format("{0}: {1} ({2})", column.DataGridViewColumn.HeaderText, Value.ToString(), itemCount == 1 ? OneItemText : itemCount.ToString() + XXXItemsText);
            }
            //set
            //{
            //    text = value;
            //}
        }

        /// <summary>
        /// Gets or sets the Alphabetic value
        /// </summary>
        public override object Value
        {
            get
            {
                return val;
            }
            set
            {
                if (value != null && !string.IsNullOrEmpty(value.ToString())) //useful for textand image object
                    val = value.ToString().Substring(0, 1).ToUpper();
                else
                    val = "";
            }
        }

        #region ICloneable Members

        /// <summary>
        /// Overrides the Clone() function
        /// </summary>
        /// <returns>OutlookGridAlphabeticGroup</returns>
        public override object Clone()
        {
            OutlookGridAlphabeticGroup gr = new OutlookGridAlphabeticGroup(parentGroup);

            gr.column = column;
            gr.val = val;
            gr.collapsed = collapsed;
            //gr.text = this.text;
            gr.height = height;
            gr.groupImage = groupImage;
            gr.formatStyle = formatStyle;
            gr.xXXItemsText = XXXItemsText;
            gr.oneItemText = OneItemText;
            gr.allowHiddenWhenGrouped = allowHiddenWhenGrouped;
            gr.sortBySummaryCount = sortBySummaryCount;
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
                return string.Compare(val.ToString(), ((OutlookGridAlphabeticGroup)obj).Value.ToString()) * orderModifier;
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
            allowHiddenWhenGrouped = true;
            Interval = DateInterval.Smart;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parentGroup">The parentGroup if any.</param>
        public OutlookGridDateTimeGroup(IOutlookGridGroup parentGroup)
            : base(parentGroup)
        {
            allowHiddenWhenGrouped = true;
            Interval = DateInterval.Smart;
        }

        ///<summary>
        ///Gets or sets the displayed text.
        ///</summary>
        public override string Text
        {
            get
            {
                return string.Format("{0}: {1} ({2})", column.DataGridViewColumn.HeaderText, Value.ToString(), itemCount == 1 ? OneItemText : itemCount.ToString() + XXXItemsText);
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
                return val;
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

                        val = OutlookGridGroupHelpers.GetDayText(valDateTime);
                        break;
                    case DateInterval.Year:
                        //If no date Time let the valDateTime to the min value !
                        if (value != null && value != DBNull.Value)
                        {
                            valDateTime = DateTime.Parse(value.ToString());
                            val = valDateTime.Year;
                        }
                        else
                        {
                            valDateTime = DateTime.MinValue;
                            val = LanguageManager.Instance.GetLocalisedString("NODATE");
                        }
                        break;
                    case DateInterval.Month:
                        //If no date Time let the valDateTime to the min value !
                        if (value != null && value != DBNull.Value)
                        {
                            valDateTime = DateTime.Parse(value.ToString());
                            val = ti.ToTitleCase(valDateTime.ToString("MMMM")) + " " + valDateTime.Year;
                        }
                        else
                        {
                            valDateTime = DateTime.MinValue;
                            val = LanguageManager.Instance.GetLocalisedString("NODATE");
                        }
                        break;
                    case DateInterval.Day:
                        if (value != null && value != DBNull.Value)
                        {
                            valDateTime = DateTime.Parse(value.ToString());
                            val = valDateTime.Date.ToShortDateString();
                        }
                        else
                        {
                            valDateTime = DateTime.MinValue;
                            val = LanguageManager.Instance.GetLocalisedString("NODATE");
                        }
                        break;
                    case DateInterval.Quarter:
                        if (value != null && value != DBNull.Value)
                        {
                            valDateTime = DateTime.Parse(value.ToString());
                            val = OutlookGridGroupHelpers.GetQuarterAsString(valDateTime) + " " + valDateTime.Year;
                        }
                        else
                        {
                            valDateTime = DateTime.MinValue;
                            val = LanguageManager.Instance.GetLocalisedString("NODATE");
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
            OutlookGridDateTimeGroup gr = new OutlookGridDateTimeGroup(parentGroup);
            gr.column = column;
            gr.val = val;
            gr.collapsed = collapsed;
            //gr.text = this.text;
            gr.height = height;
            gr.groupImage = groupImage;
            gr.formatStyle = formatStyle;
            gr.xXXItemsText = XXXItemsText;
            gr.oneItemText = OneItemText;
            gr.allowHiddenWhenGrouped = allowHiddenWhenGrouped;
            gr.sortBySummaryCount = sortBySummaryCount;
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
                    if (OutlookGridGroupHelpers.GetDateCode(valDateTime.Date) == OutlookGridGroupHelpers.GetDateCode(val.Date))
                    {
                        return 0;
                    }
                    else
                    {
                        return DateTime.Compare(valDateTime.Date, val.Date) * orderModifier;
                    }
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