namespace Krypton.Toolkit.Suite.Extended.Outlook.Grid
{
    public class LanguageManager
    {
        #region Instance Fields

        private LanguageStringSettings _languageSettings = new LanguageStringSettings();

        #endregion

        #region Identity

        #endregion

        #region Setters and Getters

        /// <summary>Sets the after next month text.</summary>
        /// <param name="value">The value.</param>
        public void SetAfterNextMonthText(string value) => _languageSettings.AfterNextMonth = value;
        
        public string GetAfterNextMonthText() => _languageSettings.AfterNextMonth;
        
        public void SetAlphabeticGroupText(string value) => _languageSettings.AlphabeticGroupText = value;
        
        public string GetAlphabeticGroupText() => _languageSettings.AlphabeticGroupText;
        
        public void SetBarText(string value) => _languageSettings.Bar = value;
        
        public string GetBarText() => _languageSettings.Bar;
        
        public void SetBeforePreviousMonthText(string value) => _languageSettings.BeforePreviousMonth = value;
        
        public string GetBeforePreviousMonthText() => _languageSettings.BeforePreviousMonth;
        
        public void SetBestFitText(string value) => _languageSettings.BestFit = value;
        
        public string GetBestFitText() => _languageSettings.BestFit;
        
        public void SetBestFitAllText(string value) => _languageSettings.BestFitAll = value;
        
        public string GetBestFitAllText() => _languageSettings.BestFitAll;
        
        public void SetCancelText(string value) => _languageSettings.Cancel = value;
        
        public string GetCancelText() => _languageSettings.Cancel;
        
        public void SetClearGroupingText(string value) => _languageSettings.ClearGrouping = value;
        
        public string GetClearGroupingText() => _languageSettings.ClearGrouping;
        
        public void SetClearRulesText(string value) => _languageSettings.ClearRules = value;
        
        public string GetClearRulesText() => _languageSettings.ClearRules;
        
        public void SetClearSortingText(string value) => _languageSettings.ClearSorting = value;
        
        public string GetClearSortingText() => _languageSettings.ClearSorting;
        
        public void SetCollapseText(string value) => _languageSettings.Collapse = value;
        
        public string GetCollapseText() => _languageSettings.Collapse;
        
        public void SetColumnsText(string value) => _languageSettings.Columns = value;
        
        public string GetColumnsText() => _languageSettings.Columns;

        public void SetConditionalFormattingText(string value) => _languageSettings.ConditionalFormatting = value;

        public string GetConditionalFormattingText() => _languageSettings.ConditionalFormatting;

        public void SetCustomThreeDotsText(string value) => _languageSettings.CustomThreeDots = value;

        public string GetCustomThreeDotsText() => _languageSettings.CustomThreeDots;

        public void SetDateGroupText(string value) => _languageSettings.DateGroupText = value;

        public string GetDateGroupText() => _languageSettings.DateGroupText;

        public void SetDayText(string value) => _languageSettings.Day = value;

        public string GetDayText() => _languageSettings.Day;

        public void SetDragColumnToGroupText(string value) => _languageSettings.DragColumnToGroup = value;

        public string GetDragColumnToGroupText() => _languageSettings.DragColumnToGroup;

        public void SetEarlierDuringThisMonthText(string value) => _languageSettings.EarlierDuringThisMonth = value;

        public string GetEarlierDuringThisMonthText() => _languageSettings.EarlierDuringThisMonth;

        public void SetEarlierThisYearText(string value) => _languageSettings.EarlierThisYear = value;

        public string GetEarlierThisYearText() => _languageSettings.EarlierThisYear;

        public void SetExpandText(string value) => _languageSettings.Expand = value;

        public string GetExpandText() => _languageSettings.Expand;

        public void SetFinishText(string value) => _languageSettings.Finish = value;

        public string GetFinishText() => _languageSettings.Finish;

        public void SetFullCollapseText(string value) => _languageSettings.FullCollapse = value;

        public string GetFullCollapseText() => _languageSettings.FullCollapse;

        public void SetFullExpandText(string value) => _languageSettings.FullExpand = value;

        public string GetFullExpandText() => _languageSettings.FullExpand;

        public void SetGradientFillText(string value) => _languageSettings.GradientFill = value;

        public string GetGradientFillText() => _languageSettings.GradientFill;

        public void SetGroupText(string value) => _languageSettings.Group = value;

        public string GetGroupText() => _languageSettings.Group;

