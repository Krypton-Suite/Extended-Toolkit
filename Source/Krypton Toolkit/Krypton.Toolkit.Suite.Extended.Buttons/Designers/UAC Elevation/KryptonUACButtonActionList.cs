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

namespace Krypton.Toolkit.Suite.Extended.Buttons;

internal sealed class KryptonUACButtonActionList : DesignerActionList
{
    private readonly KryptonUACButtonDesigner _designer;

    public KryptonUACButtonActionList(KryptonUACButtonDesigner designer)
        : base(designer.Component)
    {
        _designer = designer;
    }

    public bool UseAsUACElevatedButton
    {
        get => Button.UseAsUACElevatedButton;
        set => SetProperty(nameof(KryptonUACButtonVersion2.UseAsUACElevatedButton), value);
    }

    public ButtonStyle ButtonStyle
    {
        get => Button.ButtonStyle;
        set => SetProperty(nameof(KryptonUACButtonVersion2.ButtonStyle), value);
    }

    public ContextMenuStrip? ContextMenuStrip
    {
        get => Button.ContextMenuStrip;
        set => SetProperty(nameof(KryptonUACButtonVersion2.ContextMenuStrip), value);
    }

    public VisualOrientation Orientation
    {
        get => Button.Orientation;
        set => SetProperty(nameof(KryptonUACButtonVersion2.Orientation), value);
    }

    public string Text
    {
        get => Button.Values.Text;
        set => SetProperty(nameof(ButtonValues.Text), value);
    }

    public string ExtraText
    {
        get => Button.Values.ExtraText;
        set => SetProperty(nameof(ButtonValues.ExtraText), value);
    }

    public Image? Image
    {
        get => Button.Values.Image;
        set => SetProperty(nameof(ButtonValues.Image), value);
    }

    public PaletteMode PaletteMode
    {
        get => Button.PaletteMode;
        set => SetProperty(nameof(KryptonUACButtonVersion2.PaletteMode), value);
    }

    public Font? ShortTextFont
    {
        get => Button.StateCommon.Content.ShortText.Font;
        set => SetProperty(@"StateCommon.Content.ShortText.Font", value);
    }

    public Font? LongTextFont
    {
        get => Button.StateCommon.Content.LongText.Font;
        set => SetProperty(@"StateCommon.Content.LongText.Font", value);
    }

    public override DesignerActionItemCollection GetSortedActionItems()
    {
        return
        [
            new DesignerActionHeaderItem(@"Appearance"),
            new DesignerActionPropertyItem(nameof(ButtonStyle), @"Style", @"Appearance", @"Button style"),
            new DesignerActionPropertyItem(nameof(ContextMenuStrip), @"Context Menu Strip", @"Appearance", @"The context menu strip for the control."),
            new DesignerActionPropertyItem(nameof(Orientation), @"Orientation", @"Appearance", @"Button orientation"),
            new DesignerActionPropertyItem(nameof(ShortTextFont), @"Short Text Font", @"Appearance", @"The short text font."),
            new DesignerActionPropertyItem(nameof(LongTextFont), @"Long Text Font", @"Appearance", @"The long text font."),
            new DesignerActionHeaderItem(@"Values"),
            new DesignerActionPropertyItem(nameof(Text), @"Text", @"Values", @"Button text"),
            new DesignerActionPropertyItem(nameof(ExtraText), @"ExtraText", @"Values", @"Button extra text"),
            new DesignerActionPropertyItem(nameof(Image), @"Image", @"Values", @"Button image"),
            new DesignerActionHeaderItem(@"Visuals"),
            new DesignerActionPropertyItem(nameof(PaletteMode), @"Palette", @"Visuals", @"Palette applied to drawing"),
            new DesignerActionHeaderItem(@"UAC Elevation"),
            new DesignerActionPropertyItem(nameof(UseAsUACElevatedButton), @"Use as an UAC Elevated Button", @"UAC Elevation", @"Use this button to elevate a process."),
        ];
    }

    private KryptonUACButtonVersion2 Button => (KryptonUACButtonVersion2)_designer.Component;

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
