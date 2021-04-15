#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Cyotek.Windows.Forms;
using System;
using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Drawing.Suite.Legacy
{
    public class ColourGridWindow : KryptonForm
    {
        #region Designer Code
        private Cyotek.Windows.Forms.ColorGrid cgMain;
        private KryptonPanel kryptonPanel1;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.cgMain = new Cyotek.Windows.Forms.ColorGrid();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.cgMain);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(247, 159);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // cgMain
            // 
            this.cgMain.BackColor = System.Drawing.Color.Transparent;
            this.cgMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cgMain.Location = new System.Drawing.Point(0, 0);
            this.cgMain.Name = "cgMain";
            this.cgMain.Size = new System.Drawing.Size(247, 165);
            this.cgMain.TabIndex = 1;
            this.cgMain.AutoAddColorsChanged += new System.EventHandler(this.CgMain_AutoAddColorsChanged);
            this.cgMain.ColorChanged += new System.EventHandler(this.CgMain_ColorChanged);
            // 
            // ColourGridWindow
            // 
            this.ClientSize = new System.Drawing.Size(247, 159);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ColourGridWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private Color _colour;

        private ColorGrid _grid;
        #endregion

        #region Properties
        public Color Colour { get => _colour; set => _colour = value; }

        public ColorGrid ColourGrid { get => _grid; private set => _grid = value; }
        #endregion

        #region Constructors
        public ColourGridWindow()
        {
            InitializeComponent();

            ColourGrid = cgMain;
        }

        public ColourGridWindow(Color colour)
        {
            InitializeComponent();

            ColourGrid = cgMain;

            ColourGrid.AddCustomColor(colour);

            ColourGrid.Color = colour;
        }
        #endregion

        private void CgMain_AutoAddColorsChanged(object sender, EventArgs e)
        {
            AdjustWindow();
        }

        private void AdjustWindow()
        {
            Height = ColourGrid.Height;
        }

        private void CgMain_ColorChanged(object sender, EventArgs e)
        {
            Colour = ColourGrid.Color;
        }
    }
}