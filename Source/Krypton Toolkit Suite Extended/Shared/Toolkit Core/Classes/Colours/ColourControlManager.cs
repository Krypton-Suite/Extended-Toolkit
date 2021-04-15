#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Core
{
    public class ColourControlManager
    {
        #region Variables
        private int _minimumDarkColourHueValue, _maximumDarkColourHueValue, _minimumMediumColourHueValue, _maximumMediumColourHueValue, _minimumLightColourHueValue, _maximumLightColourHueValue,
                    _minimumLightestColourHueValue, _maximumLightestColourHueValue;
        #endregion

        #region Properties
        public int MinimumDarkColourHueValue { get { return _minimumDarkColourHueValue; } set { _minimumDarkColourHueValue = value; } }

        public int MaximumDarkColourHueValue { get { return _maximumDarkColourHueValue; } set { _maximumDarkColourHueValue = value; } }

        public int MinimumMediumColourHueValue { get { return _minimumMediumColourHueValue; } set { _minimumMediumColourHueValue = value; } }

        public int MaximumMediumColourHueValue { get { return _maximumMediumColourHueValue; } set { _maximumMediumColourHueValue = value; } }

        public int MinimumLightColourHueValue { get { return _minimumLightColourHueValue; } set { _minimumLightColourHueValue = value; } }

        public int MaximumLightColourHueValue { get { return _maximumLightColourHueValue; } set { _maximumLightColourHueValue = value; } }

        public int MinimumLightestColourHueValue { get { return _minimumLightestColourHueValue; } set { _minimumLightestColourHueValue = value; } }

        public int MaximumLightestColourHueValue { get { return _maximumLightestColourHueValue; } set { _maximumLightestColourHueValue = value; } }
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
}