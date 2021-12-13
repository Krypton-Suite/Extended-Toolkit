#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Navi.Suite
{
    public class NaviColourTableOff7Black : NaviColourTable
    {
        // General colors 
        public override Color Border { get { return Color.FromArgb(167, 173, 182); } }
        public override Color BorderInner { get { return Color.FromArgb(255, 255, 255); } }
        public override Color Text { get { return Color.FromArgb(0, 0, 0); } }
        public override Color ShapesFront { get { return Color.FromArgb(49, 52, 49); } }
        public override Color Background { get { return Color.FromArgb(255, 255, 255); } }

        // Designtime only
        public override Color DashedLineColor { get { return Color.FromArgb(101, 147, 207); } }

        // NaviBandCollapsed
        public override Color BandCollapsedBgColor1 { get { return Color.FromArgb(235, 235, 235); } }
        public override Color BandCollapsedBgColor2 { get { return Color.FromArgb(209, 214, 220); } }
        public override Color BandCollapsedHoveredColor1 { get { return Color.FromArgb(255, 231, 162); } }
        public override Color BandCollapsedClickedColor1 { get { return Color.FromArgb(251, 140, 60); } }

        // NaviBand Popup
        public override Color PopupBandBackground1 { get { return Color.FromArgb(240, 241, 242); } }
        public override Color PopupBandBackground2 { get { return Color.FromArgb(227, 239, 255); } }

        // NaviBar header
        public override Color HeaderColor1 { get { return Color.FromArgb(189, 193, 200); } }
        public override Color HeaderColor2 { get { return Color.FromArgb(240, 241, 242); } }
        public override Color HeaderText { get { return Color.FromArgb(0, 0, 0); } }

        // NaviBar Overflowpanel
        public override Color OverflowColor1 { get { return Color.FromArgb(209, 214, 220); } }
        public override Color OverflowColor2 { get { return Color.FromArgb(209, 214, 220); } }

        // NaviButton Normal
        public override Color ButtonNormalColor1 { get { return Color.FromArgb(219, 222, 226); } }
        public override Color ButtonNormalColor2 { get { return Color.FromArgb(199, 203, 209); } }
        public override Color ButtonNormalColor3 { get { return Color.FromArgb(223, 226, 228); } }
        public override Color ButtonNormalColor4 { get { return Color.FromArgb(248, 248, 249); } }

        // NaviButton hovered
        public override Color ButtonHoveredColor1 { get { return Color.FromArgb(255, 230, 159); } }
        public override Color ButtonHoveredColor2 { get { return Color.FromArgb(255, 215, 103); } }
        public override Color ButtonHoveredColor3 { get { return Color.FromArgb(255, 233, 168); } }
        public override Color ButtonHoveredColor4 { get { return Color.FromArgb(255, 254, 228); } }

        // NaviButton active
        public override Color ButtonActiveColor1 { get { return Color.FromArgb(254, 225, 122); } }
        public override Color ButtonActiveColor2 { get { return Color.FromArgb(255, 171, 63); } }
        public override Color ButtonActiveColor3 { get { return Color.FromArgb(255, 188, 111); } }
        public override Color ButtonActiveColor4 { get { return Color.FromArgb(255, 217, 170); } }

        // NaviButton clicked
        public override Color ButtonClickedColor1 { get { return Color.FromArgb(255, 211, 101); } }
        public override Color ButtonClickedColor2 { get { return Color.FromArgb(251, 140, 60); } }
        public override Color ButtonClickedColor3 { get { return Color.FromArgb(255, 173, 67); } }
        public override Color ButtonClickedColor4 { get { return Color.FromArgb(255, 189, 105); } }

        // NaviClientArea
        public override Color NaviClientareaBgColor1 { get { return Color.FromArgb(209, 214, 220); } }
        public override Color NaviClientareaBgColor2 { get { return Color.FromArgb(231, 235, 239); } }

        // NaviCollapseButton Normal
        public override Color CollapseButtonNormalColor1 { get { return Color.FromArgb(240, 241, 242); } }
        public override Color CollapseButtonNormalColor2 { get { return Color.FromArgb(189, 193, 200); } }

        // NaviCollapseButton Hovered
        public override Color CollapseButtonHoveredColor1 { get { return Color.FromArgb(248, 194, 94); } } // Dark
        public override Color CollapseButtonHoveredColor2 { get { return Color.FromArgb(255, 255, 220); } } // Light

        // NaviCollapseButton Clicked
        public override Color CollapseButtonClickedColor1 { get { return Color.FromArgb(232, 127, 8); } }
        public override Color CollapseButtonClickedColor2 { get { return Color.FromArgb(247, 217, 121); } }

        // NaviCollapseButton button
        public override Color ButtonCollapseFront { get { return Color.FromArgb(255, 248, 203); } }
        public override Color ButtonCollapseActive { get { return Color.FromArgb(255, 248, 203); } }

        // NaviGroup normal
        public override Color GroupColor1 { get { return Color.FromArgb(239, 240, 241); } }
        public override Color GroupColor2 { get { return Color.FromArgb(221, 224, 227); } }

        // NaviGroup hovered
        public override Color GroupHoveredColor1 { get { return Color.FromArgb(255, 255, 255); } }
        public override Color GroupHoveredColor2 { get { return Color.FromArgb(232, 234, 236); } }
        public override Color GroupBorderLight { get { return Color.FromArgb(199, 203, 209); } }

        // Navigroup expanded
        public override Color GroupExpandedColor1 { get { return Color.FromArgb(37, 37, 37); } }
        public override Color GroupExpandedColor2 { get { return Color.FromArgb(98, 98, 98); } }

        // Splitter
        public override Color SplitterColor1 { get { return Color.FromArgb(195, 200, 206); } }
        public override Color SplitterColor2 { get { return Color.FromArgb(255, 255, 255); } }
        public override Color SplitterColor3 { get { return Color.FromArgb(255, 255, 255); } }
    }
}