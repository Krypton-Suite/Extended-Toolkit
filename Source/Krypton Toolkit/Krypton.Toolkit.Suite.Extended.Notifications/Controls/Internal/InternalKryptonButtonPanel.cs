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

namespace Krypton.Toolkit.Suite.Extended.Notifications;

[ToolboxItem(false)]
public class InternalKryptonButtonPanel : UserControl
{
    private KryptonBorderEdge kbeBorder;
    private KryptonPanel kryptonPanel1;

    private void InitializeComponent()
    {
        this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
        this.kbeBorder = new Krypton.Toolkit.KryptonBorderEdge();
        ((System.ComponentModel.ISupportInitialize)this.kryptonPanel1).BeginInit();
        this.kryptonPanel1.SuspendLayout();
        this.SuspendLayout();
        // 
        // kryptonPanel1
        // 
        this.kryptonPanel1.Controls.Add(this.kbeBorder);
        this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
        this.kryptonPanel1.Name = "kryptonPanel1";
        this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
        this.kryptonPanel1.Size = new System.Drawing.Size(563, 50);
        this.kryptonPanel1.TabIndex = 0;
        // 
        // kbeBorder
        // 
        this.kbeBorder.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderPrimary;
        this.kbeBorder.Dock = System.Windows.Forms.DockStyle.Top;
        this.kbeBorder.Location = new System.Drawing.Point(0, 0);
        this.kbeBorder.Name = "kbeBorder";
        this.kbeBorder.Size = new System.Drawing.Size(563, 1);
        this.kbeBorder.Text = "kryptonBorderEdge1";
        // 
        // KryptonButtonPanel
        // 
        this.BackColor = System.Drawing.Color.Transparent;
        this.Controls.Add(this.kryptonPanel1);
        this.Name = "KryptonButtonPanel";
        this.Size = new System.Drawing.Size(563, 50);
        ((System.ComponentModel.ISupportInitialize)this.kryptonPanel1).EndInit();
        this.kryptonPanel1.ResumeLayout(false);
        this.kryptonPanel1.PerformLayout();
        this.ResumeLayout(false);

    }
}