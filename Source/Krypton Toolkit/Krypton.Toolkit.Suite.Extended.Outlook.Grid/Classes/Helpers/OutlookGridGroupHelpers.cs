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
    /// <summary>
    /// Class containing functions for the IOutlookGridGroups
    /// </summary>
    public class OutlookGridGroupHelpers
    {
        /// <summary>
        /// Gets the title for a specific datetime
        /// </summary>
        /// <param name="date">The DateTime </param>
        /// <returns>The text to display</returns>
        public static string? GetDayText(DateTime date)
        {
            switch (GetDateCode(date))
            {
                case "NODATE":
                    return KryptonOutlookGridLanguageManager.GeneralStrings.NoDate;// "Today";
                case "TODAY":
                    return KryptonOutlookGridLanguageManager.GeneralStrings.Today;// "Today";
                case "YESTERDAY":
                    return KryptonOutlookGridLanguageManager.GeneralStrings.Yesterday;//"Yesterday";
                case "TOMORROW":
                    return KryptonOutlookGridLanguageManager.GeneralStrings.Tomorrow;//"Tomorrow";
                case "Monday":
                    return KryptonOutlookGridLanguageManager.GeneralStrings.Monday;
                case "Tuesday":
                    return KryptonOutlookGridLanguageManager.GeneralStrings.Tuesday;
                case "Wednesday":
                    return KryptonOutlookGridLanguageManager.GeneralStrings.Wednesday;
                case "Thursday":
                    return KryptonOutlookGridLanguageManager.GeneralStrings.Thursday;
                case "Friday":
                    return KryptonOutlookGridLanguageManager.GeneralStrings.Friday;
                case "Saturday":
                    return KryptonOutlookGridLanguageManager.GeneralStrings.Saturday;
                case "Sunday":
                    return UppercaseFirst(date.ToString("dddd"));
                case "NEXTWEEK":
                    return KryptonOutlookGridLanguageManager.GeneralStrings.NextWeek;//"Next Week";
                case "INTWOWEEKS": //dans le deux semaines a venir
                    return KryptonOutlookGridLanguageManager.GeneralStrings.InTwoWeeks;//"In two weeks"; //dans le deux semaines a venir
                case "INTHREEWEEKS": //dans les trois semaines à venir
                    return KryptonOutlookGridLanguageManager.GeneralStrings.InThreeWeeks;//"In three weeks"; //dans les trois semaines à venir
                case "LATERDURINGTHISMONTH": //Plus tard au cours de ce mois 
                    return KryptonOutlookGridLanguageManager.GeneralStrings.LaterDuringThisMonth;//"Later during this month"; //Plus tard au cours de ce mois 
                case "NEXTMONTH": //Prochain mois
                    return KryptonOutlookGridLanguageManager.GeneralStrings.NextMonth;//"Next month"; //Prochain mois
                case "AFTERNEXTMONTH":  //Au-delà du prochain mois 
                    return KryptonOutlookGridLanguageManager.GeneralStrings.AfterNextMonth;//"After next month";  //Au-delà du prochain mois 
                case "PREVIOUSWEEK":
                    return KryptonOutlookGridLanguageManager.GeneralStrings.PreviousWeek;//"Previous Week";
                case "TWOWEEKSAGO": //Il y a deux semaines
                    return KryptonOutlookGridLanguageManager.GeneralStrings.TwoWeeksAgo;//"Two weeks ago"; //Il y a deux semaines
                case "THREEWEEKSAGO": //Il y a trois semaines
                    return KryptonOutlookGridLanguageManager.GeneralStrings.ThreeWeeksAgo;//"Three weeks ago"; //Il y a deux semaines
                case "EARLIERDURINGTHISMONTH": //Plus tôt durant ce mois
                    return KryptonOutlookGridLanguageManager.GeneralStrings.EarlierDuringThisMonth;//"Earlier during this month";  //Plus tot au cours de ce mois
                case "PREVIOUSMONTH": //Mois précédent
                    return KryptonOutlookGridLanguageManager.GeneralStrings.PreviousMonth;//"Previous Month";  //Mois dernier
                case "BEFOREPREVIOUSMONTH":  //Mois dernier // no longer exist
                    return KryptonOutlookGridLanguageManager.GeneralStrings.BeforePreviousMonth;//"Before Previous Month";   //Avant le mois dernier
                case "EARLIERTHISYEAR":  //Mois dernier // no longer exist
                    return KryptonOutlookGridLanguageManager.GeneralStrings.EarlierDuringThisYear;//"Before Previous Month";   //Avant le mois dernier
                case "PREVIOUSYEAR":  //Mois dernier // no longer exist
                    return KryptonOutlookGridLanguageManager.GeneralStrings.PreviousYear;//"Before Previous Month";   //Avant le mois dernier
                case "OLDER":  //Mois dernier // no longer exist
                    return KryptonOutlookGridLanguageManager.GeneralStrings.Older;//"Before Previous Month";   //Avant le mois dernier

                default:
                    return date.Date.ToShortDateString();
            }
        }

        /// <summary>
        /// Gets the code according to a datetime
        /// </summary>
        /// <param name="date">The DateTime to analyze.</param>
        /// <returns>The associated code.</returns>
        public static string GetDateCode(DateTime date)
        {
            if (date.Date == DateTime.MinValue)//Today
            {
                return "NODATE";
            }
            else if (date.Date == DateTime.Now.Date)//Today
            {
                return "TODAY";
            }
            else if (date.Date == DateTime.Now.AddDays(-1).Date)
            {
                return "YESTERDAY";
            }
            else if (date.Date == DateTime.Now.AddDays(1).Date)
            {
                return "TOMORROW";
            }
            else if (date.Date >= GetFirstDayOfWeek(DateTime.Now) && date.Date <= GetLastDayOfWeek(DateTime.Now))
            {
                return date.Date.DayOfWeek.ToString();//"DAYOFWEEK";
            }
            else if (date.Date > GetLastDayOfWeek(DateTime.Now) && date.Date <= GetLastDayOfWeek(DateTime.Now).AddDays(6))
            {
                return "NEXTWEEK";
            }
            else if (date.Date > GetLastDayOfWeek(DateTime.Now).AddDays(6) && date.Date <= GetLastDayOfWeek(DateTime.Now).AddDays(12))
            {
                return "INTWOWEEKS"; //dans les deux semaines a venir
            }
            else if (date.Date > GetLastDayOfWeek(DateTime.Now).AddDays(12) && date.Date <= GetLastDayOfWeek(DateTime.Now).AddDays(18))
            {
                return "INTHREEWEEKS"; //dans les trois semaines à venir
            }
            else if (date.Date > GetLastDayOfWeek(DateTime.Now).AddDays(18) && date.Date <= new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(-1))//AddDays(DateTime.DaysInMonth(DateTime.Now.Year,DateTime.Now.Month)-1)))
            {
                return "LATERDURINGTHISMONTH"; //Plus tard au cours de ce mois 
            }
            else if (date.Date > GetLastDayOfWeek(DateTime.Now).AddDays(18) && date.Date > new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(-1) && date.Date <= new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(2).AddDays(-1))
            {
                return "NEXTMONTH"; //Prochain mois
            }
            else if (date.Date > GetLastDayOfWeek(DateTime.Now).AddDays(18) && date.Date > new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(2).AddDays(-1))
            {
                return "AFTERNEXTMONTH";  //Au-delà du prochain mois 
            }
            else if (date.Date < GetFirstDayOfWeek(DateTime.Now) && date.Date >= GetFirstDayOfWeek(DateTime.Now).AddDays(-7))
            {
                return "PREVIOUSWEEK";
            }
            else if (date.Date <= GetFirstDayOfWeek(DateTime.Now).AddDays(-7) && date.Date >= GetFirstDayOfWeek(DateTime.Now).AddDays(-14))
            {
                return "TWOWEEKSAGO"; //Il y a deux semaines
            }
            else if (date.Date <= GetFirstDayOfWeek(DateTime.Now).AddDays(-14) && date.Date >= GetFirstDayOfWeek(DateTime.Now).AddDays(-21))
            {
                return "THREEWEEKSAGO"; //Il y a trois semaines
            }
            else if (date.Date <= GetFirstDayOfWeek(DateTime.Now).AddDays(-21) && date.Date >= new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1))
            {
                return "EARLIERDURINGTHISMONTH"; //Plus tôt durant ce mois
            }
            else if (date.Date <= GetFirstDayOfWeek(DateTime.Now).AddDays(-21) && date.Date >= new DateTime(DateTime.Now.Year, DateTime.Now.AddMonths(-1).Month, 1) && date.Date <= new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddDays(-1))
            {
                return "PREVIOUSMONTH"; //Mois précédent
            }
            //On simplifie les tests, il n'y a pas de raison de tout tester
            else if (date.Date >= new DateTime(DateTime.Now.Year, 1, 1))
            {
                return "EARLIERTHISYEAR";  //Plus tôt cet année
            }
            else if (date.Date >= new DateTime(DateTime.Now.Year - 1, 1, 1) && date.Date <= new DateTime(DateTime.Now.Year, 1, 1).AddDays(-1))
            {
                return "PREVIOUSYEAR";  //L'année dernière
            }
            else if (date.Date <= new DateTime(DateTime.Now.Year - 1, 1, 1).AddDays(-1))
            {
                return "OLDER";  //Older
            }
            else
            {
                return date.Date.ToShortDateString();
            }
        }

        /// <summary>Gets the date code numeric.</summary>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        public static int GetDateCodeNumeric(DateTime date)
        {
            switch (GetDateCode(date))
            {
                case "NODATE":
                    return int.MaxValue;
                case "AFTERNEXTMONTH":  //Au-delà du prochain mois 
                    return 14;
                case "NEXTMONTH": //Prochain mois
                    return 13;
                case "LATERDURINGTHISMONTH": //Plus tard au cours de ce mois 
                    return 12;
                case "INTHREEWEEKS": //dans les trois semaines à venir
                    return 11;
                case "INTWOWEEKS": //dans les deux semaines a venir
                    return 10;
                case "NEXTWEEK":
                    return 9;
                case "Sunday":
                    return 8;
                case "Saturday":
                    return 7;
                case "Friday":
                    return 6;
                case "Thursday":
                    return 5;
                case "Wednesday":
                    return 4;
                case "Tuesday":
                    return 3;
                case "Monday":
                    return 2;
                case "TOMORROW":
                    return 1;
                case "TODAY":
                    return 0;
                case "YESTERDAY":
                    return -1;
                case "PREVIOUSWEEK":
                    return -2;
                case "TWOWEEKSAGO": //Il y a deux semaines
                    return -3;
                case "THREEWEEKSAGO": //Il y a trois semaines
                    return -4;
                case "EARLIERDURINGTHISMONTH": //Plus tôt durant ce mois
                    return -5;
                case "PREVIOUSMONTH": //Mois précédent
                    return -6;
                case "EARLIERTHISYEAR":  //Plus tôt cet année
                    return -7;
                case "PREVIOUSYEAR":  //L'année dernière
                    return -8;
                case "OLDER":  //Older
                    return -9;
                //case date.Date.ToShortDateString():
                default:
                    return int.MinValue;
            }
        }

        /// <summary>
        /// Uppercase the first letter of the string
        /// </summary>
        /// <param name="s">The string.</param>
        /// <returns>The tring with the first letter uppercased.</returns>
        private static string? UppercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            char[] a = s.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new(a);
        }

        /// <summary>
        /// Returns the first day of the week that the specified date is in using the current culture.
        /// </summary>
        /// <param name="dayInWeek">The date to analyse</param>
        /// <returns>The first day of week.</returns>
        public static DateTime GetFirstDayOfWeek(DateTime dayInWeek)
        {
            CultureInfo defaultCultureInfo = CultureInfo.CurrentCulture;
            return GetFirstDayOfWeek(dayInWeek, defaultCultureInfo);
        }

        /// <summary>
        /// Returns the last day of the week that the specified date is in using the current culture.
        /// </summary>
        /// <param name="dayInWeek">The date to analyse</param>
        /// <returns>The last day of week.</returns>
        public static DateTime GetLastDayOfWeek(DateTime dayInWeek)
        {
            CultureInfo defaultCultureInfo = CultureInfo.CurrentCulture;
            return GetFirstDayOfWeek(dayInWeek, defaultCultureInfo).AddDays(6);
        }

        /// <summary>
        /// Returns the first day of the week that the specified date is in.
        /// </summary>
        /// <param name="dayInWeek">The date to analyse</param>
        /// <param name="cultureInfo">The CultureInfo</param>
        /// <returns>The first day of week.</returns>
        public static DateTime GetFirstDayOfWeek(DateTime dayInWeek, CultureInfo cultureInfo)
        {
            DayOfWeek firstDay = cultureInfo.DateTimeFormat.FirstDayOfWeek;
            DateTime firstDayInWeek = dayInWeek.Date;
            int difference = (int)dayInWeek.DayOfWeek - (int)firstDay;
            difference = (7 + difference) % 7;
            return dayInWeek.AddDays(-difference).Date;
        }

        /// <summary>
        /// Gets the user-friendly and localized text of quarter
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string GetQuarterAsString(DateTime dateTime)
        {
            switch (GetQuarter(dateTime))
            {
                case 1:
                    return KryptonOutlookGridLanguageManager.GeneralStrings.QuarterOne;
                case 2:
                    return KryptonOutlookGridLanguageManager.GeneralStrings.QuarterTwo;
                case 3:
                    return KryptonOutlookGridLanguageManager.GeneralStrings.QuarterThree;
                case 4:
                    return KryptonOutlookGridLanguageManager.GeneralStrings.QuarterFour;
                default:
                    return "";
            }
        }

        /// <summary>
        /// Gets the quarter according to the month.
        /// </summary>
        /// <param name="dateTime">The date DateTime</param>
        /// <returns>The quarter number.</returns>
        public static int GetQuarter(DateTime dateTime)
        {
            if (dateTime.Month <= 3)
            {
                return 1;
            }

            if (dateTime.Month <= 6)
            {
                return 2;
            }

            if (dateTime.Month <= 9)
            {
                return 3;
            }

            return 4;
        }

        /// <summary>
        /// Returns a fully qualified type name without the version, culture, or token
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string SimpleQualifiedName(Type t)
        {
            return $"{t.FullName}, {t.Assembly.GetName().Name}";
        }
    }
}
