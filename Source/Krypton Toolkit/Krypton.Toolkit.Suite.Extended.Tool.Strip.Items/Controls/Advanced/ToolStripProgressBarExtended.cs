#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Tool.Strip.Items
{
    /// <summary>Code from: https://stackoverflow.com/questions/43138097/show-text-on-progressbar-in-statusstrip</summary>
    /// <seealso cref="System.Windows.Forms.ToolStripProgressBar" />
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.All)]
    public class ToolStripProgressBarExtended : ToolStripProgressBar
    {
        private string _displayText;

        public string DisplayText
        {
            get => _displayText;

            set => _displayText = value;
        }

        public ToolStripProgressBarExtended() : base()
        {
            Control.HandleCreated += Control_HandleCreated;
        }

        private void Control_HandleCreated(object sender, EventArgs e)
        {
            var s = new ProgressBarHelper((ProgressBar) Control, _displayText);
        }

        public class ProgressBarHelper : NativeWindow
        {
            private string _displyText;

            private ProgressBar _progressBar;

            public ProgressBarHelper(ProgressBar progressBar, string displyText)
            {
                _progressBar = progressBar;

                _displyText = displyText;

                AssignHandle(_progressBar.Handle);
            }

            protected override void WndProc(ref Message m)
            {
                base.WndProc(ref m);

                if (m.Msg == 0xF)
                {
                    using (var g = _progressBar.CreateGraphics())
                    {
                        TextRenderer.DrawText(g, $"{_displyText}", _progressBar.Font, _progressBar.ClientRectangle, _progressBar.ForeColor);
                    }
                }
            }
        }
    }
}