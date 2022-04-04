#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
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
                case AllAvailableColourTypes.ALTERNATIVENORMALTEXTCOLOUR:
                    colourSettingsManager.SetAlternativeNormalTextColour(colour);
                    break;
                case AllAvailableColourTypes.BASECOLOUR:
                    colourSettingsManager.SetBaseColour(colour);
                    break;
                case AllAvailableColourTypes.BORDERCOLOUR:
                    colourSettingsManager.SetBorderColour(colour);
                    break;
                case AllAvailableColourTypes.CUSTOMCOLOURONE:
                    colourSettingsManager.SetCustomColourOne(colour);
                    break;
                case AllAvailableColourTypes.CUSTOMCOLOURTWO:
                    colourSettingsManager.SetCustomColourTwo(colour);
                    break;
                case AllAvailableColourTypes.CUSTOMCOLOURTHREE:
                    colourSettingsManager.SetCustomColourThree(colour);
                    break;
                case AllAvailableColourTypes.CUSTOMCOLOURFOUR:
                    colourSettingsManager.SetCustomColourFour(colour);
                    break;
                case AllAvailableColourTypes.CUSTOMCOLOURFIVE:
                    colourSettingsManager.SetCustomColourFive(colour);
                    break;
                case AllAvailableColourTypes.CUSTOMCOLOURSIX:
                    colourSettingsManager.SetCustomColourSix(colour);
                    break;
                case AllAvailableColourTypes.CUSTOMTEXTCOLOURONE:
                    colourSettingsManager.SetCustomTextColourOne(colour);
                    break;
                case AllAvailableColourTypes.CUSTOMTEXTCOLOURTWO:
                    colourSettingsManager.SetCustomTextColourTwo(colour);
                    break;
                case AllAvailableColourTypes.CUSTOMTEXTCOLOURTHREE:
                    colourSettingsManager.SetCustomTextColourThree(colour);
                    break;
                case AllAvailableColourTypes.CUSTOMTEXTCOLOURFOUR:
                    colourSettingsManager.SetCustomTextColourFour(colour);
                    break;
                case AllAvailableColourTypes.CUSTOMTEXTCOLOURFIVE:
                    colourSettingsManager.SetCustomTextColourFive(colour);
                    break;
                case AllAvailableColourTypes.CUSTOMTEXTCOLOURSIX:
                    colourSettingsManager.SetCustomTextColourSix(colour);
                    break;
                case AllAvailableColourTypes.DARKESTCOLOUR:
                    colourSettingsManager.SetDarkColour(colour);
                    break;
                case AllAvailableColourTypes.DISABLEDCONTROLCOLOUR:
                    colourSettingsManager.SetDisabledControlColour(colour);
                    break;
                case AllAvailableColourTypes.DISABLEDTEXTCOLOUR:
                    colourSettingsManager.SetDisabledTextColour(colour);
                    break;
                case AllAvailableColourTypes.FOCUSEDTEXTCOLOUR:
                    colourSettingsManager.SetFocusedTextColour(colour);
                    break;
                case AllAvailableColourTypes.LIGHTCOLOUR:
                    colourSettingsManager.SetLightColour(colour);
                    break;
                case AllAvailableColourTypes.LIGHTESTCOLOUR:
                    colourSettingsManager.SetLightestColour(colour);
                    break;
                case AllAvailableColourTypes.LINKDISABLEDCOLOUR:
                    colourSettingsManager.SetLinkDisabledColour(colour);
                    break;
                case AllAvailableColourTypes.LINKHOVERCOLOUR:
                    colourSettingsManager.SetLinkHoverColour(colour);
                    break;
                case AllAvailableColourTypes.LINKNORMALCOLOUR:
                    colourSettingsManager.SetLinkNormalColour(colour);
                    break;
                case AllAvailableColourTypes.LINKVISITEDCOLOUR:
                    colourSettingsManager.SetLinkVisitedColour(colour);
                    break;
                case AllAvailableColourTypes.MEDIUMCOLOUR:
                    colourSettingsManager.SetMediumColour(colour);
                    break;
                case AllAvailableColourTypes.MENUTEXTCOLOUR:
                    colourSettingsManager.SetMenuTextColour(colour);
                    break;
                case AllAvailableColourTypes.NORMALTEXTCOLOUR:
                    colourSettingsManager.SetNormalTextColour(colour);
                    break;
                case AllAvailableColourTypes.PRESSEDTEXTCOLOUR:
                    colourSettingsManager.SetPressedTextColour(colour);
                    break;
                case AllAvailableColourTypes.STATUSTEXTCOLOUR:
                    colourSettingsManager.SetStatusStripTextColour(colour);
                    break;
                default:
                    break;
            }
        }

        public static void SetColourSettingsAsString(AllAvailableColourTypes colourType, Color colour)
        {
            ColourStringSettingsManager colourStringSettingsManager = new ColourStringSettingsManager();

            switch (colourType)
            {
                case AllAvailableColourTypes.ALTERNATIVENORMALTEXTCOLOUR:
                    colourStringSettingsManager.SetAlternativeNormalTextColour(ColourFormatting.FormatColourAsString(colour));
                    break;
                case AllAvailableColourTypes.BASECOLOUR:
                    colourStringSettingsManager.SetBaseColour(ColourFormatting.FormatColourAsString(colour));
                    break;
                case AllAvailableColourTypes.BORDERCOLOUR:
                    colourStringSettingsManager.SetBorderColour(ColourFormatting.FormatColourAsString(colour));
                    break;
                case AllAvailableColourTypes.CUSTOMCOLOURONE:
                    colourStringSettingsManager.SetCustomColourOne(ColourFormatting.FormatColourAsString(colour));
                    break;
                case AllAvailableColourTypes.CUSTOMCOLOURTWO:
                    colourStringSettingsManager.SetCustomColourTwo(ColourFormatting.FormatColourAsString(colour));
                    break;
                case AllAvailableColourTypes.CUSTOMCOLOURTHREE:
                    colourStringSettingsManager.SetCustomColourThree(ColourFormatting.FormatColourAsString(colour));
                    break;
                case AllAvailableColourTypes.CUSTOMCOLOURFOUR:
                    colourStringSettingsManager.SetCustomColourFour(ColourFormatting.FormatColourAsString(colour));
                    break;
                case AllAvailableColourTypes.CUSTOMCOLOURFIVE:
                    colourStringSettingsManager.SetCustomColourFive(ColourFormatting.FormatColourAsString(colour));
                    break;
                case AllAvailableColourTypes.CUSTOMCOLOURSIX:
                    colourStringSettingsManager.SetCustomColourSix(ColourFormatting.FormatColourAsRGBString(colour));
                    break;
                case AllAvailableColourTypes.CUSTOMTEXTCOLOURONE:
                    colourStringSettingsManager.SetCustomTextColourOne(ColourFormatting.FormatColourAsString(colour));
                    break;
                case AllAvailableColourTypes.CUSTOMTEXTCOLOURTWO:
                    colourStringSettingsManager.SetCustomTextColourTwo(ColourFormatting.FormatColourAsString(colour));
                    break;
                case AllAvailableColourTypes.CUSTOMTEXTCOLOURTHREE:
                    colourStringSettingsManager.SetCustomTextColourThree(ColourFormatting.FormatColourAsString(colour));
                    break;
                case AllAvailableColourTypes.CUSTOMTEXTCOLOURFOUR:
                    colourStringSettingsManager.SetCustomTextColourFour(ColourFormatting.FormatColourAsString(colour));
                    break;
                case AllAvailableColourTypes.CUSTOMTEXTCOLOURFIVE:
                    colourStringSettingsManager.SetCustomTextColourFive(ColourFormatting.FormatColourAsString(colour));
                    break;
                case AllAvailableColourTypes.CUSTOMTEXTCOLOURSIX:
                    colourStringSettingsManager.SetCustomTextColourSix(ColourFormatting.FormatColourAsRGBString(colour));
                    break;
                case AllAvailableColourTypes.DARKESTCOLOUR:
                    colourStringSettingsManager.SetDarkestColour(ColourFormatting.FormatColourAsString(colour));
                    break;
                case AllAvailableColourTypes.DISABLEDCONTROLCOLOUR:
                    colourStringSettingsManager.SetDisabledColour(ColourFormatting.FormatColourAsString(colour));
                    break;
                case AllAvailableColourTypes.DISABLEDTEXTCOLOUR:
                    colourStringSettingsManager.SetDisabledTextColour(ColourFormatting.FormatColourAsString(colour));
                    break;
                case AllAvailableColourTypes.FOCUSEDTEXTCOLOUR:
                    colourStringSettingsManager.SetFocusedTextColour(ColourFormatting.FormatColourAsString(colour));
                    break;
                case AllAvailableColourTypes.LIGHTCOLOUR:
                    colourStringSettingsManager.SetLightColour(ColourFormatting.FormatColourAsString(colour));
                    break;
                case AllAvailableColourTypes.LIGHTESTCOLOUR:
                    colourStringSettingsManager.SetLightestColour(ColourFormatting.FormatColourAsString(colour));
                    break;
                case AllAvailableColourTypes.LINKDISABLEDCOLOUR:
                    colourStringSettingsManager.SetLinkDisabledColour(ColourFormatting.FormatColourAsString(colour));
                    break;
                case AllAvailableColourTypes.LINKHOVERCOLOUR:
                    colourStringSettingsManager.SetLinkHoverColour(ColourFormatting.FormatColourAsString(colour));
                    break;
                case AllAvailableColourTypes.LINKNORMALCOLOUR:
                    colourStringSettingsManager.SetLinkNormalColour(ColourFormatting.FormatColourAsString(colour));
                    break;
                case AllAvailableColourTypes.LINKVISITEDCOLOUR:
                    colourStringSettingsManager.SetLinkVisitedColour(ColourFormatting.FormatColourAsString(colour));
                    break;
                case AllAvailableColourTypes.MEDIUMCOLOUR:
                    colourStringSettingsManager.SetMediumColour(ColourFormatting.FormatColourAsString(colour));
                    break;
                case AllAvailableColourTypes.MENUTEXTCOLOUR:
                    colourStringSettingsManager.SetMenuTextColour(ColourFormatting.FormatColourAsString(colour));
                    break;
                case AllAvailableColourTypes.NORMALTEXTCOLOUR:
                    colourStringSettingsManager.SetNormalTextColour(ColourFormatting.FormatColourAsString(colour));
                    break;
                case AllAvailableColourTypes.PRESSEDTEXTCOLOUR:
                    colourStringSettingsManager.SetPressedTextColour(ColourFormatting.FormatColourAsString(colour));
                    break;
                case AllAvailableColourTypes.STATUSTEXTCOLOUR:
                    colourStringSettingsManager.SetStatusTextColour(ColourFormatting.FormatColourAsString(colour));
                    break;
                default:
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
                case BasicPaletteColourDefinitions.BASECOLOUR:
                    colourSettingsManager.SetBaseColour(colour);
                    break;
                case BasicPaletteColourDefinitions.DARKESTCOLOUR:
                    colourSettingsManager.SetDarkColour(colour);
                    break;
                case BasicPaletteColourDefinitions.MIDDLECOLOUR:
                    colourSettingsManager.SetMediumColour(colour);
                    break;
                case BasicPaletteColourDefinitions.LIGHTCOLOUR:
                    colourSettingsManager.SetLightColour(colour);
                    break;
                case BasicPaletteColourDefinitions.LIGHTESTCOLOUR:
                    colourSettingsManager.SetLightestColour(colour);
                    break;
                default:
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
                    case AllAvailableColourTypes.ALTERNATIVENORMALTEXTCOLOUR:
                        tempColour = colourSettingsManager.GetAlternativeNormalTextColour();
                        break;
                    case AllAvailableColourTypes.BASECOLOUR:
                        tempColour = colourSettingsManager.GetBaseColour();
                        break;
                    case AllAvailableColourTypes.BORDERCOLOUR:
                        tempColour = colourSettingsManager.GetBorderColour();
                        break;
                    case AllAvailableColourTypes.CUSTOMCOLOURONE:
                        tempColour = colourSettingsManager.GetCustomColourOne();
                        break;
                    case AllAvailableColourTypes.CUSTOMCOLOURTWO:
                        tempColour = colourSettingsManager.GetCustomColourTwo();
                        break;
                    case AllAvailableColourTypes.CUSTOMCOLOURTHREE:
                        tempColour = colourSettingsManager.GetCustomColourThree();
                        break;
                    case AllAvailableColourTypes.CUSTOMCOLOURFOUR:
                        tempColour = colourSettingsManager.GetCustomColourFour();
                        break;
                    case AllAvailableColourTypes.CUSTOMCOLOURFIVE:
                        tempColour = colourSettingsManager.GetCustomColourFive();
                        break;
                    case AllAvailableColourTypes.CUSTOMCOLOURSIX:
                        tempColour = colourSettingsManager.GetCustomColourSix();
                        break;
                    case AllAvailableColourTypes.CUSTOMTEXTCOLOURONE:
                        tempColour = colourSettingsManager.GetCustomTextColourOne();
                        break;
                    case AllAvailableColourTypes.CUSTOMTEXTCOLOURTWO:
                        tempColour = colourSettingsManager.GetCustomTextColourTwo();
                        break;
                    case AllAvailableColourTypes.CUSTOMTEXTCOLOURTHREE:
                        tempColour = colourSettingsManager.GetCustomTextColourThree();
                        break;
                    case AllAvailableColourTypes.CUSTOMTEXTCOLOURFOUR:
                        tempColour = colourSettingsManager.GetCustomTextColourFour();
                        break;
                    case AllAvailableColourTypes.CUSTOMTEXTCOLOURFIVE:
                        tempColour = colourSettingsManager.GetCustomTextColourFive();
                        break;
                    case AllAvailableColourTypes.CUSTOMTEXTCOLOURSIX:
                        tempColour = colourSettingsManager.GetCustomTextColourSix();
                        break;
                    case AllAvailableColourTypes.DARKESTCOLOUR:
                        tempColour = colourSettingsManager.GetDarkColour();
                        break;
                    case AllAvailableColourTypes.DISABLEDCONTROLCOLOUR:
                        tempColour = colourSettingsManager.GetDisabledControlColour();
                        break;
                    case AllAvailableColourTypes.DISABLEDTEXTCOLOUR:
                        tempColour = colourSettingsManager.GetDisabledTextColour();
                        break;
                    case AllAvailableColourTypes.FOCUSEDTEXTCOLOUR:
                        tempColour = colourSettingsManager.GetFocusedTextColour();
                        break;
                    case AllAvailableColourTypes.LIGHTCOLOUR:
                        tempColour = colourSettingsManager.GetLightColour();
                        break;
                    case AllAvailableColourTypes.LIGHTESTCOLOUR:
                        tempColour = colourSettingsManager.GetLightestColour();
                        break;
                    case AllAvailableColourTypes.LINKDISABLEDCOLOUR:
                        tempColour = colourSettingsManager.GetLinkDisabledColour();
                        break;
                    case AllAvailableColourTypes.LINKHOVERCOLOUR:
                        tempColour = colourSettingsManager.GetLinkHoverColour();
                        break;
                    case AllAvailableColourTypes.LINKNORMALCOLOUR:
                        tempColour = colourSettingsManager.GetLinkNormalColour();
                        break;
                    case AllAvailableColourTypes.LINKVISITEDCOLOUR:
                        tempColour = colourSettingsManager.GetLinkVisitedColour();
                        break;
                    case AllAvailableColourTypes.MEDIUMCOLOUR:
                        tempColour = colourSettingsManager.GetMediumColour();
                        break;
                    case AllAvailableColourTypes.MENUTEXTCOLOUR:
                        tempColour = colourSettingsManager.GetMenuTextColour();
                        break;
                    case AllAvailableColourTypes.NORMALTEXTCOLOUR:
                        tempColour = colourSettingsManager.GetNormalTextColour();
                        break;
                    case AllAvailableColourTypes.PRESSEDTEXTCOLOUR:
                        tempColour = colourSettingsManager.GetPressedTextColour();
                        break;
                    case AllAvailableColourTypes.STATUSTEXTCOLOUR:
                        tempColour = colourSettingsManager.GetStatusStripTextColour();
                        break;
                    default:
                        tempColour = Color.FromArgb(0, 0, 0, 0);
                        break;
                }
            }
            catch (Exception exc)
            {
                KryptonMessageBox.Show($"An unexpected error has occurred: { exc.Message }", "Retrieving Settings Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                tempColour = Color.FromArgb(0, 0, 0, 0);
            }

            return tempColour;
        }

        public static void RetrieveAllColourSettingsAsColour()
        {
            AllMergedColourSettingsManager colourSettingsManager = new AllMergedColourSettingsManager();

            try
            {

            }
            catch (Exception exc)
            {
                KryptonMessageBox.Show($"An unexpected error has occurred: { exc.Message }", "Retrieving Settings Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    case SettingTypes.BOOLEAN:
                        globalBooleanSettingsManager.SaveBooleanSettings();
                        break;
                    case SettingTypes.COLOUR:
                        colourSettingsManager.SaveAllMergedColourSettings();
                        break;
                    case SettingTypes.COLOURSTRING:
                        //colourStringSettingsManager.SaveColourStringSettings();
                        break;
                    case SettingTypes.COLOURINTEGER:
                        colourIntegerSettingsManager.SaveColourIntegerSettings();
                        break;
                    case SettingTypes.STRING:
                        globalStringSettingsManager.SaveStringSettings();
                        break;
                    case SettingTypes.INTEGER:
                        colourIntegerSettingsManager.SaveColourIntegerSettings();
                        break;
                    default:
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