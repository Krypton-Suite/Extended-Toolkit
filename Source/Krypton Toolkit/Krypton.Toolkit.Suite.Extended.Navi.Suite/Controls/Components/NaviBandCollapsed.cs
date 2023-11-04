﻿#region MIT License
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

namespace Krypton.Toolkit.Suite.Extended.Navi.Suite
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
     Designer("Krypton.Toolkit.Suite.Extended.Navi.Suite.NaviBandDesigner, Krypton.Toolkit.Suite.Extended.Navi.Suite, Version=2.0.0.0, Culture=neutral, PublicKeyToken=86dab5aa2dd98116"),
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
        /// <param name="e">Additional paint info</param>
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