        public void SetGroupIntervalText(string value) => _languageSettings.GroupInterval = value;

        public string GetGroupIntervalText() => _languageSettings.GroupInterval;

        public void SetHideGroupBoxText(string value) => _languageSettings.HideGroupBox = value;

        public string GetHideGroupBoxText() => _languageSettings.HideGroupBox;

        public void SetInThreeWeeksText(string value) => _languageSettings.InThreeWeeks = value;

        public string GetInThreeWeeksText() => _languageSettings.InThreeWeeks;

        public void SetInTwoWeeksText(string value) => _languageSettings.InTwoWeeks = value;

        public string GetInTwoWeeksText() => _languageSettings.InTwoWeeks;

        public void SetLaterDuringThisMonthText(string value) => _languageSettings.LaterDuringThisMonth = value;

        public string GetLaterDuringThisMonthText() => _languageSettings.LaterDuringThisMonth;

        public void SetMonthText(string value) => _languageSettings.Month = value;

        public string GetMonthText() => _languageSettings.Month;

        public void SetNextMonthText(string value) => _languageSettings.NextMonth = value;

        public string GetNextMonthText() => _languageSettings.NextMonth;

        public void SetNextWeekText(string value) => _languageSettings.NextWeek = value;

        public string GetNextWeekText() => _languageSettings.NextWeek;

        public void SetNoDateText(string value) => _languageSettings.NoDate = value;

        public string GetNoDateText() => _languageSettings.NoDate;

        public void SetOlderText(string value) => _languageSettings.Older = value;

        public string GetOlderText() => _languageSettings.Older;

        public void SetOneItemText(string value) => _languageSettings.OneItem = value;

        public string GetOneItemText() => _languageSettings.OneItem;

        public void SetOtherText(string value) => _languageSettings.Other = value;

        public string GetOtherText() => _languageSettings.Other;

        public void SetPaletteCustomText(string value) => _languageSettings.PaletteCustom = value;

        public string GetPaletteCustomText() => _languageSettings.PaletteCustom;

        public void SetPaletteCustomHeadingText(string value) => _languageSettings.PaletteCustomHeading = value;

        public string GetPaletteCustomHeadingText() => _languageSettings.PaletteCustomHeading;

        public void SetPreviousMonthText(string value) => _languageSettings.PreviousMonth = value;

        public string GetPreviousMonthText() => _languageSettings.PreviousMonth;

        public void SetPreviousWeekText(string value) => _languageSettings.PreviousWeek = value;

        public string GetPreviousWeekText() => _languageSettings.PreviousWeek;

        public void SetPreviousYearText(string value) => _languageSettings.PreviousYear = value;

        public string GetPreviousYearText() => _languageSettings.PreviousYear;

        public void SetQ1Text(string value) => _languageSettings.Q1 = value;

        public string GetQ1Text() => _languageSettings.Q1;

        public void SetQ2Text(string value) => _languageSettings.Q2 = value;

        public string GetQ2Text() => _languageSettings.Q2;

        public void SetQ3Text(string value) => _languageSettings.Q3 = value;

        public string GetQ3Text() => _languageSettings.Q3;

        public void SetQ4Text(string value) => _languageSettings.Q4 = value;

        public string GetQ4Text() => _languageSettings.Q4;

        public void SetQuarterText(string value) => _languageSettings.Quarter = value;

        public string GetQuarterText() => _languageSettings.Quarter;

        public void SetShowGroupBoxText(string value) => _languageSettings.ShowGroupBox = value;

        public string GetShowGroupBoxText() => _languageSettings.ShowGroupBox;

        public void SetSmartText(string value) => _languageSettings.Smart = value;

        public string GetSmartText() => _languageSettings.Smart;

        public void SetSolidFillText(string value) => _languageSettings.SolidFill = value;

        public string GetSolidFillText() => _languageSettings.SolidFill;

        public void SetSortAscendingText(string value) => _languageSettings.SortAscending = value;

        public string GetSortAscendingText() => _languageSettings.SortAscending;

        public void SetSortBySummaryCountText(string value) => _languageSettings.SortBySummaryCount = value;

        public string GetSortBySummaryCountText() => _languageSettings.SortBySummaryCount;

        public void SetSortDescendingText(string value) => _languageSettings.SortDescending = value;

        public string GetSortDescendingText() => _languageSettings.SortDescending;

        public void SetThreeColorsRangeText(string value) => _languageSettings.ThreeColorsRange = value;

