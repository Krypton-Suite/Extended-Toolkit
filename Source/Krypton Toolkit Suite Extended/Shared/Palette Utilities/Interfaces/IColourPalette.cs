using System;
using System.Drawing;

namespace Krypton.Toolkit.Extended.Palette.Utilities
{
    /// <summary>
    /// Aggregates all colours to be used in an custom palette configuration.
    /// </summary>
    public interface IColourPalette
    {
        Color TextLabelControl { get; set; }

        Color TextButtonNormal { get; set; }

        Color TextButtonChecked { get; set; }

        Color ButtonNormalBorder { get; set; }

        Color ButtonNormalDefaultBorder { get; set; }

        Color ButtonNormalBack1 { get; set; }

        Color ButtonNormalBack2 { get; set; }

        Color ButtonNormalDefaultBack1 { get; set; }

        Color ButtonNormalDefaultBack2 { get; set; }
        
		Color ButtonNormalNavigatorBack1 { get; set; }

        Color ButtonNormalNavigatorBack2 { get; set; }

        Color PanelClient { get; set; }

        Color PanelAlternative { get; set; }

        Color ControlBorder { get; set; }

        Color SeparatorHighBorder1 { get; set; }

        Color SeparatorHighBorder2 { get; set; }

        Color HeaderPrimaryBack1 { get; set; }
        
		Color HeaderPrimaryBack2 { get; set; }

        Color HeaderSecondaryBack1 { get; set; }

        Color HeaderSecondaryBack2 { get; set; }

        Color HeaderText { get; set; }

        Color StatusStripText { get; set; }
        
		Color ButtonBorder { get; set; }

        Color SeparatorLight { get; set; }

        Color SeparatorDark { get; set; }

        Color GripLight { get; set; }

        Color GripDark { get; set; }

        Color ToolStripBack { get; set; }

        Color StatusStripLight { get; set; }

        Color StatusStripDark { get; set; }

        Color ImageMargin { get; set; }

        Color ToolStripBegin { get; set; }

        Color ToolStripMiddle { get; set; }
        
		Color ToolStripEnd { get; set; }

        Color OverflowBegin { get; set; }

        Color OverflowMiddle { get; set; }

        Color OverflowEnd { get; set; }

        Color ToolStripBorder { get; set; }
        
		Color FormBorderActive { get; set; }

        Color FormBorderInactive { get; set; }

        Color FormBorderActiveLight { get; set; }

        Color FormBorderActiveDark { get; set; }

        Color FormBorderInactiveLight { get; set; }

        Color FormBorderInactiveDark { get; set; }

        Color FormBorderHeaderActive { get; set; }

        Color FormBorderHeaderInactive { get; set; }

        Color FormBorderHeaderActive1 { get; set; }

        Color FormBorderHeaderActive2 { get; set; }
 
        Color FormBorderHeaderInactive1 { get; set; }

        Color FormBorderHeaderInactive2 { get; set; }

        Color FormHeaderShortActive { get; set; }

        Color FormHeaderShortInactive { get; set; }

        Color FormHeaderLongActive { get; set; }

        Color FormHeaderLongInactive { get; set; }

        Color FormButtonBorderTrack { get; set; }

        Color FormButtonBack1Track { get; set; }

        Color FormButtonBack2Track { get; set; }

        Color FormButtonBorderPressed { get; set; }

        Color FormButtonBack1Pressed { get; set; }

        Color FormButtonBack2Pressed { get; set; }

        Color TextButtonFormNormal { get; set; }

        Color TextButtonFormTracking { get; set; }

        Color TextButtonFormPressed { get; set; }

        Color LinkNotVisitedOverrideControl { get; set; }

        Color LinkVisitedOverrideControl { get; set; }

        Color LinkPressedOverrideControl { get; set; }

        Color LinkNotVisitedOverridePanel { get; set; }

        Color LinkVisitedOverridePanel { get; set; }

        Color LinkPressedOverridePanel { get; set; }

        Color TextLabelPanel { get; set; }

        Color RibbonTabTextNormal { get; set; }

        Color RibbonTabTextChecked { get; set; }

        Color RibbonTabSelected1 { get; set; }

        Color RibbonTabSelected2 { get; set; }

        Color RibbonTabSelected3 { get; set; }

        Color RibbonTabSelected4 { get; set; }

        Color RibbonTabSelected5 { get; set; }

        Color RibbonTabTracking1 { get; set; }

        Color RibbonTabTracking2 { get; set; }

        Color RibbonTabHighlight1 { get; set; }

        Color RibbonTabHighlight2 { get; set; }

        Color RibbonTabHighlight3 { get; set; }

        Color RibbonTabHighlight4 { get; set; }

        Color RibbonTabHighlight5 { get; set; }

        Color RibbonTabSeparatorColour { get; set; }

        Color RibbonGroupsArea1 { get; set; }

        Color RibbonGroupsArea2 { get; set; }

        Color RibbonGroupsArea3 { get; set; }

        Color RibbonGroupsArea4 { get; set; }

        Color RibbonGroupsArea5 { get; set; }

        Color RibbonGroupBorder1 { get; set; }

        Color RibbonGroupBorder2 { get; set; }

        Color RibbonGroupTitle1 { get; set; }

        Color RibbonGroupTitle2 { get; set; }

        Color RibbonGroupBorderContext1 { get; set; }

        Color RibbonGroupBorderContext2 { get; set; }

        Color RibbonGroupTitleContext1 { get; set; }

        Color RibbonGroupTitleContext2 { get; set; }

        Color RibbonGroupDialogDark { get; set; }

        Color RibbonGroupDialogLight { get; set; }

        Color RibbonGroupTitleTracking1 { get; set; }

        Color RibbonGroupTitleTracking2 { get; set; }

        RibbonMinimizeBarDark = 102,
        RibbonMinimizeBarLight = 103,
        RibbonGroupCollapsedBorder1 = 104,
        RibbonGroupCollapsedBorder2 = 105,
        RibbonGroupCollapsedBorder3 = 106,

        RibbonGroupCollapsedBorder4 = 107,
        RibbonGroupCollapsedBack1 = 108,
        RibbonGroupCollapsedBack2 = 109,
        RibbonGroupCollapsedBack3 = 110,
        RibbonGroupCollapsedBack4 = 111,

        RibbonGroupCollapsedBorderT1 = 112,
        RibbonGroupCollapsedBorderT2 = 113,
        RibbonGroupCollapsedBorderT3 = 114,
        RibbonGroupCollapsedBorderT4 = 115,
        RibbonGroupCollapsedBackT1 = 116,

        RibbonGroupCollapsedBackT2 = 117,
        RibbonGroupCollapsedBackT3 = 118,
        RibbonGroupCollapsedBackT4 = 119,
        RibbonGroupFrameBorder1 = 120,
        RibbonGroupFrameBorder2 = 121,
    }
}