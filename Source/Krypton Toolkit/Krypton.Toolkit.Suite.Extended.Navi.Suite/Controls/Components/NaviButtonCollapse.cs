#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
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
            get { return collapsed; }
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