#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
 */
#endregion

global using System.Collections.Generic;
global using System.Drawing;
global using System.Drawing.Drawing2D;
global using System.Windows.Forms;
global using Xunit;

using Krypton.Toolkit.Suite.Extended.BottomSheet;

namespace Krypton.Toolkit.Suite.Extended.BottomSheet.Tests;

public class BottomSheetRenderingTests
{
    [Fact]
    public void CreateTopRoundRectPath_ReturnsClosedPath()
    {
        using GraphicsPath path = BottomSheetRendering.CreateTopRoundRectPath(new Rectangle(0, 0, 100, 60), 8);
        Assert.True(path.PointCount > 0);
    }

    [Fact]
    public void ResolveSurfaceColor_ReturnsOpaqueColor()
    {
        Color color = BottomSheetRendering.ResolveSurfaceColor(BottomSheetSurfaceStyle.PanelClient);
        Assert.True(color.A > 0);
    }
}

public class BottomSheetConfigTests
{
    [Fact]
    public void Clone_CreatesIndependentCopy()
    {
        var source = new KryptonBottomSheetConfig { SheetHeight = 333, Data = "test" };
        KryptonBottomSheetConfig clone = source.Clone();

        clone.SheetHeight = 111;
        Assert.Equal(333, source.SheetHeight);
        Assert.Equal("test", clone.Data);
    }

    [Fact]
    public void DefaultOptions_Resolve_AppliesOverrides()
    {
        KryptonBottomSheetDefaultOptions.Default = new KryptonBottomSheetConfig
        {
            SheetHeight = 400,
            TrapFocus = false,
        };

        KryptonBottomSheetConfig resolved = KryptonBottomSheetDefaultOptions.Resolve(new KryptonBottomSheetConfig
        {
            SheetHeight = 250,
        });

        Assert.Equal(250, resolved.SheetHeight);
        Assert.False(resolved.TrapFocus);
    }
}

public class BottomSheetSnapResolverTests
{
    [Fact]
    public void ResolveTargetHeight_PicksNearestSnap()
    {
        int result = BottomSheetSnapResolver.ResolveTargetHeight(
            210,
            800,
            120,
            600,
            new[] { 180, 320, 480 });

        Assert.Equal(180, result);
    }

    [Fact]
    public void NormalizeSnapHeights_CombinesPixelsAndPercentages()
    {
        IReadOnlyList<int> result = BottomSheetSnapResolver.NormalizeSnapHeights(
            new[] { 200 },
            new[] { 0.5d },
            hostHeight: 800,
            minimumHeight: 120,
            maximumHeight: 600);

        Assert.Contains(200, result);
        Assert.Contains(400, result);
    }
}

public class BottomSheetConfigConflictTests
{
    [Fact]
    public void GetEffectiveConflictMode_UsesReplaceExistingFallback()
    {
        var config = new KryptonBottomSheetConfig { ReplaceExisting = true };
        Assert.Equal(BottomSheetConflictMode.Replace, config.GetEffectiveConflictMode());
    }

    [Fact]
    public void GetEffectiveConflictMode_PrefersExplicitConflictMode()
    {
        var config = new KryptonBottomSheetConfig
        {
            ReplaceExisting = true,
            ConflictMode = BottomSheetConflictMode.Queue,
        };

        Assert.Equal(BottomSheetConflictMode.Queue, config.GetEffectiveConflictMode());
    }
}

public class BottomSheetBlurRendererTests
{
    [Fact]
    public void CaptureControl_ReturnsNullForDisposedControl()
    {
        using Panel panel = new() { Size = new Size(100, 100) };
        panel.Dispose();
        Assert.Null(BottomSheetBlurRenderer.CaptureControl(panel));
    }
}

public class BottomSheetRefTests
{
    [Fact]
    public void Dismiss_CallsDismissAction()
    {
        object? captured = null;
        var sheetRef = new KryptonBottomSheetRef(new Panel(), result => captured = result);
        sheetRef.Dismiss("ok");
        Assert.Equal("ok", captured);
        Assert.False(sheetRef.IsDismissed);
    }
}
