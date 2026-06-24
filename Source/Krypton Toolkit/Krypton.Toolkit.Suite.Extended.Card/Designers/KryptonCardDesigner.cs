#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Card;

internal class KryptonCardDesigner : ParentControlDesigner
{
    private KryptonCard? _card;

    public override void Initialize(IComponent component)
    {
        base.Initialize(component);
        _card = (KryptonCard)component;
        AutoResizeHandles = true;

        EnableDesignMode(_card.DesignContentPanel, nameof(KryptonCard.Content));
        EnableDesignMode(_card.DesignActionsPanel, nameof(KryptonCard.Actions));
        EnableDesignMode(_card.DesignFooterPanel, nameof(KryptonCard.Footer));
        _card.PerformLayout();
    }

    public override bool CanParent(Control control) => false;

    public override DesignerActionListCollection ActionLists
    {
        get
        {
            var lists = new DesignerActionListCollection
            {
                new KryptonCardActionList(this),
            };
            return lists;
        }
    }

    protected override void OnPaintAdornments(PaintEventArgs pe)
    {
        base.OnPaintAdornments(pe);
        if (_card == null)
        {
            return;
        }

        using Pen pen = new(SystemColors.ControlDarkDark) { DashStyle = DashStyle.Dot };
        Rectangle bounds = _card.ClientRectangle;
        bounds.Width--;
        bounds.Height--;
        pe.Graphics.DrawRectangle(pen, bounds);
    }
}
