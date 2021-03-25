#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    /// <summary>
    /// Contains methods to convert from MessageBox enums to InformationBox enums.
    /// </summary>
    internal static class MessageBoxEnumConverter
    {
        /// <summary>
        /// Parses the specified MessageBoxButtons value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The converted value</returns>
        internal static InformationBoxButtons Parse(MessageBoxButtons value)
        {
            return (InformationBoxButtons)Enum.Parse(typeof(InformationBoxButtons), value.ToString());
        }

        /// <summary>
        /// Parses the specified MessageBoxIcon value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The converted value</returns>
        internal static InformationBoxIcon Parse(MessageBoxIcon value)
        {
            return (InformationBoxIcon)Enum.Parse(typeof(InformationBoxIcon), value.ToString());
        }

        /// <summary>
        /// Parses the specified MessageBoxDefaultButton value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The converted value</returns>
        internal static InformationBoxDefaultButton Parse(MessageBoxDefaultButton value)
        {
            return (InformationBoxDefaultButton)Enum.Parse(typeof(InformationBoxDefaultButton), value.ToString());
        }
    }
}