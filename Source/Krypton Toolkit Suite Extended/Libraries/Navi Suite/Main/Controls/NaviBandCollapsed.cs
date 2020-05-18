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

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.Navi.Suite
{
    /// <summary>
    /// This class represents a Band which is collapsed
    /// </summary>
    /// <remarks>
    /// The navigation pane contains one band which acts for all bands as the collapsed version. 
    /// The navigation pane brings the collapsed band to front when the user turns the navigation pane
    /// to collapsed mode. 
    /// </remarks>
    [
     Designer("Krypton.Toolkit.Extended.Navi.Suite.NaviBandDesigner, Krypton.Toolkit.Extended.Navi.Suite, Version=2.0.0.0, Culture=neutral, PublicKeyToken=86dab5aa2dd98116"),
     ToolboxItem(false)
    ]
    public partial class NaviBandCollapsed : NaviControl
    {
        #region Fields

        private Font headerFont;
        private InputState inputState;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the Navigation band
        /// </summary>
        public NaviBandCollapsed()
        {
            Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the Navigation band
        /// </summary>
        public NaviBandCollapsed(IContainer container)
        {
            container.Add(this);
            Initialize();
        }

        #endregion

        #region Properties
        #endregion

        #region Methods

        /// <summary>
        /// Initializes the control for the first time. 
        /// </summary>
        internal void Initialize()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, true);

            headerFont = new Font("Arial", 11F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            ResizeRedraw = true;
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Overriden. Raises the Paint event
        /// </summary>
        /// <param name="e">Additional paint info</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Renderer.DrawNaviBandCollapsedBg(e.Graphics, ClientRectangle, Text, headerFont,
            RightToLeft == RightToLeft.Yes, inputState);
        }

        /// <summary>
        /// Overriden. Raises the Resize event and Invalidates the control
        /// </summary>
        /// <param name="e">Additional mouse info</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }

        /// <summary>
        /// Overriden. Raises the TetChanged event
        /// </summary>
        /// <param name="e">Additional event info</param>
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }

        /// <summary>
        /// Overriden. Raises the PaintBackground
        /// </summary>
        /// <param name="pevent">Additional paint info</param>
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
        }

        /// <summary>
        /// Overriden. Raises the MouseEnter event
        /// </summary>
        /// <param name="e">Additional mouse info</param>
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            inputState = InputState.Hovered;
            Invalidate();
        }

        /// <summary>
        /// Overriden. Raises the MouseDown event
        /// </summary>
        /// <param name="e">Additional mouse info</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            inputState = InputState.Clicked;
            Invalidate();
        }

        /// <summary>
        /// Overriden. Raises the MouseUp event 
        /// </summary>
        /// <param name="e">Additional mouse info</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            inputState = InputState.Hovered;
            Invalidate();
        }

        /// <summary>
        /// Overriden. Raises the MouseLeave event
        /// </summary>
        /// <param name="e">Additional mouse info</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            inputState = InputState.Normal;
            Invalidate();
        }

        #endregion
    }
}