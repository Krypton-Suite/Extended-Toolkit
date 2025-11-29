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

namespace Krypton.Toolkit.Suite.Extended.Controls;

/// <summary>
/// An abstraction of <see cref="System.Drawing.SolidBrush"/>.
/// </summary>
/// <remarks>Exists in order to make test assertions on usage of
/// <see cref="System.Drawing.SolidBrush"/>.</remarks>
public sealed class SolidBrushExtended : ISolidBrush
{
    private readonly System.Drawing.SolidBrush native;

    /// <summary>
    /// Instantiates a new <see cref="SolidBrushExtended"/> with the specified
    /// <paramref name="color"/>.
    /// </summary>
    /// <param name="color">The desired value of
    /// <see cref="Color"/>.</param>
    public SolidBrushExtended(Color color)
    {
        native = new System.Drawing.SolidBrush(color);
    }

    /// <summary>
    /// Finalizes the <see cref="SolidBrushExtended"/>.
    /// </summary>
    ~SolidBrushExtended()
    {
        Dispose(false);
        System.Diagnostics.Debug.Fail($"{GetType().FullName} was not disposed!");
    }

    /// <summary>
    /// The <see cref="System.Drawing.Color"/> of the
    /// <see cref="SolidBrushExtended"/>.
    /// </summary>
    public Color Color => native.Color;

    /// <summary>
    /// The <see cref="System.Drawing.SolidBrush"/> of which the
    /// <see cref="SolidBrushExtended"/> is an abstraction.
    /// </summary>
    System.Drawing.SolidBrush ISolidBrush.Native => native;

    /// <summary>
    /// Disposes resources acquired by the <see cref="SolidBrushExtended"/>.
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (disposing)
        {
            native.Dispose();
        }
    }
}