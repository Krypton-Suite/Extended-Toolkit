#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Drawing;
using System.Globalization;

namespace Krypton.Toolkit.Suite.Extended.Calendar
{
    /// <summary>
    /// Provides the colour information to the graphical elements.
    /// </summary>
    public class CalendarColourTable
    {
        #region Static Methods        
        /// <summary>
        /// Returns the result of combining the specified colours
        /// </summary>
        /// <param name="colour1">First colour to combine</param>
        /// <param name="colour2">Second colour to combine</param>
        /// <returns>Average of both colours</returns>
        public static Color Combine(Color colour1, Color colour2)
        {
            return Color.FromArgb((colour1.R + colour2.R) / 2, (colour1.G + colour2.G) / 2, (colour1.B + colour2.B) / 2);
        }

        /// <summary>
        /// Converts the hex formatted colour to a <see cref="Color"/>
        /// </summary>
        /// <param name="hexadecimal"></param>
        /// <returns></returns>
        public static Color FromHex(string hexadecimal)
        {
            if (hexadecimal.StartsWith("#"))
            {
                hexadecimal = hexadecimal.Substring(1);
            }

            if (hexadecimal.Length < 3 || hexadecimal.Length > 6)
            {
                throw new Exception("Hexadecimal value not valid!");
            }

            return Color.FromArgb(int.Parse(hexadecimal.Substring(0, 2), NumberStyles.HexNumber), int.Parse(hexadecimal.Substring(2, 2), NumberStyles.HexNumber), int.Parse(hexadecimal.Substring(4, 2), NumberStyles.HexNumber));
        }
        #endregion

        #region Colours

        /// <summary>
        /// Background color of calendar
        /// </summary>
        public Color Background = SystemColors.Control;

        /// <summary>
        /// Background color of days in even months
        /// </summary>
        public Color DayBackgroundEven = SystemColors.Control;

        /// <summary>
        /// Background color of days in odd months
        /// </summary>
        public Color DayBackgroundOdd = SystemColors.ControlLight;

        /// <summary>
        /// Background color of selected days
        /// </summary>
        public Color DayBackgroundSelected = SystemColors.Highlight;

        /// <summary>
        /// Border of 
        /// </summary>
        public Color DayBorder = SystemColors.ControlDark;

        /// <summary>
        /// Background color of day headers.
        /// </summary>
        public Color DayHeaderBackground = Combine(SystemColors.ControlDark, SystemColors.Control);

        /// <summary>
        /// Color of text of day headers
        /// </summary>
        public Color DayHeaderText = SystemColors.GrayText;

        /// <summary>
        /// Color of secondary text in headers
        /// </summary>
        public Color DayHeaderSecondaryText = SystemColors.GrayText;

        /// <summary>
        /// Color of border of the top part of the days
        /// </summary>
        /// <remarks>
        /// The DayTop is the zone of the calendar where items that lasts all or more are placed.
        /// </remarks>
        public Color DayTopBorder = SystemColors.ControlDark;

        /// <summary>
        /// Color of border of the top parth of the days when selected
        /// </summary>
        /// <remarks>
        /// The DayTop is the zone of the calendar where items that lasts all or more are placed.
        /// </remarks>
        public Color DayTopSelectedBorder = SystemColors.ControlDark;

        /// <summary>
        /// Background color of day tops.
        /// </summary>
        /// <remarks>
        /// The DayTop is the zone of the calendar where items that lasts all or more are placed.
        /// </remarks>
        public Color DayTopBackground = SystemColors.ControlLight;

        /// <summary>
        /// Background color of selected day tops.
        /// </summary>
        /// <remarks>
        /// The DayTop is the zone of the calendar where items that lasts all or more are placed.
        /// </remarks>
        public Color DayTopSelectedBackground = SystemColors.Highlight;

        /// <summary>
        /// Color of items borders
        /// </summary>
        public Color ItemBorder = SystemColors.ControlText;

        /// <summary>
        /// Background color of items
        /// </summary>
        public Color ItemBackground = SystemColors.Window;

        /// <summary>
        /// Forecolor of items
        /// </summary>
        public Color ItemText = SystemColors.WindowText;

        /// <summary>
        /// Color of secondary text on items (Dates and times)
        /// </summary>
        public Color ItemSecondaryText = SystemColors.GrayText;

        /// <summary>
        /// Color of items shadow
        /// </summary>
        public Color ItemShadow = Color.FromArgb(50, Color.Black);

        /// <summary>
        /// Color of items selected border
        /// </summary>
        public Color ItemSelectedBorder = SystemColors.Highlight;

        /// <summary>
        /// Background color of selected items
        /// </summary>
        public Color ItemSelectedBackground = Combine(SystemColors.Highlight, SystemColors.HighlightText);

        /// <summary>
        /// Forecolor of selected items
        /// </summary>
        public Color ItemSelectedText = SystemColors.WindowText;

        /// <summary>
        /// Background color of week headers
        /// </summary>
        public Color WeekHeaderBackground = Combine(SystemColors.ControlDark, SystemColors.Control);

        /// <summary>
        /// Border color of week headers
        /// </summary>
        public Color WeekHeaderBorder = SystemColors.ControlDark;

        /// <summary>
        /// Forecolor of week headers
        /// </summary>
        public Color WeekHeaderText = SystemColors.ControlText;

        /// <summary>
        /// Forecolor of day names
        /// </summary>
        public Color WeekDayName = SystemColors.ControlText;

        /// <summary>
        /// Border color of today day
        /// </summary>
        public Color TodayBorder = Color.Orange;

        /// <summary>
        /// Background color of today's DayTop
        /// </summary>
        public Color TodayTopBackground = Color.Orange;

        /// <summary>
        /// Color of lines in timescale
        /// </summary>
        public Color TimeScaleLine = SystemColors.ControlDark;

        /// <summary>
        /// Color of text representing hours on the timescale
        /// </summary>
        public Color TimeScaleHours = SystemColors.GrayText;

        /// <summary>
        /// Color of text representing minutes on the timescale
        /// </summary>
        public Color TimeScaleMinutes = SystemColors.GrayText;

        /// <summary>
        /// Background color of time units
        /// </summary>
        public Color TimeUnitBackground = SystemColors.Control;

        /// <summary>
        /// Background color of highlighted time units
        /// </summary>
        public Color TimeUnitHighlightedBackground = Combine(SystemColors.Control, SystemColors.ControlLightLight);

        /// <summary>
        /// Background color of selected time units
        /// </summary>
        public Color TimeUnitSelectedBackground = SystemColors.Highlight;

        /// <summary>
        /// Color of light border of time units
        /// </summary>
        public Color TimeUnitBorderLight = SystemColors.ControlDark;

        /// <summary>
        /// Color of dark border of time units
        /// </summary>
        public Color TimeUnitBorderDark = SystemColors.ControlDarkDark;

        /// <summary>
        /// Border color of the overflow indicators
        /// </summary>
        public Color DayOverflowBorder = Color.White;

        /// <summary>
        /// Background color of the overflow indicators
        /// </summary>
        public Color DayOverflowBackground = SystemColors.ControlLight;

        /// <summary>
        /// Background color of selected overflow indicators
        /// </summary>
        public Color DayOverflowSelectedBackground = Color.Orange;

        #endregion
    }
}