#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.Collections;

namespace Krypton.Toolkit.Suite.Extended.Core
{
    public class PaletteCompisitionEngine
    {
        #region Variables
        private PaletteMode _paletteMode;
        #endregion

        #region Properties
        public PaletteMode PaletteMode { get { return _paletteMode; } set { _paletteMode = value; } }
        #endregion

        #region Constructors
        public PaletteCompisitionEngine()
        {

        }
        #endregion

        #region Methods        
        /// <summary>
        /// Creates a new palette.
        /// </summary>
        /// <param name="palette">The palette.</param>
        /// <param name="paletteMode">The palette mode.</param>
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
        /// <param name="disabledControlColourPreview">The disabled colour preview.</param>
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
        /// <param name="ribbonTabTextColour">The ribbon tab text colour.</param>
        /// <param name="statusState">State of the status.</param>
        /// <param name="invertColours">if set to <c>true</c> [invert colours].</param>
        public static void CreatePalette(KryptonPalette palette, PaletteMode paletteMode, Color baseColour, Color darkColour, Color middleColour, Color lightColour, Color lightestColour, Color borderColourPreview, Color alternativeNormalTextColourPreview, Color normalTextColourPreview, Color disabledTextColourPreview, Color focusedTextColourPreview, Color pressedTextColourPreview, Color disabledControlColourPreview, Color linkDisabledColourPreview, Color linkFocusedColour, Color linkNormalColourPreview, Color linkHoverColourPreview, Color linkVisitedColourPreview, Color customColourOne, Color customColourTwo, Color customColourThree, Color customColourFour, Color customColourFive, Color customTextColourOne, Color customTextColourTwo, Color customTextColourThree, Color customTextColourFour, Color customTextColourFive, Color menuTextColour, Color statusTextColour, Color ribbonTabTextColour, ToolStripLabel statusState = null, bool invertColours = false)
        {
            palette = new KryptonPalette();

            try
            {
                palette.BasePaletteMode = paletteMode;

                if (lightestColour == Color.Transparent)
                {
                    lightestColour = lightColour;
                }

                if (invertColours)
                {
                    #region Button Cluster
                    palette.ButtonStyles.ButtonCluster.OverrideDefault.Back.Color1 = darkColour;

                    palette.ButtonStyles.ButtonCluster.OverrideFocus.Back.Color1 = darkColour;

                    palette.ButtonStyles.ButtonCluster.StateCheckedNormal.Back.Color1 = darkColour;

                    palette.ButtonStyles.ButtonCluster.StateCommon.Back.ColorStyle = PaletteColorStyle.GlassNormalFull;

                    palette.ButtonStyles.ButtonCluster.StateNormal.Back.Color1 = middleColour;

                    palette.ButtonStyles.ButtonCluster.StatePressed.Back.Color1 = baseColour;

                    palette.ButtonStyles.ButtonCluster.StateTracking.Back.Color1 = darkColour;
                    #endregion

                    #region Button Common
                    palette.ButtonStyles.ButtonCommon.OverrideDefault.Back.Color1 = lightColour;

                    palette.ButtonStyles.ButtonCommon.OverrideDefault.Content.LongText.Color1 = normalTextColourPreview;

                    palette.ButtonStyles.ButtonCommon.OverrideDefault.Content.ShortText.Color1 = normalTextColourPreview;

                    palette.ButtonStyles.ButtonCommon.StateCheckedNormal.Back.Color1 = darkColour;

                    palette.ButtonStyles.ButtonCommon.StateCheckedNormal.Back.Color2 = baseColour;

                    palette.ButtonStyles.ButtonCommon.StateCheckedNormal.Back.ColorStyle = PaletteColorStyle.GlassCheckedFull;

                    palette.ButtonStyles.ButtonCommon.StateCheckedNormal.Content.LongText.Color1 = alternativeNormalTextColourPreview;

                    palette.ButtonStyles.ButtonCommon.StateCheckedNormal.Content.ShortText.Color1 = alternativeNormalTextColourPreview;

                    palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Back.Color1 = darkColour;

                    palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Back.Color2 = baseColour;

                    palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Back.ColorStyle = PaletteColorStyle.GlassCheckedStump;

                    palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Border.DrawBorders = PaletteDrawBorders.All;

                    palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Content.LongText.Color1 = alternativeNormalTextColourPreview;

                    palette.ButtonStyles.ButtonCommon.StateCheckedPressed.Content.ShortText.Color1 = alternativeNormalTextColourPreview;

                    palette.ButtonStyles.ButtonCommon.StateCheckedTracking.Back.Color1 = baseColour;

                    palette.ButtonStyles.ButtonCommon.StateCheckedTracking.Back.Color2 = baseColour;

                    palette.ButtonStyles.ButtonCommon.StateCheckedTracking.Border.DrawBorders = PaletteDrawBorders.All;

                    palette.ButtonStyles.ButtonCommon.StateCheckedTracking.Content.LongText.Color1 = alternativeNormalTextColourPreview;

                    palette.ButtonStyles.ButtonCommon.StateCheckedTracking.Content.ShortText.Color1 = alternativeNormalTextColourPreview;

                    palette.ButtonStyles.ButtonCommon.StateCommon.Back.Color1 = lightColour;

                    palette.ButtonStyles.ButtonCommon.StateDisabled.Back.Color1 = disabledControlColourPreview;

                    palette.ButtonStyles.ButtonCommon.StateDisabled.Back.Color2 = disabledControlColourPreview;

                    /*
                    palette.ButtonStyles.ButtonCommon.StateDisabled.Back.Color1 = lightColour;

                    palette.ButtonStyles.ButtonCommon.StateDisabled.Back.Color2 = lightColour;
                    */

                    palette.ButtonStyles.ButtonCommon.StateDisabled.Content.LongText.Color1 = disabledTextColourPreview;

                    palette.ButtonStyles.ButtonCommon.StateDisabled.Content.ShortText.Color1 = disabledTextColourPreview;

                    palette.ButtonStyles.ButtonCommon.StateNormal.Back.Color1 = lightColour;

                    palette.ButtonStyles.ButtonCommon.StateNormal.Back.Color2 = lightColour;

                    palette.ButtonStyles.ButtonCommon.StateNormal.Content.LongText.Color1 = normalTextColourPreview;

                    palette.ButtonStyles.ButtonCommon.StateNormal.Content.LongText.Color2 = normalTextColourPreview;

                    palette.ButtonStyles.ButtonCommon.StateNormal.Content.ShortText.Color1 = normalTextColourPreview;

                    palette.ButtonStyles.ButtonCommon.StateNormal.Content.ShortText.Color2 = normalTextColourPreview;

                    palette.ButtonStyles.ButtonCommon.StatePressed.Back.Color1 = darkColour;

                    palette.ButtonStyles.ButtonCommon.StatePressed.Back.Color2 = baseColour;

                    palette.ButtonStyles.ButtonCommon.StatePressed.Content.LongText.Color1 = alternativeNormalTextColourPreview;

                    palette.ButtonStyles.ButtonCommon.StatePressed.Content.ShortText.Color1 = alternativeNormalTextColourPreview;

                    palette.ButtonStyles.ButtonCommon.StateTracking.Back.Color1 = lightColour;

                    palette.ButtonStyles.ButtonCommon.StateTracking.Back.Color2 = lightestColour;

                    palette.ButtonStyles.ButtonCommon.StateTracking.Content.LongText.Color1 = normalTextColourPreview;

                    palette.ButtonStyles.ButtonCommon.StateTracking.Content.ShortText.Color1 = normalTextColourPreview;
                    #endregion

                    #region Common
                    palette.Common.StateCommon.Back.Color1 = darkColour;

                    palette.Common.StateCommon.Back.Color2 = middleColour;

                    palette.Common.StateCommon.Border.Color1 = middleColour;

                    palette.Common.StateCommon.Border.Color2 = lightestColour;

                    palette.Common.StateCommon.Border.DrawBorders = PaletteDrawBorders.All;

                    palette.Common.StateCommon.Content.LongText.Color1 = normalTextColourPreview;

                    palette.Common.StateCommon.Content.LongText.Color2 = normalTextColourPreview;

                    palette.Common.StateCommon.Content.ShortText.Color1 = normalTextColourPreview;

                    palette.Common.StateCommon.Content.ShortText.Color2 = normalTextColourPreview;
                    #endregion

                    #region Form Styles
                    palette.FormStyles.FormCommon.StateActive.Back.Color1 = middleColour;

                    palette.FormStyles.FormCommon.StateActive.Border.DrawBorders = PaletteDrawBorders.All;
                    #endregion

                    #region Grid Styles
                    palette.GridStyles.GridSheet.StateCommon.HeaderColumn.Content.Color1 = darkColour;

                    palette.GridStyles.GridSheet.StateCommon.HeaderRow.Content.Color1 = darkColour;

                    palette.GridStyles.GridSheet.StateNormal.HeaderColumn.Content.Color1 = lightestColour;

                    palette.GridStyles.GridSheet.StateNormal.HeaderColumn.Content.Color2 = baseColour;

                    palette.GridStyles.GridSheet.StateNormal.HeaderRow.Content.Color1 = lightestColour;

                    palette.GridStyles.GridSheet.StateTracking.HeaderColumn.Content.Color1 = middleColour;
                    #endregion
                }
                else
                {
                    #region Button Cluster
                    palette.ButtonStyles.ButtonCluster.OverrideDefault.Back.Color1 = baseColour;

                    palette.ButtonStyles.ButtonCluster.OverrideFocus.Back.Color1 = baseColour;

                    palette.ButtonStyles.ButtonCluster.StateCheckedNormal.Back.Color1 = baseColour;

                    palette.ButtonStyles.ButtonCluster.StateCommon.Back.ColorStyle = PaletteColorStyle.GlassNormalFull;

                    palette.ButtonStyles.ButtonCluster.StateNormal.Back.Color1 = middleColour;

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

                    palette.ButtonStyles.ButtonCommon.StateDisabled.Back.Color1 = disabledControlColourPreview;

                    palette.ButtonStyles.ButtonCommon.StateDisabled.Back.Color2 = disabledControlColourPreview;

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

                    palette.GridStyles.GridSheet.StateNormal.HeaderColumn.Content.Color2 = middleColour;

                    palette.GridStyles.GridSheet.StateNormal.HeaderRow.Content.Color1 = darkColour;

                    palette.GridStyles.GridSheet.StateTracking.HeaderColumn.Content.Color1 = baseColour;
                    #endregion

                    #region Header Styles
                    palette.HeaderStyles.HeaderCommon.StateCommon.Back.Color1 = middleColour;

                    palette.HeaderStyles.HeaderCommon.StateCommon.Back.Color2 = lightColour;

                    palette.HeaderStyles.HeaderCommon.StateDisabled.Back.Color1 = lightColour;

                    palette.HeaderStyles.HeaderCommon.StateDisabled.Back.Color2 = lightestColour;

                    palette.HeaderStyles.HeaderCommon.StateDisabled.Content.LongText.Color1 = disabledTextColourPreview;

                    palette.HeaderStyles.HeaderCommon.StateDisabled.Content.LongText.Color2 = baseColour;

                    palette.HeaderStyles.HeaderCommon.StateDisabled.Content.ShortText.Color1 = disabledTextColourPreview;

                    palette.HeaderStyles.HeaderCommon.StateDisabled.Content.ShortText.Color2 = baseColour;

                    palette.HeaderStyles.HeaderForm.StateCommon.Back.Color1 = middleColour;

                    palette.HeaderStyles.HeaderForm.StateCommon.Back.Color2 = lightColour;

                    palette.HeaderStyles.HeaderForm.StateDisabled.Back.Color1 = disabledControlColourPreview;

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

                    palette.LabelStyles.LabelNormalControl.StateDisabled.LongText.Color1 = linkDisabledColourPreview;

                    palette.LabelStyles.LabelNormalControl.StateDisabled.ShortText.Color1 = linkDisabledColourPreview;

                    palette.LabelStyles.LabelNormalControl.StateNormal.LongText.Color1 = normalTextColourPreview;

                    palette.LabelStyles.LabelNormalControl.StateNormal.ShortText.Color1 = normalTextColourPreview;

                    palette.LabelStyles.LabelNormalControl.OverrideFocus.LongText.Color1 = linkFocusedColour;

                    palette.LabelStyles.LabelNormalControl.OverrideFocus.ShortText.Color1 = linkFocusedColour;
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

                    palette.Ribbon.RibbonGroupCollapsedBorder.StateCommon.BackColor2 = middleColour;

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

                    palette.Ribbon.RibbonGroupNormalBorder.StateCommon.BackColor2 = middleColour;

                    palette.Ribbon.RibbonGroupNormalTitle.StateCommon.BackColor1 = lightestColour; // Or 230, 230, 230

                    palette.Ribbon.RibbonGroupNormalTitle.StateCommon.BackColor2 = middleColour;

                    palette.Ribbon.RibbonGroupNormalTitle.StateCommon.TextColor = customTextColourFive;

                    palette.Ribbon.RibbonGroupNormalTitle.StateTracking.BackColor1 = lightestColour;

                    palette.Ribbon.RibbonGroupNormalTitle.StateTracking.BackColor2 = middleColour;

                    palette.Ribbon.RibbonQATFullbar.BackColor1 = middleColour;

                    palette.Ribbon.RibbonQATFullbar.BackColor2 = middleColour;

                    palette.Ribbon.RibbonQATFullbar.BackColor3 = middleColour;

                    palette.Ribbon.RibbonQATMinibar.StateCommon.BackColor1 = middleColour;

                    palette.Ribbon.RibbonQATMinibar.StateCommon.BackColor2 = middleColour;

                    palette.Ribbon.RibbonQATMinibar.StateCommon.BackColor3 = middleColour;

                    palette.Ribbon.RibbonQATMinibar.StateCommon.BackColor4 = middleColour;

                    palette.Ribbon.RibbonQATOverflow.BackColor1 = middleColour;

                    palette.Ribbon.RibbonQATOverflow.BackColor2 = middleColour;

                    palette.Ribbon.RibbonTab.StateCheckedTracking.BackColor1 = middleColour;

                    palette.Ribbon.RibbonTab.StateCheckedTracking.BackColor2 = lightColour;

                    palette.Ribbon.RibbonTab.StateCheckedTracking.BackColor3 = darkColour;

                    palette.Ribbon.RibbonTab.StateCheckedTracking.BackColor4 = middleColour;

                    palette.Ribbon.RibbonTab.StateCommon.BackColor1 = middleColour;

                    palette.Ribbon.RibbonTab.StateCommon.BackColor3 = middleColour;

                    palette.Ribbon.RibbonTab.StateCommon.BackColor4 = lightColour;

                    palette.Ribbon.RibbonTab.StateCommon.BackColor5 = lightColour;

                    palette.Ribbon.RibbonTab.StateCommon.TextColor = normalTextColourPreview;

                    palette.Ribbon.RibbonTab.StateContextCheckedTracking.BackColor2 = middleColour;

                    palette.Ribbon.RibbonTab.StateTracking.BackColor2 = middleColour;

                    palette.Ribbon.RibbonTab.StateCommon.TextColor = ribbonTabTextColour;
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

                    palette.ToolMenuStatus.Button.OverflowButtonGradientMiddle = middleColour;

                    palette.ToolMenuStatus.Grip.GripDark = baseColour;

                    palette.ToolMenuStatus.Grip.GripLight = customColourFive;

                    palette.ToolMenuStatus.Menu.ImageMarginGradientBegin = baseColour;

                    palette.ToolMenuStatus.Menu.ImageMarginGradientEnd = darkColour;

                    palette.ToolMenuStatus.Menu.ImageMarginGradientMiddle = middleColour;

                    palette.ToolMenuStatus.Menu.ImageMarginRevealedGradientBegin = baseColour;

                    palette.ToolMenuStatus.Menu.ImageMarginRevealedGradientEnd = darkColour;

                    palette.ToolMenuStatus.Menu.ImageMarginRevealedGradientMiddle = middleColour;

                    palette.ToolMenuStatus.Menu.MenuBorder = baseColour;

                    palette.ToolMenuStatus.Menu.MenuItemBorder = darkColour;

                    palette.ToolMenuStatus.Menu.MenuItemPressedGradientBegin = baseColour;

                    palette.ToolMenuStatus.Menu.MenuItemPressedGradientEnd = darkColour;

                    palette.ToolMenuStatus.Menu.MenuItemPressedGradientMiddle = middleColour;

                    palette.ToolMenuStatus.Menu.MenuItemSelected = middleColour;

                    palette.ToolMenuStatus.Menu.MenuItemSelectedGradientBegin = darkColour;

                    palette.ToolMenuStatus.Menu.MenuItemSelectedGradientEnd = baseColour;

                    palette.ToolMenuStatus.Menu.MenuItemText = menuTextColour;

                    palette.ToolMenuStatus.MenuStrip.MenuStripGradientBegin = baseColour;

                    palette.ToolMenuStatus.MenuStrip.MenuStripGradientEnd = darkColour;

                    palette.ToolMenuStatus.MenuStrip.MenuStripText = normalTextColourPreview;

                    palette.ToolMenuStatus.Rafting.RaftingContainerGradientBegin = middleColour;

                    palette.ToolMenuStatus.Rafting.RaftingContainerGradientEnd = darkColour;

                    palette.ToolMenuStatus.Separator.SeparatorDark = baseColour;

                    palette.ToolMenuStatus.Separator.SeparatorLight = lightColour;

                    palette.ToolMenuStatus.StatusStrip.StatusStripGradientBegin = baseColour;

                    palette.ToolMenuStatus.StatusStrip.StatusStripGradientEnd = lightColour;

                    palette.ToolMenuStatus.StatusStrip.StatusStripText = normalTextColourPreview;

                    palette.ToolMenuStatus.ToolStrip.ToolStripBorder = darkColour;

                    palette.ToolMenuStatus.ToolStrip.ToolStripContentPanelGradientBegin = lightColour;

                    palette.ToolMenuStatus.ToolStrip.ToolStripContentPanelGradientEnd = darkColour;

                    palette.ToolMenuStatus.ToolStrip.ToolStripDropDownBackground = middleColour;

                    palette.ToolMenuStatus.ToolStrip.ToolStripGradientBegin = darkColour;

                    palette.ToolMenuStatus.ToolStrip.ToolStripGradientEnd = lightColour;

                    palette.ToolMenuStatus.ToolStrip.ToolStripGradientMiddle = middleColour;

                    palette.ToolMenuStatus.ToolStrip.ToolStripPanelGradientBegin = lightColour;

                    palette.ToolMenuStatus.ToolStrip.ToolStripPanelGradientEnd = darkColour;

                    palette.ToolMenuStatus.ToolStrip.ToolStripText = normalTextColourPreview;
                    #endregion
                }

                palette.Export();

                statusState.Text = $"Palette exported to: { palette.GetCustomisedKryptonPaletteFilePath() }";
            }
            catch (Exception exc)
            {
                ExceptionHandler.CaptureException(exc, icon: MessageBoxIcon.Error, methodSignature: Helpers.GetCurrentMethod());
            }
        }

