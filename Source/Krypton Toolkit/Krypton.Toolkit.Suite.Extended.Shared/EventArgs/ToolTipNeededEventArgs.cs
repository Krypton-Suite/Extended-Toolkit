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

namespace Krypton.Toolkit.Suite.Extended.Shared
{
    /// <summary>
    /// Event arguments for the ToolTipNeeded event raised by a KryptonComboBox when it
    /// needs to render a tooltip.
    /// </summary>
    public class ToolTipNeededEventArgs : EventArgs
    {
        #region Public

        /// <summary>
        /// The title of the tooltip.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// The body of the tooltip.
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// The icon of the tooltip.
        /// </summary>
        public Image Icon { get; set; }

        /// <summary>
        /// The index of the item of the <see cref="KryptonComboBox"/> for which a tooltip is
        /// being requested.
        /// </summary>
        public int Index
        {
            get;
            private set;
        }

        /// <summary>
        /// The item of the <see cref="KryptonComboBox"/> for which a tooltip is being
        /// requested.
        /// </summary>
        public object Item
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets whether the instance is empty.
        /// </summary>
        public bool IsEmpty => string.IsNullOrEmpty(Title) && string.IsNullOrEmpty(Body) && Icon == null;

        #endregion

        #region Identity

        /// <summary>
        /// Initializes a new instance of the ToolTipNeededEventArgs class.
        /// </summary>
        /// <param name="index">
        /// The index of the item for which a tooltip is being requested.
        /// </param>
        /// <param name="item">
        /// The item for which a tooltip is being requested.
        /// </param>
        public ToolTipNeededEventArgs(int index, object item)
        {
            Index = index;
            Item = item;
        }

        #endregion

    }
}