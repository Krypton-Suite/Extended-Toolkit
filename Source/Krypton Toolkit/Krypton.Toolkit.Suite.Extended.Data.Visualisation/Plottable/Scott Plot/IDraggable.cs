using System;

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public interface IDraggable
    {
        bool DragEnabled { get; set; }
        Cursor DragCursor { get; }
        bool IsUnderMouse(double coordinateX, double coordinateY, double snapX, double snapY);
        void DragTo(double coordinateX, double coordinateY, bool fixedSize);
        event EventHandler Dragged;
    }
}
