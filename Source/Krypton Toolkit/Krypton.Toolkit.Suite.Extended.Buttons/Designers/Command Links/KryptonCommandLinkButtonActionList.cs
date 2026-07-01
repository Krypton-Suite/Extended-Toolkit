#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
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

#pragma warning disable CS0618

namespace Krypton.Toolkit.Suite.Extended.Buttons;

internal sealed class KryptonCommandLinkButtonActionList : DesignerActionList
{
    private readonly KryptonCommandLinkButtonDesigner _designer;

    public KryptonCommandLinkButtonActionList(KryptonCommandLinkButtonDesigner designer)
        : base(designer.Component)
    {
        _designer = designer;
    }

    public ButtonStyle ButtonStyle
    {
        get => Button.ButtonStyle;
        set => SetProperty(nameof(KryptonCommandLinkButton.ButtonStyle), value);
    }

    public VisualOrientation Orientation
    {
        get => Button.Orientation;
        set => SetProperty(nameof(KryptonCommandLinkButton.Orientation), value);
    }

    public string Heading
    {
        get => Button.CommandLinkTextValues.Heading;
        set => SetProperty(nameof(CommandLinkTextValues.Heading), value);
    }

    public string Description
    {
        get => Button.CommandLinkTextValues.Description;
        set => SetProperty(nameof(CommandLinkTextValues.Description), value);
    }

    public Image? Image
    {
        get => Button.CommandLinkImageValue.Image;
        set => SetProperty(nameof(ImageValue.Image), value);
    }

    public PaletteMode PaletteMode
    {
        get => Button.PaletteMode;
        set => SetProperty(nameof(KryptonCommandLinkButton.PaletteMode), value);
    }

    public override DesignerActionItemCollection GetSortedActionItems()
    {
        return
        [
            new DesignerActionHeaderItem("Appearance"),
            new DesignerActionPropertyItem(nameof(Orientation), "Orientation", "Appearance", "Button orientation"),
            new DesignerActionHeaderItem("CommandLink"),
            new DesignerActionPropertyItem(nameof(Heading), "Heading", "CommandLink", "Button Heading text"),
            new DesignerActionPropertyItem(nameof(Description), "Description", "CommandLink", "Button Subscript Description text"),
            new DesignerActionPropertyItem(nameof(Image), "Image", "CommandLink", "Button image"),
            new DesignerActionHeaderItem("Visuals"),
            new DesignerActionPropertyItem(nameof(ButtonStyle), "Style", "Visuals", "Button style"),
            new DesignerActionPropertyItem(nameof(PaletteMode), "Palette", "Visuals", "Palette applied to drawing"),
        ];
    }

    private KryptonCommandLinkButton Button => (KryptonCommandLinkButton)_designer.Component;

    private void SetProperty<T>(string propertyName, T value)
    {
        IComponentChangeService? service = GetService(typeof(IComponentChangeService)) as IComponentChangeService;
        PropertyDescriptor? property = TypeDescriptor.GetProperties(Button)[propertyName];
        if (property != null && !Equals(property.GetValue(Button), value))
        {
            service?.OnComponentChanged(Button, null, property.GetValue(Button), value);
            property.SetValue(Button, value);
        }
    }
}

#pragma warning restore CS0618
