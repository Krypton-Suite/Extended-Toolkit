#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.Collections.Specialized;

namespace Krypton.Toolkit.Suite.Extended.Settings
{
    public class ColourCollectionStringSettingsManager
    {
        #region Variables
        private ColourCollectionStringSettings _colourCollectionStringSettings = new ColourCollectionStringSettings();
        #endregion

        #region Constructor
        public ColourCollectionStringSettingsManager()
        {

        }
        #endregion

        #region Setters and Getters
        /// <summary>
        /// Sets the value of ColourStringCollectionValues to value.
        /// </summary>
        /// <param name="value">The value of ColourStringCollectionValues.</param>
        public void SetColourStringCollectionValues(string value)
        {
            _colourCollectionStringSettings.ColourStringCollectionValues.Add(value);
        }

        /// <summary>
        /// Returns the values of ColourStringCollectionValues.
        /// </summary>
        /// <returns>The values of ColourStringCollectionValues.</returns>
        public StringCollection GetColourStringCollectionValues()
        {
            return _colourCollectionStringSettings.ColourStringCollectionValues;
        }
        #endregion
    }
}