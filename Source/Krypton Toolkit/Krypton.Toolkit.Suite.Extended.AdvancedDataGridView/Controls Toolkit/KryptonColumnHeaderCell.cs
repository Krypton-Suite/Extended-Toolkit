#region Original License
/*
 *
 * Microsoft Public License (Ms-PL)
 *
 * This license governs use of the accompanying software. If you use the software, you accept this license. If you do not accept the license, do not use the software.
 *
 * 1. Definitions 
 *
 * The terms "reproduce," "reproduction," "derivative works," and "distribution" have the same meaning here as under U.S. copyright law.
 *
 * A "contribution" is the original software, or any additions or changes to the software.
 *
 * A "contributor" is any person that distributes its contribution under this license.
 *
 * "Licensed patents" are a contributor's patent claims that read directly on its contribution.
 *
 * 2. Grant of Rights
 *
 * (A) Copyright Grant- Subject to the terms of this license, including the license conditions and limitations in section 3, each contributor grants you a non-exclusive, worldwide, royalty-free copyright license to reproduce its contribution, prepare derivative works of its contribution, and distribute its contribution or any derivative works that you create.
 *
 * (B) Patent Grant- Subject to the terms of this license, including the license conditions and limitations in section 3, each contributor grants you a non-exclusive, worldwide, royalty-free license under its licensed patents to make, have made, use, sell, offer for sale, import, and/or otherwise dispose of its contribution in the software or derivative works of the contribution in the software.
 *
 * 3. Conditions and Limitations
 *
 * (A) No Trademark License- This license does not grant you rights to use any contributors' name, logo, or trademarks.
 *
 * (B) If you bring a patent claim against any contributor over patents that you claim are infringed by the software, your patent license from such contributor to the software ends automatically.
 *
 * (C) If you distribute any portion of the software, you must retain all copyright, patent, trademark, and attribution notices that are present in the software.
 *
 * (D) If you distribute any portion of the software in source code form, you may do so only under this license by including a complete copy of this license with your distribution. If you distribute any portion of the software in compiled or object code form, you may only do so under a license that complies with this license.
 *
 * (E) The software is licensed "as-is." You bear the risk of using it. The contributors give no express warranties, guarantees or conditions. You may have additional consumer rights under your local laws which this license cannot change. To the extent permitted under your local laws, the contributors exclude the implied warranties of merchantability, fitness for a particular purpose and non-infringement.
 *
 */
#endregion

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

// ReSharper disable ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
namespace Krypton.Toolkit.Suite.Extended.AdvancedDataGridView;

internal class KryptonColumnHeaderCell : DataGridViewColumnHeaderCell
{
    #region Instance Fields

    private Size _filterButtonImageSize = new Size(16, 16);
    private bool _filterButtonPressed;
    private bool _filterButtonOver;
    private Rectangle _filterButtonOffsetBounds = Rectangle.Empty;
    private Rectangle _filterButtonImageBounds = Rectangle.Empty;
    private Padding _filterButtonMargin = new Padding(3, 4, 3, 4);
    private bool _filterEnabled;
    private Font? _glyphFont;
    private float _glyphFontSize;

    /// <summary>
    /// Get the MenuStrip for this ColumnHeaderCell
    /// </summary>
    public MenuStrip MenuStrip { get; private set; }


    #endregion

    #region Constants

    /// <summary>
    /// Default behaviour for Date and Time filter
    /// </summary>
    private const bool FILTER_DATE_AND_TIME_DEFAULT_ENABLED = false;

    private const string GlyphUnfiltered = "▾";
    private const string GlyphFiltered = "∇";
    private const string GlyphSortAsc = "▲";
    private const string GlyphSortDesc = "▼";
    private const string GlyphSaved = "★";
    private const int FilterButtonBaseSize = 16;

    #endregion

    #region Events

    public event ColumnHeaderCellEventHandler FilterPopup;
    public event ColumnHeaderCellEventHandler SortChanged;
    public event ColumnHeaderCellEventHandler FilterChanged;

    #endregion

    #region Identity

