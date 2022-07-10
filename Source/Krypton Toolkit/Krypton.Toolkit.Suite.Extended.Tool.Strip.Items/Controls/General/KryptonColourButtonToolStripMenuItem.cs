﻿#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.Data.SqlClient;

namespace Krypton.Toolkit.Suite.Extended.Tool.Strip.Items
{
    [ToolboxBitmap(typeof(Button)), ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.All), DefaultEvent(@"SelectedColorChanged"), DefaultProperty(@"SelectedColor")]
    public class KryptonColourButtonToolStripMenuItem : ToolStripControlHostFixed
    {
        #region Instance Fields

        private Color _selectedColor;

        private Color _emptyBorderColor;

        #endregion

        #region Events

        /// <summary>
        /// Occurs when the SelectedColor property changes value.
        /// </summary>
        [Category(@"Property Changed")]
        [Description(@"Occurs when the SelectedColor property changes value.")]
        public event EventHandler<ColorEventArgs> SelectedColorChanged;

        /// <summary>
        /// Occurs when the user is tracking over a color.
        /// </summary>
        [Category(@"Action")]
        [Description(@"Occurs when user is tracking over a color.")]
        public event EventHandler<ColorEventArgs> TrackingColor;

        /// <summary>
        /// Occurs when the user selects the more colors option.
        /// </summary>
        [Category(@"Action")]
        [Description(@"Occurs when user selects the more colors option.")]
        public event CancelEventHandler MoreColors;

        #endregion

        #region Host Control

        /// <summary>
        /// Gets the KryptonColorButton control.
        /// </summary>
        /// <value>The KryptonColorButton control.</value>
        [RefreshProperties(RefreshProperties.All),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public KryptonColorButton KryptonColourButtonControl => Control as KryptonColorButton;

        #endregion

        #region Public

        [DefaultValue(typeof(Color), "Red")]
        public Color SelectedColor
        {
            get => KryptonColourButtonControl.SelectedColor;
            set
            {
                if (value != KryptonColourButtonControl.SelectedColor)
                {
                    KryptonColourButtonControl.SelectedColor = value;

                    //OnSelectedColorChanged(KryptonColourButtonControl.SelectedColor);
                }
            }
        }

        [DefaultValue(typeof(Color), "DarkGray")]
        public Color EmptyBorderColor
        {
            get => KryptonColourButtonControl.EmptyBorderColor;

            set
            {
                if (value != _emptyBorderColor)
                {
                    KryptonColourButtonControl.EmptyBorderColor = value;
                }
            }
        }

        public new string Text { get => KryptonColourButtonControl.Text; set => KryptonColourButtonControl.Text = value; }

        public Rectangle SelectedRect { get => KryptonColourButtonControl.SelectedRect; set => KryptonColourButtonControl.SelectedRect = value; }

        #endregion

        #region Identity

        /// Initializes a new instance of the <see cref="KryptonComboBoxToolStripMenuItem"/> class.
        /// </summary>
        public KryptonColourButtonToolStripMenuItem()
            : base(new KryptonColorButton())
        {
            AutoSize = false;

            SelectedColor = KryptonColourButtonControl.SelectedColor;

            EmptyBorderColor = KryptonColourButtonControl.EmptyBorderColor;
        }

        #endregion

        #region Protected Virtual

        //protected virtual void OnSelectedColorChanged(Color selectedColor) => SelectedColorChanged?.Invoke(this, new ColorEventArgs(selectedColor));

        //protected virtual void OnTrackingColor(ColorEventArgs colorEvent) => TrackingColor?.Invoke(this, colorEvent);

        //protected virtual void OnMoreColors(CancelEventArgs e) => MoreColors?.Invoke(this, e); 

        #endregion

        #region Implementation

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
            return KryptonColourButtonControl.GetPreferredSize(constrainingSize);
        }

        /// <summary>
        /// Subscribes events from the hosted control.
        /// </summary>
        /// <param name="control">The control from which to subscribe events.</param>
        protected override void OnSubscribeControlEvents(Control control)
        {
            base.OnSubscribeControlEvents(control);

            //Add your code here to subsribe to Control Events
        }

        /// <summary>
        /// Unsubscribes events from the hosted control.
        /// </summary>
        /// <param name="control">The control from which to unsubscribe events.</param>
        protected override void OnUnsubscribeControlEvents(Control control)
        {
            base.OnUnsubscribeControlEvents(control);

            //Add your code here to unsubscribe from control events.
        }

        #endregion
    }
}