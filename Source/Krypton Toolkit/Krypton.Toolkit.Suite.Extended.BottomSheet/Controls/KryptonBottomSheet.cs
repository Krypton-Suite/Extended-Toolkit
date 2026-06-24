#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.BottomSheet;

/// <summary>
/// Material-inspired bottom sheet surface with optional drag handle and hosted content area.
/// </summary>
[ToolboxItem(true)]
[ToolboxBitmap(typeof(KryptonBottomSheet), "ToolboxBitmaps.KryptonBottomSheet.bmp")]
[Designer(typeof(KryptonBottomSheetDesigner))]
[DesignerCategory(@"code")]
[Description(@"Bottom sheet surface used by KryptonBottomSheetManager and available for advanced hosting scenarios.")]
public class KryptonBottomSheet : Panel
{
    private readonly KryptonPanel _contentHost;
    private readonly Timer _touchTimer;
    private int _cornerRadius = BottomSheetMetrics.DefaultCornerRadius;
    private int _elevation = BottomSheetMetrics.DefaultElevation;
    private bool _showHandle = true;
    private bool _enableDragToDismiss = true;
    private int _dragDismissThreshold = BottomSheetMetrics.DragDismissThreshold;
    private double _dragDismissVelocity = BottomSheetMetrics.DragDismissVelocity;
    private BottomSheetSurfaceStyle _surfaceStyle = BottomSheetSurfaceStyle.PanelClient;
    private int _dragOffset;
    private bool _isDragging;
    private Point _dragStartScreen;
    private DateTime _dragStartTime;
    private Point _lastDragScreen;
    private DateTime _lastDragTime;

