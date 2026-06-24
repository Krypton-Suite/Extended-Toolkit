#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
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
