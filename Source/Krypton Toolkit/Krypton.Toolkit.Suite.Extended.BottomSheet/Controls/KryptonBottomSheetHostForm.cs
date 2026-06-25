#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2026 - 2026 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.BottomSheet;

internal sealed class KryptonBottomSheetHostForm : KryptonForm
{
    private readonly IWin32Window _owner;
    private readonly Control? _ownerControl;
    private readonly KryptonBottomSheetConfig _config;
    private readonly KryptonBottomSheetRef _sheetRef;
    private readonly Control? _previousFocus;
    private readonly BottomSheetBackdropPanel _backdrop;
    private readonly KryptonBottomSheet _sheet;
    private readonly Timer _animationTimer;
    private readonly Control _content;
    private IReadOnlyList<int> _snapHeights;
    private readonly float _dpiScale;
    private BottomSheetFocusTrap? _focusTrap;
    private Image? _blurImage;
    private int _targetTop;
    private int _currentTop;
    private int _animationStartTop;
    private int _animationTargetTop;
    private int _animationDurationMilliseconds;
    private long _animationStartTimestamp;
    private double _animationBackdropStart;
    private double _backdropProgress;
    private double _targetBackdropProgress;
    private bool _isClosing;
    private object? _dismissResult;
    private bool _backdropMouseDown;

    public KryptonBottomSheetHostForm(
        IWin32Window owner,
        Control content,
        KryptonBottomSheetConfig config,
        KryptonBottomSheetRef sheetRef)
    {
        _owner = owner;
        _ownerControl = owner as Control;
        _config = config;
        _content = content;
        _sheetRef = sheetRef;
        _previousFocus = FindFocusedControl(owner);
        _dpiScale = BottomSheetDpi.GetScaleFactor(_ownerControl);
        _snapHeights = Array.Empty<int>();

        FormBorderStyle = FormBorderStyle.None;
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.Manual;
        KeyPreview = true;
        TopMost = true;
        Text = string.Empty;
        AccessibleRole = AccessibleRole.Dialog;

        if (!string.IsNullOrWhiteSpace(config.AccessibleName))
        {
            AccessibleName = config.AccessibleName;
        }

        if (!string.IsNullOrWhiteSpace(config.AccessibleDescription))
        {
            AccessibleDescription = config.AccessibleDescription;
        }

        _backdrop = new BottomSheetBackdropPanel
        {
            Dock = DockStyle.Fill,
            BackdropStyle = config.BackdropStyle,
            BackdropOpacity = config.BackdropOpacity,
            AnimationOpacity = 0d,
        };
        _backdrop.MouseDown += Backdrop_MouseDown;
        _backdrop.MouseUp += Backdrop_MouseUp;

        _sheet = new KryptonBottomSheet
        {
            CornerRadius = BottomSheetDpi.Scale(config.CornerRadius, _dpiScale),
            Elevation = BottomSheetDpi.Scale(config.Elevation, _dpiScale),
            ShowHandle = config.ShowHandle,
            EnableDragToDismiss = config.EnableDragToDismiss,
            DragDismissThreshold = BottomSheetDpi.Scale(config.DragDismissThreshold, _dpiScale),
            DragDismissVelocity = config.DragDismissVelocity,
            SurfaceStyle = config.SurfaceStyle,
        };

        if (_ownerControl != null)
        {
            RightToLeft = _ownerControl.RightToLeft;
        }

        if (config.EnableDragToDismiss)
        {
            _sheet.DragDismissRequested += (_, _) => RequestDismiss(null);
            _sheet.SnapBackRequested += (_, _) => SnapBackFromDrag();
            _sheet.DragCompleted += (_, args) => ResizeSheet(args.TargetHeight, animate: true);
            _sheet.DragOffsetChanged += (_, _) => PositionSheet(_currentTop + _sheet.DragOffset);
        }

        _animationTimer = new Timer { Interval = BottomSheetMetrics.AnimationIntervalMilliseconds };
        _animationTimer.Tick += AnimationTimer_Tick;

        Controls.Add(_backdrop);
        Controls.Add(_sheet);

        _sheet.ContentHost.Controls.Add(content);
        content.Dock = DockStyle.Fill;

        ApplyBounds();
        RefreshSnapHeights();
        ApplyBackdrop();
        ApplySheetLayout(initial: true);
        PositionSheetOffScreenBelow();

        if (_ownerControl != null)
        {
            _ownerControl.LocationChanged += Owner_BoundsChanged;
            _ownerControl.SizeChanged += Owner_BoundsChanged;
            if (_ownerControl.IsHandleCreated)
            {
                _ownerControl.HandleCreated += Owner_BoundsChanged;
            }
        }
    }

