#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Drawing.Utilities
{
    public class ColourGridUserControl : UserControl
    {
        #region Designer Code
        private Panel panel1;
        private KryptonButton kbtnSavePalette;
        private Panel panel2;
        private Cyotek.Windows.Forms.ColorGrid cgColour;
        private KryptonButton kbtnOpenPalette;

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.kbtnOpenPalette = new Krypton.Toolkit.KryptonButton();
            this.kbtnSavePalette = new Krypton.Toolkit.KryptonButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cgColour = new Cyotek.Windows.Forms.ColorGrid();
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
            this.panel1.Size = new System.Drawing.Size(249, 24);
            this.panel1.TabIndex = 0;
            // 
            // kbtnOpenPalette
            // 
            this.kbtnOpenPalette.AutoSize = true;
            this.kbtnOpenPalette.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnOpenPalette.Location = new System.Drawing.Point(0, 0);
            this.kbtnOpenPalette.Name = "kbtnOpenPalette";
            this.kbtnOpenPalette.Size = new System.Drawing.Size(22, 22);
            this.kbtnOpenPalette.TabIndex = 0;
            this.kbtnOpenPalette.ToolTipValues.Description = "Load a custom palette.";
            this.kbtnOpenPalette.ToolTipValues.EnableToolTips = true;
            this.kbtnOpenPalette.ToolTipValues.Heading = "Load Palette";
            this.kbtnOpenPalette.ToolTipValues.Image = global::Krypton.Toolkit.Suite.Extended.Drawing.Utilities.Properties.Resources.palette_load;
            this.kbtnOpenPalette.Values.Image = global::Krypton.Toolkit.Suite.Extended.Drawing.Utilities.Properties.Resources.palette_load;
            this.kbtnOpenPalette.Values.Text = "";
            this.kbtnOpenPalette.Click += new System.EventHandler(this.kbtnOpenPalette_Click);
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
            this.kbtnSavePalette.Click += new System.EventHandler(this.kbtnSavePalette_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.cgColour);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(249, 167);
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
            // ColourGridUserControl
            // 
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ColourGridUserControl";
            this.Size = new System.Drawing.Size(249, 191);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region Properties
        public ColorGrid ColourGrid { get => cgColour; }
        #endregion

        #region Constructors
        public ColourGridUserControl()
        {
            InitializeComponent();
        }
        #endregion

        private void kbtnOpenPalette_Click(object sender, EventArgs e)
        {

        }

        private void kbtnSavePalette_Click(object sender, EventArgs e)
        {

        }
    }
}