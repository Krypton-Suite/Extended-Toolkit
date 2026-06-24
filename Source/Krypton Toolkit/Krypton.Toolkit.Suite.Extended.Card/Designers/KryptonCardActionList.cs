#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Card;

internal sealed class KryptonCardActionList : DesignerActionList
{
    private readonly KryptonCardDesigner _designer;

    public KryptonCardActionList(KryptonCardDesigner designer)
        : base(designer.Component)
    {
        _designer = designer;
    }

    public CardAppearance Appearance
    {
        get => Card.Appearance;
        set => SetProperty(nameof(KryptonCard.Appearance), value);
    }

    public bool Clickable
    {
        get => Card.Clickable;
        set => SetProperty(nameof(KryptonCard.Clickable), value);
    }

    public int Elevation
    {
        get => Card.Elevation;
        set => SetProperty(nameof(KryptonCard.Elevation), value);
    }

    public override DesignerActionItemCollection GetSortedActionItems()
    {
        return
        [
            new DesignerActionPropertyItem(nameof(Appearance), @"Appearance", @"Card", @"Card visual style."),
            new DesignerActionPropertyItem(nameof(Elevation), @"Elevation", @"Card", @"Card shadow elevation."),
            new DesignerActionPropertyItem(nameof(Clickable), @"Clickable", @"Card", @"Whether the card raises CardClick."),
        ];
    }

    private KryptonCard Card => (KryptonCard)_designer.Component;

    private void SetProperty<T>(string propertyName, T value)
    {
        PropertyDescriptor? property = TypeDescriptor.GetProperties(Card)[propertyName];
        property?.SetValue(Card, value);
    }
}
