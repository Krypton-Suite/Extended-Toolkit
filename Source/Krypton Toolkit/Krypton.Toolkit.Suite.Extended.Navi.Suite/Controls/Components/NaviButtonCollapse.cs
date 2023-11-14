#region MIT License
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
    [ToolboxItem(false)]
    public partial class NaviButtonCollapse : NaviButton
    {
        // Fields
        private bool collapsed;

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the NavigationBarButton
        /// </summary>
        public NaviButtonCollapse()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets whether the buttons should be drawn in minimized mode or not
        /// </summary>
        [
        Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        ]
        public override bool Collapsed
        {
            get => collapsed;
            set
            {
                // We need an explicit override with Invalidate otherwise the control is not 
                // invalidated properly. 
                collapsed = value;
                Invalidate();
            }
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
            Renderer.DrawButtonCollapseBg(e.Graphics, ClientRectangle, inputState,
               RightToLeft == RightToLeft.Yes, collapsed);
        }

        #endregion
    }
}