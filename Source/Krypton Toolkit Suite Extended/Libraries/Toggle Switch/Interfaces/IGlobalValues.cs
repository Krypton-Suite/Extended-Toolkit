using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Toggle.Switch
{
    public interface IGlobalValues
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

        public int ButtonShadowWidth { get; set; }
        public int CornerRadius { get; set; }
    }
}