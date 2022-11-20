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

namespace Krypton.Toolkit.Suite.Extended.Core
{
    public class ColourSettingsManagementEngine
    {
        #region Constructor
        public ColourSettingsManagementEngine()
        {

        }
        #endregion

        #region Methods        
        /// <summary>
        /// Sets the colour settings as colour.
        /// </summary>
        /// <param name="colourType">Type of the colour.</param>
        /// <param name="colour">The colour.</param>
        public static void SetColourSettingsAsColour(AllAvailableColourTypes colourType, Color colour)
        {
            AllMergedColourSettingsManager colourSettingsManager = new AllMergedColourSettingsManager();

            switch (colourType)
            {
                case AllAvailableColourTypes.AlternativeNormalTextColour:
                    colourSettingsManager.SetAlternativeNormalTextColour(colour);
                    break;
                case AllAvailableColourTypes.BaseColour:
                    colourSettingsManager.SetBaseColour(colour);
                    break;
                case AllAvailableColourTypes.BorderColour:
                    colourSettingsManager.SetBorderColour(colour);
                    break;
                case AllAvailableColourTypes.CustomColourOne:
                    colourSettingsManager.SetCustomColourOne(colour);
                    break;
                case AllAvailableColourTypes.CustomColourTwo:
                    colourSettingsManager.SetCustomColourTwo(colour);
                    break;
                case AllAvailableColourTypes.CustomColourThree:
                    colourSettingsManager.SetCustomColourThree(colour);
                    break;
                case AllAvailableColourTypes.CustomColourFour:
                    colourSettingsManager.SetCustomColourFour(colour);
                    break;
                case AllAvailableColourTypes.CustomColourFive:
                    colourSettingsManager.SetCustomColourFive(colour);
                    break;
                case AllAvailableColourTypes.CustomColourSix:
                    colourSettingsManager.SetCustomColourSix(colour);
                    break;
                case AllAvailableColourTypes.CustomTextColourOne:
                    colourSettingsManager.SetCustomTextColourOne(colour);
                    break;
                case AllAvailableColourTypes.CustomTextColourTwo:
                    colourSettingsManager.SetCustomTextColourTwo(colour);
                    break;
                case AllAvailableColourTypes.CustomTextColourThree:
                    colourSettingsManager.SetCustomTextColourThree(colour);
                    break;
                case AllAvailableColourTypes.CustomTextColourFour:
                    colourSettingsManager.SetCustomTextColourFour(colour);
                    break;
                case AllAvailableColourTypes.CustomTextColourFive:
                    colourSettingsManager.SetCustomTextColourFive(colour);
                    break;
                case AllAvailableColourTypes.CustomTextColourSix:
                    colourSettingsManager.SetCustomTextColourSix(colour);
                    break;
                case AllAvailableColourTypes.DarkestColour:
                    colourSettingsManager.SetDarkColour(colour);
                    break;
                case AllAvailableColourTypes.DisabledControlColour:
                    colourSettingsManager.SetDisabledControlColour(colour);
                    break;
                case AllAvailableColourTypes.DisabledTextColour:
                    colourSettingsManager.SetDisabledTextColour(colour);
                    break;
                case AllAvailableColourTypes.FocusedTextColour:
                    colourSettingsManager.SetFocusedTextColour(colour);
                    break;
                case AllAvailableColourTypes.LightColour:
                    colourSettingsManager.SetLightColour(colour);
                    break;
                case AllAvailableColourTypes.LightestColour:
                    colourSettingsManager.SetLightestColour(colour);
                    break;
                case AllAvailableColourTypes.LinkDisabledColour:
                    colourSettingsManager.SetLinkDisabledColour(colour);
                    break;
                case AllAvailableColourTypes.LinkHoverColour:
                    colourSettingsManager.SetLinkHoverColour(colour);
                    break;
                case AllAvailableColourTypes.LinkNormalColour:
                    colourSettingsManager.SetLinkNormalColour(colour);
                    break;
                case AllAvailableColourTypes.LinkVisitedColour:
                    colourSettingsManager.SetLinkVisitedColour(colour);
                    break;
                case AllAvailableColourTypes.MediumColour:
                    colourSettingsManager.SetMediumColour(colour);
                    break;
                case AllAvailableColourTypes.MenuTextColour:
                    colourSettingsManager.SetMenuTextColour(colour);
                    break;
                case AllAvailableColourTypes.NormalTextColour:
                    colourSettingsManager.SetNormalTextColour(colour);
                    break;
                case AllAvailableColourTypes.PressedTextColour:
                    colourSettingsManager.SetPressedTextColour(colour);
                    break;
                case AllAvailableColourTypes.StatusTextColour:
                    colourSettingsManager.SetStatusStripTextColour(colour);
                    break;
            }
        }

