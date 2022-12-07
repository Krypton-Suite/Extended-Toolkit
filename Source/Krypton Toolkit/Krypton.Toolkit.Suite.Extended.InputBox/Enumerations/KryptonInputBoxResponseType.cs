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
    /// <summary>The response input type for the <see cref="KryptonInputBoxExtended"/>.</summary>
    public enum KryptonInputBoxResponseType
    {
        /// <summary>No response input.</summary>
        None = 0,
        /// <summary>Use a <see cref="KryptonComboBox"/> as the response input type.</summary>
        ComboBox = 1,
        /// <summary>Use a <see cref="KryptonDateTimePicker"/> as the response input type.</summary>
        DateTimePicker = 2,
        /// <summary>Use a <see cref="KryptonTextBox"/> as the response input type.</summary>
        TextBox = 3,
        /// <summary>Use a <see cref="KryptonMaskedTextBox"/> as the response input type.</summary>
        MaskedTextBox = 4,
        /// <summary>Use a <see cref="KryptonTextBox"/> with the password character facility turned on as the response input type.</summary>
        PasswordBox = 5,
        /// <summary>Use a <see cref="KryptonRichTextBox"/> as the response input type.</summary>
        RichTextBox = 6,
        /// <summary>Use a <see cref="KryptonNumericUpDown"/> as the response input type.</summary>
        NumericUpDown = 7,
        /// <summary>Use a <see cref="KryptonDomainUpDown"/> as the response input type.</summary>
        DomainUpDown = 8,
    }
}