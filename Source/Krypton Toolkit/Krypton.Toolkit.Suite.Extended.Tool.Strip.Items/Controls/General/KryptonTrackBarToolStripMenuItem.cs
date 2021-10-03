#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Tool.Strip.Items
{
    [ToolboxBitmap(typeof(KryptonTrackBar)), ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.All)]
    public class KryptonTrackBarToolStripMenuItem : ToolStripControlHostFixed
    {
        // Constants =========================================================
        // Attributes ========================================================
        // Properties ========================================================
        /// <summary>
        /// Gets the KryptonTrackBar control.
        /// </summary>
        /// <value>The KryptonTrackBar control.</value>
        [RefreshProperties(RefreshProperties.All),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public KryptonTrackBar KryptonTrackBarControl
        {
            get { return Control as KryptonTrackBar; }
        }

        // Constructor ========================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="KryptonTrackBarToolStripMenuItem"/> class.
        /// </summary>
        public KryptonTrackBarToolStripMenuItem()
            : base(new KryptonTrackBar())
        {
            this.AutoSize = false;
        }

        /// <summary>
        /// Retrieves the size of a rectangular area into which a control can be fitted.
        /// </summary>
        /// <param name="constrainingSize">The custom-sized area for a control.</param>
        /// <returns>
        /// An ordered pair of type <see cref="T:System.Drawing.Size"></see> representing the width and height of a rectangle.
        /// </returns>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public override Size GetPreferredSize(Size constrainingSize)
        {
            //return base.GetPreferredSize(constrainingSize);
            return this.KryptonTrackBarControl.GetPreferredSize(constrainingSize);
        }

        /// <summary>
        /// Subscribes events from the hosted control.
        /// </summary>
        /// <param name="control">The control from which to subscribe events.</param>
        protected override void OnSubscribeControlEvents(Control control)
        {
            base.OnSubscribeControlEvents(control);

            //Add your code here to subsribe to Control Events
            ((KryptonTrackBar)control).ValueChanged += new EventHandler(OnValueChanged);
        }

        /// <summary>
        /// Unsubscribes events from the hosted control.
        /// </summary>
        /// <param name="control">The control from which to unsubscribe events.</param>
        protected override void OnUnsubscribeControlEvents(Control control)
        {
            base.OnUnsubscribeControlEvents(control);

            //Add your code here to unsubscribe from control events.
            ((KryptonTrackBar)control).ValueChanged -= new EventHandler(OnValueChanged);
        }

        #region ... exposed properties ...
        public int Value
        {
            get { return ((KryptonTrackBar)this.Control).Value; }
            set { ((KryptonTrackBar)this.Control).Value = value; }
        }

        public int LargeChange
        {
            get { return ((KryptonTrackBar)this.Control).LargeChange; }
            set { ((KryptonTrackBar)this.Control).LargeChange = value; }
        }

        public int SmallChange
        {
            get { return ((KryptonTrackBar)this.Control).SmallChange; }
            set { ((KryptonTrackBar)this.Control).SmallChange = value; }
        }

        public int Maximum
        {
            get { return ((KryptonTrackBar)this.Control).Maximum; }
            set { ((KryptonTrackBar)this.Control).Maximum = value; }
        }

        public int Minimum
        {
            get { return ((KryptonTrackBar)this.Control).Minimum; }
            set { ((KryptonTrackBar)this.Control).Minimum = value; }
        }

        public bool VolumeControl
        {
            get { return ((KryptonTrackBar)this.Control).VolumeControl; }
            set { ((KryptonTrackBar)this.Control).VolumeControl = value; }
        }

        public PaletteTrackBarSize TrackBarSize
        {
            get { return ((KryptonTrackBar)this.Control).TrackBarSize; }
            set { ((KryptonTrackBar)this.Control).TrackBarSize = value; }
        }

        public TickStyle TickStyle
        {
            get { return ((KryptonTrackBar)this.Control).TickStyle; }
            set { ((KryptonTrackBar)this.Control).TickStyle = value; }
        }

        public int TickFrequency
        {
            get { return ((KryptonTrackBar)this.Control).TickFrequency; }
            set { ((KryptonTrackBar)this.Control).TickFrequency = value; }
        }

        public Orientation Orientation
        {
            get { return ((KryptonTrackBar)this.Control).Orientation; }
            set { ((KryptonTrackBar)this.Control).Orientation = value; }
        }
        #endregion

        #region ... exposed events ...
        public event EventHandler ValueChanged;
        protected void OnValueChanged(object sender, EventArgs e)
        {
            if (ValueChanged != null)
                ValueChanged(this, e);
        }

        #endregion
    }
}