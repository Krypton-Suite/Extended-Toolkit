﻿#region MIT License
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

using System.Collections.Specialized;

namespace Krypton.Toolkit.Suite.Extended.Settings
{
    public class ColourCollectionStringSettingsManager
    {
        #region Variables
        private ColourCollectionStringSettings _colourCollectionStringSettings = new();
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