    public KryptonColumnHeaderCell(DataGridViewColumnHeaderCell oldCell, bool filterEnabled) : base()
    {
        Tag = oldCell.Tag;

        ErrorText = oldCell.ErrorText;

        ToolTipText = oldCell.ToolTipText;

        Value = oldCell.Value;

        ValueType = oldCell.ValueType;

        ContextMenuStrip = oldCell.ContextMenuStrip;

        Style = oldCell.Style;

        _filterEnabled = filterEnabled;

        if (oldCell is KryptonColumnHeaderCell { MenuStrip: not null } oldCellt)
        {
            MenuStrip = oldCellt.MenuStrip;
            _filterButtonPressed = oldCellt._filterButtonPressed;
            _filterButtonOver = oldCellt._filterButtonOver;
            _filterButtonOffsetBounds = oldCellt._filterButtonOffsetBounds;
            _filterButtonImageBounds = oldCellt._filterButtonImageBounds;
            MenuStrip.FilterChanged += new EventHandler(MenuStrip_FilterChanged);
            MenuStrip.SortChanged += new EventHandler(MenuStrip_SortChanged);
        }
        else
        {
            // OwningColumn may be null if the header cell is not attached to a column yet.
            // Guard against null and use object as a fallback type.
            Type dataType = oldCell.OwningColumn?.ValueType ?? typeof(object);
            MenuStrip = new MenuStrip(dataType);
            MenuStrip.FilterChanged += new EventHandler(MenuStrip_FilterChanged);
            MenuStrip.SortChanged += new EventHandler(MenuStrip_SortChanged);
        }

        IsFilterDateAndTimeEnabled = FILTER_DATE_AND_TIME_DEFAULT_ENABLED;
        IsSortEnabled = true;
        IsFilterEnabled = true;
        IsFilterChecklistEnabled = true;
    }

    ~KryptonColumnHeaderCell()
    {
        if (MenuStrip != null)
        {
            MenuStrip.FilterChanged -= MenuStrip_FilterChanged;
            MenuStrip.SortChanged -= MenuStrip_SortChanged;
        }

        _glyphFont?.Dispose();
    }

    #endregion

    #region Implementation

    /// <summary>
    /// Get or Set the Filter and Sort enabled status
    /// </summary>
    public bool FilterAndSortEnabled
    {
        get => _filterEnabled;
        set
        {
            if (!value)
            {
                _filterButtonPressed = false;
                _filterButtonOver = false;
            }

            if (value != _filterEnabled)
            {
                _filterEnabled = value;
                bool refreshed = false;
                if (MenuStrip.FilterString!.Length > 0)
                {
                    MenuStrip_FilterChanged(this, EventArgs.Empty);
                    refreshed = true;
                }
                if (MenuStrip.SortString!.Length > 0)
                {
                    MenuStrip_SortChanged(this, EventArgs.Empty);
                    refreshed = true;
                }
                if (!refreshed)
                {
                    RepaintCell();
                }
            }

            PrepareFilterButtonLayout();
        }
    }

    /// <summary>
    /// Set or Unset the Filter and Sort to Loaded mode
    /// </summary>
    /// <param name="enabled"></param>
    public void SetLoadedMode(bool enabled)
    {
        MenuStrip.SetLoadedMode(enabled);
        RepaintCell();
    }

    /// <summary>
    /// Clean Sort
    /// </summary>
    public void CleanSort()
    {
        if (MenuStrip != null && FilterAndSortEnabled)
        {
            MenuStrip.CleanSort();
            RepaintCell();
        }
    }

    /// <summary>
    /// Clean Filter
    /// </summary>
    public void CleanFilter()
    {
        if (MenuStrip != null && FilterAndSortEnabled)
        {
            MenuStrip.CleanFilter();
            RepaintCell();
        }
    }

    /// <summary>
    /// Sort ASC
    /// </summary>
    public void SortASC()
    {
        if (MenuStrip != null && FilterAndSortEnabled)
        {
            MenuStrip.SortAsc();
        }
    }

    /// <summary>
    /// Sort DESC
    /// </summary>
    public void SortDESC()
    {
        if (MenuStrip != null && FilterAndSortEnabled)
        {
            MenuStrip.SortDesc();
        }
    }

    /// <summary>
    /// Clone the ColumnHeaderCell
    /// </summary>
    /// <returns></returns>
    public override object Clone()
    {
        return new KryptonColumnHeaderCell(this, FilterAndSortEnabled);
    }

