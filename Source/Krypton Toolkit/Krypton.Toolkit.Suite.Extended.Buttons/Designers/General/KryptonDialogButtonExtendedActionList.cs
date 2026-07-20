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

internal sealed class KryptonDialogButtonExtendedActionList : DesignerActionList
{
    private readonly KryptonDialogButtonExtendedDesigner _designer;

    public KryptonDialogButtonExtendedActionList(KryptonDialogButtonExtendedDesigner designer)
        : base(designer.Component)
    {
        _designer = designer;
    }

    public ButtonStyle ButtonStyle
    {
        get => Button.ButtonStyle;
        set => SetProperty(nameof(KryptonDialogButtonExtended.ButtonStyle), value);
    }

    public DialogResult DialogResult
    {
        get => Button.DialogResult;
        set => SetProperty(nameof(KryptonDialogButtonExtended.DialogResult), value);
    }

    public KryptonContextMenu? KryptonContextMenu
    {
        get => Button.KryptonContextMenu;
        set => SetProperty(nameof(KryptonDialogButtonExtended.KryptonContextMenu), value);
    }

    public VisualOrientation Orientation
    {
        get => Button.Orientation;
        set => SetProperty(nameof(KryptonDialogButtonExtended.Orientation), value);
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
        set => SetProperty(nameof(KryptonDialogButtonExtended.PaletteMode), value);
    }

    public Font? StateCommonShortTextFont
    {
        get => Button.StateCommon.Content.ShortText.Font;
        set => SetProperty(@"StateCommon.Content.ShortText.Font", value);
    }

    public Font? StateCommonLongTextFont
    {
        get => Button.StateCommon.Content.LongText.Font;
        set => SetProperty(@"StateCommon.Content.LongText.Font", value);
    }

    public float StateCommonCornerRoundingRadius
    {
        get => Button.StateCommon.Border.Rounding;
        set => SetProperty(@"StateCommon.Border.Rounding", value);
    }

    public bool UseAsUACElevatedButton
    {
        get => Button.Values.UseAsUACElevationButton;
        set => SetProperty(nameof(ButtonValues.UseAsUACElevationButton), value);
    }

    public KryptonButtonBuiltInDisplayString DisplayStringType
    {
        get => Button.DisplayString;
        set => SetProperty(nameof(KryptonDialogButtonExtended.DisplayString), value);
    }

    public override DesignerActionItemCollection GetSortedActionItems()
    {
        DesignerActionItemCollection actions =
        [
            new DesignerActionHeaderItem(@"Appearance"),
            new DesignerActionPropertyItem(nameof(ButtonStyle), @"Style", @"Appearance", @"Button style"),
            new DesignerActionPropertyItem(nameof(KryptonContextMenu), @"Krypton Context Menu", @"Appearance", @"The Krypton Context Menu for the control."),
            new DesignerActionPropertyItem(nameof(Orientation), @"Orientation", @"Appearance", @"Button orientation"),
            new DesignerActionPropertyItem(nameof(StateCommonShortTextFont), @"State Common Short Text Font", @"Appearance", @"The State Common Short Text Font."),
            new DesignerActionPropertyItem(nameof(StateCommonLongTextFont), @"State Common State Common Long Text Font", @"Appearance", @"The State Common State Common Long Text Font."),
            new DesignerActionPropertyItem(nameof(StateCommonCornerRoundingRadius), @"State Common Corner Rounding Radius", @"Appearance", @"The corner rounding radius of the control."),
            new DesignerActionHeaderItem(@"Values"),
            new DesignerActionPropertyItem(nameof(Text), @"Text", @"Values", @"Button text"),
            new DesignerActionPropertyItem(nameof(ExtraText), @"ExtraText", @"Values", @"Button extra text"),
            new DesignerActionPropertyItem(nameof(Image), @"Image", @"Values", @"Button image"),
            new DesignerActionPropertyItem(nameof(DialogResult), @"DialogResult", @"Values", @"The DialogResult for this button"),
            new DesignerActionPropertyItem(nameof(DisplayStringType), @"DisplayStringType", @"Values", @"Use a built-in string from the KryptonManager."),
            new DesignerActionHeaderItem(@"Visuals"),
            new DesignerActionPropertyItem(nameof(PaletteMode), @"Palette", @"Visuals", @"Palette applied to drawing"),
            new DesignerActionHeaderItem(@"UAC Elevation"),
            new DesignerActionPropertyItem(nameof(UseAsUACElevatedButton), @"Use as an UAC Elevated Button", @"UAC Elevation", @"Use this button to elevate a process."),
        ];

        return actions;
    }

    private KryptonDialogButtonExtended Button => (KryptonDialogButtonExtended)_designer.Component;

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
