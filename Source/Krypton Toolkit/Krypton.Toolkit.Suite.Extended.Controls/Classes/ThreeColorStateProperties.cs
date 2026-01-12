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

using System.ComponentModel;

namespace Krypton.Toolkit.Suite.Extended.Controls;

/// <summary>
/// Provides properties for customizing the three-color state behavior of a progress bar.
/// </summary>
[TypeConverter(typeof(ExpandableObjectConverter))]
public class ThreeColorStateProperties
{
    #region Instance Fields

    private bool _useThreeColorState = false;
    private Color _lowColor = Color.Red;
    private Color _mediumColor = Color.Orange;
    private Color _highColor = Color.Green;
    private int _lowThreshold = 45;
    private int _highThreshold = 75;

    #endregion

    #region Identity

    /// <summary>
    /// Initializes a new instance of the <see cref="ThreeColorStateProperties"/> class.
    /// </summary>
    public ThreeColorStateProperties()
    {
    }

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets or sets a value indicating whether the three-color state feature is enabled.
    /// </summary>
    /// <value><b>True</b> if three-color state is enabled; otherwise, <b>false</b>. The default is <b>false</b>.</value>
    /// <remarks>
    /// When enabled, the progress bar color changes based on the current value:
    /// - Below <see cref="LowThreshold"/>: <see cref="LowColor"/>
    /// - Between thresholds: <see cref="MediumColor"/>
    /// - Above <see cref="HighThreshold"/>: <see cref="HighColor"/>
    /// </remarks>
    [Category("Behavior"),
     DefaultValue(false),
     Description("Enables the three-color state feature that changes the progress bar color based on the current value.")]
    public bool UseThreeColorState
    {
        get => _useThreeColorState;
        set
        {
            _useThreeColorState = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Gets or sets the color used when the progress value is below the low threshold.
    /// </summary>
    /// <value>The color for low values. The default is <see cref="Color.Red"/>.</value>
    [Category("Appearance"),
     DefaultValue(typeof(Color), "Red"),
     Description("The color used when the progress value is below the low threshold.")]
    public Color LowColor
    {
        get => _lowColor;
        set
        {
            _lowColor = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Gets or sets the color used when the progress value is between the low and high thresholds.
    /// </summary>
    /// <value>The color for medium values. The default is <see cref="Color.Orange"/>.</value>
    [Category("Appearance"),
     DefaultValue(typeof(Color), "Orange"),
     Description("The color used when the progress value is between the low and high thresholds.")]
    public Color MediumColor
    {
        get => _mediumColor;
        set
        {
            _mediumColor = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Gets or sets the color used when the progress value is above the high threshold.
    /// </summary>
    /// <value>The color for high values. The default is <see cref="Color.Green"/>.</value>
    [Category("Appearance"),
     DefaultValue(typeof(Color), "Green"),
     Description("The color used when the progress value is above the high threshold.")]
    public Color HighColor
    {
        get => _highColor;
        set
        {
            _highColor = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Gets or sets the threshold value below which the low color is used.
    /// </summary>
    /// <value>The low threshold percentage (0-100). The default is <b>45</b>.</value>
    /// <remarks>
    /// When the progress value is less than this threshold, the <see cref="LowColor"/> is used.
    /// </remarks>
    [Category("Behavior"),
     DefaultValue(45),
     Description("The threshold value below which the low color is used (0-100).")]
    public int LowThreshold
    {
        get => _lowThreshold;
        set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "LowThreshold must be between 0 and 100.");
            }

            if (value >= _highThreshold)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "LowThreshold must be less than HighThreshold.");
            }

            _lowThreshold = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Gets or sets the threshold value above which the high color is used.
    /// </summary>
    /// <value>The high threshold percentage (0-100). The default is <b>75</b>.</value>
    /// <remarks>
    /// When the progress value is greater than or equal to this threshold, the <see cref="HighColor"/> is used.
    /// </remarks>
    [Category("Behavior"),
     DefaultValue(75),
     Description("The threshold value above which the high color is used (0-100).")]
    public int HighThreshold
    {
        get => _highThreshold;
        set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "HighThreshold must be between 0 and 100.");
            }

            if (value <= _lowThreshold)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "HighThreshold must be greater than LowThreshold.");
            }

            _highThreshold = value;
            OnPropertyChanged();
        }
    }

    #endregion

    #region Implementation

    /// <summary>
    /// Called when any property changes.
    /// </summary>
    public event EventHandler? PropertyChanged;

    /// <summary>
    /// Raises the PropertyChanged event.
    /// </summary>
    protected void OnPropertyChanged()
    {
        PropertyChanged?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    /// Returns a string representation of this object.
    /// </summary>
    /// <returns>A string that represents this object.</returns>
    public override string ToString()
    {
        return $"Low: {LowThreshold}%, High: {HighThreshold}%";
    }

    #endregion
}
