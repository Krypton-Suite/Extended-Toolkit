#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Navi.Suite
{
    /// <summary>
    /// Indicates in what state the control currently is. 
    /// </summary>
    public enum ControlState
    {
        /// <summary>
        /// Indicates that the control is in it's normal state
        /// </summary>
        Normal,

        /// <summary>
        /// Indicates that the control is the active control
        /// </summary>
        Active,

        /// <summary>
        /// Indicates that the control is the focused control
        /// </summary>
        Focused
    }

    /// <summary>
    /// Indicates what input has been given to the control
    /// </summary>
    public enum InputState
    {
        /// <summary>
        /// Indicates that no input has been given
        /// </summary>
        Normal,

        /// <summary>
        /// Indicates that the user is currently clicking on the control
        /// </summary>
        Clicked,

        /// <summary>
        /// Indicates that the user is currently hovering the control with the mouse
        /// </summary>
        Hovered
    }

    /// <summary>
    /// Indicates how a control is presented to the user. 
    /// </summary>
    public enum NaviLayoutStyle
    {
        StyleFromOwner,

        /// <summary>
        /// Presents the control in the Blue Office 2003 colour and layout style
        /// </summary>
        Office2003Blue,

        /// <summary>
        /// Presents the control in the Green Office 2003 colour and layout style
        /// </summary>
        Office2003Green,

        /// <summary>
        /// Presents the control in the Silver Office 2003 colour and layout style
        /// </summary>
        Office2003Silver,

        /// <summary>
        /// Indicates that the control should be presented as the blue Ms Office 2007 Navigation pane
        /// </summary>
        Office2007Blue,

        /// <summary>
        /// Indicates that the control should be presented as the silver Ms Office 2007 Navigation pane
        /// </summary>
        Office2007Silver,

        /// <summary>
        /// Indicates that the control should be presented as the black Ms Office 2007 Navigation pane
        /// </summary>
        Office2007Black,

        /// <summary>
        /// Indicates that the control should be presented as the blue Ms Office 2010 Navigation pane
        /// </summary>
        Office2010Blue,

        /// <summary>
        /// Indicates that the control should be presented as the silver Ms Office 2010 Navigation pane
        /// </summary>
        Office2010Silver,

        /// <summary>
        /// Indicates that the control should be presented as the black Ms Office 2010 Navigation pane
        /// </summary>
        Office2010Black,
    }
}