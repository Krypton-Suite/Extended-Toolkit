#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
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
