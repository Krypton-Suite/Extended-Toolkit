﻿#region MIT License
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

namespace Krypton.Toolkit.Suite.Extended.Drawing.Utilities
{
    public class ColourGridUI : UserControl
    {
        #region Design Code
        private Panel panel1;
        private KryptonButton kbtnOpenPalette;
        private Panel panel2;
        private KryptonButton kbtnSavePalette;
        private Cyotek.Windows.Forms.ColorGrid cgColour;

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cgColour = new Cyotek.Windows.Forms.ColorGrid();
            this.kbtnOpenPalette = new Krypton.Toolkit.KryptonButton();
            this.kbtnSavePalette = new Krypton.Toolkit.KryptonButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.kbtnSavePalette);
            this.panel1.Controls.Add(this.kbtnOpenPalette);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(247, 25);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.cgColour);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(247, 162);
            this.panel2.TabIndex = 1;
            // 
            // cgColour
            // 
            this.cgColour.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cgColour.Location = new System.Drawing.Point(0, 0);
            this.cgColour.Name = "cgColour";
            this.cgColour.Size = new System.Drawing.Size(247, 165);
            this.cgColour.TabIndex = 0;
            // 
            // kbtnOpenPalette
            // 
            this.kbtnOpenPalette.AutoSize = true;
            this.kbtnOpenPalette.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnOpenPalette.Location = new System.Drawing.Point(0, 0);
            this.kbtnOpenPalette.Name = "kbtnOpenPalette";
            this.kbtnOpenPalette.Size = new System.Drawing.Size(22, 22);
            this.kbtnOpenPalette.TabIndex = 0;
            this.kbtnOpenPalette.ToolTipValues.Description = "Open a custom palette.";
            this.kbtnOpenPalette.ToolTipValues.EnableToolTips = true;
            this.kbtnOpenPalette.ToolTipValues.Heading = "Open Palette";
            this.kbtnOpenPalette.ToolTipValues.Image = global::Krypton.Toolkit.Suite.Extended.Drawing.Utilities.Properties.Resources.palette_load;
            this.kbtnOpenPalette.Values.Image = global::Krypton.Toolkit.Suite.Extended.Drawing.Utilities.Properties.Resources.palette_load;
            this.kbtnOpenPalette.Values.Text = "";
            // 
            // kbtnSavePalette
            // 
            this.kbtnSavePalette.AutoSize = true;
            this.kbtnSavePalette.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnSavePalette.Location = new System.Drawing.Point(28, 0);
            this.kbtnSavePalette.Name = "kbtnSavePalette";
            this.kbtnSavePalette.Size = new System.Drawing.Size(22, 22);
            this.kbtnSavePalette.TabIndex = 1;
            this.kbtnSavePalette.ToolTipValues.Description = "Save a custom palette.";
            this.kbtnSavePalette.ToolTipValues.EnableToolTips = true;
            this.kbtnSavePalette.ToolTipValues.Heading = "Save Palette";
            this.kbtnSavePalette.ToolTipValues.Image = global::Krypton.Toolkit.Suite.Extended.Drawing.Utilities.Properties.Resources.palette_save;
            this.kbtnSavePalette.Values.Image = global::Krypton.Toolkit.Suite.Extended.Drawing.Utilities.Properties.Resources.palette_save;
            this.kbtnSavePalette.Values.Text = "";
            // 
            // ColourGridUI
            // 
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ColourGridUI";
            this.Size = new System.Drawing.Size(247, 187);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private bool _showButtonToolTips;
        #endregion

        #region Properties
        [DefaultValue(true)]
        public bool ShowButtonToolTips { get => _showButtonToolTips; set { _showButtonToolTips = value; Invalidate(); } }

        public ColorGrid ColourGrid => cgColour;

        #endregion

        #region Constructor
        public ColourGridUI()
        {
            InitializeComponent();
        }
        #endregion
    }
}
