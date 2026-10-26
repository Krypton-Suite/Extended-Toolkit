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
/// Themed card surface with optional rounded clipping.
/// </summary>
[ToolboxItem(false)]
internal class KryptonCardChrome : KryptonPanel
{
    private int _cornerRadius;
    private CardAppearance _appearance = CardAppearance.Elevated;
    private bool _selected;
    private Color _outlineColor = SystemColors.ControlDark;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int CornerRadius
    {
        get => _cornerRadius;
        set
        {
            _cornerRadius = Math.Max(0, value);
            UpdateRegion();
            Invalidate();
        }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public CardAppearance Appearance
    {
        get => _appearance;
        set
        {
            _appearance = value;
            ApplyAppearance();
            Invalidate();
        }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool Selected
    {
        get => _selected;
        set
        {
            if (_selected == value)
            {
                return;
            }

            _selected = value;
            Invalidate();
        }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Color OutlineColor
    {
        get => _outlineColor;
        set
        {
            _outlineColor = value;
            Invalidate();
        }
    }

    public void UpdateRegion()
    {
        if (_cornerRadius <= 0 || Width <= 0 || Height <= 0)
        {
            Region = null;
            return;
        }

        using GraphicsPath path = CardRendering.CreateRoundRectPath(ClientRectangle, _cornerRadius);
        Region = new Region(path);
    }

    public void ApplyAppearance()
    {
        PanelBackStyle = _appearance switch
        {
            CardAppearance.Filled => PaletteBackStyle.PanelAlternate,
            CardAppearance.Outlined => PaletteBackStyle.PanelClient,
            _ => PaletteBackStyle.PanelAlternate,
        };
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        UpdateRegion();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        if (_appearance == CardAppearance.Outlined)
        {
            CardRendering.DrawOutline(e.Graphics, ClientRectangle, _cornerRadius, _outlineColor);
        }

        if (_selected)
        {
            CardRendering.DrawSelectionAccent(
                e.Graphics,
                ClientRectangle,
                _cornerRadius,
                Color.FromArgb(180, OutlineColor));
        }
    }
}
