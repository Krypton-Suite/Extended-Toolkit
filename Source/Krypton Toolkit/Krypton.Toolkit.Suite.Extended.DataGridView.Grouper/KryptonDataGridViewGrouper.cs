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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Grid.Grouper;

/// <summary>
/// Clean-room projection-style grid grouping: builds a bound intermediate <see cref="DataTable"/>
/// with synthesized group header rows. Intended for <see cref="Krypton.Toolkit.KryptonDataGridView"/> or any <see cref="DataGridView"/>.
/// </summary>
[DefaultProperty(nameof(DataGridView))]
[ToolboxItem(true)]
public sealed class KryptonDataGridViewGrouper : Component
{
    public const string DragDataFormat =
        nameof(Krypton) + nameof(Toolkit) + ".DataGridView.Grouper.DataProperty";

    private DataGridView? _grid;

    /// <remarks>Captured before the first grouping apply and restored after <see cref="ClearGrouping"/>.</remarks>
    private object? _baseDataSource;

    private string? _baseDataMember;
    private DataTable? _activeGroupedSnapshot;
    private readonly List<string> _groupLevels = [];

    /// <inheritdoc />
    /// <remarks>Passes <paramref name="container"/> to underlying <see cref="Component"/>.
    /// </remarks>
    public KryptonDataGridViewGrouper(IContainer? container)
    {
        container?.Add(this);
    }

    /// <summary>
    /// Creates a grouper targeting the supplied grid.
    /// </summary>
    public KryptonDataGridViewGrouper(DataGridView grid) : this() => DataGridView = grid;

    /// <summary>
    /// Creates a grouper without an initial grid.
    /// </summary>
    public KryptonDataGridViewGrouper()
    {
        Options = new DataGridViewGrouperOptions();
    }

    public DataGridView? DataGridView
    {
        get => _grid;
        set => SwapGridHooks(_grid, value);
    }

    public DataGridViewGrouperOptions Options { get; set; }

    public SortOrder GroupSortOrder { get; set; } = SortOrder.Ascending;

    public IReadOnlyList<string> GroupLevels => _groupLevels;

    public IDictionary<string, bool> CollapseState { get; } = new Dictionary<string, bool>(StringComparer.Ordinal);

    public event EventHandler? GroupingChanged;

    private bool _internalApply;
    private bool _headerMouseDown;
    private int _headerColumnIndex = -1;
    private Point _headerDownPoint;
    private Font? _groupRowFont;

    /// <summary>True when the bound table is the projection produced by this grouper.</summary>
    public bool IsGrouped =>
        _grid != null
        && _activeGroupedSnapshot != null
        && ReferenceEquals(_grid.DataSource, _activeGroupedSnapshot);

    /// <summary>Replaces the ordered hierarchy (outermost first).</summary>
    public void SetGroupLevels(IEnumerable<string> dataPropertyNames)
    {
        _groupLevels.Clear();
        _groupLevels.AddRange(dataPropertyNames
            .Where(s => !string.IsNullOrWhiteSpace(s))
            .Select(static s => s!));
        Apply(true);
    }

    public void AddGroupLevel(string dataPropertyName)
    {
        if (string.IsNullOrWhiteSpace(dataPropertyName))
        {
            return;
        }

        if (!_groupLevels.Contains(dataPropertyName, StringComparer.OrdinalIgnoreCase))
        {
            _groupLevels.Add(dataPropertyName);
        }

        Apply(true);
    }

    public bool RemoveGroupLevel(string dataPropertyName)
    {
        int removed = _groupLevels.RemoveAll(s =>
            string.Equals(s, dataPropertyName, StringComparison.OrdinalIgnoreCase));

        if (removed > 0)
        {
            Apply(true);
        }

        return removed > 0;
    }

    public void ClearGroupLevels() => _groupLevels.Clear();

    /// <summary>Convenience single-column grouping (clears prior levels).</summary>
    public bool SetGroupOn(string? dataPropertyName)
    {
        if (string.IsNullOrWhiteSpace(dataPropertyName))
        {
            ClearGrouping();
            return false;
        }

        _groupLevels.Clear();
        _groupLevels.Add(dataPropertyName!);
        Apply(true);
        return true;
    }

