#region License and Copyright
/*
 
Copyright (c) Guifreaks - Jacob Mesu
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are met:
    * Redistributions of source code must retain the above copyright
      notice, this list of conditions and the following disclaimer.
    * Redistributions in binary form must reproduce the above copyright
      notice, this list of conditions and the following disclaimer in the
      documentation and/or other materials provided with the distribution.
    * Neither the name of the Guifreaks nor the
      names of its contributors may be used to endorse or promote products
      derived from this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
DISCLAIMED. IN NO EVENT SHALL <COPYRIGHT HOLDER> BE LIABLE FOR ANY
DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
(INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
(INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

*/
#endregion

using System.Drawing;

namespace Krypton.Toolkit.Extended.Navi.Suite
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