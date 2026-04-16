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

using Krypton.Toolkit;

namespace Krypton.Toolkit.Suite.Extended.GanttChart;

/// <summary>
/// WinForms Gantt-style schedule view with task names, timeline bars, optional finish-to-start links,
/// and palette colours from the current global Krypton theme.
/// </summary>
[DefaultEvent(nameof(TaskSelected))]
[ToolboxBitmap(typeof(MonthCalendar))]
public class KryptonGanttChart : UserControl
{
    #region Fields

    private readonly KryptonScrollBar _vScroll = new KryptonScrollBar();
    private readonly KryptonScrollBar _hScroll = new KryptonScrollBar();
    private readonly BindingList<GanttTask> _tasks = new BindingList<GanttTask>();
    private List<GanttDependency> _dependencies = [];
    private readonly List<GanttTask> _hookedTasks = [];

    private PaletteBase? _palette;
    private ThemeColours _theme;

    private int _taskListWidth = 200;
    private int _rowHeight = 24;
    private int _headerHeight = 32;
    private float _pixelsPerDay = 32f;
    private DateTime _timelineStart = DateTime.Today;
    private int _minChartDaySpan = 14;
    private GanttTask? _selectedTask;
    private bool _allowTaskDrag = true;
    private bool _showWeekendShading = true;
    private bool _showDependencies = true;

    private bool _dragging;
    private Point _dragStart;
    private GanttTask? _dragTask;
    private DateTime _dragOrigStart;
    private DateTime _dragOrigEnd;

    private static readonly Color[] s_barAccent =
    [
        Color.FromArgb(70, 130, 180),
        Color.FromArgb(60, 179, 113),
        Color.FromArgb(218, 165, 32),
        Color.FromArgb(205, 92, 92),
        Color.FromArgb(147, 112, 219),
        Color.FromArgb(70, 150, 160),
    ];

    #endregion

    #region Nested type

    private struct ThemeColours
    {
        public Color Background;
        public Color TaskColumn;
        public Color GridLine;
        public Color HeaderBack;
        public Color HeaderText;
        public Color TaskText;
        public Color BarBorder;
        public Color SelectedRow;
        public Color DependencyLine;
        public Color Weekend;
    }

    #endregion

    #region Identity

