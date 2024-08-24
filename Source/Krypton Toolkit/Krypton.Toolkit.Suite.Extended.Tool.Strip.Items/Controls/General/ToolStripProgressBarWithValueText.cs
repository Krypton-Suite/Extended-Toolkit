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
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.StatusStrip), ToolboxBitmap(typeof(ToolStripProgressBar)), Description(@"")]
    public class ToolStripProgressBarWithValueText : ToolStripProgressBar
    {
        #region Instance Fields

        private bool _displayValue;

        private Color _displayTextColour;

        // ReSharper disable PrivateFieldCanBeConvertedToLocalVariable
        private readonly PaletteBase _palette;
        // ReSharper restore PrivateFieldCanBeConvertedToLocalVariable

        #endregion

        #region Public

        public bool DisplayValue { get => _displayValue; set { _displayValue = value; Invalidate(); } }

        public Color DisplayTextColour { get => _displayTextColour; set => _displayTextColour = value; }

        #endregion

        #region Identity

        public ToolStripProgressBarWithValueText(PaletteBase palette)
        {
            _palette = palette;
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

            private readonly bool _useDisplayText;

            private readonly Color _displayTextColour;

            private readonly ProgressBar _progressBar;

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
