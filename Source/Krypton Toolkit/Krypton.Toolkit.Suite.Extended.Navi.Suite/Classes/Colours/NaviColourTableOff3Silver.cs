#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Navi.Suite
{
    public class NaviColourTableOff3Silver : NaviColourTable
    {
        // General colors 
        public override Color Border { get { return Color.FromArgb(124, 124, 148); } }
        public override Color BorderInner { get { return Color.FromArgb(255, 255, 255); } }
        public override Color Text { get { return Color.FromArgb(0, 0, 0); } }
        public override Color ShapesFront { get { return Color.FromArgb(86, 125, 177); } }
        public override Color Background { get { return Color.FromArgb(255, 255, 255); } }

        // Designtime only
        public override Color DashedLineColor { get { return Color.FromArgb(101, 147, 207); } }

        // NaviBandCollapsed
        public override Color BandCollapsedBgColor1 { get { return Color.FromArgb(199, 198, 216); } }
        public override Color BandCollapsedBgColor2 { get { return Color.FromArgb(209, 214, 220); } }
        public override Color BandCollapsedHoveredColor1 { get { return Color.FromArgb(255, 231, 162); } }
        public override Color BandCollapsedClickedColor1 { get { return Color.FromArgb(251, 140, 60); } }

        // NaviBand Popup
        public override Color PopupBandBackground1 { get { return Color.FromArgb(227, 239, 255); } }
        public override Color PopupBandBackground2 { get { return Color.FromArgb(227, 239, 255); } }

        // NaviBar header
        public override Color HeaderColor1 { get { return Color.FromArgb(114, 113, 147); } }
        public override Color HeaderColor2 { get { return Color.FromArgb(168, 167, 191); } }
        public override Color HeaderText { get { return Color.FromArgb(255, 255, 255); } }

        // NaviBar Overflowpanel
        public override Color OverflowColor1 { get { return Color.FromArgb(209, 214, 220); } }
        public override Color OverflowColor2 { get { return Color.FromArgb(209, 214, 220); } }

        // NaviButton Normal
        public override Color ButtonNormalColor1 { get { return Color.FromArgb(225, 226, 236); } }
        public override Color ButtonNormalColor2 { get { return Color.FromArgb(149, 147, 177); } }
        public override Color ButtonNormalColor3 { get { return Color.FromArgb(196, 221, 255); } } // Hightlight dark
        public override Color ButtonNormalColor4 { get { return Color.FromArgb(227, 239, 255); } } // Highlight light

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
        public override Color CollapseButtonNormalColor1 { get { return Color.FromArgb(168, 167, 191); } }
        public override Color CollapseButtonNormalColor2 { get { return Color.FromArgb(114, 113, 147); } }

        // NaviCollapseButton Hovered
        public override Color CollapseButtonHoveredColor1 { get { return Color.FromArgb(248, 194, 94); } } // Dark
        public override Color CollapseButtonHoveredColor2 { get { return Color.FromArgb(255, 255, 220); } } // Light

        // NaviCollapseButton Clicked
        public override Color CollapseButtonClickedColor1 { get { return Color.FromArgb(232, 127, 8); } }
        public override Color CollapseButtonClickedColor2 { get { return Color.FromArgb(247, 217, 121); } }

        // NaviCollapseButton
        public override Color ButtonCollapseFront { get { return Color.FromArgb(255, 248, 203); } }
        public override Color ButtonCollapseActive { get { return Color.FromArgb(255, 248, 203); } }

        // NaviGroup normal
        public override Color GroupColor1 { get { return Color.FromArgb(242, 244, 244); } }
        public override Color GroupColor2 { get { return Color.FromArgb(213, 219, 231); } }

        // NaviGroup hovered
        public override Color GroupHoveredColor1 { get { return Color.FromArgb(242, 244, 244); } }
        public override Color GroupHoveredColor2 { get { return Color.FromArgb(213, 219, 231); } }
        public override Color GroupBorderLight { get { return Color.FromArgb(197, 199, 199); } }

        // Navigroup expanded
        public override Color GroupExpandedColor1 { get { return Color.FromArgb(37, 37, 37); } }
        public override Color GroupExpandedColor2 { get { return Color.FromArgb(98, 98, 98); } }

        // Splitter
        public override Color SplitterColor1 { get { return Color.FromArgb(119, 118, 151); } }
        public override Color SplitterColor2 { get { return Color.FromArgb(168, 167, 191); } }
        public override Color SplitterColor3 { get { return Color.FromArgb(255, 255, 255); } }
    }
}