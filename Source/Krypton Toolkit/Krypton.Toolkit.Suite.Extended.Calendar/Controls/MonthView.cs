#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Krypton.Toolkit.Suite.Extended.Tools;

namespace Krypton.Toolkit.Suite.Extended.Calendar
{
    /// <summary>
    /// Hosts a month-level calendar where user can select day-based dates
    /// </summary>
    [DefaultEvent("SelectionChanged")]
    public class MonthView
        : ContainerControl
    {

        #region Subclasses

        /// <summary>
        /// Represents the different kinds of selection in MonthView
        /// </summary>
        public enum MonthViewSelection
        {
            /// <summary>
            /// User can select whatever date available to mouse reach
            /// </summary>
            Manual,

            /// <summary>
            /// Selection is limited to just one day
            /// </summary>
            Day,

            /// <summary>
            /// Selecion is limited to <see cref="WorkWeekStart"/> and <see cref="WorkWeekEnd"/> weekly ranges
            /// </summary>
            WorkWeek,

            /// <summary>
            /// Selection is limited to a full week
            /// </summary>
            Week,

            /// <summary>
            /// Selection is limited to a full month
            /// </summary>
            Month
        }

        #endregion

        #region Fields
        private int _forwardMonthIndex;
        private MonthViewDay _lastHitted;
        private bool _mouseDown;
        private Size _daySize;
        private DateTime _selectionStart;
        private DateTime _selectionEnd;
        private string _monthTitleFormat;
        private DayOfWeek _weekStart;
        private DayOfWeek _workWeekStart;
        private DayOfWeek _workWeekEnd;
        private MonthViewSelection _selectionMode;
        private string _dayNamesFormat;
        private bool _dayNamesVisible;
        private int _dayNamesLength;
        private DateTime _viewStart;
        private Size _monthSize;
        private MonthViewMonth[] _months;
        private Padding _itemPadding;
        private Color _monthTitleColour;
        private Color _monthTitleColourInactive;
        private Color _monthTitleTextColour;
        private Color _monthTitleTextColourInactive;
        private Color _dayBackgroundColour;
        private Color _daySelectedBackgroundColour;
        private Color _dayTextColour;
        private Color _daySelectedTextColour;
        private Color _arrowsColour;
        private Color _arrowsSelectedColour;
        private Color _dayGrayedText;
        private Color _todayBorderColour;
        private int _maxSelectionCount;
        private Rectangle _forwardButtonBounds;
        private bool _forwardButtonSelected;
        private Rectangle _backwardButtonBounds;
        private bool _backwardButtonSelected;
        #endregion

        #region Events

        /// <summary>
        /// Occurs when selection has changed.
        /// </summary>
        public event EventHandler SelectionChanged;

        #endregion

        #region Ctors

        public MonthView()
        {
            SetStyle(ControlStyles.Opaque, true);
            DoubleBuffered = true;

            _dayNamesFormat = "ddd";
            _monthTitleFormat = "MMMM yyyy";
            _selectionMode = MonthViewSelection.Manual;
            _workWeekStart = DayOfWeek.Monday;
            _workWeekEnd = DayOfWeek.Friday;
            _weekStart = DayOfWeek.Sunday;
            _dayNamesVisible = true;
            _dayNamesLength = 2;
            _viewStart = DateTime.Now;
            _itemPadding = new Padding(2);
            _monthTitleColour = SystemColors.ActiveCaption;
            _monthTitleColourInactive = SystemColors.InactiveCaption;
            _monthTitleTextColour = SystemColors.ActiveCaptionText;
            _monthTitleTextColourInactive = SystemColors.InactiveCaptionText;
            _dayBackgroundColour = Color.Empty;
            _daySelectedBackgroundColour = SystemColors.Highlight;
            _dayTextColour = SystemColors.WindowText;
            _daySelectedTextColour = SystemColors.HighlightText;
            _arrowsColour = SystemColors.Window;
            _arrowsSelectedColour = Color.Gold;
            _dayGrayedText = SystemColors.GrayText;
            _todayBorderColour = Color.Maroon;

            UpdateMonthSize();
            UpdateMonths();
        }

        #endregion

        #region Props

        /// <summary>
        /// Gets the size of days rectangles
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Size DaySize
        {
            get { return _daySize; }
        }

        /// <summary>
        /// Gets or sets the format of day names
        /// </summary>
        [DefaultValue("ddd")]
        public string DayNamesFormat
        {
            get { return _dayNamesFormat; }
            set { _dayNamesFormat = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating if day names should be visible
        /// </summary>
        [DefaultValue(true)]
        public bool DayNamesVisible
        {
            get { return _dayNamesVisible; }
            set { _dayNamesVisible = value; }
        }

        /// <summary>
        /// Gets or sets how many characters of day names should be displayed
        /// </summary>
        [DefaultValue(2)]
        public int DayNamesLength
        {
            get { return _dayNamesLength; }
            set { _dayNamesLength = value; UpdateMonths(); }
        }

        /// <summary>
        /// Gets or sets what the first day of weeks should be
        /// </summary>
        [DefaultValue(DayOfWeek.Sunday)]
        public DayOfWeek FirstDayOfWeek
        {
            get { return _weekStart; }
            set { _weekStart = value; }
        }

        /// <summary>
        /// Gets a value indicating if the backward button is selected
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool BackwardButtonSelected
        {
            get { return _backwardButtonSelected; }
        }

        /// <summary>
        /// Gets the bounds of the backward button
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Rectangle BackwardButtonBounds
        {
            get { return _backwardButtonBounds; }
        }

        /// <summary>
        /// Gets a value indicating if the forward button is selected
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ForwardButtonSelected
        {
            get { return _forwardButtonSelected; }
        }

        /// <summary>
        /// Gets the bounds of the forward button
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Rectangle ForwardButtonBounds
        {
            get { return _forwardButtonBounds; }
        }


        /// <summary>
        /// Gets or sets the Font of the Control
        /// </summary>
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;

                UpdateMonthSize();
                UpdateMonths();
            }
        }

        /// <summary>
        /// Gets or sets the internal padding of items (Days, day names, month names)
        /// </summary>
        public Padding ItemPadding
        {
            get { return _itemPadding; }
            set { _itemPadding = value; }
        }

        /// <summary>
        /// Gets or sets the maximum selection count of days
        /// </summary>
        [DefaultValue(0)]
        public int MaxSelectionCount
        {
            get { return _maxSelectionCount; }
            set { _maxSelectionCount = value; }
        }

        /// <summary>
        /// Gets the Months currently displayed on the calendar
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MonthViewMonth[] Months
        {
            get { return _months; }
        }

        /// <summary>
        /// Gets the size of an entire month inside the <see cref="MonthView"/>
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Size MonthSize
        {
            get { return _monthSize; }
        }

        /// <summary>
        /// Gets or sets the format of month titles
        /// </summary>
        [DefaultValue("MMMM yyyy")]
        public string MonthTitleFormat
        {
            get { return _monthTitleFormat; }
            set { _monthTitleFormat = value; UpdateMonths(); }
        }

        /// <summary>
        /// Gets or sets the start of selection
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime SelectionStart
        {
            get { return _selectionStart; }
            set
            {
                if (MaxSelectionCount > 0)
                {
                    if (Math.Abs(value.Subtract(SelectionEnd).TotalDays) >= MaxSelectionCount)
                    {
                        return;
                    }
                }

                _selectionStart = value;
                Invalidate();
                OnSelectionChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Gets or sets the end of selection
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime SelectionEnd
        {
            get { return _selectionEnd; }
            set
            {
                if (MaxSelectionCount > 0)
                {
                    if (Math.Abs(value.Subtract(SelectionStart).TotalDays) >= MaxSelectionCount)
                    {
                        return;
                    }
                }

                _selectionEnd = value.Date.Add(new TimeSpan(23, 59, 59));
                Invalidate();
                OnSelectionChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Gets or sets the selection mode of <see cref="MonthView"/>
        /// </summary>
        [DefaultValue(MonthViewSelection.Manual)]
        public MonthViewSelection SelectionMode
        {
            get { return _selectionMode; }
            set { _selectionMode = value; }
        }

        /// <summary>
        /// Gets or sets the date of the first displayed month
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime ViewStart
        {
            get { return _viewStart; }
            set { _viewStart = value; UpdateMonths(); Invalidate(); }
        }

        /// <summary>
        /// Gets the last day of the last month showed on the view.
        /// </summary>
        public DateTime ViewEnd
        {
            get
            {
                DateTime month = Months[Months.Length - 1].Date;
                return month.Date.AddDays(DateTime.DaysInMonth(month.Year, month.Month));
            }
        }

        /// <summary>
        /// Gets or sets the day that starts a work-week
        /// </summary>
        [DefaultValue(DayOfWeek.Monday)]
        public DayOfWeek WorkWeekStart
        {
            get { return _workWeekStart; }
            set { _workWeekStart = value; }
        }

        /// <summary>
        /// Gets or sets the day that ends a work-week
        /// </summary>
        [DefaultValue(DayOfWeek.Friday)]
        public DayOfWeek WorkWeekEnd
        {
            get { return _workWeekEnd; }
            set { _workWeekEnd = value; }
        }

        #endregion

        #region Color Properties

        public Color ArrowsSelectedColour
        {
            get { return _arrowsSelectedColour; }
            set { _arrowsSelectedColour = value; }
        }


        public Color ArrowsColour
        {
            get { return _arrowsColour; }
            set { _arrowsColour = value; }
        }


        public Color DaySelectedTextColour
        {
            get { return _daySelectedTextColour; }
            set { _daySelectedTextColour = value; }
        }


        public Color DaySelectedColour
        {
            get { return _dayTextColour; }
            set { _dayTextColour = value; }
        }


        public Color DaySelectedBackgroundColour
        {
            get { return _daySelectedBackgroundColour; }
            set { _daySelectedBackgroundColour = value; }
        }

        public Color DayBackgroundColour
        {
            get { return _dayBackgroundColour; }
            set { _dayBackgroundColour = value; }
        }


        public Color DayGrayedText
        {
            get { return _dayGrayedText; }
            set { _dayGrayedText = value; }
        }

        public Color MonthTitleColour
        {
            get { return _monthTitleColour; }
            set { _monthTitleColour = value; }
        }

        public Color MonthTitleTextColourInactive
        {
            get { return _monthTitleTextColourInactive; }
            set { _monthTitleTextColourInactive = value; }
        }

        public Color MonthTitleTextColour
        {
            get { return _monthTitleTextColour; }
            set { _monthTitleTextColour = value; }
        }


        public Color MonthTitleColourInactive
        {
            get { return _monthTitleColourInactive; }
            set { _monthTitleColourInactive = value; }
        }

        /// <summary>
        /// Gets or sets the color of the today day border color
        /// </summary>
        public Color TodayBorderColour
        {
            get { return _todayBorderColour; }
            set { _todayBorderColour = value; }
        }


        #endregion

        #region Public Methods

        /// <summary>
        /// Checks if a day is hitted on the specified point
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public MonthViewDay HitTest(Point p)
        {
            for (int i = 0; i < Months.Length; i++)
            {
                if (Months[i].Bounds.Contains(p))
                {
                    for (int j = 0; j < Months[i].Days.Length; j++)
                    {
                        if (/*Months[i].Days[j].Visible && */Months[i].Days[j].Bounds.Contains(p))
                        {
                            return Months[i].Days[j];
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Moves the view one month forward
        /// </summary>
        public void GoForward()
        {
            ViewStart = ViewStart.AddMonths(1);
        }

        /// <summary>
        /// Moves the view one month backward
        /// </summary>
        public void GoBackward()
        {
            ViewStart = ViewStart.AddMonths(-1);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Sets the value of the <see cref=""/> property
        /// </summary>
        /// <param name="bounds">Bounds of the button</param>
        private void SetForwardButtonBounds(Rectangle bounds)
        {
            _forwardButtonBounds = bounds;
        }

        /// <summary>
        /// Sets the value of the <see cref=""/> property
        /// </summary>
        /// <param name="bounds">Bounds of the button</param>
        private void SetBackwardButtonBounds(Rectangle bounds)
        {
            _backwardButtonBounds = bounds;
        }

        /// <summary>
        /// Sets the value of the <see cref=""/> property
        /// </summary>
        /// <param name="bounds">Value indicating if button is selected</param>
        private void SetForwardButtonSelected(bool selected)
        {
            _forwardButtonSelected = selected;
            Invalidate(ForwardButtonBounds);
        }

        /// <summary>
        /// Sets the value of the <see cref=""/> property
        /// </summary>
        /// <param name="bounds">Value indicating if button is selected</param>
        private void SetBackwardButtonSelected(bool selected)
        {
            _backwardButtonSelected = selected;
            Invalidate(BackwardButtonBounds);
        }

        /// <summary>
        /// Selects the week where the hit is contained
        /// </summary>
        /// <param name="hit"></param>
        private void SelectWeek(DateTime hit)
        {
            int preDays = (new int[] { 0, 1, 2, 3, 4, 5, 6 })[(int)hit.DayOfWeek] - (int)FirstDayOfWeek;

            _selectionStart = hit.AddDays(-preDays);
            SelectionEnd = SelectionStart.AddDays(6);
        }

        /// <summary>
        /// Selecs the work-week where the hit is contanied
        /// </summary>
        /// <param name="hit"></param>
        private void SelectWorkWeek(DateTime hit)
        {
            int preDays = (new int[] { 0, 1, 2, 3, 4, 5, 6 })[(int)hit.DayOfWeek] - (int)WorkWeekStart;

            _selectionStart = hit.AddDays(-preDays);
            SelectionEnd = SelectionStart.AddDays(Math.Abs(WorkWeekStart - WorkWeekEnd));
        }

        /// <summary>
        /// Selecs the month where the hit is contanied
        /// </summary>
        /// <param name="hit"></param>
        private void SelectMonth(DateTime hit)
        {
            _selectionStart = new DateTime(hit.Year, hit.Month, 1);
            SelectionEnd = new DateTime(hit.Year, hit.Month, DateTime.DaysInMonth(hit.Year, hit.Month));
        }

        /// <summary>
        /// Draws a box of text
        /// </summary>
        /// <param name="e"></param>
        private void DrawBox(MonthViewBoxEventArgs e)
        {
            if (!e.BackgroundColour.IsEmpty)
            {
                using (SolidBrush b = new SolidBrush(e.BackgroundColour))
                {
                    e.Graphics.FillRectangle(b, e.Bounds);
                }
            }

            if (!e.TextColour.IsEmpty && !MissingFrameWorkAPIs.IsNullOrWhiteSpace(e.Text))
            {
                TextRenderer.DrawText(e.Graphics, e.Text, e.Font != null ? e.Font : Font, e.Bounds, e.TextColour, e.TextFlags);
            }

            if (!e.BorderColour.IsEmpty)
            {
                using (Pen p = new Pen(e.BorderColour))
                {
                    Rectangle r = e.Bounds;
                    r.Width--; r.Height--;
                    e.Graphics.DrawRectangle(p, r);
                }
            }
        }

        private void UpdateMonthSize()
        {
            //One row of day names plus 31 possible numbers
            string[] strs = new string[7 + 31];
            int maxWidth = 0;
            int maxHeight = 0;

            for (int i = 0; i < 7; i++)
            {
                strs[i] = ViewStart.AddDays(i).ToString(DayNamesFormat).Substring(0, DayNamesLength);
            }

            for (int i = 7; i < strs.Length; i++)
            {
                strs[i] = (i - 6).ToString();
            }

            Font f = new Font(Font, FontStyle.Bold);

            for (int i = 0; i < strs.Length; i++)
            {
                Size s = TextRenderer.MeasureText(strs[i], f);
                maxWidth = Math.Max(s.Width, maxWidth);
                maxHeight = Math.Max(s.Height, maxHeight);
            }

            maxWidth += ItemPadding.Horizontal;
            maxHeight += ItemPadding.Vertical;

            _daySize = new Size(maxWidth, maxHeight);
            _monthSize = new Size(maxWidth * 7, maxHeight * 7 + maxHeight * (DayNamesVisible ? 1 : 0));
        }

        private void UpdateMonths()
        {
            int gapping = 2;
            int calendarsX = Convert.ToInt32(Math.Max(Math.Floor((double)ClientSize.Width / (double)(MonthSize.Width + gapping)), 1.0));
            int calendarsY = Convert.ToInt32(Math.Max(Math.Floor((double)ClientSize.Height / (double)(MonthSize.Height + gapping)), 1.0));
            int calendars = calendarsX * calendarsY;
            int monthsWidth = (calendarsX * MonthSize.Width) + (calendarsX - 1) * gapping;
            int monthsHeight = (calendarsY * MonthSize.Height) + (calendarsY - 1) * gapping;
            int startX = (ClientSize.Width - monthsWidth) / 2;
            int startY = (ClientSize.Height - monthsHeight) / 2;
            int curX = startX;
            int curY = startY;
            _forwardMonthIndex = calendarsX - 1;

            _months = new MonthViewMonth[calendars];

            for (int i = 0; i < Months.Length; i++)
            {
                Months[i] = new MonthViewMonth(this, ViewStart.AddMonths(i));
                Months[i].SetLocation(new Point(curX, curY));

                curX += gapping + MonthSize.Width;

                if ((i + 1) % calendarsX == 0)
                {
                    curX = startX;
                    curY += gapping + MonthSize.Height;
                }
            }

            MonthViewMonth first = Months[0];
            MonthViewMonth last = Months[_forwardMonthIndex];

            SetBackwardButtonBounds(new Rectangle(first.Bounds.Left + ItemPadding.Left, first.Bounds.Top + ItemPadding.Top, DaySize.Height - ItemPadding.Horizontal, DaySize.Height - ItemPadding.Vertical));
            SetForwardButtonBounds(new Rectangle(first.Bounds.Right - ItemPadding.Right - BackwardButtonBounds.Width, first.Bounds.Top + ItemPadding.Top, BackwardButtonBounds.Width, BackwardButtonBounds.Height));
        }

        #endregion

        #region Overrides

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);

            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            Focus();

            _mouseDown = true;

            MonthViewDay day = HitTest(e.Location);

            if (day != null)
            {
                switch (SelectionMode)
                {
                    case MonthViewSelection.Manual:
                    case MonthViewSelection.Day:
                        SelectionEnd = _selectionStart = day.Date;
                        break;
                    case MonthViewSelection.WorkWeek:
                        SelectWorkWeek(day.Date);
                        break;
                    case MonthViewSelection.Week:
                        SelectWeek(day.Date);
                        break;
                    case MonthViewSelection.Month:
                        SelectMonth(day.Date);
                        break;
                }
            }

            if (ForwardButtonSelected)
            {
                GoForward();
            }
            else if (BackwardButtonSelected)
            {
                GoBackward();
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (_mouseDown)
            {
                MonthViewDay day = HitTest(e.Location);

                if (day != null && day != _lastHitted)
                {
                    switch (SelectionMode)
                    {
                        case MonthViewSelection.Manual:
                            if (day.Date > SelectionStart)
                            {
                                SelectionEnd = day.Date;
                            }
                            else
                            {
                                SelectionStart = day.Date;
                            }
                            break;
                        case MonthViewSelection.Day:
                            SelectionEnd = _selectionStart = day.Date;
                            break;
                        case MonthViewSelection.WorkWeek:
                            SelectWorkWeek(day.Date);
                            break;
                        case MonthViewSelection.Week:
                            SelectWeek(day.Date);
                            break;
                        case MonthViewSelection.Month:
                            SelectMonth(day.Date);
                            break;
                    }

                    _lastHitted = day;
                }
            }

            if (ForwardButtonBounds.Contains(e.Location))
            {
                SetForwardButtonSelected(true);
            }
            else if (ForwardButtonSelected)
            {
                SetForwardButtonSelected(false);
            }

            if (BackwardButtonBounds.Contains(e.Location))
            {
                SetBackwardButtonSelected(true);
            }
            else if (BackwardButtonSelected)
            {
                SetBackwardButtonSelected(false);
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            _mouseDown = false;
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);

            if (e.Delta < 0)
            {
                GoForward();
            }
            else
            {
                GoBackward();
            }
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);

            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.Clear(SystemColors.Window);

            for (int i = 0; i < Months.Length; i++)
            {
                if (Months[i].Bounds.IntersectsWith(e.ClipRectangle))
                {
                    #region MonthTitle

                    string title = Months[i].Date.ToString(MonthTitleFormat);
                    MonthViewBoxEventArgs evtTitle = new MonthViewBoxEventArgs(e.Graphics, Months[i].MonthNameBounds,
                        title,
                        Focused ? MonthTitleTextColour : MonthTitleTextColourInactive,
                        Focused ? MonthTitleColour : MonthTitleColourInactive);

                    DrawBox(evtTitle);

                    #endregion

                    #region DayNames

                    for (int j = 0; j < Months[i].DayNamesBounds.Length; j++)
                    {
                        MonthViewBoxEventArgs evtDay = new MonthViewBoxEventArgs(e.Graphics, Months[i].DayNamesBounds[j], Months[i].DayHeaders[j],
                            StringAlignment.Far, ForeColor, DayBackgroundColour);

                        DrawBox(evtDay);
                    }

                    if (Months[i].DayNamesBounds != null && Months[i].DayNamesBounds.Length != 0)
                    {
                        using (Pen p = new Pen(MonthTitleColour))
                        {
                            int y = Months[i].DayNamesBounds[0].Bottom;
                            e.Graphics.DrawLine(p, new Point(Months[i].Bounds.X, y), new Point(Months[i].Bounds.Right, y));
                        }
                    }
                    #endregion

                    #region Days
                    foreach (MonthViewDay day in Months[i].Days)
                    {
                        if (!day.Visible) continue;

                        MonthViewBoxEventArgs evtDay = new MonthViewBoxEventArgs(e.Graphics, day.Bounds, day.Date.Day.ToString(),
                            StringAlignment.Far,
                            day.Grayed ? DayGrayedText : (day.Selected ? DaySelectedTextColour : ForeColor),
                            day.Selected ? DaySelectedBackgroundColour : DayBackgroundColour);

                        if (day.Date.Equals(DateTime.Now.Date))
                        {
                            evtDay.BorderColour = TodayBorderColour;
                        }

                        DrawBox(evtDay);
                    }
                    #endregion 

                    #region Arrows

                    if (i == 0)
                    {
                        Rectangle r = BackwardButtonBounds;
                        using (Brush b = new SolidBrush(BackwardButtonSelected ? ArrowsSelectedColour : ArrowsColour))
                        {
                            e.Graphics.FillPolygon(b, new Point[] {
                                new Point(r.Right, r.Top),
                                new Point(r.Right, r.Bottom - 1),
                                new Point(r.Left + r.Width / 2, r.Top + r.Height / 2),
                            });
                        }
                    }

                    if (i == _forwardMonthIndex)
                    {
                        Rectangle r = ForwardButtonBounds;
                        using (Brush b = new SolidBrush(ForwardButtonSelected ? ArrowsSelectedColour : ArrowsColour))
                        {
                            e.Graphics.FillPolygon(b, new Point[] {
                                new Point(r.X, r.Top),
                                new Point(r.X, r.Bottom - 1),
                                new Point(r.Left + r.Width / 2, r.Top + r.Height / 2),
                            });
                        }
                    }

                    #endregion
                }
            }
        }

        protected override void OnResize(EventArgs e)
        {
            UpdateMonths();
            Invalidate();
        }

        protected void OnSelectionChanged(EventArgs e)
        {
            if (SelectionChanged != null)
            {
                SelectionChanged(this, e);
            }
        }

        #endregion
    }
}