        public static void SetColourSettingsAsString(AllAvailableColourTypes colourType, Color colour)
        {
            ColourStringSettingsManager colourStringSettingsManager = new ColourStringSettingsManager();

            switch (colourType)
            {
                case AllAvailableColourTypes.AlternativeNormalTextColour:
                    colourStringSettingsManager.SetAlternativeNormalTextColour(ColourFormatting.FormatColourAsString(colour));
                    break;
                case AllAvailableColourTypes.BaseColour:
                    colourStringSettingsManager.SetBaseColour(ColourFormatting.FormatColourAsString(colour));
                    break;
                case AllAvailableColourTypes.BorderColour:
                    colourStringSettingsManager.SetBorderColour(ColourFormatting.FormatColourAsString(colour));
                    break;
                case AllAvailableColourTypes.CustomColourOne:
                    colourStringSettingsManager.SetCustomColourOne(ColourFormatting.FormatColourAsString(colour));
                    break;
                case AllAvailableColourTypes.CustomColourTwo:
                    colourStringSettingsManager.SetCustomColourTwo(ColourFormatting.FormatColourAsString(colour));
                    break;
                case AllAvailableColourTypes.CustomColourThree:
                    colourStringSettingsManager.SetCustomColourThree(ColourFormatting.FormatColourAsString(colour));
                    break;
                case AllAvailableColourTypes.CustomColourFour:
                    colourStringSettingsManager.SetCustomColourFour(ColourFormatting.FormatColourAsString(colour));
                    break;
                case AllAvailableColourTypes.CustomColourFive:
                    colourStringSettingsManager.SetCustomColourFive(ColourFormatting.FormatColourAsString(colour));
                    break;
                case AllAvailableColourTypes.CustomColourSix:
                    colourStringSettingsManager.SetCustomColourSix(ColourFormatting.FormatColourAsRGBString(colour));
                    break;
                case AllAvailableColourTypes.CustomTextColourOne:
                    colourStringSettingsManager.SetCustomTextColourOne(ColourFormatting.FormatColourAsString(colour));
                    break;
                case AllAvailableColourTypes.CustomTextColourTwo:
                    colourStringSettingsManager.SetCustomTextColourTwo(ColourFormatting.FormatColourAsString(colour));
                    break;
                case AllAvailableColourTypes.CustomTextColourThree:
                    colourStringSettingsManager.SetCustomTextColourThree(ColourFormatting.FormatColourAsString(colour));
                    break;
                case AllAvailableColourTypes.CustomTextColourFour:
                    colourStringSettingsManager.SetCustomTextColourFour(ColourFormatting.FormatColourAsString(colour));
                    break;
                case AllAvailableColourTypes.CustomTextColourFive:
                    colourStringSettingsManager.SetCustomTextColourFive(ColourFormatting.FormatColourAsString(colour));
                    break;
                case AllAvailableColourTypes.CustomTextColourSix:
                    colourStringSettingsManager.SetCustomTextColourSix(ColourFormatting.FormatColourAsRGBString(colour));
                    break;
                case AllAvailableColourTypes.DarkestColour:
                    colourStringSettingsManager.SetDarkestColour(ColourFormatting.FormatColourAsString(colour));
                    break;
                case AllAvailableColourTypes.DisabledControlColour:
                    colourStringSettingsManager.SetDisabledColour(ColourFormatting.FormatColourAsString(colour));
                    break;
                case AllAvailableColourTypes.DisabledTextColour:
                    colourStringSettingsManager.SetDisabledTextColour(ColourFormatting.FormatColourAsString(colour));
                    break;
                case AllAvailableColourTypes.FocusedTextColour:
                    colourStringSettingsManager.SetFocusedTextColour(ColourFormatting.FormatColourAsString(colour));
                    break;
                case AllAvailableColourTypes.LightColour:
                    colourStringSettingsManager.SetLightColour(ColourFormatting.FormatColourAsString(colour));
                    break;
                case AllAvailableColourTypes.LightestColour:
                    colourStringSettingsManager.SetLightestColour(ColourFormatting.FormatColourAsString(colour));
                    break;
                case AllAvailableColourTypes.LinkDisabledColour:
                    colourStringSettingsManager.SetLinkDisabledColour(ColourFormatting.FormatColourAsString(colour));
                    break;
                case AllAvailableColourTypes.LinkHoverColour:
                    colourStringSettingsManager.SetLinkHoverColour(ColourFormatting.FormatColourAsString(colour));
                    break;
                case AllAvailableColourTypes.LinkNormalColour:
                    colourStringSettingsManager.SetLinkNormalColour(ColourFormatting.FormatColourAsString(colour));
                    break;
                case AllAvailableColourTypes.LinkVisitedColour:
                    colourStringSettingsManager.SetLinkVisitedColour(ColourFormatting.FormatColourAsString(colour));
                    break;
                case AllAvailableColourTypes.MediumColour:
                    colourStringSettingsManager.SetMediumColour(ColourFormatting.FormatColourAsString(colour));
                    break;
                case AllAvailableColourTypes.MenuTextColour:
                    colourStringSettingsManager.SetMenuTextColour(ColourFormatting.FormatColourAsString(colour));
                    break;
                case AllAvailableColourTypes.NormalTextColour:
                    colourStringSettingsManager.SetNormalTextColour(ColourFormatting.FormatColourAsString(colour));
                    break;
                case AllAvailableColourTypes.PressedTextColour:
                    colourStringSettingsManager.SetPressedTextColour(ColourFormatting.FormatColourAsString(colour));
                    break;
                case AllAvailableColourTypes.StatusTextColour:
                    colourStringSettingsManager.SetStatusTextColour(ColourFormatting.FormatColourAsString(colour));
                    break;
            }
        }

