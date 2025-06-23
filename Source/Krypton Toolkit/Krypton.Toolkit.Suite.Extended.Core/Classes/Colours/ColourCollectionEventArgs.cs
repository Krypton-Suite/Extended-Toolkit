#region MIT License
/*
 *
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

namespace Krypton.Toolkit.Suite.Extended.Core;

/// <summary>Provides data for the <see cref="ColourCollection.CollectionChanged"/> event of a <see cref="ColourCollection"/> instance.</summary>
public class ColourCollectionEventArgs : EventArgs
{
    #region Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="ColourCollectionEventArgs"/> class for the specified color.
    /// </summary>
    /// <param name="index">The color index that the event is responding to.</param>
    /// <param name="colour">The %Color% that the event is responding to.</param>
    public ColourCollectionEventArgs(int index, Color colour)
    {
        this.Index = index;
        this.Colour = colour;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ColourCollectionEventArgs"/> class.
    /// </summary>
    protected ColourCollectionEventArgs()
    { }

    #endregion

    #region Properties

    /// <summary>
    /// Gets the color that raised the event.
    /// </summary>
    /// <value>The color that raised the event.</value>
    public Color Colour { get; protected set; }

    /// <summary>
    /// Gets the color index that raised the event.
    /// </summary>
    /// <value>The color index that raised the event.</value>
    public int Index { get; protected set; }

    #endregion
}