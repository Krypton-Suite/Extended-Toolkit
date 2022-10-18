﻿#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Navi.Suite
{
    public abstract class NaviColourTable
    {
        // General colors 
        public abstract Color Border { get; }
        public abstract Color BorderInner { get; }
        public abstract Color Text { get; }
        public abstract Color ShapesFront { get; }
        public abstract Color Background { get; }

        // Designtime only
        public abstract Color DashedLineColor { get; }

        // NaviBandCollapsed 
        public abstract Color BandCollapsedBgColor1 { get; }
        public abstract Color BandCollapsedBgColor2 { get; }

        // NaviBandCollapsed hovered
        public abstract Color BandCollapsedHoveredColor1 { get; }

        // NaviBandCollapsed clicked
        public abstract Color BandCollapsedClickedColor1 { get; }

        // NaviBand Popup
        public abstract Color PopupBandBackground1 { get; }
        public abstract Color PopupBandBackground2 { get; }

        // NaviBar header
        public abstract Color HeaderColor1 { get; }
        public abstract Color HeaderColor2 { get; }
        public abstract Color HeaderText { get; }

        // NaviBar Overflowpanel
        public abstract Color OverflowColor1 { get; }
        public abstract Color OverflowColor2 { get; }

        // NaviButton Normal
        public abstract Color ButtonNormalColor1 { get; }
        public abstract Color ButtonNormalColor2 { get; }
        public abstract Color ButtonNormalColor3 { get; }
        public abstract Color ButtonNormalColor4 { get; }

        // NaviButton hovered
        public abstract Color ButtonHoveredColor1 { get; }
        public abstract Color ButtonHoveredColor2 { get; }
        public abstract Color ButtonHoveredColor3 { get; }
        public abstract Color ButtonHoveredColor4 { get; }

        // NaviButton active
        public abstract Color ButtonActiveColor1 { get; }
        public abstract Color ButtonActiveColor2 { get; }
        public abstract Color ButtonActiveColor3 { get; }
        public abstract Color ButtonActiveColor4 { get; }

        // NaviButton clicked
        public abstract Color ButtonClickedColor1 { get; }
        public abstract Color ButtonClickedColor2 { get; }
        public abstract Color ButtonClickedColor3 { get; }
        public abstract Color ButtonClickedColor4 { get; }

        // NaviClientArea
        public abstract Color NaviClientareaBgColor1 { get; }
        public abstract Color NaviClientareaBgColor2 { get; }

        // NaviCollapseButton Normal
        public abstract Color CollapseButtonNormalColor1 { get; }
        public abstract Color CollapseButtonNormalColor2 { get; }

        // NaviCollapseButton Hovered
        public abstract Color CollapseButtonHoveredColor1 { get; }
        public abstract Color CollapseButtonHoveredColor2 { get; }

        // NaviCollapseButton Clicked
        public abstract Color CollapseButtonClickedColor1 { get; }
        public abstract Color CollapseButtonClickedColor2 { get; }

        public abstract Color ButtonCollapseFront { get; }
        public abstract Color ButtonCollapseActive { get; }

        // NaviGroup normal
        public abstract Color GroupColor1 { get; }
        public abstract Color GroupColor2 { get; }

        // NaviGroup hovered
        public abstract Color GroupHoveredColor1 { get; }
        public abstract Color GroupHoveredColor2 { get; }
        public abstract Color GroupBorderLight { get; }

        // NaviGroup expanded
        public abstract Color GroupExpandedColor1 { get; }
        public abstract Color GroupExpandedColor2 { get; }

        // NaviSplitter
        public abstract Color SplitterColor1 { get; }
        public abstract Color SplitterColor2 { get; }
        public abstract Color SplitterColor3 { get; }
    }
}