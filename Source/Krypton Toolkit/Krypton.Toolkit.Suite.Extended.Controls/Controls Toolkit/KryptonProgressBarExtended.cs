#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2026 - 2026 Krypton Suite
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

using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Text;
using Krypton.Toolkit;

namespace Krypton.Toolkit.Suite.Extended.Controls;

/// <summary>
/// Represents a Krypton progress bar control with three-color state support.
/// </summary>
/// <remarks>
/// This control extends <see cref="KryptonProgressBar"/> to add support for dynamic color changes
/// based on progress value thresholds. When enabled, the progress bar color changes based on the current value:
/// - Below low threshold: Low color (default: Red)
/// - Between thresholds: Medium color (default: Orange)
/// - Above high threshold: High color (default: Green)
/// </remarks>
public class KryptonProgressBarExtended : KryptonProgressBar
{
    #region Instance Fields

    private ThreeColorStateProperties _stateProperties;
    private int _lastPercentage = -1;

    #endregion

    #region Identity

    /// <summary>
    /// Initializes a new instance of the <see cref="KryptonProgressBarExtended"/> class.
    /// </summary>
    public KryptonProgressBarExtended()
    {
        _stateProperties = new ThreeColorStateProperties();
        _stateProperties.PropertyChanged += ThreeColorState_PropertyChanged;
    }

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets or sets the three-color state properties.
    /// </summary>
    /// <value>A <see cref="ThreeColorStateProperties"/> object containing the color and threshold settings.</value>
    /// <remarks>
    /// This property provides access to the colors and thresholds used for the three-color state feature.
    /// The property is expandable in the property grid, allowing easy customization of colors and thresholds.
    /// Use <see cref="ThreeColorStateProperties.UseThreeColorState"/> to enable or disable the feature.
    /// </remarks>
    [Category("Appearance"),
     Description("Gets or sets the three-color state properties including colors and thresholds."),
     DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public ThreeColorStateProperties ThreeColorState
    {
        get => _stateProperties;
        set
        {
            if (_stateProperties != null)
            {
                _stateProperties.PropertyChanged -= ThreeColorState_PropertyChanged;
            }

            _stateProperties = value ?? new ThreeColorStateProperties();

            if (_stateProperties != null)
            {
                _stateProperties.PropertyChanged += ThreeColorState_PropertyChanged;
            }

            UpdateProgressBarColor();
            Invalidate();
        }
    }

    #endregion

    #region Overrides

    /// <summary>
    /// Raises the <see cref="Control.HandleCreated" /> event.
    /// </summary>
    /// <param name="e">An <see cref="EventArgs" /> that contains the event data.</param>
    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);
        UpdateProgressBarColor();
    }

    /// <summary>
    /// Processes Windows messages.
    /// </summary>
    /// <param name="m">The Windows Message to process.</param>
    protected override void WndProc(ref Message m)
    {
        // Intercept PBM_SETPOS (0x402) to detect when Value changes
        // This allows us to update the color immediately when the value changes
        const int PBM_SETPOS = 0x402; // WM_USER + 2
        
        base.WndProc(ref m);

        // Update color after the message is processed, when the Value has actually changed
        if (m.Msg == PBM_SETPOS && _stateProperties.UseThreeColorState && IsHandleCreated)
        {
            UpdateProgressBarColor();
        }
    }

    /// <summary>
    /// Raises the <see cref="Control.Paint" /> event.
    /// </summary>
    /// <param name="e">A <see cref="PaintEventArgs" /> that contains the event data.</param>
    protected override void OnPaint(PaintEventArgs e)
    {
        // Update color before base paints to ensure it's applied
        UpdateProgressBarColor();
        base.OnPaint(e);
    }

    /// <summary>
    /// Returns a string representation for this <see cref="KryptonProgressBarExtended" />.
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

    #endregion

    #region Implementation

    /// <summary>
    /// Updates the progress bar color based on the current value and three-color state settings.
    /// </summary>
    private void UpdateProgressBarColor()
    {
        if (!_stateProperties.UseThreeColorState || !IsHandleCreated)
        {
            _lastPercentage = -1; // Reset tracking when disabled
            return;
        }

        // Calculate the percentage
        int range = Maximum - Minimum;
        if (range == 0)
        {
            return;
        }

        int percentage = (int)(((double)(Value - Minimum) / range) * 100);

        // Only update if percentage changed or if we're forcing an update
        if (percentage == _lastPercentage)
        {
            return;
        }

        _lastPercentage = percentage;

        Color colorToUse;

        if (percentage < _stateProperties.LowThreshold)
        {
            colorToUse = _stateProperties.LowColor;
        }
        else if (percentage >= _stateProperties.HighThreshold)
        {
            colorToUse = _stateProperties.HighColor;
        }
        else
        {
            colorToUse = _stateProperties.MediumColor;
        }

        // Update the KryptonProgressBar color using StateCommon.Back for better integration with Krypton theming
        try
        {
            if (StateCommon != null && StateCommon.Back != null)
            {
                StateCommon.Back.Color1 = colorToUse;
                StateCommon.Back.Color2 = colorToUse;
                // Force the control to repaint with the new color
                Invalidate();
            }
            else
            {
                // Fallback to Windows message if StateCommon is not available
                SetProgressBarColorViaMessage(colorToUse);
            }
        }
        catch
        {
            // If StateCommon is not available or throws an exception, use Windows message (fallback)
            SetProgressBarColorViaMessage(colorToUse);
        }
    }

    /// <summary>
    /// Sets the progress bar color using Windows PBM_SETBARCOLOR message.
    /// </summary>
    /// <param name="color">The color to set.</param>
    private void SetProgressBarColorViaMessage(Color color)
    {
        // Convert Color to COLORREF (0x00BBGGRR format)
        int colorRef = color.B | (color.G << 8) | (color.R << 16);

        // Send PBM_SETBARCOLOR message to change the progress bar color
        UnsafeNativeMethods.SendMessage(Handle, NativeMethods.PBM_SETBARCOLOR, IntPtr.Zero, new IntPtr(colorRef));
    }

    /// <summary>
    /// Handles the PropertyChanged event of the ThreeColorState object.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    private void ThreeColorState_PropertyChanged(object? sender, EventArgs e)
    {
        _lastPercentage = -1; // Force update on property change
        UpdateProgressBarColor();
        Invalidate();
    }

    #endregion
}