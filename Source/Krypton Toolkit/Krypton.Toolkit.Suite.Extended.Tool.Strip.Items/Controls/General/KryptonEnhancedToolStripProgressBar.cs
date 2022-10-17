#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Tool.Strip.Items
{
    /// <summary>
    /// Additions from: https://stackoverflow.com/questions/43138097/show-text-on-progressbar-in-statusstrip
    /// </summary>
    /// <seealso cref="System.Windows.Forms.ToolStripProgressBar" />
    [Description(""), ToolboxBitmap(typeof(ToolStripProgressBar)), ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.All)]
    public class KryptonEnhancedToolStripProgressBar : ToolStripProgressBar
    {
        #region Variables
        private bool _useKryptonRender, _useDisplayText;

        private Color _displayTextColour;

        private IPalette _palette;
        #endregion

        #region Properties
        [DefaultValue(false)]
        public bool UseKryptonRender { get => _useKryptonRender; set { _useKryptonRender = value; Invalidate(); } }

        [DefaultValue(false)]
        public bool UseDisplayText { get => _useDisplayText; set => _useDisplayText = value; }

        [DefaultValue(typeof(Color), "Color.Black")]
        public Color DisplayTextColour { get => _displayTextColour; set => _displayTextColour = value; }
        #endregion

        #region Constructor

        /// <summary>Initializes a new instance of the <see cref="KryptonEnhancedToolStripProgressBar" /> class.</summary>
        public KryptonEnhancedToolStripProgressBar() : base()
        {
            _displayTextColour = _palette.ColorTable.StatusStripText;

            Font = _palette.ColorTable.StatusStripFont;

            Control.HandleCreated += Control_HandleCreated;
        }

        #endregion

        #region Implementation

        private void Control_HandleCreated(object sender, EventArgs e)
        {
            //var s = new ProgressBarHandler((ProgressBar) Control, _useDisplayText, _displayTextColour);
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