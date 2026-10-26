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
/// Application-wide default options for bottom sheets.
/// </summary>
public static class KryptonBottomSheetDefaultOptions
{
    private static KryptonBottomSheetConfig _default = new();

    /// <summary>
    /// Gets or sets the default configuration merged into each opened bottom sheet.
    /// </summary>
    public static KryptonBottomSheetConfig Default
    {
        get => _default;
        set => _default = value ?? new KryptonBottomSheetConfig();
    }

    /// <summary>
    /// Creates a resolved configuration by merging <see cref="Default"/> with optional overrides.
    /// </summary>
    public static KryptonBottomSheetConfig Resolve(KryptonBottomSheetConfig? overrides)
    {
        KryptonBottomSheetConfig resolved = _default.Clone();
        if (overrides != null)
        {
            resolved.ApplyPartialOverrides(overrides);
        }

        return resolved;
    }
}
