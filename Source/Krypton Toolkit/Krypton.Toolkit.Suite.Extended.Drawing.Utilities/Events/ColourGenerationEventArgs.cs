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

namespace Krypton.Toolkit.Suite.Extended.Drawing.Utilities;

public class ColourGenerationEventArgs : EventArgs
{
    #region Variables
    private Color _colour;

    private byte _alphaValue, _redValue, _greenValue, _blueValue;
    #endregion

    #region Properties
    /// <summary>Gets or sets the colour.</summary>
    /// <value>The colour.</value>
    public Color Colour { get => _colour; set => _colour = value; }
    #endregion

    #region Constructors
    /// <summary>Initializes a new instance of the <see cref="ColourGenerationEventArgs" /> class.</summary>
    /// <param name="alphaValue">The alpha value.</param>
    /// <param name="redValue">The red value.</param>
    /// <param name="greenValue">The green value.</param>
    /// <param name="blueValue">The blue value.</param>
    public ColourGenerationEventArgs(byte alphaValue, byte redValue, byte greenValue, byte blueValue)
    {
        _alphaValue = alphaValue;

        _redValue = redValue;

        _greenValue = greenValue;

        _blueValue = blueValue;

        SetColour(alphaValue, redValue, greenValue, blueValue);
    }
    #endregion

    /// <summary>Sets the colour.</summary>
    /// <param name="alphaValue">The alpha value.</param>
    /// <param name="redValue">The red value.</param>
    /// <param name="greenValue">The green value.</param>
    /// <param name="blueValue">The blue value.</param>
    public void SetColour(byte alphaValue, byte redValue, byte greenValue, byte blueValue) => Colour = Color.FromArgb(alphaValue, redValue, greenValue, blueValue);

    /// <summary>Sets the colour.</summary>
    /// <param name="colour">The colour.</param>
    public void SetColour(Color colour) => Colour = colour;

    /// <summary>Gets the colour.</summary>
    /// <returns>
    ///   <br />
    /// </returns>
    public Color GetColour() => Colour;
}