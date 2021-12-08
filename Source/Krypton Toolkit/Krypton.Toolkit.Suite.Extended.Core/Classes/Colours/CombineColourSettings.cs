#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Core
{
    public class CombineColourSettings
    {
        #region Variables
        private Color _baseColour, _darkColour, _middleColour, _lightColour, _lightestColour, _borderColourPreview, _alternativeNormalTextColourPreview, _normalTextColourPreview, _disabledTextColourPreview, _focusedTextColourPreview, _pressedTextColourPreview, _disabledColourPreview, _linkNormalColourPreview, _linkHoverColourPreview, _linkVisitedColourPreview, _customColourOne, _customColourTwo, _customColourThree, _customColourFour, _customColourFive, _customTextColourOne, _customTextColourTwo, _customTextColourThree, _customTextColourFour, _customTextColourFive, _menuTextColour, _statusTextColour, _ribbonTabTextColour;

        private AllMergedColourSettingsManager _colourSettingsManager = new AllMergedColourSettingsManager();
        #endregion

        #region Properties
        public Color BaseColour { get { return _baseColour; } set { _baseColour = value; } }

        public Color DarkColour { get { return _darkColour; } set { _darkColour = value; } }

        public Color MiddleColour { get { return _middleColour; } set { _middleColour = value; } }

        public Color LightColour { get { return _lightColour; } set { _lightColour = value; } }

        public Color LightestColour { get { return _lightestColour; } set { _lightestColour = value; } }

        public Color BorderColourPreview { get { return _borderColourPreview; } set { _borderColourPreview = value; } }

        public Color AlternativeNormalTextColourPreview { get { return _alternativeNormalTextColourPreview; } set { _alternativeNormalTextColourPreview = value; } }

        public Color NormalTextColourPreview { get { return _normalTextColourPreview; } set { _normalTextColourPreview = value; } }

        public Color DisabledTextColourPreview { get { return _disabledTextColourPreview; } set { _disabledTextColourPreview = value; } }

        public Color FocusedTextColourPreview { get { return _focusedTextColourPreview; } set { _focusedTextColourPreview = value; } }

        public Color PressedTextColourPreview { get { return _pressedTextColourPreview; } set { _pressedTextColourPreview = value; } }

        public Color DisabledColourPreview { get { return _disabledColourPreview; } set { _disabledColourPreview = value; } }

        public Color LinkNormalColourPreview { get { return _linkNormalColourPreview; } set { _linkNormalColourPreview = value; } }

        public Color LinkHoverColourPreview { get { return _linkHoverColourPreview; } set { _linkHoverColourPreview = value; } }

        public Color LinkVisitedColourPreview { get { return _linkVisitedColourPreview; } set { _linkVisitedColourPreview = value; } }

        public Color CustomColourOne { get { return _customColourOne; } set { _customColourOne = value; } }

        public Color CustomColourTwo { get { return _customColourTwo; } set { _customColourTwo = value; } }

        public Color CustomColourThree { get { return _customColourThree; } set { _customColourThree = value; } }

        public Color CustomColourFour { get { return _customColourFour; } set { _customColourFour = value; } }

        public Color CustomColourFive { get { return _customColourFive; } set { _customColourFive = value; } }

        public Color CustomTextColourOne { get { return _customTextColourOne; } set { _customTextColourOne = value; } }

        public Color CustomTextColourTwo { get { return _customTextColourTwo; } set { _customTextColourTwo = value; } }

        public Color CustomTextColourThree { get { return _customTextColourThree; } set { _customTextColourThree = value; } }

        public Color CustomTextColourFour { get { return _customTextColourFour; } set { _customTextColourFour = value; } }

        public Color CustomTextColourFive { get { return _customTextColourFive; } set { _customTextColourFive = value; } }

        public Color MenuTextColour { get { return _menuTextColour; } set { _menuTextColour = value; } }

        public Color StatusTextColour { get { return _statusTextColour; } set { _statusTextColour = value; } }

        public Color RibbonTabTextColour { get { return _ribbonTabTextColour; } set { _ribbonTabTextColour = value; } }
        #endregion

        #region Constructors
        public CombineColourSettings()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CombineColourSettings"/> class.
        /// </summary>
        /// <param name="baseColour">The base colour.</param>
        /// <param name="darkColour">The dark colour.</param>
        /// <param name="middleColour">The middle colour.</param>
        /// <param name="lightColour">The light colour.</param>
        /// <param name="lightestColour">The lightest colour.</param>
        public CombineColourSettings(Color baseColour, Color darkColour, Color middleColour, Color lightColour, Color lightestColour)
        {
            BaseColour = baseColour;

            DarkColour = darkColour;

            MiddleColour = middleColour;

            LightColour = lightColour;

            LightestColour = lightestColour;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CombineColourSettings"/> class.
        /// </summary>
        /// <param name="baseColour">The base colour.</param>
        /// <param name="darkColour">The dark colour.</param>
        /// <param name="middleColour">The middle colour.</param>
        /// <param name="lightColour">The light colour.</param>
        /// <param name="lightestColour">The lightest colour.</param>
        /// <param name="borderColourPreview">The border colour preview.</param>
        /// <param name="alternativeNormalTextColourPreview">The alternative normal text colour preview.</param>
        /// <param name="normalTextColourPreview">The normal text colour preview.</param>
        /// <param name="disabledTextColourPreview">The disabled text colour preview.</param>
        /// <param name="focusedTextColourPreview">The focused text colour preview.</param>
        /// <param name="pressedTextColourPreview">The pressed text colour preview.</param>
        /// <param name="disabledColourPreview">The disabled colour preview.</param>
        /// <param name="linkNormalColourPreview">The link normal colour preview.</param>
        /// <param name="linkHoverColourPreview">The link hover colour preview.</param>
        /// <param name="linkVisitedColourPreview">The link visited colour preview.</param>
        /// <param name="customColourOne">The custom colour one.</param>
        /// <param name="customColourTwo">The custom colour two.</param>
        /// <param name="customColourThree">The custom colour three.</param>
        /// <param name="customColourFour">The custom colour four.</param>
        /// <param name="customColourFive">The custom colour five.</param>
        /// <param name="customTextColourOne">The custom text colour one.</param>
        /// <param name="customTextColourTwo">The custom text colour two.</param>
        /// <param name="customTextColourThree">The custom text colour three.</param>
        /// <param name="customTextColourFour">The custom text colour four.</param>
        /// <param name="customTextColourFive">The custom text colour five.</param>
        /// <param name="menuTextColour">The menu text colour.</param>
        /// <param name="statusTextColour">The status text colour.</param>
        public CombineColourSettings(Color baseColour, Color darkColour, Color middleColour, Color lightColour, Color lightestColour, Color borderColourPreview, Color alternativeNormalTextColourPreview, Color normalTextColourPreview, Color disabledTextColourPreview, Color focusedTextColourPreview, Color pressedTextColourPreview, Color disabledColourPreview, Color linkNormalColourPreview, Color linkHoverColourPreview, Color linkVisitedColourPreview, Color customColourOne, Color customColourTwo, Color customColourThree, Color customColourFour, Color customColourFive, Color customTextColourOne, Color customTextColourTwo, Color customTextColourThree, Color customTextColourFour, Color customTextColourFive, Color menuTextColour, Color statusTextColour, Color ribbonTabTextColour)
        {
            BaseColour = baseColour;

            DarkColour = darkColour;

            MiddleColour = middleColour;

            LightColour = lightColour;

            LightestColour = lightestColour;

            BorderColourPreview = borderColourPreview;

            AlternativeNormalTextColourPreview = alternativeNormalTextColourPreview;

            NormalTextColourPreview = normalTextColourPreview;

            DisabledTextColourPreview = disabledTextColourPreview;

            FocusedTextColourPreview = focusedTextColourPreview;

            PressedTextColourPreview = pressedTextColourPreview;

            DisabledColourPreview = disabledTextColourPreview;

            LinkNormalColourPreview = linkNormalColourPreview;

            LinkHoverColourPreview = linkHoverColourPreview;

            LinkVisitedColourPreview = linkVisitedColourPreview;

            CustomColourOne = customColourOne;

            CustomColourTwo = customColourTwo;

            CustomColourThree = customColourThree;

            CustomColourFour = customColourFour;

            CustomColourFive = customColourFive;

            CustomTextColourOne = customTextColourOne;

            CustomTextColourTwo = customTextColourTwo;

            CustomTextColourThree = customTextColourThree;

            CustomTextColourFour = customTextColourFour;

            CustomTextColourFive = customTextColourFive;

            MenuTextColour = menuTextColour;

            StatusTextColour = statusTextColour;

            RibbonTabTextColour = ribbonTabTextColour;
        }
        #endregion

        #region Methods
        public void SaveSettings(bool useConfirmDialog = false)
        {
            _colourSettingsManager.ResetToDefaults();

            _colourSettingsManager.SaveAllMergedColourSettings(useConfirmDialog);

            try
            {
                if (BaseColour != null || DarkColour != null || MiddleColour != null || LightColour != null || LightestColour != null || BorderColourPreview != null || AlternativeNormalTextColourPreview != null || NormalTextColourPreview != null || DisabledTextColourPreview != null || FocusedTextColourPreview != null || PressedTextColourPreview != null || DisabledColourPreview != null || LinkNormalColourPreview != null || LinkHoverColourPreview != null || LinkVisitedColourPreview != null || CustomColourOne != null || CustomColourTwo != null || CustomColourThree != null || CustomColourFour != null || CustomColourFive != null || CustomTextColourOne != null || CustomTextColourTwo != null || CustomTextColourThree != null || CustomTextColourFour != null || CustomTextColourFive != null || MenuTextColour != null || StatusTextColour != null || RibbonTabTextColour != null)
                {
                    _colourSettingsManager.SetBaseColour(BaseColour);

                    _colourSettingsManager.SetDarkColour(DarkColour);

                    _colourSettingsManager.SetMediumColour(MiddleColour);

                    _colourSettingsManager.SetLightColour(LightColour);

                    _colourSettingsManager.SetLightestColour(LightestColour);

                    _colourSettingsManager.SetBorderColour(BorderColourPreview);

                    _colourSettingsManager.SetAlternativeNormalTextColour(AlternativeNormalTextColourPreview);

                    _colourSettingsManager.SetNormalTextColour(NormalTextColourPreview);

                    _colourSettingsManager.SetDisabledTextColour(DisabledTextColourPreview);

                    _colourSettingsManager.SetFocusedTextColour(FocusedTextColourPreview);

                    _colourSettingsManager.SetPressedTextColour(PressedTextColourPreview);

                    _colourSettingsManager.SetDisabledControlColour(DisabledColourPreview);

                    _colourSettingsManager.SetLinkNormalColour(LinkNormalColourPreview);

                    _colourSettingsManager.SetLinkHoverColour(LinkHoverColourPreview);

                    _colourSettingsManager.SetLinkVisitedColour(LinkVisitedColourPreview);

                    _colourSettingsManager.SetCustomColourOne(CustomColourOne);

                    _colourSettingsManager.SetCustomColourTwo(CustomColourTwo);

                    _colourSettingsManager.SetCustomColourThree(CustomColourThree);

                    _colourSettingsManager.SetCustomColourFour(CustomColourFour);

                    _colourSettingsManager.SetCustomColourFive(CustomColourFive);

                    _colourSettingsManager.SetCustomTextColourOne(CustomTextColourOne);

                    _colourSettingsManager.SetCustomTextColourTwo(CustomTextColourTwo);

                    _colourSettingsManager.SetCustomTextColourThree(CustomTextColourThree);

                    _colourSettingsManager.SetCustomTextColourFour(CustomTextColourFour);

                    _colourSettingsManager.SetCustomTextColourFive(CustomTextColourFive);

                    _colourSettingsManager.SetMenuTextColour(MenuTextColour);

                    _colourSettingsManager.SetStatusStripTextColour(StatusTextColour);

                    _colourSettingsManager.SetRibbonTabTextColour(RibbonTabTextColour);

                    _colourSettingsManager.SaveAllMergedColourSettings(useConfirmDialog);
                }
                else
                {
                    DialogResult result = KryptonMessageBox.Show("One or more colours are not defined, use white & black?", "Non-Defined Colours", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
            }
            catch (Exception exc)
            {
                ExceptionHandler.CaptureException(exc, icon: MessageBoxIcon.Error, methodSignature: Helpers.GetCurrentMethod());
            }
        }

        public static void KeepColoursBasic(Color baseColour, Color darkColour, Color middleColour, Color lightColour, Color lightestColour, bool saveSettings = true)
        {
            #region Assign variables
            AllMergedColourSettingsManager colourSettingsManager = new AllMergedColourSettingsManager();
            #endregion

            if (saveSettings)
            {
                colourSettingsManager.SetBaseColour(baseColour);

                colourSettingsManager.SetDarkColour(darkColour);

                colourSettingsManager.SetMediumColour(middleColour);

                colourSettingsManager.SetLightColour(lightColour);

                colourSettingsManager.SetLightestColour(lightestColour);

                colourSettingsManager.SaveAllMergedColourSettings();
            }
            else
            {

            }
        }

        /// <summary>
        /// Keeps the colours extended.
        /// </summary>
        /// <param name="borderColourPreview">The border colour preview.</param>
        /// <param name="alternativeNormalTextColourPreview">The alternative normal text colour preview.</param>
        /// <param name="normalTextColourPreview">The normal text colour preview.</param>
        /// <param name="disabledTextColourPreview">The disabled text colour preview.</param>
        /// <param name="focusedTextColourPreview">The focused text colour preview.</param>
        /// <param name="pressedTextColourPreview">The pressed text colour preview.</param>
        /// <param name="disabledColourPreview">The disabled colour preview.</param>
        /// <param name="linkNormalColourPreview">The link normal colour preview.</param>
        /// <param name="linkHoverColourPreview">The link hover colour preview.</param>
        /// <param name="linkVisitedColourPreview">The link visited colour preview.</param>
        /// <param name="customColourOne">The custom colour one.</param>
        /// <param name="customColourTwo">The custom colour two.</param>
        /// <param name="customColourThree">The custom colour three.</param>
        /// <param name="customColourFour">The custom colour four.</param>
        /// <param name="customColourFive">The custom colour five.</param>
        /// <param name="customTextColourOne">The custom text colour one.</param>
        /// <param name="customTextColourTwo">The custom text colour two.</param>
        /// <param name="customTextColourThree">The custom text colour three.</param>
        /// <param name="customTextColourFour">The custom text colour four.</param>
        /// <param name="customTextColourFive">The custom text colour five.</param>
        /// <param name="menuTextColour">The menu text colour.</param>
        /// <param name="statusTextColour">The status text colour.</param>
        /// <param name="saveSettings">if set to <c>true</c> [save settings].</param>
        public static void KeepColoursExtended(Color borderColourPreview, Color alternativeNormalTextColourPreview, Color normalTextColourPreview, Color disabledTextColourPreview, Color focusedTextColourPreview, Color pressedTextColourPreview, Color disabledColourPreview, Color linkNormalColourPreview, Color linkHoverColourPreview, Color linkVisitedColourPreview, Color customColourOne, Color customColourTwo, Color customColourThree, Color customColourFour, Color customColourFive, Color customTextColourOne, Color customTextColourTwo, Color customTextColourThree, Color customTextColourFour, Color customTextColourFive, Color menuTextColour, Color statusTextColour, bool saveSettings = true)
        {

        }

        /// <summary>
        /// Combines the colour values.
        /// </summary>
        /// <param name="baseColour">The base colour.</param>
        /// <param name="darkColour">The dark colour.</param>
        /// <param name="middleColour">The middle colour.</param>
        /// <param name="lightColour">The light colour.</param>
        /// <param name="lightestColour">The lightest colour.</param>
        /// <param name="borderColourPreview">The border colour preview.</param>
        /// <param name="alternativeNormalTextColourPreview">The alternative normal text colour preview.</param>
        /// <param name="normalTextColourPreview">The normal text colour preview.</param>
        /// <param name="disabledTextColourPreview">The disabled text colour preview.</param>
        /// <param name="focusedTextColourPreview">The focused text colour preview.</param>
        /// <param name="pressedTextColourPreview">The pressed text colour preview.</param>
        /// <param name="disabledColourPreview">The disabled colour preview.</param>
        /// <param name="linkNormalColourPreview">The link normal colour preview.</param>
        /// <param name="linkHoverColourPreview">The link hover colour preview.</param>
        /// <param name="linkVisitedColourPreview">The link visited colour preview.</param>
        /// <param name="customColourOne">The custom colour one.</param>
        /// <param name="customColourTwo">The custom colour two.</param>
        /// <param name="customColourThree">The custom colour three.</param>
        /// <param name="customColourFour">The custom colour four.</param>
        /// <param name="customColourFive">The custom colour five.</param>
        /// <param name="customTextColourOne">The custom text colour one.</param>
        /// <param name="customTextColourTwo">The custom text colour two.</param>
        /// <param name="customTextColourThree">The custom text colour three.</param>
        /// <param name="customTextColourFour">The custom text colour four.</param>
        /// <param name="customTextColourFive">The custom text colour five.</param>
        /// <param name="menuTextColour">The menu text colour.</param>
        /// <param name="statusTextColour">The status text colour.</param>
        public static void CombineColourValues(Color baseColour, Color darkColour, Color middleColour, Color lightColour, Color lightestColour, Color borderColourPreview, Color alternativeNormalTextColourPreview, Color normalTextColourPreview, Color disabledTextColourPreview, Color focusedTextColourPreview, Color pressedTextColourPreview, Color disabledColourPreview, Color linkNormalColourPreview, Color linkHoverColourPreview, Color linkVisitedColourPreview, Color customColourOne, Color customColourTwo, Color customColourThree, Color customColourFour, Color customColourFive, Color customTextColourOne, Color customTextColourTwo, Color customTextColourThree, Color customTextColourFour, Color customTextColourFive, Color menuTextColour, Color statusTextColour)
        {
            AllMergedColourSettingsManager colourSettingsManager = new AllMergedColourSettingsManager();

            colourSettingsManager.SetBaseColour(baseColour);

            colourSettingsManager.SetDarkColour(darkColour);

            colourSettingsManager.SetMediumColour(middleColour);

            colourSettingsManager.SetLightColour(lightColour);

            colourSettingsManager.SetLightestColour(lightestColour);

            colourSettingsManager.SetBorderColour(borderColourPreview);

            colourSettingsManager.SetAlternativeNormalTextColour(alternativeNormalTextColourPreview);

            colourSettingsManager.SetNormalTextColour(normalTextColourPreview);

            colourSettingsManager.SetDisabledTextColour(disabledTextColourPreview);

            colourSettingsManager.SetFocusedTextColour(focusedTextColourPreview);

            colourSettingsManager.SetPressedTextColour(pressedTextColourPreview);

            colourSettingsManager.SetDisabledControlColour(disabledColourPreview);

            colourSettingsManager.SetLinkNormalColour(linkNormalColourPreview);

            colourSettingsManager.SetLinkHoverColour(linkHoverColourPreview);

            colourSettingsManager.SetLinkVisitedColour(linkVisitedColourPreview);

            colourSettingsManager.SetCustomColourOne(customColourOne);

            colourSettingsManager.SetCustomColourTwo(customColourTwo);

            colourSettingsManager.SetCustomColourThree(customColourThree);

            colourSettingsManager.SetCustomColourFour(customColourFour);

            colourSettingsManager.SetCustomColourFive(customColourFive);

            colourSettingsManager.SetCustomTextColourOne(customTextColourOne);

            colourSettingsManager.SetCustomTextColourTwo(customTextColourTwo);

            colourSettingsManager.SetCustomTextColourThree(customTextColourThree);

            colourSettingsManager.SetCustomTextColourFour(customTextColourFour);

            colourSettingsManager.SetCustomTextColourFive(customTextColourFive);

            colourSettingsManager.SetMenuTextColour(menuTextColour);

            colourSettingsManager.SetStatusStripTextColour(statusTextColour);

            colourSettingsManager.SaveAllMergedColourSettings();
        }
        #endregion
    }
}