#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Krypton.Toolkit.Suite.Extended.Calendar
{
    /// <summary>
    /// Represents an item of the calendar with a date and timespan
    /// </summary>
    /// <remarks>
    /// <para>CalendarItem provides a graphical representation of tasks within a date range.</para>
    /// </remarks>
    public class CalendarItemAlternative : CalendarSelectableElement
    {
        #region Static

        private static int CompareBounds(Rectangle r1, Rectangle r2)
        {
            return r1.Top.CompareTo(r2.Top);
        }

        #endregion

        #region Events

        #endregion

        #region Fields
        private Rectangle[] _additionalBounds;
        private Color _backgroundColour;
        private Color _backgroundColourLighter;
        private Color _borderColour;
        private DateTime _startDate;
        private DateTime _endDate;
        private Color _oreColour;
        private bool _locked;
        private TimeSpan _duration;
        private Image _image;
        private CalendarItemImageAlign _imageAlign;
        private bool _isDragging;
        private bool _isEditing;
        private bool _isResizingStartDate;
        private bool _isResizingEndDate;
        private bool _isOnView;
        private int _minuteStartTop;
        private int _minuteEndTop;
        private HatchStyle _pattern;
        private Color _patternColor;
        private List<CalendarTimeScaleUnit> _unitsPassing;
        private List<CalendarDayTop> _topsPassing;
        private object _tag;
        private string _text;
        #endregion

        #region Ctor

        /// <summary>
        /// Creates a new Item that belongs to the specified calendar
        /// </summary>
        /// <param name="calendar">Calendar to reference item</param>
        public CalendarItemAlternative(KryptonCalendar calendar) : base(calendar)
        {
            _unitsPassing = new List<CalendarTimeScaleUnit>();
            _topsPassing = new List<CalendarDayTop>();
            _backgroundColour = Color.Empty;
            _borderColour = Color.Empty;
            _oreColour = Color.Empty;
            _backgroundColourLighter = Color.Empty;
            _imageAlign = CalendarItemImageAlign.WEST;
        }

        /// <summary>
        /// Creates a new item with the specified date range and text
        /// </summary>
        /// <param name="calendar">Calendar to reference item</param>
        /// <param name="startDate">Start date of the item</param>
        /// <param name="endDate">End date of the item</param>
        /// <param name="text">Text of the item</param>
        public CalendarItemAlternative(KryptonCalendar calendar, DateTime startDate, DateTime endDate, string text) : this(calendar)
        {
            StartDate = startDate;
            EndDate = endDate;
            Text = text;
        }

        /// <summary>
        /// Creates a new item with the specified date, duration and text
        /// </summary>
        /// <param name="calendar">Calendar to reference item</param>
        /// <param name="startDate">Start date of the item</param>
        /// <param name="duration">Duration of the item</param>
        /// <param name="text">Text of the item</param>
        public CalendarItemAlternative(KryptonCalendar calendar, DateTime startDate, TimeSpan duration, string text) : this(calendar, startDate, startDate.Add(duration), text)
        { }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets an array of rectangles containing bounds additional to <see cref="Bounds"/> property.
        /// </summary>
        /// <remarks>
        /// Items may contain additional bounds because of several graphical occourences, mostly when <see cref="Calendar"/> in 
        /// <see cref="CalendarDaysMode.Short"/> mode, due to the duration of the item; e.g. when an all day item lasts several weeks, 
        /// one rectangle for week must be drawn to indicate the presence of the item.
        /// </remarks>
        public virtual Rectangle[] AditionalBounds
        {
            get { return _additionalBounds; }
            set { _additionalBounds = value; }
        }

        /// <summary>
        /// Gets or sets the a background color for the object. If Color.Empty, renderer default's will be used.
        /// </summary>
        public Color BackgroundColour
        {
            get { return _backgroundColour; }
            set { _backgroundColour = value; }
        }

        /// <summary>
        /// Gets or sets the lighter background color of the item
        /// </summary>
        public Color BackgroundColourLighter
        {
            get { return _backgroundColourLighter; }
            set { _backgroundColourLighter = value; }
        }

        /// <summary>
        /// Gets or sets the bordercolor of the item. If Color.Empty, renderer default's will be used.
        /// </summary>
        public Color BorderColour
        {
            get { return _borderColour; }
            set { _borderColour = value; }
        }

        /// <summary>
        /// Gets the StartDate of the item. Implemented
        /// </summary>
        public override DateTime Date
        {
            get
            {
                return StartDate;
            }
        }

        /// <summary>
        /// Gets the day on the <see cref="KryptonCalendar"/> where this item ends
        /// </summary>
        /// <remarks>
        /// This day is not necesarily the day corresponding to the day on <see cref="EndDate"/>, 
        /// since this date can be out of the range of the current view.
        /// <para>If Item is not on view date range this property will return null.</para>
        /// </remarks>
        public CalendarDay DayEnd
        {
            get
            {
                if (!IsOnViewDateRange)
                {
                    return null;
                }
                else if (IsOpenEnd)
                {
                    return Calendar.Days[Calendar.Days.Length - 1];
                }
                else
                {
                    return Calendar.FindDay(EndDate);
                }
            }
        }

        /// <summary>
        /// Gets the day on the <see cref="KryptonCalendar"/> where this item starts
        /// </summary>
        /// <remarks>
        /// This day is not necesarily the day corresponding to the day on <see cref="StartDate"/>, 
        /// since start date can be out of the range of the current view.
        /// <para>If Item is not on view date range this property will return null.</para>
        /// </remarks>
        public CalendarDay DayStart
        {
            get
            {
                if (!IsOnViewDateRange)
                {
                    return null;
                }
                else if (IsOpenStart)
                {
                    return Calendar.Days[0];
                }
                else
                {
                    return Calendar.FindDay(StartDate);
                }
            }
        }

        /// <summary>
        /// Gets the duration of the item
        /// </summary>
        public TimeSpan Duration
        {
            get
            {
                if (_duration.TotalMinutes == 0)
                {
                    _duration = EndDate.Subtract(StartDate);
                }
                return _duration;
            }
        }

        /// <summary>
        /// Gets or sets the end time of the item
        /// </summary>
        public DateTime EndDate

        {
            get { return _endDate; }
            set
            {
                _endDate = value;
                _duration = new TimeSpan(0, 0, 0);
                ClearPassings();
            }
        }

        /// <summary>
        /// Gets the text of the end date
        /// </summary>
        public virtual string EndDateText
        {
            get
            {
                string date = string.Empty;
                string time = string.Empty;

                if (IsOpenEnd)
                {
                    date = EndDate.ToString(Calendar.ItemsDateFormat);
                }

                if (ShowEndTime && !EndDate.TimeOfDay.Equals(new TimeSpan(23, 59, 59)))
                {
                    time = EndDate.ToString(Calendar.ItemsTimeFormat);
                }

                return string.Format("{0} {1}", date, time).Trim();
            }
        }

        /// <summary>
        /// Gets or sets the forecolor of the item. If Color.Empty, renderer default's will be used.
        /// </summary>
        public Color ForeColour
        {
            get { return _oreColour; }
            set
            {
                _oreColour = value;
            }
        }

        /// <summary>
        /// Gets or sets an image for the item
        /// </summary>
        public Image Image
        {
            get { return _image; }
            set { _image = value; }
        }

        /// <summary>
        /// Gets or sets the alignment of the image relative to the text
        /// </summary>
        public CalendarItemImageAlign ImageAlign
        {
            get { return _imageAlign; }
            set { _imageAlign = value; }
        }

        /// <summary>
        /// Gets a value indicating if the item is being dragged
        /// </summary>
        public bool IsDragging
        {
            get { return _isDragging; }
        }

        /// <summary>
        /// Gets a value indicating if the item is currently being edited by the user
        /// </summary>
        public bool IsEditing
        {
            get { return _isEditing; }
        }

        /// <summary>
        /// Gets a value indicating if the item goes on the DayTop area of the <see cref="CalendarDay"/>
        /// </summary>
        public bool IsOnDayTop
        {
            get
            {
                return StartDate.Day != EndDate.AddSeconds(1).Day;
            }
        }

        /// <summary>
        /// Gets a value indicating if the item is currently on view.
        /// </summary>
        /// <remarks>
        /// The item may not be on view because of scrolling
        /// </remarks>
        public bool IsOnView
        {
            get { return _isOnView; }
        }

        /// <summary>
        /// Gets a value indicating if the item is on the range specified by <see cref="Calendar.ViewStart"/> and <see cref="Calendar.ViewEnd"/>
        /// </summary>
        public bool IsOnViewDateRange
        {
            get
            {
                //Checks for an intersection of item's dates against calendar dates
                DateTime fd = Calendar.Days[0].Date;
                DateTime ld = Calendar.Days[Calendar.Days.Length - 1].Date.Add(new TimeSpan(23, 59, 59));
                DateTime sd = StartDate;
                DateTime ed = EndDate;
                return sd < ld && fd < ed;
            }
        }

        /// <summary>
        /// Gets a value indicating if the item's <see cref="StartDate"/> is before the <see cref="Calendar.ViewStart"/> date.
        /// </summary>
        public bool IsOpenStart
        {
            get
            {
                return StartDate.CompareTo(Calendar.Days[0].Date) < 0;
            }
        }

        /// <summary>
        /// Gets a value indicating if the item's <see cref="EndDate"/> is aftter the <see cref="Calendar.ViewEnd"/> date.
        /// </summary>
        public bool IsOpenEnd
        {
            get
            {
                return EndDate.CompareTo(Calendar.Days[Calendar.Days.Length - 1].Date.Add(new TimeSpan(23, 59, 59))) > 0;
            }
        }

        /// <summary>
        /// Gets a value indicating if item is being resized by the <see cref="StartDate"/>
        /// </summary>
        public bool IsResizingStartDate
        {
            get { return _isResizingStartDate; }
        }

        /// <summary>
        /// Gets a value indicating if item is being resized by the <see cref="EndDate"/>
        /// </summary>
        public bool IsResizingEndDate
        {
            get { return _isResizingEndDate; }
        }

        /// <summary>
        /// Gets a value indicating if this item is locked.
        /// </summary>
        /// <remarks>
        /// When an item is locked, the user can't drag it or change it's text
        /// </remarks>
        public bool Locked
        {
            get { return _locked; }
            set { _locked = value; }
        }

        /// <summary>
        /// Gets the top correspoinding to the ending minute
        /// </summary>
        public int MinuteEndTop
        {
            get { return _minuteEndTop; }
        }


        /// <summary>
        /// Gets the top corresponding to the starting minute
        /// </summary>
        public int MinuteStartTop
        {
            get { return _minuteStartTop; }
        }


        /// <summary>
        /// Gets or sets the units that this item passes by
        /// </summary>
        internal List<CalendarTimeScaleUnit> UnitsPassing
        {
            get { return _unitsPassing; }
            set { _unitsPassing = value; }
        }

        /// <summary>
        /// Gets or sets the pattern style to use in the background of item.
        /// </summary>
        public HatchStyle Pattern
        {
            get { return _pattern; }
            set { _pattern = value; }
        }


        /// <summary>
        /// Gets or sets the pattern's color
        /// </summary>
        public Color PatternColor
        {
            get { return _patternColor; }
            set { _patternColor = value; }
        }


        /// <summary>
        /// Gets the list of DayTops that this item passes thru
        /// </summary>
        internal List<CalendarDayTop> TopsPassing
        {
            get { return _topsPassing; }
        }

        /// <summary>
        /// Gets a value indicating if the item should show the time of the <see cref="StartDate"/>
        /// </summary>
        public bool ShowStartTime
        {
            get
            {
                return IsOpenStart || ((IsOnDayTop || Calendar.DaysMode == CalendarDaysMode.SHORT) && !StartDate.TimeOfDay.Equals(new TimeSpan(0, 0, 0)));
            }
        }

        /// <summary>
        /// Gets a value indicating if the item should show the time of the <see cref="EndDate"/>
        /// </summary>
        public virtual bool ShowEndTime
        {
            get
            {
                return (IsOpenEnd ||
                    ((IsOnDayTop || Calendar.DaysMode == CalendarDaysMode.SHORT) && !EndDate.TimeOfDay.Equals(new TimeSpan(23, 59, 59)))) &&
                    !(Calendar.DaysMode == CalendarDaysMode.SHORT && StartDate.Date == EndDate.Date);
            }
        }

        /// <summary>
        /// Gets the text of the start date
        /// </summary>
        public virtual string StartDateText
        {
            get
            {
                string date = string.Empty;
                string time = string.Empty;

                if (IsOpenStart)
                {
                    date = StartDate.ToString(Calendar.ItemsDateFormat);
                }

                if (ShowStartTime && !StartDate.TimeOfDay.Equals(new TimeSpan(0, 0, 0)))
                {
                    time = StartDate.ToString(Calendar.ItemsTimeFormat);
                }

                return string.Format("{0} {1}", date, time).Trim();
            }
        }

        /// <summary>
        /// Gets or sets the start time of the item
        /// </summary>
        public virtual DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                _startDate = value;
                _duration = new TimeSpan(0, 0, 0);
                ClearPassings();
            }
        }

        /// <summary>
        /// Gets or sets a tag object for the item
        /// </summary>
        public object Tag
        {
            get { return _tag; }
            set { _tag = value; }
        }

        /// <summary>
        /// Gets or sets the text of the item
        /// </summary>
        public virtual string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Applies color to background, border, and forecolor, from the specified color.
        /// </summary>
        public void ApplyColor(Color color)
        {
            BackgroundColour = color;
            BackgroundColourLighter = Color.FromArgb(
                color.R + (255 - color.R) / 2 + (255 - color.R) / 3,
                color.G + (255 - color.G) / 2 + (255 - color.G) / 3,
                color.B + (255 - color.B) / 2 + (255 - color.B) / 3);

            BorderColour = Color.FromArgb(
                Convert.ToInt32(Convert.ToSingle(color.R) * .8f),
                Convert.ToInt32(Convert.ToSingle(color.G) * .8f),
                Convert.ToInt32(Convert.ToSingle(color.B) * .8f));

            int avg = (color.R + color.G + color.B) / 3;

            if (avg > 255 / 2)
            {
                ForeColour = Color.Black;
            }
            else
            {
                ForeColour = Color.White;
            }
        }

        /// <summary>
        /// Gets all the bounds related to the item.
        /// </summary>
        /// <remarks>
        ///  Items that are broken on two or more weeks may have more than one rectangle bounds.
        /// </remarks>
        /// <returns></returns>
        public IEnumerable<Rectangle> GetAllBounds()
        {
            List<Rectangle> r = new List<Rectangle>(AditionalBounds == null ? new Rectangle[] { } : AditionalBounds);
            r.Add(Bounds);

            r.Sort(CompareBounds);

            return r;
        }

        /// <summary>
        /// Removes all specific coloring for the item.
        /// </summary>
        public void RemoveColors()
        {
            BackgroundColour = Color.Empty;
            ForeColour = Color.Empty;
            BorderColour = Color.Empty;
        }

        /// <summary>
        /// Gets a value indicating if the specified point is in a resize zone of <see cref="StartDate"/>
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool ResizeStartDateZone(Point p)
        {
            int margin = 4;

            List<Rectangle> rects = new List<Rectangle>(GetAllBounds());
            Rectangle first = rects[0];
            Rectangle last = rects[rects.Count - 1];

            if (IsOnDayTop || Calendar.DaysMode == CalendarDaysMode.SHORT)
            {
                return Rectangle.FromLTRB(first.Left, first.Top, first.Left + margin, first.Bottom).Contains(p);
            }
            else
            {
                return Rectangle.FromLTRB(first.Left, first.Top, first.Right, first.Top + margin).Contains(p);
            }
        }

        /// <summary>
        /// Gets a value indicating if the specified point is in a resize zone of <see cref="EndDate"/>
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool ResizeEndDateZone(Point p)
        {
            int margin = 4;

            List<Rectangle> rects = new List<Rectangle>(GetAllBounds());
            Rectangle first = rects[0];
            Rectangle last = rects[rects.Count - 1];

            if (IsOnDayTop || Calendar.DaysMode == CalendarDaysMode.SHORT)
            {
                return Rectangle.FromLTRB(last.Right - margin, last.Top, last.Right, last.Bottom).Contains(p);
            }
            else
            {
                return Rectangle.FromLTRB(last.Left, last.Bottom - margin, last.Right, last.Bottom).Contains(p);
            }
        }

        /// <summary>
        /// Sets the bounds of the item
        /// </summary>
        /// <param name="r"></param>
        public new void SetBounds(Rectangle r)
        {
            base.SetBounds(r);
        }

        /// <summary>
        /// Indicates if the time of the item intersects with the provided time
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public bool IntersectsWith(TimeSpan timeStart, TimeSpan timeEnd)
        {
            Rectangle r1 = Rectangle.FromLTRB(0, Convert.ToInt32(StartDate.TimeOfDay.TotalMinutes), 5, Convert.ToInt32(EndDate.TimeOfDay.TotalMinutes));
            Rectangle r2 = Rectangle.FromLTRB(0, Convert.ToInt32(timeStart.TotalMinutes), 5, Convert.ToInt32(timeEnd.TotalMinutes - 1));
            return r1.IntersectsWith(r2);
        }

        public override string ToString()
        {
            return $"{StartDate.ToShortTimeString()} - {EndDate.ToShortTimeString()}";
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Adds bounds for the item
        /// </summary>
        /// <param name="r"></param>
        internal void AddBounds(Rectangle r)
        {
            if (r.IsEmpty) throw new ArgumentException("r can't be empty");

            if (Bounds.IsEmpty)
            {
                SetBounds(r);
            }
            else
            {
                List<Rectangle> rs = new List<Rectangle>(AditionalBounds == null ? new Rectangle[] { } : AditionalBounds);
                rs.Add(r);
                AditionalBounds = rs.ToArray();
            }
        }

        /// <summary>
        /// Adds the specified unit as a passing unit
        /// </summary>
        /// <param name="calendarTimeScaleUnit"></param>
        internal void AddUnitPassing(CalendarTimeScaleUnit calendarTimeScaleUnit)
        {
            if (!UnitsPassing.Contains(calendarTimeScaleUnit))
            {
                UnitsPassing.Add(calendarTimeScaleUnit);
            }
        }

        /// <summary>
        /// Adds the specified <see cref="CalendarDayTop"/> as a passing one
        /// </summary>
        /// <param name="top"></param>
        internal void AddTopPassing(CalendarDayTop top)
        {
            if (!TopsPassing.Contains(top))
            {
                TopsPassing.Add(top);
            }
        }

        /// <summary>
        /// Clears the item's existance off passing units and tops
        /// </summary>
        internal void ClearPassings()
        {
            foreach (CalendarTimeScaleUnit unit in UnitsPassing)
            {
                unit.ClearItemExistance(this);
            }

            UnitsPassing.Clear();
            TopsPassing.Clear();
        }

        /// <summary>
        /// Clears all bounds of the item
        /// </summary>
        internal void ClearBounds()
        {
            SetBounds(Rectangle.Empty);
            AditionalBounds = new Rectangle[] { };
            SetMinuteStartTop(0);
            SetMinuteEndTop(0);
        }

        /// <summary>
        /// It pushes the left and the right to the center of the item
        /// to visually indicate start and end time
        /// </summary>
        internal void FirstAndLastRectangleGapping()
        {
            if (!IsOpenStart)
                SetBounds(Rectangle.FromLTRB(Bounds.Left + Calendar.Renderer.ItemsPadding,
                    Bounds.Top, Bounds.Right, Bounds.Bottom));

            if (!IsOpenEnd)
            {
                if (AditionalBounds != null && AditionalBounds.Length > 0)
                {
                    Rectangle r = AditionalBounds[AditionalBounds.Length - 1];
                    AditionalBounds[AditionalBounds.Length - 1] = Rectangle.FromLTRB(
                        r.Left, r.Top, r.Right - Calendar.Renderer.ItemsPadding, r.Bottom);
                }
                else
                {
                    Rectangle r = Bounds;
                    SetBounds(Rectangle.FromLTRB(
                        r.Left, r.Top, r.Right - Calendar.Renderer.ItemsPadding, r.Bottom));
                }
            }
        }

        /// <summary>
        /// Sets the value of the <see cref="Dragging"/> property
        /// </summary>
        /// <param name="dragging">Value indicating if the item is currently being dragged</param>
        internal void SetIsDragging(bool dragging)
        {
            _isDragging = dragging;
        }

        /// <summary>
        /// Sets the value of the <see cref="IsEditing"/> property
        /// </summary>
        /// <param name="editing">Value indicating if user is currently being editing</param>
        internal void SetIsEditing(bool editing)
        {
            _isEditing = editing;
        }

        /// <summary>
        /// Sets the value of the <see cref="IsOnView"/> property
        /// </summary>
        /// <param name="onView">Indicates if the item is currently on view</param>
        internal void SetIsOnView(bool onView)
        {
            _isOnView = onView;
        }

        /// <summary>
        /// Sets the value of the <see cref="IsResizingStartDate"/> property
        /// </summary>
        /// <param name="resizing"></param>
        internal void SetIsResizingStartDate(bool resizing)
        {
            _isResizingStartDate = resizing;
        }

        /// <summary>
        /// Sets the value of the <see cref="IsResizingEndDate"/> property
        /// </summary>
        /// <param name="resizing"></param>
        internal void SetIsResizingEndDate(bool resizing)
        {
            _isResizingEndDate = resizing;
        }

        /// <summary>
        /// Sets the value of the <see cref="MinuteStartTop"/> property
        /// </summary>
        /// <param name="top"></param>
        internal void SetMinuteStartTop(int top)
        {
            _minuteStartTop = top;
        }

        /// <summary>
        /// Sets the value of the <see cref="MinuteEndTop"/> property
        /// </summary>
        /// <param name="top"></param>
        internal void SetMinuteEndTop(int top)
        {
            _minuteEndTop = top;
        }

        #endregion

    }
}