        public static void ChangeTheme(KryptonComboBox themeChoice, KryptonPalette palette)
        {
            if (themeChoice.Text == "Global")
            {
                palette.BasePaletteMode = PaletteMode.Global;

                SwitchPaletteMode(PaletteMode.Global);
            }
            else if (themeChoice.Text == "Professional System")
            {
                palette.BasePaletteMode = PaletteMode.ProfessionalSystem;

                SwitchPaletteMode(PaletteMode.ProfessionalSystem);
            }
            else if (themeChoice.Text == "Professional Office 2003")
            {
                palette.BasePaletteMode = PaletteMode.ProfessionalOffice2003;

                SwitchPaletteMode(PaletteMode.ProfessionalOffice2003);
            }
            else if (themeChoice.Text == "Office 2007 Blue")
            {
                palette.BasePaletteMode = PaletteMode.Office2007Blue;

                SwitchPaletteMode(PaletteMode.Office2007Blue);
            }
            else if (themeChoice.Text == "Office 2007 Black")
            {
                palette.BasePaletteMode = PaletteMode.Office2007Black;

                SwitchPaletteMode(PaletteMode.Office2007Black);
            }
            else if (themeChoice.Text == "Office 2007 Silver")
            {
                palette.BasePaletteMode = PaletteMode.Office2007Silver;

                SwitchPaletteMode(PaletteMode.Office2007Silver);
            }
            else if (themeChoice.Text == "Office 2010 Blue")
            {
                palette.BasePaletteMode = PaletteMode.Office2010Blue;

                SwitchPaletteMode(PaletteMode.Office2010Blue);
            }
            else if (themeChoice.Text == "Office 2010 Black")
            {
                palette.BasePaletteMode = PaletteMode.Office2010Black;

                SwitchPaletteMode(PaletteMode.Office2010Black);
            }
            else if (themeChoice.Text == "Office 2010 Silver")
            {
                palette.BasePaletteMode = PaletteMode.Office2010Silver;

                SwitchPaletteMode(PaletteMode.Office2010Silver);
            }
            else if (themeChoice.Text == "Office 2013 White")
            {
                palette.BasePaletteMode = PaletteMode.Office2013White;

                SwitchPaletteMode(PaletteMode.Office2013White);
            }
            else if (themeChoice.Text == "Sparkle Blue")
            {
                palette.BasePaletteMode = PaletteMode.SparkleBlue;

                SwitchPaletteMode(PaletteMode.SparkleBlue);
            }
            else if (themeChoice.Text == "Sparkle Orange")
            {
                palette.BasePaletteMode = PaletteMode.SparkleOrange;

                SwitchPaletteMode(PaletteMode.SparkleOrange);
            }
            else if (themeChoice.Text == "Sparkle Purple")
            {
                palette.BasePaletteMode = PaletteMode.SparklePurple;

                SwitchPaletteMode(PaletteMode.SparklePurple);
            }
            else if (themeChoice.Text == "Custom")
            {
                palette.BasePaletteMode = PaletteMode.Custom;

                SwitchPaletteMode(PaletteMode.Custom);
            }
        }

