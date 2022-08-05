using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Suite.Extended.Outlook.Grid
{
    public class LanguageStringStorage : Storage
    {
        #region Instance Fields

        private LanguageStringSettings _languageStrings = new LanguageStringSettings();

        #endregion

        public override bool IsDefault { get; }

        #region Properties

        public string AfterNextMonth { get => _languageStrings.AfterNextMonth; set => _languageStrings.AfterNextMonth = value; }

        public string AlphabeticGroupText { get => _languageStrings.AlphabeticGroupText; set => _languageStrings.AlphabeticGroupText = value; }

        public string Bar { get => _languageStrings.Bar; set => _languageStrings.Bar = value; }

        public string BeforePreviousMonth { get => _languageStrings.BeforePreviousMonth; set => _languageStrings.BeforePreviousMonth = value; }

        public string BestFitAll { get => _languageStrings.BestFitAll; set => _languageStrings.BestFitAll = value; }

        public string BestFit { get => _languageStrings.BestFit; set => _languageStrings.BestFit = value; }

        public string Cancel { get => _languageStrings.Cancel; set => _languageStrings.Cancel = value; }

        public string ClearGrouping { get => _languageStrings.ClearGrouping; set => _languageStrings.ClearGrouping = value; }

        public string ClearRules { get => _languageStrings.ClearRules; set => _languageStrings.ClearRules = value; }

        public string ClearSorting { get => _languageStrings.ClearSorting; set => _languageStrings.ClearSorting = value; }

        public string Collapse { get => _languageStrings.Collapse; set => _languageStrings.Collapse = value; }

        public string Columns { get => _languageStrings.Columns; set => _languageStrings.Columns = value; }

        public string ConditionalFormatting { get => _languageStrings.ConditionalFormatting; set => _languageStrings.ConditionalFormatting = value; }

        public string CustomThreeDots { get => _languageStrings.CustomThreeDots; set => _languageStrings.CustomThreeDots = value; }

        public string DateGroupText { get => _languageStrings.DateGroupText; set => _languageStrings.DateGroupText = value; }

        public string Day { get => _languageStrings.Day; set => _languageStrings.Day = value; }

        public string DragColumnToGroup { get => _languageStrings.DragColumnToGroup; set => _languageStrings.DragColumnToGroup = value; }

        public string EarlierDuringThisMonth { get => _languageStrings.EarlierDuringThisMonth; set => _languageStrings.EarlierDuringThisMonth = value; }

        public string EarlierThisYear { get => _languageStrings.EarlierThisYear; set => _languageStrings.EarlierThisYear = value; }

        public string Expand { get => _languageStrings.Expand; set => _languageStrings.Expand = value; }

        public string Finish { get => _languageStrings.Finish; set => _languageStrings.Finish = value; }

        public string FullCollapse { get => _languageStrings.FullCollapse; set => _languageStrings.FullCollapse = value; }

        public string FullExpand { get => _languageStrings.FullExpand; set => _languageStrings.FullExpand = value; }

        public string GradientFill { get => _languageStrings.GradientFill; set => _languageStrings.GradientFill = value; }

        public string Group { get => _languageStrings.Group; set => _languageStrings.Group = value; }

        public string GroupInterval { get => _languageStrings.GroupInterval; set => _languageStrings.GroupInterval = value; }

        public string HideGroupBox { get => _languageStrings.HideGroupBox; set => _languageStrings.HideGroupBox = value; }

        public string InThreeWeeks { get => _languageStrings.InThreeWeeks; set => _languageStrings.InThreeWeeks = value; }

        public string InTwoWeeks { get => _languageStrings.InTwoWeeks; set => _languageStrings.InTwoWeeks = value; }

        public string LaterDuringThisMonth { get => _languageStrings.LaterDuringThisMonth; set => _languageStrings.LaterDuringThisMonth = value; }

        public string Month { get => _languageStrings.Month; set => _languageStrings.Month = value; }

        public string NextMonth { get => _languageStrings.NextMonth; set => _languageStrings.NextMonth = value; }

        public string NextWeek { get => _languageStrings.NextWeek; set => _languageStrings.NextWeek = value; }

        public string NoDate { get => _languageStrings.NoDate; set => _languageStrings.NoDate = value; }

        public string Older { get => _languageStrings.Older; set => _languageStrings.Older = value; }

        public string OneItem { get => _languageStrings.OneItem; set => _languageStrings.OneItem = value; }

        public string Other { get => _languageStrings.Other; set => _languageStrings.Other = value; }

        public string PaletteCustom { get => _languageStrings.PaletteCustom; set => _languageStrings.PaletteCustom = value; }

        public string PaletteCustomHeading { get => _languageStrings.PaletteCustomHeading; set => _languageStrings.PaletteCustomHeading = value; }

        public string PreviousMonth { get => _languageStrings.PreviousMonth; set => _languageStrings.PreviousMonth = value; }

        public string PreviousWeek { get => _languageStrings.PreviousWeek; set => _languageStrings.PreviousWeek = value; }

        public string PreviousYear { get => _languageStrings.PreviousYear; set => _languageStrings.PreviousYear = value; }

        public string Q1 { get => _languageStrings.Q1; set => _languageStrings.Q1 = value; }

        public string Q2 { get => _languageStrings.Q2; set => _languageStrings.Q2 = value; }

        public string Q3 { get => _languageStrings.Q3; set => _languageStrings.Q3 = value; }

        public string Q4 { get => _languageStrings.Q4; set => _languageStrings.Q4 = value; }

        public string Quarter { get => _languageStrings.Quarter; set => _languageStrings.Quarter = value; }

        public string ShowGroupBox { get => _languageStrings.ShowGroupBox; set => _languageStrings.ShowGroupBox = value; }

        public string Smart { get => _languageStrings.Smart; set => _languageStrings.Smart = value; }

        public string SolidFill { get => _languageStrings.SolidFill; set => _languageStrings.SolidFill = value; }

        public string SortAscending { get => _languageStrings.SortAscending; set => _languageStrings.SortAscending = value; }

        public string SortBySummaryCount { get => _languageStrings.SortBySummaryCount; set => _languageStrings.SortBySummaryCount = value; }

        public string SortDescending { get => _languageStrings.SortDescending; set => _languageStrings.SortDescending = value; }

        public string ThreeColorsRange { get => _languageStrings.ThreeColorsRange; set => _languageStrings.ThreeColorsRange = value; }

        public string ThreeWeeksAgo { get => _languageStrings.ThreeWeeksAgo; set => _languageStrings.ThreeWeeksAgo = value; }

        public string Today { get => _languageStrings.Today; set => _languageStrings.Today = value; }

        public string Tomorrow { get => _languageStrings.Tomorrow; set => _languageStrings.Tomorrow = value; }

        public string TwoColorsRange { get => _languageStrings.TwoColorsRange; set => _languageStrings.TwoColorsRange = value; }

        public string TwoWeeksAgo { get => _languageStrings.TwoWeeksAgo; set => _languageStrings.TwoWeeksAgo = value; }

        public string Ungroup { get => _languageStrings.Ungroup; set => _languageStrings.Ungroup = value; }

        public string Unknown { get => _languageStrings.Unknown; set => _languageStrings.Unknown = value; }

        public string XXXItems { get => _languageStrings.XXXItems; set => _languageStrings.XXXItems = value; }

        public string Year { get => _languageStrings.Year; set => _languageStrings.Year = value; }

        public string YearGroupText { get => _languageStrings.YearGroupText; set => _languageStrings.YearGroupText = value; }

        public string Yesterday { get => _languageStrings.Today; set => _languageStrings.Today = value; }

        #endregion
    }
}
