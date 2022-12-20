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

namespace Krypton.Toolkit.Suite.Extended.Messagebox;

/// <summary>Specifies an icon for the <see cref="KryptonMessageBoxExtended"/>.</summary>
public enum ExtendedKryptonMessageBoxIcon
{
    /// <summary>Specify a custom icon.</summary>
    Custom = 0,
    /// <summary>Specify no icon.</summary>
    None = 1,
    /// <summary>Specify a hand icon.</summary>
    Hand = 2,
    /// <summary>Specify the system hand icon.</summary>
    SystemHand = MessageBoxIcon.Hand,
    /// <summary>Specify a question icon.</summary>
    Question = 3,
    /// <summary>Specify the system question icon.</summary>
    SystemQuestion = MessageBoxIcon.Question,
    /// <summary>Specify a exclamation icon.</summary>
    Exclamation = 4,
    /// <summary>Specify the system exclamation icon.</summary>
    SystemExclamation = MessageBoxIcon.Exclamation,
    /// <summary>Specify a asterisk icon.</summary>
    Asterisk = 5,
    /// <summary>Specify the system asterisk icon.</summary>
    SystemAsterisk = MessageBoxIcon.Asterisk,
    /// <summary>Specify a stop icon.</summary>
    Stop = 6,
    /// <summary>Specify the system stop icon.</summary>
    SystemStop = MessageBoxIcon.Stop,
    /// <summary>Specify a error icon.</summary>
    Error = 7,
    /// <summary>Specify the system error icon.</summary>
    SystemError = MessageBoxIcon.Error,
    /// <summary>Specify a warning icon.</summary>
    Warning = 8,
    /// <summary>Specify the system warning icon.</summary>
    SystemWarning = MessageBoxIcon.Warning,
    /// <summary>Specify a information icon.</summary>
    Information = 9,
    /// <summary>Specify the system information icon.</summary>
    SystemInformation = MessageBoxIcon.Information,
    /// <summary>Specify a UAC shield icon.</summary>
    Shield = 10,
    /// <summary>Specify a Windows logo icon.</summary>
    WindowsLogo = 11,
    /// <summary>Specify your application icon.</summary>
    Application = 12,
    /// <summary>Specify the default system application icon. See <see cref="SystemIcons.Application"/>.</summary>
    SystemApplication = 13
}