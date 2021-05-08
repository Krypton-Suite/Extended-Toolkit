#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Developer.Utilities
{
    /// <summary>Specifies the button layout in the <see cref="KryptonMessageBoxExtended"/>.</summary>
    public enum ExtendedMessageBoxButtons
    {
        /// <summary>Defines a custom button layout. Linked to <see cref="ExtendedMessageBoxCustomButtonOptions"/> values.</summary>
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

    /// <summary>Specifies an icon for the <see cref="KryptonMessageBoxExtended"/>.</summary>
    public enum ExtendedMessageBoxIcon
    {
        /// <summary>Specify a custom icon.</summary>
        CUSTOM = 0,
        /// <summary>Specify no icon.</summary>
        NONE = 1,
        /// <summary>Specify a hand icon.</summary>
        HAND = 2,
        /// <summary>Specify a question icon.</summary>
        QUESTION = 3,
        /// <summary>Specify a exclamation icon.</summary>
        EXCLAMATION = 4,
        /// <summary>Specify a asterisk icon.</summary>
        ASTERISK = 5,
        /// <summary>Specify a stop icon.</summary>
        STOP = 6,
        /// <summary>Specify a error icon.</summary>
        ERROR = 7,
        /// <summary>Specify a warning icon.</summary>
        WARNING = 8,
        /// <summary>Specify a information icon.</summary>
        INFORMATION = 9
    }

    /// <summary>Specifies a custom button layout.</summary>
    public enum ExtendedMessageBoxCustomButtonOptions
    {
        /// <summary>Do not use custom buttons, instead default to an 'OK' only button.</summary>
        NONE = 0,
        /// <summary>Use a one button layout.</summary>
        ONEBUTTON = 1,
        /// <summary>Use a two button layout.</summary>
        TWOBUTTONS = 2,
        /// <summary>Use a three button layout.</summary>
        THREEBUTTONS = 3
    }

    public enum ExtendedMessageBoxTimeoutAction
    {
        BUTTONONE = 0,
        BUTTONTWO = 1,
        BUTTONTHREE = 2,
        CLOSE = 3
    }

    public enum ExtendedMessageBoxTimeoutButton
    {
        FIRSTBUTTON = 0,
        SECONDBUTTON = 1,
        THIRDBUTTON = 2
    }
}