    /// <summary>Initializes a new instance of the <see cref="KryptonGanttChart"/> class.</summary>
    public KryptonGanttChart()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.UserPaint |
                 ControlStyles.OptimizedDoubleBuffer |
                 ControlStyles.ResizeRedraw, true);

        DoubleBuffered = true;
        Font = new Font("Segoe UI", 9f);
        ForeColor = SystemColors.ControlText;
        BackColor = SystemColors.Control;

        _hScroll.Dock = DockStyle.Bottom;
        _hScroll.Orientation = ScrollBarOrientation.Horizontal;
        _hScroll.Visible = false;
        _hScroll.Scroll += (_, _) => Invalidate();

        _vScroll.Dock = DockStyle.Right;
        _vScroll.Orientation = ScrollBarOrientation.Vertical;
        _vScroll.Visible = false;
        _vScroll.Scroll += (_, _) => Invalidate();

        Controls.Add(_hScroll);
        Controls.Add(_vScroll);

        _tasks.ListChanged += Tasks_ListChanged;
        KryptonManager.GlobalPaletteChanged += OnGlobalPaletteChanged;
        OnGlobalPaletteChanged(this, EventArgs.Empty);

        Disposed += (_, _) =>
        {
            KryptonManager.GlobalPaletteChanged -= OnGlobalPaletteChanged;
            if (_palette != null)
            {
                _palette.PalettePaint -= OnPalettePaint;
            }

            UnhookAllTasks();
        };
    }

    #endregion

    #region Events

    /// <summary>Occurs when the user selects a task.</summary>
    [Description("Occurs when the user selects a task.")]
    public event EventHandler<GanttTaskEventArgs>? TaskSelected;

    /// <summary>Occurs when task dates change after a drag operation.</summary>
    [Description("Occurs when task dates change after a drag operation.")]
    public event EventHandler<GanttTaskEventArgs>? TaskDatesChanged;

    #endregion

    #region Properties

    /// <summary>Tasks displayed on the chart, top to bottom.</summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IList<GanttTask> Tasks => _tasks;

    /// <summary>Dependencies drawn between tasks.</summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public List<GanttDependency>? Dependencies
    {
        get => _dependencies;
        set
        {
            _dependencies = value ?? [];
            Invalidate();
        }
    }

    /// <summary>First visible day column on the timeline.</summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public DateTime TimelineStart
    {
        get => _timelineStart;
        set
        {
            var d = value.Date;
            if (_timelineStart == d) return;
            _timelineStart = d;
            Invalidate();
            UpdateScrollBars();
        }
    }

    /// <summary>Horizontal scale in pixels per day.</summary>
    [DefaultValue(32f)]
    public float PixelsPerDay
    {
        get => _pixelsPerDay;
        set
        {
            var v = Math.Max(4f, value);
            if (Math.Abs(_pixelsPerDay - v) < 0.01f) return;
            _pixelsPerDay = v;
            Invalidate();
            UpdateScrollBars();
        }
    }

    /// <summary>Width of the fixed task name column.</summary>
    [DefaultValue(200)]
    public int TaskListWidth
    {
        get => _taskListWidth;
        set
        {
            var v = Math.Max(40, value);
            if (_taskListWidth == v) return;
            _taskListWidth = v;
            Invalidate();
            UpdateScrollBars();
        }
    }

    /// <summary>Height of each task row.</summary>
    [DefaultValue(24)]
    public int RowHeight
    {
        get => _rowHeight;
        set
        {
            var v = Math.Max(14, value);
            if (_rowHeight == v) return;
            _rowHeight = v;
            Invalidate();
            UpdateScrollBars();
        }
    }

    /// <summary>Height of the date header strip.</summary>
    [DefaultValue(32)]
    public int HeaderHeight
    {
        get => _headerHeight;
        set
        {
            var v = Math.Max(18, value);
            if (_headerHeight == v) return;
            _headerHeight = v;
            Invalidate();
            UpdateScrollBars();
        }
    }

    /// <summary>Minimum number of day columns when there is little or no data.</summary>
    [DefaultValue(14)]
    public int MinChartDaySpan
    {
        get => _minChartDaySpan;
        set
        {
            var v = Math.Max(1, value);
            if (_minChartDaySpan == v) return;
            _minChartDaySpan = v;
            Invalidate();
            UpdateScrollBars();
        }
    }

    /// <summary>Allows moving a task horizontally by dragging its bar.</summary>
    [DefaultValue(true)]
    public bool AllowTaskDrag
    {
        get => _allowTaskDrag;
        set => _allowTaskDrag = value;
    }

    /// <summary>Shades weekend columns in the chart area.</summary>
    [DefaultValue(true)]
    public bool ShowWeekendShading
    {
        get => _showWeekendShading;
        set
        {
            if (_showWeekendShading == value) return;
            _showWeekendShading = value;
            Invalidate();
        }
    }

    /// <summary>Draws dependency connectors between predecessor and successor bars.</summary>
    [DefaultValue(true)]
    public bool ShowDependencies
    {
        get => _showDependencies;
        set
        {
            if (_showDependencies == value) return;
            _showDependencies = value;
            Invalidate();
        }
    }

    /// <summary>The currently selected task, if any.</summary>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public GanttTask? SelectedTask
    {
        get => _selectedTask;
        set
        {
            if (ReferenceEquals(_selectedTask, value)) return;
            _selectedTask = value;
            Invalidate();
        }
    }

    #endregion

    #region Palette

    private void OnGlobalPaletteChanged(object? sender, EventArgs e)
    {
        if (_palette != null)
        {
            _palette.PalettePaint -= OnPalettePaint;
        }

        _palette = KryptonManager.CurrentGlobalPalette;

        if (_palette != null)
        {
            _palette.PalettePaint += OnPalettePaint;
        }

        ReloadTheme();
    }

    private void OnPalettePaint(object? sender, PaletteLayoutEventArgs e) => ReloadTheme();

    private void ReloadTheme()
    {
        if (_palette == null)
        {
            _theme = new ThemeColours
            {
                Background = SystemColors.Window,
                TaskColumn = SystemColors.Control,
                GridLine = SystemColors.ControlDark,
                HeaderBack = SystemColors.Control,
                HeaderText = SystemColors.ControlText,
                TaskText = SystemColors.ControlText,
                BarBorder = SystemColors.ControlDark,
                SelectedRow = Color.FromArgb(50, SystemColors.Highlight),
                DependencyLine = SystemColors.ControlDark,
                Weekend = Color.FromArgb(35, Color.Gray),
            };
        }
        else
        {
            _theme = new ThemeColours
            {
                Background = _palette.GetBackColor1(PaletteBackStyle.PanelClient, PaletteState.Normal),
                TaskColumn = _palette.GetBackColor1(PaletteBackStyle.TabOneNote, PaletteState.Normal),
                GridLine = _palette.GetBorderColor1(PaletteBorderStyle.GridDataCellSheet, PaletteState.Normal),
                HeaderBack = _palette.GetBackColor1(PaletteBackStyle.HeaderForm, PaletteState.Normal),
                HeaderText = _palette.GetContentShortTextColor1(PaletteContentStyle.HeaderForm, PaletteState.Normal),
                TaskText = _palette.GetContentShortTextColor1(PaletteContentStyle.InputControlStandalone, PaletteState.Normal),
                BarBorder = _palette.GetBorderColor1(PaletteBorderStyle.InputControlStandalone, PaletteState.Normal),
                SelectedRow = Color.FromArgb(60, _palette.GetBackColor1(PaletteBackStyle.ButtonStandalone, PaletteState.Tracking)),
                DependencyLine = _palette.GetBorderColor1(PaletteBorderStyle.HeaderPrimary, PaletteState.Normal),
                Weekend = Color.FromArgb(30, _palette.GetBackColor1(PaletteBackStyle.PanelClient, PaletteState.Disabled)),
            };
        }

        Invalidate();
    }

    #endregion

    #region Task list hooks

    private void Tasks_ListChanged(object? sender, ListChangedEventArgs e)
    {
        switch (e.ListChangedType)
        {
            case ListChangedType.Reset:
                ResubscribeAllTasks();
                break;
            case ListChangedType.ItemAdded:
                HookTask(_tasks[e.NewIndex]);
                break;
            case ListChangedType.ItemDeleted:
                ResubscribeAllTasks();
                break;
            default:
                Invalidate();
                UpdateScrollBars();
                return;
        }

        Invalidate();
        UpdateScrollBars();
    }

    private void ResubscribeAllTasks()
    {
        UnhookAllTasks();
        foreach (var t in _tasks)
        {
            HookTask(t);
        }
    }

    private void HookTask(GanttTask task)
    {
        if (_hookedTasks.Contains(task)) return;
        task.PropertyChanged += Task_PropertyChanged;
        _hookedTasks.Add(task);
    }

    private void UnhookAllTasks()
    {
        foreach (var t in _hookedTasks)
        {
            t.PropertyChanged -= Task_PropertyChanged;
        }

        _hookedTasks.Clear();
    }

    private void Task_PropertyChanged(object? sender, PropertyChangedEventArgs e) =>
        Invalidate();

    #endregion

    #region Geometry

    private Rectangle GetContentRectangle()
    {
        int rw = _vScroll.Visible ? _vScroll.Width : 0;
        int bh = _hScroll.Visible ? _hScroll.Height : 0;
        return new Rectangle(0, 0, Math.Max(0, ClientSize.Width - rw), Math.Max(0, ClientSize.Height - bh));
    }

    private int GetTotalContentHeight() => _headerHeight + _tasks.Count * _rowHeight + 4;

    private double GetChartDaySpan()
    {
        DateTime last = _timelineStart.Date;
        foreach (var t in _tasks)
        {
            if (t.End.Date > last)
            {
                last = t.End.Date;
            }

            if (t.Start.Date > last)
            {
                last = t.Start.Date;
            }
        }

        int span = (int)(last - _timelineStart.Date).TotalDays + 1;
        return Math.Max(span, _minChartDaySpan);
    }

    private int GetTotalChartPixelWidth() =>
        (int)Math.Ceiling(GetChartDaySpan() * _pixelsPerDay) + 8;

    private float ChartX(double daysFromStart) => (float)(daysFromStart * _pixelsPerDay);

    private float ScreenChartX(double daysFromStart) => _taskListWidth + ChartX(daysFromStart) - _hScroll.Value;

    private void GetBarHorizontalSpan(GanttTask task, out float left, out float right)
    {
        var startDays = (task.Start.Date - _timelineStart.Date).TotalDays;
        var endDaysExclusive = (task.End.Date - _timelineStart.Date).TotalDays + 1;
        left = ScreenChartX(startDays);
        right = ScreenChartX(endDaysExclusive);
    }

    private float RowTopScreen(int row) => _headerHeight + row * _rowHeight - _vScroll.Value;

    private Rectangle GetBarBounds(int row, GanttTask task)
    {
        GetBarHorizontalSpan(task, out var left, out var right);
        float top = RowTopScreen(row) + 4;
        float h = _rowHeight - 8;
        var x1 = Math.Min(left, right);
        var x2 = Math.Max(left, right);
        return Rectangle.FromLTRB((int)Math.Floor(x1), (int)Math.Floor(top), (int)Math.Ceiling(x2), (int)Math.Ceiling(top + h));
    }

    private bool HitTestBar(Point client, out int row, out GanttTask? task)
    {
        row = -1;
        task = null;
        if (client.X <= _taskListWidth || client.Y <= _headerHeight)
        {
            return false;
        }

        var content = GetContentRectangle();
        if (!content.Contains(client))
        {
            return false;
        }

        for (var i = 0; i < _tasks.Count; i++)
        {
            var r = GetBarBounds(i, _tasks[i]);
            if (r.Contains(client))
            {
                row = i;
                task = _tasks[i];
                return true;
            }
        }

        return false;
    }

    private bool HitTestRowLabel(Point client, out int row, out GanttTask? task)
    {
        row = -1;
        task = null;
        if (client.X > _taskListWidth || client.Y <= _headerHeight)
        {
            return false;
        }

        for (var i = 0; i < _tasks.Count; i++)
        {
            float y1 = RowTopScreen(i);
            float y2 = y1 + _rowHeight;
            if (client.Y >= y1 && client.Y < y2)
            {
                row = i;
                task = _tasks[i];
                return true;
            }
        }

        return false;
    }

    private void UpdateScrollBars()
    {
        if (Width <= 0 || Height <= 0)
        {
            return;
        }

        // Two passes: vertical scrollbar width affects horizontal extents.
        for (var pass = 0; pass < 2; pass++)
        {
            var content = GetContentRectangle();
            int totalH = GetTotalContentHeight();
            int maxY = Math.Max(0, totalH - content.Height);

            _vScroll.LargeChange = Math.Max(_rowHeight, Math.Max(1, content.Height / 2));
            _vScroll.SmallChange = _rowHeight;
            _vScroll.Maximum = Math.Max(0, maxY + _vScroll.LargeChange - 1);
            _vScroll.Visible = maxY > 0;
            _vScroll.Value = ScrollClamp(_vScroll.Value, 0, maxY);

            int chartViewport = Math.Max(0, content.Width - _taskListWidth);
            int totalChartW = GetTotalChartPixelWidth();
            int maxX = Math.Max(0, totalChartW - chartViewport);

            _hScroll.LargeChange = Math.Max((int)_pixelsPerDay * 2, Math.Max(1, chartViewport / 3));
            _hScroll.SmallChange = Math.Max(1, (int)(_pixelsPerDay / 2));
            _hScroll.Maximum = Math.Max(0, maxX + _hScroll.LargeChange - 1);
            _hScroll.Visible = maxX > 0;
            _hScroll.Value = ScrollClamp(_hScroll.Value, 0, maxX);
        }
    }

    private static int ScrollClamp(int value, int min, int max) => value < min ? min : (value > max ? max : value);

    #endregion

    #region Mouse

    /// <inheritdoc />
    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);
        Focus();
        if (e.Button != MouseButtons.Left) return;

        GanttTask? hit = null;
        if (HitTestBar(e.Location, out _, out var tBar))
        {
            hit = tBar;
        }
        else if (HitTestRowLabel(e.Location, out _, out var tRow))
        {
            hit = tRow;
        }

        SelectedTask = hit;
        if (hit != null)
        {
            TaskSelected?.Invoke(this, new GanttTaskEventArgs(hit));
        }

        if (_allowTaskDrag && hit != null && HitTestBar(e.Location, out _, out var dragBar) && ReferenceEquals(dragBar, hit))
        {
            _dragging = true;
            _dragStart = e.Location;
            _dragTask = hit;
            _dragOrigStart = hit.Start.Date;
            _dragOrigEnd = hit.End.Date;
        }
    }

    /// <inheritdoc />
    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);
        if (!_dragging || _dragTask == null) return;

        int dx = e.X - _dragStart.X;
        var dayShift = (int)Math.Round(dx / _pixelsPerDay);
        if (dayShift == 0) return;

        var span = (_dragOrigEnd - _dragOrigStart).Days;
        if (span < 0) span = 0;

        var newStart = _dragOrigStart.AddDays(dayShift);
        var newEnd = newStart.AddDays(span);
        _dragTask.Start = newStart;
        _dragTask.End = newEnd;
        Invalidate();
    }

    /// <inheritdoc />
    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseUp(e);
        if (_dragging && _dragTask != null && e.Button == MouseButtons.Left)
        {
            _dragging = false;
            TaskDatesChanged?.Invoke(this, new GanttTaskEventArgs(_dragTask));
            _dragTask = null;
            UpdateScrollBars();
        }
    }

    /// <inheritdoc />
    protected override void OnLostFocus(EventArgs e)
    {
        base.OnLostFocus(e);
        if (_dragging)
        {
            _dragging = false;
            _dragTask = null;
        }
    }

    /// <inheritdoc />
    protected override void OnMouseWheel(MouseEventArgs e)
    {
        if ((ModifierKeys & Keys.Shift) == Keys.Shift)
        {
            int delta = e.Delta > 0 ? -_hScroll.SmallChange : _hScroll.SmallChange;
            int maxX = Math.Max(0, _hScroll.Maximum - _hScroll.LargeChange + 1);
            _hScroll.Value = ScrollClamp(_hScroll.Value + delta, _hScroll.Minimum, maxX);
        }
        else
        {
            int delta = e.Delta > 0 ? -_vScroll.SmallChange : _vScroll.SmallChange;
            int maxY = Math.Max(0, _vScroll.Maximum - _vScroll.LargeChange + 1);
            _vScroll.Value = ScrollClamp(_vScroll.Value + delta, _vScroll.Minimum, maxY);
        }

        Invalidate();
        base.OnMouseWheel(e);
    }

    #endregion

    #region Layout / paint

    /// <inheritdoc />
    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);
        UpdateScrollBars();
    }

    /// <inheritdoc />
    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        UpdateScrollBars();
    }

    /// <inheritdoc />
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        var g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

        var content = GetContentRectangle();
        using (var brush = new SolidBrush(_theme.Background))
        {
            g.FillRectangle(brush, content);
        }

        DrawTimelineHeader(g, content);
        DrawTaskPane(g, content);
        DrawChartArea(g, content);
        DrawBorder(g, content);
        DrawScrollCorner(g);
    }

    private void DrawScrollCorner(Graphics g)
    {
        if (!(_vScroll.Visible && _hScroll.Visible)) return;
        var r = new Rectangle(ClientSize.Width - _vScroll.Width, ClientSize.Height - _hScroll.Height, _vScroll.Width, _hScroll.Height);
        using var b = new SolidBrush(_theme.TaskColumn);
        g.FillRectangle(b, r);
    }

    private void DrawBorder(Graphics g, Rectangle content)
    {
        using var pen = new Pen(_theme.GridLine);
        g.DrawRectangle(pen, new Rectangle(content.X, content.Y, content.Width - 1, content.Height - 1));
    }

    private void DrawTimelineHeader(Graphics g, Rectangle content)
    {
        var headerRect = new Rectangle(content.X, content.Y, content.Width, _headerHeight);
        int innerRight = content.Right;
        using (var brush = new LinearGradientBrush(headerRect, _theme.HeaderBack, ControlPaint.Light(_theme.HeaderBack), 90f))
        {
            g.FillRectangle(brush, headerRect);
        }

        using (var pen = new Pen(_theme.GridLine))
        {
            g.DrawLine(pen, content.X + _taskListWidth, content.Y, content.X + _taskListWidth, content.Bottom);
        }

        var taskHdr = new Rectangle(content.X + 1, content.Y + 1, _taskListWidth - 2, _headerHeight - 2);
        using (var font = new Font(Font, FontStyle.Bold))
        {
            TextRenderer.DrawText(g, "Task", font, taskHdr, _theme.HeaderText,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
        }

        double span = GetChartDaySpan();
        int firstDay = (int)Math.Floor(_hScroll.Value / _pixelsPerDay);
        if (firstDay < 0) firstDay = 0;

        for (int day = firstDay; day < span + 2; day++)
        {
            float x = ScreenChartX(day);
            if (x > innerRight) break;
            if (x < _taskListWidth - 8) continue;

            var dayDate = _timelineStart.AddDays(day);
            string label = dayDate.ToString("ddd d", CultureInfo.CurrentCulture);
            var cell = new Rectangle((int)x, content.Y + 2, (int)Math.Max(12, _pixelsPerDay), _headerHeight - 4);
            TextRenderer.DrawText(g, label, Font, cell, _theme.HeaderText,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);

            g.DrawLine(new Pen(_theme.GridLine), x, content.Y, x, content.Bottom);
        }

        using (var pen = new Pen(_theme.GridLine))
        {
            g.DrawLine(pen, content.X, content.Y + _headerHeight, innerRight, content.Y + _headerHeight);
        }
    }

    private void DrawTaskPane(Graphics g, Rectangle content)
    {
        var colRect = new Rectangle(content.X, content.Y + _headerHeight, _taskListWidth, content.Height - _headerHeight);
        using (var brush = new SolidBrush(_theme.TaskColumn))
        {
            g.FillRectangle(brush, colRect);
        }

        using (var pen = new Pen(_theme.GridLine))
        {
            g.DrawLine(pen, content.X + _taskListWidth, content.Y + _headerHeight, content.X + _taskListWidth, content.Bottom);
        }

        for (var i = 0; i < _tasks.Count; i++)
        {
            var task = _tasks[i];
            float y = RowTopScreen(i);
            if (y + _rowHeight < content.Y + _headerHeight || y > content.Bottom) continue;

            var rowRect = new Rectangle(content.X + 2, (int)y + 1, _taskListWidth - 4, _rowHeight - 2);
            if (ReferenceEquals(task, _selectedTask))
            {
                using var b = new SolidBrush(_theme.SelectedRow);
                g.FillRectangle(b, rowRect);
            }

            TextRenderer.DrawText(g, task.Name, Font, rowRect, _theme.TaskText,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);

            float lineY = y + _rowHeight;
            g.DrawLine(new Pen(_theme.GridLine), content.X, (int)lineY, content.X + _taskListWidth, (int)lineY);
        }
    }

    private void DrawChartArea(Graphics g, Rectangle content)
    {
        float chartLeft = content.X + _taskListWidth;
        var chartRect = new Rectangle((int)chartLeft, content.Y + _headerHeight, content.Right - (int)chartLeft, content.Height - _headerHeight);
        if (chartRect.Width <= 0 || chartRect.Height <= 0) return;

        var clip = g.ClipBounds;
        g.SetClip(chartRect);

        if (_showWeekendShading)
        {
            double span = GetChartDaySpan();
            for (int day = 0; day < span + 1; day++)
            {
                var dt = _timelineStart.AddDays(day);
                if (dt.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday)
                {
                    float x1 = ScreenChartX(day);
                    float x2 = ScreenChartX(day + 1);
                    using var br = new SolidBrush(_theme.Weekend);
                    g.FillRectangle(br, x1, chartRect.Top, x2 - x1, chartRect.Height);
                }
            }
        }

        double spanDays = GetChartDaySpan();
        for (int day = 0; day <= spanDays + 1; day++)
        {
            float x = ScreenChartX(day);
            if (x < chartLeft - 2 || x > content.Right) continue;
            using var pen = new Pen(_showWeekendShading && _timelineStart.AddDays(day).DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday
                ? Color.FromArgb(80, _theme.GridLine)
                : Color.FromArgb(120, _theme.GridLine));
            g.DrawLine(pen, x, chartRect.Top, x, chartRect.Bottom);
        }

        for (var i = 0; i < _tasks.Count; i++)
        {
            float y = RowTopScreen(i);
            if (y + _rowHeight < chartRect.Top || y > chartRect.Bottom) continue;
            g.DrawLine(new Pen(Color.FromArgb(60, _theme.GridLine)), chartLeft, y + _rowHeight, content.Right, y + _rowHeight);
        }

        if (_showDependencies)
        {
            DrawDependencies(g, chartRect);
        }

        for (var i = 0; i < _tasks.Count; i++)
        {
            var task = _tasks[i];
            var bar = GetBarBounds(i, task);
            if (bar.Bottom < chartRect.Top || bar.Top > chartRect.Bottom) continue;

            Color fill = task.BarColor ?? s_barAccent[i % s_barAccent.Length];
            using var brush = new LinearGradientBrush(bar, ControlPaint.Light(fill), fill, 90f);
            FillRoundedRectangle(g, brush, bar, 2);
            using var pen = new Pen(_theme.BarBorder);
            DrawRoundedRectangle(g, pen, bar, 2);

            if (task.PercentComplete is > 0 and < 100)
            {
                int doneW = (int)(bar.Width * (task.PercentComplete / 100f));
                var doneRect = new Rectangle(bar.X, bar.Y, Math.Max(1, doneW), bar.Height);
                using var overlay = new SolidBrush(Color.FromArgb(110, Color.Black));
                g.FillRectangle(overlay, doneRect);
            }
        }

        g.ResetClip();
        g.SetClip(clip);
    }

    private void DrawDependencies(Graphics g, Rectangle chartRect)
    {
        var map = new Dictionary<string, int>(StringComparer.Ordinal);
        for (var i = 0; i < _tasks.Count; i++)
        {
            map[_tasks[i].Id] = i;
        }

        using var pen = new Pen(_theme.DependencyLine)
        {
            CustomEndCap = new AdjustableArrowCap(3, 3)
        };

        foreach (var d in _dependencies)
        {
            if (!map.TryGetValue(d.PredecessorId, out var pi) || !map.TryGetValue(d.SuccessorId, out var si))
            {
                continue;
            }

            var pred = _tasks[pi];
            var succ = _tasks[si];
            GetBarHorizontalSpan(pred, out var pLeft, out var pRight);
            GetBarHorizontalSpan(succ, out var sLeft, out var sRight);
            float pX = Math.Max(pLeft, pRight) - 1;
            float sX = Math.Min(sLeft, sRight) + 1;
            float pY = RowTopScreen(pi) + _rowHeight / 2f;
            float sY = RowTopScreen(si) + _rowHeight / 2f;

            if (pY < chartRect.Top - 40 || pY > chartRect.Bottom + 40) continue;
            if (sY < chartRect.Top - 40 || sY > chartRect.Bottom + 40) continue;

            float midX = Math.Min(pX + 18, sX - 8);
            using var path = new GraphicsPath();
            path.AddLines([
                new PointF(pX, pY),
                new PointF(midX, pY),
                new PointF(midX, sY),
                new PointF(sX, sY)
            ]);
            g.DrawPath(pen, path);
        }
    }

    private static GraphicsPath GetRoundedRectPath(Rectangle bounds, int radius)
    {
        int d = Math.Min(radius * 2, Math.Min(bounds.Width, bounds.Height));
        var path = new GraphicsPath();
        if (d <= 0)
        {
            path.AddRectangle(bounds);
            return path;
        }

        path.AddArc(bounds.X, bounds.Y, d, d, 180, 90);
        path.AddArc(bounds.Right - d, bounds.Y, d, d, 270, 90);
        path.AddArc(bounds.Right - d, bounds.Bottom - d, d, d, 0, 90);
        path.AddArc(bounds.X, bounds.Bottom - d, d, d, 90, 90);
        path.CloseFigure();
        return path;
    }

    private static void FillRoundedRectangle(Graphics g, Brush brush, Rectangle bounds, int radius)
    {
        using var path = GetRoundedRectPath(bounds, radius);
        g.FillPath(brush, path);
    }

    private static void DrawRoundedRectangle(Graphics g, Pen pen, Rectangle bounds, int radius)
    {
        using var path = GetRoundedRectPath(bounds, radius);
        g.DrawPath(pen, path);
    }

    #endregion
}
