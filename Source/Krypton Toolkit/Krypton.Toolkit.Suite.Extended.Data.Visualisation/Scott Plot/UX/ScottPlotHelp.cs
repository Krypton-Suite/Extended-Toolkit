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
    public class ScottPlotHelp : KryptonForm
    {
        private KryptonPanel kryptonPanel1;
        private KryptonPanel kryptonPanel2;
        private KryptonBorderEdge kryptonBorderEdge1;
        private KryptonLabel kryptonLabel1;
        private KryptonButton kbtnOk;

        private void InitializeComponent()
        {
            kryptonPanel1 = new KryptonPanel();
            kbtnOk = new KryptonButton();
            kryptonPanel2 = new KryptonPanel();
            kryptonBorderEdge1 = new KryptonBorderEdge();
            kryptonLabel1 = new KryptonLabel();
            ((ISupportInitialize)(kryptonPanel1)).BeginInit();
            kryptonPanel1.SuspendLayout();
            ((ISupportInitialize)(kryptonPanel2)).BeginInit();
            kryptonPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // kryptonPanel1
            // 
            kryptonPanel1.Controls.Add(kryptonBorderEdge1);
            kryptonPanel1.Controls.Add(kbtnOk);
            kryptonPanel1.Dock = DockStyle.Bottom;
            kryptonPanel1.Location = new Point(0, 557);
            kryptonPanel1.Name = "kryptonPanel1";
            kryptonPanel1.PanelBackStyle = PaletteBackStyle.PanelAlternate;
            kryptonPanel1.Size = new Size(639, 55);
            kryptonPanel1.TabIndex = 1;
            // 
            // kbtnOk
            // 
            kbtnOk.DialogResult = DialogResult.OK;
            kbtnOk.Location = new Point(292, 18);
            kbtnOk.Name = "kbtnOk";
            kbtnOk.Size = new Size(54, 25);
            kbtnOk.TabIndex = 3;
            kbtnOk.Values.Text = "O&k";
            // 
            // kryptonPanel2
            // 
            kryptonPanel2.Controls.Add(kryptonLabel1);
            kryptonPanel2.Dock = DockStyle.Fill;
            kryptonPanel2.Location = new Point(0, 0);
            kryptonPanel2.Name = "kryptonPanel2";
            kryptonPanel2.Size = new Size(639, 557);
            kryptonPanel2.TabIndex = 2;
            // 
            // kryptonBorderEdge1
            // 
            kryptonBorderEdge1.BorderStyle = PaletteBorderStyle.HeaderSecondary;
            kryptonBorderEdge1.Dock = DockStyle.Top;
            kryptonBorderEdge1.Location = new Point(0, 0);
            kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            kryptonBorderEdge1.Size = new Size(639, 1);
            kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // kryptonLabel1
            // 
            kryptonLabel1.Dock = DockStyle.Fill;
            kryptonLabel1.Location = new Point(0, 0);
            kryptonLabel1.Name = "kryptonLabel1";
            kryptonLabel1.Size = new Size(639, 557);
            kryptonLabel1.TabIndex = 0;
            kryptonLabel1.Values.Text = "kryptonLabel1";
            // 
            // ScottPlotHelp
            // 
            ClientSize = new Size(639, 612);
            Controls.Add(kryptonPanel2);
            Controls.Add(kryptonPanel1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ScottPlotHelp";
            ShowInTaskbar = false;
            ((ISupportInitialize)(kryptonPanel1)).EndInit();
            kryptonPanel1.ResumeLayout(false);
            kryptonPanel1.PerformLayout();
            ((ISupportInitialize)(kryptonPanel2)).EndInit();
            kryptonPanel2.ResumeLayout(false);
            kryptonPanel2.PerformLayout();
            ResumeLayout(false);

        }
    }
}