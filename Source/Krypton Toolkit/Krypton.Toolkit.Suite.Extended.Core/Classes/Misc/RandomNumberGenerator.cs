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

namespace Krypton.Toolkit.Suite.Extended.Core
{
    public class RandomNumberGenerator
    {
        #region Constants
        private const int MINIMUM_COLOUR_VALUE = 0, MAXMUM_COLOUR_VALUE = 256;
        #endregion

        #region Variables
        private int _alphaValue, _redValue, _greenValue, _blueValue, _hueValue; //, _max = byte.MaxValue + 1;

        private Random _randomColourGenerator = new();
        #endregion

        #region Properties
        public int AlphaValue
        {
            get => _alphaValue;
            set => _alphaValue = value;
        }

        public int RedValue
        {
            get => _redValue;
            set => _redValue = value;
        }

        public int GreenValue
        {
            get => _greenValue;
            set => _greenValue = value;
        }

        public int BlueValue
        {
            get => _blueValue;
            set => _blueValue = value;
        }

        public int HueValue
        {
            get => _hueValue;
            set => _hueValue = value;
        }
        #endregion

        #region Constructor
        public RandomNumberGenerator()
        {

        }
        #endregion

        #region Methods
        /// <summary>
        /// Randomly generate a alpha number.
        /// </summary>
        /// <param name="startNumber">The start number.</param>
        /// <param name="endNumber">The end number.</param>
        /// <returns></returns>
        public int RandomlyGenerateAlphaNumberBetween(int startNumber, int endNumber)
        {
            int alphaOutput;

            Random random = new();

            alphaOutput = random.Next(startNumber, endNumber + 1);

            SetAlphaValue(alphaOutput);

            return alphaOutput;
        }

        /// <summary>
        /// Randomly generate a number.
        /// </summary>
        /// <param name="startNumber">The start number.</param>
        /// <param name="endNumber">The end number.</param>
        /// <returns></returns>
        public int RandomlyGenerateARedNumberBetween(int startNumber, int endNumber)
        {
            int output1;

            Random random = new();

            output1 = random.Next(startNumber, endNumber + 1);

            SetRedValue(output1);

            if (output1 == GetGreenValue() && output1 == GetBlueValue())
            {
                RandomlyGenerateARedNumberBetween(startNumber, endNumber);
            }

            return output1;
        }

        public int RandomlyGenerateAGreenNumberBetween(int startNumber, int endNumber)
        {
            int output2;

            Random random = new();

            output2 = random.Next(startNumber, endNumber + 1);

            SetGreenValue(output2);

            if (output2 == GetBlueValue() && output2 == GetRedValue())
            {
                RandomlyGenerateAGreenNumberBetween(startNumber, endNumber);
            }

            return output2;
        }

        public int RandomlyGenerateABlueNumberBetween(int startNumber, int endNumber)
        {
            int output3;

            Random random = new();

            output3 = random.Next(startNumber, endNumber + 1);

            SetBlueValue(output3);

            if (output3 == GetGreenValue() && output3 == GetRedValue())
            {
                RandomlyGenerateABlueNumberBetween(startNumber, endNumber);
            }

            return output3;
        }

        public int RandomlyGenerateAHueNumberBetween(int startNumber, int endNumber)
        {
            int hueOutputValue;

            Random random = new();

            hueOutputValue = random.Next(startNumber, endNumber + 1);

            SetHueValue(hueOutputValue);

            return hueOutputValue;
        }

        /// <summary>
        /// Generates the random colour.
        /// </summary>
        /// <param name="generateAlphaValue">if set to <c>true</c> [generate alpha value].</param>
        public void GenerateRandomColour(bool generateAlphaValue = false)
        {
            int a, r, g, b;

            if (generateAlphaValue)
            {
                a = _randomColourGenerator.Next(MAXMUM_COLOUR_VALUE);

                SetAlphaValue(a);
            }
            else
            {
                SetAlphaValue(MAXMUM_COLOUR_VALUE);
            }

            r = _randomColourGenerator.Next(MAXMUM_COLOUR_VALUE);

            SetRedValue(r);

            g = _randomColourGenerator.Next(MAXMUM_COLOUR_VALUE);

            SetGreenValue(g);

            b = _randomColourGenerator.Next(MAXMUM_COLOUR_VALUE);

            SetBlueValue(b);
        }
        #endregion

        #region Setters & Getters
        /// <summary>
        /// Sets the AlpheValue to value of value.
        /// </summary>
        /// <param name="value">The value of the AlpheValue.</param>
        public void SetAlphaValue(int value)
        {
            AlphaValue = value;
        }

        /// <summary>
        /// Gets the AlpheValue current value.
        /// </summary>
        /// <returns>The AlpheValue current value.</returns>
        public int GetAlphaValue()
        {
            return AlphaValue;
        }

        /// <summary>
        /// Sets the RedValue to value of value.
        /// </summary>
        /// <param name="value">The value of the RedValue.</param>
        public void SetRedValue(int value)
        {
            RedValue = value;
        }

        /// <summary>
        /// Gets the RedValue current value.
        /// </summary>
        /// <returns>The RedValue current value.</returns>
        public int GetRedValue()
        {
            return RedValue;
        }

        /// <summary>
        /// Sets the GreenValue to value of value.
        /// </summary>
        /// <param name="value">The value of the GreenValue.</param>
        public void SetGreenValue(int value)
        {
            GreenValue = value;
        }

        /// <summary>
        /// Gets the GreenValue current value.
        /// </summary>
        /// <returns>The GreenValue current value.</returns>
        public int GetGreenValue()
        {
            return GreenValue;
        }

        /// <summary>
        /// Sets the BlueValue to value of value.
        /// </summary>
        /// <param name="value">The value of the BlueValue.</param>
        public void SetBlueValue(int value) => BlueValue = value;

        /// <summary>
        /// Gets the BlueValue current value.
        /// </summary>
        /// <returns>The BlueValue current value.</returns>
        public int GetBlueValue() => BlueValue;

        /// <summary>
        /// Sets the hue value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void SetHueValue(int value) => HueValue = value;

        /// <summary>
        /// Gets the hue value.
        /// </summary>
        /// <returns></returns>
        public int GetHueValue() => HueValue;
        #endregion
    }
}