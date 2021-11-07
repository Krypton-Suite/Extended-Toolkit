#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Messagebox
{
    /// <summary>Specifies the button layout in the <see cref="KryptonMessageBoxExtended"/>.</summary>
    public enum ExtendedMessageBoxButtons
    {
        /// <summary>Defines a custom button layout. Linked to <see cref="ExtendedMessageBoxCustomButtonVisibility"/> values.</summary>
        CUSTOM = 0,
        /// <summary>Defines a 'OK' button only.</summary>
        OK = 5,
        /// <summary>Defines both 'OK' and 'Cancel' buttons.</summary>
        OKCANCEL = 6,
        /// <summary>Defines 'Abort', 'Retry' and 'Ignore' buttons.</summary>
        ABORTRETRYIGNORE = 7,
        /// <summary>Defines 'Yes', 'No' and 'Cancel' buttons.</summary>
        YESNOCANCEL = 8,
        /// <summary>Defines both 'Yes' and 'No' buttons.</summary>
        YESNO = 9,
        /// <summary>Defines both 'Retry' and 'Cancel' buttons.</summary>
        RETRYCANCEL = 10
    }
}