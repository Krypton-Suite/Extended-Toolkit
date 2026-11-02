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

/// <summary>
/// Configuration options used when opening a <see cref="KryptonBottomSheet"/>.
/// </summary>
public sealed class KryptonBottomSheetConfig
{
    /// <summary>
    /// Gets or sets optional data passed to sheet content.
    /// </summary>
    public object? Data { get; set; }

    /// <summary>
    /// Gets or sets the accessible name applied to the bottom sheet dialog surface.
    /// </summary>
    public string? AccessibleName { get; set; }

    /// <summary>
    /// Gets or sets the accessible description applied to the bottom sheet dialog surface.
    /// </summary>
    public string? AccessibleDescription { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether a dimmed backdrop is shown behind the sheet.
    /// </summary>
    public bool HasBackdrop { get; set; } = true;

    /// <summary>
    /// Gets or sets the backdrop rendering style.
    /// </summary>
    public BottomSheetBackdropStyle BackdropStyle { get; set; } = BottomSheetBackdropStyle.Dim;

    /// <summary>
    /// Gets or sets a value indicating whether the sheet can be dismissed with Escape or backdrop clicks.
    /// </summary>
    public bool DisableClose { get; set; }

    /// <summary>
    /// Gets or sets how the sheet is presented to the user.
    /// </summary>
    public BottomSheetDisplayMode DisplayMode { get; set; } = BottomSheetDisplayMode.Modal;

    /// <summary>
    /// Gets or sets the region covered by the host overlay.
    /// </summary>
    public BottomSheetBoundsMode BoundsMode { get; set; } = BottomSheetBoundsMode.OwnerClient;

    /// <summary>
    /// Gets or sets how the sheet height is calculated.
    /// </summary>
    public BottomSheetHeightMode HeightMode { get; set; } = BottomSheetHeightMode.Fixed;

    /// <summary>
    /// Gets or sets the preferred sheet height in pixels when <see cref="HeightMode"/> is <see cref="BottomSheetHeightMode.Fixed"/>.
    /// </summary>
    public int SheetHeight { get; set; } = BottomSheetMetrics.DefaultSheetHeight;

    /// <summary>
    /// Gets or sets the minimum sheet height in pixels.
    /// </summary>
    public int MinimumSheetHeight { get; set; } = BottomSheetMetrics.MinimumSheetHeight;

    /// <summary>
    /// Gets or sets the maximum sheet height in pixels.
    /// </summary>
    public int MaximumSheetHeight { get; set; } = BottomSheetMetrics.MaximumSheetHeight;

    /// <summary>
    /// Gets or sets optional snap heights in pixels used when drag-to-dismiss ends without closing.
    /// </summary>
    public int[]? SnapHeights { get; set; }

    /// <summary>
    /// Gets or sets the maximum sheet width in pixels. Zero uses the full host width.
    /// </summary>
    public int MaxSheetWidth { get; set; }

    /// <summary>
    /// Gets or sets the top corner radius in pixels.
    /// </summary>
    public int CornerRadius { get; set; } = BottomSheetMetrics.DefaultCornerRadius;

    /// <summary>
    /// Gets or sets the elevation used for the sheet shadow.
    /// </summary>
    public int Elevation { get; set; } = BottomSheetMetrics.DefaultElevation;

    /// <summary>
    /// Gets or sets the palette-backed surface style for the sheet.
    /// </summary>
    public BottomSheetSurfaceStyle SurfaceStyle { get; set; } = BottomSheetSurfaceStyle.PanelClient;

    /// <summary>
    /// Gets or sets a value indicating whether a drag handle is shown at the top of the sheet.
    /// </summary>
    public bool ShowHandle { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether drag-to-dismiss is enabled when a handle is shown.
    /// </summary>
    public bool EnableDragToDismiss { get; set; } = true;

    /// <summary>
    /// Gets or sets the drag distance in pixels required to dismiss the sheet.
    /// </summary>
    public int DragDismissThreshold { get; set; } = BottomSheetMetrics.DragDismissThreshold;

    /// <summary>
    /// Gets or sets the downward velocity in pixels per second required to dismiss during a quick fling.
    /// </summary>
    public double DragDismissVelocity { get; set; } = BottomSheetMetrics.DragDismissVelocity;

    /// <summary>
    /// Gets or sets the backdrop opacity when <see cref="HasBackdrop"/> is true.
    /// </summary>
    public double BackdropOpacity { get; set; } = BottomSheetMetrics.DefaultBackdropOpacity;

    /// <summary>
    /// Gets or sets how focus is assigned when the sheet opens.
    /// </summary>
    public BottomSheetAutoFocusMode AutoFocus { get; set; } = BottomSheetAutoFocusMode.FirstTabbable;

    /// <summary>
    /// Gets or sets an optional CSS-style selector used to choose the initial focus target.
    /// </summary>
    public string? AutoFocusSelector { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether focus is trapped inside the sheet while open.
    /// </summary>
    public bool TrapFocus { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether the sheet should restore focus to the previously focused control when dismissed.
    /// </summary>
    public bool RestoreFocusOnDismiss { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether an already open sheet is replaced instead of throwing.
    /// </summary>
    public bool ReplaceExisting { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether hosted content is disposed when the sheet closes.
    /// </summary>
    public bool DisposeContentOnDismiss { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether backdrop and sheet slide animations are enabled.
    /// </summary>
    public bool Animate { get; set; } = true;

    /// <summary>
    /// Gets or sets the slide open/close animation duration in milliseconds.
    /// </summary>
    public int AnimationDurationMilliseconds { get; set; } = BottomSheetMetrics.AnimationDurationMilliseconds;

    /// <summary>
    /// Gets or sets the slide close animation duration in milliseconds.
    /// </summary>
    public int CloseAnimationDurationMilliseconds { get; set; } = BottomSheetMetrics.CloseAnimationDurationMilliseconds;

    /// <summary>
    /// Gets or sets the easing curve applied to slide animations.
    /// </summary>
    public BottomSheetAnimationEasing AnimationEasing { get; set; } = BottomSheetAnimationEasing.Standard;

    /// <summary>
    /// Gets or sets how a new open request is handled when another sheet is already active.
    /// </summary>
    public BottomSheetConflictMode ConflictMode { get; set; } = BottomSheetConflictMode.Throw;

    /// <summary>
    /// Gets or sets optional snap heights expressed as fractions of the host height (0.05 to 1.0).
    /// </summary>
    public double[]? SnapHeightPercentages { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the owner form is disabled while a modal sheet is open.
    /// </summary>
    public bool DisableOwnerWhileOpen { get; set; } = true;

    /// <summary>
    /// Returns the conflict mode that will be applied when opening a sheet.
    /// </summary>
    public BottomSheetConflictMode GetEffectiveConflictMode() =>
        ConflictMode != BottomSheetConflictMode.Throw
            ? ConflictMode
            : ReplaceExisting
                ? BottomSheetConflictMode.Replace
                : BottomSheetConflictMode.Throw;

    /// <summary>
    /// Creates a shallow copy of this configuration.
    /// </summary>
    public KryptonBottomSheetConfig Clone()
    {
        KryptonBottomSheetConfig clone = new();
        clone.ApplyOverrides(this);
        return clone;
    }

    /// <summary>
    /// Copies only values that differ from a freshly created configuration template.
    /// </summary>
    public void ApplyPartialOverrides(KryptonBottomSheetConfig source)
    {
        KryptonBottomSheetConfig template = new();

        if (source.Data != null)
        {
            Data = source.Data;
        }

        if (source.AccessibleName != null)
        {
            AccessibleName = source.AccessibleName;
        }

        if (source.AccessibleDescription != null)
        {
            AccessibleDescription = source.AccessibleDescription;
        }

        if (source.HasBackdrop != template.HasBackdrop)
        {
            HasBackdrop = source.HasBackdrop;
        }

        if (source.BackdropStyle != template.BackdropStyle)
        {
            BackdropStyle = source.BackdropStyle;
        }

        if (source.DisableClose != template.DisableClose)
        {
            DisableClose = source.DisableClose;
        }

        if (source.DisplayMode != template.DisplayMode)
        {
            DisplayMode = source.DisplayMode;
        }

        if (source.BoundsMode != template.BoundsMode)
        {
            BoundsMode = source.BoundsMode;
        }

        if (source.HeightMode != template.HeightMode)
        {
            HeightMode = source.HeightMode;
        }

        if (source.SheetHeight != template.SheetHeight)
        {
            SheetHeight = source.SheetHeight;
        }

        if (source.MinimumSheetHeight != template.MinimumSheetHeight)
        {
            MinimumSheetHeight = source.MinimumSheetHeight;
        }

        if (source.MaximumSheetHeight != template.MaximumSheetHeight)
        {
            MaximumSheetHeight = source.MaximumSheetHeight;
        }

        if (source.SnapHeights != null)
        {
            SnapHeights = source.SnapHeights.ToArray();
        }

        if (source.SnapHeightPercentages != null)
        {
            SnapHeightPercentages = source.SnapHeightPercentages.ToArray();
        }

        if (source.MaxSheetWidth != template.MaxSheetWidth)
        {
            MaxSheetWidth = source.MaxSheetWidth;
        }

        if (source.CornerRadius != template.CornerRadius)
        {
            CornerRadius = source.CornerRadius;
        }

        if (source.Elevation != template.Elevation)
        {
            Elevation = source.Elevation;
        }

        if (source.SurfaceStyle != template.SurfaceStyle)
        {
            SurfaceStyle = source.SurfaceStyle;
        }

        if (source.ShowHandle != template.ShowHandle)
        {
            ShowHandle = source.ShowHandle;
        }

        if (source.EnableDragToDismiss != template.EnableDragToDismiss)
        {
            EnableDragToDismiss = source.EnableDragToDismiss;
        }

        if (source.DragDismissThreshold != template.DragDismissThreshold)
        {
            DragDismissThreshold = source.DragDismissThreshold;
        }

        if (Math.Abs(source.DragDismissVelocity - template.DragDismissVelocity) > 0.001d)
        {
            DragDismissVelocity = source.DragDismissVelocity;
        }

        if (Math.Abs(source.BackdropOpacity - template.BackdropOpacity) > 0.001d)
        {
            BackdropOpacity = source.BackdropOpacity;
        }

        if (source.AutoFocus != template.AutoFocus)
        {
            AutoFocus = source.AutoFocus;
        }

        if (source.AutoFocusSelector != null)
        {
            AutoFocusSelector = source.AutoFocusSelector;
        }

        if (source.TrapFocus != template.TrapFocus)
        {
            TrapFocus = source.TrapFocus;
        }

        if (source.RestoreFocusOnDismiss != template.RestoreFocusOnDismiss)
        {
            RestoreFocusOnDismiss = source.RestoreFocusOnDismiss;
        }

        if (source.ReplaceExisting != template.ReplaceExisting)
        {
            ReplaceExisting = source.ReplaceExisting;
        }

        if (source.DisposeContentOnDismiss != template.DisposeContentOnDismiss)
        {
            DisposeContentOnDismiss = source.DisposeContentOnDismiss;
        }

        if (source.Animate != template.Animate)
        {
            Animate = source.Animate;
        }

        if (source.AnimationDurationMilliseconds != template.AnimationDurationMilliseconds)
        {
            AnimationDurationMilliseconds = source.AnimationDurationMilliseconds;
        }

        if (source.CloseAnimationDurationMilliseconds != template.CloseAnimationDurationMilliseconds)
        {
            CloseAnimationDurationMilliseconds = source.CloseAnimationDurationMilliseconds;
        }

        if (source.AnimationEasing != template.AnimationEasing)
        {
            AnimationEasing = source.AnimationEasing;
        }

        if (source.ConflictMode != template.ConflictMode)
        {
            ConflictMode = source.ConflictMode;
        }

        if (source.DisableOwnerWhileOpen != template.DisableOwnerWhileOpen)
        {
            DisableOwnerWhileOpen = source.DisableOwnerWhileOpen;
        }
    }

    /// <summary>
    /// Copies all values from another configuration instance.
    /// </summary>
    public void ApplyOverrides(KryptonBottomSheetConfig source)
    {
        Data = source.Data;
        AccessibleName = source.AccessibleName;
        AccessibleDescription = source.AccessibleDescription;
        HasBackdrop = source.HasBackdrop;
        BackdropStyle = source.BackdropStyle;
        DisableClose = source.DisableClose;
        DisplayMode = source.DisplayMode;
        BoundsMode = source.BoundsMode;
        HeightMode = source.HeightMode;
        SheetHeight = source.SheetHeight;
        MinimumSheetHeight = source.MinimumSheetHeight;
        MaximumSheetHeight = source.MaximumSheetHeight;
        SnapHeights = source.SnapHeights?.ToArray();
        SnapHeightPercentages = source.SnapHeightPercentages?.ToArray();
        MaxSheetWidth = source.MaxSheetWidth;
        CornerRadius = source.CornerRadius;
        Elevation = source.Elevation;
        SurfaceStyle = source.SurfaceStyle;
        ShowHandle = source.ShowHandle;
        EnableDragToDismiss = source.EnableDragToDismiss;
        DragDismissThreshold = source.DragDismissThreshold;
        DragDismissVelocity = source.DragDismissVelocity;
        BackdropOpacity = source.BackdropOpacity;
        AutoFocus = source.AutoFocus;
        AutoFocusSelector = source.AutoFocusSelector;
        TrapFocus = source.TrapFocus;
        RestoreFocusOnDismiss = source.RestoreFocusOnDismiss;
        ReplaceExisting = source.ReplaceExisting;
        DisposeContentOnDismiss = source.DisposeContentOnDismiss;
        Animate = source.Animate;
        AnimationDurationMilliseconds = source.AnimationDurationMilliseconds;
        CloseAnimationDurationMilliseconds = source.CloseAnimationDurationMilliseconds;
        AnimationEasing = source.AnimationEasing;
        ConflictMode = source.ConflictMode;
        DisableOwnerWhileOpen = source.DisableOwnerWhileOpen;
    }
}
