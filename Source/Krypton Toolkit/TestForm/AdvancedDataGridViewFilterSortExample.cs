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
 */
#endregion

using System.Data;
using System.IO;

using Krypton.Toolkit.Suite.Extended.AdvancedDataGridView;

namespace TestForm;

/// <summary>
/// Comprehensive TestForm demo for <see cref="KryptonAdvancedDataGridView"/> Excel-style
/// header filter/sort dropdowns (issue #443).
/// </summary>
public sealed class AdvancedDataGridViewFilterSortExample : KryptonForm
{
    private const int InitialRowCount = 160;

    private static readonly string[] Products =
    [
        "Notebook", "Stapler", "USB-C Hub", "Desk Lamp", "Water Bottle",
        "Keyboard", "Mouse", "Monitor Arm", "Desk Plant", "Webcam"
    ];

    private static readonly string[] Categories =
    [
        "Office", "Electronics", "Outdoor", "Kitchen", "Office", "Electronics"
    ];

    private readonly DataSet _dataSet = new();
    private readonly DataTable _table;
    private readonly BindingSource _bindingSource = new();
    private readonly List<(string Name, string Filter, string Sort)> _savedViews = [];
    private readonly Dictionary<string, ColumnOptionState> _columnOptions = new(StringComparer.Ordinal);
    private readonly List<Image> _flagImages = [];

    private readonly KryptonAdvancedDataGridView _grid = new();
    private readonly KryptonAdvancedDataGridViewSearchToolBar _searchBar = new();
    private readonly KryptonTextBox _txtProductContains = new();
    private readonly KryptonTextBox _txtFilterString = new();
    private readonly KryptonTextBox _txtSortString = new();
    private readonly KryptonLabel _lblRowCount = new();
    private readonly KryptonComboBox _cmbSavedViews = new();
    private readonly KryptonComboBox _cmbColumn = new();
    private readonly KryptonCheckBox _chkFilterAndSort = new();
    private readonly KryptonCheckBox _chkRtl = new();
    private readonly KryptonCheckBox _chkNotInLogic = new();
    private readonly KryptonCheckBox _chkColFilterAndSort = new();
    private readonly KryptonCheckBox _chkColSort = new();
    private readonly KryptonCheckBox _chkColFilter = new();
    private readonly KryptonCheckBox _chkColChecklist = new();
    private readonly KryptonCheckBox _chkColCustom = new();
    private readonly KryptonCheckBox _chkColDateTime = new();

    private bool _suppressColumnOptionEvents;
    private int _nextId = 1;

    public AdvancedDataGridViewFilterSortExample()
    {
        _table = _dataSet.Tables.Add("Orders");

        Text = "Advanced Data Grid — Filter & Sort";
        StartPosition = FormStartPosition.CenterScreen;
        MinimumSize = new Size(1100, 720);
        Size = new Size(1280, 820);
        AutoScaleMode = AutoScaleMode.Dpi;
        AutoScaleDimensions = new SizeF(96F, 96F);

        BuildLayout();
        ConfigureGrid();
        Load += (_, _) =>
        {
            ReloadData(InitialRowCount);
            ApplyColumnDefaults();
            RefreshColumnOptionEditor();
        };
        FormClosed += (_, _) =>
        {
            foreach (Image image in _flagImages)
            {
                image.Dispose();
            }
        };
    }

