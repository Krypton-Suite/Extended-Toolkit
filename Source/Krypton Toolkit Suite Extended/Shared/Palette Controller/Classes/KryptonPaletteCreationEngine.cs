using Krypton.Toolkit.Suite.Extended.Core;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.Palette.Controller
{
    /// <summary>
    /// This class contains the logic, and does the heavy lifting to create a new <seealso cref="KryptonPalette"/> so you don't have to!
    /// </summary>
    public static class KryptonPaletteCreationEngine
    {
        /// <summary>Exports the palette theme.</summary>
        /// <param name="palette">The palette.</param>
        /// <param name="paletteMode">The palette mode.</param>
        /// <param name="baseColour">The base colour.</param>
        /// <param name="darkColour">The dark colour.</param>
        /// <param name="mediumColour">The medium colour.</param>
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
        /// <param name="linkFocusedColourPreview">The link focused colour preview.</param>
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
        /// <param name="ribbonTabTextColour">The ribbon tab text colour.</param>
        /// <param name="statusState">State of the status.</param>
        /// <param name="invertColours">if set to <c>true</c> [invert colours].</param>
        public static void ExportPaletteTheme(KryptonPalette palette, PaletteMode paletteMode, PictureBox baseColour, PictureBox darkColour, PictureBox mediumColour, PictureBox lightColour, PictureBox lightestColour, PictureBox borderColourPreview, PictureBox alternativeNormalTextColourPreview, PictureBox normalTextColourPreview, PictureBox disabledTextColourPreview, PictureBox focusedTextColourPreview, PictureBox pressedTextColourPreview, PictureBox disabledColourPreview, PictureBox linkNormalColourPreview, PictureBox linkFocusedColourPreview, PictureBox linkHoverColourPreview, PictureBox linkVisitedColourPreview, PictureBox customColourOne, PictureBox customColourTwo, PictureBox customColourThree, PictureBox customColourFour, PictureBox customColourFive, PictureBox customTextColourOne, PictureBox customTextColourTwo, PictureBox customTextColourThree, PictureBox customTextColourFour, PictureBox customTextColourFive, PictureBox menuTextColour, PictureBox statusTextColour, PictureBox ribbonTabTextColour, ToolStripLabel statusState, bool invertColours = false)
        {
            palette = new KryptonPalette();

            //try
            //{
            palette.BasePaletteMode = paletteMode;

            if (lightestColour.BackColor == Color.Transparent)
            {
                lightestColour.BackColor = lightColour.BackColor;
            }

            if (invertColours)
            {
                #region Button Cluster
                palette.ButtonStyles.ButtonCluster.OverrideDefault.Back.Color1 = darkColour.BackColor;

                palette.ButtonStyles.ButtonCluster.OverrideFocus.Back.Color1 = darkColour.BackColor;

                palette.ButtonStyles.ButtonCluster.StateCheckedNormal.Back.Color1 = darkColour.BackColor;

                palette.ButtonStyles.ButtonCluster.StateCommon.Back.ColorStyle = PaletteColorStyle.GlassNormalFull;

                palette.ButtonStyles.ButtonCluster.StateNormal.Back.Color1 = mediumColour.BackColor;

                palette.ButtonStyles.ButtonCluster.StatePressed.Back.Color1 = baseColour.BackColor;

                palette.ButtonStyles.ButtonCluster.StateTracking.Back.Color1 = darkColour.BackColor;
                #endregion

                #region Button Common
                palette.ButtonStyles.ButtonCommon.OverrideDefault.Back.Color1 = lightColour.BackColor;

                palette.ButtonStyles.ButtonCommon.OverrideDefault.Content.LongText.Color1 = normalTextColourPreview.BackColor;

                palette.ButtonStyles.ButtonCommon.OverrideDefault.Content.ShortText.Color1 = normalTextColourPreview.BackColor;

                palette.ButtonStyles.ButtonCommon.StateCheckedNormal.Back.Color1 = darkColour.BackColor;

                palette.ButtonStyles.ButtonCommon.StateCheckedNormal.Back.Color2 = baseColour.BackColor;

                palette.ButtonStyles.ButtonCommon.StateCheckedNormal.Back.ColorStyle = PaletteColorStyle.GlassCheckedFull;

                palette.ButtonStyles.ButtonCommon.StateCheckedNormal.Content.LongText.Color1 = alternativeNormalTextColourPreview.BackColor;

                palette.ButtonStyles.ButtonCommon.StateCheckedNormal.Content.ShortText.Color1 = alternativeNormalTextColourPreview.BackColor;

                palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Back.Color1 = darkColour.BackColor;

                palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Back.Color2 = baseColour.BackColor;

                palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Back.ColorStyle = PaletteColorStyle.GlassCheckedStump;

                palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Border.DrawBorders = PaletteDrawBorders.All;

                palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Content.LongText.Color1 = alternativeNormalTextColourPreview.BackColor;

                palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Content.ShortText.Color1 = alternativeNormalTextColourPreview.BackColor;

                palette.ButtonStyles.ButtonCommon.StateCheckedTracking.Back.Color1 = baseColour.BackColor;

                palette.ButtonStyles.ButtonCommon.StateCheckedTracking.Back.Color2 = baseColour.BackColor;

                palette.ButtonStyles.ButtonCommon.StateCheckedTracking.Border.DrawBorders = PaletteDrawBorders.All;

                palette.ButtonStyles.ButtonCommon.StateCheckedTracking.Content.LongText.Color1 = alternativeNormalTextColourPreview.BackColor;

                palette.ButtonStyles.ButtonCommon.StateCheckedTracking.Content.ShortText.Color1 = alternativeNormalTextColourPreview.BackColor;

                palette.ButtonStyles.ButtonCommon.StateCommon.Back.Color1 = lightColour.BackColor;

                palette.ButtonStyles.ButtonCommon.StateDisabled.Back.Color1 = disabledColourPreview.BackColor;

                palette.ButtonStyles.ButtonCommon.StateDisabled.Back.Color2 = disabledColourPreview.BackColor;

                /*
                palette.ButtonStyles.ButtonCommon.StateDisabled.Back.Color1 = lightColour.BackColor;

                palette.ButtonStyles.ButtonCommon.StateDisabled.Back.Color2 = lightColour.BackColor;
                */

                palette.ButtonStyles.ButtonCommon.StateDisabled.Content.LongText.Color1 = disabledTextColourPreview.BackColor;

                palette.ButtonStyles.ButtonCommon.StateDisabled.Content.ShortText.Color1 = disabledTextColourPreview.BackColor;

                palette.ButtonStyles.ButtonCommon.StateNormal.Back.Color1 = lightColour.BackColor;

                palette.ButtonStyles.ButtonCommon.StateNormal.Back.Color2 = lightColour.BackColor;

                palette.ButtonStyles.ButtonCommon.StateNormal.Content.LongText.Color1 = normalTextColourPreview.BackColor;

                palette.ButtonStyles.ButtonCommon.StateNormal.Content.LongText.Color2 = normalTextColourPreview.BackColor;

                palette.ButtonStyles.ButtonCommon.StateNormal.Content.ShortText.Color1 = normalTextColourPreview.BackColor;

                palette.ButtonStyles.ButtonCommon.StateNormal.Content.ShortText.Color2 = normalTextColourPreview.BackColor;

                palette.ButtonStyles.ButtonCommon.StatePressed.Back.Color1 = darkColour.BackColor;

                palette.ButtonStyles.ButtonCommon.StatePressed.Back.Color2 = baseColour.BackColor;

                palette.ButtonStyles.ButtonCommon.StatePressed.Content.LongText.Color1 = alternativeNormalTextColourPreview.BackColor;

                palette.ButtonStyles.ButtonCommon.StatePressed.Content.ShortText.Color1 = alternativeNormalTextColourPreview.BackColor;

                palette.ButtonStyles.ButtonCommon.StateTracking.Back.Color1 = lightColour.BackColor;

                palette.ButtonStyles.ButtonCommon.StateTracking.Back.Color2 = lightestColour.BackColor;

                palette.ButtonStyles.ButtonCommon.StateTracking.Content.LongText.Color1 = normalTextColourPreview.BackColor;

                palette.ButtonStyles.ButtonCommon.StateTracking.Content.ShortText.Color1 = normalTextColourPreview.BackColor;
                #endregion
            }
            else
            {
                #region Button Cluster
                palette.ButtonStyles.ButtonCluster.OverrideDefault.Back.Color1 = baseColour.BackColor;

                palette.ButtonStyles.ButtonCluster.OverrideFocus.Back.Color1 = baseColour.BackColor;

                palette.ButtonStyles.ButtonCluster.StateCheckedNormal.Back.Color1 = baseColour.BackColor;

                palette.ButtonStyles.ButtonCluster.StateCommon.Back.ColorStyle = PaletteColorStyle.GlassNormalFull;

                palette.ButtonStyles.ButtonCluster.StateNormal.Back.Color1 = mediumColour.BackColor;

                palette.ButtonStyles.ButtonCluster.StatePressed.Back.Color1 = darkColour.BackColor;

                palette.ButtonStyles.ButtonCluster.StateTracking.Back.Color1 = baseColour.BackColor;
                #endregion

                #region Button Common
                palette.ButtonStyles.ButtonCommon.OverrideDefault.Back.Color1 = baseColour.BackColor;

                palette.ButtonStyles.ButtonCommon.OverrideDefault.Content.LongText.Color1 = alternativeNormalTextColourPreview.BackColor;

                palette.ButtonStyles.ButtonCommon.OverrideDefault.Content.ShortText.Color1 = alternativeNormalTextColourPreview.BackColor;

                palette.ButtonStyles.ButtonCommon.StateCheckedNormal.Back.Color1 = lightestColour.BackColor;

                palette.ButtonStyles.ButtonCommon.StateCheckedNormal.Back.Color2 = lightColour.BackColor;

                palette.ButtonStyles.ButtonCommon.StateCheckedNormal.Back.ColorStyle = PaletteColorStyle.GlassCheckedFull;

                palette.ButtonStyles.ButtonCommon.StateCheckedNormal.Content.LongText.Color1 = normalTextColourPreview.BackColor;

                palette.ButtonStyles.ButtonCommon.StateCheckedNormal.Content.ShortText.Color1 = normalTextColourPreview.BackColor;

                palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Back.Color1 = lightestColour.BackColor;

                palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Back.Color2 = lightColour.BackColor;

                palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Back.ColorStyle = PaletteColorStyle.GlassCheckedStump;

                palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Border.DrawBorders = PaletteDrawBorders.All;

                palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Content.LongText.Color1 = normalTextColourPreview.BackColor;

                palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Content.ShortText.Color1 = normalTextColourPreview.BackColor;

                palette.ButtonStyles.ButtonCommon.StateCheckedTracking.Back.Color1 = lightestColour.BackColor;

                palette.ButtonStyles.ButtonCommon.StateCheckedTracking.Back.Color2 = lightColour.BackColor;

                palette.ButtonStyles.ButtonCommon.StateCheckedTracking.Border.DrawBorders = PaletteDrawBorders.All;

                palette.ButtonStyles.ButtonCommon.StateCheckedTracking.Content.LongText.Color1 = normalTextColourPreview.BackColor;

                palette.ButtonStyles.ButtonCommon.StateCheckedTracking.Content.ShortText.Color1 = normalTextColourPreview.BackColor;

                palette.ButtonStyles.ButtonCommon.StateCommon.Back.Color1 = baseColour.BackColor;

                palette.ButtonStyles.ButtonCommon.StateDisabled.Back.Color1 = disabledColourPreview.BackColor;

                palette.ButtonStyles.ButtonCommon.StateDisabled.Back.Color2 = disabledColourPreview.BackColor;

                /*
                palette.ButtonStyles.ButtonCommon.StateDisabled.Back.Color1 = baseColour.BackColor;

                palette.ButtonStyles.ButtonCommon.StateDisabled.Back.Color2 = baseColour.BackColor;
                */

                palette.ButtonStyles.ButtonCommon.StateDisabled.Content.LongText.Color1 = disabledTextColourPreview.BackColor;

                palette.ButtonStyles.ButtonCommon.StateDisabled.Content.ShortText.Color1 = disabledTextColourPreview.BackColor;

                palette.ButtonStyles.ButtonCommon.StateNormal.Back.Color1 = baseColour.BackColor;

                palette.ButtonStyles.ButtonCommon.StateNormal.Back.Color2 = baseColour.BackColor;

                palette.ButtonStyles.ButtonCommon.StateNormal.Content.LongText.Color1 = alternativeNormalTextColourPreview.BackColor;

                palette.ButtonStyles.ButtonCommon.StateNormal.Content.LongText.Color2 = alternativeNormalTextColourPreview.BackColor;

                palette.ButtonStyles.ButtonCommon.StateNormal.Content.ShortText.Color1 = alternativeNormalTextColourPreview.BackColor;

                palette.ButtonStyles.ButtonCommon.StateNormal.Content.ShortText.Color2 = alternativeNormalTextColourPreview.BackColor;

                palette.ButtonStyles.ButtonCommon.StatePressed.Back.Color1 = lightestColour.BackColor;

                palette.ButtonStyles.ButtonCommon.StatePressed.Back.Color2 = lightColour.BackColor;

                palette.ButtonStyles.ButtonCommon.StatePressed.Content.LongText.Color1 = normalTextColourPreview.BackColor;

                palette.ButtonStyles.ButtonCommon.StatePressed.Content.ShortText.Color1 = normalTextColourPreview.BackColor;

                palette.ButtonStyles.ButtonCommon.StateTracking.Back.Color1 = baseColour.BackColor;

                palette.ButtonStyles.ButtonCommon.StateTracking.Back.Color2 = darkColour.BackColor;

                palette.ButtonStyles.ButtonCommon.StateTracking.Content.LongText.Color1 = alternativeNormalTextColourPreview.BackColor;

                palette.ButtonStyles.ButtonCommon.StateTracking.Content.ShortText.Color1 = alternativeNormalTextColourPreview.BackColor;
                #endregion

                #region Common
                palette.Common.StateCommon.Back.Color1 = lightestColour.BackColor;

                palette.Common.StateCommon.Back.Color2 = baseColour.BackColor;

                palette.Common.StateCommon.Border.Color1 = baseColour.BackColor;

                palette.Common.StateCommon.Border.Color2 = darkColour.BackColor;

                palette.Common.StateCommon.Border.DrawBorders = PaletteDrawBorders.All;

                palette.Common.StateCommon.Content.LongText.Color1 = alternativeNormalTextColourPreview.BackColor;

                palette.Common.StateCommon.Content.LongText.Color2 = alternativeNormalTextColourPreview.BackColor;

                palette.Common.StateCommon.Content.ShortText.Color1 = alternativeNormalTextColourPreview.BackColor;

                palette.Common.StateCommon.Content.ShortText.Color2 = alternativeNormalTextColourPreview.BackColor;
                #endregion

                #region Form Styles
                palette.FormStyles.FormCommon.StateActive.Back.Color1 = baseColour.BackColor;

                palette.FormStyles.FormCommon.StateActive.Border.DrawBorders = PaletteDrawBorders.All;
                #endregion

                #region Grid Styles
                palette.GridStyles.GridSheet.StateCommon.HeaderColumn.Content.Color1 = lightestColour.BackColor;

                palette.GridStyles.GridSheet.StateCommon.HeaderRow.Content.Color1 = lightestColour.BackColor;

                palette.GridStyles.GridSheet.StateNormal.HeaderColumn.Content.Color1 = darkColour.BackColor;

                palette.GridStyles.GridSheet.StateNormal.HeaderColumn.Content.Color2 = mediumColour.BackColor;

                palette.GridStyles.GridSheet.StateNormal.HeaderRow.Content.Color1 = darkColour.BackColor;

                palette.GridStyles.GridSheet.StateTracking.HeaderColumn.Content.Color1 = baseColour.BackColor;
                #endregion

                #region Header Styles
                palette.HeaderStyles.HeaderCommon.StateCommon.Back.Color1 = mediumColour.BackColor;

                palette.HeaderStyles.HeaderCommon.StateCommon.Back.Color2 = lightColour.BackColor;

                palette.HeaderStyles.HeaderCommon.StateDisabled.Back.Color1 = lightColour.BackColor;

                palette.HeaderStyles.HeaderCommon.StateDisabled.Back.Color2 = lightestColour.BackColor;

                palette.HeaderStyles.HeaderCommon.StateDisabled.Content.LongText.Color1 = disabledTextColourPreview.BackColor;

                palette.HeaderStyles.HeaderCommon.StateDisabled.Content.LongText.Color2 = baseColour.BackColor;

                palette.HeaderStyles.HeaderCommon.StateDisabled.Content.ShortText.Color1 = disabledTextColourPreview.BackColor;

                palette.HeaderStyles.HeaderCommon.StateDisabled.Content.ShortText.Color2 = baseColour.BackColor;

                palette.HeaderStyles.HeaderForm.StateCommon.Back.Color1 = mediumColour.BackColor;

                palette.HeaderStyles.HeaderForm.StateCommon.Back.Color2 = lightColour.BackColor;

                palette.HeaderStyles.HeaderForm.StateDisabled.Back.Color1 = disabledColourPreview.BackColor;

                palette.HeaderStyles.HeaderForm.StateDisabled.Back.Color2 = baseColour.BackColor;

                palette.HeaderStyles.HeaderForm.StateDisabled.Content.LongText.Color1 = disabledTextColourPreview.BackColor;

                palette.HeaderStyles.HeaderForm.StateDisabled.Content.ShortText.Color1 = disabledTextColourPreview.BackColor;
                #endregion

                #region Label Styles
                palette.LabelStyles.LabelNormalControl.OverrideNotVisited.LongText.Color1 = linkNormalColourPreview.BackColor;

                palette.LabelStyles.LabelNormalControl.OverrideNotVisited.ShortText.Color1 = linkNormalColourPreview.BackColor;

                palette.LabelStyles.LabelNormalControl.OverridePressed.LongText.Color1 = linkHoverColourPreview.BackColor;

                palette.LabelStyles.LabelNormalControl.OverridePressed.ShortText.Color1 = linkHoverColourPreview.BackColor;

                palette.LabelStyles.LabelNormalControl.OverrideVisited.LongText.Color1 = linkVisitedColourPreview.BackColor;

                palette.LabelStyles.LabelNormalControl.OverrideVisited.ShortText.Color1 = linkVisitedColourPreview.BackColor;

                palette.LabelStyles.LabelNormalControl.OverrideFocus.LongText.Color1 = linkFocusedColourPreview.BackColor;

                palette.LabelStyles.LabelNormalControl.OverrideFocus.ShortText.Color1 = linkFocusedColourPreview.BackColor;

                palette.LabelStyles.LabelNormalControl.StateDisabled.LongText.Color1 = disabledTextColourPreview.BackColor;

                palette.LabelStyles.LabelNormalControl.StateDisabled.ShortText.Color1 = disabledTextColourPreview.BackColor;

                palette.LabelStyles.LabelNormalControl.StateNormal.LongText.Color1 = normalTextColourPreview.BackColor;

                palette.LabelStyles.LabelNormalControl.StateNormal.ShortText.Color1 = normalTextColourPreview.BackColor;
                #endregion

                #region Ribbon
                palette.Ribbon.RibbonAppButton.StateCommon.BackColor2 = baseColour.BackColor;

                palette.Ribbon.RibbonAppButton.StateCommon.BackColor3 = customColourThree.BackColor;

                palette.Ribbon.RibbonAppButton.StateCommon.BackColor5 = baseColour.BackColor;

                palette.Ribbon.RibbonAppButton.StatePressed.BackColor5 = darkColour.BackColor;

                palette.Ribbon.RibbonAppButton.StateTracking.BackColor5 = customColourFive.BackColor;

                palette.Ribbon.RibbonGroupArea.StateCheckedNormal.BackColor1 = baseColour.BackColor;

                palette.Ribbon.RibbonGroupArea.StateCheckedNormal.BackColor2 = customColourTwo.BackColor;

                palette.Ribbon.RibbonGroupArea.StateCheckedNormal.BackColor3 = baseColour.BackColor;

                palette.Ribbon.RibbonGroupArea.StateCheckedNormal.BackColor4 = baseColour.BackColor;

                palette.Ribbon.RibbonGroupArea.StateCheckedNormal.BackColor5 = baseColour.BackColor;

                palette.Ribbon.RibbonGroupButtonText.StateCommon.TextColor = customTextColourTwo.BackColor;

                palette.Ribbon.RibbonGroupCheckBoxText.StateCommon.TextColor = customTextColourTwo.BackColor;

                palette.Ribbon.RibbonGroupCollapsedBack.StateNormal.BackColor1 = SystemColors.Window;

                palette.Ribbon.RibbonGroupCollapsedBack.StateNormal.BackColor2 = baseColour.BackColor;

                palette.Ribbon.RibbonGroupCollapsedBack.StateNormal.BackColor3 = lightColour.BackColor;

                palette.Ribbon.RibbonGroupCollapsedBack.StateNormal.BackColor4 = baseColour.BackColor;

                palette.Ribbon.RibbonGroupCollapsedBack.StateTracking.BackColor1 = SystemColors.Window;

                palette.Ribbon.RibbonGroupCollapsedBack.StateTracking.BackColor2 = lightColour.BackColor;

                palette.Ribbon.RibbonGroupCollapsedBack.StateTracking.BackColor3 = lightestColour.BackColor; // Or 230, 230, 230

                palette.Ribbon.RibbonGroupCollapsedBack.StateTracking.BackColor4 = baseColour.BackColor;

                palette.Ribbon.RibbonGroupCollapsedBorder.StateCommon.BackColor1 = baseColour.BackColor;

                palette.Ribbon.RibbonGroupCollapsedBorder.StateCommon.BackColor2 = mediumColour.BackColor;

                palette.Ribbon.RibbonGroupCollapsedBorder.StateCommon.BackColor3 = lightColour.BackColor;

                palette.Ribbon.RibbonGroupCollapsedBorder.StateCommon.BackColor4 = baseColour.BackColor;

                palette.Ribbon.RibbonGroupCollapsedBorder.StateCommon.BackColor5 = baseColour.BackColor;

                palette.Ribbon.RibbonGroupCollapsedFrameBack.StateCommon.BackColor1 = baseColour.BackColor;

                palette.Ribbon.RibbonGroupCollapsedFrameBack.StateCommon.BackColor2 = baseColour.BackColor;

                palette.Ribbon.RibbonGroupCollapsedFrameBack.StateCommon.BackColor3 = lightColour.BackColor;

                palette.Ribbon.RibbonGroupCollapsedFrameBack.StateCommon.BackColor4 = lightColour.BackColor;

                palette.Ribbon.RibbonGroupCollapsedFrameBack.StateCommon.BackColor5 = baseColour.BackColor;

                palette.Ribbon.RibbonGroupCollapsedFrameBorder.StateCommon.BackColor1 = lightColour.BackColor;

                palette.Ribbon.RibbonGroupCollapsedFrameBorder.StateCommon.BackColor2 = lightestColour.BackColor; // Or 230, 230, 230

                palette.Ribbon.RibbonGroupCollapsedText.StateCommon.TextColor = alternativeNormalTextColourPreview.BackColor;

                palette.Ribbon.RibbonGroupNormalBorder.StateCommon.BackColor1 = baseColour.BackColor;

                palette.Ribbon.RibbonGroupNormalBorder.StateCommon.BackColor2 = mediumColour.BackColor;

                palette.Ribbon.RibbonGroupNormalTitle.StateCommon.BackColor1 = lightestColour.BackColor; // Or 230, 230, 230

                palette.Ribbon.RibbonGroupNormalTitle.StateCommon.BackColor2 = mediumColour.BackColor;

                palette.Ribbon.RibbonGroupNormalTitle.StateCommon.TextColor = customTextColourFive.BackColor;

                palette.Ribbon.RibbonGroupNormalTitle.StateTracking.BackColor1 = lightestColour.BackColor;

                palette.Ribbon.RibbonGroupNormalTitle.StateTracking.BackColor2 = mediumColour.BackColor;

                palette.Ribbon.RibbonQATFullbar.BackColor1 = mediumColour.BackColor;

                palette.Ribbon.RibbonQATFullbar.BackColor2 = mediumColour.BackColor;

                palette.Ribbon.RibbonQATFullbar.BackColor3 = mediumColour.BackColor;

                palette.Ribbon.RibbonQATMinibar.StateCommon.BackColor1 = mediumColour.BackColor;

                palette.Ribbon.RibbonQATMinibar.StateCommon.BackColor2 = mediumColour.BackColor;

                palette.Ribbon.RibbonQATMinibar.StateCommon.BackColor3 = mediumColour.BackColor;

                palette.Ribbon.RibbonQATMinibar.StateCommon.BackColor4 = mediumColour.BackColor;

                palette.Ribbon.RibbonQATOverflow.BackColor1 = mediumColour.BackColor;

                palette.Ribbon.RibbonQATOverflow.BackColor2 = mediumColour.BackColor;

                palette.Ribbon.RibbonTab.StateCheckedTracking.BackColor1 = mediumColour.BackColor;

                palette.Ribbon.RibbonTab.StateCheckedTracking.BackColor2 = lightColour.BackColor;

                palette.Ribbon.RibbonTab.StateCheckedTracking.BackColor3 = darkColour.BackColor;

                palette.Ribbon.RibbonTab.StateCheckedTracking.BackColor4 = mediumColour.BackColor;

                palette.Ribbon.RibbonTab.StateCommon.BackColor1 = mediumColour.BackColor;

                palette.Ribbon.RibbonTab.StateCommon.BackColor3 = mediumColour.BackColor;

                palette.Ribbon.RibbonTab.StateCommon.BackColor4 = lightColour.BackColor;

                palette.Ribbon.RibbonTab.StateCommon.BackColor5 = lightColour.BackColor;

                palette.Ribbon.RibbonTab.StateCommon.TextColor = normalTextColourPreview.BackColor;

                palette.Ribbon.RibbonTab.StateContextCheckedTracking.BackColor2 = mediumColour.BackColor;

                palette.Ribbon.RibbonTab.StateTracking.BackColor2 = mediumColour.BackColor;

                palette.Ribbon.RibbonTab.StateNormal.TextColor = ribbonTabTextColour.BackColor;
                #endregion

                #region Separator Styles
                palette.SeparatorStyles.SeparatorCommon.StateCommon.Back.Color1 = baseColour.BackColor;

                palette.SeparatorStyles.SeparatorCommon.StateCommon.Back.Color2 = baseColour.BackColor;

                palette.SeparatorStyles.SeparatorCommon.StateCommon.Border.Color1 = baseColour.BackColor;

                palette.SeparatorStyles.SeparatorCommon.StateCommon.Border.Color1 = baseColour.BackColor;

                palette.SeparatorStyles.SeparatorCommon.StateCommon.Border.DrawBorders = PaletteDrawBorders.All;
                #endregion

                #region Tool Menu Status
                palette.ToolMenuStatus.Button.ButtonPressedBorder = baseColour.BackColor;

                palette.ToolMenuStatus.Button.ButtonSelectedBorder = baseColour.BackColor;

                palette.ToolMenuStatus.Button.OverflowButtonGradientBegin = darkColour.BackColor;

                palette.ToolMenuStatus.Button.OverflowButtonGradientEnd = baseColour.BackColor;

                palette.ToolMenuStatus.Button.OverflowButtonGradientMiddle = mediumColour.BackColor;

                palette.ToolMenuStatus.Grip.GripDark = baseColour.BackColor;

                palette.ToolMenuStatus.Grip.GripLight = customColourFive.BackColor;

                palette.ToolMenuStatus.Menu.ImageMarginGradientBegin = baseColour.BackColor;

                palette.ToolMenuStatus.Menu.ImageMarginGradientEnd = darkColour.BackColor;

                palette.ToolMenuStatus.Menu.ImageMarginGradientMiddle = mediumColour.BackColor;

                palette.ToolMenuStatus.Menu.ImageMarginRevealedGradientBegin = baseColour.BackColor;

                palette.ToolMenuStatus.Menu.ImageMarginRevealedGradientEnd = darkColour.BackColor;

                palette.ToolMenuStatus.Menu.ImageMarginRevealedGradientMiddle = mediumColour.BackColor;

                palette.ToolMenuStatus.Menu.MenuBorder = baseColour.BackColor;

                palette.ToolMenuStatus.Menu.MenuItemBorder = darkColour.BackColor;

                palette.ToolMenuStatus.Menu.MenuItemPressedGradientBegin = baseColour.BackColor;

                palette.ToolMenuStatus.Menu.MenuItemPressedGradientEnd = darkColour.BackColor;

                palette.ToolMenuStatus.Menu.MenuItemPressedGradientMiddle = mediumColour.BackColor;

                palette.ToolMenuStatus.Menu.MenuItemSelected = mediumColour.BackColor;

                palette.ToolMenuStatus.Menu.MenuItemSelectedGradientBegin = darkColour.BackColor;

                palette.ToolMenuStatus.Menu.MenuItemSelectedGradientEnd = baseColour.BackColor;

                palette.ToolMenuStatus.Menu.MenuItemText = menuTextColour.BackColor;

                palette.ToolMenuStatus.MenuStrip.MenuStripGradientBegin = baseColour.BackColor;

                palette.ToolMenuStatus.MenuStrip.MenuStripGradientEnd = darkColour.BackColor;

                palette.ToolMenuStatus.MenuStrip.MenuStripText = normalTextColourPreview.BackColor;

                palette.ToolMenuStatus.Rafting.RaftingContainerGradientBegin = mediumColour.BackColor;

                palette.ToolMenuStatus.Rafting.RaftingContainerGradientEnd = darkColour.BackColor;

                palette.ToolMenuStatus.Separator.SeparatorDark = baseColour.BackColor;

                palette.ToolMenuStatus.Separator.SeparatorLight = lightColour.BackColor;

                palette.ToolMenuStatus.StatusStrip.StatusStripGradientBegin = baseColour.BackColor;

                palette.ToolMenuStatus.StatusStrip.StatusStripGradientEnd = lightColour.BackColor;

                palette.ToolMenuStatus.StatusStrip.StatusStripText = normalTextColourPreview.BackColor;

                palette.ToolMenuStatus.ToolStrip.ToolStripBorder = darkColour.BackColor;

                palette.ToolMenuStatus.ToolStrip.ToolStripContentPanelGradientBegin = lightColour.BackColor;

                palette.ToolMenuStatus.ToolStrip.ToolStripContentPanelGradientEnd = darkColour.BackColor;

                palette.ToolMenuStatus.ToolStrip.ToolStripDropDownBackground = mediumColour.BackColor;

                palette.ToolMenuStatus.ToolStrip.ToolStripGradientBegin = darkColour.BackColor;

                palette.ToolMenuStatus.ToolStrip.ToolStripGradientEnd = lightColour.BackColor;

                palette.ToolMenuStatus.ToolStrip.ToolStripGradientMiddle = mediumColour.BackColor;

                palette.ToolMenuStatus.ToolStrip.ToolStripPanelGradientBegin = lightColour.BackColor;

                palette.ToolMenuStatus.ToolStrip.ToolStripPanelGradientEnd = darkColour.BackColor;

                palette.ToolMenuStatus.ToolStrip.ToolStripText = normalTextColourPreview.BackColor;
                #endregion
            }

            palette.Export();

            statusState.Text = $"Palette exported to: { palette.GetCustomisedKryptonPaletteFilePath() }";
            //}
            //catch (Exception exc)
            //{
            //    statusState.Text = $"An error has occurred: { exc.Message }";
            //}
        }


        /// <summary>Exports the palette theme.</summary>
        /// <param name="palette">The palette.</param>
        /// <param name="paletteMode">The palette mode.</param>
        /// <param name="baseColour">The base colour.</param>
        /// <param name="darkColour">The dark colour.</param>
        /// <param name="mediumColour">The medium colour.</param>
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
        /// <param name="linkFocusedColourPreview">The link focused colour preview.</param>
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
        /// <param name="ribbonTabTextColour">The ribbon tab text colour.</param>
        /// <param name="invertColours">if set to <c>true</c> [invert colours].</param>
        public static void ExportPaletteTheme(KryptonPalette palette, PaletteMode paletteMode, Color baseColour, Color darkColour, Color mediumColour, Color lightColour, Color lightestColour, Color borderColourPreview, Color alternativeNormalTextColourPreview, Color normalTextColourPreview, Color disabledTextColourPreview, Color focusedTextColourPreview, Color pressedTextColourPreview, Color disabledColourPreview, Color linkNormalColourPreview, Color linkFocusedColourPreview, Color linkHoverColourPreview, Color linkVisitedColourPreview, Color customColourOne, Color customColourTwo, Color customColourThree, Color customColourFour, Color customColourFive, Color customTextColourOne, Color customTextColourTwo, Color customTextColourThree, Color customTextColourFour, Color customTextColourFive, Color menuTextColour, Color statusTextColour, Color ribbonTabTextColour, bool invertColours = false)
        {
            try
            {
                palette.BasePaletteMode = paletteMode;

                if (invertColours)
                {

                }
                else
                {
                    #region Button Cluster
                    palette.ButtonStyles.ButtonCluster.OverrideDefault.Back.Color1 = baseColour;

                    palette.ButtonStyles.ButtonCluster.OverrideFocus.Back.Color1 = baseColour;

                    palette.ButtonStyles.ButtonCluster.StateCheckedNormal.Back.Color1 = baseColour;

                    palette.ButtonStyles.ButtonCluster.StateCommon.Back.ColorStyle = PaletteColorStyle.GlassNormalFull;

                    palette.ButtonStyles.ButtonCluster.StateNormal.Back.Color1 = mediumColour;

                    palette.ButtonStyles.ButtonCluster.StatePressed.Back.Color1 = darkColour;

                    palette.ButtonStyles.ButtonCluster.StateTracking.Back.Color1 = baseColour;
                    #endregion

                    #region Button Common
                    palette.ButtonStyles.ButtonCommon.OverrideDefault.Back.Color1 = baseColour;

                    palette.ButtonStyles.ButtonCommon.OverrideDefault.Content.LongText.Color1 = alternativeNormalTextColourPreview;

                    palette.ButtonStyles.ButtonCommon.OverrideDefault.Content.ShortText.Color1 = alternativeNormalTextColourPreview;

                    palette.ButtonStyles.ButtonCommon.StateCheckedNormal.Back.Color1 = lightestColour;

                    palette.ButtonStyles.ButtonCommon.StateCheckedNormal.Back.Color2 = lightColour;

                    palette.ButtonStyles.ButtonCommon.StateCheckedNormal.Back.ColorStyle = PaletteColorStyle.GlassCheckedFull;

                    palette.ButtonStyles.ButtonCommon.StateCheckedNormal.Content.LongText.Color1 = normalTextColourPreview;

                    palette.ButtonStyles.ButtonCommon.StateCheckedNormal.Content.ShortText.Color1 = normalTextColourPreview;

                    palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Back.Color1 = lightestColour;

                    palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Back.Color2 = lightColour;

                    palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Back.ColorStyle = PaletteColorStyle.GlassCheckedStump;

                    palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Border.DrawBorders = PaletteDrawBorders.All;

                    palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Content.LongText.Color1 = normalTextColourPreview;

                    palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Content.ShortText.Color1 = normalTextColourPreview;

                    palette.ButtonStyles.ButtonCommon.StateCheckedTracking.Back.Color1 = lightestColour;

                    palette.ButtonStyles.ButtonCommon.StateCheckedTracking.Back.Color2 = lightColour;

                    palette.ButtonStyles.ButtonCommon.StateCheckedTracking.Border.DrawBorders = PaletteDrawBorders.All;

                    palette.ButtonStyles.ButtonCommon.StateCheckedTracking.Content.LongText.Color1 = normalTextColourPreview;

                    palette.ButtonStyles.ButtonCommon.StateCheckedTracking.Content.ShortText.Color1 = normalTextColourPreview;

                    palette.ButtonStyles.ButtonCommon.StateCommon.Back.Color1 = baseColour;

                    palette.ButtonStyles.ButtonCommon.StateDisabled.Back.Color1 = disabledColourPreview;

                    palette.ButtonStyles.ButtonCommon.StateDisabled.Back.Color2 = disabledColourPreview;

                    /*
                    palette.ButtonStyles.ButtonCommon.StateDisabled.Back.Color1 = baseColour;

                    palette.ButtonStyles.ButtonCommon.StateDisabled.Back.Color2 = baseColour;
                    */

                    palette.ButtonStyles.ButtonCommon.StateDisabled.Content.LongText.Color1 = disabledTextColourPreview;

                    palette.ButtonStyles.ButtonCommon.StateDisabled.Content.ShortText.Color1 = disabledTextColourPreview;

                    palette.ButtonStyles.ButtonCommon.StateNormal.Back.Color1 = baseColour;

                    palette.ButtonStyles.ButtonCommon.StateNormal.Back.Color2 = baseColour;

                    palette.ButtonStyles.ButtonCommon.StateNormal.Content.LongText.Color1 = alternativeNormalTextColourPreview;

                    palette.ButtonStyles.ButtonCommon.StateNormal.Content.LongText.Color2 = alternativeNormalTextColourPreview;

                    palette.ButtonStyles.ButtonCommon.StateNormal.Content.ShortText.Color1 = alternativeNormalTextColourPreview;

                    palette.ButtonStyles.ButtonCommon.StateNormal.Content.ShortText.Color2 = alternativeNormalTextColourPreview;

                    palette.ButtonStyles.ButtonCommon.StatePressed.Back.Color1 = lightestColour;

                    palette.ButtonStyles.ButtonCommon.StatePressed.Back.Color2 = lightColour;

                    palette.ButtonStyles.ButtonCommon.StatePressed.Content.LongText.Color1 = normalTextColourPreview;

                    palette.ButtonStyles.ButtonCommon.StatePressed.Content.ShortText.Color1 = normalTextColourPreview;

                    palette.ButtonStyles.ButtonCommon.StateTracking.Back.Color1 = baseColour;

                    palette.ButtonStyles.ButtonCommon.StateTracking.Back.Color2 = darkColour;

                    palette.ButtonStyles.ButtonCommon.StateTracking.Content.LongText.Color1 = alternativeNormalTextColourPreview;

                    palette.ButtonStyles.ButtonCommon.StateTracking.Content.ShortText.Color1 = alternativeNormalTextColourPreview;
                    #endregion

                    #region Common
                    palette.Common.StateCommon.Back.Color1 = lightestColour;

                    palette.Common.StateCommon.Back.Color2 = baseColour;

                    palette.Common.StateCommon.Border.Color1 = baseColour;

                    palette.Common.StateCommon.Border.Color2 = darkColour;

                    palette.Common.StateCommon.Border.DrawBorders = PaletteDrawBorders.All;

                    palette.Common.StateCommon.Content.LongText.Color1 = alternativeNormalTextColourPreview;

                    palette.Common.StateCommon.Content.LongText.Color2 = alternativeNormalTextColourPreview;

                    palette.Common.StateCommon.Content.ShortText.Color1 = alternativeNormalTextColourPreview;

                    palette.Common.StateCommon.Content.ShortText.Color2 = alternativeNormalTextColourPreview;
                    #endregion

                    #region Form Styles
                    palette.FormStyles.FormCommon.StateActive.Back.Color1 = baseColour;

                    palette.FormStyles.FormCommon.StateActive.Border.DrawBorders = PaletteDrawBorders.All;
                    #endregion

                    #region Grid Styles
                    palette.GridStyles.GridSheet.StateCommon.HeaderColumn.Content.Color1 = lightestColour;

                    palette.GridStyles.GridSheet.StateCommon.HeaderRow.Content.Color1 = lightestColour;

                    palette.GridStyles.GridSheet.StateNormal.HeaderColumn.Content.Color1 = darkColour;

                    palette.GridStyles.GridSheet.StateNormal.HeaderColumn.Content.Color2 = mediumColour;

                    palette.GridStyles.GridSheet.StateNormal.HeaderRow.Content.Color1 = darkColour;

                    palette.GridStyles.GridSheet.StateTracking.HeaderColumn.Content.Color1 = baseColour;
                    #endregion

                    #region Header Styles
                    palette.HeaderStyles.HeaderCommon.StateCommon.Back.Color1 = mediumColour;

                    palette.HeaderStyles.HeaderCommon.StateCommon.Back.Color2 = lightColour;

                    palette.HeaderStyles.HeaderCommon.StateDisabled.Back.Color1 = lightColour;

                    palette.HeaderStyles.HeaderCommon.StateDisabled.Back.Color2 = lightestColour;

                    palette.HeaderStyles.HeaderCommon.StateDisabled.Content.LongText.Color1 = disabledTextColourPreview;

                    palette.HeaderStyles.HeaderCommon.StateDisabled.Content.LongText.Color2 = baseColour;

                    palette.HeaderStyles.HeaderCommon.StateDisabled.Content.ShortText.Color1 = disabledTextColourPreview;

                    palette.HeaderStyles.HeaderCommon.StateDisabled.Content.ShortText.Color2 = baseColour;

                    palette.HeaderStyles.HeaderForm.StateCommon.Back.Color1 = mediumColour;

                    palette.HeaderStyles.HeaderForm.StateCommon.Back.Color2 = lightColour;

                    palette.HeaderStyles.HeaderForm.StateDisabled.Back.Color1 = disabledColourPreview;

                    palette.HeaderStyles.HeaderForm.StateDisabled.Back.Color2 = baseColour;

                    palette.HeaderStyles.HeaderForm.StateDisabled.Content.LongText.Color1 = disabledTextColourPreview;

                    palette.HeaderStyles.HeaderForm.StateDisabled.Content.ShortText.Color1 = disabledTextColourPreview;
                    #endregion

                    #region Label Styles
                    palette.LabelStyles.LabelNormalControl.OverrideNotVisited.LongText.Color1 = linkNormalColourPreview;

                    palette.LabelStyles.LabelNormalControl.OverrideNotVisited.ShortText.Color1 = linkNormalColourPreview;

                    palette.LabelStyles.LabelNormalControl.OverridePressed.LongText.Color1 = linkHoverColourPreview;

                    palette.LabelStyles.LabelNormalControl.OverridePressed.ShortText.Color1 = linkHoverColourPreview;

                    palette.LabelStyles.LabelNormalControl.OverrideVisited.LongText.Color1 = linkVisitedColourPreview;

                    palette.LabelStyles.LabelNormalControl.OverrideVisited.ShortText.Color1 = linkVisitedColourPreview;

                    palette.LabelStyles.LabelNormalControl.OverrideFocus.LongText.Color1 = linkFocusedColourPreview;

                    palette.LabelStyles.LabelNormalControl.OverrideFocus.ShortText.Color1 = linkFocusedColourPreview;

                    palette.LabelStyles.LabelNormalControl.StateDisabled.LongText.Color1 = disabledTextColourPreview;

                    palette.LabelStyles.LabelNormalControl.StateDisabled.ShortText.Color1 = disabledTextColourPreview;

                    palette.LabelStyles.LabelNormalControl.StateNormal.LongText.Color1 = normalTextColourPreview;

                    palette.LabelStyles.LabelNormalControl.StateNormal.ShortText.Color1 = normalTextColourPreview;
                    #endregion

                    #region Ribbon
                    palette.Ribbon.RibbonAppButton.StateCommon.BackColor2 = baseColour;

                    palette.Ribbon.RibbonAppButton.StateCommon.BackColor3 = customColourThree;

                    palette.Ribbon.RibbonAppButton.StateCommon.BackColor5 = baseColour;

                    palette.Ribbon.RibbonAppButton.StatePressed.BackColor5 = darkColour;

                    palette.Ribbon.RibbonAppButton.StateTracking.BackColor5 = customColourFive;

                    palette.Ribbon.RibbonGroupArea.StateCheckedNormal.BackColor1 = baseColour;

                    palette.Ribbon.RibbonGroupArea.StateCheckedNormal.BackColor2 = customColourTwo;

                    palette.Ribbon.RibbonGroupArea.StateCheckedNormal.BackColor3 = baseColour;

                    palette.Ribbon.RibbonGroupArea.StateCheckedNormal.BackColor4 = baseColour;

                    palette.Ribbon.RibbonGroupArea.StateCheckedNormal.BackColor5 = baseColour;

                    palette.Ribbon.RibbonGroupButtonText.StateCommon.TextColor = customTextColourTwo;

                    palette.Ribbon.RibbonGroupCheckBoxText.StateCommon.TextColor = customTextColourTwo;

                    palette.Ribbon.RibbonGroupCollapsedBack.StateNormal.BackColor1 = SystemColors.Window;

                    palette.Ribbon.RibbonGroupCollapsedBack.StateNormal.BackColor2 = baseColour;

                    palette.Ribbon.RibbonGroupCollapsedBack.StateNormal.BackColor3 = lightColour;

                    palette.Ribbon.RibbonGroupCollapsedBack.StateNormal.BackColor4 = baseColour;

                    palette.Ribbon.RibbonGroupCollapsedBack.StateTracking.BackColor1 = SystemColors.Window;

                    palette.Ribbon.RibbonGroupCollapsedBack.StateTracking.BackColor2 = lightColour;

                    palette.Ribbon.RibbonGroupCollapsedBack.StateTracking.BackColor3 = lightestColour; // Or 230, 230, 230

                    palette.Ribbon.RibbonGroupCollapsedBack.StateTracking.BackColor4 = baseColour;

                    palette.Ribbon.RibbonGroupCollapsedBorder.StateCommon.BackColor1 = baseColour;

                    palette.Ribbon.RibbonGroupCollapsedBorder.StateCommon.BackColor2 = mediumColour;

                    palette.Ribbon.RibbonGroupCollapsedBorder.StateCommon.BackColor3 = lightColour;

                    palette.Ribbon.RibbonGroupCollapsedBorder.StateCommon.BackColor4 = baseColour;

                    palette.Ribbon.RibbonGroupCollapsedBorder.StateCommon.BackColor5 = baseColour;

                    palette.Ribbon.RibbonGroupCollapsedFrameBack.StateCommon.BackColor1 = baseColour;

                    palette.Ribbon.RibbonGroupCollapsedFrameBack.StateCommon.BackColor2 = baseColour;

                    palette.Ribbon.RibbonGroupCollapsedFrameBack.StateCommon.BackColor3 = lightColour;

                    palette.Ribbon.RibbonGroupCollapsedFrameBack.StateCommon.BackColor4 = lightColour;

                    palette.Ribbon.RibbonGroupCollapsedFrameBack.StateCommon.BackColor5 = baseColour;

                    palette.Ribbon.RibbonGroupCollapsedFrameBorder.StateCommon.BackColor1 = lightColour;

                    palette.Ribbon.RibbonGroupCollapsedFrameBorder.StateCommon.BackColor2 = lightestColour; // Or 230, 230, 230

                    palette.Ribbon.RibbonGroupCollapsedText.StateCommon.TextColor = alternativeNormalTextColourPreview;

                    palette.Ribbon.RibbonGroupNormalBorder.StateCommon.BackColor1 = baseColour;

                    palette.Ribbon.RibbonGroupNormalBorder.StateCommon.BackColor2 = mediumColour;

                    palette.Ribbon.RibbonGroupNormalTitle.StateCommon.BackColor1 = lightestColour; // Or 230, 230, 230

                    palette.Ribbon.RibbonGroupNormalTitle.StateCommon.BackColor2 = mediumColour;

                    palette.Ribbon.RibbonGroupNormalTitle.StateCommon.TextColor = customTextColourFive;

                    palette.Ribbon.RibbonGroupNormalTitle.StateTracking.BackColor1 = lightestColour;

                    palette.Ribbon.RibbonGroupNormalTitle.StateTracking.BackColor2 = mediumColour;

                    palette.Ribbon.RibbonQATFullbar.BackColor1 = mediumColour;

                    palette.Ribbon.RibbonQATFullbar.BackColor2 = mediumColour;

                    palette.Ribbon.RibbonQATFullbar.BackColor3 = mediumColour;

                    palette.Ribbon.RibbonQATMinibar.StateCommon.BackColor1 = mediumColour;

                    palette.Ribbon.RibbonQATMinibar.StateCommon.BackColor2 = mediumColour;

                    palette.Ribbon.RibbonQATMinibar.StateCommon.BackColor3 = mediumColour;

                    palette.Ribbon.RibbonQATMinibar.StateCommon.BackColor4 = mediumColour;

                    palette.Ribbon.RibbonQATOverflow.BackColor1 = mediumColour;

                    palette.Ribbon.RibbonQATOverflow.BackColor2 = mediumColour;

                    palette.Ribbon.RibbonTab.StateCheckedTracking.BackColor1 = mediumColour;

                    palette.Ribbon.RibbonTab.StateCheckedTracking.BackColor2 = lightColour;

                    palette.Ribbon.RibbonTab.StateCheckedTracking.BackColor3 = darkColour;

                    palette.Ribbon.RibbonTab.StateCheckedTracking.BackColor4 = mediumColour;

                    palette.Ribbon.RibbonTab.StateCommon.BackColor1 = mediumColour;

                    palette.Ribbon.RibbonTab.StateCommon.BackColor3 = mediumColour;

                    palette.Ribbon.RibbonTab.StateCommon.BackColor4 = lightColour;

                    palette.Ribbon.RibbonTab.StateCommon.BackColor5 = lightColour;

                    palette.Ribbon.RibbonTab.StateCommon.TextColor = normalTextColourPreview;

                    palette.Ribbon.RibbonTab.StateContextCheckedTracking.BackColor2 = mediumColour;

                    palette.Ribbon.RibbonTab.StateTracking.BackColor2 = mediumColour;

                    palette.Ribbon.RibbonTab.StateNormal.TextColor = ribbonTabTextColour;
                    #endregion

                    #region Separator Styles
                    palette.SeparatorStyles.SeparatorCommon.StateCommon.Back.Color1 = baseColour;

                    palette.SeparatorStyles.SeparatorCommon.StateCommon.Back.Color2 = baseColour;

                    palette.SeparatorStyles.SeparatorCommon.StateCommon.Border.Color1 = baseColour;

                    palette.SeparatorStyles.SeparatorCommon.StateCommon.Border.Color1 = baseColour;

                    palette.SeparatorStyles.SeparatorCommon.StateCommon.Border.DrawBorders = PaletteDrawBorders.All;
                    #endregion

                    #region Tool Menu Status
                    palette.ToolMenuStatus.Button.ButtonPressedBorder = baseColour;

                    palette.ToolMenuStatus.Button.ButtonSelectedBorder = baseColour;

                    palette.ToolMenuStatus.Button.OverflowButtonGradientBegin = darkColour;

                    palette.ToolMenuStatus.Button.OverflowButtonGradientEnd = baseColour;

                    palette.ToolMenuStatus.Button.OverflowButtonGradientMiddle = mediumColour;

                    palette.ToolMenuStatus.Grip.GripDark = baseColour;

                    palette.ToolMenuStatus.Grip.GripLight = customColourFive;

                    palette.ToolMenuStatus.Menu.ImageMarginGradientBegin = baseColour;

                    palette.ToolMenuStatus.Menu.ImageMarginGradientEnd = darkColour;

                    palette.ToolMenuStatus.Menu.ImageMarginGradientMiddle = mediumColour;

                    palette.ToolMenuStatus.Menu.ImageMarginRevealedGradientBegin = baseColour;

                    palette.ToolMenuStatus.Menu.ImageMarginRevealedGradientEnd = darkColour;

                    palette.ToolMenuStatus.Menu.ImageMarginRevealedGradientMiddle = mediumColour;

                    palette.ToolMenuStatus.Menu.MenuBorder = baseColour;

                    palette.ToolMenuStatus.Menu.MenuItemBorder = darkColour;

                    palette.ToolMenuStatus.Menu.MenuItemPressedGradientBegin = baseColour;

                    palette.ToolMenuStatus.Menu.MenuItemPressedGradientEnd = darkColour;

                    palette.ToolMenuStatus.Menu.MenuItemPressedGradientMiddle = mediumColour;

                    palette.ToolMenuStatus.Menu.MenuItemSelected = mediumColour;

                    palette.ToolMenuStatus.Menu.MenuItemSelectedGradientBegin = darkColour;

                    palette.ToolMenuStatus.Menu.MenuItemSelectedGradientEnd = baseColour;

                    palette.ToolMenuStatus.Menu.MenuItemText = menuTextColour;

                    palette.ToolMenuStatus.MenuStrip.MenuStripGradientBegin = baseColour;

                    palette.ToolMenuStatus.MenuStrip.MenuStripGradientEnd = darkColour;

                    palette.ToolMenuStatus.MenuStrip.MenuStripText = normalTextColourPreview;

                    palette.ToolMenuStatus.Rafting.RaftingContainerGradientBegin = mediumColour;

                    palette.ToolMenuStatus.Rafting.RaftingContainerGradientEnd = darkColour;

                    palette.ToolMenuStatus.Separator.SeparatorDark = baseColour;

                    palette.ToolMenuStatus.Separator.SeparatorLight = lightColour;

                    palette.ToolMenuStatus.StatusStrip.StatusStripGradientBegin = baseColour;

                    palette.ToolMenuStatus.StatusStrip.StatusStripGradientEnd = lightColour;

                    palette.ToolMenuStatus.StatusStrip.StatusStripText = normalTextColourPreview;

                    palette.ToolMenuStatus.ToolStrip.ToolStripBorder = darkColour;

                    palette.ToolMenuStatus.ToolStrip.ToolStripContentPanelGradientBegin = lightColour;

                    palette.ToolMenuStatus.ToolStrip.ToolStripContentPanelGradientEnd = darkColour;

                    palette.ToolMenuStatus.ToolStrip.ToolStripDropDownBackground = mediumColour;

                    palette.ToolMenuStatus.ToolStrip.ToolStripGradientBegin = darkColour;

                    palette.ToolMenuStatus.ToolStrip.ToolStripGradientEnd = lightColour;

                    palette.ToolMenuStatus.ToolStrip.ToolStripGradientMiddle = mediumColour;

                    palette.ToolMenuStatus.ToolStrip.ToolStripPanelGradientBegin = lightColour;

                    palette.ToolMenuStatus.ToolStrip.ToolStripPanelGradientEnd = darkColour;

                    palette.ToolMenuStatus.ToolStrip.ToolStripText = normalTextColourPreview;
                    #endregion

                    #region Trackbar
                    palette.TrackBar.StateCommon.Position.Color4 = darkColour;
                    #endregion
                }

                palette.Export();

                KryptonMessageBox.Show($"Palette exported to: { palette.GetCustomisedKryptonPaletteFilePath() }", "Export Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exc)
            {
                ExceptionHandler.CaptureException(exc);
            }
        }

        #region !EXPERIMENTAL CODE!               
        /// <summary>
        /// Exports the palette.
        /// </summary>
        /// <param name="paletteMode">The palette mode.</param>
        /// <param name="baseColour">The base colour.</param>
        /// <param name="darkColour">The dark colour.</param>
        /// <param name="mediumColour">The middle colour.</param>
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
        /// <param name="linkFocusedColourPreview">The link focused colour preview.</param>
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
        /// <param name="ribbonTabTextColour">The ribbon tab text colour.</param>
        /// <param name="invertColours">if set to <c>true</c> [invert colours].</param>
        public static void ExportPalette(PaletteMode paletteMode, PictureBox baseColour, PictureBox darkColour, PictureBox mediumColour, PictureBox lightColour, PictureBox lightestColour, PictureBox borderColourPreview, PictureBox alternativeNormalTextColourPreview, PictureBox normalTextColourPreview, PictureBox disabledTextColourPreview, PictureBox focusedTextColourPreview, PictureBox pressedTextColourPreview, PictureBox disabledColourPreview, PictureBox linkNormalColourPreview, PictureBox linkFocusedColourPreview, PictureBox linkHoverColourPreview, PictureBox linkVisitedColourPreview, PictureBox customColourOne, PictureBox customColourTwo, PictureBox customColourThree, PictureBox customColourFour, PictureBox customColourFive, PictureBox customTextColourOne, PictureBox customTextColourTwo, PictureBox customTextColourThree, PictureBox customTextColourFour, PictureBox customTextColourFive, PictureBox menuTextColour, PictureBox statusTextColour, PictureBox ribbonTabTextColour, bool invertColours = false)
        {
            KryptonPalette palette = new KryptonPalette();

            try
            {
                palette.BasePaletteMode = paletteMode;

                if (lightestColour.BackColor == Color.Transparent)
                {
                    lightestColour.BackColor = lightColour.BackColor;
                }

                if (invertColours)
                {

                }
                else
                {
                    #region Button Cluster
                    palette.ButtonStyles.ButtonCluster.OverrideDefault.Back.Color1 = baseColour.BackColor;

                    palette.ButtonStyles.ButtonCluster.OverrideFocus.Back.Color1 = baseColour.BackColor;

                    palette.ButtonStyles.ButtonCluster.StateCheckedNormal.Back.Color1 = baseColour.BackColor;

                    palette.ButtonStyles.ButtonCluster.StateCommon.Back.ColorStyle = PaletteColorStyle.GlassNormalFull;

                    palette.ButtonStyles.ButtonCluster.StateNormal.Back.Color1 = mediumColour.BackColor;

                    palette.ButtonStyles.ButtonCluster.StatePressed.Back.Color1 = darkColour.BackColor;

                    palette.ButtonStyles.ButtonCluster.StateTracking.Back.Color1 = baseColour.BackColor;
                    #endregion

                    #region Button Common
                    palette.ButtonStyles.ButtonCommon.OverrideDefault.Back.Color1 = baseColour.BackColor;

                    palette.ButtonStyles.ButtonCommon.OverrideDefault.Content.LongText.Color1 = alternativeNormalTextColourPreview.BackColor;

                    palette.ButtonStyles.ButtonCommon.OverrideDefault.Content.ShortText.Color1 = alternativeNormalTextColourPreview.BackColor;

                    palette.ButtonStyles.ButtonCommon.StateCheckedNormal.Back.Color1 = lightestColour.BackColor;

                    palette.ButtonStyles.ButtonCommon.StateCheckedNormal.Back.Color2 = lightColour.BackColor;

                    palette.ButtonStyles.ButtonCommon.StateCheckedNormal.Back.ColorStyle = PaletteColorStyle.GlassCheckedFull;

                    palette.ButtonStyles.ButtonCommon.StateCheckedNormal.Content.LongText.Color1 = normalTextColourPreview.BackColor;

                    palette.ButtonStyles.ButtonCommon.StateCheckedNormal.Content.ShortText.Color1 = normalTextColourPreview.BackColor;

                    palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Back.Color1 = lightestColour.BackColor;

                    palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Back.Color2 = lightColour.BackColor;

                    palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Back.ColorStyle = PaletteColorStyle.GlassCheckedStump;

                    palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Border.DrawBorders = PaletteDrawBorders.All;

                    palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Content.LongText.Color1 = normalTextColourPreview.BackColor;

                    palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Content.ShortText.Color1 = normalTextColourPreview.BackColor;

                    palette.ButtonStyles.ButtonCommon.StateCheckedTracking.Back.Color1 = lightestColour.BackColor;

                    palette.ButtonStyles.ButtonCommon.StateCheckedTracking.Back.Color2 = lightColour.BackColor;

                    palette.ButtonStyles.ButtonCommon.StateCheckedTracking.Border.DrawBorders = PaletteDrawBorders.All;

                    palette.ButtonStyles.ButtonCommon.StateCheckedTracking.Content.LongText.Color1 = normalTextColourPreview.BackColor;

                    palette.ButtonStyles.ButtonCommon.StateCheckedTracking.Content.ShortText.Color1 = normalTextColourPreview.BackColor;

                    palette.ButtonStyles.ButtonCommon.StateCommon.Back.Color1 = baseColour.BackColor;

                    palette.ButtonStyles.ButtonCommon.StateDisabled.Back.Color1 = disabledColourPreview.BackColor;

                    palette.ButtonStyles.ButtonCommon.StateDisabled.Back.Color2 = disabledColourPreview.BackColor;

                    /*
                    palette.ButtonStyles.ButtonCommon.StateDisabled.Back.Color1 = baseColour.BackColor;

                    palette.ButtonStyles.ButtonCommon.StateDisabled.Back.Color2 = baseColour.BackColor;
                    */

                    palette.ButtonStyles.ButtonCommon.StateDisabled.Content.LongText.Color1 = disabledTextColourPreview.BackColor;

                    palette.ButtonStyles.ButtonCommon.StateDisabled.Content.ShortText.Color1 = disabledTextColourPreview.BackColor;

                    palette.ButtonStyles.ButtonCommon.StateNormal.Back.Color1 = baseColour.BackColor;

                    palette.ButtonStyles.ButtonCommon.StateNormal.Back.Color2 = baseColour.BackColor;

                    palette.ButtonStyles.ButtonCommon.StateNormal.Content.LongText.Color1 = alternativeNormalTextColourPreview.BackColor;

                    palette.ButtonStyles.ButtonCommon.StateNormal.Content.LongText.Color2 = alternativeNormalTextColourPreview.BackColor;

                    palette.ButtonStyles.ButtonCommon.StateNormal.Content.ShortText.Color1 = alternativeNormalTextColourPreview.BackColor;

                    palette.ButtonStyles.ButtonCommon.StateNormal.Content.ShortText.Color2 = alternativeNormalTextColourPreview.BackColor;

                    palette.ButtonStyles.ButtonCommon.StatePressed.Back.Color1 = lightestColour.BackColor;

                    palette.ButtonStyles.ButtonCommon.StatePressed.Back.Color2 = lightColour.BackColor;

                    palette.ButtonStyles.ButtonCommon.StatePressed.Content.LongText.Color1 = normalTextColourPreview.BackColor;

                    palette.ButtonStyles.ButtonCommon.StatePressed.Content.ShortText.Color1 = normalTextColourPreview.BackColor;

                    palette.ButtonStyles.ButtonCommon.StateTracking.Back.Color1 = baseColour.BackColor;

                    palette.ButtonStyles.ButtonCommon.StateTracking.Back.Color2 = darkColour.BackColor;

                    palette.ButtonStyles.ButtonCommon.StateTracking.Content.LongText.Color1 = alternativeNormalTextColourPreview.BackColor;

                    palette.ButtonStyles.ButtonCommon.StateTracking.Content.ShortText.Color1 = alternativeNormalTextColourPreview.BackColor;
                    #endregion

                    #region Common
                    palette.Common.StateCommon.Back.Color1 = lightestColour.BackColor;

                    palette.Common.StateCommon.Back.Color2 = baseColour.BackColor;

                    palette.Common.StateCommon.Border.Color1 = baseColour.BackColor;

                    palette.Common.StateCommon.Border.Color2 = darkColour.BackColor;

                    palette.Common.StateCommon.Border.DrawBorders = PaletteDrawBorders.All;

                    palette.Common.StateCommon.Content.LongText.Color1 = alternativeNormalTextColourPreview.BackColor;

                    palette.Common.StateCommon.Content.LongText.Color2 = alternativeNormalTextColourPreview.BackColor;

                    palette.Common.StateCommon.Content.ShortText.Color1 = alternativeNormalTextColourPreview.BackColor;

                    palette.Common.StateCommon.Content.ShortText.Color2 = alternativeNormalTextColourPreview.BackColor;
                    #endregion

                    #region Form Styles
                    palette.FormStyles.FormCommon.StateActive.Back.Color1 = baseColour.BackColor;

                    palette.FormStyles.FormCommon.StateActive.Border.DrawBorders = PaletteDrawBorders.All;
                    #endregion

                    #region Grid Styles
                    palette.GridStyles.GridSheet.StateCommon.HeaderColumn.Content.Color1 = lightestColour.BackColor;

                    palette.GridStyles.GridSheet.StateCommon.HeaderRow.Content.Color1 = lightestColour.BackColor;

                    palette.GridStyles.GridSheet.StateNormal.HeaderColumn.Content.Color1 = darkColour.BackColor;

                    palette.GridStyles.GridSheet.StateNormal.HeaderColumn.Content.Color2 = mediumColour.BackColor;

                    palette.GridStyles.GridSheet.StateNormal.HeaderRow.Content.Color1 = darkColour.BackColor;

                    palette.GridStyles.GridSheet.StateTracking.HeaderColumn.Content.Color1 = baseColour.BackColor;
                    #endregion

                    #region Header Styles
                    palette.HeaderStyles.HeaderCommon.StateCommon.Back.Color1 = mediumColour.BackColor;

                    palette.HeaderStyles.HeaderCommon.StateCommon.Back.Color2 = lightColour.BackColor;

                    palette.HeaderStyles.HeaderCommon.StateDisabled.Back.Color1 = lightColour.BackColor;

                    palette.HeaderStyles.HeaderCommon.StateDisabled.Back.Color2 = lightestColour.BackColor;

                    palette.HeaderStyles.HeaderCommon.StateDisabled.Content.LongText.Color1 = disabledTextColourPreview.BackColor;

                    palette.HeaderStyles.HeaderCommon.StateDisabled.Content.LongText.Color2 = baseColour.BackColor;

                    palette.HeaderStyles.HeaderCommon.StateDisabled.Content.ShortText.Color1 = disabledTextColourPreview.BackColor;

                    palette.HeaderStyles.HeaderCommon.StateDisabled.Content.ShortText.Color2 = baseColour.BackColor;

                    palette.HeaderStyles.HeaderForm.StateCommon.Back.Color1 = mediumColour.BackColor;

                    palette.HeaderStyles.HeaderForm.StateCommon.Back.Color2 = lightColour.BackColor;

                    palette.HeaderStyles.HeaderForm.StateDisabled.Back.Color1 = disabledColourPreview.BackColor;

                    palette.HeaderStyles.HeaderForm.StateDisabled.Back.Color2 = baseColour.BackColor;

                    palette.HeaderStyles.HeaderForm.StateDisabled.Content.LongText.Color1 = disabledTextColourPreview.BackColor;

                    palette.HeaderStyles.HeaderForm.StateDisabled.Content.ShortText.Color1 = disabledTextColourPreview.BackColor;
                    #endregion

                    #region Label Styles
                    palette.LabelStyles.LabelNormalControl.OverrideNotVisited.LongText.Color1 = linkNormalColourPreview.BackColor;

                    palette.LabelStyles.LabelNormalControl.OverrideNotVisited.ShortText.Color1 = linkNormalColourPreview.BackColor;

                    palette.LabelStyles.LabelNormalControl.OverridePressed.LongText.Color1 = linkHoverColourPreview.BackColor;

                    palette.LabelStyles.LabelNormalControl.OverridePressed.ShortText.Color1 = linkHoverColourPreview.BackColor;

                    palette.LabelStyles.LabelNormalControl.OverrideVisited.LongText.Color1 = linkVisitedColourPreview.BackColor;

                    palette.LabelStyles.LabelNormalControl.OverrideVisited.ShortText.Color1 = linkVisitedColourPreview.BackColor;

                    palette.LabelStyles.LabelNormalControl.OverrideFocus.LongText.Color1 = linkFocusedColourPreview.BackColor;

                    palette.LabelStyles.LabelNormalControl.OverrideFocus.ShortText.Color1 = linkFocusedColourPreview.BackColor;

                    palette.LabelStyles.LabelNormalControl.StateDisabled.LongText.Color1 = disabledTextColourPreview.BackColor;

                    palette.LabelStyles.LabelNormalControl.StateDisabled.ShortText.Color1 = disabledTextColourPreview.BackColor;

                    palette.LabelStyles.LabelNormalControl.StateNormal.LongText.Color1 = normalTextColourPreview.BackColor;

                    palette.LabelStyles.LabelNormalControl.StateNormal.ShortText.Color1 = normalTextColourPreview.BackColor;
                    #endregion

                    #region Ribbon
                    palette.Ribbon.RibbonAppButton.StateCommon.BackColor2 = baseColour.BackColor;

                    palette.Ribbon.RibbonAppButton.StateCommon.BackColor3 = customColourThree.BackColor;

                    palette.Ribbon.RibbonAppButton.StateCommon.BackColor5 = baseColour.BackColor;

                    palette.Ribbon.RibbonAppButton.StatePressed.BackColor5 = darkColour.BackColor;

                    palette.Ribbon.RibbonAppButton.StateTracking.BackColor5 = customColourFive.BackColor;

                    palette.Ribbon.RibbonGroupArea.StateCheckedNormal.BackColor1 = baseColour.BackColor;

                    palette.Ribbon.RibbonGroupArea.StateCheckedNormal.BackColor2 = customColourTwo.BackColor;

                    palette.Ribbon.RibbonGroupArea.StateCheckedNormal.BackColor3 = baseColour.BackColor;

                    palette.Ribbon.RibbonGroupArea.StateCheckedNormal.BackColor4 = baseColour.BackColor;

                    palette.Ribbon.RibbonGroupArea.StateCheckedNormal.BackColor5 = baseColour.BackColor;

                    palette.Ribbon.RibbonGroupButtonText.StateCommon.TextColor = customTextColourTwo.BackColor;

                    palette.Ribbon.RibbonGroupCheckBoxText.StateCommon.TextColor = customTextColourTwo.BackColor;

                    palette.Ribbon.RibbonGroupCollapsedBack.StateNormal.BackColor1 = SystemColors.Window;

                    palette.Ribbon.RibbonGroupCollapsedBack.StateNormal.BackColor2 = baseColour.BackColor;

                    palette.Ribbon.RibbonGroupCollapsedBack.StateNormal.BackColor3 = lightColour.BackColor;

                    palette.Ribbon.RibbonGroupCollapsedBack.StateNormal.BackColor4 = baseColour.BackColor;

                    palette.Ribbon.RibbonGroupCollapsedBack.StateTracking.BackColor1 = SystemColors.Window;

                    palette.Ribbon.RibbonGroupCollapsedBack.StateTracking.BackColor2 = lightColour.BackColor;

                    palette.Ribbon.RibbonGroupCollapsedBack.StateTracking.BackColor3 = lightestColour.BackColor; // Or 230, 230, 230

                    palette.Ribbon.RibbonGroupCollapsedBack.StateTracking.BackColor4 = baseColour.BackColor;

                    palette.Ribbon.RibbonGroupCollapsedBorder.StateCommon.BackColor1 = baseColour.BackColor;

                    palette.Ribbon.RibbonGroupCollapsedBorder.StateCommon.BackColor2 = mediumColour.BackColor;

                    palette.Ribbon.RibbonGroupCollapsedBorder.StateCommon.BackColor3 = lightColour.BackColor;

                    palette.Ribbon.RibbonGroupCollapsedBorder.StateCommon.BackColor4 = baseColour.BackColor;

                    palette.Ribbon.RibbonGroupCollapsedBorder.StateCommon.BackColor5 = baseColour.BackColor;

                    palette.Ribbon.RibbonGroupCollapsedFrameBack.StateCommon.BackColor1 = baseColour.BackColor;

                    palette.Ribbon.RibbonGroupCollapsedFrameBack.StateCommon.BackColor2 = baseColour.BackColor;

                    palette.Ribbon.RibbonGroupCollapsedFrameBack.StateCommon.BackColor3 = lightColour.BackColor;

                    palette.Ribbon.RibbonGroupCollapsedFrameBack.StateCommon.BackColor4 = lightColour.BackColor;

                    palette.Ribbon.RibbonGroupCollapsedFrameBack.StateCommon.BackColor5 = baseColour.BackColor;

                    palette.Ribbon.RibbonGroupCollapsedFrameBorder.StateCommon.BackColor1 = lightColour.BackColor;

                    palette.Ribbon.RibbonGroupCollapsedFrameBorder.StateCommon.BackColor2 = lightestColour.BackColor; // Or 230, 230, 230

                    palette.Ribbon.RibbonGroupCollapsedText.StateCommon.TextColor = alternativeNormalTextColourPreview.BackColor;

                    palette.Ribbon.RibbonGroupNormalBorder.StateCommon.BackColor1 = baseColour.BackColor;

                    palette.Ribbon.RibbonGroupNormalBorder.StateCommon.BackColor2 = mediumColour.BackColor;

                    palette.Ribbon.RibbonGroupNormalTitle.StateCommon.BackColor1 = lightestColour.BackColor; // Or 230, 230, 230

                    palette.Ribbon.RibbonGroupNormalTitle.StateCommon.BackColor2 = mediumColour.BackColor;

                    palette.Ribbon.RibbonGroupNormalTitle.StateCommon.TextColor = customTextColourFive.BackColor;

                    palette.Ribbon.RibbonGroupNormalTitle.StateTracking.BackColor1 = lightestColour.BackColor;

                    palette.Ribbon.RibbonGroupNormalTitle.StateTracking.BackColor2 = mediumColour.BackColor;

                    palette.Ribbon.RibbonQATFullbar.BackColor1 = mediumColour.BackColor;

                    palette.Ribbon.RibbonQATFullbar.BackColor2 = mediumColour.BackColor;

                    palette.Ribbon.RibbonQATFullbar.BackColor3 = mediumColour.BackColor;

                    palette.Ribbon.RibbonQATMinibar.StateCommon.BackColor1 = mediumColour.BackColor;

                    palette.Ribbon.RibbonQATMinibar.StateCommon.BackColor2 = mediumColour.BackColor;

                    palette.Ribbon.RibbonQATMinibar.StateCommon.BackColor3 = mediumColour.BackColor;

                    palette.Ribbon.RibbonQATMinibar.StateCommon.BackColor4 = mediumColour.BackColor;

                    palette.Ribbon.RibbonQATOverflow.BackColor1 = mediumColour.BackColor;

                    palette.Ribbon.RibbonQATOverflow.BackColor2 = mediumColour.BackColor;

                    palette.Ribbon.RibbonTab.StateCheckedTracking.BackColor1 = mediumColour.BackColor;

                    palette.Ribbon.RibbonTab.StateCheckedTracking.BackColor2 = lightColour.BackColor;

                    palette.Ribbon.RibbonTab.StateCheckedTracking.BackColor3 = darkColour.BackColor;

                    palette.Ribbon.RibbonTab.StateCheckedTracking.BackColor4 = mediumColour.BackColor;

                    palette.Ribbon.RibbonTab.StateCommon.BackColor1 = mediumColour.BackColor;

                    palette.Ribbon.RibbonTab.StateCommon.BackColor3 = mediumColour.BackColor;

                    palette.Ribbon.RibbonTab.StateCommon.BackColor4 = lightColour.BackColor;

                    palette.Ribbon.RibbonTab.StateCommon.BackColor5 = lightColour.BackColor;

                    palette.Ribbon.RibbonTab.StateCommon.TextColor = normalTextColourPreview.BackColor;

                    palette.Ribbon.RibbonTab.StateContextCheckedTracking.BackColor2 = mediumColour.BackColor;

                    palette.Ribbon.RibbonTab.StateTracking.BackColor2 = mediumColour.BackColor;

                    palette.Ribbon.RibbonTab.StateNormal.TextColor = ribbonTabTextColour.BackColor;
                    #endregion

                    #region Separator Styles
                    palette.SeparatorStyles.SeparatorCommon.StateCommon.Back.Color1 = baseColour.BackColor;

                    palette.SeparatorStyles.SeparatorCommon.StateCommon.Back.Color2 = baseColour.BackColor;

                    palette.SeparatorStyles.SeparatorCommon.StateCommon.Border.Color1 = baseColour.BackColor;

                    palette.SeparatorStyles.SeparatorCommon.StateCommon.Border.Color1 = baseColour.BackColor;

                    palette.SeparatorStyles.SeparatorCommon.StateCommon.Border.DrawBorders = PaletteDrawBorders.All;
                    #endregion

                    #region Tool Menu Status
                    palette.ToolMenuStatus.Button.ButtonPressedBorder = baseColour.BackColor;

                    palette.ToolMenuStatus.Button.ButtonSelectedBorder = baseColour.BackColor;

                    palette.ToolMenuStatus.Button.OverflowButtonGradientBegin = darkColour.BackColor;

                    palette.ToolMenuStatus.Button.OverflowButtonGradientEnd = baseColour.BackColor;

                    palette.ToolMenuStatus.Button.OverflowButtonGradientMiddle = mediumColour.BackColor;

                    palette.ToolMenuStatus.Grip.GripDark = baseColour.BackColor;

                    palette.ToolMenuStatus.Grip.GripLight = customColourFive.BackColor;

                    palette.ToolMenuStatus.Menu.ImageMarginGradientBegin = baseColour.BackColor;

                    palette.ToolMenuStatus.Menu.ImageMarginGradientEnd = darkColour.BackColor;

                    palette.ToolMenuStatus.Menu.ImageMarginGradientMiddle = mediumColour.BackColor;

                    palette.ToolMenuStatus.Menu.ImageMarginRevealedGradientBegin = baseColour.BackColor;

                    palette.ToolMenuStatus.Menu.ImageMarginRevealedGradientEnd = darkColour.BackColor;

                    palette.ToolMenuStatus.Menu.ImageMarginRevealedGradientMiddle = mediumColour.BackColor;

                    palette.ToolMenuStatus.Menu.MenuBorder = baseColour.BackColor;

                    palette.ToolMenuStatus.Menu.MenuItemBorder = darkColour.BackColor;

                    palette.ToolMenuStatus.Menu.MenuItemPressedGradientBegin = baseColour.BackColor;

                    palette.ToolMenuStatus.Menu.MenuItemPressedGradientEnd = darkColour.BackColor;

                    palette.ToolMenuStatus.Menu.MenuItemPressedGradientMiddle = mediumColour.BackColor;

                    palette.ToolMenuStatus.Menu.MenuItemSelected = mediumColour.BackColor;

                    palette.ToolMenuStatus.Menu.MenuItemSelectedGradientBegin = darkColour.BackColor;

                    palette.ToolMenuStatus.Menu.MenuItemSelectedGradientEnd = baseColour.BackColor;

                    palette.ToolMenuStatus.Menu.MenuItemText = menuTextColour.BackColor;

                    palette.ToolMenuStatus.MenuStrip.MenuStripGradientBegin = baseColour.BackColor;

                    palette.ToolMenuStatus.MenuStrip.MenuStripGradientEnd = darkColour.BackColor;

                    palette.ToolMenuStatus.MenuStrip.MenuStripText = normalTextColourPreview.BackColor;

                    palette.ToolMenuStatus.Rafting.RaftingContainerGradientBegin = mediumColour.BackColor;

                    palette.ToolMenuStatus.Rafting.RaftingContainerGradientEnd = darkColour.BackColor;

                    palette.ToolMenuStatus.Separator.SeparatorDark = baseColour.BackColor;

                    palette.ToolMenuStatus.Separator.SeparatorLight = lightColour.BackColor;

                    palette.ToolMenuStatus.StatusStrip.StatusStripGradientBegin = baseColour.BackColor;

                    palette.ToolMenuStatus.StatusStrip.StatusStripGradientEnd = lightColour.BackColor;

                    palette.ToolMenuStatus.StatusStrip.StatusStripText = statusTextColour.BackColor;

                    palette.ToolMenuStatus.ToolStrip.ToolStripBorder = darkColour.BackColor;

                    palette.ToolMenuStatus.ToolStrip.ToolStripContentPanelGradientBegin = lightColour.BackColor;

                    palette.ToolMenuStatus.ToolStrip.ToolStripContentPanelGradientEnd = darkColour.BackColor;

                    palette.ToolMenuStatus.ToolStrip.ToolStripDropDownBackground = mediumColour.BackColor;

                    palette.ToolMenuStatus.ToolStrip.ToolStripGradientBegin = darkColour.BackColor;

                    palette.ToolMenuStatus.ToolStrip.ToolStripGradientEnd = lightColour.BackColor;

                    palette.ToolMenuStatus.ToolStrip.ToolStripGradientMiddle = mediumColour.BackColor;

                    palette.ToolMenuStatus.ToolStrip.ToolStripPanelGradientBegin = lightColour.BackColor;

                    palette.ToolMenuStatus.ToolStrip.ToolStripPanelGradientEnd = darkColour.BackColor;

                    palette.ToolMenuStatus.ToolStrip.ToolStripText = normalTextColourPreview.BackColor;
                    #endregion

                    #region Trackbar
                    palette.TrackBar.StateCommon.Position.Color4 = mediumColour.BackColor;

                    palette.TrackBar.StateCommon.Position.Color5 = lightColour.BackColor;

                    palette.TrackBar.StateCommon.Tick.Color3 = darkColour.BackColor;

                    palette.TrackBar.StateCommon.Tick.Color4 = mediumColour.BackColor;

                    palette.TrackBar.StateCommon.Tick.Color5 = lightColour.BackColor;

                    palette.TrackBar.StateCommon.Track.Color1 = baseColour.BackColor;

                    palette.TrackBar.StateCommon.Track.Color2 = darkColour.BackColor;

                    palette.TrackBar.StateCommon.Track.Color3 = mediumColour.BackColor;

                    palette.TrackBar.StateCommon.Track.Color4 = lightColour.BackColor;

                    palette.TrackBar.StateCommon.Track.Color5 = lightestColour.BackColor;

                    palette.TrackBar.StateNormal.Track.Color1 = baseColour.BackColor;

                    palette.TrackBar.StateNormal.Track.Color2 = darkColour.BackColor;

                    palette.TrackBar.StateNormal.Track.Color3 = mediumColour.BackColor;

                    palette.TrackBar.StateNormal.Track.Color4 = lightColour.BackColor;

                    palette.TrackBar.StateNormal.Track.Color5 = lightestColour.BackColor;
                    #endregion
                }

                palette.Export();

                KryptonMessageBox.Show($"Palette exported to: { palette.GetCustomisedKryptonPaletteFilePath() }", "Export Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exc)
            {
                ExceptionHandler.CaptureException(exc);
            }
        }

        /// <summary>
        /// Exports the palette.
        /// </summary>
        /// <param name="paletteMode">The palette mode.</param>
        /// <param name="baseColour">The base colour.</param>
        /// <param name="darkColour">The dark colour.</param>
        /// <param name="mediumColour">The middle colour.</param>
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
        /// <param name="linkFocusedColourPreview">The link focused colour preview.</param>
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
        /// <param name="ribbonTabTextColour">The ribbon tab text colour.</param>
        /// <param name="invertColours">if set to <c>true</c> [invert colours].</param>
        public static void ExportPalette(PaletteMode paletteMode, CircularPictureBox baseColour, CircularPictureBox darkColour, CircularPictureBox mediumColour, CircularPictureBox lightColour, CircularPictureBox lightestColour, CircularPictureBox borderColourPreview, CircularPictureBox alternativeNormalTextColourPreview, CircularPictureBox normalTextColourPreview, CircularPictureBox disabledTextColourPreview, CircularPictureBox focusedTextColourPreview, CircularPictureBox pressedTextColourPreview, CircularPictureBox disabledColourPreview, CircularPictureBox linkNormalColourPreview, CircularPictureBox linkFocusedColourPreview, CircularPictureBox linkHoverColourPreview, CircularPictureBox linkVisitedColourPreview, CircularPictureBox customColourOne, CircularPictureBox customColourTwo, CircularPictureBox customColourThree, CircularPictureBox customColourFour, CircularPictureBox customColourFive, CircularPictureBox customTextColourOne, CircularPictureBox customTextColourTwo, CircularPictureBox customTextColourThree, CircularPictureBox customTextColourFour, CircularPictureBox customTextColourFive, CircularPictureBox menuTextColour, CircularPictureBox statusTextColour, CircularPictureBox ribbonTabTextColour, bool invertColours = false)
        {
            KryptonPalette palette = new KryptonPalette();

            try
            {
                palette.BasePaletteMode = paletteMode;

                if (lightestColour.BackColor == Color.Transparent)
                {
                    lightestColour.BackColor = lightColour.BackColor;
                }

                if (invertColours)
                {

                }
                else
                {
                    #region Button Cluster
                    palette.ButtonStyles.ButtonCluster.OverrideDefault.Back.Color1 = baseColour.BackColor;

                    palette.ButtonStyles.ButtonCluster.OverrideFocus.Back.Color1 = baseColour.BackColor;

                    palette.ButtonStyles.ButtonCluster.StateCheckedNormal.Back.Color1 = baseColour.BackColor;

                    palette.ButtonStyles.ButtonCluster.StateCommon.Back.ColorStyle = PaletteColorStyle.GlassNormalFull;

                    palette.ButtonStyles.ButtonCluster.StateNormal.Back.Color1 = mediumColour.BackColor;

                    palette.ButtonStyles.ButtonCluster.StatePressed.Back.Color1 = darkColour.BackColor;

                    palette.ButtonStyles.ButtonCluster.StateTracking.Back.Color1 = baseColour.BackColor;
                    #endregion

                    #region Button Common
                    palette.ButtonStyles.ButtonCommon.OverrideDefault.Back.Color1 = baseColour.BackColor;

                    palette.ButtonStyles.ButtonCommon.OverrideDefault.Content.LongText.Color1 = alternativeNormalTextColourPreview.BackColor;

                    palette.ButtonStyles.ButtonCommon.OverrideDefault.Content.ShortText.Color1 = alternativeNormalTextColourPreview.BackColor;

                    palette.ButtonStyles.ButtonCommon.StateCheckedNormal.Back.Color1 = lightestColour.BackColor;

                    palette.ButtonStyles.ButtonCommon.StateCheckedNormal.Back.Color2 = lightColour.BackColor;

                    palette.ButtonStyles.ButtonCommon.StateCheckedNormal.Back.ColorStyle = PaletteColorStyle.GlassCheckedFull;

                    palette.ButtonStyles.ButtonCommon.StateCheckedNormal.Content.LongText.Color1 = normalTextColourPreview.BackColor;

                    palette.ButtonStyles.ButtonCommon.StateCheckedNormal.Content.ShortText.Color1 = normalTextColourPreview.BackColor;

                    palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Back.Color1 = lightestColour.BackColor;

                    palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Back.Color2 = lightColour.BackColor;

                    palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Back.ColorStyle = PaletteColorStyle.GlassCheckedStump;

                    palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Border.DrawBorders = PaletteDrawBorders.All;

                    palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Content.LongText.Color1 = normalTextColourPreview.BackColor;

                    palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Content.ShortText.Color1 = normalTextColourPreview.BackColor;

                    palette.ButtonStyles.ButtonCommon.StateCheckedTracking.Back.Color1 = lightestColour.BackColor;

                    palette.ButtonStyles.ButtonCommon.StateCheckedTracking.Back.Color2 = lightColour.BackColor;

                    palette.ButtonStyles.ButtonCommon.StateCheckedTracking.Border.DrawBorders = PaletteDrawBorders.All;

                    palette.ButtonStyles.ButtonCommon.StateCheckedTracking.Content.LongText.Color1 = normalTextColourPreview.BackColor;

                    palette.ButtonStyles.ButtonCommon.StateCheckedTracking.Content.ShortText.Color1 = normalTextColourPreview.BackColor;

                    palette.ButtonStyles.ButtonCommon.StateCommon.Back.Color1 = baseColour.BackColor;

                    palette.ButtonStyles.ButtonCommon.StateDisabled.Back.Color1 = disabledColourPreview.BackColor;

                    palette.ButtonStyles.ButtonCommon.StateDisabled.Back.Color2 = disabledColourPreview.BackColor;

                    /*
                    palette.ButtonStyles.ButtonCommon.StateDisabled.Back.Color1 = baseColour.BackColor;

                    palette.ButtonStyles.ButtonCommon.StateDisabled.Back.Color2 = baseColour.BackColor;
                    */

                    palette.ButtonStyles.ButtonCommon.StateDisabled.Content.LongText.Color1 = disabledTextColourPreview.BackColor;

                    palette.ButtonStyles.ButtonCommon.StateDisabled.Content.ShortText.Color1 = disabledTextColourPreview.BackColor;

                    palette.ButtonStyles.ButtonCommon.StateNormal.Back.Color1 = baseColour.BackColor;

                    palette.ButtonStyles.ButtonCommon.StateNormal.Back.Color2 = baseColour.BackColor;

                    palette.ButtonStyles.ButtonCommon.StateNormal.Content.LongText.Color1 = alternativeNormalTextColourPreview.BackColor;

                    palette.ButtonStyles.ButtonCommon.StateNormal.Content.LongText.Color2 = alternativeNormalTextColourPreview.BackColor;

                    palette.ButtonStyles.ButtonCommon.StateNormal.Content.ShortText.Color1 = alternativeNormalTextColourPreview.BackColor;

                    palette.ButtonStyles.ButtonCommon.StateNormal.Content.ShortText.Color2 = alternativeNormalTextColourPreview.BackColor;

                    palette.ButtonStyles.ButtonCommon.StatePressed.Back.Color1 = lightestColour.BackColor;

                    palette.ButtonStyles.ButtonCommon.StatePressed.Back.Color2 = lightColour.BackColor;

                    palette.ButtonStyles.ButtonCommon.StatePressed.Content.LongText.Color1 = normalTextColourPreview.BackColor;

                    palette.ButtonStyles.ButtonCommon.StatePressed.Content.ShortText.Color1 = normalTextColourPreview.BackColor;

                    palette.ButtonStyles.ButtonCommon.StateTracking.Back.Color1 = baseColour.BackColor;

                    palette.ButtonStyles.ButtonCommon.StateTracking.Back.Color2 = darkColour.BackColor;

                    palette.ButtonStyles.ButtonCommon.StateTracking.Content.LongText.Color1 = alternativeNormalTextColourPreview.BackColor;

                    palette.ButtonStyles.ButtonCommon.StateTracking.Content.ShortText.Color1 = alternativeNormalTextColourPreview.BackColor;
                    #endregion

                    #region Common
                    palette.Common.StateCommon.Back.Color1 = lightestColour.BackColor;

                    palette.Common.StateCommon.Back.Color2 = baseColour.BackColor;

                    palette.Common.StateCommon.Border.Color1 = baseColour.BackColor;

                    palette.Common.StateCommon.Border.Color2 = darkColour.BackColor;

                    palette.Common.StateCommon.Border.DrawBorders = PaletteDrawBorders.All;

                    palette.Common.StateCommon.Content.LongText.Color1 = alternativeNormalTextColourPreview.BackColor;

                    palette.Common.StateCommon.Content.LongText.Color2 = alternativeNormalTextColourPreview.BackColor;

                    palette.Common.StateCommon.Content.ShortText.Color1 = alternativeNormalTextColourPreview.BackColor;

                    palette.Common.StateCommon.Content.ShortText.Color2 = alternativeNormalTextColourPreview.BackColor;
                    #endregion

                    #region Form Styles
                    palette.FormStyles.FormCommon.StateActive.Back.Color1 = baseColour.BackColor;

                    palette.FormStyles.FormCommon.StateActive.Border.DrawBorders = PaletteDrawBorders.All;
                    #endregion

                    #region Grid Styles
                    palette.GridStyles.GridSheet.StateCommon.HeaderColumn.Content.Color1 = lightestColour.BackColor;

                    palette.GridStyles.GridSheet.StateCommon.HeaderRow.Content.Color1 = lightestColour.BackColor;

                    palette.GridStyles.GridSheet.StateNormal.HeaderColumn.Content.Color1 = darkColour.BackColor;

                    palette.GridStyles.GridSheet.StateNormal.HeaderColumn.Content.Color2 = mediumColour.BackColor;

                    palette.GridStyles.GridSheet.StateNormal.HeaderRow.Content.Color1 = darkColour.BackColor;

                    palette.GridStyles.GridSheet.StateTracking.HeaderColumn.Content.Color1 = baseColour.BackColor;
                    #endregion

                    #region Header Styles
                    palette.HeaderStyles.HeaderCommon.StateCommon.Back.Color1 = mediumColour.BackColor;

                    palette.HeaderStyles.HeaderCommon.StateCommon.Back.Color2 = lightColour.BackColor;

                    palette.HeaderStyles.HeaderCommon.StateDisabled.Back.Color1 = lightColour.BackColor;

                    palette.HeaderStyles.HeaderCommon.StateDisabled.Back.Color2 = lightestColour.BackColor;

                    palette.HeaderStyles.HeaderCommon.StateDisabled.Content.LongText.Color1 = disabledTextColourPreview.BackColor;

                    palette.HeaderStyles.HeaderCommon.StateDisabled.Content.LongText.Color2 = baseColour.BackColor;

                    palette.HeaderStyles.HeaderCommon.StateDisabled.Content.ShortText.Color1 = disabledTextColourPreview.BackColor;

                    palette.HeaderStyles.HeaderCommon.StateDisabled.Content.ShortText.Color2 = baseColour.BackColor;

                    palette.HeaderStyles.HeaderForm.StateCommon.Back.Color1 = mediumColour.BackColor;

                    palette.HeaderStyles.HeaderForm.StateCommon.Back.Color2 = lightColour.BackColor;

                    palette.HeaderStyles.HeaderForm.StateDisabled.Back.Color1 = disabledColourPreview.BackColor;

                    palette.HeaderStyles.HeaderForm.StateDisabled.Back.Color2 = baseColour.BackColor;

                    palette.HeaderStyles.HeaderForm.StateDisabled.Content.LongText.Color1 = disabledTextColourPreview.BackColor;

                    palette.HeaderStyles.HeaderForm.StateDisabled.Content.ShortText.Color1 = disabledTextColourPreview.BackColor;
                    #endregion

                    #region Label Styles
                    palette.LabelStyles.LabelNormalControl.OverrideNotVisited.LongText.Color1 = linkNormalColourPreview.BackColor;

                    palette.LabelStyles.LabelNormalControl.OverrideNotVisited.ShortText.Color1 = linkNormalColourPreview.BackColor;

                    palette.LabelStyles.LabelNormalControl.OverridePressed.LongText.Color1 = linkHoverColourPreview.BackColor;

                    palette.LabelStyles.LabelNormalControl.OverridePressed.ShortText.Color1 = linkHoverColourPreview.BackColor;

                    palette.LabelStyles.LabelNormalControl.OverrideVisited.LongText.Color1 = linkVisitedColourPreview.BackColor;

                    palette.LabelStyles.LabelNormalControl.OverrideVisited.ShortText.Color1 = linkVisitedColourPreview.BackColor;

                    palette.LabelStyles.LabelNormalControl.OverrideFocus.LongText.Color1 = linkFocusedColourPreview.BackColor;

                    palette.LabelStyles.LabelNormalControl.OverrideFocus.ShortText.Color1 = linkFocusedColourPreview.BackColor;

                    palette.LabelStyles.LabelNormalControl.StateDisabled.LongText.Color1 = disabledTextColourPreview.BackColor;

                    palette.LabelStyles.LabelNormalControl.StateDisabled.ShortText.Color1 = disabledTextColourPreview.BackColor;

                    palette.LabelStyles.LabelNormalControl.StateNormal.LongText.Color1 = normalTextColourPreview.BackColor;

                    palette.LabelStyles.LabelNormalControl.StateNormal.ShortText.Color1 = normalTextColourPreview.BackColor;
                    #endregion

                    #region Ribbon
                    palette.Ribbon.RibbonAppButton.StateCommon.BackColor2 = baseColour.BackColor;

                    palette.Ribbon.RibbonAppButton.StateCommon.BackColor3 = customColourThree.BackColor;

                    palette.Ribbon.RibbonAppButton.StateCommon.BackColor5 = baseColour.BackColor;

                    palette.Ribbon.RibbonAppButton.StatePressed.BackColor5 = darkColour.BackColor;

                    palette.Ribbon.RibbonAppButton.StateTracking.BackColor5 = customColourFive.BackColor;

                    palette.Ribbon.RibbonGroupArea.StateCheckedNormal.BackColor1 = baseColour.BackColor;

                    palette.Ribbon.RibbonGroupArea.StateCheckedNormal.BackColor2 = customColourTwo.BackColor;

                    palette.Ribbon.RibbonGroupArea.StateCheckedNormal.BackColor3 = baseColour.BackColor;

                    palette.Ribbon.RibbonGroupArea.StateCheckedNormal.BackColor4 = baseColour.BackColor;

                    palette.Ribbon.RibbonGroupArea.StateCheckedNormal.BackColor5 = baseColour.BackColor;

                    palette.Ribbon.RibbonGroupButtonText.StateCommon.TextColor = customTextColourTwo.BackColor;

                    palette.Ribbon.RibbonGroupCheckBoxText.StateCommon.TextColor = customTextColourTwo.BackColor;

                    palette.Ribbon.RibbonGroupCollapsedBack.StateNormal.BackColor1 = SystemColors.Window;

                    palette.Ribbon.RibbonGroupCollapsedBack.StateNormal.BackColor2 = baseColour.BackColor;

                    palette.Ribbon.RibbonGroupCollapsedBack.StateNormal.BackColor3 = lightColour.BackColor;

                    palette.Ribbon.RibbonGroupCollapsedBack.StateNormal.BackColor4 = baseColour.BackColor;

                    palette.Ribbon.RibbonGroupCollapsedBack.StateTracking.BackColor1 = SystemColors.Window;

                    palette.Ribbon.RibbonGroupCollapsedBack.StateTracking.BackColor2 = lightColour.BackColor;

                    palette.Ribbon.RibbonGroupCollapsedBack.StateTracking.BackColor3 = lightestColour.BackColor; // Or 230, 230, 230

                    palette.Ribbon.RibbonGroupCollapsedBack.StateTracking.BackColor4 = baseColour.BackColor;

                    palette.Ribbon.RibbonGroupCollapsedBorder.StateCommon.BackColor1 = baseColour.BackColor;

                    palette.Ribbon.RibbonGroupCollapsedBorder.StateCommon.BackColor2 = mediumColour.BackColor;

                    palette.Ribbon.RibbonGroupCollapsedBorder.StateCommon.BackColor3 = lightColour.BackColor;

                    palette.Ribbon.RibbonGroupCollapsedBorder.StateCommon.BackColor4 = baseColour.BackColor;

                    palette.Ribbon.RibbonGroupCollapsedBorder.StateCommon.BackColor5 = baseColour.BackColor;

                    palette.Ribbon.RibbonGroupCollapsedFrameBack.StateCommon.BackColor1 = baseColour.BackColor;

                    palette.Ribbon.RibbonGroupCollapsedFrameBack.StateCommon.BackColor2 = baseColour.BackColor;

                    palette.Ribbon.RibbonGroupCollapsedFrameBack.StateCommon.BackColor3 = lightColour.BackColor;

                    palette.Ribbon.RibbonGroupCollapsedFrameBack.StateCommon.BackColor4 = lightColour.BackColor;

                    palette.Ribbon.RibbonGroupCollapsedFrameBack.StateCommon.BackColor5 = baseColour.BackColor;

                    palette.Ribbon.RibbonGroupCollapsedFrameBorder.StateCommon.BackColor1 = lightColour.BackColor;

                    palette.Ribbon.RibbonGroupCollapsedFrameBorder.StateCommon.BackColor2 = lightestColour.BackColor; // Or 230, 230, 230

                    palette.Ribbon.RibbonGroupCollapsedText.StateCommon.TextColor = alternativeNormalTextColourPreview.BackColor;

                    palette.Ribbon.RibbonGroupNormalBorder.StateCommon.BackColor1 = baseColour.BackColor;

                    palette.Ribbon.RibbonGroupNormalBorder.StateCommon.BackColor2 = mediumColour.BackColor;

                    palette.Ribbon.RibbonGroupNormalTitle.StateCommon.BackColor1 = lightestColour.BackColor; // Or 230, 230, 230

                    palette.Ribbon.RibbonGroupNormalTitle.StateCommon.BackColor2 = mediumColour.BackColor;

                    palette.Ribbon.RibbonGroupNormalTitle.StateCommon.TextColor = customTextColourFive.BackColor;

                    palette.Ribbon.RibbonGroupNormalTitle.StateTracking.BackColor1 = lightestColour.BackColor;

                    palette.Ribbon.RibbonGroupNormalTitle.StateTracking.BackColor2 = mediumColour.BackColor;

                    palette.Ribbon.RibbonQATFullbar.BackColor1 = mediumColour.BackColor;

                    palette.Ribbon.RibbonQATFullbar.BackColor2 = mediumColour.BackColor;

                    palette.Ribbon.RibbonQATFullbar.BackColor3 = mediumColour.BackColor;

                    palette.Ribbon.RibbonQATMinibar.StateCommon.BackColor1 = mediumColour.BackColor;

                    palette.Ribbon.RibbonQATMinibar.StateCommon.BackColor2 = mediumColour.BackColor;

                    palette.Ribbon.RibbonQATMinibar.StateCommon.BackColor3 = mediumColour.BackColor;

                    palette.Ribbon.RibbonQATMinibar.StateCommon.BackColor4 = mediumColour.BackColor;

                    palette.Ribbon.RibbonQATOverflow.BackColor1 = mediumColour.BackColor;

                    palette.Ribbon.RibbonQATOverflow.BackColor2 = mediumColour.BackColor;

                    palette.Ribbon.RibbonTab.StateCheckedTracking.BackColor1 = mediumColour.BackColor;

                    palette.Ribbon.RibbonTab.StateCheckedTracking.BackColor2 = lightColour.BackColor;

                    palette.Ribbon.RibbonTab.StateCheckedTracking.BackColor3 = darkColour.BackColor;

                    palette.Ribbon.RibbonTab.StateCheckedTracking.BackColor4 = mediumColour.BackColor;

                    palette.Ribbon.RibbonTab.StateCommon.BackColor1 = mediumColour.BackColor;

                    palette.Ribbon.RibbonTab.StateCommon.BackColor3 = mediumColour.BackColor;

                    palette.Ribbon.RibbonTab.StateCommon.BackColor4 = lightColour.BackColor;

                    palette.Ribbon.RibbonTab.StateCommon.BackColor5 = lightColour.BackColor;

                    palette.Ribbon.RibbonTab.StateCommon.TextColor = normalTextColourPreview.BackColor;

                    palette.Ribbon.RibbonTab.StateContextCheckedTracking.BackColor2 = mediumColour.BackColor;

                    palette.Ribbon.RibbonTab.StateTracking.BackColor2 = mediumColour.BackColor;

                    palette.Ribbon.RibbonTab.StateNormal.TextColor = ribbonTabTextColour.BackColor;
                    #endregion

                    #region Separator Styles
                    palette.SeparatorStyles.SeparatorCommon.StateCommon.Back.Color1 = baseColour.BackColor;

                    palette.SeparatorStyles.SeparatorCommon.StateCommon.Back.Color2 = baseColour.BackColor;

                    palette.SeparatorStyles.SeparatorCommon.StateCommon.Border.Color1 = baseColour.BackColor;

                    palette.SeparatorStyles.SeparatorCommon.StateCommon.Border.Color1 = baseColour.BackColor;

                    palette.SeparatorStyles.SeparatorCommon.StateCommon.Border.DrawBorders = PaletteDrawBorders.All;
                    #endregion

                    #region Tool Menu Status
                    palette.ToolMenuStatus.Button.ButtonPressedBorder = baseColour.BackColor;

                    palette.ToolMenuStatus.Button.ButtonSelectedBorder = baseColour.BackColor;

                    palette.ToolMenuStatus.Button.OverflowButtonGradientBegin = darkColour.BackColor;

                    palette.ToolMenuStatus.Button.OverflowButtonGradientEnd = baseColour.BackColor;

                    palette.ToolMenuStatus.Button.OverflowButtonGradientMiddle = mediumColour.BackColor;

                    palette.ToolMenuStatus.Grip.GripDark = baseColour.BackColor;

                    palette.ToolMenuStatus.Grip.GripLight = customColourFive.BackColor;

                    palette.ToolMenuStatus.Menu.ImageMarginGradientBegin = baseColour.BackColor;

                    palette.ToolMenuStatus.Menu.ImageMarginGradientEnd = darkColour.BackColor;

                    palette.ToolMenuStatus.Menu.ImageMarginGradientMiddle = mediumColour.BackColor;

                    palette.ToolMenuStatus.Menu.ImageMarginRevealedGradientBegin = baseColour.BackColor;

                    palette.ToolMenuStatus.Menu.ImageMarginRevealedGradientEnd = darkColour.BackColor;

                    palette.ToolMenuStatus.Menu.ImageMarginRevealedGradientMiddle = mediumColour.BackColor;

                    palette.ToolMenuStatus.Menu.MenuBorder = baseColour.BackColor;

                    palette.ToolMenuStatus.Menu.MenuItemBorder = darkColour.BackColor;

                    palette.ToolMenuStatus.Menu.MenuItemPressedGradientBegin = baseColour.BackColor;

                    palette.ToolMenuStatus.Menu.MenuItemPressedGradientEnd = darkColour.BackColor;

                    palette.ToolMenuStatus.Menu.MenuItemPressedGradientMiddle = mediumColour.BackColor;

                    palette.ToolMenuStatus.Menu.MenuItemSelected = mediumColour.BackColor;

                    palette.ToolMenuStatus.Menu.MenuItemSelectedGradientBegin = darkColour.BackColor;

                    palette.ToolMenuStatus.Menu.MenuItemSelectedGradientEnd = baseColour.BackColor;

                    palette.ToolMenuStatus.Menu.MenuItemText = menuTextColour.BackColor;

                    palette.ToolMenuStatus.MenuStrip.MenuStripGradientBegin = baseColour.BackColor;

                    palette.ToolMenuStatus.MenuStrip.MenuStripGradientEnd = darkColour.BackColor;

                    palette.ToolMenuStatus.MenuStrip.MenuStripText = normalTextColourPreview.BackColor;

                    palette.ToolMenuStatus.Rafting.RaftingContainerGradientBegin = mediumColour.BackColor;

                    palette.ToolMenuStatus.Rafting.RaftingContainerGradientEnd = darkColour.BackColor;

                    palette.ToolMenuStatus.Separator.SeparatorDark = baseColour.BackColor;

                    palette.ToolMenuStatus.Separator.SeparatorLight = lightColour.BackColor;

                    palette.ToolMenuStatus.StatusStrip.StatusStripGradientBegin = baseColour.BackColor;

                    palette.ToolMenuStatus.StatusStrip.StatusStripGradientEnd = lightColour.BackColor;

                    palette.ToolMenuStatus.StatusStrip.StatusStripText = statusTextColour.BackColor;

                    palette.ToolMenuStatus.ToolStrip.ToolStripBorder = darkColour.BackColor;

                    palette.ToolMenuStatus.ToolStrip.ToolStripContentPanelGradientBegin = lightColour.BackColor;

                    palette.ToolMenuStatus.ToolStrip.ToolStripContentPanelGradientEnd = darkColour.BackColor;

                    palette.ToolMenuStatus.ToolStrip.ToolStripDropDownBackground = mediumColour.BackColor;

                    palette.ToolMenuStatus.ToolStrip.ToolStripGradientBegin = darkColour.BackColor;

                    palette.ToolMenuStatus.ToolStrip.ToolStripGradientEnd = lightColour.BackColor;

                    palette.ToolMenuStatus.ToolStrip.ToolStripGradientMiddle = mediumColour.BackColor;

                    palette.ToolMenuStatus.ToolStrip.ToolStripPanelGradientBegin = lightColour.BackColor;

                    palette.ToolMenuStatus.ToolStrip.ToolStripPanelGradientEnd = darkColour.BackColor;

                    palette.ToolMenuStatus.ToolStrip.ToolStripText = normalTextColourPreview.BackColor;
                    #endregion

                    #region Trackbar
                    palette.TrackBar.StateCommon.Position.Color4 = mediumColour.BackColor;

                    palette.TrackBar.StateCommon.Position.Color5 = lightColour.BackColor;

                    palette.TrackBar.StateCommon.Tick.Color3 = darkColour.BackColor;

                    palette.TrackBar.StateCommon.Tick.Color4 = mediumColour.BackColor;

                    palette.TrackBar.StateCommon.Tick.Color5 = lightColour.BackColor;

                    palette.TrackBar.StateCommon.Track.Color1 = baseColour.BackColor;

                    palette.TrackBar.StateCommon.Track.Color2 = darkColour.BackColor;

                    palette.TrackBar.StateCommon.Track.Color3 = mediumColour.BackColor;

                    palette.TrackBar.StateCommon.Track.Color4 = lightColour.BackColor;

                    palette.TrackBar.StateCommon.Track.Color5 = lightestColour.BackColor;

                    palette.TrackBar.StateNormal.Track.Color1 = baseColour.BackColor;

                    palette.TrackBar.StateNormal.Track.Color2 = darkColour.BackColor;

                    palette.TrackBar.StateNormal.Track.Color3 = mediumColour.BackColor;

                    palette.TrackBar.StateNormal.Track.Color4 = lightColour.BackColor;

                    palette.TrackBar.StateNormal.Track.Color5 = lightestColour.BackColor;
                    #endregion
                }

                palette.Export();

                KryptonMessageBox.Show($"Palette exported to: { palette.GetCustomisedKryptonPaletteFilePath() }", "Export Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exc)
            {
                ExceptionHandler.CaptureException(exc);
            }
        }
        #endregion

        /// <summary>Exports the palette theme.</summary>
        /// <param name="palette">The palette.</param>
        /// <param name="paletteMode">The palette mode.</param>
        /// <param name="paletteColourArray">The palette colour array.</param>
        /// <param name="invertColours">if set to <c>true</c> [invert colours].</param>
        public static void ExportPaletteTheme(KryptonPalette palette, PaletteMode paletteMode, Color[] paletteColourArray, bool invertColours = false)
        {
            palette = new KryptonPalette();

            try
            {
                palette.BasePaletteMode = paletteMode;

                if (paletteColourArray[4] == Color.Transparent)
                {
                    paletteColourArray[4] = paletteColourArray[3];
                }

                if (invertColours)
                {
                    #region Button Cluster
                    palette.ButtonStyles.ButtonCluster.OverrideDefault.Back.Color1 = paletteColourArray[1];

                    palette.ButtonStyles.ButtonCluster.OverrideFocus.Back.Color1 = paletteColourArray[1];

                    palette.ButtonStyles.ButtonCluster.StateCheckedNormal.Back.Color1 = paletteColourArray[1];

                    palette.ButtonStyles.ButtonCluster.StateCommon.Back.ColorStyle = PaletteColorStyle.GlassNormalFull;

                    palette.ButtonStyles.ButtonCluster.StateNormal.Back.Color1 = paletteColourArray[2];

                    palette.ButtonStyles.ButtonCluster.StatePressed.Back.Color1 = paletteColourArray[0];

                    palette.ButtonStyles.ButtonCluster.StateTracking.Back.Color1 = paletteColourArray[1];
                    #endregion

                    #region Button Common
                    palette.ButtonStyles.ButtonCommon.OverrideDefault.Back.Color1 = paletteColourArray[3];

                    palette.ButtonStyles.ButtonCommon.OverrideDefault.Content.LongText.Color1 = paletteColourArray[7];

                    palette.ButtonStyles.ButtonCommon.OverrideDefault.Content.ShortText.Color1 = paletteColourArray[7];

                    palette.ButtonStyles.ButtonCommon.StateCheckedNormal.Back.Color1 = paletteColourArray[1];

                    palette.ButtonStyles.ButtonCommon.StateCheckedNormal.Back.Color2 = paletteColourArray[0];

                    palette.ButtonStyles.ButtonCommon.StateCheckedNormal.Back.ColorStyle = PaletteColorStyle.GlassCheckedFull;

                    palette.ButtonStyles.ButtonCommon.StateCheckedNormal.Content.LongText.Color1 = paletteColourArray[6];

                    palette.ButtonStyles.ButtonCommon.StateCheckedNormal.Content.ShortText.Color1 = paletteColourArray[6];

                    palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Back.Color1 = paletteColourArray[1];

                    palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Back.Color2 = paletteColourArray[0];

                    palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Back.ColorStyle = PaletteColorStyle.GlassCheckedStump;

                    palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Border.DrawBorders = PaletteDrawBorders.All;

                    palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Content.LongText.Color1 = paletteColourArray[6];

                    palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Content.ShortText.Color1 = paletteColourArray[6];

                    palette.ButtonStyles.ButtonCommon.StateCheckedTracking.Back.Color1 = paletteColourArray[0];

                    palette.ButtonStyles.ButtonCommon.StateCheckedTracking.Back.Color2 = paletteColourArray[0];

                    palette.ButtonStyles.ButtonCommon.StateCheckedTracking.Border.DrawBorders = PaletteDrawBorders.All;

                    palette.ButtonStyles.ButtonCommon.StateCheckedTracking.Content.LongText.Color1 = paletteColourArray[6];

                    palette.ButtonStyles.ButtonCommon.StateCheckedTracking.Content.ShortText.Color1 = paletteColourArray[6];

                    palette.ButtonStyles.ButtonCommon.StateCommon.Back.Color1 = paletteColourArray[3];

                    palette.ButtonStyles.ButtonCommon.StateDisabled.Back.Color1 = paletteColourArray[11];

                    palette.ButtonStyles.ButtonCommon.StateDisabled.Back.Color2 = paletteColourArray[11];

                    /*
                    palette.ButtonStyles.ButtonCommon.StateDisabled.Back.Color1 = paletteColourArray[3];

                    palette.ButtonStyles.ButtonCommon.StateDisabled.Back.Color2 = paletteColourArray[3];
                    */

                    palette.ButtonStyles.ButtonCommon.StateDisabled.Content.LongText.Color1 = paletteColourArray[8];

                    palette.ButtonStyles.ButtonCommon.StateDisabled.Content.ShortText.Color1 = paletteColourArray[8];

                    palette.ButtonStyles.ButtonCommon.StateNormal.Back.Color1 = paletteColourArray[3];

                    palette.ButtonStyles.ButtonCommon.StateNormal.Back.Color2 = paletteColourArray[3];

                    palette.ButtonStyles.ButtonCommon.StateNormal.Content.LongText.Color1 = paletteColourArray[7];

                    palette.ButtonStyles.ButtonCommon.StateNormal.Content.LongText.Color2 = paletteColourArray[7];

                    palette.ButtonStyles.ButtonCommon.StateNormal.Content.ShortText.Color1 = paletteColourArray[7];

                    palette.ButtonStyles.ButtonCommon.StateNormal.Content.ShortText.Color2 = paletteColourArray[7];

                    palette.ButtonStyles.ButtonCommon.StatePressed.Back.Color1 = paletteColourArray[1];

                    palette.ButtonStyles.ButtonCommon.StatePressed.Back.Color2 = paletteColourArray[0];

                    palette.ButtonStyles.ButtonCommon.StatePressed.Content.LongText.Color1 = paletteColourArray[6];

                    palette.ButtonStyles.ButtonCommon.StatePressed.Content.ShortText.Color1 = paletteColourArray[6];

                    palette.ButtonStyles.ButtonCommon.StateTracking.Back.Color1 = paletteColourArray[3];

                    palette.ButtonStyles.ButtonCommon.StateTracking.Back.Color2 = paletteColourArray[4];

                    palette.ButtonStyles.ButtonCommon.StateTracking.Content.LongText.Color1 = paletteColourArray[7];

                    palette.ButtonStyles.ButtonCommon.StateTracking.Content.ShortText.Color1 = paletteColourArray[7];
                    #endregion
                }
                else
                {
                    #region Button Cluster
                    palette.ButtonStyles.ButtonCluster.OverrideDefault.Back.Color1 = paletteColourArray[0];

                    palette.ButtonStyles.ButtonCluster.OverrideFocus.Back.Color1 = paletteColourArray[0];

                    palette.ButtonStyles.ButtonCluster.StateCheckedNormal.Back.Color1 = paletteColourArray[0];

                    palette.ButtonStyles.ButtonCluster.StateCommon.Back.ColorStyle = PaletteColorStyle.GlassNormalFull;

                    palette.ButtonStyles.ButtonCluster.StateNormal.Back.Color1 = paletteColourArray[2];

                    palette.ButtonStyles.ButtonCluster.StatePressed.Back.Color1 = paletteColourArray[1];

                    palette.ButtonStyles.ButtonCluster.StateTracking.Back.Color1 = paletteColourArray[0];
                    #endregion

                    #region Button Common
                    palette.ButtonStyles.ButtonCommon.OverrideDefault.Back.Color1 = paletteColourArray[0];

                    palette.ButtonStyles.ButtonCommon.OverrideDefault.Content.LongText.Color1 = paletteColourArray[6];

                    palette.ButtonStyles.ButtonCommon.OverrideDefault.Content.ShortText.Color1 = paletteColourArray[6];

                    palette.ButtonStyles.ButtonCommon.StateCheckedNormal.Back.Color1 = paletteColourArray[4];

                    palette.ButtonStyles.ButtonCommon.StateCheckedNormal.Back.Color2 = paletteColourArray[3];

                    palette.ButtonStyles.ButtonCommon.StateCheckedNormal.Back.ColorStyle = PaletteColorStyle.GlassCheckedFull;

                    palette.ButtonStyles.ButtonCommon.StateCheckedNormal.Content.LongText.Color1 = paletteColourArray[7];

                    palette.ButtonStyles.ButtonCommon.StateCheckedNormal.Content.ShortText.Color1 = paletteColourArray[7];

                    palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Back.Color1 = paletteColourArray[4];

                    palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Back.Color2 = paletteColourArray[3];

                    palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Back.ColorStyle = PaletteColorStyle.GlassCheckedStump;

                    palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Border.DrawBorders = PaletteDrawBorders.All;

                    palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Content.LongText.Color1 = paletteColourArray[7];

                    palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Content.ShortText.Color1 = paletteColourArray[7];

                    palette.ButtonStyles.ButtonCommon.StateCheckedTracking.Back.Color1 = paletteColourArray[4];

                    palette.ButtonStyles.ButtonCommon.StateCheckedTracking.Back.Color2 = paletteColourArray[3];

                    palette.ButtonStyles.ButtonCommon.StateCheckedTracking.Border.DrawBorders = PaletteDrawBorders.All;

                    palette.ButtonStyles.ButtonCommon.StateCheckedTracking.Content.LongText.Color1 = paletteColourArray[7];

                    palette.ButtonStyles.ButtonCommon.StateCheckedTracking.Content.ShortText.Color1 = paletteColourArray[7];

                    palette.ButtonStyles.ButtonCommon.StateCommon.Back.Color1 = paletteColourArray[0];

                    palette.ButtonStyles.ButtonCommon.StateDisabled.Back.Color1 = paletteColourArray[11];

                    palette.ButtonStyles.ButtonCommon.StateDisabled.Back.Color2 = paletteColourArray[11];

                    /*
                    palette.ButtonStyles.ButtonCommon.StateDisabled.Back.Color1 = paletteColourArray[0];

                    palette.ButtonStyles.ButtonCommon.StateDisabled.Back.Color2 = paletteColourArray[0];
                    */

                    palette.ButtonStyles.ButtonCommon.StateDisabled.Content.LongText.Color1 = paletteColourArray[8];

                    palette.ButtonStyles.ButtonCommon.StateDisabled.Content.ShortText.Color1 = paletteColourArray[8];

                    palette.ButtonStyles.ButtonCommon.StateNormal.Back.Color1 = paletteColourArray[0];

                    palette.ButtonStyles.ButtonCommon.StateNormal.Back.Color2 = paletteColourArray[0];

                    palette.ButtonStyles.ButtonCommon.StateNormal.Content.LongText.Color1 = paletteColourArray[6];

                    palette.ButtonStyles.ButtonCommon.StateNormal.Content.LongText.Color2 = paletteColourArray[6];

                    palette.ButtonStyles.ButtonCommon.StateNormal.Content.ShortText.Color1 = paletteColourArray[6];

                    palette.ButtonStyles.ButtonCommon.StateNormal.Content.ShortText.Color2 = paletteColourArray[6];

                    palette.ButtonStyles.ButtonCommon.StatePressed.Back.Color1 = paletteColourArray[4];

                    palette.ButtonStyles.ButtonCommon.StatePressed.Back.Color2 = paletteColourArray[3];

                    palette.ButtonStyles.ButtonCommon.StatePressed.Content.LongText.Color1 = paletteColourArray[7];

                    palette.ButtonStyles.ButtonCommon.StatePressed.Content.ShortText.Color1 = paletteColourArray[7];

                    palette.ButtonStyles.ButtonCommon.StateTracking.Back.Color1 = paletteColourArray[0];

                    palette.ButtonStyles.ButtonCommon.StateTracking.Back.Color2 = paletteColourArray[1];

                    palette.ButtonStyles.ButtonCommon.StateTracking.Content.LongText.Color1 = paletteColourArray[6];

                    palette.ButtonStyles.ButtonCommon.StateTracking.Content.ShortText.Color1 = paletteColourArray[6];
                    #endregion

                    #region Common
                    palette.Common.StateCommon.Back.Color1 = paletteColourArray[4];

                    palette.Common.StateCommon.Back.Color2 = paletteColourArray[0];

                    palette.Common.StateCommon.Border.Color1 = paletteColourArray[0];

                    palette.Common.StateCommon.Border.Color2 = paletteColourArray[1];

                    palette.Common.StateCommon.Border.DrawBorders = PaletteDrawBorders.All;

                    palette.Common.StateCommon.Content.LongText.Color1 = paletteColourArray[6];

                    palette.Common.StateCommon.Content.LongText.Color2 = paletteColourArray[6];

                    palette.Common.StateCommon.Content.ShortText.Color1 = paletteColourArray[6];

                    palette.Common.StateCommon.Content.ShortText.Color2 = paletteColourArray[6];
                    #endregion

                    #region Form Styles
                    palette.FormStyles.FormCommon.StateActive.Back.Color1 = paletteColourArray[0];

                    palette.FormStyles.FormCommon.StateActive.Border.DrawBorders = PaletteDrawBorders.All;
                    #endregion

                    #region Grid Styles
                    palette.GridStyles.GridSheet.StateCommon.HeaderColumn.Content.Color1 = paletteColourArray[4];

                    palette.GridStyles.GridSheet.StateCommon.HeaderRow.Content.Color1 = paletteColourArray[4];

                    palette.GridStyles.GridSheet.StateNormal.HeaderColumn.Content.Color1 = paletteColourArray[1];

                    palette.GridStyles.GridSheet.StateNormal.HeaderColumn.Content.Color2 = paletteColourArray[2];

                    palette.GridStyles.GridSheet.StateNormal.HeaderRow.Content.Color1 = paletteColourArray[1];

                    palette.GridStyles.GridSheet.StateTracking.HeaderColumn.Content.Color1 = paletteColourArray[0];
                    #endregion

                    #region Header Styles
                    palette.HeaderStyles.HeaderCommon.StateCommon.Back.Color1 = paletteColourArray[2];

                    palette.HeaderStyles.HeaderCommon.StateCommon.Back.Color2 = paletteColourArray[3];

                    palette.HeaderStyles.HeaderCommon.StateDisabled.Back.Color1 = paletteColourArray[3];

                    palette.HeaderStyles.HeaderCommon.StateDisabled.Back.Color2 = paletteColourArray[4];

                    palette.HeaderStyles.HeaderCommon.StateDisabled.Content.LongText.Color1 = paletteColourArray[8];

                    palette.HeaderStyles.HeaderCommon.StateDisabled.Content.LongText.Color2 = paletteColourArray[0];

                    palette.HeaderStyles.HeaderCommon.StateDisabled.Content.ShortText.Color1 = paletteColourArray[8];

                    palette.HeaderStyles.HeaderCommon.StateDisabled.Content.ShortText.Color2 = paletteColourArray[0];

                    palette.HeaderStyles.HeaderForm.StateCommon.Back.Color1 = paletteColourArray[2];

                    palette.HeaderStyles.HeaderForm.StateCommon.Back.Color2 = paletteColourArray[3];

                    palette.HeaderStyles.HeaderForm.StateDisabled.Back.Color1 = paletteColourArray[11];

                    palette.HeaderStyles.HeaderForm.StateDisabled.Back.Color2 = paletteColourArray[0];

                    palette.HeaderStyles.HeaderForm.StateDisabled.Content.LongText.Color1 = paletteColourArray[8];

                    palette.HeaderStyles.HeaderForm.StateDisabled.Content.ShortText.Color1 = paletteColourArray[8];
                    #endregion

                    #region Label Styles
                    palette.LabelStyles.LabelNormalControl.OverrideNotVisited.LongText.Color1 = paletteColourArray[14];

                    palette.LabelStyles.LabelNormalControl.OverrideNotVisited.ShortText.Color1 = paletteColourArray[14];

                    palette.LabelStyles.LabelNormalControl.OverridePressed.LongText.Color1 = paletteColourArray[13];

                    palette.LabelStyles.LabelNormalControl.OverridePressed.ShortText.Color1 = paletteColourArray[13];

                    palette.LabelStyles.LabelNormalControl.OverrideVisited.LongText.Color1 = paletteColourArray[15];

                    palette.LabelStyles.LabelNormalControl.OverrideVisited.ShortText.Color1 = paletteColourArray[15];

                    palette.LabelStyles.LabelNormalControl.OverrideFocus.LongText.Color1 = paletteColourArray[12];

                    palette.LabelStyles.LabelNormalControl.OverrideFocus.ShortText.Color1 = paletteColourArray[12];

                    palette.LabelStyles.LabelNormalControl.StateDisabled.LongText.Color1 = paletteColourArray[8];

                    palette.LabelStyles.LabelNormalControl.StateDisabled.ShortText.Color1 = paletteColourArray[8];

                    palette.LabelStyles.LabelNormalControl.StateNormal.LongText.Color1 = paletteColourArray[7];

                    palette.LabelStyles.LabelNormalControl.StateNormal.ShortText.Color1 = paletteColourArray[7];
                    #endregion

                    #region Ribbon
                    palette.Ribbon.RibbonAppButton.StateCommon.BackColor2 = paletteColourArray[0];

                    palette.Ribbon.RibbonAppButton.StateCommon.BackColor3 = paletteColourArray[18];

                    palette.Ribbon.RibbonAppButton.StateCommon.BackColor5 = paletteColourArray[0];

                    palette.Ribbon.RibbonAppButton.StatePressed.BackColor5 = paletteColourArray[1];

                    palette.Ribbon.RibbonAppButton.StateTracking.BackColor5 = paletteColourArray[20];

                    palette.Ribbon.RibbonGroupArea.StateCheckedNormal.BackColor1 = paletteColourArray[0];

                    palette.Ribbon.RibbonGroupArea.StateCheckedNormal.BackColor2 = paletteColourArray[17];

                    palette.Ribbon.RibbonGroupArea.StateCheckedNormal.BackColor3 = paletteColourArray[0];

                    palette.Ribbon.RibbonGroupArea.StateCheckedNormal.BackColor4 = paletteColourArray[0];

                    palette.Ribbon.RibbonGroupArea.StateCheckedNormal.BackColor5 = paletteColourArray[0];

                    palette.Ribbon.RibbonGroupButtonText.StateCommon.TextColor = paletteColourArray[22];

                    palette.Ribbon.RibbonGroupCheckBoxText.StateCommon.TextColor = paletteColourArray[22];

                    palette.Ribbon.RibbonGroupCollapsedBack.StateNormal.BackColor1 = SystemColors.Window;

                    palette.Ribbon.RibbonGroupCollapsedBack.StateNormal.BackColor2 = paletteColourArray[0];

                    palette.Ribbon.RibbonGroupCollapsedBack.StateNormal.BackColor3 = paletteColourArray[3];

                    palette.Ribbon.RibbonGroupCollapsedBack.StateNormal.BackColor4 = paletteColourArray[0];

                    palette.Ribbon.RibbonGroupCollapsedBack.StateTracking.BackColor1 = SystemColors.Window;

                    palette.Ribbon.RibbonGroupCollapsedBack.StateTracking.BackColor2 = paletteColourArray[3];

                    palette.Ribbon.RibbonGroupCollapsedBack.StateTracking.BackColor3 = paletteColourArray[4]; // Or 230, 230, 230

                    palette.Ribbon.RibbonGroupCollapsedBack.StateTracking.BackColor4 = paletteColourArray[0];

                    palette.Ribbon.RibbonGroupCollapsedBorder.StateCommon.BackColor1 = paletteColourArray[0];

                    palette.Ribbon.RibbonGroupCollapsedBorder.StateCommon.BackColor2 = paletteColourArray[2];

                    palette.Ribbon.RibbonGroupCollapsedBorder.StateCommon.BackColor3 = paletteColourArray[3];

                    palette.Ribbon.RibbonGroupCollapsedBorder.StateCommon.BackColor4 = paletteColourArray[0];

                    palette.Ribbon.RibbonGroupCollapsedBorder.StateCommon.BackColor5 = paletteColourArray[0];

                    palette.Ribbon.RibbonGroupCollapsedFrameBack.StateCommon.BackColor1 = paletteColourArray[0];

                    palette.Ribbon.RibbonGroupCollapsedFrameBack.StateCommon.BackColor2 = paletteColourArray[0];

                    palette.Ribbon.RibbonGroupCollapsedFrameBack.StateCommon.BackColor3 = paletteColourArray[3];

                    palette.Ribbon.RibbonGroupCollapsedFrameBack.StateCommon.BackColor4 = paletteColourArray[3];

                    palette.Ribbon.RibbonGroupCollapsedFrameBack.StateCommon.BackColor5 = paletteColourArray[0];

                    palette.Ribbon.RibbonGroupCollapsedFrameBorder.StateCommon.BackColor1 = paletteColourArray[3];

                    palette.Ribbon.RibbonGroupCollapsedFrameBorder.StateCommon.BackColor2 = paletteColourArray[4]; // Or 230, 230, 230

                    palette.Ribbon.RibbonGroupCollapsedText.StateCommon.TextColor = paletteColourArray[6];

                    palette.Ribbon.RibbonGroupNormalBorder.StateCommon.BackColor1 = paletteColourArray[0];

                    palette.Ribbon.RibbonGroupNormalBorder.StateCommon.BackColor2 = paletteColourArray[2];

                    palette.Ribbon.RibbonGroupNormalTitle.StateCommon.BackColor1 = paletteColourArray[4]; // Or 230, 230, 230

                    palette.Ribbon.RibbonGroupNormalTitle.StateCommon.BackColor2 = paletteColourArray[2];

                    palette.Ribbon.RibbonGroupNormalTitle.StateCommon.TextColor = paletteColourArray[25];

                    palette.Ribbon.RibbonGroupNormalTitle.StateTracking.BackColor1 = paletteColourArray[4];

                    palette.Ribbon.RibbonGroupNormalTitle.StateTracking.BackColor2 = paletteColourArray[2];

                    palette.Ribbon.RibbonQATFullbar.BackColor1 = paletteColourArray[2];

                    palette.Ribbon.RibbonQATFullbar.BackColor2 = paletteColourArray[2];

                    palette.Ribbon.RibbonQATFullbar.BackColor3 = paletteColourArray[2];

                    palette.Ribbon.RibbonQATMinibar.StateCommon.BackColor1 = paletteColourArray[2];

                    palette.Ribbon.RibbonQATMinibar.StateCommon.BackColor2 = paletteColourArray[2];

                    palette.Ribbon.RibbonQATMinibar.StateCommon.BackColor3 = paletteColourArray[2];

                    palette.Ribbon.RibbonQATMinibar.StateCommon.BackColor4 = paletteColourArray[2];

                    palette.Ribbon.RibbonQATOverflow.BackColor1 = paletteColourArray[2];

                    palette.Ribbon.RibbonQATOverflow.BackColor2 = paletteColourArray[2];

                    palette.Ribbon.RibbonTab.StateCheckedTracking.BackColor1 = paletteColourArray[2];

                    palette.Ribbon.RibbonTab.StateCheckedTracking.BackColor2 = paletteColourArray[3];

                    palette.Ribbon.RibbonTab.StateCheckedTracking.BackColor3 = paletteColourArray[1];

                    palette.Ribbon.RibbonTab.StateCheckedTracking.BackColor4 = paletteColourArray[2];

                    palette.Ribbon.RibbonTab.StateCommon.BackColor1 = paletteColourArray[2];

                    palette.Ribbon.RibbonTab.StateCommon.BackColor3 = paletteColourArray[2];

                    palette.Ribbon.RibbonTab.StateCommon.BackColor4 = paletteColourArray[3];

                    palette.Ribbon.RibbonTab.StateCommon.BackColor5 = paletteColourArray[3];

                    palette.Ribbon.RibbonTab.StateCommon.TextColor = paletteColourArray[7];

                    palette.Ribbon.RibbonTab.StateContextCheckedTracking.BackColor2 = paletteColourArray[2];

                    palette.Ribbon.RibbonTab.StateTracking.BackColor2 = paletteColourArray[2];

                    palette.Ribbon.RibbonTab.StateNormal.TextColor = paletteColourArray[28];
                    #endregion

                    #region Separator Styles
                    palette.SeparatorStyles.SeparatorCommon.StateCommon.Back.Color1 = paletteColourArray[0];

                    palette.SeparatorStyles.SeparatorCommon.StateCommon.Back.Color2 = paletteColourArray[0];

                    palette.SeparatorStyles.SeparatorCommon.StateCommon.Border.Color1 = paletteColourArray[0];

                    palette.SeparatorStyles.SeparatorCommon.StateCommon.Border.Color1 = paletteColourArray[0];

                    palette.SeparatorStyles.SeparatorCommon.StateCommon.Border.DrawBorders = PaletteDrawBorders.All;
                    #endregion

                    #region Tool Menu Status
                    palette.ToolMenuStatus.Button.ButtonPressedBorder = paletteColourArray[0];

                    palette.ToolMenuStatus.Button.ButtonSelectedBorder = paletteColourArray[0];

                    palette.ToolMenuStatus.Button.OverflowButtonGradientBegin = paletteColourArray[1];

                    palette.ToolMenuStatus.Button.OverflowButtonGradientEnd = paletteColourArray[0];

                    palette.ToolMenuStatus.Button.OverflowButtonGradientMiddle = paletteColourArray[2];

                    palette.ToolMenuStatus.Grip.GripDark = paletteColourArray[0];

                    palette.ToolMenuStatus.Grip.GripLight = paletteColourArray[20];

                    palette.ToolMenuStatus.Menu.ImageMarginGradientBegin = paletteColourArray[0];

                    palette.ToolMenuStatus.Menu.ImageMarginGradientEnd = paletteColourArray[1];

                    palette.ToolMenuStatus.Menu.ImageMarginGradientMiddle = paletteColourArray[2];

                    palette.ToolMenuStatus.Menu.ImageMarginRevealedGradientBegin = paletteColourArray[0];

                    palette.ToolMenuStatus.Menu.ImageMarginRevealedGradientEnd = paletteColourArray[1];

                    palette.ToolMenuStatus.Menu.ImageMarginRevealedGradientMiddle = paletteColourArray[2];

                    palette.ToolMenuStatus.Menu.MenuBorder = paletteColourArray[0];

                    palette.ToolMenuStatus.Menu.MenuItemBorder = paletteColourArray[1];

                    palette.ToolMenuStatus.Menu.MenuItemPressedGradientBegin = paletteColourArray[0];

                    palette.ToolMenuStatus.Menu.MenuItemPressedGradientEnd = paletteColourArray[1];

                    palette.ToolMenuStatus.Menu.MenuItemPressedGradientMiddle = paletteColourArray[2];

                    palette.ToolMenuStatus.Menu.MenuItemSelected = paletteColourArray[2];

                    palette.ToolMenuStatus.Menu.MenuItemSelectedGradientBegin = paletteColourArray[1];

                    palette.ToolMenuStatus.Menu.MenuItemSelectedGradientEnd = paletteColourArray[0];

                    palette.ToolMenuStatus.Menu.MenuItemText = paletteColourArray[26];

                    palette.ToolMenuStatus.MenuStrip.MenuStripGradientBegin = paletteColourArray[0];

                    palette.ToolMenuStatus.MenuStrip.MenuStripGradientEnd = paletteColourArray[1];

                    palette.ToolMenuStatus.MenuStrip.MenuStripText = paletteColourArray[7];

                    palette.ToolMenuStatus.Rafting.RaftingContainerGradientBegin = paletteColourArray[2];

                    palette.ToolMenuStatus.Rafting.RaftingContainerGradientEnd = paletteColourArray[1];

                    palette.ToolMenuStatus.Separator.SeparatorDark = paletteColourArray[0];

                    palette.ToolMenuStatus.Separator.SeparatorLight = paletteColourArray[3];

                    palette.ToolMenuStatus.StatusStrip.StatusStripGradientBegin = paletteColourArray[0];

                    palette.ToolMenuStatus.StatusStrip.StatusStripGradientEnd = paletteColourArray[3];

                    palette.ToolMenuStatus.StatusStrip.StatusStripText = paletteColourArray[7];

                    palette.ToolMenuStatus.ToolStrip.ToolStripBorder = paletteColourArray[1];

                    palette.ToolMenuStatus.ToolStrip.ToolStripContentPanelGradientBegin = paletteColourArray[3];

                    palette.ToolMenuStatus.ToolStrip.ToolStripContentPanelGradientEnd = paletteColourArray[1];

                    palette.ToolMenuStatus.ToolStrip.ToolStripDropDownBackground = paletteColourArray[2];

                    palette.ToolMenuStatus.ToolStrip.ToolStripGradientBegin = paletteColourArray[1];

                    palette.ToolMenuStatus.ToolStrip.ToolStripGradientEnd = paletteColourArray[3];

                    palette.ToolMenuStatus.ToolStrip.ToolStripGradientMiddle = paletteColourArray[2];

                    palette.ToolMenuStatus.ToolStrip.ToolStripPanelGradientBegin = paletteColourArray[3];

                    palette.ToolMenuStatus.ToolStrip.ToolStripPanelGradientEnd = paletteColourArray[1];

                    palette.ToolMenuStatus.ToolStrip.ToolStripText = paletteColourArray[7];
                    #endregion
                }

                palette.Export();

                KryptonMessageBox.Show($"Palette exported to: { palette.GetCustomisedKryptonPaletteFilePath() }", "Palette Created", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception e)
            {
                ExceptionHandler.CaptureException(e);
            }
        }
    }
}