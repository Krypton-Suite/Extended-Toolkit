#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Calendar
{
    /// <summary>
    /// Enumerates the possible modes of the days visualization on the <see cref="KryptonCalendar"/>
    /// </summary>
    public enum CalendarDaysMode
    {
        /// <summary>
        /// A short version of the day is visible without time scale.
        /// </summary>
        Short,

        /// <summary>
        /// The day is fully visible with time scale.
        /// </summary>
        Expanded
    }

    /// <summary>
    /// Possible alignment for <see cref="CalendarItemAlternative"/> images
    /// </summary>
    public enum CalendarItemImageAlign
    {
        /// <summary>
        /// Image is drawn at north of text
        /// </summary>
        North,

        /// <summary>
        /// Image is drawn at south of text
        /// </summary>
        South,

        /// <summary>
        /// Image is drawn at east of text
        /// </summary>
        East,

        /// <summary>
        /// Image is drawn at west of text
        /// </summary>
        West,
    }

    /// <summary>
    /// Enumerates possible timescales for <see cref="KryptonCalendar"/> control
    /// </summary>
    public enum CalendarTimeScale
    {
        /// <summary>
        /// Makes calendar show intervals of 60 minutes
        /// </summary>
        SixtyMinutes = 60,

        /// <summary>
        /// Makes calendar show intervals of 30 minutes
        /// </summary>
        ThirtyMinutes = 30,

        /// <summary>
        /// Makes calendar show intervals of 15 minutes
        /// </summary>
        FifteenMinutes = 15,

        /// <summary>
        /// Makes calendar show intervals of 10 minutes
        /// </summary>
        TenMinutes = 10,

        /// <summary>
        /// Makes calendar show intervals of 6 minutes
        /// </summary>
        SixMinutes = 6,

        /// <summary>
        /// Makes calendar show intervals of 5 minutes
        /// </summary>
        FiveMinutes = 5
    }
}