    /// <summary>
    /// Get the MenuStrip SortType
    /// </summary>
    public MenuStrip.SortType ActiveSortType
    {
        get
        {
            if (MenuStrip != null && FilterAndSortEnabled)
            {
                return MenuStrip.ActiveSortType;
            }
            else
            {
                return MenuStrip.SortType.None;
            }
        }
    }

    /// <summary>
    /// Get the MenuStrip FilterType
    /// </summary>
    public MenuStrip.FilterType ActiveFilterType
    {
        get
        {
            if (MenuStrip != null && FilterAndSortEnabled)
            {
                return MenuStrip.ActiveFilterType;
            }
            else
            {
                return MenuStrip.FilterType.None;
            }
        }
    }

    /// <summary>
    /// Get the Sort string
    /// </summary>
    public string? SortString
    {
        get
        {
            if (MenuStrip != null && FilterAndSortEnabled)
            {
                return MenuStrip.SortString;
            }
            else
            {
                return "";
            }
        }
    }

    /// <summary>
    /// Get the Filter string
    /// </summary>
    public string? FilterString
    {
        get
        {
            if (MenuStrip != null && FilterAndSortEnabled)
            {
                return MenuStrip.FilterString;
            }
            else
            {
                return "";
            }
        }
    }

    /// <summary>
    /// Get the Minimum size
    /// </summary>
    public Size MinimumSize
    {
        get
        {
            UpdateScaledMetrics();
            return new(_filterButtonImageSize.Width + _filterButtonMargin.Left + _filterButtonMargin.Right,
                _filterButtonImageSize.Height + _filterButtonMargin.Bottom + _filterButtonMargin.Top);
        }
    }

    /// <summary>
    /// Get or Set the Sort enabled status
    /// </summary>
    public bool IsSortEnabled
    {
        get => MenuStrip.IsSortEnabled;
        set => MenuStrip.IsSortEnabled = value;
    }

    /// <summary>
    /// Get or Set the Filter enabled status
    /// </summary>
    public bool IsFilterEnabled
    {
        get => MenuStrip.IsFilterEnabled;
        set => MenuStrip.IsFilterEnabled = value;
    }

    /// <summary>
    /// Get or Set the Filter enabled status
    /// </summary>
    public bool IsFilterChecklistEnabled
    {
        get => MenuStrip.IsFilterChecklistEnabled;
        set => MenuStrip.IsFilterChecklistEnabled = value;
    }

    /// <summary>
    /// Get or Set the FilterDateAndTime enabled status
    /// </summary>
    public bool IsFilterDateAndTimeEnabled
    {
        get => MenuStrip.IsFilterDateAndTimeEnabled;
        set => MenuStrip.IsFilterDateAndTimeEnabled = value;
    }

    /// <summary>
    /// Get or Set the NOT IN logic for Filter
    /// </summary>
    public bool IsMenuStripFilterNOTINLogicEnabled
    {
        get => MenuStrip.IsFilterNotinLogicEnabled;
        set => MenuStrip.IsFilterNotinLogicEnabled = value;
    }

    /// <summary>
    /// Set the text filter search nodes behaviour
    /// </summary>
    public bool DoesTextFilterRemoveNodesOnSearch
    {
        get => MenuStrip.DoesTextFilterRemoveNodesOnSearch;
        set => MenuStrip.DoesTextFilterRemoveNodesOnSearch = value;
    }

    /// <summary>
    /// Number of nodes to enable the TextChanged delay on text filter
    /// </summary>
    public int TextFilterTextChangedDelayNodes
    {
        get => MenuStrip.TextFilterTextChangedDelayNodes;
        set => MenuStrip.TextFilterTextChangedDelayNodes = value;
    }

    /// <summary>
    /// Enabled or disable Sort capabilities
    /// </summary>
    /// <param name="enabled"></param>
    public void SetSortEnabled(bool enabled)
    {
        if (MenuStrip != null)
        {
            MenuStrip.IsSortEnabled = enabled;
            MenuStrip.SetSortEnabled(enabled);
        }
    }

