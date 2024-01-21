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

namespace Krypton.Toolkit.Suite.Extended.Calendar
{
    public class CalendarRendererItemBoundsEventArgs : CalendarRendererItemEventArgs
    {
        #region Fields
        private Rectangle _bounds;
        private bool _isFirst;
        private bool _isLast;
        #endregion

        #region Ctor

        /// <summary>
        /// Creates a new Event
        /// </summary>
        /// <param name="original"></param>
        /// <param name="bounds"></param>
        /// <param name="isFirst"></param>
        /// <param name="isLast"></param>
        internal CalendarRendererItemBoundsEventArgs(CalendarRendererItemEventArgs original, Rectangle bounds, bool isFirst, bool isLast) : base(original, original.Item)
        {
            _isFirst = isFirst;
            _isLast = isLast;
            _bounds = bounds;
        }

        #endregion

        #region Props

        /// <summary>
        /// Gets the bounds of the item to be rendered.
        /// </summary>
        /// <remarks>
        /// Items may have more than one bounds due to week segmentation.
        /// </remarks>
        public Rectangle Bounds => _bounds;

        /// <summary>
        /// Gets a value indicating if the bounds are the first of the item.
        /// </summary>
        /// <remarks>
        /// Items may have more than one bounds due to week segmentation.
        /// </remarks>
        public bool IsFirst => _isFirst;

        /// <summary>
        /// Gets a value indicating if the bounds are the last of the item.
        /// </summary>
        /// <remarks>
        /// Items may have more than one bounds due to week segmentation.
        /// </remarks>
        public bool IsLast
        {
            get => _isLast;
            set => _isLast = value;
        }


        #endregion
    }
}