﻿#region MIT License
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

namespace Krypton.Toolkit.Suite.Extended.Toast
{
    public enum ActionType
    {
        Default = 0,
        Dismiss = 1,
        LaunchProcess = 2,
        Open = 3
    }

    public enum ActionButtonLocation
    {
        Left = 0,
        Right = 1
    }

    public enum DefaultNotificationButton
    {
        /// <summary>Use the 'action' button as the default button.</summary>
        ActionButton = 0,
        /// <summary>Use the 'dismiss' button as the default button.</summary>
        DismissButton = 1,
        /// <summary>Use neither button as the default button.</summary>
        None = 2
    }

    public enum IconType
    {
        /// <summary>Specify no icon.</summary>
        None = 0,
        /// <summary>Specify a hand icon.</summary>
        Hand = 1,
        /// <summary>Specify a question icon.</summary>
        Question = 2,
        /// <summary>Specify a exclamation icon.</summary>
        Exclamation = 3,
        /// <summary>Specify a asterisk icon.</summary>
        Asterisk = 4,
        /// <summary>Specify a stop icon.</summary>
        Stop = 5,
        /// <summary>Specify a error icon.</summary>
        Error = 6,
        /// <summary>Specify a warning icon.</summary>
        Warning = 7,
        /// <summary>Specify a information icon.</summary>
        Information = 8,
        /// <summary>Specify a UAC shield icon.</summary>
        Shield = 9,
        /// <summary>Specify a Windows logo icon.</summary>
        WindowsLogo = 10,
        /// <summary>Use a custom icon.</summary>
        Custom = 11,
        /// <summary>Use a Ok icon.</summary>
        Ok = 12
    }

    public enum RightToLeftSupport
    {
        Inherit = 0,
        LeftToRight = 1,
        RightToLeft = 2
    }

    public enum ToastNotificationSystemSounds
    {
        Asterisk = 0,
        Beep = 1,
        Exclamation = 2,
        Hand = 3,
        Question = 4,
        Custom = 5,
        None = 6
    }

    public enum ToastNotificationContentAreaType
    {
        Label = 0,
        WrappedLabel = 1,
        MultiLinedTextBox = 2,
        RichTextBox = 3
    }

    public enum KryptonButtonBuiltInDisplayString
    {
        Abort = 0,
        Apply = 1,
        Cancel = 2,
        Collapse = 3,
        Continue = 4,
        Close = 5,
        Custom = 6,
        Yes = 7,
        No = 8,
        Ok = 9,
        Retry = 10,
        Ignore = 11,
        Help = 12,
        TryAgain = 13,
        Expand = 14,
        Today = 15,
        Back = 16,
        Exit = 17,
        Finish = 18,
        Next = 19,
        Previous = 20
    }
}