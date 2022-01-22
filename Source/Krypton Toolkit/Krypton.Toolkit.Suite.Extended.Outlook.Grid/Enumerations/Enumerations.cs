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
    /// Conditional Formatting type
    /// </summary>
    public enum EnumConditionalFormatType
    {
        /// <summary>
        /// Two scale color
        /// </summary>
        TwoColoursRange,
        /// <summary>
        /// Three scale color
        /// </summary>
        ThreeColoursRange,
        /// <summary>
        /// Bar
        /// </summary>
        Bar
    }

    /// <summary>
    /// Grid filling mode
    /// </summary>
    public enum FillMode
    {
        /// <summary>
        /// The grid contains only groups (faster).
        /// </summary>
        GroupsOnly,
        /// <summary>
        /// The grid contains groups and nodes (no choice, choose this one !)
        /// </summary>
        GroupsAndNodes
    }

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
}