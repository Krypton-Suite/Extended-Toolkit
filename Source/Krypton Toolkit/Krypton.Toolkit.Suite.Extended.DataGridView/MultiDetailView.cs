#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.DataGridView;

/// <summary>
/// TODO: use Krypton.Navigator
/// </summary>
public class MultiDetailView : TabControl, IDetailView<TabControl>
{
    /// <inheritdoc />
    public Dictionary<KryptonDataGridView, string> ChildGrids { get; } = new();

    public MultiDetailView()
    {
        Visible = false;
    }

    /// <inheritdoc />
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public DataGridViewCell DetailsCurrentCell
    {
        get => ((KryptonDataGridView) SelectedTab.Controls[0]).CurrentCell;
        set => ((KryptonDataGridView)SelectedTab.Controls[0]).CurrentCell = value;
    }

    /// <inheritdoc />
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public DataGridViewRow DetailsCurrentRow => ((KryptonDataGridView)SelectedTab.Controls[0]).CurrentRow;

    /// <inheritdoc />
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public event DataGridViewCellMouseEventHandler DetailsCellMouseClick
    {
        add
        {
            foreach (TabPage page in TabPages)
            {
                ((KryptonDataGridView) page.Controls[0]).CellMouseClick += value;
            }
        }

        remove
        {
            foreach (TabPage page in TabPages)
            {
                ((KryptonDataGridView) page.Controls[0]).CellMouseClick -= value;
            }
        }
    }
}