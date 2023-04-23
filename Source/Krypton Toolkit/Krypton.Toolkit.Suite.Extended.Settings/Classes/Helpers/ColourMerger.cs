#region MIT License
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

namespace Krypton.Toolkit.Suite.Extended.Settings
{
    public class ColourMerger
    {
        #region Variables
        AllMergedColourSettingsManager _amcsm = new();

        Color _baseColour, _darkColour, _middleColour, _lightColour, _lightestColour, _borderColour, _alternativeNormalTextColour, _normalTextColour, _disabledTextColour, _focusedTextColour, _pressedTextColour, _disabledControlColour, _linkNormalColour, _linkFocusedColour, _linkHoverColour, _linkVisitedColour, _customColourOne, _customColourTwo, _customColourThree, _customColourFour, _customColourFive, _customColourSix, _customTextColourOne, _customTextColourTwo, _customTextColourThree, _customTextColourFour, _customTextColourFive, _customTextColourSix, _menuTextColour, _statusTextColour, _ribbonTabTextColour;
        #endregion

        #region Properties

        #endregion

        #region Constructor

        public ColourMerger()
        {
            _baseColour = Color.Empty;

            _darkColour = Color.Empty;

            _middleColour = Color.Empty;

            _lightColour = Color.Empty;

            _lightestColour = Color.Empty;

            _borderColour = Color.Empty;

            _alternativeNormalTextColour = Color.Empty;

            _normalTextColour = Color.Empty;

            _disabledTextColour = Color.Empty;

            _focusedTextColour = Color.Empty;

            _pressedTextColour = Color.Empty;

            _disabledControlColour = Color.Empty;

            _linkNormalColour = Color.Empty;

            _linkFocusedColour = Color.Empty;

            _linkHoverColour = Color.Empty;

            _linkVisitedColour = Color.Empty;

            _customColourOne = Color.Empty;

            _customColourTwo = Color.Empty;

            _customColourThree = Color.Empty;

            _customColourFour = Color.Empty;

            _customColourFive = Color.Empty;

            _customColourSix = Color.Empty;

            _customTextColourOne = Color.Empty;

            _customTextColourTwo = Color.Empty;

            _customTextColourThree = Color.Empty;

            _customTextColourFour = Color.Empty;

            _customTextColourFive = Color.Empty;

            _customTextColourSix = Color.Empty;

            _menuTextColour = Color.Empty;

            _statusTextColour = Color.Empty;

            _ribbonTabTextColour = Color.Empty;
        }
        #endregion

        #region Public Methods
        public static void MergeColours(bool usePrompt = false)
        {
            if (usePrompt)
            {

            }
            else
            {

            }
        }
        #endregion

