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

#region Original MIT License

/*
 * Source code for _PasswordTextBox Control_ is Copyright © 2016
 * [Nils Jonsson][mail] and [contributors][contributors].
 *  
 * Permission is hereby granted, free of charge, to any person obtaining a copy of
 * this software and associated documentation files (the “Software”), to deal in the
 * Software without restriction, including without limitation the rights to use,
 * copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the
 * Software, and to permit persons to whom the Software is furnished to do so,
 * subject to the following conditions:
 *  
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *  
 * THE SOFTWARE IS PROVIDED “AS IS,” WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
 * FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
 * COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN
 * AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
 * WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 *  
 * [mail]:         mailto:passwordtextbox@nilsjonsson.com                           "send email to Nils Jonsson"
 * [contributors]: https://github.com/njonsson/PasswordTextBox-Control/contributors "PasswordTextBox Control contributors at GitHub"   
 */

#endregion

namespace Krypton.Toolkit.Suite.Extended.Controls
{
    /// <summary>
    /// An abstraction of <see cref="System.Drawing.Graphics"/>.
    /// </summary>
    /// <remarks>Exists in order to make test assertions on usage of
    /// <see cref="System.Drawing.Graphics"/>.</remarks>
    public interface IGraphics : IDisposable
    {
        /// <summary>
        /// Gets or sets the rendering mode for text associated with the
        /// <see cref="IGraphics"/> object.
        /// </summary>
        TextRenderingHint TextRenderingHint { get; set; }

        /// <summary>
        /// Draws the specified <paramref name="string"/> at the specified
        /// <paramref name="point"/> with the specified
        /// <paramref name="solidBrush"/> and <paramref name="font"/>.
        /// </summary>
        /// <param name="string">The <see cref="string"/> to draw.</param>
        /// <param name="font">A <see cref="Font"/> that determines the
        /// appearance of the <paramref name="string"/>.</param>
        /// <param name="solidBrush">An <see cref="ISolidBrush"/> that
        /// determines the appearance of the <paramref name="string"/>.</param>
        /// <param name="point">A <see cref="PointF"/> that defines the top-left
        /// position of the <paramref name="string"/>.</param>
        void DrawString(string @string,
                        Font font,
                        ISolidBrush solidBrush,
                        PointF point);

        /// <summary>
        /// Fills the interior of the specified <paramref name="rectangle"/>
        /// using the specified <paramref name="solidBrush"/>.
        /// </summary>
        /// <param name="solidBrush">An <see cref="ISolidBrush"/> that
        /// determines the appearance of the
        /// <paramref name="rectangle"/>.</param>
        /// <param name="rectangle">A <see cref="RectangleF"/> describing the
        /// area to be filled.</param>
        void FillRectangle(ISolidBrush solidBrush, RectangleF rectangle);

        /// <summary>
        /// Measures the specified <paramref name="string"/> when drawn with the
        /// specified <paramref name="font"/>.
        /// </summary>
        /// <param name="string">The <see cref="string"/> to measure.</param>
        /// <param name="font">A <see cref="Font"/> that determines the
        /// appearance of the <paramref name="string"/>.</param>
        /// <returns>The measured <see cref="SizeF"/>.</returns>
        /// <exception cref="ArgumentNullException">An argument is
        /// <c>null</c>.</exception>
        SizeF MeasureString(string @string, Font font);
    }
}