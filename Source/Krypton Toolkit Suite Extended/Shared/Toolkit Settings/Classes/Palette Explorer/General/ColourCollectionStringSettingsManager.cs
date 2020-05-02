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