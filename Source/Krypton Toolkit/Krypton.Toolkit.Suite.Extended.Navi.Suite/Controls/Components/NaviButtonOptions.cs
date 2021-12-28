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
    public partial class NaviButtonOptions : NaviButton
    {
        #region Overrides

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            Renderer.DrawOptionsTriangle(e.Graphics, ClientRectangle);
        }

        #endregion

        #region Event Handling
        #endregion
    }
}