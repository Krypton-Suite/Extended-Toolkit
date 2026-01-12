# KryptonAdvancedDataGridView

## Table of Contents

1. [Overview](#overview)
2. [Features](#features)
3. [Getting Started](#getting-started)
4. [API Reference](#api-reference)
   - [KryptonAdvancedDataGridView Class](#kryptonadvanceddatagridview-class)
   - [KryptonAdvancedDataGridViewSearchToolBar Class](#kryptonadvanceddatagridviewsearchtoolbar-class)
   - [Events](#events)
   - [Enumerations](#enumerations)
5. [Filtering](#filtering)
6. [Sorting](#sorting)
7. [Search Functionality](#search-functionality)
8. [Internationalization](#internationalization)
9. [Advanced Usage](#advanced-usage)
10. [Examples](#examples)
11. [Best Practices](#best-practices)

---

## Overview

`KryptonAdvancedDataGridView` is an enhanced DataGridView control that extends the standard `KryptonDataGridView` with advanced filtering, sorting, and search capabilities. It provides a user-friendly interface for data manipulation with built-in support for multiple data types, custom filters, and internationalization.

### Key Benefits

- **Advanced Filtering**: Multiple filter types including checklist, custom filters, and date/time filters
- **Flexible Sorting**: Multi-column sorting with ascending/descending options
- **Built-in Search**: Integrated search toolbar for finding data within the grid
- **Type-Aware**: Automatically detects and handles different data types (DateTime, numeric, string, boolean, etc.)
- **Internationalization**: Full translation support for all UI elements
- **Performance Optimized**: Efficient filtering and sorting with double buffering support

---

## Features

### Core Features

1. **Column Header Filtering**
   - Click column headers to access filter menus
   - Visual indicators for filtered/sorted columns
   - Support for multiple filter types per column

2. **Filter Types**
   - **Checklist Filter**: Select multiple values from a checklist
   - **Custom Filter**: Build complex filter expressions
   - **Date/Time Filter**: Special handling for DateTime columns
   - **Text Filter**: Search within checklist items

3. **Sorting**
   - Single and multi-column sorting
   - Ascending/Descending order
   - Visual sort indicators
   - Programmatic sort control

4. **Search Toolbar**
   - Search across all columns or specific columns
   - Case-sensitive and whole word options
   - Find next functionality
   - Column selection dropdown

5. **Data Source Support**
   - `BindingSource`
   - `DataView`
   - `DataTable`

---

## Getting Started

### Basic Setup

```csharp
using Krypton.Toolkit.Suite.Extended.AdvancedDataGridView;

// Create the control
KryptonAdvancedDataGridView advancedGrid = new KryptonAdvancedDataGridView();

// Set up data source
BindingSource bindingSource = new BindingSource();
bindingSource.DataSource = yourDataSet;
bindingSource.DataMember = "YourTableName";

advancedGrid.DataSource = bindingSource;

// Enable double buffering for better performance
advancedGrid.SetDoubleBuffered();
```

### Adding to a Form

```csharp
// In your form designer or code
this.Controls.Add(advancedGrid);
advancedGrid.Dock = DockStyle.Fill;
```

---

## API Reference

### KryptonAdvancedDataGridView Class

#### Properties

##### FilterAndSortEnabled
```csharp
public bool FilterAndSortEnabled { get; set; }
```
Gets or sets whether filtering and sorting are enabled globally for the control.

**Default**: `true`

##### FilterString
```csharp
public string? FilterString { get; }
```
Gets the current filter string applied to the data source. This is a read-only property that reflects the combined filter from all columns.

##### SortString
```csharp
public string? SortString { get; }
```
Gets the current sort string applied to the data source. This is a read-only property that reflects the combined sort order from all columns.

##### SortStringChangedInvokeBeforeDatasourceUpdate
```csharp
public bool SortStringChangedInvokeBeforeDatasourceUpdate { get; set; }
```
Determines whether the `SortStringChanged` event is raised before or after the data source is updated.

**Default**: `true`

##### FilterStringChangedInvokeBeforeDatasourceUpdate
```csharp
public bool FilterStringChangedInvokeBeforeDatasourceUpdate { get; set; }
```
Determines whether the `FilterStringChanged` event is raised before or after the data source is updated.

**Default**: `true`

#### Methods

##### Filter and Sort Management

###### SetFilterAndSortEnabled
```csharp
public void SetFilterAndSortEnabled(DataGridViewColumn column, bool enabled)
```
Enables or disables filtering and sorting capabilities for a specific column.

**Parameters:**
- `column`: The DataGridViewColumn to configure
- `enabled`: `true` to enable, `false` to disable

**Example:**
```csharp
advancedGrid.SetFilterAndSortEnabled(advancedGrid.Columns["ID"], false);
```

###### EnableFilterAndSort / DisableFilterAndSort
```csharp
public void EnableFilterAndSort(DataGridViewColumn column)
public void DisableFilterAndSort(DataGridViewColumn column)
```
Convenience methods to enable or disable filter and sort for a column.

##### Filter Configuration

###### SetFilterEnabled
```csharp
public void SetFilterEnabled(DataGridViewColumn column, bool enabled)
```
Enables or disables filtering for a specific column.

###### SetFilterChecklistEnabled
```csharp
public void SetFilterChecklistEnabled(DataGridViewColumn column, bool enabled)
```
Enables or disables the checklist filter for a specific column.

**Example:**
```csharp
// Disable checklist filter for GUID column
advancedGrid.SetFilterChecklistEnabled(advancedGrid.Columns["guid"], false);
```

###### SetFilterCustomEnabled
```csharp
public void SetFilterCustomEnabled(DataGridViewColumn column, bool enabled)
```
Enables or disables custom filter functionality for a specific column.

###### SetFilterDateAndTimeEnabled
```csharp
public void SetFilterDateAndTimeEnabled(DataGridViewColumn column, bool enabled)
```
Enables or disables date/time specific filtering for DateTime columns.

**Example:**
```csharp
advancedGrid.SetFilterDateAndTimeEnabled(advancedGrid.Columns["datetime"], true);
```

###### SetFilterChecklistNodesMax
```csharp
public void SetFilterChecklistNodesMax(DataGridViewColumn column, int maxnodes)
public void SetFilterChecklistNodesMax(int maxnodes)
```
Sets the maximum number of nodes to display in the checklist filter before enabling text filtering. Can be set per column or globally.

**Parameters:**
- `column`: The column to configure (or omit for global setting)
- `maxnodes`: Maximum number of nodes before text filter is enabled

**Example:**
```csharp
// Enable text filtering after 10 items
advancedGrid.SetFilterChecklistNodesMax(advancedGrid.Columns["Category"], 10);
```

###### SetFilterChecklistTextFilterTextChangedDelayNodes
```csharp
public void SetFilterChecklistTextFilterTextChangedDelayNodes(DataGridViewColumn column, int numnodes)
public void SetFilterChecklistTextFilterTextChangedDelayNodes(int numNodes)
```
Sets the number of nodes required before enabling TextChanged delay in the filter checklist.

**Example:**
```csharp
// Enable delay after 10 nodes
advancedGrid.SetFilterChecklistTextFilterTextChangedDelayNodes(advancedGrid.Columns["string"], 10);
```

###### SetFilterChecklistTextFilterTextChangedDelayMs
```csharp
public void SetFilterChecklistTextFilterTextChangedDelayMs(DataGridViewColumn column, int milliseconds)
public void SetFilterChecklistTextFilterTextChangedDelayMs(int milliseconds)
```
Sets the delay in milliseconds for TextChanged events in the filter checklist.

**Example:**
```csharp
// 500ms delay
advancedGrid.SetFilterChecklistTextFilterTextChangedDelayMs(advancedGrid.Columns["string"], 500);
```

###### SetChecklistTextFilterRemoveNodesOnSearchMode
```csharp
public void SetChecklistTextFilterRemoveNodesOnSearchMode(DataGridViewColumn column, bool enabled)
```
Controls whether nodes are removed from the checklist when searching (filtering the checklist itself).

**Example:**
```csharp
advancedGrid.SetChecklistTextFilterRemoveNodesOnSearchMode(advancedGrid.Columns["decimal"], false);
```

###### SetTextFilterRemoveNodesOnSearch
```csharp
public void SetTextFilterRemoveNodesOnSearch(DataGridViewColumn column, bool enabled)
public bool? GetTextFilterRemoveNodesOnSearch(DataGridViewColumn column)
```
Sets or gets whether text filter removes nodes from the checklist during search.

###### SetMenuStripFilterNotInLogic
```csharp
public void SetMenuStripFilterNotInLogic(bool enabled)
```
Sets the NOT IN logic for checkbox filters globally.

##### Sort Configuration

###### SetSortEnabled
```csharp
public void SetSortEnabled(DataGridViewColumn column, bool enabled)
```
Enables or disables sorting for a specific column.

**Example:**
```csharp
advancedGrid.SetSortEnabled(advancedGrid.Columns["guid"], false);
```

###### SortAscending / SortDescending
```csharp
public void SortAscending(DataGridViewColumn column)
public void SortDescending(DataGridViewColumn column)
```
Programmatically sorts a column in ascending or descending order.

**Example:**
```csharp
advancedGrid.SortAscending(advancedGrid.Columns["datetime"]);
advancedGrid.SortDescending(advancedGrid.Columns["double"]);
```

##### Filter and Sort Operations

###### CleanFilter
```csharp
public void CleanFilter()
public void CleanFilter(bool fireEvent)
public void CleanFilter(DataGridViewColumn column)
public void CleanFilter(DataGridViewColumn column, bool fireEvent)
```
Clears filters. Can clear all filters or filters for a specific column.

**Parameters:**
- `fireEvent`: Whether to raise the `FilterStringChanged` event
- `column`: Specific column to clear (optional)

**Example:**
```csharp
// Clear all filters
advancedGrid.CleanFilter();

// Clear filter for specific column without firing event
advancedGrid.CleanFilter(advancedGrid.Columns["Name"], false);
```

###### CleanSort
```csharp
public void CleanSort()
public void CleanSort(bool fireEvent)
public void CleanSort(DataGridViewColumn column)
public void CleanSort(DataGridViewColumn column, bool fireEvent)
```
Clears sorting. Can clear all sorts or sort for a specific column.

**Example:**
```csharp
advancedGrid.CleanSort(advancedGrid.Columns["datetime"]);
```

###### CleanFilterAndSort
```csharp
public void CleanFilterAndSort()
```
Clears both filters and sorts from all columns.

**Example:**
```csharp
advancedGrid.CleanFilterAndSort();
```

###### LoadFilterAndSort
```csharp
public void LoadFilterAndSort(string? filter, string? sorting)
```
Loads a saved filter and sort preset.

**Parameters:**
- `filter`: The filter string to apply
- `sorting`: The sort string to apply

**Example:**
```csharp
string savedFilter = "Name LIKE '%John%' AND Age > 25";
string savedSort = "Name ASC, Age DESC";
advancedGrid.LoadFilterAndSort(savedFilter, savedSort);
```

##### Search Methods

###### FindCell
```csharp
public DataGridViewCell? FindCell(
    string valueToFind, 
    string? columnName, 
    int rowIndex, 
    int columnIndex, 
    bool isWholeWordSearch, 
    bool isCaseSensitive)
```
Finds a cell containing the specified value.

**Parameters:**
- `valueToFind`: The value to search for
- `columnName`: Name of the column to search (null for all columns)
- `rowIndex`: Starting row index
- `columnIndex`: Starting column index
- `isWholeWordSearch`: Whether to match whole words only
- `isCaseSensitive`: Whether the search is case-sensitive

**Returns:** The found `DataGridViewCell` or `null` if not found.

**Example:**
```csharp
DataGridViewCell? cell = advancedGrid.FindCell(
    "John", 
    "Name", 
    0, 
    0, 
    false, 
    false);

if (cell != null)
{
    advancedGrid.CurrentCell = cell;
}
```

##### Utility Methods

###### SetDoubleBuffered
```csharp
public void SetDoubleBuffered()
```
Enables double buffering for improved rendering performance. Recommended for large datasets.

**Example:**
```csharp
advancedGrid.SetDoubleBuffered();
```

###### ShowMenuStrip
```csharp
public void ShowMenuStrip(DataGridViewColumn column)
```
Programmatically shows the filter/sort menu for a specific column.

**Example:**
```csharp
advancedGrid.ShowMenuStrip(advancedGrid.Columns["Name"]);
```

###### TriggerFilterStringChanged
```csharp
public void TriggerFilterStringChanged()
```
Manually triggers the `FilterStringChanged` event. Useful when you modify the filter programmatically.

**Example:**
```csharp
// After programmatically modifying filter
advancedGrid.TriggerFilterStringChanged();
```

###### TriggerSortStringChanged
```csharp
public void TriggerSortStringChanged()
```
Manually triggers the `SortStringChanged` event.

---

### KryptonAdvancedDataGridViewSearchToolBar Class

The search toolbar provides integrated search functionality for the DataGridView.

#### Properties

##### Translations
```csharp
public static Dictionary<string, string> Translations { get; }
```
Static dictionary containing all translatable strings for the search toolbar.

#### Methods

###### SetColumns
```csharp
public void SetColumns(DataGridViewColumnCollection columns)
```
Sets the columns available for searching in the dropdown.

**Example:**
```csharp
searchToolBar.SetColumns(advancedGrid.Columns);
```

###### SetTranslations
```csharp
public static void SetTranslations(IDictionary<string, string>? translations)
```
Sets the translation dictionary for the search toolbar.

**Example:**
```csharp
Dictionary<string, string> translations = new Dictionary<string, string>
{
    { "ADGVSTBLabelSearch", "Rechercher:" },
    { "ADGVSTBButtonSearchToolTip", "Suivant" }
};
KryptonAdvancedDataGridViewSearchToolBar.SetTranslations(translations);
```

###### GetTranslations
```csharp
public static IDictionary<string, string> GetTranslations()
```
Gets the current translation dictionary.

###### LoadTranslationsFromFile
```csharp
public static IDictionary<string, string> LoadTranslationsFromFile(string filename)
```
Loads translations from a JSON file.

**Example:**
```csharp
var translations = KryptonAdvancedDataGridViewSearchToolBar.LoadTranslationsFromFile("lang.json");
KryptonAdvancedDataGridViewSearchToolBar.SetTranslations(translations);
```

#### Events

##### Search
```csharp
public event AdvancedDataGridViewSearchToolBarSearchEventHandler? Search;
```
Raised when the user initiates a search.

**Event Handler Signature:**
```csharp
void SearchToolBar_Search(object sender, AdvancedDataGridViewSearchToolBarSearchEventArgs e)
{
    // e.ValueToSearch - The search text
    // e.ColumnToSearch - The selected column (null for all columns)
    // e.CaseSensitive - Whether search is case-sensitive
    // e.WholeWord - Whether to match whole words only
    // e.FromBegin - Whether to search from the beginning
}
```

**Example:**
```csharp
searchToolBar.Search += (sender, e) =>
{
    DataGridViewCell? cell = advancedGrid.FindCell(
        e.ValueToSearch,
        e.ColumnToSearch?.Name,
        e.FromBegin ? 0 : advancedGrid.CurrentCell?.RowIndex ?? 0,
        e.FromBegin ? 0 : advancedGrid.CurrentCell?.ColumnIndex ?? 0,
        e.WholeWord,
        e.CaseSensitive);
    
    if (cell != null)
    {
        advancedGrid.CurrentCell = cell;
    }
};
```

---

## Events

### SortStringChanged

Raised when the sort string changes.

**Event Handler:**
```csharp
public event EventHandler<SortEventArgs> SortStringChanged;
```

**Event Args:**
```csharp
public class SortEventArgs : EventArgs
{
    public string? SortString { get; set; }
    public bool Cancel { get; set; }
}
```

**Example:**
```csharp
advancedGrid.SortStringChanged += (sender, e) =>
{
    // e.SortString contains the current sort string
    // Set e.Cancel = true to prevent automatic data source update
    // You can then manually update: bindingSource.Sort = e.SortString;
    
    Console.WriteLine($"Sort changed: {e.SortString}");
};
```

### FilterStringChanged

Raised when the filter string changes.

**Event Handler:**
```csharp
public event EventHandler<FilterEventArgs> FilterStringChanged;
```

**Event Args:**
```csharp
public class FilterEventArgs : EventArgs
{
    public string? FilterString { get; set; }
    public bool Cancel { get; set; }
}
```

**Example:**
```csharp
advancedGrid.FilterStringChanged += (sender, e) =>
{
    // e.FilterString contains the current filter string
    // You can modify it before it's applied
    // Set e.Cancel = true to prevent automatic data source update
    
    // Add additional custom filter
    if (!string.IsNullOrEmpty(customFilterText))
    {
        e.FilterString += (!string.IsNullOrEmpty(e.FilterString) ? " AND " : "") 
            + $"CustomColumn LIKE '%{customFilterText}%'";
    }
    
    Console.WriteLine($"Filter changed: {e.FilterString}");
};
```

---

## Enumerations

### FilterType

```csharp
public enum FilterType
{
    Unknown,
    DateTime,
    TimeSpan,
    String,
    Float,
    Integer
}
```

Represents the data type detected for filtering purposes.

### TranslationKey

Contains all available translation keys for the control. See [Internationalization](#internationalization) section for details.

---

## Filtering

### Filter Types

#### Checklist Filter

The checklist filter allows users to select multiple values from a dropdown list. It's ideal for columns with a limited set of distinct values.

**Features:**
- Select All / Deselect All
- Text search within checklist items
- Automatic handling of null/empty values
- Configurable maximum nodes before text filtering

**Configuration:**
```csharp
// Enable checklist filter (enabled by default)
advancedGrid.SetFilterChecklistEnabled(advancedGrid.Columns["Status"], true);

// Set maximum nodes before text filter is enabled
advancedGrid.SetFilterChecklistNodesMax(advancedGrid.Columns["Category"], 50);

// Configure text filter delay
advancedGrid.SetFilterChecklistTextFilterTextChangedDelayNodes(advancedGrid.Columns["Category"], 10);
advancedGrid.SetFilterChecklistTextFilterTextChangedDelayMs(advancedGrid.Columns["Category"], 500);
```

#### Custom Filter

Custom filters allow users to build complex filter expressions using operators like equals, contains, greater than, etc.

**Available Operators:**
- Equals / Does not equal
- Greater than / Greater than or equal to
- Less than / Less than or equal to
- Begins with / Does not begin with
- Ends with / Does not end with
- Contains / Does not contain
- Between (for numeric and date values)
- Earlier than / Later than (for date values)

**Configuration:**
```csharp
// Enable custom filter (enabled by default)
advancedGrid.SetFilterCustomEnabled(advancedGrid.Columns["Name"], true);
```

#### Date/Time Filter

Special filtering for DateTime columns with date and time specific operators.

**Configuration:**
```csharp
// Enable date/time filtering
advancedGrid.SetFilterDateAndTimeEnabled(advancedGrid.Columns["CreatedDate"], true);
```

### Filter String Format

Filters are combined using AND logic. The filter string follows DataView RowFilter syntax:

```
Column1 = 'Value1' AND Column2 > 100 AND Column3 LIKE '%text%'
```

### Programmatic Filtering

```csharp
// Load a saved filter
string filter = "Age > 25 AND Status = 'Active'";
advancedGrid.LoadFilterAndSort(filter, null);

// Clear all filters
advancedGrid.CleanFilter();

// Clear filter for specific column
advancedGrid.CleanFilter(advancedGrid.Columns["Status"]);
```

---

## Sorting

### Multi-Column Sorting

The control supports sorting by multiple columns. The sort order is determined by the order in which columns are sorted.

**Example:**
```csharp
// Sort by Name ascending, then Age descending
advancedGrid.SortAscending(advancedGrid.Columns["Name"]);
advancedGrid.SortDescending(advancedGrid.Columns["Age"]);
```

### Sort String Format

The sort string follows DataView Sort syntax:

```
Column1 ASC, Column2 DESC, Column3 ASC
```

### Programmatic Sorting

```csharp
// Sort ascending
advancedGrid.SortAscending(advancedGrid.Columns["Name"]);

// Sort descending
advancedGrid.SortDescending(advancedGrid.Columns["Date"]);

// Clear all sorts
advancedGrid.CleanSort();

// Clear sort for specific column
advancedGrid.CleanSort(advancedGrid.Columns["Name"]);

// Load saved sort
advancedGrid.LoadFilterAndSort(null, "Name ASC, Date DESC");
```

### Disabling Sorting

```csharp
// Disable sorting for a specific column
advancedGrid.SetSortEnabled(advancedGrid.Columns["ID"], false);
```

---

## Search Functionality

### Using the Search Toolbar

1. **Add the Search Toolbar to your form:**
```csharp
KryptonAdvancedDataGridViewSearchToolBar searchToolBar = 
    new KryptonAdvancedDataGridViewSearchToolBar();

// Set the columns
searchToolBar.SetColumns(advancedGrid.Columns);

// Add to form
this.Controls.Add(searchToolBar);
searchToolBar.Dock = DockStyle.Top;
```

2. **Handle the Search event:**
```csharp
searchToolBar.Search += (sender, e) =>
{
    bool restartSearch = true;
    int startColumn = 0;
    int startRow = 0;
    
    if (!e.FromBegin)
    {
        bool endCol = advancedGrid.CurrentCell.ColumnIndex + 1 >= advancedGrid.ColumnCount;
        bool endRow = advancedGrid.CurrentCell.RowIndex + 1 >= advancedGrid.RowCount;
        
        if (endCol && endRow)
        {
            startColumn = advancedGrid.CurrentCell.ColumnIndex;
            startRow = advancedGrid.CurrentCell.RowIndex;
        }
        else
        {
            startColumn = endCol ? 0 : advancedGrid.CurrentCell.ColumnIndex + 1;
            startRow = advancedGrid.CurrentCell.RowIndex + (endCol ? 1 : 0);
        }
    }
    
    DataGridViewCell? cell = advancedGrid.FindCell(
        e.ValueToSearch,
        e.ColumnToSearch?.Name,
        startRow,
        startColumn,
        e.WholeWord,
        e.CaseSensitive);
    
    if (cell == null && restartSearch)
    {
        // Wrap around to beginning
        cell = advancedGrid.FindCell(
            e.ValueToSearch,
            e.ColumnToSearch?.Name,
            0,
            0,
            e.WholeWord,
            e.CaseSensitive);
    }
    
    if (cell != null)
    {
        advancedGrid.CurrentCell = cell;
        advancedGrid.FirstDisplayedScrollingRowIndex = cell.RowIndex;
    }
};
```

### Search Options

- **Column Selection**: Search all columns or a specific column
- **Case Sensitive**: Toggle case-sensitive matching
- **Whole Word**: Match complete words only
- **From Begin**: Start search from the beginning

---

## Internationalization

### Translation Keys

The control supports full internationalization through translation dictionaries.

#### KryptonAdvancedDataGridView Translation Keys

```csharp
public enum TranslationKey
{
    KryptonAdvancedDataGridViewSortDateTimeAscending,
    KryptonAdvancedDataGridViewSortDateTimeDescending,
    KryptonAdvancedDataGridViewSortBoolAscending,
    KryptonAdvancedDataGridViewSortBoolDescending,
    KryptonAdvancedDataGridViewSortNumAscending,
    KryptonAdvancedDataGridViewSortNumDescending,
    KryptonAdvancedDataGridViewSortTextAscending,
    KryptonAdvancedDataGridViewSortTextDescending,
    KryptonAdvancedDataGridViewAddCustomFilter,
    KryptonAdvancedDataGridViewCustomFilter,
    KryptonAdvancedDataGridViewClearFilter,
    KryptonAdvancedDataGridViewClearSort,
    KryptonAdvancedDataGridViewButtonFilter,
    KryptonAdvancedDataGridViewButtonUndoFilter,
    KryptonAdvancedDataGridViewNodeSelectAll,
    KryptonAdvancedDataGridViewNodeSelectEmpty,
    KryptonAdvancedDataGridViewNodeSelectTrue,
    KryptonAdvancedDataGridViewNodeSelectFalse,
    KryptonAdvancedDataGridViewFilterChecklistDisable,
    KryptonAdvancedDataGridViewEquals,
    KryptonAdvancedDataGridViewDoesNotEqual,
    KryptonAdvancedDataGridViewEarlierThan,
    KryptonAdvancedDataGridViewEarlierThanOrEqualTo,
    KryptonAdvancedDataGridViewLaterThan,
    KryptonAdvancedDataGridViewLaterThanOrEqualTo,
    KryptonAdvancedDataGridViewBetween,
    KryptonAdvancedDataGridViewGreaterThan,
    KryptonAdvancedDataGridViewGreaterThanOrEqualTo,
    KryptonAdvancedDataGridViewLessThan,
    KryptonAdvancedDataGridViewLessThanOrEqualTo,
    KryptonAdvancedDataGridViewBeginsWith,
    KryptonAdvancedDataGridViewDoesNotBeginWith,
    KryptonAdvancedDataGridViewEndsWith,
    KryptonAdvancedDataGridViewDoesNotEndWith,
    KryptonAdvancedDataGridViewContains,
    KryptonAdvancedDataGridViewDoesNotContain,
    KryptonAdvancedDataGridViewInvalidValue,
    KryptonAdvancedDataGridViewFilterStringDescription,
    KryptonAdvancedDataGridViewFormTitle,
    KryptonAdvancedDataGridViewLabelColumnNameText,
    KryptonAdvancedDataGridViewLabelAnd,
    KryptonAdvancedDataGridViewButtonOk,
    KryptonAdvancedDataGridViewButtonCancel
}
```

#### KryptonAdvancedDataGridViewSearchToolBar Translation Keys

```csharp
public enum TranslationKey
{
    ADGVSTBLabelSearch,
    ADGVSTBButtonFromBegin,
    ADGVSTBButtonCaseSensitiveToolTip,
    ADGVSTBButtonSearchToolTip,
    ADGVSTBButtonCloseToolTip,
    ADGVSTBButtonWholeWordToolTip,
    ADGVSTBComboBoxColumnsAll,
    ADGVSTBTextBoxSearchToolTip
}
```

### Setting Translations

#### Method 1: Programmatically

```csharp
Dictionary<string, string> translations = new Dictionary<string, string>
{
    { "KryptonAdvancedDataGridViewSortTextAscending", "Trier A à Z" },
    { "KryptonAdvancedDataGridViewSortTextDescending", "Trier Z à A" },
    { "KryptonAdvancedDataGridViewClearFilter", "Effacer le filtre" },
    // ... add all translations
};

KryptonAdvancedDataGridView.SetTranslations(translations);
KryptonAdvancedDataGridViewSearchToolBar.SetTranslations(translations);
```

#### Method 2: From JSON File

```csharp
// Load from file
var translations = KryptonAdvancedDataGridView.LoadTranslationsFromFile("lang.json");
KryptonAdvancedDataGridView.SetTranslations(translations);

var searchTranslations = KryptonAdvancedDataGridViewSearchToolBar.LoadTranslationsFromFile("lang.json");
KryptonAdvancedDataGridViewSearchToolBar.SetTranslations(searchTranslations);
```

**Example JSON file (lang.json):**
```json
{
  "KryptonAdvancedDataGridViewSortTextAscending": "Trier A à Z",
  "KryptonAdvancedDataGridViewSortTextDescending": "Trier Z à A",
  "KryptonAdvancedDataGridViewClearFilter": "Effacer le filtre",
  "ADGVSTBLabelSearch": "Rechercher:",
  "ADGVSTBButtonSearchToolTip": "Suivant"
}
```

### Getting Current Translations

```csharp
var translations = KryptonAdvancedDataGridView.GetTranslations();
var searchTranslations = KryptonAdvancedDataGridViewSearchToolBar.GetTranslations();
```

---

## Advanced Usage

### Saving and Restoring Filter/Sort States

```csharp
// Save current state
string currentFilter = advancedGrid.FilterString;
string currentSort = advancedGrid.SortString;

// Save to settings or database
Properties.Settings.Default.LastFilter = currentFilter;
Properties.Settings.Default.LastSort = currentSort;
Properties.Settings.Default.Save();

// Restore on form load
if (!string.IsNullOrEmpty(Properties.Settings.Default.LastFilter) ||
    !string.IsNullOrEmpty(Properties.Settings.Default.LastSort))
{
    advancedGrid.LoadFilterAndSort(
        Properties.Settings.Default.LastFilter,
        Properties.Settings.Default.LastSort);
}
```

### Custom Filter Logic

You can intercept and modify filter strings before they're applied:

```csharp
advancedGrid.FilterStringChanged += (sender, e) =>
{
    // Add custom filter logic
    string customFilter = "IsActive = true";
    
    if (!string.IsNullOrEmpty(e.FilterString))
    {
        e.FilterString = $"({e.FilterString}) AND {customFilter}";
    }
    else
    {
        e.FilterString = customFilter;
    }
};
```

### Event Timing Control

Control when events fire relative to data source updates:

```csharp
// Fire events before data source update (default)
advancedGrid.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
advancedGrid.SortStringChangedInvokeBeforeDatasourceUpdate = true;

// Or fire after data source update
advancedGrid.FilterStringChangedInvokeBeforeDatasourceUpdate = false;
advancedGrid.SortStringChangedInvokeBeforeDatasourceUpdate = false;
```

### Handling Data Source Changes

```csharp
// The control automatically handles data source changes
// But you may need to refresh column configurations

advancedGrid.DataSourceChanged += (sender, e) =>
{
    // Reconfigure columns if needed
    foreach (DataGridViewColumn column in advancedGrid.Columns)
    {
        // Reapply settings
        advancedGrid.SetFilterDateAndTimeEnabled(column, 
            column.ValueType == typeof(DateTime));
    }
};
```

### Performance Optimization

```csharp
// Enable double buffering
advancedGrid.SetDoubleBuffered();

// Disable filtering for columns that don't need it
foreach (DataGridViewColumn column in advancedGrid.Columns)
{
    if (column.Name == "ID" || column.Name == "Image")
    {
        advancedGrid.DisableFilterAndSort(column);
    }
}

// Set checklist node limits to improve performance
advancedGrid.SetFilterChecklistNodesMax(50); // Global setting
```

---

## Examples

### Complete Example: Basic Setup

```csharp
using System;
using System.Data;
using System.Windows.Forms;
using Krypton.Toolkit.Suite.Extended.AdvancedDataGridView;

public partial class MainForm : KryptonForm
{
    private KryptonAdvancedDataGridView advancedGrid;
    private KryptonAdvancedDataGridViewSearchToolBar searchToolBar;
    private BindingSource bindingSource;
    private DataTable dataTable;

    public MainForm()
    {
        InitializeComponent();
        InitializeAdvancedGrid();
    }

    private void InitializeAdvancedGrid()
    {
        // Create the grid
        advancedGrid = new KryptonAdvancedDataGridView();
        advancedGrid.Dock = DockStyle.Fill;
        advancedGrid.SetDoubleBuffered();
        
        // Create search toolbar
        searchToolBar = new KryptonAdvancedDataGridViewSearchToolBar();
        searchToolBar.Dock = DockStyle.Top;
        
        // Setup data
        dataTable = new DataTable();
        dataTable.Columns.Add("ID", typeof(int));
        dataTable.Columns.Add("Name", typeof(string));
        dataTable.Columns.Add("Age", typeof(int));
        dataTable.Columns.Add("CreatedDate", typeof(DateTime));
        dataTable.Columns.Add("IsActive", typeof(bool));
        
        // Add sample data
        for (int i = 0; i < 100; i++)
        {
            dataTable.Rows.Add(i, $"User {i}", 20 + i % 50, 
                DateTime.Now.AddDays(-i), i % 2 == 0);
        }
        
        // Setup binding source
        bindingSource = new BindingSource();
        bindingSource.DataSource = dataTable;
        advancedGrid.DataSource = bindingSource;
        
        // Configure columns
        advancedGrid.SetFilterDateAndTimeEnabled(
            advancedGrid.Columns["CreatedDate"], true);
        advancedGrid.SetSortEnabled(advancedGrid.Columns["ID"], false);
        
        // Setup search toolbar
        searchToolBar.SetColumns(advancedGrid.Columns);
        searchToolBar.Search += SearchToolBar_Search;
        
        // Handle events
        advancedGrid.FilterStringChanged += AdvancedGrid_FilterStringChanged;
        advancedGrid.SortStringChanged += AdvancedGrid_SortStringChanged;
        
        // Add to form
        this.Controls.Add(advancedGrid);
        this.Controls.Add(searchToolBar);
    }

    private void SearchToolBar_Search(object sender, 
        AdvancedDataGridViewSearchToolBarSearchEventArgs e)
    {
        int startRow = e.FromBegin ? 0 : 
            (advancedGrid.CurrentCell?.RowIndex ?? 0);
        int startCol = e.FromBegin ? 0 : 
            (advancedGrid.CurrentCell?.ColumnIndex ?? 0);
        
        DataGridViewCell? cell = advancedGrid.FindCell(
            e.ValueToSearch,
            e.ColumnToSearch?.Name,
            startRow,
            startCol,
            e.WholeWord,
            e.CaseSensitive);
        
        if (cell != null)
        {
            advancedGrid.CurrentCell = cell;
            advancedGrid.FirstDisplayedScrollingRowIndex = cell.RowIndex;
        }
    }

    private void AdvancedGrid_FilterStringChanged(object sender, 
        KryptonAdvancedDataGridView.FilterEventArgs e)
    {
        Console.WriteLine($"Filter: {e.FilterString}");
    }

    private void AdvancedGrid_SortStringChanged(object sender, 
        KryptonAdvancedDataGridView.SortEventArgs e)
    {
        Console.WriteLine($"Sort: {e.SortString}");
    }
}
```

### Example: Saving Filter/Sort Presets

```csharp
private Dictionary<string, FilterSortPreset> savedPresets = 
    new Dictionary<string, FilterSortPreset>();

private class FilterSortPreset
{
    public string Filter { get; set; }
    public string Sort { get; set; }
    public string Name { get; set; }
}

private void SavePreset(string name)
{
    savedPresets[name] = new FilterSortPreset
    {
        Name = name,
        Filter = advancedGrid.FilterString,
        Sort = advancedGrid.SortString
    };
}

private void LoadPreset(string name)
{
    if (savedPresets.ContainsKey(name))
    {
        var preset = savedPresets[name];
        advancedGrid.LoadFilterAndSort(preset.Filter, preset.Sort);
    }
}
```

---

## Best Practices

### 1. Performance

- **Enable double buffering** for large datasets:
  ```csharp
  advancedGrid.SetDoubleBuffered();
  ```

- **Disable filtering/sorting** for columns that don't need it:
  ```csharp
  advancedGrid.DisableFilterAndSort(advancedGrid.Columns["Image"]);
  ```

- **Set checklist node limits** to prevent performance issues:
  ```csharp
  advancedGrid.SetFilterChecklistNodesMax(100);
  ```

### 2. User Experience

- **Configure date/time filtering** for DateTime columns:
  ```csharp
  advancedGrid.SetFilterDateAndTimeEnabled(dateColumn, true);
  ```

- **Disable checklist** for columns with too many unique values:
  ```csharp
  advancedGrid.SetFilterChecklistEnabled(advancedGrid.Columns["GUID"], false);
  ```

- **Provide search functionality** using the search toolbar for better UX.

### 3. Data Source Management

- **Use BindingSource** for best compatibility:
  ```csharp
  BindingSource bs = new BindingSource();
  bs.DataSource = dataSet;
  bs.DataMember = "TableName";
  advancedGrid.DataSource = bs;
  ```

- **Handle data source changes** properly by reconfiguring columns if needed.

### 4. Internationalization

- **Load translations early** in application startup:
  ```csharp
  // In Program.cs or MainForm constructor
  var translations = KryptonAdvancedDataGridView.LoadTranslationsFromFile("lang.json");
  KryptonAdvancedDataGridView.SetTranslations(translations);
  ```

### 5. Error Handling

- **Validate filter strings** in FilterStringChanged event:
  ```csharp
  advancedGrid.FilterStringChanged += (sender, e) =>
  {
      try
      {
          // Validate or modify filter string
          if (string.IsNullOrEmpty(e.FilterString))
              return;
              
          // Test the filter
          var testView = new DataView(dataTable);
          testView.RowFilter = e.FilterString;
      }
      catch (Exception ex)
      {
          MessageBox.Show($"Invalid filter: {ex.Message}");
          e.Cancel = true;
      }
  };
  ```

### 6. State Management

- **Save and restore** filter/sort states for better user experience:
  ```csharp
  // Save on form closing
  Properties.Settings.Default.LastFilter = advancedGrid.FilterString;
  Properties.Settings.Default.LastSort = advancedGrid.SortString;
  
  // Restore on form load
  advancedGrid.LoadFilterAndSort(
      Properties.Settings.Default.LastFilter,
      Properties.Settings.Default.LastSort);
  ```

---

## Troubleshooting

### Common Issues

1. **Filters not working**: Ensure the data source supports filtering (BindingSource, DataView, or DataTable).

2. **Sort not working**: Check that `SortMode` is set to `Programmatic` (handled automatically by the control).

3. **Performance issues**: Enable double buffering and set checklist node limits.

4. **Translations not applying**: Ensure translations are set before the control is displayed.

5. **Search not finding results**: Verify the search is case-sensitive/whole word settings match your expectations.

---

## Additional Resources

- See the example project: `Source/Krypton Toolkit/Examples/AdvancedDataGridView.cs`
- Check the main README for general Krypton Toolkit information
- Review the changelog for version-specific features and fixes
