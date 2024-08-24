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
    /// <summary>
    /// Contains basic information about a drawing event for <see cref="CalendarRenderer"/>
    /// </summary>
    public class CalendarRendererEventArgs : EventArgs
    {
        #region Events

        #endregion

        #region Fields
        private KryptonCalendar? _calendar;
        private Rectangle _clip;
        private Graphics? _graphics;
        private object? _tag;
        #endregion

        #region Ctor

        /// <summary>
        /// Use it wisely just to initialize some stuff
        /// </summary>
        protected CalendarRendererEventArgs()
        {

        }

        /// <summary>
        /// Creates a new <see cref="CalendarRendererEventArgs"/>
        /// </summary>
        /// <param name="calendar">Calendar where painting</param>
        /// <param name="g">Device where to paint</param>
        /// <param name="clipRectangle">Paint event clip area</param>
        public CalendarRendererEventArgs(KryptonCalendar? calendar, Graphics? g, Rectangle clipRectangle)
        {
            _calendar = calendar;
            _graphics = g;
            _clip = clipRectangle;
        }

        /// <summary>
        /// Creates a new <see cref="CalendarRendererEventArgs"/>
        /// </summary>
        /// <param name="calendar">Calendar where painting</param>
        /// <param name="g">Device where to paint</param>
        /// <param name="clipRectangle">Paint event clip area</param>
        /// <param name="tag"></param>
        public CalendarRendererEventArgs(KryptonCalendar? calendar, Graphics? g, Rectangle clipRectangle, object? tag)
        {
            _calendar = calendar;
            _graphics = g;
            _clip = clipRectangle;
            _tag = tag;
        }

        /// <summary>
        /// Copies the parameters from the specified <see cref="CalendarRendererEventArgs"/>
        /// </summary>
        /// <param name="original"></param>
        public CalendarRendererEventArgs(CalendarRendererEventArgs original)
        {
            _calendar = original.Calendar;
            _graphics = original.Graphics;
            _clip = original.ClipRectangle;
            _tag = original.Tag;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the calendar where painting
        /// </summary>
        public KryptonCalendar? Calendar => _calendar;

        /// <summary>
        /// Gets the clip of the paint event
        /// </summary>
        public Rectangle ClipRectangle => _clip;

        /// <summary>
        /// Gets the device where to paint
        /// </summary>
        public Graphics? Graphics => _graphics;

        /// <summary>
        /// Gets or sets a tag for the event
        /// </summary>
        public object? Tag
        {
            get => _tag;
            set => _tag = value;
        }


        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        #endregion
    }
}