    public void RequestDismiss(object? result)
    {
        if (_isClosing || _config.DisableClose)
        {
            return;
        }

        _dismissResult = result;
        _isClosing = true;
        _currentTop = _sheet.Top;
        _sheet.ResetDrag();
        _targetBackdropProgress = 0d;
        AnimateSlideTo(GetOffScreenTop(), closing: true, completeDismiss: true);
    }

    public bool AnimateDismissAndWait(object? result, int timeoutMilliseconds = 5000)
    {
        if (IsDisposed)
        {
            return true;
        }

        if (_isClosing)
        {
            return WaitForClose(timeoutMilliseconds);
        }

        using System.Threading.ManualResetEventSlim closed = new(false);
        FormClosedEventHandler? onClosed = null;
        onClosed = (_, _) =>
        {
            closed.Set();
            FormClosed -= onClosed;
        };
        FormClosed += onClosed;

        RequestDismiss(result);
        closed.Wait(timeoutMilliseconds);
        return closed.IsSet;
    }

    public void ShowSheet()
    {
        _isClosing = false;
        _targetBackdropProgress = _config.HasBackdrop ? 1d : 0d;
        _backdropProgress = 0d;
        _backdrop.AnimationOpacity = 0d;
        _targetTop = Height - _sheet.Height;
        PositionSheetOffScreenBelow();
        AnimateSlideTo(_targetTop, closing: false, completeDismiss: false, onComplete: CompleteOpen);
    }

    protected override void OnShown(EventArgs e)
    {
        base.OnShown(e);

        if (_config.TrapFocus)
        {
            _focusTrap = new BottomSheetFocusTrap(this, _sheet);
        }

        ShowSheet();
    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
        base.OnKeyDown(e);

        if (e.KeyCode == Keys.Escape && !_config.DisableClose)
        {
            e.Handled = true;
            RequestDismiss(null);
        }
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (_ownerControl != null)
            {
                _ownerControl.LocationChanged -= Owner_BoundsChanged;
                _ownerControl.SizeChanged -= Owner_BoundsChanged;
                _ownerControl.HandleCreated -= Owner_BoundsChanged;
            }

            _focusTrap?.Dispose();
            _animationTimer.Dispose();
            _blurImage?.Dispose();
        }

