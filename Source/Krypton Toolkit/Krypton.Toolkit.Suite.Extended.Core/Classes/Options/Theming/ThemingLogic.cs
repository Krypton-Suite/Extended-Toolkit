﻿#region MIT License
/*
 *
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

namespace Krypton.Toolkit.Suite.Extended.Core
{
    public class ThemingLogic
    {
        #region Variables
        private IThemeOptions _themeOptions;
        private PaletteThemeSettingsManager _paletteThemeSettingsManager = new PaletteThemeSettingsManager();
        #endregion

        #region Constructors
        public ThemingLogic()
        {

        }
        #endregion

        #region Events
        public void PaletteMode_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Methods
        public void InitialisePaletteCollection(ArrayList paletteCollection)
        {
            paletteCollection = new ArrayList();

            paletteCollection.Add("Global");

            paletteCollection.Add("Professional System");

            paletteCollection.Add("Professional Office 2003");

            paletteCollection.Add("Office 2007 Blue");

            paletteCollection.Add("Office 2007 Silver");

            paletteCollection.Add("Office 2007 Black");

            paletteCollection.Add("Office 2010 Blue");

            paletteCollection.Add("Office 2010 Silver");

            paletteCollection.Add("Office 2010 Black");

            paletteCollection.Add("Office 2013");

            paletteCollection.Add("Office 2013 White");

            paletteCollection.Add("Sparkle Blue");

            paletteCollection.Add("Sparkle Orange");

            paletteCollection.Add("Sparkle Purple");

            paletteCollection.Add("Custom");
        }

        public void InitialisePaletteCollection(AutoCompleteStringCollection paletteCollection)
        {
            paletteCollection = new AutoCompleteStringCollection();

            paletteCollection.Add("Global");

            paletteCollection.Add("Professional System");

            paletteCollection.Add("Professional Office 2003");

            paletteCollection.Add("Office 2007 Blue");

            paletteCollection.Add("Office 2007 Silver");

            paletteCollection.Add("Office 2007 Black");

            paletteCollection.Add("Office 2010 Blue");

            paletteCollection.Add("Office 2010 Silver");

            paletteCollection.Add("Office 2010 Black");

            paletteCollection.Add("Office 2013");

            paletteCollection.Add("Office 2013 White");

            paletteCollection.Add("Sparkle Blue");

            paletteCollection.Add("Sparkle Orange");

            paletteCollection.Add("Sparkle Purple");

            paletteCollection.Add("Custom");
        }

        public void InitialisePaletteCollectionControl(ComboBox paletteCollectionControl, ArrayList paletteCollection, AutoCompleteStringCollection paletteStringCollection)
        {
            InitialisePaletteCollection(paletteCollection);

            InitialisePaletteCollection(paletteStringCollection);

            foreach (string item in paletteCollection)
            {
                paletteCollectionControl.Items.Add(item);
            }

            foreach (string item in paletteStringCollection)
            {
                paletteCollectionControl.AutoCompleteCustomSource.Add(item);
            }
        }

        public void InitialisePaletteCollectionControl(KryptonComboBox paletteCollectionControl, ArrayList paletteCollection, AutoCompleteStringCollection paletteStringCollection)
        {
            InitialisePaletteCollection(paletteCollection);

            InitialisePaletteCollection(paletteStringCollection);

            foreach (string item in paletteCollection)
            {
                paletteCollectionControl.Items.Add(item);
            }

            foreach (string item in paletteStringCollection)
            {
                paletteCollectionControl.AutoCompleteCustomSource.Add(item);
            }
        }

        public void ChangeTheme(PaletteMode paletteMode)
        {
            SetPaletteMode(paletteMode);

            switch (paletteMode)
            {
                case PaletteMode.Global:
                    _themeOptions.KryptonManager.GlobalPaletteMode = PaletteModeManager.Custom;
                    break;
                case PaletteMode.ProfessionalSystem:
                    _themeOptions.KryptonManager.GlobalPaletteMode = PaletteModeManager.ProfessionalSystem;
                    break;
                case PaletteMode.ProfessionalOffice2003:
                    _themeOptions.KryptonManager.GlobalPaletteMode = PaletteModeManager.ProfessionalOffice2003;
                    break;
                case PaletteMode.Office2007Blue:
                    _themeOptions.KryptonManager.GlobalPaletteMode = PaletteModeManager.Office2007Blue;
                    break;
                case PaletteMode.Office2007Silver:
                    _themeOptions.KryptonManager.GlobalPaletteMode = PaletteModeManager.Office2007Silver;
                    break;
                case PaletteMode.Office2007Black:
                    _themeOptions.KryptonManager.GlobalPaletteMode = PaletteModeManager.Office2007Black;
                    break;
                case PaletteMode.Office2010Blue:
                    _themeOptions.KryptonManager.GlobalPaletteMode = PaletteModeManager.Office2010Blue;
                    break;
                case PaletteMode.Office2010Silver:
                    _themeOptions.KryptonManager.GlobalPaletteMode = PaletteModeManager.Office2010Silver;
                    break;
                case PaletteMode.Office2010Black:
                    _themeOptions.KryptonManager.GlobalPaletteMode = PaletteModeManager.Office2010Black;
                    break;
                    break;
                case PaletteMode.Office2013White:
                    _themeOptions.KryptonManager.GlobalPaletteMode = PaletteModeManager.Office2013White;
                    break;
                case PaletteMode.SparkleBlue:
                    _themeOptions.KryptonManager.GlobalPaletteMode = PaletteModeManager.SparkleBlue;
                    break;
                case PaletteMode.SparkleOrange:
                    _themeOptions.KryptonManager.GlobalPaletteMode = PaletteModeManager.SparkleOrange;
                    break;
                case PaletteMode.SparklePurple:
                    _themeOptions.KryptonManager.GlobalPaletteMode = PaletteModeManager.SparklePurple;
                    break;
                case PaletteMode.Custom:
                    _themeOptions.KryptonManager.GlobalPaletteMode = PaletteModeManager.Custom;

                    _paletteThemeSettingsManager.SetCustomThemeFilePath(_themeOptions.PaletteFilePathControl.Text);
                    break;
                default:
                    break;
            }

            EnableApplyButton(true);

            EnableRestoreToDefaultsButton(true);
        }

        private void EnableRestoreToDefaultsButton(bool enabled)
        {
            _themeOptions.ResetToDefaultsControl.Enabled = enabled;
        }

        private void EnableApplyButton(bool enabled)
        {
            _themeOptions.ApplyControl.Enabled = enabled;
        }

        private void EnableCustomThemeControls(bool enabled)
        {
            _themeOptions.CustomPaletteLabel.Enabled = enabled;

            _themeOptions.PaletteFilePathControl.Enabled = enabled;

            _themeOptions.LoadPaletteFilePathControl.Enabled = enabled;
        }

        private string GetPaletteModeAsString(PaletteMode paletteMode)
        {
            string mode = "";

            switch (paletteMode)
            {
                case PaletteMode.Global:
                    mode = "Global";
                    break;
                case PaletteMode.ProfessionalSystem:
                    mode = "Professional System";
                    break;
                case PaletteMode.ProfessionalOffice2003:
                    mode = "Professional Office 2003";
                    break;
                case PaletteMode.Office2007Blue:
                    mode = "Office 2007 Blue";
                    break;
                case PaletteMode.Office2007Silver:
                    mode = "Office 2007 Silver";
                    break;
                case PaletteMode.Office2007Black:
                    mode = "Office 2007 Black";
                    break;
                case PaletteMode.Office2010Blue:
                    mode = "Office 2010 Blue";
                    break;
                case PaletteMode.Office2010Silver:
                    mode = "Office 2010 Silver";
                    break;
                case PaletteMode.Office2010Black:
                    mode = "Office 2010 Black";
                    break;
                case PaletteMode.Office2013White:
                    mode = "Office 2013 White";
                    break;
                case PaletteMode.SparkleBlue:
                    mode = "Sparkle Blue";
                    break;
                case PaletteMode.SparkleOrange:
                    mode = "Sparkle Orange";
                    break;
                case PaletteMode.SparklePurple:
                    mode = "Sparkle Purple";
                    break;
                case PaletteMode.Custom:
                    mode = "Custom";
                    break;
            }

            return mode;
        }
        #endregion

        #region Setters/Getters
        /// <summary>
        /// Sets the PaletteMode to the value of paletteMode.
        /// </summary>
        /// <param name="paletteMode">The value of paletteMode.</param>
        public void SetPaletteMode(PaletteMode paletteMode)
        {
            _themeOptions.PaletteMode = paletteMode;
        }

        /// <summary>
        /// Gets the PaletteMode value.
        /// </summary>
        /// <returns>The value of paletteMode.</returns>
        public PaletteMode GetPaletteMode()
        {
            return _themeOptions.PaletteMode;
        }
        #endregion
    }
}