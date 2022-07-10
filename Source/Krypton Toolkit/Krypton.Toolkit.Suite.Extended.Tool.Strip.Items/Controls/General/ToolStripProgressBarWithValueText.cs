#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using static Krypton.Toolkit.Suite.Extended.Tool.Strip.Items.KryptonEnhancedToolStripProgressBar;

namespace Krypton.Toolkit.Suite.Extended.Tool.Strip.Items
{
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.StatusStrip), ToolboxBitmap(typeof(ToolStripProgressBar)), Description(@"")]
    public class ToolStripProgressBarWithValueText : ToolStripProgressBar
    {
        #region Instance Fields

        private bool _displayValue;

        private Color _displayTextColour;

        private IPalette _palette;

        #endregion

        #region Public

        public bool DisplayValue { get => _displayValue; set { _displayValue = value; Invalidate(); } }

        public Color DisplayTextColour { get => _displayTextColour; set => _displayTextColour = value; }

        #endregion

        #region Identity

        public ToolStripProgressBarWithValueText()
        {
            _displayTextColour = _palette.ColorTable.StatusStripText; 

            Font = _palette.ColorTable.StatusStripFont;

            Control.HandleCreated += Control_HandleCreated;
        }

        #endregion

        #region Implementation

        private void Control_HandleCreated(object sender, EventArgs e)
        {
            var s = new ProgressBarHandler((ProgressBar)Control, _displayValue, _displayTextColour);
        }

        #endregion

        #region ProgressBarHandler

        public class ProgressBarHandler : NativeWindow
        {
            #region Instance Fields

            private bool _useDisplayText;

            private Color _displayTextColour;

            private ProgressBar _progressBar;

            #endregion

            #region Identity

            public ProgressBarHandler(ProgressBar progressBar, bool useDisplayText, Color displayTextColour)
            {
                _progressBar = progressBar;

                _useDisplayText = useDisplayText;

                _displayTextColour = displayTextColour;

                AssignHandle(_progressBar.Handle);
            }

            #endregion

            #region Protected

            protected override void WndProc(ref Message m)
            {
                base.WndProc(ref m);

                if (_useDisplayText)
                {
                    if (m.Msg == 0xF)
                    {
                        using (var g = _progressBar.CreateGraphics())
                        {
                            TextRenderer.DrawText(g, $"{_progressBar.Value}", _progressBar.Font, _progressBar.ClientRectangle, _displayTextColour);
                        }
                    }
                }
            }

            #endregion
        }

        #endregion
    }
}
