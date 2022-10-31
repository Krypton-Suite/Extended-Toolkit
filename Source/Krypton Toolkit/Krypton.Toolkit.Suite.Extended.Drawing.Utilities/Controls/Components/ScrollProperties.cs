﻿#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Drawing.Utilities
{
    partial class ScrollControl
    {
        #region Nested Types

        /// <summary>
        /// Provides basic properties for the horizontal scroll bar in a <see cref="ScrollControl"/>.
        /// </summary>
        public class HScrollProperties : ScrollProperties
        {
            #region Public Constructors

            /// <summary>
            /// Initializes a new instance of the <see cref="ScrollProperties" /> class.
            /// </summary>
            /// <param name="container">The <see cref="ScrollControl" /> whose scrolling properties this object describes.</param>
            public HScrollProperties(ScrollControl container)
              : base(container)
            { }

            #endregion
        }

        /// <summary>
        /// Encapsulates properties related to scrolling.
        /// </summary>
        public abstract class ScrollProperties
        {
            #region Instance Fields

            private readonly ScrollControl _container;

            #endregion

            #region Protected Constructors

            /// <summary>
            /// Initializes a new instance of the <see cref="ScrollProperties"/> class.
            /// </summary>
            /// <param name="container">The <see cref="ScrollControl"/> whose scrolling properties this object describes.</param>
            protected ScrollProperties(ScrollControl container)
            {
                //System.Windows.Forms.ScrollProperties
                _container = container;
            }

            #endregion

            #region Public Properties

            /// <summary>
            /// Gets or sets whether the scroll bar can be used on the container.
            /// </summary>
            /// <value><c>true</c> if the scroll bar can be used; otherwise, <c>false</c>.</value>
            [DefaultValue(true)]
            public bool Enabled { get; set; }

            /// <summary>
            /// Gets or sets the distance to move a scroll bar in response to a large scroll command.
            /// </summary>
            /// <value>An <see cref="int"/> describing how far, in pixels, to move the scroll bar in response to a large change.</value>
            [DefaultValue(10)]
            public int LargeChange { get; set; }

            /// <summary>
            /// Gets or sets the upper limit of the scrollable range.
            /// </summary>
            /// <value>An <see cref="int"/> representing the maximum range of the scroll bar.</value>
            [DefaultValue(100)]
            public int Maximum { get; set; }

            /// <summary>
            /// Gets or sets the lower limit of the scrollable range.
            /// </summary>
            /// <value>An <see cref="int"/> representing the lower range of the scroll bar.</value>
            [DefaultValue(0)]
            public int Minimum { get; set; }

            /// <summary>
            /// Gets the control to which this scroll information applies.
            /// </summary>
            /// <value>A <see cref="ScrollControl"/>.</value>
            public ScrollControl ParentControl => _container;

            /// <summary>
            /// Gets or sets the distance to move a scroll bar in response to a small scroll command.
            /// </summary>
            /// <value>An <see cref="int"/> representing how far, in pixels, to move the scroll bar.</value>
            [DefaultValue(1)]
            public int SmallChange { get; set; }

            /// <summary>
            /// Gets or sets a numeric value that represents the current position of the scroll bar box.
            /// </summary>
            /// <value>An <see cref="int"/> representing the position of the scroll bar box, in pixels. </value>
            [Bindable(true)]
            [DefaultValue(0)]
            public int Value { get; set; }

            /// <summary>
            /// Gets or sets whether the scroll bar can be seen by the user.
            /// </summary>
            /// <value><c>true</c> if it can be seen; otherwise, <c>false</c>.</value>
            [DefaultValue(false)]
            public bool Visible { get; set; }

            #endregion
        }

        /// <summary>
        /// Provides basic properties for the vertical scroll bar in a <see cref="ScrollControl"/>.
        /// </summary>
        public class VScrollProperties : ScrollProperties
        {
            #region Public Constructors

            /// <summary>
            /// Initializes a new instance of the <see cref="ScrollProperties" /> class.
            /// </summary>
            /// <param name="container">The <see cref="ScrollControl" /> whose scrolling properties this object describes.</param>
            public VScrollProperties(ScrollControl container)
              : base(container)
            { }

            #endregion
        }

        #endregion
    }
}