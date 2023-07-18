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

// ReSharper disable VirtualMemberCallInConstructor
// ReSharper disable UnusedVariable
namespace Krypton.Toolkit.Suite.Extended.Calendar
{
    [DefaultEvent("LoadItems")]
    [ToolboxBitmap(typeof(MonthCalendar))]
    public class KryptonCalendar : ScrollableControl
    {
        #region "Reload Palette"
        private void Calendar_Invalidated(object sender, InvalidateEventArgs e)
        {
            Renderer!.ReloadPalette();
        }
        #endregion

        #region ... Krypton ...
        private PaletteBase? _palette;
        private PaletteRedirect _paletteRedirect;

        //Kripton Palette Events
        private void OnGlobalPaletteChanged(object sender, EventArgs e)
        {
            if (_palette != null)
            {
                _palette.PalettePaint -= OnPalettePaint;
            }

            _palette = KryptonManager.CurrentGlobalPalette;
            _paletteRedirect.Target = _palette;

            if (_palette != null)
            {
                _palette.PalettePaint += OnPalettePaint;
                //repaint with new values

            }
            Renderer?.ReloadPalette();
            Invalidate();
        }

        //Kripton Palette Events
        private void OnPalettePaint(object sender, PaletteLayoutEventArgs e)
        {
            Renderer?.ReloadPalette();
            Invalidate();
        }
        #endregion

        #region Subclasses

        /// <summary>
        /// Possible states of the calendar
        /// </summary>
        public enum CalendarState
        {
            /// <summary>
            /// Nothing happening
            /// </summary>
            Idle,

            /// <summary>
            /// User is currently dragging on view to select a time range
            /// </summary>
            DraggingTimeSelection,

            /// <summary>
            /// User is currently dragging an item among the view
            /// </summary>
            DraggingItem,

            /// <summary>
            /// User is editing an item's Text
            /// </summary>
            EditingItemText,

            /// <summary>
            /// User is currently resizing an item
            /// </summary>
            ResizingItem
        }

        #endregion

        #region Static

        /// <summary>
        /// Returns a value indicating if two date ranges intersect
        /// </summary>
        /// <param name="startA"></param>
        /// <param name="endA"></param>
        /// <param name="startB"></param>
        /// <param name="endB"></param>
        /// <returns></returns>
        public static bool DateIntersects(DateTime startA, DateTime endA, DateTime startB, DateTime endB)
        {
            return startB < endA && startA < endB;
        }

        #endregion

        #region Events

        /// <summary>
        /// Delegate that supports <see cref="LoadItems"/> event
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Event Data</param>
        public delegate void CalendarLoadEventHandler(object sender, CalendarLoadEventArgs e);

        /// <summary>
        /// Delegate that supports item-related events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void CalendarItemEventHandler(object sender, CalendarItemEventArgs e);

        /// <summary>
        /// Delegate that supports cancelable item-related events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void CalendarItemCancelEventHandler(object sender, CalendarItemCancelEventArgs e);

        /// <summary>
        /// Delegate that supports <see cref="CalendarDay"/>-related events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void CalendarDayEventHandler(object sender, CalendarDayEventArgs e);

        /// <summary>
        /// Occurs when items are load into view
        /// </summary>
        [Description("Occurs when items are load into view")]
        public event CalendarLoadEventHandler LoadItems;

        /// <summary>
        /// Occurs when a day header is clicked
        /// </summary>
        [Description("Occurs when a day header is clicked")]
        public event CalendarDayEventHandler DayHeaderClick;

        /// <summary>
        /// Occurs when an item is about to be created.
        /// </summary>
        /// <remarks>
        /// Event can be cancelled
        /// </remarks>
        [Description("Occurs when an item is about to be created.")]
        public event CalendarItemCancelEventHandler ItemCreating;

        /// <summary>
        /// Occurs when an item has been created.
        /// </summary>
        [Description("Occurs when an item has been created.")]
        public event CalendarItemCancelEventHandler ItemCreated;

        /// <summary>
        /// Occurs before an item is deleted
        /// </summary>
        [Description("Occurs before an item is deleted")]
        public event CalendarItemCancelEventHandler ItemDeleting;

        /// <summary>
        /// Occurs when an item has been deleted
        /// </summary>
        [Description("Occurs when an item has been deleted")]
        public event CalendarItemEventHandler ItemDeleted;

        /// <summary>
        /// Occurs when an item text is about to be edited
        /// </summary>
        [Description("Occurs when an item text is about to be edited")]
        public event CalendarItemCancelEventHandler ItemTextEditing;

        /// <summary>
        /// Occurs when an item text is edited
        /// </summary>
        [Description("Occurs when an item text is edited")]
        public event CalendarItemCancelEventHandler ItemTextEdited;

        /// <summary>
        /// Occurs when an item time range has changed
        /// </summary>
        [Description("Occurs when an item time range has changed")]
        public event CalendarItemEventHandler ItemDatesChanged;

        /// <summary>
        /// Occurs when an item is clicked
        /// </summary>
        [Description("Occurs when an item is clicked")]
        public event CalendarItemEventHandler ItemClick;

        /// <summary>
        /// Occurs when an item is double-clicked
        /// </summary>
        [Description("Occurs when an item is double-clicked")]
        public event CalendarItemEventHandler ItemDoubleClick;

        /// <summary>
        /// Occurs when an item is selected
        /// </summary>
        [Description("Occurs when an item is selected")]
        public event CalendarItemEventHandler ItemSelected;

        /// <summary>
        /// Occurs after the items are positioned
        /// </summary>
        /// <remarks>
        /// Items bounds can be altered using the <see cref="CalendarItemAlternative.SetBounds"/> method.
        /// </remarks>
        [Description("Occurs after the items are positioned")]
        public event EventHandler ItemsPositioned;

        /// <summary>
        /// Occurs when the mouse is moved over an item
        /// </summary>
        [Description("Occurs when the mouse is moved over an item")]
        public event CalendarItemEventHandler ItemMouseHover;

        #endregion

