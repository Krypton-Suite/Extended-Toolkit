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

namespace Krypton.Toolkit.Suite.Extended.Calendar;

public class KryptonCalendarTextBox : KryptonTextBox //TextBox
{
    #region Fields
    private KryptonCalendar _calendar;
    #endregion

    #region Ctor

    /// <summary>
    /// Creates a new <see cref="KryptonCalendarTextBox"/> for the specified <see cref="KryptonCalendar"/>
    /// </summary>
    /// <param name="calendar">Calendar where this control lives</param>
    public KryptonCalendarTextBox(KryptonCalendar calendar)
    {
        _calendar = calendar;
    }

    #endregion

    #region Props

    /// <summary>
    /// Gets the calendar where this control lives
    /// </summary>
    public KryptonCalendar Calendar => _calendar;

    #endregion

    #region Methods



    #endregion
}