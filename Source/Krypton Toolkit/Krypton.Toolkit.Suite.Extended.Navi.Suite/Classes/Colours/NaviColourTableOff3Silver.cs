#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Navi.Suite;

public class NaviColourTableOff3Silver : NaviColourTable
{
    // General colors 
    public override Color Border => Color.FromArgb(124, 124, 148);
    public override Color BorderInner => Color.FromArgb(255, 255, 255);
    public override Color Text => Color.FromArgb(0, 0, 0);
    public override Color ShapesFront => Color.FromArgb(86, 125, 177);
    public override Color Background => Color.FromArgb(255, 255, 255);

    // Designtime only
    public override Color DashedLineColor => Color.FromArgb(101, 147, 207);

    // NaviBandCollapsed
    public override Color BandCollapsedBgColor1 => Color.FromArgb(199, 198, 216);
    public override Color BandCollapsedBgColor2 => Color.FromArgb(209, 214, 220);
    public override Color BandCollapsedHoveredColor1 => Color.FromArgb(255, 231, 162);
    public override Color BandCollapsedClickedColor1 => Color.FromArgb(251, 140, 60);

    // NaviBand Popup
    public override Color PopupBandBackground1 => Color.FromArgb(227, 239, 255);
    public override Color PopupBandBackground2 => Color.FromArgb(227, 239, 255);

    // NaviBar header
    public override Color HeaderColor1 => Color.FromArgb(114, 113, 147);
    public override Color HeaderColor2 => Color.FromArgb(168, 167, 191);
    public override Color HeaderText => Color.FromArgb(255, 255, 255);

    // NaviBar Overflowpanel
    public override Color OverflowColor1 => Color.FromArgb(209, 214, 220);
    public override Color OverflowColor2 => Color.FromArgb(209, 214, 220);

    // NaviButton Normal
    public override Color ButtonNormalColor1 => Color.FromArgb(225, 226, 236);
    public override Color ButtonNormalColor2 => Color.FromArgb(149, 147, 177);
    public override Color ButtonNormalColor3 => Color.FromArgb(196, 221, 255); // Hightlight dark
    public override Color ButtonNormalColor4 => Color.FromArgb(227, 239, 255); // Highlight light

    // NaviButton hovered
    public override Color ButtonHoveredColor1 => Color.FromArgb(255, 230, 159);
    public override Color ButtonHoveredColor2 => Color.FromArgb(255, 215, 103);
    public override Color ButtonHoveredColor3 => Color.FromArgb(255, 233, 168);
    public override Color ButtonHoveredColor4 => Color.FromArgb(255, 254, 228);

    // NaviButton active
    public override Color ButtonActiveColor1 => Color.FromArgb(254, 225, 122);
    public override Color ButtonActiveColor2 => Color.FromArgb(255, 171, 63);
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
    public override Color CollapseButtonNormalColor1 => Color.FromArgb(168, 167, 191);
    public override Color CollapseButtonNormalColor2 => Color.FromArgb(114, 113, 147);

    // NaviCollapseButton Hovered
    public override Color CollapseButtonHoveredColor1 => Color.FromArgb(248, 194, 94); // Dark
    public override Color CollapseButtonHoveredColor2 => Color.FromArgb(255, 255, 220); // Light

    // NaviCollapseButton Clicked
    public override Color CollapseButtonClickedColor1 => Color.FromArgb(232, 127, 8);
    public override Color CollapseButtonClickedColor2 => Color.FromArgb(247, 217, 121);

    // NaviCollapseButton
    public override Color ButtonCollapseFront => Color.FromArgb(255, 248, 203);
    public override Color ButtonCollapseActive => Color.FromArgb(255, 248, 203);

    // NaviGroup normal
    public override Color GroupColor1 => Color.FromArgb(242, 244, 244);
    public override Color GroupColor2 => Color.FromArgb(213, 219, 231);

    // NaviGroup hovered
    public override Color GroupHoveredColor1 => Color.FromArgb(242, 244, 244);
    public override Color GroupHoveredColor2 => Color.FromArgb(213, 219, 231);
    public override Color GroupBorderLight => Color.FromArgb(197, 199, 199);

    // Navigroup expanded
    public override Color GroupExpandedColor1 => Color.FromArgb(37, 37, 37);
    public override Color GroupExpandedColor2 => Color.FromArgb(98, 98, 98);

    // Splitter
    public override Color SplitterColor1 => Color.FromArgb(119, 118, 151);
    public override Color SplitterColor2 => Color.FromArgb(168, 167, 191);
    public override Color SplitterColor3 => Color.FromArgb(255, 255, 255);
}