        base.Dispose(disposing);
    }

    private void CompleteOpen()
    {
        _sheetRef.NotifyOpened();
        ApplyInitialFocus();
    }

    private bool WaitForClose(int timeoutMilliseconds)
    {
        using System.Threading.ManualResetEventSlim closed = new(false);
        FormClosedEventHandler? onClosed = null;
        onClosed = (_, _) =>
        {
            closed.Set();
            FormClosed -= onClosed;
        };
        FormClosed += onClosed;
        closed.Wait(timeoutMilliseconds);
        return closed.IsSet;
    }

    private void Backdrop_MouseDown(object? sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            _backdropMouseDown = true;
        }
    }

    private void Backdrop_MouseUp(object? sender, MouseEventArgs e)
    {
        if (_backdropMouseDown && e.Button == MouseButtons.Left && !_config.DisableClose)
        {
            RequestDismiss(null);
        }

        _backdropMouseDown = false;
    }

    private void Owner_BoundsChanged(object? sender, EventArgs e)
    {
        if (_isClosing)
        {
            return;
        }

        ApplyBounds();
        RefreshSnapHeights();
        ApplySheetLayout(initial: false);
        PositionSheet(Math.Min(_currentTop, Height - _sheet.Height));
        _targetTop = Height - _sheet.Height;
    }

    private void RefreshSnapHeights()
    {
        int minimum = BottomSheetDpi.Scale(_config.MinimumSheetHeight, _dpiScale);
        int maximum = Math.Min(
            BottomSheetDpi.Scale(_config.MaximumSheetHeight, _dpiScale),
            Height - BottomSheetDpi.Scale(48, _dpiScale));

        _snapHeights = BottomSheetSnapResolver.NormalizeSnapHeights(
            _config.SnapHeights,
            _config.SnapHeightPercentages,
            Height,
            minimum,
            maximum);
    }

    private void ApplyBounds()
    {
        Rectangle bounds = GetHostBounds();
        Bounds = bounds;
        MinimumSize = bounds.Size;
        MaximumSize = bounds.Size;
    }

    private Rectangle GetHostBounds() =>
        _config.BoundsMode == BottomSheetBoundsMode.WorkingArea
            ? GetWorkingAreaBounds()
            : GetOwnerClientBounds();

    private Rectangle GetOwnerClientBounds()
    {
        if (_ownerControl != null && !_ownerControl.IsDisposed)
        {
            return _ownerControl.RectangleToScreen(_ownerControl.ClientRectangle);
        }

        return Screen.FromPoint(Cursor.Position).WorkingArea;
    }

    private Rectangle GetWorkingAreaBounds()
    {
        Control? context = _ownerControl;
        Screen screen = context != null ? Screen.FromControl(context) : Screen.FromPoint(Cursor.Position);
        return screen.WorkingArea;
    }

    private void ApplyBackdrop()
    {
        if (!_config.HasBackdrop)
        {
            _backdrop.Visible = false;
            _backdrop.Enabled = false;
            Opacity = 1d;
            return;
        }

        _backdrop.Visible = true;
        _backdrop.Enabled = !_config.DisableClose;
        Opacity = 1d;

        if (_config.BackdropStyle == BottomSheetBackdropStyle.Blur)
        {
            ApplyBlurBackdrop();
        }
    }

    private void ApplyBlurBackdrop()
    {
        _blurImage?.Dispose();
        _blurImage = null;

        using Bitmap? capture = BottomSheetBlurRenderer.CaptureControl(_ownerControl);
        if (capture == null)
        {
            _backdrop.BackdropStyle = BottomSheetBackdropStyle.Dim;
            return;
        }

        _blurImage = BottomSheetBlurRenderer.ApplyBlur(capture, 8, _config.BackdropOpacity);
        _backdrop.BlurImage = _blurImage;
    }

    private void ApplySheetLayout(bool initial)
    {
        int maxWidth = _config.MaxSheetWidth > 0
            ? BottomSheetDpi.Scale(_config.MaxSheetWidth, _dpiScale)
            : Width;

        if (maxWidth <= 0)
        {
            maxWidth = BottomSheetDpi.Scale(BottomSheetMetrics.DefaultMaxSheetWidth, _dpiScale);
        }

        int sheetWidth = Math.Min(Width, maxWidth);
        int sheetHeight = ResolveSheetHeight(sheetWidth);

        _sheet.Width = sheetWidth;
        _sheet.Height = sheetHeight;
        _sheet.Left = RightToLeft == RightToLeft.Yes ? 0 : Math.Max(0, (Width - sheetWidth) / 2);
        _targetTop = Height - sheetHeight;

        if (initial)
        {
            _currentTop = Height;
        }
    }

    private int ResolveSheetHeight(int sheetWidth)
    {
        if (_config.HeightMode == BottomSheetHeightMode.Auto)
        {
            _sheet.Width = sheetWidth;
            return BottomSheetLayout.MeasureContentHeight(_content, _sheet, _config, _dpiScale);
        }

        return Clamp(
            BottomSheetDpi.Scale(_config.SheetHeight, _dpiScale),
            BottomSheetDpi.Scale(_config.MinimumSheetHeight, _dpiScale),
            Math.Min(
                BottomSheetDpi.Scale(_config.MaximumSheetHeight, _dpiScale),
                Height - BottomSheetDpi.Scale(48, _dpiScale)));
    }

    private void ResizeSheet(int targetHeight, bool animate)
    {
        int resolved = BottomSheetSnapResolver.ResolveTargetHeight(
            targetHeight,
            Height,
            BottomSheetDpi.Scale(_config.MinimumSheetHeight, _dpiScale),
            Math.Min(BottomSheetDpi.Scale(_config.MaximumSheetHeight, _dpiScale), Height - 48),
            _snapHeights);

        _sheet.Height = resolved;
        _targetTop = Height - resolved;

        if (animate && _config.Animate)
        {
            AnimateSlideTo(_targetTop, closing: false, completeDismiss: false);
        }
        else
        {
            PositionSheet(_targetTop);
        }
    }

    private void SnapBackFromDrag()
    {
        _currentTop = _sheet.Top;
        _sheet.ResetDrag();
        ResizeSheet(_sheet.Height, animate: true);
    }

    private void PositionSheet(int top)
    {
        _currentTop = top;
        _sheet.Top = top;
    }

    private int GetOffScreenTop() => Height;

    private void PositionSheetOffScreenBelow()
    {
        _currentTop = GetOffScreenTop();
        PositionSheet(_currentTop);
    }

    private void AnimateSlideTo(int targetTop, bool closing, bool completeDismiss, Action? onComplete = null)
    {
        _animationStartTop = _currentTop;
        _animationTargetTop = targetTop;
        _animationDurationMilliseconds = Math.Max(
            1,
            closing
                ? _config.CloseAnimationDurationMilliseconds
                : _config.AnimationDurationMilliseconds);
        _animationStartTimestamp = Environment.TickCount;
        _animationBackdropStart = _backdropProgress;
        _animationTimer.Tag = new AnimationState(closing, completeDismiss, onComplete);

        if (!_config.Animate)
        {
            FinishSlideAnimation((AnimationState)_animationTimer.Tag);
            return;
        }

        if (!_animationTimer.Enabled)
        {
            _animationTimer.Start();
        }
    }

    private void FinishSlideAnimation(AnimationState state)
    {
        _animationTimer.Stop();
        _animationTimer.Tag = null;

        _currentTop = _animationTargetTop;
        _backdropProgress = _targetBackdropProgress;
        _backdrop.AnimationOpacity = _backdropProgress;
        PositionSheet(_currentTop);

        state.OnComplete?.Invoke();

        if (state.CompleteDismiss)
        {
            CompleteDismiss();
        }
    }

    private void AnimationTimer_Tick(object? sender, EventArgs e)
    {
        if (!(_animationTimer.Tag is AnimationState state))
        {
            _animationTimer.Stop();
            return;
        }

        int elapsed = unchecked(Environment.TickCount - (int)_animationStartTimestamp);
        if (elapsed < 0)
        {
            elapsed = int.MaxValue;
        }

        double progress = BottomSheetAnimation.CalculateProgress(elapsed, _animationDurationMilliseconds);
        double eased = BottomSheetAnimation.ResolveEasing(progress, state.Closing, _config.AnimationEasing);

        _currentTop = BottomSheetAnimation.Interpolate(_animationStartTop, _animationTargetTop, eased);
        _backdropProgress = BottomSheetAnimation.Interpolate(_animationBackdropStart, _targetBackdropProgress, eased);
        _backdrop.AnimationOpacity = _backdropProgress;

        PositionSheet(_currentTop);

        if (progress >= 1d)
        {
            FinishSlideAnimation(state);
        }
    }

    private void CompleteDismiss()
    {
        Hide();
        _sheetRef.NotifyDismissed(_dismissResult);

        if (_config.RestoreFocusOnDismiss && _previousFocus != null && !_previousFocus.IsDisposed)
        {
            _previousFocus.Focus();
        }

        Close();
    }

    private void ApplyInitialFocus()
    {
        Control? focusTarget = BottomSheetFocusResolver.ResolveInitialFocus(_content, _config, _sheet);
        focusTarget?.Focus();
    }

    private static Control? FindFocusedControl(IWin32Window owner)
    {
        if (owner is ContainerControl container && container.ActiveControl != null)
        {
            return container.ActiveControl;
        }

        if (owner is Control control)
        {
            return control;
        }

        return Form.ActiveForm;
    }

    private static int Clamp(int value, int min, int max) =>
        Math.Max(min, Math.Min(max, value));

    private sealed class AnimationState
    {
        public AnimationState(bool closing, bool completeDismiss, Action? onComplete)
        {
            Closing = closing;
            CompleteDismiss = completeDismiss;
            OnComplete = onComplete;
        }

        public bool Closing { get; }
        public bool CompleteDismiss { get; }
        public Action? OnComplete { get; }
    }
}
