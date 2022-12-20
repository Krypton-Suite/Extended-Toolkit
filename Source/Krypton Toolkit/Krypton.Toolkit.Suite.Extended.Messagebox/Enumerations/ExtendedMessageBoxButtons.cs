#region MIT License
/*
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

namespace Krypton.Toolkit.Suite.Extended.Messagebox
{
    /// <summary>Specifies the button layout in the <see cref="KryptonMessageBoxExtended"/>.</summary>
    public enum ExtendedMessageBoxButtons
    {
        /// <summary>Defines a custom button layout. Linked to <see cref="ExtendedMessageBoxCustomButtonOptions"/> values.</summary>
        Custom = 13,
        /// <summary>
        ///  Specifies that the message box contains an OK button.
        /// </summary>
        OK = MessageBoxButtons.OK,

        /// <summary>
        ///  Specifies that the message box contains OK and Cancel buttons.
        /// </summary>
        OKCancel = MessageBoxButtons.OKCancel,

        /// <summary>
        ///  Specifies that the message box contains Abort, Retry, and Ignore buttons.
        /// </summary>
        AbortRetryIgnore = MessageBoxButtons.AbortRetryIgnore,

        /// <summary>
        ///  Specifies that the message box contains Yes, No, and Cancel buttons.
        /// </summary>
        YesNoCancel = MessageBoxButtons.YesNoCancel,

        /// <summary>
        ///  Specifies that the message box contains Yes and No buttons.
        /// </summary>
        YesNo = MessageBoxButtons.YesNo,

        /// <summary>
        ///  Specifies that the message box contains Retry and Cancel buttons.
        /// </summary>
        RetryCancel = MessageBoxButtons.RetryCancel,

        /// <summary>
        ///  Specifies that the message box contains Cancel, Try Again, and Continue buttons.
        /// </summary>
#if NET60_OR_GREATER
            CancelTryContinue = MessageBoxButtons.CancelTryContinue
#else
        CancelTryContinue = 0x00000006
#endif 
    }
}