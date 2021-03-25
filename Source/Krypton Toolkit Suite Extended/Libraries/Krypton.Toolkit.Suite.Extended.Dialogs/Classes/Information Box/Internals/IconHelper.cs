#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    /// <summary>
    /// Contains utility methods related to icons
    /// </summary>
    internal static class IconHelper
    {
        /// <summary>
        /// Return the <see cref="System.Drawing.Icon"/> associated with the specified <see cref="InformationBoxIcon"/>.
        /// </summary>
        /// <param name="iconType">Type of the icon.</param>
        /// <returns>An icon corresponding to the iconType</returns>
        internal static Icon FromEnum(InformationBoxIcon iconType)
        {
            switch (iconType)
            {
                case InformationBoxIcon.Asterisk:
                case InformationBoxIcon.Information:
                    return Properties.Resources.info;

                case InformationBoxIcon.Error:
                case InformationBoxIcon.Hand:
                case InformationBoxIcon.Stop:
                    return Properties.Resources.error;

                case InformationBoxIcon.Exclamation:
                case InformationBoxIcon.Warning:
                    return Properties.Resources.warning;

                case InformationBoxIcon.Question:
                    return Properties.Resources.question;

                case InformationBoxIcon.Success:
                    return Properties.Resources.good;

                case InformationBoxIcon.Fax:
                    return Properties.Resources.fax;

                case InformationBoxIcon.Gamepad:
                    return Properties.Resources.gamepad;

                case InformationBoxIcon.Joystick:
                    return Properties.Resources.joystick;

                case InformationBoxIcon.Keys:
                    return Properties.Resources.keys;

                case InformationBoxIcon.Locker:
                    return Properties.Resources.locker;

                case InformationBoxIcon.Phone:
                    return Properties.Resources.phone;

                case InformationBoxIcon.Printer:
                    return Properties.Resources.printer;

                case InformationBoxIcon.Scanner:
                    return Properties.Resources.scanner;

                case InformationBoxIcon.Speakers:
                    return Properties.Resources.speakers;

                case InformationBoxIcon.None:
                default:
                    return null;
            }
        }

        /// <summary>
        /// Gets the category of the icon.
        /// </summary>
        /// <param name="iconType">Type of the icon.</param>
        /// <returns>A message category corresponding to the iconType</returns>
        internal static InformationBoxMessageCategory GetCategory(InformationBoxIcon iconType)
        {
            switch (iconType)
            {
                case InformationBoxIcon.Asterisk:
                case InformationBoxIcon.Information:
                    return InformationBoxMessageCategory.Asterisk;

                case InformationBoxIcon.Error:
                case InformationBoxIcon.Hand:
                case InformationBoxIcon.Stop:
                    return InformationBoxMessageCategory.Hand;

                case InformationBoxIcon.Exclamation:
                case InformationBoxIcon.Warning:
                    return InformationBoxMessageCategory.Exclamation;

                case InformationBoxIcon.Question:
                    return InformationBoxMessageCategory.Question;

                default:
                    return InformationBoxMessageCategory.Other;
            }
        }
    }
}