        #region Fields
        private KryptonCalendarTextBox? _textBox;
        private bool _allowNew;
        private bool _allowItemEdit;
        private bool _allowItemResize;
        private bool _creatingItem;
        private CalendarDay?[] _days;
        private CalendarDaysMode _daysMode;
        private CalendarItemAlternative? _editModeItem;
        private bool _finalizingEdition;
        private DayOfWeek _firstDayOfWeek;
        private CalendarHighlightRange[] _highlightRanges;
        private CalendarItemCollection _items;
        private string _itemsDateFormat;
        private string _itemsTimeFormat;
        private int _maximumFullDays;
        private int _maximumViewDays;
        private CalendarRenderer? _renderer;
        private DateTime _selEnd;
        private DateTime _selStart;
        private CalendarState _state;
        private CalendarTimeScale _timeScale;
        private int _timeUnitsOffset;
        private DateTime _viewEnd;
        private DateTime _viewStart;
        private CalendarWeek[] _weeks;
        private List<CalendarSelectableElement?> _selectedElements;
        private ICalendarSelectableElement? _selectedElementEnd;
        private ICalendarSelectableElement? _selectedElementStart;
        private Rectangle _selectedElementSquare;
        private CalendarItemAlternative? _itemOnState;
        private bool _itemOnStateChanged;
        #endregion

        #region Ctor

        /// <summary>
        /// Creates a new <see cref="KryptonCalendar"/> control
        /// </summary>
        public KryptonCalendar()
        {
            AutoSize = true;

            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.Selectable, true);

            DoubleBuffered = true;

            _selectedElements = new List<CalendarSelectableElement?>();
            _items = new CalendarItemCollection(this);
            //_renderer = new CalendarProfessionalRenderer(this);
            _renderer = new CalendarKryptonRenderer(this);
            _maximumFullDays = 8;
            _maximumViewDays = 35;

            HighlightRanges = new[] {
                new CalendarHighlightRange( DayOfWeek.Monday, new TimeSpan(8,0,0), new TimeSpan(17,0,0)),
                new CalendarHighlightRange( DayOfWeek.Tuesday, new TimeSpan(8,0,0), new TimeSpan(17,0,0)),
                new CalendarHighlightRange( DayOfWeek.Wednesday, new TimeSpan(8,0,0), new TimeSpan(17,0,0)),
                new CalendarHighlightRange( DayOfWeek.Thursday, new TimeSpan(8,0,0), new TimeSpan(17,0,0)),
                new CalendarHighlightRange( DayOfWeek.Friday, new TimeSpan(8,0,0), new TimeSpan(17,0,0)),
            };

            _timeScale = CalendarTimeScale.ThirtyMinutes;
            SetViewRange(DateTime.Now, DateTime.Now.AddDays(2));

            InvalidateEventHandler ieh = Calendar_Invalidated;

            // add Palette Handler
            if (_palette != null)
            {
                _palette.PalettePaint += OnPalettePaint;
            }

            KryptonManager.GlobalPaletteChanged += OnGlobalPaletteChanged;

            _palette = KryptonManager.CurrentGlobalPalette;
            _paletteRedirect = new PaletteRedirect(_palette);

            _itemsDateFormat = "dd/MMM";
            _itemsTimeFormat = "hh:mm tt";
            _allowItemEdit = true;
            _allowNew = true;
            _allowItemResize = true;



        }


        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating if the control let's the user create new items.
        /// </summary>
        [DefaultValue(true)]
        [Description("Allows the user to create new items on the view")]
        public bool AllowNew
        {
            get => _allowNew;
            set => _allowNew = value;
        }

        /// <summary>
        /// Gets or sets a value indicating if the user can edit the item using the mouse or keyboard
        /// </summary>
        [DefaultValue(true)]
        [Description("Allows or denies the user the edition of items text or date ranges.")]
        public bool AllowItemEdit
        {
            get => _allowItemEdit;
            set => _allowItemEdit = value;
        }

        /// <summary>
        /// Gets or sets a value indicating if calendar allows user to resize the calendar.
        /// </summary>
        [DefaultValue(true)]
        [Description("Allows or denies the user to resize items on the calendar")]
        public bool AllowItemResize
        {
            get => _allowItemResize;
            set => _allowItemResize = value;
        }

        /// <summary>
        /// Gets the days visible on the ccurrent view
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CalendarDay?[] Days => _days;

        /// <summary>
        /// Gets the mode in which days are drawn.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CalendarDaysMode DaysMode => _daysMode;

        /// <summary>
        /// Gets the union of day body rectangles
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Rectangle DaysBodyRectangle
        {
            get
            {
                Rectangle first = Days[0]!.BodyBounds;
                Rectangle last = Days[Days.Length - 1]!.BodyBounds;

                return Rectangle.Union(first, last);
            }
        }

        /// <summary>
        /// Gets if the calendar is currently in edit mode of some item
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool EditMode => TextBox != null;

        /// <summary>
        /// Gets the item being edited (if any)
        /// </summary>
        public CalendarItemAlternative? EditModeItem => _editModeItem;

        /// <summary>
        /// Gets or sets the first day of weeks
        /// </summary>
        [Description("Starting day of weeks")]
        [DefaultValue(DayOfWeek.Sunday)]
        public DayOfWeek FirstDayOfWeek
        {
            set => _firstDayOfWeek = value;
            get => _firstDayOfWeek;
        }


        /// <summary>
        /// Gets or sets the time ranges that should be highlighted as work-time.
        /// This ranges are week based.
        /// </summary>
        public CalendarHighlightRange[] HighlightRanges
        {
            get => _highlightRanges;
            set { _highlightRanges = value; UpdateHighlights(); }
        }

        /// <summary>
        /// Gets the collection of items currently on the view.
        /// </summary>
        /// <remarks>
        /// This collection changes every time the view is changed
        /// </remarks>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CalendarItemCollection Items => _items;

        /// <summary>
        /// Gets or sets the format in which time is shown in the items, when applicable
        /// </summary>
        [DefaultValue("dd/MMM")]
        public string ItemsDateFormat
        {
            get => _itemsDateFormat;
            set => _itemsDateFormat = value;
        }

        /// <summary>
        /// Gets or sets the format in which time is shown in the items, when applicable
        /// </summary>
        [DefaultValue("hh:mm tt")]
        public string ItemsTimeFormat
        {
            get => _itemsTimeFormat;
            set => _itemsTimeFormat = value;
        }

        /// <summary>
        /// Gets or sets the maximum full days shown on the view. 
        /// After this amount of days, they will be shown as short days.
        /// </summary>
        [DefaultValue(8)]
        public int MaximumFullDays
        {
            get => _maximumFullDays;
            set => _maximumFullDays = value;
        }

