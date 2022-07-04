#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Navi.Suite
{
    public class NaviColourTableOff3Blue : NaviColourTable
    {
        // General colors 
        public override Color Border => Color.FromArgb(0, 45, 150);
        public override Color BorderInner => Color.FromArgb(255, 255, 255);
        public override Color Text => Color.FromArgb(0, 0, 0);
        public override Color Background => Color.FromArgb(255, 255, 255);
        public override Color ShapesFront => Color.FromArgb(0, 45, 150);

        // Designtime only
        public override Color DashedLineColor => Color.FromArgb(101, 147, 207);

        // NaviBandCollapsed
        public override Color BandCollapsedBgColor1 => Color.FromArgb(162, 193, 245);
        public override Color BandCollapsedBgColor2 => Color.FromArgb(209, 214, 220);
        public override Color BandCollapsedHoveredColor1 => Color.FromArgb(255, 231, 162);
        public override Color BandCollapsedClickedColor1 => Color.FromArgb(251, 140, 60);

        // NaviBand Popup
        public override Color PopupBandBackground1 => Color.FromArgb(227, 239, 255);
        public override Color PopupBandBackground2 => Color.FromArgb(227, 239, 255);

        // NaviBar header
        public override Color HeaderColor1 => Color.FromArgb(7, 59, 150);
        public override Color HeaderColor2 => Color.FromArgb(89, 135, 214);
        public override Color HeaderText => Color.FromArgb(255, 255, 255);

        // NaviBar Overflowpanel
        public override Color OverflowColor1 => Color.FromArgb(209, 214, 220);
        public override Color OverflowColor2 => Color.FromArgb(209, 214, 220);

        // NaviButton Normal
        public override Color ButtonNormalColor1 => Color.FromArgb(210, 229, 252);
        public override Color ButtonNormalColor2 => Color.FromArgb(139, 176, 228);
        public override Color ButtonNormalColor3 => Color.FromArgb(196, 221, 255); // Hightlight dark
        public override Color ButtonNormalColor4 => Color.FromArgb(227, 239, 255); // Highlight light

        // NaviButton hovered
        public override Color ButtonHoveredColor1 => Color.FromArgb(255, 255, 220);
        public override Color ButtonHoveredColor2 => Color.FromArgb(255, 215, 103);
        public override Color ButtonHoveredColor3 => Color.FromArgb(255, 233, 168);
        public override Color ButtonHoveredColor4 => Color.FromArgb(255, 254, 228);

        // NaviButton active
        public override Color ButtonActiveColor1 => Color.FromArgb(252, 233, 160);
        public override Color ButtonActiveColor2 => Color.FromArgb(240, 161, 30);
        public override Color ButtonActiveColor3 => Color.FromArgb(255, 188, 111);
        public override Color ButtonActiveColor4 => Color.FromArgb(255, 217, 170);

        // NaviButton clicked
        public override Color ButtonClickedColor1 => Color.FromArgb(255, 211, 101);
        public override Color ButtonClickedColor2 => Color.FromArgb(251, 140, 60);
        public override Color ButtonClickedColor3 => Color.FromArgb(255, 173, 67);
        public override Color ButtonClickedColor4 => Color.FromArgb(255, 189, 105);

        // NaviClientArea
        public override Color NaviClientareaBgColor1 => Color.FromArgb(209, 214, 220);
        public override Color NaviClientareaBgColor2 => Color.FromArgb(231, 235, 239);

        // NaviCollapseButton Normal
        public override Color CollapseButtonNormalColor1 => Color.FromArgb(89, 135, 214);
        public override Color CollapseButtonNormalColor2 => Color.FromArgb(7, 59, 150);

        // NaviCollapseButton Hovered
        public override Color CollapseButtonHoveredColor1 => Color.FromArgb(248, 194, 94); // Dark
        public override Color CollapseButtonHoveredColor2 => Color.FromArgb(255, 255, 220); // Light

        // NaviCollapseButton Clicked
        public override Color CollapseButtonClickedColor1 => Color.FromArgb(232, 127, 8);
        public override Color CollapseButtonClickedColor2 => Color.FromArgb(247, 217, 121);

        // NaviCollapseButton
        public override Color ButtonCollapseFront => Color.FromArgb(255, 255, 255);
        public override Color ButtonCollapseActive => Color.FromArgb(0, 45, 150);

        // NaviGroup normal
        public override Color GroupColor1 => Color.FromArgb(196, 218, 250);
        public override Color GroupColor2 => Color.FromArgb(160, 191, 245);

        // NaviGroup hovered
        public override Color GroupHoveredColor1 => Color.FromArgb(196, 218, 250);
        public override Color GroupHoveredColor2 => Color.FromArgb(160, 191, 245);
        public override Color GroupBorderLight => Color.FromArgb(158, 190, 245);

        // Navigroup expanded
        public override Color GroupExpandedColor1 => Color.FromArgb(37, 37, 37);
        public override Color GroupExpandedColor2 => Color.FromArgb(98, 98, 98);

        // Splitter
        public override Color SplitterColor1 => Color.FromArgb(14, 66, 156);
        public override Color SplitterColor2 => Color.FromArgb(89, 135, 214);
        public override Color SplitterColor3 => Color.FromArgb(255, 255, 255);

        // TODO 
        //public override Color ButtonOptionsOuter { get { return Color.FromArgb(67, 113, 176); } }
        //public override Color ButtonOptionsInner { get { return Color.FromArgb(255, 248, 203); } }
    }
}