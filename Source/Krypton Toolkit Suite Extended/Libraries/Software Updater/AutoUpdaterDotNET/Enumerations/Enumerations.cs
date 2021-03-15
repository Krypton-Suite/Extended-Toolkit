#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.Xml.Serialization;

namespace Krypton.Toolkit.Suite.Extended.Software.Updater.AutoUpdaterDotNET
{
    /// <summary>
    ///     Enum representing the remind later time span.
    /// </summary>
    public enum RemindLaterFormat
    {
        /// <summary>
        ///     Represents the time span in minutes.
        /// </summary>
        MINUTES,

        /// <summary>
        ///     Represents the time span in hours.
        /// </summary>
        HOURS,

        /// <summary>
        ///     Represents the time span in days.
        /// </summary>
        DAYS
    }

    /// <summary>
    ///     Enum representing the effect of Mandatory flag.
    /// </summary>
    public enum Mode
    {
        /// <summary>
        /// In this mode, it ignores Remind Later and Skip values set previously and hide both buttons.
        /// </summary>
        [XmlEnum("0")] NORMAL,

        /// <summary>
        /// In this mode, it won't show close button in addition to Normal mode behaviour.
        /// </summary>
        [XmlEnum("1")] FORCED,

        /// <summary>
        /// In this mode, it will start downloading and applying update without showing standard update dialog in addition to Forced mode behaviour.
        /// </summary>
        [XmlEnum("2")] FORCEDDOWNLOAD
    }
}