    public void ClearGrouping()
    {
        if (_grid == null)
        {
            return;
        }

        _groupLevels.Clear();
        CollapseState.Clear();
        _activeGroupedSnapshot = null;

        _internalApply = true;
        try
        {
            _grid.DataMember = _baseDataMember;
            _grid.DataSource = _baseDataSource;
        }
        finally
        {
            _internalApply = false;
        }

        _baseDataSource = null;
        _baseDataMember = null;
        GroupingChanged?.Invoke(this, EventArgs.Empty);
    }

    public void Refresh()
    {
        if (_groupLevels.Count == 0)
        {
            return;
        }

        Apply(true);
    }

    public void ExpandAll()
    {
        AssignCollapseToAll(false);
        Apply(true);
    }

    public void CollapseAll()
    {
        AssignCollapseToAll(true);
        Apply(true);
    }

    private void AssignCollapseToAll(bool collapsed)
    {
        if (_activeGroupedSnapshot == null)
        {
            return;
        }

        foreach (DataRow r in _activeGroupedSnapshot.Rows)
        {
            object? mark = r[DataGridViewGrouperSchema.IsGroup];
            object? pathCell = r[DataGridViewGrouperSchema.GroupPath];
            if (mark is true && pathCell is string path && !string.IsNullOrEmpty(path))
            {
                CollapseState[path] = collapsed;
            }
        }
    }

    /// <summary>Toggles expand/collapse for the group path stored on the row.</summary>
    public void ToggleGroupPath(string path)
    {
        if (string.IsNullOrEmpty(path))
        {
            return;
        }

        if (!CollapseState.TryGetValue(path, out bool cur))
        {
            cur = Options.StartCollapsed;
        }

        CollapseState[path] = !cur;
        Apply(true);
    }

    private void Apply(bool raise)
    {
        if (_grid == null || _groupLevels.Count == 0)
        {
            if (_groupLevels.Count == 0 && _activeGroupedSnapshot != null)
            {
                ClearGrouping();
            }

            return;
        }

        if (!ReferenceEquals(_grid.DataSource, _activeGroupedSnapshot))
        {
            _baseDataSource ??= _grid.DataSource;
            _baseDataMember ??= _grid.DataMember;
        }

        if (!GroupedDataSourceResolver.TryResolve(_baseDataSource, _baseDataMember, out GroupedResolvedSource resolved)
            || resolved.TableTemplate is null)
        {
            return;
        }

        if (!GroupedTableComposer.TryCompose(
                resolved,
                _groupLevels,
                GroupSortOrder,
                Options,
                CollapseState,
                out DataTable? composed))
        {
            return;
        }

        _internalApply = true;
        try
        {
            _grid.DataSource = composed;
            _grid.DataMember = string.Empty;
            _activeGroupedSnapshot = composed;
        }
        finally
        {
            _internalApply = false;
        }

        HideInternalColumns();

        if (raise)
        {
            GroupingChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    private void HideInternalColumns()
    {
        if (_grid == null)
        {
            return;
        }

        foreach (DataGridViewColumn column in _grid.Columns)
        {
            if (column.DataPropertyName.StartsWith("__KG_", StringComparison.Ordinal))
            {
                column.Visible = false;
            }
        }
    }

    private void SwapGridHooks(DataGridView? oldGrid, DataGridView? newGrid)
    {
        if (ReferenceEquals(oldGrid, newGrid))
        {
            return;
        }

        if (oldGrid != null)
        {
            oldGrid.DataSourceChanged -= OnGridDataSourceChanged;
            oldGrid.CellBeginEdit -= OnCellBeginEdit;
            oldGrid.CellDoubleClick -= OnCellDoubleClick;
            oldGrid.MouseDown -= OnGridMouseDown;
            oldGrid.MouseMove -= OnGridMouseMove;
            oldGrid.DataBindingComplete -= OnDataBindingComplete;
        }

        _grid = newGrid;

        if (_grid != null)
        {
            _grid.DataSourceChanged += OnGridDataSourceChanged;
            _grid.CellBeginEdit += OnCellBeginEdit;
            _grid.CellDoubleClick += OnCellDoubleClick;
            _grid.MouseDown += OnGridMouseDown;
            _grid.MouseMove += OnGridMouseMove;
            _grid.DataBindingComplete += OnDataBindingComplete;
        }
    }

    private void OnDataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e)
    {
        if (_grid == null || !IsGrouped)
        {
            return;
        }

        _groupRowFont?.Dispose();
        _groupRowFont = new Font(_grid.Font, _grid.Font.Style | Options.GroupHeaderFontStyle);

        foreach (DataGridViewRow row in _grid.Rows)
        {
            if (row.IsNewRow)
            {
                continue;
            }

            if (TryGetGroupHeader(row, out bool isGroup) && isGroup)
            {
                row.Height = Math.Max(18, Options.GroupRowHeight);
                row.DefaultCellStyle.Font = _groupRowFont;
            }
        }
    }

    private void OnGridDataSourceChanged(object? sender, EventArgs e)
    {
        if (_internalApply)
        {
            return;
        }

        if (_activeGroupedSnapshot != null && ReferenceEquals(_grid?.DataSource, _activeGroupedSnapshot))
        {
            return;
        }

        _baseDataSource = _grid?.DataSource;
        _baseDataMember = _grid?.DataMember;
        _activeGroupedSnapshot = null;
        _groupLevels.Clear();
        CollapseState.Clear();
    }

    private void OnCellBeginEdit(object? sender, DataGridViewCellCancelEventArgs e)
    {
        if (_grid == null || e.RowIndex < 0)
        {
            return;
        }

        DataGridViewRow row = _grid.Rows[e.RowIndex];
        if (TryGetGroupHeader(row, out bool isGroup) && isGroup)
        {
            e.Cancel = true;
        }
    }

    private void OnCellDoubleClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (_grid == null || e.RowIndex < 0)
        {
            return;
        }

        DataGridViewRow row = _grid.Rows[e.RowIndex];
        if (!TryGetGroupMeta(row, out bool isGroup, out string path) || !isGroup)
        {
            return;
        }

        ToggleGroupPath(path);
    }