    /// <summary>
    /// Enable or disable Filter capabilities
    /// </summary>
    /// <param name="enabled"></param>
    public void SetFilterEnabled(bool enabled)
    {
        if (MenuStrip != null)
        {
            MenuStrip.IsFilterEnabled = enabled;
            MenuStrip.SetFilterEnabled(enabled);
        }
    }

    /// <summary>
    /// Enable or disable Filter checklist capabilities
    /// </summary>
    /// <param name="enabled"></param>
    public void SetFilterChecklistEnabled(bool enabled)
    {
        if (MenuStrip != null)
        {
            MenuStrip.IsFilterChecklistEnabled = enabled;
            MenuStrip.SetFilterChecklistEnabled(enabled);
        }
    }

    /// <summary>
    /// Set Filter checklist nodes max
    /// </summary>
    /// <param name="maxnodes"></param>
    public void SetFilterChecklistNodesMax(int maxnodes)
    {
        if (maxnodes >= 0)
        {
            MenuStrip.MaxChecklistNodes = maxnodes;
        }
    }

    /// <summary>
    /// Enable or disable Filter checklist nodes max
    /// </summary>
    /// <param name="enabled"></param>
    public void EnabledFilterChecklistNodesMax(bool enabled)
    {
        if (MenuStrip.MaxChecklistNodes == 0 && enabled)
        {
            MenuStrip.MaxChecklistNodes = MenuStrip.DefaultMaxChecklistNodes;
        }
        else if (MenuStrip.MaxChecklistNodes != 0 && !enabled)
        {
            MenuStrip.MaxChecklistNodes = 0;
        }
    }

    /// <summary>
    /// Enable or disable Filter custom capabilities
    /// </summary>
    /// <param name="enabled"></param>
    public void SetFilterCustomEnabled(bool enabled)
    {
        if (MenuStrip != null)
        {
            MenuStrip.IsFilterCustomEnabled = enabled;
            MenuStrip.SetFilterCustomEnabled(enabled);
        }
    }

    /// <summary>
    /// Enable or disable Text filter on checklist remove node mode
    /// </summary>
    /// <param name="enabled"></param>
    public void SetChecklistTextFilterRemoveNodesOnSearchMode(bool enabled)
    {
        if (MenuStrip != null)
        {
            MenuStrip.SetChecklistTextFilterRemoveNodesOnSearchMode(enabled);
        }
    }

    /// <summary>
    /// Disable text filter TextChanged delay
    /// </summary>
    public void SetTextFilterTextChangedDelayNodesDisabled()
    {
        if (MenuStrip != null)
        {
            MenuStrip.SetTextFilterTextChangedDelayNodesDisabled();
        }
    }

    /// <summary>
    /// Set text filter TextChanged delay milliseconds
    /// </summary>
    public void SetTextFilterTextChangedDelayMs(int milliseconds)
    {
        if (MenuStrip != null)
        {
            MenuStrip.TextFilterTextChangedDelayMs = milliseconds;
        }
    }

    #endregion


    #region menustrip events

    /// <summary>
    /// OnFilterChanged event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void MenuStrip_FilterChanged(object? sender, EventArgs e)
    {
        RepaintCell();
        if (FilterAndSortEnabled && FilterChanged != null)
        {
            FilterChanged(this, new ColumnHeaderCellEventArgs(MenuStrip, OwningColumn));
        }
    }

    /// <summary>
    /// OnSortChanged event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void MenuStrip_SortChanged(object? sender, EventArgs e)
    {
        RepaintCell();
        if (FilterAndSortEnabled && SortChanged != null)
        {
            SortChanged(this, new ColumnHeaderCellEventArgs(MenuStrip, OwningColumn));
        }
    }

    /// <summary>
    /// Clean attached events
    /// </summary>
    public void CleanEvents()
    {
        MenuStrip.FilterChanged -= MenuStrip_FilterChanged;
        MenuStrip.SortChanged -= MenuStrip_SortChanged;
        _glyphFont?.Dispose();
        _glyphFont = null;
    }


    #endregion


    #region paint methods

    /// <summary>
    /// Repaint the Cell
    /// </summary>
    private void RepaintCell()
    {
        if (Displayed && DataGridView != null)
        {
            DataGridView.InvalidateCell(this);
        }
    }

