#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Tool.Strip.Items
{
    public class KryptonStatusStrip : StatusStrip
    {
        #region Variables
        private ToolStripProgressBar _progressBar;
        #endregion

        #region Properties
        public ToolStripProgressBar ProgressBar { get => _progressBar; set => _progressBar = value; }
        #endregion

        #region Constructor
        public KryptonStatusStrip()
        {

        }
        #endregion

        #region Overrides
        protected override void OnRendererChanged(EventArgs e)
        {
            if (ToolStripManager.Renderer is KryptonProfessionalRenderer kpr)
            {
                ProgressBar.BackColor = kpr.KCT.StatusStripGradientEnd;
            }

            base.OnRendererChanged(e);
        }
        #endregion
    }
}