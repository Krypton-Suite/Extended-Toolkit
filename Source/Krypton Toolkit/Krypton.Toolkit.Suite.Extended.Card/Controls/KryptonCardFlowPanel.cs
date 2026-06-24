#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
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