        #region Internal Methods                
        /// <summary>
        /// Merges all palette colours.
        /// </summary>
        /// <param name="baseColour">The base colour.</param>
        /// <param name="darkColour">The dark colour.</param>
        /// <param name="middleColour">The middle colour.</param>
        /// <param name="lightColour">The light colour.</param>
        /// <param name="lightestColour">The lightest colour.</param>
        /// <param name="borderColour">The border colour.</param>
        /// <param name="alternativeNormalTextColour">The alternative normal text colour.</param>
        /// <param name="normalTextColour">The normal text colour.</param>
        /// <param name="disabledTextColour">The disabled text colour.</param>
        /// <param name="focusedTextColour">The focused text colour.</param>
        /// <param name="pressedTextColour">The pressed text colour.</param>
        /// <param name="disabledControlColour">The disabled control colour.</param>
        /// <param name="linkNormalColour">The link normal colour.</param>
        /// <param name="linkFocusedColour">The link focused colour.</param>
        /// <param name="linkHoverColour">The link hover colour.</param>
        /// <param name="linkVisitedColour">The link visited colour.</param>
        /// <param name="customColourOne">The custom colour one.</param>
        /// <param name="customColourTwo">The custom colour two.</param>
        /// <param name="customColourThree">The custom colour three.</param>
        /// <param name="customColourFour">The custom colour four.</param>
        /// <param name="customColourFive">The custom colour five.</param>
        /// <param name="customColourSix">The custom colour six.</param>
        /// <param name="customTextColourOne">The custom text colour one.</param>
        /// <param name="customTextColourTwo">The custom text colour two.</param>
        /// <param name="customTextColourThree">The custom text colour three.</param>
        /// <param name="customTextColourFour">The custom text colour four.</param>
        /// <param name="customTextColourFive">The custom text colour five.</param>
        /// <param name="customTextColourSix">The custom text colour six.</param>
        /// <param name="menuTextColour">The menu text colour.</param>
        /// <param name="statusTextColour">The status text colour.</param>
        /// <param name="ribbonTabTextColour">The ribbon tab text colour.</param>
        /// <param name="askForConfirmation">if set to <c>true</c> [ask for confirmation].</param>
        internal static void MergeAllPaletteColours(Color baseColour, Color darkColour, Color middleColour, Color lightColour, Color lightestColour, Color borderColour, Color alternativeNormalTextColour, Color normalTextColour, Color disabledTextColour, Color focusedTextColour, Color pressedTextColour, Color disabledControlColour, Color linkNormalColour, Color linkFocusedColour, Color linkHoverColour, Color linkVisitedColour, Color customColourOne, Color customColourTwo, Color customColourThree, Color customColourFour, Color customColourFive, Color customColourSix, Color customTextColourOne, Color customTextColourTwo, Color customTextColourThree, Color customTextColourFour, Color customTextColourFive, Color customTextColourSix, Color menuTextColour, Color statusTextColour, Color ribbonTabTextColour, bool askForConfirmation = false)
        {
            try
            {
                AllMergedColourSettingsManager manager = new();

                if (SettingsVarifier.AreAllMergedColourSettingsDefault())
                {
                    MergeAllPaletteColoursIntoOneSettingsFile(baseColour, darkColour, middleColour, lightColour, lightestColour, borderColour, alternativeNormalTextColour, normalTextColour, disabledTextColour, focusedTextColour, pressedTextColour, disabledControlColour, linkNormalColour, linkFocusedColour, linkHoverColour, linkVisitedColour, customColourOne, customColourTwo, customColourThree, customColourFour, customColourFive, customColourSix, customTextColourOne, customTextColourTwo, customTextColourThree, customTextColourFour, customTextColourFive, customTextColourSix, menuTextColour, statusTextColour, ribbonTabTextColour);
                }
                else
                {
                    manager.ResetToDefaults();

                    MergeAllPaletteColoursIntoOneSettingsFile(baseColour, darkColour, middleColour, lightColour, lightestColour, borderColour, alternativeNormalTextColour, normalTextColour, disabledTextColour, focusedTextColour, pressedTextColour, disabledControlColour, linkNormalColour, linkFocusedColour, linkHoverColour, linkVisitedColour, customColourOne, customColourTwo, customColourThree, customColourFour, customColourFive, customColourSix, customTextColourOne, customTextColourTwo, customTextColourThree, customTextColourFour, customTextColourFive, customTextColourSix, menuTextColour, statusTextColour, ribbonTabTextColour);
                }
            }
            catch (Exception exc)
            {
                KryptonMessageBox.Show($"An exeption was thrown: {exc.Message}");
            }
        }