    /// <summary>
    /// Draw the filter/sort dropdown after Krypton has painted the header.
    /// </summary>
    internal void PaintFilterButton(Graphics graphics, Rectangle cellBounds, Rectangle clipBounds)
    {
        if (SortGlyphDirection != SortOrder.None)
        {
            SortGlyphDirection = SortOrder.None;
        }

        if (!CanShowFilterButton)
        {
            return;
        }

        UpdateFilterButtonBounds(cellBounds);

        Rectangle buttonBounds = _filterButtonOffsetBounds;
        if (!clipBounds.IntersectsWith(buttonBounds) && !cellBounds.IntersectsWith(buttonBounds))
        {
            return;
        }

        GetFilterButtonColors(out Color backColor, out Color borderColor, out Color glyphColor, out Color headerBackColor);

        // Cover header text that would otherwise sit under the button.
        Rectangle eraseBounds = buttonBounds;
        eraseBounds.Inflate(_filterButtonMargin.Right, 0);
        eraseBounds.Intersect(cellBounds);
        using (var headerBrush = new SolidBrush(headerBackColor))
        {
            graphics.FillRectangle(headerBrush, eraseBounds);
        }

        ControlPaint.DrawBorder(graphics, buttonBounds, borderColor, ButtonBorderStyle.Solid);
        Rectangle faceBounds = buttonBounds;
        faceBounds.Inflate(-1, -1);
        using (var faceBrush = new SolidBrush(backColor))
        {
            graphics.FillRectangle(faceBrush, faceBounds);
        }

        string glyph = FilterGlyph;
        float fontSize = Math.Max(8f, faceBounds.Height * (glyph.Length > 1 ? 0.52f : 0.68f));
        Font glyphFont = GetGlyphFont(fontSize);
        TextRenderer.DrawText(
            graphics,
            glyph,
            glyphFont,
            faceBounds,
            glyphColor,
            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding | TextFormatFlags.SingleLine | TextFormatFlags.NoPrefix);
    }

    /// <summary>
    /// Pain method
    /// </summary>
    protected override void Paint(
        Graphics graphics,
        Rectangle clipBounds,
        Rectangle cellBounds,
        int rowIndex,
        DataGridViewElementStates cellState,
        object? value,
        object? formattedValue,
        string? errorText,
        DataGridViewCellStyle cellStyle,
        DataGridViewAdvancedBorderStyle advancedBorderStyle,
        DataGridViewPaintParts paintParts)
    {
        if (SortGlyphDirection != SortOrder.None)
        {
            SortGlyphDirection = SortOrder.None;
        }

        base.Paint(graphics, clipBounds, cellBounds, rowIndex,
            cellState, value, formattedValue,
            errorText, cellStyle, advancedBorderStyle, paintParts);

        if (paintParts.HasFlag(DataGridViewPaintParts.ContentBackground))
        {
            PaintFilterButton(graphics, cellBounds, clipBounds);
        }
    }

    /// <summary>
    /// Ensure column min width and header height can host the filter button.
    /// </summary>
    internal void PrepareFilterButtonLayout()
    {
        UpdateScaledMetrics();

        if (OwningColumn is null || DataGridView is null)
        {
            return;
        }

        Size min = MinimumSize;
        OwningColumn.MinimumWidth = Math.Max(OwningColumn.MinimumWidth, min.Width);
        if (DataGridView.ColumnHeadersHeight < min.Height)
        {
            DataGridView.ColumnHeadersHeight = min.Height;
        }
    }

    private bool CanShowFilterButton =>
        FilterAndSortEnabled
        && OwningColumn is not null
        && OwningColumn.ValueType != typeof(Bitmap)
        && OwningColumn.ValueType != typeof(Image);

    private bool IsRightToLeft => DataGridView?.RightToLeft == RightToLeft.Yes;

    private string FilterGlyph
    {
        get
        {
            if (ActiveFilterType == MenuStrip.FilterType.Loaded)
            {
                return GlyphSaved;
            }

            bool filtered = ActiveFilterType != MenuStrip.FilterType.None;
            return (filtered, ActiveSortType) switch
            {
                (true, MenuStrip.SortType.Asc) => GlyphFiltered + GlyphSortAsc,
                (true, MenuStrip.SortType.Desc) => GlyphFiltered + GlyphSortDesc,
                (true, _) => GlyphFiltered,
                (false, MenuStrip.SortType.Asc) => GlyphSortAsc,
                (false, MenuStrip.SortType.Desc) => GlyphSortDesc,
                _ => GlyphUnfiltered
            };
        }
    }

