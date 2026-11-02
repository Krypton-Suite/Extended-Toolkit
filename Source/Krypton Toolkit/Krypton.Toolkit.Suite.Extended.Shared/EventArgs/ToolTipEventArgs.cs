#region MIT License
/*
 *
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

namespace Krypton.Toolkit.Suite.Extended.Shared;

/// <summary>Details for a tooltip related event.</summary>
public class ToolTipEventArgs : EventArgs
{
    #region Public

    /// <summary>
    /// Gets the view element that is related to the tooltip.
    /// </summary>
    public ViewBase? Target { get; }

    /// <summary>
    /// Gets the screen point of the mouse where tooltip is required.
    /// </summary>
    public Point ControlMousePosition { get; }

    #endregion

    #region Identity

    /// <summary>
    /// Initialize a new instance of the ToolTipEventArgs class.
    /// </summary>
    /// <param name="target">Reference to view element that requires tooltip.</param>
    /// <param name="controlMousePosition">Screen location of mouse when tooltip was required.</param>
    public ToolTipEventArgs(ViewBase? target, Point controlMousePosition)
    {
        //Debug.Assert(target != null);

        // Remember parameter details
        Target = target;
        ControlMousePosition = controlMousePosition;
    }

    #endregion
}