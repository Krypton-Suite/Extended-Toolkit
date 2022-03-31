#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Core
{
    public class PaletteImportManager
    {
        #region Variables
        private KryptonPalette _palette;

        private AllMergedColourSettingsManager _colourSettingsManager = new AllMergedColourSettingsManager();

        private GlobalStringSettingsManager _globalStringSettingsManager = new GlobalStringSettingsManager();
        #endregion

        #region Constructors
        public PaletteImportManager()
        {

        }
        #endregion

        #region Methods
        public void ImportColourScheme(KryptonPalette palette)
        {
            try
            {
                //palette = new KryptonPalette();

                //palette.Import();

                _colourSettingsManager.SetBaseColour(palette.ButtonStyles.ButtonCommon.OverrideDefault.Back.Color1);

                _colourSettingsManager.SetDarkColour(palette.ButtonStyles.ButtonCluster.StatePressed.Back.Color1);

                _colourSettingsManager.SetMediumColour(palette.ButtonStyles.ButtonCluster.StateNormal.Back.Color1);

                _colourSettingsManager.SetLightColour(palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Back.Color2);

                _colourSettingsManager.SetLightestColour(palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Back.Color1);

                _colourSettingsManager.SetBorderColour(Color.Gray); // Need work

                _colourSettingsManager.SetAlternativeNormalTextColour(palette.ButtonStyles.ButtonCommon.OverrideDefault.Content.LongText.Color1);

                _colourSettingsManager.SetNormalTextColour(palette.ButtonStyles.ButtonCommon.StateCheckedNormal.Content.LongText.Color1);

                _colourSettingsManager.SetFocusedTextColour(palette.ButtonStyles.ButtonCommon.OverrideFocus.Content.LongText.Color1);

                _colourSettingsManager.SetDisabledTextColour(palette.ButtonStyles.ButtonCommon.StateDisabled.Content.LongText.Color1);

                _colourSettingsManager.SetDisabledControlColour(palette.ButtonStyles.ButtonCommon.StateDisabled.Back.Color1);

                _colourSettingsManager.SetLinkNormalColour(palette.LabelStyles.LabelNormalControl.OverrideNotVisited.LongText.Color1);

                _colourSettingsManager.SetLinkHoverColour(palette.LabelStyles.LabelNormalControl.OverridePressed.LongText.Color1);

                _colourSettingsManager.SetLinkFocusedColour(palette.LabelStyles.LabelNormalControl.OverrideFocus.LongText.Color1);

                _colourSettingsManager.SetLinkVisitedColour(palette.LabelStyles.LabelNormalControl.OverrideVisited.LongText.Color1);



                _colourSettingsManager.SetMenuTextColour(palette.ToolMenuStatus.Menu.MenuItemText);

                _colourSettingsManager.SetStatusStripTextColour(palette.ToolMenuStatus.StatusStrip.StatusStripText);

                _colourSettingsManager.SaveAllMergedColourSettings();

                _globalStringSettingsManager.SetBasePaletteMode(palette.BasePaletteMode.ToString());

                _globalStringSettingsManager.SetFeedbackText("The import was successful.");

                _globalStringSettingsManager.SaveStringSettings();
            }
            catch (Exception exc)
            {
                KryptonMessageBox.Show($"Error: { exc.Message }", "Palette Import Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                _globalStringSettingsManager.SetFeedbackText("Failed to import colours!");

                _globalStringSettingsManager.SaveStringSettings();
            }
        }

        public void ImportColourScheme()
        {
            try
            {
                _palette = new KryptonPalette();

                _palette.Import();

                _colourSettingsManager.SetBaseColour(_palette.ButtonStyles.ButtonCommon.OverrideDefault.Back.Color1);

                _colourSettingsManager.SetDarkColour(_palette.ButtonStyles.ButtonCluster.StatePressed.Back.Color1);

                _colourSettingsManager.SetMediumColour(_palette.ButtonStyles.ButtonCluster.StateNormal.Back.Color1);

                _colourSettingsManager.SetLightColour(_palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Back.Color2);

                _colourSettingsManager.SetLightestColour(_palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Back.Color1);

                _colourSettingsManager.SetBorderColour(Color.Gray); // Need work

                _colourSettingsManager.SetAlternativeNormalTextColour(_palette.ButtonStyles.ButtonCommon.OverrideDefault.Content.LongText.Color1);

                _colourSettingsManager.SetNormalTextColour(_palette.ButtonStyles.ButtonCommon.StateCheckedNormal.Content.LongText.Color1);

                _colourSettingsManager.SetDisabledTextColour(_palette.ButtonStyles.ButtonCommon.StateDisabled.Content.LongText.Color1);

                _colourSettingsManager.SetDisabledControlColour(_palette.ButtonStyles.ButtonCommon.StateDisabled.Back.Color1);

                _colourSettingsManager.SetLinkNormalColour(_palette.LabelStyles.LabelNormalControl.OverrideNotVisited.LongText.Color1);

                _colourSettingsManager.SetLinkHoverColour(_palette.LabelStyles.LabelNormalControl.OverridePressed.LongText.Color1);

                _colourSettingsManager.SetLinkVisitedColour(_palette.LabelStyles.LabelNormalControl.OverrideVisited.LongText.Color1);



                _colourSettingsManager.SetMenuTextColour(_palette.ToolMenuStatus.Menu.MenuItemText);

                _colourSettingsManager.SetStatusStripTextColour(_palette.ToolMenuStatus.StatusStrip.StatusStripText);

                _colourSettingsManager.SaveAllMergedColourSettings();

                _globalStringSettingsManager.SetBasePaletteMode(_palette.BasePaletteMode.ToString());

                _globalStringSettingsManager.SetFeedbackText("The import was successful.");

                _globalStringSettingsManager.SaveStringSettings();
            }
            catch (Exception exc)
            {
                ExtendedKryptonMessageBox.Show($"Error: { exc.Message }", "_palette Import Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                _globalStringSettingsManager.SetFeedbackText("Failed to import colours!");

                _globalStringSettingsManager.SaveStringSettings();
            }
        }

        #region New Methods
        public static void ImportPaletteColourScheme(KryptonPalette palette)
        {
            GlobalStringSettingsManager globalStringSettingsManager = new GlobalStringSettingsManager();

            try
            {
                ColourSettingsManagementEngine.SetColourSettingsAsColour(AllAvailableColourTypes.ALTERNATIVENORMALTEXTCOLOUR, palette.ButtonStyles.ButtonCommon.OverrideDefault.Content.LongText.Color1);

                ColourSettingsManagementEngine.SetColourSettingsAsColour(AllAvailableColourTypes.BASECOLOUR, palette.ButtonStyles.ButtonCommon.OverrideDefault.Back.Color1);

                ColourSettingsManagementEngine.SetColourSettingsAsColour(AllAvailableColourTypes.BORDERCOLOUR, Color.Gray); // Needs work!

                ColourSettingsManagementEngine.SetColourSettingsAsColour(AllAvailableColourTypes.CUSTOMCOLOURONE, Color.Gray); // Needs work!

                ColourSettingsManagementEngine.SetColourSettingsAsColour(AllAvailableColourTypes.CUSTOMCOLOURTWO, Color.Gray); // Needs work!

                ColourSettingsManagementEngine.SetColourSettingsAsColour(AllAvailableColourTypes.CUSTOMCOLOURTHREE, Color.Gray); // Needs work!

                ColourSettingsManagementEngine.SetColourSettingsAsColour(AllAvailableColourTypes.CUSTOMCOLOURFOUR, Color.Gray); // Needs work!

                ColourSettingsManagementEngine.SetColourSettingsAsColour(AllAvailableColourTypes.CUSTOMCOLOURFIVE, Color.Gray); // Needs work!

                ColourSettingsManagementEngine.SetColourSettingsAsColour(AllAvailableColourTypes.CUSTOMTEXTCOLOURONE, Color.Gray); // Needs work!

                ColourSettingsManagementEngine.SetColourSettingsAsColour(AllAvailableColourTypes.CUSTOMTEXTCOLOURTWO, Color.Gray); // Needs work!

                ColourSettingsManagementEngine.SetColourSettingsAsColour(AllAvailableColourTypes.CUSTOMTEXTCOLOURTHREE, Color.Gray); // Needs work!

                ColourSettingsManagementEngine.SetColourSettingsAsColour(AllAvailableColourTypes.CUSTOMTEXTCOLOURFOUR, Color.Gray); // Needs work!

                ColourSettingsManagementEngine.SetColourSettingsAsColour(AllAvailableColourTypes.CUSTOMTEXTCOLOURFIVE, Color.Gray); // Needs work!

                ColourSettingsManagementEngine.SetColourSettingsAsColour(AllAvailableColourTypes.DARKESTCOLOUR, palette.ButtonStyles.ButtonCluster.StatePressed.Back.Color1);

                ColourSettingsManagementEngine.SetColourSettingsAsColour(AllAvailableColourTypes.DISABLEDCONTROLCOLOUR, palette.ButtonStyles.ButtonCommon.StateDisabled.Back.Color1);

                ColourSettingsManagementEngine.SetColourSettingsAsColour(AllAvailableColourTypes.DISABLEDTEXTCOLOUR, palette.ButtonStyles.ButtonCommon.StateDisabled.Content.LongText.Color1);

                ColourSettingsManagementEngine.SetColourSettingsAsColour(AllAvailableColourTypes.FOCUSEDTEXTCOLOUR, palette.ButtonStyles.ButtonCommon.OverrideFocus.Content.LongText.Color1);

                ColourSettingsManagementEngine.SetColourSettingsAsColour(AllAvailableColourTypes.LIGHTCOLOUR, palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Back.Color2);

                ColourSettingsManagementEngine.SetColourSettingsAsColour(AllAvailableColourTypes.LIGHTESTCOLOUR, palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Back.Color1);

                ColourSettingsManagementEngine.SetColourSettingsAsColour(AllAvailableColourTypes.LINKDISABLEDCOLOUR, palette.LabelStyles.LabelNormalControl.StateDisabled.LongText.Color1);

                ColourSettingsManagementEngine.SetColourSettingsAsColour(AllAvailableColourTypes.LINKHOVERCOLOUR, palette.LabelStyles.LabelNormalControl.OverridePressed.LongText.Color1);

                ColourSettingsManagementEngine.SetColourSettingsAsColour(AllAvailableColourTypes.LINKNORMALCOLOUR, palette.LabelStyles.LabelNormalControl.OverrideNotVisited.LongText.Color1);

                ColourSettingsManagementEngine.SetColourSettingsAsColour(AllAvailableColourTypes.LINKVISITEDCOLOUR, palette.LabelStyles.LabelNormalControl.OverrideVisited.LongText.Color1);

                ColourSettingsManagementEngine.SetColourSettingsAsColour(AllAvailableColourTypes.MEDIUMCOLOUR, palette.ButtonStyles.ButtonCluster.StateNormal.Back.Color1);

                ColourSettingsManagementEngine.SetColourSettingsAsColour(AllAvailableColourTypes.MENUTEXTCOLOUR, palette.ToolMenuStatus.Menu.MenuItemText);

                ColourSettingsManagementEngine.SetColourSettingsAsColour(AllAvailableColourTypes.NORMALTEXTCOLOUR, palette.ButtonStyles.ButtonCommon.StateCommon.Content.LongText.Color1);

                ColourSettingsManagementEngine.SetColourSettingsAsColour(AllAvailableColourTypes.PRESSEDTEXTCOLOUR, palette.ButtonStyles.ButtonCommon.StatePressed.Content.LongText.Color1);

                ColourSettingsManagementEngine.SetColourSettingsAsColour(AllAvailableColourTypes.STATUSTEXTCOLOUR, palette.ToolMenuStatus.StatusStrip.StatusStripText);

                ColourSettingsManagementEngine.SaveSettings(SettingTypes.COLOUR);

                globalStringSettingsManager.SetBasePaletteMode(palette.BasePaletteMode.ToString());

                globalStringSettingsManager.SetFeedbackText("The import was successful.");

                ColourSettingsManagementEngine.SaveSettings(SettingTypes.STRING);
            }
            catch (Exception exc)
            {
                KryptonMessageBox.Show($"Error: { exc.Message }", "_palette Import Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                globalStringSettingsManager.SetFeedbackText("Failed to import colours!");

                globalStringSettingsManager.SaveStringSettings();
            }
        }

        public static void ImportPaletteColourScheme()
        {
            GlobalStringSettingsManager globalStringSettingsManager = new GlobalStringSettingsManager();

            try
            {
                KryptonPalette palette = new KryptonPalette();

                palette.Import();

                ColourSettingsManagementEngine.SetColourSettingsAsColour(AllAvailableColourTypes.ALTERNATIVENORMALTEXTCOLOUR, palette.ButtonStyles.ButtonCommon.OverrideDefault.Content.LongText.Color1);

                ColourSettingsManagementEngine.SetColourSettingsAsColour(AllAvailableColourTypes.BASECOLOUR, palette.ButtonStyles.ButtonCommon.OverrideDefault.Back.Color1);

                ColourSettingsManagementEngine.SetColourSettingsAsColour(AllAvailableColourTypes.BORDERCOLOUR, Color.Gray); // Needs work!

                ColourSettingsManagementEngine.SetColourSettingsAsColour(AllAvailableColourTypes.CUSTOMCOLOURONE, Color.Gray); // Needs work!

                ColourSettingsManagementEngine.SetColourSettingsAsColour(AllAvailableColourTypes.CUSTOMCOLOURTWO, Color.Gray); // Needs work!

                ColourSettingsManagementEngine.SetColourSettingsAsColour(AllAvailableColourTypes.CUSTOMCOLOURTHREE, Color.Gray); // Needs work!

                ColourSettingsManagementEngine.SetColourSettingsAsColour(AllAvailableColourTypes.CUSTOMCOLOURFOUR, Color.Gray); // Needs work!

                ColourSettingsManagementEngine.SetColourSettingsAsColour(AllAvailableColourTypes.CUSTOMCOLOURFIVE, Color.Gray); // Needs work!

                ColourSettingsManagementEngine.SetColourSettingsAsColour(AllAvailableColourTypes.CUSTOMTEXTCOLOURONE, Color.Gray); // Needs work!

                ColourSettingsManagementEngine.SetColourSettingsAsColour(AllAvailableColourTypes.CUSTOMTEXTCOLOURTWO, Color.Gray); // Needs work!

                ColourSettingsManagementEngine.SetColourSettingsAsColour(AllAvailableColourTypes.CUSTOMTEXTCOLOURTHREE, Color.Gray); // Needs work!

                ColourSettingsManagementEngine.SetColourSettingsAsColour(AllAvailableColourTypes.CUSTOMTEXTCOLOURFOUR, Color.Gray); // Needs work!

                ColourSettingsManagementEngine.SetColourSettingsAsColour(AllAvailableColourTypes.CUSTOMTEXTCOLOURFIVE, Color.Gray); // Needs work!

                ColourSettingsManagementEngine.SetColourSettingsAsColour(AllAvailableColourTypes.DARKESTCOLOUR, palette.ButtonStyles.ButtonCluster.StatePressed.Back.Color1);

                ColourSettingsManagementEngine.SetColourSettingsAsColour(AllAvailableColourTypes.DISABLEDCONTROLCOLOUR, palette.ButtonStyles.ButtonCommon.StateDisabled.Back.Color1);

                ColourSettingsManagementEngine.SetColourSettingsAsColour(AllAvailableColourTypes.DISABLEDTEXTCOLOUR, palette.ButtonStyles.ButtonCommon.StateDisabled.Content.LongText.Color1);

                ColourSettingsManagementEngine.SetColourSettingsAsColour(AllAvailableColourTypes.FOCUSEDTEXTCOLOUR, palette.ButtonStyles.ButtonCommon.OverrideFocus.Content.LongText.Color1);

                ColourSettingsManagementEngine.SetColourSettingsAsColour(AllAvailableColourTypes.LIGHTCOLOUR, palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Back.Color2);

                ColourSettingsManagementEngine.SetColourSettingsAsColour(AllAvailableColourTypes.LIGHTESTCOLOUR, palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Back.Color1);

                ColourSettingsManagementEngine.SetColourSettingsAsColour(AllAvailableColourTypes.LINKDISABLEDCOLOUR, palette.LabelStyles.LabelNormalControl.StateDisabled.LongText.Color1);

                ColourSettingsManagementEngine.SetColourSettingsAsColour(AllAvailableColourTypes.LINKHOVERCOLOUR, palette.LabelStyles.LabelNormalControl.OverridePressed.LongText.Color1);

                ColourSettingsManagementEngine.SetColourSettingsAsColour(AllAvailableColourTypes.LINKNORMALCOLOUR, palette.LabelStyles.LabelNormalControl.OverrideNotVisited.LongText.Color1);

                ColourSettingsManagementEngine.SetColourSettingsAsColour(AllAvailableColourTypes.LINKVISITEDCOLOUR, palette.LabelStyles.LabelNormalControl.OverrideVisited.LongText.Color1);

                ColourSettingsManagementEngine.SetColourSettingsAsColour(AllAvailableColourTypes.MEDIUMCOLOUR, palette.ButtonStyles.ButtonCluster.StateNormal.Back.Color1);

                ColourSettingsManagementEngine.SetColourSettingsAsColour(AllAvailableColourTypes.MENUTEXTCOLOUR, palette.ToolMenuStatus.Menu.MenuItemText);

                ColourSettingsManagementEngine.SetColourSettingsAsColour(AllAvailableColourTypes.NORMALTEXTCOLOUR, palette.ButtonStyles.ButtonCommon.StateCommon.Content.LongText.Color1);

                ColourSettingsManagementEngine.SetColourSettingsAsColour(AllAvailableColourTypes.PRESSEDTEXTCOLOUR, palette.ButtonStyles.ButtonCommon.StatePressed.Content.LongText.Color1);

                ColourSettingsManagementEngine.SetColourSettingsAsColour(AllAvailableColourTypes.STATUSTEXTCOLOUR, palette.ToolMenuStatus.StatusStrip.StatusStripText);

                ColourSettingsManagementEngine.SaveSettings(SettingTypes.COLOUR);

                globalStringSettingsManager.SetBasePaletteMode(palette.BasePaletteMode.ToString());

                globalStringSettingsManager.SetFeedbackText("The import was successful.");

                ColourSettingsManagementEngine.SaveSettings(SettingTypes.STRING);
            }
            catch (Exception exc)
            {
                KryptonMessageBox.Show($"Error: { exc.Message }", "_palette Import Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                globalStringSettingsManager.SetFeedbackText("Failed to import colours!");

                globalStringSettingsManager.SaveStringSettings();
            }
        }
        #endregion

        #endregion
    }
}