        public string GetThreeColorsRangeText() => _languageSettings.ThreeColorsRange;

        public void SetThreeWeeksAgoText(string value) => _languageSettings.ThreeWeeksAgo = value;

        public string GetThreeWeeksAgoText() => _languageSettings.ThreeWeeksAgo;

        public void SetTodayText(string value) => _languageSettings.Today = value;

        public string GetTodayText() => _languageSettings.Today;

        public void SetTomorrowText(string value) => _languageSettings.Tomorrow = value;

        public string GetTomorrowText() => _languageSettings.Tomorrow;

        public void SetTwoColorsRangeText(string value) => _languageSettings.TwoColorsRange = value;

        public string GetTwoColorsRangeText() => _languageSettings.TwoColorsRange;

        public void SetTwoWeeksAgoText(string value) => _languageSettings.TwoWeeksAgo = value;

        public string GetTwoWeeksAgoText() => _languageSettings.TwoWeeksAgo;

        public void SetUngroupText(string value) => _languageSettings.Ungroup = value;

        public string GetUngroupText() => _languageSettings.Ungroup;

        public void SetUnknownText(string value) => _languageSettings.Unknown = value;

        public string GetUnknownText() => _languageSettings.Unknown;

        public void SetXXXItemsText(string value) => _languageSettings.XXXItems = value;

        public string GetXXXItemsText() => _languageSettings.XXXItems;

        public void SetYearText(string value) => _languageSettings.Year = value;

        public string GetYearText() => _languageSettings.Year;

        public void SetYearGroupText(string value) => _languageSettings.YearGroupText = value;

        public string GetYearGroupText() => _languageSettings.YearGroupText;

        public void SetYesterdayText(string value) => _languageSettings.Yesterday = value;

        /// <summary>Gets the yesterday text.</summary>
        public string GetYesterdayText() => _languageSettings.Yesterday;

        #endregion

        #region Methods

        public static void SaveLanguageSettings()
        {
            LanguageManager languageManager = new LanguageManager();

            LanguageStringSettings languageSettings = languageManager._languageSettings;

            DialogResult result = KryptonMessageBox.Show(
                "Do you want to save the language settings in their current state?", "Save Language Settings",
                MessageBoxButtons.YesNo, KryptonMessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                languageSettings.Save();
            }
        }

