namespace Krypton.Toolkit.Suite.Extended.Dock.Extender
{
    public sealed class KryptonDockExtender
    {
        private Control _dockHost;
        private Flotables _floaties;

        // this is the blue overlay that presents a preview how the control will be docked
        internal KryptonOverlayForm _overlay = new();


        public Flotables Floaties => _floaties;

        public KryptonDockExtender(Control dockHost)
        {
            _dockHost = dockHost;
            _floaties = new();
        }

        /// <summary>
        /// display the container control that is either floating or docked
        /// </summary>
        /// <param name="container"></param>
        public void Show(Control container)
        {
            IFloatable f = _floaties.FindFloatables(container);
            if (f != null)
            {
                f.Show();
            }
        }

        /// <summary>
        /// this will gracefully hide the container control
        /// making sure that the floating window is also closed
        /// </summary>
        /// <param name="container"></param>
        public void Hide(Control container)
        {
            IFloatable f = _floaties.FindFloatables(container);
            if (f != null)
            {
                f.Hide();
            }
        }

        /// <summary>
        /// Attach a container control and use it as a grip hande. The container must support mouse move events.
        /// </summary>
        /// <param name="container">container to make dockable/floatable</param>
        /// <returns>the floaty that manages the container's behaviour</returns>
        public IFloatable Attach(ScrollableControl container)
        {
            return Attach(container, container, null);
        }

        /// <summary>
        /// Attach a container and a grip handle. The handle must support mouse move events.
        /// </summary>
        /// <param name="container">container to make dockable/floatable</param>
        /// <param name="handle">grip handle used to drag the container</param>
        /// <returns>the floaty that manages the container's behaviour</returns>
        public IFloatable Attach(ScrollableControl container, Control handle)
        {
            return Attach(container, handle, null);
        }

        /// <summary>
        /// attach this class to any dockable type of container control 
        /// to make it dockable.
        /// Attach a container control and use it as a grip hande. The handle must support mouse move events.
        /// Supply a splitter control to allow resizing of the docked container
        /// </summary>
        /// <param name="container">control to be dockable</param>
        /// <param name="handle">handle to be used to track the mouse movement (e.g. caption of the container)</param>
        /// <param name="splitter">splitter to resize the docked container (optional)</param>
        public IFloatable Attach(ScrollableControl container, Control handle, KryptonSeparator splitter)
        {
            if (container == null) throw new ArgumentException("container cannot be null");
            if (handle == null) throw new ArgumentException("handle cannot be null");

            DockState _dockState = new DockState();
            _dockState.Container = container;
            _dockState.Handle = handle;
            _dockState.OrgDockHost = _dockHost;
            _dockState.Splitter = splitter;

            KryptonFloatableForm floaty = new KryptonFloatableForm(this);
            floaty.Attach(_dockState);
            _floaties.Add(floaty);
            return floaty;
        }

        // finds the potential dockhost control at the specified location
        internal Control FindDockHost(KryptonFloatableForm floaty, Point pt)
        {
            Control c = null;
            if (FormIsHit(floaty.DockState.OrgDockHost, pt))
                c = floaty.DockState.OrgDockHost; //assume toplevel control

            if (floaty.DockOnHostOnly)
                return c;

            foreach (KryptonFloatableForm f in Floaties)
            {
                if (f.DockState.Container.Visible && FormIsHit(f.DockState.Container, pt))
                {
                    // add this line to dissallow docking inside floaties
                    //if (f.Visible) continue;

                    c = f.DockState.Container; // found suitable floating form
                    break;
                }
            }

            return c;
        }

        // finds the potential dockhost control at the specified location
        internal bool FormIsHit(Control c, Point pt)
        {
            if (c == null) return false;

            Point pc = c.PointToClient(pt);
            bool hit = c.ClientRectangle.IntersectsWith(new Rectangle(pc,
                new Size(1, 1))); //.TopLevelControl; // this is tricky
            return hit;
        }
    }
}