using Cyotek.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Extended.Colour.Controls
{
    public class ColourGridDialog : KryptonForm
    {
        #region Designer Code
        private KryptonPanel kryptonPanel1;
        private Cyotek.Windows.Forms.ColorGrid cgColour;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.cgColour = new Cyotek.Windows.Forms.ColorGrid();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.cgColour);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(247, 164);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // cgColour
            // 
            this.cgColour.BackColor = System.Drawing.Color.Transparent;
            this.cgColour.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cgColour.Location = new System.Drawing.Point(0, 0);
            this.cgColour.Name = "cgColour";
            this.cgColour.Size = new System.Drawing.Size(247, 165);
            this.cgColour.TabIndex = 1;
            this.cgColour.AutoAddColorsChanged += new System.EventHandler(this.cgColour_AutoAddColorsChanged);
            this.cgColour.ColorChanged += new System.EventHandler(this.cgColour_ColorChanged);
            // 
            // ColourGridDialog
            // 
            this.ClientSize = new System.Drawing.Size(247, 164);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ColourGridDialog";
            this.Load += new System.EventHandler(this.ColourGridDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region Event
        public delegate void SelectedColourChangedEventHandler(object sender, ColourChangedEventArgs e);

        public event SelectedColourChangedEventHandler SelectedColourChanged;

        protected virtual void OnSelectedColourChanged(object sender, ColourChangedEventArgs e) => SelectedColourChanged?.Invoke(sender, e);
        #endregion

        #region Variables
        private Color _colour;

        private ColorGrid _grid;
        #endregion

        #region Properties
        public Color Colour { get => _colour; set { _colour = value; ColourChangedEventArgs colour = new ColourChangedEventArgs(value); OnSelectedColourChanged(this, colour); } }

        public ColorGrid ColourGrid { get => _grid; private set => _grid = value;  }
        #endregion

        #region Constructors
        public ColourGridDialog()
        {
            InitializeComponent();

            ColourGrid = cgColour;
        }

        public ColourGridDialog(Color colour)
        {
            InitializeComponent();

            ColourGrid = cgColour;

            ColourGrid.AddCustomColor(colour);

            ColourGrid.Color = colour;
        }
        #endregion

        private void ColourGridDialog_Load(object sender, EventArgs e)
        {

        }

        private void cgColour_AutoAddColorsChanged(object sender, EventArgs e)
        {
            AdjustWindow();
        }

        private void AdjustWindow()
        {
            Width = ColourGrid.Width;

            Height = ColourGrid.Height;
        }

        private void cgColour_ColorChanged(object sender, EventArgs e)
        {
            Colour = ColourGrid.Color;
        }
    }
}