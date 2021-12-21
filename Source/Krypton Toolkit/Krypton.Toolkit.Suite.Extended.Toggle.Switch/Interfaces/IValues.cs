#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Toggle.Switch
{
    public interface IGlobalValues
    {
        public int ButtonShadowWidth { get; set; }
        public int CornerRadius { get; set; }
    }

    #region ICarbonValues
    public interface ICarbonValues
    {
        public Color OuterBorderColour { get; set; }
        public Color OuterBorderColour1 { get; set; }
        public Color OuterBorderColour2 { get; set; }
        public Color InnerBorderColour1 { get; set; }
        public Color InnerBorderColour2 { get; set; }
        public Color LeftSideBackColour1 { get; set; }
        public Color LeftSideBackColour2 { get; set; }
        public Color RightSideBackColour1 { get; set; }
        public Color RightSideBackColour2 { get; set; }
        public Color ButtonNormalBorderColour1 { get; set; }
        public Color ButtonNormalBorderColour2 { get; set; }
        public Color ButtonNormalSurfaceColour1 { get; set; }
        public Color ButtonNormalSurfaceColour2 { get; set; }
        public Color ButtonNormalUpperSurfaceColour1 { get; set; }
        public Color ButtonNormalUpperSurfaceColour2 { get; set; }
        public Color ButtonNormalLowerSurfaceColour1 { get; set; }
        public Color ButtonNormalLowerSurfaceColour2 { get; set; }
        public Color ButtonHoverBorderColour1 { get; set; }
        public Color ButtonHoverBorderColour2 { get; set; }
        public Color ButtonHoverSurfaceColour1 { get; set; }
        public Color ButtonHoverSurfaceColour2 { get; set; }
        public Color ButtonHoverUpperSurfaceColour1 { get; set; }
        public Color ButtonHoverUpperSurfaceColour2 { get; set; }
        public Color ButtonHoverLowerSurfaceColour1 { get; set; }
        public Color ButtonHoverLowerSurfaceColour2 { get; set; }
        public Color ButtonPressedBorderColour1 { get; set; }
        public Color ButtonPressedBorderColour2 { get; set; }
        public Color ButtonPressedSurfaceColour1 { get; set; }
        public Color ButtonPressedSurfaceColour2 { get; set; }
        public Color ButtonPressedUpperSurfaceColour1 { get; set; }
        public Color ButtonPressedUpperSurfaceColour2 { get; set; }
        public Color ButtonPressedLowerSurfaceColour1 { get; set; }
        public Color ButtonPressedLowerSurfaceColour2 { get; set; }
        public Color ButtonShadowColour1 { get; set; }
        public Color ButtonShadowColour2 { get; set; }
    }
    #endregion

    #region IFancyValues
    public interface IFancyValues
    {
        public Color OuterBorderColour1 { get; set; }
        public Color OuterBorderColour2 { get; set; }
        public Color InnerBorderColour1 { get; set; }
        public Color InnerBorderColour2 { get; set; }
        public Color LeftSideBackColour1 { get; set; }
        public Color LeftSideBackColour2 { get; set; }
        public Color RightSideBackColour1 { get; set; }
        public Color RightSideBackColour2 { get; set; }
        public Color ButtonNormalBorderColour1 { get; set; }
        public Color ButtonNormalBorderColour2 { get; set; }
        public Color ButtonNormalUpperSurfaceColour1 { get; set; }
        public Color ButtonNormalUpperSurfaceColour2 { get; set; }
        public Color ButtonNormalLowerSurfaceColour1 { get; set; }
        public Color ButtonNormalLowerSurfaceColour2 { get; set; }
        public Color ButtonHoverBorderColour1 { get; set; }
        public Color ButtonHoverBorderColour2 { get; set; }
        public Color ButtonHoverUpperSurfaceColour1 { get; set; }
        public Color ButtonHoverUpperSurfaceColour2 { get; set; }
        public Color ButtonHoverLowerSurfaceColour1 { get; set; }
        public Color ButtonHoverLowerSurfaceColour2 { get; set; }
        public Color ButtonPressedBorderColour1 { get; set; }
        public Color ButtonPressedBorderColour2 { get; set; }
        public Color ButtonPressedUpperSurfaceColour1 { get; set; }
        public Color ButtonPressedUpperSurfaceColour2 { get; set; }
        public Color ButtonPressedLowerSurfaceColour1 { get; set; }
        public Color ButtonPressedLowerSurfaceColour2 { get; set; }
        public Color ButtonShadowColour1 { get; set; }
        public Color ButtonShadowColour2 { get; set; }
    }
    #endregion

    #region IIOS5Values
    public interface IIOS5Content
    {
        public Color BorderColour { get; set; }
        public Color LeftSideUpperColour1 { get; set; }
        public Color LeftSideUpperColour2 { get; set; }
        public Color LeftSideLowerColour1 { get; set; }
        public Color LeftSideLowerColour2 { get; set; }
        public Color LeftSideUpperBorderColour { get; set; }
        public Color LeftSideLowerBorderColour { get; set; }
        public Color RightSideUpperColour1 { get; set; }
        public Color RightSideUpperColour2 { get; set; }
        public Color RightSideLowerColour1 { get; set; }
        public Color RightSideLowerColour2 { get; set; }
        public Color RightSideUpperBorderColour { get; set; }
        public Color RightSideLowerBorderColour { get; set; }
        public Color ButtonShadowColour { get; set; }
        public Color ButtonNormalOuterBorderColour { get; set; }
        public Color ButtonNormalInnerBorderColour { get; set; }
        public Color ButtonNormalSurfaceColour1 { get; set; }
        public Color ButtonNormalSurfaceColour2 { get; set; }
        public Color ButtonHoverOuterBorderColour { get; set; }
        public Color ButtonHoverInnerBorderColour { get; set; }
        public Color ButtonHoverSurfaceColour1 { get; set; }
        public Color ButtonHoverSurfaceColour2 { get; set; }
        public Color ButtonPressedOuterBorderColour { get; set; }
        public Color ButtonPressedInnerBorderColour { get; set; }
        public Color ButtonPressedSurfaceColour1 { get; set; }
        public Color ButtonPressedSurfaceColour2 { get; set; }
    }
    #endregion

    #region IIPhoneValues
    public interface IIPhoneValues
    {
        public Color OuterBorderColour { get; set; }
        public Color InnerBorderColour1 { get; set; }
        public Color InnerBorderColour2 { get; set; }
        public Color LeftSideBackColour1 { get; set; }
        public Color LeftSideBackColour2 { get; set; }
        public Color RightSideBackColour1 { get; set; }
        public Color RightSideBackColour2 { get; set; }
        public Color ButtonNormalBorderColour1 { get; set; }
        public Color ButtonNormalBorderColour2 { get; set; }
        public Color ButtonNormalSurfaceColour1 { get; set; }
        public Color ButtonNormalSurfaceColour2 { get; set; }
        public Color ButtonHoverBorderColour1 { get; set; }
        public Color ButtonHoverBorderColour2 { get; set; }
        public Color ButtonHoverSurfaceColour1 { get; set; }
        public Color ButtonHoverSurfaceColour2 { get; set; }
        public Color ButtonPressedBorderColour1 { get; set; }
        public Color ButtonPressedBorderColour2 { get; set; }
        public Color ButtonPressedSurfaceColour1 { get; set; }
        public Color ButtonPressedSurfaceColour2 { get; set; }
        public Color ButtonShadowColour1 { get; set; }
        public Color ButtonShadowColour2 { get; set; }
        public int ButtonCornerRadius { get; set; }
    }
    #endregion

    #region IMetroValues
    public interface IMetroValues
    {
        public Color BackColour { get; set; }
        public Color LeftSideColour { get; set; }
        public Color LeftSideColourHovered { get; set; }
        public Color LeftSideColourPressed { get; set; }
        public Color RightSideColour { get; set; }
        public Color RightSideColourHovered { get; set; }
        public Color RightSideColourPressed { get; set; }
        public Color BorderColour { get; set; }
        public Color ButtonColour { get; set; }
        public Color ButtonColourHovered { get; set; }
        public Color ButtonColourPressed { get; set; }
    }
    #endregion

    #region IModernValues
    public interface IModernValues
    {
        public Color OuterBorderColour { get; set; }
        public Color InnerBorderColour1 { get; set; }
        public Color InnerBorderColour2 { get; set; }
        public Color LeftSideBackColour1 { get; set; }
        public Color LeftSideBackColour2 { get; set; }
        public Color RightSideBackColour1 { get; set; }
        public Color RightSideBackColour2 { get; set; }
        public Color ButtonNormalBorderColour1 { get; set; }
        public Color ButtonNormalBorderColour2 { get; set; }
        public Color ButtonNormalSurfaceColour1 { get; set; }
        public Color ButtonNormalSurfaceColour2 { get; set; }
        public Color ArrowNormalColour { get; set; }
        public Color ButtonHoverBorderColour1 { get; set; }
        public Color ButtonHoverBorderColour2 { get; set; }
        public Color ButtonHoverSurfaceColour1 { get; set; }
        public Color ButtonHoverSurfaceColour2 { get; set; }
        public Color ArrowHoverColour { get; set; }
        public Color ButtonPressedBorderColour1 { get; set; }
        public Color ButtonPressedBorderColour2 { get; set; }
        public Color ButtonPressedSurfaceColour1 { get; set; }
        public Color ButtonPressedSurfaceColour2 { get; set; }
        public Color ArrowPressedColour { get; set; }
        public Color ButtonShadowColour1 { get; set; }
        public Color ButtonShadowColour2 { get; set; }
        public int ButtonCornerRadius { get; set; }
    }
    #endregion

    #region IOSXValues
    public interface IOSXValues
    {
        public Color OuterBorderColour { get; set; }
        public Color InnerBorderColour1 { get; set; }
        public Color InnerBorderColour2 { get; set; }
        public Color BackColour1 { get; set; }
        public Color BackColour2 { get; set; }
        public Color ButtonNormalBorderColour1 { get; set; }
        public Color ButtonNormalBorderColour2 { get; set; }
        public Color ButtonNormalSurfaceColour1 { get; set; }
        public Color ButtonNormalSurfaceColour2 { get; set; }
        public Color ButtonHoverBorderColour1 { get; set; }
        public Color ButtonHoverBorderColour2 { get; set; }
        public Color ButtonHoverSurfaceColour1 { get; set; }
        public Color ButtonHoverSurfaceColour2 { get; set; }
        public Color ButtonPressedBorderColour1 { get; set; }
        public Color ButtonPressedBorderColour2 { get; set; }
        public Color ButtonPressedSurfaceColour1 { get; set; }
        public Color ButtonPressedSurfaceColour2 { get; set; }
        public Color ButtonShadowColour1 { get; set; }
        public Color ButtonShadowColour2 { get; set; }
    }
    #endregion

    #region IPlainAndSimpleValues
    public interface IPlainAndSimpleValues
    {
        public Color BorderColourChecked { get; set; }
        public Color BorderColourUnchecked { get; set; }
        public int BorderWidth { get; set; }
        public int ButtonMargin { get; set; }
        public Color InnerBackgroundColour { get; set; }
        public Color ButtonColour { get; set; }
    }
    #endregion

    #region IAndroidValues
    public interface IAndroidValues
    {
        public Color BorderColour { get; set; }
        public Color BackColour { get; set; }
        public Color LeftSideColour { get; set; }
        public Color RightSideColour { get; set; }
        public Color OffButtonColour { get; set; }
        public Color OnButtonColour { get; set; }
        public Color OffButtonBorderColour { get; set; }
        public Color OnButtonBorderColour { get; set; }
        public int SlantAngle { get; set; }
    }
    #endregion

    #region IBrushedMetalValues
    public interface IBrushedMetalValues
    {
        public Color BorderColour1 { get; set; }
        public Color BorderColour2 { get; set; }
        public Color BackColour1 { get; set; }
        public Color BackColour2 { get; set; }
        public Color UpperShadowColour1 { get; set; }
        public Color UpperShadowColour2 { get; set; }
        public Color ButtonNormalBorderColour { get; set; }
        public Color ButtonNormalSurfaceColour { get; set; }
        public Color ButtonHoverBorderColour { get; set; }
        public Color ButtonHoverSurfaceColour { get; set; }
        public Color ButtonPressedBorderColour { get; set; }
        public Color ButtonPressedSurfaceColour { get; set; }

        public int UpperShadowHeight { get; set; }
    }
    #endregion
}