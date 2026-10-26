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
/// Flow layout surface for arranging <see cref="KryptonCard"/> controls.
/// </summary>
[ToolboxItem(true)]
[ToolboxBitmap(typeof(KryptonCard))]
[Description(@"Arranges KryptonCard controls in a wrapping flow layout.")]
public class KryptonCardFlowPanel : KryptonPanel
{
    private readonly FlowLayoutPanel _host;

    public KryptonCardFlowPanel()
    {
        PanelBackStyle = PaletteBackStyle.PanelClient;
        Padding = new Padding(8);
        Dock = DockStyle.Fill;

        _host = new FlowLayoutPanel
        {
            AutoScroll = true,
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.LeftToRight,
            WrapContents = true,
            Padding = new Padding(4),
        };

        Controls.Add(_host);
    }

    /// <summary>
    /// Gets the hosted card collection.
    /// </summary>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Control.ControlCollection Cards => _host.Controls;

    /// <summary>
    /// Gets or sets the spacing between cards.
    /// </summary>
    [Category(@"Layout")]
    [DefaultValue(12)]
    public int CardSpacing
    {
        get => _host.Padding.All;
        set => _host.Padding = new Padding(Math.Max(0, value));
    }
}
