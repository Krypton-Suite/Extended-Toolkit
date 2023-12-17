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

namespace Krypton.Toolkit.Suite.Extended.Controls
{
    /// <summary>
    /// Represents a Windows progress bar control which displays 
    /// its <see cref="ProgressBar.Value" /> as text on a faded background.
    /// Based off of: https://www.codeproject.com/Articles/1082902/How-to-Paint-on-Top-of-a-ProgressBar-using-Csharp
    /// </summary>
    /// <remarks>
    /// KryptonProgressBarExtended is a specialized type of <see cref="ProgressBar" />, which it extends 
    /// to fade its background colors and to display its <see cref="KryptonProgressBarExtended.Text" />. 
    /// 
    /// <para>You can manipulate the background fading intensity by changing the value of 
    /// property <see cref="KryptonProgressBarExtended.Fade" /> which accepts values between 0 and 255. 
    /// Lower values make the background darker; higher values make the background lighter.</para>
    /// 
    /// <para>The current <see cref="ProgressBar.Text" /> is displayed using the values of properties 
    /// <see cref="KryptonProgressBarExtended.Font" /> and <see cref="KryptonProgressBarExtended.ForeColor" />.</para>
    /// 
    /// <para><note type="inherit">When you derive from KryptonProgressBarExtended, adding new functionality to the 
    /// derived class, if your derived class references objects that must be disposed of before an instance of 
    /// your class is destroyed, you must override the <see cref="KryptonProgressBarExtended.Dispose(bool)" /> 
    /// method, and call <see cref="System.ComponentModel.Component.Dispose()">Dispose()</see> on all objects 
    /// that are referenced in your class, before calling <c>Dispose(disposing)</c> on the base class.</note></para>
    /// </remarks>
    [Description("Provides a ProgressBar which displays its Value as text on a faded background."),
     Designer(typeof(KryptonProgressBarExtendedVersion2Designer)),
     ToolboxBitmap(typeof(ProgressBar)),
     Obsolete(@"Please use the native KryptonProgressBar instead.")]
    public class KryptonProgressBarExtended : ProgressBar
    {
        #region Instance Fields

        private int _fade = 150;

