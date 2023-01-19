using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Suite.Extended.Dock.Extender
{
    internal struct DockState
    {
        /// <summary>
        /// the docking control (usually a container class, e.g Panel)
        /// </summary>
        public ScrollableControl Container;
        /// <summary>
        /// handle of the container that the user can use to select and move the container
        /// </summary>
        public Control Handle;

        /// <summary>
        /// splitter that is attached to this panel for resizing.
        /// this is optional
        /// </summary>
        public Splitter Splitter;

        /// <summary>
        /// the parent of the container
        /// </summary>
        public Control OrgDockingParent;

        /// <summary>
        /// the base docking host that contains all docking panels
        /// </summary>
        public Control OrgDockHost;

        /// <summary>
        /// the origional docking style, stored in order to reset the state
        /// </summary>
        public DockStyle OrgDockStyle;

        /// <summary>
        /// the origional bounds of the container
        /// </summary>
        public Rectangle OrgBounds;

    }
}