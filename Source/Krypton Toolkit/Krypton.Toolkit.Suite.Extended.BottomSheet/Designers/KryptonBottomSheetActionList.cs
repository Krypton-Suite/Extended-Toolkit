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

namespace Krypton.Toolkit.Suite.Extended.BottomSheet;

internal sealed class KryptonBottomSheetActionList : DesignerActionList
{
    private readonly KryptonBottomSheetDesigner _designer;

    public KryptonBottomSheetActionList(KryptonBottomSheetDesigner designer)
        : base(designer.Component)
    {
        _designer = designer;
    }

    public bool ShowHandle
    {
        get => Sheet.ShowHandle;
        set => SetProperty(nameof(KryptonBottomSheet.ShowHandle), value);
    }

    public bool EnableDragToDismiss
    {
        get => Sheet.EnableDragToDismiss;
        set => SetProperty(nameof(KryptonBottomSheet.EnableDragToDismiss), value);
    }

    public int CornerRadius
    {
        get => Sheet.CornerRadius;
        set => SetProperty(nameof(KryptonBottomSheet.CornerRadius), value);
    }

    public override DesignerActionItemCollection GetSortedActionItems() =>
    [
        new DesignerActionPropertyItem(nameof(ShowHandle), @"Show handle", @"Bottom Sheet", @"Whether the drag handle is visible."),
        new DesignerActionPropertyItem(nameof(EnableDragToDismiss), @"Drag to dismiss", @"Bottom Sheet", @"Whether dragging dismisses the sheet."),
        new DesignerActionPropertyItem(nameof(CornerRadius), @"Corner radius", @"Bottom Sheet", @"Top corner radius in pixels."),
    ];

    private KryptonBottomSheet Sheet => (KryptonBottomSheet)_designer.Component;

    private void SetProperty<T>(string propertyName, T value)
    {
        PropertyDescriptor? property = TypeDescriptor.GetProperties(Sheet)[propertyName];
        property?.SetValue(Sheet, value);
    }
}
