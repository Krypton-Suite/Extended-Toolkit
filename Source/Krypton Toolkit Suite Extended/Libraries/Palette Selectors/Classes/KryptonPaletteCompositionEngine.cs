using Krypton.Toolkit.Suite.Extended.Core;
using System;
using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Palette.Selectors
{
    public class KryptonPaletteCompositionEngine
    {
        #region Variables
        private KryptonPalette _palette;
        #endregion

        #region Constructor
        public KryptonPaletteCompositionEngine()
        {

        }
        #endregion

        #region Methods
        public static void CreateNewKryptonPalette(PaletteMode paletteMode, Color baseColour, Color darkColour, Color mediumColour, Color lightColour, Color lightestColour, Color borderColour, Color disabledTextColour, Color focusedTextColour, Color alternativeNormalTextColour, Color normalTextColour, Color pressedTextColour, Color disabledObjectColour, Color linkFocusedTextColour, Color linkHoverTextColour, Color linkNormalTextColour, Color linkVisitedTextColour, Color customColourOne, Color customColourTwo, Color customColourThree, Color customColourFour, Color customColourFive, Color customTextColourOne, Color customTextColourTwo, Color customTextColourThree, Color customTextColourFour, Color customTextColourFive, Color menuTextColour, Color statusStripTextColour, Color ribbonTabTextColour, bool invertColours = false)
        {
            try
            {
                KryptonPaletteCompositionEngine compositionEngine = new KryptonPaletteCompositionEngine();

                compositionEngine._palette = new KryptonPalette();

                compositionEngine._palette.BasePaletteMode = paletteMode;

                if (lightestColour == Color.Transparent)
                {
                    lightestColour = lightColour;
                }

                if (invertColours)
                {
                    #region Button Cluster
                    compositionEngine._palette.ButtonStyles.ButtonCluster.OverrideDefault.Back.Color1 = darkColour;

                    compositionEngine._palette.ButtonStyles.ButtonCluster.OverrideFocus.Back.Color1 = darkColour;

                    compositionEngine._palette.ButtonStyles.ButtonCluster.StateCheckedNormal.Back.Color1 = darkColour;

                    compositionEngine._palette.ButtonStyles.ButtonCluster.StateCommon.Back.ColorStyle = PaletteColorStyle.GlassNormalFull;

                    compositionEngine._palette.ButtonStyles.ButtonCluster.StateNormal.Back.Color1 = mediumColour;

                    compositionEngine._palette.ButtonStyles.ButtonCluster.StatePressed.Back.Color1 = baseColour;

                    compositionEngine._palette.ButtonStyles.ButtonCluster.StateTracking.Back.Color1 = darkColour;
                    #endregion

                    #region Button Common
                    compositionEngine._palette.ButtonStyles.ButtonCommon.OverrideDefault.Back.Color1 = lightColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.OverrideDefault.Content.LongText.Color1 = normalTextColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.OverrideDefault.Content.ShortText.Color1 = normalTextColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateCheckedNormal.Back.Color1 = darkColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateCheckedNormal.Back.Color2 = baseColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateCheckedNormal.Back.ColorStyle = PaletteColorStyle.GlassCheckedFull;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateCheckedNormal.Content.LongText.Color1 = alternativeNormalTextColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateCheckedNormal.Content.ShortText.Color1 = alternativeNormalTextColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Back.Color1 = darkColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Back.Color2 = baseColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Back.ColorStyle = PaletteColorStyle.GlassCheckedStump;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Border.DrawBorders = PaletteDrawBorders.All;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Content.LongText.Color1 = alternativeNormalTextColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Content.ShortText.Color1 = alternativeNormalTextColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateCheckedTracking.Back.Color1 = baseColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateCheckedTracking.Back.Color2 = baseColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateCheckedTracking.Border.DrawBorders = PaletteDrawBorders.All;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateCheckedTracking.Content.LongText.Color1 = alternativeNormalTextColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateCheckedTracking.Content.ShortText.Color1 = alternativeNormalTextColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateCommon.Back.Color1 = lightColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateDisabled.Back.Color1 = disabledObjectColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateDisabled.Back.Color2 = disabledObjectColour;

                    /*
                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateDisabled.Back.Color1 = lightColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateDisabled.Back.Color2 = lightColour;
                    */

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateDisabled.Content.LongText.Color1 = disabledTextColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateDisabled.Content.ShortText.Color1 = disabledTextColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateNormal.Back.Color1 = lightColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateNormal.Back.Color2 = lightColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateNormal.Content.LongText.Color1 = normalTextColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateNormal.Content.LongText.Color2 = normalTextColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateNormal.Content.ShortText.Color1 = normalTextColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateNormal.Content.ShortText.Color2 = normalTextColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StatePressed.Back.Color1 = darkColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StatePressed.Back.Color2 = baseColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StatePressed.Content.LongText.Color1 = alternativeNormalTextColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StatePressed.Content.ShortText.Color1 = alternativeNormalTextColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateTracking.Back.Color1 = lightColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateTracking.Back.Color2 = lightestColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateTracking.Content.LongText.Color1 = normalTextColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateTracking.Content.ShortText.Color1 = normalTextColour;
                    #endregion
                }
                else
                {
                    #region Button Cluster
                    compositionEngine._palette.ButtonStyles.ButtonCluster.OverrideDefault.Back.Color1 = baseColour;

                    compositionEngine._palette.ButtonStyles.ButtonCluster.OverrideFocus.Back.Color1 = baseColour;

                    compositionEngine._palette.ButtonStyles.ButtonCluster.StateCheckedNormal.Back.Color1 = baseColour;

                    compositionEngine._palette.ButtonStyles.ButtonCluster.StateCommon.Back.ColorStyle = PaletteColorStyle.GlassNormalFull;

                    compositionEngine._palette.ButtonStyles.ButtonCluster.StateNormal.Back.Color1 = mediumColour;

                    compositionEngine._palette.ButtonStyles.ButtonCluster.StatePressed.Back.Color1 = darkColour;

                    compositionEngine._palette.ButtonStyles.ButtonCluster.StateTracking.Back.Color1 = baseColour;
                    #endregion

                    #region Button Common
                    compositionEngine._palette.ButtonStyles.ButtonCommon.OverrideDefault.Back.Color1 = baseColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.OverrideDefault.Content.LongText.Color1 = alternativeNormalTextColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.OverrideDefault.Content.ShortText.Color1 = alternativeNormalTextColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateCheckedNormal.Back.Color1 = lightestColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateCheckedNormal.Back.Color2 = lightColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateCheckedNormal.Back.ColorStyle = PaletteColorStyle.GlassCheckedFull;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateCheckedNormal.Content.LongText.Color1 = normalTextColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateCheckedNormal.Content.ShortText.Color1 = normalTextColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Back.Color1 = lightestColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Back.Color2 = lightColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Back.ColorStyle = PaletteColorStyle.GlassCheckedStump;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Border.DrawBorders = PaletteDrawBorders.All;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Content.LongText.Color1 = normalTextColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Content.ShortText.Color1 = normalTextColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateCheckedTracking.Back.Color1 = lightestColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateCheckedTracking.Back.Color2 = lightColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateCheckedTracking.Border.DrawBorders = PaletteDrawBorders.All;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateCheckedTracking.Content.LongText.Color1 = normalTextColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateCheckedTracking.Content.ShortText.Color1 = normalTextColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateCommon.Back.Color1 = baseColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateDisabled.Back.Color1 = disabledObjectColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateDisabled.Back.Color2 = disabledObjectColour;

                    /*
                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateDisabled.Back.Color1 = baseColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateDisabled.Back.Color2 = baseColour;
                    */

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateDisabled.Content.LongText.Color1 = disabledTextColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateDisabled.Content.ShortText.Color1 = disabledTextColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateNormal.Back.Color1 = baseColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateNormal.Back.Color2 = baseColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateNormal.Content.LongText.Color1 = alternativeNormalTextColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateNormal.Content.LongText.Color2 = alternativeNormalTextColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateNormal.Content.ShortText.Color1 = alternativeNormalTextColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateNormal.Content.ShortText.Color2 = alternativeNormalTextColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StatePressed.Back.Color1 = lightestColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StatePressed.Back.Color2 = lightColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StatePressed.Content.LongText.Color1 = normalTextColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StatePressed.Content.ShortText.Color1 = normalTextColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateTracking.Back.Color1 = baseColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateTracking.Back.Color2 = darkColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateTracking.Content.LongText.Color1 = alternativeNormalTextColour;

                    compositionEngine._palette.ButtonStyles.ButtonCommon.StateTracking.Content.ShortText.Color1 = alternativeNormalTextColour;
                    #endregion

                    #region Common
                    compositionEngine._palette.Common.StateCommon.Back.Color1 = lightestColour;

                    compositionEngine._palette.Common.StateCommon.Back.Color2 = baseColour;

                    compositionEngine._palette.Common.StateCommon.Border.Color1 = baseColour;

                    compositionEngine._palette.Common.StateCommon.Border.Color2 = darkColour;

                    compositionEngine._palette.Common.StateCommon.Border.DrawBorders = PaletteDrawBorders.All;

                    compositionEngine._palette.Common.StateCommon.Content.LongText.Color1 = alternativeNormalTextColour;

                    compositionEngine._palette.Common.StateCommon.Content.LongText.Color2 = alternativeNormalTextColour;

                    compositionEngine._palette.Common.StateCommon.Content.ShortText.Color1 = alternativeNormalTextColour;

                    compositionEngine._palette.Common.StateCommon.Content.ShortText.Color2 = alternativeNormalTextColour;
                    #endregion

                    #region Form Styles
                    compositionEngine._palette.FormStyles.FormCommon.StateActive.Back.Color1 = baseColour;

                    compositionEngine._palette.FormStyles.FormCommon.StateActive.Border.DrawBorders = PaletteDrawBorders.All;
                    #endregion

                    #region Grid Styles
                    compositionEngine._palette.GridStyles.GridSheet.StateCommon.HeaderColumn.Content.Color1 = lightestColour;

                    compositionEngine._palette.GridStyles.GridSheet.StateCommon.HeaderRow.Content.Color1 = lightestColour;

                    compositionEngine._palette.GridStyles.GridSheet.StateNormal.HeaderColumn.Content.Color1 = darkColour;

                    compositionEngine._palette.GridStyles.GridSheet.StateNormal.HeaderColumn.Content.Color2 = mediumColour;

                    compositionEngine._palette.GridStyles.GridSheet.StateNormal.HeaderRow.Content.Color1 = darkColour;

                    compositionEngine._palette.GridStyles.GridSheet.StateTracking.HeaderColumn.Content.Color1 = baseColour;
                    #endregion

                    #region Header Styles
                    compositionEngine._palette.HeaderStyles.HeaderCommon.StateCommon.Back.Color1 = mediumColour;

                    compositionEngine._palette.HeaderStyles.HeaderCommon.StateCommon.Back.Color2 = lightColour;

                    compositionEngine._palette.HeaderStyles.HeaderCommon.StateDisabled.Back.Color1 = lightColour;

                    compositionEngine._palette.HeaderStyles.HeaderCommon.StateDisabled.Back.Color2 = lightestColour;

                    compositionEngine._palette.HeaderStyles.HeaderCommon.StateDisabled.Content.LongText.Color1 = disabledTextColour;

                    compositionEngine._palette.HeaderStyles.HeaderCommon.StateDisabled.Content.LongText.Color2 = baseColour;

                    compositionEngine._palette.HeaderStyles.HeaderCommon.StateDisabled.Content.ShortText.Color1 = disabledTextColour;

                    compositionEngine._palette.HeaderStyles.HeaderCommon.StateDisabled.Content.ShortText.Color2 = baseColour;

                    compositionEngine._palette.HeaderStyles.HeaderForm.StateCommon.Back.Color1 = mediumColour;

                    compositionEngine._palette.HeaderStyles.HeaderForm.StateCommon.Back.Color2 = lightColour;

                    compositionEngine._palette.HeaderStyles.HeaderForm.StateDisabled.Back.Color1 = disabledObjectColour;

                    compositionEngine._palette.HeaderStyles.HeaderForm.StateDisabled.Back.Color2 = baseColour;

                    compositionEngine._palette.HeaderStyles.HeaderForm.StateDisabled.Content.LongText.Color1 = disabledTextColour;

                    compositionEngine._palette.HeaderStyles.HeaderForm.StateDisabled.Content.ShortText.Color1 = disabledTextColour;
                    #endregion

                    #region Label Styles
                    compositionEngine._palette.LabelStyles.LabelNormalControl.OverrideNotVisited.LongText.Color1 = linkNormalTextColour;

                    compositionEngine._palette.LabelStyles.LabelNormalControl.OverrideNotVisited.ShortText.Color1 = linkNormalTextColour;

                    compositionEngine._palette.LabelStyles.LabelNormalControl.OverridePressed.LongText.Color1 = linkHoverTextColour;

                    compositionEngine._palette.LabelStyles.LabelNormalControl.OverridePressed.ShortText.Color1 = linkHoverTextColour;

                    compositionEngine._palette.LabelStyles.LabelNormalControl.OverrideVisited.LongText.Color1 = linkVisitedTextColour;

                    compositionEngine._palette.LabelStyles.LabelNormalControl.OverrideVisited.ShortText.Color1 = linkVisitedTextColour;

                    compositionEngine._palette.LabelStyles.LabelNormalControl.OverrideFocus.LongText.Color1 = linkFocusedTextColour;

                    compositionEngine._palette.LabelStyles.LabelNormalControl.OverrideFocus.ShortText.Color1 = linkFocusedTextColour;

                    compositionEngine._palette.LabelStyles.LabelNormalControl.StateDisabled.LongText.Color1 = disabledTextColour;

                    compositionEngine._palette.LabelStyles.LabelNormalControl.StateDisabled.ShortText.Color1 = disabledTextColour;

                    compositionEngine._palette.LabelStyles.LabelNormalControl.StateNormal.LongText.Color1 = normalTextColour;

                    compositionEngine._palette.LabelStyles.LabelNormalControl.StateNormal.ShortText.Color1 = normalTextColour;
                    #endregion

                    #region Ribbon
                    compositionEngine._palette.Ribbon.RibbonAppButton.StateCommon.BackColor2 = baseColour;

                    compositionEngine._palette.Ribbon.RibbonAppButton.StateCommon.BackColor3 = customColourThree;

                    compositionEngine._palette.Ribbon.RibbonAppButton.StateCommon.BackColor5 = baseColour;

                    compositionEngine._palette.Ribbon.RibbonAppButton.StatePressed5 = darkColour;

                    compositionEngine._palette.Ribbon.RibbonAppButton.StateTracking5 = customColourFive;

                    compositionEngine._palette.Ribbon.RibbonGroupArea.StateCheckedNormal1 = baseColour;

                    compositionEngine._palette.Ribbon.RibbonGroupArea.StateCheckedNormal2 = customColourTwo;

                    compositionEngine._palette.Ribbon.RibbonGroupArea.StateCheckedNormal3 = baseColour;

                    compositionEngine._palette.Ribbon.RibbonGroupArea.StateCheckedNormal4 = baseColour;

                    compositionEngine._palette.Ribbon.RibbonGroupArea.StateCheckedNormal5 = baseColour;

                    compositionEngine._palette.Ribbon.RibbonGroupButtonText.StateCommon.TextColor = customTextColourTwo;

                    compositionEngine._palette.Ribbon.RibbonGroupCheckBoxText.StateCommon.TextColor = customTextColourTwo;

                    compositionEngine._palette.Ribbon.RibbonGroupCollapsedBack.StateNormal1 = SystemColors.Window;

                    compositionEngine._palette.Ribbon.RibbonGroupCollapsedBack.StateNormal2 = baseColour;

                    compositionEngine._palette.Ribbon.RibbonGroupCollapsedBack.StateNormal3 = lightColour;

                    compositionEngine._palette.Ribbon.RibbonGroupCollapsedBack.StateNormal4 = baseColour;

                    compositionEngine._palette.Ribbon.RibbonGroupCollapsedBack.StateTracking1 = SystemColors.Window;

                    compositionEngine._palette.Ribbon.RibbonGroupCollapsedBack.StateTracking2 = lightColour;

                    compositionEngine._palette.Ribbon.RibbonGroupCollapsedBack.StateTracking3 = lightestColour; // Or 230, 230, 230

                    compositionEngine._palette.Ribbon.RibbonGroupCollapsedBack.StateTracking4 = baseColour;

                    compositionEngine._palette.Ribbon.RibbonGroupCollapsedBorder.StateCommon1 = baseColour;

                    compositionEngine._palette.Ribbon.RibbonGroupCollapsedBorder.StateCommon2 = mediumColour;

                    compositionEngine._palette.Ribbon.RibbonGroupCollapsedBorder.StateCommon3 = lightColour;

                    compositionEngine._palette.Ribbon.RibbonGroupCollapsedBorder.StateCommon4 = baseColour;

                    compositionEngine._palette.Ribbon.RibbonGroupCollapsedBorder.StateCommon5 = baseColour;

                    compositionEngine._palette.Ribbon.RibbonGroupCollapsedFrameBack.StateCommon1 = baseColour;

                    compositionEngine._palette.Ribbon.RibbonGroupCollapsedFrameBack.StateCommon2 = baseColour;

                    compositionEngine._palette.Ribbon.RibbonGroupCollapsedFrameBack.StateCommon3 = lightColour;

                    compositionEngine._palette.Ribbon.RibbonGroupCollapsedFrameBack.StateCommon4 = lightColour;

                    compositionEngine._palette.Ribbon.RibbonGroupCollapsedFrameBack.StateCommon5 = baseColour;

                    compositionEngine._palette.Ribbon.RibbonGroupCollapsedFrameBorder.StateCommon1 = lightColour;

                    compositionEngine._palette.Ribbon.RibbonGroupCollapsedFrameBorder.StateCommon2 = lightestColour; // Or 230, 230, 230

                    compositionEngine._palette.Ribbon.RibbonGroupCollapsedText.StateCommon.TextColor = alternativeNormalTextColour;

                    compositionEngine._palette.Ribbon.RibbonGroupNormalBorder.StateCommon1 = baseColour;

                    compositionEngine._palette.Ribbon.RibbonGroupNormalBorder.StateCommon2 = mediumColour;

                    compositionEngine._palette.Ribbon.RibbonGroupNormalTitle.StateCommon1 = lightestColour; // Or 230, 230, 230

                    compositionEngine._palette.Ribbon.RibbonGroupNormalTitle.StateCommon2 = mediumColour;

                    compositionEngine._palette.Ribbon.RibbonGroupNormalTitle.StateCommon.TextColor = customTextColourFive;

                    compositionEngine._palette.Ribbon.RibbonGroupNormalTitle.StateTracking1 = lightestColour;

                    compositionEngine._palette.Ribbon.RibbonGroupNormalTitle.StateTracking2 = mediumColour;

                    compositionEngine._palette.Ribbon.RibbonQATFullbar1 = mediumColour;

                    compositionEngine._palette.Ribbon.RibbonQATFullbar2 = mediumColour;

                    compositionEngine._palette.Ribbon.RibbonQATFullbar3 = mediumColour;

                    compositionEngine._palette.Ribbon.RibbonQATMinibar.StateCommon1 = mediumColour;

                    compositionEngine._palette.Ribbon.RibbonQATMinibar.StateCommon2 = mediumColour;

                    compositionEngine._palette.Ribbon.RibbonQATMinibar.StateCommon3 = mediumColour;

                    compositionEngine._palette.Ribbon.RibbonQATMinibar.StateCommon4 = mediumColour;

                    compositionEngine._palette.Ribbon.RibbonQATOverflow1 = mediumColour;

                    compositionEngine._palette.Ribbon.RibbonQATOverflow2 = mediumColour;

                    compositionEngine._palette.Ribbon.RibbonTab.StateCheckedTracking1 = mediumColour;

                    compositionEngine._palette.Ribbon.RibbonTab.StateCheckedTracking2 = lightColour;

                    compositionEngine._palette.Ribbon.RibbonTab.StateCheckedTracking3 = darkColour;

                    compositionEngine._palette.Ribbon.RibbonTab.StateCheckedTracking4 = mediumColour;

                    compositionEngine._palette.Ribbon.RibbonTab.StateCommon1 = mediumColour;

                    compositionEngine._palette.Ribbon.RibbonTab.StateCommon3 = mediumColour;

                    compositionEngine._palette.Ribbon.RibbonTab.StateCommon4 = lightColour;

                    compositionEngine._palette.Ribbon.RibbonTab.StateCommon5 = lightColour;

                    compositionEngine._palette.Ribbon.RibbonTab.StateCommon.TextColor = normalTextColour;

                    compositionEngine._palette.Ribbon.RibbonTab.StateContextCheckedTracking2 = mediumColour;

                    compositionEngine._palette.Ribbon.RibbonTab.StateTracking2 = mediumColour;

                    compositionEngine._palette.Ribbon.RibbonTab.StateNormal.TextColor = ribbonTabTextColour;
                    #endregion

                    #region Separator Styles
                    compositionEngine._palette.SeparatorStyles.SeparatorCommon.StateCommon.Back.Color1 = baseColour;

                    compositionEngine._palette.SeparatorStyles.SeparatorCommon.StateCommon.Back.Color2 = baseColour;

                    compositionEngine._palette.SeparatorStyles.SeparatorCommon.StateCommon.Border.Color1 = baseColour;

                    compositionEngine._palette.SeparatorStyles.SeparatorCommon.StateCommon.Border.Color1 = baseColour;

                    compositionEngine._palette.SeparatorStyles.SeparatorCommon.StateCommon.Border.DrawBorders = PaletteDrawBorders.All;
                    #endregion

                    #region Tool Menu Status
                    compositionEngine._palette.ToolMenuStatus.Button.ButtonPressedBorder = baseColour;

                    compositionEngine._palette.ToolMenuStatus.Button.ButtonSelectedBorder = baseColour;

                    compositionEngine._palette.ToolMenuStatus.Button.OverflowButtonGradientBegin = darkColour;

                    compositionEngine._palette.ToolMenuStatus.Button.OverflowButtonGradientEnd = baseColour;

                    compositionEngine._palette.ToolMenuStatus.Button.OverflowButtonGradientMiddle = mediumColour;

                    compositionEngine._palette.ToolMenuStatus.Grip.GripDark = baseColour;

                    compositionEngine._palette.ToolMenuStatus.Grip.GripLight = customColourFive;

                    compositionEngine._palette.ToolMenuStatus.Menu.ImageMarginGradientBegin = baseColour;

                    compositionEngine._palette.ToolMenuStatus.Menu.ImageMarginGradientEnd = darkColour;

                    compositionEngine._palette.ToolMenuStatus.Menu.ImageMarginGradientMiddle = mediumColour;

                    compositionEngine._palette.ToolMenuStatus.Menu.ImageMarginRevealedGradientBegin = baseColour;

                    compositionEngine._palette.ToolMenuStatus.Menu.ImageMarginRevealedGradientEnd = darkColour;

                    compositionEngine._palette.ToolMenuStatus.Menu.ImageMarginRevealedGradientMiddle = mediumColour;

                    compositionEngine._palette.ToolMenuStatus.Menu.MenuBorder = baseColour;

                    compositionEngine._palette.ToolMenuStatus.Menu.MenuItemBorder = darkColour;

                    compositionEngine._palette.ToolMenuStatus.Menu.MenuItemPressedGradientBegin = baseColour;

                    compositionEngine._palette.ToolMenuStatus.Menu.MenuItemPressedGradientEnd = darkColour;

                    compositionEngine._palette.ToolMenuStatus.Menu.MenuItemPressedGradientMiddle = mediumColour;

                    compositionEngine._palette.ToolMenuStatus.Menu.MenuItemSelected = mediumColour;

                    compositionEngine._palette.ToolMenuStatus.Menu.MenuItemSelectedGradientBegin = darkColour;

                    compositionEngine._palette.ToolMenuStatus.Menu.MenuItemSelectedGradientEnd = baseColour;

                    compositionEngine._palette.ToolMenuStatus.Menu.MenuItemText = menuTextColour;

                    compositionEngine._palette.ToolMenuStatus.MenuStrip.MenuStripGradientBegin = baseColour;

                    compositionEngine._palette.ToolMenuStatus.MenuStrip.MenuStripGradientEnd = darkColour;

                    compositionEngine._palette.ToolMenuStatus.MenuStrip.MenuStripText = normalTextColour;

                    compositionEngine._palette.ToolMenuStatus.Rafting.RaftingContainerGradientBegin = mediumColour;

                    compositionEngine._palette.ToolMenuStatus.Rafting.RaftingContainerGradientEnd = darkColour;

                    compositionEngine._palette.ToolMenuStatus.Separator.SeparatorDark = baseColour;

                    compositionEngine._palette.ToolMenuStatus.Separator.SeparatorLight = lightColour;

                    compositionEngine._palette.ToolMenuStatus.StatusStrip.StatusStripGradientBegin = baseColour;

                    compositionEngine._palette.ToolMenuStatus.StatusStrip.StatusStripGradientEnd = lightColour;

                    compositionEngine._palette.ToolMenuStatus.StatusStrip.StatusStripText = normalTextColour;

                    compositionEngine._palette.ToolMenuStatus.ToolStrip.ToolStripBorder = darkColour;

                    compositionEngine._palette.ToolMenuStatus.ToolStrip.ToolStripContentPanelGradientBegin = lightColour;

                    compositionEngine._palette.ToolMenuStatus.ToolStrip.ToolStripContentPanelGradientEnd = darkColour;

                    compositionEngine._palette.ToolMenuStatus.ToolStrip.ToolStripDropDownBackground = mediumColour;

                    compositionEngine._palette.ToolMenuStatus.ToolStrip.ToolStripGradientBegin = darkColour;

                    compositionEngine._palette.ToolMenuStatus.ToolStrip.ToolStripGradientEnd = lightColour;

                    compositionEngine._palette.ToolMenuStatus.ToolStrip.ToolStripGradientMiddle = mediumColour;

                    compositionEngine._palette.ToolMenuStatus.ToolStrip.ToolStripPanelGradientBegin = lightColour;

                    compositionEngine._palette.ToolMenuStatus.ToolStrip.ToolStripPanelGradientEnd = darkColour;

                    compositionEngine._palette.ToolMenuStatus.ToolStrip.ToolStripText = normalTextColour;
                    #endregion
                }

                compositionEngine._palette.Export();
            }
            catch (Exception e)
            {
                ExceptionHandler.CaptureException(e);
            }
        }
        #endregion
    }
}