using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Suite.Extended.ComboBox;

public class KryptonGroupedComboBox : KryptonComboBox
{
    #region Instance Fields

    private Dictionary<string, List<object>> _groupedItems = new Dictionary<string, List<object>>();

    #endregion

    #region Identity

    public KryptonGroupedComboBox()
    {
        DrawMode = DrawMode.OwnerDrawVariable;

        DropDownStyle = ComboBoxStyle.DropDownList;

        MeasureItem += KryptonGroupedComboBox_MeasureItem;

        DrawItem += KryptonGroupedComboBox_DrawItem;
    }

    #endregion

    #region Implementation

    public void SetGroupedItems(Dictionary<string, List<object>> groupedItems)
    {
        _groupedItems = groupedItems;

        Items.Clear();
        foreach (var group in _groupedItems)
        {
            Items.Add(new KryptonGroupHeaderItem(group.Key));
            foreach (var item in group.Value)
                Items.Add(item);
        }
    }

    private void KryptonGroupedComboBox_MeasureItem(object? sender, MeasureItemEventArgs e)
    {
        if (e.Index < 0)
        {
            return;
        }

        object? item = Items[e.Index];
        e.ItemHeight = item is KryptonGroupHeaderItem ? Font.Height + 8 : Font.Height + 2;
    }

    private void KryptonGroupedComboBox_DrawItem(object? sender, DrawItemEventArgs e)
    {
        if (e.Index < 0)
        {
            return;
        }

        object? item = Items[e.Index];
        bool isSelected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;

        e.DrawBackground();
        var bounds = e.Bounds;
        var g = e.Graphics;

        if (item is KryptonGroupHeaderItem header)
        {
            using var brush = new SolidBrush(Color.LightGray);
            g.FillRectangle(brush, bounds);
            TextRenderer.DrawText(g, header.HeaderText, new Font(Font, FontStyle.Bold),
                bounds, Color.Black, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
        }
        else
        {
            string? text = item?.ToString();
            Color textColor = isSelected ? SystemColors.HighlightText : SystemColors.ControlText;
            TextRenderer.DrawText(g, text, Font, bounds, textColor,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
        }

        e.DrawFocusRectangle();
    }

    #endregion
}