        /// <summary>
        /// Gets or sets the maximum amount of days supported by the view.
        /// Value must be multiple of 7
        /// </summary>
        [DefaultValue(35)]
        public int MaximumViewDays
        {
            get => _maximumViewDays;
            set
            {
                if (value % 7 != 0)
                {
                    throw new Exception("MaximumViewDays must be multiple of 7");
                }
                _maximumViewDays = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="CalendarRenderer"/> of the <see cref="Calendar"/>
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CalendarRenderer? Renderer
        {
            get => _renderer;
            set
            {
                _renderer = value;

                if (value != null && Created)
                {
                    value.OnInitialize(new CalendarRendererEventArgs(null, null, Rectangle.Empty));
                }
            }
        }

        /// <summary>
        /// Gets the last selected element
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ICalendarSelectableElement? SelectedElementEnd
        {
            get => _selectedElementEnd;
            set
            {
                _selectedElementEnd = value;

                UpdateSelectionElements();
            }
        }

        /// <summary>
        /// Gets the first selected element
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ICalendarSelectableElement? SelectedElementStart
        {
            get => _selectedElementStart;
            set
            {
                _selectedElementStart = value;

                UpdateSelectionElements();
            }
        }

        /// <summary>
        /// Gets or sets the end date-time of the view's selection.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime SelectionEnd
        {
            get => _selEnd;
            set => _selEnd = value;
        }

        /// <summary>
        /// Gets or sets the start date-time of the view's selection.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime SelectionStart
        {
            get => _selStart;
            set => _selStart = value;
        }

        /// <summary>
        /// Gets or sets the state of the calendar
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CalendarState State => _state;

        /// <summary>
        /// Gets the TextBox of the edit mode
        /// </summary>
        internal KryptonCalendarTextBox? TextBox
        {
            get => _textBox;
            set => _textBox = value;
        }

        /// <summary>
        /// Gets or sets the <see cref="CalendarTimeScale"/> for visualization.
        /// </summary>
        [DefaultValue(CalendarTimeScale.ThirtyMinutes)]
        public CalendarTimeScale TimeScale
        {
            get => _timeScale;
            set
            {
                _timeScale = value;

                for (int i = 0; i < Days.Length; i++)
                {
                    Days[i]!.UpdateUnits();
                }

                Renderer!.PerformLayout();
                Refresh();
            }
        }

        /// <summary>
        /// Gets or sets the offset of scrolled units
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int TimeUnitsOffset
        {
            get => _timeUnitsOffset;
            set
            {
                _timeUnitsOffset = value;
                Renderer!.PerformLayout();
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the end date-time of the current view.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime ViewEnd
        {
            get => _viewEnd;
            set
            {
                _viewEnd = value.Date.Add(new TimeSpan(23, 59, 59));
                ClearItems();
                UpdateDaysAndWeeks();
                Renderer!.PerformLayout();
                Invalidate();
                ReloadItems();
            }
        }

        /// <summary>
        /// Gets or sets the start date-time of the current view.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime ViewStart
        {
            get => _viewStart;
            set
            {
                _viewStart = value.Date;
                ClearItems();
                UpdateDaysAndWeeks();
                Renderer!.PerformLayout();
                Invalidate();
                ReloadItems();
            }
        }

        /// <summary>
        /// Gets the weeks currently visible on the calendar, if <see cref="DaysMode"/> is <see cref="CalendarDaysMode.Short"/>
        /// </summary>
        public CalendarWeek[] Weeks => _weeks;

        #endregion

        #region Public Methods

        /// <summary>
        /// Activates the edit mode on the first selected item
        /// </summary>
        public void ActivateEditMode()
        {
            foreach (CalendarItemAlternative? item in Items)
            {
                if (item.Selected)
                {
                    ActivateEditMode(item);
                    return;
                }
            }
        }

        /// <summary>
        /// Activates the edit mode on the specified item
        /// </summary>
        /// <param name="item"></param>
        public void ActivateEditMode(CalendarItemAlternative? item)
        {
            CalendarItemCancelEventArgs evt = new CalendarItemCancelEventArgs(item);

            if (!_creatingItem)
            {
                OnItemEditing(evt);
            }

            if (evt.Cancel)
            {
                return;
            }

            _editModeItem = item;
            TextBox = new KryptonCalendarTextBox(this);
            TextBox.KeyDown += TextBox_KeyDown;
            TextBox.LostFocus += TextBox_LostFocus;
            if (item != null)
            {
                Rectangle r = item.Bounds;
                r.Inflate(-2, -2);
                TextBox.Bounds = r;
            }

            //TextBox.BorderStyle = BorderStyle.None;
            TextBox.Text = item?.Text;
            TextBox.Multiline = true;

            Controls.Add(TextBox);
            TextBox.Visible = true;
            TextBox.Focus();
            TextBox.SelectionStart = TextBox.Text.Length;

            SetState(CalendarState.EditingItemText);
        }

        /// <summary>
        /// Creates a new item on the current selection. 
        /// If there's no selection, this will be ignored.
        /// </summary>
        /// <param name="itemText">Text of the item</param>
        /// <param name="editMode">If <c>true</c> activates the edit mode so user can edit the text of the item.</param>
        public void CreateItemOnSelection(string? itemText, bool editMode)
        {
            if (SelectedElementEnd == null || SelectedElementStart == null)
            {
                return;
            }

            CalendarTimeScaleUnit? unitEnd = SelectedElementEnd as CalendarTimeScaleUnit;
            CalendarDayTop? dayTop = SelectedElementEnd as CalendarDayTop;
            CalendarDay? day = SelectedElementEnd as CalendarDay;
            TimeSpan duration = unitEnd != null ? unitEnd.Duration : new TimeSpan(23, 59, 59);
            CalendarItemAlternative item = new CalendarItemAlternative(this);

            DateTime dstart = SelectedElementStart.Date;
            DateTime dend = SelectedElementEnd.Date;

            if (dend.CompareTo(dstart) < 0)
            {
                DateTime dtmp = dend;
                dend = dstart;
                dstart = dtmp;
            }

            item.StartDate = dstart;
            item.EndDate = dend.Add(duration);
            item.Text = itemText;

            CalendarItemCancelEventArgs evtA = new CalendarItemCancelEventArgs(item);

            OnItemCreating(evtA);

            if (!evtA.Cancel)
            {
                Items.Add(item);

                if (editMode)
                {
                    _creatingItem = true;
                    ActivateEditMode(item);
                }
            }


        }

        /// <summary>
        /// Ensures the scrolling shows the specified time unit. It doesn't affect View date ranges.
        /// </summary>
        /// <param name="unit">Unit to ensure visibility</param>
        public void EnsureVisible(CalendarTimeScaleUnit? unit)
        {
            if (Days.Length == 0)
            {
                return;
            }

            Rectangle view = Days[0]!.BodyBounds;

            if (unit != null)
            {
                if (unit.Bounds.Bottom > view.Bottom)
                {
                    if (Renderer != null)
                    {
                        TimeUnitsOffset =
                            -Convert.ToInt32(Math.Ceiling(unit.Date.TimeOfDay.TotalMinutes / (double)TimeScale))
                            + Renderer.GetVisibleTimeUnits();
                    }
                }
                else if (unit.Bounds.Top < view.Top)
                {
                    TimeUnitsOffset = -Convert.ToInt32(Math.Ceiling(unit.Date.TimeOfDay.TotalMinutes / (double)TimeScale));
                }
            }
        }

        /// <summary>
        /// Finalizes editing the <see cref="EditModeItem"/>.
        /// </summary>
        /// <param name="cancel">Value indicating if edition of item should be canceled.</param>
        public void FinalizeEditMode(bool cancel)
        {
            if (!EditMode || EditModeItem == null || _finalizingEdition)
            {
                return;
            }

            _finalizingEdition = true;

            if (_editModeItem != null)
            {
                string? cancelText = _editModeItem.Text;
                CalendarItemAlternative? itemBuffer = _editModeItem;
                _editModeItem = null;
                CalendarItemCancelEventArgs evt = new CalendarItemCancelEventArgs(itemBuffer);

                if (!cancel)
                {
                    if (TextBox != null)
                    {
                        itemBuffer.Text = TextBox.Text.Trim();
                    }
                }

                if (TextBox != null)
                {
                    TextBox.Visible = false;
                    Controls.Remove(TextBox);
                    TextBox.Dispose();
                }

                if (_editModeItem != null)
                {
                    Invalidate(itemBuffer);
                }

                _textBox = null;

                if (_creatingItem)
                {
                    OnItemCreated(evt);
                }
                else
                {
                    OnItemEdited(evt);
                }

                if (evt.Cancel)
                {
                    itemBuffer.Text = cancelText;
                }
            }


            _creatingItem = false;
            _finalizingEdition = false;

            if (State == CalendarState.EditingItemText)
            {
                SetState(CalendarState.Idle);
            }
        }

        /// <summary>
        /// Finds the <see cref="CalendarDay"/> for the specified date, if in the view.
        /// </summary>
        /// <param name="d">Date to find day</param>
        /// <returns><see cref="CalendarDay"/> object that matches the date, <c>null</c> if day was not found.</returns>
        public CalendarDay? FindDay(DateTime d)
        {
            for (int i = 0; i < Days.Length; i++)
            {
                if (Days[i]!.Date.Date.Equals(d.Date.Date))
                {
                    return Days[i];
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the items that are currently selected
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CalendarItemAlternative> GetSelectedItems()
        {
            List<CalendarItemAlternative> items = new List<CalendarItemAlternative>();

            foreach (CalendarItemAlternative item in Items)
            {
                if (item.Selected)
                {
                    items.Add(item);
                }
            }

            return items;
        }

        /// <summary>
        /// Gets the time unit that starts with the specified date
        /// </summary>
        /// <param name="d">Date and time of the unit you want to extract</param>
        /// <returns>Matching time unit. <c>null</c> If out of range.</returns>
        public CalendarTimeScaleUnit? GetTimeUnit(DateTime d)
        {
            foreach (CalendarDay? day in Days)
            {
                if (day != null && day.Date.Equals(d.Date))
                {
                    double duration = Convert.ToDouble((int)TimeScale);
                    int index =
                        Convert.ToInt32(
                            Math.Floor(
                                d.TimeOfDay.TotalMinutes / duration
                            )
                        );

                    return day.TimeUnits[index];
                }
            }

            return null;
        }

        /// <summary>
        /// Searches for the first hitted <see cref="ICalendarSelectableElement"/>
        /// </summary>
        /// <param name="p">Point to check for hit test</param>
        /// <returns></returns>
        public ICalendarSelectableElement? HitTest(Point p)
        {
            return HitTest(p, false);
        }

        /// <summary>
        /// Searches for the first hitted <see cref="ICalendarSelectableElement"/>
        /// </summary>
        /// <param name="p">Point to check for hit test</param>
        /// <param name="ignoreItems"></param>
        /// <returns></returns>
        public ICalendarSelectableElement? HitTest(Point p, bool ignoreItems)
        {
            if (!ignoreItems)
            {
                foreach (CalendarItemAlternative? item in Items)
                {
                    foreach (Rectangle r in item.GetAllBounds())
                    {
                        if (r.Contains(p))
                        {
                            return item;
                        }
                    }
                }
            }

            for (int i = 0; i < Days.Length; i++)
            {
                if (Days[i]!.Bounds.Contains(p))
                {
                    if (DaysMode == CalendarDaysMode.Expanded)
                    {
                        if (Days[i]!.DayTop!.Bounds.Contains(p))
                        {
                            return Days[i]!.DayTop;
                        }
                        else
                        {
                            for (int j = 0; j < Days[i]!.TimeUnits.Length; j++)
                            {
                                if (Days[i]!.TimeUnits[j]!.Visible &&
                                    Days[i]!.TimeUnits[j]!.Bounds.Contains(p))
                                {
                                    return Days[i]!.TimeUnits[j];
                                }
                            }
                        }

                        return Days[i];
                    }
                    else if (DaysMode == CalendarDaysMode.Short)
                    {
                        return Days[i];
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Returns the item hitted at the specified location. Null if no item hitted.
        /// </summary>
        /// <param name="p">Location to serach for items</param>
        /// <returns>Hitted item at the location. Null if no item hitted.</returns>
        public CalendarItemAlternative? ItemAt(Point p)
        {
            return HitTest(p) as CalendarItemAlternative;
        }

        /// <summary>
        /// Invalidates the bounds of the specified day
        /// </summary>
        /// <param name="day"></param>
        public void Invalidate(CalendarDay day)
        {
            Invalidate(day.Bounds);
        }

        /// <summary>
        /// Ivalidates the bounds of the specified unit
        /// </summary>
        /// <param name="unit"></param>
        public void Invalidate(CalendarTimeScaleUnit unit)
        {
            Invalidate(unit.Bounds);
        }

        /// <summary>
        /// Invalidates the area of the specified item
        /// </summary>
        /// <param name="item"></param>
        public void Invalidate(CalendarItemAlternative? item)
        {
            if (item != null)
            {
                Rectangle r = item.Bounds;

                foreach (Rectangle bounds in item.GetAllBounds())
                {
                    r = Rectangle.Union(r, bounds);
                }

                r.Inflate(Renderer!.ItemShadowPadding + Renderer.ItemInvalidateMargin, Renderer.ItemShadowPadding + Renderer.ItemInvalidateMargin);
                Invalidate(r);
            }
        }

        /// <summary>
        /// Establishes the selection range with only one graphical update.
        /// </summary>
        /// <param name="selectionStart">Fisrt selected element</param>
        /// <param name="selectionEnd">Last selection element</param>
        public void SetSelectionRange(ICalendarSelectableElement? selectionStart, ICalendarSelectableElement? selectionEnd)
        {
            _selectedElementStart = selectionStart;
            SelectedElementEnd = selectionEnd;
        }

        /// <summary>
        /// Sets the value of <see cref="ViewStart"/> and <see cref="ViewEnd"/> properties
        /// triggering only one repaint process
        /// </summary>
        /// <param name="dateStart">Start date of view</param>
        /// <param name="dateEnd">End date of view</param>
        public void SetViewRange(DateTime dateStart, DateTime dateEnd)
        {
            _viewStart = dateStart.Date;
            ViewEnd = dateEnd;
        }

        /// <summary>
        /// Returns a value indicating if the view range intersects the specified date range.
        /// </summary>
        /// <param name="dateStart"></param>
        /// <param name="dateEnd"></param>
        public bool ViewIntersects(DateTime dateStart, DateTime dateEnd)
        {
            return DateIntersects(ViewStart, ViewEnd, dateStart, dateEnd);
        }

        /// <summary>
        /// Returns a value indicating if the view range intersect the date range of the specified item
        /// </summary>
        /// <param name="item"></param>
        public bool ViewIntersects(CalendarItemAlternative item)
        {
            return ViewIntersects(item.StartDate, item.EndDate);
        }

        #endregion

        #region Private Methods

        protected override bool IsInputKey(Keys keyData)
        {
            if (
                keyData == Keys.Down ||
                keyData == Keys.Up ||
                keyData == Keys.Right ||
                keyData == Keys.Left)
            {
                return true;
            }
            else
            {

                return base.IsInputKey(keyData);
            }
        }

        /// <summary>
        /// Removes all the items currently on the calendar
        /// </summary>
        private void ClearItems()
        {
            Items.Clear();
            Renderer!.DayTopHeight = Renderer.DayTopMinHeight;
        }

        /// <summary>
        /// Unselects the selected items
        /// </summary>
        private void ClearSelectedItems()
        {
            Rectangle r = Rectangle.Empty;

            foreach (CalendarItemAlternative item in Items)
            {
                if (item.Selected)
                {
                    if (r.IsEmpty)
                    {
                        r = item.Bounds;
                    }
                    else
                    {
                        r = Rectangle.Union(r, item.Bounds);
                    }
                }

                item.SetSelected(false);
            }

            Invalidate(r);
        }

        /// <summary>
        /// Deletes the currently selected item
        /// </summary>
        private void DeleteSelectedItems()
        {
            Stack<CalendarItemAlternative?> toDelete = new Stack<CalendarItemAlternative?>();

            foreach (CalendarItemAlternative? item in Items)
            {
                if (item.Selected)
                {
                    CalendarItemCancelEventArgs evt = new CalendarItemCancelEventArgs(item);

                    OnItemDeleting(evt);

                    if (!evt.Cancel)
                    {
                        toDelete.Push(item);
                    }
                }
            }

            if (toDelete.Count > 0)
            {
                while (toDelete.Count > 0)
                {
                    CalendarItemAlternative? item = toDelete.Pop();

                    Items.Remove(item);

                    OnItemDeleted(new CalendarItemEventArgs(item));
                }

                Renderer!.PerformItemsLayout();
            }
        }

        /// <summary>
        /// Clears current items and reloads for specified view
        /// </summary>
        private void ReloadItems() => OnLoadItems(new CalendarLoadEventArgs(this, ViewStart, ViewEnd));

        /// <summary>
        /// Grows the rectangle to repaint currently selected elements
        /// </summary>
        /// <param name="rect"></param>
        private void GrowSquare(Rectangle rect)
        {
            if (_selectedElementSquare.IsEmpty)
            {
                _selectedElementSquare = rect;
            }
            else
            {
                _selectedElementSquare = Rectangle.Union(_selectedElementSquare, rect);
            }
        }

        /// <summary>
        /// Clears selection of currently selected components (As quick as possible)
        /// </summary>
        private void ClearSelectedComponents()
        {
            foreach (CalendarSelectableElement? element in _selectedElements)
            {
                if (element != null)
                {
                    element.SetSelected(false);
                }
            }

            _selectedElements.Clear();

            Invalidate(_selectedElementSquare);
            _selectedElementSquare = Rectangle.Empty;

        }

        /// <summary>
        /// Scrolls the calendar using the specified delta
        /// </summary>
        /// <param name="delta"></param>
        private void ScrollCalendar(int delta)
        {
            if (delta < 0)
            {
                SetViewRange(ViewStart.AddDays(7), ViewEnd.AddDays(7));
            }
            else
            {
                SetViewRange(ViewStart.AddDays(-7), ViewEnd.AddDays(-7));
            }
        }

        /// <summary>
        /// Raises the <see cref="ItemsPositioned"/> event
        /// </summary>
        internal void RaiseItemsPositioned()
        {
            OnItemsPositioned(EventArgs.Empty);
        }

        /// <summary>
        /// Scrolls the time units using the specified delta
        /// </summary>
        /// <param name="delta"></param>
        private void ScrollTimeUnits(int delta)
        {
            int possible = TimeUnitsOffset;
            if (Renderer != null)
            {
                int visible = Renderer.GetVisibleTimeUnits();

                if (delta < 0)
                {
                    possible--;
                }
                else
                {
                    possible++;
                }

                if (possible > 0)
                {
                    possible = 0;
                }
                else if (
                    Days.Length > 0
                    && Days[0]?.TimeUnits != null
                    && possible * -1 >= Days[0]?.TimeUnits.Length)
                {
                    possible = Days[0]!.TimeUnits.Length - 1;
                    possible *= -1;
                }
                else if (Days.Length > 0
                         && Days[0]?.TimeUnits != null)
                {
                    int max = Days[0]!.TimeUnits.Length - visible;
                    max *= -1;
                    if (possible < max)
                    {
                        possible = max;
                    }
                }
            }

            if (possible != TimeUnitsOffset)
            {
                TimeUnitsOffset = possible;
            }
        }

        /// <summary>
        /// Sets the value of the <see cref="DaysMode"/> property.
        /// </summary>
        /// <param name="mode">Mode in which days will be rendered</param>
        private void SetDaysMode(CalendarDaysMode mode)
        {
            _daysMode = mode;
        }

        /// <summary>
        /// Sets the value of the <see cref="State"/> property
        /// </summary>
        /// <param name="state">Current state of the calendar</param>
        private void SetState(CalendarState state)
        {
            _state = state;
        }

        /// <summary>
        /// Handles the LostFocus event of the TextBox that edit items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_LostFocus(object sender, EventArgs e)
        {
            FinalizeEditMode(false);
        }

        /// <summary>
        /// Handles the Keydown event of the TextBox that edit items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                FinalizeEditMode(true);
            }
            else if (e.KeyCode == Keys.Enter)
            {
                FinalizeEditMode(false);
            }
        }

        /// <summary>
        /// Updates the 
        /// </summary>
        private void UpdateDaysAndWeeks()
        {
            TimeSpan span = (new DateTime(ViewEnd.Year, ViewEnd.Month, ViewEnd.Day, 23, 59, 59)).Subtract(ViewStart.Date);
            int preDays = 0;
            span = span.Add(new TimeSpan(0, 0, 0, 1, 0));

            if (span.Days < 1 || span.Days > MaximumViewDays)
            {
                throw new Exception("Days between ViewStart and ViewEnd should be between 1 and MaximumViewDays");
            }

            if (span.Days > MaximumFullDays)
            {
                SetDaysMode(CalendarDaysMode.Short);
                preDays = (new[] { 0, 1, 2, 3, 4, 5, 6 })[(int)ViewStart.DayOfWeek] - (int)FirstDayOfWeek;
                span = span.Add(new TimeSpan(preDays, 0, 0, 0));

                while (span.Days % 7 != 0)
                    span = span.Add(new TimeSpan(1, 0, 0, 0));
            }
            else
            {
                SetDaysMode(CalendarDaysMode.Expanded);
            }

            _days = new CalendarDay?[span.Days];

            for (int i = 0; i < Days.Length; i++)
                Days[i] = new CalendarDay(this, ViewStart.AddDays(-preDays + i), i);


            //Weeks
            if (DaysMode == CalendarDaysMode.Short)
            {
                List<CalendarWeek> weeks = new List<CalendarWeek>();

                for (int i = 0; i < Days.Length; i++)
                {
                    if (Days[i]!.Date.DayOfWeek == FirstDayOfWeek)
                    {
                        weeks.Add(new CalendarWeek(this, Days[i]!.Date));
                    }
                }

                _weeks = weeks.ToArray();
            }
            else
            {
                _weeks = new CalendarWeek[] { };
            }

            UpdateHighlights();

        }

        /// <summary>
        /// Updates the value of the <see cref="CalendarTimeScaleUnit.Highlighted"/> property on the time units of days.
        /// </summary>
        internal void UpdateHighlights()
        {
            for (int i = 0; i < Days.Length; i++)
            {
                Days[i]!.UpdateHighlights();
            }
        }

        /// <summary>
        /// Informs elements who's selected and who's not, and repaints <see cref="_selectedElementSquare"/>
        /// </summary>
        private void UpdateSelectionElements()
        {
            CalendarTimeScaleUnit? unitStart = _selectedElementStart as CalendarTimeScaleUnit;
            CalendarDayTop? topStart = _selectedElementStart as CalendarDayTop;
            CalendarDay? dayStart = _selectedElementStart as CalendarDay;
            CalendarTimeScaleUnit? unitEnd = _selectedElementEnd as CalendarTimeScaleUnit;
            CalendarDayTop? topEnd = _selectedElementEnd as CalendarDayTop;
            CalendarDay? dayEnd = _selectedElementEnd as CalendarDay;

            ClearSelectedComponents();

            if (_selectedElementEnd == null || _selectedElementStart == null)
            {
                return;
            }

            if (SelectedElementStart != null && _selectedElementEnd.CompareTo(SelectedElementStart) < 0)
            {
                //swap
                unitStart = _selectedElementEnd as CalendarTimeScaleUnit;
                topStart = _selectedElementEnd as CalendarDayTop;
                dayStart = _selectedElementEnd as CalendarDay;
                unitEnd = SelectedElementStart as CalendarTimeScaleUnit;
                topEnd = SelectedElementStart as CalendarDayTop;
                dayEnd = _selectedElementStart as CalendarDay;
            }

            if (unitStart != null && unitEnd != null)
            {
                bool reached = false;
                for (int i = unitStart.Day.Index; !reached; i++)
                {
                    for (int j = (i == unitStart.Day.Index ? unitStart.Index : 0); i < Days.Length && j < Days[i]!.TimeUnits.Length; j++)
                    {
                        CalendarTimeScaleUnit? unit = Days[i]!.TimeUnits[j];
                        if (unit != null)
                        {
                            unit.SetSelected(true);
                            GrowSquare(unit.Bounds);
                            _selectedElements.Add(unit);

                            if (unit.Equals(unitEnd))
                            {
                                reached = true;
                                break;
                            }
                        }
                    }
                }
            }
            else if (topStart != null && topEnd != null)
            {
                for (int i = topStart.Day.Index; i <= topEnd.Day.Index; i++)
                {
                    CalendarDayTop? top = Days[i]!.DayTop;

                    if (top != null)
                    {
                        top.SetSelected(true);
                        GrowSquare(top.Bounds);
                        _selectedElements.Add(top);
                    }
                }
            }
            else if (dayStart != null && dayEnd != null)
            {
                for (int i = dayStart.Index; i <= dayEnd.Index; i++)
                {
                    CalendarDay? day = Days[i];

                    if (day != null)
                    {
                        day.SetSelected(true);
                        GrowSquare(day.Bounds);
                        _selectedElements.Add(day);
                    }
                }
            }

            Invalidate(_selectedElementSquare);
        }

        #endregion

        #region Overrided Events and Raisers

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            Renderer!.OnInitialize(new CalendarRendererEventArgs(new CalendarRendererEventArgs(this, null, Rectangle.Empty)));
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            Select();
        }

        protected override void OnDoubleClick(EventArgs e)
        {
            base.OnDoubleClick(e);

            CreateItemOnSelection(string.Empty, true);
        }

        protected virtual void OnDayHeaderClick(CalendarDayEventArgs e)
        {
            DayHeaderClick(this, e);
        }

        protected virtual void OnItemClick(CalendarItemEventArgs e)
        {
            ItemClick(this, e);
        }

        protected virtual void OnItemCreating(CalendarItemCancelEventArgs e)
        {
            ItemCreating(this, e);
        }

        protected virtual void OnItemCreated(CalendarItemCancelEventArgs e)
        {
            ItemCreated(this, e);
        }

        protected virtual void OnItemDeleting(CalendarItemCancelEventArgs e)
        {
            ItemDeleting(this, e);
        }

        protected virtual void OnItemDeleted(CalendarItemEventArgs e)
        {
            ItemDeleted(this, e);
        }

        protected virtual void OnItemDoubleClick(CalendarItemEventArgs e)
        {
            ItemDoubleClick(this, e);
        }

        protected virtual void OnItemEditing(CalendarItemCancelEventArgs e)
        {
            ItemTextEditing(this, e);
        }

        protected virtual void OnItemEdited(CalendarItemCancelEventArgs e)
        {
            ItemTextEdited(this, e);
        }

        protected virtual void OnItemSelected(CalendarItemEventArgs e)
        {
            ItemSelected(this, e);
        }

        protected virtual void OnItemsPositioned(EventArgs e)
        {
            ItemsPositioned(this, e);
        }

        protected virtual void OnItemDatesChanged(CalendarItemEventArgs e)
        {
            ItemDatesChanged(this, e);
        }

        protected virtual void OnItemMouseHover(CalendarItemEventArgs e)
        {
            ItemMouseHover(this, e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            bool shiftPressed = (ModifierKeys & Keys.Shift) == Keys.Shift;
            int jump = (int)TimeScale;
            ICalendarSelectableElement? sStart = null;
            ICalendarSelectableElement? sEnd = null;

            if (e.KeyCode == Keys.F2)
            {
                ActivateEditMode();
            }
            else if (e.KeyCode == Keys.Delete)
            {
                DeleteSelectedItems();
            }
            else if (e.KeyCode == Keys.Insert)
            {
                if (AllowNew)
                {
                    CreateItemOnSelection(string.Empty, true);
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (e.Shift)
                {
                    sStart = SelectedElementStart;
                }

                if (SelectedElementEnd != null)
                {
                    sEnd = GetTimeUnit(SelectedElementEnd.Date.Add(new TimeSpan(0, (int)TimeScale, 0)));
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (e.Shift)
                {
                    sStart = SelectedElementStart;
                }

                if (SelectedElementEnd != null)
                {
                    sEnd = GetTimeUnit(SelectedElementEnd.Date.Add(new TimeSpan(0, -(int)TimeScale, 0)));
                }
            }
            else if (e.KeyCode == Keys.Right)
            {
                if (SelectedElementEnd != null)
                {
                    sEnd = GetTimeUnit(SelectedElementEnd.Date.Add(new TimeSpan(24, 0, 0)));
                }
            }
            else if (e.KeyCode == Keys.Left)
            {
                if (SelectedElementEnd != null)
                {
                    sEnd = GetTimeUnit(SelectedElementEnd.Date.Add(new TimeSpan(-24, 0, 0)));
                }
            }
            else if (e.KeyCode == Keys.PageDown)
            {

            }
            else if (e.KeyCode == Keys.PageUp)
            {

            }


            if (sStart != null)
            {
                SetSelectionRange(sStart, sEnd);
            }
            else if (sEnd != null)
            {
                SetSelectionRange(sEnd, sEnd);

                if (sEnd is CalendarTimeScaleUnit)
                {
                    EnsureVisible(sEnd as CalendarTimeScaleUnit);
                }
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            if (AllowNew)
            {
                CreateItemOnSelection(e.KeyChar.ToString(), true);
            }
        }

        protected virtual void OnLoadItems(CalendarLoadEventArgs e)
        {
            LoadItems(this, e);
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            base.OnMouseDoubleClick(e);

            CalendarItemAlternative? item = ItemAt(e.Location);

            if (item != null)
            {
                OnItemDoubleClick(new CalendarItemEventArgs(item));
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            ICalendarSelectableElement? hitted = HitTest(e.Location);
            CalendarItemAlternative? hittedItem = hitted as CalendarItemAlternative;
            bool shiftPressed = (ModifierKeys & Keys.Shift) == Keys.Shift;

            if (!Focused)
            {
                Focus();
            }

            switch (State)
            {
                case CalendarState.Idle:
                    if (hittedItem != null)
                    {
                        if (!shiftPressed)
                        {
                            ClearSelectedItems();
                        }

                        hittedItem.SetSelected(true);
                        Invalidate(hittedItem);
                        OnItemSelected(new CalendarItemEventArgs(hittedItem));

                        _itemOnState = hittedItem;
                        _itemOnStateChanged = false;

                        if (AllowItemEdit)
                        {
                            if (_itemOnState.ResizeStartDateZone(e.Location) && AllowItemResize)
                            {
                                SetState(CalendarState.ResizingItem);
                                _itemOnState.SetIsResizingStartDate(true);
                            }
                            else if (_itemOnState.ResizeEndDateZone(e.Location) && AllowItemResize)
                            {
                                SetState(CalendarState.ResizingItem);
                                _itemOnState.SetIsResizingEndDate(true);
                            }
                            else
                            {
                                SetState(CalendarState.DraggingItem);
                            }
                        }

                        SetSelectionRange(null, null);
                    }
                    else
                    {
                        ClearSelectedItems();

                        if (shiftPressed)
                        {
                            if (SelectedElementEnd != null && hitted != null && SelectedElementEnd == null && !SelectedElementEnd!.Equals(hitted))
                            {
                                SelectedElementEnd = hitted;
                            }
                        }
                        else
                        {
                            if (SelectedElementStart == null || (hitted != null && !SelectedElementStart.Equals(hitted)))
                            {
                                SetSelectionRange(hitted, hitted);
                            }
                        }

                        SetState(CalendarState.DraggingTimeSelection);
                    }
                    break;
                case CalendarState.DraggingTimeSelection:
                    break;
                case CalendarState.DraggingItem:
                    break;
                case CalendarState.ResizingItem:
                    break;
                case CalendarState.EditingItemText:
                    break;

            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            ICalendarSelectableElement? hitted = HitTest(e.Location, State != CalendarState.Idle);
            CalendarItemAlternative? hittedItem = hitted as CalendarItemAlternative;
            CalendarDayTop? hittedTop = hitted as CalendarDayTop;
            bool shiftPressed = (ModifierKeys & Keys.Shift) == Keys.Shift;

            if (hitted != null)
            {
                switch (State)
                {
                    case CalendarState.Idle:
                        Cursor should = Cursors.Default;

                        if (hittedItem != null)
                        {
                            if ((hittedItem.ResizeEndDateZone(e.Location) || hittedItem.ResizeStartDateZone(e.Location)) && AllowItemResize)
                            {
                                should = hittedItem.IsOnDayTop || DaysMode == CalendarDaysMode.Short ? Cursors.SizeWE : Cursors.SizeNS;
                            }

                            OnItemMouseHover(new CalendarItemEventArgs(hittedItem));

                        }
                        if (!Cursor.Equals(should))
                        {
                            Cursor = should;
                        }

                        break;
                    case CalendarState.DraggingTimeSelection:
                        if (SelectedElementStart != null && !SelectedElementEnd!.Equals(hitted))
                        {
                            SelectedElementEnd = hitted;
                        }

                        break;
                    case CalendarState.DraggingItem:
                        if (_itemOnState != null)
                        {
                            TimeSpan duration = _itemOnState.Duration;
                            _itemOnState.SetIsDragging(true);
                            _itemOnState.StartDate = hitted.Date;
                            _itemOnState.EndDate = _itemOnState.StartDate.Add(duration);
                        }

                        Renderer!.PerformItemsLayout();
                        Invalidate();
                        _itemOnStateChanged = true;
                        break;
                    case CalendarState.ResizingItem:
                        if (_itemOnState != null && _itemOnState.IsResizingEndDate && hitted.Date.CompareTo(_itemOnState.StartDate) >= 0)
                        {
                            _itemOnState.EndDate = hitted.Date.Add(hittedTop != null || DaysMode == CalendarDaysMode.Short ? new TimeSpan(23, 59, 59) : Days[0]!.TimeUnits[0]!.Duration);
                        }
                        else if (_itemOnState != null && _itemOnState.IsResizingStartDate && hitted.Date.CompareTo(_itemOnState.EndDate) <= 0)
                        {
                            _itemOnState.StartDate = hitted.Date;
                        }
                        Renderer!.PerformItemsLayout();
                        Invalidate();
                        _itemOnStateChanged = true;
                        break;
                    case CalendarState.EditingItemText:
                        break;
                }
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            ICalendarSelectableElement? hitted = HitTest(e.Location, State == CalendarState.DraggingTimeSelection);
            CalendarItemAlternative? hittedItem = hitted as CalendarItemAlternative;
            CalendarDay? hittedDay = hitted as CalendarDay;
            bool shiftPressed = (ModifierKeys & Keys.Shift) == Keys.Shift;

            switch (State)
            {
                case CalendarState.Idle:

                    break;
                case CalendarState.DraggingTimeSelection:
                    if (SelectedElementStart == null || (hitted != null && !SelectedElementEnd!.Equals(hitted)))
                    {
                        SelectedElementEnd = hitted;
                    }
                    if (hittedDay != null)
                    {
                        if (hittedDay.HeaderBounds.Contains(e.Location))
                        {
                            OnDayHeaderClick(new CalendarDayEventArgs(hittedDay));
                        }
                    }
                    break;
                case CalendarState.DraggingItem:
                    if (_itemOnStateChanged)
                    {
                        OnItemDatesChanged(new CalendarItemEventArgs(_itemOnState));
                    }

                    break;
                case CalendarState.ResizingItem:
                    if (_itemOnStateChanged)
                    {
                        OnItemDatesChanged(new CalendarItemEventArgs(_itemOnState));
                    }

                    break;
                case CalendarState.EditingItemText:
                    break;
            }

            if (_itemOnState != null)
            {
                _itemOnState.SetIsDragging(false);
                _itemOnState.SetIsResizingEndDate(false);
                _itemOnState.SetIsResizingStartDate(false);
                Invalidate(_itemOnState);
                OnItemClick(new CalendarItemEventArgs(_itemOnState));
                _itemOnState = null;
            }
            SetState(CalendarState.Idle);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);

            if (DaysMode == CalendarDaysMode.Expanded)
            {
                ScrollTimeUnits(e.Delta);
            }
            else if (DaysMode == CalendarDaysMode.Short)
            {
                ScrollCalendar(e.Delta);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            CalendarRendererEventArgs evt = new CalendarRendererEventArgs(this, e.Graphics, e.ClipRectangle);

            //Calendar background
            Renderer!.OnDrawBackground(evt);

            // Headers / Timescale
            switch (DaysMode)
            {
                case CalendarDaysMode.Short:
                    Renderer.OnDrawDayNameHeaders(evt);
                    Renderer.OnDrawWeekHeaders(evt);
                    break;
                case CalendarDaysMode.Expanded:
                    Renderer.OnDrawTimeScale(evt);
                    break;
                default:
                    throw new NotImplementedException("Current DaysMode not implemented");
            }

            //Days on view
            Renderer.OnDrawDays(evt);

            //Items
            Renderer.OnDrawItems(evt);

            //Overflow marks
            Renderer.OnDrawOverflows(evt);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            TimeUnitsOffset = TimeUnitsOffset;
            Renderer!.PerformLayout();
        }

        #endregion
    }
}