        private SolidBrush? _fadeBrush;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the opacity of the white overlay brush which fades 
        /// the background colors of the <see cref="KryptonProgressBarExtended" />.
        /// </summary>
        /// <value>An <see cref="int" /> representing the alpha 
        /// value of the overlay color. The default is <b>150</b>.</value>
        /// <remarks>
        /// You can use this property to manipulate the density of the background coloring of this control, 
        /// to allow for better readability of any text within the <see cref="KryptonProgressBarExtended" />. You can use 
        /// the <see cref="KryptonProgressBarExtended.Font" /> and <see cref="KryptonProgressBarExtended.ForeColor" /> properties 
        /// to further optimize the display of text.
        /// 
        /// <para>Acceptable values for this property are between 0 and 255 inclusive. The default is 150; 
        /// lower values make the background darker; higher values make the background lighter.</para>
        /// </remarks>
        /// <exception cref="System.ArgumentOutOfRangeException">The value assigned to the property is less than 0 or greater than 255.</exception>
        [Category("Appearance"),
        DefaultValue(150),
        Description("Specifies the opacity of the white overlay brush which fades the background colors of the KryptonProgressBarExtendedVersion2.")]
        public int Fade
        {
            get => _fade;
            set
            {
                if (value < 0 || value > 255)
                {
                    object[] str = new object[] { value };
                    throw new ArgumentOutOfRangeException("value", $"A value of '{str}' is not valid for 'Fade'. 'Fade' must be between 0 and 255.");
                }

                _fade = value;

                // Clean up previous brush
                if (_fadeBrush != null)
                {
                    _fadeBrush.Dispose();
                }

                _fadeBrush = new SolidBrush(Color.FromArgb(value, Color.White));

                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="System.Drawing.Font" /> of 
        /// the text displayed by the <see cref="KryptonProgressBarExtendedVersion2" />.
        /// </summary>
        /// <value>The <see cref="System.Drawing.Font" /> to 
        /// apply to the text displayed by the control.</value>
        /// <remarks>
        /// You can use the Font property to change the <see cref="System.Drawing.Font" /> 
        /// to use when drawing text. To change the text <see cref="Color" />, 
        /// use the <see cref="KryptonProgressBarExtendedVersion2.ForeColor" /> property.
        /// 
        /// <para>The Font property is an ambient property. An ambient property is 
        /// a control property that, if not set, is retrieved from the parent control.</para>
        /// 
        /// <para>Because the <see cref="System.Drawing.Font" /> class is immutable (meaning 
        /// that you cannot adjust any of its properties), you can only assign the Font property 
        /// a new Font. However, you can base the new font on the existing font.</para>
        /// 
        /// <para><note type="inherit">When overriding the Font property in a derived class, use the 
        /// base class's Font property to extend the base implementation. Otherwise, you must provide 
        /// all the implementation.</note></para>
        /// </remarks>
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public override Font Font { get => base.Font; set => base.Font = value; }

        /// <summary>
        /// Gets or sets the color of the text displayed by <see cref="KryptonProgressBarExtendedVersion2" />.
        /// </summary>
        /// <value>A <see cref="Color" /> that represents the 
        /// control's foreground color. The default is <b>ControlText</b>.</value>
        /// <remarks>
        /// You can use the ForeColor property to change the color of the text within the 
        /// <see cref="KryptonProgressBarExtendedVersion2" /> to match the text of other controls on your form.
        /// To change the <see cref="System.Drawing.Font" /> to use when drawing text, use the 
        /// <see cref="KryptonProgressBarExtendedVersion2.Font">KryptonProgressBarExtendedVersion2.Font</see> property.
        /// 
        /// <para><note type="inherit">When overriding the ForeColor property in a derived class, 
        /// use the base class's ForeColor property to extend the base implementation. Otherwise, 
        /// you must provide all the implementation.</note></para>
        /// </remarks>
        [DefaultValue(typeof(Color), "ControlText")]
        public override Color ForeColor { get; set; }

        /// <summary>
        /// Gets the text associated with this <see cref="KryptonProgressBarExtendedVersion2" />.
        /// </summary>
        /// <value>A <see cref="string" /> representing the text displayed in the control.</value>
        /// <remarks>
        /// The <see cref="KryptonProgressBarExtendedVersion2" /> control supports display of a single line of 
        /// text, consisting of the <see cref="ProgressBar.Value" /> followed by a percent sign.
        /// 
        /// <para>The text is displayed using the values of properties 
        /// <see cref="KryptonProgressBarExtendedVersion2.Font" /> and <see cref="KryptonProgressBarExtendedVersion2.ForeColor" />.</para>
        /// </remarks>
        [Browsable(false),
         EditorBrowsable(EditorBrowsableState.Always),
         Bindable(false)]
        public override string Text => $"{Value.ToString(CultureInfo.CurrentCulture)}%";

        #endregion

        #region Protected Properties

        /// <summary>
        /// Returns the parameters used to create the window 
        /// for the <see cref="KryptonProgressBarExtendedVersion2" /> control.
        /// </summary>
        /// <value>A <see cref="System.Windows.Forms.CreateParams" /> object that contains the 
        /// required creation parameters for the <see cref="KryptonProgressBarExtendedVersion2" /> control.</value>
        /// <remarks>
        /// The information returned by the CreateParams property is used to 
        /// pass information about the initial state and appearance of this 
        /// control, at the time an instance of this class is being created.
        /// 
        /// <para><note type="inherit">When overriding the CreateParams property in a derived 
        /// class, use the base class's CreateParams property to extend the base implementation. 
        /// Otherwise, you must provide all the implementation.</note></para>
        /// </remarks>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;

                // Make the control use double buffering
                cp.ExStyle |= NativeMethods.WS_EX_COMPOSITED;

                return cp;
            }
        }

        #endregion

        #region Identity

        /// <summary>Initializes a new instance of the <see cref="KryptonProgressBarExtended" /> class.</summary>
        public KryptonProgressBarExtended()
        {
            ForeColor = SystemColors.ControlText;

            _fadeBrush = new SolidBrush(Color.FromArgb(Fade, 255, 255, 255));
        }

        #endregion

        #region Garbage Collection

