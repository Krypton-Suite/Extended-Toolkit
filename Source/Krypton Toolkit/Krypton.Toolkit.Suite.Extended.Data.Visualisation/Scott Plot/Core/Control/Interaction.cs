﻿namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    /// <summary>
    /// This class contains logic to perform plot manipulations in response to UI actions.
    /// To customize how user inputs are interpreted, inherit and override functions in this class.
    /// To customize behavior of actions, replace properties of <see cref="Actions"/> with custom delegates.
    /// To customize UI inputs, assign desired button and key properties of <see cref="Inputs"/>.
    /// </summary>
    public class Interaction : IPlotInteraction
    {
        public IPlotControl PlotControl { get; private set; }

        /// <summary>
        /// Buttons and keys in this object can be overwritten to customize actions for specific user input events.
        /// (e.g., make left-click-drag zoom instead of pan)
        /// </summary>
        public InputBindings Inputs = InputBindings.Standard();

        /// <summary>
        /// Delegates in this object can be overwritten with custom functions that manipulate the plot.
        /// (e.g., changing the sensitivity of click-drag-zooming)
        /// </summary>
        public PlotActions Actions = PlotActions.Standard();

        protected readonly KeyboardState Keyboard = new();
        protected readonly MouseState Mouse = new();

        public bool IsDraggingMouse(Pixel pos) => Mouse.PressedButtons.Any() && Mouse.IsDragging(pos);
        protected bool LockX => Inputs.ShouldLockX(Keyboard.PressedKeys);
        protected bool LockY => Inputs.ShouldLockY(Keyboard.PressedKeys);
        protected bool IsZoomingRectangle = false;

        public Interaction(IPlotControl control)
        {
            PlotControl = control;
        }

        /// <summary>
        /// Disable all mouse interactivity
        /// </summary>
        public void Disable()
        {
            Actions = PlotActions.NonInteractive();
        }

        /// <summary>
        /// Enable mouse interactivity using the default mouse actions
        /// </summary>
        public void Enable()
        {
            Actions = PlotActions.Standard();
        }

        /// <summary>
        /// Enable mouse interactivity using custom mouse actions
        /// </summary>
        public void Enable(PlotActions customActions)
        {
            Actions = customActions;
        }

        /// <summary>
        /// Return the last observed location of the mouse in coordinate units
        /// </summary>
        public Coordinates GetMouseCoordinates(IXAxis? xAxis = null, IYAxis? yAxis = null)
        {
            return PlotControl.Plot.GetCoordinates(Mouse.LastPosition, xAxis, yAxis);
        }

        public virtual void OnMouseMove(Pixel newPosition)
        {
            Mouse.LastPosition = newPosition;

            if (IsDraggingMouse(newPosition))
            {
                MouseDrag(
                    from: Mouse.MouseDownPosition,
                    to: newPosition,
                    button: Mouse.PressedButtons.First(),
                    keys: Keyboard.PressedKeys,
                    start: Mouse.MouseDownAxisLimits);
            }
        }

        protected virtual void MouseDrag(Pixel from, Pixel to, MouseButton button, IEnumerable<Key> keys, MultiAxisLimitManager start)
        {
            var lockY = Inputs.ShouldLockY(keys);
            var lockX = Inputs.ShouldLockX(keys);
            LockedAxes locks = new(lockX, LockY);

            MouseDrag drag = new(start, from, to);

            if (Inputs.ShouldZoomRectangle(button, keys))
            {
                Actions.DragZoomRectangle(PlotControl, drag, locks);
                IsZoomingRectangle = true;
            }
            else if (button == Inputs.DragPanButton)
            {
                Actions.DragPan(PlotControl, drag, locks);
            }
            else if (button == Inputs.DragZoomButton)
            {

                Actions.DragZoom(PlotControl, drag, locks);
            }
        }

        public virtual void KeyUp(Key key)
        {
            Keyboard.Up(key);
        }

        public virtual void KeyDown(Key key)
        {
            Keyboard.Down(key);
        }

        public virtual void MouseDown(Pixel position, MouseButton button)
        {
            Mouse.Down(position, button, new MultiAxisLimitManager(PlotControl));
        }

        public virtual void MouseUp(Pixel position, MouseButton button)
        {
            var isDragging = Mouse.IsDragging(position);

            var droppedZoomRectangle =
                isDragging &&
                Inputs.ShouldZoomRectangle(button, Keyboard.PressedKeys) &&
                IsZoomingRectangle;

            if (droppedZoomRectangle)
            {
                Actions.ZoomRectangleApply(PlotControl);
                Actions.ZoomRectangleClear(PlotControl);
                IsZoomingRectangle = false;
            }

            // this covers the case where an extremely tiny zoom rectangle was made
            if (isDragging == false && button == Inputs.ClickAutoAxisButton)
            {
                Actions.AutoScale(PlotControl);
            }

            if (button == Inputs.DragZoomRectangleButton)
            {
                Actions.ZoomRectangleClear(PlotControl);
                IsZoomingRectangle = false;
            }

            if (!isDragging && button == Inputs.ClickContextMenuButton)
            {
                Actions.ShowContextMenu(PlotControl, position);
            }

            Mouse.Up(button);
        }

        public virtual void DoubleClick()
        {
            Actions.ToggleBenchmark(PlotControl);
        }

        public virtual void MouseWheelVertical(Pixel pixel, float delta)
        {
            var direction = delta > 0 ? MouseWheelDirection.Up : MouseWheelDirection.Down;

            if (Inputs.ZoomInWheelDirection.HasValue && Inputs.ZoomInWheelDirection == direction)
            {
                Actions.ZoomIn(PlotControl, pixel, new LockedAxes(LockX, LockY));
            }
            else if (Inputs.ZoomOutWheelDirection.HasValue && Inputs.ZoomOutWheelDirection == direction)
            {
                Actions.ZoomOut(PlotControl, pixel, new LockedAxes(LockX, LockY));
            }
            else if (Inputs.PanUpWheelDirection.HasValue && Inputs.PanUpWheelDirection == direction)
            {
                Actions.PanUp(PlotControl);
            }
            else if (Inputs.PanDownWheelDirection.HasValue && Inputs.PanDownWheelDirection == direction)
            {
                Actions.PanDown(PlotControl);
            }
            else if (Inputs.PanRightWheelDirection.HasValue && Inputs.PanRightWheelDirection == direction)
            {
                Actions.PanRight(PlotControl);
            }
            else if (Inputs.PanLeftWheelDirection.HasValue && Inputs.PanLeftWheelDirection == direction)
            {
                Actions.PanLeft(PlotControl);
            }
            else
            {
                return;
            }
        }
    }
}