#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Core
{
    public static class ColourUtilities
    {
        #region Methods
        /// <summary>
        /// Converts the HSL values to a Color.
        /// </summary>
        /// <param name="alpha">The alpha.</param>
        /// <param name="hue">The hue.</param>
        /// <param name="saturation">The saturation.</param>
        /// <param name="lighting">The lighting.</param>
        /// <returns></returns>
        public static Color FromHsl(int alpha, float hue, float saturation, float lighting)
        {
            if (0 > alpha || 255 < alpha)
            {
                throw new ArgumentOutOfRangeException("alpha");
            }
            if (0f > hue || 360f < hue)
            {
                throw new ArgumentOutOfRangeException("hue");
            }
            if (0f > saturation || 1f < saturation)
            {
                throw new ArgumentOutOfRangeException("saturation");
            }
            if (0f > lighting || 1f < lighting)
            {
                throw new ArgumentOutOfRangeException("lighting");
            }

            if (0 == saturation)
            {
                return Color.FromArgb(alpha, Convert.ToInt32(lighting * 255), Convert.ToInt32(lighting * 255), Convert.ToInt32(lighting * 255));
            }

            float fMax, fMid, fMin;
            int iSextant, iMax, iMid, iMin;

            if (0.5 < lighting)
            {
                fMax = lighting - (lighting * saturation) + saturation;
                fMin = lighting + (lighting * saturation) - saturation;
            }
            else
            {
                fMax = lighting + (lighting * saturation);
                fMin = lighting - (lighting * saturation);
            }

            iSextant = (int)Math.Floor(hue / 60f);
            if (300f <= hue)
            {
                hue -= 360f;
            }
            hue /= 60f;
            hue -= 2f * (float)Math.Floor(((iSextant + 1f) % 6f) / 2f);
            if (0 == iSextant % 2)
            {
                fMid = hue * (fMax - fMin) + fMin;
            }
            else
            {
                fMid = fMin - hue * (fMax - fMin);
            }

            iMax = Convert.ToInt32(fMax * 255);
            iMid = Convert.ToInt32(fMid * 255);
            iMin = Convert.ToInt32(fMin * 255);

            switch (iSextant)
            {
                case 1:
                    return Color.FromArgb(alpha, iMid, iMax, iMin);
                case 2:
                    return Color.FromArgb(alpha, iMin, iMax, iMid);
                case 3:
                    return Color.FromArgb(alpha, iMin, iMid, iMax);
                case 4:
                    return Color.FromArgb(alpha, iMid, iMin, iMax);
                case 5:
                    return Color.FromArgb(alpha, iMax, iMin, iMid);
                default:
                    return Color.FromArgb(alpha, iMax, iMid, iMin);
            }
        }

        /// <summary>
        /// Tints the color by the given percent.
        /// </summary>
        /// <param name="color">The color being tinted.</param>
        /// <param name="percent">The percent to tint. Ex: 0.1 will make the color 10% lighter.</param>
        /// <returns>The new tinted color.</returns>
        public static Color Lighten(this Color color, float percent)
        {
            var lighting = color.GetBrightness();
            lighting = lighting + lighting * percent;
            if (lighting > 1.0)
            {
                lighting = 1;
            }
            else if (lighting <= 0)
            {
                lighting = 0.1f;
            }
            var tintedColor = FromHsl(color.A, color.GetHue(), color.GetSaturation(), lighting);

            return tintedColor;
        }

        /// <summary>
        /// Tints the color by the given percent.
        /// </summary>
        /// <param name="color">The color being tinted.</param>
        /// <param name="percent">The percent to tint. Ex: 0.1 will make the color 10% darker.</param>
        /// <returns>The new tinted color.</returns>
        public static Color Darken(this Color color, float percent)
        {
            var lighting = color.GetBrightness();
            lighting = lighting - lighting * percent;
            if (lighting > 1.0)
            {
                lighting = 1;
            }
            else if (lighting <= 0)
            {
                lighting = 0;
            }
            var tintedColor = FromHsl(color.A, color.GetHue(), color.GetSaturation(), lighting);

            return tintedColor;
        }

        /// <summary>
        /// Generates the colour shades.
        /// </summary>
        /// <param name="baseColour">The base colour.</param>
        /// <param name="darkestColour">The darkest colour.</param>
        /// <param name="mediumColour">The medium colour.</param>
        /// <param name="lightColour">The light colour.</param>
        /// <param name="lightestColour">The lightest colour.</param>
        public static void GenerateColourShades(Color baseColour, PictureBox darkestColour, PictureBox mediumColour, PictureBox lightColour, PictureBox lightestColour)
        {
            ColourIntensitySettingsManager colourBlendingSettingsManager = new ColourIntensitySettingsManager();

            if (baseColour != null)
            {
                darkestColour.BackColor = Darken(baseColour, colourBlendingSettingsManager.GetDarkestColourIntensity());

                mediumColour.BackColor = Darken(baseColour, colourBlendingSettingsManager.GetMediumColourIntensity());

                lightColour.BackColor = Lighten(baseColour, colourBlendingSettingsManager.GetLightColourIntensity());

                lightestColour.BackColor = Lighten(baseColour, colourBlendingSettingsManager.GetLightestColourIntensity());

                if (lightestColour.BackColor == lightColour.BackColor)
                {
                    lightestColour.BackColor = Color.Transparent;

                    lightestColour.Enabled = false;
                }
                else
                {
                    lightestColour.Enabled = true;
                }
            }
        }

        /// <summary>
        /// Generates the colour shades.
        /// </summary>
        /// <param name="baseColour">The base colour.</param>
        /// <param name="darkestColour">The darkest colour.</param>
        /// <param name="mediumColour">The middle colour.</param>
        /// <param name="lightColour">The light colour.</param>
        /// <param name="lightestColour">The lightest colour.</param>
        public static void GenerateColourShades(Color baseColour, CircularPictureBox darkestColour, CircularPictureBox mediumColour, CircularPictureBox lightColour, CircularPictureBox lightestColour)
        {
            ColourIntensitySettingsManager colourBlendingSettingsManager = new ColourIntensitySettingsManager();

            if (baseColour != null)
            {
                darkestColour.BackColor = Darken(baseColour, colourBlendingSettingsManager.GetDarkestColourIntensity());

                mediumColour.BackColor = Darken(baseColour, colourBlendingSettingsManager.GetMediumColourIntensity());

                lightColour.BackColor = Lighten(baseColour, colourBlendingSettingsManager.GetLightColourIntensity());

                lightestColour.BackColor = Lighten(baseColour, colourBlendingSettingsManager.GetLightestColourIntensity());

                if (lightestColour.BackColor == lightColour.BackColor)
                {
                    lightestColour.BackColor = Color.Transparent;

                    lightestColour.Enabled = false;
                }
                else
                {
                    lightestColour.Enabled = true;
                }
            }
        }

        /// <summary>
        /// Generates the colour shades.
        /// </summary>
        /// <param name="darkestColour">The darkest colour.</param>
        /// <param name="mediumColour">The medium colour.</param>
        /// <param name="lightColour">The light colour.</param>
        /// <param name="lightestColour">The lightest colour.</param>
        /// <param name="darkColourValue">The dark colour value.</param>
        /// <param name="mediumColourValue">The medium colour value.</param>
        /// <param name="lightColourValue">The light colour value.</param>
        /// <param name="lightestColourValue">The lightest colour value.</param>
        /// <param name="baseColour">The base colour.</param>
        public static void GenerateColourShades(CircularPictureBox darkestColour, CircularPictureBox mediumColour, CircularPictureBox lightColour, CircularPictureBox lightestColour, float darkColourValue, float mediumColourValue, float lightColourValue, float lightestColourValue, Color baseColour)
        {
            try
            {
                darkestColour.BackColor = Darken(baseColour, darkColourValue);

                mediumColour.BackColor = Darken(baseColour, mediumColourValue);

                lightColour.BackColor = Lighten(baseColour, lightColourValue);

                lightestColour.BackColor = Lighten(baseColour, lightestColourValue);
            }
            catch (Exception ex)
            {
                ExceptionHandler.CaptureException(ex, icon: MessageBoxIcon.Error, methodSignature: Helpers.GetCurrentMethod());
            }
        }

        /// <summary>
        /// Formats the colour ARGB string.
        /// </summary>
        /// <param name="colourInput">The colour input.</param>
        /// <returns>A string containing the alpha, red, green and blue colour values of the selected <paramref name="colourInput"/>.</returns>
        public static string FormatColourARGBString(Color colourInput)
        {
            return $"{ colourInput.A.ToString() }, { colourInput.R.ToString() }, { colourInput.G.ToString() }, { colourInput.B.ToString() }";
        }

        /// <summary>
        /// Formats the colour RGB string.
        /// </summary>
        /// <param name="colourInput">The colour input.</param>
        /// <returns>A string containing the red, green and blue colour values of the selected <paramref name="colourInput"/>.</returns>
        public static string FormatColourRGBString(Color colourInput)
        {
            return $"{ colourInput.R.ToString() }, { colourInput.G.ToString() }, { colourInput.B.ToString() }";
        }

        /// <summary>
        /// Propagates the HSB values.
        /// </summary>
        /// <param name="hueValue">The hue value.</param>
        /// <param name="saturationValue">The saturation value.</param>
        /// <param name="brightnessValue">The brightness value.</param>
        /// <param name="hue">The hue.</param>
        /// <param name="saturation">The saturation.</param>
        /// <param name="brightness">The brightness.</param>
        public static void PropagateHSBValues(KryptonNumericUpDown hueValue, KryptonNumericUpDown saturationValue, KryptonNumericUpDown brightnessValue, decimal hue, decimal saturation, decimal brightness)
        {
            hueValue.Value = hue;

            saturationValue.Value = saturation;

            brightnessValue.Value = brightness;
        }

        /// <summary>
        /// Propagates the standard colours.
        /// </summary>
        /// <param name="standardColourSelection">The standard colour selection.</param>
        public static void PropagateStandardColours(KryptonComboBox standardColourSelection)
        {
            List<Color> allColours = new List<Color>();

            foreach (KnownColor colour in Enum.GetValues(typeof(KnownColor)))
            {
                Color standardColour = Color.FromKnownColor(colour);

                if (!allColours.Contains(standardColour))
                {
                    standardColourSelection.Items.Add(standardColour.Name);

                    standardColourSelection.AutoCompleteCustomSource.Add(standardColour.Name);

                    allColours.Add(standardColour);
                }
            }
        }

        /// <summary>
        /// Propagates the system colours.
        /// </summary>
        /// <param name="systemColourSelection">The system colour selection.</param>
        public static void PropagateSystemColours(KryptonComboBox systemColourSelection)
        {
            List<Color> allSystemColours = new List<Color>();

            PropertyInfo[] systemColourProperties = typeof(SystemColors).GetProperties();

            foreach (PropertyInfo propertyInfo in systemColourProperties)
            {
                object colourObject = propertyInfo.GetValue(null, null);

                Color systemColour = (Color)colourObject;

                if (!allSystemColours.Contains(systemColour))
                {
                    systemColourSelection.Items.Add(systemColour.Name);

                    systemColourSelection.AutoCompleteCustomSource.Add(systemColour.Name);

                    allSystemColours.Add(systemColour);
                }
            }
        }

        public static void PropagateBasePaletteModes(KryptonComboBox basePaletteModeSelection)
        {
            List<PaletteMode> allPaletteModes = new List<PaletteMode>();

            foreach (string mode in Enum.GetNames(typeof(PaletteMode)))
            {
                basePaletteModeSelection.Items.Add(mode);
            }
        }

        public static void PropagateBasePaletteModes(KryptonRibbonGroupComboBox basePaletteModeSelection)
        {
            List<PaletteMode> allPaletteModes = new List<PaletteMode>();

            foreach (string mode in Enum.GetNames(typeof(PaletteMode)))
            {
                basePaletteModeSelection.Items.Add(mode);
            }
        }

        /// <summary>
        /// Grabs the colour definitions.
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
        public static void GrabColourDefinitions(PictureBox baseColour, PictureBox darkColour, PictureBox middleColour, PictureBox lightColour, PictureBox lightestColour, PictureBox borderColourPreview, PictureBox alternativeNormalTextColourPreview, PictureBox normalTextColourPreview, PictureBox disabledTextColourPreview, PictureBox focusedTextColourPreview, PictureBox pressedTextColourPreview, PictureBox disabledColourPreview, PictureBox linkNormalColourPreview, PictureBox linkFocusedColourPreview, PictureBox linkHoverColourPreview, PictureBox linkVisitedColourPreview, PictureBox customColourOne, PictureBox customColourTwo, PictureBox customColourThree, PictureBox customColourFour, PictureBox customColourFive, PictureBox customTextColourOne, PictureBox customTextColourTwo, PictureBox customTextColourThree, PictureBox customTextColourFour, PictureBox customTextColourFive, PictureBox menuTextColour, PictureBox statusTextColour, PictureBox ribbonTabTextColourPreview)
        {
            AllMergedColourSettingsManager colourSettingsManager = new AllMergedColourSettingsManager();

            baseColour.BackColor = colourSettingsManager.GetBaseColour();

            darkColour.BackColor = colourSettingsManager.GetDarkColour();

            middleColour.BackColor = colourSettingsManager.GetMediumColour();

            lightColour.BackColor = colourSettingsManager.GetLightColour();

            lightestColour.BackColor = colourSettingsManager.GetLightestColour();

            borderColourPreview.BackColor = colourSettingsManager.GetBorderColour();

            alternativeNormalTextColourPreview.BackColor = colourSettingsManager.GetAlternativeNormalTextColour();

            normalTextColourPreview.BackColor = colourSettingsManager.GetNormalTextColour();

            disabledTextColourPreview.BackColor = colourSettingsManager.GetDisabledTextColour();

            focusedTextColourPreview.BackColor = colourSettingsManager.GetFocusedTextColour();

            pressedTextColourPreview.BackColor = colourSettingsManager.GetPressedTextColour();

            disabledColourPreview.BackColor = colourSettingsManager.GetDisabledControlColour();

            linkNormalColourPreview.BackColor = colourSettingsManager.GetLinkNormalColour();

            linkFocusedColourPreview.BackColor = colourSettingsManager.GetLinkFocusedColour();

            linkHoverColourPreview.BackColor = colourSettingsManager.GetLinkHoverColour();

            linkVisitedColourPreview.BackColor = colourSettingsManager.GetLinkVisitedColour();

            customColourOne.BackColor = colourSettingsManager.GetCustomColourOne();

            customColourTwo.BackColor = colourSettingsManager.GetCustomColourTwo();

            customColourThree.BackColor = colourSettingsManager.GetCustomColourThree();

            customColourFour.BackColor = colourSettingsManager.GetCustomColourFour();

            customColourFive.BackColor = colourSettingsManager.GetCustomColourFive();

            menuTextColour.BackColor = colourSettingsManager.GetMenuTextColour();

            customTextColourOne.BackColor = colourSettingsManager.GetCustomTextColourOne();

            customTextColourTwo.BackColor = colourSettingsManager.GetCustomTextColourTwo();

            customTextColourThree.BackColor = colourSettingsManager.GetCustomTextColourThree();

            customTextColourFour.BackColor = colourSettingsManager.GetCustomTextColourFour();

            customTextColourFive.BackColor = colourSettingsManager.GetCustomTextColourFive();

            statusTextColour.BackColor = colourSettingsManager.GetStatusStripTextColour();

            ribbonTabTextColourPreview.BackColor = colourSettingsManager.GetRibbonTabTextColour();
        }

        /// <summary>
        /// Grabs the colour definitions.
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
        public static void GrabColourDefinitions(CircularPictureBox baseColour, CircularPictureBox darkColour, CircularPictureBox middleColour, CircularPictureBox lightColour, CircularPictureBox lightestColour, CircularPictureBox borderColourPreview, CircularPictureBox alternativeNormalTextColourPreview, CircularPictureBox normalTextColourPreview, CircularPictureBox disabledTextColourPreview, CircularPictureBox focusedTextColourPreview, CircularPictureBox pressedTextColourPreview, CircularPictureBox disabledColourPreview, CircularPictureBox linkNormalColourPreview, CircularPictureBox linkFocusedColourPreview, CircularPictureBox linkHoverColourPreview, CircularPictureBox linkVisitedColourPreview, CircularPictureBox customColourOne, CircularPictureBox customColourTwo, CircularPictureBox customColourThree, CircularPictureBox customColourFour, CircularPictureBox customColourFive, CircularPictureBox customTextColourOne, CircularPictureBox customTextColourTwo, CircularPictureBox customTextColourThree, CircularPictureBox customTextColourFour, CircularPictureBox customTextColourFive, CircularPictureBox menuTextColour, CircularPictureBox statusTextColour, CircularPictureBox ribbonTabTextColourPreview)
        {
            AllMergedColourSettingsManager colourSettingsManager = new AllMergedColourSettingsManager();

            baseColour.BackColor = colourSettingsManager.GetBaseColour();

            darkColour.BackColor = colourSettingsManager.GetDarkColour();

            middleColour.BackColor = colourSettingsManager.GetMediumColour();

            lightColour.BackColor = colourSettingsManager.GetLightColour();

            lightestColour.BackColor = colourSettingsManager.GetLightestColour();

            borderColourPreview.BackColor = colourSettingsManager.GetBorderColour();

            alternativeNormalTextColourPreview.BackColor = colourSettingsManager.GetAlternativeNormalTextColour();

            normalTextColourPreview.BackColor = colourSettingsManager.GetNormalTextColour();

            disabledTextColourPreview.BackColor = colourSettingsManager.GetDisabledTextColour();

            focusedTextColourPreview.BackColor = colourSettingsManager.GetFocusedTextColour();

            pressedTextColourPreview.BackColor = colourSettingsManager.GetPressedTextColour();

            disabledColourPreview.BackColor = colourSettingsManager.GetDisabledControlColour();

            linkNormalColourPreview.BackColor = colourSettingsManager.GetLinkNormalColour();

            linkFocusedColourPreview.BackColor = colourSettingsManager.GetLinkFocusedColour();

            linkHoverColourPreview.BackColor = colourSettingsManager.GetLinkHoverColour();

            linkVisitedColourPreview.BackColor = colourSettingsManager.GetLinkVisitedColour();

            customColourOne.BackColor = colourSettingsManager.GetCustomColourOne();

            customColourTwo.BackColor = colourSettingsManager.GetCustomColourTwo();

            customColourThree.BackColor = colourSettingsManager.GetCustomColourThree();

            customColourFour.BackColor = colourSettingsManager.GetCustomColourFour();

            customColourFive.BackColor = colourSettingsManager.GetCustomColourFive();

            menuTextColour.BackColor = colourSettingsManager.GetMenuTextColour();

            customTextColourOne.BackColor = colourSettingsManager.GetCustomTextColourOne();

            customTextColourTwo.BackColor = colourSettingsManager.GetCustomTextColourTwo();

            customTextColourThree.BackColor = colourSettingsManager.GetCustomTextColourThree();

            customTextColourFour.BackColor = colourSettingsManager.GetCustomTextColourFour();

            customTextColourFive.BackColor = colourSettingsManager.GetCustomTextColourFive();

            statusTextColour.BackColor = colourSettingsManager.GetStatusStripTextColour();

            ribbonTabTextColourPreview.BackColor = colourSettingsManager.GetRibbonTabTextColour();
        }

        /// <summary>
        /// Defines the custom colour.
        /// </summary>
        /// <param name="colourDefinitions">The colour definitions.</param>
        /// <param name="definedColour">The defined colour.</param>
        /// <param name="usePrompt">if set to <c>true</c> [use prompt].</param>
        public static void DefineCustomColour(MiscellaneousColourDefinitions colourDefinitions, Color definedColour, bool usePrompt = false)
        {
            #region Old Code            
            //switch (colourDefinitions)
            //{
            //    case MiscellaneousColourDefinitions.BORDERCOLOUR:
            //        _baseColour = colourSettingsManager.GetBaseColour();

            //        _darkestColour = colourSettingsManager.GetDarkestColour();

            //        _middleColour = colourSettingsManager.GetMediumColour();

            //        _lightColour = colourSettingsManager.GetLightColour();

            //        _lightestColour = colourSettingsManager.GetLightestColour();

            //        colourSettingsManager.SetBaseColour(_baseColour);

            //        colourSettingsManager.SetDarkestColour(_darkestColour);

            //        colourSettingsManager.SetMediumColour(_middleColour);

            //        colourSettingsManager.SetLightColour(_lightColour);

            //        colourSettingsManager.SetLightestColour(_lightestColour);

            //        colourSettingsManager.SetBorderColour(definedColour);

            //        colourSettingsManager.SaveColourSettings(usePrompt);
            //        break;
            //    case MiscellaneousColourDefinitions.ALTERNATIVENORMALTEXTCOLOUR:
            //        _baseColour = colourSettingsManager.GetBaseColour();

            //        _darkestColour = colourSettingsManager.GetDarkestColour();

            //        _middleColour = colourSettingsManager.GetMediumColour();

            //        _lightColour = colourSettingsManager.GetLightColour();

            //        _lightestColour = colourSettingsManager.GetLightestColour();

            //        colourSettingsManager.SetBaseColour(_baseColour);

            //        colourSettingsManager.SetDarkestColour(_darkestColour);

            //        colourSettingsManager.SetMediumColour(_middleColour);

            //        colourSettingsManager.SetLightColour(_lightColour);

            //        colourSettingsManager.SetLightestColour(_lightestColour);

            //        colourSettingsManager.SetAlternativeNormalTextColour(definedColour);

            //        colourSettingsManager.SaveColourSettings(usePrompt);
            //        break;
            //    case MiscellaneousColourDefinitions.NORMALTEXTCOLOUR:
            //        _baseColour = colourSettingsManager.GetBaseColour();

            //        _darkestColour = colourSettingsManager.GetDarkestColour();

            //        _middleColour = colourSettingsManager.GetMediumColour();

            //        _lightColour = colourSettingsManager.GetLightColour();

            //        _lightestColour = colourSettingsManager.GetLightestColour();

            //        colourSettingsManager.SetBaseColour(_baseColour);

            //        colourSettingsManager.SetDarkestColour(_darkestColour);

            //        colourSettingsManager.SetMediumColour(_middleColour);

            //        colourSettingsManager.SetLightColour(_lightColour);

            //        colourSettingsManager.SetLightestColour(_lightestColour);

            //        colourSettingsManager.SetNormalTextColour(definedColour);

            //        colourSettingsManager.SaveColourSettings(usePrompt);
            //        break;
            //    case MiscellaneousColourDefinitions.DISABLEDTEXTCOLOUR:
            //        _baseColour = colourSettingsManager.GetBaseColour();

            //        _darkestColour = colourSettingsManager.GetDarkestColour();

            //        _middleColour = colourSettingsManager.GetMediumColour();

            //        _lightColour = colourSettingsManager.GetLightColour();

            //        _lightestColour = colourSettingsManager.GetLightestColour();

            //        colourSettingsManager.SetBaseColour(_baseColour);

            //        colourSettingsManager.SetDarkestColour(_darkestColour);

            //        colourSettingsManager.SetMediumColour(_middleColour);

            //        colourSettingsManager.SetLightColour(_lightColour);

            //        colourSettingsManager.SetLightestColour(_lightestColour);

            //        colourSettingsManager.SetDisabledTextColour(definedColour);

            //        colourSettingsManager.SaveColourSettings(usePrompt);
            //        break;
            //    case MiscellaneousColourDefinitions.FOCUSEDTEXTCOLOUR:
            //        _baseColour = colourSettingsManager.GetBaseColour();

            //        _darkestColour = colourSettingsManager.GetDarkestColour();

            //        _middleColour = colourSettingsManager.GetMediumColour();

            //        _lightColour = colourSettingsManager.GetLightColour();

            //        _lightestColour = colourSettingsManager.GetLightestColour();

            //        colourSettingsManager.SetBaseColour(_baseColour);

            //        colourSettingsManager.SetDarkestColour(_darkestColour);

            //        colourSettingsManager.SetMediumColour(_middleColour);

            //        colourSettingsManager.SetLightColour(_lightColour);

            //        colourSettingsManager.SetLightestColour(_lightestColour);

            //        colourSettingsManager.SetFocusedTextColour(definedColour);

            //        colourSettingsManager.SaveColourSettings(usePrompt);
            //        break;
            //    case MiscellaneousColourDefinitions.PRESSEDTEXTCOLOUR:
            //        _baseColour = colourSettingsManager.GetBaseColour();

            //        _darkestColour = colourSettingsManager.GetDarkestColour();

            //        _middleColour = colourSettingsManager.GetMediumColour();

            //        _lightColour = colourSettingsManager.GetLightColour();

            //        _lightestColour = colourSettingsManager.GetLightestColour();

            //        colourSettingsManager.SetBaseColour(_baseColour);

            //        colourSettingsManager.SetDarkestColour(_darkestColour);

            //        colourSettingsManager.SetMediumColour(_middleColour);

            //        colourSettingsManager.SetLightColour(_lightColour);

            //        colourSettingsManager.SetLightestColour(_lightestColour);

            //        colourSettingsManager.SetPressedTextColour(definedColour);

            //        colourSettingsManager.SaveColourSettings(usePrompt);
            //        break;
            //    case MiscellaneousColourDefinitions.LINKNORMALTEXTCOLOUR:
            //        _baseColour = colourSettingsManager.GetBaseColour();

            //        _darkestColour = colourSettingsManager.GetDarkestColour();

            //        _middleColour = colourSettingsManager.GetMediumColour();

            //        _lightColour = colourSettingsManager.GetLightColour();

            //        _lightestColour = colourSettingsManager.GetLightestColour();

            //        colourSettingsManager.SetBaseColour(_baseColour);

            //        colourSettingsManager.SetDarkestColour(_darkestColour);

            //        colourSettingsManager.SetMediumColour(_middleColour);

            //        colourSettingsManager.SetLightColour(_lightColour);

            //        colourSettingsManager.SetLightestColour(_lightestColour);

            //        colourSettingsManager.SetLinkNormalColour(definedColour);

            //        colourSettingsManager.SaveColourSettings(usePrompt);
            //        break;
            //    case MiscellaneousColourDefinitions.LINKHOVERTEXTCOLOUR:
            //        _baseColour = colourSettingsManager.GetBaseColour();

            //        _darkestColour = colourSettingsManager.GetDarkestColour();

            //        _middleColour = colourSettingsManager.GetMediumColour();

            //        _lightColour = colourSettingsManager.GetLightColour();

            //        _lightestColour = colourSettingsManager.GetLightestColour();

            //        colourSettingsManager.SetBaseColour(_baseColour);

            //        colourSettingsManager.SetDarkestColour(_darkestColour);

            //        colourSettingsManager.SetMediumColour(_middleColour);

            //        colourSettingsManager.SetLightColour(_lightColour);

            //        colourSettingsManager.SetLightestColour(_lightestColour);

            //        colourSettingsManager.SetLinkHoverColour(definedColour);

            //        colourSettingsManager.SaveColourSettings(usePrompt);
            //        break;
            //    case MiscellaneousColourDefinitions.LINKVISITEDTEXTCOLOUR:
            //        _baseColour = colourSettingsManager.GetBaseColour();

            //        _darkestColour = colourSettingsManager.GetDarkestColour();

            //        _middleColour = colourSettingsManager.GetMediumColour();

            //        _lightColour = colourSettingsManager.GetLightColour();

            //        _lightestColour = colourSettingsManager.GetLightestColour();

            //        colourSettingsManager.SetBaseColour(_baseColour);

            //        colourSettingsManager.SetDarkestColour(_darkestColour);

            //        colourSettingsManager.SetMediumColour(_middleColour);

            //        colourSettingsManager.SetLightColour(_lightColour);

            //        colourSettingsManager.SetLightestColour(_lightestColour);

            //        colourSettingsManager.SetLinkVisitedColour(definedColour);

            //        colourSettingsManager.SaveColourSettings(usePrompt);
            //        break;
            //    case MiscellaneousColourDefinitions.DISABLEDCONTROLCOLOUR:
            //        _baseColour = colourSettingsManager.GetBaseColour();

            //        _darkestColour = colourSettingsManager.GetDarkestColour();

            //        _middleColour = colourSettingsManager.GetMediumColour();

            //        _lightColour = colourSettingsManager.GetLightColour();

            //        _lightestColour = colourSettingsManager.GetLightestColour();

            //        colourSettingsManager.SetBaseColour(_baseColour);

            //        colourSettingsManager.SetDarkestColour(_darkestColour);

            //        colourSettingsManager.SetMediumColour(_middleColour);

            //        colourSettingsManager.SetLightColour(_lightColour);

            //        colourSettingsManager.SetLightestColour(_lightestColour);

            //        colourSettingsManager.SetDisabledControlColour(definedColour);

            //        colourSettingsManager.SaveColourSettings(usePrompt);
            //        break;
            //    case MiscellaneousColourDefinitions.CUSTOMCOLOURONE:
            //        _baseColour = colourSettingsManager.GetBaseColour();

            //        _darkestColour = colourSettingsManager.GetDarkestColour();

            //        _middleColour = colourSettingsManager.GetMediumColour();

            //        _lightColour = colourSettingsManager.GetLightColour();

            //        _lightestColour = colourSettingsManager.GetLightestColour();

            //        colourSettingsManager.SetBaseColour(_baseColour);

            //        colourSettingsManager.SetDarkestColour(_darkestColour);

            //        colourSettingsManager.SetMediumColour(_middleColour);

            //        colourSettingsManager.SetLightColour(_lightColour);

            //        colourSettingsManager.SetLightestColour(_lightestColour);

            //        colourSettingsManager.SetCustomColourOne(definedColour);

            //        colourSettingsManager.SaveColourSettings(usePrompt);
            //        break;
            //    case MiscellaneousColourDefinitions.CUSTOMCOLOURTWO:
            //        _baseColour = colourSettingsManager.GetBaseColour();

            //        _darkestColour = colourSettingsManager.GetDarkestColour();

            //        _middleColour = colourSettingsManager.GetMediumColour();

            //        _lightColour = colourSettingsManager.GetLightColour();

            //        _lightestColour = colourSettingsManager.GetLightestColour();

            //        colourSettingsManager.SetBaseColour(_baseColour);

            //        colourSettingsManager.SetDarkestColour(_darkestColour);

            //        colourSettingsManager.SetMediumColour(_middleColour);

            //        colourSettingsManager.SetLightColour(_lightColour);

            //        colourSettingsManager.SetLightestColour(_lightestColour);

            //        colourSettingsManager.SetCustomColourTwo(definedColour);

            //        colourSettingsManager.SaveColourSettings(usePrompt);
            //        break;
            //    case MiscellaneousColourDefinitions.CUSTOMCOLOURTHREE:
            //        _baseColour = colourSettingsManager.GetBaseColour();

            //        _darkestColour = colourSettingsManager.GetDarkestColour();

            //        _middleColour = colourSettingsManager.GetMediumColour();

            //        _lightColour = colourSettingsManager.GetLightColour();

            //        _lightestColour = colourSettingsManager.GetLightestColour();

            //        colourSettingsManager.SetBaseColour(_baseColour);

            //        colourSettingsManager.SetDarkestColour(_darkestColour);

            //        colourSettingsManager.SetMediumColour(_middleColour);

            //        colourSettingsManager.SetLightColour(_lightColour);

            //        colourSettingsManager.SetLightestColour(_lightestColour);

            //        colourSettingsManager.SetCustomColourThree(definedColour);

            //        colourSettingsManager.SaveColourSettings(usePrompt);
            //        break;
            //    case MiscellaneousColourDefinitions.CUSTOMCOLOURFOUR:
            //        _baseColour = colourSettingsManager.GetBaseColour();

            //        _darkestColour = colourSettingsManager.GetDarkestColour();

            //        _middleColour = colourSettingsManager.GetMediumColour();

            //        _lightColour = colourSettingsManager.GetLightColour();

            //        _lightestColour = colourSettingsManager.GetLightestColour();

            //        colourSettingsManager.SetBaseColour(_baseColour);

            //        colourSettingsManager.SetDarkestColour(_darkestColour);

            //        colourSettingsManager.SetMediumColour(_middleColour);

            //        colourSettingsManager.SetLightColour(_lightColour);

            //        colourSettingsManager.SetLightestColour(_lightestColour);

            //        colourSettingsManager.SetCustomColourFour(definedColour);

            //        colourSettingsManager.SaveColourSettings(usePrompt);
            //        break;
            //    case MiscellaneousColourDefinitions.CUSTOMCOLOURFIVE:
            //        _baseColour = colourSettingsManager.GetBaseColour();

            //        _darkestColour = colourSettingsManager.GetDarkestColour();

            //        _middleColour = colourSettingsManager.GetMediumColour();

            //        _lightColour = colourSettingsManager.GetLightColour();

            //        _lightestColour = colourSettingsManager.GetLightestColour();

            //        colourSettingsManager.SetBaseColour(_baseColour);

            //        colourSettingsManager.SetDarkestColour(_darkestColour);

            //        colourSettingsManager.SetMediumColour(_middleColour);

            //        colourSettingsManager.SetLightColour(_lightColour);

            //        colourSettingsManager.SetLightestColour(_lightestColour);

            //        colourSettingsManager.SetCustomColourFive(definedColour);

            //        colourSettingsManager.SaveColourSettings(usePrompt);
            //        break;
            //    case MiscellaneousColourDefinitions.MENUTEXTCOLOUR:
            //        _baseColour = colourSettingsManager.GetBaseColour();

            //        _darkestColour = colourSettingsManager.GetDarkestColour();

            //        _middleColour = colourSettingsManager.GetMediumColour();

            //        _lightColour = colourSettingsManager.GetLightColour();

            //        _lightestColour = colourSettingsManager.GetLightestColour();

            //        colourSettingsManager.SetBaseColour(_baseColour);

            //        colourSettingsManager.SetDarkestColour(_darkestColour);

            //        colourSettingsManager.SetMediumColour(_middleColour);

            //        colourSettingsManager.SetLightColour(_lightColour);

            //        colourSettingsManager.SetLightestColour(_lightestColour);

            //        colourSettingsManager.SetMenuTextColour(definedColour);

            //        colourSettingsManager.SaveColourSettings(usePrompt);
            //        break;
            //    case MiscellaneousColourDefinitions.CUSTOMTEXTCOLOURONE:
            //        _baseColour = colourSettingsManager.GetBaseColour();

            //        _darkestColour = colourSettingsManager.GetDarkestColour();

            //        _middleColour = colourSettingsManager.GetMediumColour();

            //        _lightColour = colourSettingsManager.GetLightColour();

            //        _lightestColour = colourSettingsManager.GetLightestColour();

            //        colourSettingsManager.SetBaseColour(_baseColour);

            //        colourSettingsManager.SetDarkestColour(_darkestColour);

            //        colourSettingsManager.SetMediumColour(_middleColour);

            //        colourSettingsManager.SetLightColour(_lightColour);

            //        colourSettingsManager.SetLightestColour(_lightestColour);

            //        colourSettingsManager.SetCustomTextColourOne(definedColour);

            //        colourSettingsManager.SaveColourSettings(usePrompt);
            //        break;
            //    case MiscellaneousColourDefinitions.CUSTOMTEXTCOLOURTWO:
            //        _baseColour = colourSettingsManager.GetBaseColour();

            //        _darkestColour = colourSettingsManager.GetDarkestColour();

            //        _middleColour = colourSettingsManager.GetMediumColour();

            //        _lightColour = colourSettingsManager.GetLightColour();

            //        _lightestColour = colourSettingsManager.GetLightestColour();

            //        colourSettingsManager.SetBaseColour(_baseColour);

            //        colourSettingsManager.SetDarkestColour(_darkestColour);

            //        colourSettingsManager.SetMediumColour(_middleColour);

            //        colourSettingsManager.SetLightColour(_lightColour);

            //        colourSettingsManager.SetLightestColour(_lightestColour);

            //        colourSettingsManager.SetCustomTextColourTwo(definedColour);

            //        colourSettingsManager.SaveColourSettings(usePrompt);
            //        break;
            //    case MiscellaneousColourDefinitions.CUSTOMTEXTCOLOURTHREE:
            //        _baseColour = colourSettingsManager.GetBaseColour();

            //        _darkestColour = colourSettingsManager.GetDarkestColour();

            //        _middleColour = colourSettingsManager.GetMediumColour();

            //        _lightColour = colourSettingsManager.GetLightColour();

            //        _lightestColour = colourSettingsManager.GetLightestColour();

            //        colourSettingsManager.SetBaseColour(_baseColour);

            //        colourSettingsManager.SetDarkestColour(_darkestColour);

            //        colourSettingsManager.SetMediumColour(_middleColour);

            //        colourSettingsManager.SetLightColour(_lightColour);

            //        colourSettingsManager.SetLightestColour(_lightestColour);

            //        colourSettingsManager.SetCustomTextColourThree(definedColour);

            //        colourSettingsManager.SaveColourSettings(usePrompt);
            //        break;
            //    case MiscellaneousColourDefinitions.CUSTOMTEXTCOLOURFOUR:
            //        _baseColour = colourSettingsManager.GetBaseColour();

            //        _darkestColour = colourSettingsManager.GetDarkestColour();

            //        _middleColour = colourSettingsManager.GetMediumColour();

            //        _lightColour = colourSettingsManager.GetLightColour();

            //        _lightestColour = colourSettingsManager.GetLightestColour();

            //        colourSettingsManager.SetBaseColour(_baseColour);

            //        colourSettingsManager.SetDarkestColour(_darkestColour);

            //        colourSettingsManager.SetMediumColour(_middleColour);

            //        colourSettingsManager.SetLightColour(_lightColour);

            //        colourSettingsManager.SetLightestColour(_lightestColour);

            //        colourSettingsManager.SetCustomTextColourFour(definedColour);

            //        colourSettingsManager.SaveColourSettings(usePrompt);
            //        break;
            //    case MiscellaneousColourDefinitions.CUSTOMTEXTCOLOURFIVE:
            //        _baseColour = colourSettingsManager.GetBaseColour();

            //        _darkestColour = colourSettingsManager.GetDarkestColour();

            //        _middleColour = colourSettingsManager.GetMediumColour();

            //        _lightColour = colourSettingsManager.GetLightColour();

            //        _lightestColour = colourSettingsManager.GetLightestColour();

            //        colourSettingsManager.SetBaseColour(_baseColour);

            //        colourSettingsManager.SetDarkestColour(_darkestColour);

            //        colourSettingsManager.SetMediumColour(_middleColour);

            //        colourSettingsManager.SetLightColour(_lightColour);

            //        colourSettingsManager.SetLightestColour(_lightestColour);

            //        colourSettingsManager.SetCustomTextColourFive(definedColour);

            //        colourSettingsManager.SaveColourSettings(usePrompt);
            //        break;
            //    case MiscellaneousColourDefinitions.STATUSTEXTCOLOUR:
            //        _baseColour = colourSettingsManager.GetBaseColour();

            //        _darkestColour = colourSettingsManager.GetDarkestColour();

            //        _middleColour = colourSettingsManager.GetMediumColour();

            //        _lightColour = colourSettingsManager.GetLightColour();

            //        _lightestColour = colourSettingsManager.GetLightestColour();

            //        colourSettingsManager.SetBaseColour(_baseColour);

            //        colourSettingsManager.SetDarkestColour(_darkestColour);

            //        colourSettingsManager.SetMediumColour(_middleColour);

            //        colourSettingsManager.SetLightColour(_lightColour);

            //        colourSettingsManager.SetLightestColour(_lightestColour);

            //        colourSettingsManager.SetStatusStripTextColour(definedColour);

            //        colourSettingsManager.SaveColourSettings(usePrompt);
            //        break;
            //    case MiscellaneousColourDefinitions.RIBBONTABTEXTCOLOUR:
            //        break;
            //    default:
            //        break;
            //}
            #endregion

            switch (colourDefinitions)
            {
                case MiscellaneousColourDefinitions.BORDERCOLOUR:
                    break;
                case MiscellaneousColourDefinitions.ALTERNATIVENORMALTEXTCOLOUR:
                    break;
                case MiscellaneousColourDefinitions.NORMALTEXTCOLOUR:
                    break;
                case MiscellaneousColourDefinitions.DISABLEDTEXTCOLOUR:
                    break;
                case MiscellaneousColourDefinitions.FOCUSEDTEXTCOLOUR:
                    break;
                case MiscellaneousColourDefinitions.PRESSEDTEXTCOLOUR:
                    break;
                case MiscellaneousColourDefinitions.LINKNORMALTEXTCOLOUR:
                    break;
                case MiscellaneousColourDefinitions.LINKDISABLEDTEXTCOLOUR:
                    break;
                case MiscellaneousColourDefinitions.LINKHOVERTEXTCOLOUR:
                    break;
                case MiscellaneousColourDefinitions.LINKVISITEDTEXTCOLOUR:
                    break;
                case MiscellaneousColourDefinitions.DISABLEDCONTROLCOLOUR:
                    break;
                case MiscellaneousColourDefinitions.CUSTOMCOLOURONE:
                    break;
                case MiscellaneousColourDefinitions.CUSTOMCOLOURTWO:
                    break;
                case MiscellaneousColourDefinitions.CUSTOMCOLOURTHREE:
                    break;
                case MiscellaneousColourDefinitions.CUSTOMCOLOURFOUR:
                    break;
                case MiscellaneousColourDefinitions.CUSTOMCOLOURFIVE:
                    break;
                case MiscellaneousColourDefinitions.MENUTEXTCOLOUR:
                    break;
                case MiscellaneousColourDefinitions.CUSTOMTEXTCOLOURONE:
                    break;
                case MiscellaneousColourDefinitions.CUSTOMTEXTCOLOURTWO:
                    break;
                case MiscellaneousColourDefinitions.CUSTOMTEXTCOLOURTHREE:
                    break;
                case MiscellaneousColourDefinitions.CUSTOMTEXTCOLOURFOUR:
                    break;
                case MiscellaneousColourDefinitions.CUSTOMTEXTCOLOURFIVE:
                    break;
                case MiscellaneousColourDefinitions.STATUSTEXTCOLOUR:
                    break;
                case MiscellaneousColourDefinitions.RIBBONTABTEXTCOLOUR:
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Resets the colour definitions.
        /// </summary>
        /// <param name="cbxBaseColourPreview">The CBX base colour preview.</param>
        /// <param name="cbxDarkColourPreview">The CBX dark colour preview.</param>
        /// <param name="cbxMiddleColourPreview">The CBX middle colour preview.</param>
        /// <param name="cbxLightColourPreview">The CBX light colour preview.</param>
        /// <param name="cbxLightestColourPreview">The CBX lightest colour preview.</param>
        /// <param name="cbxBorderColourPreview">The CBX border colour preview.</param>
        /// <param name="cbxAlternativeNormalTextColourPreview">The CBX alternative normal text colour preview.</param>
        /// <param name="cbxNormalTextColourPreview">The CBX normal text colour preview.</param>
        /// <param name="cbxDisabledTextColourPreview">The CBX disabled text colour preview.</param>
        /// <param name="cbxFocusedTextColourPreview">The CBX focused text colour preview.</param>
        /// <param name="cbxPressedTextColourPreview">The CBX pressed text colour preview.</param>
        /// <param name="cbxDisabledColourPreview">The CBX disabled colour preview.</param>
        /// <param name="cbxLinkNormalColourPreview">The CBX link normal colour preview.</param>
        /// <param name="cbxLinkFocusedColourPreview">The CBX link focused colour preview.</param>
        /// <param name="cbxLinkHoverColourPreview">The CBX link hover colour preview.</param>
        /// <param name="cbxLinkVisitedColourPreview">The CBX link visited colour preview.</param>
        /// <param name="cbxCustomColourOnePreview">The CBX custom colour one preview.</param>
        /// <param name="cbxCustomColourTwoPreview">The CBX custom colour two preview.</param>
        /// <param name="cbxCustomColourThreePreview">The CBX custom colour three preview.</param>
        /// <param name="cbxCustomColourFourPreview">The CBX custom colour four preview.</param>
        /// <param name="cbxCustomColourFivePreview">The CBX custom colour five preview.</param>
        /// <param name="cbxCustomTextColourOnePreview">The CBX custom text colour one preview.</param>
        /// <param name="cbxCustomTextColourTwoPreview">The CBX custom text colour two preview.</param>
        /// <param name="cbxCustomTextColourThreePreview">The CBX custom text colour three preview.</param>
        /// <param name="cbxCustomTextColourFourPreview">The CBX custom text colour four preview.</param>
        /// <param name="cbxCustomTextColourFivePreview">The CBX custom text colour five preview.</param>
        /// <param name="cbxMenuTextColourPreview">The CBX menu text colour preview.</param>
        /// <param name="cbxStatusTextColourPreview">The CBX status text colour preview.</param>
        /// <param name="cbxRibbonTabTextColourPreview">The CBX ribbon tab text colour preview.</param>
        public static void ResetColourDefinitions(CircularPictureBox cbxBaseColourPreview, CircularPictureBox cbxDarkColourPreview, CircularPictureBox cbxMiddleColourPreview, CircularPictureBox cbxLightColourPreview, CircularPictureBox cbxLightestColourPreview, CircularPictureBox cbxBorderColourPreview, CircularPictureBox cbxAlternativeNormalTextColourPreview, CircularPictureBox cbxNormalTextColourPreview, CircularPictureBox cbxDisabledTextColourPreview, CircularPictureBox cbxFocusedTextColourPreview, CircularPictureBox cbxPressedTextColourPreview, CircularPictureBox cbxDisabledColourPreview, CircularPictureBox cbxLinkNormalColourPreview, CircularPictureBox cbxLinkFocusedColourPreview, CircularPictureBox cbxLinkHoverColourPreview, CircularPictureBox cbxLinkVisitedColourPreview, CircularPictureBox cbxCustomColourOnePreview, CircularPictureBox cbxCustomColourTwoPreview, CircularPictureBox cbxCustomColourThreePreview, CircularPictureBox cbxCustomColourFourPreview, CircularPictureBox cbxCustomColourFivePreview, CircularPictureBox cbxCustomTextColourOnePreview, CircularPictureBox cbxCustomTextColourTwoPreview, CircularPictureBox cbxCustomTextColourThreePreview, CircularPictureBox cbxCustomTextColourFourPreview, CircularPictureBox cbxCustomTextColourFivePreview, CircularPictureBox cbxMenuTextColourPreview, CircularPictureBox cbxStatusTextColourPreview, CircularPictureBox cbxRibbonTabTextColourPreview)
        {
            Color resetColour = Color.White;

            cbxBaseColourPreview.BackColor = resetColour;

            cbxDarkColourPreview.BackColor = resetColour;

            cbxMiddleColourPreview.BackColor = resetColour;

            cbxLightColourPreview.BackColor = resetColour;

            cbxLightestColourPreview.BackColor = resetColour;

            cbxBorderColourPreview.BackColor = resetColour;

            cbxAlternativeNormalTextColourPreview.BackColor = resetColour;

            cbxNormalTextColourPreview.BackColor = resetColour;

            cbxDisabledTextColourPreview.BackColor = resetColour;

            cbxFocusedTextColourPreview.BackColor = resetColour;

            cbxPressedTextColourPreview.BackColor = resetColour;

            cbxDisabledColourPreview.BackColor = resetColour;

            cbxLinkNormalColourPreview.BackColor = resetColour;

            cbxLinkFocusedColourPreview.BackColor = resetColour;

            cbxLinkHoverColourPreview.BackColor = resetColour;

            cbxLinkVisitedColourPreview.BackColor = resetColour;

            cbxCustomColourOnePreview.BackColor = resetColour;

            cbxCustomColourTwoPreview.BackColor = resetColour;

            cbxCustomColourThreePreview.BackColor = resetColour;

            cbxCustomColourFourPreview.BackColor = resetColour;

            cbxCustomColourFivePreview.BackColor = resetColour;

            cbxCustomTextColourOnePreview.BackColor = resetColour;

            cbxCustomTextColourTwoPreview.BackColor = resetColour;

            cbxCustomTextColourThreePreview.BackColor = resetColour;

            cbxCustomTextColourFourPreview.BackColor = resetColour;

            cbxCustomTextColourFivePreview.BackColor = resetColour;

            cbxMenuTextColourPreview.BackColor = resetColour;

            cbxStatusTextColourPreview.BackColor = resetColour;

            cbxRibbonTabTextColourPreview.BackColor = resetColour;
        }

        /// <summary>
        /// Resets the colour definitions.
        /// </summary>
        /// <param name="pbxBaseColourPreview">The PBX base colour preview.</param>
        /// <param name="pbxDarkColourPreview">The PBX dark colour preview.</param>
        /// <param name="pbxMiddleColourPreview">The PBX middle colour preview.</param>
        /// <param name="pbxLightColourPreview">The PBX light colour preview.</param>
        /// <param name="pbxLightestColourPreview">The PBX lightest colour preview.</param>
        /// <param name="pbxBorderColourPreview">The PBX border colour preview.</param>
        /// <param name="pbxAlternativeNormalTextColourPreview">The PBX alternative normal text colour preview.</param>
        /// <param name="pbxNormalTextColourPreview">The PBX normal text colour preview.</param>
        /// <param name="pbxDisabledTextColourPreview">The PBX disabled text colour preview.</param>
        /// <param name="pbxFocusedTextColourPreview">The PBX focused text colour preview.</param>
        /// <param name="pbxPressedTextColourPreview">The PBX pressed text colour preview.</param>
        /// <param name="pbxDisabledColourPreview">The PBX disabled colour preview.</param>
        /// <param name="pbxLinkNormalColourPreview">The PBX link normal colour preview.</param>
        /// <param name="pbxLinkFocusedColourPreview">The PBX link focused colour preview.</param>
        /// <param name="pbxLinkHoverColourPreview">The PBX link hover colour preview.</param>
        /// <param name="pbxLinkVisitedColourPreview">The PBX link visited colour preview.</param>
        /// <param name="pbxCustomColourOnePreview">The PBX custom colour one preview.</param>
        /// <param name="pbxCustomColourTwoPreview">The PBX custom colour two preview.</param>
        /// <param name="pbxCustomColourThreePreview">The PBX custom colour three preview.</param>
        /// <param name="pbxCustomColourFourPreview">The PBX custom colour four preview.</param>
        /// <param name="pbxCustomColourFivePreview">The PBX custom colour five preview.</param>
        /// <param name="pbxCustomTextColourOnePreview">The PBX custom text colour one preview.</param>
        /// <param name="pbxCustomTextColourTwoPreview">The PBX custom text colour two preview.</param>
        /// <param name="pbxCustomTextColourThreePreview">The PBX custom text colour three preview.</param>
        /// <param name="pbxCustomTextColourFourPreview">The PBX custom text colour four preview.</param>
        /// <param name="pbxCustomTextColourFivePreview">The PBX custom text colour five preview.</param>
        /// <param name="pbxMenuTextColourPreview">The PBX menu text colour preview.</param>
        /// <param name="pbxStatusTextColourPreview">The PBX status text colour preview.</param>
        /// <param name="pbxRibbonTabTextColourPreview">The PBX ribbon tab text colour preview.</param>
        public static void ResetColourDefinitions(PictureBox pbxBaseColourPreview, PictureBox pbxDarkColourPreview, PictureBox pbxMiddleColourPreview, PictureBox pbxLightColourPreview, PictureBox pbxLightestColourPreview, PictureBox pbxBorderColourPreview, PictureBox pbxAlternativeNormalTextColourPreview, PictureBox pbxNormalTextColourPreview, PictureBox pbxDisabledTextColourPreview, PictureBox pbxFocusedTextColourPreview, PictureBox pbxPressedTextColourPreview, PictureBox pbxDisabledColourPreview, PictureBox pbxLinkNormalColourPreview, PictureBox pbxLinkFocusedColourPreview, PictureBox pbxLinkHoverColourPreview, PictureBox pbxLinkVisitedColourPreview, PictureBox pbxCustomColourOnePreview, PictureBox pbxCustomColourTwoPreview, PictureBox pbxCustomColourThreePreview, PictureBox pbxCustomColourFourPreview, PictureBox pbxCustomColourFivePreview, PictureBox pbxCustomTextColourOnePreview, PictureBox pbxCustomTextColourTwoPreview, PictureBox pbxCustomTextColourThreePreview, PictureBox pbxCustomTextColourFourPreview, PictureBox pbxCustomTextColourFivePreview, PictureBox pbxMenuTextColourPreview, PictureBox pbxStatusTextColourPreview, PictureBox pbxRibbonTabTextColourPreview)
        {

        }

        public static void InvertColours(CircularPictureBox cbxBaseColourPreview, CircularPictureBox cbxDarkColourPreview, CircularPictureBox cbxMiddleColourPreview, CircularPictureBox cbxLightColourPreview, CircularPictureBox cbxLightestColourPreview, CircularPictureBox cbxBorderColourPreview, CircularPictureBox cbxAlternativeNormalTextColourPreview, CircularPictureBox cbxNormalTextColourPreview, CircularPictureBox cbxDisabledTextColourPreview, CircularPictureBox cbxFocusedTextColourPreview, CircularPictureBox cbxPressedTextColourPreview, CircularPictureBox cbxDisabledColourPreview, CircularPictureBox cbxLinkNormalColourPreview, CircularPictureBox cbxLinkFocusedColourPreview, CircularPictureBox cbxLinkHoverColourPreview, CircularPictureBox cbxLinkVisitedColourPreview, CircularPictureBox cbxCustomColourOnePreview, CircularPictureBox cbxCustomColourTwoPreview, CircularPictureBox cbxCustomColourThreePreview, CircularPictureBox cbxCustomColourFourPreview, CircularPictureBox cbxCustomColourFivePreview, CircularPictureBox cbxCustomTextColourOnePreview, CircularPictureBox cbxCustomTextColourTwoPreview, CircularPictureBox cbxCustomTextColourThreePreview, CircularPictureBox cbxCustomTextColourFourPreview, CircularPictureBox cbxCustomTextColourFivePreview, CircularPictureBox cbxMenuTextColourPreview, CircularPictureBox cbxStatusTextColourPreview, CircularPictureBox cbxRibbonTabTextColourPreview)
        {
            AllMergedColourSettingsManager colourSettingsManager = new AllMergedColourSettingsManager();

            #region Backup Values
            Color baseColour = colourSettingsManager.GetBaseColour(), darkColour = colourSettingsManager.GetDarkColour(), middleColour = colourSettingsManager.GetMediumColour(), lightColour = colourSettingsManager.GetLightColour(), lightestColour = colourSettingsManager.GetLightestColour(), borderColourPreview = colourSettingsManager.GetBorderColour(), alternativeNormalTextColourPreview = colourSettingsManager.GetAlternativeNormalTextColour(), normalTextColourPreview = colourSettingsManager.GetNormalTextColour(), disabledTextColourPreview = colourSettingsManager.GetDisabledTextColour(), focusedTextColourPreview = colourSettingsManager.GetFocusedTextColour(), pressedTextColourPreview = colourSettingsManager.GetPressedTextColour(), disabledColourPreview = colourSettingsManager.GetDisabledControlColour(), linkNormalColourPreview = colourSettingsManager.GetLinkNormalColour(), linkHoverColourPreview = colourSettingsManager.GetLinkHoverColour(), linkVisitedColourPreview = colourSettingsManager.GetLinkVisitedColour(), customColourOne = colourSettingsManager.GetCustomColourOne(), customColourTwo = colourSettingsManager.GetCustomColourTwo(), customColourThree = colourSettingsManager.GetCustomColourThree(), customColourFour = colourSettingsManager.GetCustomColourFour(), customColourFive = colourSettingsManager.GetCustomColourFive(), customTextColourOne = colourSettingsManager.GetCustomTextColourOne(), customTextColourTwo = colourSettingsManager.GetCustomTextColourTwo(), customTextColourThree = colourSettingsManager.GetCustomTextColourThree(), customTextColourFour = colourSettingsManager.GetCustomTextColourFour(), customTextColourFive = colourSettingsManager.GetCustomTextColourFive(), menuTextColour = colourSettingsManager.GetMenuTextColour(), statusTextColour = colourSettingsManager.GetStatusStripTextColour();
            #endregion

            // Reset back to white
            ResetColourDefinitions(cbxBaseColourPreview, cbxDarkColourPreview, cbxMiddleColourPreview, cbxLightColourPreview, cbxLightestColourPreview, cbxBorderColourPreview, cbxAlternativeNormalTextColourPreview, cbxNormalTextColourPreview, cbxDisabledTextColourPreview, cbxFocusedTextColourPreview, cbxPressedTextColourPreview, cbxDisabledColourPreview, cbxLinkNormalColourPreview, cbxLinkFocusedColourPreview, cbxLinkHoverColourPreview, cbxLinkVisitedColourPreview, cbxCustomColourOnePreview, cbxCustomColourTwoPreview, cbxCustomColourThreePreview, cbxCustomColourFourPreview, cbxCustomColourFivePreview, cbxCustomTextColourOnePreview, cbxCustomTextColourTwoPreview, cbxCustomTextColourThreePreview, cbxCustomTextColourFourPreview, cbxCustomTextColourFivePreview, cbxMenuTextColourPreview, cbxStatusTextColourPreview, cbxRibbonTabTextColourPreview);

            #region Set Settings

            #endregion

            cbxBaseColourPreview.BackColor = middleColour;

            cbxDarkColourPreview.BackColor = lightestColour;

            cbxMiddleColourPreview.BackColor = lightColour;

            cbxLightColourPreview.BackColor = baseColour;

            cbxLightestColourPreview.BackColor = darkColour;
        }

        public static void InvertColours(PictureBox baseColour, PictureBox darkColour, PictureBox middleColour, PictureBox lightColour, PictureBox lightestColour, PictureBox borderColour, PictureBox alternativeNormalTextColour, PictureBox normalTextColour, PictureBox disabledTextColour, PictureBox focusedTextColour, PictureBox pressedTextColour, PictureBox disabledColour, PictureBox linkNormalColour, PictureBox linkFocusedColour, PictureBox linkHoverColour, PictureBox linkVisitedColour, PictureBox customColourOne, PictureBox customColourTwo, PictureBox customColourThree, PictureBox customColourFour, PictureBox customColourFive, PictureBox customTextColourOne, PictureBox customTextColourTwo, PictureBox customTextColourThree, PictureBox customTextColourFour, PictureBox customTextColourFive, PictureBox menuTextColour, PictureBox statusTextColour, PictureBox ribbonTabTextColour)
        {
            AllMergedColourSettingsManager colourSettingsManager = new AllMergedColourSettingsManager();

            #region Backup Values
            Color baseColourPreview = colourSettingsManager.GetBaseColour(), darkColourPreview = colourSettingsManager.GetDarkColour(), middleColourPreview = colourSettingsManager.GetMediumColour(), lightColourPreview = colourSettingsManager.GetLightColour(), lightestColourPreview = colourSettingsManager.GetLightestColour(), borderColourPreview = colourSettingsManager.GetBorderColour(), alternativeNormalTextColourPreview = colourSettingsManager.GetAlternativeNormalTextColour(), normalTextColourPreview = colourSettingsManager.GetNormalTextColour(), disabledTextColourPreview = colourSettingsManager.GetDisabledTextColour(), focusedTextColourPreview = colourSettingsManager.GetFocusedTextColour(), pressedTextColourPreview = colourSettingsManager.GetPressedTextColour(), disabledColourPreview = colourSettingsManager.GetDisabledControlColour(), linkNormalColourPreview = colourSettingsManager.GetLinkNormalColour(), linkFocusedColourPreview = colourSettingsManager.GetLinkFocusedColour(), linkHoverColourPreview = colourSettingsManager.GetLinkHoverColour(), linkVisitedColourPreview = colourSettingsManager.GetLinkVisitedColour(), customColourOnePreview = colourSettingsManager.GetCustomColourOne(), customColourTwoPreview = colourSettingsManager.GetCustomColourTwo(), customColourThreePreview = colourSettingsManager.GetCustomColourThree(), customColourFourPreview = colourSettingsManager.GetCustomColourFour(), customColourFivePreview = colourSettingsManager.GetCustomColourFive(), customTextColourOnePreview = colourSettingsManager.GetCustomTextColourOne(), customTextColourTwoPreview = colourSettingsManager.GetCustomTextColourTwo(), customTextColourThreePreview = colourSettingsManager.GetCustomTextColourThree(), customTextColourFourPreview = colourSettingsManager.GetCustomTextColourFour(), customTextColourFivePreview = colourSettingsManager.GetCustomTextColourFive(), menuTextColourPreview = colourSettingsManager.GetMenuTextColour(), statusTextColourPreview = colourSettingsManager.GetStatusStripTextColour(), ribbonTabTextColourPreview = colourSettingsManager.GetRibbonTabTextColour();
            #endregion

            ResetColourDefinitions(baseColour, darkColour, middleColour, lightColour, lightestColour, borderColour, alternativeNormalTextColour, normalTextColour, disabledTextColour, focusedTextColour, pressedTextColour, disabledColour, linkNormalColour, linkFocusedColour, linkHoverColour, linkVisitedColour, customColourOne, customColourTwo, customColourThree, customColourFour, customColourFive, customTextColourOne, customTextColourTwo, customTextColourThree, customTextColourFour, customTextColourFive, menuTextColour, statusTextColour, ribbonTabTextColour);
        }

        public static void RevertColours(CircularPictureBox cbxBaseColourPreview, CircularPictureBox cbxDarkColourPreview, CircularPictureBox cbxMiddleColourPreview, CircularPictureBox cbxLightColourPreview, CircularPictureBox cbxLightestColourPreview, CircularPictureBox cbxBorderColourPreview, CircularPictureBox cbxAlternativeNormalTextColourPreview, CircularPictureBox cbxNormalTextColourPreview, CircularPictureBox cbxDisabledTextColourPreview, CircularPictureBox cbxFocusedTextColourPreview, CircularPictureBox cbxPressedTextColourPreview, CircularPictureBox cbxDisabledColourPreview, CircularPictureBox cbxLinkNormalColourPreview, CircularPictureBox cbxLinkFocusedColourPreview, CircularPictureBox cbxLinkHoverColourPreview, CircularPictureBox cbxLinkVisitedColourPreview, CircularPictureBox cbxCustomColourOnePreview, CircularPictureBox cbxCustomColourTwoPreview, CircularPictureBox cbxCustomColourThreePreview, CircularPictureBox cbxCustomColourFourPreview, CircularPictureBox cbxCustomColourFivePreview, CircularPictureBox cbxCustomTextColourOnePreview, CircularPictureBox cbxCustomTextColourTwoPreview, CircularPictureBox cbxCustomTextColourThreePreview, CircularPictureBox cbxCustomTextColourFourPreview, CircularPictureBox cbxCustomTextColourFivePreview, CircularPictureBox cbxMenuTextColourPreview, CircularPictureBox cbxStatusTextColourPreview, CircularPictureBox cbxRibbonTabTextColourPreview)
        {
            AllMergedColourSettingsManager colourSettingsManager = new AllMergedColourSettingsManager();

            #region Backup Values
            Color baseColour = colourSettingsManager.GetBaseColour(), darkColour = colourSettingsManager.GetDarkColour(), middleColour = colourSettingsManager.GetMediumColour(), lightColour = colourSettingsManager.GetLightColour(), lightestColour = colourSettingsManager.GetLightestColour(), borderColourPreview = colourSettingsManager.GetBorderColour(), alternativeNormalTextColourPreview = colourSettingsManager.GetAlternativeNormalTextColour(), normalTextColourPreview = colourSettingsManager.GetNormalTextColour(), disabledTextColourPreview = colourSettingsManager.GetDisabledTextColour(), focusedTextColourPreview = colourSettingsManager.GetFocusedTextColour(), pressedTextColourPreview = colourSettingsManager.GetPressedTextColour(), disabledColourPreview = colourSettingsManager.GetDisabledControlColour(), linkNormalColourPreview = colourSettingsManager.GetLinkNormalColour(), linkHoverColourPreview = colourSettingsManager.GetLinkHoverColour(), linkVisitedColourPreview = colourSettingsManager.GetLinkVisitedColour(), customColourOne = colourSettingsManager.GetCustomColourOne(), customColourTwo = colourSettingsManager.GetCustomColourTwo(), customColourThree = colourSettingsManager.GetCustomColourThree(), customColourFour = colourSettingsManager.GetCustomColourFour(), customColourFive = colourSettingsManager.GetCustomColourFive(), customTextColourOne = colourSettingsManager.GetCustomTextColourOne(), customTextColourTwo = colourSettingsManager.GetCustomTextColourTwo(), customTextColourThree = colourSettingsManager.GetCustomTextColourThree(), customTextColourFour = colourSettingsManager.GetCustomTextColourFour(), customTextColourFive = colourSettingsManager.GetCustomTextColourFive(), menuTextColour = colourSettingsManager.GetMenuTextColour(), statusTextColour = colourSettingsManager.GetStatusStripTextColour();
            #endregion

            // Reset back to white
            ResetColourDefinitions(cbxBaseColourPreview, cbxDarkColourPreview, cbxMiddleColourPreview, cbxLightColourPreview, cbxLightestColourPreview, cbxBorderColourPreview, cbxAlternativeNormalTextColourPreview, cbxNormalTextColourPreview, cbxDisabledTextColourPreview, cbxFocusedTextColourPreview, cbxPressedTextColourPreview, cbxDisabledColourPreview, cbxLinkNormalColourPreview, cbxLinkFocusedColourPreview, cbxLinkHoverColourPreview, cbxLinkVisitedColourPreview, cbxCustomColourOnePreview, cbxCustomColourTwoPreview, cbxCustomColourThreePreview, cbxCustomColourFourPreview, cbxCustomColourFivePreview, cbxCustomTextColourOnePreview, cbxCustomTextColourTwoPreview, cbxCustomTextColourThreePreview, cbxCustomTextColourFourPreview, cbxCustomTextColourFivePreview, cbxMenuTextColourPreview, cbxStatusTextColourPreview, cbxRibbonTabTextColourPreview);

            cbxBaseColourPreview.BackColor = lightColour;

            cbxDarkColourPreview.BackColor = lightestColour;

            cbxMiddleColourPreview.BackColor = baseColour;

            cbxLightColourPreview.BackColor = middleColour;

            cbxLightestColourPreview.BackColor = darkColour;
        }

        public static void RevertColours(PictureBox baseColour, PictureBox darkColour, PictureBox middleColour, PictureBox lightColour, PictureBox lightestColour, PictureBox borderColour, PictureBox alternativeNormalTextColour, PictureBox normalTextColour, PictureBox disabledTextColour, PictureBox focusedTextColour, PictureBox pressedTextColour, PictureBox disabledColour, PictureBox linkNormalColour, PictureBox linkFocusedColour, PictureBox linkHoverColour, PictureBox linkVisitedColour, PictureBox customColourOne, PictureBox customColourTwo, PictureBox customColourThree, PictureBox customColourFour, PictureBox customColourFive, PictureBox customTextColourOne, PictureBox customTextColourTwo, PictureBox customTextColourThree, PictureBox customTextColourFour, PictureBox customTextColourFive, PictureBox menuTextColour, PictureBox statusTextColour, PictureBox ribbonTabTextColour)
        {
            AllMergedColourSettingsManager colourSettingsManager = new AllMergedColourSettingsManager();

            #region Backup Values
            Color baseColourPreview = colourSettingsManager.GetBaseColour(), darkColourPreview = colourSettingsManager.GetDarkColour(), middleColourPreview = colourSettingsManager.GetMediumColour(), lightColourPreview = colourSettingsManager.GetLightColour(), lightestColourPreview = colourSettingsManager.GetLightestColour(), borderColourPreview = colourSettingsManager.GetBorderColour(), alternativeNormalTextColourPreview = colourSettingsManager.GetAlternativeNormalTextColour(), normalTextColourPreview = colourSettingsManager.GetNormalTextColour(), disabledTextColourPreview = colourSettingsManager.GetDisabledTextColour(), focusedTextColourPreview = colourSettingsManager.GetFocusedTextColour(), pressedTextColourPreview = colourSettingsManager.GetPressedTextColour(), disabledColourPreview = colourSettingsManager.GetDisabledControlColour(), linkNormalColourPreview = colourSettingsManager.GetLinkNormalColour(), linkHoverColourPreview = colourSettingsManager.GetLinkHoverColour(), linkVisitedColourPreview = colourSettingsManager.GetLinkVisitedColour(), customColourOnePreview = colourSettingsManager.GetCustomColourOne(), customColourTwoPreview = colourSettingsManager.GetCustomColourTwo(), customColourThreePreview = colourSettingsManager.GetCustomColourThree(), customColourFourPreview = colourSettingsManager.GetCustomColourFour(), customColourFivePreview = colourSettingsManager.GetCustomColourFive(), customTextColourOnePreview = colourSettingsManager.GetCustomTextColourOne(), customTextColourTwoPreview = colourSettingsManager.GetCustomTextColourTwo(), customTextColourThreePreview = colourSettingsManager.GetCustomTextColourThree(), customTextColourFourPreview = colourSettingsManager.GetCustomTextColourFour(), customTextColourFivePreview = colourSettingsManager.GetCustomTextColourFive(), menuTextColourPreview = colourSettingsManager.GetMenuTextColour(), statusTextColourPreview = colourSettingsManager.GetStatusStripTextColour();
            #endregion

            ResetColourDefinitions(baseColour, darkColour, middleColour, lightColour, lightestColour, borderColour, alternativeNormalTextColour, normalTextColour, disabledTextColour, focusedTextColour, pressedTextColour, disabledColour, linkNormalColour, linkFocusedColour, linkHoverColour, linkVisitedColour, customColourOne, customColourTwo, customColourThree, customColourFour, customColourFive, customTextColourOne, customTextColourTwo, customTextColourThree, customTextColourFour, customTextColourFive, menuTextColour, statusTextColour, ribbonTabTextColour);
        }

        /// <summary>
        /// Updates the colour.
        /// </summary>
        /// <param name="colourPreview">The colour preview.</param>
        /// <param name="alpha">The alpha.</param>
        /// <param name="red">The red.</param>
        /// <param name="green">The green.</param>
        /// <param name="blue">The blue.</param>
        public static void UpdateColour(PictureBox colourPreview, int alpha, int red, int green, int blue)
        {
            colourPreview.BackColor = Color.FromArgb(alpha, red, green, blue);
        }
        #endregion
    }
}