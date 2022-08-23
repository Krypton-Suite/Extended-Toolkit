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
    /// <summary>Expose a global set of strings used within the Krypton Outlook Grid and that are localizable.</summary>
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class OutlookGridLanguageStrings : GlobalId
    {
        #region Static Fields

        private const string DEFAULT_AFTER_NEXT_MONTH = "After next month";

        private const string DEFAULT_ALPHABETIC_GROUP_TEXT = "Alphabetic";

        private const string DEFAULT_BAR = "Data Bars";

        private const string DEFAULT_BEFORE_PREVIOUS_MONTH = "Before previous month";

        private const string DEFAULT_BEST_FIT_ALL = "Best fit (all columns)";

        private const string DEFAULT_BEST_FIT = "Best fit";

        private const string DEFAULT_CANCEL = "Cancel";

        private const string DEFAULT_CLEAR_GROUPING = "Clear grouping";

        private const string DEFAULT_CLEAR_RULES = "Clear rules...";

        private const string DEFAULT_CLEAR_SORTING = "Clear sorting";

        private const string DEFAULT_COLLAPSE = "Collapse";

        private const string DEFAULT_COLUMNS = "Columns";

        private const string DEFAULT_CONDITIONAL_FORMATTING = "Conditional formatting";

        private const string DEFAULT_CUSTOM_THREE_DOTS = "Custom...";

        private const string DEFAULT_DATE_GROUP_TEXT = "Date";

        private const string DEFAULT_DAY = "Day";

        private const string DEFAULT_DRAG_COLUMN_TO_GROUP = "Drag a column header here to group by that column";

        private const string DEFAULT_EARLIER_DURING_THIS_MONTH = "Earlier during this month";

        private const string DEFAULT_EARLIER_THIS_YEAR = "Earlier this year";

        private const string DEFAULT_EXPAND = "Expand";

        private const string DEFAULT_FINISH = "Finish";

        private const string DEFAULT_FULL_COLLAPSE = "Full collapse";

        private const string DEFAULT_FULL_EXPAND = "Full expand";

        private const string DEFAULT_GRADIENT_FILL = "Gradient Fill";

        private const string DEFAULT_GROUP = "Group by this column";

        private const string DEFAULT_GROUP_INTERVAL = "Group interval";

        private const string DEFAULT_HIDE_GROUP_BOX = "Hide GroupBox";

        private const string DEFAULT_IN_THREE_WEEKS = "In three weeks";

        private const string DEFAULT_IN_TWO_WEEKS = "In two weeks";

        private const string DEFAULT_LATER_DURING_THIS_MONTH = "Later during this month";

        private const string DEFAULT_MONTH = "Month";

        private const string DEFAULT_NEXT_MONTH = "Next month";

        private const string DEFAULT_NEXT_WEEK = "Next week";

        private const string DEFAULT_NO_DATE = "No date";

        private const string DEFAULT_OLDER = "Older";

        private const string DEFAULT_ONE_ITEM = "1 item";

        private const string DEFAULT_OTHER = "Other";

        private const string DEFAULT_PALETTE_CUSTOM = "Custom...";

        private const string DEFAULT_PALETTE_CUSTOM_HEADING = "Custom palettes";

        private const string DEFAULT_PREVIOUS_MONTH = "Previous month";

        private const string DEFAULT_PREVIOUS_WEEK = "Previous week";

        private const string DEFAULT_PREVIOUS_YEAR = "Previous year";

        private const string DEFAULT_QUARTER_ONE = "Q1";

        private const string DEFAULT_QUARTER_TWO = "Q2";

        private const string DEFAULT_QUARTER_THREE = "Q3";

        private const string DEFAULT_QUARTER_FOUR = "Q4";

        private const string DEFAULT_QUARTER = "Quarter";

        private const string DEFAULT_SHOW_GROUP_BOX = "Show GroupBox";

        private const string DEFAULT_SMART = "Smart";

        private const string DEFAULT_SOLID_FILL = "Solid Fill";

        private const string DEFAULT_SORT_ASCENDING = "Sort ascending";

        private const string DEFAULT_SORT_BY_SUMMARY_COUNT = "Sort by summary count";

        private const string DEFAULT_SORT_DESCENDING = "Sort descending";

        private const string DEFAULT_THREE_COLOURS_RANGE = "Three Colour Scale";

        private const string DEFAULT_THREE_WEEKS_AGO = "Three weeks ago";

        private const string DEFAULT_TODAY = "Today";

        private const string DEFAULT_TOMORROW = "Tomorrow";

        private const string DEFAULT_TWO_COLOURS_RANGE = "Two Colour Scale";

        private const string DEFAULT_TWO_WEEKS_AGO = "Two weeks ago";

        private const string DEFAULT_UNGROUP = "Ungroup";

        private const string DEFAULT_UNKNOWN = "Unknown";

        private const string DEFAULT_NUMBER_OF_ITEMS = " items";

        private const string DEFAULT_YEAR = "Year";

        private const string DEFAULT_YEAR_GROUP_TEXT = "Year";

        private const string DEFAULT_YESTERDAY = "Yesterday";

        #endregion

        #region Identity

        public OutlookGridLanguageStrings() => Reset();

        public override string ToString() => !IsDefault ? "Modified" : string.Empty;

        #endregion

        #region Public

        [Browsable(false)]
        public bool IsDefault => AfterNextMonth.Equals(DEFAULT_AFTER_NEXT_MONTH) &&
                                 AlphabeticGroupText.Equals(DEFAULT_ALPHABETIC_GROUP_TEXT) &&
                                 Bar.Equals(DEFAULT_BAR) &&
                                 BeforePreviousMonth.Equals(DEFAULT_BEFORE_PREVIOUS_MONTH) &&
                                 BestFitAll.Equals(DEFAULT_BEST_FIT_ALL) &&
                                 BestFit.Equals(DEFAULT_BEST_FIT) &&
                                 Cancel.Equals(DEFAULT_CANCEL) &&
                                 ClearGrouping.Equals(DEFAULT_CLEAR_GROUPING) &&
                                 ClearRules.Equals(DEFAULT_CLEAR_RULES) &&
                                 ClearSorting.Equals(DEFAULT_CLEAR_SORTING) &&
                                 Collapse.Equals(DEFAULT_COLLAPSE) &&
                                 Columns.Equals(DEFAULT_COLUMNS) &&
                                 ConditionalFormatting.Equals(DEFAULT_CONDITIONAL_FORMATTING) &&
                                 CustomThreeDots.Equals(DEFAULT_CUSTOM_THREE_DOTS) &&
                                 DateGroupText.Equals(DEFAULT_DATE_GROUP_TEXT) &&
                                 Day.Equals(DEFAULT_DAY) &&
                                 DragColumnToGroup.Equals(DEFAULT_DRAG_COLUMN_TO_GROUP) &&
                                 EarlierDuringThisMonth.Equals(DEFAULT_EARLIER_DURING_THIS_MONTH) &&
                                 EarlierDuringThisYear.Equals(DEFAULT_EARLIER_THIS_YEAR) &&
                                 Expand.Equals(DEFAULT_EXPAND) &&
                                 Finish.Equals(DEFAULT_FINISH) &&
                                 FullCollapse.Equals(DEFAULT_FULL_COLLAPSE) &&
                                 FullExpand.Equals(DEFAULT_FULL_EXPAND) &&
                                 GradientFill.Equals(DEFAULT_GRADIENT_FILL) &&
                                 Group.Equals(DEFAULT_GROUP) &&
                                 GroupInterval.Equals(DEFAULT_GROUP_INTERVAL) &&
                                 HideGroupBox.Equals(DEFAULT_HIDE_GROUP_BOX) &&
                                 InThreeWeeks.Equals(DEFAULT_IN_THREE_WEEKS) &&
                                 InTwoWeeks.Equals(DEFAULT_IN_TWO_WEEKS) &&
                                 LaterDuringThisMonth.Equals(DEFAULT_LATER_DURING_THIS_MONTH) &&
                                 Month.Equals(DEFAULT_MONTH) &&
                                 NextMonth.Equals(DEFAULT_NEXT_MONTH) &&
                                 NextWeek.Equals(DEFAULT_NEXT_WEEK) &&
                                 NoDate.Equals(DEFAULT_NO_DATE) &&
                                 Older.Equals(DEFAULT_OLDER) &&
                                 OneItem.Equals(DEFAULT_ONE_ITEM) &&
                                 Other.Equals(DEFAULT_OTHER) &&
                                 PaletteCustom.Equals(DEFAULT_PALETTE_CUSTOM) &&
                                 PaletteCustomHeading.Equals(DEFAULT_PALETTE_CUSTOM_HEADING) &&
                                 PreviousMonth.Equals(DEFAULT_PREVIOUS_MONTH) &&
                                 PreviousWeek.Equals(DEFAULT_PREVIOUS_WEEK) &&
                                 PreviousYear.Equals(DEFAULT_PREVIOUS_YEAR) &&
                                 QuarterOne.Equals(DEFAULT_QUARTER_ONE) &&
                                 QuarterTwo.Equals(DEFAULT_QUARTER_TWO) &&
                                 QuarterThree.Equals(DEFAULT_QUARTER_THREE) &&
                                 Quarter.Equals(DEFAULT_QUARTER) &&
                                 ShowGroupBox.Equals(DEFAULT_SHOW_GROUP_BOX) &&
                                 Smart.Equals(DEFAULT_SMART) &&
                                 SolidFill.Equals(DEFAULT_SOLID_FILL) &&
                                 SortAscending.Equals(DEFAULT_SORT_ASCENDING) &&
                                 SortBySummaryCount.Equals(DEFAULT_SORT_BY_SUMMARY_COUNT) &&
                                 SortDescending.Equals(DEFAULT_SORT_DESCENDING) &&
                                 ThreeColoursRange.Equals(DEFAULT_THREE_COLOURS_RANGE) &&
                                 ThreeWeeksAgo.Equals(DEFAULT_THREE_WEEKS_AGO) &&
                                 Today.Equals(DEFAULT_TODAY) &&
                                 Tomorrow.Equals(DEFAULT_TOMORROW) &&
                                 TwoColoursRange.Equals(DEFAULT_TWO_COLOURS_RANGE) &&
                                 TwoWeeksAgo.Equals(DEFAULT_TWO_WEEKS_AGO) &&
                                 Ungroup.Equals(DEFAULT_UNGROUP) &&
                                 Unknown.Equals(DEFAULT_UNKNOWN) &&
                                 NumberOfItems.Equals(DEFAULT_NUMBER_OF_ITEMS) &&
                                 Year.Equals(DEFAULT_YEAR) &&
                                 YearGroupText.Equals(DEFAULT_YEAR_GROUP_TEXT) &&
                                 Yesterday.Equals(DEFAULT_YESTERDAY);

        public void Reset()
        {
            AfterNextMonth = DEFAULT_AFTER_NEXT_MONTH;

            AlphabeticGroupText = DEFAULT_ALPHABETIC_GROUP_TEXT;

            Bar = DEFAULT_BAR;

            BeforePreviousMonth = DEFAULT_BEFORE_PREVIOUS_MONTH;

            BestFitAll = DEFAULT_BEST_FIT_ALL;

            BestFit = DEFAULT_BEST_FIT;

            Cancel = DEFAULT_CANCEL;

            ClearGrouping = DEFAULT_CLEAR_GROUPING;

            ClearRules = DEFAULT_CLEAR_RULES;

            ClearSorting = DEFAULT_CLEAR_SORTING;

            Collapse = DEFAULT_COLLAPSE;

            Columns = DEFAULT_COLUMNS;

            ConditionalFormatting = DEFAULT_CONDITIONAL_FORMATTING;

            CustomThreeDots = DEFAULT_CUSTOM_THREE_DOTS;

            DateGroupText = DEFAULT_DATE_GROUP_TEXT;

            Day = DEFAULT_DAY;

            DragColumnToGroup = DEFAULT_DRAG_COLUMN_TO_GROUP;

            EarlierDuringThisMonth = DEFAULT_EARLIER_DURING_THIS_MONTH;

            EarlierDuringThisYear = DEFAULT_EARLIER_THIS_YEAR;

            Expand = DEFAULT_EXPAND;

            Finish = DEFAULT_FINISH;

            FullCollapse = DEFAULT_FULL_COLLAPSE;

            FullExpand = DEFAULT_FULL_EXPAND;

            GradientFill = DEFAULT_GRADIENT_FILL;

            Group = DEFAULT_GROUP;

            GroupInterval = DEFAULT_GROUP_INTERVAL;

            HideGroupBox = DEFAULT_HIDE_GROUP_BOX;

            InThreeWeeks = DEFAULT_IN_THREE_WEEKS;

            InTwoWeeks = DEFAULT_IN_TWO_WEEKS;

            LaterDuringThisMonth = DEFAULT_LATER_DURING_THIS_MONTH;

            Month = DEFAULT_MONTH;

            NextMonth = DEFAULT_NEXT_MONTH;

            NextWeek = DEFAULT_NEXT_WEEK;

            NoDate = DEFAULT_NO_DATE;

            Older = DEFAULT_OLDER;

            OneItem = DEFAULT_ONE_ITEM;

            Other = DEFAULT_OTHER;

            PaletteCustom = DEFAULT_PALETTE_CUSTOM;

            PaletteCustomHeading = DEFAULT_PALETTE_CUSTOM_HEADING;

            PreviousMonth = DEFAULT_PREVIOUS_MONTH;

            PreviousWeek = DEFAULT_PREVIOUS_WEEK;

            PreviousYear = DEFAULT_PREVIOUS_YEAR;

            QuarterOne = DEFAULT_QUARTER_ONE;

            QuarterTwo = DEFAULT_QUARTER_TWO;

            QuarterThree = DEFAULT_QUARTER_THREE;

            QuarterFour = DEFAULT_QUARTER_FOUR;

            Quarter = DEFAULT_QUARTER;

            ShowGroupBox = DEFAULT_SHOW_GROUP_BOX;

            Smart = DEFAULT_SMART;

            SolidFill = DEFAULT_SOLID_FILL;

            SortAscending = DEFAULT_SORT_ASCENDING;

            SortBySummaryCount = DEFAULT_SORT_BY_SUMMARY_COUNT;

            SortDescending = DEFAULT_SORT_DESCENDING;

            ThreeColoursRange = DEFAULT_THREE_COLOURS_RANGE;

            ThreeWeeksAgo = DEFAULT_THREE_WEEKS_AGO;

            Today = DEFAULT_TODAY;

            Tomorrow = DEFAULT_TOMORROW;

            TwoColoursRange = DEFAULT_TWO_COLOURS_RANGE;

            TwoWeeksAgo = DEFAULT_TWO_WEEKS_AGO;

            Ungroup = DEFAULT_UNGROUP;

            Unknown = DEFAULT_UNKNOWN;

            NumberOfItems = DEFAULT_NUMBER_OF_ITEMS;

            Year = DEFAULT_YEAR;

            YearGroupText = DEFAULT_YEAR_GROUP_TEXT;

            Yesterday = DEFAULT_YESTERDAY;
        }

        #endregion

        #region Properties

        public string AfterNextMonth { get; set; }

        public string AlphabeticGroupText { get; set; }

        public string Bar { get; set; }

        public string BeforePreviousMonth { get; set; }

        public string BestFitAll { get; set; }

        public string BestFit { get; set; }

        public string Cancel { get; set; }

        public string ClearGrouping { get; set; }

        public string ClearRules { get; set; }

        public string ClearSorting { get; set; }

        public string Collapse { get; set; }

        public string Columns { get; set; }

        public string ConditionalFormatting { get; set; }

        public string CustomThreeDots { get; set; }

        public string DateGroupText { get; set; }

        public string Day { get; set; }

        public string DragColumnToGroup { get; set; }

        public string EarlierDuringThisMonth { get; set; }

        public string EarlierDuringThisYear { get; set; }

        public string Expand { get; set; }

        public string Finish { get; set; }

        public string FullCollapse { get; set; }

        public string FullExpand { get; set; }

        public string GradientFill { get; set; }

        public string Group { get; set; }

        public string GroupInterval { get; set; }

        public string HideGroupBox { get; set; }

        public string InThreeWeeks { get; set; }

        public string InTwoWeeks { get; set; }

        public string LaterDuringThisMonth { get; set; }

        public string Month { get; set; }

        public string NextMonth { get; set; }

        public string NextWeek { get; set; }

        public string NoDate { get; set; }

        public string Older { get; set; }

        public string OneItem { get; set; }

        public string Other { get; set; }

        public string PaletteCustom { get; set; }

        public string PaletteCustomHeading { get; set; }

        public string PreviousMonth { get; set; }

        public string PreviousWeek { get; set; }

        public string PreviousYear { get; set; }

        public string QuarterOne { get; set; }

        public string QuarterTwo { get; set; }

        public string QuarterThree { get; set; }

        public string QuarterFour { get; set; }

        public string Quarter { get; set; }

        public string ShowGroupBox { get; set; }

        public string Smart { get; set; }

        public string SolidFill { get; set; }

        public string SortAscending { get; set; }

        public string SortBySummaryCount { get; set; }

        public string SortDescending { get; set; }

        public string ThreeColoursRange { get; set; }

        public string ThreeWeeksAgo { get; set; }

        public string Today { get; set; }

        public string Tomorrow { get; set; }

        public string TwoColoursRange { get; set; }

        public string TwoWeeksAgo { get; set; }

        public string Ungroup { get; set; }

        public string Unknown { get; set; }

        public string NumberOfItems { get; set; }

        public string Year { get; set; }

        public string YearGroupText { get; set; }

        public string Yesterday { get; set; }

        #endregion
    }
}