        public static void ResetLanguageSettings()
        {
            LanguageManager languageManager = new LanguageManager();

            LanguageDefaultNeutralStringSettings defaultNeutralStringSettings =
                new LanguageDefaultNeutralStringSettings();

            DialogResult result = KryptonMessageBox.Show(
                "You are about to set the language settings back to their defaults. Do you want to continue?",
                "Reset Language Settings", MessageBoxButtons.YesNo, KryptonMessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                languageManager.SetAfterNextMonthText(defaultNeutralStringSettings.AfterNextMonth);

                languageManager.SetAlphabeticGroupText(defaultNeutralStringSettings.AlphabeticGroupText);

                languageManager.SetBarText(defaultNeutralStringSettings.Bar);

                languageManager.SetBeforePreviousMonthText(defaultNeutralStringSettings.BeforePreviousMonth);

                languageManager.SetBestFitAllText(defaultNeutralStringSettings.BestFitAll);

                languageManager.SetBestFitText(defaultNeutralStringSettings.BestFit);

                languageManager.SetCancelText(defaultNeutralStringSettings.Cancel);

                languageManager.SetClearGroupingText(defaultNeutralStringSettings.ClearGrouping);

                languageManager.SetClearRulesText(defaultNeutralStringSettings.ClearRules);

                languageManager.SetClearSortingText(defaultNeutralStringSettings.ClearSorting);

                languageManager.SetCollapseText(defaultNeutralStringSettings.Collapse);

                languageManager.SetColumnsText(defaultNeutralStringSettings.Columns);

                languageManager.SetConditionalFormattingText(defaultNeutralStringSettings.ConditionalFormatting);

                languageManager.SetCustomThreeDotsText(defaultNeutralStringSettings.CustomThreeDots);

                languageManager.SetDateGroupText(defaultNeutralStringSettings.DateGroupText);

                languageManager.SetDayText(defaultNeutralStringSettings.Day);

                languageManager.SetDragColumnToGroupText(defaultNeutralStringSettings.DragColumnToGroup);

                languageManager.SetEarlierDuringThisMonthText(defaultNeutralStringSettings.EarlierDuringThisMonth);

                languageManager.SetEarlierThisYearText(defaultNeutralStringSettings.EarlierThisYear);

                languageManager.SetExpandText(defaultNeutralStringSettings.Expand);

                languageManager.SetFinishText(defaultNeutralStringSettings.Finish);

                languageManager.SetFullCollapseText(defaultNeutralStringSettings.FullCollapse);

                languageManager.SetFullExpandText(defaultNeutralStringSettings.FullExpand);

                languageManager.SetGradientFillText(defaultNeutralStringSettings.GradientFill);

                languageManager.SetGroupText(defaultNeutralStringSettings.Group);

                languageManager.SetGroupIntervalText(defaultNeutralStringSettings.GroupInterval);

                languageManager.SetHideGroupBoxText(defaultNeutralStringSettings.HideGroupBox);

                languageManager.SetInThreeWeeksText(defaultNeutralStringSettings.InThreeWeeks);

                languageManager.SetInTwoWeeksText(defaultNeutralStringSettings.InTwoWeeks);

                languageManager.SetLaterDuringThisMonthText(defaultNeutralStringSettings.LaterDuringThisMonth);

                languageManager.SetMonthText(defaultNeutralStringSettings.Month);

                languageManager.SetNextMonthText(defaultNeutralStringSettings.NextMonth);

                languageManager.SetNextWeekText(defaultNeutralStringSettings.NextWeek);

                languageManager.SetNoDateText(defaultNeutralStringSettings.NoDate);

                languageManager.SetOlderText(defaultNeutralStringSettings.Older);

                languageManager.SetOneItemText(defaultNeutralStringSettings.OneItem);

                languageManager.SetOtherText(defaultNeutralStringSettings.Other);

                languageManager.SetPaletteCustomText(defaultNeutralStringSettings.PaletteCustom);

                languageManager.SetPaletteCustomHeadingText(defaultNeutralStringSettings.PaletteCustomHeading);

                languageManager.SetPreviousMonthText(defaultNeutralStringSettings.PreviousMonth);

                languageManager.SetPreviousWeekText(defaultNeutralStringSettings.PreviousWeek);

                languageManager.SetPreviousYearText(defaultNeutralStringSettings.PreviousYear);

                languageManager.SetQ1Text(defaultNeutralStringSettings.Q1);

                languageManager.SetQ2Text(defaultNeutralStringSettings.Q2);

                languageManager.SetQ3Text(defaultNeutralStringSettings.Q3);

                languageManager.SetQ4Text(defaultNeutralStringSettings.Q4);

                languageManager.SetQuarterText(defaultNeutralStringSettings.Quarter);

                languageManager.SetShowGroupBoxText(defaultNeutralStringSettings.ShowGroupBox);

                languageManager.SetSmartText(defaultNeutralStringSettings.Smart);

                languageManager.SetSolidFillText(defaultNeutralStringSettings.SolidFill);

                languageManager.SetSortAscendingText(defaultNeutralStringSettings.SortAscending);

                languageManager.SetSortBySummaryCountText(defaultNeutralStringSettings.SortBySummaryCount);

                languageManager.SetSortDescendingText(defaultNeutralStringSettings.SortDescending);

                languageManager.SetThreeColorsRangeText(defaultNeutralStringSettings.ThreeColorsRange);

                languageManager.SetThreeWeeksAgoText(defaultNeutralStringSettings.ThreeWeeksAgo);

                languageManager.SetTodayText(defaultNeutralStringSettings.Today);

                languageManager.SetTomorrowText(defaultNeutralStringSettings.Tomorrow);

                languageManager.SetTwoColorsRangeText(defaultNeutralStringSettings.TwoColorsRange);

                languageManager.SetTwoWeeksAgoText(defaultNeutralStringSettings.TwoWeeksAgo);

                languageManager.SetUngroupText(defaultNeutralStringSettings.Ungroup);

                languageManager.SetUnknownText(defaultNeutralStringSettings.Unknown);

                languageManager.SetXXXItemsText(defaultNeutralStringSettings.XXXItems);

                languageManager.SetYearText(defaultNeutralStringSettings.Year);

                languageManager.SetYearGroupText(defaultNeutralStringSettings.YearGroupText);

                languageManager.SetYesterdayText(defaultNeutralStringSettings.Yesterday);

                languageManager._languageSettings.Save();
            }
        }

        #endregion
    }
}