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

        private const string DefaultAfterNextMonth = "After next month";

        private const string DefaultAlphabeticGroupText = "Alphabetic";

        private const string DefaultBar = "Data Bars";

        private const string DefaultBeforePreviousMonth = "Before previous month";

        private const string DefaultBestFitAll = "Best fit (all columns)";

        private const string DefaultBestFit = "Best fit";

        private const string DefaultCancel = "Cancel";

        private const string DefaultClearGrouping = "Clear grouping";

        private const string DefaultClearRules = "Clear rules...";

        private const string DefaultClearSorting = "Clear sorting";

        private const string DefaultCollapse = "Collapse";

        private const string DefaultColumns = "Columns";

        private const string DefaultConditionalFormatting = "Conditional formatting";

        private const string DefaultCustomThreeDots = "Custom...";

        private const string DefaultDateGroupText = "Date";

        private const string DefaultDay = "Day";

        private const string DefaultDragColumnToGroup = "Drag a column header here to group by that column";

        private const string DefaultEarlierDuringThisMonth = "Earlier during this month";

        private const string DefaultEarlierThisYear = "Earlier this year";

        private const string DefaultExpand = "Expand";

        private const string DefaultFinish = "Finish";

        private const string DefaultFullCollapse = "Full collapse";

        private const string DefaultFullExpand = "Full expand";

        private const string DefaultGradientFill = "Gradient Fill";

        private const string DefaultGroup = "Group by this column";

        private const string DefaultGroupInterval = "Group interval";

        private const string DefaultHideGroupBox = "Hide GroupBox";

        private const string DefaultInThreeWeeks = "In three weeks";

        private const string DefaultInTwoWeeks = "In two weeks";

        private const string DefaultLaterDuringThisMonth = "Later during this month";

        private const string DefaultMonth = "Month";

        private const string DefaultNextMonth = "Next month";

        private const string DefaultNextWeek = "Next week";

        private const string DefaultNoDate = "No date";

        private const string DefaultOlder = "Older";

        private const string DefaultOneItem = "1 item";

        private const string DefaultOther = "Other";

        private const string DefaultPaletteCustom = "Custom...";

        private const string DefaultPaletteCustomHeading = "Custom palettes";

        private const string DefaultPreviousMonth = "Previous month";

        private const string DefaultPreviousWeek = "Previous week";

        private const string DefaultPreviousYear = "Previous year";

        private const string DefaultQuarterOne = "Q1";

        private const string DefaultQuarterTwo = "Q2";

        private const string DefaultQuarterThree = "Q3";

        private const string DefaultQuarterFour = "Q4";

        private const string DefaultQuarter = "Quarter";

        private const string DefaultShowGroupBox = "Show GroupBox";

        private const string DefaultSmart = "Smart";

        private const string DefaultSolidFill = "Solid Fill";

        private const string DefaultSortAscending = "Sort ascending";

        private const string DefaultSortBySummaryCount = "Sort by summary count";

        private const string DefaultSortDescending = "Sort descending";

        private const string DefaultThreeColoursRange = "Three Colour Scale";

        private const string DefaultThreeWeeksAgo = "Three weeks ago";

        private const string DefaultToday = "Today";

        private const string DefaultTomorrow = "Tomorrow";

        private const string DefaultTwoColoursRange = "Two Colour Scale";

        private const string DefaultTwoWeeksAgo = "Two weeks ago";

        private const string DefaultUngroup = "Ungroup";

        private const string DefaultUnknown = "Unknown";

        private const string DefaultNumberOfItems = " items";

        private const string DefaultYear = "Year";

        private const string DefaultYearGroupText = "Year";

        private const string DefaultYesterday = "Yesterday";

        private const string DefaultMonday = "Monday";

        private const string DefaultTuesday = "Tuesday";

        private const string DefaultWednesday = "Wednesday";

        private const string DefaultThursday = "Thursday";

        private const string DefaultFriday = "Friday";

        private const string DefaultSaturday = "Saturday";

        private const string DefaultSunday = "Sunday";

        private const string DefaultMinimumColour = "Min Colour";

        private const string DefaultMediumColour = "Medium Colour";

        private const string DefaultMaximumColour = "Max Colour";

        #endregion

        #region Identity

        public OutlookGridLanguageStrings() => Reset();

        public override string ToString() => !IsDefault ? "Modified" : string.Empty;

        #endregion

        #region Public

        [Browsable(false)]
        public bool IsDefault => AfterNextMonth.Equals(DefaultAfterNextMonth) &&
                                 AlphabeticGroupText.Equals(DefaultAlphabeticGroupText) &&
                                 Bar.Equals(DefaultBar) &&
                                 BeforePreviousMonth.Equals(DefaultBeforePreviousMonth) &&
                                 BestFitAll.Equals(DefaultBestFitAll) &&
                                 BestFit.Equals(DefaultBestFit) &&
                                 Cancel.Equals(DefaultCancel) &&
                                 ClearGrouping.Equals(DefaultClearGrouping) &&
                                 ClearRules.Equals(DefaultClearRules) &&
                                 ClearSorting.Equals(DefaultClearSorting) &&
                                 Collapse.Equals(DefaultCollapse) &&
                                 Columns.Equals(DefaultColumns) &&
                                 ConditionalFormatting.Equals(DefaultConditionalFormatting) &&
                                 CustomThreeDots.Equals(DefaultCustomThreeDots) &&
                                 DateGroupText.Equals(DefaultDateGroupText) &&
                                 Day.Equals(DefaultDay) &&
                                 DragColumnToGroup.Equals(DefaultDragColumnToGroup) &&
                                 EarlierDuringThisMonth.Equals(DefaultEarlierDuringThisMonth) &&
                                 EarlierDuringThisYear.Equals(DefaultEarlierThisYear) &&
                                 Expand.Equals(DefaultExpand) &&
                                 Finish.Equals(DefaultFinish) &&
                                 FullCollapse.Equals(DefaultFullCollapse) &&
                                 FullExpand.Equals(DefaultFullExpand) &&
                                 GradientFill.Equals(DefaultGradientFill) &&
                                 Group.Equals(DefaultGroup) &&
                                 GroupInterval.Equals(DefaultGroupInterval) &&
                                 HideGroupBox.Equals(DefaultHideGroupBox) &&
                                 InThreeWeeks.Equals(DefaultInThreeWeeks) &&
                                 InTwoWeeks.Equals(DefaultInTwoWeeks) &&
                                 LaterDuringThisMonth.Equals(DefaultLaterDuringThisMonth) &&
                                 Month.Equals(DefaultMonth) &&
                                 NextMonth.Equals(DefaultNextMonth) &&
                                 NextWeek.Equals(DefaultNextWeek) &&
                                 NoDate.Equals(DefaultNoDate) &&
                                 Older.Equals(DefaultOlder) &&
                                 OneItem.Equals(DefaultOneItem) &&
                                 Other.Equals(DefaultOther) &&
                                 PaletteCustom.Equals(DefaultPaletteCustom) &&
                                 PaletteCustomHeading.Equals(DefaultPaletteCustomHeading) &&
                                 PreviousMonth.Equals(DefaultPreviousMonth) &&
                                 PreviousWeek.Equals(DefaultPreviousWeek) &&
                                 PreviousYear.Equals(DefaultPreviousYear) &&
                                 QuarterOne.Equals(DefaultQuarterOne) &&
                                 QuarterTwo.Equals(DefaultQuarterTwo) &&
                                 QuarterThree.Equals(DefaultQuarterThree) &&
                                 QuarterFour.Equals(DefaultQuarterFour) &&
                                 Quarter.Equals(DefaultQuarter) &&
                                 ShowGroupBox.Equals(DefaultShowGroupBox) &&
                                 Smart.Equals(DefaultSmart) &&
                                 SolidFill.Equals(DefaultSolidFill) &&
                                 SortAscending.Equals(DefaultSortAscending) &&
                                 SortBySummaryCount.Equals(DefaultSortBySummaryCount) &&
                                 SortDescending.Equals(DefaultSortDescending) &&
                                 ThreeColoursRange.Equals(DefaultThreeColoursRange) &&
                                 ThreeWeeksAgo.Equals(DefaultThreeWeeksAgo) &&
                                 Today.Equals(DefaultToday) &&
                                 Tomorrow.Equals(DefaultTomorrow) &&
                                 TwoColoursRange.Equals(DefaultTwoColoursRange) &&
                                 TwoWeeksAgo.Equals(DefaultTwoWeeksAgo) &&
                                 UnGroup.Equals(DefaultUngroup) &&
                                 Unknown.Equals(DefaultUnknown) &&
                                 NumberOfItems.Equals(DefaultNumberOfItems) &&
                                 Year.Equals(DefaultYear) &&
                                 YearGroupText.Equals(DefaultYearGroupText) &&
                                 Yesterday.Equals(DefaultYesterday) &&
                                 Monday.Equals(DefaultMonday) &&
                                 Tuesday.Equals(DefaultTuesday) &&
                                 Wednesday.Equals(DefaultWednesday) &&
                                 Thursday.Equals(DefaultThursday) &&
                                 Friday.Equals(DefaultFriday) &&
                                 Saturday.Equals(DefaultSaturday) &&
                                 Sunday.Equals(DefaultSunday) &&
                                 MinimumColour.Equals(DefaultMinimumColour) &&
                                 MediumColour.Equals(DefaultMediumColour) &&
                                 MaximumColour.Equals(DefaultMaximumColour);

        public void Reset()
        {
            AfterNextMonth = DefaultAfterNextMonth;

            AlphabeticGroupText = DefaultAlphabeticGroupText;

            Bar = DefaultBar;

            BeforePreviousMonth = DefaultBeforePreviousMonth;

            BestFitAll = DefaultBestFitAll;

            BestFit = DefaultBestFit;

            Cancel = DefaultCancel;

            ClearGrouping = DefaultClearGrouping;

            ClearRules = DefaultClearRules;

            ClearSorting = DefaultClearSorting;

            Collapse = DefaultCollapse;

            Columns = DefaultColumns;

            ConditionalFormatting = DefaultConditionalFormatting;

            CustomThreeDots = DefaultCustomThreeDots;

            DateGroupText = DefaultDateGroupText;

            Day = DefaultDay;

            DragColumnToGroup = DefaultDragColumnToGroup;

            EarlierDuringThisMonth = DefaultEarlierDuringThisMonth;

            EarlierDuringThisYear = DefaultEarlierThisYear;

            Expand = DefaultExpand;

            Finish = DefaultFinish;

            FullCollapse = DefaultFullCollapse;

            FullExpand = DefaultFullExpand;

            GradientFill = DefaultGradientFill;

            Group = DefaultGroup;

            GroupInterval = DefaultGroupInterval;

            HideGroupBox = DefaultHideGroupBox;

            InThreeWeeks = DefaultInThreeWeeks;

            InTwoWeeks = DefaultInTwoWeeks;

            LaterDuringThisMonth = DefaultLaterDuringThisMonth;

            Month = DefaultMonth;

            NextMonth = DefaultNextMonth;

            NextWeek = DefaultNextWeek;

            NoDate = DefaultNoDate;

            Older = DefaultOlder;

            OneItem = DefaultOneItem;

            Other = DefaultOther;

            PaletteCustom = DefaultPaletteCustom;

            PaletteCustomHeading = DefaultPaletteCustomHeading;

            PreviousMonth = DefaultPreviousMonth;

            PreviousWeek = DefaultPreviousWeek;

            PreviousYear = DefaultPreviousYear;

            QuarterOne = DefaultQuarterOne;

            QuarterTwo = DefaultQuarterTwo;

            QuarterThree = DefaultQuarterThree;

            QuarterFour = DefaultQuarterFour;

            Quarter = DefaultQuarter;

            ShowGroupBox = DefaultShowGroupBox;

            Smart = DefaultSmart;

            SolidFill = DefaultSolidFill;

            SortAscending = DefaultSortAscending;

            SortBySummaryCount = DefaultSortBySummaryCount;

            SortDescending = DefaultSortDescending;

            ThreeColoursRange = DefaultThreeColoursRange;

            ThreeWeeksAgo = DefaultThreeWeeksAgo;

            Today = DefaultToday;

            Tomorrow = DefaultTomorrow;

            TwoColoursRange = DefaultTwoColoursRange;

            TwoWeeksAgo = DefaultTwoWeeksAgo;

            UnGroup = DefaultUngroup;

            Unknown = DefaultUnknown;

            NumberOfItems = DefaultNumberOfItems;

            Year = DefaultYear;

            YearGroupText = DefaultYearGroupText;

            Yesterday = DefaultYesterday;

            Monday = DefaultMonday;

            Tuesday = DefaultTuesday;

            Wednesday = DefaultWednesday;

            Thursday = DefaultThursday;

            Friday = DefaultFriday;

            Saturday = DefaultSaturday;

            Sunday = DefaultSunday;

            MinimumColour = DefaultMinimumColour;

            MediumColour = DefaultMediumColour;

            MaximumColour = DefaultMaximumColour;
        }

        #endregion

        #region Properties

        /// <summary>Gets or sets the after next month string for the KryptonOutlookGrid.</summary>
        [Localizable(true)]
        [Category(@"Visuals")]
        [Description(@"AfterNextMonth string used for Krypton Outlook Grid.")]
        [DefaultValue(DefaultAfterNextMonth)]
        [RefreshProperties(RefreshProperties.All)]
        public string AfterNextMonth { get; set; }

        /// <summary>Gets or sets the alphabetic group string for the KryptonOutlookGrid.</summary>
        public string AlphabeticGroupText { get; set; }

        /// <summary>Gets or sets the bar string for the KryptonOutlookGrid.</summary>
        public string Bar { get; set; }

        /// <summary>Gets or sets the before previous month string for the KryptonOutlookGrid.</summary>
        public string BeforePreviousMonth { get; set; }

        /// <summary>Gets or sets the best fit all string for the KryptonOutlookGrid.</summary>
        public string BestFitAll { get; set; }

        /// <summary>Gets or sets the best fit string for the KryptonOutlookGrid.</summary>
        public string BestFit { get; set; }

        /// <summary>Gets or sets the cancel string for the KryptonOutlookGrid.</summary>
        public string Cancel { get; set; }

        /// <summary>Gets or sets the clear grouping string for the KryptonOutlookGrid.</summary>
        public string ClearGrouping { get; set; }

        /// <summary>Gets or sets the clear rules string for the KryptonOutlookGrid.</summary>
        public string ClearRules { get; set; }

        /// <summary>Gets or sets the clear sorting string for the KryptonOutlookGrid.</summary>
        public string ClearSorting { get; set; }

        /// <summary>Gets or sets the collapse string for the KryptonOutlookGrid.</summary>
        public string Collapse { get; set; }

        /// <summary>Gets or sets the columns string for the KryptonOutlookGrid.</summary>
        public string Columns { get; set; }

        /// <summary>Gets or sets the conditional formatting string for the KryptonOutlookGrid.</summary>
        public string ConditionalFormatting { get; set; }

        /// <summary>Gets or sets the custom three dots string for the KryptonOutlookGrid.</summary>
        public string CustomThreeDots { get; set; }

        /// <summary>Gets or sets the date group text string for the KryptonOutlookGrid.</summary>
        public string DateGroupText { get; set; }

        /// <summary>Gets or sets the day string for the KryptonOutlookGrid.</summary>
        public string Day { get; set; }

        /// <summary>Gets or sets the drag column to group string for the KryptonOutlookGrid.</summary>
        public string DragColumnToGroup { get; set; }

        /// <summary>Gets or sets the earlier during this month string for the KryptonOutlookGrid.</summary>
        public string EarlierDuringThisMonth { get; set; }

        /// <summary>Gets or sets the earlier during this year string for the KryptonOutlookGrid.</summary>
        public string EarlierDuringThisYear { get; set; }

        /// <summary>Gets or sets the expand string for the KryptonOutlookGrid.</summary>
        public string Expand { get; set; }

        /// <summary>Gets or sets the finish string for the KryptonOutlookGrid.</summary>
        public string Finish { get; set; }

        /// <summary>Gets or sets the full collapse string for the KryptonOutlookGrid.</summary>
        public string FullCollapse { get; set; }

        /// <summary>Gets or sets the full expand string for the KryptonOutlookGrid.</summary>
        public string FullExpand { get; set; }

        /// <summary>Gets or sets the gradient fill string for the KryptonOutlookGrid.</summary>
        public string GradientFill { get; set; }

        /// <summary>Gets or sets the group string for the KryptonOutlookGrid.</summary>
        public string Group { get; set; }

        /// <summary>Gets or sets the group interval string for the KryptonOutlookGrid.</summary>
        public string GroupInterval { get; set; }

        /// <summary>Gets or sets the hide group box string for the KryptonOutlookGrid.</summary>
        public string HideGroupBox { get; set; }

        /// <summary>Gets or sets the in three weeks string for the KryptonOutlookGrid.</summary>
        public string InThreeWeeks { get; set; }

        /// <summary>Gets or sets the in two weeks string for the KryptonOutlookGrid.</summary>
        public string InTwoWeeks { get; set; }

        /// <summary>Gets or sets the later during this month string for the KryptonOutlookGrid.</summary>
        public string LaterDuringThisMonth { get; set; }

        /// <summary>Gets or sets the month string for the KryptonOutlookGrid.</summary>
        public string Month { get; set; }

        /// <summary>Gets or sets the next month string for the KryptonOutlookGrid.</summary>
        public string NextMonth { get; set; }

        /// <summary>Gets or sets the next week string for the KryptonOutlookGrid.</summary>
        public string NextWeek { get; set; }

        /// <summary>Gets or sets the no date string for the KryptonOutlookGrid.</summary>
        public string NoDate { get; set; }

        /// <summary>Gets or sets the older string for the KryptonOutlookGrid.</summary>
        public string Older { get; set; }

        /// <summary>Gets or sets the one item string for the KryptonOutlookGrid.</summary>
        public string OneItem { get; set; }

        /// <summary>Gets or sets the other string for the KryptonOutlookGrid.</summary>
        public string Other { get; set; }

        /// <summary>Gets or sets the palette custom string for the KryptonOutlookGrid.</summary>
        public string PaletteCustom { get; set; }

        /// <summary>Gets or sets the palette custom heading string for the KryptonOutlookGrid.</summary>
        public string PaletteCustomHeading { get; set; }

        /// <summary>Gets or sets the previous month string for the KryptonOutlookGrid.</summary>
        public string PreviousMonth { get; set; }

        /// <summary>Gets or sets the previous week string for the KryptonOutlookGrid.</summary>
        public string PreviousWeek { get; set; }

        /// <summary>Gets or sets the previous year string for the KryptonOutlookGrid.</summary>
        public string PreviousYear { get; set; }

        /// <summary>Gets or sets the quarter one string for the KryptonOutlookGrid.</summary>
        public string QuarterOne { get; set; }

        /// <summary>Gets or sets the quarter two string for the KryptonOutlookGrid.</summary>
        public string QuarterTwo { get; set; }

        /// <summary>Gets or sets the quarter three string for the KryptonOutlookGrid.</summary>
        public string QuarterThree { get; set; }

        /// <summary>Gets or sets the quarter four string for the KryptonOutlookGrid.</summary>
        public string QuarterFour { get; set; }

        /// <summary>Gets or sets the quarter string for the KryptonOutlookGrid.</summary>
        public string Quarter { get; set; }

        /// <summary>Gets or sets the show group box string for the KryptonOutlookGrid.</summary>
        public string ShowGroupBox { get; set; }

        /// <summary>Gets or sets the smart string for the KryptonOutlookGrid.</summary>
        public string Smart { get; set; }

        /// <summary>Gets or sets the solid fill string for the KryptonOutlookGrid.</summary>
        public string SolidFill { get; set; }

        /// <summary>Gets or sets the sort ascending string for the KryptonOutlookGrid.</summary>
        public string SortAscending { get; set; }

        /// <summary>Gets or sets the sort by summary count string for the KryptonOutlookGrid.</summary>
        public string SortBySummaryCount { get; set; }

        /// <summary>Gets or sets the sort descending string for the KryptonOutlookGrid.</summary>
        public string SortDescending { get; set; }

        /// <summary>Gets or sets the three colours range string for the KryptonOutlookGrid.</summary>
        public string ThreeColoursRange { get; set; }

        /// <summary>Gets or sets the three weeks ago string for the KryptonOutlookGrid.</summary>
        public string ThreeWeeksAgo { get; set; }

        /// <summary>Gets or sets the today string for the KryptonOutlookGrid.</summary>
        public string Today { get; set; }

        /// <summary>Gets or sets the tomorrow string for the KryptonOutlookGrid.</summary>
        public string Tomorrow { get; set; }

        /// <summary>Gets or sets the two colours range string for the KryptonOutlookGrid.</summary>
        public string TwoColoursRange { get; set; }

        /// <summary>Gets or sets the two weeks ago string for the KryptonOutlookGrid.</summary>
        public string TwoWeeksAgo { get; set; }

        /// <summary>Gets or sets the UnGroup string for the KryptonOutlookGrid.</summary>
        public string UnGroup { get; set; }

        /// <summary>Gets or sets the unknown string for the KryptonOutlookGrid.</summary>
        public string Unknown { get; set; }

        /// <summary>Gets or sets the number of items string for the KryptonOutlookGrid.</summary>
        public string NumberOfItems { get; set; }

        /// <summary>Gets or sets the year string for the KryptonOutlookGrid.</summary>
        public string Year { get; set; }

        /// <summary>Gets or sets the year group text string for the KryptonOutlookGrid.</summary>
        public string YearGroupText { get; set; }

        /// <summary>Gets or sets the yesterday string for the KryptonOutlookGrid.</summary>
        public string Yesterday { get; set; }

        public string Monday { get; set; }

        public string Tuesday { get; set; }

        public string Wednesday { get; set; }

        public string Thursday { get; set; }

        public string Friday { get; set; }

        public string Saturday { get; set; }

        public string Sunday { get; set; }

        public string MinimumColour { get; set; }

        public string MediumColour { get; set; }

        public string MaximumColour { get; set; }

        #endregion
    }
}