    private void BuildLayout()
    {
        var root = new KryptonPanel { Dock = DockStyle.Fill };
        Controls.Add(root);

        var layout = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            BackColor = Color.Transparent,
            ColumnCount = 1,
            RowCount = 6,
            Padding = new Padding(8)
        };
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 92F));
        root.Controls.Add(layout);

        layout.Controls.Add(CreateLegend(), 0, 0);
        layout.Controls.Add(CreateToolbar(), 0, 1);
        layout.Controls.Add(CreateColumnOptions(), 0, 2);

        _searchBar.GripStyle = ToolStripGripStyle.Hidden;
        _searchBar.Dock = DockStyle.Top;
        _searchBar.Search += OnSearch;
        layout.Controls.Add(_searchBar, 0, 3);

        _grid.Dock = DockStyle.Fill;
        _grid.FilterAndSortEnabled = true;
        _grid.AllowUserToAddRows = false;
        _grid.AllowUserToDeleteRows = false;
        _grid.RowHeadersVisible = true;
        _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        _grid.SetDoubleBuffered();
        _grid.FilterStringChanged += OnFilterStringChanged;
        _grid.SortStringChanged += OnSortStringChanged;
        layout.Controls.Add(_grid, 0, 4);

        layout.Controls.Add(CreateStatusPanel(), 0, 5);
    }

    private static Control CreateLegend()
    {
        var header = new KryptonHeaderGroup
        {
            Dock = DockStyle.Top,
            Height = 78,
            MinimumSize = new Size(0, 78)
        };
        header.ValuesPrimary.Heading = "Header filter glyphs";
        header.ValuesPrimary.Description = "Click the button on the right of a column header.";
        header.ValuesPrimary.Image = null;
        header.HeaderVisibleSecondary = false;

        var legend = new KryptonWrapLabel
        {
            Dock = DockStyle.Fill,
            Text = "▾ idle   ·   ∇ filtered   ·   ▲ / ▼ sorted   ·   ∇▲ / ∇▼ filtered + sorted   ·   ★ saved view.  " +
                   "Image columns have no dropdown. Use the header menu for checklist, custom, and sort. " +
                   "Switch the theme on the Start Screen to confirm palette-aware button colours."
        };
        header.Panel.Controls.Add(legend);
        return header;
    }

    private Control CreateToolbar()
    {
        var flow = new FlowLayoutPanel
        {
            Dock = DockStyle.Top,
            AutoSize = true,
            WrapContents = true,
            BackColor = Color.Transparent,
            Padding = new Padding(0, 4, 0, 4)
        };

        flow.Controls.Add(CreateButton("Reload 160 rows", (_, _) => ReloadData(InitialRowCount)));
        flow.Controls.Add(CreateButton("Add 40 rows", (_, _) => AddRows(40)));
        flow.Controls.Add(CreateButton("Sort Product A–Z", (_, _) => SortColumn("Product", ascending: true)));
        flow.Controls.Add(CreateButton("Sort Price high–low", (_, _) => SortColumn("Price", ascending: false)));
        flow.Controls.Add(CreateButton("Open Category filter", (_, _) => OpenFilter("Category")));
        flow.Controls.Add(CreateButton("Save view", (_, _) => SaveCurrentView()));
        flow.Controls.Add(CreateButton("Apply view", (_, _) => ApplySavedView()));
        flow.Controls.Add(CreateButton("Clear filter & sort", (_, _) =>
        {
            _txtProductContains.Text = string.Empty;
            _grid.CleanFilterAndSort();
        }));

        _cmbSavedViews.Width = 160;
        _cmbSavedViews.DropDownStyle = ComboBoxStyle.DropDownList;
        flow.Controls.Add(WrapLabeled("Saved views", _cmbSavedViews));

        _chkFilterAndSort.Values.Text = "Filter & sort enabled";
        _chkFilterAndSort.Checked = true;
        _chkFilterAndSort.CheckedChanged += (_, _) => _grid.FilterAndSortEnabled = _chkFilterAndSort.Checked;
        flow.Controls.Add(_chkFilterAndSort);

        _chkRtl.Values.Text = "Right to left";
        _chkRtl.CheckedChanged += (_, _) =>
            RightToLeft = _chkRtl.Checked ? RightToLeft.Yes : RightToLeft.No;
        flow.Controls.Add(_chkRtl);

        _chkNotInLogic.Values.Text = "Checklist NOT IN logic";
        _chkNotInLogic.CheckedChanged += (_, _) => _grid.SetMenuStripFilterNotInLogic(_chkNotInLogic.Checked);
        flow.Controls.Add(_chkNotInLogic);

        return flow;
    }

    private Control CreateColumnOptions()
    {
        var group = new KryptonGroupBox
        {
            Dock = DockStyle.Top,
            Height = 72,
            MinimumSize = new Size(0, 72)
        };
        group.Values.Heading = "Per-column options";

        var flow = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            AutoSize = true,
            WrapContents = true,
            BackColor = Color.Transparent,
            Padding = new Padding(4)
        };

        _cmbColumn.Width = 140;
        _cmbColumn.DropDownStyle = ComboBoxStyle.DropDownList;
        _cmbColumn.SelectedIndexChanged += (_, _) => RefreshColumnOptionEditor();
        flow.Controls.Add(WrapLabeled("Column", _cmbColumn));

        ConfigureColumnCheck(_chkColFilterAndSort, "Filter & sort", (column, enabled) =>
            _grid.SetFilterAndSortEnabled(column, enabled));
        ConfigureColumnCheck(_chkColSort, "Sort", (column, enabled) =>
            _grid.SetSortEnabled(column, enabled));
        ConfigureColumnCheck(_chkColFilter, "Filter", (column, enabled) =>
            _grid.SetFilterEnabled(column, enabled));
        ConfigureColumnCheck(_chkColChecklist, "Checklist", (column, enabled) =>
            _grid.SetFilterChecklistEnabled(column, enabled));
        ConfigureColumnCheck(_chkColCustom, "Custom filter", (column, enabled) =>
            _grid.SetFilterCustomEnabled(column, enabled));
        ConfigureColumnCheck(_chkColDateTime, "Date and time", (column, enabled) =>
            _grid.SetFilterDateAndTimeEnabled(column, enabled));

        flow.Controls.Add(_chkColFilterAndSort);
        flow.Controls.Add(_chkColSort);
        flow.Controls.Add(_chkColFilter);
        flow.Controls.Add(_chkColChecklist);
        flow.Controls.Add(_chkColCustom);
        flow.Controls.Add(_chkColDateTime);
        flow.Controls.Add(CreateButton("Open this filter", (_, _) =>
        {
            DataGridViewColumn? column = SelectedColumn();
            if (column is not null)
            {
                _grid.ShowMenuStrip(column);
            }
        }));

        var extraFilter = WrapLabeled("Product contains", _txtProductContains);
        _txtProductContains.Width = 160;
        _txtProductContains.TextChanged += (_, _) => _grid.TriggerFilterStringChanged();
        flow.Controls.Add(extraFilter);

        group.Panel.Controls.Add(flow);
        return group;
    }

    private Control CreateStatusPanel()
    {
        var panel = new KryptonPanel { Dock = DockStyle.Fill };
        var layout = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            BackColor = Color.Transparent,
            ColumnCount = 4,
            RowCount = 2,
            Padding = new Padding(4)
        };
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90F));
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

        _lblRowCount.Values.Text = "Rows: 0";
        layout.Controls.Add(_lblRowCount, 0, 0);
        layout.SetColumnSpan(_lblRowCount, 4);

        layout.Controls.Add(new KryptonLabel { Values = { Text = "Filter" } }, 0, 1);
        _txtFilterString.Multiline = true;
        _txtFilterString.ReadOnly = true;
        _txtFilterString.Dock = DockStyle.Fill;
        _txtFilterString.ScrollBars = ScrollBars.Vertical;
        layout.Controls.Add(_txtFilterString, 1, 1);

        layout.Controls.Add(new KryptonLabel { Values = { Text = "Sort" } }, 2, 1);
        _txtSortString.Multiline = true;
        _txtSortString.ReadOnly = true;
        _txtSortString.Dock = DockStyle.Fill;
        _txtSortString.ScrollBars = ScrollBars.Vertical;
        layout.Controls.Add(_txtSortString, 3, 1);

        panel.Controls.Add(layout);
        return panel;
    }

    private void ConfigureGrid()
    {
        _table.Columns.Add("Id", typeof(int));
        _table.Columns.Add("Product", typeof(string));
        _table.Columns.Add("Category", typeof(string));
        _table.Columns.Add("Price", typeof(decimal));
        _table.Columns.Add("Qty", typeof(int));
        _table.Columns.Add("InStock", typeof(bool));
        _table.Columns.Add("Ordered", typeof(DateTime));
        _table.Columns.Add("Updated", typeof(DateTime));
        _table.Columns.Add("Duration", typeof(TimeSpan));
        _table.Columns.Add("Sku", typeof(Guid));
        _table.Columns.Add("Flag", typeof(Bitmap));

        _bindingSource.DataSource = _dataSet;
        _bindingSource.DataMember = _table.TableName;
        _bindingSource.ListChanged += (_, _) => UpdateRowCount();
        _grid.DataSource = _bindingSource;
    }

    private void ReloadData(int count)
    {
        _grid.CleanFilterAndSort();
        _txtProductContains.Text = string.Empty;
        _table.Rows.Clear();
        _nextId = 1;
        AddRows(count);
        FormatColumns();
        _searchBar.SetColumns(_grid.Columns);
        UpdateRowCount();
    }

    private void AddRows(int count)
    {
        EnsureFlagImages();
        var random = new Random();
        int maxMinutes = (int)TimeSpan.FromHours(12).TotalMinutes;

        for (int i = 0; i < count; i++)
        {
            string? product = _nextId % 7 == 0 ? null : Products[random.Next(Products.Length)];
            string category = _nextId % 11 == 0 ? string.Empty : Categories[random.Next(Categories.Length)];
            DateTime ordered = DateTime.Today.AddDays(-random.Next(0, 120));
            DateTime updated = ordered.AddHours(random.Next(0, 48)).AddMinutes(random.Next(0, 60));

            _table.Rows.Add(
                _nextId,
                product,
                category,
                Math.Round((decimal)(random.Next(5, 240) + random.NextDouble()), 2),
                random.Next(0, 50),
                _nextId % 3 != 0,
                ordered,
                updated,
                TimeSpan.FromMinutes(random.Next(15, maxMinutes)),
                Guid.NewGuid(),
                _flagImages[random.Next(_flagImages.Count)]);

            _nextId++;
        }
    }

    private void FormatColumns()
    {
        if (_grid.Columns["Id"] is DataGridViewColumn id)
        {
            id.HeaderText = "Id";
            id.Frozen = true;
        }

        if (_grid.Columns["Product"] is DataGridViewColumn product)
        {
            product.HeaderText = "Product";
            product.MinimumWidth = 120;
        }

        if (_grid.Columns["Category"] is DataGridViewColumn category)
        {
            category.HeaderText = "Category";
        }

        if (_grid.Columns["Price"] is DataGridViewColumn price)
        {
            price.HeaderText = "Price";
            price.DefaultCellStyle.Format = "C2";
            price.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        if (_grid.Columns["Qty"] is DataGridViewColumn qty)
        {
            qty.HeaderText = "Qty";
            qty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        if (_grid.Columns["InStock"] is DataGridViewColumn inStock)
        {
            inStock.HeaderText = "In stock";
        }

        if (_grid.Columns["Ordered"] is DataGridViewColumn ordered)
        {
            ordered.HeaderText = "Ordered";
            ordered.DefaultCellStyle.Format = "d";
        }

        if (_grid.Columns["Updated"] is DataGridViewColumn updated)
        {
            updated.HeaderText = "Updated";
            updated.DefaultCellStyle.Format = "g";
        }

        if (_grid.Columns["Duration"] is DataGridViewColumn duration)
        {
            duration.HeaderText = "Duration";
            duration.DefaultCellStyle.Format = @"hh\:mm";
        }

        if (_grid.Columns["Sku"] is DataGridViewColumn sku)
        {
            sku.HeaderText = "Sku";
        }

        if (_grid.Columns["Flag"] is DataGridViewColumn flag)
        {
            flag.HeaderText = "Flag";
            flag.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
    }

    private void ApplyColumnDefaults()
    {
        _columnOptions.Clear();
        foreach (DataGridViewColumn column in _grid.Columns)
        {
            var state = new ColumnOptionState();
            switch (column.Name)
            {
                case "Sku":
                    state.Sort = false;
                    state.Checklist = false;
                    break;
                case "Updated":
                    state.DateAndTime = true;
                    break;
                case "Duration":
                    state.Custom = false;
                    break;
                case "Flag":
                    state.FilterAndSort = false;
                    state.Sort = false;
                    state.Filter = false;
                    state.Checklist = false;
                    state.Custom = false;
                    break;
            }

            _columnOptions[column.Name] = state;
            ApplyColumnState(column, state);
        }

        if (_grid.Columns["Product"] is DataGridViewColumn product)
        {
            _grid.SetFilterChecklistTextFilterTextChangedDelayNodes(product, 8);
            _grid.SetFilterChecklistTextFilterTextChangedDelayMs(product, 400);
        }

        _cmbColumn.DataSource = null;
        _cmbColumn.DataSource = _grid.Columns.Cast<DataGridViewColumn>().Select(c => c.Name).ToList();
    }

    private void ApplyColumnState(DataGridViewColumn column, ColumnOptionState state)
    {
        _grid.SetFilterAndSortEnabled(column, state.FilterAndSort);
        _grid.SetSortEnabled(column, state.Sort);
        _grid.SetFilterEnabled(column, state.Filter);
        _grid.SetFilterChecklistEnabled(column, state.Checklist);
        _grid.SetFilterCustomEnabled(column, state.Custom);
        _grid.SetFilterDateAndTimeEnabled(column, state.DateAndTime);
    }

    private void RefreshColumnOptionEditor()
    {
        DataGridViewColumn? column = SelectedColumn();
        if (column is null || !_columnOptions.TryGetValue(column.Name, out ColumnOptionState? state))
        {
            return;
        }

        _suppressColumnOptionEvents = true;
        _chkColFilterAndSort.Checked = state.FilterAndSort;
        _chkColSort.Checked = state.Sort;
        _chkColFilter.Checked = state.Filter;
        _chkColChecklist.Checked = state.Checklist;
        _chkColCustom.Checked = state.Custom;
        _chkColDateTime.Checked = state.DateAndTime;
        _suppressColumnOptionEvents = false;
    }

    private void ConfigureColumnCheck(KryptonCheckBox checkBox, string text, Action<DataGridViewColumn, bool> apply)
    {
        checkBox.Values.Text = text;
        checkBox.CheckedChanged += (_, _) =>
        {
            if (_suppressColumnOptionEvents)
            {
                return;
            }

            DataGridViewColumn? column = SelectedColumn();
            if (column is null || !_columnOptions.TryGetValue(column.Name, out ColumnOptionState? state))
            {
                return;
            }

            state.FilterAndSort = _chkColFilterAndSort.Checked;
            state.Sort = _chkColSort.Checked;
            state.Filter = _chkColFilter.Checked;
            state.Checklist = _chkColChecklist.Checked;
            state.Custom = _chkColCustom.Checked;
            state.DateAndTime = _chkColDateTime.Checked;
            apply(column, checkBox.Checked);
        };
    }

    private DataGridViewColumn? SelectedColumn()
    {
        if (_cmbColumn.SelectedItem is string name && _grid.Columns.Contains(name))
        {
            return _grid.Columns[name];
        }

        return null;
    }

    private void SortColumn(string columnName, bool ascending)
    {
        if (!_grid.Columns.Contains(columnName))
        {
            return;
        }

        DataGridViewColumn column = _grid.Columns[columnName]!;
        if (ascending)
        {
            _grid.SortAscending(column);
        }
        else
        {
            _grid.SortDescending(column);
        }
    }

    private void OpenFilter(string columnName)
    {
        if (_grid.Columns.Contains(columnName))
        {
            _grid.ShowMenuStrip(_grid.Columns[columnName]!);
        }
    }

    private void SaveCurrentView()
    {
        string name = $"View {_savedViews.Count + 1}";
        _savedViews.Add((name, _grid.FilterString ?? string.Empty, _grid.SortString ?? string.Empty));
        _cmbSavedViews.DataSource = null;
        _cmbSavedViews.DataSource = _savedViews.Select(v => v.Name).ToList();
        _cmbSavedViews.SelectedIndex = _savedViews.Count - 1;
    }

    private void ApplySavedView()
    {
        if (_cmbSavedViews.SelectedIndex < 0 || _cmbSavedViews.SelectedIndex >= _savedViews.Count)
        {
            return;
        }

        (string _, string filter, string sort) = _savedViews[_cmbSavedViews.SelectedIndex];
        _grid.LoadFilterAndSort(filter, sort);
    }

    private void OnFilterStringChanged(object? sender, KryptonAdvancedDataGridView.FilterEventArgs e)
    {
        string extra = _txtProductContains.Text.Trim();
        if (extra.Length > 0)
        {
            string clause = $"Product LIKE '%{extra.Replace("'", "''")}%'";
            e.FilterString += (string.IsNullOrEmpty(e.FilterString) ? string.Empty : " AND ") + clause;
        }

        _txtFilterString.Text = e.FilterString;
        UpdateRowCount();
    }

    private void OnSortStringChanged(object? sender, KryptonAdvancedDataGridView.SortEventArgs e)
    {
        _txtSortString.Text = e.SortString;
    }

    private void OnSearch(object? sender, AdvancedDataGridViewSearchToolBarSearchEventArgs e)
    {
        int startColumn = 0;
        int startRow = 0;
        if (!e.FromBegin && _grid.CurrentCell is not null)
        {
            bool endColumn = _grid.CurrentCell.ColumnIndex + 1 >= _grid.ColumnCount;
            startColumn = endColumn ? 0 : _grid.CurrentCell.ColumnIndex + 1;
            startRow = _grid.CurrentCell.RowIndex + (endColumn ? 1 : 0);
        }

        DataGridViewCell? cell = _grid.FindCell(
            e.ValueToSearch,
            e.ColumnToSearch?.Name!,
            startRow,
            startColumn,
            e.WholeWord,
            e.CaseSensitive) ?? _grid.FindCell(
            e.ValueToSearch,
            e.ColumnToSearch?.Name!,
            0,
            0,
            e.WholeWord,
            e.CaseSensitive);

        if (cell is not null)
        {
            _grid.CurrentCell = cell;
        }
    }

    private void UpdateRowCount()
    {
        _lblRowCount.Values.Text = $"Rows: {_bindingSource.List.Count} visible / {_table.Rows.Count} total";
    }

    private void EnsureFlagImages()
    {
        if (_flagImages.Count > 0)
        {
            return;
        }

        Image? green = TryLoadImage("flag-green_24.png");
        Image? red = TryLoadImage("flag-red_24.png");
        _flagImages.Add(green ?? CreateSwatch(Color.ForestGreen));
        _flagImages.Add(red ?? CreateSwatch(Color.Firebrick));
    }

    private static Image? TryLoadImage(string fileName)
    {
        string[] candidates =
        [
            Path.Combine(Application.StartupPath, fileName),
            Path.Combine(Application.StartupPath, "Examples", fileName)
        ];

        foreach (string path in candidates)
        {
            if (File.Exists(path))
            {
                return Image.FromFile(path);
            }
        }

        return null;
    }

    private static Bitmap CreateSwatch(Color color)
    {
        var bitmap = new Bitmap(16, 16);
        using var graphics = Graphics.FromImage(bitmap);
        using var brush = new SolidBrush(color);
        graphics.Clear(Color.White);
        graphics.FillEllipse(brush, 1, 1, 14, 14);
        return bitmap;
    }

    private static KryptonButton CreateButton(string text, EventHandler onClick)
    {
        var button = new KryptonButton
        {
            AutoSize = true,
            Margin = new Padding(2)
        };
        button.Values.Text = text;
        button.Click += onClick;
        return button;
    }

    private static Control WrapLabeled(string label, Control control)
    {
        var host = new FlowLayoutPanel
        {
            AutoSize = true,
            WrapContents = false,
            BackColor = Color.Transparent,
            Margin = new Padding(2)
        };
        host.Controls.Add(new KryptonLabel { Values = { Text = label }, Padding = new Padding(0, 4, 4, 0) });
        host.Controls.Add(control);
        return host;
    }

    private sealed class ColumnOptionState
    {
        public bool FilterAndSort { get; set; } = true;
        public bool Sort { get; set; } = true;
        public bool Filter { get; set; } = true;
        public bool Checklist { get; set; } = true;
        public bool Custom { get; set; } = true;
        public bool DateAndTime { get; set; }
    }
}
