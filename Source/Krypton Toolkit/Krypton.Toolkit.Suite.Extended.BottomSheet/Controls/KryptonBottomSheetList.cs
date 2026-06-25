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
/// Raised when a <see cref="KryptonBottomSheetList"/> item is selected.
/// </summary>
public sealed class BottomSheetListItemEventArgs : EventArgs
{
    public BottomSheetListItemEventArgs(BottomSheetListItem item) => Item = item;

    public BottomSheetListItem Item { get; }
}

/// <summary>
/// Material-style action list for bottom sheet content.
/// </summary>
[ToolboxItem(true)]
[DesignerCategory(@"code")]
[Description(@"Action list chrome for bottom sheet content.")]
public class KryptonBottomSheetList : UserControl
{
    private readonly List<BottomSheetListItem> _items = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="KryptonBottomSheetList"/> class.
    /// </summary>
    public KryptonBottomSheetList()
    {
        Dock = DockStyle.Fill;
        AutoSize = true;
        AutoSizeMode = AutoSizeMode.GrowAndShrink;
        Padding = new Padding(0, 4, 0, 8);
    }

    /// <summary>
    /// Occurs when an enabled list item is selected.
    /// </summary>
    public event EventHandler<BottomSheetListItemEventArgs>? ItemSelected;

    /// <summary>
    /// Gets the list items displayed in the sheet.
    /// </summary>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IList<BottomSheetListItem> Items => _items;

    /// <summary>
    /// Replaces all items and rebuilds the list UI.
    /// </summary>
    public void SetItems(IEnumerable<BottomSheetListItem> items)
    {
        _items.Clear();
        _items.AddRange(items);
        Rebuild();
    }

    /// <summary>
    /// Wires item selection to dismiss the sheet with the item result.
    /// </summary>
    public void BindDismiss(KryptonBottomSheetRef sheetRef)
    {
        ItemSelected += (_, args) =>
        {
            if (args.Item.Enabled)
            {
                sheetRef.Dismiss(args.Item.Result ?? args.Item.Text);
            }
        };
    }

    private void Rebuild()
    {
        Controls.Clear();

        foreach (BottomSheetListItem item in _items)
        {
            KryptonButton button = new()
            {
                Dock = DockStyle.Top,
                Height = string.IsNullOrWhiteSpace(item.Subtitle) ? 44 : 56,
                Enabled = item.Enabled,
                ButtonStyle = ButtonStyle.ListItem,
                Values =
                {
                    Text = item.Text,
                    ExtraText = item.Subtitle ?? string.Empty,
                },
            };
            button.StateCommon.Content.ShortText.TextH = PaletteRelativeAlign.Near;
            button.StateCommon.Content.LongText.TextH = PaletteRelativeAlign.Near;

            button.Click += (_, _) => ItemSelected?.Invoke(this, new BottomSheetListItemEventArgs(item));
            Controls.Add(button);
        }
    }
}
