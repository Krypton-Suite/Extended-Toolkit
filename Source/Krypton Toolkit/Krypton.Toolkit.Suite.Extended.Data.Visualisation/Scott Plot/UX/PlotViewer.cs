#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
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
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.fpViewer = new Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot.FormsPlot();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.fpViewer);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(584, 361);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // fpViewer
            // 
            this.fpViewer.BackColor = System.Drawing.Color.Transparent;
            this.fpViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpViewer.Location = new System.Drawing.Point(0, 0);
            this.fpViewer.Name = "fpViewer";
            this.fpViewer.Size = new System.Drawing.Size(584, 361);
            this.fpViewer.TabIndex = 1;
            // 
            // PlotViewer
            // 
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "PlotViewer";
            this.Text = "ScottPlot Viewer";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

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