    /// <summary>
    /// Initializes a new instance of the <see cref="KryptonBottomSheet"/> class.
    /// </summary>
    public KryptonBottomSheet()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint
                 | ControlStyles.OptimizedDoubleBuffer
                 | ControlStyles.ResizeRedraw
                 | ControlStyles.UserPaint, true);

        AccessibleRole = AccessibleRole.Dialog;
        BackColor = Color.Transparent;
        TabStop = true;

        _contentHost = new KryptonPanel
        {
            Dock = DockStyle.Fill,
            PanelBackStyle = PaletteBackStyle.PanelClient,
        };

        _touchTimer = new Timer { Interval = 16 };
        _touchTimer.Tick += TouchTimer_Tick;

        Controls.Add(_contentHost);
        UpdateContentPadding();

        KryptonManager.GlobalPaletteChanged += OnGlobalPaletteChanged;
    }

    /// <summary>
    /// Gets the panel that hosts bottom sheet content.
    /// </summary>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public KryptonPanel ContentHost => _contentHost;

    /// <summary>
    /// Gets or sets the top corner radius in pixels.
    /// </summary>
    [DefaultValue(BottomSheetMetrics.DefaultCornerRadius)]
    public int CornerRadius
    {
        get => _cornerRadius;
        set
        {
            int radius = Math.Max(0, value);
            if (_cornerRadius == radius)
            {
                return;
            }

            _cornerRadius = radius;
            ApplyRegion();
            Invalidate();
        }
    }

    /// <summary>
    /// Gets or sets the elevation used when painting the sheet shadow.
    /// </summary>
    [DefaultValue(BottomSheetMetrics.DefaultElevation)]
    public int Elevation
    {
        get => _elevation;
        set
        {
            int elevation = Math.Max(0, value);
            if (_elevation == elevation)
            {
                return;
            }

            _elevation = elevation;
            Invalidate();
        }
    }

    /// <summary>
    /// Gets or sets the palette-backed surface style.
    /// </summary>
    [DefaultValue(BottomSheetSurfaceStyle.PanelClient)]
    public BottomSheetSurfaceStyle SurfaceStyle
    {
        get => _surfaceStyle;
        set
        {
            if (_surfaceStyle == value)
            {
                return;
            }

            _surfaceStyle = value;
            _contentHost.PanelBackStyle = BottomSheetRendering.ToPaletteBackStyle(value);
            Invalidate();
        }
    }

    /// <summary>
    /// Gets or sets a value indicating whether a drag handle is shown at the top of the sheet.
    /// </summary>
    [DefaultValue(true)]
    public bool ShowHandle
    {
        get => _showHandle;
        set
        {
            if (_showHandle == value)
            {
                return;
            }

            _showHandle = value;
            UpdateContentPadding();
            Invalidate();
        }
    }

    /// <summary>
    /// Gets or sets a value indicating whether drag gestures can dismiss the sheet.
    /// </summary>
    [DefaultValue(true)]
    public bool EnableDragToDismiss
    {
        get => _enableDragToDismiss;
        set => _enableDragToDismiss = value;
    }

    /// <summary>
    /// Gets or sets the drag distance required to dismiss the sheet.
    /// </summary>
    [DefaultValue(BottomSheetMetrics.DragDismissThreshold)]
    public int DragDismissThreshold
    {
        get => _dragDismissThreshold;
        set => _dragDismissThreshold = Math.Max(24, value);
    }

    /// <summary>
    /// Gets or sets the downward fling velocity required to dismiss the sheet.
    /// </summary>
    [DefaultValue(BottomSheetMetrics.DragDismissVelocity)]
    public double DragDismissVelocity
    {
        get => _dragDismissVelocity;
        set => _dragDismissVelocity = Math.Max(100d, value);
    }

    /// <summary>
    /// Gets the current drag offset applied while the user drags the sheet downward.
    /// </summary>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int DragOffset => _dragOffset;

    /// <summary>
    /// Occurs when the user drags the sheet downward past the dismiss threshold.
    /// </summary>
    public event EventHandler? DragDismissRequested;

    /// <summary>
    /// Occurs when the drag gesture ends without dismissal and the sheet should snap back.
    /// </summary>
    public event EventHandler<BottomSheetDragCompletedEventArgs>? DragCompleted;

    /// <summary>
    /// Sets the drag offset used during interactive dismiss gestures.
    /// </summary>
    public void SetDragOffset(int offset)
    {
        _dragOffset = Math.Max(0, offset);
        Invalidate();
    }

    /// <summary>
    /// Clears any active drag offset and drag state.
    /// </summary>
    public void ResetDrag()
    {
        _isDragging = false;
        _dragOffset = 0;
        _touchTimer.Stop();
        Invalidate();
    }

    /// <inheritdoc />
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            KryptonManager.GlobalPaletteChanged -= OnGlobalPaletteChanged;
            _touchTimer.Dispose();
        }

        base.Dispose(disposing);
    }

    /// <inheritdoc />
    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);
        ApplyRegion();
    }

    /// <inheritdoc />
    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        ApplyRegion();
    }

    /// <inheritdoc />
    protected override void OnRightToLeftChanged(EventArgs e)
    {
        base.OnRightToLeftChanged(e);
        Invalidate();
    }

    /// <inheritdoc />
    protected override void OnPaint(PaintEventArgs e)
    {
        Rectangle bounds = ClientRectangle;
        bounds.Y += _dragOffset;

        Color surfaceColor = BottomSheetRendering.ResolveSurfaceColor(_surfaceStyle);
        Color shadowColor = Color.FromArgb(90, 0, 0, 0);
        Color handleColor = ControlPaint.Light(surfaceColor, 0.25f);

        BottomSheetRendering.DrawElevationShadow(e.Graphics, bounds, _cornerRadius, _elevation, shadowColor);

        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        using GraphicsPath path = BottomSheetRendering.CreateTopRoundRectPath(bounds, _cornerRadius);
        using SolidBrush brush = new(surfaceColor);
        e.Graphics.FillPath(brush, path);

        if (_showHandle)
        {
            bool rtl = RightToLeft == RightToLeft.Yes;
            BottomSheetRendering.DrawHandle(e.Graphics, bounds, handleColor, rtl);
        }
    }

    /// <inheritdoc />
    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);
        BeginDrag(e);
    }

    /// <inheritdoc />
    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);
        UpdateDrag(e);
    }

    /// <inheritdoc />
    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseUp(e);
        EndDrag();
    }

    private void BeginDrag(MouseEventArgs e)
    {
        if (!_showHandle || !_enableDragToDismiss || e.Button != MouseButtons.Left)
        {
            return;
        }

        if (!GetHandleHitArea().Contains(e.Location))
        {
            return;
        }

        _isDragging = true;
        _dragStartScreen = PointToScreen(e.Location);
        _lastDragScreen = _dragStartScreen;
        _dragStartTime = DateTime.UtcNow;
        _lastDragTime = _dragStartTime;
        _touchTimer.Start();
    }

    private void UpdateDrag(MouseEventArgs e)
    {
        if (!_isDragging)
        {
            return;
        }

        Point currentScreen = PointToScreen(e.Location);
        ApplyDragDelta(currentScreen);
    }

    private void TouchTimer_Tick(object? sender, EventArgs e)
    {
        if (!_isDragging)
        {
            _touchTimer.Stop();
            return;
        }

        Point currentScreen = Cursor.Position;
        if (GetHandleHitArea().Contains(PointToClient(currentScreen)))
        {
            ApplyDragDelta(currentScreen);
        }
    }

    private void ApplyDragDelta(Point currentScreen)
    {
        int delta = Math.Max(0, currentScreen.Y - _dragStartScreen.Y);
        _lastDragScreen = currentScreen;
        _lastDragTime = DateTime.UtcNow;
        SetDragOffset(delta);
        DragOffsetChanged?.Invoke(this, EventArgs.Empty);
    }

    private void EndDrag()
    {
        if (!_isDragging)
        {
            return;
        }

        _isDragging = false;
        _touchTimer.Stop();

        double elapsedSeconds = Math.Max(0.001d, (_lastDragTime - _dragStartTime).TotalSeconds);
        double velocity = (_lastDragScreen.Y - _dragStartScreen.Y) / elapsedSeconds;
        bool dismiss = _dragOffset >= _dragDismissThreshold || velocity >= _dragDismissVelocity;

        if (dismiss)
        {
            DragDismissRequested?.Invoke(this, EventArgs.Empty);
            return;
        }

        int targetHeight = Math.Max(BottomSheetMetrics.MinimumSheetHeight, Height - _dragOffset);
        DragCompleted?.Invoke(this, new BottomSheetDragCompletedEventArgs(targetHeight));
        SnapBackRequested?.Invoke(this, EventArgs.Empty);
    }

    internal event EventHandler? DragOffsetChanged;
    internal event EventHandler? SnapBackRequested;

    private void OnGlobalPaletteChanged(object? sender, EventArgs e)
    {
        _contentHost.PanelBackStyle = BottomSheetRendering.ToPaletteBackStyle(_surfaceStyle);
        Invalidate();
    }

    private void UpdateContentPadding()
    {
        int topPadding = _showHandle
            ? BottomSheetMetrics.HandleTopMargin + BottomSheetMetrics.HandleHeight + BottomSheetMetrics.HandleBottomMargin
            : BottomSheetMetrics.StandardPadding;

        _contentHost.Padding = new Padding(
            BottomSheetMetrics.StandardPadding,
            topPadding,
            BottomSheetMetrics.StandardPadding,
            BottomSheetMetrics.StandardPadding);
    }

    private Rectangle GetHandleHitArea()
    {
        int hitHeight = BottomSheetMetrics.HandleTopMargin
                        + BottomSheetMetrics.HandleHeight
                        + BottomSheetMetrics.HandleBottomMargin;

        return new Rectangle(0, 0, Width, hitHeight);
    }

    private void ApplyRegion()
    {
        if (!IsHandleCreated || Width <= 0 || Height <= 0)
        {
            return;
        }

        using GraphicsPath path = BottomSheetRendering.CreateTopRoundRectPath(ClientRectangle, _cornerRadius);
        Region = new Region(path);
    }
}
