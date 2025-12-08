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

namespace Krypton.Toolkit.Suite.Extended.Calendar;

/// <summary>
/// Represents the top area of a day, where multiday and all day items are stored
/// </summary>
public class CalendarDayTop : CalendarSelectableElement
{
    #region Events

    #endregion

    #region Fields
    private CalendarDay _day;
    private List<CalendarItemAlternative> _passingItems;
    #endregion

    #region Ctor

    /// <summary>
    /// Creates a new DayTop for the specified day
    /// </summary>
    /// <param name="day"></param>
    public CalendarDayTop(CalendarDay day) : base(day.Calendar)
    {
        _day = day;
        _passingItems = [];
    }

    #endregion

    #region Properties

    public override DateTime Date => new DateTime(Day.Date.Year, Day.Date.Month, Day.Date.Day);

    /// <summary>
    /// Gets the Day of this DayTop
    /// </summary>
    public CalendarDay Day => _day;


    /// <summary>
    /// Gets the list of items passing on this daytop
    /// </summary>
    public List<CalendarItemAlternative> PassingItems => _passingItems;

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    internal void AddPassingItem(CalendarItemAlternative item)
    {
        if (!PassingItems.Contains(item))
        {
            PassingItems.Add(item);
        }
    }

    #endregion
}