        /// <summary>
        /// Sets the basic colours.
        /// </summary>
        /// <param name="basicPaletteColourDefinition">The basic palette colour definition.</param>
        /// <param name="colour">The colour.</param>
        public static void SetBasicColours(BasicPaletteColourDefinitions basicPaletteColourDefinition, Color colour)
        {
            BasicColourSettingsManager colourSettingsManager = new BasicColourSettingsManager();

            switch (basicPaletteColourDefinition)
            {
                case BasicPaletteColourDefinitions.BaseColour:
                    colourSettingsManager.SetBaseColour(colour);
                    break;
                case BasicPaletteColourDefinitions.DarkestColour:
                    colourSettingsManager.SetDarkColour(colour);
                    break;
                case BasicPaletteColourDefinitions.MiddleColour:
                    colourSettingsManager.SetMediumColour(colour);
                    break;
                case BasicPaletteColourDefinitions.LightColour:
                    colourSettingsManager.SetLightColour(colour);
                    break;
                case BasicPaletteColourDefinitions.LightestColour:
                    colourSettingsManager.SetLightestColour(colour);
                    break;
            }
        }

        /// <summary>
        /// Retrieves the selected colour.
        /// </summary>
        /// <param name="colourType">Type of the colour.</param>
        /// <returns>The chosen colour.</returns>
        public static Color RetrieveSelectedColour(AllAvailableColourTypes colourType)
        {
            Color tempColour = Color.FromArgb(0, 0, 0, 0);

            AllMergedColourSettingsManager colourSettingsManager = new AllMergedColourSettingsManager();

            try
            {
                switch (colourType)
                {
                    case AllAvailableColourTypes.AlternativeNormalTextColour:
                        tempColour = colourSettingsManager.GetAlternativeNormalTextColour();
                        break;
                    case AllAvailableColourTypes.BaseColour:
                        tempColour = colourSettingsManager.GetBaseColour();
                        break;
                    case AllAvailableColourTypes.BorderColour:
                        tempColour = colourSettingsManager.GetBorderColour();
                        break;
                    case AllAvailableColourTypes.CustomColourOne:
                        tempColour = colourSettingsManager.GetCustomColourOne();
                        break;
                    case AllAvailableColourTypes.CustomColourTwo:
                        tempColour = colourSettingsManager.GetCustomColourTwo();
                        break;
                    case AllAvailableColourTypes.CustomColourThree:
                        tempColour = colourSettingsManager.GetCustomColourThree();
                        break;
                    case AllAvailableColourTypes.CustomColourFour:
                        tempColour = colourSettingsManager.GetCustomColourFour();
                        break;
                    case AllAvailableColourTypes.CustomColourFive:
                        tempColour = colourSettingsManager.GetCustomColourFive();
                        break;
                    case AllAvailableColourTypes.CustomColourSix:
                        tempColour = colourSettingsManager.GetCustomColourSix();
                        break;
                    case AllAvailableColourTypes.CustomTextColourOne:
                        tempColour = colourSettingsManager.GetCustomTextColourOne();
                        break;
                    case AllAvailableColourTypes.CustomTextColourTwo:
                        tempColour = colourSettingsManager.GetCustomTextColourTwo();
                        break;
                    case AllAvailableColourTypes.CustomTextColourThree:
                        tempColour = colourSettingsManager.GetCustomTextColourThree();
                        break;
                    case AllAvailableColourTypes.CustomTextColourFour:
                        tempColour = colourSettingsManager.GetCustomTextColourFour();
                        break;
                    case AllAvailableColourTypes.CustomTextColourFive:
                        tempColour = colourSettingsManager.GetCustomTextColourFive();
                        break;
                    case AllAvailableColourTypes.CustomTextColourSix:
                        tempColour = colourSettingsManager.GetCustomTextColourSix();
                        break;
                    case AllAvailableColourTypes.DarkestColour:
                        tempColour = colourSettingsManager.GetDarkColour();
                        break;
                    case AllAvailableColourTypes.DisabledControlColour:
                        tempColour = colourSettingsManager.GetDisabledControlColour();
                        break;
                    case AllAvailableColourTypes.DisabledTextColour:
                        tempColour = colourSettingsManager.GetDisabledTextColour();
                        break;
                    case AllAvailableColourTypes.FocusedTextColour:
                        tempColour = colourSettingsManager.GetFocusedTextColour();
                        break;
                    case AllAvailableColourTypes.LightColour:
                        tempColour = colourSettingsManager.GetLightColour();
                        break;
                    case AllAvailableColourTypes.LightestColour:
                        tempColour = colourSettingsManager.GetLightestColour();
                        break;
                    case AllAvailableColourTypes.LinkDisabledColour:
                        tempColour = colourSettingsManager.GetLinkDisabledColour();
                        break;
                    case AllAvailableColourTypes.LinkHoverColour:
                        tempColour = colourSettingsManager.GetLinkHoverColour();
                        break;
                    case AllAvailableColourTypes.LinkNormalColour:
                        tempColour = colourSettingsManager.GetLinkNormalColour();
                        break;
                    case AllAvailableColourTypes.LinkVisitedColour:
                        tempColour = colourSettingsManager.GetLinkVisitedColour();
                        break;
                    case AllAvailableColourTypes.MediumColour:
                        tempColour = colourSettingsManager.GetMediumColour();
                        break;
                    case AllAvailableColourTypes.MenuTextColour:
                        tempColour = colourSettingsManager.GetMenuTextColour();
                        break;
                    case AllAvailableColourTypes.NormalTextColour:
                        tempColour = colourSettingsManager.GetNormalTextColour();
                        break;
                    case AllAvailableColourTypes.PressedTextColour:
                        tempColour = colourSettingsManager.GetPressedTextColour();
                        break;
                    case AllAvailableColourTypes.StatusTextColour:
                        tempColour = colourSettingsManager.GetStatusStripTextColour();
                        break;
                    default:
                        tempColour = Color.FromArgb(0, 0, 0, 0);
                        break;
                }
            }
            catch (Exception exc)
            {
                KryptonMessageBox.Show($"An unexpected error has occurred: { exc.Message }", "Retrieving Settings Failed", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error);

                tempColour = Color.FromArgb(0, 0, 0, 0);
            }

            return tempColour;
        }