    private void UpdateScaledMetrics()
    {
        int dpi = DataGridView?.DeviceDpi ?? 96;
        int side = Math.Max(FilterButtonBaseSize, (FilterButtonBaseSize * dpi) / 96);
        int width = FilterGlyph.Length > 1 ? (side * 3) / 2 + 4 : side;
        _filterButtonImageSize = new Size(width, side);

        int h = Math.Max(1, (3 * dpi) / 96);
        int v = Math.Max(2, (4 * dpi) / 96);
        _filterButtonMargin = new Padding(h, v, h, v);
    }

    private void UpdateFilterButtonBounds(Rectangle? cellBounds = null)
    {
        UpdateScaledMetrics();

        Rectangle cell = cellBounds ?? (DataGridView is not null
            ? DataGridView.GetCellDisplayRectangle(ColumnIndex, -1, false)
            : Rectangle.Empty);

        if (cell.IsEmpty)
        {
            _filterButtonOffsetBounds = Rectangle.Empty;
            _filterButtonImageBounds = Rectangle.Empty;
            return;
        }

        int xOffset = IsRightToLeft
            ? cell.Left + _filterButtonMargin.Left
            : cell.Right - _filterButtonImageSize.Width - _filterButtonMargin.Right;
        int yOffset = cell.Bottom - _filterButtonImageSize.Height - _filterButtonMargin.Bottom;
        _filterButtonOffsetBounds = new Rectangle(new Point(xOffset, yOffset), _filterButtonImageSize);

        int xLocal = IsRightToLeft
            ? _filterButtonMargin.Left
            : cell.Width - _filterButtonImageSize.Width - _filterButtonMargin.Right;
        int yLocal = cell.Height - _filterButtonImageSize.Height - _filterButtonMargin.Bottom;
        _filterButtonImageBounds = new Rectangle(new Point(xLocal, yLocal), _filterButtonImageSize);
    }

    private void GetFilterButtonColors(out Color backColor, out Color borderColor, out Color glyphColor, out Color headerBackColor)
    {
        backColor = _filterButtonOver ? Color.WhiteSmoke : Color.White;
        borderColor = Color.Gray;
        glyphColor = Color.DimGray;
        headerBackColor = SystemColors.Control;

        if (DataGridView is not KryptonDataGridView kdgv)
        {
            if (DataGridView is not null)
            {
                headerBackColor = DataGridView.ColumnHeadersDefaultCellStyle.BackColor;
            }

            if (ActiveFilterType != MenuStrip.FilterType.None)
            {
                glyphColor = SystemColors.Highlight;
            }
            else if (ActiveSortType != MenuStrip.SortType.None)
            {
                glyphColor = SystemColors.ControlText;
            }

            return;
        }

        PaletteState state = _filterButtonPressed
            ? PaletteState.Pressed
            : _filterButtonOver
                ? PaletteState.Tracking
                : PaletteState.Normal;

        PaletteDataGridViewTripleStates header = state switch
        {
            PaletteState.Pressed => kdgv.StatePressed.HeaderColumn,
            PaletteState.Tracking => kdgv.StateTracking.HeaderColumn,
            _ => kdgv.StateNormal.HeaderColumn
        };

        Color paletteBack = header.Back.GetBackColor1(state);
        Color paletteBorder = header.Border.GetBorderColor1(state);
        Color paletteText = header.Content.GetContentShortTextColor1(state);

        if (!paletteBack.IsEmpty && paletteBack.A > 0)
        {
            headerBackColor = paletteBack;
            backColor = _filterButtonPressed
                ? ControlPaint.Dark(paletteBack, 0.02f)
                : _filterButtonOver
                    ? ControlPaint.Light(paletteBack, 0.45f)
                    : ControlPaint.Light(paletteBack, 0.2f);
        }

        if (!paletteBorder.IsEmpty && paletteBorder.A > 0)
        {
            borderColor = paletteBorder;
        }

        bool filtered = ActiveFilterType != MenuStrip.FilterType.None;
        bool sorted = ActiveSortType != MenuStrip.SortType.None;
        if (filtered)
        {
            glyphColor = SystemColors.Highlight;
        }
        else if (sorted)
        {
            glyphColor = paletteText.IsEmpty || paletteText.A == 0 ? SystemColors.ControlText : paletteText;
        }
        else if (!paletteText.IsEmpty && paletteText.A > 0)
        {
            glyphColor = Color.FromArgb(170, paletteText);
        }
    }