        private static void SwitchPaletteMode(PaletteMode mode)
        {
            PaletteCompisitionEngine pce = new PaletteCompisitionEngine();

            pce.SetPaletteMode(mode);
        }

        public static void PropagateThemes(KryptonComboBox themeList, bool sort = true)
        {
            ArrayList themeCollection = new ArrayList(15);

            themeCollection.Add("Global");

            themeCollection.Add("Professional System");

            themeCollection.Add("Professional Office 2003");

            themeCollection.Add("Office 2007 Blue");

            themeCollection.Add("Office 2007 Black");

            themeCollection.Add("Office 2007 Silver");

            themeCollection.Add("Office 2010 Blue");

            themeCollection.Add("Office 2010 Black");

            themeCollection.Add("Office 2010 Silver");

            themeCollection.Add("Office 2013");

            themeCollection.Add("Office 2013 White");

            themeCollection.Add("Sparkle Blue");

            themeCollection.Add("Sparkle Orange");

            themeCollection.Add("Sparkle Purple");

            themeCollection.Add("Custom");

            if (sort)
            {
                themeCollection.Sort();
            }

            foreach (string item in themeCollection)
            {
                themeList.Items.Add(item);
            }
        }

        public static void PropagateThemes(KryptonRibbonGroupComboBox themeList, bool sort = true)
        {
            ArrayList themeCollection = new ArrayList(15);

            themeCollection.Add("Global");

            themeCollection.Add("Professional System");

            themeCollection.Add("Professional Office 2003");

            themeCollection.Add("Office 2007 Blue");

            themeCollection.Add("Office 2007 Black");

            themeCollection.Add("Office 2007 Silver");

            themeCollection.Add("Office 2010 Blue");

            themeCollection.Add("Office 2010 Black");

            themeCollection.Add("Office 2010 Silver");

            themeCollection.Add("Office 2013");

            themeCollection.Add("Office 2013 White");

            themeCollection.Add("Sparkle Blue");

            themeCollection.Add("Sparkle Orange");

            themeCollection.Add("Sparkle Purple");

            themeCollection.Add("Custom");

            if (sort)
            {
                themeCollection.Sort();
            }

            foreach (string item in themeCollection)
            {
                themeList.Items.Add(item);
            }
        }
        #endregion

        #region Setters and Getters
        /// <summary>
        /// Sets the PaletteMode to the value of mode.
        /// </summary>
        /// <param name="mode">The value of mode.</param>
        public void SetPaletteMode(PaletteMode mode)
        {
            PaletteMode = mode;
        }

        /// <summary>
        /// Gets the PaletteMode value.
        /// </summary>
        /// <returns>The value of mode.</returns>
        public PaletteMode GetPaletteMode()
        {
            return PaletteMode;
        }
        #endregion
    }
}