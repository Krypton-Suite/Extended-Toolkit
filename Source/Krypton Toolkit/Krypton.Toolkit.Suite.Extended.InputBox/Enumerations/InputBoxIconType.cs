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
        NONE = 0,
        /// <summary>Specifies a custom icon.</summary>
        CUSTOM = 1,
        /// <summary>Specifies the critical icon.</summary>
        CRITICAL = 2,
        /// <summary>Specifies a hand icon.</summary>
        HAND = 3,
        /// <summary>Specifies a information icon.</summary>
        INFORMATION = 4,
        /// <summary>Specifies a ok icon.</summary>
        OK = 5,
        /// <summary>Specifies a question icon.</summary>
        QUESTION = 6,
        /// <summary>Specifies a stop icon.</summary>
        STOP = 7,
        /// <summary>Specifies a error icon.</summary>
        ERROR = 8,
        /// <summary>Specifies a warning icon.</summary>
        EXCLAMATION = 9
    }
}