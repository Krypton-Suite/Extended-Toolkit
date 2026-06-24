#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.BottomSheet;

internal class KryptonBottomSheetDesigner : ParentControlDesigner
{
    private KryptonBottomSheet? _sheet;

    public override void Initialize(IComponent component)
    {
        base.Initialize(component);
        _sheet = (KryptonBottomSheet)component;
        EnableDesignMode(_sheet.ContentHost, nameof(KryptonBottomSheet.ContentHost));
    }

    public override bool CanParent(Control control) => false;

    public override DesignerActionListCollection ActionLists
    {
        get
        {
            DesignerActionListCollection lists = new()
            {
                new KryptonBottomSheetActionList(this),
            };
            return lists;
        }
    }
}
