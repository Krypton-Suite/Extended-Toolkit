#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
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
        public KryptonTrackBar? KryptonTrackBarControl => Control as KryptonTrackBar;

        // Constructor ========================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="KryptonTrackBarToolStripMenuItem"/> class.
        /// </summary>
        public KryptonTrackBarToolStripMenuItem()
            : base(new KryptonTrackBar())
        {
            AutoSize = false;
        }

        /// <summary>
        /// Retrieves the size of a rectangular area into which a control can be fitted.
        /// </summary>
        /// <param name="constrainingSize">The custom-sized area for a control.</param>
        /// <returns>
        /// An ordered pair of type <see cref="T:System.Drawing.Size"></see> representing the width and height of a rectangle.
        /// </returns>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public override Size GetPreferredSize(Size constrainingSize) =>
            //return base.GetPreferredSize(constrainingSize);
            KryptonTrackBarControl!.GetPreferredSize(constrainingSize);

        /// <summary>
        /// Subscribes events from the hosted control.
        /// </summary>
        /// <param name="control">The control from which to subscribe events.</param>
        protected override void OnSubscribeControlEvents(Control control)
        {
            base.OnSubscribeControlEvents(control);

            //Add your code here to subsribe to Control Events
            ((KryptonTrackBar)control).ValueChanged += OnValueChanged;
        }

        /// <summary>
        /// Unsubscribes events from the hosted control.
        /// </summary>
        /// <param name="control">The control from which to unsubscribe events.</param>
        protected override void OnUnsubscribeControlEvents(Control control)
        {
            base.OnUnsubscribeControlEvents(control);

            //Add your code here to unsubscribe from control events.
            ((KryptonTrackBar)control).ValueChanged -= OnValueChanged;
        }

        #region ... exposed properties ...
        public int Value
        {
            get => ((KryptonTrackBar)Control).Value;
            set => ((KryptonTrackBar)Control).Value = value;
        }

        public int LargeChange
        {
            get => ((KryptonTrackBar)Control).LargeChange;
            set => ((KryptonTrackBar)Control).LargeChange = value;
        }

        public int SmallChange
        {
            get => ((KryptonTrackBar)Control).SmallChange;
            set => ((KryptonTrackBar)Control).SmallChange = value;
        }

        public int Maximum
        {
            get => ((KryptonTrackBar)Control).Maximum;
            set => ((KryptonTrackBar)Control).Maximum = value;
        }

        public int Minimum
        {
            get => ((KryptonTrackBar)Control).Minimum;
            set => ((KryptonTrackBar)Control).Minimum = value;
        }

        public bool VolumeControl
        {
            get => ((KryptonTrackBar)Control).VolumeControl;
            set => ((KryptonTrackBar)Control).VolumeControl = value;
        }

        public PaletteTrackBarSize TrackBarSize
        {
            get => ((KryptonTrackBar)Control).TrackBarSize;
            set => ((KryptonTrackBar)Control).TrackBarSize = value;
        }

        public TickStyle TickStyle
        {
            get => ((KryptonTrackBar)Control).TickStyle;
            set => ((KryptonTrackBar)Control).TickStyle = value;
        }

        public int TickFrequency
        {
            get => ((KryptonTrackBar)Control).TickFrequency;
            set => ((KryptonTrackBar)Control).TickFrequency = value;
        }

        public Orientation Orientation
        {
            get => ((KryptonTrackBar)Control).Orientation;
            set => ((KryptonTrackBar)Control).Orientation = value;
        }
        #endregion

        #region ... exposed events ...
        public event EventHandler? ValueChanged;
        protected void OnValueChanged(object? sender, EventArgs e) => ValueChanged?.Invoke(this, e);

        #endregion
    }
}