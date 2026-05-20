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
 */
#endregion

using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Grid.Grouper;

/// <summary>
/// Visual and behavioural options for grouped grid rows.
/// </summary>
public sealed class DataGridViewGrouperOptions
{
    /// <summary>When grouping is applied, new group nodes expand or collapse initially.</summary>
    public bool StartCollapsed { get; set; }

    /// <summary>Include counts in grouped header captions such as Region: North (4).</summary>
    public bool IncludeChildCountInHeader { get; set; } = true;

    /// <summary>If true and the source is omitted for a caption cell, repeats the grouped value in bound columns.</summary>
    public bool PromotePrimaryGroupValueIntoFirstColumn { get; set; } = true;

    /// <summary>Pixel height applied to synthesized group rows (data rows leave grid default).</summary>
    public int GroupRowHeight { get; set; } = 28;

    /// <summary>Font delta for group captions (applied as style adjustment over inherited font).</summary>
    public FontStyle GroupHeaderFontStyle { get; set; } = FontStyle.Bold;
}
