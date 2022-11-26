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

namespace Krypton.Toolkit.Suite.Extended.InputBox
{
    /// <summary>Specifies the input box icon type.</summary>
    public enum InputBoxIconType
    {
        /// <summary>No icon.</summary>
        None = 0,
        /// <summary>Specifies a custom icon.</summary>
        Custom = 1,
        /// <summary>Specifies the critical icon.</summary>
        Critical = 2,
        /// <summary>Specifies a hand icon.</summary>
        Hand = 3,
        /// <summary>Specifies a information icon.</summary>
        Information = 4,
        /// <summary>Specifies a ok icon.</summary>
        Ok = 5,
        /// <summary>Specifies a question icon.</summary>
        Question = 6,
        /// <summary>Specifies a stop icon.</summary>
        Stop = 7,
        /// <summary>Specifies a error icon.</summary>
        Error = 8,
        /// <summary>Specifies a warning icon.</summary>
        Exclamation = 9,
        /// <summary>Specifies the asterisk icon.</summary>
        Asterisk = 10
    }
}