        /// <summary> 
        /// Releases the unmanaged resources used by the <see cref="KryptonProgressBarExtendedVersion2" /> 
        /// and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing"><b>True</b> to release both managed and unmanaged 
        /// resources; <b>false</b> to release only unmanaged resources.</param> 
        /// <remarks>
        /// This method is called by the public <see cref="Control.Dispose" /> method and 
        /// the <see cref="Object.Finalize" /> method. Dispose invokes Dispose with the 
        /// <i>disposing</i> parameter set to <b>true</b>. Finalize invokes Dispose with 
        /// <i>disposing</i> set to <b>false</b>.
        /// 
        /// <para><note type="inherit">Dispose might be called multiple times by other objects. 
        /// When overriding <i>Dispose(Boolean)</i>, be careful not to reference objects that 
        /// have been previously disposed of in an earlier call to Dispose.
        /// 
        /// <para>If your derived class references objects that must be disposed of before an 
        /// instance of your class is destroyed, you must call <see cref="Control.Dispose" /> on 
        /// all objects that are referenced in your class, before calling <c>Dispose(disposing)</c> 
        /// on the base class.</para></note></para>
        /// </remarks>
        /// <overloads>Releases all resources used by the <see cref="KryptonProgressBarExtendedVersion2" />.
        /// <para>This member is overloaded. For complete information about this member, 
        /// click a name in the overload list.</para></overloads>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_fadeBrush != null)
                {
                    _fadeBrush.Dispose();

                    _fadeBrush = null;
                }
            }

            base.Dispose(disposing);
        }

        #endregion

        #region Implementation

        /// <summary>
        /// Processes Windows messages.
        /// </summary>
        /// <param name="m">The Windows Message to process.</param>
        /// <remarks>
        /// All messages are sent to the WndProc method after getting filtered 
        /// through the PreProcessMessage method. The WndProc method corresponds 
        /// exactly to the Windows WindowProc function. 
        /// 
        /// <para><note type="inherit">Inheriting controls should call the base class's 
        /// WndProc method to process any messages that they do not handle.</note></para>
        /// </remarks>
        protected override void WndProc(ref Message m)
        {
            int msg = m.Msg;

            if (msg == NativeMethods.WM_PAINT)
            {
                WmPaint(ref m);

                return;
            }

            if (msg == NativeMethods.WM_PRINTCLIENT)
            {
                WmPrintClient(ref m);

                return;
            }

            base.WndProc(ref m);
        }

        /// <summary>
        /// Returns a string representation for this <see cref="KryptonProgressBarExtendedVersion2" />.
        /// </summary>
        /// <returns>A <see cref="string" /> that describes this control.</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(GetType().FullName);
            builder.Append(", Minimum: ");
            builder.Append(Minimum.ToString(CultureInfo.CurrentCulture));
            builder.Append(", Maximum: ");
            builder.Append(Maximum.ToString(CultureInfo.CurrentCulture));
            builder.Append(", Value: ");
            builder.Append(Value.ToString(CultureInfo.CurrentCulture));

            return builder.ToString();
        }

        private void PaintPrivate(IntPtr device)
        {
            // Create a Graphics object for the device context
            using (Graphics graphics = Graphics.FromHdc(device))
            {
                Rectangle rect = ClientRectangle;

                if (_fadeBrush != null)
                {
                    // Paint a translucent white layer on top, to fade the colors a bit
                    graphics.FillRectangle(_fadeBrush, rect);
                }

                TextRenderer.DrawText(graphics, Text, Font, rect, ForeColor);
            }
        }

        private void WmPaint(ref Message m)
        {
            // Create a wrapper for the Handle
            HandleRef myHandle = new HandleRef(this, Handle);

            // Prepare the window for painting and retrieve a device context
            NativeMethods.PAINTSTRUCT pAINTSTRUCT = new NativeMethods.PAINTSTRUCT();
            IntPtr hDC = UnsafeNativeMethods.BeginPaint(myHandle, ref pAINTSTRUCT);

            try
            {
                // Apply hDC to message
                m.WParam = hDC;

                // Let Windows paint
                base.WndProc(ref m);

                // Custom painting
                PaintPrivate(hDC);
            }
            finally
            {
                // Release the device context that BeginPaint retrieved
                UnsafeNativeMethods.EndPaint(myHandle, ref pAINTSTRUCT);
            }
        }

        private void WmPrintClient(ref Message m)
        {
            // Retrieve the device context
            IntPtr hDC = m.WParam;

            // Let Windows paint
            base.WndProc(ref m);

            // Custom painting
            PaintPrivate(hDC);
        }

        #endregion
    }
}