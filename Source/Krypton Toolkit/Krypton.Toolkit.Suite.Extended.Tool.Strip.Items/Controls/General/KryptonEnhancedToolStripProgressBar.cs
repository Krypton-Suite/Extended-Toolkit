#region MIT License
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

        private PaletteBase _palette;
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