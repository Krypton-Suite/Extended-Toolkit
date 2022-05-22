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
        public override string Text => $"{Column.DataGridViewColumn.HeaderText}: {Value} ({(ItemCount == 1 ? OneItemText : ItemCount.ToString() + XXXItemsText)})";

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
                if (value != null && !string.IsNullOrEmpty(value.ToString())) //useful for text and image object
                {
                    base.Value = value.ToString().Substring(0, 1).ToUpper();
                }
                else
                {
                    base.Value = string.Empty;
                }
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
}