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
/// Standard spacing values inspired by Material Design bottom sheets.
/// </summary>
internal static class BottomSheetMetrics
{
    public const int StandardPadding = 16;
    public const int HandleWidth = 32;
    public const int HandleHeight = 4;
    public const int HandleTopMargin = 8;
    public const int HandleBottomMargin = 8;
    public const int DefaultCornerRadius = 12;
    public const int DefaultElevation = 8;
    public const int AnimationIntervalMilliseconds = 16;
    public const int AnimationDurationMilliseconds = 300;
    public const int CloseAnimationDurationMilliseconds = 200;
    public const int AnimationStepPixels = 18;
    public const int DefaultSheetHeight = 280;
    public const int MinimumSheetHeight = 120;
    public const int MaximumSheetHeight = 640;
    public const int DragDismissThreshold = 96;
    public const double DragDismissVelocity = 900d;
    public const double DefaultBackdropOpacity = 0.45d;
    public const int DefaultMaxSheetWidth = 640;
}