    private Font GetGlyphFont(float pixelSize)
    {
        if (_glyphFont is not null && Math.Abs(_glyphFontSize - pixelSize) < 0.5f)
        {
            return _glyphFont;
        }

        _glyphFont?.Dispose();
        _glyphFont = CreateSymbolFont(pixelSize);
        _glyphFontSize = pixelSize;
        return _glyphFont;
    }

    private static Font CreateSymbolFont(float pixelSize)
    {
        string[] families = ["Segoe UI Symbol", "Segoe UI", "Microsoft Sans Serif"];
        foreach (string family in families)
        {
            try
            {
                var font = new Font(family, pixelSize, FontStyle.Regular, GraphicsUnit.Pixel);
                if (string.Equals(font.Name, family, StringComparison.OrdinalIgnoreCase)
                    || font.FontFamily.Name.IndexOf("Segoe", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    return font;
                }

                font.Dispose();
            }
            catch
            {
                // Try the next installed family.
            }
        }

        return new Font(FontFamily.GenericSansSerif, pixelSize, FontStyle.Regular, GraphicsUnit.Pixel);
    }

    #endregion


    #region mouse events

    /// <summary>
    /// OnMouseMove event
    /// </summary>
    /// <param name="e"></param>
    protected override void OnMouseMove(DataGridViewCellMouseEventArgs e)
    {
        if (CanShowFilterButton)
        {
            UpdateFilterButtonBounds();
            if (_filterButtonImageBounds.Contains(e.X, e.Y) && !_filterButtonOver)
            {
                _filterButtonOver = true;
                RepaintCell();
            }
            else if (!_filterButtonImageBounds.Contains(e.X, e.Y) && _filterButtonOver)
            {
                _filterButtonOver = false;
                RepaintCell();
            }
        }
        base.OnMouseMove(e);
    }

    /// <summary>
    /// OnMouseDown event
    /// </summary>
    /// <param name="e"></param>
    protected override void OnMouseDown(DataGridViewCellMouseEventArgs e)
    {
        if (CanShowFilterButton)
        {
            UpdateFilterButtonBounds();
        }

        if (CanShowFilterButton && _filterButtonImageBounds.Contains(e.X, e.Y))
        {
            if (e.Button == MouseButtons.Left && !_filterButtonPressed)
            {
                _filterButtonPressed = true;
                _filterButtonOver = true;
                RepaintCell();
            }
        }
        else
        {
            base.OnMouseDown(e);
        }
    }

    /// <summary>
    /// OnMouseUp event
    /// </summary>
    /// <param name="e"></param>
    protected override void OnMouseUp(DataGridViewCellMouseEventArgs e)
    {
        if (CanShowFilterButton)
        {
            UpdateFilterButtonBounds();
        }

        if (CanShowFilterButton && e.Button == MouseButtons.Left && _filterButtonPressed)
        {
            _filterButtonPressed = false;
            _filterButtonOver = false;
            RepaintCell();
            if (_filterButtonImageBounds.Contains(e.X, e.Y) && FilterPopup != null)
            {
                FilterPopup(this, new ColumnHeaderCellEventArgs(MenuStrip, OwningColumn));
            }
        }
        base.OnMouseUp(e);
    }

    /// <summary>
    /// OnMouseLeave event
    /// </summary>
    /// <param name="rowIndex"></param>
    protected override void OnMouseLeave(int rowIndex)
    {
        if (FilterAndSortEnabled && _filterButtonOver)
        {
            _filterButtonOver = false;
            RepaintCell();
        }

        base.OnMouseLeave(rowIndex);
    }

    #endregion
}