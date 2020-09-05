namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation
{
    public interface IDraggable
    {
        bool DragEnabled { get; set; }
        Cursor DragCursor { get; }
        void SetLimits(double? x1, double? x2, double? y1, double? y2);
        bool IsUnderMouse(double coordinateX, double coordinateY, double snapX, double snapY);
        void DragTo(double coordinateX, double coordinateY, bool isShiftDown, bool isAltDown, bool isCtrlDown);
    }
}
