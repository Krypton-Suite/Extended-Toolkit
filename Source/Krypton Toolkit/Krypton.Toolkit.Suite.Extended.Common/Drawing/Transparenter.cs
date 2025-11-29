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

namespace Krypton.Toolkit.Suite.Extended.Common;

/// <summary>
/// Code from: https://github.com/aalitor/AltoControls/blob/on-development/AltoControls/Helpers/Transparenter.cs
/// </summary>
public class Transparenter
{
    /// <summary>
    /// Makes the control transparent.
    /// </summary>
    /// <param name="control">The control.</param>
    /// <param name="g">The g.</param>
    public static void MakeTransparent(Control control, Graphics g)
    {
        var parent = control.Parent;
        if (parent == null)
        {
            return;
        }

        var bounds = control.Bounds;
        var siblings = parent.Controls;
        int index = siblings.IndexOf(control);
        Bitmap? behind = null;
        for (int i = siblings.Count - 1; i > index; i--)
        {
            var c = siblings[i];
            if (!c.Bounds.IntersectsWith(bounds))
            {
                continue;
            }

            if (behind == null)
            {
                behind = new Bitmap(control.Parent.ClientSize.Width, control.Parent.ClientSize.Height);
            }

            c.DrawToBitmap(behind, c.Bounds);
        }
        if (behind == null)
        {
            return;
        }

        g.DrawImage(behind, control.ClientRectangle, bounds, GraphicsUnit.Pixel);
        behind.Dispose();
    }
}