        public static void RetrieveAllColourSettingsAsColour()
        {
            AllMergedColourSettingsManager colourSettingsManager = new AllMergedColourSettingsManager();

            try
            {
                // Note: Complete this
            }
            catch (Exception exc)
            {
                KryptonMessageBox.Show($"An unexpected error has occurred: { exc.Message }", "Retrieving Settings Failed", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error);
            }
        }

        public static void SaveSettings(SettingTypes settingType)
        {
            #region Variables
            AllMergedColourSettingsManager colourSettingsManager = new AllMergedColourSettingsManager();

            //ColourStringSettingsManager colourStringSettingsManager = new ColourStringSettingsManager();

            ColourIntegerSettingsManager colourIntegerSettingsManager = new ColourIntegerSettingsManager();

            GlobalBooleanSettingsManager globalBooleanSettingsManager = new GlobalBooleanSettingsManager();

            GlobalStringSettingsManager globalStringSettingsManager = new GlobalStringSettingsManager();
            #endregion

            try
            {
                switch (settingType)
                {
                    case SettingTypes.Boolean:
                        globalBooleanSettingsManager.SaveBooleanSettings();
                        break;
                    case SettingTypes.Colour:
                        colourSettingsManager.SaveAllMergedColourSettings();
                        break;
                    case SettingTypes.ColourString:
                        //colourStringSettingsManager.SaveColourStringSettings();
                        break;
                    case SettingTypes.ColourInteger:
                        colourIntegerSettingsManager.SaveColourIntegerSettings();
                        break;
                    case SettingTypes.String:
                        globalStringSettingsManager.SaveStringSettings();
                        break;
                    case SettingTypes.Integer:
                        colourIntegerSettingsManager.SaveColourIntegerSettings();
                        break;
                }
            }
            catch (Exception exc)
            {
                ExceptionHandler.CaptureException(exc, methodSignature: Helpers.GetCurrentMethod());
            }
        }
        #endregion
    }
}