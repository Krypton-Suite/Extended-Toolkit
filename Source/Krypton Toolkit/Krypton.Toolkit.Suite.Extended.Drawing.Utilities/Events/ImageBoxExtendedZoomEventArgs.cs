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

/// <summary>
/// Contains event data for the <see cref="ImageBoxExtended.ZoomChanged"/> event.
/// </summary>
public class ImageBoxExtendedZoomEventArgs : EventArgs
{
    #region Public Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="ImageBoxExtendedZoomEventArgs"/> class.
    /// </summary>
    /// <param name="actions">The zoom operation being performed.</param>
    /// <param name="source">The source of the operation.</param>
    /// <param name="oldZoom">The old zoom level.</param>
    /// <param name="newZoom">The new zoom level.</param>
    public ImageBoxExtendedZoomEventArgs(ImageBoxZoomActions actions, ImageBoxActionSources source, int oldZoom, int newZoom)
        : this()
    {
        this.Actions = actions;
        this.Source = source;
        this.OldZoom = oldZoom;
        this.NewZoom = newZoom;
    }

    #endregion

    #region Protected Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="ImageBoxExtendedZoomEventArgs"/> class.
    /// </summary>
    protected ImageBoxExtendedZoomEventArgs()
    { }

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets or sets the actions that occured.
    /// </summary>
    /// <value>The zoom operation.</value>
    public ImageBoxZoomActions Actions { get; protected set; }

    /// <summary>
    /// Gets or sets the new zoom level.
    /// </summary>
    /// <value>The new zoom level.</value>
    public int NewZoom { get; protected set; }

    /// <summary>
    /// Gets or sets the old zoom level.
    /// </summary>
    /// <value>The old zoom level.</value>
    public int OldZoom { get; protected set; }

    /// <summary>
    /// Gets or sets the source of the operation..
    /// </summary>
    /// <value>The source.</value>
    public ImageBoxActionSources Source { get; protected set; }

    #endregion
}