#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Forms
{
    /// <summary>
    /// Implementation for the fixed close button for krypton form.
    /// </summary>
    public class ButtonSpecFormWindowClose : ButtonSpecFormFixed
    {
        private bool _enabled = true;

        #region Public

        /// <summary>
        /// Form Close Button Enabled: This will also Disable the System Menu `Close` BUT NOT the `Alt+F4` key action
        /// </summary>
        [Category(@"Appearance")]
        [DefaultValue(true)]
        [Description("Form Close Button Enabled: This will also Disable the System Menu `Close` BUT NOT the `Alt+F4` key action")]
        public bool Enabled
        {
            get => _enabled;
            set
            {
                if (_enabled != value)
                {
                    _enabled = value;
                    IntPtr hSystemMenu = PlatformInvoke.GetSystemMenu(KryptonForm.Handle, false);
                    if (hSystemMenu != IntPtr.Zero)
                    {
                        PlatformInvoke.EnableMenuItem(hSystemMenu, PlatformInvoke.SC_.CLOSE, _enabled ? PlatformInvoke.MF_.ENABLED : PlatformInvoke.MF_.DISABLED);
                    }
                }
            }
        }

        #endregion

        #region Identity
        /// <summary>
        /// Initialize a new instance of the ButtonSpecFormWindowClose class.
        /// </summary>
        /// <param name="form">Reference to owning krypton form instance.</param>
        public ButtonSpecFormWindowClose(VirtualKryptonFormExtended form)
            : base(form, PaletteButtonSpecStyle.FormClose)
        {
        }
        #endregion

        #region IButtonSpecValues
        /// <summary>
        /// Gets the button visible value.
        /// </summary>
        /// <param name="palette">Palette to use for inheriting values.</param>
        /// <returns>Button visibility.</returns>
        public override bool GetVisible(PaletteBase palette)
        {
            // We do not show if the custom chrome is combined with composition,
            // in which case the form buttons are handled by the composition
            if (KryptonForm.ApplyComposition && KryptonForm.ApplyCustomChrome)
            {
                return false;
            }

            // Have all buttons been turned off?
            return KryptonForm.ControlBox && KryptonForm.CloseBox;
        }

        /// <summary>
        /// Gets the button enabled state.
        /// </summary>
        /// <param name="palette">Palette to use for inheriting values.</param>
        /// <returns>Button enabled state.</returns>
        public override ButtonEnabled GetEnabled(PaletteBase palette) => KryptonForm.CloseBox && Enabled ? ButtonEnabled.True : ButtonEnabled.False;

        /// <summary>
        /// Gets the button checked state.
        /// </summary>
        /// <param name="palette">Palette to use for inheriting values.</param>
        /// <returns>Button checked state.</returns>
        public override ButtonCheckState GetChecked(PaletteBase palette) =>
            // Close button is never shown as checked
            ButtonCheckState.NotCheckButton;

        #endregion    

        #region Protected Overrides
        /// <summary>
        /// Raises the Click event.
        /// </summary>
        /// <param name="e">An EventArgs that contains the event data.</param>
        protected override void OnClick(EventArgs e)
        {
            // Only if associated view is enabled to we perform an action
            if (GetViewEnabled())
            {
                // If we do not provide an inert form
                if (!KryptonForm.InertForm)
                {
                    // Only if the mouse is still within the button bounds do we perform action
                    MouseEventArgs mea = (MouseEventArgs)e;
                    if (GetView().ClientRectangle.Contains(mea.Location))
                    {
                        PropertyInfo pi = typeof(Form).GetProperty(@"CloseReason",
                                                                    BindingFlags.Instance |
                                                                    BindingFlags.SetProperty |
                                                                    BindingFlags.NonPublic);

                        // Update form with the reason for the close
                        pi.SetValue(KryptonForm, CloseReason.UserClosing, null);

                        // Convert screen position to LPARAM format of WM_SYSCOMMAND message
                        Point screenPos = Control.MousePosition;
                        IntPtr lParam = (IntPtr)(PlatformInvoke.MAKELOWORD(screenPos.X) |
                                                 PlatformInvoke.MAKEHIWORD(screenPos.Y));

                        // Request the form be closed down
                        KryptonForm.SendSysCommand(PlatformInvoke.SC_.CLOSE, lParam);

                        // Let base class fire any other attached events
                        base.OnClick(e);
                    }
                }
            }
        }
        #endregion
    }
}