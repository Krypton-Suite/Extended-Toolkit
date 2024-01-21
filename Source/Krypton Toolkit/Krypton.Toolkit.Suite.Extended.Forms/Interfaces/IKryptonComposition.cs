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

namespace Krypton.Toolkit.Suite.Extended.Forms
{
    /// <summary>
    /// Exposes interface for visual form to cooperate with a view for composition.
    /// </summary>
    public interface IKryptonComposition
    {
        /// <summary>
        /// Gets the pixel height of the composition extension into the client area.
        /// </summary>
        int CompHeight { get; }

        /// <summary>
        /// Should painting be performed for the selection glyph.
        /// </summary>
        bool CompVisible { get; set; }

        /// <summary>
        /// Gets and sets the form that owns the composition.
        /// </summary>
        VisualForm CompOwnerForm { get; set; }

        /// <summary>
        /// Request a repaint and optional layout.
        /// </summary>
        /// <param name="needLayout">Is a layout required.</param>
        void CompNeedPaint(bool needLayout);

        /// <summary>
        /// Gets the handle of the composition element control.
        /// </summary>
        IntPtr CompHandle { get; }
    }
}