#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Tool.Strip.Items
{
    [Description(""), ToolboxBitmap(typeof(ToolStripProgressBar)), ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.All)]
    public class KryptonEnhancedToolStripProgressBar : ToolStripProgressBar
    {
        #region Variables
        private bool _useKryptonRender;
        #endregion

        #region Properties
        [DefaultValue(false)]
        public bool UseKryptonRender { get => _useKryptonRender; set { _useKryptonRender = value; Invalidate(); } }
        #endregion

        #region Constructor
        public KryptonEnhancedToolStripProgressBar()
        {

        }
        #endregion

        #region Overrides
        protected override void OnPaint(PaintEventArgs e)
        {
            if (_useKryptonRender)
            {
                if (ToolStripManager.Renderer is KryptonProfessionalRenderer kpr)
                {
                    BackColor = kpr.KCT.StatusStripGradientEnd;
                }
            }

            base.OnPaint(e);
        }
        #endregion
    }
}