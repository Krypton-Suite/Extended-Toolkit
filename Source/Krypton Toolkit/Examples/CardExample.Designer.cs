#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
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
 */
#endregion

namespace Examples;

partial class CardExample
{
    private System.ComponentModel.IContainer components = null!;
    private KryptonPanel _panel = null!;
    private FlowLayoutPanel _flowPanel = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            components?.Dispose();
        }

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        _panel = new KryptonPanel();
        _flowPanel = new FlowLayoutPanel();
        ((System.ComponentModel.ISupportInitialize)_panel).BeginInit();
        _panel.SuspendLayout();
        SuspendLayout();
        //
        // _flowPanel
        //
        _flowPanel.AutoScroll = true;
        _flowPanel.Dock = DockStyle.Fill;
        _flowPanel.FlowDirection = FlowDirection.LeftToRight;
        _flowPanel.WrapContents = true;
        _flowPanel.Padding = new Padding(8);
        //
        // _panel
        //
        _panel.Controls.Add(_flowPanel);
        _panel.Dock = DockStyle.Fill;
        _panel.Location = new Point(0, 0);
        _panel.Name = "_panel";
        _panel.PanelBackStyle = PaletteBackStyle.PanelClient;
        _panel.Size = new Size(784, 461);
        _panel.TabIndex = 0;
        //
        // CardExample
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(784, 461);
        Controls.Add(_panel);
        MinimumSize = new Size(640, 420);
        Name = "CardExample";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "KryptonCard Examples";
        ((System.ComponentModel.ISupportInitialize)_panel).EndInit();
        _panel.ResumeLayout(false);
        ResumeLayout(false);
    }
}
