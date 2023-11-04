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

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class PlotViewer : KryptonForm
    {
        #region Design Code
        private KryptonPanel kryptonPanel1;
        private FormsPlot fpViewer;

        private void InitializeComponent()
        {
            kryptonPanel1 = new KryptonPanel();
            fpViewer = new FormsPlot();
            ((ISupportInitialize)(kryptonPanel1)).BeginInit();
            kryptonPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // kryptonPanel1
            // 
            kryptonPanel1.Controls.Add(fpViewer);
            kryptonPanel1.Dock = DockStyle.Fill;
            kryptonPanel1.Location = new Point(0, 0);
            kryptonPanel1.Name = "kryptonPanel1";
            kryptonPanel1.Size = new Size(584, 361);
            kryptonPanel1.TabIndex = 0;
            // 
            // fpViewer
            // 
            fpViewer.BackColor = Color.Transparent;
            fpViewer.Dock = DockStyle.Fill;
            fpViewer.Location = new Point(0, 0);
            fpViewer.Name = "fpViewer";
            fpViewer.Size = new Size(584, 361);
            fpViewer.TabIndex = 1;
            // 
            // PlotViewer
            // 
            ClientSize = new Size(584, 361);
            Controls.Add(kryptonPanel1);
            Name = "PlotViewer";
            Text = "ScottPlot Viewer";
            ((ISupportInitialize)(kryptonPanel1)).EndInit();
            kryptonPanel1.ResumeLayout(false);
            ResumeLayout(false);

        }
        #endregion

        #region Property

        public FormsPlot Plot => fpViewer;

        #endregion

        #region Constructor

        public PlotViewer(Plot plot, int windowWidth = 600, int windowHeight = 400, string windowTitle = "ScottPlot Viewer")
        {
            InitializeComponent();

            Width = windowWidth;

            Height = windowHeight;

            Text = windowTitle;

            fpViewer.Reset(plot);

            fpViewer.Refresh();
        }

        #endregion
    }
}
