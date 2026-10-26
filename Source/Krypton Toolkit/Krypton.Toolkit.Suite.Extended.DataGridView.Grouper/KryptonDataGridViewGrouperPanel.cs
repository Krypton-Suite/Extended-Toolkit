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
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Grid.Grouper;

/// <summary>
/// Flows group-column chips built from <see cref="KryptonDataGridViewGrouper.GroupLevels"/> and accepts
/// column-header drags that originate from <see cref="KryptonDataGridViewGrouper"/> wiring.
/// </summary>
[ToolboxItem(true)]
public class KryptonDataGridViewGrouperPanel : UserControl
{
    private readonly KryptonPanel _chrome;
    private readonly KryptonLabel _hintLabel;
    private readonly FlowLayoutPanel _flow;
    private KryptonDataGridViewGrouper? _grouper;

    public KryptonDataGridViewGrouperPanel()
    {
        Height = 96;

        _chrome = new KryptonPanel { Dock = DockStyle.Fill, Padding = new Padding(4) };

        _hintLabel = new KryptonLabel
        {
            Dock = DockStyle.Top,
            Height = 26,
            Text = @"Drag a column header onto the strip below to group. Click the chip text to remove that level.",
            Margin = Padding.Empty,
        };

        _flow = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            AutoScroll = true,
            Padding = new Padding(4),
            WrapContents = false,
            FlowDirection = FlowDirection.LeftToRight,
            AllowDrop = true,
            BackColor = SystemColors.Window,
        };

        _flow.DragEnter += FlowOnDragEnter;
        _flow.DragDrop += FlowOnDragDrop;

        Controls.Add(_chrome);
        _chrome.Controls.Add(_flow);
        _chrome.Controls.Add(_hintLabel);

        DoubleBuffered = true;
    }

    [DefaultValue(null)]
    public KryptonDataGridViewGrouper? Grouper
    {
        get => _grouper;
        set
        {
            if (_grouper != null)
            {
                _grouper.GroupingChanged -= GrouperOnGroupingChanged;
            }

            _grouper = value;

            if (_grouper != null)
            {
                _grouper.GroupingChanged += GrouperOnGroupingChanged;
            }

            RebuildChips();
        }
    }

    [Localizable(true)]
    public string HintText
    {
        get => _hintLabel.Text;
        set => _hintLabel.Text = value;
    }

    private void GrouperOnGroupingChanged(object? sender, EventArgs e) => RebuildChips();

    private void FlowOnDragEnter(object? sender, DragEventArgs e)
    {
        e.Effect = e.Data?.GetDataPresent(KryptonDataGridViewGrouper.DragDataFormat) == true
            ? DragDropEffects.Copy
            : DragDropEffects.None;
    }

    private void FlowOnDragDrop(object? sender, DragEventArgs e)
    {
        if (_grouper == null || e.Data?.GetData(KryptonDataGridViewGrouper.DragDataFormat) is not string propertyName ||
            string.IsNullOrWhiteSpace(propertyName))
        {
            return;
        }

        _grouper.AddGroupLevel(propertyName);
    }

    private void RebuildChips()
    {
        _flow.SuspendLayout();

        foreach (Control c in _flow.Controls)
        {
            c.Click -= ChipOnClick;
            c.Dispose();
        }

        _flow.Controls.Clear();

        if (_grouper != null)
        {
            foreach (string level in _grouper.GroupLevels)
            {
                var chip = new KryptonButton
                {
                    AutoSize = true,
                    Text = $"{level}  ✕",
                    Tag = level,
                    Margin = new Padding(3),
                };

                chip.Click += ChipOnClick;
                _flow.Controls.Add(chip);
            }
        }

        _flow.ResumeLayout();
    }

    private void ChipOnClick(object? sender, EventArgs args)
    {
        if (_grouper == null || sender is not KryptonButton button || button.Tag is not string prop)
        {
            return;
        }

        _grouper.RemoveGroupLevel(prop);
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            Grouper = null;
            _flow.DragEnter -= FlowOnDragEnter;
            _flow.DragDrop -= FlowOnDragDrop;
        }

        base.Dispose(disposing);
    }
}
