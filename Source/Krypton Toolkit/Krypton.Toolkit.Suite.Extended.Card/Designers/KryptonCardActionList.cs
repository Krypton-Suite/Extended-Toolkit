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
