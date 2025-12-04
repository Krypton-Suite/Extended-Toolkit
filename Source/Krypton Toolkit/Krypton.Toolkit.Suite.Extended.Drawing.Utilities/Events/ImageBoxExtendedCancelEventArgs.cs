#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
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

/// <summary>
/// Provides data for a cancelable event.
/// </summary>
public class ImageBoxExtendedCancelEventArgs : CancelEventArgs
{
    #region Public Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="ImageBoxExtendedCancelEventArgs"/> class.
    /// </summary>
    /// <param name="location">The location of the action being performed.</param>
    public ImageBoxExtendedCancelEventArgs(Point location)
        : this()
    {
        this.Location = location;
    }

    #endregion

    #region Protected Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="ImageBoxExtendedCancelEventArgs"/> class.
    /// </summary>
    protected ImageBoxExtendedCancelEventArgs()
    { }

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets or sets the location of the action being performed.
    /// </summary>
    /// <value>The location of the action being performed.</value>
    public Point Location { get; protected set; }

    #endregion
}