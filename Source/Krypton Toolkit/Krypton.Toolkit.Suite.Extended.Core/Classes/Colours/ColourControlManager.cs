#region MIT License
/*
 *
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

namespace Krypton.Toolkit.Suite.Extended.Core;

public class ColourControlManager
{
    #region Variables
    private int _minimumDarkColourHueValue, _maximumDarkColourHueValue, _minimumMediumColourHueValue, _maximumMediumColourHueValue, _minimumLightColourHueValue, _maximumLightColourHueValue,
        _minimumLightestColourHueValue, _maximumLightestColourHueValue;
    #endregion

    #region Properties
    public int MinimumDarkColourHueValue { get => _minimumDarkColourHueValue;
        set => _minimumDarkColourHueValue = value;
    }

    public int MaximumDarkColourHueValue { get => _maximumDarkColourHueValue;
        set => _maximumDarkColourHueValue = value;
    }

    public int MinimumMediumColourHueValue { get => _minimumMediumColourHueValue;
        set => _minimumMediumColourHueValue = value;
    }

    public int MaximumMediumColourHueValue { get => _maximumMediumColourHueValue;
        set => _maximumMediumColourHueValue = value;
    }

    public int MinimumLightColourHueValue { get => _minimumLightColourHueValue;
        set => _minimumLightColourHueValue = value;
    }

    public int MaximumLightColourHueValue { get => _maximumLightColourHueValue;
        set => _maximumLightColourHueValue = value;
    }

    public int MinimumLightestColourHueValue { get => _minimumLightestColourHueValue;
        set => _minimumLightestColourHueValue = value;
    }

    public int MaximumLightestColourHueValue { get => _maximumLightestColourHueValue;
        set => _maximumLightestColourHueValue = value;
    }
    #endregion

    #region Constructor
    public ColourControlManager()
    {

    }
    #endregion

    #region Methods
    public void SetDarkColourHueValues(KryptonNumericUpDown hueValues, int minValue, int maxValue)
    {
        hueValues.Minimum = minValue;

        hueValues.Maximum = maxValue;
    }

    public void SetMediumColourHueValues(KryptonNumericUpDown hueValues, int minValue, int maxValue)
    {
        hueValues.Minimum = minValue;

        hueValues.Maximum = maxValue;
    }

    public void SetLightColourHueValues(KryptonNumericUpDown hueValues, int minValue, int maxValue)
    {
        hueValues.Minimum = minValue;

        hueValues.Maximum = maxValue;
    }

    public void SetLightestColourHueValues(KryptonNumericUpDown hueValues, int minValue, int maxValue)
    {
        hueValues.Minimum = minValue;

        hueValues.Maximum = maxValue;
    }
    #endregion
}