    private void OnGridMouseDown(object? sender, MouseEventArgs e)
    {
        if (_grid == null || e.Button != MouseButtons.Left)
        {
            return;
        }

        DataGridView.HitTestInfo hit = _grid.HitTest(e.X, e.Y);
        if (hit.RowIndex != -1 || hit.ColumnIndex < 0 || hit.ColumnIndex >= _grid.ColumnCount)
        {
            _headerMouseDown = false;
            _headerColumnIndex = -1;
            return;
        }

        _headerMouseDown = true;
        _headerDownPoint = e.Location;
        _headerColumnIndex = hit.ColumnIndex;
    }

    private void OnGridMouseMove(object? sender, MouseEventArgs e)
    {
        if (!_headerMouseDown || _grid == null || e.Button != MouseButtons.Left || _headerColumnIndex < 0)
        {
            return;
        }

        Size threshold = SystemInformation.DragSize;
        var dx = Math.Abs(e.X - _headerDownPoint.X);
        var dy = Math.Abs(e.Y - _headerDownPoint.Y);
        if (dx <= threshold.Width / 2 && dy <= threshold.Height / 2)
        {
            return;
        }

        DataGridViewColumn column = _grid.Columns[_headerColumnIndex];
        if (string.IsNullOrEmpty(column.DataPropertyName))
        {
            _headerMouseDown = false;
            return;
        }

        _grid.DoDragDrop(
            new DataObject(DragDataFormat, column.DataPropertyName),
            DragDropEffects.Copy);

        _headerMouseDown = false;
        _headerColumnIndex = -1;
    }

    private static bool TryGetGroupHeader(DataGridViewRow row, out bool isGroup)
    {
        isGroup = false;
        if (row.DataBoundItem is not DataRowView drv)
        {
            return false;
        }

        object? cell = drv.Row[DataGridViewGrouperSchema.IsGroup];
        if (cell is bool b)
        {
            isGroup = b;
            return true;
        }

        return false;
    }

    private static bool TryGetGroupMeta(DataGridViewRow row, out bool isGroup, out string path)
    {
        path = string.Empty;
        isGroup = false;
        if (row.DataBoundItem is not DataRowView drv)
        {
            return false;
        }

        object? flag = drv.Row[DataGridViewGrouperSchema.IsGroup];
        if (flag is not bool b || !b)
        {
            return false;
        }

        isGroup = true;
        path = drv.Row[DataGridViewGrouperSchema.GroupPath]?.ToString() ?? string.Empty;
        return !string.IsNullOrEmpty(path);
    }

    /// <inheritdoc />
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            DataGridView = null;
            _groupRowFont?.Dispose();
            _groupRowFont = null;
        }

        base.Dispose(disposing);
    }
}