        /// <summary>
        /// Merges all palette colours into one settings file.
        /// </summary>
        /// <param name="baseColour">The base colour.</param>
        /// <param name="darkColour">The dark colour.</param>
        /// <param name="middleColour">The middle colour.</param>
        /// <param name="lightColour">The light colour.</param>
        /// <param name="lightestColour">The lightest colour.</param>
        /// <param name="borderColour">The border colour.</param>
        /// <param name="alternativeNormalTextColour">The alternative normal text colour.</param>
        /// <param name="normalTextColour">The normal text colour.</param>
        /// <param name="disabledTextColour">The disabled text colour.</param>
        /// <param name="focusedTextColour">The focused text colour.</param>
        /// <param name="pressedTextColour">The pressed text colour.</param>
        /// <param name="disabledControlColour">The disabled control colour.</param>
        /// <param name="linkNormalColour">The link normal colour.</param>
        /// <param name="linkFocusedColour">The link focused colour.</param>
        /// <param name="linkHoverColour">The link hover colour.</param>
        /// <param name="linkVisitedColour">The link visited colour.</param>
        /// <param name="customColourOne">The custom colour one.</param>
        /// <param name="customColourTwo">The custom colour two.</param>
        /// <param name="customColourThree">The custom colour three.</param>
        /// <param name="customColourFour">The custom colour four.</param>
        /// <param name="customColourFive">The custom colour five.</param>
        /// <param name="customColourSix">The custom colour six.</param>
        /// <param name="customTextColourOne">The custom text colour one.</param>
        /// <param name="customTextColourTwo">The custom text colour two.</param>
        /// <param name="customTextColourThree">The custom text colour three.</param>
        /// <param name="customTextColourFour">The custom text colour four.</param>
        /// <param name="customTextColourFive">The custom text colour five.</param>
        /// <param name="customTextColourSix">The custom text colour six.</param>
        /// <param name="menuTextColour">The menu text colour.</param>
        /// <param name="statusTextColour">The status text colour.</param>
        /// <param name="ribbonTabTextColour">The ribbon tab text colour.</param>
        private static void MergeAllPaletteColoursIntoOneSettingsFile(Color baseColour, Color darkColour, Color middleColour, Color lightColour, Color lightestColour, Color borderColour, Color alternativeNormalTextColour, Color normalTextColour, Color disabledTextColour, Color focusedTextColour, Color pressedTextColour, Color disabledControlColour, Color linkNormalColour, Color linkFocusedColour, Color linkHoverColour, Color linkVisitedColour, Color customColourOne, Color customColourTwo, Color customColourThree, Color customColourFour, Color customColourFive, Color customColourSix, Color customTextColourOne, Color customTextColourTwo, Color customTextColourThree, Color customTextColourFour, Color customTextColourFive, Color customTextColourSix, Color menuTextColour, Color statusTextColour, Color ribbonTabTextColour)
        {
            AllMergedColourSettingsManager manager = new();

            manager.SetBaseColour(baseColour);

            manager.SetDarkColour(darkColour);

            manager.SetMediumColour(middleColour);

            manager.SetLightColour(lightColour);

            manager.SetLightestColour(lightestColour);

            manager.SetBorderColour(borderColour);

            manager.SetAlternativeNormalTextColour(alternativeNormalTextColour);

            manager.SetNormalTextColour(normalTextColour);

            manager.SetDisabledTextColour(disabledTextColour);

            manager.SetFocusedTextColour(focusedTextColour);

            manager.SetPressedTextColour(pressedTextColour);

            manager.SetDisabledControlColour(disabledControlColour);

            manager.SetLinkNormalColour(linkNormalColour);

            manager.SetLinkFocusedColour(linkFocusedColour);

            manager.SetLinkHoverColour(linkHoverColour);

            manager.SetLinkVisitedColour(linkVisitedColour);

            manager.SetCustomColourOne(customColourOne);

            manager.SetCustomColourTwo(customColourTwo);

            manager.SetCustomColourThree(customColourThree);

            manager.SetCustomColourFour(customColourFour);

            manager.SetCustomColourFive(customColourFive);

            manager.SetCustomColourSix(customColourSix);

            manager.SetCustomTextColourOne(customTextColourOne);

            manager.SetCustomTextColourTwo(customTextColourTwo);

            manager.SetCustomTextColourThree(customTextColourThree);

            manager.SetCustomTextColourFour(customTextColourFour);

            manager.SetCustomTextColourFive(customTextColourFive);

            manager.SetCustomTextColourSix(customTextColourSix);

            manager.SetMenuTextColour(menuTextColour);

            manager.SetStatusStripTextColour(statusTextColour);

            manager.SetRibbonTabTextColour(ribbonTabTextColour);

            manager.SaveAllMergedColourSettings(manager.GetAlwaysUsePrompt());
        }
        #endregion
    }
}