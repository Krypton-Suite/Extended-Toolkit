#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
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
    public interface IToastNotificationUIElements
    {
        /// <summary>Gets the base window.</summary>
        /// <value>The base window.</value>
        public KryptonForm BaseWindow { get; }

        /// <summary>Gets the content panel.</summary>
        /// <value>The content panel.</value>
        public KryptonPanel ContentPanel { get; }

        /// <summary>Gets the button panel.</summary>
        /// <value>The button panel.</value>
        public KryptonPanel ButtonPanel { get; }

        /// <summary>Gets the header label.</summary>
        /// <value>The header label.</value>
        public KryptonLabel HeaderLabel { get; }

        /// <summary>Gets the content label.</summary>
        /// <value>The content label.</value>
        public KryptonWrapLabel ContentLabel { get; }

        /// <summary>Gets the action button.</summary>
        /// <value>The action button.</value>
        public KryptonButton ActionButton { get; }

        /// <summary>Gets the dismiss button.</summary>
        /// <value>The dismiss button.</value>
        public KryptonButton DismissButton { get; }

        /// <summary>Gets the icon box.</summary>
        /// <value>The icon box.</value>
        public PictureBox IconBox { get; }
    }
}