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

namespace Krypton.Toolkit.Suite.Extended.Card;

/// <summary>
/// Table layout surface for arranging <see cref="KryptonCard"/> controls in columns.
/// </summary>
[ToolboxItem(true)]
[ToolboxBitmap(typeof(KryptonCard))]
[Description(@"Arranges KryptonCard controls in a responsive table layout.")]
public class KryptonCardTablePanel : KryptonPanel
{
    private readonly TableLayoutPanel _host;
    private int _columns = 2;
    private int _nextRow;
    private int _nextColumn;

    public KryptonCardTablePanel()
    {
        PanelBackStyle = PaletteBackStyle.PanelClient;
        Padding = new Padding(8);
        Dock = DockStyle.Fill;

        _host = new TableLayoutPanel
        {
            AutoScroll = true,
            AutoSize = true,
            AutoSizeMode = AutoSizeMode.GrowAndShrink,
            ColumnCount = _columns,
            Dock = DockStyle.Fill,
            Padding = new Padding(4),
        };

        ResetColumns();
        Controls.Add(_host);
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Control.ControlCollection Cards => _host.Controls;

    [Category(@"Layout")]
    [DefaultValue(2)]
    public int Columns
    {
        get => _columns;
        set
        {
            _columns = Math.Max(1, value);
            ResetColumns();
            ReflowCards();
        }
    }

    /// <summary>
    /// Adds a card to the next available table cell.
    /// </summary>
    public void AddCard(KryptonCard card)
    {
        card.Margin = new Padding(8);
        _host.Controls.Add(card, _nextColumn, _nextRow);

        _nextColumn++;
        if (_nextColumn >= _columns)
        {
            _nextColumn = 0;
            _nextRow++;
            EnsureRow(_nextRow);
        }
    }

    private void ResetColumns()
    {
        _host.ColumnCount = _columns;
        _host.ColumnStyles.Clear();
        for (int i = 0; i < _columns; i++)
        {
            _host.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / _columns));
        }
    }

    private void ReflowCards()
    {
        var cards = _host.Controls.Cast<Control>().ToArray();
        _host.Controls.Clear();
        _host.RowStyles.Clear();
        _nextRow = 0;
        _nextColumn = 0;

        foreach (Control card in cards)
        {
            AddCard((KryptonCard)card);
        }
    }

    private void EnsureRow(int rowIndex)
    {
        while (_host.RowStyles.Count <= rowIndex)
        {
            _host.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        }
    }
}
