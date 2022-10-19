﻿#region MIT License
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

namespace Krypton.Toolkit.Suite.Extended.Language.Model
{
    /// <summary>The chosen language for buttons.</summary>
    public enum SelectedLanguage
    {
        /// <summary>The Czech definition.</summary>
        Czech = 0,
        /// <summary>The English definition.</summary>
        English = 1,
        /// <summary>The Français definition.</summary>
        Français = 2,
        /// <summary>The Deutsch definition.</summary>
        Deutsch = 3,
        /// <summary>The Slovakian definition.</summary>
        Slovakian = 4,
        /// <summary>The Español definition.</summary>
        Español = 5,
        /// <summary>A custom language definition.</summary>
        Custom = 6
    }

    /// <summary>The type of buttons.</summary>
    public enum DialogButtonsType
    {
        /// <summary>Ok button only.</summary>
        OK,
        /// <summary>A ok/cancel button.</summary>
        OKCancel,
        /// <summary>A yes/no button.</summary>
        YesNo,
        /// <summary>A yes/no/cancel button.</summary>
        YesNoCancel,
        /// <summary>A retry/cancel button.</summary>
        RetryCancel,
        /// <summary>A abort/retry/ignore button.</summary>
        AbortRetryIgnore
    }

    public enum DialogButtonType
    {
        Abort = 0,
        Cancel = 1,
        Ignore = 2,
        No = 3,
        OK = 4,
        Retry = 5,
        Yes = 6
    }
}