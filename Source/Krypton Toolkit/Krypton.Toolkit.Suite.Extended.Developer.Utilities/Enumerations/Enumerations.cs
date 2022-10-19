#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
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