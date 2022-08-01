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
        /// <summary>Defines a custom button layout. Linked to <see cref="ExtendedMessageBoxCustomButtonOptions"/> values.</summary>
        Custom = 0,
        /// <summary>Defines a 'OK' button only.</summary>
        OK = 5,
        /// <summary>Defines both 'OK' and 'Cancel' buttons.</summary>
        OkCancel = 6,
        /// <summary>Defines 'Abort', 'Retry' and 'Ignore' buttons.</summary>
        AbortRetryIgnore = 7,
        /// <summary>Defines 'Yes', 'No' and 'Cancel' buttons.</summary>
        YesNoCancel = 8,
        /// <summary>Defines both 'Yes' and 'No' buttons.</summary>
        YesNo = 9,
        /// <summary>Defines both 'Retry' and 'Cancel' buttons.</summary>
        RetryCancel = 10,
        /// <summary>Defines 'Cancel', 'Try Again' and 'Continue' buttons.</summary>
        CancelTryContinue = 11
    }

    /// <summary>Specifies an icon for the <see cref="KryptonMessageBoxExtended"/>.</summary>
    public enum ExtendedKryptonMessageBoxIcon
    {
        /// <summary>Specify a custom icon.</summary>
        Custom = 0,
        /// <summary>Specify no icon.</summary>
        None = 1,
        /// <summary>Specify a hand icon.</summary>
        Hand = 2,
        /// <summary>Specify a question icon.</summary>
        Question = 3,
        /// <summary>Specify a exclamation icon.</summary>
        Exclamation = 4,
        /// <summary>Specify a asterisk icon.</summary>
        Asterisk = 5,
        /// <summary>Specify a stop icon.</summary>
        Stop = 6,
        /// <summary>Specify a error icon.</summary>
        Error = 7,
        /// <summary>Specify a warning icon.</summary>
        Warning = 8,
        /// <summary>Specify a information icon.</summary>
        Information = 9,
        /// <summary>Specify a UAC shield icon.</summary>
        Shield = 10,
        /// <summary>Specify a Windows logo icon.</summary>
        WindowsLogo = 11
    }

    /// <summary>Specifies a custom button layout.</summary>
    public enum ExtendedMessageBoxCustomButtonOptions
    {
        /// <summary>Do not use custom buttons, instead default to an 'OK' only button.</summary>
        None = 0,
        /// <summary>Use a one button layout.</summary>
        OneButton = 1,
        /// <summary>Use a two button layout.</summary>
        TwoButtons = 2,
        /// <summary>Use a three button layout.</summary>
        ThreeButtons = 3,
        /// <summary>Use a four button layout.</summary>
        FourButtons = 4
    }

    public enum ExtendedMessageBoxTimeoutAction
    {
        Close = 0,
        ButtonOne = 1,
        ButtonTwo = 2,
        ButtonThree = 3,
        ButtonFour = 4 
    }

    public enum ExtendedMessageBoxTimeoutButton
    {
        FirstButton = 0,
        SECONDBUTTON = 1,
        THIRDBUTTON = 2
    }

    public enum ExtendedMessageBoxDialogResult
    {
        NONE = 0,
        OK = 1,
        CANCEL = 2,
        ABORT = 3,
        RETRY = 4,
        IGNORE = 5,
        YES = 6,
        NO = 7,
        TRYAGAIN = 8,
        CONTINUE = 9
    }
}