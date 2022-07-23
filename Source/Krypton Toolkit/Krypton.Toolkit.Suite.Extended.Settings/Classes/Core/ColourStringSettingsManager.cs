#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Settings
{
    public class ColourStringSettingsManager
    {
        #region Variables
        private ColourStringSettings _colourStringSettings = new ColourStringSettings();
        #endregion

        #region Constructors
        public ColourStringSettingsManager()
        {

        }
        #endregion

        #region Setters and Getters
        /// <summary>
        /// Sets the BaseColour to the value of baseColour.
        /// </summary>
        /// <param name="baseColour">The value of baseColour.</param>
        public void SetBaseColour(string baseColour)
        {
            _colourStringSettings.BaseColour = baseColour;
        }

        /// <summary>
        /// Gets the BaseColour value.
        /// </summary>
        /// <returns>The value of baseColour.</returns>
        public string GetBaseColour()
        {
            return _colourStringSettings.BaseColour;
        }

        /// <summary>
        /// Sets the DarkestColour to the value of darkestColour.
        /// </summary>
        /// <param name="darkestColour">The value of darkestColour.</param>
        public void SetDarkestColour(string darkestColour)
        {
            _colourStringSettings.DarkColour = darkestColour;
        }

        /// <summary>
        /// Gets the DarkestColour value.
        /// </summary>
        /// <returns>The value of darkestColour.</returns>
        public string GetDarkestColour()
        {
            return _colourStringSettings.DarkColour;
        }

        /// <summary>
        /// Sets the MediumColour to the value of mediumColour.
        /// </summary>
        /// <param name="mediumColour">The value of mediumColour.</param>
        public void SetMediumColour(string mediumColour)
        {
            _colourStringSettings.MediumColour = mediumColour;
        }

        /// <summary>
        /// Gets the MediumColour value.
        /// </summary>
        /// <returns>The value of mediumColour.</returns>
        public string GetMediumColour()
        {
            return _colourStringSettings.MediumColour;
        }

        /// <summary>
        /// Sets the LightColour to the value of lightColour.
        /// </summary>
        /// <param name="lightColour">The value of lightColour.</param>
        public void SetLightColour(string lightColour)
        {
            _colourStringSettings.LightColour = lightColour;
        }

        /// <summary>
        /// Gets the LightColour value.
        /// </summary>
        /// <returns>The value of lightColour.</returns>
        public string GetLightColour()
        {
            return _colourStringSettings.LightColour;
        }

        /// <summary>
        /// Sets the LightestColour to the value of lightestColour.
        /// </summary>
        /// <param name="lightestColour">The value of lightestColour.</param>
        public void SetLightestColour(string lightestColour)
        {
            _colourStringSettings.LightestColour = lightestColour;
        }

        /// <summary>
        /// Gets the LightestColour value.
        /// </summary>
        /// <returns>The value of lightestColour.</returns>
        public string GetLightestColour()
        {
            return _colourStringSettings.LightestColour;
        }

        /// <summary>
        /// Sets the BorderColour to the value of borderColour.
        /// </summary>
        /// <param name="borderColour">The value of borderColour.</param>
        public void SetBorderColour(string borderColour)
        {
            _colourStringSettings.BorderColour = borderColour;
        }

        /// <summary>
        /// Gets the BorderColour value.
        /// </summary>
        /// <returns>The value of borderColour.</returns>
        public string GetBorderColour()
        {
            return _colourStringSettings.BorderColour;
        }

        /// <summary>
        /// Sets the NormalTextColour to the value of normalTextColour.
        /// </summary>
        /// <param name="normalTextColour">The value of normalTextColour.</param>
        public void SetNormalTextColour(string normalTextColour)
        {
            _colourStringSettings.NormalTextColour = normalTextColour;
        }

        /// <summary>
        /// Gets the NormalTextColour value.
        /// </summary>
        /// <returns>The value of normalTextColour.</returns>
        public string GetNormalTextColour()
        {
            return _colourStringSettings.NormalTextColour;
        }

        /// <summary>
        /// Sets the FocusedTextColour to the value of focusedTextColour.
        /// </summary>
        /// <param name="focusedTextColour">The value of focusedTextColour.</param>
        public void SetFocusedTextColour(string focusedTextColour)
        {
            _colourStringSettings.FocusedTextColour = focusedTextColour;
        }

        /// <summary>
        /// Gets the FocusedTextColour value.
        /// </summary>
        /// <returns>The value of focusedTextColour.</returns>
        public string GetFocusedTextColour()
        {
            return _colourStringSettings.FocusedTextColour;
        }

        /// <summary>
        /// Sets the AlternativeNormalTextColour to the value of alternativeNormalTextColour.
        /// </summary>
        /// <param name="alternativeNormalTextColour">The value of alternativeNormalTextColour.</param>
        public void SetAlternativeNormalTextColour(string alternativeNormalTextColour)
        {
            _colourStringSettings.AlternativeNormalTextColour = alternativeNormalTextColour;
        }

        /// <summary>
        /// Gets the AlternativeNormalTextColour value.
        /// </summary>
        /// <returns>The value of alternativeNormalTextColour.</returns>
        public string GetAlternativeNormalTextColour()
        {
            return _colourStringSettings.AlternativeNormalTextColour;
        }

        /// <summary>
        /// Sets the DisabledTextColour to the value of disabledTextColur.
        /// </summary>
        /// <param name="disabledTextColur">The value of disabledTextColur.</param>
        public void SetDisabledTextColour(string disabledTextColur)
        {
            _colourStringSettings.DisabledTextColour = disabledTextColur;
        }

        /// <summary>
        /// Gets the DisabledTextColour value.
        /// </summary>
        /// <returns>The value of disabledTextColur.</returns>
        public string GetDisabledTextColour()
        {
            return _colourStringSettings.DisabledTextColour;
        }

        /// <summary>
        /// Sets the DisabledColour to the value of disabledColour.
        /// </summary>
        /// <param name="disabledColour">The value of disabledColour.</param>
        public void SetDisabledColour(string disabledColour)
        {
            _colourStringSettings.DisabledControlColour = disabledColour;
        }

        /// <summary>
        /// Gets the DisabledColour value.
        /// </summary>
        /// <returns>The value of disabledColour.</returns>
        public string GetDisabledColour()
        {
            return _colourStringSettings.DisabledControlColour;
        }

        /// <summary>
        /// Sets the LinkNormalColour to the value of linkNormalColour.
        /// </summary>
        /// <param name="linkNormalColour">The value of linkNormalColour.</param>
        public void SetLinkNormalColour(string linkNormalColour)
        {
            _colourStringSettings.LinkNormalColour = linkNormalColour;
        }

        /// <summary>
        /// Gets the LinkNormalColour value.
        /// </summary>
        /// <returns>The value of linkNormalColour.</returns>
        public string GetLinkNormalColour()
        {
            return _colourStringSettings.LinkNormalColour;
        }

        /// <summary>
        /// Sets the LinkFocusedColour to the value of linkFocusedColour.
        /// </summary>
        /// <param name="linkFocusedColour">The value of linkFocusedColour.</param>
        public void SetLinkFocusedColour(string linkFocusedColour)
        {
            _colourStringSettings.LinkFocusedColour = linkFocusedColour;
        }

        /// <summary>
        /// Gets the LinkFocusedColour value.
        /// </summary>
        /// <returns>The value of linkFocusedColour.</returns>
        public string GetLinkFocusedColour()
        {
            return _colourStringSettings.LinkFocusedColour;
        }

        /*
        /// <summary>
        /// Sets the FocusTextColour to the value of focusTextColour.
        /// </summary>
        /// <param name="focusTextColour">The value of focusTextColour.</param>
        public void SetFocusTextColour(string focusTextColour)
        {
            _colourStringSettings.FocusTextColour = focusTextColour;
        }

        /// <summary>
        /// Gets the FocusTextColour value.
        /// </summary>
        /// <returns>The value of focusTextColour.</returns>
        public string GetFocusTextColour()
        {
            return _colourStringSettings.FocusTextColour;
        }
        */

        /// <summary>
        /// Sets the PressedTextColour to the value of pressedTextColour.
        /// </summary>
        /// <param name="pressedTextColour">The value of pressedTextColour.</param>
        public void SetPressedTextColour(string pressedTextColour)
        {
            _colourStringSettings.PressedTextColour = pressedTextColour;
        }

        /// <summary>
        /// Gets the PressedTextColour value.
        /// </summary>
        /// <returns>The value of pressedTextColour.</returns>
        public string GetPressedTextColour()
        {
            return _colourStringSettings.PressedTextColour;
        }

        /// <summary>
        /// Sets the LinkHoverColour to the value of linkHoverColour.
        /// </summary>
        /// <param name="linkHoverColour">The value of linkHoverColour.</param>
        public void SetLinkHoverColour(string linkHoverColour)
        {
            _colourStringSettings.LinkHoverColour = linkHoverColour;
        }

        /// <summary>
        /// Gets the LinkHoverColour value.
        /// </summary>
        /// <returns>The value of linkHoverColour.</returns>
        public string GetLinkHoverColour()
        {
            return _colourStringSettings.LinkHoverColour;
        }

        /// <summary>
        /// Sets the LinkVisitedColour to the value of linkVisitedColour.
        /// </summary>
        /// <param name="linkVisitedColour">The value of linkVisitedColour.</param>
        public void SetLinkVisitedColour(string linkVisitedColour)
        {
            _colourStringSettings.LinkVisitedColour = linkVisitedColour;
        }

        /// <summary>
        /// Gets the LinkVisitedColour value.
        /// </summary>
        /// <returns>The value of linkVisitedColour.</returns>
        public string GetLinkVisitedColour()
        {
            return _colourStringSettings.LinkVisitedColour;
        }

        /// <summary>
        /// Sets the LinkDisabledColour to the value of linkDisabledColour.
        /// </summary>
        /// <param name="linkDisabledColour">The value of linkDisabledColour.</param>
        public void SetLinkDisabledColour(string linkDisabledColour)
        {
            _colourStringSettings.LinkDisabledColour = linkDisabledColour;
        }

        /// <summary>
        /// Gets the LinkDisabledColour value.
        /// </summary>
        /// <returns>The value of linkDisabledColour.</returns>
        public string GetLinkDisabledColour()
        {
            return _colourStringSettings.LinkDisabledColour;
        }

        /// <summary>
        /// Sets the CustomColourOne to the value of customColourOne.
        /// </summary>
        /// <param name="customColourOne">The value of customColourOne.</param>
        public void SetCustomColourOne(string customColourOne)
        {
            _colourStringSettings.CustomColourOne = customColourOne;
        }

        /// <summary>
        /// Gets the CustomColourOne value.
        /// </summary>
        /// <returns>The value of customColourOne.</returns>
        public string GetCustomColourOne()
        {
            return _colourStringSettings.CustomColourOne;
        }

        /// <summary>
        /// Sets the CustomColourTwo to the value of customColourTwo.
        /// </summary>
        /// <param name="customColourTwo">The value of customColourTwo.</param>
        public void SetCustomColourTwo(string customColourTwo)
        {
            _colourStringSettings.CustomColourTwo = customColourTwo;
        }

        /// <summary>
        /// Gets the CustomColourTwo value.
        /// </summary>
        /// <returns>The value of customColourTwo.</returns>
        public string GetCustomColourTwo()
        {
            return _colourStringSettings.CustomColourTwo;
        }

        /// <summary>
        /// Sets the CustomColourThree to the value of customColourThree.
        /// </summary>
        /// <param name="customColourThree">The value of customColourThree.</param>
        public void SetCustomColourThree(string customColourThree)
        {
            _colourStringSettings.CustomColourThree = customColourThree;
        }

        /// <summary>
        /// Gets the CustomColourThree value.
        /// </summary>
        /// <returns>The value of customColourThree.</returns>
        public string GetCustomColourThree()
        {
            return _colourStringSettings.CustomColourThree;
        }

        /// <summary>
        /// Sets the CustomColourFour to the value of customColourFour.
        /// </summary>
        /// <param name="customColourFour">The value of customColourFour.</param>
        public void SetCustomColourFour(string customColourFour)
        {
            _colourStringSettings.CustomColourFour = customColourFour;
        }

        /// <summary>
        /// Gets the CustomColourFour value.
        /// </summary>
        /// <returns>The value of customColourFour.</returns>
        public string GetCustomColourFour()
        {
            return _colourStringSettings.CustomColourFour;
        }

        /// <summary>
        /// Sets the CustomColourFive to the value of customColourFive.
        /// </summary>
        /// <param name="customColourFive">The value of customColourFive.</param>
        public void SetCustomColourFive(string customColourFive)
        {
            _colourStringSettings.CustomColourFive = customColourFive;
        }

        /// <summary>
        /// Gets the CustomColourFive value.
        /// </summary>
        /// <returns>The value of customColourFive.</returns>
        public string GetCustomColourFive()
        {
            return _colourStringSettings.CustomColourFive;
        }

        /// <summary>
        /// Sets the value of CustomColourSix to customColourSix.
        /// </summary>
        /// <param name="customColourSix">The value of CustomColourSix.</param>
        public void SetCustomColourSix(string customColourSix)
        {
            _colourStringSettings.CustomColourSix = customColourSix;
        }

        /// <summary>
        /// Returns the value of CustomColourSix.
        /// </summary>
        /// <returns>The value of CustomColourSix.</returns>
        public string GetCustomColourSix()
        {
            return _colourStringSettings.CustomColourSix;
        }

        /// <summary>
        /// Sets the MenuTextColour to the value of menuTextColour.
        /// </summary>
        /// <param name="menuTextColour">The value of menuTextColour.</param>
        public void SetMenuTextColour(string menuTextColour)
        {
            _colourStringSettings.MenuTextColour = menuTextColour;
        }

        /// <summary>
        /// Gets the MenuTextColour value.
        /// </summary>
        /// <returns>The value of menuTextColour.</returns>
        public string GetMenuTextColour()
        {
            return _colourStringSettings.MenuTextColour;
        }

        /// <summary>
        /// Sets the CustomTextColourOne to the value of customTextColourOne.
        /// </summary>
        /// <param name="customTextColourOne">The value of customTextColourOne.</param>
        public void SetCustomTextColourOne(string customTextColourOne)
        {
            _colourStringSettings.CustomTextColourOne = customTextColourOne;
        }

        /// <summary>
        /// Gets the CustomTextColourOne value.
        /// </summary>
        /// <returns>The value of customTextColourOne.</returns>
        public string GetCustomTextColourOne()
        {
            return _colourStringSettings.CustomTextColourOne;
        }

        /// <summary>
        /// Sets the CustomTextColourTwo to the value of customTextColourTwo.
        /// </summary>
        /// <param name="customTextColourTwo">The value of customTextColourTwo.</param>
        public void SetCustomTextColourTwo(string customTextColourTwo)
        {
            _colourStringSettings.CustomTextColourTwo = customTextColourTwo;
        }

        /// <summary>
        /// Gets the CustomTextColourTwo value.
        /// </summary>
        /// <returns>The value of customTextColourTwo.</returns>
        public string GetCustomTextColourTwo()
        {
            return _colourStringSettings.CustomTextColourTwo;
        }

        /// <summary>
        /// Sets the CustomTextColourThree to the value of customTextColourThree.
        /// </summary>
        /// <param name="customTextColourThree">The value of customTextColourThree.</param>
        public void SetCustomTextColourThree(string customTextColourThree)
        {
            _colourStringSettings.CustomTextColourThree = customTextColourThree;
        }

        /// <summary>
        /// Gets the CustomTextColourThree value.
        /// </summary>
        /// <returns>The value of customTextColourThree.</returns>
        public string GetCustomTextColourThree()
        {
            return _colourStringSettings.CustomTextColourThree;
        }

        /// <summary>
        /// Sets the CustomTextColourFour to the value of customTextColourFour.
        /// </summary>
        /// <param name="customTextColourFour">The value of customTextColourFour.</param>
        public void SetCustomTextColourFour(string customTextColourFour)
        {
            _colourStringSettings.CustomTextColourFour = customTextColourFour;
        }

        /// <summary>
        /// Gets the CustomTextColourFour value.
        /// </summary>
        /// <returns>The value of customTextColourFour.</returns>
        public string GetCustomTextColourFour()
        {
            return _colourStringSettings.CustomTextColourFour;
        }

        /// <summary>
        /// Sets the CustomTextColourFive to the value of customTextColourFive.
        /// </summary>
        /// <param name="customTextColourFive">The value of customTextColourFive.</param>
        public void SetCustomTextColourFive(string customTextColourFive)
        {
            _colourStringSettings.CustomTextColourFive = customTextColourFive;
        }

        /// <summary>
        /// Gets the CustomTextColourFive value.
        /// </summary>
        /// <returns>The value of customTextColourFive.</returns>
        public string GetCustomTextColourFive()
        {
            return _colourStringSettings.CustomTextColourFive;
        }

        /// <summary>
        /// Sets the value of CustomTextColourSix to customTextColourSix.
        /// </summary>
        /// <param name="customTextColourSix">The value of CustomTextColourSix.</param>
        public void SetCustomTextColourSix(string customTextColourSix)
        {
            _colourStringSettings.CustomTextColourSix = customTextColourSix;
        }

        /// <summary>
        /// Returns the value of CustomTextColourSix.
        /// </summary>
        /// <returns>The value of CustomTextColourSix.</returns>
        public string GetCustomTextColourSix()
        {
            return _colourStringSettings.CustomTextColourSix;
        }

        /// <summary>
        /// Sets the StatusTextColour to the value of statusTextColour.
        /// </summary>
        /// <param name="statusTextColour">The value of statusTextColour.</param>
        public void SetStatusTextColour(string statusTextColour)
        {
            _colourStringSettings.StatusStripTextColour = statusTextColour;
        }

        /// <summary>
        /// Gets the StatusTextColour value.
        /// </summary>
        /// <returns>The value of statusTextColour.</returns>
        public string GetStatusTextColour()
        {
            return _colourStringSettings.StatusStripTextColour;
        }
        #endregion

        #region Save Settings
        public void SaveColourStringSettings(bool usePrompt = false)
        {
            if (usePrompt)
            {
                DialogResult result = KryptonMessageBox.Show("Do you want to save the current colour string settings?", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                //KryptonMessageBoxExtendedResult result = ExtendedKryptonMessageBox.Show("Do you want to save the current colour settings?", "Save Confirmation", KryptonMessageBoxExtendedButtons.YESNO, KryptonMessageBoxExtendedIcon.QUESTION);

                if (result == DialogResult.Yes)
                {
                    _colourStringSettings.Save();
                }
                else
                {
                    ResetColourStringSettings(usePrompt);
                }
            }
            else
            {
                _colourStringSettings.Save();
            }
        }

        public void ResetColourStringSettings(bool usePrompt = false)
        {
            if (usePrompt)
            {
                DialogResult result = KryptonMessageBox.Show("This action will reset the colour string values. Do you want to continue?", "Reset Colour String Values", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    ResetColourStringSettings();

                    SaveColourStringSettings(usePrompt);
                }
                else
                {
                    ResetColourStringSettings();

                    SaveColourStringSettings();
                }
            }
        }

        private void ResetColourStringSettings()
        {
            SetBaseColour("");

            SetDarkestColour("");

            SetMediumColour("");

            SetLightColour("");

            SetLightestColour("");

            SetBorderColour("");

            SetAlternativeNormalTextColour("");

            SetNormalTextColour("");

            SetFocusedTextColour("");

            SetPressedTextColour("");

            SetDisabledTextColour("");

            SetDisabledColour("");

            SetLinkNormalColour("");

            SetLinkFocusedColour("");

            SetLinkHoverColour("");

            SetLinkVisitedColour("");

            SetCustomColourOne("");

            SetCustomColourTwo("");

            SetCustomColourThree("");

            SetCustomColourFour("");

            SetCustomColourFive("");

            SetCustomColourSix("");

            SetMenuTextColour("");

            SetCustomTextColourOne("");

            SetCustomTextColourTwo("");

            SetCustomTextColourThree("");

            SetCustomTextColourFour("");

            SetCustomTextColourFive("");

            SetCustomTextColourSix("");

            SetStatusTextColour("");
        }
        #endregion
    }
}