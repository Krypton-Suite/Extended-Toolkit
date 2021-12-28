#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Navi.Suite
{
    public class NaviColourTableOff10Silver : NaviColourTableOff7Blue
    {
        // General colors 
        public override Color Border { get { return Color.FromArgb(46, 46, 46); } }
        public override Color BorderInner { get { return Color.FromArgb(167, 167, 167); } }
        public override Color Text { get { return Color.FromArgb(255, 255, 255); } }
        public override Color ShapesFront { get { return Color.FromArgb(255, 255, 255); } }
        public override Color Background { get { return Color.FromArgb(80, 80, 80); } }

        // Designtime only
        public override Color DashedLineColor { get { return Color.FromArgb(101, 147, 207); } }

        // NaviBandCollapsed
        public override Color BandCollapsedBgColor1 { get { return Color.FromArgb(87, 87, 87); } }
        public override Color BandCollapsedBgColor2 { get { return Color.FromArgb(139, 139, 139); } }
        public override Color BandCollapsedHoveredColor1 { get { return Color.FromArgb(139, 139, 139); } }
        public override Color BandCollapsedClickedColor1 { get { return Color.FromArgb(139, 139, 139); } }

        // NaviBand Popup
        public override Color PopupBandBackground1 { get { return Color.FromArgb(87, 87, 87); } }
        public override Color PopupBandBackground2 { get { return Color.FromArgb(139, 139, 139); } }

        // NaviBar header
        public override Color HeaderColor1 { get { return Color.FromArgb(139, 139, 139); } }
        public override Color HeaderColor2 { get { return Color.FromArgb(227, 239, 255); } }
        public override Color HeaderText { get { return Color.FromArgb(255, 255, 255); } }

        // NaviBar Overflowpanel
        public override Color OverflowColor1 { get { return Color.FromArgb(80, 80, 80); } }
        public override Color OverflowColor2 { get { return Color.FromArgb(209, 214, 220); } }

        // NaviButton Normal
        public override Color ButtonNormalColor1 { get { return Color.FromArgb(80, 80, 80); } } // Light
        public override Color ButtonNormalColor2 { get { return Color.FromArgb(173, 209, 255); } } // Dark
        public override Color ButtonNormalColor3 { get { return Color.FromArgb(196, 221, 255); } } // Hightlight dark
        public override Color ButtonNormalColor4 { get { return Color.FromArgb(227, 239, 255); } } // Highlight light

        // NaviButton hovered
        public override Color ButtonHoveredColor1 { get { return Color.FromArgb(104, 104, 104); } }
        public override Color ButtonHoveredColor2 { get { return Color.FromArgb(82, 82, 82); } }
        public override Color ButtonHoveredColor3 { get { return Color.FromArgb(125, 125, 125); } }
        public override Color ButtonHoveredColor4 { get { return Color.FromArgb(255, 254, 228); } }

        // NaviButton active
        public override Color ButtonActiveColor1 { get { return Color.FromArgb(109, 109, 109); } }
        public override Color ButtonActiveColor2 { get { return Color.FromArgb(75, 75, 75); } }
        public override Color ButtonActiveColor3 { get { return Color.FromArgb(91, 91, 91); } }
        public override Color ButtonActiveColor4 { get { return Color.FromArgb(150, 150, 150); } }

        // NaviButton clicked
        public override Color ButtonClickedColor1 { get { return Color.FromArgb(62, 62, 62); } }
        public override Color ButtonClickedColor2 { get { return Color.FromArgb(72, 72, 72); } }
        public override Color ButtonClickedColor3 { get { return Color.FromArgb(72, 72, 72); } }
        public override Color ButtonClickedColor4 { get { return Color.FromArgb(255, 189, 105); } }

        // NaviClientArea
        public override Color NaviClientareaBgColor1 { get { return Color.FromArgb(80, 80, 80); } }
        public override Color NaviClientareaBgColor2 { get { return Color.FromArgb(139, 139, 139); } }

        // NaviCollapseButton Normal
        public override Color CollapseButtonNormalColor1 { get { return Color.FromArgb(232, 127, 8); } }
        public override Color CollapseButtonNormalColor2 { get { return Color.FromArgb(247, 217, 121); } }

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
        public override Color GroupColor1 { get { return Color.FromArgb(226, 238, 255); } }
        public override Color GroupColor2 { get { return Color.FromArgb(214, 232, 255); } }

        // NaviGroup hovered
        public override Color GroupHoveredColor1 { get { return Color.FromArgb(255, 255, 255); } }
        public override Color GroupHoveredColor2 { get { return Color.FromArgb(227, 239, 255); } }
        public override Color GroupBorderLight { get { return Color.FromArgb(173, 209, 255); } }

        // Navigroup expanded
        public override Color GroupExpandedColor1 { get { return Color.FromArgb(37, 37, 37); } }
        public override Color GroupExpandedColor2 { get { return Color.FromArgb(98, 98, 98); } }

        // Splitter
        public override Color SplitterColor1 { get { return Color.FromArgb(102, 102, 102); } }
        public override Color SplitterColor2 { get { return Color.FromArgb(79, 79, 79); } }
        public override Color SplitterColor3 { get { return Color.FromArgb(255, 255, 255); } }
    }
}